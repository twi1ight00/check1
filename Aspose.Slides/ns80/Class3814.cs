using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3814 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "size";

	public override Enum600 PropertyType => Enum600.const_228;

	public override bool IsInheritedProperty => true;

	static Class3814()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("landscape", Class3700.Class3702.class3689_295);
		class3548_0.method_0("portrait", Class3700.Class3702.class3689_296);
		class3548_0.method_0("a5", Class3700.Class3702.class3689_297);
		class3548_0.method_0("a4", Class3700.Class3702.class3689_298);
		class3548_0.method_0("a3", Class3700.Class3702.class3689_299);
		class3548_0.method_0("b5", Class3700.Class3702.class3689_300);
		class3548_0.method_0("b4", Class3700.Class3702.class3689_301);
		class3548_0.method_0("letter", Class3700.Class3702.class3689_302);
		class3548_0.method_0("legal", Class3700.Class3702.class3689_303);
		class3548_0.method_0("ledger", Class3700.Class3702.class3689_304);
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
		while (lu != null)
		{
			@class.Add(base.vmethod_0(lu, engine));
			lu = lu.NextLexicalUnit;
		}
		return @class;
	}
}
