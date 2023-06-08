using System;

namespace ns67;

internal class Class3357 : Class3344
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
				class3453_0 = value;
			}
		}
	}

	public Class3357()
		: this(new Class3453(0f, 0f, 0f, 0f))
	{
	}

	public Class3357(Class3453 color)
	{
		Color = color;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3357(class3453_0);
	}
}
