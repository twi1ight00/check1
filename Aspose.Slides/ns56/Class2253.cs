using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2253 : Class1351
{
	public delegate Class2253 Delegate2506();

	public delegate void Delegate2507(Class2253 elementData);

	public delegate void Delegate2508(Class2253 elementData);

	public Class2254.Delegate2509 delegate2509_0;

	public Class2254.Delegate2510 delegate2510_0;

	private List<Class2254> list_0;

	public Class2254[] SldLayoutIdList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "sldLayoutId")
				{
					Class2254 item = new Class2254(reader);
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

	public Class2253(XmlReader reader)
		: base(reader)
	{
	}

	public Class2253()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2254>();
	}

	protected override void vmethod_2()
	{
		delegate2509_0 = method_3;
		delegate2510_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2254 item in list_0)
		{
			item.vmethod_4("p", writer, "sldLayoutId");
		}
		writer.WriteEndElement();
	}

	private Class2254 method_3()
	{
		Class2254 @class = new Class2254();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2254 elementData)
	{
		list_0.Add(elementData);
	}
}
