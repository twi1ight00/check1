using System;
using System.Xml;

namespace ns56;

internal class Class1829 : Class1351
{
	public delegate Class1829 Delegate1366();

	public delegate void Delegate1367(Class1829 elementData);

	public delegate void Delegate1368(Class1829 elementData);

	private float float_0;

	private float float_1;

	public float D
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

	public float Sp
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "sp":
					float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "d":
					float_0 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1829(XmlReader reader)
		: base(reader)
	{
	}

	public Class1829()
	{
	}

	protected override void vmethod_1()
	{
		float_0 = float.NaN;
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
		writer.WriteAttributeString("d", XmlConvert.ToString((int)Math.Round(float_0 * 1000f)));
		writer.WriteAttributeString("sp", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		writer.WriteEndElement();
	}
}
