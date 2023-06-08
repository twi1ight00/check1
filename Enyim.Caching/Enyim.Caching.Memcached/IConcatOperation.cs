namespace Enyim.Caching.Memcached;

public interface IConcatOperation : ISingleItemOperation, IOperation
{
	ConcatenationMode Mode { get; }
}
