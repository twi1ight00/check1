using System;
using System.Xml;

namespace ns56;

internal class Class1711 : Class1351
{
	public delegate Class1711 Delegate1012();

	public delegate void Delegate1013(Class1711 elementData);

	public delegate void Delegate1014(Class1711 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public const uint uint_3 = uint.MaxValue;

	public Class1713.Delegate1018 delegate1018_0;

	public Class1713.Delegate1020 delegate1020_0;

	public Class1713.Delegate1018 delegate1018_1;

	public Class1713.Delegate1020 delegate1020_1;

	public Class1752.Delegate1135 delegate1135_0;

	public Class1752.Delegate1137 delegate1137_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_4;

	private string string_0;

	private string string_1;

	private Enum250 enum250_0;

	private string string_2;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private string string_3;

	private string string_4;

	private string string_5;

	private Class1713 class1713_0;

	private Class1713 class1713_1;

	private Class1752 class1752_0;

	private Class1502 class1502_0;

	public static readonly Enum250 enum250_1 = Class2417.smethod_0("none");

	public uint Id
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

	public string UniqueName
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

	public string Name
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

	public Enum250 TotalsRowFunction
	{
		get
		{
			return enum250_0;
		}
		set
		{
			enum250_0 = value;
		}
	}

	public string TotalsRowLabel
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

	public uint QueryTableFieldId
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

	public uint HeaderRowDxfId
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

	public uint DataDxfId
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

	public uint TotalsRowDxfId
	{
		get
		{
			return uint_8;
		}
		set
		{
			uint_8 = value;
		}
	}

	public string HeaderRowCellStyle
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

	public string DataCellStyle
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string TotalsRowCellStyle
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public Class1713 CalculatedColumnFormula => class1713_0;

	public Class1713 TotalsRowFormula => class1713_1;

	public Class1752 XmlColumnPr => class1752_0;

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
				case "xmlColumnPr":
					class1752_0 = new Class1752(reader);
					break;
				case "totalsRowFormula":
					class1713_1 = new Class1713(reader);
					break;
				case "calculatedColumnFormula":
					class1713_0 = new Class1713(reader);
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
				case "id":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "uniqueName":
					string_0 = reader.Value;
					break;
				case "name":
					string_1 = reader.Value;
					break;
				case "totalsRowFunction":
					enum250_0 = Class2417.smethod_0(reader.Value);
					break;
				case "totalsRowLabel":
					string_2 = reader.Value;
					break;
				case "queryTableFieldId":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "headerRowDxfId":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "dataDxfId":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "totalsRowDxfId":
					uint_8 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "headerRowCellStyle":
					string_3 = reader.Value;
					break;
				case "dataCellStyle":
					string_4 = reader.Value;
					break;
				case "totalsRowCellStyle":
					string_5 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1711(XmlReader reader)
		: base(reader)
	{
	}

	public Class1711()
	{
	}

	protected override void vmethod_1()
	{
		enum250_0 = enum250_1;
		uint_5 = uint.MaxValue;
		uint_6 = uint.MaxValue;
		uint_7 = uint.MaxValue;
		uint_8 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate1018_0 = method_3;
		delegate1020_0 = method_4;
		delegate1018_1 = method_5;
		delegate1020_1 = method_6;
		delegate1135_0 = method_7;
		delegate1137_0 = method_8;
		delegate385_0 = method_9;
		delegate387_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("id", XmlConvert.ToString(uint_4));
		if (string_0 != null)
		{
			writer.WriteAttributeString("uniqueName", string_0);
		}
		writer.WriteAttributeString("name", string_1);
		if (enum250_0 != enum250_1)
		{
			writer.WriteAttributeString("totalsRowFunction", Class2417.smethod_1(enum250_0));
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("totalsRowLabel", string_2);
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("queryTableFieldId", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != uint.MaxValue)
		{
			writer.WriteAttributeString("headerRowDxfId", XmlConvert.ToString(uint_6));
		}
		if (uint_7 != uint.MaxValue)
		{
			writer.WriteAttributeString("dataDxfId", XmlConvert.ToString(uint_7));
		}
		if (uint_8 != uint.MaxValue)
		{
			writer.WriteAttributeString("totalsRowDxfId", XmlConvert.ToString(uint_8));
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("headerRowCellStyle", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("dataCellStyle", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("totalsRowCellStyle", string_5);
		}
		if (class1713_0 != null)
		{
			class1713_0.vmethod_4("ssml", writer, "calculatedColumnFormula");
		}
		if (class1713_1 != null)
		{
			class1713_1.vmethod_4("ssml", writer, "totalsRowFormula");
		}
		if (class1752_0 != null)
		{
			class1752_0.vmethod_4("ssml", writer, "xmlColumnPr");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1713 method_3()
	{
		if (class1713_0 != null)
		{
			throw new Exception("Only one <calculatedColumnFormula> element can be added.");
		}
		class1713_0 = new Class1713();
		return class1713_0;
	}

	private void method_4(Class1713 _calculatedColumnFormula)
	{
		class1713_0 = _calculatedColumnFormula;
	}

	private Class1713 method_5()
	{
		if (class1713_1 != null)
		{
			throw new Exception("Only one <totalsRowFormula> element can be added.");
		}
		class1713_1 = new Class1713();
		return class1713_1;
	}

	private void method_6(Class1713 _totalsRowFormula)
	{
		class1713_1 = _totalsRowFormula;
	}

	private Class1752 method_7()
	{
		if (class1752_0 != null)
		{
			throw new Exception("Only one <xmlColumnPr> element can be added.");
		}
		class1752_0 = new Class1752();
		return class1752_0;
	}

	private void method_8(Class1752 _xmlColumnPr)
	{
		class1752_0 = _xmlColumnPr;
	}

	private Class1502 method_9()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_10(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
