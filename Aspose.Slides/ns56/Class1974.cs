using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1974 : Class1351
{
	public delegate Class1974 Delegate1789();

	public delegate void Delegate1790(Class1974 elementData);

	public delegate void Delegate1791(Class1974 elementData);

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	public const float float_0 = float.NaN;

	public const float float_1 = float.NaN;

	public const TileFlip tileFlip_0 = TileFlip.NotDefined;

	private double double_2;

	private double double_3;

	private float float_2;

	private float float_3;

	private TileFlip tileFlip_1;

	private RectangleAlignment rectangleAlignment_0;

	public static readonly RectangleAlignment rectangleAlignment_1 = RectangleAlignment.NotDefined;

	public double Tx
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

	public double Ty
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

	public float Sx
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public float Sy
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public TileFlip Flip
	{
		get
		{
			return tileFlip_1;
		}
		set
		{
			tileFlip_1 = value;
		}
	}

	public RectangleAlignment Algn
	{
		get
		{
			return rectangleAlignment_0;
		}
		set
		{
			rectangleAlignment_0 = value;
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
				case "tx":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "ty":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "sx":
					float_2 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "sy":
					float_3 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "flip":
					tileFlip_1 = Class2577.smethod_0(reader.Value);
					break;
				case "algn":
					rectangleAlignment_0 = Class2552.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1974(XmlReader reader)
		: base(reader)
	{
	}

	public Class1974()
	{
	}

	protected override void vmethod_1()
	{
		double_2 = double.NaN;
		double_3 = double.NaN;
		float_2 = float.NaN;
		float_3 = float.NaN;
		tileFlip_1 = TileFlip.NotDefined;
		rectangleAlignment_0 = rectangleAlignment_1;
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
		if (!double.IsNaN(double_2))
		{
			writer.WriteAttributeString("tx", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		}
		if (!double.IsNaN(double_3))
		{
			writer.WriteAttributeString("ty", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		if (!float.IsNaN(float_2))
		{
			writer.WriteAttributeString("sx", XmlConvert.ToString((int)Math.Round(float_2 * 1000f)));
		}
		if (!float.IsNaN(float_3))
		{
			writer.WriteAttributeString("sy", XmlConvert.ToString((int)Math.Round(float_3 * 1000f)));
		}
		if (tileFlip_1 != TileFlip.NotDefined)
		{
			writer.WriteAttributeString("flip", Class2577.smethod_1(tileFlip_1));
		}
		if (rectangleAlignment_0 != rectangleAlignment_1)
		{
			writer.WriteAttributeString("algn", Class2552.smethod_1(rectangleAlignment_0));
		}
		writer.WriteEndElement();
	}
}
