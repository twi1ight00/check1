using System;
using System.Xml;

namespace ns56;

internal class Class1836 : Class1351
{
	public delegate Class1836 Delegate1387();

	public delegate void Delegate1388(Class1836 elementData);

	public delegate void Delegate1389(Class1836 elementData);

	public Class1916.Delegate1615 delegate1615_0;

	public Class1916.Delegate1617 delegate1617_0;

	public Class1919.Delegate1624 delegate1624_0;

	public Class1919.Delegate1626 delegate1626_0;

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	private Class1916 class1916_0;

	private Class1919 class1919_0;

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

	public Class1916 Scene3d => class1916_0;

	public Class1919 Sp3d => class1919_0;

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
				case "sp3d":
					class1919_0 = new Class1919(reader);
					break;
				case "scene3d":
					class1916_0 = new Class1916(reader);
					break;
				case "effectDag":
					class2605_0 = new Class2605("effectDag", new Class1832(reader));
					break;
				case "effectLst":
					class2605_0 = new Class2605("effectLst", new Class1833(reader));
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

	public Class1836(XmlReader reader)
		: base(reader)
	{
	}

	public Class1836()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_7;
		delegate1615_0 = method_3;
		delegate1617_0 = method_4;
		delegate1624_0 = method_5;
		delegate1626_0 = method_6;
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
			case "effectDag":
				((Class1832)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "effectLst":
				((Class1833)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
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
		writer.WriteEndElement();
	}

	private Class1916 method_3()
	{
		if (class1916_0 != null)
		{
			throw new Exception("Only one <scene3d> element can be added.");
		}
		class1916_0 = new Class1916();
		return class1916_0;
	}

	private void method_4(Class1916 _scene3d)
	{
		class1916_0 = _scene3d;
	}

	private Class1919 method_5()
	{
		if (class1919_0 != null)
		{
			throw new Exception("Only one <sp3d> element can be added.");
		}
		class1919_0 = new Class1919();
		return class1919_0;
	}

	private void method_6(Class1919 _sp3d)
	{
		class1919_0 = _sp3d;
	}

	private Class2605 method_7(string elementName)
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
