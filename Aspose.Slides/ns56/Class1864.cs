using System;
using System.Xml;

namespace ns56;

internal class Class1864 : Class1351
{
	public delegate Class1864 Delegate1471();

	public delegate void Delegate1472(Class1864 elementData);

	public delegate void Delegate1473(Class1864 elementData);

	public const float float_0 = 0f;

	public const float float_1 = 0f;

	public const float float_2 = 0f;

	private float float_3;

	private float float_4;

	private float float_5;

	public float Hue
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

	public float Sat
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

	public float Lum
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
				case "lum":
					float_5 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "sat":
					float_4 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "hue":
					float_3 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1864(XmlReader reader)
		: base(reader)
	{
	}

	public Class1864()
	{
	}

	protected override void vmethod_1()
	{
		float_3 = 0f;
		float_4 = 0f;
		float_5 = 0f;
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
		if (float_3 != 0f)
		{
			writer.WriteAttributeString("hue", XmlConvert.ToString((int)Math.Round(float_3 * 60000f)));
		}
		if (float_4 != 0f)
		{
			writer.WriteAttributeString("sat", XmlConvert.ToString((int)Math.Round(float_4 * 1000f)));
		}
		if (float_5 != 0f)
		{
			writer.WriteAttributeString("lum", XmlConvert.ToString((int)Math.Round(float_5 * 1000f)));
		}
		writer.WriteEndElement();
	}
}
