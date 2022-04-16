using Blurhash.Core;

namespace Benchmarks.Helpers;

public class CoreDecoderHelper : CoreDecoder
{
    public void Decode(string blurhash, Pixel[,] pixels, double punch = 1.0)
    {
        CoreDecode(blurhash, pixels, punch);
    }
}
