using System;

namespace ns67;

internal sealed class Class3372 : ICloneable
{
	private Class3435 class3435_0 = new Class3435();

	private Class3436 class3436_0 = new Class3436();

	private Class3343 class3343_0;

	public Class3435 Camera
	{
		get
		{
			return class3435_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (class3435_0 != value)
			{
				class3435_0 = value.method_0();
			}
		}
	}

	public Class3436 LightRig
	{
		get
		{
			return class3436_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (class3436_0 != value)
			{
				class3436_0 = value.method_0();
			}
		}
	}

	public Class3343 Backdrop
	{
		get
		{
			return class3343_0;
		}
		set
		{
			if (class3343_0 != value)
			{
				class3343_0 = value?.method_0();
			}
		}
	}

	public Class3372()
	{
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3372 method_0()
	{
		return new Class3372(this);
	}

	private Class3372(Class3372 src)
	{
		Camera = src.class3435_0;
		LightRig = src.class3436_0;
		Backdrop = src.class3343_0;
	}
}
