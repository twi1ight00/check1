using System;
using System.Xml;
using ns57;

namespace ns56;

internal class Class1796 : Class1351
{
	public delegate Class1796 Delegate1267();

	public delegate void Delegate1268(Class1796 elementData);

	public delegate void Delegate1269(Class1796 elementData);

	private Guid guid_0;

	private Enum291 enum291_0;

	public static readonly Guid guid_1 = Guid.Empty;

	public static readonly Enum291 enum291_1 = Class2525.smethod_0("sp");

	public Guid Id
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public Enum291 BldStep
	{
		get
		{
			return enum291_0;
		}
		set
		{
			enum291_0 = value;
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
				case "bldStep":
					enum291_0 = Class2525.smethod_0(reader.Value);
					break;
				case "id":
					guid_0 = new Guid(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1796(XmlReader reader)
		: base(reader)
	{
	}

	public Class1796()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = guid_1;
		enum291_0 = enum291_1;
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
		if (guid_0 != guid_1)
		{
			writer.WriteAttributeString("id", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		}
		if (enum291_0 != enum291_1)
		{
			writer.WriteAttributeString("bldStep", Class2525.smethod_1(enum291_0));
		}
		writer.WriteEndElement();
	}
}
