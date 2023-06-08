using System.Xml;

namespace ns56;

internal class Class1650 : Class1351
{
	public delegate Class1650 Delegate829();

	public delegate void Delegate830(Class1650 elementData);

	public delegate void Delegate831(Class1650 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public const uint uint_3 = uint.MaxValue;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	public uint I1
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public uint I2
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public uint I3
	{
		get
		{
			return uint_6;
		}
		set
		{
			uint_6 = value;
		}
	}

	public uint I4
	{
		get
		{
			return uint_7;
		}
		set
		{
			uint_7 = value;
		}
	}

	public string Ref
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

	public string Name
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string Sheet
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string R_Id
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
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
				case "i1":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "i2":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "i3":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "i4":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ref":
					string_0 = reader.Value;
					break;
				case "name":
					string_1 = reader.Value;
					break;
				case "sheet":
					string_2 = reader.Value;
					break;
				case "r:id":
					string_3 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1650(XmlReader reader)
		: base(reader)
	{
	}

	public Class1650()
	{
	}

	protected override void vmethod_1()
	{
		uint_4 = uint.MaxValue;
		uint_5 = uint.MaxValue;
		uint_6 = uint.MaxValue;
		uint_7 = uint.MaxValue;
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
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("i1", XmlConvert.ToString(uint_4));
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("i2", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != uint.MaxValue)
		{
			writer.WriteAttributeString("i3", XmlConvert.ToString(uint_6));
		}
		if (uint_7 != uint.MaxValue)
		{
			writer.WriteAttributeString("i4", XmlConvert.ToString(uint_7));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("ref", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("name", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("sheet", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("r:id", string_3);
		}
		writer.WriteEndElement();
	}
}
