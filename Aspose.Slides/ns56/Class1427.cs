using System;
using System.Xml;

namespace ns56;

internal class Class1427 : Class1351
{
	public delegate Class1427 Delegate243();

	public delegate void Delegate244(Class1427 elementData);

	public delegate void Delegate245(Class1427 elementData);

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Enum237 enum237_0;

	private Enum251 enum251_0;

	private uint uint_0;

	private Class1624 class1624_0;

	private Class1502 class1502_0;

	public static readonly Enum237 enum237_1 = Class2404.smethod_0("selection");

	public static readonly Enum251 enum251_1 = Class2418.smethod_0("none");

	public Enum237 Scope
	{
		get
		{
			return enum237_0;
		}
		set
		{
			enum237_0 = value;
		}
	}

	public Enum251 Type
	{
		get
		{
			return enum251_0;
		}
		set
		{
			enum251_0 = value;
		}
	}

	public uint Priority
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public Class1624 PivotAreas => class1624_0;

	public Class1502 ExtLst => class1502_0;

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
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "pivotAreas":
					class1624_0 = new Class1624(reader);
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
				case "priority":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "type":
					enum251_0 = Class2418.smethod_0(reader.Value);
					break;
				case "scope":
					enum237_0 = Class2404.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1427(XmlReader reader)
		: base(reader)
	{
	}

	public Class1427()
	{
	}

	protected override void vmethod_1()
	{
		enum237_0 = enum237_1;
		enum251_0 = enum251_1;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1624_0 = new Class1624();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum237_0 != enum237_1)
		{
			writer.WriteAttributeString("scope", Class2404.smethod_1(enum237_0));
		}
		if (enum251_0 != enum251_1)
		{
			writer.WriteAttributeString("type", Class2418.smethod_1(enum251_0));
		}
		writer.WriteAttributeString("priority", XmlConvert.ToString(uint_0));
		class1624_0.vmethod_4("ssml", writer, "pivotAreas");
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1502 method_3()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_4(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
