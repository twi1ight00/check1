using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1668 : Class1351
{
	public delegate Class1668 Delegate883();

	public delegate void Delegate884(Class1668 elementData);

	public delegate void Delegate885(Class1668 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] RevisionsList => list_0.ToArray();

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
				case "rrc":
				{
					Class1667 obj12 = new Class1667(reader);
					list_0.Add(new Class2605("rrc", obj12));
					break;
				}
				case "rm":
				{
					Class1665 obj11 = new Class1665(reader);
					list_0.Add(new Class2605("rm", obj11));
					break;
				}
				case "rcv":
				{
					Class1659 obj10 = new Class1659(reader);
					list_0.Add(new Class2605("rcv", obj10));
					break;
				}
				case "rsnm":
				{
					Class1669 obj9 = new Class1669(reader);
					list_0.Add(new Class2605("rsnm", obj9));
					break;
				}
				case "ris":
				{
					Class1664 obj8 = new Class1664(reader);
					list_0.Add(new Class2605("ris", obj8));
					break;
				}
				case "rcc":
				{
					Class1771 obj7 = new Class1771(reader);
					list_0.Add(new Class2605("rcc", obj7));
					break;
				}
				case "rfmt":
				{
					Class1661 obj6 = new Class1661(reader);
					list_0.Add(new Class2605("rfmt", obj6));
					break;
				}
				case "raf":
				{
					Class1656 obj5 = new Class1656(reader);
					list_0.Add(new Class2605("raf", obj5));
					break;
				}
				case "rdn":
				{
					Class1660 obj4 = new Class1660(reader);
					list_0.Add(new Class2605("rdn", obj4));
					break;
				}
				case "rcmt":
				{
					Class1657 obj3 = new Class1657(reader);
					list_0.Add(new Class2605("rcmt", obj3));
					break;
				}
				case "rqt":
				{
					Class1666 obj2 = new Class1666(reader);
					list_0.Add(new Class2605("rqt", obj2));
					break;
				}
				case "rcft":
				{
					Class1658 obj = new Class1658(reader);
					list_0.Add(new Class2605("rcft", obj));
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

	public Class1668(XmlReader reader)
		: base(reader)
	{
	}

	public Class1668()
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
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "rrc":
				((Class1667)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rm":
				((Class1665)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rcv":
				((Class1659)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rsnm":
				((Class1669)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "ris":
				((Class1664)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rcc":
				((Class1771)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rfmt":
				((Class1661)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "raf":
				((Class1656)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rdn":
				((Class1660)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rcmt":
				((Class1657)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rqt":
				((Class1666)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "rcft":
				((Class1658)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"rrc" => new Class2605("rrc", new Class1667()), 
			"rm" => new Class2605("rm", new Class1665()), 
			"rcv" => new Class2605("rcv", new Class1659()), 
			"rsnm" => new Class2605("rsnm", new Class1669()), 
			"ris" => new Class2605("ris", new Class1664()), 
			"rcc" => new Class2605("rcc", new Class1771()), 
			"rfmt" => new Class2605("rfmt", new Class1661()), 
			"raf" => new Class2605("raf", new Class1656()), 
			"rdn" => new Class2605("rdn", new Class1660()), 
			"rcmt" => new Class2605("rcmt", new Class1657()), 
			"rqt" => new Class2605("rqt", new Class1666()), 
			"rcft" => new Class2605("rcft", new Class1658()), 
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
