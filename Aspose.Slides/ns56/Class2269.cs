using System;
using System.Xml;

namespace ns56;

internal class Class2269 : Class1351
{
	public delegate Class2269 Delegate2554();

	public delegate void Delegate2555(Class2269 elementData);

	public delegate void Delegate2556(Class2269 elementData);

	public const float float_0 = float.NaN;

	public const float float_1 = float.NaN;

	public const float float_2 = float.NaN;

	public const float float_3 = float.NaN;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private Class2281 class2281_0;

	public float By
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public float From
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	public float To
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	public float P14_BounceEnd
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	public Class2281 CBhvr => class2281_0;

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "cBhvr")
				{
					class2281_0 = new Class2281(reader);
					continue;
				}
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
				case "p14:bounceEnd":
					float_7 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "to":
					float_6 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "from":
					float_5 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				case "by":
					float_4 = (float)XmlConvert.ToInt32(reader.Value) / 60000f;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2269(XmlReader reader)
		: base(reader)
	{
	}

	public Class2269()
	{
	}

	protected override void vmethod_1()
	{
		float_4 = float.NaN;
		float_5 = float.NaN;
		float_6 = float.NaN;
		float_7 = float.NaN;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class2281_0 = new Class2281();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!float.IsNaN(float_4))
		{
			writer.WriteAttributeString("by", XmlConvert.ToString((int)Math.Round(float_4 * 60000f)));
		}
		if (!float.IsNaN(float_5))
		{
			writer.WriteAttributeString("from", XmlConvert.ToString((int)Math.Round(float_5 * 60000f)));
		}
		if (!float.IsNaN(float_6))
		{
			writer.WriteAttributeString("to", XmlConvert.ToString((int)Math.Round(float_6 * 60000f)));
		}
		if (!float.IsNaN(float_7))
		{
			writer.WriteAttributeString("p14:bounceEnd", XmlConvert.ToString((int)Math.Round(float_7 * 1000f)));
		}
		class2281_0.vmethod_4("p", writer, "cBhvr");
		writer.WriteEndElement();
	}
}
