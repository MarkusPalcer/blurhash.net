﻿using System;
using System.Linq;
using System.Net.Mime;
using Blurhash.Core;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Blurhash.ImageSharp
{
    public class Decoder : CoreDecoder
    {
        /// <summary>
        /// Decodes a Blurhash string into a <c>System.Drawing.Image</c>
        /// </summary>
        /// <param name="blurhash">The blurhash string to decode</param>
        /// <param name="outputWidth">The desired width of the output in pixels</param>
        /// <param name="outputHeight">The desired height of the output in pixels</param>
        /// <param name="punch">A value that affects the contrast of the decoded image. 1 means normal, smaller values will make the effect more subtle, and larger values will make it stronger.</param>
        /// <returns>The decoded preview</returns>
        public Image<Rgba32> Decode(string blurhash, int outputWidth, int outputHeight, double punch = 1.0)
        {
            var pixelData = base.CoreDecode(blurhash, outputWidth, outputHeight, punch);
            return ConvertToBitmap(pixelData);
        }

        /// <summary>
        /// Converts the library-independent representation of pixels into a bitmap
        /// </summary>
        /// <param name="pixelData">The library-independent representation of the image</param>
        /// <returns>A <c>System.Drawing.Bitmap</c> in 32bpp-RGB representation</returns>
        internal static Image<Rgba32> ConvertToBitmap(Blurhash.Core.Pixel[,] pixelData)
        {
            var width = pixelData.GetLength(0);
            var height = pixelData.GetLength(1);

            var data = Enumerable.Range(0, height)
                .SelectMany(y => Enumerable.Range(0, width).Select(x => (x, y)))
                .Select(tuple => pixelData[tuple.x, tuple.y])
                .SelectMany(pixel => new byte[]
                {
                    (byte) MathUtils.LinearTosRgb(pixel.Red), (byte) MathUtils.LinearTosRgb(pixel.Green),
                    (byte) MathUtils.LinearTosRgb(pixel.Blue), 255
                })
                .ToArray();

            return Image.LoadPixelData<Rgba32>(data.AsSpan(), width, height);
        }
    }
}