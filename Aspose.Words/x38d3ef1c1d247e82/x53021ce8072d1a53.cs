using System;
using System.Collections;

namespace x38d3ef1c1d247e82;

internal class x53021ce8072d1a53 : x1e9b3e0e8864e135, IEnumerable
{
	private readonly IDictionary x579c7d284bd868ba;

	public int xd44988f225497f3a => x579c7d284bd868ba.Count;

	internal x53021ce8072d1a53(IDictionary dictionary)
	{
		x579c7d284bd868ba = dictionary;
	}

	public bool xd6b6ed77479ef68c(object xccb63ca5f63dc470)
	{
		throw new NotSupportedException("WrapperSet collection cannot be modified.");
	}

	public void xa9d636b00ff486b7()
	{
		throw new NotSupportedException("WrapperSet collection cannot be modified.");
	}

	public bool x263d579af1d0d43f(object xccb63ca5f63dc470)
	{
		return x579c7d284bd868ba.Contains(xccb63ca5f63dc470);
	}

	public IEnumerator GetEnumerator()
	{
		return x579c7d284bd868ba.Keys.GetEnumerator();
	}

	public bool x52b190e626f65140(object xccb63ca5f63dc470)
	{
		throw new NotSupportedException("WrapperSet collection cannot be modified.");
	}
}
