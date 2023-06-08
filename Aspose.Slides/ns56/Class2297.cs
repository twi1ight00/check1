using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2297 : Class1351
{
	public delegate Class2297 Delegate2638();

	public delegate void Delegate2640(Class2297 elementData);

	public delegate void Delegate2639(Class2297 elementData);

	public Class2296.Delegate2635 delegate2635_0;

	public Class2296.Delegate2636 delegate2636_0;

	private List<Class2296> list_0;

	public Class2296[] TmplList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tmpl")
				{
					Class2296 item = new Class2296(reader);
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

	public Class2297(XmlReader reader)
		: base(reader)
	{
	}

	public Class2297()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2296>();
	}

	protected override void vmethod_2()
	{
		delegate2635_0 = method_3;
		delegate2636_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2296 item in list_0)
		{
			item.vmethod_4("p", writer, "tmpl");
		}
		writer.WriteEndElement();
	}

	private Class2296 method_3()
	{
		Class2296 @class = new Class2296();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2296 elementData)
	{
		list_0.Add(elementData);
	}
}
