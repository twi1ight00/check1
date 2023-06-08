using System.Xml;

namespace ns56;

internal class Class1595 : Class1351
{
	public delegate Class1595 Delegate664();

	public delegate void Delegate666(Class1595 elementData);

	public delegate void Delegate665(Class1595 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public const bool bool_2 = false;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_3 = true;

	public const bool bool_4 = true;

	public const bool bool_5 = true;

	public const bool bool_6 = true;

	private bool bool_7;

	private string string_0;

	private bool bool_8;

	private bool bool_9;

	private uint uint_1;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	public bool Local
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public string LocalConnection
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool LocalRefresh
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public bool SendLocale
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public uint RowDrillCount
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

	public bool ServerFill
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool ServerNumberFormat
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public bool ServerFont
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public bool ServerFontColor
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
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
				case "local":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "localConnection":
					string_0 = reader.Value;
					break;
				case "localRefresh":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sendLocale":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rowDrillCount":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "serverFill":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "serverNumberFormat":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "serverFont":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "serverFontColor":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1595(XmlReader reader)
		: base(reader)
	{
	}

	public Class1595()
	{
	}

	protected override void vmethod_1()
	{
		bool_7 = false;
		bool_8 = true;
		bool_9 = false;
		uint_1 = uint.MaxValue;
		bool_10 = true;
		bool_11 = true;
		bool_12 = true;
		bool_13 = true;
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
		if (bool_7)
		{
			writer.WriteAttributeString("local", bool_7 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("localConnection", string_0);
		}
		if (!bool_8)
		{
			writer.WriteAttributeString("localRefresh", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("sendLocale", bool_9 ? "1" : "0");
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("rowDrillCount", XmlConvert.ToString(uint_1));
		}
		if (!bool_10)
		{
			writer.WriteAttributeString("serverFill", bool_10 ? "1" : "0");
		}
		if (!bool_11)
		{
			writer.WriteAttributeString("serverNumberFormat", bool_11 ? "1" : "0");
		}
		if (!bool_12)
		{
			writer.WriteAttributeString("serverFont", bool_12 ? "1" : "0");
		}
		if (!bool_13)
		{
			writer.WriteAttributeString("serverFontColor", bool_13 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
