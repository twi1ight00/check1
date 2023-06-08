using System;

namespace ns67;

internal sealed class Class3348 : Class3344
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

	public Class3348(Class3453 color)
	{
		Color = color;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3348(class3453_0);
	}
}
