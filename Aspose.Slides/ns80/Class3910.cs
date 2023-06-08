using ns72;
using ns73;
using ns74;
using ns76;
using ns79;
using ns84;
using ns88;

namespace ns80;

internal class Class3910 : Class3850
{
	private static Class3548<Class3679> class3548_0;

	public override string PropertyName => "font-variant-alternates";

	public override Enum600 PropertyType => Enum600.const_125;

	public override bool IsInheritedProperty => true;

	static Class3910()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("normal", Class3700.Class3702.class3689_5);
		class3548_0.method_0("stylistic", Class3700.Class3702.class3689_90);
		class3548_0.method_0("historical-forms", Class3700.Class3702.class3689_91);
		class3548_0.method_0("styleset", Class3700.Class3702.class3689_92);
		class3548_0.method_0("character-variant", Class3700.Class3702.class3689_93);
		class3548_0.method_0("swash", Class3700.Class3702.class3689_94);
		class3548_0.method_0("ornaments", Class3700.Class3702.class3689_95);
		class3548_0.method_0("annotation", Class3700.Class3702.class3689_96);
	}

	public override Class3679 vmethod_1()
	{
		return Class3700.Class3702.class3689_5;
	}

	public override Class3548<Class3679> vmethod_3()
	{
		return class3548_0;
	}

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		if (lu.LexicalUnitType == 41)
		{
			string text = lu.imethod_3().ToLowerInvariant();
			text = text.Substring(0, text.Length - 1);
			switch (text)
			{
			case "styleset":
			{
				Interface99 interface2 = lu.imethod_4();
				if (interface2 == null)
				{
					throw method_4(text);
				}
				return new Class3694(text, Class3689.smethod_1(interface2.imethod_5()));
			}
			case "stylistic":
			{
				Interface99 @interface = lu.imethod_4();
				if (@interface == null)
				{
					throw method_4(text);
				}
				return new Class3694(text, Class3689.smethod_1(@interface.imethod_5()));
			}
			}
		}
		return base.vmethod_0(lu, engine);
	}
}
