namespace Enyim.Caching.Memcached.Results;

public class ConcatOperationResult : OperationResultBase, IConcatOperationResult, ICasOperationResult, IOperationResult
{
	public ulong Cas { get; set; }
}
