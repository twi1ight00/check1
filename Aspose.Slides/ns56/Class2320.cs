using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2320 : Class1351
{
	public delegate Class2320 Delegate2707();

	public delegate void Delegate2708(Class2320 elementData);

	public delegate void Delegate2709(Class2320 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] AnchorList => list_0.ToArray();

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
				case "absSizeAnchor":
				{
					Class1982 obj2 = new Class1982(reader);
					list_0.Add(new Class2605("absSizeAnchor", obj2));
					break;
				}
				case "relSizeAnchor":
				{
					Class2010 obj = new Class2010(reader);
					list_0.Add(new Class2605("relSizeAnchor", obj));
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

	public Class2320(XmlReader reader)
		: base(reader)
	{
	}

	public Class2320()
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
		writer.WriteStartElement("cdr", elementName, "http://schemas.openxmlformats.org/drawingml/2006/chartDrawing");
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
				case "absSizeAnchor":
					((Class1982)item.Object).vmethod_4("cdr", writer, item.Name);
					break;
				case "relSizeAnchor":
					((Class2010)item.Object).vmethod_4("cdr", writer, item.Name);
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
			"absSizeAnchor" => new Class2605("absSizeAnchor", new Class1982()), 
			"relSizeAnchor" => new Class2605("relSizeAnchor", new Class2010()), 
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
