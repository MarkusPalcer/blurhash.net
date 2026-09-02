using System;

namespace Blurhash;

/// <summary>
/// This class provides functionality to encode large images into Blurhash strings by sending pixels into the encoder and getting the result at the end.
/// </summary>
/// <remarks>
/// <b>Important:</b> The <c>LargeImageEncoder</c> class does not check if you provided all pixels or sent duplicate pixels. If you do so, your blurhash string will be wrong.
/// </remarks>
public class LargeImageEncoder
{
    private readonly int componentsX;
    private readonly int componentsY;
    private readonly int width;
    private readonly int height;
    private readonly int size;
    private int processedPixels;
    private readonly IProgress<int>? progressCallback;
    private readonly Pixel[] factors;
    private readonly char[] resultBuffer;
    private readonly double[] xCosines;
    private readonly double[] yCosines;

    /// <summary>
    /// This class provides functionality to encode large images into Blurhash strings by sending pixels into the encoder and getting the result at the end.
    /// </summary>
    /// <remarks>
    /// <b>Important:</b> The <c>LargeImageEncoder</c> class does not check if you provided all pixels or sent duplicate pixels. If you do so, your blurhash string will be wrong.
    /// </remarks>
    public LargeImageEncoder(int componentsX, int componentsY, int width, int height, IProgress<int>? progressCallback)
    {
        if (componentsX < 1) throw new ArgumentException("componentsX needs to be at least 1");
        if (componentsX > 9) throw new ArgumentException("componentsX needs to be at most 9");
        if (componentsY < 1) throw new ArgumentException("componentsY needs to be at least 1");
        if (componentsY > 9) throw new ArgumentException("componentsY needs to be at most 9");

        this.componentsX = componentsX;
        this.componentsY = componentsY;
        this.width = width;
        this.height = height;
        size = width * height;
        this.progressCallback = progressCallback;
        factors = new Pixel[this.componentsX * this.componentsY];
        resultBuffer = new char[4 + 2 * this.componentsX * this.componentsY];
        xCosines = new double[componentsX * width];
        yCosines = new double[componentsY * height];
        
        for (var yComponent = 0; yComponent < componentsY; yComponent++)
        for (var xComponent = 0; xComponent < componentsX; xComponent++)
        {
            for (var xPixel = 0; xPixel < width; xPixel++)
            {
                xCosines[xComponent * width + xPixel] = Math.Cos(Math.PI * xComponent * xPixel / width);
            }

            for (var yPixel = 0; yPixel < height; yPixel++)
            {
                yCosines[yComponent * height + yPixel] = Math.Cos(Math.PI * yComponent * yPixel / height);
            }
        }
    }

    /// <summary>
    /// Encodes a 2-dimensional array of pixels into a Blurhash string
    /// </summary>
    /// <param name="pixels">The 2-dimensional array of pixels to encode</param>
    /// <param name="componentsX">The number of components used on the X-Axis for the DCT</param>
    /// <param name="componentsY">The number of components used on the Y-Axis for the DCT</param>
    /// <param name="progressCallback">An optional progress handler to receive progress updates</param>
    /// <returns>The resulting Blurhash string</returns>
    public static string Encode(Pixel[,] pixels,
        int componentsX,
        int componentsY,
        IProgress<int>? progressCallback = null)
    {
        var width = pixels.GetLength(0);
        var height = pixels.GetLength(1);

        var encoder = new LargeImageEncoder(componentsX, componentsY, width, height, progressCallback);

        return encoder.Encode(pixels);
    }

    public void AddPixels(Span<StreamedPixel> pixels)
    {
        for (var i = 0; i < pixels.Length; i++)
        {
            var pixel = pixels[i];
            var xPixel = pixel.X;
            var yPixel = pixel.Y;
            
            for (var yComponent = 0; yComponent < componentsY; yComponent++)
            for (var xComponent = 0; xComponent < componentsX; xComponent++)
            {
                double normalization = (xComponent == 0 && yComponent == 0) ? 1 : 2;
                var scale = normalization / (width * height);

                var basis = xCosines[xComponent * width + xPixel] * yCosines[yComponent * height + yPixel];
                var r = basis * pixel.Red;
                var g = basis * pixel.Green;
                var b = basis * pixel.Blue;

                factors[componentsX * yComponent + xComponent].Red += r * scale;
                factors[componentsX * yComponent + xComponent].Green += g * scale;
                factors[componentsX * yComponent + xComponent].Blue += b * scale;

                progressCallback?.Report(processedPixels * 100 / size);
                processedPixels++;
            }
        }
    }

    public string Finish()
    {
        var dc = factors[0];
        var acCount = componentsX * componentsY - 1;

        var sizeFlag = (componentsX - 1) + (componentsY - 1) * 9;
        sizeFlag.EncodeBase83(resultBuffer.AsSpan().Slice(0, 1));

        float maximumValue;
        if (acCount > 0)
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

            var quantizedMaximumValue = (int)Math.Max(0.0, Math.Min(82.0, Math.Floor(actualMaximumValue * 166 - 0.5)));
            maximumValue = ((float)quantizedMaximumValue + 1) / 166;
            quantizedMaximumValue.EncodeBase83(resultBuffer.AsSpan().Slice(1, 1));
        }
        else
        {
            maximumValue = 1;
            resultBuffer[1] = '0';
        }

        Core.EncodeDc(dc.Red, dc.Green, dc.Blue).EncodeBase83(resultBuffer.AsSpan().Slice(2, 4));

        for (var yComponent = 0; yComponent < componentsY; yComponent++)
        for (var xComponent = 0; xComponent < componentsX; xComponent++)
        {
            // Ignore DC component
            if (xComponent == 0 && yComponent == 0) continue;

            var factorIndex = componentsX * yComponent + xComponent;

            Core.EncodeAc(factors[factorIndex].Red, factors[factorIndex].Green, factors[factorIndex].Blue, maximumValue)
                .EncodeBase83(resultBuffer.AsSpan().Slice(6 + (factorIndex - 1) * 2, 2));
        }

        return resultBuffer.AsSpan().ToString();
    }
    
    public string Encode(Pixel[,] pixels)
    {
        Span<StreamedPixel> pixelBuffer = stackalloc StreamedPixel[height];
        for (var xPixel = 0; xPixel < width; xPixel++)
        {
            for (var yPixel = 0; yPixel < height; yPixel++)
            {
                var pixel = pixels[xPixel, yPixel];
                pixelBuffer[yPixel] = new StreamedPixel(pixel.Red, pixel.Green, pixel.Blue, xPixel, yPixel);
            }
            
            AddPixels(pixelBuffer);
        }

        return Finish();
    }
}