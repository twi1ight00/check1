using System.Collections.Generic;

namespace Enyim.Caching;

/// <summary>
/// A fast comparer for dictionaries indexed by UInt. Faster than using Comparer.Default
/// </summary>
public sealed class UIntEqualityComparer : IEqualityComparer<uint>
{
	bool IEqualityComparer<uint>.Equals(uint x, uint y)
	{
		return x == y;
	}

	int IEqualityComparer<uint>.GetHashCode(uint value)
	{
		return value.GetHashCode();
	}
}
