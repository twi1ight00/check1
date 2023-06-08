using System;
using System.Xml;

namespace ns56;

internal class Class2339 : Class1351
{
	public delegate Class2339 Delegate2763();

	public delegate void Delegate2764(Class2339 elementData);

	internal const bool bool_0 = true;

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
		string namespaceURI = reader.NamespaceURI;
		while (reader.MoveToNextAttribute())
		{
			if (!(reader.Prefix == "xmlns"))
			{
				string text;
				if ((text = ((reader.LookupNamespace(reader.Prefix) == namespaceURI) ? reader.LocalName : reader.Name)) == null || !(text == "val"))
				{
					throw new Exception("Unknown attribute \"" + reader.Name + "\"");
				}
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	internal Class2339(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2339()
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
		writer.WriteAttributeString("val", bool_1 ? "1" : "0");
		writer.WriteEndElement();
	}
}
