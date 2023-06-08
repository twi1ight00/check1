using ns187;

namespace ns171;

internal class Class5379 : Class5376
{
	public override Class5024 imethod_0(int propId, Class5024 property, Class5052 maker, Class5634 propertyList)
	{
		int index = -1;
		switch ((Enum679)propId)
		{
		case Enum679.const_231:
			index = 2;
			break;
		case Enum679.const_188:
			index = 1;
			break;
		case Enum679.const_190:
			index = 0;
			break;
		case Enum679.const_193:
			index = 3;
			break;
		case Enum679.const_194:
			index = 4;
			break;
		case Enum679.const_195:
			index = 5;
			break;
		}
		return (Class5024)property.vmethod_8()[index];
	}
}
