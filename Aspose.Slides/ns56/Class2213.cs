using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2213 : Class1351
{
	public delegate Class2213 Delegate2375();

	public delegate void Delegate2376(Class2213 elementData);

	public delegate void Delegate2377(Class2213 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const LineStyle lineStyle_0 = LineStyle.NotDefined;

	public const LineJoinStyle lineJoinStyle_0 = LineJoinStyle.NotDefined;

	public const LineCapStyle lineCapStyle_0 = LineCapStyle.NotDefined;

	public const Enum352 enum352_1 = Enum352.const_0;

	public const Enum364 enum364_0 = Enum364.const_0;

	public const Enum365 enum365_0 = Enum365.const_0;

	public const Enum352 enum352_2 = Enum352.const_0;

	public const Enum368 enum368_0 = Enum368.const_0;

	public const Enum369 enum369_0 = Enum369.const_0;

	public const Enum367 enum367_0 = Enum367.const_0;

	public const Enum368 enum368_1 = Enum368.const_0;

	public const Enum369 enum369_1 = Enum369.const_0;

	public const Enum367 enum367_1 = Enum367.const_0;

	public const Enum352 enum352_3 = Enum352.const_0;

	private Enum362 enum362_1;

	private Enum352 enum352_4;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private LineStyle lineStyle_1;

	private string string_4;

	private LineJoinStyle lineJoinStyle_1;

	private LineCapStyle lineCapStyle_1;

	private string string_5;

	private Enum352 enum352_5;

	private Enum364 enum364_1;

	private string string_6;

	private Enum365 enum365_1;

	private string string_7;

	private Enum352 enum352_6;

	private Enum368 enum368_2;

	private Enum369 enum369_2;

	private Enum367 enum367_2;

	private Enum368 enum368_3;

	private Enum369 enum369_3;

	private Enum367 enum367_3;

	private string string_8;

	private string string_9;

	private string string_10;

	private Enum352 enum352_7;

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
			return enum352_4;
		}
		set
		{
			enum352_4 = value;
		}
	}

	public string Weight
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

	public string Color2
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

	public string Opacity
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

	public LineStyle Linestyle
	{
		get
		{
			return lineStyle_1;
		}
		set
		{
			lineStyle_1 = value;
		}
	}

	public string Miterlimit
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

	public LineJoinStyle Joinstyle
	{
		get
		{
			return lineJoinStyle_1;
		}
		set
		{
			lineJoinStyle_1 = value;
		}
	}

	public LineCapStyle Endcap
	{
		get
		{
			return lineCapStyle_1;
		}
		set
		{
			lineCapStyle_1 = value;
		}
	}

	public string Dashstyle
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

	public Enum352 Insetpen
	{
		get
		{
			return enum352_5;
		}
		set
		{
			enum352_5 = value;
		}
	}

	public Enum364 Filltype
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

	public string Src
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

	public Enum365 Imageaspect
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

	public string Imagesize
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

	public Enum352 Imagealignshape
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

	public Enum368 Startarrow
	{
		get
		{
			return enum368_2;
		}
		set
		{
			enum368_2 = value;
		}
	}

	public Enum369 Startarrowwidth
	{
		get
		{
			return enum369_2;
		}
		set
		{
			enum369_2 = value;
		}
	}

	public Enum367 Startarrowlength
	{
		get
		{
			return enum367_2;
		}
		set
		{
			enum367_2 = value;
		}
	}

	public Enum368 Endarrow
	{
		get
		{
			return enum368_3;
		}
		set
		{
			enum368_3 = value;
		}
	}

	public Enum369 Endarrowwidth
	{
		get
		{
			return enum369_3;
		}
		set
		{
			enum369_3 = value;
		}
	}

	public Enum367 Endarrowlength
	{
		get
		{
			return enum367_3;
		}
		set
		{
			enum367_3 = value;
		}
	}

	public string O_Href
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

	public string O_Althref
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

	public string O_Title
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

	public Enum352 O_Forcedash
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
					enum352_4 = Class2488.smethod_0(reader.Value);
					break;
				case "weight":
					string_0 = reader.Value;
					break;
				case "color":
					string_1 = reader.Value;
					break;
				case "color2":
					string_2 = reader.Value;
					break;
				case "opacity":
					string_3 = reader.Value;
					break;
				case "linestyle":
					lineStyle_1 = Class2562.smethod_0(reader.Value);
					break;
				case "miterlimit":
					string_4 = reader.Value;
					break;
				case "joinstyle":
					lineJoinStyle_1 = Class2561.smethod_0(reader.Value);
					break;
				case "endcap":
					lineCapStyle_1 = Class2560.smethod_0(reader.Value);
					break;
				case "dashstyle":
					string_5 = reader.Value;
					break;
				case "insetpen":
					enum352_5 = Class2488.smethod_0(reader.Value);
					break;
				case "filltype":
					enum364_1 = Class2500.smethod_0(reader.Value);
					break;
				case "src":
					string_6 = reader.Value;
					break;
				case "imageaspect":
					enum365_1 = Class2501.smethod_0(reader.Value);
					break;
				case "imagesize":
					string_7 = reader.Value;
					break;
				case "imagealignshape":
					enum352_6 = Class2488.smethod_0(reader.Value);
					break;
				case "startarrow":
					enum368_2 = Class2504.smethod_0(reader.Value);
					break;
				case "startarrowwidth":
					enum369_2 = Class2505.smethod_0(reader.Value);
					break;
				case "startarrowlength":
					enum367_2 = Class2503.smethod_0(reader.Value);
					break;
				case "endarrow":
					enum368_3 = Class2504.smethod_0(reader.Value);
					break;
				case "endarrowwidth":
					enum369_3 = Class2505.smethod_0(reader.Value);
					break;
				case "endarrowlength":
					enum367_3 = Class2503.smethod_0(reader.Value);
					break;
				case "o:href":
					string_8 = reader.Value;
					break;
				case "o:althref":
					string_9 = reader.Value;
					break;
				case "o:title":
					string_10 = reader.Value;
					break;
				case "o:forcedash":
					enum352_7 = Class2488.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2213(XmlReader reader)
		: base(reader)
	{
	}

	public Class2213()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		enum352_4 = Enum352.const_0;
		lineStyle_1 = LineStyle.NotDefined;
		lineJoinStyle_1 = LineJoinStyle.NotDefined;
		lineCapStyle_1 = LineCapStyle.NotDefined;
		enum352_5 = Enum352.const_0;
		enum364_1 = Enum364.const_0;
		enum365_1 = Enum365.const_0;
		enum352_6 = Enum352.const_0;
		enum368_2 = Enum368.const_0;
		enum369_2 = Enum369.const_0;
		enum367_2 = Enum367.const_0;
		enum368_3 = Enum368.const_0;
		enum369_3 = Enum369.const_0;
		enum367_3 = Enum367.const_0;
		enum352_7 = Enum352.const_0;
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
		if (enum352_4 != 0)
		{
			writer.WriteAttributeString("on", Class2488.smethod_1(enum352_4));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("weight", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("color", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("color2", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("opacity", string_3);
		}
		if (lineStyle_1 != LineStyle.NotDefined)
		{
			writer.WriteAttributeString("linestyle", Class2562.smethod_1(lineStyle_1));
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("miterlimit", string_4);
		}
		if (lineJoinStyle_1 != LineJoinStyle.NotDefined)
		{
			writer.WriteAttributeString("joinstyle", Class2561.smethod_1(lineJoinStyle_1));
		}
		if (lineCapStyle_1 != LineCapStyle.NotDefined)
		{
			writer.WriteAttributeString("endcap", Class2560.smethod_1(lineCapStyle_1));
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("dashstyle", string_5);
		}
		if (enum352_5 != 0)
		{
			writer.WriteAttributeString("insetpen", Class2488.smethod_1(enum352_5));
		}
		if (enum364_1 != 0)
		{
			writer.WriteAttributeString("filltype", Class2500.smethod_1(enum364_1));
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("src", string_6);
		}
		if (enum365_1 != 0)
		{
			writer.WriteAttributeString("imageaspect", Class2501.smethod_1(enum365_1));
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("imagesize", string_7);
		}
		if (enum352_6 != 0)
		{
			writer.WriteAttributeString("imagealignshape", Class2488.smethod_1(enum352_6));
		}
		if (enum368_2 != 0)
		{
			writer.WriteAttributeString("startarrow", Class2504.smethod_1(enum368_2));
		}
		if (enum369_2 != 0)
		{
			writer.WriteAttributeString("startarrowwidth", Class2505.smethod_1(enum369_2));
		}
		if (enum367_2 != 0)
		{
			writer.WriteAttributeString("startarrowlength", Class2503.smethod_1(enum367_2));
		}
		if (enum368_3 != 0)
		{
			writer.WriteAttributeString("endarrow", Class2504.smethod_1(enum368_3));
		}
		if (enum369_3 != 0)
		{
			writer.WriteAttributeString("endarrowwidth", Class2505.smethod_1(enum369_3));
		}
		if (enum367_3 != 0)
		{
			writer.WriteAttributeString("endarrowlength", Class2503.smethod_1(enum367_3));
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("o:href", string_8);
		}
		if (string_9 != null)
		{
			writer.WriteAttributeString("o:althref", string_9);
		}
		if (string_10 != null)
		{
			writer.WriteAttributeString("o:title", string_10);
		}
		if (enum352_7 != 0)
		{
			writer.WriteAttributeString("o:forcedash", Class2488.smethod_1(enum352_7));
		}
		writer.WriteEndElement();
	}
}
