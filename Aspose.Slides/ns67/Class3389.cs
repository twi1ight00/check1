using System;

namespace ns67;

internal sealed class Class3389 : ICloneable
{
	private Class3390 class3390_0;

	private readonly Class3390[] class3390_1 = new Class3390[9];

	public Class3390 DefaultParagraphStyle
	{
		get
		{
			return class3390_0;
		}
		set
		{
			if (value != class3390_0)
			{
				class3390_0 = value?.method_0();
			}
		}
	}

	public Class3390[] ListLevelTextStyles => class3390_1;

	public Class3389()
	{
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3389 method_0()
	{
		return new Class3389(this);
	}

	private Class3389(Class3389 src)
	{
		class3390_0 = src.class3390_0.method_0();
		for (int i = 0; i < class3390_1.Length; i++)
		{
			Class3390 @class = src.class3390_1[i];
			if (@class != null)
			{
				class3390_1[i] = @class.method_0();
			}
		}
	}
}
