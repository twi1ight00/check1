using System.Xml;

namespace ns56;

internal class Class2181 : Class1351
{
	public delegate Class2181 Delegate2275();

	public delegate void Delegate2277(Class2181 elementData);

	public delegate void Delegate2276(Class2181 elementData);

	private Enum338 enum338_0;

	public static readonly Enum338 enum338_1 = Class2470.smethod_0("rel");

	public Enum338 Val
	{
		get
		{
			return enum338_0;
		}
		set
		{
			enum338_0 = value;
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
				enum338_0 = Class2470.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2181(XmlReader reader)
		: base(reader)
	{
	}

	public Class2181()
	{
	}

	protected override void vmethod_1()
	{
		enum338_0 = enum338_1;
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
		if (enum338_0 != enum338_1)
		{
			writer.WriteAttributeString("val", Class2470.smethod_1(enum338_0));
		}
		writer.WriteEndElement();
	}
}
