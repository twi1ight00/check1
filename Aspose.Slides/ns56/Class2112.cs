using System.Xml;

namespace ns56;

internal class Class2112 : Class1351
{
	public delegate Class2112 Delegate2062();

	public delegate void Delegate2063(Class2112 elementData);

	public delegate void Delegate2064(Class2112 elementData);

	private Enum323 enum323_0;

	public static readonly Enum323 enum323_1 = Class2451.smethod_0("marker");

	public Enum323 Val
	{
		get
		{
			return enum323_0;
		}
		set
		{
			enum323_0 = value;
		}
	}

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				_ = reader.LocalName;
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "val")
			{
				enum323_0 = Class2451.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2112(XmlReader reader)
		: base(reader)
	{
	}

	public Class2112()
	{
	}

	protected override void vmethod_1()
	{
		enum323_0 = enum323_1;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum323_0 != enum323_1)
		{
			writer.WriteAttributeString("val", Class2451.smethod_1(enum323_0));
		}
		writer.WriteEndElement();
	}
}
