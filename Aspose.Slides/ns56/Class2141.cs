using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2141 : Class1351
{
	public delegate Class2141 Delegate2155();

	public delegate void Delegate2156(Class2141 elementData);

	public delegate void Delegate2157(Class2141 elementData);

	public Class2226.Delegate2414 delegate2414_0;

	public Class2226.Delegate2415 delegate2415_0;

	private List<Class2226> list_0;

	public Class2226[] CmList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cm")
				{
					Class2226 item = new Class2226(reader);
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

	public Class2141(XmlReader reader)
		: base(reader)
	{
	}

	public Class2141()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2226>();
	}

	protected override void vmethod_2()
	{
		delegate2414_0 = method_3;
		delegate2415_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("p", elementName, "http://schemas.openxmlformats.org/presentationml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		foreach (Class2226 item in list_0)
		{
			item.vmethod_4("p", writer, "cm");
		}
		writer.WriteEndElement();
	}

	private Class2226 method_3()
	{
		Class2226 @class = new Class2226();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2226 elementData)
	{
		list_0.Add(elementData);
	}
}
