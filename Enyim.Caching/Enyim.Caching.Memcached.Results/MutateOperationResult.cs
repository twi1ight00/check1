namespace Enyim.Caching.Memcached.Results;

public class MutateOperationResult : OperationResultBase, IMutateOperationResult, ICasOperationResult, IOperationResult
{
	public ulong Cas { get; set; }

	public ulong Value { get; set; }
}
