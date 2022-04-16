using Blurhash.Core;

namespace Benchmarks.Helpers;

public class CoreEncoderHelper : CoreEncoder
{
    public string Encode(Pixel[,] pixels, int componentsX, int componentsY)
    {
        return CoreEncode(pixels, componentsX, componentsY);
    }
}
