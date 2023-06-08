using System;
using System.Xml;

namespace ns56;

internal class Class1866 : Class1351
{
	public delegate Class1866 Delegate1477();

	public delegate void Delegate1479(Class1866 elementData);

	public delegate void Delegate1478(Class1866 elementData);

	public const double double_0 = 0.0;

	public const double double_1 = 0.0;

	public const float float_0 = 0f;

	public Class2605.Delegate2773 delegate2773_0;

	private double double_2;

	private double double_3;

	private float float_1;

	private Class2605 class2605_0;

	public double BlurRad
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double Dist
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public float Dir
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

	public Class2605 Color
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
				case "scrgbClr":
					class2605_0 = new Class2605("scrgbClr", new Class1918(reader));
					break;
				case "srgbClr":
					class2605_0 = new Class2605("srgbClr", new Class1926(reader));
					break;
				case "hslClr":
					class2605_0 = new Class2605("hslClr", new Class1863(reader));
					break;
				case "sysClr":
					class2605_0 = new Class2605("sysClr", new Class1931(reader));
					break;
				case "schemeClr":
					class2605_0 = new Class2605("schemeClr", new Class1917(reader));
					break;
				case "prstClr":
					class2605_0 = new Class2605("prstClr", new Class1907(reader));
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
				case "dir":
					float_1 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "dist":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "blurRad":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1866(XmlReader reader)
		: base(reader)
	{
	}

	public Class1866()
	{
	}

	protected override void vmethod_1()
	{
		double_2 = 0.0;
		double_3 = 0.0;
		float_1 = 0f;
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (double_2 != 0.0)
		{
			writer.WriteAttributeString("blurRad", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		}
		if (double_3 != 0.0)
		{
			writer.WriteAttributeString("dist", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		if (float_1 != 0f)
		{
			writer.WriteAttributeString("dir", XmlConvert.ToString((int)Math.Round(float_1 * 60000f)));
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "scrgbClr":
				((Class1918)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "srgbClr":
				((Class1926)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "hslClr":
				((Class1863)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "sysClr":
				((Class1931)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "schemeClr":
				((Class1917)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "prstClr":
				((Class1907)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Color already is initialized.");
		}
		switch (elementName)
		{
		case "scrgbClr":
			class2605_0 = new Class2605("scrgbClr", new Class1918());
			break;
		case "srgbClr":
			class2605_0 = new Class2605("srgbClr", new Class1926());
			break;
		case "hslClr":
			class2605_0 = new Class2605("hslClr", new Class1863());
			break;
		case "sysClr":
			class2605_0 = new Class2605("sysClr", new Class1931());
			break;
		case "schemeClr":
			class2605_0 = new Class2605("schemeClr", new Class1917());
			break;
		case "prstClr":
			class2605_0 = new Class2605("prstClr", new Class1907());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
