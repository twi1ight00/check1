using System.Xml;

namespace ns56;

internal class Class2200 : Class1351
{
	public delegate Class2200 Delegate2336();

	public delegate void Delegate2337(Class2200 elementData);

	public delegate void Delegate2338(Class2200 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	private Enum362 enum362_1;

	public Enum362 V_Ext
	{
		get
		{
			return enum362_1;
		}
		set
		{
			enum362_1 = value;
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "v:ext")
			{
				enum362_1 = Class2498.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2200(XmlReader reader)
		: base(reader)
	{
	}

	public Class2200()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
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
		if (enum362_1 != 0)
		{
			writer.WriteAttributeString("v:ext", Class2498.smethod_1(enum362_1));
		}
		writer.WriteEndElement();
	}
}
