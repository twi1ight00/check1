using ns73;

namespace ns78;

internal class Class3747 : Class3741
{
	public Class3747(string feature, Class3679 argument)
		: base(feature, argument)
	{
	}

	public Class3747(string feature)
		: base(feature, Class3700.Class3702.class3685_0)
	{
	}

	public override bool imethod_0(Class3677 device)
	{
		if (base.Value == 0)
		{
			return device.Color.MonochromeBitPerPixel > base.Value;
		}
		return device.Color.MonochromeBitPerPixel == base.Value;
	}
}
