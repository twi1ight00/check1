using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1808 : Class1351
{
	public delegate Class1808 Delegate1303();

	public delegate void Delegate1304(Class1808 elementData);

	public delegate void Delegate1305(Class1808 elementData);

	private FillBlendMode fillBlendMode_0;

	private Class1832 class1832_0;

	public FillBlendMode Blend
	{
		get
		{
			return fillBlendMode_0;
		}
		set
		{
			fillBlendMode_0 = value;
		}
	}

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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "blend")
			{
				fillBlendMode_0 = Class2518.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1808(XmlReader reader)
		: base(reader)
	{
	}

	public Class1808()
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
		writer.WriteAttributeString("blend", Class2518.smethod_1(fillBlendMode_0));
		class1832_0.vmethod_4("a", writer, "cont");
		writer.WriteEndElement();
	}
}
