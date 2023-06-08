using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3998 : Class3997
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "image-resolution";

	public override Enum600 PropertyType => Enum600.const_145;

	public override bool IsInheritedProperty => true;

	static Class3998()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("from-image", Class3700.Class3702.class3689_97);
		class3548_0.method_0("snap", Class3700.Class3702.class3689_98);
	}

	public override Class3679 vmethod_1()
	{
		return new Class3691(Class3700.Class3702.class3685_22);
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
