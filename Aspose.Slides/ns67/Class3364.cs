using System;

namespace ns67;

internal abstract class Class3364 : ICloneable
{
	private Class3453 class3453_0 = new Class3453(0f, 0f, 0f, 0f);

	public Class3453 Color
	{
		get
		{
			return class3453_0;
		}
		set
		{
			if (class3453_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3453_0 = value.method_1();
			}
		}
	}

	public object Clone()
	{
		return vmethod_0();
	}

	public abstract Class3364 vmethod_0();

	protected Class3364()
	{
	}

	protected Class3364(Class3364 src)
	{
		Color = src.class3453_0;
	}
}
