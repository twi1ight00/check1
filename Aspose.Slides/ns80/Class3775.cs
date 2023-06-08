using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3775 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "background-size";

	public override Enum600 PropertyType => Enum600.const_24;

	public override bool IsInheritedProperty => true;

	static Class3775()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("cover", Class3700.Class3702.class3689_18);
		class3548_0.method_0("contain", Class3700.Class3702.class3689_19);
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
	}

	public override Class3679 vmethod_1()
	{
		return new Class3691(Class3700.Class3702.class3689_3);
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3691 @class = new Class3691();
		Class3679 class2;
		while (true)
		{
			if (lu != null)
			{
				class2 = base.vmethod_0(lu, engine);
				if (Class3700.Class3702.class3689_18 == class2 || Class3700.Class3702.class3689_19 == class2)
				{
					break;
				}
				@class.Add(class2);
				lu = lu.NextLexicalUnit;
				continue;
			}
			return @class;
		}
		return class2;
	}
}
