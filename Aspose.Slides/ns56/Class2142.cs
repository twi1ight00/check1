using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2142 : Class1351
{
	public delegate Class2142 Delegate2158();

	public delegate void Delegate2159(Class2142 elementData);

	public delegate void Delegate2160(Class2142 elementData);

	public Class2344.Delegate2771 delegate2771_0;

	public Class2344.Delegate2772 delegate2772_0;

	private List<Class2344> list_0;

	public Class2344[] PropertyList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "property")
				{
					Class2344 item = new Class2344(reader);
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

	public Class2142(XmlReader reader)
		: base(reader)
	{
	}

	public Class2142()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2344>();
	}

	protected override void vmethod_2()
	{
		delegate2771_0 = method_3;
		delegate2772_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("", elementName, "http://schemas.openxmlformats.org/officeDocument/2006/custom-properties");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes") == null)
		{
			writer.WriteAttributeString("xmlns", "vt", null, "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
		}
		foreach (Class2344 item in list_0)
		{
			item.vmethod_4("", writer, "property");
		}
		writer.WriteEndElement();
	}

	private Class2344 method_3()
	{
		Class2344 @class = new Class2344();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2344 elementData)
	{
		list_0.Add(elementData);
	}
}
