namespace Helmer.Shared.Common;

public enum Result
{
	/// <summary>
	///     Request passed, response data is in the result class. Equivalent to 200 OK.
	/// </summary>
	Ok,

	/// <summary>
	///     Request passed, a new resource was successfully created. Equivalent to 201 Created.
	/// </summary>
	Created,

	/// <summary>
	///     Request passed, the request has been successfully processed. Equivalent to 204 NoContent.
	/// </summary>
	NoContent,

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 400 Bad Request.
	///     Follow-up logic: Client should modify the request before retrying.
	/// </summary>
	BadRequest,

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 401 Unauthorized.
	///     Follow-up logic: Client should re-authenticate before retrying.
	/// </summary>
	Unauthorized,

	/// <summary>
	///     Request failed, access to the resource is Forbidden. Equivalent to 403 Forbidden. Re-authenticating has no use.
	///     Follow-up logic: Client should not retry the request.
	/// </summary>
	Forbidden,

	/// <summary>
	///     Request failed, the resource cannot be found by the code. Equivalent to 404 Not found.
	///     Follow-up logic: Client may retry the request at some point in the future.
	/// </summary>
	NotFound,

	/// <summary>
	///     Request failed, The resource was found by the code, but the content is not conform the criteria. Equivalent to 406
	///     Not acceptable.
	///		Follow-up logic: Client should modify the request before retrying.
	/// </summary>
	NotAcceptable,

	/// <summary>
	///     Request failed, the request cannot be fully processed by the code due to cancellation or timeout. Equivalent to 408
	///     timeout
	///     Follow-up logic: Client may retry the request without modifications at some point in the (near) future.
	/// </summary>
	Timeout,

	/// <summary>
	///     Request failed, the request cannot be processed by the code. Equivalent to 409 conflict
	///		Follow-up logic: Dependent on what causes the conflict, and the state of the resource.
	/// </summary>
	Conflict,

	/// <summary>
	///     Request failed, an insecure url address is used (http:// instead of https://) Refers to 426 Upgrade Required.
	///		Follow-up logic: Client should modify the request (upgrade to different protocol) before retrying.
	/// </summary>
	InsecureUrl,

	/// <summary>
	///     Request failed, an insecure url address is used (http:// instead of https://) Refers to 451, in the meaning that
	///     this resource is not available due to legal reasons (gdpr).
	///		Follow-up logic: Fatal error.
	/// </summary>
	UnavailableForLegalReasons,

	/// <summary>
	///     Request failed, a generic error occurred. Equivalent to 500 Internal server error.
	///		Follow-up logic: Fatal error.
	/// </summary>
	InternalServerError,

	/// <summary>
	///     Request failed, the code is not implemented. Equivalent to 501 NotImplemented.
	///		Follow-up logic: Fatal error.
	/// </summary>
	NotImplemented,

	/// <summary>
	///     Request failed, the request cannot be fully processed by the code due to a bad gateway. Equivalent to 502 Bad
	///     Gateway.
	///     Follow-up logic: Dependent on the context, a retry may be possible if the condition is temporary. If permanent, this is a fatal error.
	/// </summary>
	BadGateway,

	/// <summary>
	///     Request failed, the request cannot be fully processed by the code due to gateway timeout. Equivalent to 504 Gateway Timeout.
	///     Follow-up logic: Dependent on the context, a retry may be possible if the condition is temporary. If permanent, this is a fatal error.
	/// </summary>
	GatewayTimeout
}