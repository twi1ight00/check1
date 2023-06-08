using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1445 : Class1351
{
	public delegate void Delegate299(Class1445 elementData);

	public delegate Class1445 Delegate297();

	public delegate void Delegate298(Class1445 elementData);

	public Class1444.Delegate294 delegate294_0;

	public Class1444.Delegate295 delegate295_0;

	private List<Class1444> list_0;

	public Class1444[] CustomWorkbookViewList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "customWorkbookView")
				{
					Class1444 item = new Class1444(reader);
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

	public Class1445(XmlReader reader)
		: base(reader)
	{
	}

	public Class1445()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1444>();
	}

	protected override void vmethod_2()
	{
		delegate294_0 = method_3;
		delegate295_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1444 item in list_0)
		{
			item.vmethod_4("ssml", writer, "customWorkbookView");
		}
		writer.WriteEndElement();
	}

	private Class1444 method_3()
	{
		Class1444 @class = new Class1444();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1444 elementData)
	{
		list_0.Add(elementData);
	}
}
