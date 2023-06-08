namespace ns67;

internal sealed class Class3327 : Class3326
{
	private Class3345 class3345_0;

	private Class3346 class3346_0;

	private Class3362 class3362_0;

	private Class3364 class3364_0;

	private Class3363 class3363_0;

	private Class3368 class3368_0;

	public Class3345 Blur
	{
		get
		{
			return class3345_0;
		}
		set
		{
			if (class3345_0 != value)
			{
				if (value != null)
				{
					class3345_0 = (Class3345)value.vmethod_0();
				}
				else
				{
					class3345_0 = null;
				}
			}
		}
	}

	public Class3346 FillOverlay
	{
		get
		{
			return class3346_0;
		}
		set
		{
			if (class3346_0 != value)
			{
				if (value != null)
				{
					class3346_0 = (Class3346)value.vmethod_0();
				}
				else
				{
					class3346_0 = null;
				}
			}
		}
	}

	public Class3362 Glow
	{
		get
		{
			return class3362_0;
		}
		set
		{
			if (class3362_0 != value)
			{
				class3362_0 = value?.method_0();
			}
		}
	}

	public Class3364 Shadow
	{
		get
		{
			return class3364_0;
		}
		set
		{
			if (class3364_0 != value)
			{
				class3364_0 = value?.vmethod_0();
			}
		}
	}

	public Class3363 Reflection
	{
		get
		{
			return class3363_0;
		}
		set
		{
			if (class3363_0 != value)
			{
				class3363_0 = value?.method_0();
			}
		}
	}

	public Class3368 SoftEdge
	{
		get
		{
			return class3368_0;
		}
		set
		{
			if (class3368_0 != value)
			{
				class3368_0 = value?.method_0();
			}
		}
	}

	public override Class3326 vmethod_0()
	{
		Class3327 @class = new Class3327();
		@class.Blur = class3345_0;
		@class.FillOverlay = class3346_0;
		@class.Glow = class3362_0;
		@class.Shadow = class3364_0;
		@class.Reflection = class3363_0;
		@class.SoftEdge = class3368_0;
		return @class;
	}
}
