using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2333 : Class1351
{
	public delegate Class2333 Delegate2746();

	public delegate void Delegate2747(Class2333 elementData);

	public delegate void Delegate2748(Class2333 elementData);

	public const Enum371 enum371_0 = Enum371.const_0;

	public const LineStyle lineStyle_0 = LineStyle.NotDefined;

	public const LineJoinStyle lineJoinStyle_0 = LineJoinStyle.NotDefined;

	public const LineCapStyle lineCapStyle_0 = LineCapStyle.NotDefined;

	public const Enum364 enum364_0 = Enum364.const_0;

	public const Enum365 enum365_0 = Enum365.const_0;

	public const Enum371 enum371_1 = Enum371.const_0;

	public const Enum368 enum368_0 = Enum368.const_0;

	public const Enum369 enum369_0 = Enum369.const_0;

	public const Enum367 enum367_0 = Enum367.const_0;

	public const Enum368 enum368_1 = Enum368.const_0;

	public const Enum369 enum369_1 = Enum369.const_0;

	public const Enum367 enum367_1 = Enum367.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const Enum371 enum371_2 = Enum371.const_0;

	public Class2213.Delegate2375 delegate2375_0;

	public Class2213.Delegate2377 delegate2377_0;

	public Class2213.Delegate2375 delegate2375_1;

	public Class2213.Delegate2377 delegate2377_1;

	public Class2213.Delegate2375 delegate2375_2;

	public Class2213.Delegate2377 delegate2377_2;

	public Class2213.Delegate2375 delegate2375_3;

	public Class2213.Delegate2377 delegate2377_3;

	public Class2213.Delegate2375 delegate2375_4;

	public Class2213.Delegate2377 delegate2377_4;

	private string string_0;

	private Enum371 enum371_3;

	private string string_1;

	private string string_2;

	private string string_3;

	private LineStyle lineStyle_1;

	private string string_4;

	private LineJoinStyle lineJoinStyle_1;

	private LineCapStyle lineCapStyle_1;

	private string string_5;

	private Enum364 enum364_1;

	private string string_6;

	private Enum365 enum365_1;

	private string string_7;

	private Enum371 enum371_4;

	private string string_8;

	private Enum368 enum368_2;

	private Enum369 enum369_2;

	private Enum367 enum367_2;

	private Enum368 enum368_3;

	private Enum369 enum369_3;

	private Enum367 enum367_3;

	private string string_9;

	private string string_10;

	private string string_11;

	private Enum352 enum352_1;

	private string string_12;

	private Enum371 enum371_5;

	private string string_13;

	private Class2213 class2213_0;

	private Class2213 class2213_1;

	private Class2213 class2213_2;

	private Class2213 class2213_3;

	private Class2213 class2213_4;

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
			return enum371_3;
		}
		set
		{
			enum371_3 = value;
		}
	}

	public string Weight
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

	public string Color
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

	public Enum371 Imagealignshape
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

	public string Color2
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
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public string O_Althref
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

	public string O_Title
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

	public Enum352 O_Forcedash
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

	public string R_Id
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

	public Enum371 Insetpen
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

	public string O_Relid
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

	public Class2213 Left => class2213_0;

	public Class2213 Top => class2213_1;

	public Class2213 Right => class2213_2;

	public Class2213 Bottom => class2213_3;

	public Class2213 Column => class2213_4;

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
				switch (reader.LocalName)
				{
				case "column":
					class2213_4 = new Class2213(reader);
					break;
				case "bottom":
					class2213_3 = new Class2213(reader);
					break;
				case "right":
					class2213_2 = new Class2213(reader);
					break;
				case "top":
					class2213_1 = new Class2213(reader);
					break;
				case "left":
					class2213_0 = new Class2213(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
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
					enum371_3 = Class2507.smethod_0(reader.Value);
					break;
				case "weight":
					string_1 = reader.Value;
					break;
				case "color":
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
					enum371_4 = Class2507.smethod_0(reader.Value);
					break;
				case "color2":
					string_8 = reader.Value;
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
					string_9 = reader.Value;
					break;
				case "o:althref":
					string_10 = reader.Value;
					break;
				case "o:title":
					string_11 = reader.Value;
					break;
				case "o:forcedash":
					enum352_1 = Class2488.smethod_0(reader.Value);
					break;
				case "r:id":
					string_12 = reader.Value;
					break;
				case "insetpen":
					enum371_5 = Class2507.smethod_0(reader.Value);
					break;
				case "o:relid":
					string_13 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2333(XmlReader reader)
		: base(reader)
	{
	}

	public Class2333()
	{
	}

	protected override void vmethod_1()
	{
		enum371_3 = Enum371.const_0;
		lineStyle_1 = LineStyle.NotDefined;
		lineJoinStyle_1 = LineJoinStyle.NotDefined;
		lineCapStyle_1 = LineCapStyle.NotDefined;
		enum364_1 = Enum364.const_0;
		enum365_1 = Enum365.const_0;
		enum371_4 = Enum371.const_0;
		enum368_2 = Enum368.const_0;
		enum369_2 = Enum369.const_0;
		enum367_2 = Enum367.const_0;
		enum368_3 = Enum368.const_0;
		enum369_3 = Enum369.const_0;
		enum367_3 = Enum367.const_0;
		enum352_1 = Enum352.const_0;
		enum371_5 = Enum371.const_0;
	}

	protected override void vmethod_2()
	{
		delegate2375_0 = method_3;
		delegate2377_0 = method_4;
		delegate2375_1 = method_5;
		delegate2377_1 = method_6;
		delegate2375_2 = method_7;
		delegate2377_2 = method_8;
		delegate2375_3 = method_9;
		delegate2377_3 = method_10;
		delegate2375_4 = method_11;
		delegate2377_4 = method_12;
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
		if (enum371_3 != 0)
		{
			writer.WriteAttributeString("on", Class2507.smethod_1(enum371_3));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("weight", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("color", string_2);
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
		if (enum371_4 != 0)
		{
			writer.WriteAttributeString("imagealignshape", Class2507.smethod_1(enum371_4));
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("color2", string_8);
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
		if (string_9 != null)
		{
			writer.WriteAttributeString("o:href", string_9);
		}
		if (string_10 != null)
		{
			writer.WriteAttributeString("o:althref", string_10);
		}
		if (string_11 != null)
		{
			writer.WriteAttributeString("o:title", string_11);
		}
		if (enum352_1 != 0)
		{
			writer.WriteAttributeString("o:forcedash", Class2488.smethod_1(enum352_1));
		}
		if (string_12 != null)
		{
			writer.WriteAttributeString("r:id", string_12);
		}
		if (enum371_5 != 0)
		{
			writer.WriteAttributeString("insetpen", Class2507.smethod_1(enum371_5));
		}
		if (string_13 != null)
		{
			writer.WriteAttributeString("o:relid", string_13);
		}
		if (class2213_0 != null)
		{
			class2213_0.vmethod_4("o", writer, "left");
		}
		if (class2213_1 != null)
		{
			class2213_1.vmethod_4("o", writer, "top");
		}
		if (class2213_2 != null)
		{
			class2213_2.vmethod_4("o", writer, "right");
		}
		if (class2213_3 != null)
		{
			class2213_3.vmethod_4("o", writer, "bottom");
		}
		if (class2213_4 != null)
		{
			class2213_4.vmethod_4("o", writer, "column");
		}
		writer.WriteEndElement();
	}

	private Class2213 method_3()
	{
		if (class2213_0 != null)
		{
			throw new Exception("Only one <left> element can be added.");
		}
		class2213_0 = new Class2213();
		return class2213_0;
	}

	private void method_4(Class2213 _left)
	{
		class2213_0 = _left;
	}

	private Class2213 method_5()
	{
		if (class2213_1 != null)
		{
			throw new Exception("Only one <top> element can be added.");
		}
		class2213_1 = new Class2213();
		return class2213_1;
	}

	private void method_6(Class2213 _top)
	{
		class2213_1 = _top;
	}

	private Class2213 method_7()
	{
		if (class2213_2 != null)
		{
			throw new Exception("Only one <right> element can be added.");
		}
		class2213_2 = new Class2213();
		return class2213_2;
	}

	private void method_8(Class2213 _right)
	{
		class2213_2 = _right;
	}

	private Class2213 method_9()
	{
		if (class2213_3 != null)
		{
			throw new Exception("Only one <bottom> element can be added.");
		}
		class2213_3 = new Class2213();
		return class2213_3;
	}

	private void method_10(Class2213 _bottom)
	{
		class2213_3 = _bottom;
	}

	private Class2213 method_11()
	{
		if (class2213_4 != null)
		{
			throw new Exception("Only one <column> element can be added.");
		}
		class2213_4 = new Class2213();
		return class2213_4;
	}

	private void method_12(Class2213 _column)
	{
		class2213_4 = _column;
	}
}
