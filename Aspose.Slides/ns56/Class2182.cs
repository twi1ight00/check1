using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2182 : Class1351
{
	public delegate Class2182 Delegate2278();

	public delegate void Delegate2279(Class2182 elementData);

	public delegate void Delegate2280(Class2182 elementData);

	public Class2174.Delegate2254 delegate2254_0;

	public Class2174.Delegate2255 delegate2255_0;

	private List<Class2174> list_0;

	public Class2174[] RuleList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "rule")
				{
					Class2174 item = new Class2174(reader);
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

	public Class2182(XmlReader reader)
		: base(reader)
	{
	}

	public Class2182()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2174>();
	}

	protected override void vmethod_2()
	{
		delegate2254_0 = method_3;
		delegate2255_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2174 item in list_0)
		{
			item.vmethod_4("dgm", writer, "rule");
		}
		writer.WriteEndElement();
	}

	private Class2174 method_3()
	{
		Class2174 @class = new Class2174();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2174 elementData)
	{
		list_0.Add(elementData);
	}
}
