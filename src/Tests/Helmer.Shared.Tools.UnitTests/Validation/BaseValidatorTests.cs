using Helmer.Shared.Tools.UnitTests.TestData;
using Helmer.Shared.Tools.Validation;

namespace Helmer.Shared.Tools.UnitTests.Validation;

public class BaseValidatorTests
{
	[Fact]
	public void IsValid_WithValidModel_ReturnsTrue()
	{
		// Arrange
		var validator = new BaseValidator<TestModel>();
		var model = new TestModel
		{
			Name = "Test"
		};

		// Act
		var result = validator.IsValid(model);

		// Assert
		Assert.True(result);
	}
}
