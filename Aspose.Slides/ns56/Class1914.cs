using System;
using System.Xml;

namespace ns56;

internal class Class1914 : Class1351
{
	public delegate Class1914 Delegate1609();

	public delegate void Delegate1610(Class1914 elementData);

	public delegate void Delegate1611(Class1914 elementData);

	public const float float_0 = 0f;

	public const float float_1 = 0f;

	private float float_2;

	private float float_3;

	public float Tx
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

	public float Ty
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
				case "ty":
					float_3 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "tx":
					float_2 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1914(XmlReader reader)
		: base(reader)
	{
	}

	public Class1914()
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
			writer.WriteAttributeString("tx", XmlConvert.ToString((int)Math.Round(float_2 * 1000f)));
		}
		if (float_3 != 0f)
		{
			writer.WriteAttributeString("ty", XmlConvert.ToString((int)Math.Round(float_3 * 1000f)));
		}
		writer.WriteEndElement();
	}
}
