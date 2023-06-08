using System.Xml;
using ns215;

namespace ns216;

internal class Class5867 : Class5782
{
	internal static string Tag => "digestMethod";

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_53(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		reader.method_6(node);
		base.vmethod_5(reader, node);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5867();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
