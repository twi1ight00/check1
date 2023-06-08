using System.Xml;

namespace ns56;

internal class Class2198 : Class1351
{
	public delegate Class2198 Delegate2330();

	public delegate void Delegate2331(Class2198 elementData);

	public delegate void Delegate2332(Class2198 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const Enum339 enum339_0 = Enum339.const_0;

	public const Enum352 enum352_1 = Enum352.const_0;

	public const Enum352 enum352_2 = Enum352.const_0;

	public const Enum352 enum352_3 = Enum352.const_0;

	public const Enum352 enum352_4 = Enum352.const_0;

	public const Enum352 enum352_5 = Enum352.const_0;

	private Enum362 enum362_1;

	private Enum352 enum352_6;

	private string string_0;

	private string string_1;

	private Enum339 enum339_1;

	private Enum352 enum352_7;

	private string string_2;

	private string string_3;

	private Enum352 enum352_8;

	private string string_4;

	private Enum352 enum352_9;

	private Enum352 enum352_10;

	private Enum352 enum352_11;

	private Enum352 enum352_12;

	public static readonly Enum352 enum352_13 = Class2488.smethod_0("f");

	public Enum362 V_Ext
	{
		get
		{
			return enum362_1;
		}
		set
		{
			enum362_1 = value;
		}
	}

	public Enum352 On
	{
		get
		{
			return enum352_6;
		}
		set
		{
			enum352_6 = value;
		}
	}

	public string Type
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

	public string Gap
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

	public Enum339 Angle
	{
		get
		{
			return enum339_1;
		}
		set
		{
			enum339_1 = value;
		}
	}

	public Enum352 Dropauto
	{
		get
		{
			return enum352_7;
		}
		set
		{
			enum352_7 = value;
		}
	}

	public string Drop
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

	public string Distance
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

	public Enum352 Lengthspecified
	{
		get
		{
			return enum352_8;
		}
		set
		{
			enum352_8 = value;
		}
	}

	public string Length
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

	public Enum352 Accentbar
	{
		get
		{
			return enum352_9;
		}
		set
		{
			enum352_9 = value;
		}
	}

	public Enum352 Textborder
	{
		get
		{
			return enum352_10;
		}
		set
		{
			enum352_10 = value;
		}
	}

	public Enum352 Minusx
	{
		get
		{
			return enum352_11;
		}
		set
		{
			enum352_11 = value;
		}
	}

	public Enum352 Minusy
	{
		get
		{
			return enum352_12;
		}
		set
		{
			enum352_12 = value;
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
				case "v:ext":
					enum362_1 = Class2498.smethod_0(reader.Value);
					break;
				case "on":
					enum352_6 = Class2488.smethod_0(reader.Value);
					break;
				case "type":
					string_0 = reader.Value;
					break;
				case "gap":
					string_1 = reader.Value;
					break;
				case "angle":
					enum339_1 = Class2471.smethod_0(reader.Value);
					break;
				case "dropauto":
					enum352_7 = Class2488.smethod_0(reader.Value);
					break;
				case "drop":
					string_2 = reader.Value;
					break;
				case "distance":
					string_3 = reader.Value;
					break;
				case "lengthspecified":
					enum352_8 = Class2488.smethod_0(reader.Value);
					break;
				case "length":
					string_4 = reader.Value;
					break;
				case "accentbar":
					enum352_9 = Class2488.smethod_0(reader.Value);
					break;
				case "textborder":
					enum352_10 = Class2488.smethod_0(reader.Value);
					break;
				case "minusx":
					enum352_11 = Class2488.smethod_0(reader.Value);
					break;
				case "minusy":
					enum352_12 = Class2488.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2198(XmlReader reader)
		: base(reader)
	{
	}

	public Class2198()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		enum352_6 = Enum352.const_0;
		enum339_1 = Enum339.const_0;
		enum352_7 = Enum352.const_0;
		enum352_8 = enum352_13;
		enum352_9 = Enum352.const_0;
		enum352_10 = Enum352.const_0;
		enum352_11 = Enum352.const_0;
		enum352_12 = Enum352.const_0;
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
		if (enum362_1 != 0)
		{
			writer.WriteAttributeString("v:ext", Class2498.smethod_1(enum362_1));
		}
		if (enum352_6 != 0)
		{
			writer.WriteAttributeString("on", Class2488.smethod_1(enum352_6));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("type", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("gap", string_1);
		}
		if (enum339_1 != 0)
		{
			writer.WriteAttributeString("angle", Class2471.smethod_1(enum339_1));
		}
		if (enum352_7 != 0)
		{
			writer.WriteAttributeString("dropauto", Class2488.smethod_1(enum352_7));
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("drop", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("distance", string_3);
		}
		if (enum352_8 != enum352_13)
		{
			writer.WriteAttributeString("lengthspecified", Class2488.smethod_1(enum352_8));
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("length", string_4);
		}
		if (enum352_9 != 0)
		{
			writer.WriteAttributeString("accentbar", Class2488.smethod_1(enum352_9));
		}
		if (enum352_10 != 0)
		{
			writer.WriteAttributeString("textborder", Class2488.smethod_1(enum352_10));
		}
		if (enum352_11 != 0)
		{
			writer.WriteAttributeString("minusx", Class2488.smethod_1(enum352_11));
		}
		if (enum352_12 != 0)
		{
			writer.WriteAttributeString("minusy", Class2488.smethod_1(enum352_12));
		}
		writer.WriteEndElement();
	}
}
