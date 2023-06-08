using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2140 : Class1351
{
	public delegate Class2140 Delegate2152();

	public delegate void Delegate2153(Class2140 elementData);

	public delegate void Delegate2154(Class2140 elementData);

	public Class2225.Delegate2411 delegate2411_0;

	public Class2225.Delegate2412 delegate2412_0;

	private List<Class2225> list_0;

	public Class2225[] CmAuthorList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cmAuthor")
				{
					Class2225 item = new Class2225(reader);
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

	public Class2140(XmlReader reader)
		: base(reader)
	{
	}

	public Class2140()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2225>();
	}

	protected override void vmethod_2()
	{
		delegate2411_0 = method_3;
		delegate2412_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("p", elementName, "http://schemas.openxmlformats.org/presentationml/2006/main");
		foreach (Class2225 item in list_0)
		{
			item.vmethod_4("p", writer, "cmAuthor");
		}
		writer.WriteEndElement();
	}

	private Class2225 method_3()
	{
		Class2225 @class = new Class2225();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2225 elementData)
	{
		list_0.Add(elementData);
	}
}
