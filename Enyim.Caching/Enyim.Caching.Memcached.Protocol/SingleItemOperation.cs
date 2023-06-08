namespace Enyim.Caching.Memcached.Protocol;

/// <summary>
/// Base class for implementing operations working with keyed items.
/// </summary>
public abstract class SingleItemOperation : Operation, ISingleItemOperation, IOperation
{
	public string Key { get; private set; }

	public ulong Cas { get; set; }

	/// <summary>
	/// The item key of the current operation.
	/// </summary>
	string ISingleItemOperation.Key => Key;

	ulong ISingleItemOperation.CasValue => Cas;

	protected SingleItemOperation(string key)
	{
		Key = key;
	}
}
