using System.Xml;
using ns215;

namespace ns216;

internal class Class5883 : Class5782
{
	internal static string Tag => "reason";

	public Class5883()
	{
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_135(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		reader.method_6(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5883();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
