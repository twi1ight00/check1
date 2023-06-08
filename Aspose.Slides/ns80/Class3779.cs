using System.Collections.Generic;
using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3779 : Class3772
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "border-image-width";

	public override Enum600 PropertyType => Enum600.const_45;

	public override bool IsInheritedProperty => false;

	static Class3779()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("auto", Class3700.Class3702.class3689_3);
	}

	public override Class3679 vmethod_1()
	{
		return new Class3691(Class3700.Class3702.class3685_1);
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

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		Class3691 @class = (Class3691)value;
		if (@class.Length != 4)
		{
			IList<Class3679> value2 = new List<Class3679>(@class);
			value2 = Class3770.smethod_0(value2);
			@class = new Class3691(value2);
		}
		return base.vmethod_2(element, engine, pseudoElement, map, @class, propertyIndex);
	}
}
