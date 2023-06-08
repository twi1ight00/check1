using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3784 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "box-shadow";

	public override Enum600 PropertyType => Enum600.const_66;

	public override bool IsInheritedProperty => false;

	static Class3784()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("inset", Class3700.Class3702.class3689_109);
	}

	public override Class3679 vmethod_1()
	{
		return new Class3691(Class3700.Class3702.class3689_4);
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3691 @class = new Class3691();
		while (lu != null)
		{
			switch (lu.LexicalUnitType)
			{
			default:
				@class.Add(base.vmethod_0(lu, engine));
				break;
			case 35:
			{
				string key = lu.imethod_5().ToLowerInvariant();
				Class3679 class2 = vmethod_3().method_1(key);
				if (class2 != null)
				{
					@class.Add(class2);
				}
				else
				{
					@class.Add(engine.method_6(Enum600.const_71).vmethod_0(lu, engine));
				}
				break;
			}
			case 0:
				@class.Add(Class3700.Class3702.class3689_0);
				break;
			case 12:
				return Class3700.Class3702.class3695_0;
			}
			lu = lu.NextLexicalUnit;
		}
		return @class;
	}
}
