using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1443 : Class1351
{
	public delegate void Delegate293(Class1443 elementData);

	public delegate Class1443 Delegate291();

	public delegate void Delegate292(Class1443 elementData);

	public Class1442.Delegate288 delegate288_0;

	public Class1442.Delegate289 delegate289_0;

	private List<Class1442> list_0;

	public Class1442[] CustomSheetViewList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "customSheetView")
				{
					Class1442 item = new Class1442(reader);
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

	public Class1443(XmlReader reader)
		: base(reader)
	{
	}

	public Class1443()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1442>();
	}

	protected override void vmethod_2()
	{
		delegate288_0 = method_3;
		delegate289_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1442 item in list_0)
		{
			item.vmethod_4("ssml", writer, "customSheetView");
		}
		writer.WriteEndElement();
	}

	private Class1442 method_3()
	{
		Class1442 @class = new Class1442();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1442 elementData)
	{
		list_0.Add(elementData);
	}
}
