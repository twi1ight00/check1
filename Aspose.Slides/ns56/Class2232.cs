using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2232 : Class1351
{
	public delegate Class2232 Delegate2434();

	public delegate void Delegate2436(Class2232 elementData);

	public delegate void Delegate2435(Class2232 elementData);

	public Class2231.Delegate2431 delegate2431_0;

	public Class2231.Delegate2432 delegate2432_0;

	public Class2263.Delegate2536 delegate2536_0;

	public Class2263.Delegate2538 delegate2538_0;

	private List<Class2231> list_0;

	private Class2263 class2263_0;

	public Class2231[] CustDataList => list_0.ToArray();

	public Class2263 Tags => class2263_0;

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
				case "tags":
					class2263_0 = new Class2263(reader);
					break;
				case "custData":
				{
					Class2231 item = new Class2231(reader);
					list_0.Add(item);
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

	public Class2232(XmlReader reader)
		: base(reader)
	{
	}

	public Class2232()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2231>();
	}

	protected override void vmethod_2()
	{
		delegate2431_0 = method_3;
		delegate2432_0 = method_4;
		delegate2536_0 = method_5;
		delegate2538_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2231 item in list_0)
		{
			item.vmethod_4("p", writer, "custData");
		}
		if (class2263_0 != null)
		{
			class2263_0.vmethod_4("p", writer, "tags");
		}
		writer.WriteEndElement();
	}

	private Class2231 method_3()
	{
		Class2231 @class = new Class2231();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2231 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2263 method_5()
	{
		if (class2263_0 != null)
		{
			throw new Exception("Only one <tags> element can be added.");
		}
		class2263_0 = new Class2263();
		return class2263_0;
	}

	private void method_6(Class2263 _tags)
	{
		class2263_0 = _tags;
	}
}
