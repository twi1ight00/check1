using System;
using System.Xml;

namespace ns56;

internal class Class1932 : Class1351
{
	public delegate Class1932 Delegate1663();

	public delegate void Delegate1664(Class1932 elementData);

	public delegate void Delegate1665(Class1932 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

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

	public Class2605 ThemeableEffectStyle
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
				case "effectRef":
					class2605_1 = new Class2605("effectRef", new Class1929(reader));
					break;
				case "effect":
					class2605_1 = new Class2605("effect", new Class1834(reader));
					break;
				case "fillRef":
					class2605_0 = new Class2605("fillRef", new Class1929(reader));
					break;
				case "fill":
					class2605_0 = new Class2605("fill", new Class1842(reader));
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

	public Class1932(XmlReader reader)
		: base(reader)
	{
	}

	public Class1932()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2773_1 = method_4;
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
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
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "effectRef":
				((Class1929)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "effect":
				((Class1834)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_1 != null)
		{
			throw new Exception("ThemeableEffectStyle already is initialized.");
		}
		switch (elementName)
		{
		case "effectRef":
			class2605_1 = new Class2605("effectRef", new Class1929());
			break;
		case "effect":
			class2605_1 = new Class2605("effect", new Class1834());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_1;
	}

	private Class2605 method_4(string elementName)
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
