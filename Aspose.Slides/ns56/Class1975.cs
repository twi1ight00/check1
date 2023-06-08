using System;
using System.Xml;

namespace ns56;

internal class Class1975 : Class1351
{
	public delegate Class1975 Delegate1792();

	public delegate void Delegate1793(Class1975 elementData);

	public delegate void Delegate1794(Class1975 elementData);

	public const float float_0 = 0f;

	public const float float_1 = 0f;

	private float float_2;

	private float float_3;

	public float Hue
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

	public float Amt
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
				case "amt":
					float_3 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "hue":
					float_2 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1975(XmlReader reader)
		: base(reader)
	{
	}

	public Class1975()
	{
	}

	protected override void vmethod_1()
	{
		float_2 = 0f;
		float_3 = 0f;
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
		if (float_2 != 0f)
		{
			writer.WriteAttributeString("hue", XmlConvert.ToString((int)Math.Round(float_2 * 60000f)));
		}
		if (float_3 != 0f)
		{
			writer.WriteAttributeString("amt", XmlConvert.ToString((int)Math.Round(float_3 * 1000f)));
		}
		writer.WriteEndElement();
	}
}
