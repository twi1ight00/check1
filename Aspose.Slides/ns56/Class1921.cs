using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1921 : Class1351
{
	public delegate Class1921 Delegate1630();

	public delegate void Delegate1632(Class1921 elementData);

	public delegate void Delegate1631(Class1921 elementData);

	public const BlackWhiteMode blackWhiteMode_0 = BlackWhiteMode.White;

	public Class1976.Delegate1795 delegate1795_0;

	public Class1976.Delegate1797 delegate1797_0;

	public Class1875.Delegate1504 delegate1504_0;

	public Class1875.Delegate1506 delegate1506_0;

	public Class1916.Delegate1615 delegate1615_0;

	public Class1916.Delegate1617 delegate1617_0;

	public Class1919.Delegate1624 delegate1624_0;

	public Class1919.Delegate1626 delegate1626_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	public Class2605.Delegate2773 delegate2773_2;

	private BlackWhiteMode blackWhiteMode_1;

	private Class1976 class1976_0;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

	private Class1875 class1875_0;

	private Class2605 class2605_2;

	private Class1916 class1916_0;

	private Class1919 class1919_0;

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

	public Class1976 Xfrm => class1976_0;

	public Class2605 Geometry
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

	public Class2605 FillProperties
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

	public Class1875 Ln => class1875_0;

	public Class2605 EffectProperties
	{
		get
		{
			return class2605_2;
		}
		set
		{
			class2605_2 = value;
		}
	}

	public Class1916 Scene3d => class1916_0;

	public Class1919 Sp3d => class1919_0;

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
					class1976_0 = new Class1976(reader);
					break;
				case "custGeom":
					class2605_0 = new Class2605("custGeom", new Class1828(reader));
					break;
				case "prstGeom":
					class2605_0 = new Class2605("prstGeom", new Class1908(reader));
					break;
				case "noFill":
					class2605_1 = new Class2605("noFill", new Class1878(reader));
					break;
				case "solidFill":
					class2605_1 = new Class2605("solidFill", new Class1924(reader));
					break;
				case "gradFill":
					class2605_1 = new Class2605("gradFill", new Class1853(reader));
					break;
				case "blipFill":
					class2605_1 = new Class2605("blipFill", new Class1810(reader));
					break;
				case "pattFill":
					class2605_1 = new Class2605("pattFill", new Class1900(reader));
					break;
				case "grpFill":
					class2605_1 = new Class2605("grpFill", new Class1859(reader));
					break;
				case "ln":
					class1875_0 = new Class1875(reader);
					break;
				case "effectLst":
					class2605_2 = new Class2605("effectLst", new Class1833(reader));
					break;
				case "effectDag":
					class2605_2 = new Class2605("effectDag", new Class1832(reader));
					break;
				case "scene3d":
					class1916_0 = new Class1916(reader);
					break;
				case "sp3d":
					class1919_0 = new Class1919(reader);
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

	public Class1921(XmlReader reader)
		: base(reader)
	{
	}

	public Class1921()
	{
	}

	protected override void vmethod_1()
	{
		blackWhiteMode_1 = BlackWhiteMode.White;
	}

	protected override void vmethod_2()
	{
		delegate1795_0 = method_3;
		delegate1797_0 = method_4;
		delegate2773_2 = method_15;
		delegate2773_1 = method_14;
		delegate1504_0 = method_5;
		delegate1506_0 = method_6;
		delegate2773_0 = method_13;
		delegate1615_0 = method_7;
		delegate1617_0 = method_8;
		delegate1624_0 = method_9;
		delegate1626_0 = method_10;
		delegate1534_0 = method_11;
		delegate1535_0 = method_12;
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
		if (class1976_0 != null)
		{
			class1976_0.vmethod_4("a", writer, "xfrm");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "prstGeom":
				((Class1908)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "custGeom":
				((Class1828)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "noFill":
				((Class1878)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "solidFill":
				((Class1924)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "gradFill":
				((Class1853)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "blipFill":
				((Class1810)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "pattFill":
				((Class1900)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "grpFill":
				((Class1859)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		if (class1875_0 != null)
		{
			class1875_0.vmethod_4("a", writer, "ln");
		}
		if (class2605_2 != null)
		{
			switch (class2605_2.Name)
			{
			case "effectDag":
				((Class1832)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			case "effectLst":
				((Class1833)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			}
		}
		if (class1916_0 != null)
		{
			class1916_0.vmethod_4("a", writer, "scene3d");
		}
		if (class1919_0 != null)
		{
			class1919_0.vmethod_4("a", writer, "sp3d");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1976 method_3()
	{
		if (class1976_0 != null)
		{
			throw new Exception("Only one <xfrm> element can be added.");
		}
		class1976_0 = new Class1976();
		return class1976_0;
	}

	private void method_4(Class1976 _xfrm)
	{
		class1976_0 = _xfrm;
	}

	private Class1875 method_5()
	{
		if (class1875_0 != null)
		{
			throw new Exception("Only one <ln> element can be added.");
		}
		class1875_0 = new Class1875();
		return class1875_0;
	}

	private void method_6(Class1875 _ln)
	{
		class1875_0 = _ln;
	}

	private Class1916 method_7()
	{
		if (class1916_0 != null)
		{
			throw new Exception("Only one <scene3d> element can be added.");
		}
		class1916_0 = new Class1916();
		return class1916_0;
	}

	private void method_8(Class1916 _scene3d)
	{
		class1916_0 = _scene3d;
	}

	private Class1919 method_9()
	{
		if (class1919_0 != null)
		{
			throw new Exception("Only one <sp3d> element can be added.");
		}
		class1919_0 = new Class1919();
		return class1919_0;
	}

	private void method_10(Class1919 _sp3d)
	{
		class1919_0 = _sp3d;
	}

	private Class1885 method_11()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_12(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}

	private Class2605 method_13(string elementName)
	{
		if (class2605_2 != null)
		{
			throw new Exception("EffectProperties already is initialized.");
		}
		switch (elementName)
		{
		case "effectDag":
			class2605_2 = new Class2605("effectDag", new Class1832());
			break;
		case "effectLst":
			class2605_2 = new Class2605("effectLst", new Class1833());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_2;
	}

	private Class2605 method_14(string elementName)
	{
		if (class2605_1 != null)
		{
			throw new Exception("FillProperties already is initialized.");
		}
		switch (elementName)
		{
		case "noFill":
			class2605_1 = new Class2605("noFill", new Class1878());
			break;
		case "solidFill":
			class2605_1 = new Class2605("solidFill", new Class1924());
			break;
		case "gradFill":
			class2605_1 = new Class2605("gradFill", new Class1853());
			break;
		case "blipFill":
			class2605_1 = new Class2605("blipFill", new Class1810());
			break;
		case "pattFill":
			class2605_1 = new Class2605("pattFill", new Class1900());
			break;
		case "grpFill":
			class2605_1 = new Class2605("grpFill", new Class1859());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_1;
	}

	private Class2605 method_15(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Geometry already is initialized.");
		}
		switch (elementName)
		{
		case "prstGeom":
			class2605_0 = new Class2605("prstGeom", new Class1908());
			break;
		case "custGeom":
			class2605_0 = new Class2605("custGeom", new Class1828());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
