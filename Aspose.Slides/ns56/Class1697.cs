using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1697 : Class1351
{
	public delegate Class1697 Delegate970();

	public delegate void Delegate971(Class1697 elementData);

	public delegate void Delegate972(Class1697 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = true;

	public const bool bool_3 = true;

	public const bool bool_4 = true;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = true;

	public const bool bool_8 = true;

	public const bool bool_9 = true;

	public const bool bool_10 = true;

	public const uint uint_0 = 64u;

	public const uint uint_1 = 100u;

	public const uint uint_2 = 0u;

	public const uint uint_3 = 0u;

	public const uint uint_4 = 0u;

	public Class1611.Delegate712 delegate712_0;

	public Class1611.Delegate714 delegate714_0;

	public Class1679.Delegate916 delegate916_0;

	public Class1679.Delegate917 delegate917_0;

	public Class1636.Delegate787 delegate787_0;

	public Class1636.Delegate788 delegate788_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private Enum239 enum239_0;

	private string string_0;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private uint uint_9;

	private uint uint_10;

	private Class1611 class1611_0;

	private List<Class1679> list_0;

	private List<Class1636> list_1;

	private Class1502 class1502_0;

	public static readonly Enum239 enum239_1 = Class2406.smethod_0("normal");

	public bool WindowProtection
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

	public bool ShowFormulas
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

	public bool ShowGridLines
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

	public bool ShowRowColHeaders
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

	public bool ShowZeros
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

	public bool RightToLeft
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public bool TabSelected
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	public bool ShowRuler
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public bool ShowOutlineSymbols
	{
		get
		{
			return bool_19;
		}
		set
		{
			bool_19 = value;
		}
	}

	public bool DefaultGridColor
	{
		get
		{
			return bool_20;
		}
		set
		{
			bool_20 = value;
		}
	}

	public bool ShowWhiteSpace
	{
		get
		{
			return bool_21;
		}
		set
		{
			bool_21 = value;
		}
	}

	public Enum239 View
	{
		get
		{
			return enum239_0;
		}
		set
		{
			enum239_0 = value;
		}
	}

	public string TopLeftCell
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

	public uint ColorId
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

	public uint ZoomScale
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

	public uint ZoomScaleNormal
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

	public uint ZoomScaleSheetLayoutView
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

	public uint ZoomScalePageLayoutView
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

	public uint WorkbookViewId
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

	public Class1611 Pane => class1611_0;

	public Class1679[] SelectionList => list_0.ToArray();

	public Class1636[] PivotSelectionList => list_1.ToArray();

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
				switch (reader.LocalName)
				{
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "pivotSelection":
				{
					Class1636 item2 = new Class1636(reader);
					list_1.Add(item2);
					break;
				}
				case "selection":
				{
					Class1679 item = new Class1679(reader);
					list_0.Add(item);
					break;
				}
				case "pane":
					class1611_0 = new Class1611(reader);
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
				case "windowProtection":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showFormulas":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showGridLines":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showRowColHeaders":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showZeros":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rightToLeft":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "tabSelected":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showRuler":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showOutlineSymbols":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "defaultGridColor":
					bool_20 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showWhiteSpace":
					bool_21 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "view":
					enum239_0 = Class2406.smethod_0(reader.Value);
					break;
				case "topLeftCell":
					string_0 = reader.Value;
					break;
				case "colorId":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "zoomScale":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "zoomScaleNormal":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "zoomScaleSheetLayoutView":
					uint_8 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "zoomScalePageLayoutView":
					uint_9 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "workbookViewId":
					uint_10 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1697(XmlReader reader)
		: base(reader)
	{
	}

	public Class1697()
	{
	}

	protected override void vmethod_1()
	{
		bool_11 = false;
		bool_12 = false;
		bool_13 = true;
		bool_14 = true;
		bool_15 = true;
		bool_16 = false;
		bool_17 = false;
		bool_18 = true;
		bool_19 = true;
		bool_20 = true;
		bool_21 = true;
		enum239_0 = enum239_1;
		uint_5 = 64u;
		uint_6 = 100u;
		uint_7 = 0u;
		uint_8 = 0u;
		uint_9 = 0u;
		list_0 = new List<Class1679>();
		list_1 = new List<Class1636>();
	}

	protected override void vmethod_2()
	{
		delegate712_0 = method_3;
		delegate714_0 = method_4;
		delegate916_0 = method_5;
		delegate917_0 = method_6;
		delegate787_0 = method_7;
		delegate788_0 = method_8;
		delegate385_0 = method_9;
		delegate387_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_11)
		{
			writer.WriteAttributeString("windowProtection", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("showFormulas", bool_12 ? "1" : "0");
		}
		if (!bool_13)
		{
			writer.WriteAttributeString("showGridLines", bool_13 ? "1" : "0");
		}
		if (!bool_14)
		{
			writer.WriteAttributeString("showRowColHeaders", bool_14 ? "1" : "0");
		}
		if (!bool_15)
		{
			writer.WriteAttributeString("showZeros", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("rightToLeft", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("tabSelected", bool_17 ? "1" : "0");
		}
		if (!bool_18)
		{
			writer.WriteAttributeString("showRuler", bool_18 ? "1" : "0");
		}
		if (!bool_19)
		{
			writer.WriteAttributeString("showOutlineSymbols", bool_19 ? "1" : "0");
		}
		if (!bool_20)
		{
			writer.WriteAttributeString("defaultGridColor", bool_20 ? "1" : "0");
		}
		if (!bool_21)
		{
			writer.WriteAttributeString("showWhiteSpace", bool_21 ? "1" : "0");
		}
		if (enum239_0 != enum239_1)
		{
			writer.WriteAttributeString("view", Class2406.smethod_1(enum239_0));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("topLeftCell", string_0);
		}
		if (uint_5 != 64)
		{
			writer.WriteAttributeString("colorId", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != 100)
		{
			writer.WriteAttributeString("zoomScale", XmlConvert.ToString(uint_6));
		}
		if (uint_7 != 0)
		{
			writer.WriteAttributeString("zoomScaleNormal", XmlConvert.ToString(uint_7));
		}
		if (uint_8 != 0)
		{
			writer.WriteAttributeString("zoomScaleSheetLayoutView", XmlConvert.ToString(uint_8));
		}
		if (uint_9 != 0)
		{
			writer.WriteAttributeString("zoomScalePageLayoutView", XmlConvert.ToString(uint_9));
		}
		writer.WriteAttributeString("workbookViewId", XmlConvert.ToString(uint_10));
		if (class1611_0 != null)
		{
			class1611_0.vmethod_4("ssml", writer, "pane");
		}
		foreach (Class1679 item in list_0)
		{
			item.vmethod_4("ssml", writer, "selection");
		}
		foreach (Class1636 item2 in list_1)
		{
			item2.vmethod_4("ssml", writer, "pivotSelection");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1611 method_3()
	{
		if (class1611_0 != null)
		{
			throw new Exception("Only one <pane> element can be added.");
		}
		class1611_0 = new Class1611();
		return class1611_0;
	}

	private void method_4(Class1611 _pane)
	{
		class1611_0 = _pane;
	}

	private Class1679 method_5()
	{
		Class1679 @class = new Class1679();
		list_0.Add(@class);
		return @class;
	}

	private void method_6(Class1679 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1636 method_7()
	{
		Class1636 @class = new Class1636();
		list_1.Add(@class);
		return @class;
	}

	private void method_8(Class1636 elementData)
	{
		list_1.Add(elementData);
	}

	private Class1502 method_9()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_10(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
