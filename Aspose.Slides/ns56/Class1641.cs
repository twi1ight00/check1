using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1641 : Class1351
{
	public delegate void Delegate804(Class1641 elementData);

	public delegate Class1641 Delegate802();

	public delegate void Delegate803(Class1641 elementData);

	public Class1640.Delegate799 delegate799_0;

	public Class1640.Delegate800 delegate800_0;

	private List<Class1640> list_0;

	public Class1640[] ProtectedRangeList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "protectedRange")
				{
					Class1640 item = new Class1640(reader);
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

	public Class1641(XmlReader reader)
		: base(reader)
	{
	}

	public Class1641()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1640>();
	}

	protected override void vmethod_2()
	{
		delegate799_0 = method_3;
		delegate800_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1640 item in list_0)
		{
			item.vmethod_4("ssml", writer, "protectedRange");
		}
		writer.WriteEndElement();
	}

	private Class1640 method_3()
	{
		Class1640 @class = new Class1640();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1640 elementData)
	{
		list_0.Add(elementData);
	}
}
