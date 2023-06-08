using System.Xml;

namespace ns56;

internal class Class2192 : Class1351
{
	public delegate Class2192 Delegate2308();

	public delegate void Delegate2309(Class2192 elementData);

	public delegate void Delegate2310(Class2192 elementData);

	private Class1997 class1997_0;

	public Class1995 SpTree => class1997_0;

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "spTree")
				{
					class1997_0 = new Class1997(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2192(XmlReader reader)
		: base(reader)
	{
	}

	public Class2192()
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
		class1997_0 = new Class1997();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("dsp", elementName, "http://schemas.microsoft.com/office/drawing/2008/diagram");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		class1997_0.vmethod_4("dsp", writer, "spTree");
		writer.WriteEndElement();
	}
}
