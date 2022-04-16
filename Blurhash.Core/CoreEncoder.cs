using System;

namespace Blurhash.Core
{
    /// <summary>
    /// The core encoding algorithm of Blurhash.
    /// To be not specific to any graphics manipulation library this algorithm only operates on <c>double</c> values.
    /// </summary>
    public class CoreEncoder
    {
        /// <summary>
        /// A callback to be called when the progress of the operation changes.
        /// It receives a value between 0.0 and 1.0 that indicates the progress.
        /// </summary>
        public Action<double> ProgressCallback { get; set; }

        /// <summary>
        /// Encodes a 2-dimensional array of pixels into a Blurhash string
        /// </summary>
        /// <param name="pixels">The 2-dimensional array of pixels to encode</param>
        /// <param name="componentsX">The number of components used on the X-Axis for the DCT</param>
        /// <param name="componentsY">The number of components used on the Y-Axis for the DCT</param>
        /// <returns>The resulting Blurhash string</returns>
        protected string CoreEncode(Pixel[,] pixels, int componentsX, int componentsY)
        {
            if (componentsX < 1) throw new ArgumentException("componentsX needs to be at least 1");
            if (componentsX > 9) throw new ArgumentException("componentsX needs to be at most 9");
            if (componentsY < 1) throw new ArgumentException("componentsY needs to be at least 1");
            if (componentsY > 9) throw new ArgumentException("componentsY needs to be at most 9");

            Span<Pixel> factors = stackalloc Pixel[componentsX * componentsY];
            Span<char> resultBuffer = stackalloc char[4 + 2 * componentsX * componentsY];

            var factorCount = componentsX * componentsY;
            var processedFactors = 0;

            var width = pixels.GetLength(0);
            var height = pixels.GetLength(1);

            var xCosines = new double[width];
            var yCosines = new double[height];

            for(var yComponent = 0; yComponent < componentsY; yComponent++)
            for(var xComponent = 0; xComponent < componentsX; xComponent++)
            {
                double r = 0, g = 0, b = 0;
                double normalization = (xComponent == 0 && yComponent == 0) ? 1 : 2;

                for (var xPixel = 0; xPixel < width; xPixel++)
                {
                    xCosines[xPixel] = Math.Cos(Math.PI * xComponent * xPixel / width);
                }

                for (var yPixel = 0; yPixel < height; yPixel++)
                {
                    yCosines[yPixel] = Math.Cos(Math.PI * yComponent * yPixel / height);
                }

                for(var xPixel = 0; xPixel < width; xPixel++)
                for(var yPixel = 0; yPixel < height; yPixel++)
                {
                    var basis = xCosines[xPixel] * yCosines[yPixel];
                    var pixel = pixels[xPixel,yPixel];
                    r += basis * pixel.Red;
                    g += basis * pixel.Green;
                    b += basis * pixel.Blue;
                }

                var scale = normalization / (width * height);
                factors[componentsX * yComponent + xComponent].Red = r * scale;
                factors[componentsX * yComponent + xComponent].Green = g * scale;
                factors[componentsX * yComponent + xComponent].Blue = b * scale;

                ProgressCallback?.Invoke((double) processedFactors / factorCount);
                processedFactors++;
            }

            var dc = factors[0];
            var acCount = componentsX * componentsY - 1;

            var sizeFlag = (componentsX - 1) + (componentsY - 1) * 9;
            sizeFlag.EncodeBase83(resultBuffer.Slice(0, 1));

            float maximumValue;
            if(acCount > 0)
            {
                // Get maximum absolute value of all AC components
                var actualMaximumValue = 0.0;
                for (var yComponent = 0; yComponent < componentsY; yComponent++)
                for (var xComponent = 0; xComponent < componentsX; xComponent++)
                {
                    // Ignore DC component
                    if (xComponent == 0 && yComponent == 0) continue;

                    var factorIndex = componentsX * yComponent + xComponent;

                    actualMaximumValue = Math.Max(Math.Abs(factors[factorIndex].Red), actualMaximumValue);
                    actualMaximumValue = Math.Max(Math.Abs(factors[factorIndex].Green), actualMaximumValue);
                    actualMaximumValue = Math.Max(Math.Abs(factors[factorIndex].Blue), actualMaximumValue);
                }

                var quantizedMaximumValue = (int) Math.Max(0.0, Math.Min(82.0, Math.Floor(actualMaximumValue * 166 - 0.5)));
                maximumValue = ((float)quantizedMaximumValue + 1) / 166;
                quantizedMaximumValue.EncodeBase83(resultBuffer.Slice(1, 1));
            } else {
                maximumValue = 1;
                resultBuffer[1] = '0';
            }

            EncodeDc(dc.Red, dc.Green, dc.Blue).EncodeBase83(resultBuffer.Slice(2, 4));

            for (var yComponent = 0; yComponent < componentsY; yComponent++)
            for (var xComponent = 0; xComponent < componentsX; xComponent++)
            {
                // Ignore DC component
                if (xComponent == 0 && yComponent == 0) continue;

                var factorIndex = componentsX * yComponent + xComponent;

                EncodeAc(factors[factorIndex].Red, factors[factorIndex].Green, factors[factorIndex].Blue, maximumValue).EncodeBase83(resultBuffer.Slice(6 + (factorIndex - 1) * 2, 2));
            }

            return resultBuffer.ToString();
        }

        private static int EncodeAc(double r, double g, double b, double maximumValue) {
            var quantizedR = (int) Math.Max(0, Math.Min(18, Math.Floor(MathUtils.SignPow(r / maximumValue, 0.5) * 9 + 9.5)));
            var quantizedG = (int) Math.Max(0, Math.Min(18, Math.Floor(MathUtils.SignPow(g / maximumValue, 0.5) * 9 + 9.5)));
            var quantizedB = (int) Math.Max(0, Math.Min(18, Math.Floor(MathUtils.SignPow(b / maximumValue, 0.5) * 9 + 9.5)));

            return quantizedR * 19 * 19 + quantizedG * 19 + quantizedB;
        }

        private static int EncodeDc(double r, double g, double b) {
            var roundedR = MathUtils.LinearTosRgb(r);
            var roundedG = MathUtils.LinearTosRgb(g);
            var roundedB = MathUtils.LinearTosRgb(b);
            return (roundedR << 16) + (roundedG << 8) + roundedB;
        }
    }
}
