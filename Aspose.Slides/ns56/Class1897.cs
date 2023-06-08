using System.Xml;

namespace ns56;

internal class Class1897 : Class1351
{
	public delegate Class1897 Delegate1558();

	public delegate void Delegate1559(Class1897 elementData);

	public delegate void Delegate1560(Class1897 elementData);

	private Class1782 class1782_0;

	public Class1782 Pt => class1782_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "pt")
				{
					class1782_0 = new Class1782(reader);
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

	public Class1897(XmlReader reader)
		: base(reader)
	{
	}

	public Class1897()
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
		class1782_0 = new Class1782();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1782_0.vmethod_4("a", writer, "pt");
		writer.WriteEndElement();
	}
}
