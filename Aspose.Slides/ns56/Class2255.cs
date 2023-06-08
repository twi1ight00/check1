using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2255 : Class1351
{
	public delegate Class2255 Delegate2512();

	public delegate void Delegate2514(Class2255 elementData);

	public delegate void Delegate2513(Class2255 elementData);

	public Class2256.Delegate2515 delegate2515_0;

	public Class2256.Delegate2516 delegate2516_0;

	private List<Class2256> list_0;

	public Class2256[] SldMasterIdList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "sldMasterId")
				{
					Class2256 item = new Class2256(reader);
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

	public Class2255(XmlReader reader)
		: base(reader)
	{
	}

	public Class2255()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2256>();
	}

	protected override void vmethod_2()
	{
		delegate2515_0 = method_3;
		delegate2516_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2256 item in list_0)
		{
			item.vmethod_4("p", writer, "sldMasterId");
		}
		writer.WriteEndElement();
	}

	private Class2256 method_3()
	{
		Class2256 @class = new Class2256();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2256 elementData)
	{
		list_0.Add(elementData);
	}
}
