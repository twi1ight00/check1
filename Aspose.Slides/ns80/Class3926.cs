using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3926 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "move-to";

	public override Enum600 PropertyType => Enum600.const_176;

	public override bool IsInheritedProperty => false;

	static Class3926()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("here", Class3700.Class3702.class3689_78);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_5;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		short lexicalUnitType = lu.LexicalUnitType;
		if (lexicalUnitType == 35)
		{
			Class3679 @class = vmethod_3().method_1(lu.imethod_5().ToLowerInvariant());
			if (@class != null)
			{
				return @class;
			}
			return Class3689.smethod_1(lu.imethod_5());
		}
		throw method_1(lu.LexicalUnitType);
	}
}
