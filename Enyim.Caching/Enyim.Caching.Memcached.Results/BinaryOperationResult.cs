namespace Enyim.Caching.Memcached.Results;

public class BinaryOperationResult : OperationResultBase, ICasOperationResult, IOperationResult
{
	public ulong Cas { get; set; }
}
