using System;
using System.Xml;

namespace ns56;

internal class Class1789 : Class1351
{
	public delegate Class1789 Delegate1246();

	public delegate void Delegate1247(Class1789 elementData);

	public delegate void Delegate1248(Class1789 elementData);

	public const float float_0 = 100f;

	private float float_1;

	public float Amt
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "amt")
			{
				float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
			}
		}
		reader.MoveToElement();
	}

	public Class1789(XmlReader reader)
		: base(reader)
	{
	}

	public Class1789()
	{
	}

	protected override void vmethod_1()
	{
		float_1 = 100f;
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
		if (float_1 != 100f)
		{
			writer.WriteAttributeString("amt", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		}
		writer.WriteEndElement();
	}
}
