using Helmer.Shared.Common.Extensions;

namespace Helmer.Shared.Common.UnitTests;

public class ResultExtensionsTests
{
	[Fact]
	public void AddMessage_WithMessage_AddsMessageToResult()
	{
		// Arrange
		var result = Result.BadRequest;
		var message = "Test message";

		// Act
		result.AddMessage(message);

		// Assert
		Assert.True(result.Messages.Contains(message));
	}
}
