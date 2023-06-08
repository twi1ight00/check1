using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2164 : Class1351
{
	public delegate Class2164 Delegate2224();

	public delegate void Delegate2226(Class2164 elementData);

	public delegate void Delegate2225(Class2164 elementData);

	public Class2163.Delegate2221 delegate2221_0;

	public Class2163.Delegate2222 delegate2222_0;

	private List<Class2163> list_0;

	public Class2163[] CxnList => list_0.ToArray();

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
					Class2163 item = new Class2163(reader);
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

	public Class2164(XmlReader reader)
		: base(reader)
	{
	}

	public Class2164()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2163>();
	}

	protected override void vmethod_2()
	{
		delegate2221_0 = method_3;
		delegate2222_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2163 item in list_0)
		{
			item.vmethod_4("dgm", writer, "cxn");
		}
		writer.WriteEndElement();
	}

	private Class2163 method_3()
	{
		Class2163 @class = new Class2163();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2163 elementData)
	{
		list_0.Add(elementData);
	}
}
