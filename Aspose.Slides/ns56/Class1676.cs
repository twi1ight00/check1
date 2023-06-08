using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1676 : Class1351
{
	public delegate void Delegate908(Class1676 elementData);

	public delegate Class1676 Delegate907();

	public delegate void Delegate909(Class1676 elementData);

	public Class1653.Delegate838 delegate838_0;

	public Class1653.Delegate839 delegate839_0;

	public Class1620.Delegate739 delegate739_0;

	public Class1620.Delegate740 delegate740_0;

	public Class1619.Delegate736 delegate736_0;

	public Class1619.Delegate738 delegate738_0;

	private string string_0;

	private List<Class1653> list_0;

	private List<Class1620> list_1;

	private Class1619 class1619_0;

	public string T
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

	public Class1653[] RList => list_0.ToArray();

	public Class1620[] RPhList => list_1.ToArray();

	public Class1619 PhoneticPr => class1619_0;

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
			case "phoneticPr":
				class1619_0 = new Class1619(reader);
				break;
			case "rPh":
			{
				Class1620 item2 = new Class1620(reader);
				list_1.Add(item2);
				break;
			}
			case "r":
			{
				Class1653 item = new Class1653(reader);
				list_0.Add(item);
				break;
			}
			case "t":
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
	}

	public Class1676(XmlReader reader)
		: base(reader)
	{
	}

	public Class1676()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1653>();
		list_1 = new List<Class1620>();
	}

	protected override void vmethod_2()
	{
		delegate838_0 = method_3;
		delegate839_0 = method_4;
		delegate739_0 = method_5;
		delegate740_0 = method_6;
		delegate736_0 = method_7;
		delegate738_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			method_1("ssml", writer, "t", string_0);
		}
		foreach (Class1653 item in list_0)
		{
			item.vmethod_4("ssml", writer, "r");
		}
		foreach (Class1620 item2 in list_1)
		{
			item2.vmethod_4("ssml", writer, "rPh");
		}
		if (class1619_0 != null)
		{
			class1619_0.vmethod_4("ssml", writer, "phoneticPr");
		}
		writer.WriteEndElement();
	}

	private Class1653 method_3()
	{
		Class1653 @class = new Class1653();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1653 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1620 method_5()
	{
		Class1620 @class = new Class1620();
		list_1.Add(@class);
		return @class;
	}

	private void method_6(Class1620 elementData)
	{
		list_1.Add(elementData);
	}

	private Class1619 method_7()
	{
		if (class1619_0 != null)
		{
			throw new Exception("Only one <phoneticPr> element can be added.");
		}
		class1619_0 = new Class1619();
		return class1619_0;
	}

	private void method_8(Class1619 _phoneticPr)
	{
		class1619_0 = _phoneticPr;
	}
}
