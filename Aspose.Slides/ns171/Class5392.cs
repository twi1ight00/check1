using ns187;

namespace ns171;

internal class Class5392 : Interface179
{
	public Class5024 imethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		switch ((Enum679)property.imethod_0())
		{
		case Enum679.const_266:
			switch ((Enum679)propId)
			{
			case Enum679.const_353:
				return Class5042.smethod_0(93, "NO_WRAP");
			case Enum679.const_348:
				return Class5042.smethod_0(48, "FALSE");
			case Enum679.const_230:
			case Enum679.const_349:
				return Class5042.smethod_0(108, "PRESERVE");
			}
			break;
		case Enum679.const_180:
			if (propId == 266)
			{
				return Class5042.smethod_0(93, "NO_WRAP");
			}
			break;
		}
		return null;
	}
}
