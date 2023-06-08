using System;

namespace ns180;

internal class Class5595
{
	protected object object_0;

	public object method_0()
	{
		return object_0;
	}

	public Class5595(object source)
	{
		if (source == null)
		{
			throw new ArgumentException("null source");
		}
		object_0 = source;
	}

	public override string ToString()
	{
		return object_0.ToString();
	}
}
