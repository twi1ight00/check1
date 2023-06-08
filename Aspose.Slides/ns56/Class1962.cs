using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1962 : Class1351
{
	public delegate Class1962 Delegate1753();

	public delegate void Delegate1754(Class1962 elementData);

	public delegate void Delegate1755(Class1962 elementData);

	public Class1963.Delegate1756 delegate1756_0;

	public Class1963.Delegate1758 delegate1758_0;

	public Class1953.Delegate1726 delegate1726_0;

	public Class1953.Delegate1728 delegate1728_0;

	public Class2605.Delegate2773 delegate2773_0;

	private Class1963 class1963_0;

	private List<Class2605> list_0;

	private Class1953 class1953_0;

	public Class1963 PPr => class1963_0;

	public Class2605[] TextRunList => list_0.ToArray();

	public Class1953 EndParaRPr => class1953_0;

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
				case "endParaRPr":
					class1953_0 = new Class1953(reader);
					break;
				case "fld":
				{
					Class1955 obj3 = new Class1955(reader);
					list_0.Add(new Class2605("fld", obj3));
					break;
				}
				case "br":
				{
					Class1957 obj2 = new Class1957(reader);
					list_0.Add(new Class2605("br", obj2));
					break;
				}
				case "r":
				{
					Class1354 obj = new Class1354(reader);
					list_0.Add(new Class2605("r", obj));
					break;
				}
				case "pPr":
					class1963_0 = new Class1963(reader);
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

	public Class1962(XmlReader reader)
		: base(reader)
	{
	}

	public Class1962()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate1756_0 = method_3;
		delegate1758_0 = method_4;
		delegate2773_0 = method_7;
		delegate1726_0 = method_5;
		delegate1728_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1963_0 != null)
		{
			class1963_0.vmethod_4("a", writer, "pPr");
		}
		if (list_0 != null)
		{
			foreach (Class2605 item in list_0)
			{
				switch (item.Name)
				{
				case "fld":
					((Class1955)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "br":
					((Class1957)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "r":
					((Class1354)item.Object).vmethod_4("a", writer, item.Name);
					break;
				}
			}
		}
		if (class1953_0 != null)
		{
			class1953_0.vmethod_4("a", writer, "endParaRPr");
		}
		writer.WriteEndElement();
	}

	private Class1963 method_3()
	{
		if (class1963_0 != null)
		{
			throw new Exception("Only one <pPr> element can be added.");
		}
		class1963_0 = new Class1963();
		return class1963_0;
	}

	private void method_4(Class1963 _pPr)
	{
		class1963_0 = _pPr;
	}

	private Class1953 method_5()
	{
		if (class1953_0 != null)
		{
			throw new Exception("Only one <endParaRPr> element can be added.");
		}
		class1953_0 = new Class1953();
		return class1953_0;
	}

	private void method_6(Class1953 _endParaRPr)
	{
		class1953_0 = _endParaRPr;
	}

	private Class2605 method_7(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"fld" => new Class2605("fld", new Class1955()), 
			"br" => new Class2605("br", new Class1957()), 
			"r" => new Class2605("r", new Class1354()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_8(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
