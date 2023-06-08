using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2169 : Class1351
{
	public delegate Class2169 Delegate2239();

	public delegate void Delegate2240(Class2169 elementData);

	public delegate void Delegate2241(Class2169 elementData);

	public const string string_0 = "";

	public const string string_1 = "";

	public const string string_2 = "none";

	public const string string_3 = "all";

	public const string string_4 = "true";

	public const string string_5 = "1";

	public const string string_6 = "0";

	public const string string_7 = "1";

	public Class2605.Delegate2773 delegate2773_0;

	private string string_8;

	private string string_9;

	private string string_10;

	private string string_11;

	private string string_12;

	private string string_13;

	private string string_14;

	private string string_15;

	private List<Class2605> list_0;

	public string Name
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string Ref
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public string Axis
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public string PtType
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public string HideLastTrans
	{
		get
		{
			return string_12;
		}
		set
		{
			string_12 = value;
		}
	}

	public string St
	{
		get
		{
			return string_13;
		}
		set
		{
			string_13 = value;
		}
	}

	public string Cnt
	{
		get
		{
			return string_14;
		}
		set
		{
			string_14 = value;
		}
	}

	public string Step
	{
		get
		{
			return string_15;
		}
		set
		{
			string_15 = value;
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
					Class2146 obj9 = new Class2146(reader);
					list_0.Add(new Class2605("alg", obj9));
					break;
				}
				case "shape":
				{
					Class2188 obj8 = new Class2188(reader);
					list_0.Add(new Class2605("shape", obj8));
					break;
				}
				case "presOf":
				{
					Class2178 obj7 = new Class2178(reader);
					list_0.Add(new Class2605("presOf", obj7));
					break;
				}
				case "constrLst":
				{
					Class2157 obj6 = new Class2157(reader);
					list_0.Add(new Class2605("constrLst", obj6));
					break;
				}
				case "ruleLst":
				{
					Class2182 obj5 = new Class2182(reader);
					list_0.Add(new Class2605("ruleLst", obj5));
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
				case "name":
					string_8 = reader.Value;
					break;
				case "ref":
					string_9 = reader.Value;
					break;
				case "axis":
					string_10 = reader.Value;
					break;
				case "ptType":
					string_11 = reader.Value;
					break;
				case "hideLastTrans":
					string_12 = reader.Value;
					break;
				case "st":
					string_13 = reader.Value;
					break;
				case "cnt":
					string_14 = reader.Value;
					break;
				case "step":
					string_15 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2169(XmlReader reader)
		: base(reader)
	{
	}

	public Class2169()
	{
	}

	protected override void vmethod_1()
	{
		string_8 = "";
		string_9 = "";
		string_10 = "none";
		string_11 = "all";
		string_12 = "true";
		string_13 = "1";
		string_14 = "0";
		string_15 = "1";
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
		if (string_8 != "")
		{
			writer.WriteAttributeString("name", string_8);
		}
		if (string_9 != "")
		{
			writer.WriteAttributeString("ref", string_9);
		}
		if (string_10 != "none")
		{
			writer.WriteAttributeString("axis", string_10);
		}
		if (string_11 != "all")
		{
			writer.WriteAttributeString("ptType", string_11);
		}
		if (string_12 != "true")
		{
			writer.WriteAttributeString("hideLastTrans", string_12);
		}
		if (string_13 != "1")
		{
			writer.WriteAttributeString("st", string_13);
		}
		if (string_14 != "0")
		{
			writer.WriteAttributeString("cnt", string_14);
		}
		if (string_15 != "1")
		{
			writer.WriteAttributeString("step", string_15);
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
