using System;
using System.Xml;

namespace ns56;

internal class Class1436 : Class1351
{
	public delegate Class1436 Delegate270();

	public delegate void Delegate271(Class1436 elementData);

	public delegate void Delegate272(Class1436 elementData);

	public const uint uint_0 = 100u;

	public const bool bool_0 = false;

	public Class1607.Delegate700 delegate700_0;

	public Class1607.Delegate702 delegate702_0;

	public Class1435.Delegate267 delegate267_0;

	public Class1435.Delegate269 delegate269_0;

	public Class1546.Delegate517 delegate517_0;

	public Class1546.Delegate519 delegate519_0;

	private Guid guid_0;

	private uint uint_1;

	private Enum238 enum238_0;

	private bool bool_1;

	private Class1607 class1607_0;

	private Class1435 class1435_0;

	private Class1546 class1546_0;

	public static readonly Enum238 enum238_1 = Class2405.smethod_0("visible");

	public Guid Guid
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

	public uint Scale
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Enum238 State
	{
		get
		{
			return enum238_0;
		}
		set
		{
			enum238_0 = value;
		}
	}

	public bool ZoomToFit
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class1607 PageMargins => class1607_0;

	public Class1435 PageSetup => class1435_0;

	public Class1546 HeaderFooter => class1546_0;

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
				case "headerFooter":
					class1546_0 = new Class1546(reader);
					break;
				case "pageSetup":
					class1435_0 = new Class1435(reader);
					break;
				case "pageMargins":
					class1607_0 = new Class1607(reader);
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
		while (reader.MoveToNextAttribute())
		{
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "zoomToFit":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "state":
					enum238_0 = Class2405.smethod_0(reader.Value);
					break;
				case "scale":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "guid":
					guid_0 = new Guid(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1436(XmlReader reader)
		: base(reader)
	{
	}

	public Class1436()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		uint_1 = 100u;
		enum238_0 = enum238_1;
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
		delegate700_0 = method_3;
		delegate702_0 = method_4;
		delegate267_0 = method_5;
		delegate269_0 = method_6;
		delegate517_0 = method_7;
		delegate519_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		if (uint_1 != 100)
		{
			writer.WriteAttributeString("scale", XmlConvert.ToString(uint_1));
		}
		if (enum238_0 != enum238_1)
		{
			writer.WriteAttributeString("state", Class2405.smethod_1(enum238_0));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("zoomToFit", bool_1 ? "1" : "0");
		}
		if (class1607_0 != null)
		{
			class1607_0.vmethod_4("ssml", writer, "pageMargins");
		}
		if (class1435_0 != null)
		{
			class1435_0.vmethod_4("ssml", writer, "pageSetup");
		}
		if (class1546_0 != null)
		{
			class1546_0.vmethod_4("ssml", writer, "headerFooter");
		}
		writer.WriteEndElement();
	}

	private Class1607 method_3()
	{
		if (class1607_0 != null)
		{
			throw new Exception("Only one <pageMargins> element can be added.");
		}
		class1607_0 = new Class1607();
		return class1607_0;
	}

	private void method_4(Class1607 _pageMargins)
	{
		class1607_0 = _pageMargins;
	}

	private Class1435 method_5()
	{
		if (class1435_0 != null)
		{
			throw new Exception("Only one <pageSetup> element can be added.");
		}
		class1435_0 = new Class1435();
		return class1435_0;
	}

	private void method_6(Class1435 _pageSetup)
	{
		class1435_0 = _pageSetup;
	}

	private Class1546 method_7()
	{
		if (class1546_0 != null)
		{
			throw new Exception("Only one <headerFooter> element can be added.");
		}
		class1546_0 = new Class1546();
		return class1546_0;
	}

	private void method_8(Class1546 _headerFooter)
	{
		class1546_0 = _headerFooter;
	}
}
