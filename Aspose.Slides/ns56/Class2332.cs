using System.Xml;

namespace ns56;

internal class Class2332 : Class1351
{
	public delegate Class2332 Delegate2743();

	public delegate void Delegate2744(Class2332 elementData);

	public delegate void Delegate2745(Class2332 elementData);

	public const Enum371 enum371_0 = Enum371.const_0;

	public const Enum366 enum366_0 = Enum366.const_0;

	public const Enum371 enum371_1 = Enum371.const_0;

	private string string_0;

	private Enum371 enum371_2;

	private Enum366 enum366_1;

	private Enum371 enum371_3;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	public string Id
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

	public Enum371 On
	{
		get
		{
			return enum371_2;
		}
		set
		{
			enum371_2 = value;
		}
	}

	public Enum366 Type
	{
		get
		{
			return enum366_1;
		}
		set
		{
			enum366_1 = value;
		}
	}

	public Enum371 Obscured
	{
		get
		{
			return enum371_3;
		}
		set
		{
			enum371_3 = value;
		}
	}

	public string Color
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

	public string Opacity
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

	public string Offset
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

	public string Color2
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

	public string Offset2
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

	public string Origin
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string Matrix
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
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
				case "id":
					string_0 = reader.Value;
					break;
				case "on":
					enum371_2 = Class2507.smethod_0(reader.Value);
					break;
				case "type":
					enum366_1 = Class2502.smethod_0(reader.Value);
					break;
				case "obscured":
					enum371_3 = Class2507.smethod_0(reader.Value);
					break;
				case "color":
					string_1 = reader.Value;
					break;
				case "opacity":
					string_2 = reader.Value;
					break;
				case "offset":
					string_3 = reader.Value;
					break;
				case "color2":
					string_4 = reader.Value;
					break;
				case "offset2":
					string_5 = reader.Value;
					break;
				case "origin":
					string_6 = reader.Value;
					break;
				case "matrix":
					string_7 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2332(XmlReader reader)
		: base(reader)
	{
	}

	public Class2332()
	{
	}

	protected override void vmethod_1()
	{
		enum371_2 = Enum371.const_0;
		enum366_1 = Enum366.const_0;
		enum371_3 = Enum371.const_0;
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
		if (string_0 != null)
		{
			writer.WriteAttributeString("id", string_0);
		}
		if (enum371_2 != 0)
		{
			writer.WriteAttributeString("on", Class2507.smethod_1(enum371_2));
		}
		if (enum366_1 != 0)
		{
			writer.WriteAttributeString("type", Class2502.smethod_1(enum366_1));
		}
		if (enum371_3 != 0)
		{
			writer.WriteAttributeString("obscured", Class2507.smethod_1(enum371_3));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("color", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("opacity", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("offset", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("color2", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("offset2", string_5);
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("origin", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("matrix", string_7);
		}
		writer.WriteEndElement();
	}
}
