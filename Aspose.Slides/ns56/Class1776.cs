using System;
using System.Xml;

namespace ns56;

internal class Class1776 : Class1351
{
	public delegate Class1776 Delegate1207();

	public delegate void Delegate1208(Class1776 elementData);

	public delegate void Delegate1209(Class1776 elementData);

	private float float_0;

	private float float_1;

	private float float_2;

	public float R
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float G
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

	public float B
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
					float_2 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "g":
					float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "r":
					float_0 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1776(XmlReader reader)
		: base(reader)
	{
	}

	public Class1776()
	{
	}

	protected override void vmethod_1()
	{
		float_0 = float.NaN;
		float_1 = float.NaN;
		float_2 = float.NaN;
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
		writer.WriteAttributeString("r", XmlConvert.ToString((int)Math.Round(float_0 * 1000f)));
		writer.WriteAttributeString("g", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		writer.WriteAttributeString("b", XmlConvert.ToString((int)Math.Round(float_2 * 1000f)));
		writer.WriteEndElement();
	}
}
