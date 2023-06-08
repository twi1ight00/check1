namespace Enyim.Caching.Memcached;

public interface IMutatorOperation : ISingleItemOperation, IOperation
{
	MutationMode Mode { get; }

	ulong Result { get; }
}
