using System;
using System.Xml;

namespace ns56;

internal class Class1942 : Class1351
{
	public delegate Class1942 Delegate1693();

	public delegate void Delegate1694(Class1942 elementData);

	public delegate void Delegate1695(Class1942 elementData);

	public Class1932.Delegate1663 delegate1663_0;

	public Class1932.Delegate1665 delegate1665_0;

	public Class1938.Delegate1681 delegate1681_0;

	public Class1938.Delegate1683 delegate1683_0;

	public Class1938.Delegate1681 delegate1681_1;

	public Class1938.Delegate1683 delegate1683_1;

	public Class1938.Delegate1681 delegate1681_2;

	public Class1938.Delegate1683 delegate1683_2;

	public Class1938.Delegate1681 delegate1681_3;

	public Class1938.Delegate1683 delegate1683_3;

	public Class1938.Delegate1681 delegate1681_4;

	public Class1938.Delegate1683 delegate1683_4;

	public Class1938.Delegate1681 delegate1681_5;

	public Class1938.Delegate1683 delegate1683_5;

	public Class1938.Delegate1681 delegate1681_6;

	public Class1938.Delegate1683 delegate1683_6;

	public Class1938.Delegate1681 delegate1681_7;

	public Class1938.Delegate1683 delegate1683_7;

	public Class1938.Delegate1681 delegate1681_8;

	public Class1938.Delegate1683 delegate1683_8;

	public Class1938.Delegate1681 delegate1681_9;

	public Class1938.Delegate1683 delegate1683_9;

	public Class1938.Delegate1681 delegate1681_10;

	public Class1938.Delegate1683 delegate1683_10;

	public Class1938.Delegate1681 delegate1681_11;

	public Class1938.Delegate1683 delegate1683_11;

	public Class1938.Delegate1681 delegate1681_12;

	public Class1938.Delegate1683 delegate1683_12;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Guid guid_0;

	private string string_0;

	private Class1932 class1932_0;

	private Class1938 class1938_0;

	private Class1938 class1938_1;

	private Class1938 class1938_2;

	private Class1938 class1938_3;

	private Class1938 class1938_4;

	private Class1938 class1938_5;

	private Class1938 class1938_6;

	private Class1938 class1938_7;

	private Class1938 class1938_8;

	private Class1938 class1938_9;

	private Class1938 class1938_10;

	private Class1938 class1938_11;

	private Class1938 class1938_12;

	private Class1886 class1886_0;

	public Guid StyleId
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

	public string StyleName
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

	public Class1932 TblBg => class1932_0;

	public Class1938 WholeTbl => class1938_0;

	public Class1938 Band1H => class1938_1;

	public Class1938 Band2H => class1938_2;

	public Class1938 Band1V => class1938_3;

	public Class1938 Band2V => class1938_4;

	public Class1938 LastCol => class1938_5;

	public Class1938 FirstCol => class1938_6;

	public Class1938 LastRow => class1938_7;

	public Class1938 SeCell => class1938_8;

	public Class1938 SwCell => class1938_9;

	public Class1938 FirstRow => class1938_10;

	public Class1938 NeCell => class1938_11;

	public Class1938 NwCell => class1938_12;

	public Class1885 ExtLst => class1886_0;

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
				case "tblBg":
					class1932_0 = new Class1932(reader);
					break;
				case "wholeTbl":
					class1938_0 = new Class1938(reader);
					break;
				case "band1H":
					class1938_1 = new Class1938(reader);
					break;
				case "band2H":
					class1938_2 = new Class1938(reader);
					break;
				case "band1V":
					class1938_3 = new Class1938(reader);
					break;
				case "band2V":
					class1938_4 = new Class1938(reader);
					break;
				case "lastCol":
					class1938_5 = new Class1938(reader);
					break;
				case "firstCol":
					class1938_6 = new Class1938(reader);
					break;
				case "lastRow":
					class1938_7 = new Class1938(reader);
					break;
				case "seCell":
					class1938_8 = new Class1938(reader);
					break;
				case "swCell":
					class1938_9 = new Class1938(reader);
					break;
				case "firstRow":
					class1938_10 = new Class1938(reader);
					break;
				case "neCell":
					class1938_11 = new Class1938(reader);
					break;
				case "nwCell":
					class1938_12 = new Class1938(reader);
					break;
				case "extLst":
					class1886_0 = new Class1886(reader);
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
				case "styleName":
					string_0 = reader.Value;
					break;
				case "styleId":
					guid_0 = new Guid(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1942(XmlReader reader)
		: base(reader)
	{
	}

	public Class1942()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
	}

	protected override void vmethod_2()
	{
		delegate1663_0 = method_3;
		delegate1665_0 = method_4;
		delegate1681_0 = method_5;
		delegate1683_0 = method_6;
		delegate1681_1 = method_7;
		delegate1683_1 = method_8;
		delegate1681_2 = method_9;
		delegate1683_2 = method_10;
		delegate1681_3 = method_11;
		delegate1683_3 = method_12;
		delegate1681_4 = method_13;
		delegate1683_4 = method_14;
		delegate1681_5 = method_15;
		delegate1683_5 = method_16;
		delegate1681_6 = method_17;
		delegate1683_6 = method_18;
		delegate1681_7 = method_19;
		delegate1683_7 = method_20;
		delegate1681_8 = method_21;
		delegate1683_8 = method_22;
		delegate1681_9 = method_23;
		delegate1683_9 = method_24;
		delegate1681_10 = method_25;
		delegate1683_10 = method_26;
		delegate1681_11 = method_27;
		delegate1683_11 = method_28;
		delegate1681_12 = method_29;
		delegate1683_12 = method_30;
		delegate1534_0 = method_31;
		delegate1535_0 = method_32;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("styleId", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		writer.WriteAttributeString("styleName", string_0);
		if (class1932_0 != null)
		{
			class1932_0.vmethod_4("a", writer, "tblBg");
		}
		if (class1938_0 != null)
		{
			class1938_0.vmethod_4("a", writer, "wholeTbl");
		}
		if (class1938_1 != null)
		{
			class1938_1.vmethod_4("a", writer, "band1H");
		}
		if (class1938_2 != null)
		{
			class1938_2.vmethod_4("a", writer, "band2H");
		}
		if (class1938_3 != null)
		{
			class1938_3.vmethod_4("a", writer, "band1V");
		}
		if (class1938_4 != null)
		{
			class1938_4.vmethod_4("a", writer, "band2V");
		}
		if (class1938_5 != null)
		{
			class1938_5.vmethod_4("a", writer, "lastCol");
		}
		if (class1938_6 != null)
		{
			class1938_6.vmethod_4("a", writer, "firstCol");
		}
		if (class1938_7 != null)
		{
			class1938_7.vmethod_4("a", writer, "lastRow");
		}
		if (class1938_8 != null)
		{
			class1938_8.vmethod_4("a", writer, "seCell");
		}
		if (class1938_9 != null)
		{
			class1938_9.vmethod_4("a", writer, "swCell");
		}
		if (class1938_10 != null)
		{
			class1938_10.vmethod_4("a", writer, "firstRow");
		}
		if (class1938_11 != null)
		{
			class1938_11.vmethod_4("a", writer, "neCell");
		}
		if (class1938_12 != null)
		{
			class1938_12.vmethod_4("a", writer, "nwCell");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1932 method_3()
	{
		if (class1932_0 != null)
		{
			throw new Exception("Only one <tblBg> element can be added.");
		}
		class1932_0 = new Class1932();
		return class1932_0;
	}

	private void method_4(Class1932 _tblBg)
	{
		class1932_0 = _tblBg;
	}

	private Class1938 method_5()
	{
		if (class1938_0 != null)
		{
			throw new Exception("Only one <wholeTbl> element can be added.");
		}
		class1938_0 = new Class1938();
		return class1938_0;
	}

	private void method_6(Class1938 _wholeTbl)
	{
		class1938_0 = _wholeTbl;
	}

	private Class1938 method_7()
	{
		if (class1938_1 != null)
		{
			throw new Exception("Only one <band1H> element can be added.");
		}
		class1938_1 = new Class1938();
		return class1938_1;
	}

	private void method_8(Class1938 _band1H)
	{
		class1938_1 = _band1H;
	}

	private Class1938 method_9()
	{
		if (class1938_2 != null)
		{
			throw new Exception("Only one <band2H> element can be added.");
		}
		class1938_2 = new Class1938();
		return class1938_2;
	}

	private void method_10(Class1938 _band2H)
	{
		class1938_2 = _band2H;
	}

	private Class1938 method_11()
	{
		if (class1938_3 != null)
		{
			throw new Exception("Only one <band1V> element can be added.");
		}
		class1938_3 = new Class1938();
		return class1938_3;
	}

	private void method_12(Class1938 _band1V)
	{
		class1938_3 = _band1V;
	}

	private Class1938 method_13()
	{
		if (class1938_4 != null)
		{
			throw new Exception("Only one <band2V> element can be added.");
		}
		class1938_4 = new Class1938();
		return class1938_4;
	}

	private void method_14(Class1938 _band2V)
	{
		class1938_4 = _band2V;
	}

	private Class1938 method_15()
	{
		if (class1938_5 != null)
		{
			throw new Exception("Only one <lastCol> element can be added.");
		}
		class1938_5 = new Class1938();
		return class1938_5;
	}

	private void method_16(Class1938 _lastCol)
	{
		class1938_5 = _lastCol;
	}

	private Class1938 method_17()
	{
		if (class1938_6 != null)
		{
			throw new Exception("Only one <firstCol> element can be added.");
		}
		class1938_6 = new Class1938();
		return class1938_6;
	}

	private void method_18(Class1938 _firstCol)
	{
		class1938_6 = _firstCol;
	}

	private Class1938 method_19()
	{
		if (class1938_7 != null)
		{
			throw new Exception("Only one <lastRow> element can be added.");
		}
		class1938_7 = new Class1938();
		return class1938_7;
	}

	private void method_20(Class1938 _lastRow)
	{
		class1938_7 = _lastRow;
	}

	private Class1938 method_21()
	{
		if (class1938_8 != null)
		{
			throw new Exception("Only one <seCell> element can be added.");
		}
		class1938_8 = new Class1938();
		return class1938_8;
	}

	private void method_22(Class1938 _seCell)
	{
		class1938_8 = _seCell;
	}

	private Class1938 method_23()
	{
		if (class1938_9 != null)
		{
			throw new Exception("Only one <swCell> element can be added.");
		}
		class1938_9 = new Class1938();
		return class1938_9;
	}

	private void method_24(Class1938 _swCell)
	{
		class1938_9 = _swCell;
	}

	private Class1938 method_25()
	{
		if (class1938_10 != null)
		{
			throw new Exception("Only one <firstRow> element can be added.");
		}
		class1938_10 = new Class1938();
		return class1938_10;
	}

	private void method_26(Class1938 _firstRow)
	{
		class1938_10 = _firstRow;
	}

	private Class1938 method_27()
	{
		if (class1938_11 != null)
		{
			throw new Exception("Only one <neCell> element can be added.");
		}
		class1938_11 = new Class1938();
		return class1938_11;
	}

	private void method_28(Class1938 _neCell)
	{
		class1938_11 = _neCell;
	}

	private Class1938 method_29()
	{
		if (class1938_12 != null)
		{
			throw new Exception("Only one <nwCell> element can be added.");
		}
		class1938_12 = new Class1938();
		return class1938_12;
	}

	private void method_30(Class1938 _nwCell)
	{
		class1938_12 = _nwCell;
	}

	private Class1885 method_31()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_32(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
