using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5879 : Class5782
{
	public float S => (float)method_5("short").Value;

	public float L => (float)method_5("long").Value;

	public XfaEnums.Enum736 Orientation => (XfaEnums.Enum736)method_5("orientation").Value;

	internal static string Tag => "medium";

	public Class5879()
	{
		Class5906.smethod_4(this, "imagingBBox", string.Empty);
		Class5906.smethod_1(this, "long", 0f);
		Class5906.smethod_6(this, "orientation", XfaEnums.Enum736.const_0);
		Class5906.smethod_1(this, "short", 0f);
		Class5906.smethod_4(this, "stock", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_109(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5879();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
