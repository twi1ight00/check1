using ns73;
using ns74;
using ns76;
using ns79;
using ns84;

namespace ns80;

internal class Class3855 : Class3854
{
	public override string PropertyName => "background-color";

	public override Enum600 PropertyType => Enum600.const_19;

	public override bool IsInheritedProperty => false;

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3688_175;
	}

	public override Class3679 vmethod_2(Interface91 element, Class3726 engine, string pseudoElement, Class4074 map, Class3679 value, int propertyIndex)
	{
		if (value != null && Class3700.Class3702.class3689_45 != value)
		{
			if (Class3700.Class3702.class3689_522 == value)
			{
				return engine.method_9(element, pseudoElement, engine.method_1(Enum600.const_71));
			}
		}
		else
		{
			value = Class3700.Class3702.class3688_175;
		}
		return base.vmethod_2(element, engine, pseudoElement, map, value, propertyIndex);
	}
}