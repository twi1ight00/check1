using System.Collections.Generic;
using ns72;
using ns73;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3875 : Class3866
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "play-during";

	public override Enum600 PropertyType => Enum600.const_213;

	public override bool IsInheritedProperty => false;

	static Class3875()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("mix", Class3700.Class3702.class3689_88);
		class3548_0.method_0("repeat", Class3700.Class3702.class3689_26);
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
		class3548_0.method_0("none", Class3700.Class3702.class3689_4);
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
		List<Class3679> list = new List<Class3679>();
		do
		{
			list.Add(base.vmethod_0(lu, engine));
			lu = lu.NextLexicalUnit;
		}
		while (lu != null);
		return new Class3691(list);
	}
}
