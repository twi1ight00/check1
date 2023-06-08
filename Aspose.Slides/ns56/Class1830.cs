using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1830 : Class1351
{
	public delegate Class1830 Delegate1369();

	public delegate void Delegate1370(Class1830 elementData);

	public delegate void Delegate1371(Class1830 elementData);

	public Class1829.Delegate1366 delegate1366_0;

	public Class1829.Delegate1367 delegate1367_0;

	private List<Class1829> list_0;

	public Class1829[] DsList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "ds")
				{
					Class1829 item = new Class1829(reader);
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

	public Class1830(XmlReader reader)
		: base(reader)
	{
	}

	public Class1830()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1829>();
	}

	protected override void vmethod_2()
	{
		delegate1366_0 = method_3;
		delegate1367_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1829 item in list_0)
		{
			item.vmethod_4("a", writer, "ds");
		}
		writer.WriteEndElement();
	}

	private Class1829 method_3()
	{
		Class1829 @class = new Class1829();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1829 elementData)
	{
		list_0.Add(elementData);
	}
}
