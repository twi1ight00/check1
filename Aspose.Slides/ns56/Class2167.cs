using System.Xml;

namespace ns56;

internal class Class2167 : Class1351
{
	public delegate Class2167 Delegate2233();

	public delegate void Delegate2234(Class2167 elementData);

	public delegate void Delegate2235(Class2167 elementData);

	private Enum331 enum331_0;

	public static readonly Enum331 enum331_1 = Class2462.smethod_0("norm");

	public Enum331 Val
	{
		get
		{
			return enum331_0;
		}
		set
		{
			enum331_0 = value;
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
				enum331_0 = Class2462.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2167(XmlReader reader)
		: base(reader)
	{
	}

	public Class2167()
	{
	}

	protected override void vmethod_1()
	{
		enum331_0 = enum331_1;
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
		if (enum331_0 != enum331_1)
		{
			writer.WriteAttributeString("val", Class2462.smethod_1(enum331_0));
		}
		writer.WriteEndElement();
	}
}
