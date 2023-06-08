using System.Xml;

namespace ns56;

internal class Class2337 : Class1351
{
	public delegate Class2337 Delegate2758();

	public delegate void Delegate2759(Class2337 elementData);

	public delegate void Delegate2760(Class2337 elementData);

	public const Enum377 enum377_0 = Enum377.const_0;

	public const Enum376 enum376_0 = Enum376.const_0;

	public const Enum374 enum374_0 = Enum374.const_0;

	public const Enum375 enum375_0 = Enum375.const_0;

	private Enum377 enum377_1;

	private Enum376 enum376_1;

	private Enum374 enum374_1;

	private Enum375 enum375_1;

	public Enum377 Type
	{
		get
		{
			return enum377_1;
		}
		set
		{
			enum377_1 = value;
		}
	}

	public Enum376 Side
	{
		get
		{
			return enum376_1;
		}
		set
		{
			enum376_1 = value;
		}
	}

	public Enum374 Anchorx
	{
		get
		{
			return enum374_1;
		}
		set
		{
			enum374_1 = value;
		}
	}

	public Enum375 Anchory
	{
		get
		{
			return enum375_1;
		}
		set
		{
			enum375_1 = value;
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
				case "anchory":
					enum375_1 = Class2511.smethod_0(reader.Value);
					break;
				case "anchorx":
					enum374_1 = Class2510.smethod_0(reader.Value);
					break;
				case "side":
					enum376_1 = Class2512.smethod_0(reader.Value);
					break;
				case "type":
					enum377_1 = Class2513.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2337(XmlReader reader)
		: base(reader)
	{
	}

	public Class2337()
	{
	}

	protected override void vmethod_1()
	{
		enum377_1 = Enum377.const_0;
		enum376_1 = Enum376.const_0;
		enum374_1 = Enum374.const_0;
		enum375_1 = Enum375.const_0;
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
		if (enum377_1 != 0)
		{
			writer.WriteAttributeString("type", Class2513.smethod_1(enum377_1));
		}
		if (enum376_1 != 0)
		{
			writer.WriteAttributeString("side", Class2512.smethod_1(enum376_1));
		}
		if (enum374_1 != 0)
		{
			writer.WriteAttributeString("anchorx", Class2510.smethod_1(enum374_1));
		}
		if (enum375_1 != 0)
		{
			writer.WriteAttributeString("anchory", Class2511.smethod_1(enum375_1));
		}
		writer.WriteEndElement();
	}
}
