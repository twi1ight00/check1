using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1824 : Class1351
{
	public delegate Class1824 Delegate1351();

	public delegate void Delegate1352(Class1824 elementData);

	public delegate void Delegate1353(Class1824 elementData);

	public Class1823.Delegate1348 delegate1348_0;

	public Class1823.Delegate1349 delegate1349_0;

	private List<Class1823> list_0;

	public Class1823[] CxnList => list_0.ToArray();

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "cxn")
				{
					Class1823 item = new Class1823(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class1824(XmlReader reader)
		: base(reader)
	{
	}

	public Class1824()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1823>();
	}

	protected override void vmethod_2()
	{
		delegate1348_0 = method_3;
		delegate1349_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1823 item in list_0)
		{
			item.vmethod_4("a", writer, "cxn");
		}
		writer.WriteEndElement();
	}

	private Class1823 method_3()
	{
		Class1823 @class = new Class1823();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1823 elementData)
	{
		list_0.Add(elementData);
	}
}
