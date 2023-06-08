using System;
using System.Xml;

namespace ns56;

internal class Class1477 : Class1351
{
	public delegate Class1477 Delegate308();

	public delegate void Delegate309(Class1477 elementData);

	public delegate void Delegate310(Class1477 elementData);

	public const int int_0 = -1;

	public const uint uint_0 = 1048832u;

	public const uint uint_1 = uint.MaxValue;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private uint uint_2;

	private Enum194 enum194_0;

	private Enum240 enum240_0;

	private int int_1;

	private uint uint_3;

	private uint uint_4;

	private Class1502 class1502_0;

	public static readonly Enum194 enum194_1 = Class2361.smethod_0("sum");

	public static readonly Enum240 enum240_1 = Class2407.smethod_0("normal");

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public uint Fld
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public Enum194 Subtotal
	{
		get
		{
			return enum194_0;
		}
		set
		{
			enum194_0 = value;
		}
	}

	public Enum240 ShowDataAs
	{
		get
		{
			return enum240_0;
		}
		set
		{
			enum240_0 = value;
		}
	}

	public int BaseField
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public uint BaseItem
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public uint NumFmtId
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1502_0 = new Class1502(reader);
					continue;
				}
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
				case "name":
					string_0 = reader.Value;
					break;
				case "fld":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "subtotal":
					enum194_0 = Class2361.smethod_0(reader.Value);
					break;
				case "showDataAs":
					enum240_0 = Class2407.smethod_0(reader.Value);
					break;
				case "baseField":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "baseItem":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "numFmtId":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1477(XmlReader reader)
		: base(reader)
	{
	}

	public Class1477()
	{
	}

	protected override void vmethod_1()
	{
		enum194_0 = enum194_1;
		enum240_0 = enum240_1;
		int_1 = -1;
		uint_3 = 1048832u;
		uint_4 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		writer.WriteAttributeString("fld", XmlConvert.ToString(uint_2));
		if (enum194_0 != enum194_1)
		{
			writer.WriteAttributeString("subtotal", Class2361.smethod_1(enum194_0));
		}
		if (enum240_0 != enum240_1)
		{
			writer.WriteAttributeString("showDataAs", Class2407.smethod_1(enum240_0));
		}
		if (int_1 != -1)
		{
			writer.WriteAttributeString("baseField", XmlConvert.ToString(int_1));
		}
		if (uint_3 != 1048832)
		{
			writer.WriteAttributeString("baseItem", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("numFmtId", XmlConvert.ToString(uint_4));
		}
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
