using System;
using System.Xml;

namespace ns56;

internal class Class1980 : Class1351
{
	public delegate Class1980 Delegate1807();

	public delegate void Delegate1808(Class1980 elementData);

	public delegate void Delegate1809(Class1980 elementData);

	public Class1875.Delegate1504 delegate1504_0;

	public Class1875.Delegate1506 delegate1506_0;

	public Class2605.Delegate2773 delegate2773_0;

	private Class1875 class1875_0;

	private Class2605 class2605_0;

	public Class1875 Ln => class1875_0;

	public Class2605 EffectProperties
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
				case "effectDag":
					class2605_0 = new Class2605("effectDag", new Class1832(reader));
					break;
				case "effectLst":
					class2605_0 = new Class2605("effectLst", new Class1833(reader));
					break;
				case "ln":
					class1875_0 = new Class1875(reader);
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

	public Class1980(XmlReader reader)
		: base(reader)
	{
	}

	public Class1980()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1504_0 = method_3;
		delegate1506_0 = method_4;
		delegate2773_0 = method_5;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1875_0 != null)
		{
			class1875_0.vmethod_4("a", writer, "ln");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "effectDag":
				((Class1832)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "effectLst":
				((Class1833)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class1875 method_3()
	{
		if (class1875_0 != null)
		{
			throw new Exception("Only one <ln> element can be added.");
		}
		class1875_0 = new Class1875();
		return class1875_0;
	}

	private void method_4(Class1875 _ln)
	{
		class1875_0 = _ln;
	}

	private Class2605 method_5(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("EffectProperties already is initialized.");
		}
		switch (elementName)
		{
		case "effectDag":
			class2605_0 = new Class2605("effectDag", new Class1832());
			break;
		case "effectLst":
			class2605_0 = new Class2605("effectLst", new Class1833());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
