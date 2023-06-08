using System;
using System.Xml;

namespace ns56;

internal class Class1977 : Class1351
{
	public delegate Class1977 Delegate1798();

	public delegate void Delegate1799(Class1977 elementData);

	public delegate void Delegate1800(Class1977 elementData);

	public const float float_0 = 100f;

	public const float float_1 = 100f;

	public const float float_2 = 0f;

	public const float float_3 = 0f;

	public const double double_0 = 0.0;

	public const double double_1 = 0.0;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private double double_2;

	private double double_3;

	public float Sx
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

	public float Sy
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

	public float Kx
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

	public float Ky
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
				case "sx":
					float_4 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "sy":
					float_5 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "kx":
					float_6 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "ky":
					float_7 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "tx":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "ty":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1977(XmlReader reader)
		: base(reader)
	{
	}

	public Class1977()
	{
	}

	protected override void vmethod_1()
	{
		float_4 = 100f;
		float_5 = 100f;
		float_6 = 0f;
		float_7 = 0f;
		double_2 = 0.0;
		double_3 = 0.0;
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
		if (float_4 != 100f)
		{
			writer.WriteAttributeString("sx", XmlConvert.ToString((int)Math.Round(float_4 * 1000f)));
		}
		if (float_5 != 100f)
		{
			writer.WriteAttributeString("sy", XmlConvert.ToString((int)Math.Round(float_5 * 1000f)));
		}
		if (float_6 != 0f)
		{
			writer.WriteAttributeString("kx", XmlConvert.ToString((int)Math.Round(float_6 * 60000f)));
		}
		if (float_7 != 0f)
		{
			writer.WriteAttributeString("ky", XmlConvert.ToString((int)Math.Round(float_7 * 60000f)));
		}
		if (double_2 != 0.0)
		{
			writer.WriteAttributeString("tx", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		}
		if (double_3 != 0.0)
		{
			writer.WriteAttributeString("ty", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		writer.WriteEndElement();
	}
}
