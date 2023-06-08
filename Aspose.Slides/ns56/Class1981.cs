using System.Xml;

namespace ns56;

internal class Class1981 : Class1351
{
	public delegate Class1981 Delegate1810();

	public delegate void Delegate1811(Class1981 elementData);

	public delegate void Delegate1812(Class1981 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private Class1782 class1782_0;

	public string GdRefX
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

	public string MinX
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

	public string MaxX
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

	public string GdRefY
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

	public string MinY
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

	public string MaxY
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
				case "gdRefX":
					string_0 = reader.Value;
					break;
				case "minX":
					string_1 = reader.Value;
					break;
				case "maxX":
					string_2 = reader.Value;
					break;
				case "gdRefY":
					string_3 = reader.Value;
					break;
				case "minY":
					string_4 = reader.Value;
					break;
				case "maxY":
					string_5 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1981(XmlReader reader)
		: base(reader)
	{
	}

	public Class1981()
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
			writer.WriteAttributeString("gdRefX", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("minX", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("maxX", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("gdRefY", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("minY", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("maxY", string_5);
		}
		class1782_0.vmethod_4("a", writer, "pos");
		writer.WriteEndElement();
	}
}
