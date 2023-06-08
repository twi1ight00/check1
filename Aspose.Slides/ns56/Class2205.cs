using System.Xml;

namespace ns56;

internal class Class2205 : Class1351
{
	public delegate Class2205 Delegate2351();

	public delegate void Delegate2352(Class2205 elementData);

	public delegate void Delegate2353(Class2205 elementData);

	public const Enum352 enum352_0 = Enum352.const_0;

	private Class1474 class1474_0;

	private Enum352 enum352_1;

	public Class1474 I => class1474_0;

	public Enum352 Annotation
	{
		get
		{
			return enum352_1;
		}
		set
		{
			enum352_1 = value;
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "annotation":
					enum352_1 = Class2488.smethod_0(reader.Value);
					break;
				case "i":
					class1474_0 = new Class1474(reader);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2205(XmlReader reader)
		: base(reader)
	{
	}

	public Class2205()
	{
	}

	protected override void vmethod_1()
	{
		enum352_1 = Enum352.const_0;
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
		if (class1474_0 != null)
		{
			writer.WriteAttributeString("i", class1474_0.OuterXml);
		}
		if (enum352_1 != 0)
		{
			writer.WriteAttributeString("annotation", Class2488.smethod_1(enum352_1));
		}
		writer.WriteEndElement();
	}
}
