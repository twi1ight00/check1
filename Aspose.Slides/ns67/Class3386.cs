using System;

namespace ns67;

internal sealed class Class3386 : Class3384
{
	private Class3374 class3374_0;

	public Class3374 Value
	{
		get
		{
			return class3374_0;
		}
		set
		{
			if (value != class3374_0)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3374_0 = value.method_0();
			}
		}
	}

	public Class3386(Class3374 value)
	{
		Value = value;
	}

	public override Class3384 vmethod_0()
	{
		return new Class3386(class3374_0);
	}
}
