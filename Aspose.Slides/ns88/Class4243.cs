using ns72;
using ns73;
using ns76;

namespace ns88;

internal class Class4243 : Interface100
{
	private Class3709 class3709_0;

	private static Class3548<Class3679> class3548_0;

	static Class4243()
	{
		class3548_0 = new Class3548<Class3679>();
		class3548_0.method_0("repeating", Class3700.Class3702.class3689_247);
		class3548_0.method_0("numeric", Class3700.Class3702.class3689_248);
		class3548_0.method_0("alphabetic", Class3700.Class3702.class3689_38);
		class3548_0.method_0("symbolic", Class3700.Class3702.class3689_249);
		class3548_0.method_0("additive", Class3700.Class3702.class3689_250);
		class3548_0.method_0("non-repeating", Class3700.Class3702.class3689_251);
	}

	public Class4243(Class3709 rule)
	{
		class3709_0 = rule;
	}

	public void imethod_0(string name, Interface99 lu, bool important)
	{
		switch (name.ToLowerInvariant())
		{
		case "fallback":
		{
			if (lu.LexicalUnitType != 36)
			{
				throw Class4246.smethod_11(lu.LexicalUnitType);
			}
			Class3679 @class = class3548_0.method_1(lu.imethod_5());
			class3709_0.Fallback = ((Class3680)@class).vmethod_3();
			break;
		}
		case "glyphs":
			do
			{
				if (lu.LexicalUnitType == 36)
				{
					class3709_0.Glyphs.Add(lu.imethod_5());
					lu = lu.NextLexicalUnit;
					continue;
				}
				throw Class4246.smethod_11(lu.LexicalUnitType);
			}
			while (lu != null);
			break;
		case "prefix":
			if (lu.LexicalUnitType != 36)
			{
				throw Class4246.smethod_11(lu.LexicalUnitType);
			}
			class3709_0.Prefix = lu.imethod_5();
			break;
		case "suffix":
			if (lu.LexicalUnitType != 36)
			{
				throw Class4246.smethod_11(lu.LexicalUnitType);
			}
			class3709_0.Suffix = lu.imethod_5();
			break;
		case "type":
		{
			if (lu.LexicalUnitType != 35)
			{
				throw Class4246.smethod_11(lu.LexicalUnitType);
			}
			Class3679 @class = class3548_0.method_1(lu.imethod_5());
			if (@class == null)
			{
				throw Class4246.smethod_7(lu.imethod_5());
			}
			class3709_0.CounterType = ((Class3680)@class).vmethod_3();
			break;
		}
		default:
			class3709_0.ParentStyleSheet.Engine.ErrorHandler.imethod_0(new Exception11($"Invalid property name '{name}'."));
			break;
		}
	}
}
