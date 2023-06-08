using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1554 : Class1351
{
	public delegate void Delegate543(Class1554 elementData);

	public delegate Class1554 Delegate541();

	public delegate void Delegate542(Class1554 elementData);

	public Class1553.Delegate538 delegate538_0;

	public Class1553.Delegate539 delegate539_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private List<Class1553> list_0;

	private Class1502 class1502_0;

	public Class1553[] IgnoredErrorList => list_0.ToArray();

	public Class1502 ExtLst => class1502_0;

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
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "ignoredError":
				{
					Class1553 item = new Class1553(reader);
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

	public Class1554(XmlReader reader)
		: base(reader)
	{
	}

	public Class1554()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1553>();
	}

	protected override void vmethod_2()
	{
		delegate538_0 = method_3;
		delegate539_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1553 item in list_0)
		{
			item.vmethod_4("ssml", writer, "ignoredError");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1553 method_3()
	{
		Class1553 @class = new Class1553();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1553 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
