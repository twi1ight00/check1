using System;
using System.Xml;

namespace ns56;

internal class Class2223 : Class1351
{
	public delegate Class2223 Delegate2405();

	public delegate void Delegate2406(Class2223 elementData);

	public delegate void Delegate2407(Class2223 elementData);

	public const bool bool_0 = false;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	private bool bool_1;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

	private Class1888 class1888_0;

	public bool ShadeToTitle
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class2605 FillProperties
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

	public Class2605 EffectProperties
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

	public Class1885 ExtLst => class1888_0;

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
				case "noFill":
					class2605_0 = new Class2605("noFill", new Class1878(reader));
					break;
				case "solidFill":
					class2605_0 = new Class2605("solidFill", new Class1924(reader));
					break;
				case "gradFill":
					class2605_0 = new Class2605("gradFill", new Class1853(reader));
					break;
				case "blipFill":
					class2605_0 = new Class2605("blipFill", new Class1810(reader));
					break;
				case "pattFill":
					class2605_0 = new Class2605("pattFill", new Class1900(reader));
					break;
				case "grpFill":
					class2605_0 = new Class2605("grpFill", new Class1859(reader));
					break;
				case "effectLst":
					class2605_1 = new Class2605("effectLst", new Class1833(reader));
					break;
				case "effectDag":
					class2605_1 = new Class2605("effectDag", new Class1832(reader));
					break;
				case "extLst":
					class1888_0 = new Class1888(reader);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "shadeToTitle")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2223(XmlReader reader)
		: base(reader)
	{
	}

	public Class2223()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
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
		if (bool_1)
		{
			writer.WriteAttributeString("shadeToTitle", bool_1 ? "1" : "0");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "noFill":
				((Class1878)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "solidFill":
				((Class1924)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "gradFill":
				((Class1853)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "blipFill":
				((Class1810)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "pattFill":
				((Class1900)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "grpFill":
				((Class1859)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "effectDag":
				((Class1832)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "effectLst":
				((Class1833)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}

	private Class2605 method_5(string elementName)
	{
		if (class2605_1 != null)
		{
			throw new Exception("EffectProperties already is initialized.");
		}
		switch (elementName)
		{
		case "effectDag":
			class2605_1 = new Class2605("effectDag", new Class1832());
			break;
		case "effectLst":
			class2605_1 = new Class2605("effectLst", new Class1833());
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
			throw new Exception("FillProperties already is initialized.");
		}
		switch (elementName)
		{
		case "noFill":
			class2605_0 = new Class2605("noFill", new Class1878());
			break;
		case "solidFill":
			class2605_0 = new Class2605("solidFill", new Class1924());
			break;
		case "gradFill":
			class2605_0 = new Class2605("gradFill", new Class1853());
			break;
		case "blipFill":
			class2605_0 = new Class2605("blipFill", new Class1810());
			break;
		case "pattFill":
			class2605_0 = new Class2605("pattFill", new Class1900());
			break;
		case "grpFill":
			class2605_0 = new Class2605("grpFill", new Class1859());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
