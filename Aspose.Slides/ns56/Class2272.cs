using System;
using System.Xml;

namespace ns56;

internal class Class2272 : Class1351
{
	public delegate Class2272 Delegate2563();

	public delegate void Delegate2565(Class2272 elementData);

	public delegate void Delegate2564(Class2272 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 Value
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
				case "clrVal":
					class2605_0 = new Class2605("clrVal", new Class1814(reader));
					break;
				case "strVal":
					class2605_0 = new Class2605("strVal", new Class2275(reader));
					break;
				case "fltVal":
					class2605_0 = new Class2605("fltVal", new Class2273(reader));
					break;
				case "intVal":
					class2605_0 = new Class2605("intVal", new Class2274(reader));
					break;
				case "boolVal":
					class2605_0 = new Class2605("boolVal", new Class2271(reader));
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

	public Class2272(XmlReader reader)
		: base(reader)
	{
	}

	public Class2272()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
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
			case "clrVal":
				((Class1814)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "strVal":
				((Class2275)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "fltVal":
				((Class2273)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "intVal":
				((Class2274)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "boolVal":
				((Class2271)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Value already is initialized.");
		}
		switch (elementName)
		{
		case "clrVal":
			class2605_0 = new Class2605("clrVal", new Class1814());
			break;
		case "strVal":
			class2605_0 = new Class2605("strVal", new Class2275());
			break;
		case "fltVal":
			class2605_0 = new Class2605("fltVal", new Class2273());
			break;
		case "intVal":
			class2605_0 = new Class2605("intVal", new Class2274());
			break;
		case "boolVal":
			class2605_0 = new Class2605("boolVal", new Class2271());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
