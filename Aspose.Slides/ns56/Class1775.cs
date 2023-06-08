using System;
using System.Xml;

namespace ns56;

internal class Class1775 : Class1351
{
	public delegate Class1775 Delegate1204();

	public delegate void Delegate1205(Class1775 elementData);

	public delegate void Delegate1206(Class1775 elementData);

	private float float_0;

	private float float_1;

	private float float_2;

	public float H
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

	public float S
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

	public float L
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
				case "l":
					float_2 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "s":
					float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "h":
					float_0 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1775(XmlReader reader)
		: base(reader)
	{
	}

	public Class1775()
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
		writer.WriteAttributeString("h", XmlConvert.ToString((int)Math.Round(float_0 * 60000f)));
		writer.WriteAttributeString("s", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		writer.WriteAttributeString("l", XmlConvert.ToString((int)Math.Round(float_2 * 1000f)));
		writer.WriteEndElement();
	}
}
