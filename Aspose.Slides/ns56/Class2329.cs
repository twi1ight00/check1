using System.Xml;

namespace ns56;

internal class Class2329 : Class1351
{
	public delegate Class2329 Delegate2734();

	public delegate void Delegate2735(Class2329 elementData);

	public delegate void Delegate2736(Class2329 elementData);

	public const Enum371 enum371_0 = Enum371.const_0;

	public const Enum371 enum371_1 = Enum371.const_0;

	public const Enum370 enum370_0 = Enum370.const_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private Enum371 enum371_2;

	private Enum371 enum371_3;

	private Enum370 enum370_1;

	private string string_3;

	private string string_4;

	private string string_5;

	public string Position
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

	public string Polar
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

	public string Map
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

	public Enum371 Invx
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

	public Enum371 Invy
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

	public Enum370 Switch
	{
		get
		{
			return enum370_1;
		}
		set
		{
			enum370_1 = value;
		}
	}

	public string Xrange
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

	public string Yrange
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

	public string Radiusrange
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
				case "position":
					string_0 = reader.Value;
					break;
				case "polar":
					string_1 = reader.Value;
					break;
				case "map":
					string_2 = reader.Value;
					break;
				case "invx":
					enum371_2 = Class2507.smethod_0(reader.Value);
					break;
				case "invy":
					enum371_3 = Class2507.smethod_0(reader.Value);
					break;
				case "switch":
					enum370_1 = Class2506.smethod_0(reader.Value);
					break;
				case "xrange":
					string_3 = reader.Value;
					break;
				case "yrange":
					string_4 = reader.Value;
					break;
				case "radiusrange":
					string_5 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2329(XmlReader reader)
		: base(reader)
	{
	}

	public Class2329()
	{
	}

	protected override void vmethod_1()
	{
		enum371_2 = Enum371.const_0;
		enum371_3 = Enum371.const_0;
		enum370_1 = Enum370.const_0;
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
			writer.WriteAttributeString("position", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("polar", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("map", string_2);
		}
		if (enum371_2 != 0)
		{
			writer.WriteAttributeString("invx", Class2507.smethod_1(enum371_2));
		}
		if (enum371_3 != 0)
		{
			writer.WriteAttributeString("invy", Class2507.smethod_1(enum371_3));
		}
		if (enum370_1 != 0)
		{
			writer.WriteAttributeString("switch", Class2506.smethod_1(enum370_1));
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("xrange", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("yrange", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("radiusrange", string_5);
		}
		writer.WriteEndElement();
	}
}
