using System;

namespace ns67;

internal sealed class Class3392 : Class3391
{
	private Class3453 class3453_0;

	public Class3453 Color
	{
		get
		{
			return class3453_0;
		}
		set
		{
			if (value != class3453_0)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3453_0 = value.method_1();
			}
		}
	}

	public Class3392(Class3453 color)
	{
		Color = color;
	}

	public override Class3391 vmethod_0()
	{
		return new Class3392(class3453_0);
	}
}
