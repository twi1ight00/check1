using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.Contracts;

namespace System.Data.Entity.Internal;

/// <summary>
///     An implementation of <see cref="T:System.Collections.Generic.ISet`1" /> that wraps an existing set but makes
///     it read-only.
/// </summary>
/// <typeparam name="T"></typeparam>
internal class ReadOnlySet<T> : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private readonly ISet<T> _set;

	public int Count => _set.Count;

	public bool IsReadOnly => true;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.ReadOnlySet`1" /> class wrapped around
	///     another existing set.
	/// </summary>
	/// <param name="set">The existing set.</param>
	public ReadOnlySet(ISet<T> set)
	{
		_set = set;
	}

	public bool Add(T item)
	{
		throw Error.DbPropertyValues_PropertyValueNamesAreReadonly();
	}

	public void ExceptWith(IEnumerable<T> other)
	{
		_set.ExceptWith(other);
	}

	public void IntersectWith(IEnumerable<T> other)
	{
		_set.IntersectWith(other);
	}

	public bool IsProperSubsetOf(IEnumerable<T> other)
	{
		return _set.IsProperSubsetOf(other);
	}

	public bool IsProperSupersetOf(IEnumerable<T> other)
	{
		return _set.IsProperSupersetOf(other);
	}

	public bool IsSubsetOf(IEnumerable<T> other)
	{
		return _set.IsSubsetOf(other);
	}

	public bool IsSupersetOf(IEnumerable<T> other)
	{
		return _set.IsSupersetOf(other);
	}

	public bool Overlaps(IEnumerable<T> other)
	{
		return _set.Overlaps(other);
	}

	public bool SetEquals(IEnumerable<T> other)
	{
		return _set.SetEquals(other);
	}

	public void SymmetricExceptWith(IEnumerable<T> other)
	{
		_set.SymmetricExceptWith(other);
	}

	public void UnionWith(IEnumerable<T> other)
	{
		_set.UnionWith(other);
	}

	void ICollection<T>.Add(T item)
	{
		throw Error.DbPropertyValues_PropertyValueNamesAreReadonly();
	}

	public void Clear()
	{
		throw Error.DbPropertyValues_PropertyValueNamesAreReadonly();
	}

	public bool Contains(T item)
	{
		return _set.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (__ContractsRuntime.insideContractEvaluation <= 4)
		{
			try
			{
				__ContractsRuntime.insideContractEvaluation++;
				RuntimeFailureMethods.Requires(array != null, null, "array != null");
				RuntimeFailureMethods.Requires(arrayIndex >= 0, null, "arrayIndex >= 0");
				RuntimeFailureMethods.Requires(arrayIndex + ((ICollection<T>)this).Count <= array.Length, null, "arrayIndex + this.Count  <= array.Length");
			}
			finally
			{
				__ContractsRuntime.insideContractEvaluation--;
			}
		}
		_set.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		throw Error.DbPropertyValues_PropertyValueNamesAreReadonly();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _set.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)_set).GetEnumerator();
	}
}
