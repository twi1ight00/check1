using System;
using System.Xml;
using ns215;

namespace ns216;

internal class Class5868 : Class5782
{
	internal static string Tag => "encoding";

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_60(this);
	}

	internal override void vmethod_5(Class5932 reader, XmlNode node)
	{
		throw new NotImplementedException();
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5868();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}
}
