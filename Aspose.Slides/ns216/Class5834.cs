using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5834 : Class5783, Interface249
{
	internal static string Tag => "pageArea";

	public XfaEnums.Enum706 LayoutType => XfaEnums.Enum706.const_0;

	public Class5834()
	{
		Class5906.smethod_6(this, "blankOrNotBlank", XfaEnums.Enum715.const_0);
		Class5906.smethod_2(this, "initialNumber", 1);
		Class5906.smethod_3(this, "numbered", @default: true);
		Class5906.smethod_6(this, "oddOrEven", XfaEnums.Enum716.const_0);
		Class5906.smethod_6(this, "pagePosition", XfaEnums.Enum717.const_0);
		Class5906.smethod_4(this, "relevant", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_120(this);
		base.vmethod_4(visitor);
		visitor.vmethod_121(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5834();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[10]
		{
			Class5807.Tag,
			Class5816.Tag,
			Class5879.Tag,
			Class5832.Tag,
			Class5786.Tag,
			Class5802.Tag,
			"draw",
			"exclGroup",
			"field",
			"subform"
		};
	}
}
