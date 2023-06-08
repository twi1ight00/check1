using System;
using System.Xml;

namespace ns56;

internal class Class1771 : Class1351
{
	public delegate Class1771 Delegate1192();

	public delegate void Delegate1193(Class1771 elementData);

	public delegate void Delegate1194(Class1771 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public const bool bool_9 = false;

	public const bool bool_10 = false;

	public Class1394.Delegate144 delegate144_0;

	public Class1394.Delegate146 delegate146_0;

	public Class1498.Delegate371 delegate371_0;

	public Class1498.Delegate373 delegate373_0;

	public Class1498.Delegate371 delegate371_1;

	public Class1498.Delegate373 delegate373_1;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_1;

	private bool bool_11;

	private bool bool_12;

	private uint uint_2;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private uint uint_3;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private Class1394 class1394_0;

	private Class1394 class1394_1;

	private Class1498 class1498_0;

	private Class1498 class1498_1;

	private Class1502 class1502_0;

	public uint RId
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

	public bool Ua
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public bool Ra
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public uint SId
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

	public bool OdxfAttr
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	public bool XfDxf
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	public bool S
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	public bool Dxf
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public uint NumFmtId
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

	public bool QuotePrefix
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	public bool OldQuotePrefix
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public bool Ph
	{
		get
		{
			return bool_19;
		}
		set
		{
			bool_19 = value;
		}
	}

	public bool OldPh
	{
		get
		{
			return bool_20;
		}
		set
		{
			bool_20 = value;
		}
	}

	public bool EndOfListFormulaUpdate
	{
		get
		{
			return bool_21;
		}
		set
		{
			bool_21 = value;
		}
	}

	public Class1394 Oc => class1394_0;

	public Class1394 Nc => class1394_1;

	public Class1498 Odxf => class1498_0;

	public Class1498 Ndxf => class1498_1;

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
				case "ndxf":
					class1498_1 = new Class1498(reader);
					break;
				case "odxf":
					class1498_0 = new Class1498(reader);
					break;
				case "nc":
					class1394_1 = new Class1394(reader);
					break;
				case "oc":
					class1394_0 = new Class1394(reader);
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
				case "rId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ua":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ra":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "odxf":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "xfDxf":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "s":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dxf":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "numFmtId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "quotePrefix":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "oldQuotePrefix":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ph":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "oldPh":
					bool_20 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "endOfListFormulaUpdate":
					bool_21 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1771(XmlReader reader)
		: base(reader)
	{
	}

	public Class1771()
	{
	}

	protected override void vmethod_1()
	{
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		bool_14 = false;
		bool_15 = false;
		bool_16 = false;
		uint_3 = uint.MaxValue;
		bool_17 = false;
		bool_18 = false;
		bool_19 = false;
		bool_20 = false;
		bool_21 = false;
	}

	protected override void vmethod_2()
	{
		delegate144_0 = method_3;
		delegate146_0 = method_4;
		delegate371_0 = method_5;
		delegate373_0 = method_6;
		delegate371_1 = method_7;
		delegate373_1 = method_8;
		delegate385_0 = method_9;
		delegate387_0 = method_10;
	}

	protected override void vmethod_3()
	{
		class1394_1 = new Class1394();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("rId", XmlConvert.ToString(uint_1));
		if (bool_11)
		{
			writer.WriteAttributeString("ua", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("ra", bool_12 ? "1" : "0");
		}
		writer.WriteAttributeString("sId", XmlConvert.ToString(uint_2));
		if (bool_13)
		{
			writer.WriteAttributeString("odxf", bool_13 ? "1" : "0");
		}
		if (bool_14)
		{
			writer.WriteAttributeString("xfDxf", bool_14 ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("s", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("dxf", bool_16 ? "1" : "0");
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("numFmtId", XmlConvert.ToString(uint_3));
		}
		if (bool_17)
		{
			writer.WriteAttributeString("quotePrefix", bool_17 ? "1" : "0");
		}
		if (bool_18)
		{
			writer.WriteAttributeString("oldQuotePrefix", bool_18 ? "1" : "0");
		}
		if (bool_19)
		{
			writer.WriteAttributeString("ph", bool_19 ? "1" : "0");
		}
		if (bool_20)
		{
			writer.WriteAttributeString("oldPh", bool_20 ? "1" : "0");
		}
		if (bool_21)
		{
			writer.WriteAttributeString("endOfListFormulaUpdate", bool_21 ? "1" : "0");
		}
		if (class1394_0 != null)
		{
			class1394_0.vmethod_4("ssml", writer, "oc");
		}
		class1394_1.vmethod_4("ssml", writer, "nc");
		if (class1498_0 != null)
		{
			class1498_0.vmethod_4("ssml", writer, "odxf");
		}
		if (class1498_1 != null)
		{
			class1498_1.vmethod_4("ssml", writer, "ndxf");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1394 method_3()
	{
		if (class1394_0 != null)
		{
			throw new Exception("Only one <oc> element can be added.");
		}
		class1394_0 = new Class1394();
		return class1394_0;
	}

	private void method_4(Class1394 _oc)
	{
		class1394_0 = _oc;
	}

	private Class1498 method_5()
	{
		if (class1498_0 != null)
		{
			throw new Exception("Only one <odxf> element can be added.");
		}
		class1498_0 = new Class1498();
		return class1498_0;
	}

	private void method_6(Class1498 _odxf)
	{
		class1498_0 = _odxf;
	}

	private Class1498 method_7()
	{
		if (class1498_1 != null)
		{
			throw new Exception("Only one <ndxf> element can be added.");
		}
		class1498_1 = new Class1498();
		return class1498_1;
	}

	private void method_8(Class1498 _ndxf)
	{
		class1498_1 = _ndxf;
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
