using ns171;

namespace ns187;

internal class Class5083 : Class5048.Class5081
{
	private static Class5024 class5024_1 = Class5048.smethod_1(0);

	private static Class5024 class5024_2 = Class5048.smethod_1(1);

	private static Class5024 class5024_3 = Class5048.smethod_1(2);

	private static Class5024 class5024_4 = Class5048.smethod_1(3);

	private static Class5024 class5024_5 = Class5048.smethod_1(4);

	private static Class5024 class5024_6 = Class5048.smethod_1(5);

	private static Class5024 class5024_7 = Class5048.smethod_1(6);

	public Class5083(int propId)
		: base(propId)
	{
	}

	public override Class5024 vmethod_7(Class5634 propertyList)
	{
		Class5094 @class = propertyList.method_0();
		return (Enum679)@class.vmethod_24() switch
		{
			Enum679.const_72 => class5024_7, 
			Enum679.const_74 => class5024_3, 
			Enum679.const_76 => class5024_6, 
			Enum679.const_77 => class5024_5, 
			Enum679.const_78 => class5024_1, 
			Enum679.const_79 => class5024_2, 
			Enum679.const_80 => class5024_4, 
			_ => null, 
		};
	}
}
