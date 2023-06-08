using System;
using System.Xml;

namespace ns56;

internal class Class2190 : Class1351
{
	public delegate Class2190 Delegate2302();

	public delegate void Delegate2304(Class2190 elementData);

	public delegate void Delegate2303(Class2190 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 Text3D
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
				case "flatTx":
					class2605_0 = new Class2605("flatTx", new Class1844(reader));
					break;
				case "sp3d":
					class2605_0 = new Class2605("sp3d", new Class1919(reader));
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

	public Class2190(XmlReader reader)
		: base(reader)
	{
	}

	public Class2190()
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
			case "flatTx":
				((Class1844)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "sp3d":
				((Class1919)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Text3D already is initialized.");
		}
		switch (elementName)
		{
		case "flatTx":
			class2605_0 = new Class2605("flatTx", new Class1844());
			break;
		case "sp3d":
			class2605_0 = new Class2605("sp3d", new Class1919());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
