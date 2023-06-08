using System;
using System.Xml;

namespace ns56;

internal class Class1373 : Class1351
{
	public delegate Class1373 Delegate81();

	public delegate void Delegate82(Class1373 elementData);

	public delegate void Delegate83(Class1373 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public const bool bool_2 = true;

	public const bool bool_3 = true;

	public const int int_0 = 0;

	public const int int_1 = 0;

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = 600u;

	public const uint uint_3 = 0u;

	public const uint uint_4 = 0u;

	public const bool bool_4 = true;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Enum256 enum256_0;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private int int_2;

	private int int_3;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private uint uint_9;

	private bool bool_9;

	private Class1502 class1502_0;

	public static readonly Enum256 enum256_1 = Class2423.smethod_0("visible");

	public Enum256 Visibility
	{
		get
		{
			return enum256_0;
		}
		set
		{
			enum256_0 = value;
		}
	}

	public bool Minimized
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

	public bool ShowHorizontalScroll
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

	public bool ShowVerticalScroll
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

	public bool ShowSheetTabs
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

	public int XWindow
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int YWindow
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public uint WindowWidth
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

	public uint WindowHeight
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

	public uint TabRatio
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

	public uint FirstSheet
	{
		get
		{
			return uint_8;
		}
		set
		{
			uint_8 = value;
		}
	}

	public uint ActiveTab
	{
		get
		{
			return uint_9;
		}
		set
		{
			uint_9 = value;
		}
	}

	public bool AutoFilterDateGrouping
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

	public Class1502 ExtLst => class1502_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1502_0 = new Class1502(reader);
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
				case "visibility":
					enum256_0 = Class2423.smethod_0(reader.Value);
					break;
				case "minimized":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showHorizontalScroll":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showVerticalScroll":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showSheetTabs":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "xWindow":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				case "yWindow":
					int_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "windowWidth":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "windowHeight":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "tabRatio":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "firstSheet":
					uint_8 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "activeTab":
					uint_9 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "autoFilterDateGrouping":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1373(XmlReader reader)
		: base(reader)
	{
	}

	public Class1373()
	{
	}

	protected override void vmethod_1()
	{
		enum256_0 = enum256_1;
		bool_5 = false;
		bool_6 = true;
		bool_7 = true;
		bool_8 = true;
		int_2 = 0;
		int_3 = 0;
		uint_5 = uint.MaxValue;
		uint_6 = uint.MaxValue;
		uint_7 = 600u;
		uint_8 = 0u;
		uint_9 = 0u;
		bool_9 = true;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum256_0 != enum256_1)
		{
			writer.WriteAttributeString("visibility", Class2423.smethod_1(enum256_0));
		}
		if (bool_5)
		{
			writer.WriteAttributeString("minimized", bool_5 ? "1" : "0");
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("showHorizontalScroll", bool_6 ? "1" : "0");
		}
		if (!bool_7)
		{
			writer.WriteAttributeString("showVerticalScroll", bool_7 ? "1" : "0");
		}
		if (!bool_8)
		{
			writer.WriteAttributeString("showSheetTabs", bool_8 ? "1" : "0");
		}
		if (int_2 != 0)
		{
			writer.WriteAttributeString("xWindow", XmlConvert.ToString(int_2));
		}
		if (int_3 != 0)
		{
			writer.WriteAttributeString("yWindow", XmlConvert.ToString(int_3));
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("windowWidth", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != uint.MaxValue)
		{
			writer.WriteAttributeString("windowHeight", XmlConvert.ToString(uint_6));
		}
		if (uint_7 != 600)
		{
			writer.WriteAttributeString("tabRatio", XmlConvert.ToString(uint_7));
		}
		if (uint_8 != 0)
		{
			writer.WriteAttributeString("firstSheet", XmlConvert.ToString(uint_8));
		}
		if (uint_9 != 0)
		{
			writer.WriteAttributeString("activeTab", XmlConvert.ToString(uint_9));
		}
		if (!bool_9)
		{
			writer.WriteAttributeString("autoFilterDateGrouping", bool_9 ? "1" : "0");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1502 method_3()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_4(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
