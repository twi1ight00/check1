using System.Xml;

namespace ns56;

internal class Class2001 : Class1999
{
	public delegate void Delegate2312(Class2001 elementData);

	private Class1880 class1880_0;

	private Class1883 class1883_0;

	public override Class1880 CNvPr => class1880_0;

	public override Class1883 CNvGrpSpPr => class1883_0;

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
				switch (reader.LocalName)
				{
				case "cNvGrpSpPr":
					class1883_0 = new Class1883(reader);
					break;
				case "cNvPr":
					class1880_0 = new Class1880(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2001(XmlReader reader)
		: base(reader)
	{
	}

	public Class2001()
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
		class1880_0 = new Class1880();
		class1883_0 = new Class1883();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1880_0.vmethod_4("dsp", writer, "cNvPr");
		class1883_0.vmethod_4("dsp", writer, "cNvGrpSpPr");
		writer.WriteEndElement();
	}
}
