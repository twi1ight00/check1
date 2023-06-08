using System.Xml;

namespace ns56;

internal class Class1636 : Class1351
{
	public delegate Class1636 Delegate787();

	public delegate void Delegate788(Class1636 elementData);

	public delegate void Delegate789(Class1636 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const uint uint_0 = 0u;

	public const Enum183 enum183_0 = Enum183.const_0;

	public const uint uint_1 = 0u;

	public const uint uint_2 = 0u;

	public const uint uint_3 = 0u;

	public const uint uint_4 = 0u;

	public const uint uint_5 = 0u;

	public const uint uint_6 = 0u;

	public const uint uint_7 = 0u;

	public const uint uint_8 = 0u;

	public const uint uint_9 = 0u;

	private Enum224 enum224_0;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private uint uint_10;

	private Enum183 enum183_1;

	private uint uint_11;

	private uint uint_12;

	private uint uint_13;

	private uint uint_14;

	private uint uint_15;

	private uint uint_16;

	private uint uint_17;

	private uint uint_18;

	private uint uint_19;

	private string string_0;

	private Class1621 class1621_0;

	public static readonly Enum224 enum224_1 = Class2391.smethod_0("topLeft");

	public Enum224 Pane
	{
		get
		{
			return enum224_0;
		}
		set
		{
			enum224_0 = value;
		}
	}

	public bool ShowHeader
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool Label
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool Data
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool Extendable
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

	public uint Count
	{
		get
		{
			return uint_10;
		}
		set
		{
			uint_10 = value;
		}
	}

	public Enum183 Axis
	{
		get
		{
			return enum183_1;
		}
		set
		{
			enum183_1 = value;
		}
	}

	public uint Dimension
	{
		get
		{
			return uint_11;
		}
		set
		{
			uint_11 = value;
		}
	}

	public uint Start
	{
		get
		{
			return uint_12;
		}
		set
		{
			uint_12 = value;
		}
	}

	public uint Min
	{
		get
		{
			return uint_13;
		}
		set
		{
			uint_13 = value;
		}
	}

	public uint Max
	{
		get
		{
			return uint_14;
		}
		set
		{
			uint_14 = value;
		}
	}

	public uint ActiveRow
	{
		get
		{
			return uint_15;
		}
		set
		{
			uint_15 = value;
		}
	}

	public uint ActiveCol
	{
		get
		{
			return uint_16;
		}
		set
		{
			uint_16 = value;
		}
	}

	public uint PreviousRow
	{
		get
		{
			return uint_17;
		}
		set
		{
			uint_17 = value;
		}
	}

	public uint PreviousCol
	{
		get
		{
			return uint_18;
		}
		set
		{
			uint_18 = value;
		}
	}

	public uint Click
	{
		get
		{
			return uint_19;
		}
		set
		{
			uint_19 = value;
		}
	}

	public string R_Id
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

	public Class1621 PivotArea => class1621_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "pivotArea")
				{
					class1621_0 = new Class1621(reader);
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
				case "pane":
					enum224_0 = Class2391.smethod_0(reader.Value);
					break;
				case "showHeader":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "label":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "data":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "extendable":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "count":
					uint_10 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "axis":
					enum183_1 = Class2349.smethod_0(reader.Value);
					break;
				case "dimension":
					uint_11 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "start":
					uint_12 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "min":
					uint_13 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "max":
					uint_14 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "activeRow":
					uint_15 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "activeCol":
					uint_16 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "previousRow":
					uint_17 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "previousCol":
					uint_18 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "click":
					uint_19 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "r:id":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1636(XmlReader reader)
		: base(reader)
	{
	}

	public Class1636()
	{
	}

	protected override void vmethod_1()
	{
		enum224_0 = enum224_1;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		uint_10 = 0u;
		enum183_1 = Enum183.const_0;
		uint_11 = 0u;
		uint_12 = 0u;
		uint_13 = 0u;
		uint_14 = 0u;
		uint_15 = 0u;
		uint_16 = 0u;
		uint_17 = 0u;
		uint_18 = 0u;
		uint_19 = 0u;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class1621_0 = new Class1621();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum224_0 != enum224_1)
		{
			writer.WriteAttributeString("pane", Class2391.smethod_1(enum224_0));
		}
		if (bool_4)
		{
			writer.WriteAttributeString("showHeader", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("label", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("data", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("extendable", bool_7 ? "1" : "0");
		}
		if (uint_10 != 0)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_10));
		}
		if (enum183_1 != 0)
		{
			writer.WriteAttributeString("axis", Class2349.smethod_1(enum183_1));
		}
		if (uint_11 != 0)
		{
			writer.WriteAttributeString("dimension", XmlConvert.ToString(uint_11));
		}
		if (uint_12 != 0)
		{
			writer.WriteAttributeString("start", XmlConvert.ToString(uint_12));
		}
		if (uint_13 != 0)
		{
			writer.WriteAttributeString("min", XmlConvert.ToString(uint_13));
		}
		if (uint_14 != 0)
		{
			writer.WriteAttributeString("max", XmlConvert.ToString(uint_14));
		}
		if (uint_15 != 0)
		{
			writer.WriteAttributeString("activeRow", XmlConvert.ToString(uint_15));
		}
		if (uint_16 != 0)
		{
			writer.WriteAttributeString("activeCol", XmlConvert.ToString(uint_16));
		}
		if (uint_17 != 0)
		{
			writer.WriteAttributeString("previousRow", XmlConvert.ToString(uint_17));
		}
		if (uint_18 != 0)
		{
			writer.WriteAttributeString("previousCol", XmlConvert.ToString(uint_18));
		}
		if (uint_19 != 0)
		{
			writer.WriteAttributeString("click", XmlConvert.ToString(uint_19));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("r:id", string_0);
		}
		class1621_0.vmethod_4("ssml", writer, "pivotArea");
		writer.WriteEndElement();
	}
}
