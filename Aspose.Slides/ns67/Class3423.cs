using System;

namespace ns67;

internal abstract class Class3423 : ICloneable
{
	private Class3406 class3406_0;

	public Class3406 RunProperties
	{
		get
		{
			return class3406_0;
		}
		set
		{
			if (value != class3406_0)
			{
				class3406_0 = value?.method_0();
			}
		}
	}

	public object Clone()
	{
		return vmethod_0();
	}

	public abstract Class3423 vmethod_0();

	protected Class3423()
	{
	}

	protected Class3423(Class3423 src)
	{
		RunProperties = src.RunProperties;
	}
}
