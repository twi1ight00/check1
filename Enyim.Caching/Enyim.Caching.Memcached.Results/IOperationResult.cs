using System;

namespace Enyim.Caching.Memcached.Results;

public interface IOperationResult
{
	/// <summary>
	/// A value indicating whether an operation was successful
	/// </summary>
	bool Success { get; set; }

	/// <summary>
	/// A message indicating success, warning or failure reason for an operation
	/// </summary>
	string Message { get; set; }

	/// <summary>
	/// An exception that caused a failure
	/// </summary>
	Exception Exception { get; set; }

	/// <summary>
	/// The StatusCode returned from the server
	/// </summary>
	int? StatusCode { get; set; }

	/// <summary>
	/// A result that influenced the current result
	/// </summary>
	IOperationResult InnerResult { get; set; }
}
