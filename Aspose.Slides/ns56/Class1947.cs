using System;
using System.Xml;
using Aspose.Slides;
using ns16;

namespace ns56;

internal class Class1947 : Class1351
{
	public delegate Class1947 Delegate1708();

	public delegate void Delegate1709(Class1947 elementData);

	public delegate void Delegate1710(Class1947 elementData);

	public const float float_0 = float.NaN;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const TextVerticalOverflowType textVerticalOverflowType_0 = TextVerticalOverflowType.NotDefined;

	public const Enum378 enum378_0 = Enum378.const_0;

	public const TextVerticalType textVerticalType_0 = TextVerticalType.NotDefined;

	public const Enum314 enum314_0 = Enum314.const_0;

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	public const double double_2 = double.NaN;

	public const double double_3 = double.NaN;

	public const int int_0 = 0;

	public const double double_4 = double.NaN;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const TextAnchorType textAnchorType_0 = TextAnchorType.NotDefined;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	public const NullableBool nullableBool_4 = NullableBool.NotDefined;

	public const bool bool_0 = false;

	public const NullableBool nullableBool_5 = NullableBool.NotDefined;

	public Class1911.Delegate1600 delegate1600_0;

	public Class1911.Delegate1602 delegate1602_0;

	public Class1916.Delegate1615 delegate1615_0;

	public Class1916.Delegate1617 delegate1617_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	private float float_1;

	private NullableBool nullableBool_6;

	private TextVerticalOverflowType textVerticalOverflowType_1;

	private Enum378 enum378_1;

	private TextVerticalType textVerticalType_1;

	private Enum314 enum314_1;

	private double double_5;

	private double double_6;

	private double double_7;

	private double double_8;

	private int int_1;

	private double double_9;

	private NullableBool nullableBool_7;

	private NullableBool nullableBool_8;

	private TextAnchorType textAnchorType_1;

	private NullableBool nullableBool_9;

	private NullableBool nullableBool_10;

	private bool bool_1;

	private NullableBool nullableBool_11;

	private Class1911 class1911_0;

	private Class2605 class2605_0;

	private Class1916 class1916_0;

	private Class2605 class2605_1;

	private Class1886 class1886_0;

	public float Rot
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public NullableBool SpcFirstLastPara
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

	public TextVerticalOverflowType VertOverflow
	{
		get
		{
			return textVerticalOverflowType_1;
		}
		set
		{
			textVerticalOverflowType_1 = value;
		}
	}

	public Enum378 HorzOverflow
	{
		get
		{
			return enum378_1;
		}
		set
		{
			enum378_1 = value;
		}
	}

	public TextVerticalType Vert
	{
		get
		{
			return textVerticalType_1;
		}
		set
		{
			textVerticalType_1 = value;
		}
	}

	public Enum314 Wrap
	{
		get
		{
			return enum314_1;
		}
		set
		{
			enum314_1 = value;
		}
	}

	public double LIns
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public double TIns
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = value;
		}
	}

	public double RIns
	{
		get
		{
			return double_7;
		}
		set
		{
			double_7 = value;
		}
	}

	public double BIns
	{
		get
		{
			return double_8;
		}
		set
		{
			double_8 = value;
		}
	}

	public int NumCol
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

	public double SpcCol
	{
		get
		{
			return double_9;
		}
		set
		{
			double_9 = value;
		}
	}

	public NullableBool RtlCol
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

	public NullableBool FromWordArt
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

	public TextAnchorType Anchor
	{
		get
		{
			return textAnchorType_1;
		}
		set
		{
			textAnchorType_1 = value;
		}
	}

	public NullableBool AnchorCtr
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

	public NullableBool ForceAA
	{
		get
		{
			return nullableBool_10;
		}
		set
		{
			nullableBool_10 = value;
		}
	}

	public bool Upright
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public NullableBool CompatLnSpc
	{
		get
		{
			return nullableBool_11;
		}
		set
		{
			nullableBool_11 = value;
		}
	}

	public Class1911 PrstTxWarp => class1911_0;

	public Class2605 TextAutofit
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

	public Class1916 Scene3d => class1916_0;

	public Class2605 Text3D
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
				case "prstTxWarp":
					class1911_0 = new Class1911(reader);
					break;
				case "noAutofit":
					class2605_0 = new Class2605("noAutofit", new Class1959(reader));
					break;
				case "normAutofit":
					class2605_0 = new Class2605("normAutofit", new Class1961(reader));
					break;
				case "spAutoFit":
					class2605_0 = new Class2605("spAutoFit", new Class1964(reader));
					break;
				case "scene3d":
					class1916_0 = new Class1916(reader);
					break;
				case "sp3d":
					class2605_1 = new Class2605("sp3d", new Class1919(reader));
					break;
				case "flatTx":
					class2605_1 = new Class2605("flatTx", new Class1844(reader));
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
				case "rot":
					float_1 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "spcFirstLastPara":
					nullableBool_6 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "vertOverflow":
					textVerticalOverflowType_1 = Class2574.smethod_0(reader.Value);
					break;
				case "horzOverflow":
					enum378_1 = Class2568.smethod_0(reader.Value);
					break;
				case "vert":
					textVerticalType_1 = Class2573.smethod_0(reader.Value);
					break;
				case "wrap":
					enum314_1 = Class2442.smethod_0(reader.Value);
					break;
				case "lIns":
					double_5 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "tIns":
					double_6 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "rIns":
					double_7 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "bIns":
					double_8 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "numCol":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "spcCol":
					double_9 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "rtlCol":
					nullableBool_7 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "fromWordArt":
					nullableBool_8 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "anchor":
					textAnchorType_1 = Class2564.smethod_0(reader.Value);
					break;
				case "anchorCtr":
					nullableBool_9 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "forceAA":
					nullableBool_10 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "upright":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "compatLnSpc":
					nullableBool_11 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1947(XmlReader reader)
		: base(reader)
	{
	}

	public Class1947()
	{
	}

	protected override void vmethod_1()
	{
		float_1 = float.NaN;
		nullableBool_6 = NullableBool.NotDefined;
		textVerticalOverflowType_1 = TextVerticalOverflowType.NotDefined;
		enum378_1 = Enum378.const_0;
		textVerticalType_1 = TextVerticalType.NotDefined;
		enum314_1 = Enum314.const_0;
		double_5 = double.NaN;
		double_6 = double.NaN;
		double_7 = double.NaN;
		double_8 = double.NaN;
		int_1 = 0;
		double_9 = double.NaN;
		nullableBool_7 = NullableBool.NotDefined;
		nullableBool_8 = NullableBool.NotDefined;
		textAnchorType_1 = TextAnchorType.NotDefined;
		nullableBool_9 = NullableBool.NotDefined;
		nullableBool_10 = NullableBool.NotDefined;
		bool_1 = false;
		nullableBool_11 = NullableBool.NotDefined;
	}

	protected override void vmethod_2()
	{
		delegate1600_0 = method_3;
		delegate1602_0 = method_4;
		delegate2773_1 = method_10;
		delegate1615_0 = method_5;
		delegate1617_0 = method_6;
		delegate2773_0 = method_9;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!float.IsNaN(float_1))
		{
			writer.WriteAttributeString("rot", XmlConvert.ToString((int)Math.Round(float_1 * 60000f)));
		}
		if (nullableBool_6 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("spcFirstLastPara", (nullableBool_6 == NullableBool.True) ? "1" : "0");
		}
		if (textVerticalOverflowType_1 != TextVerticalOverflowType.NotDefined)
		{
			writer.WriteAttributeString("vertOverflow", Class2574.smethod_1(textVerticalOverflowType_1));
		}
		if (enum378_1 != Enum378.const_0)
		{
			writer.WriteAttributeString("horzOverflow", Class2568.smethod_1(enum378_1));
		}
		if (textVerticalType_1 != TextVerticalType.NotDefined)
		{
			writer.WriteAttributeString("vert", Class2573.smethod_1(textVerticalType_1));
		}
		if (enum314_1 != 0)
		{
			writer.WriteAttributeString("wrap", Class2442.smethod_1(enum314_1));
		}
		if (!double.IsNaN(double_5))
		{
			writer.WriteAttributeString("lIns", XmlConvert.ToString((long)Math.Round(double_5 * 12700.0)));
		}
		if (!double.IsNaN(double_6))
		{
			writer.WriteAttributeString("tIns", XmlConvert.ToString((long)Math.Round(double_6 * 12700.0)));
		}
		if (!double.IsNaN(double_7))
		{
			writer.WriteAttributeString("rIns", XmlConvert.ToString((long)Math.Round(double_7 * 12700.0)));
		}
		if (!double.IsNaN(double_8))
		{
			writer.WriteAttributeString("bIns", XmlConvert.ToString((long)Math.Round(double_8 * 12700.0)));
		}
		if (int_1 != 0)
		{
			writer.WriteAttributeString("numCol", XmlConvert.ToString(int_1));
		}
		if (!double.IsNaN(double_9))
		{
			writer.WriteAttributeString("spcCol", XmlConvert.ToString((long)Math.Round(double_9 * 12700.0)));
		}
		if (nullableBool_7 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("rtlCol", (nullableBool_7 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_8 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("fromWordArt", (nullableBool_8 == NullableBool.True) ? "1" : "0");
		}
		if (textAnchorType_1 != TextAnchorType.NotDefined)
		{
			writer.WriteAttributeString("anchor", Class2564.smethod_1(textAnchorType_1));
		}
		if (nullableBool_9 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("anchorCtr", (nullableBool_9 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_10 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("forceAA", (nullableBool_10 == NullableBool.True) ? "1" : "0");
		}
		if (bool_1)
		{
			writer.WriteAttributeString("upright", bool_1 ? "1" : "0");
		}
		if (nullableBool_11 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("compatLnSpc", (nullableBool_11 == NullableBool.True) ? "1" : "0");
		}
		if (class1911_0 != null)
		{
			class1911_0.vmethod_4("a", writer, "prstTxWarp");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "spAutoFit":
				((Class1964)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "normAutofit":
				((Class1961)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "noAutofit":
				((Class1959)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class1916_0 != null)
		{
			class1916_0.vmethod_4("a", writer, "scene3d");
		}
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "flatTx":
				((Class1844)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "sp3d":
				((Class1919)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1911 method_3()
	{
		if (class1911_0 != null)
		{
			throw new Exception("Only one <prstTxWarp> element can be added.");
		}
		class1911_0 = new Class1911();
		return class1911_0;
	}

	private void method_4(Class1911 _prstTxWarp)
	{
		class1911_0 = _prstTxWarp;
	}

	private Class1916 method_5()
	{
		if (class1916_0 != null)
		{
			throw new Exception("Only one <scene3d> element can be added.");
		}
		class1916_0 = new Class1916();
		return class1916_0;
	}

	private void method_6(Class1916 _scene3d)
	{
		class1916_0 = _scene3d;
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

	private Class2605 method_9(string elementName)
	{
		if (class2605_1 != null)
		{
			throw new Exception("Text3D already is initialized.");
		}
		switch (elementName)
		{
		case "flatTx":
			class2605_1 = new Class2605("flatTx", new Class1844());
			break;
		case "sp3d":
			class2605_1 = new Class2605("sp3d", new Class1919());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_1;
	}

	private Class2605 method_10(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("TextAutofit already is initialized.");
		}
		switch (elementName)
		{
		case "spAutoFit":
			class2605_0 = new Class2605("spAutoFit", new Class1964());
			break;
		case "normAutofit":
			class2605_0 = new Class2605("normAutofit", new Class1961());
			break;
		case "noAutofit":
			class2605_0 = new Class2605("noAutofit", new Class1959());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
