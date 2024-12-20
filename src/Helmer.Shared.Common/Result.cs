﻿using System.Net;

namespace Helmer.Shared.Common;

/// <summary>
///     This class returns a result on a command-type function
/// </summary>
public class Result
{
	/// <summary>
	///     Initializes a new instance of the <see cref="Result" /> class.
	/// </summary>
	/// <param name="messages">Messages explaining the result </param>
	/// <param name="statusCode">The HttpStatusCode</param>
	protected Result(List<string> messages, HttpStatusCode statusCode)
	{
		var isSuccess = statusCode is HttpStatusCode.OK or HttpStatusCode.NoContent or HttpStatusCode.Created;
		IsSuccess = isSuccess;
		Messages = messages;
		StatusCode = statusCode;
	}

	/// <summary>
	///     Gets or sets if the command was executed successfully, or data was retrieved
	/// </summary>
	public bool IsSuccess { get; private set; }

	/// <summary>
	///     Gets or sets the messages for explaining the result, please use the resx
	/// </summary>
	public ICollection<string> Messages { get; private set; }

	/// <summary>
	///     Gets or sets a statuscode defining the Result
	/// </summary>
	public HttpStatusCode StatusCode { get; private set; }

	/// <summary>
	///     Request passed, data is in the result class. Equivalent to 200 OK.
	/// </summary>
	public static Result Ok =>
		new(new List<string> { "The request succeeded and the requested information is in the response" }, HttpStatusCode.OK);

	/// <summary>
	///     Request passed, a new resource was successfully created. Equivalent to 201 Created.
	/// </summary>
	public static Result Created =>
		new(new List<string> { "A new resource was successfully created" }, HttpStatusCode.Created);

	/// <summary>
	///     Request passed, the request has been successfully processed. Equivalent to 204 NoContent.
	/// </summary>
	public static Result NoContent => new(new List<string> { "The request has been successfully processed" }, HttpStatusCode.NoContent);

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 400 Bad Request.
	/// </summary>
	public static Result BadRequest =>
		new(new List<string> { "The request cannot be processed by the code due to a validation error" }, HttpStatusCode.BadRequest);

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 401 Unauthorized.
	/// </summary>
	public static Result UnAuthorized =>
		new(new List<string> { "The request cannot be processed by the code, no authorization" }, HttpStatusCode.Unauthorized);

	/// <summary>
	///     Request failed, access to the resource is Forbidden. Equivalent to 403 Forbidden. Re-authenticating has no use.
	/// </summary>
	public static Result Forbidden =>
		new(new List<string> { "Access to the resource is forbidden" }, HttpStatusCode.Forbidden);

	/// <summary>
	///     Request failed, the resource cannot be found by the code. Equivalent to 404 Not found.
	/// </summary>
	public static Result NotFound => new(new List<string> { "The resource cannot be found by the code" }, HttpStatusCode.NotFound);

	/// <summary>
	///     Request failed, The resource was found by the code, but the content is not conform the criteria. Equivalent to 406 Not acceptable.
	/// </summary>
	public static Result NotAcceptable =>
		new(new List<string> { "The resource was found by the code, but the content is not conform the criteria" }, HttpStatusCode.NotAcceptable);

	/// <summary>
	///     Request failed, the request cannot be fully processed by the code due to cancellation or timeout. Equivalent to 408 timeout
	/// </summary>
	public static Result Timeout =>
		new(new List<string> { "The request cannot be processed by the code due to cancellation or timeout" }, HttpStatusCode.RequestTimeout);

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 409 conflict
	/// </summary>
	public static Result Conflict =>
		new(new List<string> { "The request cannot be processed by the code due to a conflict" }, HttpStatusCode.Conflict);

	/// <summary>
	///     Request failed, an insecure url address is used (http:// instead of https://) Refers to 426 Upgrade Required.
	/// </summary>
	public static Result InsecureUrl => new(new List<string> { "The request cannot be processed by the server, due to an insecure url address being used." }, HttpStatusCode.UpgradeRequired);
	
	/// <summary>
	///     Request failed, an insecure url address is used (http:// instead of https://) Refers to 451, in the meaning that this resource is not available due to legal reasons (gdpr)
	/// </summary>
	public static Result UnavailableForLegalReasons =>
		new(new List<string> { "The request cannot be processed by the server, due to legal reasons." }, HttpStatusCode.UnavailableForLegalReasons);

	/// <summary>
	///     Request failed, a generic error occured. Equivalent to 500 Internal server error.
	/// </summary>
	public static Result InternalServerError =>
		new(new List<string> { "The request cannot be processed by the server. A generic error has occured." }, HttpStatusCode.InternalServerError);

	/// <summary>
	///     Request failed, the code is not implemented. Equivalent to 501 NotImplemented.
	/// </summary>
	public static Result NotImplemented =>
		new(new List<string> { "The request cannot be processed by the server. This functionality is not implemented" }, HttpStatusCode.NotImplemented);
}
