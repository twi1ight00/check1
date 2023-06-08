using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5836 : Class5783
{
	internal static string Tag => "para";

	internal XfaEnums.Enum719 HAlign => (XfaEnums.Enum719)method_5("hAlign").Value;

	internal XfaEnums.Enum720 VAlign => (XfaEnums.Enum720)method_5("vAlign").Value;

	internal float LineHeight => (float)method_5("lineHeight").Value;

	internal float MarginLeft => (float)method_5("marginLeft").Value;

	internal float MarginRight => (float)method_5("marginRight").Value;

	internal int Orphans => (int)method_5("orphans").Value;

	internal string Preserve => (string)method_5("preserve").Value;

	internal float RadixOffset => (float)method_5("radixOffset").Value;

	internal float SpaceAbove => (float)method_5("spaceAbove").Value;

	internal float SpaceBelow => (float)method_5("spaceBelow").Value;

	internal string TabDefault => (string)method_5("tabDefault").Value;

	internal string TabStops => (string)method_5("tabStops").Value;

	internal float TextIndent => (float)method_5("textIndent").Value;

	public Class5836()
	{
		Class5906.smethod_6(this, "hAlign", XfaEnums.Enum719.const_0);
		Class5906.smethod_6(this, "vAlign", XfaEnums.Enum720.const_0);
		Class5906.smethod_1(this, "lineHeight", 0f);
		Class5906.smethod_1(this, "marginLeft", 0f);
		Class5906.smethod_1(this, "marginRight", 0f);
		Class5906.smethod_2(this, "orphans", 0);
		Class5906.smethod_1(this, "radixOffset", 0f);
		Class5906.smethod_2(this, "preserve", 0);
		Class5906.smethod_1(this, "spaceAbove", 0f);
		Class5906.smethod_1(this, "spaceBelow", 0f);
		Class5906.smethod_4(this, "tabDefault", string.Empty);
		Class5906.smethod_4(this, "tabStops", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
		Class5906.smethod_1(this, "textIndent", 0f);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_124(this);
		base.vmethod_4(visitor);
		visitor.vmethod_125(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5836();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5873.Tag };
	}
}
