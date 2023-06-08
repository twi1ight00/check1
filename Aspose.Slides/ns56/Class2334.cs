using System.Xml;

namespace ns56;

internal class Class2334 : Class1351
{
	public delegate Class2334 Delegate2749();

	public delegate void Delegate2750(Class2334 elementData);

	public delegate void Delegate2751(Class2334 elementData);

	public const Enum371 enum371_0 = Enum371.const_0;

	public const Enum371 enum371_1 = Enum371.const_0;

	public const Enum371 enum371_2 = Enum371.const_0;

	public const Enum371 enum371_3 = Enum371.const_0;

	public const Enum371 enum371_4 = Enum371.const_0;

	private string string_0;

	private string string_1;

	private Enum371 enum371_5;

	private Enum371 enum371_6;

	private Enum371 enum371_7;

	private Enum371 enum371_8;

	private Enum371 enum371_9;

	private string string_2;

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

	public string Style
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

	public Enum371 On
	{
		get
		{
			return enum371_5;
		}
		set
		{
			enum371_5 = value;
		}
	}

	public Enum371 Fitshape
	{
		get
		{
			return enum371_6;
		}
		set
		{
			enum371_6 = value;
		}
	}

	public Enum371 Fitpath
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

	public Enum371 Trim
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

	public Enum371 Xscale
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

	public string String
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
				case "style":
					string_1 = reader.Value;
					break;
				case "on":
					enum371_5 = Class2507.smethod_0(reader.Value);
					break;
				case "fitshape":
					enum371_6 = Class2507.smethod_0(reader.Value);
					break;
				case "fitpath":
					enum371_7 = Class2507.smethod_0(reader.Value);
					break;
				case "trim":
					enum371_8 = Class2507.smethod_0(reader.Value);
					break;
				case "xscale":
					enum371_9 = Class2507.smethod_0(reader.Value);
					break;
				case "string":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2334(XmlReader reader)
		: base(reader)
	{
	}

	public Class2334()
	{
	}

	protected override void vmethod_1()
	{
		enum371_5 = Enum371.const_0;
		enum371_6 = Enum371.const_0;
		enum371_7 = Enum371.const_0;
		enum371_8 = Enum371.const_0;
		enum371_9 = Enum371.const_0;
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
			writer.WriteAttributeString("style", string_1);
		}
		if (enum371_5 != 0)
		{
			writer.WriteAttributeString("on", Class2507.smethod_1(enum371_5));
		}
		if (enum371_6 != 0)
		{
			writer.WriteAttributeString("fitshape", Class2507.smethod_1(enum371_6));
		}
		if (enum371_7 != 0)
		{
			writer.WriteAttributeString("fitpath", Class2507.smethod_1(enum371_7));
		}
		if (enum371_8 != 0)
		{
			writer.WriteAttributeString("trim", Class2507.smethod_1(enum371_8));
		}
		if (enum371_9 != 0)
		{
			writer.WriteAttributeString("xscale", Class2507.smethod_1(enum371_9));
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("string", string_2);
		}
		writer.WriteEndElement();
	}
}
