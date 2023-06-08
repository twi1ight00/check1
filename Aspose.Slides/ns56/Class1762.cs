using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1762 : Class1351
{
	public delegate Class1762 Delegate1165();

	public delegate void Delegate1166(Class1762 elementData);

	public delegate void Delegate1167(Class1762 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class1763 class1763_0;

	private Class1861 class1861_0;

	private List<Class2605> list_0;

	public Class1763 NvGrpSpPr => class1763_0;

	public Class1861 GrpSpPr => class1861_0;

	public Class2605[] ShapeList => list_0.ToArray();

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
					class1763_0 = new Class1763(reader);
					break;
				case "grpSpPr":
					class1861_0 = new Class1861(reader);
					break;
				case "sp":
				{
					Class1767 obj5 = new Class1767(reader);
					list_0.Add(new Class2605("sp", obj5));
					break;
				}
				case "grpSp":
				{
					Class1762 obj4 = new Class1762(reader);
					list_0.Add(new Class2605("grpSp", obj4));
					break;
				}
				case "graphicFrame":
				{
					Class1760 obj3 = new Class1760(reader);
					list_0.Add(new Class2605("graphicFrame", obj3));
					break;
				}
				case "cxnSp":
				{
					Class1757 obj2 = new Class1757(reader);
					list_0.Add(new Class2605("cxnSp", obj2));
					break;
				}
				case "pic":
				{
					Class1765 obj = new Class1765(reader);
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

	public Class1762(XmlReader reader)
		: base(reader)
	{
	}

	public Class1762()
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
		class1763_0 = new Class1763();
		class1861_0 = new Class1861();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1763_0.vmethod_4("xdr", writer, "nvGrpSpPr");
		class1861_0.vmethod_4("xdr", writer, "grpSpPr");
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "pic":
				((Class1765)item.Object).vmethod_4("xdr", writer, item.Name);
				break;
			case "cxnSp":
				((Class1757)item.Object).vmethod_4("xdr", writer, item.Name);
				break;
			case "graphicFrame":
				((Class1760)item.Object).vmethod_4("xdr", writer, item.Name);
				break;
			case "grpSp":
				((Class1762)item.Object).vmethod_4("xdr", writer, item.Name);
				break;
			case "sp":
				((Class1767)item.Object).vmethod_4("xdr", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"pic" => new Class2605("pic", new Class1765()), 
			"cxnSp" => new Class2605("cxnSp", new Class1757()), 
			"graphicFrame" => new Class2605("graphicFrame", new Class1760()), 
			"grpSp" => new Class2605("grpSp", new Class1762()), 
			"sp" => new Class2605("sp", new Class1767()), 
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
