using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1423 : Class1351
{
	public delegate void Delegate232(Class1423 elementData);

	public delegate Class1423 Delegate231();

	public delegate void Delegate233(Class1423 elementData);

	public Class1415.Delegate207 delegate207_0;

	public Class1415.Delegate208 delegate208_0;

	private List<Class1415> list_0;

	public Class1415[] ColList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "col")
				{
					Class1415 item = new Class1415(reader);
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

	public Class1423(XmlReader reader)
		: base(reader)
	{
	}

	public Class1423()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1415>();
	}

	protected override void vmethod_2()
	{
		delegate207_0 = method_3;
		delegate208_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1415 item in list_0)
		{
			item.vmethod_4("ssml", writer, "col");
		}
		writer.WriteEndElement();
	}

	private Class1415 method_3()
	{
		Class1415 @class = new Class1415();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1415 elementData)
	{
		list_0.Add(elementData);
	}
}
