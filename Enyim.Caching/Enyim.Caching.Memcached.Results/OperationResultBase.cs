using System;

namespace Enyim.Caching.Memcached.Results;

public abstract class OperationResultBase : IOperationResult
{
	public bool Success { get; set; }

	public string Message { get; set; }

	public Exception Exception { get; set; }

	public int? StatusCode { get; set; }

	public IOperationResult InnerResult { get; set; }
}
