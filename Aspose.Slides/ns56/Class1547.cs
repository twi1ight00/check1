using System.Xml;

namespace ns56;

internal class Class1547 : Class1351
{
	public delegate Class1547 Delegate520();

	public delegate void Delegate521(Class1547 elementData);

	public delegate void Delegate522(Class1547 elementData);

	private int int_0;

	public int HierarchyUsage
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "hierarchyUsage")
			{
				int_0 = XmlConvert.ToInt32(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1547(XmlReader reader)
		: base(reader)
	{
	}

	public Class1547()
	{
	}

	protected override void vmethod_1()
	{
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
		writer.WriteAttributeString("hierarchyUsage", XmlConvert.ToString(int_0));
		writer.WriteEndElement();
	}
}
