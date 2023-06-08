using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4211 : Class4154
{
	private readonly Class4337 class4337_0;

	private bool bool_0;

	private bool bool_1;

	public Class4337 Value => class4337_0;

	public bool IsHigher => bool_0;

	public bool IsLower => bool_1;

	internal Class4211(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			if (Class3700.Class3702.class3689_49 == cssValue)
			{
				bool_0 = true;
			}
			else if (Class3700.Class3702.class3689_50 == cssValue)
			{
				bool_1 = true;
			}
			else if (Class3700.Class3702.class3689_46 == cssValue)
			{
				class4337_0 = new Class4337(-90f, Enum634.const_10);
			}
			else if (Class3700.Class3702.class3689_47 == cssValue)
			{
				class4337_0 = new Class4337(0f, Enum634.const_10);
			}
			else if (Class3700.Class3702.class3689_48 == cssValue)
			{
				class4337_0 = new Class4337(90f, Enum634.const_10);
			}
		}
		else
		{
			class4337_0 = Class4338.smethod_3((Class3681)cssValue);
		}
	}
}
