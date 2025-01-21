using Xunit;

namespace TP_1.Tests;

public class RomanConverterTests
{
    [Theory]
    [InlineData("I", 1)]
    [InlineData("V", 5)]
    [InlineData("X", 10)]
    [InlineData("L", 50)]
    [InlineData("C", 100)]
    [InlineData("D", 500)]
    [InlineData("M", 1000)]
    [InlineData("G", 5000)]
    [InlineData("H", 10000)]
    [InlineData("J", 50000)]
    [InlineData("K", 100000)]
    [InlineData("F", 500000)]
    [InlineData("P", 1000000)]
    public void ConvertRomanToArabicNumbers_SingleCharacter_ReturnsCorrectValue(string roman, int expected)
    {
        int result = RomanConverter.ConvertRomanToArabicNumbers(roman);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("IV", 4)]      // 5 - 1
    [InlineData("IX", 9)]      // 10 - 1
    [InlineData("XL", 40)]     // 50 - 10
    [InlineData("XC", 90)]     // 100 - 10
    [InlineData("CD", 400)]    // 500 - 100
    [InlineData("CM", 900)]    // 1000 - 100
    [InlineData("IM", 999)]    // 1000 - 1
    [InlineData("XM", 990)]    // 1000 - 10
    [InlineData("IH", 9999)]   // 10000 - 10
    [InlineData("XP", 999990)] // 1000000 - 10
    public void ConvertRomanToArabicNumbers_SubtractionCases_ReturnsCorrectValue(string roman, int expected)
    {
        int result = RomanConverter.ConvertRomanToArabicNumbers(roman);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("MMXXIV", 2024)]
    [InlineData("MCMLXXXIX", 1989)]
    [InlineData("MMMDCCCLXXXVIII", 3888)]
    [InlineData("HG", 15000)]           // 5000 + 10000
    [InlineData("HGDCCLXXVII", 15777)]  // (5000 + 10000) + 500 + 200 + 70 + 7
    [InlineData("KKK", 300000)]         // 100000 + 100000 + 100000
    public void ConvertRomanToArabicNumbers_ComplexNumbers_ReturnsCorrectValue(string roman, int expected)
    {
        int result = RomanConverter.ConvertRomanToArabicNumbers(roman);
        Assert.Equal(expected, result);
    } 

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ConvertRomanToArabicNumbers_EmptyOrWhitespace_ThrowsArgumentException(string roman)
    {
        Assert.Throws<ArgumentException>(() => RomanConverter.ConvertRomanToArabicNumbers(roman));
    }

    [Theory]
    [InlineData("ABC")]
    [InlineData("123")]
    [InlineData("XVI2")]
    public void ConvertRomanToArabicNumbers_InvalidCharacters_ThrowsArgumentException(string roman)
    {
        Assert.Throws<ArgumentException>(() => RomanConverter.ConvertRomanToArabicNumbers(roman));
    }

    [Fact]
    public void GetValueDescription_ValidSymbol_ReturnsCorrectDescription()
    {
        string description = RomanConverter.GetValueDescription('M');
        Assert.Equal("1 000", description);
    }

    [Fact]
    public void GetValueDescription_InvalidSymbol_ReturnsUnknownMessage()
    {
        string description = RomanConverter.GetValueDescription('Z');
        Assert.Equal("Symbole inconnu", description);
    }

    [Fact]
    public void GetAllSymbols_ReturnsCorrectNumberOfSymbols()
    {
        var symbols = RomanConverter.GetAllSymbols();
        Assert.Equal(13, symbols.Count);
    }
}