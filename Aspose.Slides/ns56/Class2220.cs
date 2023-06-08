using System;
using System.Xml;

namespace ns56;

internal class Class2220 : Class1351
{
	public delegate Class2220 Delegate2396();

	public delegate void Delegate2397(Class2220 elementData);

	public delegate void Delegate2398(Class2220 elementData);

	public const float float_0 = 50f;

	public const int int_0 = 1;

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = true;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = true;

	public const uint uint_0 = 1u;

	public Class2255.Delegate2512 delegate2512_0;

	public Class2255.Delegate2514 delegate2514_0;

	public Class2242.Delegate2470 delegate2470_0;

	public Class2242.Delegate2472 delegate2472_0;

	public Class2236.Delegate2452 delegate2452_0;

	public Class2236.Delegate2454 delegate2454_0;

	public Class2251.Delegate2500 delegate2500_0;

	public Class2251.Delegate2502 delegate2502_0;

	public Class2258.Delegate2521 delegate2521_0;

	public Class2258.Delegate2523 delegate2523_0;

	public Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	public Class2234.Delegate2440 delegate2440_0;

	public Class2234.Delegate2442 delegate2442_0;

	public Class1447.Delegate303 delegate303_1;

	public Class1447.Delegate304 delegate304_1;

	public Class1447.Delegate303 delegate303_2;

	public Class1447.Delegate304 delegate304_2;

	public Class2232.Delegate2434 delegate2434_0;

	public Class2232.Delegate2436 delegate2436_0;

	public Class1447.Delegate303 delegate303_3;

	public Class1447.Delegate304 delegate304_3;

	public Class1958.Delegate1741 delegate1741_0;

	public Class1958.Delegate1743 delegate1743_0;

	public Class2241.Delegate2467 delegate2467_0;

	public Class2241.Delegate2469 delegate2469_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private float float_1;

	private int int_1;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private uint uint_1;

	private Class2255 class2255_0;

	private Class2242 class2242_0;

	private Class2236 class2236_0;

	private Class2251 class2251_0;

	private Class2258 class2258_0;

	private Class1906 class1906_0;

	private Class1472 class1472_0;

	private Class2234 class2234_0;

	private Class1464 class1464_0;

	private Class1469 class1469_0;

	private Class2232 class2232_0;

	private Class1465 class1465_0;

	private Class1958 class1958_0;

	private Class2241 class2241_0;

	private Class1888 class1888_0;

	public float ServerZoom
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

	public int FirstSlideNum
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool ShowSpecialPlsOnTitleSld
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

	public bool Rtl
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

	public bool RemovePersonalInfoOnSave
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

	public bool CompatMode
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

	public bool StrictFirstAndLastChars
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

	public bool EmbedTrueTypeFonts
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

	public bool SaveSubsetFonts
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	public bool AutoCompressPictures
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	public uint BookmarkIdSeed
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

	public Class2255 SldMasterIdLst => class2255_0;

	public Class2242 NotesMasterIdLst => class2242_0;

	public Class2236 HandoutMasterIdLst => class2236_0;

	public Class2251 SldIdLst => class2251_0;

	public Class2258 SldSz => class2258_0;

	public Class1906 NotesSz => class1906_0;

	public Class1472 SmartTags => class1472_0;

	public Class2234 EmbeddedFontLst => class2234_0;

	public Class1464 CustShowLst => class1464_0;

	public Class1469 PhotoAlbum => class1469_0;

	public Class2232 CustDataLst => class2232_0;

	public Class1465 Kinsoku => class1465_0;

	public Class1958 DefaultTextStyle => class1958_0;

	public Class2241 ModifyVerifier => class2241_0;

	public Class1885 ExtLst => class1888_0;

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
				case "sldMasterIdLst":
					class2255_0 = new Class2255(reader);
					break;
				case "notesMasterIdLst":
					class2242_0 = new Class2242(reader);
					break;
				case "handoutMasterIdLst":
					class2236_0 = new Class2236(reader);
					break;
				case "sldIdLst":
					class2251_0 = new Class2251(reader);
					break;
				case "sldSz":
					class2258_0 = new Class2258(reader);
					break;
				case "notesSz":
					class1906_0 = new Class1906(reader);
					break;
				case "smartTags":
					class1472_0 = new Class1472(reader);
					flag = true;
					break;
				case "embeddedFontLst":
					class2234_0 = new Class2234(reader);
					break;
				case "custShowLst":
					class1464_0 = new Class1464(reader);
					flag = true;
					break;
				case "photoAlbum":
					class1469_0 = new Class1469(reader);
					flag = true;
					break;
				case "custDataLst":
					class2232_0 = new Class2232(reader);
					break;
				case "kinsoku":
					class1465_0 = new Class1465(reader);
					flag = true;
					break;
				case "defaultTextStyle":
					class1958_0 = new Class1958(reader);
					break;
				case "modifyVerifier":
					class2241_0 = new Class2241(reader);
					break;
				case "extLst":
					class1888_0 = new Class1888(reader);
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
				case "serverZoom":
					float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				case "firstSlideNum":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "showSpecialPlsOnTitleSld":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rtl":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "removePersonalInfoOnSave":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "compatMode":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "strictFirstAndLastChars":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "embedTrueTypeFonts":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "saveSubsetFonts":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "autoCompressPictures":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "bookmarkIdSeed":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2220(XmlReader reader)
		: base(reader)
	{
	}

	public Class2220()
	{
	}

	protected override void vmethod_1()
	{
		float_1 = 50f;
		int_1 = 1;
		bool_8 = true;
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		bool_12 = true;
		bool_13 = false;
		bool_14 = false;
		bool_15 = true;
		uint_1 = 1u;
	}

	protected override void vmethod_2()
	{
		delegate2512_0 = method_3;
		delegate2514_0 = method_4;
		delegate2470_0 = method_5;
		delegate2472_0 = method_6;
		delegate2452_0 = method_7;
		delegate2454_0 = method_8;
		delegate2500_0 = method_9;
		delegate2502_0 = method_10;
		delegate2521_0 = method_11;
		delegate2523_0 = method_12;
		delegate303_0 = method_13;
		delegate304_0 = method_14;
		delegate2440_0 = method_15;
		delegate2442_0 = method_16;
		delegate303_1 = method_17;
		delegate304_1 = method_18;
		delegate303_2 = method_19;
		delegate304_2 = method_20;
		delegate2434_0 = method_21;
		delegate2436_0 = method_22;
		delegate303_3 = method_23;
		delegate304_3 = method_24;
		delegate1741_0 = method_25;
		delegate1743_0 = method_26;
		delegate2467_0 = method_27;
		delegate2469_0 = method_28;
		delegate1534_0 = method_29;
		delegate1535_0 = method_30;
	}

	protected override void vmethod_3()
	{
		class1906_0 = new Class1906();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("p", elementName, "http://schemas.openxmlformats.org/presentationml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (float_1 != 50f)
		{
			writer.WriteAttributeString("serverZoom", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		}
		if (int_1 != 1)
		{
			writer.WriteAttributeString("firstSlideNum", XmlConvert.ToString(int_1));
		}
		if (!bool_8)
		{
			writer.WriteAttributeString("showSpecialPlsOnTitleSld", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("rtl", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("removePersonalInfoOnSave", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("compatMode", bool_11 ? "1" : "0");
		}
		if (!bool_12)
		{
			writer.WriteAttributeString("strictFirstAndLastChars", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("embedTrueTypeFonts", bool_13 ? "1" : "0");
		}
		if (bool_14)
		{
			writer.WriteAttributeString("saveSubsetFonts", bool_14 ? "1" : "0");
		}
		if (!bool_15)
		{
			writer.WriteAttributeString("autoCompressPictures", bool_15 ? "1" : "0");
		}
		if (uint_1 != 1)
		{
			writer.WriteAttributeString("bookmarkIdSeed", XmlConvert.ToString(uint_1));
		}
		if (class2255_0 != null)
		{
			class2255_0.vmethod_4("p", writer, "sldMasterIdLst");
		}
		if (class2242_0 != null)
		{
			class2242_0.vmethod_4("p", writer, "notesMasterIdLst");
		}
		if (class2236_0 != null)
		{
			class2236_0.vmethod_4("p", writer, "handoutMasterIdLst");
		}
		if (class2251_0 != null)
		{
			class2251_0.vmethod_4("p", writer, "sldIdLst");
		}
		if (class2258_0 != null)
		{
			class2258_0.vmethod_4("p", writer, "sldSz");
		}
		class1906_0.vmethod_4("p", writer, "notesSz");
		if (class1472_0 != null)
		{
			class1472_0.vmethod_4("p", writer, "smartTags");
		}
		if (class2234_0 != null)
		{
			class2234_0.vmethod_4("p", writer, "embeddedFontLst");
		}
		if (class1464_0 != null)
		{
			class1464_0.vmethod_4("p", writer, "custShowLst");
		}
		if (class1469_0 != null)
		{
			class1469_0.vmethod_4("p", writer, "photoAlbum");
		}
		if (class2232_0 != null)
		{
			class2232_0.vmethod_4("p", writer, "custDataLst");
		}
		if (class1465_0 != null)
		{
			class1465_0.vmethod_4("p", writer, "kinsoku");
		}
		if (class1958_0 != null)
		{
			class1958_0.vmethod_4("p", writer, "defaultTextStyle");
		}
		if (class2241_0 != null)
		{
			class2241_0.vmethod_4("p", writer, "modifyVerifier");
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2255 method_3()
	{
		if (class2255_0 != null)
		{
			throw new Exception("Only one <sldMasterIdLst> element can be added.");
		}
		class2255_0 = new Class2255();
		return class2255_0;
	}

	private void method_4(Class2255 _sldMasterIdLst)
	{
		class2255_0 = _sldMasterIdLst;
	}

	private Class2242 method_5()
	{
		if (class2242_0 != null)
		{
			throw new Exception("Only one <notesMasterIdLst> element can be added.");
		}
		class2242_0 = new Class2242();
		return class2242_0;
	}

	private void method_6(Class2242 _notesMasterIdLst)
	{
		class2242_0 = _notesMasterIdLst;
	}

	private Class2236 method_7()
	{
		if (class2236_0 != null)
		{
			throw new Exception("Only one <handoutMasterIdLst> element can be added.");
		}
		class2236_0 = new Class2236();
		return class2236_0;
	}

	private void method_8(Class2236 _handoutMasterIdLst)
	{
		class2236_0 = _handoutMasterIdLst;
	}

	private Class2251 method_9()
	{
		if (class2251_0 != null)
		{
			throw new Exception("Only one <sldIdLst> element can be added.");
		}
		class2251_0 = new Class2251();
		return class2251_0;
	}

	private void method_10(Class2251 _sldIdLst)
	{
		class2251_0 = _sldIdLst;
	}

	private Class2258 method_11()
	{
		if (class2258_0 != null)
		{
			throw new Exception("Only one <sldSz> element can be added.");
		}
		class2258_0 = new Class2258();
		return class2258_0;
	}

	private void method_12(Class2258 _sldSz)
	{
		class2258_0 = _sldSz;
	}

	private Class1447 method_13()
	{
		if (class1472_0 != null)
		{
			throw new Exception("Only one <smartTags> element can be added.");
		}
		class1472_0 = new Class1472();
		return class1472_0;
	}

	private void method_14(Class1447 _smartTags)
	{
		class1472_0 = (Class1472)_smartTags;
	}

	private Class2234 method_15()
	{
		if (class2234_0 != null)
		{
			throw new Exception("Only one <embeddedFontLst> element can be added.");
		}
		class2234_0 = new Class2234();
		return class2234_0;
	}

	private void method_16(Class2234 _embeddedFontLst)
	{
		class2234_0 = _embeddedFontLst;
	}

	private Class1447 method_17()
	{
		if (class1464_0 != null)
		{
			throw new Exception("Only one <custShowLst> element can be added.");
		}
		class1464_0 = new Class1464();
		return class1464_0;
	}

	private void method_18(Class1447 _custShowLst)
	{
		class1464_0 = (Class1464)_custShowLst;
	}

	private Class1447 method_19()
	{
		if (class1469_0 != null)
		{
			throw new Exception("Only one <photoAlbum> element can be added.");
		}
		class1469_0 = new Class1469();
		return class1469_0;
	}

	private void method_20(Class1447 _photoAlbum)
	{
		class1469_0 = (Class1469)_photoAlbum;
	}

	private Class2232 method_21()
	{
		if (class2232_0 != null)
		{
			throw new Exception("Only one <custDataLst> element can be added.");
		}
		class2232_0 = new Class2232();
		return class2232_0;
	}

	private void method_22(Class2232 _custDataLst)
	{
		class2232_0 = _custDataLst;
	}

	private Class1447 method_23()
	{
		if (class1465_0 != null)
		{
			throw new Exception("Only one <kinsoku> element can be added.");
		}
		class1465_0 = new Class1465();
		return class1465_0;
	}

	private void method_24(Class1447 _kinsoku)
	{
		class1465_0 = (Class1465)_kinsoku;
	}

	private Class1958 method_25()
	{
		if (class1958_0 != null)
		{
			throw new Exception("Only one <defaultTextStyle> element can be added.");
		}
		class1958_0 = new Class1958();
		return class1958_0;
	}

	private void method_26(Class1958 _defaultTextStyle)
	{
		class1958_0 = _defaultTextStyle;
	}

	private Class2241 method_27()
	{
		if (class2241_0 != null)
		{
			throw new Exception("Only one <modifyVerifier> element can be added.");
		}
		class2241_0 = new Class2241();
		return class2241_0;
	}

	private void method_28(Class2241 _modifyVerifier)
	{
		class2241_0 = _modifyVerifier;
	}

	private Class1885 method_29()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_30(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}
}
