using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3948 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-decoration-line";

	public override Enum600 PropertyType => Enum600.const_245;

	public override bool IsInheritedProperty => false;

	static Class3948()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
		class3548_0.method_0("underline", Class3700.Class3702.class3689_180);
		class3548_0.method_0("overline", Class3700.Class3702.class3689_181);
		class3548_0.method_0("line-through", Class3700.Class3702.class3689_182);
		class3548_0.method_0("blink", Class3700.Class3702.class3689_183);
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
		do
		{
			@class.Add(base.vmethod_0(lu, engine));
			lu = lu.NextLexicalUnit;
		}
		while (lu != null);
		return @class;
	}
}
