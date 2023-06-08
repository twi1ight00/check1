using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1759 : Class1351
{
	public delegate Class1759 Delegate1156();

	public delegate void Delegate1157(Class1759 elementData);

	public delegate void Delegate1158(Class1759 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] AnchorPlaceholderList => list_0.ToArray();

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
				case "absoluteAnchor":
				{
					Class1755 obj3 = new Class1755(reader);
					list_0.Add(new Class2605("absoluteAnchor", obj3));
					break;
				}
				case "oneCellAnchor":
				{
					Class1764 obj2 = new Class1764(reader);
					list_0.Add(new Class2605("oneCellAnchor", obj2));
					break;
				}
				case "twoCellAnchor":
				{
					Class1769 obj = new Class1769(reader);
					list_0.Add(new Class2605("twoCellAnchor", obj));
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

	public Class1759(XmlReader reader)
		: base(reader)
	{
	}

	public Class1759()
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
		writer.WriteStartElement("xdr", elementName, "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (list_0 != null)
		{
			foreach (Class2605 item in list_0)
			{
				switch (item.Name)
				{
				case "absoluteAnchor":
					((Class1755)item.Object).vmethod_4("xdr", writer, item.Name);
					break;
				case "oneCellAnchor":
					((Class1764)item.Object).vmethod_4("xdr", writer, item.Name);
					break;
				case "twoCellAnchor":
					((Class1769)item.Object).vmethod_4("xdr", writer, item.Name);
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
			"absoluteAnchor" => new Class2605("absoluteAnchor", new Class1755()), 
			"oneCellAnchor" => new Class2605("oneCellAnchor", new Class1764()), 
			"twoCellAnchor" => new Class2605("twoCellAnchor", new Class1769()), 
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
