using System.Xml;

namespace ns56;

internal class Class1553 : Class1351
{
	public delegate Class1553 Delegate538();

	public delegate void Delegate539(Class1553 elementData);

	public delegate void Delegate540(Class1553 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	private string string_0;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	public string Sqref
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

	public bool EvalError
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public bool TwoDigitTextYear
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool NumberStoredAsText
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

	public bool Formula
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

	public bool FormulaRange
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

	public bool UnlockedFormula
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

	public bool EmptyCellReference
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

	public bool ListDataValidation
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

	public bool CalculatedColumn
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
				case "sqref":
					string_0 = reader.Value;
					break;
				case "evalError":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "twoDigitTextYear":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "numberStoredAsText":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "formula":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "formulaRange":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "unlockedFormula":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "emptyCellReference":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "listDataValidation":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "calculatedColumn":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1553(XmlReader reader)
		: base(reader)
	{
	}

	public Class1553()
	{
	}

	protected override void vmethod_1()
	{
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		bool_14 = false;
		bool_15 = false;
		bool_16 = false;
		bool_17 = false;
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
		writer.WriteAttributeString("sqref", string_0);
		if (bool_9)
		{
			writer.WriteAttributeString("evalError", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("twoDigitTextYear", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("numberStoredAsText", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("formula", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("formulaRange", bool_13 ? "1" : "0");
		}
		if (bool_14)
		{
			writer.WriteAttributeString("unlockedFormula", bool_14 ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("emptyCellReference", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("listDataValidation", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("calculatedColumn", bool_17 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
