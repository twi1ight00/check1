using System;

namespace Enyim.Caching.Memcached.Results.Extensions;

public static class OperationResultExtensions
{
	/// <summary>
	/// Set the result Success to false
	/// </summary>
	/// <param name="source">Result to update</param>
	/// <param name="message">Message indicating source of failure</param>
	/// <param name="ex">Exception causing failure</param>
	/// <returns>Updated source</returns>
	public static IOperationResult Fail(this IOperationResult source, string message, Exception ex = null)
	{
		source.Success = false;
		source.Message = message;
		source.Exception = ex;
		return source;
	}

	/// <summary>
	/// Set the result Success to true
	/// </summary>
	/// <param name="source">Result to update</param>
	/// <param name="message">Message indicating a possible warning</param>
	/// <returns>Updated source</returns>
	public static IOperationResult Pass(this IOperationResult source, string message = null)
	{
		source.Success = true;
		source.Message = message;
		return source;
	}

	/// <summary>
	/// Copy properties from one IOperationResult to another.  Does not use reflection.
	/// Ony LCD properties are copied
	/// </summary>
	/// <param name="target"></param>
	public static void Copy(this IOperationResult source, IOperationResult target)
	{
		target.Message = source.Message;
		target.Success = source.Success;
		target.Exception = source.Exception;
		target.StatusCode = source.StatusCode;
	}

	/// <summary>
	/// Copy properties from one IOperationResult to another.  Does not use reflection.
	/// Ony LCD properties are copied
	/// </summary>
	/// <param name="target"></param>
	public static IOperationResult PassOrFail(this IOperationResult source, bool success, string message = "", Exception ex = null)
	{
		if (!success)
		{
			return source.Fail(message, ex);
		}
		return source.Pass();
	}

	/// <summary>
	/// Combine will attempt to minimize the depth of InnerResults and maintain status codes
	/// </summary>
	/// <param name="target"></param>
	public static void Combine(this IOperationResult source, IOperationResult target)
	{
		target.Message = source.Message;
		target.Success = source.Success;
		target.Exception = source.Exception;
		target.StatusCode = source.StatusCode ?? target.StatusCode;
		target.InnerResult = source.InnerResult ?? source;
	}
}
