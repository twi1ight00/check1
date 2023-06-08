using System;

namespace ns67;

internal sealed class Class3346 : Class3344
{
	private readonly Class3331 class3331_0;

	private Enum462 enum462_0;

	public Enum462 Blend
	{
		get
		{
			return enum462_0;
		}
		set
		{
			enum462_0 = value;
		}
	}

	public Class3331 Overlay => class3331_0;

	public Class3346(Class3331 overlay, Enum462 blend)
	{
		if (overlay == null)
		{
			throw new ArgumentNullException("overlay");
		}
		class3331_0 = overlay.vmethod_0();
		enum462_0 = blend;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3346(class3331_0, enum462_0);
	}
}
