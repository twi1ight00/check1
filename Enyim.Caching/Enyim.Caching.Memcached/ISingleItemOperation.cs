namespace Enyim.Caching.Memcached;

public interface ISingleItemOperation : IOperation
{
	string Key { get; }

	/// <summary>
	/// The CAS value returned by the server after executing the command.
	/// </summary>
	ulong CasValue { get; }
}
