using System.Xml;

namespace ns56;

internal class Class1788 : Class1351
{
	public delegate Class1788 Delegate1243();

	public delegate void Delegate1244(Class1788 elementData);

	public delegate void Delegate1245(Class1788 elementData);

	private Class1832 class1832_0;

	public Class1832 Cont => class1832_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cont")
				{
					class1832_0 = new Class1832(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class1788(XmlReader reader)
		: base(reader)
	{
	}

	public Class1788()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class1832_0 = new Class1832();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1832_0.vmethod_4("a", writer, "cont");
		writer.WriteEndElement();
	}
}
