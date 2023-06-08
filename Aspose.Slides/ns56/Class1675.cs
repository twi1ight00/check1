using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1675 : Class1351
{
	public delegate Class1675 Delegate904();

	public delegate void Delegate906(Class1675 elementData);

	public delegate void Delegate905(Class1675 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] RunPropertyList => list_0.ToArray();

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
				case "rFont":
				{
					Class1528 obj15 = new Class1528(reader);
					list_0.Add(new Class2605("rFont", obj15));
					break;
				}
				case "charset":
				{
					Class1558 obj14 = new Class1558(reader);
					list_0.Add(new Class2605("charset", obj14));
					break;
				}
				case "family":
				{
					Class1558 obj13 = new Class1558(reader);
					list_0.Add(new Class2605("family", obj13));
					break;
				}
				case "b":
				{
					Class1376 obj12 = new Class1376(reader);
					list_0.Add(new Class2605("b", obj12));
					break;
				}
				case "i":
				{
					Class1376 obj11 = new Class1376(reader);
					list_0.Add(new Class2605("i", obj11));
					break;
				}
				case "strike":
				{
					Class1376 obj10 = new Class1376(reader);
					list_0.Add(new Class2605("strike", obj10));
					break;
				}
				case "outline":
				{
					Class1376 obj9 = new Class1376(reader);
					list_0.Add(new Class2605("outline", obj9));
					break;
				}
				case "shadow":
				{
					Class1376 obj8 = new Class1376(reader);
					list_0.Add(new Class2605("shadow", obj8));
					break;
				}
				case "condense":
				{
					Class1376 obj7 = new Class1376(reader);
					list_0.Add(new Class2605("condense", obj7));
					break;
				}
				case "extend":
				{
					Class1376 obj6 = new Class1376(reader);
					list_0.Add(new Class2605("extend", obj6));
					break;
				}
				case "color":
				{
					Class1419 obj5 = new Class1419(reader);
					list_0.Add(new Class2605("color", obj5));
					break;
				}
				case "sz":
				{
					Class1531 obj4 = new Class1531(reader);
					list_0.Add(new Class2605("sz", obj4));
					break;
				}
				case "u":
				{
					Class1729 obj3 = new Class1729(reader);
					list_0.Add(new Class2605("u", obj3));
					break;
				}
				case "vertAlign":
				{
					Class1732 obj2 = new Class1732(reader);
					list_0.Add(new Class2605("vertAlign", obj2));
					break;
				}
				case "scheme":
				{
					Class1529 obj = new Class1529(reader);
					list_0.Add(new Class2605("scheme", obj));
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

	public Class1675(XmlReader reader)
		: base(reader)
	{
	}

	public Class1675()
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
			case "rFont":
				((Class1528)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "charset":
				((Class1558)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "family":
				((Class1558)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "b":
				((Class1376)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "i":
				((Class1376)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "strike":
				((Class1376)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "outline":
				((Class1376)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "shadow":
				((Class1376)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "condense":
				((Class1376)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "extend":
				((Class1376)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "color":
				((Class1419)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "sz":
				((Class1531)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "u":
				((Class1729)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "vertAlign":
				((Class1732)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "scheme":
				((Class1529)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"rFont" => new Class2605("rFont", new Class1528()), 
			"charset" => new Class2605("charset", new Class1558()), 
			"family" => new Class2605("family", new Class1558()), 
			"b" => new Class2605("b", new Class1376()), 
			"i" => new Class2605("i", new Class1376()), 
			"strike" => new Class2605("strike", new Class1376()), 
			"outline" => new Class2605("outline", new Class1376()), 
			"shadow" => new Class2605("shadow", new Class1376()), 
			"condense" => new Class2605("condense", new Class1376()), 
			"extend" => new Class2605("extend", new Class1376()), 
			"color" => new Class2605("color", new Class1419()), 
			"sz" => new Class2605("sz", new Class1531()), 
			"u" => new Class2605("u", new Class1729()), 
			"vertAlign" => new Class2605("vertAlign", new Class1732()), 
			"scheme" => new Class2605("scheme", new Class1529()), 
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
