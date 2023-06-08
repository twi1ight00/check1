using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2264 : Class1351
{
	public delegate Class2264 Delegate2539();

	public delegate void Delegate2541(Class2264 elementData);

	public delegate void Delegate2540(Class2264 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2605> list_0;

	public Class2605[] NodeList => list_0.ToArray();

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
				case "par":
				{
					Class2304 obj13 = new Class2304(reader);
					list_0.Add(new Class2605("par", obj13));
					break;
				}
				case "seq":
				{
					Class2305 obj12 = new Class2305(reader);
					list_0.Add(new Class2605("seq", obj12));
					break;
				}
				case "excl":
				{
					Class2303 obj11 = new Class2303(reader);
					list_0.Add(new Class2605("excl", obj11));
					break;
				}
				case "anim":
				{
					Class2265 obj10 = new Class2265(reader);
					list_0.Add(new Class2605("anim", obj10));
					break;
				}
				case "animClr":
				{
					Class2266 obj9 = new Class2266(reader);
					list_0.Add(new Class2605("animClr", obj9));
					break;
				}
				case "animEffect":
				{
					Class2267 obj8 = new Class2267(reader);
					list_0.Add(new Class2605("animEffect", obj8));
					break;
				}
				case "animMotion":
				{
					Class2268 obj7 = new Class2268(reader);
					list_0.Add(new Class2605("animMotion", obj7));
					break;
				}
				case "animRot":
				{
					Class2269 obj6 = new Class2269(reader);
					list_0.Add(new Class2605("animRot", obj6));
					break;
				}
				case "animScale":
				{
					Class2270 obj5 = new Class2270(reader);
					list_0.Add(new Class2605("animScale", obj5));
					break;
				}
				case "cmd":
				{
					Class2280 obj4 = new Class2280(reader);
					list_0.Add(new Class2605("cmd", obj4));
					break;
				}
				case "set":
				{
					Class2293 obj3 = new Class2293(reader);
					list_0.Add(new Class2605("set", obj3));
					break;
				}
				case "audio":
				{
					Class2288 obj2 = new Class2288(reader);
					list_0.Add(new Class2605("audio", obj2));
					break;
				}
				case "video":
				{
					Class2289 obj = new Class2289(reader);
					list_0.Add(new Class2605("video", obj));
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

	public Class2264(XmlReader reader)
		: base(reader)
	{
	}

	public Class2264()
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
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "par":
				((Class2304)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "seq":
				((Class2305)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "excl":
				((Class2303)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "anim":
				((Class2265)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "animClr":
				((Class2266)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "animEffect":
				((Class2267)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "animMotion":
				((Class2268)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "animRot":
				((Class2269)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "animScale":
				((Class2270)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "cmd":
				((Class2280)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "set":
				((Class2293)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "audio":
				((Class2288)item.Object).vmethod_4("p", writer, item.Name);
				break;
			case "video":
				((Class2289)item.Object).vmethod_4("p", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"par" => new Class2605("par", new Class2304()), 
			"seq" => new Class2605("seq", new Class2305()), 
			"excl" => new Class2605("excl", new Class2303()), 
			"anim" => new Class2605("anim", new Class2265()), 
			"animClr" => new Class2605("animClr", new Class2266()), 
			"animEffect" => new Class2605("animEffect", new Class2267()), 
			"animMotion" => new Class2605("animMotion", new Class2268()), 
			"animRot" => new Class2605("animRot", new Class2269()), 
			"animScale" => new Class2605("animScale", new Class2270()), 
			"cmd" => new Class2605("cmd", new Class2280()), 
			"set" => new Class2605("set", new Class2293()), 
			"audio" => new Class2605("audio", new Class2288()), 
			"video" => new Class2605("video", new Class2289()), 
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
