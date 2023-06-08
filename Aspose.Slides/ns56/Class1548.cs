using System.Xml;

namespace ns56;

internal class Class1548 : Class1351
{
	public delegate Class1548 Delegate523();

	public delegate void Delegate524(Class1548 elementData);

	public delegate void Delegate525(Class1548 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	public string Ref
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

	public string R_Id
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

	public string Location
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

	public string Tooltip
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

	public string Display
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
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
				case "display":
					string_4 = reader.Value;
					break;
				case "tooltip":
					string_3 = reader.Value;
					break;
				case "location":
					string_2 = reader.Value;
					break;
				case "r:id":
					string_1 = reader.Value;
					break;
				case "ref":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1548(XmlReader reader)
		: base(reader)
	{
	}

	public Class1548()
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
		writer.WriteAttributeString("ref", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("r:id", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("location", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("tooltip", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("display", string_4);
		}
		writer.WriteEndElement();
	}
}
