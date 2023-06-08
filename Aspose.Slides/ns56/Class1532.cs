using System;
using System.Xml;

namespace ns56;

internal class Class1532 : Class1351
{
	public delegate Class1532 Delegate475();

	public delegate void Delegate476(Class1532 elementData);

	public delegate void Delegate477(Class1532 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Enum208 enum208_0;

	private uint uint_1;

	private Class1621 class1621_0;

	private Class1502 class1502_0;

	public static readonly Enum208 enum208_1 = Class2375.smethod_0("formatting");

	public Enum208 Action
	{
		get
		{
			return enum208_0;
		}
		set
		{
			enum208_0 = value;
		}
	}

	public uint DxfId
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

	public Class1621 PivotArea => class1621_0;

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
				case "pivotArea":
					class1621_0 = new Class1621(reader);
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
				case "dxfId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "action":
					enum208_0 = Class2375.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1532(XmlReader reader)
		: base(reader)
	{
	}

	public Class1532()
	{
	}

	protected override void vmethod_1()
	{
		enum208_0 = enum208_1;
		uint_1 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1621_0 = new Class1621();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum208_0 != enum208_1)
		{
			writer.WriteAttributeString("action", Class2375.smethod_1(enum208_0));
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("dxfId", XmlConvert.ToString(uint_1));
		}
		class1621_0.vmethod_4("ssml", writer, "pivotArea");
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
