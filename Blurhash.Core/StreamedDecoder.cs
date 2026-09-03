using System;

namespace Blurhash;

public class StreamedDecoder
{
    private readonly string blurhash;
    private readonly int outputWidth;
    private readonly int outputHeight;
    private readonly ResultCallback resultCallback;
    private readonly double punch;
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
        this.punch = punch;
        this.progressCallback = progressCallback;
    }
    
    public void Decode()
    {
        var blurhashSpan = blurhash.AsSpan();

        var pixels = new Pixel[outputWidth, outputHeight];

        var sizeFlag = blurhashSpan.Slice(0, 1).DecodeBase83();

        var componentsY = sizeFlag / 9 + 1;
        var componentsX = sizeFlag % 9 + 1;
        var componentCount = componentsX * componentsY;

        if (blurhash.Length != 4 + 2 * componentsX * componentsY)
        {
            throw new ArgumentException("Blurhash value is missing data", nameof(blurhash));
        }

        var quantizedMaximumValue = (double)blurhashSpan.Slice(1, 1).DecodeBase83();
        var maximumValue = (quantizedMaximumValue + 1.0) / 166.0;

        var coefficients = new Pixel[componentsX, componentsY];

        var componentIndex = 0;
        for (var yComponent = 0; yComponent < componentsY; yComponent++)
        for (var xComponent = 0; xComponent < componentsX; xComponent++)
        {
            if (xComponent == 0 && yComponent == 0)
            {
                var value = blurhashSpan.Slice(2, 4).DecodeBase83();
                coefficients[xComponent, yComponent] = Core.DecodeDc(value);
            }
            else
            {
                var value = blurhashSpan.Slice(4 + componentIndex * 2, 2).DecodeBase83();
                coefficients[xComponent, yComponent] = Core.DecodeAc(value, maximumValue * punch);
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

            progressCallback?.Report(componentIndex * 100 / componentCount);
            componentIndex++;
        }
        
        Span<StreamedPixel> buffer = stackalloc StreamedPixel[outputHeight];
        
        for (var xPixel = 0; xPixel < outputWidth; xPixel++)
        {
            for (var yPixel = 0; yPixel < outputHeight; yPixel++)
            {
                buffer[yPixel].Red = pixels[xPixel, yPixel].Red;
                buffer[yPixel].Green = pixels[xPixel, yPixel].Green;
                buffer[yPixel].Blue = pixels[xPixel, yPixel].Blue;
                buffer[yPixel].X = xPixel;
                buffer[yPixel].Y = yPixel;
            }
            
            resultCallback(buffer);
        }
    }
}