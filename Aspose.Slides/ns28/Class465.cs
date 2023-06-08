using System.Xml;

namespace ns28;

internal class Class465 : Class461
{
	private Class413 class413_0;

	internal static Class482 class482_0;

	internal static readonly string string_0;

	internal static readonly string string_1;

	internal static readonly string string_2;

	internal static readonly string string_3;

	internal static readonly string string_4;

	internal static readonly string string_5;

	internal static readonly string string_6;

	internal static readonly string string_7;

	internal static readonly string string_8;

	internal static readonly string string_9;

	internal static readonly string string_10;

	internal static readonly string string_11;

	internal static readonly string string_12;

	internal static readonly string string_13;

	internal static readonly string string_14;

	internal static readonly string string_15;

	internal static readonly string string_16;

	internal static readonly string string_17;

	internal static readonly string string_18;

	internal static readonly string string_19;

	internal static readonly string string_20;

	internal static readonly string string_21;

	internal static readonly string string_22;

	internal Class410[] MasterPages
	{
		get
		{
			XmlNodeList elementsByTagName = GetElementsByTagName("master-page", string_6);
			Class410[] array = new Class410[elementsByTagName.Count];
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				array[i] = (Class410)elementsByTagName.Item(i);
			}
			return array;
		}
	}

	internal float[] SlideSize
	{
		get
		{
			float[] array = new float[3] { 0f, 0f, 0f };
			XmlNodeList elementsByTagName = GetElementsByTagName("page-layout-properties", string_6);
			string text = "";
			Class410 @class = MasterPages[0];
			if (@class != null)
			{
				text = @class.PageLayoutNameStr;
			}
			foreach (Class414 item in elementsByTagName)
			{
				string name = (item.ParentNode as Class413).Name;
				if (name == text)
				{
					array[0] = (float)item.PageWidth;
					array[1] = (float)item.PageHeight;
					if (item.PrintOrientation == Enum66.const_1)
					{
						array[2] = 1f;
					}
					return array;
				}
			}
			array[0] = 793.75f;
			array[1] = 595.25f;
			array[2] = 0f;
			return array;
		}
	}

	protected override Class482 ElementsFactory => class482_0;

	internal Class369 MasterStyles => method_0("master-styles", string_0);

	internal Class369 AutomaticStyles => method_0("automatic-styles", string_0);

	internal Class369 Styles => method_0("styles", string_0);

	static Class465()
	{
		string_0 = "urn:oasis:names:tc:opendocument:xmlns:office:1.0";
		string_1 = "http://www.w3.org/1999/xlink";
		string_2 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";
		string_3 = "http://openoffice.org/2004/office";
		string_4 = "urn:oasis:names:tc:opendocument:xmlns:smil-compatible:1.0";
		string_5 = "urn:oasis:names:tc:opendocument:xmlns:animation:1.0";
		string_6 = "urn:oasis:names:tc:opendocument:xmlns:style:1.0";
		string_7 = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";
		string_8 = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";
		string_9 = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";
		string_10 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";
		string_11 = "http://purl.org/dc/elements/1.1/";
		string_12 = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0";
		string_13 = "urn:oasis:names:tc:opendocument:xmlns:datastyle:1.0";
		string_14 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";
		string_15 = "urn:oasis:names:tc:opendocument:xmlns:chart:1.0";
		string_16 = "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0";
		string_17 = "http://www.w3.org/1998/Math/MathML";
		string_18 = "urn:oasis:names:tc:opendocument:xmlns:form:1.0";
		string_19 = "urn:oasis:names:tc:opendocument:xmlns:script:1.0";
		string_20 = "http://openoffice.org/2004/writer";
		string_21 = "http://openoffice.org/2004/calc";
		string_22 = "http://www.w3.org/2001/xml-events";
		class482_0 = new Class482(string_0);
		class482_0.Add(string_0, Class438.string_0, typeof(Class438));
		class482_0.Add(string_6, Class437.string_0, typeof(Class437));
		class482_0.Add(string_6, Class440.string_0, typeof(Class440));
		class482_0.Add(string_6, Class450.string_0, typeof(Class450));
		class482_0.Add(string_6, Class451.string_0, typeof(Class451));
		class482_0.Add(string_6, Class441.string_0, typeof(Class441));
		class482_0.Add(string_6, Class375.string_0, typeof(Class375));
		class482_0.Add(string_6, Class376.string_0, typeof(Class376));
		class482_0.Add(string_6, Class433.string_0, typeof(Class433));
		class482_0.Add(string_6, Class454.string_0, typeof(Class454));
		class482_0.Add(string_6, Class453.string_0, typeof(Class453));
		class482_0.Add(string_6, Class432.string_0, typeof(Class432));
		class482_0.Add(string_6, Class371.string_0, typeof(Class371));
		class482_0.Add(string_6, Class377.string_0, typeof(Class377));
		class482_0.Add(string_6, Class390.string_0, typeof(Class390));
		class482_0.Add(string_6, Class457.string_1, typeof(Class457));
		class482_0.Add(string_6, Class418.string_0, typeof(Class418));
		class482_0.Add(string_6, Class397.string_3, typeof(Class397));
		class482_0.Add(string_7, Class406.string_1, typeof(Class406));
		class482_0.Add(string_7, Class404.string_0, typeof(Class404));
		class482_0.Add(string_6, Class403.string_1, typeof(Class403));
		class482_0.Add(string_9, Class396.string_0, typeof(Class396));
		class482_0.Add(string_9, Class399.string_0, typeof(Class399));
		class482_0.Add(string_9, Class394.string_0, typeof(Class394));
		class482_0.Add(string_9, Class436.string_0, typeof(Class436));
		class482_0.Add(string_6, Class383.string_0, typeof(Class383));
		class482_0.Add(string_8, Class452.string_0, typeof(Class452));
		class482_0.Add(string_8, Class439.string_0, typeof(Class439));
		class482_0.Add(string_8, Class442.string_0, typeof(Class442));
		class482_0.Add(string_8, Class443.string_0, typeof(Class443));
		class482_0.Add(string_8, Class444.string_0, typeof(Class444));
		class482_0.Add(string_8, Class445.string_0, typeof(Class445));
		class482_0.Add(string_8, Class446.string_0, typeof(Class446));
		class482_0.Add(string_8, Class447.string_0, typeof(Class447));
		class482_0.Add(string_8, Class448.string_0, typeof(Class448));
		class482_0.Add(string_8, Class449.string_0, typeof(Class449));
		class482_0.Add(string_9, Class386.string_0, typeof(Class386));
		class482_0.Add(string_9, Class384.string_0, typeof(Class384));
		class482_0.Add(string_6, Class428.string_0, typeof(Class428));
		class482_0.Add(string_2, Class420.string_0, typeof(Class420));
		class482_0.Add(string_6, Class387.string_0, typeof(Class387));
		class482_0.Add(string_6, Class410.string_0, typeof(Class410));
		class482_0.Add(string_6, Class413.string_0, typeof(Class413));
		class482_0.Add(string_6, Class414.string_0, typeof(Class414));
		class482_0.Add(string_9, Class401.string_0, typeof(Class401));
		class482_0.Add(string_9, Class400.string_0, typeof(Class400));
		class482_0.Add(string_9, Class389.string_0, typeof(Class389));
		class482_0.Add(string_7, Class456.string_1, typeof(Class456));
		class482_0.Add(string_2, Class424.string_0, typeof(Class424));
		class482_0.Add(string_2, Class426.string_0, typeof(Class426));
		class482_0.Add(string_2, Class425.string_0, typeof(Class425));
		class482_0.Add(string_7, Class415.string_0, typeof(Class415));
		class482_0.Add(string_9, Class388.string_0, typeof(Class388));
		class482_0.Add(string_7, Class455.string_0, typeof(Class455));
		class482_0.Add(string_9, Class382.string_0, typeof(Class382));
		class482_0.Add(string_9, Class392.string_1, typeof(Class392));
		class482_0.Add(string_9, Class393.string_0, typeof(Class393));
		class482_0.Add(string_9, Class409.string_0, typeof(Class409));
		class482_0.Add(string_9, Class402.string_0, typeof(Class402));
		class482_0.Add(string_9, Class430.string_0, typeof(Class430));
		class482_0.Add(string_9, Class391.string_0, typeof(Class391));
		class482_0.Add(string_9, Class374.string_0, typeof(Class374));
		class482_0.Add(string_9, Class422.string_0, typeof(Class422));
		class482_0.Add(string_9, Class421.string_0, typeof(Class421));
		class482_0.Add(string_9, Class419.string_0, typeof(Class419));
		class482_0.Add(string_9, Class395.string_1, typeof(Class395));
		class482_0.Add(string_7, Class458.string_1, typeof(Class458));
		class482_0.Add(string_7, Class405.string_0, typeof(Class405));
		class482_0.Add(string_7, Class435.string_0, typeof(Class435));
	}

	public Class465(Class476 package)
		: base(package)
	{
	}

	internal Class394 method_2(string imgName)
	{
		XmlNodeList elementsByTagName = GetElementsByTagName("fill-image", string_9);
		foreach (Class394 item in elementsByTagName)
		{
			if (item.Name == imgName)
			{
				return item;
			}
		}
		return null;
	}

	internal void method_3(string imgName, string href)
	{
		Class394 @class = (Class394)Styles.method_35("fill-image", string_9);
		@class.Name = imgName;
		@class.Href = href;
	}

	internal Class396 method_4(string gradName)
	{
		Class396 @class = (Class396)Styles.method_35("gradient", string_9);
		@class.Name = gradName;
		return @class;
	}

	internal Class396 method_5(string gradientName)
	{
		XmlNodeList elementsByTagName = GetElementsByTagName("gradient", string_9);
		foreach (Class396 item in elementsByTagName)
		{
			if (item.Name == gradientName)
			{
				return item;
			}
		}
		return null;
	}

	internal Class399 method_6(string hatchName)
	{
		Class399 @class = (Class399)Styles.method_35("hatch", string_9);
		@class.Name = hatchName;
		return @class;
	}

	internal Class399 method_7(string hatchName)
	{
		XmlNodeList elementsByTagName = GetElementsByTagName("hatch", string_9);
		foreach (Class399 item in elementsByTagName)
		{
			if (item.Name == hatchName)
			{
				return item;
			}
		}
		return null;
	}

	internal Class409 method_8(string markerName)
	{
		XmlNodeList elementsByTagName = GetElementsByTagName("marker", string_9);
		foreach (Class409 item in elementsByTagName)
		{
			if (item.Name == markerName)
			{
				return item;
			}
		}
		return null;
	}

	internal Class409 method_9(string markerName)
	{
		Class409 @class = (Class409)Styles.method_35("marker", string_9);
		@class.Name = markerName;
		return @class;
	}

	internal Class409 method_10(string path, string viewbox, string name)
	{
		foreach (XmlNode childNode in ChildNodes)
		{
			if (childNode is Class409 @class && @class.LocalName == "marker" && @class.NamespaceURI == string_9 && @class.D == path && @class.ViewBox != viewbox)
			{
				return @class;
			}
		}
		Class409 class2 = (Class409)Styles.method_35("marker", string_9);
		class2.D = path;
		class2.ViewBox = viewbox;
		class2.Name = name;
		return class2;
	}

	internal Class436 method_11(string hatchName)
	{
		XmlNodeList elementsByTagName = GetElementsByTagName("stroke-dash", string_9);
		foreach (Class436 item in elementsByTagName)
		{
			if (item.Name == hatchName)
			{
				return item;
			}
		}
		return null;
	}

	internal Class436 method_12(string gradName)
	{
		Class436 @class = (Class436)Styles.method_35("stroke-dash", string_9);
		@class.Name = gradName;
		return @class;
	}

	internal Class410 method_13(string name)
	{
		Class410 @class = (Class410)MasterStyles.method_35("master-page", string_6);
		@class.Name = name;
		if (class413_0 != null)
		{
			@class.PageLayoutName = class413_0;
		}
		return @class;
	}

	internal void method_14(float width, float height, int orient)
	{
		Class413 @class = (Class413)AutomaticStyles.method_35("page-layout", string_6);
		@class.Name = "PM1";
		Class414 class2 = (Class414)@class.method_35("page-layout-properties", string_6);
		Class413 class3 = (Class413)AutomaticStyles.method_35("page-layout", string_6);
		class3.Name = "PM2";
		Class414 class4 = (Class414)class3.method_35("page-layout-properties", string_6);
		if (orient == 0)
		{
			class2.PageWidth = width;
			class2.PageHeight = height;
			class4.PageWidth = height;
			class4.PageHeight = width;
			class413_0 = @class;
		}
		else
		{
			class4.PageWidth = width;
			class4.PageHeight = height;
			class2.PageWidth = height;
			class2.PageHeight = width;
			class413_0 = class3;
		}
		class2.PrintOrientation = Enum66.const_0;
		class4.PrintOrientation = Enum66.const_1;
	}
}
