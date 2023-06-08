using System.Xml;

namespace ns56;

internal class Class1372 : Class1351
{
	public delegate Class1372 Delegate78();

	public delegate void Delegate79(Class1372 elementData);

	public delegate void Delegate80(Class1372 elementData);

	private Class1621 class1621_0;

	public Class1621 PivotArea => class1621_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "pivotArea")
				{
					class1621_0 = new Class1621(reader);
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

	public Class1372(XmlReader reader)
		: base(reader)
	{
	}

	public Class1372()
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
		class1621_0 = new Class1621();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1621_0.vmethod_4("ssml", writer, "pivotArea");
		writer.WriteEndElement();
	}
}
