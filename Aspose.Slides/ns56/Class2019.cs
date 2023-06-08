using System.Xml;

namespace ns56;

internal class Class2019 : Class1351
{
	public delegate Class2019 Delegate1846();

	public delegate void Delegate1847(Class2019 elementData);

	public delegate void Delegate1848(Class2019 elementData);

	private string string_0;

	public string R_Id
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "r:id")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2019(XmlReader reader)
		: base(reader)
	{
	}

	public Class2019()
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
		writer.WriteStartElement("c", elementName, "http://schemas.openxmlformats.org/drawingml/2006/chart");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		writer.WriteAttributeString("r:id", string_0);
		writer.WriteEndElement();
	}
}
