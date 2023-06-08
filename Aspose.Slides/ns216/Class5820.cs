using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5820 : Class5783
{
	internal static string Tag => "font";

	internal float Size => (float)method_5("size").Value;

	internal string Typeface => (string)method_5("typeface").Value;

	internal XfaEnums.Enum710 Weight => (XfaEnums.Enum710)method_5("weight").Value;

	internal XfaEnums.Enum709 Posture => (XfaEnums.Enum709)method_5("posture").Value;

	public Class5820()
	{
		Class5906.smethod_1(this, "baselineShift", 0f);
		Class5906.smethod_1(this, "fontHorizontalScale", 0f);
		Class5906.smethod_1(this, "fontVerticalScale", 0f);
		Class5906.smethod_6(this, "kerningMode", XfaEnums.Enum707.const_0);
		Class5906.smethod_1(this, "letterSpacing", 0f);
		Class5906.smethod_2(this, "lineThrough", 0);
		Class5906.smethod_6(this, "lineThroughPeriod", XfaEnums.Enum708.const_0);
		Class5906.smethod_2(this, "overline", 0);
		Class5906.smethod_6(this, "overlinePeriod", XfaEnums.Enum708.const_0);
		Class5906.smethod_6(this, "posture", XfaEnums.Enum709.const_0);
		Class5906.smethod_1(this, "size", 10f);
		Class5906.smethod_4(this, "typeface", "Arial");
		Class5906.smethod_2(this, "underline", 0);
		Class5906.smethod_6(this, "underlinePeriod", XfaEnums.Enum708.const_0);
		Class5906.smethod_6(this, "weight", XfaEnums.Enum710.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_82(this);
		base.vmethod_4(visitor);
		visitor.vmethod_83(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5820();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5816.Tag,
			Class5818.Tag
		};
	}
}
