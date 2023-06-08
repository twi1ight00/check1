using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2171 : Class1351
{
	public delegate Class2171 Delegate2245();

	public delegate void Delegate2246(Class2171 elementData);

	public delegate void Delegate2247(Class2171 elementData);

	public const string string_0 = "";

	public const string string_1 = "";

	public const string string_2 = "";

	public Class2605.Delegate2773 delegate2773_0;

	private string string_3;

	private string string_4;

	private Enum327 enum327_0;

	private string string_5;

	private List<Class2605> list_0;

	public static readonly Enum327 enum327_1 = Class2457.smethod_0("b");

	public string Name
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string StyleLbl
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public Enum327 ChOrder
	{
		get
		{
			return enum327_0;
		}
		set
		{
			enum327_0 = value;
		}
	}

	public string MoveWith
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public Class2605[] ChildNodeList => list_0.ToArray();

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
				case "alg":
				{
					Class2146 obj10 = new Class2146(reader);
					list_0.Add(new Class2605("alg", obj10));
					break;
				}
				case "shape":
				{
					Class2188 obj9 = new Class2188(reader);
					list_0.Add(new Class2605("shape", obj9));
					break;
				}
				case "presOf":
				{
					Class2178 obj8 = new Class2178(reader);
					list_0.Add(new Class2605("presOf", obj8));
					break;
				}
				case "constrLst":
				{
					Class2157 obj7 = new Class2157(reader);
					list_0.Add(new Class2605("constrLst", obj7));
					break;
				}
				case "ruleLst":
				{
					Class2182 obj6 = new Class2182(reader);
					list_0.Add(new Class2605("ruleLst", obj6));
					break;
				}
				case "varLst":
				{
					Class2172 obj5 = new Class2172(reader);
					list_0.Add(new Class2605("varLst", obj5));
					break;
				}
				case "forEach":
				{
					Class2169 obj4 = new Class2169(reader);
					list_0.Add(new Class2605("forEach", obj4));
					break;
				}
				case "layoutNode":
				{
					Class2171 obj3 = new Class2171(reader);
					list_0.Add(new Class2605("layoutNode", obj3));
					break;
				}
				case "choose":
				{
					Class2154 obj2 = new Class2154(reader);
					list_0.Add(new Class2605("choose", obj2));
					break;
				}
				case "extLst":
				{
					Class1886 obj = new Class1886(reader);
					list_0.Add(new Class2605("extLst", obj));
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
		while (reader.MoveToNextAttribute())
		{
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "moveWith":
					string_5 = reader.Value;
					break;
				case "chOrder":
					enum327_0 = Class2457.smethod_0(reader.Value);
					break;
				case "styleLbl":
					string_4 = reader.Value;
					break;
				case "name":
					string_3 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2171(XmlReader reader)
		: base(reader)
	{
	}

	public Class2171()
	{
	}

	protected override void vmethod_1()
	{
		string_3 = "";
		string_4 = "";
		enum327_0 = enum327_1;
		string_5 = "";
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
		if (string_3 != "")
		{
			writer.WriteAttributeString("name", string_3);
		}
		if (string_4 != "")
		{
			writer.WriteAttributeString("styleLbl", string_4);
		}
		if (enum327_0 != enum327_1)
		{
			writer.WriteAttributeString("chOrder", Class2457.smethod_1(enum327_0));
		}
		if (string_5 != "")
		{
			writer.WriteAttributeString("moveWith", string_5);
		}
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "alg":
				((Class2146)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "shape":
				((Class2188)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "presOf":
				((Class2178)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "constrLst":
				((Class2157)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "ruleLst":
				((Class2182)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "varLst":
				((Class2172)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "forEach":
				((Class2169)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "layoutNode":
				((Class2171)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "choose":
				((Class2154)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			case "extLst":
				((Class1886)item.Object).vmethod_4("dgm", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"alg" => new Class2605("alg", new Class2146()), 
			"shape" => new Class2605("shape", new Class2188()), 
			"presOf" => new Class2605("presOf", new Class2178()), 
			"constrLst" => new Class2605("constrLst", new Class2157()), 
			"ruleLst" => new Class2605("ruleLst", new Class2182()), 
			"varLst" => new Class2605("varLst", new Class2172()), 
			"forEach" => new Class2605("forEach", new Class2169()), 
			"layoutNode" => new Class2605("layoutNode", new Class2171()), 
			"choose" => new Class2605("choose", new Class2154()), 
			"extLst" => new Class2605("extLst", new Class1886()), 
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
