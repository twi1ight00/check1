using System.Xml;

namespace ns56;

internal class Class1376 : Class1351
{
	public delegate Class1376 Delegate90();

	public delegate void Delegate91(Class1376 elementData);

	public delegate void Delegate92(Class1376 elementData);

	public const bool bool_0 = true;

	private bool bool_1;

	public bool Val
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
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
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1376(XmlReader reader)
		: base(reader)
	{
	}

	public Class1376()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = true;
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
		if (!bool_1)
		{
			writer.WriteAttributeString("val", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
