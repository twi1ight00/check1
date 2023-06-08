using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1831 : Class1351
{
	public delegate Class1831 Delegate1372();

	public delegate void Delegate1373(Class1831 elementData);

	public delegate void Delegate1374(Class1831 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] ColorList => list_0.ToArray();

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
				case "scrgbClr":
				{
					Class1918 obj6 = new Class1918(reader);
					list_0.Add(new Class2605("scrgbClr", obj6));
					break;
				}
				case "srgbClr":
				{
					Class1926 obj5 = new Class1926(reader);
					list_0.Add(new Class2605("srgbClr", obj5));
					break;
				}
				case "hslClr":
				{
					Class1863 obj4 = new Class1863(reader);
					list_0.Add(new Class2605("hslClr", obj4));
					break;
				}
				case "sysClr":
				{
					Class1931 obj3 = new Class1931(reader);
					list_0.Add(new Class2605("sysClr", obj3));
					break;
				}
				case "schemeClr":
				{
					Class1917 obj2 = new Class1917(reader);
					list_0.Add(new Class2605("schemeClr", obj2));
					break;
				}
				case "prstClr":
				{
					Class1907 obj = new Class1907(reader);
					list_0.Add(new Class2605("prstClr", obj));
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

	public Class1831(XmlReader reader)
		: base(reader)
	{
	}

	public Class1831()
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
		if (list_0 != null)
		{
			foreach (Class2605 item in list_0)
			{
				switch (item.Name)
				{
				case "scrgbClr":
					((Class1918)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "srgbClr":
					((Class1926)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "hslClr":
					((Class1863)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "sysClr":
					((Class1931)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "schemeClr":
					((Class1917)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "prstClr":
					((Class1907)item.Object).vmethod_4("a", writer, item.Name);
					break;
				}
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"scrgbClr" => new Class2605("scrgbClr", new Class1918()), 
			"srgbClr" => new Class2605("srgbClr", new Class1926()), 
			"hslClr" => new Class2605("hslClr", new Class1863()), 
			"sysClr" => new Class2605("sysClr", new Class1931()), 
			"schemeClr" => new Class2605("schemeClr", new Class1917()), 
			"prstClr" => new Class2605("prstClr", new Class1907()), 
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
