using System.Collections;
using System.Collections.Generic;

namespace Quartz.Collection;

/// <summary>
/// A sorted set.
/// </summary>
/// <author>Marko Lahma (.NET)</author>
public interface ISortedSet<T> : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	/// <summary>
	/// Returns the object in the specified index.
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	T this[int index] { get; }

	/// <summary>
	/// Returns a portion of the list whose elements are greater than the limit object parameter.
	/// </summary>
	/// <param name="limit">The start element of the portion to extract.</param>
	/// <returns>The portion of the collection whose elements are greater than the limit object parameter.</returns>
	ISortedSet<T> TailSet(T limit);

	/// <summary>
	/// Returns the first item in the set.
	/// </summary>
	/// <returns>First object.</returns>
	T First();
}
