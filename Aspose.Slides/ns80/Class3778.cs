using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3778 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "border-image-slice";

	public override Enum600 PropertyType => Enum600.const_43;

	public override bool IsInheritedProperty => true;

	static Class3778()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("fill", Class3700.Class3702.class3689_29);
	}

	public override Class3679 vmethod_1()
	{
		return new Class3691(Class3700.Class3702.class3685_20);
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
			@class.Add(base.vmethod_0(lu, engine));
			lu = lu.NextLexicalUnit;
		}
		return @class;
	}
}
