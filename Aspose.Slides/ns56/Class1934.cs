using System;
using System.Xml;

namespace ns56;

internal class Class1934 : Class1351
{
	public delegate Class1934 Delegate1669();

	public delegate void Delegate1670(Class1934 elementData);

	public delegate void Delegate1671(Class1934 elementData);

	public const int int_0 = 1;

	public const int int_1 = 1;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public Class1946.Delegate1705 delegate1705_0;

	public Class1946.Delegate1707 delegate1707_0;

	public Class1935.Delegate1672 delegate1672_0;

	public Class1935.Delegate1674 delegate1674_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private int int_2;

	private int int_3;

	private bool bool_2;

	private bool bool_3;

	private Class1946 class1946_0;

	private Class1935 class1935_0;

	private Class1886 class1886_0;

	public int RowSpan
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int GridSpan
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public bool HMerge
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool VMerge
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class1946 TxBody => class1946_0;

	public Class1935 TcPr => class1935_0;

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
				case "extLst":
					class1886_0 = new Class1886(reader);
					break;
				case "tcPr":
					class1935_0 = new Class1935(reader);
					break;
				case "txBody":
					class1946_0 = new Class1946(reader);
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
				case "vMerge":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hMerge":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "gridSpan":
					int_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "rowSpan":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1934(XmlReader reader)
		: base(reader)
	{
	}

	public Class1934()
	{
	}

	protected override void vmethod_1()
	{
		int_2 = 1;
		int_3 = 1;
		bool_2 = false;
		bool_3 = false;
	}

	protected override void vmethod_2()
	{
		delegate1705_0 = method_3;
		delegate1707_0 = method_4;
		delegate1672_0 = method_5;
		delegate1674_0 = method_6;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (int_2 != 1)
		{
			writer.WriteAttributeString("rowSpan", XmlConvert.ToString(int_2));
		}
		if (int_3 != 1)
		{
			writer.WriteAttributeString("gridSpan", XmlConvert.ToString(int_3));
		}
		if (bool_2)
		{
			writer.WriteAttributeString("hMerge", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("vMerge", bool_3 ? "1" : "0");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("a", writer, "txBody");
		}
		if (class1935_0 != null)
		{
			class1935_0.vmethod_4("a", writer, "tcPr");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1946 method_3()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <txBody> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_4(Class1946 _txBody)
	{
		class1946_0 = _txBody;
	}

	private Class1935 method_5()
	{
		if (class1935_0 != null)
		{
			throw new Exception("Only one <tcPr> element can be added.");
		}
		class1935_0 = new Class1935();
		return class1935_0;
	}

	private void method_6(Class1935 _tcPr)
	{
		class1935_0 = _tcPr;
	}

	private Class1885 method_7()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_8(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
