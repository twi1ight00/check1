using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1913 : Class1351
{
	public delegate Class1913 Delegate1606();

	public delegate void Delegate1608(Class1913 elementData);

	public delegate void Delegate1607(Class1913 elementData);

	public const double double_0 = 0.0;

	public const float float_0 = 100f;

	public const float float_1 = 0f;

	public const float float_2 = 0f;

	public const float float_3 = 100f;

	public const double double_1 = 0.0;

	public const float float_4 = 0f;

	public const float float_5 = 90f;

	public const float float_6 = 100f;

	public const float float_7 = 100f;

	public const float float_8 = 0f;

	public const float float_9 = 0f;

	public const bool bool_0 = true;

	private double double_2;

	private float float_10;

	private float float_11;

	private float float_12;

	private float float_13;

	private double double_3;

	private float float_14;

	private float float_15;

	private float float_16;

	private float float_17;

	private float float_18;

	private float float_19;

	private RectangleAlignment rectangleAlignment_0;

	private bool bool_1;

	public static readonly RectangleAlignment rectangleAlignment_1 = Class2552.smethod_0("b");

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

	public float StA
	{
		get
		{
			return float_10;
		}
		set
		{
			float_10 = value;
		}
	}

	public float StPos
	{
		get
		{
			return float_11;
		}
		set
		{
			float_11 = value;
		}
	}

	public float EndA
	{
		get
		{
			return float_12;
		}
		set
		{
			float_12 = value;
		}
	}

	public float EndPos
	{
		get
		{
			return float_13;
		}
		set
		{
			float_13 = value;
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
			return float_14;
		}
		set
		{
			float_14 = value;
		}
	}

	public float FadeDir
	{
		get
		{
			return float_15;
		}
		set
		{
			float_15 = value;
		}
	}

	public float Sx
	{
		get
		{
			return float_16;
		}
		set
		{
			float_16 = value;
		}
	}

	public float Sy
	{
		get
		{
			return float_17;
		}
		set
		{
			float_17 = value;
		}
	}

	public float Kx
	{
		get
		{
			return float_18;
		}
		set
		{
			float_18 = value;
		}
	}

	public float Ky
	{
		get
		{
			return float_19;
		}
		set
		{
			float_19 = value;
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

	public bool RotWithShape
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
				case "blurRad":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "stA":
					float_10 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "stPos":
					float_11 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "endA":
					float_12 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "endPos":
					float_13 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "dist":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "dir":
					float_14 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "fadeDir":
					float_15 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "sx":
					float_16 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "sy":
					float_17 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "kx":
					float_18 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "ky":
					float_19 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "algn":
					rectangleAlignment_0 = Class2552.smethod_0(reader.Value);
					break;
				case "rotWithShape":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1913(XmlReader reader)
		: base(reader)
	{
	}

	public Class1913()
	{
	}

	protected override void vmethod_1()
	{
		double_2 = 0.0;
		float_10 = 100f;
		float_11 = 0f;
		float_12 = 0f;
		float_13 = 100f;
		double_3 = 0.0;
		float_14 = 0f;
		float_15 = 90f;
		float_16 = 100f;
		float_17 = 100f;
		float_18 = 0f;
		float_19 = 0f;
		rectangleAlignment_0 = rectangleAlignment_1;
		bool_1 = true;
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
		if (double_2 != 0.0)
		{
			writer.WriteAttributeString("blurRad", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		}
		if (float_10 != 100f)
		{
			writer.WriteAttributeString("stA", XmlConvert.ToString((int)Math.Round(float_10 * 1000f)));
		}
		if (float_11 != 0f)
		{
			writer.WriteAttributeString("stPos", XmlConvert.ToString((int)Math.Round(float_11 * 1000f)));
		}
		if (float_12 != 0f)
		{
			writer.WriteAttributeString("endA", XmlConvert.ToString((int)Math.Round(float_12 * 1000f)));
		}
		if (float_13 != 100f)
		{
			writer.WriteAttributeString("endPos", XmlConvert.ToString((int)Math.Round(float_13 * 1000f)));
		}
		if (double_3 != 0.0)
		{
			writer.WriteAttributeString("dist", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		if (float_14 != 0f)
		{
			writer.WriteAttributeString("dir", XmlConvert.ToString((int)Math.Round(float_14 * 60000f)));
		}
		if (float_15 != 90f)
		{
			writer.WriteAttributeString("fadeDir", XmlConvert.ToString((int)Math.Round(float_15 * 60000f)));
		}
		if (float_16 != 100f)
		{
			writer.WriteAttributeString("sx", XmlConvert.ToString((int)Math.Round(float_16 * 1000f)));
		}
		if (float_17 != 100f)
		{
			writer.WriteAttributeString("sy", XmlConvert.ToString((int)Math.Round(float_17 * 1000f)));
		}
		if (float_18 != 0f)
		{
			writer.WriteAttributeString("kx", XmlConvert.ToString((int)Math.Round(float_18 * 60000f)));
		}
		if (float_19 != 0f)
		{
			writer.WriteAttributeString("ky", XmlConvert.ToString((int)Math.Round(float_19 * 60000f)));
		}
		if (rectangleAlignment_0 != rectangleAlignment_1)
		{
			writer.WriteAttributeString("algn", Class2552.smethod_1(rectangleAlignment_0));
		}
		if (!bool_1)
		{
			writer.WriteAttributeString("rotWithShape", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
