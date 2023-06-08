using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2248 : Class1351
{
	public delegate void Delegate2489(Class2248 elementData);

	public delegate Class2248 Delegate2487();

	public delegate void Delegate2488(Class2248 elementData);

	public Class2247.Delegate2484 delegate2484_0;

	public Class2247.Delegate2485 delegate2485_0;

	private List<Class2247> list_0;

	public Class2247[] SldList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "sld")
				{
					Class2247 item = new Class2247(reader);
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

	public Class2248(XmlReader reader)
		: base(reader)
	{
	}

	public Class2248()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2247>();
	}

	protected override void vmethod_2()
	{
		delegate2484_0 = method_3;
		delegate2485_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2247 item in list_0)
		{
			item.vmethod_4("p", writer, "sld");
		}
		writer.WriteEndElement();
	}

	private Class2247 method_3()
	{
		Class2247 @class = new Class2247();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2247 elementData)
	{
		list_0.Add(elementData);
	}
}
