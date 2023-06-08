using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1998 : Class1995
{
	public delegate void Delegate2450(Class1998 elementData);

	private Class2002 class2002_0;

	private Class1861 class1861_0;

	private List<Class2605> list_0;

	private Class1889 class1889_0;

	public override Class1999 NvGrpSpPr => class2002_0;

	public override Class1861 GrpSpPr => class1861_0;

	public override Class2605[] ShapeList => list_0.ToArray();

	public override Class1885 ExtLst => class1889_0;

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
					class2002_0 = new Class2002(reader);
					break;
				case "grpSpPr":
					class1861_0 = new Class1861(reader);
					break;
				case "sp":
				{
					Class2014 obj5 = new Class2014(reader);
					list_0.Add(new Class2605("sp", obj5));
					break;
				}
				case "grpSp":
				{
					Class1998 obj4 = new Class1998(reader);
					list_0.Add(new Class2605("grpSp", obj4));
					break;
				}
				case "graphicFrame":
				{
					Class1991 obj3 = new Class1991(reader);
					list_0.Add(new Class2605("graphicFrame", obj3));
					break;
				}
				case "cxnSp":
				{
					Class1985 obj2 = new Class1985(reader);
					list_0.Add(new Class2605("cxnSp", obj2));
					break;
				}
				case "pic":
				{
					Class2006 obj = new Class2006(reader);
					list_0.Add(new Class2605("pic", obj));
					break;
				}
				case "extLst":
					class1889_0 = new Class1889(reader);
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

	public Class1998(XmlReader reader)
		: base(reader)
	{
	}

	public Class1998()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_5;
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class2002_0 = new Class2002();
		class1861_0 = new Class1861();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2002_0.vmethod_4("p", writer, "nvGrpSpPr");
		class1861_0.vmethod_4("p", writer, "grpSpPr");
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "pic":
				((Class2006)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "cxnSp":
				((Class1985)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "graphicFrame":
				((Class1991)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "grpSp":
				((Class1998)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "sp":
				((Class2014)item.Object).vmethod_4("p", writer, item.Name);
				break;
			}
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}

	private Class2605 method_5(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"pic" => new Class2605("pic", new Class2006()), 
			"cxnSp" => new Class2605("cxnSp", new Class1985()), 
			"graphicFrame" => new Class2605("graphicFrame", new Class1991()), 
			"grpSp" => new Class2605("grpSp", new Class1998()), 
			"sp" => new Class2605("sp", new Class2014()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_6(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
