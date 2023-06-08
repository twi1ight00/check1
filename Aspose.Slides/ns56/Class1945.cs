using System.Xml;

namespace ns56;

internal class Class1945 : Class1351
{
	public delegate Class1945 Delegate1702();

	public delegate void Delegate1703(Class1945 elementData);

	public delegate void Delegate1704(Class1945 elementData);

	private Class1809 class1809_0;

	public Class1809 Blip => class1809_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "blip")
				{
					class1809_0 = new Class1809(reader);
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

	public Class1945(XmlReader reader)
		: base(reader)
	{
	}

	public Class1945()
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
		class1809_0 = new Class1809();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1809_0.vmethod_4("a", writer, "blip");
		writer.WriteEndElement();
	}
}
