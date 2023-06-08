using System.Xml;
using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5858 : Class5782
{
	internal static string Tag => "appearanceFilter";

	public Class5858()
	{
		Class5906.smethod_6(this, "type", XfaEnums.Enum730.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_0(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		reader.method_6(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5858();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
