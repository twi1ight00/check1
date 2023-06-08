using System.Xml;

namespace ns56;

internal class Class2206 : Class1351
{
	public delegate Class2206 Delegate2354();

	public delegate void Delegate2355(Class2206 elementData);

	public delegate void Delegate2356(Class2206 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const Enum352 enum352_1 = Enum352.const_0;

	public const Enum352 enum352_2 = Enum352.const_0;

	public const Enum352 enum352_3 = Enum352.const_0;

	public const Enum352 enum352_4 = Enum352.const_0;

	public const Enum352 enum352_5 = Enum352.const_0;

	public const Enum352 enum352_6 = Enum352.const_0;

	public const Enum352 enum352_7 = Enum352.const_0;

	public const Enum352 enum352_8 = Enum352.const_0;

	public const Enum352 enum352_9 = Enum352.const_0;

	public const Enum352 enum352_10 = Enum352.const_0;

	private Enum362 enum362_1;

	private Enum352 enum352_11;

	private Enum352 enum352_12;

	private Enum352 enum352_13;

	private Enum352 enum352_14;

	private Enum352 enum352_15;

	private Enum352 enum352_16;

	private Enum352 enum352_17;

	private Enum352 enum352_18;

	private Enum352 enum352_19;

	private Enum352 enum352_20;

	private Enum352 enum352_21;

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

	public Enum352 Position
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

	public Enum352 Selection
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

	public Enum352 Grouping
	{
		get
		{
			return enum352_13;
		}
		set
		{
			enum352_13 = value;
		}
	}

	public Enum352 Ungrouping
	{
		get
		{
			return enum352_14;
		}
		set
		{
			enum352_14 = value;
		}
	}

	public Enum352 Rotation
	{
		get
		{
			return enum352_15;
		}
		set
		{
			enum352_15 = value;
		}
	}

	public Enum352 Cropping
	{
		get
		{
			return enum352_16;
		}
		set
		{
			enum352_16 = value;
		}
	}

	public Enum352 Verticies
	{
		get
		{
			return enum352_17;
		}
		set
		{
			enum352_17 = value;
		}
	}

	public Enum352 Adjusthandles
	{
		get
		{
			return enum352_18;
		}
		set
		{
			enum352_18 = value;
		}
	}

	public Enum352 Text
	{
		get
		{
			return enum352_19;
		}
		set
		{
			enum352_19 = value;
		}
	}

	public Enum352 Aspectratio
	{
		get
		{
			return enum352_20;
		}
		set
		{
			enum352_20 = value;
		}
	}

	public Enum352 Shapetype
	{
		get
		{
			return enum352_21;
		}
		set
		{
			enum352_21 = value;
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
				case "position":
					enum352_11 = Class2488.smethod_0(reader.Value);
					break;
				case "selection":
					enum352_12 = Class2488.smethod_0(reader.Value);
					break;
				case "grouping":
					enum352_13 = Class2488.smethod_0(reader.Value);
					break;
				case "ungrouping":
					enum352_14 = Class2488.smethod_0(reader.Value);
					break;
				case "rotation":
					enum352_15 = Class2488.smethod_0(reader.Value);
					break;
				case "cropping":
					enum352_16 = Class2488.smethod_0(reader.Value);
					break;
				case "verticies":
					enum352_17 = Class2488.smethod_0(reader.Value);
					break;
				case "adjusthandles":
					enum352_18 = Class2488.smethod_0(reader.Value);
					break;
				case "text":
					enum352_19 = Class2488.smethod_0(reader.Value);
					break;
				case "aspectratio":
					enum352_20 = Class2488.smethod_0(reader.Value);
					break;
				case "shapetype":
					enum352_21 = Class2488.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2206(XmlReader reader)
		: base(reader)
	{
	}

	public Class2206()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		enum352_11 = Enum352.const_0;
		enum352_12 = Enum352.const_0;
		enum352_13 = Enum352.const_0;
		enum352_14 = Enum352.const_0;
		enum352_15 = Enum352.const_0;
		enum352_16 = Enum352.const_0;
		enum352_17 = Enum352.const_0;
		enum352_18 = Enum352.const_0;
		enum352_19 = Enum352.const_0;
		enum352_20 = Enum352.const_0;
		enum352_21 = Enum352.const_0;
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
		if (enum352_11 != 0)
		{
			writer.WriteAttributeString("position", Class2488.smethod_1(enum352_11));
		}
		if (enum352_12 != 0)
		{
			writer.WriteAttributeString("selection", Class2488.smethod_1(enum352_12));
		}
		if (enum352_13 != 0)
		{
			writer.WriteAttributeString("grouping", Class2488.smethod_1(enum352_13));
		}
		if (enum352_14 != 0)
		{
			writer.WriteAttributeString("ungrouping", Class2488.smethod_1(enum352_14));
		}
		if (enum352_15 != 0)
		{
			writer.WriteAttributeString("rotation", Class2488.smethod_1(enum352_15));
		}
		if (enum352_16 != 0)
		{
			writer.WriteAttributeString("cropping", Class2488.smethod_1(enum352_16));
		}
		if (enum352_17 != 0)
		{
			writer.WriteAttributeString("verticies", Class2488.smethod_1(enum352_17));
		}
		if (enum352_18 != 0)
		{
			writer.WriteAttributeString("adjusthandles", Class2488.smethod_1(enum352_18));
		}
		if (enum352_19 != 0)
		{
			writer.WriteAttributeString("text", Class2488.smethod_1(enum352_19));
		}
		if (enum352_20 != 0)
		{
			writer.WriteAttributeString("aspectratio", Class2488.smethod_1(enum352_20));
		}
		if (enum352_21 != 0)
		{
			writer.WriteAttributeString("shapetype", Class2488.smethod_1(enum352_21));
		}
		writer.WriteEndElement();
	}
}
