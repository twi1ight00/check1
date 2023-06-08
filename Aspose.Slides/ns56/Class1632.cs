using System;
using System.Xml;

namespace ns56;

internal class Class1632 : Class1351
{
	public delegate Class1632 Delegate775();

	public delegate void Delegate776(Class1632 elementData);

	public delegate void Delegate777(Class1632 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const int int_0 = 0;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_3;

	private uint uint_4;

	private Enum231 enum231_0;

	private int int_1;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private Class1371 class1371_0;

	private Class1502 class1502_0;

	public uint Fld
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

	public uint MpFld
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

	public Enum231 Type
	{
		get
		{
			return enum231_0;
		}
		set
		{
			enum231_0 = value;
		}
	}

	public int EvalOrder
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

	public uint Id
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public uint IMeasureHier
	{
		get
		{
			return uint_6;
		}
		set
		{
			uint_6 = value;
		}
	}

	public uint IMeasureFld
	{
		get
		{
			return uint_7;
		}
		set
		{
			uint_7 = value;
		}
	}

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

	public string Description
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string StringValue1
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string StringValue2
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public Class1371 AutoFilter => class1371_0;

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
				case "autoFilter":
					class1371_0 = new Class1371(reader);
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
				case "fld":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "mpFld":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "type":
					enum231_0 = Class2398.smethod_0(reader.Value);
					break;
				case "evalOrder":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "id":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "iMeasureHier":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "iMeasureFld":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				case "description":
					string_1 = reader.Value;
					break;
				case "stringValue1":
					string_2 = reader.Value;
					break;
				case "stringValue2":
					string_3 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1632(XmlReader reader)
		: base(reader)
	{
	}

	public Class1632()
	{
	}

	protected override void vmethod_1()
	{
		uint_4 = uint.MaxValue;
		enum231_0 = Enum231.const_0;
		int_1 = 0;
		uint_6 = uint.MaxValue;
		uint_7 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1371_0 = new Class1371();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("fld", XmlConvert.ToString(uint_3));
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("mpFld", XmlConvert.ToString(uint_4));
		}
		writer.WriteAttributeString("type", Class2398.smethod_1(enum231_0));
		if (int_1 != 0)
		{
			writer.WriteAttributeString("evalOrder", XmlConvert.ToString(int_1));
		}
		writer.WriteAttributeString("id", XmlConvert.ToString(uint_5));
		if (uint_6 != uint.MaxValue)
		{
			writer.WriteAttributeString("iMeasureHier", XmlConvert.ToString(uint_6));
		}
		if (uint_7 != uint.MaxValue)
		{
			writer.WriteAttributeString("iMeasureFld", XmlConvert.ToString(uint_7));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("description", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("stringValue1", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("stringValue2", string_3);
		}
		class1371_0.vmethod_4("ssml", writer, "autoFilter");
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
