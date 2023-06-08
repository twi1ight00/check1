using System;

namespace ns67;

internal sealed class Class3417 : Class3415
{
	private Class3441 class3441_0;

	public Class3441 Value
	{
		get
		{
			return class3441_0;
		}
		set
		{
			if (class3441_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3441_0 = value.method_0();
			}
		}
	}

	public Class3417(Class3441 value)
	{
		Value = value;
	}

	public override Class3415 vmethod_0()
	{
		return new Class3417(class3441_0);
	}
}
