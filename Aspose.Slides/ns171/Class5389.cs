using ns187;

namespace ns171;

internal class Class5389 : Interface179
{
	public Class5024 imethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		switch (propId)
		{
		case 58:
		case 59:
			switch ((Enum679)property.imethod_0())
			{
			case Enum679.const_74:
				return Class5042.smethod_0(44, "EVEN_PAGE");
			case Enum679.const_8:
				return Class5042.smethod_0(104, "PAGE");
			case Enum679.const_207:
				return Class5042.smethod_0(100, "ODD_PAGE");
			}
			break;
		case 131:
		case 132:
		case 133:
			if (property.imethod_0() == 178)
			{
				return maker.vmethod_9(null, 5632, propertyList, "always", propertyList.method_0());
			}
			break;
		}
		return null;
	}
}
