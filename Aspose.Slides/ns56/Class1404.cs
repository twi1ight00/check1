using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1404 : Class1351
{
	public delegate void Delegate176(Class1404 elementData);

	public delegate Class1404 Delegate174();

	public delegate void Delegate175(Class1404 elementData);

	public Class1403.Delegate171 delegate171_0;

	public Class1403.Delegate172 delegate172_0;

	private List<Class1403> list_0;

	public Class1403[] CellWatchList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cellWatch")
				{
					Class1403 item = new Class1403(reader);
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

	public Class1404(XmlReader reader)
		: base(reader)
	{
	}

	public Class1404()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1403>();
	}

	protected override void vmethod_2()
	{
		delegate171_0 = method_3;
		delegate172_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1403 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cellWatch");
		}
		writer.WriteEndElement();
	}

	private Class1403 method_3()
	{
		Class1403 @class = new Class1403();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1403 elementData)
	{
		list_0.Add(elementData);
	}
}
