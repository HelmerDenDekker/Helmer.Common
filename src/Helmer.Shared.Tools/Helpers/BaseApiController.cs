using System.Net;
using Helmer.Shared.Common;
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
    /// <param name="result"><see cref="Result" /> Result  with a StatusCode</param>
    /// <returns>ActionResult according to statuscode in the <see cref="Result" /> Result </returns>
    [NonAction]
    public ActionResult ActionResponse(Result result)
    {
        return new ContentResult
        {
            StatusCode = (int)result.StatusCode,
            Content = result.Messages.First()
        };
    }

	/// <summary>
	///     A default ActionResponse for returning a generic response as returned by the <see cref="Result{TValue}" /> subclass
	/// </summary>
	/// <param name="result"><see cref="Result" /> Result  with a StatusCode</param>
	/// <returns>ActionResult according to statuscode in the <see cref="Result" /> Result </returns>
	[NonAction]
	public ActionResult ActionResponse<TValue>(Result<TValue> result)
	{
		if (result.IsSuccess && result.StatusCode == HttpStatusCode.OK)
			return Ok(result.Value);

		return ActionResponse(result);
	}
}