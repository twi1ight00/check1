using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1734 : Class1351
{
	public delegate Class1734 Delegate1081();

	public delegate void Delegate1082(Class1734 elementData);

	public delegate void Delegate1083(Class1734 elementData);

	public Class1735.Delegate1084 delegate1084_0;

	public Class1735.Delegate1085 delegate1085_0;

	private Enum258 enum258_0;

	private string string_0;

	private List<string> list_0;

	private List<Class1735> list_1;

	public static readonly Enum258 enum258_1 = Class2425.smethod_0("n");

	public Enum258 T
	{
		get
		{
			return enum258_0;
		}
		set
		{
			enum258_0 = value;
		}
	}

	public string V
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string[] StpList => list_0.ToArray();

	public Class1735[] TrList => list_1.ToArray();

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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			switch (reader.LocalName)
			{
			case "tr":
			{
				Class1735 item = new Class1735(reader);
				list_1.Add(item);
				break;
			}
			case "stp":
			{
				string text = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						text += reader.ReadString();
					}
					list_0.Add(text);
				}
				break;
			}
			case "v":
				string_0 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_0 += reader.ReadString();
					}
				}
				break;
			default:
				reader.Skip();
				flag = true;
				break;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "t")
			{
				enum258_0 = Class2425.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1734(XmlReader reader)
		: base(reader)
	{
	}

	public Class1734()
	{
	}

	protected override void vmethod_1()
	{
		enum258_0 = enum258_1;
		list_0 = new List<string>();
		list_1 = new List<Class1735>();
	}

	protected override void vmethod_2()
	{
		delegate1084_0 = method_4;
		delegate1085_0 = method_5;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum258_0 != enum258_1)
		{
			writer.WriteAttributeString("t", Class2425.smethod_1(enum258_0));
		}
		method_1("ssml", writer, "v", string_0);
		foreach (string item in list_0)
		{
			method_1("ssml", writer, "stp", item);
		}
		foreach (Class1735 item2 in list_1)
		{
			item2.vmethod_4("ssml", writer, "tr");
		}
		writer.WriteEndElement();
	}

	public void method_3(string str)
	{
		list_0.Add(str);
	}

	private Class1735 method_4()
	{
		Class1735 @class = new Class1735();
		list_1.Add(@class);
		return @class;
	}

	private void method_5(Class1735 elementData)
	{
		list_1.Add(elementData);
	}
}
