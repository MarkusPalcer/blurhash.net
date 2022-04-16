using System;
using System.Numerics;

namespace Blurhash.Core
{
    /// <summary>
    /// The core decoding algorithm of Blurhash.
    /// To be not specific to any graphics manipulation library this algorithm only operates on <c>double</c> values.
    /// </summary>
    public class CoreDecoder
    {
        /// <summary>
        /// A callback to be called when the progress of the operation changes.
        /// It receives a value between 0.0 and 1.0 that indicates the progress.
        /// </summary>
        public Action<double> ProgressCallback { get; set; }

        /// <summary>
        /// Decodes a Blurhash string into a 2-dimensional array of pixels
        /// </summary>
        /// <param name="blurhash">The blurhash string to decode</param>
        /// <param name="outputWidth">The desired width of the output in pixels</param>
        /// <param name="outputHeight">The desired height of the output in pixels</param>
        /// <param name="punch">A value that affects the contrast of the decoded image. 1 means normal, smaller values will make the effect more subtle, and larger values will make it stronger.</param>
        /// <returns>A 2-dimensional array of <see cref="Pixel"/>s </returns>
        [Obsolete("Use the other version of CoreDecode which will fill a pixel-array in place instead")]
        protected Pixel[,] CoreDecode(string blurhash, int outputWidth, int outputHeight, double punch = 1.0) {
            var pixels = new Pixel[outputWidth, outputHeight];

            CoreDecode(blurhash, pixels, punch);

            return pixels;
        }

        /// <summary>
        /// Decodes a Blurhash string into a 2-dimensional array of pixels
        /// </summary>
        /// <param name="blurhash">The blurhash string to decode</param>
        /// <param name="pixels">
        ///     A two-dimensional array that will be filled with the pixel data.<br />
        ///     First dimension is the width, second dimension is the height
        /// </param>
        /// <param name="punch">A value that affects the contrast of the decoded image. 1 means normal, smaller values will make the effect more subtle, and larger values will make it stronger.</param>
        /// <returns>A 2-dimensional array of <see cref="Pixel"/>s </returns>
        protected void CoreDecode(string blurhash, Pixel[,] pixels, double punch = 1.0)
        {
            if (blurhash.Length < 6) {
                throw new ArgumentException("Blurhash value needs to be at least 6 characters", nameof(blurhash));
            }

            var blurhashSpan = blurhash.AsSpan();

            var outputWidth = pixels.GetLength(0);
            var outputHeight = pixels.GetLength(1);

            var sizeFlag = blurhashSpan.Slice(0, 1).DecodeBase83();

            var componentsY = sizeFlag / 9 + 1;
            var componentsX = sizeFlag % 9 + 1;
            var componentCount = componentsX * componentsY;

            if (blurhash.Length != 4 + 2 * componentsX * componentsY) {
                throw new ArgumentException("Blurhash value is missing data", nameof(blurhash));
            }

            var quantizedMaximumValue = (double) blurhashSpan.Slice(1, 1).DecodeBase83();
            var maximumValue = (quantizedMaximumValue + 1.0) / 166.0;

            var coefficients = new Pixel[componentsX, componentsY];

            var componentIndex = 0;
            for (var yComponent = 0; yComponent < componentsY; yComponent++)
            for (var xComponent = 0; xComponent < componentsX; xComponent++)
            {
                if (xComponent == 0 && yComponent == 0)
                {
                    var value = blurhashSpan.Slice(2, 4).DecodeBase83();
                    coefficients[xComponent, yComponent] = DecodeDc(value);
                }
                else
                {
                    var value = blurhashSpan.Slice(4 + componentIndex * 2, 2).DecodeBase83();
                    coefficients[xComponent, yComponent] = DecodeAc(value, maximumValue * punch);
                }

                componentIndex++;
            }

            for (var xPixel = 0; xPixel < outputWidth; xPixel++)
            for (var yPixel = 0; yPixel < outputHeight; yPixel++)
            {
                ref var result = ref pixels[xPixel, yPixel];

                result.Red = 0.0;
                result.Green = 0.0;
                result.Blue = 0.0;
            }

            var xCosines = new double[outputWidth];
            var yCosines = new double[outputHeight];

            componentIndex = 1;
            for (var componentX = 0; componentX < componentsX; componentX++)
            for (var componentY = 0; componentY < componentsY; componentY++)
            {
                for (var xPixel = 0; xPixel < outputWidth; xPixel++)
                {
                    xCosines[xPixel] = Math.Cos((Math.PI * xPixel * componentX) / outputWidth);
                }

                for (var yPixel = 0; yPixel < outputHeight; yPixel++)
                {
                    yCosines[yPixel] = Math.Cos((Math.PI * yPixel * componentY) / outputHeight);
                }

                var coefficient = coefficients[componentX, componentY];

                for (var xPixel = 0; xPixel < outputWidth; xPixel++)
                for (var yPixel = 0; yPixel < outputHeight; yPixel++)
                {
                    ref var result = ref pixels[xPixel, yPixel];

                    var basis = xCosines[xPixel] * yCosines[yPixel];

                    result.Red += coefficient.Red * basis;
                    result.Green += coefficient.Green * basis;
                    result.Blue += coefficient.Blue * basis;
                }

                ProgressCallback?.Invoke((double) componentIndex / componentCount);
                componentIndex++;
            }
        }

        private static Pixel DecodeDc(BigInteger value)
        {
            var intR = (int)value >> 16;
            var intG = (int)(value >> 8) & 255;
            var intB = (int)value & 255;
            return new Pixel(MathUtils.SRgbToLinear(intR), MathUtils.SRgbToLinear(intG), MathUtils.SRgbToLinear(intB));
        }

        private static Pixel DecodeAc(BigInteger value, double maximumValue) {
            var quantizedR = (double) (value / (19 * 19));
            var quantizedG = (double) ((value / 19) % 19);
            var quantizedB = (double) (value % 19);

            var result = new Pixel(
                MathUtils.SignPow((quantizedR - 9.0) / 9.0, 2.0) * maximumValue, 
                MathUtils.SignPow((quantizedG - 9.0) / 9.0, 2.0) * maximumValue,
                MathUtils.SignPow((quantizedB - 9.0) / 9.0, 2.0) * maximumValue
                );

            return result;
        }

    }
}
