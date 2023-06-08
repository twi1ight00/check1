using System.Xml;

namespace ns56;

internal class Class2203 : Class1351
{
	public delegate Class2203 Delegate2345();

	public delegate void Delegate2346(Class2203 elementData);

	public delegate void Delegate2347(Class2203 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public const Enum346 enum346_0 = Enum346.const_0;

	private Enum362 enum362_1;

	private Enum346 enum346_1;

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

	public Enum346 Type
	{
		get
		{
			return enum346_1;
		}
		set
		{
			enum346_1 = value;
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
				case "type":
					enum346_1 = Class2482.smethod_0(reader.Value);
					break;
				case "v:ext":
					enum362_1 = Class2498.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2203(XmlReader reader)
		: base(reader)
	{
	}

	public Class2203()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		enum346_1 = Enum346.const_0;
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
		if (enum346_1 != 0)
		{
			writer.WriteAttributeString("type", Class2482.smethod_1(enum346_1));
		}
		writer.WriteEndElement();
	}
}
