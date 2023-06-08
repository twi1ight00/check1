using System;
using System.Xml;

namespace ns56;

internal class Class1873 : Class1351
{
	public delegate Class1873 Delegate1498();

	public delegate void Delegate1499(Class1873 elementData);

	public delegate void Delegate1500(Class1873 elementData);

	public const float float_0 = float.NaN;

	private float float_1;

	public float Lim
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "lim")
			{
				float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
			}
		}
		reader.MoveToElement();
	}

	public Class1873(XmlReader reader)
		: base(reader)
	{
	}

	public Class1873()
	{
	}

	protected override void vmethod_1()
	{
		float_1 = float.NaN;
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
		if (!float.IsNaN(float_1))
		{
			writer.WriteAttributeString("lim", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		}
		writer.WriteEndElement();
	}
}
