using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5825 : Class5783
{
	public XfaEnums.Enum712 Intact => (XfaEnums.Enum712)method_5("intact").Value;

	public XfaEnums.Enum712 Next => (XfaEnums.Enum712)method_5("next").Value;

	internal static string Tag => "keep";

	public Class5825()
	{
		Class5906.smethod_6(this, "intact", XfaEnums.Enum712.const_0);
		Class5906.smethod_6(this, "next", XfaEnums.Enum712.const_0);
		Class5906.smethod_6(this, "previous", XfaEnums.Enum712.const_0);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_96(this);
		base.vmethod_4(visitor);
		visitor.vmethod_97(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5825();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5816.Tag };
	}
}
