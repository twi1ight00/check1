using System;
using System.Xml;

namespace ns56;

internal class Class1915 : Class1351
{
	public delegate Class1915 Delegate1612();

	public delegate void Delegate1614(Class1915 elementData);

	public delegate void Delegate1613(Class1915 elementData);

	public const float float_0 = 0f;

	public const float float_1 = 0f;

	public const float float_2 = 0f;

	public const float float_3 = 0f;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	public float L
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

	public float T
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

	public float R
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

	public float B
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
				case "b":
					float_7 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "r":
					float_6 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "t":
					float_5 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "l":
					float_4 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1915(XmlReader reader)
		: base(reader)
	{
	}

	public Class1915()
	{
	}

	protected override void vmethod_1()
	{
		float_4 = 0f;
		float_5 = 0f;
		float_6 = 0f;
		float_7 = 0f;
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
		if (float_4 != 0f)
		{
			writer.WriteAttributeString("l", XmlConvert.ToString((int)Math.Round(float_4 * 1000f)));
		}
		if (float_5 != 0f)
		{
			writer.WriteAttributeString("t", XmlConvert.ToString((int)Math.Round(float_5 * 1000f)));
		}
		if (float_6 != 0f)
		{
			writer.WriteAttributeString("r", XmlConvert.ToString((int)Math.Round(float_6 * 1000f)));
		}
		if (float_7 != 0f)
		{
			writer.WriteAttributeString("b", XmlConvert.ToString((int)Math.Round(float_7 * 1000f)));
		}
		writer.WriteEndElement();
	}
}
