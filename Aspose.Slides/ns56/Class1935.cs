using System;
using System.Xml;
using Aspose.Slides;
using ns16;

namespace ns56;

internal class Class1935 : Class1351
{
	public delegate Class1935 Delegate1672();

	public delegate void Delegate1674(Class1935 elementData);

	public delegate void Delegate1673(Class1935 elementData);

	public const double double_0 = 7.2;

	public const double double_1 = 7.2;

	public const double double_2 = 3.6;

	public const double double_3 = 3.6;

	public const bool bool_0 = false;

	public Class1875.Delegate1504 delegate1504_0;

	public Class1875.Delegate1506 delegate1506_0;

	public Class1875.Delegate1504 delegate1504_1;

	public Class1875.Delegate1506 delegate1506_1;

	public Class1875.Delegate1504 delegate1504_2;

	public Class1875.Delegate1506 delegate1506_2;

	public Class1875.Delegate1504 delegate1504_3;

	public Class1875.Delegate1506 delegate1506_3;

	public Class1875.Delegate1504 delegate1504_4;

	public Class1875.Delegate1506 delegate1506_4;

	public Class1875.Delegate1504 delegate1504_5;

	public Class1875.Delegate1506 delegate1506_5;

	public Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	private TextVerticalType textVerticalType_0;

	private TextAnchorType textAnchorType_0;

	private bool bool_1;

	private Enum378 enum378_0;

	private Class1875 class1875_0;

	private Class1875 class1875_1;

	private Class1875 class1875_2;

	private Class1875 class1875_3;

	private Class1875 class1875_4;

	private Class1875 class1875_5;

	private Class1456 class1456_0;

	private Class2605 class2605_0;

	private Class1886 class1886_0;

	public static readonly TextVerticalType textVerticalType_1 = Class2573.smethod_0("horz");

	public static readonly TextAnchorType textAnchorType_1 = Class2564.smethod_0("t");

	public static readonly Enum378 enum378_1 = Class2568.smethod_0("clip");

	public double MarL
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double MarR
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

	public double MarT
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

	public double MarB
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

	public TextVerticalType Vert
	{
		get
		{
			return textVerticalType_0;
		}
		set
		{
			textVerticalType_0 = value;
		}
	}

	public TextAnchorType Anchor
	{
		get
		{
			return textAnchorType_0;
		}
		set
		{
			textAnchorType_0 = value;
		}
	}

	public bool AnchorCtr
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

	public Enum378 HorzOverflow
	{
		get
		{
			return enum378_0;
		}
		set
		{
			enum378_0 = value;
		}
	}

	public Class1875 LnL => class1875_0;

	public Class1875 LnR => class1875_1;

	public Class1875 LnT => class1875_2;

	public Class1875 LnB => class1875_3;

	public Class1875 LnTlToBr => class1875_4;

	public Class1875 LnBlToTr => class1875_5;

	public Class1456 Cell3D => class1456_0;

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
				case "lnL":
					class1875_0 = new Class1875(reader);
					break;
				case "lnR":
					class1875_1 = new Class1875(reader);
					break;
				case "lnT":
					class1875_2 = new Class1875(reader);
					break;
				case "lnB":
					class1875_3 = new Class1875(reader);
					break;
				case "lnTlToBr":
					class1875_4 = new Class1875(reader);
					break;
				case "lnBlToTr":
					class1875_5 = new Class1875(reader);
					break;
				case "cell3D":
					class1456_0 = new Class1456(reader);
					flag = true;
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
				case "marL":
					double_4 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "marR":
					double_5 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "marT":
					double_6 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "marB":
					double_7 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "vert":
					textVerticalType_0 = Class2573.smethod_0(reader.Value);
					break;
				case "anchor":
					textAnchorType_0 = Class2564.smethod_0(reader.Value);
					break;
				case "anchorCtr":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "horzOverflow":
					enum378_0 = Class2568.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1935(XmlReader reader)
		: base(reader)
	{
	}

	public Class1935()
	{
	}

	protected override void vmethod_1()
	{
		double_4 = 7.2;
		double_5 = 7.2;
		double_6 = 3.6;
		double_7 = 3.6;
		textVerticalType_0 = textVerticalType_1;
		textAnchorType_0 = textAnchorType_1;
		bool_1 = false;
		enum378_0 = enum378_1;
	}

	protected override void vmethod_2()
	{
		delegate1504_0 = method_3;
		delegate1506_0 = method_4;
		delegate1504_1 = method_5;
		delegate1506_1 = method_6;
		delegate1504_2 = method_7;
		delegate1506_2 = method_8;
		delegate1504_3 = method_9;
		delegate1506_3 = method_10;
		delegate1504_4 = method_11;
		delegate1506_4 = method_12;
		delegate1504_5 = method_13;
		delegate1506_5 = method_14;
		delegate303_0 = method_15;
		delegate304_0 = method_16;
		delegate2773_0 = method_19;
		delegate1534_0 = method_17;
		delegate1535_0 = method_18;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (double_4 != 7.2)
		{
			writer.WriteAttributeString("marL", XmlConvert.ToString((long)Math.Round(double_4 * 12700.0)));
		}
		if (double_5 != 7.2)
		{
			writer.WriteAttributeString("marR", XmlConvert.ToString((long)Math.Round(double_5 * 12700.0)));
		}
		if (double_6 != 3.6)
		{
			writer.WriteAttributeString("marT", XmlConvert.ToString((long)Math.Round(double_6 * 12700.0)));
		}
		if (double_7 != 3.6)
		{
			writer.WriteAttributeString("marB", XmlConvert.ToString((long)Math.Round(double_7 * 12700.0)));
		}
		if (textVerticalType_0 != textVerticalType_1)
		{
			writer.WriteAttributeString("vert", Class2573.smethod_1(textVerticalType_0));
		}
		if (textAnchorType_0 != textAnchorType_1)
		{
			writer.WriteAttributeString("anchor", Class2564.smethod_1(textAnchorType_0));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("anchorCtr", bool_1 ? "1" : "0");
		}
		if (enum378_0 != enum378_1)
		{
			writer.WriteAttributeString("horzOverflow", Class2568.smethod_1(enum378_0));
		}
		if (class1875_0 != null)
		{
			class1875_0.vmethod_4("a", writer, "lnL");
		}
		if (class1875_1 != null)
		{
			class1875_1.vmethod_4("a", writer, "lnR");
		}
		if (class1875_2 != null)
		{
			class1875_2.vmethod_4("a", writer, "lnT");
		}
		if (class1875_3 != null)
		{
			class1875_3.vmethod_4("a", writer, "lnB");
		}
		if (class1875_4 != null)
		{
			class1875_4.vmethod_4("a", writer, "lnTlToBr");
		}
		if (class1875_5 != null)
		{
			class1875_5.vmethod_4("a", writer, "lnBlToTr");
		}
		if (class1456_0 != null)
		{
			class1456_0.vmethod_4("a", writer, "cell3D");
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
			throw new Exception("Only one <lnL> element can be added.");
		}
		class1875_0 = new Class1875();
		return class1875_0;
	}

	private void method_4(Class1875 _lnL)
	{
		class1875_0 = _lnL;
	}

	private Class1875 method_5()
	{
		if (class1875_1 != null)
		{
			throw new Exception("Only one <lnR> element can be added.");
		}
		class1875_1 = new Class1875();
		return class1875_1;
	}

	private void method_6(Class1875 _lnR)
	{
		class1875_1 = _lnR;
	}

	private Class1875 method_7()
	{
		if (class1875_2 != null)
		{
			throw new Exception("Only one <lnT> element can be added.");
		}
		class1875_2 = new Class1875();
		return class1875_2;
	}

	private void method_8(Class1875 _lnT)
	{
		class1875_2 = _lnT;
	}

	private Class1875 method_9()
	{
		if (class1875_3 != null)
		{
			throw new Exception("Only one <lnB> element can be added.");
		}
		class1875_3 = new Class1875();
		return class1875_3;
	}

	private void method_10(Class1875 _lnB)
	{
		class1875_3 = _lnB;
	}

	private Class1875 method_11()
	{
		if (class1875_4 != null)
		{
			throw new Exception("Only one <lnTlToBr> element can be added.");
		}
		class1875_4 = new Class1875();
		return class1875_4;
	}

	private void method_12(Class1875 _lnTlToBr)
	{
		class1875_4 = _lnTlToBr;
	}

	private Class1875 method_13()
	{
		if (class1875_5 != null)
		{
			throw new Exception("Only one <lnBlToTr> element can be added.");
		}
		class1875_5 = new Class1875();
		return class1875_5;
	}

	private void method_14(Class1875 _lnBlToTr)
	{
		class1875_5 = _lnBlToTr;
	}

	private Class1447 method_15()
	{
		if (class1456_0 != null)
		{
			throw new Exception("Only one <cell3D> element can be added.");
		}
		class1456_0 = new Class1456();
		return class1456_0;
	}

	private void method_16(Class1447 _cell3D)
	{
		class1456_0 = (Class1456)_cell3D;
	}

	private Class1885 method_17()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_18(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}

	private Class2605 method_19(string elementName)
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
}
