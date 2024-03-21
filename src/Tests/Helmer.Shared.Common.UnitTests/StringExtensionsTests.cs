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
}