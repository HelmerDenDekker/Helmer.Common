﻿namespace Helmer.Shared.Common.Extensions;

public static class ResultExtensions
{
	/// <summary>
	///     Downcast from the <see cref="Result">Result</see> superclass to the <see cref="Result{TValue}" /> subclass
	/// </summary>
	/// <typeparam name="TValue">The query object results return object</typeparam>
	/// <param name="result">The original Result</param>
	/// <param name="value">The query object results return object value</param>
	/// <returns></returns>
	public static Result<TValue> DownCast<TValue>(this Result result, TValue? value = default)
	{
		return new Result<TValue>(value, result.Messages.ToList(), result.StatusCode);
	}

	/// <summary>
	///     Adds a message to the result
	/// </summary>
	/// <param name="result"></param>
	/// <param name="message"></param>
	/// <returns></returns>
	public static Result AddMessage(this Result result, string message)
	{
		result.Messages.Add(message);
		return result;
	}
}
