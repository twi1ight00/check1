using System;
using System.Xml;

namespace ns56;

internal class Class1792 : Class1351
{
	public delegate Class1792 Delegate1255();

	public delegate void Delegate1256(Class1792 elementData);

	public delegate void Delegate1257(Class1792 elementData);

	private float float_0;

	public float Val
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "val")
			{
				float_0 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
			}
		}
		reader.MoveToElement();
	}

	public Class1792(XmlReader reader)
		: base(reader)
	{
	}

	public Class1792()
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
		writer.WriteAttributeString("val", XmlConvert.ToString((int)Math.Round(float_0 * 60000f)));
		writer.WriteEndElement();
	}
}
