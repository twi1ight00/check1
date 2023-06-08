using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1996 : Class1995
{
	public delegate void Delegate1828(Class1996 elementData);

	private Class2000 class2000_0;

	private Class1861 class1861_0;

	private List<Class2605> list_0;

	public override Class1999 NvGrpSpPr => class2000_0;

	public override Class1861 GrpSpPr => class1861_0;

	public override Class2605[] ShapeList => list_0.ToArray();

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
				case "nvGrpSpPr":
					class2000_0 = new Class2000(reader);
					break;
				case "grpSpPr":
					class1861_0 = new Class1861(reader);
					break;
				case "sp":
				{
					Class2012 obj5 = new Class2012(reader);
					list_0.Add(new Class2605("sp", obj5));
					break;
				}
				case "grpSp":
				{
					Class1996 obj4 = new Class1996(reader);
					list_0.Add(new Class2605("grpSp", obj4));
					break;
				}
				case "graphicFrame":
				{
					Class1990 obj3 = new Class1990(reader);
					list_0.Add(new Class2605("graphicFrame", obj3));
					break;
				}
				case "cxnSp":
				{
					Class1984 obj2 = new Class1984(reader);
					list_0.Add(new Class2605("cxnSp", obj2));
					break;
				}
				case "pic":
				{
					Class2005 obj = new Class2005(reader);
					list_0.Add(new Class2605("pic", obj));
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

	public Class1996(XmlReader reader)
		: base(reader)
	{
	}

	public Class1996()
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
		class2000_0 = new Class2000();
		class1861_0 = new Class1861();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2000_0.vmethod_4("cdr", writer, "nvGrpSpPr");
		class1861_0.vmethod_4("cdr", writer, "grpSpPr");
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "pic":
				((Class2005)item.Object).vmethod_4("cdr", writer, item.Name);
				break;
			case "cxnSp":
				((Class1984)item.Object).vmethod_4("cdr", writer, item.Name);
				break;
			case "graphicFrame":
				((Class1990)item.Object).vmethod_4("cdr", writer, item.Name);
				break;
			case "grpSp":
				((Class1996)item.Object).vmethod_4("cdr", writer, item.Name);
				break;
			case "sp":
				((Class2012)item.Object).vmethod_4("cdr", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"pic" => new Class2605("pic", new Class2005()), 
			"cxnSp" => new Class2605("cxnSp", new Class1984()), 
			"graphicFrame" => new Class2605("graphicFrame", new Class1990()), 
			"grpSp" => new Class2605("grpSp", new Class1996()), 
			"sp" => new Class2605("sp", new Class2012()), 
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
