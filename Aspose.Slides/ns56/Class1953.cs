using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1953 : Class1351
{
	public delegate void Delegate1728(Class1953 elementData);

	public delegate Class1953 Delegate1726();

	public delegate void Delegate1727(Class1953 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const float float_0 = float.NaN;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const TextUnderlineType textUnderlineType_0 = TextUnderlineType.NotDefined;

	public const TextStrikethroughType textStrikethroughType_0 = TextStrikethroughType.NotDefined;

	public const float float_1 = float.NaN;

	public const TextCapType textCapType_0 = TextCapType.NotDefined;

	public const float float_2 = float.NaN;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	public const float float_3 = float.NaN;

	public const NullableBool nullableBool_4 = NullableBool.NotDefined;

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = true;

	public const uint uint_0 = 0u;

	public Class1875.Delegate1504 delegate1504_0;

	public Class1875.Delegate1506 delegate1506_0;

	public Class1814.Delegate1321 delegate1321_0;

	public Class1814.Delegate1323 delegate1323_0;

	public Class1956.Delegate1735 delegate1735_0;

	public Class1956.Delegate1737 delegate1737_0;

	public Class1956.Delegate1735 delegate1735_1;

	public Class1956.Delegate1737 delegate1737_1;

	public Class1956.Delegate1735 delegate1735_2;

	public Class1956.Delegate1737 delegate1737_2;

	public Class1956.Delegate1735 delegate1735_3;

	public Class1956.Delegate1737 delegate1737_3;

	public Class1865.Delegate1474 delegate1474_0;

	public Class1865.Delegate1476 delegate1476_0;

	public Class1865.Delegate1474 delegate1474_1;

	public Class1865.Delegate1476 delegate1476_1;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	public Class2605.Delegate2773 delegate2773_2;

	public Class2605.Delegate2773 delegate2773_3;

	private NullableBool nullableBool_5;

	private string string_0;

	private string string_1;

	private float float_4;

	private NullableBool nullableBool_6;

	private NullableBool nullableBool_7;

	private TextUnderlineType textUnderlineType_1;

	private TextStrikethroughType textStrikethroughType_1;

	private float float_5;

	private TextCapType textCapType_1;

	private float float_6;

	private NullableBool nullableBool_8;

	private float float_7;

	private NullableBool nullableBool_9;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private uint uint_1;

	private string string_2;

	private Class1875 class1875_0;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

	private Class1814 class1814_0;

	private Class2605 class2605_2;

	private Class2605 class2605_3;

	private Class1956 class1956_0;

	private Class1956 class1956_1;

	private Class1956 class1956_2;

	private Class1956 class1956_3;

	private Class1865 class1865_0;

	private Class1865 class1865_1;

	private Class1886 class1886_0;

	public NullableBool Kumimoji
	{
		get
		{
			return nullableBool_5;
		}
		set
		{
			nullableBool_5 = value;
		}
	}

	public string Lang
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

	public string AltLang
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

	public float Sz
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public NullableBool B
	{
		get
		{
			return nullableBool_6;
		}
		set
		{
			nullableBool_6 = value;
		}
	}

	public NullableBool I
	{
		get
		{
			return nullableBool_7;
		}
		set
		{
			nullableBool_7 = value;
		}
	}

	public TextUnderlineType U
	{
		get
		{
			return textUnderlineType_1;
		}
		set
		{
			textUnderlineType_1 = value;
		}
	}

	public TextStrikethroughType Strike
	{
		get
		{
			return textStrikethroughType_1;
		}
		set
		{
			textStrikethroughType_1 = value;
		}
	}

	public float Kern
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	public TextCapType Cap
	{
		get
		{
			return textCapType_1;
		}
		set
		{
			textCapType_1 = value;
		}
	}

	public float Spc
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	public NullableBool NormalizeH
	{
		get
		{
			return nullableBool_8;
		}
		set
		{
			nullableBool_8 = value;
		}
	}

	public float Baseline
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	public NullableBool NoProof
	{
		get
		{
			return nullableBool_9;
		}
		set
		{
			nullableBool_9 = value;
		}
	}

	public bool Dirty
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

	public bool Err
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool SmtClean
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public uint SmtId
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

	public string Bmk
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

	public Class1875 Ln => class1875_0;

	public Class2605 FillProperties
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
		}
	}

	public Class2605 EffectProperties
	{
		get
		{
			return class2605_1;
		}
		set
		{
			class2605_1 = value;
		}
	}

	public Class1814 Highlight => class1814_0;

	public Class2605 TextUnderlineLine
	{
		get
		{
			return class2605_2;
		}
		set
		{
			class2605_2 = value;
		}
	}

	public Class2605 TextUnderlineFill
	{
		get
		{
			return class2605_3;
		}
		set
		{
			class2605_3 = value;
		}
	}

	public Class1956 Latin => class1956_0;

	public Class1956 Ea => class1956_1;

	public Class1956 Cs => class1956_2;

	public Class1956 Sym => class1956_3;

	public Class1865 HlinkClick => class1865_0;

	public Class1865 HlinkMouseOver => class1865_1;

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
				case "ln":
					class1875_0 = new Class1875(reader);
					break;
				case "noFill":
					class2605_0 = new Class2605("noFill", new Class1878(reader));
					break;
				case "solidFill":
					class2605_0 = new Class2605("solidFill", new Class1924(reader));
					break;
				case "gradFill":
					class2605_0 = new Class2605("gradFill", new Class1853(reader));
					break;
				case "blipFill":
					class2605_0 = new Class2605("blipFill", new Class1810(reader));
					break;
				case "pattFill":
					class2605_0 = new Class2605("pattFill", new Class1900(reader));
					break;
				case "grpFill":
					class2605_0 = new Class2605("grpFill", new Class1859(reader));
					break;
				case "effectLst":
					class2605_1 = new Class2605("effectLst", new Class1833(reader));
					break;
				case "effectDag":
					class2605_1 = new Class2605("effectDag", new Class1832(reader));
					break;
				case "highlight":
					class1814_0 = new Class1814(reader);
					break;
				case "uLnTx":
					class2605_2 = new Class2605("uLnTx", new Class1972(reader));
					break;
				case "uLn":
					class2605_2 = new Class2605("uLn", new Class1875(reader));
					break;
				case "uFillTx":
					class2605_3 = new Class2605("uFillTx", new Class1970(reader));
					break;
				case "uFill":
					class2605_3 = new Class2605("uFill", new Class1971(reader));
					break;
				case "latin":
					class1956_0 = new Class1956(reader);
					break;
				case "ea":
					class1956_1 = new Class1956(reader);
					break;
				case "cs":
					class1956_2 = new Class1956(reader);
					break;
				case "sym":
					class1956_3 = new Class1956(reader);
					break;
				case "hlinkClick":
					class1865_0 = new Class1865(reader);
					break;
				case "hlinkMouseOver":
					class1865_1 = new Class1865(reader);
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
				case "kumimoji":
					nullableBool_5 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "lang":
					string_0 = reader.Value;
					break;
				case "altLang":
					string_1 = reader.Value;
					break;
				case "sz":
					float_4 = (float)XmlConvert.ToInt32(reader.Value) / 100f;
					break;
				case "b":
					nullableBool_6 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "i":
					nullableBool_7 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "u":
					textUnderlineType_1 = Class2572.smethod_0(reader.Value);
					break;
				case "strike":
					textStrikethroughType_1 = Class2570.smethod_0(reader.Value);
					break;
				case "kern":
					float_5 = (float)XmlConvert.ToInt32(reader.Value) / 100f;
					break;
				case "cap":
					textCapType_1 = Class2566.smethod_0(reader.Value);
					break;
				case "spc":
					float_6 = (float)XmlConvert.ToInt32(reader.Value) / 100f;
					break;
				case "normalizeH":
					nullableBool_8 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "baseline":
					float_7 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "noProof":
					nullableBool_9 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "dirty":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "err":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "smtClean":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "smtId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "bmk":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1953(XmlReader reader)
		: base(reader)
	{
	}

	public Class1953()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_5 = NullableBool.NotDefined;
		float_4 = float.NaN;
		nullableBool_6 = NullableBool.NotDefined;
		nullableBool_7 = NullableBool.NotDefined;
		textUnderlineType_1 = TextUnderlineType.NotDefined;
		textStrikethroughType_1 = TextStrikethroughType.NotDefined;
		float_5 = float.NaN;
		textCapType_1 = TextCapType.NotDefined;
		float_6 = float.NaN;
		nullableBool_8 = NullableBool.NotDefined;
		float_7 = float.NaN;
		nullableBool_9 = NullableBool.NotDefined;
		bool_3 = true;
		bool_4 = false;
		bool_5 = true;
		uint_1 = 0u;
	}

	protected override void vmethod_2()
	{
		delegate1504_0 = method_3;
		delegate1506_0 = method_4;
		delegate2773_1 = method_22;
		delegate2773_0 = method_21;
		delegate1321_0 = method_5;
		delegate1323_0 = method_6;
		delegate2773_3 = method_24;
		delegate2773_2 = method_23;
		delegate1735_0 = method_7;
		delegate1737_0 = method_8;
		delegate1735_1 = method_9;
		delegate1737_1 = method_10;
		delegate1735_2 = method_11;
		delegate1737_2 = method_12;
		delegate1735_3 = method_13;
		delegate1737_3 = method_14;
		delegate1474_0 = method_15;
		delegate1476_0 = method_16;
		delegate1474_1 = method_17;
		delegate1476_1 = method_18;
		delegate1534_0 = method_19;
		delegate1535_0 = method_20;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (nullableBool_5 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("kumimoji", (nullableBool_5 == NullableBool.True) ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("lang", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("altLang", string_1);
		}
		if (!float.IsNaN(float_4))
		{
			writer.WriteAttributeString("sz", XmlConvert.ToString((int)Math.Round(float_4 * 100f)));
		}
		if (nullableBool_6 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("b", (nullableBool_6 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_7 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("i", (nullableBool_7 == NullableBool.True) ? "1" : "0");
		}
		if (textUnderlineType_1 != TextUnderlineType.NotDefined)
		{
			writer.WriteAttributeString("u", Class2572.smethod_1(textUnderlineType_1));
		}
		if (textStrikethroughType_1 != TextStrikethroughType.NotDefined)
		{
			writer.WriteAttributeString("strike", Class2570.smethod_1(textStrikethroughType_1));
		}
		if (!float.IsNaN(float_5))
		{
			writer.WriteAttributeString("kern", XmlConvert.ToString((int)Math.Round(float_5 * 100f)));
		}
		if (textCapType_1 != TextCapType.NotDefined)
		{
			writer.WriteAttributeString("cap", Class2566.smethod_1(textCapType_1));
		}
		if (!float.IsNaN(float_6))
		{
			writer.WriteAttributeString("spc", XmlConvert.ToString((int)Math.Round(float_6 * 100f)));
		}
		if (nullableBool_8 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("normalizeH", (nullableBool_8 == NullableBool.True) ? "1" : "0");
		}
		if (!float.IsNaN(float_7))
		{
			writer.WriteAttributeString("baseline", XmlConvert.ToString((int)Math.Round(float_7 * 1000f)));
		}
		if (nullableBool_9 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("noProof", (nullableBool_9 == NullableBool.True) ? "1" : "0");
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("dirty", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("err", bool_4 ? "1" : "0");
		}
		if (!bool_5)
		{
			writer.WriteAttributeString("smtClean", bool_5 ? "1" : "0");
		}
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("smtId", XmlConvert.ToString(uint_1));
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("bmk", string_2);
		}
		if (class1875_0 != null)
		{
			class1875_0.vmethod_4("a", writer, "ln");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "noFill":
				((Class1878)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "solidFill":
				((Class1924)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "gradFill":
				((Class1853)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "blipFill":
				((Class1810)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "pattFill":
				((Class1900)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "grpFill":
				((Class1859)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "effectDag":
				((Class1832)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "effectLst":
				((Class1833)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		if (class1814_0 != null)
		{
			class1814_0.vmethod_4("a", writer, "highlight");
		}
		if (class2605_2 != null)
		{
			switch (class2605_2.Name)
			{
			case "uLn":
				((Class1875)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			case "uLnTx":
				((Class1972)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			}
		}
		if (class2605_3 != null)
		{
			switch (class2605_3.Name)
			{
			case "uFill":
				((Class1971)class2605_3.Object).vmethod_4("a", writer, class2605_3.Name);
				break;
			case "uFillTx":
				((Class1970)class2605_3.Object).vmethod_4("a", writer, class2605_3.Name);
				break;
			}
		}
		if (class1956_0 != null)
		{
			class1956_0.vmethod_4("a", writer, "latin");
		}
		if (class1956_1 != null)
		{
			class1956_1.vmethod_4("a", writer, "ea");
		}
		if (class1956_2 != null)
		{
			class1956_2.vmethod_4("a", writer, "cs");
		}
		if (class1956_3 != null)
		{
			class1956_3.vmethod_4("a", writer, "sym");
		}
		if (class1865_0 != null)
		{
			class1865_0.vmethod_4("a", writer, "hlinkClick");
		}
		if (class1865_1 != null)
		{
			class1865_1.vmethod_4("a", writer, "hlinkMouseOver");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1875 method_3()
	{
		if (class1875_0 != null)
		{
			throw new Exception("Only one <ln> element can be added.");
		}
		class1875_0 = new Class1875();
		return class1875_0;
	}

	private void method_4(Class1875 _ln)
	{
		class1875_0 = _ln;
	}

	private Class1814 method_5()
	{
		if (class1814_0 != null)
		{
			throw new Exception("Only one <highlight> element can be added.");
		}
		class1814_0 = new Class1814();
		return class1814_0;
	}

	private void method_6(Class1814 _highlight)
	{
		class1814_0 = _highlight;
	}

	private Class1956 method_7()
	{
		if (class1956_0 != null)
		{
			throw new Exception("Only one <latin> element can be added.");
		}
		class1956_0 = new Class1956();
		return class1956_0;
	}

	private void method_8(Class1956 _latin)
	{
		class1956_0 = _latin;
	}

	private Class1956 method_9()
	{
		if (class1956_1 != null)
		{
			throw new Exception("Only one <ea> element can be added.");
		}
		class1956_1 = new Class1956();
		return class1956_1;
	}

	private void method_10(Class1956 _ea)
	{
		class1956_1 = _ea;
	}

	private Class1956 method_11()
	{
		if (class1956_2 != null)
		{
			throw new Exception("Only one <cs> element can be added.");
		}
		class1956_2 = new Class1956();
		return class1956_2;
	}

	private void method_12(Class1956 _cs)
	{
		class1956_2 = _cs;
	}

	private Class1956 method_13()
	{
		if (class1956_3 != null)
		{
			throw new Exception("Only one <sym> element can be added.");
		}
		class1956_3 = new Class1956();
		return class1956_3;
	}

	private void method_14(Class1956 _sym)
	{
		class1956_3 = _sym;
	}

	private Class1865 method_15()
	{
		if (class1865_0 != null)
		{
			throw new Exception("Only one <hlinkClick> element can be added.");
		}
		class1865_0 = new Class1865();
		return class1865_0;
	}

	private void method_16(Class1865 _hlinkClick)
	{
		class1865_0 = _hlinkClick;
	}

	private Class1865 method_17()
	{
		if (class1865_1 != null)
		{
			throw new Exception("Only one <hlinkMouseOver> element can be added.");
		}
		class1865_1 = new Class1865();
		return class1865_1;
	}

	private void method_18(Class1865 _hlinkMouseOver)
	{
		class1865_1 = _hlinkMouseOver;
	}

	private Class1885 method_19()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_20(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}

	private Class2605 method_21(string elementName)
	{
		if (class2605_1 != null)
		{
			throw new Exception("EffectProperties already is initialized.");
		}
		switch (elementName)
		{
		case "effectDag":
			class2605_1 = new Class2605("effectDag", new Class1832());
			break;
		case "effectLst":
			class2605_1 = new Class2605("effectLst", new Class1833());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_1;
	}

	private Class2605 method_22(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("FillProperties already is initialized.");
		}
		switch (elementName)
		{
		case "noFill":
			class2605_0 = new Class2605("noFill", new Class1878());
			break;
		case "solidFill":
			class2605_0 = new Class2605("solidFill", new Class1924());
			break;
		case "gradFill":
			class2605_0 = new Class2605("gradFill", new Class1853());
			break;
		case "blipFill":
			class2605_0 = new Class2605("blipFill", new Class1810());
			break;
		case "pattFill":
			class2605_0 = new Class2605("pattFill", new Class1900());
			break;
		case "grpFill":
			class2605_0 = new Class2605("grpFill", new Class1859());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}

	private Class2605 method_23(string elementName)
	{
		if (class2605_3 != null)
		{
			throw new Exception("TextUnderlineFill already is initialized.");
		}
		switch (elementName)
		{
		case "uFill":
			class2605_3 = new Class2605("uFill", new Class1971());
			break;
		case "uFillTx":
			class2605_3 = new Class2605("uFillTx", new Class1970());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_3;
	}

	private Class2605 method_24(string elementName)
	{
		if (class2605_2 != null)
		{
			throw new Exception("TextUnderlineLine already is initialized.");
		}
		switch (elementName)
		{
		case "uLn":
			class2605_2 = new Class2605("uLn", new Class1875());
			break;
		case "uLnTx":
			class2605_2 = new Class2605("uLnTx", new Class1972());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_2;
	}
}
