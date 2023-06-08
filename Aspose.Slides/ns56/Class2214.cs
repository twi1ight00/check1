using System.Xml;

namespace ns56;

internal class Class2214 : Class1351
{
	public delegate Class2214 Delegate2378();

	public delegate void Delegate2379(Class2214 elementData);

	public delegate void Delegate2380(Class2214 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	public string R_Dm
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

	public string R_Lo
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string R_Qs
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string R_Cs
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "r:cs":
					string_3 = reader.Value;
					break;
				case "r:qs":
					string_2 = reader.Value;
					break;
				case "r:lo":
					string_1 = reader.Value;
					break;
				case "r:dm":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2214(XmlReader reader)
		: base(reader)
	{
	}

	public Class2214()
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
		writer.WriteStartElement("dgm", elementName, "http://schemas.openxmlformats.org/drawingml/2006/diagram");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		writer.WriteAttributeString("r:dm", string_0);
		writer.WriteAttributeString("r:lo", string_1);
		writer.WriteAttributeString("r:qs", string_2);
		writer.WriteAttributeString("r:cs", string_3);
		writer.WriteEndElement();
	}
}
