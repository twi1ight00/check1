using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System.Data.Entity.Edm.Internal;

internal sealed class BackingList<TElement> : IEnumerable<TElement>, IEnumerable
{
	private IList<TElement> instance;

	internal bool HasValue => instance != null;

	internal void SetValue(IList<TElement> value)
	{
		instance = value;
	}

	internal IList<TElement> EnsureValue()
	{
		if (instance == null)
		{
			instance = new List<TElement>();
		}
		return instance;
	}

	public IEnumerator<TElement> GetEnumerator()
	{
		return (instance ?? Enumerable.Empty<TElement>()).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return (instance ?? Enumerable.Empty<TElement>()).GetEnumerator();
	}
}
