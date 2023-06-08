using System.Xml;
using ns16;

namespace ns56;

internal class Class2116 : Class1351
{
	public delegate Class2116 Delegate2075();

	public delegate void Delegate2077(Class2116 elementData);

	public delegate void Delegate2076(Class2116 elementData);

	private Enum266 enum266_0;

	public static readonly Enum266 enum266_1 = Class2556.smethod_0("area");

	public Enum266 Val
	{
		get
		{
			return enum266_0;
		}
		set
		{
			enum266_0 = value;
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
				enum266_0 = Class2556.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2116(XmlReader reader)
		: base(reader)
	{
	}

	public Class2116()
	{
	}

	protected override void vmethod_1()
	{
		enum266_0 = enum266_1;
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
		if (enum266_0 != enum266_1)
		{
			writer.WriteAttributeString("val", Class2556.smethod_1(enum266_0));
		}
		writer.WriteEndElement();
	}
}
