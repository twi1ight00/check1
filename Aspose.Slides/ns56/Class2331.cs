using System.Xml;

namespace ns56;

internal class Class2331 : Class1351
{
	public delegate Class2331 Delegate2740();

	public delegate void Delegate2741(Class2331 elementData);

	public delegate void Delegate2742(Class2331 elementData);

	public const Enum371 enum371_0 = Enum371.const_0;

	public const Enum371 enum371_1 = Enum371.const_0;

	public const Enum371 enum371_2 = Enum371.const_0;

	public const Enum371 enum371_3 = Enum371.const_0;

	public const Enum371 enum371_4 = Enum371.const_0;

	public const Enum371 enum371_5 = Enum371.const_0;

	public const Enum371 enum371_6 = Enum371.const_0;

	public const Enum342 enum342_0 = Enum342.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private Enum371 enum371_7;

	private Enum371 enum371_8;

	private Enum371 enum371_9;

	private Enum371 enum371_10;

	private Enum371 enum371_11;

	private Enum371 enum371_12;

	private Enum371 enum371_13;

	private Enum342 enum342_1;

	private string string_4;

	private string string_5;

	private Enum352 enum352_1;

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

	public string V
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

	public string Limo
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

	public string Textboxrect
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

	public Enum371 Fillok
	{
		get
		{
			return enum371_7;
		}
		set
		{
			enum371_7 = value;
		}
	}

	public Enum371 Strokeok
	{
		get
		{
			return enum371_8;
		}
		set
		{
			enum371_8 = value;
		}
	}

	public Enum371 Shadowok
	{
		get
		{
			return enum371_9;
		}
		set
		{
			enum371_9 = value;
		}
	}

	public Enum371 Arrowok
	{
		get
		{
			return enum371_10;
		}
		set
		{
			enum371_10 = value;
		}
	}

	public Enum371 Gradientshapeok
	{
		get
		{
			return enum371_11;
		}
		set
		{
			enum371_11 = value;
		}
	}

	public Enum371 Textpathok
	{
		get
		{
			return enum371_12;
		}
		set
		{
			enum371_12 = value;
		}
	}

	public Enum371 Insetpenok
	{
		get
		{
			return enum371_13;
		}
		set
		{
			enum371_13 = value;
		}
	}

	public Enum342 O_Connecttype
	{
		get
		{
			return enum342_1;
		}
		set
		{
			enum342_1 = value;
		}
	}

	public string O_Connectlocs
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

	public string O_Connectangles
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

	public Enum352 O_Extrusionok
	{
		get
		{
			return enum352_1;
		}
		set
		{
			enum352_1 = value;
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
				case "v":
					string_1 = reader.Value;
					break;
				case "limo":
					string_2 = reader.Value;
					break;
				case "textboxrect":
					string_3 = reader.Value;
					break;
				case "fillok":
					enum371_7 = Class2507.smethod_0(reader.Value);
					break;
				case "strokeok":
					enum371_8 = Class2507.smethod_0(reader.Value);
					break;
				case "shadowok":
					enum371_9 = Class2507.smethod_0(reader.Value);
					break;
				case "arrowok":
					enum371_10 = Class2507.smethod_0(reader.Value);
					break;
				case "gradientshapeok":
					enum371_11 = Class2507.smethod_0(reader.Value);
					break;
				case "textpathok":
					enum371_12 = Class2507.smethod_0(reader.Value);
					break;
				case "insetpenok":
					enum371_13 = Class2507.smethod_0(reader.Value);
					break;
				case "o:connecttype":
					enum342_1 = Class2478.smethod_0(reader.Value);
					break;
				case "o:connectlocs":
					string_4 = reader.Value;
					break;
				case "o:connectangles":
					string_5 = reader.Value;
					break;
				case "o:extrusionok":
					enum352_1 = Class2488.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2331(XmlReader reader)
		: base(reader)
	{
	}

	public Class2331()
	{
	}

	protected override void vmethod_1()
	{
		enum371_7 = Enum371.const_0;
		enum371_8 = Enum371.const_0;
		enum371_9 = Enum371.const_0;
		enum371_10 = Enum371.const_0;
		enum371_11 = Enum371.const_0;
		enum371_12 = Enum371.const_0;
		enum371_13 = Enum371.const_0;
		enum342_1 = Enum342.const_0;
		enum352_1 = Enum352.const_0;
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
		if (string_1 != null)
		{
			writer.WriteAttributeString("v", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("limo", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("textboxrect", string_3);
		}
		if (enum371_7 != 0)
		{
			writer.WriteAttributeString("fillok", Class2507.smethod_1(enum371_7));
		}
		if (enum371_8 != 0)
		{
			writer.WriteAttributeString("strokeok", Class2507.smethod_1(enum371_8));
		}
		if (enum371_9 != 0)
		{
			writer.WriteAttributeString("shadowok", Class2507.smethod_1(enum371_9));
		}
		if (enum371_10 != 0)
		{
			writer.WriteAttributeString("arrowok", Class2507.smethod_1(enum371_10));
		}
		if (enum371_11 != 0)
		{
			writer.WriteAttributeString("gradientshapeok", Class2507.smethod_1(enum371_11));
		}
		if (enum371_12 != 0)
		{
			writer.WriteAttributeString("textpathok", Class2507.smethod_1(enum371_12));
		}
		if (enum371_13 != 0)
		{
			writer.WriteAttributeString("insetpenok", Class2507.smethod_1(enum371_13));
		}
		if (enum342_1 != 0)
		{
			writer.WriteAttributeString("o:connecttype", Class2478.smethod_1(enum342_1));
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("o:connectlocs", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("o:connectangles", string_5);
		}
		if (enum352_1 != 0)
		{
			writer.WriteAttributeString("o:extrusionok", Class2488.smethod_1(enum352_1));
		}
		writer.WriteEndElement();
	}
}
