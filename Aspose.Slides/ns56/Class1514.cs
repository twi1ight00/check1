using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1514 : Class1351
{
	public delegate Class1514 Delegate421();

	public delegate void Delegate423(Class1514 elementData);

	public delegate void Delegate422(Class1514 elementData);

	public Class1513.Delegate418 delegate418_0;

	public Class1513.Delegate419 delegate419_0;

	private List<Class1513> list_0;

	public Class1513[] SheetNameList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "sheetName")
				{
					Class1513 item = new Class1513(reader);
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

	public Class1514(XmlReader reader)
		: base(reader)
	{
	}

	public Class1514()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1513>();
	}

	protected override void vmethod_2()
	{
		delegate418_0 = method_3;
		delegate419_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1513 item in list_0)
		{
			item.vmethod_4("ssml", writer, "sheetName");
		}
		writer.WriteEndElement();
	}

	private Class1513 method_3()
	{
		Class1513 @class = new Class1513();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1513 elementData)
	{
		list_0.Add(elementData);
	}
}
