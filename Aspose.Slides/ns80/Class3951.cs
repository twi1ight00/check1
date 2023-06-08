using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3951 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "text-emphasis-position";

	public override Enum600 PropertyType => Enum600.const_250;

	public override bool IsInheritedProperty => true;

	static Class3951()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("over", Class3700.Class3702.class3689_266);
		class3548_0.method_0("under", Class3700.Class3702.class3689_267);
		class3548_0.method_0("right", Class3700.Class3702.class3689_12);
		class3548_0.method_0("left", Class3700.Class3702.class3689_8);
	}

	public override Class3679 vmethod_1()
	{
		return new Class3691(Class3700.Class3702.class3689_266, Class3700.Class3702.class3689_12);
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		Class3691 @class = new Class3691();
		for (Interface99 @interface = lu; @interface != null; @interface = @interface.NextLexicalUnit)
		{
			@class.Add(base.vmethod_0(@interface, engine));
		}
		return @class;
	}
}
