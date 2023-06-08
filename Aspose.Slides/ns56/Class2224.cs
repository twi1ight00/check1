using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2224 : Class1351
{
	public delegate Class2224 Delegate2408();

	public delegate void Delegate2410(Class2224 elementData);

	public delegate void Delegate2409(Class2224 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] BuildList => list_0.ToArray();

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
				case "bldGraphic":
				{
					Class2284 obj4 = new Class2284(reader);
					list_0.Add(new Class2605("bldGraphic", obj4));
					break;
				}
				case "bldOleChart":
				{
					Class2290 obj3 = new Class2290(reader);
					list_0.Add(new Class2605("bldOleChart", obj3));
					break;
				}
				case "bldDgm":
				{
					Class2277 obj2 = new Class2277(reader);
					list_0.Add(new Class2605("bldDgm", obj2));
					break;
				}
				case "bldP":
				{
					Class2278 obj = new Class2278(reader);
					list_0.Add(new Class2605("bldP", obj));
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

	public Class2224(XmlReader reader)
		: base(reader)
	{
	}

	public Class2224()
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
			case "bldGraphic":
				((Class2284)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "bldOleChart":
				((Class2290)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "bldDgm":
				((Class2277)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "bldP":
				((Class2278)item.Object).vmethod_4("p", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"bldGraphic" => new Class2605("bldGraphic", new Class2284()), 
			"bldOleChart" => new Class2605("bldOleChart", new Class2290()), 
			"bldDgm" => new Class2605("bldDgm", new Class2277()), 
			"bldP" => new Class2605("bldP", new Class2278()), 
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
