using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Represents a lifetime container.
/// </summary>
/// <remarks>
/// A lifetime container tracks the lifetime of an object, and implements
/// IDisposable. When the container is disposed, any objects in the
/// container which implement IDisposable are also disposed.
/// </remarks>
public class LifetimeContainer : ILifetimeContainer, IEnumerable<object>, IEnumerable, IDisposable
{
	private readonly List<object> items = new List<object>();

	/// <summary>
	/// Gets the number of references in the lifetime container
	/// </summary>
	/// <value>
	/// The number of references in the lifetime container
	/// </value>
	public int Count
	{
		get
		{
			lock (items)
			{
				return items.Count;
			}
		}
	}

	/// <summary>
	/// Adds an object to the lifetime container.
	/// </summary>
	/// <param name="item">The item to be added to the lifetime container.</param>
	public void Add(object item)
	{
		lock (items)
		{
			items.Add(item);
		}
	}

	/// <summary>
	/// Determine if a given object is in the lifetime container.
	/// </summary>
	/// <param name="item">
	/// The item to locate in the lifetime container.
	/// </param>
	/// <returns>
	/// Returns true if the object is contained in the lifetime
	/// container; returns false otherwise.
	/// </returns>
	public bool Contains(object item)
	{
		lock (items)
		{
			return items.Contains(item);
		}
	}

	/// <summary>
	/// Releases the resources used by the <see cref="T:Microsoft.Practices.ObjectBuilder2.LifetimeContainer" />. 
	/// </summary>
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// Releases the managed resources used by the DbDataReader and optionally releases the unmanaged resources. 
	/// </summary>
	/// <param name="disposing">
	/// true to release managed and unmanaged resources; false to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		lock (items)
		{
			List<object> list = new List<object>(items);
			list.Reverse();
			foreach (object item in list)
			{
				if (item is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			items.Clear();
		}
	}

	/// <summary>
	/// Returns an enumerator that iterates through the lifetime container.
	/// </summary>
	/// <returns>
	/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the life time container. 
	/// </returns>
	public IEnumerator<object> GetEnumerator()
	{
		return items.GetEnumerator();
	}

	/// <summary>
	/// Returns an enumerator that iterates through the lifetime container.
	/// </summary>
	/// <returns>
	/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the life time container. 
	/// </returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	/// <summary>
	/// Removes an item from the lifetime container. The item is
	/// not disposed.
	/// </summary>
	/// <param name="item">The item to be removed.</param>
	public void Remove(object item)
	{
		lock (items)
		{
			if (items.Contains(item))
			{
				items.Remove(item);
			}
		}
	}
}
