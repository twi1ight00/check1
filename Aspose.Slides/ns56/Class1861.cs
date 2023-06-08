using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1861 : Class1351
{
	public delegate Class1861 Delegate1462();

	public delegate void Delegate1463(Class1861 elementData);

	public delegate void Delegate1464(Class1861 elementData);

	public const BlackWhiteMode blackWhiteMode_0 = BlackWhiteMode.White;

	public Class1862.Delegate1465 delegate1465_0;

	public Class1862.Delegate1467 delegate1467_0;

	public Class1916.Delegate1615 delegate1615_0;

	public Class1916.Delegate1617 delegate1617_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	private BlackWhiteMode blackWhiteMode_1;

	private Class1862 class1862_0;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

	private Class1916 class1916_0;

	private Class1886 class1886_0;

	public BlackWhiteMode BwMode
	{
		get
		{
			return blackWhiteMode_1;
		}
		set
		{
			blackWhiteMode_1 = value;
		}
	}

	public Class1862 Xfrm => class1862_0;

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

	public Class1916 Scene3d => class1916_0;

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
				case "xfrm":
					class1862_0 = new Class1862(reader);
					break;
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
				case "scene3d":
					class1916_0 = new Class1916(reader);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "bwMode")
			{
				blackWhiteMode_1 = Class2517.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1861(XmlReader reader)
		: base(reader)
	{
	}

	public Class1861()
	{
	}

	protected override void vmethod_1()
	{
		blackWhiteMode_1 = BlackWhiteMode.White;
	}

	protected override void vmethod_2()
	{
		delegate1465_0 = method_3;
		delegate1467_0 = method_4;
		delegate2773_1 = method_10;
		delegate2773_0 = method_9;
		delegate1615_0 = method_5;
		delegate1617_0 = method_6;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (blackWhiteMode_1 != BlackWhiteMode.White)
		{
			writer.WriteAttributeString("bwMode", Class2517.smethod_1(blackWhiteMode_1));
		}
		if (class1862_0 != null)
		{
			class1862_0.vmethod_4("a", writer, "xfrm");
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
		if (class1916_0 != null)
		{
			class1916_0.vmethod_4("a", writer, "scene3d");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1862 method_3()
	{
		if (class1862_0 != null)
		{
			throw new Exception("Only one <xfrm> element can be added.");
		}
		class1862_0 = new Class1862();
		return class1862_0;
	}

	private void method_4(Class1862 _xfrm)
	{
		class1862_0 = _xfrm;
	}

	private Class1916 method_5()
	{
		if (class1916_0 != null)
		{
			throw new Exception("Only one <scene3d> element can be added.");
		}
		class1916_0 = new Class1916();
		return class1916_0;
	}

	private void method_6(Class1916 _scene3d)
	{
		class1916_0 = _scene3d;
	}

	private Class1885 method_7()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_8(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}

	private Class2605 method_9(string elementName)
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

	private Class2605 method_10(string elementName)
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
