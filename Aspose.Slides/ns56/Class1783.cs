using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1783 : Class1351
{
	public delegate Class1783 Delegate1228();

	public delegate void Delegate1229(Class1783 elementData);

	public delegate void Delegate1230(Class1783 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] AdjustHandleList => list_0.ToArray();

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
				case "ahPolar":
				{
					Class1905 obj2 = new Class1905(reader);
					list_0.Add(new Class2605("ahPolar", obj2));
					break;
				}
				case "ahXY":
				{
					Class1981 obj = new Class1981(reader);
					list_0.Add(new Class2605("ahXY", obj));
					break;
				}
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

	public Class1783(XmlReader reader)
		: base(reader)
	{
	}

	public Class1783()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2605>();
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
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "ahPolar":
				((Class1905)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "ahXY":
				((Class1981)item.Object).vmethod_4("a", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"ahPolar" => new Class2605("ahPolar", new Class1905()), 
			"ahXY" => new Class2605("ahXY", new Class1981()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_4(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
