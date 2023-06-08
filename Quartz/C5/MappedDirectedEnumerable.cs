using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal abstract class MappedDirectedEnumerable<T, V> : EnumerableBase<V>, IDirectedEnumerable<V>, IEnumerable<V>, IEnumerable
{
	private IDirectedEnumerable<T> directedenumerable;

	[ComVisible(true)]
	public EnumerationDirection Direction
	{
		[ComVisible(true)]
		get
		{
			return directedenumerable.Direction;
		}
	}

	[ComVisible(true)]
	public abstract V Map(T item);

	[ComVisible(true)]
	public MappedDirectedEnumerable(IDirectedEnumerable<T> directedenumerable)
	{
		this.directedenumerable = directedenumerable;
	}

	[ComVisible(true)]
	public IDirectedEnumerable<V> Backwards()
	{
		MappedDirectedEnumerable<T, V> mappedDirectedEnumerable = (MappedDirectedEnumerable<T, V>)MemberwiseClone();
		mappedDirectedEnumerable.directedenumerable = directedenumerable.Backwards();
		return mappedDirectedEnumerable;
	}

	[ComVisible(true)]
	public override IEnumerator<V> GetEnumerator()
	{
		foreach (T item in directedenumerable)
		{
			yield return Map(item);
		}
	}
}
