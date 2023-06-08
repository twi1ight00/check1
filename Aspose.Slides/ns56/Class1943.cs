using System;
using System.Xml;

namespace ns56;

internal class Class1943 : Class1351
{
	public delegate Class1943 Delegate1696();

	public delegate void Delegate1698(Class1943 elementData);

	public delegate void Delegate1697(Class1943 elementData);

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	private Enum307 enum307_0;

	private Enum307 enum307_1;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

	private Class1886 class1886_0;

	public static readonly Enum307 enum307_2 = Class2540.smethod_0("def");

	public static readonly Enum307 enum307_3 = Class2540.smethod_0("def");

	public Enum307 B
	{
		get
		{
			return enum307_0;
		}
		set
		{
			enum307_0 = value;
		}
	}

	public Enum307 I
	{
		get
		{
			return enum307_1;
		}
		set
		{
			enum307_1 = value;
		}
	}

	public Class2605 ThemeableFontStyles
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
		}
	}

	public Class2605 Color
	{
		get
		{
			return class2605_1;
		}
		set
		{
			class2605_1 = value;
		}
	}

	public Class1885 ExtLst => class1886_0;

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
				case "font":
					class2605_0 = new Class2605("font", new Class1845(reader));
					break;
				case "fontRef":
					class2605_0 = new Class2605("fontRef", new Class1846(reader));
					break;
				case "scrgbClr":
					class2605_1 = new Class2605("scrgbClr", new Class1918(reader));
					break;
				case "srgbClr":
					class2605_1 = new Class2605("srgbClr", new Class1926(reader));
					break;
				case "hslClr":
					class2605_1 = new Class2605("hslClr", new Class1863(reader));
					break;
				case "sysClr":
					class2605_1 = new Class2605("sysClr", new Class1931(reader));
					break;
				case "schemeClr":
					class2605_1 = new Class2605("schemeClr", new Class1917(reader));
					break;
				case "prstClr":
					class2605_1 = new Class2605("prstClr", new Class1907(reader));
					break;
				case "extLst":
					class1886_0 = new Class1886(reader);
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
				case "i":
					enum307_1 = Class2540.smethod_0(reader.Value);
					break;
				case "b":
					enum307_0 = Class2540.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1943(XmlReader reader)
		: base(reader)
	{
	}

	public Class1943()
	{
	}

	protected override void vmethod_1()
	{
		enum307_0 = enum307_2;
		enum307_1 = enum307_3;
	}

	protected override void vmethod_2()
	{
		delegate2773_1 = method_6;
		delegate2773_0 = method_5;
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum307_0 != enum307_2)
		{
			writer.WriteAttributeString("b", Class2540.smethod_1(enum307_0));
		}
		if (enum307_1 != enum307_3)
		{
			writer.WriteAttributeString("i", Class2540.smethod_1(enum307_1));
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "fontRef":
				((Class1846)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "font":
				((Class1845)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "scrgbClr":
				((Class1918)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "srgbClr":
				((Class1926)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "hslClr":
				((Class1863)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "sysClr":
				((Class1931)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "schemeClr":
				((Class1917)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "prstClr":
				((Class1907)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}

	private Class2605 method_5(string elementName)
	{
		if (class2605_1 != null)
		{
			throw new Exception("Color already is initialized.");
		}
		switch (elementName)
		{
		case "scrgbClr":
			class2605_1 = new Class2605("scrgbClr", new Class1918());
			break;
		case "srgbClr":
			class2605_1 = new Class2605("srgbClr", new Class1926());
			break;
		case "hslClr":
			class2605_1 = new Class2605("hslClr", new Class1863());
			break;
		case "sysClr":
			class2605_1 = new Class2605("sysClr", new Class1931());
			break;
		case "schemeClr":
			class2605_1 = new Class2605("schemeClr", new Class1917());
			break;
		case "prstClr":
			class2605_1 = new Class2605("prstClr", new Class1907());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_1;
	}

	private Class2605 method_6(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("ThemeableFontStyles already is initialized.");
		}
		switch (elementName)
		{
		case "fontRef":
			class2605_0 = new Class2605("fontRef", new Class1846());
			break;
		case "font":
			class2605_0 = new Class2605("font", new Class1845());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
