using System;
using System.Xml;

namespace ns56;

internal class Class1925 : Class1351
{
	public delegate Class1925 Delegate1642();

	public delegate void Delegate1644(Class1925 elementData);

	public delegate void Delegate1643(Class1925 elementData);

	private float float_0;

	private float float_1;

	private float float_2;

	public float Lat
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

	public float Lon
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

	public float Rev
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
				case "rev":
					float_2 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "lon":
					float_1 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "lat":
					float_0 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1925(XmlReader reader)
		: base(reader)
	{
	}

	public Class1925()
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
		writer.WriteAttributeString("lat", XmlConvert.ToString((int)Math.Round(float_0 * 60000f)));
		writer.WriteAttributeString("lon", XmlConvert.ToString((int)Math.Round(float_1 * 60000f)));
		writer.WriteAttributeString("rev", XmlConvert.ToString((int)Math.Round(float_2 * 60000f)));
		writer.WriteEndElement();
	}
}
