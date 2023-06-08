using System.Collections.Generic;

namespace System.Data.Entity.Migrations.Utilities;

internal sealed class DynamicEqualityComparer<T> : IEqualityComparer<T> where T : class
{
	private readonly Func<T, T, bool> _func;

	public DynamicEqualityComparer(Func<T, T, bool> func)
	{
		_func = func;
	}

	public bool Equals(T x, T y)
	{
		return _func(x, y);
	}

	public int GetHashCode(T obj)
	{
		return 0;
	}
}
