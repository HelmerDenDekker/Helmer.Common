using Helmer.Shared.Common.Extensions;

namespace Helmer.Shared.Common.UnitTests;

public class StringExtensionsTests
{
    [Fact]
    public void CropStringWithEllipsis_InputLengthLessThanDesiredLength_ReturnsInput()
    {
        // Arrange
        var input = "Short string";
        var desiredLength = 20;

        // Act
        var result = input.CropStringWithEllipsis(desiredLength);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void CropStringWithEllipsis_InputLengthGreaterThanDesiredLength_ReturnsCroppedStringWithEllipsis()
    {
        // Arrange
        var input = "This is a long string that needs to be cropped";
        var desiredLength = 20;

        // Act
        var result = input.CropStringWithEllipsis(desiredLength);

        // Assert
        Assert.True(result.Length <= desiredLength);
        Assert.EndsWith("...", result);
    }
    
    [Fact]
    public void String_FirstToUpperAllLower_ShouldReturnFirstAsUpper()
    {
        // Arrange

        var input = "test";

        // Act

        var result = input.FirstToUpper();

        // Assert

        Assert.Equal("Test", result);
    }

    [Fact]
    public void String_FirstToUpperAllCaps_ShouldReturnFirstAsUpper()
    {
        // Arrange

        var input = "TEST";

        // Act

        var result = input.FirstToUpper();

        // Assert

        Assert.Equal("Test", result);
    }

    [Fact]
    public void String_FirstToUpperEmptyString_ShouldReturnEmptyString()
    {
        // Arrange

        var input = string.Empty;

        // Act

        var result = input.FirstToUpper();

        // Assert

        Assert.Equal(input, result);
    }
}