using System.Net;
using Helmer.Shared.Common;
using Helmer.Shared.Common.Extensions;
using Helmer.Shared.Tools.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Helmer.Shared.Tools.Helpers;

[SecurityHeaders]
[ApiController]
[Route("[controller]")]
public class BaseApiController : ControllerBase
{
	/// <summary>
	///     A default ActionResponse for returning a generic response as returned by the result
	/// </summary>
	/// <param name="result"><see cref="Result" />The Result enum</param>
	/// <returns>ActionResult according to statuscode corresponding to the <see cref="Result" /> Result </returns>
	[NonAction]
	public ActionResult ActionResponse(Result result)
	{
		return new ContentResult
		{
			StatusCode = (int)result.StatusCode(),
			Content = result.Content()
		};
	}

	/// <summary>
	///     A default ActionResponse for returning a generic response as returned by the <see cref="ValueResult{T}" /> subclass
	/// </summary>
	/// <param name="result"><see cref="ValueResult{T}" /> Result with a value of T</param>
	/// <returns>ActionResult according to statuscode corresponding to the <see cref="ValueResult{T}" /> Result </returns>
	[NonAction]
	public ActionResult ActionResponse<TValue>(ValueResult<TValue> result)
	{
		if (result.Result.StatusCode() == HttpStatusCode.OK)
			return Ok(result.Value);

		return ActionResponse(result.Result);
	}
}
