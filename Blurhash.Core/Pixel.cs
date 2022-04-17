namespace Blurhash
{
    /// <summary>
    /// Represents a pixel within the Blurhash algorithm
    /// </summary>
    public struct Pixel
    {
        public double Red;
        public double Green;
        public double Blue;

        public Pixel(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
