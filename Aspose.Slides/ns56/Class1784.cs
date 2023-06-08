using System;
using System.Xml;

namespace ns56;

internal class Class1784 : Class1351
{
	public delegate Class1784 Delegate1231();

	public delegate void Delegate1232(Class1784 elementData);

	public delegate void Delegate1233(Class1784 elementData);

	private float float_0;

	public float Thresh
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "thresh")
			{
				float_0 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
			}
		}
		reader.MoveToElement();
	}

	public Class1784(XmlReader reader)
		: base(reader)
	{
	}

	public Class1784()
	{
	}

	protected override void vmethod_1()
	{
		float_0 = float.NaN;
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
		writer.WriteAttributeString("thresh", XmlConvert.ToString((int)Math.Round(float_0 * 1000f)));
		writer.WriteEndElement();
	}
}
