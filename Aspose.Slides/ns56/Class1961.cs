using System;
using System.Xml;

namespace ns56;

internal class Class1961 : Class1351
{
	public delegate Class1961 Delegate1750();

	public delegate void Delegate1751(Class1961 elementData);

	public delegate void Delegate1752(Class1961 elementData);

	public const float float_0 = 100f;

	public const float float_1 = 0f;

	private float float_2;

	private float float_3;

	public float FontScale
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

	public float LnSpcReduction
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
				case "lnSpcReduction":
					float_3 = (float)XmlConvert.ToInt32(reader.Value) / 1000f;
					break;
				case "fontScale":
					float_2 = (float)XmlConvert.ToInt32(reader.Value) / 1000f;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1961(XmlReader reader)
		: base(reader)
	{
	}

	public Class1961()
	{
	}

	protected override void vmethod_1()
	{
		float_2 = 100f;
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
		if (float_2 != 100f)
		{
			writer.WriteAttributeString("fontScale", XmlConvert.ToString((int)Math.Round(float_2 * 1000f)));
		}
		if (float_3 != 0f)
		{
			writer.WriteAttributeString("lnSpcReduction", XmlConvert.ToString((int)Math.Round(float_3 * 1000f)));
		}
		writer.WriteEndElement();
	}
}
