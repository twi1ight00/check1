using System.Xml;

namespace ns56;

internal class Class2148 : Class1351
{
	public delegate Class2148 Delegate2176();

	public delegate void Delegate2177(Class2148 elementData);

	public delegate void Delegate2178(Class2148 elementData);

	private Enum325 enum325_0;

	public static readonly Enum325 enum325_1 = Class2455.smethod_0("one");

	public Enum325 Val
	{
		get
		{
			return enum325_0;
		}
		set
		{
			enum325_0 = value;
		}
	}

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
				_ = reader.LocalName;
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "val")
			{
				enum325_0 = Class2455.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2148(XmlReader reader)
		: base(reader)
	{
	}

	public Class2148()
	{
	}

	protected override void vmethod_1()
	{
		enum325_0 = enum325_1;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum325_0 != enum325_1)
		{
			writer.WriteAttributeString("val", Class2455.smethod_1(enum325_0));
		}
		writer.WriteEndElement();
	}
}
