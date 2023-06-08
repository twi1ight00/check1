using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2327 : Class1351
{
	public delegate Class2327 Delegate2728();

	public delegate void Delegate2729(Class2327 elementData);

	public delegate void Delegate2730(Class2327 elementData);

	public Class2325.Delegate2722 delegate2722_0;

	public Class2325.Delegate2723 delegate2723_0;

	private List<Class2325> list_0;

	public Class2325[] FList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "f")
				{
					Class2325 item = new Class2325(reader);
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

	public Class2327(XmlReader reader)
		: base(reader)
	{
	}

	public Class2327()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2325>();
	}

	protected override void vmethod_2()
	{
		delegate2722_0 = method_3;
		delegate2723_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2325 item in list_0)
		{
			item.vmethod_4("v", writer, "f");
		}
		writer.WriteEndElement();
	}

	private Class2325 method_3()
	{
		Class2325 @class = new Class2325();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2325 elementData)
	{
		list_0.Add(elementData);
	}
}
