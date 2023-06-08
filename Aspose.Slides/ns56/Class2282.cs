using System;
using System.Xml;

namespace ns56;

internal class Class2282 : Class1351
{
	public delegate Class2282 Delegate2593();

	public delegate void Delegate2594(Class2282 elementData);

	public delegate void Delegate2595(Class2282 elementData);

	public const float float_0 = 50f;

	public const bool bool_0 = false;

	public const uint uint_0 = 1u;

	public const bool bool_1 = true;

	private float float_1;

	private bool bool_2;

	private uint uint_1;

	private bool bool_3;

	private Class2283 class2283_0;

	private Class2306 class2306_0;

	public float Vol
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

	public bool Mute
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public uint NumSld
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public bool ShowWhenStopped
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class2283 CTn => class2283_0;

	public Class2306 TgtEl => class2306_0;

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
				switch (reader.LocalName)
				{
				case "tgtEl":
					class2306_0 = new Class2306(reader);
					break;
				case "cTn":
					class2283_0 = new Class2283(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
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
				case "showWhenStopped":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "numSld":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "mute":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "vol":
					float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2282(XmlReader reader)
		: base(reader)
	{
	}

	public Class2282()
	{
	}

	protected override void vmethod_1()
	{
		float_1 = 50f;
		bool_2 = false;
		uint_1 = 1u;
		bool_3 = true;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class2283_0 = new Class2283();
		class2306_0 = new Class2306();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (float_1 != 50f)
		{
			writer.WriteAttributeString("vol", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		}
		if (bool_2)
		{
			writer.WriteAttributeString("mute", bool_2 ? "1" : "0");
		}
		if (uint_1 != 1)
		{
			writer.WriteAttributeString("numSld", XmlConvert.ToString(uint_1));
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("showWhenStopped", bool_3 ? "1" : "0");
		}
		class2283_0.vmethod_4("p", writer, "cTn");
		class2306_0.vmethod_4("p", writer, "tgtEl");
		writer.WriteEndElement();
	}
}
