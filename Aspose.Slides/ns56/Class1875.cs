using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1875 : Class1351
{
	public delegate Class1875 Delegate1504();

	public delegate void Delegate1506(Class1875 elementData);

	public delegate void Delegate1505(Class1875 elementData);

	public const double double_0 = double.NaN;

	public const LineCapStyle lineCapStyle_0 = LineCapStyle.NotDefined;

	public const LineStyle lineStyle_0 = LineStyle.NotDefined;

	public const LineAlignment lineAlignment_0 = LineAlignment.NotDefined;

	public Class1871.Delegate1492 delegate1492_0;

	public Class1871.Delegate1494 delegate1494_0;

	public Class1871.Delegate1492 delegate1492_1;

	public Class1871.Delegate1494 delegate1494_1;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	public Class2605.Delegate2773 delegate2773_2;

	private double double_1;

	private LineCapStyle lineCapStyle_1;

	private LineStyle lineStyle_1;

	private LineAlignment lineAlignment_1;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

	private Class2605 class2605_2;

	private Class1871 class1871_0;

	private Class1871 class1871_1;

	private Class1886 class1886_0;

	public double W
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public LineCapStyle Cap
	{
		get
		{
			return lineCapStyle_1;
		}
		set
		{
			lineCapStyle_1 = value;
		}
	}

	public LineStyle Cmpd
	{
		get
		{
			return lineStyle_1;
		}
		set
		{
			lineStyle_1 = value;
		}
	}

	public LineAlignment Algn
	{
		get
		{
			return lineAlignment_1;
		}
		set
		{
			lineAlignment_1 = value;
		}
	}

	public Class2605 LineFillProperties
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

	public Class2605 LineDashProperties
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

	public Class2605 LineJoinProperties
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

	public Class1871 HeadEnd => class1871_0;

	public Class1871 TailEnd => class1871_1;

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
				case "noFill":
					class2605_0 = new Class2605("noFill", new Class1878(reader));
					break;
				case "solidFill":
					class2605_0 = new Class2605("solidFill", new Class1924(reader));
					break;
				case "gradFill":
					class2605_0 = new Class2605("gradFill", new Class1853(reader));
					break;
				case "pattFill":
					class2605_0 = new Class2605("pattFill", new Class1900(reader));
					break;
				case "prstDash":
					class2605_1 = new Class2605("prstDash", new Class1909(reader));
					break;
				case "custDash":
					class2605_1 = new Class2605("custDash", new Class1830(reader));
					break;
				case "round":
					class2605_2 = new Class2605("round", new Class1874(reader));
					break;
				case "bevel":
					class2605_2 = new Class2605("bevel", new Class1872(reader));
					break;
				case "miter":
					class2605_2 = new Class2605("miter", new Class1873(reader));
					break;
				case "headEnd":
					class1871_0 = new Class1871(reader);
					break;
				case "tailEnd":
					class1871_1 = new Class1871(reader);
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
				case "algn":
					lineAlignment_1 = Class2542.smethod_0(reader.Value);
					break;
				case "cmpd":
					lineStyle_1 = Class2522.smethod_0(reader.Value);
					break;
				case "cap":
					lineCapStyle_1 = Class2535.smethod_0(reader.Value);
					break;
				case "w":
					double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1875(XmlReader reader)
		: base(reader)
	{
	}

	public Class1875()
	{
	}

	protected override void vmethod_1()
	{
		double_1 = double.NaN;
		lineCapStyle_1 = LineCapStyle.NotDefined;
		lineStyle_1 = LineStyle.NotDefined;
		lineAlignment_1 = LineAlignment.NotDefined;
	}

	protected override void vmethod_2()
	{
		delegate2773_1 = method_10;
		delegate2773_0 = method_9;
		delegate2773_2 = method_11;
		delegate1492_0 = method_3;
		delegate1494_0 = method_4;
		delegate1492_1 = method_5;
		delegate1494_1 = method_6;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!double.IsNaN(double_1))
		{
			writer.WriteAttributeString("w", XmlConvert.ToString((long)Math.Round(double_1 * 12700.0)));
		}
		if (lineCapStyle_1 != LineCapStyle.NotDefined)
		{
			writer.WriteAttributeString("cap", Class2535.smethod_1(lineCapStyle_1));
		}
		if (lineStyle_1 != LineStyle.NotDefined)
		{
			writer.WriteAttributeString("cmpd", Class2522.smethod_1(lineStyle_1));
		}
		if (lineAlignment_1 != LineAlignment.NotDefined)
		{
			writer.WriteAttributeString("algn", Class2542.smethod_1(lineAlignment_1));
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "pattFill":
				((Class1900)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "gradFill":
				((Class1853)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "solidFill":
				((Class1924)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "noFill":
				((Class1878)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "custDash":
				((Class1830)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "prstDash":
				((Class1909)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		if (class2605_2 != null)
		{
			switch (class2605_2.Name)
			{
			case "miter":
				((Class1873)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			case "bevel":
				((Class1872)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			case "round":
				((Class1874)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			}
		}
		if (class1871_0 != null)
		{
			class1871_0.vmethod_4("a", writer, "headEnd");
		}
		if (class1871_1 != null)
		{
			class1871_1.vmethod_4("a", writer, "tailEnd");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1871 method_3()
	{
		if (class1871_0 != null)
		{
			throw new Exception("Only one <headEnd> element can be added.");
		}
		class1871_0 = new Class1871();
		return class1871_0;
	}

	private void method_4(Class1871 _headEnd)
	{
		class1871_0 = _headEnd;
	}

	private Class1871 method_5()
	{
		if (class1871_1 != null)
		{
			throw new Exception("Only one <tailEnd> element can be added.");
		}
		class1871_1 = new Class1871();
		return class1871_1;
	}

	private void method_6(Class1871 _tailEnd)
	{
		class1871_1 = _tailEnd;
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
			throw new Exception("LineDashProperties already is initialized.");
		}
		switch (elementName)
		{
		case "custDash":
			class2605_1 = new Class2605("custDash", new Class1830());
			break;
		case "prstDash":
			class2605_1 = new Class2605("prstDash", new Class1909());
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
			throw new Exception("LineFillProperties already is initialized.");
		}
		switch (elementName)
		{
		case "pattFill":
			class2605_0 = new Class2605("pattFill", new Class1900());
			break;
		case "gradFill":
			class2605_0 = new Class2605("gradFill", new Class1853());
			break;
		case "solidFill":
			class2605_0 = new Class2605("solidFill", new Class1924());
			break;
		case "noFill":
			class2605_0 = new Class2605("noFill", new Class1878());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}

	private Class2605 method_11(string elementName)
	{
		if (class2605_2 != null)
		{
			throw new Exception("LineJoinProperties already is initialized.");
		}
		switch (elementName)
		{
		case "miter":
			class2605_2 = new Class2605("miter", new Class1873());
			break;
		case "bevel":
			class2605_2 = new Class2605("bevel", new Class1872());
			break;
		case "round":
			class2605_2 = new Class2605("round", new Class1874());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_2;
	}
}
