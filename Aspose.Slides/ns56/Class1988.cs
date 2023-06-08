using System.Xml;

namespace ns56;

internal class Class1988 : Class1986
{
	public delegate void Delegate2421(Class1988 elementData);

	private Class1880 class1880_0;

	private Class1879 class1879_0;

	private Class2221 class2221_0;

	public override Class1880 CNvPr => class1880_0;

	public override Class1879 CNvCxnSpPr => class1879_0;

	public override Class2221 NvPr => class2221_0;

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
				case "nvPr":
					class2221_0 = new Class2221(reader);
					break;
				case "cNvCxnSpPr":
					class1879_0 = new Class1879(reader);
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

	public Class1988(XmlReader reader)
		: base(reader)
	{
	}

	public Class1988()
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
		class1879_0 = new Class1879();
		class2221_0 = new Class2221();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1880_0.vmethod_4("p", writer, "cNvPr");
		class1879_0.vmethod_4("p", writer, "cNvCxnSpPr");
		class2221_0.vmethod_4("p", writer, "nvPr");
		writer.WriteEndElement();
	}
}
