using System;

namespace ns224;

internal class Class5997 : Class5990
{
	private Class5998 class5998_0;

	public Class5998 Color
	{
		get
		{
			return class5998_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class5998_0 = value;
		}
	}

	public Class5997(Class5998 color)
		: base(Enum746.const_0)
	{
		Color = color;
	}
}
