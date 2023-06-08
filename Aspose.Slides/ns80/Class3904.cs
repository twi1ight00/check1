using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3904 : Class3899
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "quotes";

	public override Enum600 PropertyType => Enum600.const_215;

	public override bool IsInheritedProperty => true;

	static Class3904()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_4;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		switch (lu.LexicalUnitType)
		{
		default:
			throw method_1(lu.LexicalUnitType);
		case 35:
		{
			Class3679 class2 = vmethod_3().method_1(lu.imethod_5());
			if (class2 == null)
			{
				throw method_0(lu.imethod_5());
			}
			return class2;
		}
		case 36:
		{
			Class3691 @class = new Class3691();
			do
			{
				if (lu != null)
				{
					@class.Add(Class3689.smethod_0(lu.imethod_5()));
					lu = lu.NextLexicalUnit;
					continue;
				}
				if (@class.Length % 2 == 1)
				{
					throw method_3(@class[@class.Length - 1].CSSText);
				}
				return @class;
			}
			while (lu == null || lu.LexicalUnitType == 36);
			throw method_1(lu.LexicalUnitType);
		}
		case 12:
			return Class3700.Class3702.class3695_0;
		}
	}
}
