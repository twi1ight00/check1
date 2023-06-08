using System;

namespace ns67;

internal sealed class Class3400 : Class3398
{
	private Class3449 class3449_0;

	public Class3449 Value
	{
		get
		{
			return class3449_0;
		}
		set
		{
			if (value != class3449_0)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3449_0 = value.method_0();
			}
		}
	}

	public Class3400(Class3449 value)
	{
		Value = value;
	}

	public override Class3398 vmethod_0()
	{
		return new Class3400(class3449_0);
	}
}
