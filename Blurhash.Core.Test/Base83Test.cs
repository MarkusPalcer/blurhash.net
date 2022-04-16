using System;
using FluentAssertions;
using Xunit;

namespace Blurhash.Core.Test
{
    public class Base83Test
    {
        [Theory]
        [InlineData(1092, "DD")]
        [InlineData(1092, "00DD")]
        [InlineData(1337, "G9")]
        [InlineData(1337, "00G9")]
        [InlineData(83, "10")]
        [InlineData(83, "010")]
        public void EncodingTests(int value, string expectation)
        {
            Span<char> output = stackalloc char[expectation.Length];
            value.EncodeBase83(output);
        }

        [Fact]
        public void EncodingSingleDigitsTests()
        {
            Span<char> singleOutput = stackalloc char[1];
            Span<char> doubleOutput = stackalloc char[2];

            for (var i = 0; i < 83; i++)
            {
                i.EncodeBase83(singleOutput);
                new string(singleOutput).Should().BeEquivalentTo(new string(Base83.Charset[i], 1));
                i.EncodeBase83(doubleOutput);
                new string(doubleOutput).Should().BeEquivalentTo(new string(new[] {'0', Base83.Charset[i]}));
            }
        }

        [Theory]
        [InlineData("10", 83)]
        [InlineData("010", 83)]
        [InlineData("DD", 1092)]
        [InlineData("0DD", 1092)]
        [InlineData("G9", 1337)]
        [InlineData("0G9", 1337)]
        public void DecodingTests(string input, int expected)
        {
            Base83.DecodeBase83(input.ToCharArray()).Should().Be(expected);
        }

        [Fact]
        public void DecodingEachDigitTest()
        {
            for (var i = 0; i < 83; i++)
            {
                var data = new[] { '0', Base83.Charset[i] }.AsSpan();
                Base83.DecodeBase83(data).Should().Be(i);
                Base83.DecodeBase83(data.Slice(1,1)).Should().Be(i);
            }
        }

    }
}
