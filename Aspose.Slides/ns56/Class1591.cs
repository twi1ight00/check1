using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1591 : Class1351
{
	public delegate Class1591 Delegate652();

	public delegate void Delegate654(Class1591 elementData);

	public delegate void Delegate653(Class1591 elementData);

	public Class1419.Delegate219 delegate219_0;

	public Class1419.Delegate220 delegate220_0;

	private List<Class1419> list_0;

	public Class1419[] ColorList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "color")
				{
					Class1419 item = new Class1419(reader);
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

	public Class1591(XmlReader reader)
		: base(reader)
	{
	}

	public Class1591()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1419>();
	}

	protected override void vmethod_2()
	{
		delegate219_0 = method_3;
		delegate220_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1419 item in list_0)
		{
			item.vmethod_4("ssml", writer, "color");
		}
		writer.WriteEndElement();
	}

	private Class1419 method_3()
	{
		Class1419 @class = new Class1419();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1419 elementData)
	{
		list_0.Add(elementData);
	}
}
