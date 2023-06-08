using System;

namespace ns67;

internal sealed class Class3403 : Class3401
{
	private Class3369 class3369_0;

	public Class3369 Blip
	{
		get
		{
			return class3369_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value != class3369_0)
			{
				class3369_0 = value.method_0();
			}
		}
	}

	public Class3403(Class3369 blip)
	{
		Blip = blip;
	}

	public override Class3401 vmethod_0()
	{
		return new Class3403(class3369_0);
	}
}
