using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2184 : Class1351
{
	public delegate Class2184 Delegate2284();

	public delegate void Delegate2285(Class2184 elementData);

	public delegate void Delegate2286(Class2184 elementData);

	public Class2185.Delegate2287 delegate2287_0;

	public Class2185.Delegate2288 delegate2288_0;

	private List<Class2185> list_0;

	public Class2185[] CatList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cat")
				{
					Class2185 item = new Class2185(reader);
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

	public Class2184(XmlReader reader)
		: base(reader)
	{
	}

	public Class2184()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2185>();
	}

	protected override void vmethod_2()
	{
		delegate2287_0 = method_3;
		delegate2288_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2185 item in list_0)
		{
			item.vmethod_4("dgm", writer, "cat");
		}
		writer.WriteEndElement();
	}

	private Class2185 method_3()
	{
		Class2185 @class = new Class2185();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2185 elementData)
	{
		list_0.Add(elementData);
	}
}
