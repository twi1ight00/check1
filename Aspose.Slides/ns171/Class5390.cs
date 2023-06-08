using ns187;

namespace ns171;

internal class Class5390 : Interface179
{
	public Class5024 imethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		int num = property.imethod_0();
		if (propId == 1)
		{
			switch ((Enum679)num)
			{
			case Enum679.const_52:
				return Class5042.smethod_0(51, "FIXED");
			case Enum679.const_2:
				return Class5042.smethod_0(1, "ABSOLUTE");
			case Enum679.const_302:
				return Class5042.smethod_0(215, "INLINEABSOLUTE");
			case Enum679.const_293:
				return Class5042.smethod_0(206, "ABSOLUTERELATIVE");
			case Enum679.const_197:
			case Enum679.const_223:
				return Class5042.smethod_0(9, "AUTO");
			}
		}
		if (propId == 203)
		{
			switch ((Enum679)num)
			{
			case Enum679.const_197:
				return Class5042.smethod_0(110, "RELATIVE");
			case Enum679.const_52:
				return Class5042.smethod_0(136, "STATIC");
			case Enum679.const_2:
				return Class5042.smethod_0(136, "STATIC");
			case Enum679.const_302:
				return Class5042.smethod_0(215, "INLINEABSOLUTE");
			case Enum679.const_293:
				return Class5042.smethod_0(206, "ABSOLUTERELATIVE");
			case Enum679.const_223:
				return Class5042.smethod_0(136, "STATIC");
			}
		}
		return null;
	}
}
