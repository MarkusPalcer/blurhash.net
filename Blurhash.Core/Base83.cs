using System;
using System.Collections.Generic;

namespace Blurhash.Core
{
    /// <summary>
    /// Contains methods to encode or decode integers to Base83-Strings
    /// </summary>
    public static class Base83
    {
        internal const string Charset = @"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#$%*+,-.:;=?@[]^_{|}~";

        private static readonly IReadOnlyDictionary<char, int> ReverseLookup;

        static Base83()
        {
            // Build inverse lookup table for fast decoding
            var charIndices = new Dictionary<char, int>();
            var index = 0;
            foreach (var c in Charset)
            {
                charIndices[c] = index;
                index++;
            }

            ReverseLookup = charIndices;
        }

        /// <summary>
        /// Encodes a number into its Base83-representation
        /// </summary>
        /// <param name="number">The number to encode</param>
        /// <param name="output">The data buffer to put the result data into</param>
        /// <returns>The Base83-representation of the number</returns>
        public static void EncodeBase83(this int number, Span<char> output)
        {
            var length = output.Length;
            for(var i = 0; i < length; i++)
            {
                var digit = number % 83;
                number /= 83;
                output[length - i - 1] = Charset[digit];
            }
        }

        /// <summary>
        /// Decodes an <code>IEnumerable</code> of Base83-characters into the integral value it represents
        /// </summary>
        /// <param name="base83Data">The characters to decode</param>
        /// <returns>The decoded value as integer</returns>
        public static int DecodeBase83(this ReadOnlySpan<char> base83Data)
        {
            var result = 0;
            foreach (var c in base83Data)
            {
                if (!ReverseLookup.TryGetValue(c, out var digit))
                {
                    throw new ArgumentException("The given string contains invalid characters.", nameof(base83Data));
                }

                result *= 83;
                result += digit;
            }

            return result;
        }
    }
}
