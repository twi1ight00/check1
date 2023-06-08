using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5813 : Class5783
{
	internal static string Tag => "event";

	internal Class5813()
	{
		Class5906.smethod_6(this, "activity", XfaEnums.Activity.Click);
		Class5906.smethod_6(this, "listen", XfaEnums.Enum704.const_0);
		Class5906.smethod_4(this, "ref", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_65(this);
		base.vmethod_4(visitor);
		visitor.vmethod_66(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		Class5931 @class = new Class5931(new string[4]
		{
			Class5870.Tag,
			Class5885.Tag,
			Class5844.Tag,
			Class5851.Tag
		}, this);
		@class.method_0(reader, node, this);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5813();
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
