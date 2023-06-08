using System;
using System.Xml;

namespace ns56;

internal class Class1941 : Class1351
{
	public delegate Class1941 Delegate1690();

	public delegate void Delegate1692(Class1941 elementData);

	public delegate void Delegate1691(Class1941 elementData);

	public Class1933.Delegate1666 delegate1666_0;

	public Class1933.Delegate1668 delegate1668_0;

	public Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	public Class2605.Delegate2773 delegate2773_0;

	private Class1933 class1933_0;

	private Class2605 class2605_0;

	private Class1456 class1456_0;

	public Class1933 TcBdr => class1933_0;

	public Class2605 ThemeableFillStyle
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

	public Class1456 Cell3D => class1456_0;

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
				case "cell3D":
					class1456_0 = new Class1456(reader);
					flag = true;
					break;
				case "fillRef":
					class2605_0 = new Class2605("fillRef", new Class1929(reader));
					break;
				case "fill":
					class2605_0 = new Class2605("fill", new Class1842(reader));
					break;
				case "tcBdr":
					class1933_0 = new Class1933(reader);
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
	}

	public Class1941(XmlReader reader)
		: base(reader)
	{
	}

	public Class1941()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1666_0 = method_3;
		delegate1668_0 = method_4;
		delegate2773_0 = method_7;
		delegate303_0 = method_5;
		delegate304_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1933_0 != null)
		{
			class1933_0.vmethod_4("a", writer, "tcBdr");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "fillRef":
				((Class1929)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "fill":
				((Class1842)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class1456_0 != null)
		{
			class1456_0.vmethod_4("a", writer, "cell3D");
		}
		writer.WriteEndElement();
	}

	private Class1933 method_3()
	{
		if (class1933_0 != null)
		{
			throw new Exception("Only one <tcBdr> element can be added.");
		}
		class1933_0 = new Class1933();
		return class1933_0;
	}

	private void method_4(Class1933 _tcBdr)
	{
		class1933_0 = _tcBdr;
	}

	private Class1447 method_5()
	{
		if (class1456_0 != null)
		{
			throw new Exception("Only one <cell3D> element can be added.");
		}
		class1456_0 = new Class1456();
		return class1456_0;
	}

	private void method_6(Class1447 _cell3D)
	{
		class1456_0 = (Class1456)_cell3D;
	}

	private Class2605 method_7(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("ThemeableFillStyle already is initialized.");
		}
		switch (elementName)
		{
		case "fillRef":
			class2605_0 = new Class2605("fillRef", new Class1929());
			break;
		case "fill":
			class2605_0 = new Class2605("fill", new Class1842());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
