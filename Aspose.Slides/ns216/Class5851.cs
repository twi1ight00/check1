using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5851 : Class5783
{
	internal static string Tag => "submit";

	public Class5851()
	{
		Class5906.smethod_3(this, "embedPDF", @default: false);
		Class5906.smethod_6(this, "format", XfaEnums.Enum727.const_0);
		Class5906.smethod_4(this, "target", string.Empty);
		Class5906.smethod_4(this, "textEncoding", string.Empty);
		Class5906.smethod_4(this, "xdpContent", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_161(this);
		base.vmethod_4(visitor);
		visitor.vmethod_162(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5851();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[2]
		{
			Class5812.Tag,
			Class5844.Tag
		};
	}
}
