using System;
using System.Xml;

namespace ns56;

internal class Class2326 : Class1351
{
	public delegate Class2326 Delegate2725();

	public delegate void Delegate2726(Class2326 elementData);

	public delegate void Delegate2727(Class2326 elementData);

	public const Enum364 enum364_0 = Enum364.const_0;

	public const Enum371 enum371_0 = Enum371.const_0;

	public const Enum365 enum365_0 = Enum365.const_0;

	public const Enum371 enum371_1 = Enum371.const_0;

	public const Enum363 enum363_0 = Enum363.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const Enum371 enum371_2 = Enum371.const_0;

	public const Enum371 enum371_3 = Enum371.const_0;

	public Class2203.Delegate2345 delegate2345_0;

	public Class2203.Delegate2347 delegate2347_0;

	private string string_0;

	private Enum364 enum364_1;

	private Enum371 enum371_4;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private string string_9;

	private Enum365 enum365_1;

	private string string_10;

	private string string_11;

	private Enum371 enum371_5;

	private string string_12;

	private string string_13;

	private string string_14;

	private Enum363 enum363_1;

	private Enum352 enum352_1;

	private string string_15;

	private string string_16;

	private Enum371 enum371_6;

	private Enum371 enum371_7;

	private string string_17;

	private string string_18;

	private Class2203 class2203_0;

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

	public Enum364 Type
	{
		get
		{
			return enum364_1;
		}
		set
		{
			enum364_1 = value;
		}
	}

	public Enum371 On
	{
		get
		{
			return enum371_4;
		}
		set
		{
			enum371_4 = value;
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

	public string Color2
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

	public string Src
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

	public string O_Href
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

	public string O_Althref
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

	public string Size
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

	public string Origin
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string Position
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public Enum365 Aspect
	{
		get
		{
			return enum365_1;
		}
		set
		{
			enum365_1 = value;
		}
	}

	public string Colors
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public string Angle
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public Enum371 Alignshape
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

	public string Focus
	{
		get
		{
			return string_12;
		}
		set
		{
			string_12 = value;
		}
	}

	public string Focussize
	{
		get
		{
			return string_13;
		}
		set
		{
			string_13 = value;
		}
	}

	public string Focusposition
	{
		get
		{
			return string_14;
		}
		set
		{
			string_14 = value;
		}
	}

	public Enum363 Method
	{
		get
		{
			return enum363_1;
		}
		set
		{
			enum363_1 = value;
		}
	}

	public Enum352 O_Detectmouseclick
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

	public string O_Title
	{
		get
		{
			return string_15;
		}
		set
		{
			string_15 = value;
		}
	}

	public string O_Opacity2
	{
		get
		{
			return string_16;
		}
		set
		{
			string_16 = value;
		}
	}

	public Enum371 Recolor
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

	public Enum371 Rotate
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

	public string R_Id
	{
		get
		{
			return string_17;
		}
		set
		{
			string_17 = value;
		}
	}

	public string O_Relid
	{
		get
		{
			return string_18;
		}
		set
		{
			string_18 = value;
		}
	}

	public Class2203 Fill => class2203_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "fill")
				{
					class2203_0 = new Class2203(reader);
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
				case "id":
					string_0 = reader.Value;
					break;
				case "type":
					enum364_1 = Class2500.smethod_0(reader.Value);
					break;
				case "on":
					enum371_4 = Class2507.smethod_0(reader.Value);
					break;
				case "color":
					string_1 = reader.Value;
					break;
				case "opacity":
					string_2 = reader.Value;
					break;
				case "color2":
					string_3 = reader.Value;
					break;
				case "src":
					string_4 = reader.Value;
					break;
				case "o:href":
					string_5 = reader.Value;
					break;
				case "o:althref":
					string_6 = reader.Value;
					break;
				case "size":
					string_7 = reader.Value;
					break;
				case "origin":
					string_8 = reader.Value;
					break;
				case "position":
					string_9 = reader.Value;
					break;
				case "aspect":
					enum365_1 = Class2501.smethod_0(reader.Value);
					break;
				case "colors":
					string_10 = reader.Value;
					break;
				case "angle":
					string_11 = reader.Value;
					break;
				case "alignshape":
					enum371_5 = Class2507.smethod_0(reader.Value);
					break;
				case "focus":
					string_12 = reader.Value;
					break;
				case "focussize":
					string_13 = reader.Value;
					break;
				case "focusposition":
					string_14 = reader.Value;
					break;
				case "method":
					enum363_1 = Class2499.smethod_0(reader.Value);
					break;
				case "o:detectmouseclick":
					enum352_1 = Class2488.smethod_0(reader.Value);
					break;
				case "o:title":
					string_15 = reader.Value;
					break;
				case "o:opacity2":
					string_16 = reader.Value;
					break;
				case "recolor":
					enum371_6 = Class2507.smethod_0(reader.Value);
					break;
				case "rotate":
					enum371_7 = Class2507.smethod_0(reader.Value);
					break;
				case "r:id":
					string_17 = reader.Value;
					break;
				case "o:relid":
					string_18 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2326(XmlReader reader)
		: base(reader)
	{
	}

	public Class2326()
	{
	}

	protected override void vmethod_1()
	{
		enum364_1 = Enum364.const_0;
		enum371_4 = Enum371.const_0;
		enum365_1 = Enum365.const_0;
		enum371_5 = Enum371.const_0;
		enum363_1 = Enum363.const_0;
		enum352_1 = Enum352.const_0;
		enum371_6 = Enum371.const_0;
		enum371_7 = Enum371.const_0;
	}

	protected override void vmethod_2()
	{
		delegate2345_0 = method_3;
		delegate2347_0 = method_4;
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
		if (enum364_1 != 0)
		{
			writer.WriteAttributeString("type", Class2500.smethod_1(enum364_1));
		}
		if (enum371_4 != 0)
		{
			writer.WriteAttributeString("on", Class2507.smethod_1(enum371_4));
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
			writer.WriteAttributeString("color2", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("src", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("o:href", string_5);
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("o:althref", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("size", string_7);
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("origin", string_8);
		}
		if (string_9 != null)
		{
			writer.WriteAttributeString("position", string_9);
		}
		if (enum365_1 != 0)
		{
			writer.WriteAttributeString("aspect", Class2501.smethod_1(enum365_1));
		}
		if (string_10 != null)
		{
			writer.WriteAttributeString("colors", string_10);
		}
		if (string_11 != null)
		{
			writer.WriteAttributeString("angle", string_11);
		}
		if (enum371_5 != 0)
		{
			writer.WriteAttributeString("alignshape", Class2507.smethod_1(enum371_5));
		}
		if (string_12 != null)
		{
			writer.WriteAttributeString("focus", string_12);
		}
		if (string_13 != null)
		{
			writer.WriteAttributeString("focussize", string_13);
		}
		if (string_14 != null)
		{
			writer.WriteAttributeString("focusposition", string_14);
		}
		if (enum363_1 != 0)
		{
			writer.WriteAttributeString("method", Class2499.smethod_1(enum363_1));
		}
		if (enum352_1 != 0)
		{
			writer.WriteAttributeString("o:detectmouseclick", Class2488.smethod_1(enum352_1));
		}
		if (string_15 != null)
		{
			writer.WriteAttributeString("o:title", string_15);
		}
		if (string_16 != null)
		{
			writer.WriteAttributeString("o:opacity2", string_16);
		}
		if (enum371_6 != 0)
		{
			writer.WriteAttributeString("recolor", Class2507.smethod_1(enum371_6));
		}
		if (enum371_7 != 0)
		{
			writer.WriteAttributeString("rotate", Class2507.smethod_1(enum371_7));
		}
		if (string_17 != null)
		{
			writer.WriteAttributeString("r:id", string_17);
		}
		if (string_18 != null)
		{
			writer.WriteAttributeString("o:relid", string_18);
		}
		if (class2203_0 != null)
		{
			class2203_0.vmethod_4("o", writer, "fill");
		}
		writer.WriteEndElement();
	}

	private Class2203 method_3()
	{
		if (class2203_0 != null)
		{
			throw new Exception("Only one <fill> element can be added.");
		}
		class2203_0 = new Class2203();
		return class2203_0;
	}

	private void method_4(Class2203 _fill)
	{
		class2203_0 = _fill;
	}
}
