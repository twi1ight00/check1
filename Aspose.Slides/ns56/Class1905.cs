using System.Xml;

namespace ns56;

internal class Class1905 : Class1351
{
	public delegate Class1905 Delegate1582();

	public delegate void Delegate1583(Class1905 elementData);

	public delegate void Delegate1584(Class1905 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private Class1782 class1782_0;

	public string GdRefR
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

	public string MinR
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

	public string MaxR
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

	public string GdRefAng
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

	public string MinAng
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

	public string MaxAng
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public Class1782 Pos => class1782_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "pos")
				{
					class1782_0 = new Class1782(reader);
					continue;
				}
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
				case "gdRefR":
					string_0 = reader.Value;
					break;
				case "minR":
					string_1 = reader.Value;
					break;
				case "maxR":
					string_2 = reader.Value;
					break;
				case "gdRefAng":
					string_3 = reader.Value;
					break;
				case "minAng":
					string_4 = reader.Value;
					break;
				case "maxAng":
					string_5 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1905(XmlReader reader)
		: base(reader)
	{
	}

	public Class1905()
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
		class1782_0 = new Class1782();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("gdRefR", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("minR", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("maxR", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("gdRefAng", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("minAng", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("maxAng", string_5);
		}
		class1782_0.vmethod_4("a", writer, "pos");
		writer.WriteEndElement();
	}
}
