using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1803 : Class1351
{
	public delegate Class1803 Delegate1288();

	public delegate void Delegate1289(Class1803 elementData);

	public delegate void Delegate1290(Class1803 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] FillPropertiesList => list_0.ToArray();

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
				case "noFill":
				{
					Class1878 obj6 = new Class1878(reader);
					list_0.Add(new Class2605("noFill", obj6));
					break;
				}
				case "solidFill":
				{
					Class1924 obj5 = new Class1924(reader);
					list_0.Add(new Class2605("solidFill", obj5));
					break;
				}
				case "gradFill":
				{
					Class1853 obj4 = new Class1853(reader);
					list_0.Add(new Class2605("gradFill", obj4));
					break;
				}
				case "blipFill":
				{
					Class1810 obj3 = new Class1810(reader);
					list_0.Add(new Class2605("blipFill", obj3));
					break;
				}
				case "pattFill":
				{
					Class1900 obj2 = new Class1900(reader);
					list_0.Add(new Class2605("pattFill", obj2));
					break;
				}
				case "grpFill":
				{
					Class1859 obj = new Class1859(reader);
					list_0.Add(new Class2605("grpFill", obj));
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

	public Class1803(XmlReader reader)
		: base(reader)
	{
	}

	public Class1803()
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
				case "noFill":
					((Class1878)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "solidFill":
					((Class1924)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "gradFill":
					((Class1853)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "blipFill":
					((Class1810)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "pattFill":
					((Class1900)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "grpFill":
					((Class1859)item.Object).vmethod_4("a", writer, item.Name);
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
			"noFill" => new Class2605("noFill", new Class1878()), 
			"solidFill" => new Class2605("solidFill", new Class1924()), 
			"gradFill" => new Class2605("gradFill", new Class1853()), 
			"blipFill" => new Class2605("blipFill", new Class1810()), 
			"pattFill" => new Class2605("pattFill", new Class1900()), 
			"grpFill" => new Class2605("grpFill", new Class1859()), 
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
