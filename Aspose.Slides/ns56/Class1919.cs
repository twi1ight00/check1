using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1919 : Class1351
{
	public delegate Class1919 Delegate1624();

	public delegate void Delegate1626(Class1919 elementData);

	public delegate void Delegate1625(Class1919 elementData);

	public const double double_0 = 0.0;

	public const double double_1 = 0.0;

	public const double double_2 = 0.0;

	public Class1806.Delegate1297 delegate1297_0;

	public Class1806.Delegate1299 delegate1299_0;

	public Class1806.Delegate1297 delegate1297_1;

	public Class1806.Delegate1299 delegate1299_1;

	public Class1814.Delegate1321 delegate1321_0;

	public Class1814.Delegate1323 delegate1323_0;

	public Class1814.Delegate1321 delegate1321_1;

	public Class1814.Delegate1323 delegate1323_1;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private double double_3;

	private double double_4;

	private double double_5;

	private MaterialPresetType materialPresetType_0;

	private Class1806 class1806_0;

	private Class1806 class1806_1;

	private Class1814 class1814_0;

	private Class1814 class1814_1;

	private Class1886 class1886_0;

	public static readonly MaterialPresetType materialPresetType_1 = Class2549.smethod_0("warmMatte");

	public double Z
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

	public double ExtrusionH
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

	public double ContourW
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

	public MaterialPresetType PrstMaterial
	{
		get
		{
			return materialPresetType_0;
		}
		set
		{
			materialPresetType_0 = value;
		}
	}

	public Class1806 BevelT => class1806_0;

	public Class1806 BevelB => class1806_1;

	public Class1814 ExtrusionClr => class1814_0;

	public Class1814 ContourClr => class1814_1;

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
				case "contourClr":
					class1814_1 = new Class1814(reader);
					break;
				case "extrusionClr":
					class1814_0 = new Class1814(reader);
					break;
				case "bevelB":
					class1806_1 = new Class1806(reader);
					break;
				case "bevelT":
					class1806_0 = new Class1806(reader);
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
				case "prstMaterial":
					materialPresetType_0 = Class2549.smethod_0(reader.Value);
					break;
				case "contourW":
					double_5 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "extrusionH":
					double_4 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "z":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1919(XmlReader reader)
		: base(reader)
	{
	}

	public Class1919()
	{
	}

	protected override void vmethod_1()
	{
		double_3 = 0.0;
		double_4 = 0.0;
		double_5 = 0.0;
		materialPresetType_0 = materialPresetType_1;
	}

	protected override void vmethod_2()
	{
		delegate1297_0 = method_3;
		delegate1299_0 = method_4;
		delegate1297_1 = method_5;
		delegate1299_1 = method_6;
		delegate1321_0 = method_7;
		delegate1323_0 = method_8;
		delegate1321_1 = method_9;
		delegate1323_1 = method_10;
		delegate1534_0 = method_11;
		delegate1535_0 = method_12;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (double_3 != 0.0)
		{
			writer.WriteAttributeString("z", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		if (double_4 != 0.0)
		{
			writer.WriteAttributeString("extrusionH", XmlConvert.ToString((long)Math.Round(double_4 * 12700.0)));
		}
		if (double_5 != 0.0)
		{
			writer.WriteAttributeString("contourW", XmlConvert.ToString((long)Math.Round(double_5 * 12700.0)));
		}
		if (materialPresetType_0 != materialPresetType_1)
		{
			writer.WriteAttributeString("prstMaterial", Class2549.smethod_1(materialPresetType_0));
		}
		if (class1806_0 != null)
		{
			class1806_0.vmethod_4("a", writer, "bevelT");
		}
		if (class1806_1 != null)
		{
			class1806_1.vmethod_4("a", writer, "bevelB");
		}
		if (class1814_0 != null)
		{
			class1814_0.vmethod_4("a", writer, "extrusionClr");
		}
		if (class1814_1 != null)
		{
			class1814_1.vmethod_4("a", writer, "contourClr");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1806 method_3()
	{
		if (class1806_0 != null)
		{
			throw new Exception("Only one <bevelT> element can be added.");
		}
		class1806_0 = new Class1806();
		return class1806_0;
	}

	private void method_4(Class1806 _bevelT)
	{
		class1806_0 = _bevelT;
	}

	private Class1806 method_5()
	{
		if (class1806_1 != null)
		{
			throw new Exception("Only one <bevelB> element can be added.");
		}
		class1806_1 = new Class1806();
		return class1806_1;
	}

	private void method_6(Class1806 _bevelB)
	{
		class1806_1 = _bevelB;
	}

	private Class1814 method_7()
	{
		if (class1814_0 != null)
		{
			throw new Exception("Only one <extrusionClr> element can be added.");
		}
		class1814_0 = new Class1814();
		return class1814_0;
	}

	private void method_8(Class1814 _extrusionClr)
	{
		class1814_0 = _extrusionClr;
	}

	private Class1814 method_9()
	{
		if (class1814_1 != null)
		{
			throw new Exception("Only one <contourClr> element can be added.");
		}
		class1814_1 = new Class1814();
		return class1814_1;
	}

	private void method_10(Class1814 _contourClr)
	{
		class1814_1 = _contourClr;
	}

	private Class1885 method_11()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_12(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
