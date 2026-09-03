using System;

namespace Blurhash;

public class StreamedDecoder
{
    private readonly string blurhash;

    private readonly int outputWidth;
    private readonly int outputHeight;

    private int componentsY;
    private int componentsX;

    private double maximumValue;
    private Pixel[,] coefficients;

    private double[,] xCosines;
    private double[,] yCosines;

    private readonly ResultCallback resultCallback;
    private readonly IProgress<int>? progressCallback;

    public delegate void ResultCallback(ReadOnlySpan<StreamedPixel> pixels);

    public StreamedDecoder(string blurhash,
        int outputWidth,
        int outputHeight,
        ResultCallback resultCallback,
        double punch = 1.0,
        IProgress<int>? progressCallback = null)
    {
        if (blurhash.Length < 6)
        {
            throw new ArgumentException("Blurhash value needs to be at least 6 characters", nameof(blurhash));
        }

        this.blurhash = blurhash;
        this.outputWidth = outputWidth;
        this.outputHeight = outputHeight;
        this.resultCallback = resultCallback;
        this.progressCallback = progressCallback;

        DecodeComponentCount();
        DecodeMaximumValue();
        DecodeCoefficients(punch);
        CreateCosines();
    }

    private void CreateCosines()
    {
        xCosines = new double[componentsX, outputWidth];
        yCosines = new double[componentsY, outputHeight];

        for (var componentX = 0; componentX < componentsX; componentX++)
        for (var componentY = 0; componentY < componentsY; componentY++)
        {
            for (var xPixel = 0; xPixel < outputWidth; xPixel++)
            {
                xCosines[componentX, xPixel] = Math.Cos((Math.PI * xPixel * componentX) / outputWidth);
            }

            for (var yPixel = 0; yPixel < outputHeight; yPixel++)
            {
                yCosines[componentY, yPixel] = Math.Cos((Math.PI * yPixel * componentY) / outputHeight);
            }
        }
    }

    private void DecodeCoefficients(double punch)
    {
        coefficients = new Pixel[componentsX, componentsY];
        var componentIndex = 0;
        for (var yComponent = 0; yComponent < componentsY; yComponent++)
        for (var xComponent = 0; xComponent < componentsX; xComponent++)
        {
            if (xComponent == 0 && yComponent == 0)
            {
                var value = blurhash.AsSpan().Slice(2, 4).DecodeBase83();
                coefficients[xComponent, yComponent] = Core.DecodeDc(value);
            }
            else
            {
                var value = blurhash.AsSpan().Slice(4 + componentIndex * 2, 2).DecodeBase83();
                coefficients[xComponent, yComponent] = Core.DecodeAc(value, maximumValue * punch);
            }

            componentIndex++;
        }
    }

    private void DecodeMaximumValue()
    {
        var quantizedMaximumValue = (double)blurhash.AsSpan().Slice(1, 1).DecodeBase83();
        maximumValue = (quantizedMaximumValue + 1.0) / 166.0;
    }

    private void DecodeComponentCount()
    {
        var sizeFlag = blurhash.AsSpan().Slice(0, 1).DecodeBase83();
        componentsY = sizeFlag / 9 + 1;
        componentsX = sizeFlag % 9 + 1;
        if (blurhash.Length != 4 + 2 * componentsX * componentsY)
        {
            throw new ArgumentException("Blurhash value is missing data", nameof(blurhash));
        }
    }

    public void Decode()
    {
        Span<StreamedPixel> pixels = stackalloc StreamedPixel[outputHeight];

        for (var xPixel = 0; xPixel < outputWidth; xPixel++)
        for (var yPixel = 0; yPixel < outputHeight; yPixel++)
        {
            ref var result = ref pixels[yPixel];
            
            result.Red = 0.0;
            result.Green = 0.0;
            result.Blue = 0.0;
            result.X = xPixel;
            result.Y = yPixel;

            for (var componentX = 0; componentX < componentsX; componentX++)
            for (var componentY = 0; componentY < componentsY; componentY++)
            {
                var coefficient = coefficients[componentX, componentY];
                {
                    var basis = xCosines[componentX, xPixel] * yCosines[componentY, yPixel];
                    result.Red += coefficient.Red * basis;
                    result.Green += coefficient.Green * basis;
                    result.Blue += coefficient.Blue * basis;
                }
            }

            resultCallback(pixels);

            progressCallback?.Report(xPixel * 100 / outputWidth);
        }
    }
}