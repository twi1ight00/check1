using System.Xml;

namespace ns56;

internal class Class1993 : Class1992
{
	public delegate void Delegate1827(Class1993 elementData);

	private Class1880 class1880_0;

	private Class1882 class1882_0;

	public override Class1880 CNvPr => class1880_0;

	public override Class1882 CNvGraphicFramePr => class1882_0;

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
				case "cNvGraphicFramePr":
					class1882_0 = new Class1882(reader);
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

	public Class1993(XmlReader reader)
		: base(reader)
	{
	}

	public Class1993()
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
		class1882_0 = new Class1882();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1880_0.vmethod_4("cdr", writer, "cNvPr");
		class1882_0.vmethod_4("cdr", writer, "cNvGraphicFramePr");
		writer.WriteEndElement();
	}
}
