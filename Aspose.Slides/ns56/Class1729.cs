using System.Xml;

namespace ns56;

internal class Class1729 : Class1351
{
	public delegate Class1729 Delegate1066();

	public delegate void Delegate1067(Class1729 elementData);

	public delegate void Delegate1068(Class1729 elementData);

	private Enum252 enum252_0;

	public static readonly Enum252 enum252_1 = Class2419.smethod_0("single");

	public Enum252 Val
	{
		get
		{
			return enum252_0;
		}
		set
		{
			enum252_0 = value;
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
				enum252_0 = Class2419.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1729(XmlReader reader)
		: base(reader)
	{
	}

	public Class1729()
	{
	}

	protected override void vmethod_1()
	{
		enum252_0 = enum252_1;
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
		if (enum252_0 != enum252_1)
		{
			writer.WriteAttributeString("val", Class2419.smethod_1(enum252_0));
		}
		writer.WriteEndElement();
	}
}
