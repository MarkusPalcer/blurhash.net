namespace Blurhash;

/// <summary>
/// Represents a pixel within the Blurhash algorithm
/// </summary>
public struct Pixel(double red, double green, double blue)
{
    public double Red = red;
    public double Green = green;
    public double Blue = blue;
}