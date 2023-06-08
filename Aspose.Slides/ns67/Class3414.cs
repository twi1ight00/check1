using System;

namespace ns67;

internal sealed class Class3414 : Class3412
{
	private Class3331 class3331_0;

	public Class3331 Value
	{
		get
		{
			return class3331_0;
		}
		set
		{
			if (value != class3331_0)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3331_0 = value.vmethod_0();
			}
		}
	}

	public Class3414(Class3331 value)
	{
		Value = value;
	}

	public override Class3412 vmethod_0()
	{
		return new Class3414(class3331_0);
	}
}
