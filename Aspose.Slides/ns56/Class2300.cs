using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2300 : Class1351
{
	public delegate Class2300 Delegate2647();

	public delegate void Delegate2649(Class2300 elementData);

	public delegate void Delegate2648(Class2300 elementData);

	public Class2299.Delegate2644 delegate2644_0;

	public Class2299.Delegate2645 delegate2645_0;

	private List<Class2299> list_0;

	public Class2299[] TavList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tav")
				{
					Class2299 item = new Class2299(reader);
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

	public Class2300(XmlReader reader)
		: base(reader)
	{
	}

	public Class2300()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2299>();
	}

	protected override void vmethod_2()
	{
		delegate2644_0 = method_3;
		delegate2645_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2299 item in list_0)
		{
			item.vmethod_4("p", writer, "tav");
		}
		writer.WriteEndElement();
	}

	private Class2299 method_3()
	{
		Class2299 @class = new Class2299();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2299 elementData)
	{
		list_0.Add(elementData);
	}
}
