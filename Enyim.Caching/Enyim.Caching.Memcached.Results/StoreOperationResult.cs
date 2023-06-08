namespace Enyim.Caching.Memcached.Results;

public class StoreOperationResult : OperationResultBase, IStoreOperationResult, ICasOperationResult, IOperationResult
{
	public ulong Cas { get; set; }
}
