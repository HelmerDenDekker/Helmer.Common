using System.Net;
using Helmer.Shared.Common.Extensions;

namespace Helmer.Shared.Common.UnitTests;

public class ResultExtensionsTests
{
	[Fact]
	public void IsSuccess_WhenResultIsOk_ReturnsTrue()
	{
		// Arrange
		var result = Result.Ok;

		// Act
		var isSucces = result.IsSuccess();

		// Assert
		Assert.True(isSucces);
	}

	[Fact]
	public void IsSuccess_WhenResultIsCreated_ReturnsTrue()
	{
		// Arrange
		var result = Result.Created;

		// Act
		var isSucces = result.IsSuccess();

		// Assert
		Assert.True(isSucces);
	}

	[Fact]
	public void IsSuccess_WhenResultIsNoContent_ReturnsTrue()
	{
		// Arrange
		var result = Result.NoContent;

		// Act
		var isSucces = result.IsSuccess();

		// Assert
		Assert.True(isSucces);
	}

	[Theory]
	[InlineData(Result.BadRequest)]
	[InlineData(Result.Unauthorized)]
	[InlineData(Result.Forbidden)]
	[InlineData(Result.NotFound)]
	[InlineData(Result.NotAcceptable)]
	[InlineData(Result.Timeout)]
	[InlineData(Result.Conflict)]
	[InlineData(Result.InsecureUrl)]
	[InlineData(Result.UnavailableForLegalReasons)]
	[InlineData(Result.InternalServerError)]
	[InlineData(Result.NotImplemented)]
	public void IsSuccess_WhenResultIsNotOkOrCreatedOrNoContent_ReturnsFalse(Result result)
	{
		// Arrange

		// Act
		var isSucces = result.IsSuccess();

		// Assert
		Assert.False(isSucces);
	}

	[Fact]
	public void StatusCode_WhenResultIsOk_ReturnsHttpStatusCodeOk()
	{
		// Arrange
		var result = Result.Ok;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.OK, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsCreated_ReturnsHttpStatusCodeCreated()
	{
		// Arrange
		var result = Result.Created;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.Created, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsNoContent_ReturnsHttpStatusCodeNoContent()
	{
		// Arrange
		var result = Result.NoContent;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.NoContent, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsBadRequest_ReturnsHttpStatusCodeBadRequest()
	{
		// Arrange
		var result = Result.BadRequest;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.BadRequest, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsUnauthorized_ReturnsHttpStatusCodeUnauthorized()
	{
		// Arrange
		var result = Result.Unauthorized;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsForbidden_ReturnsHttpStatusCodeForbidden()
	{
		// Arrange
		var result = Result.Forbidden;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.Forbidden, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsNotFound_ReturnsHttpStatusCodeNotFound()
	{
		// Arrange
		var result = Result.NotFound;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.NotFound, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsNotAcceptable_ReturnsHttpStatusCodeNotAcceptable()
	{
		// Arrange
		var result = Result.NotAcceptable;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.NotAcceptable, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsTimeout_ReturnsHttpStatusCodeRequestTimeout()
	{
		// Arrange
		var result = Result.Timeout;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.RequestTimeout, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsConflict_ReturnsHttpStatusCodeConflict()
	{
		// Arrange
		var result = Result.Conflict;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.Conflict, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsInsecureUrl_ReturnsHttpStatusCodeUpgradeRequired()
	{
		// Arrange
		var result = Result.InsecureUrl;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.UpgradeRequired, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsUnavailableForLegalReasons_ReturnsHttpStatusCodeUnavailableForLegalReasons()
	{
		// Arrange
		var result = Result.UnavailableForLegalReasons;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.UnavailableForLegalReasons, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsInternalServerError_ReturnsHttpStatusCodeInternalServerError()
	{
		// Arrange
		var result = Result.InternalServerError;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.InternalServerError, statusCode);
	}

	[Fact]
	public void StatusCode_WhenResultIsNotImplemented_ReturnsHttpStatusCodeNotImplemented()
	{
		// Arrange
		var result = Result.NotImplemented;

		// Act
		var statusCode = result.StatusCode();

		// Assert
		Assert.Equal(HttpStatusCode.NotImplemented, statusCode);
	}
}
