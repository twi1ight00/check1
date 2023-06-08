using System;
using System.Collections.Generic;
using System.Xml;
using Aspose.Slides;
using ns24;
using ns32;
using ns56;

namespace ns18;

internal class Class954
{
	internal static readonly string[] string_0 = new string[11]
	{
		"c", "w", "h", "ss", "ls", "hc", "vc", "l", "t", "r",
		"b"
	};

	public static void smethod_0(IGeometryShape geometryShape, Class1921 spPrElementData)
	{
		if (spPrElementData.Geometry == null)
		{
			return;
		}
		Class281 pPTXUnsupportedProps = ((GeometryShape)geometryShape).PPTXUnsupportedProps;
		Class342 geometry2DPPTXUnsupportedProps = pPTXUnsupportedProps.Geometry2DPPTXUnsupportedProps;
		Dictionary<string, int> namesToIndexMap;
		switch (spPrElementData.Geometry.Name)
		{
		case "prstGeom":
		{
			Class1908 class2 = (Class1908)spPrElementData.Geometry.Object;
			geometry2DPPTXUnsupportedProps.RawPreset = class2.Prst;
			geometry2DPPTXUnsupportedProps.Template = Class542.smethod_0(class2.Prst);
			if (geometry2DPPTXUnsupportedProps.Template != null)
			{
				geometry2DPPTXUnsupportedProps.Adjustments = smethod_1(class2.AvLst, geometry2DPPTXUnsupportedProps.Template.Adjustments, out namesToIndexMap);
			}
			break;
		}
		case "custGeom":
		{
			Class1828 @class = (Class1828)spPrElementData.Geometry.Object;
			geometry2DPPTXUnsupportedProps.Adjustments = smethod_1(@class.AvLst, null, out namesToIndexMap);
			geometry2DPPTXUnsupportedProps.RawPreset = ShapeType.Custom;
			List<Class541> list = smethod_2(@class.GdLst, namesToIndexMap);
			geometry2DPPTXUnsupportedProps.ConnSites = smethod_3(@class.CxnLst, namesToIndexMap, list);
			geometry2DPPTXUnsupportedProps.AdjustHandles = smethod_4(@class.AhLst, namesToIndexMap, list);
			Class1851 rect = @class.Rect;
			if (rect != null)
			{
				geometry2DPPTXUnsupportedProps.RectTopLeft = new Class887[1];
				geometry2DPPTXUnsupportedProps.RectTopLeft[0] = new Class887(rect.L, rect.T, namesToIndexMap, list);
				geometry2DPPTXUnsupportedProps.RectBottomRight = new Class887[1];
				geometry2DPPTXUnsupportedProps.RectBottomRight[0] = new Class887(rect.R, rect.B, namesToIndexMap, list);
			}
			Class1896 pathLst = @class.PathLst;
			if (pathLst != null)
			{
				List<Class516> list2 = new List<Class516>();
				Class1894[] pathList = pathLst.PathList;
				foreach (Class1894 path2DElementData in pathList)
				{
					list2.Add(new Class516(path2DElementData, namesToIndexMap, list));
				}
				geometry2DPPTXUnsupportedProps.Paths = list2.ToArray();
			}
			geometry2DPPTXUnsupportedProps.GeomGuides = list.ToArray();
			break;
		}
		default:
			throw new Exception("Unknown element \"" + spPrElementData.Geometry.Name + "\"");
		}
	}

	internal static Class341[] smethod_1(Class1850 avLstElementData, Class341[] template, out Dictionary<string, int> namesToIndexMap)
	{
		namesToIndexMap = new Dictionary<string, int>();
		if (avLstElementData == null)
		{
			return new Class341[0];
		}
		Class1849[] gdList = avLstElementData.GdList;
		int num = 0;
		Class341[] array;
		if (template == null)
		{
			array = new Class341[gdList.Length];
			Class1849[] array2 = gdList;
			foreach (Class1849 @class in array2)
			{
				num = (namesToIndexMap[@class.Name] = num + 1);
			}
		}
		else
		{
			for (num = 0; num < template.Length; num++)
			{
				namesToIndexMap[template[num].Name] = num + 1;
			}
			Class1849[] array3 = gdList;
			foreach (Class1849 class2 in array3)
			{
				if (!namesToIndexMap.ContainsKey(class2.Name))
				{
					num = (namesToIndexMap[class2.Name] = num + 1);
				}
			}
			array = new Class341[num];
			for (int k = 0; k < template.Length; k++)
			{
				array[k] = new Class341(template[k]);
			}
		}
		Class1849[] array4 = gdList;
		foreach (Class1849 class3 in array4)
		{
			array[namesToIndexMap[class3.Name] - 1] = new Class341(class3.Name, (class3.Fmla != null) ? class3.Fmla : "val 0");
		}
		return array;
	}

	internal static List<Class541> smethod_2(Class1850 gdLstElementData, Dictionary<string, int> nameToIndexMap)
	{
		int num = 1;
		string[] array = string_0;
		foreach (string key in array)
		{
			nameToIndexMap[key] = -(num++);
		}
		if (gdLstElementData == null)
		{
			return new List<Class541>();
		}
		Class1849[] gdList = gdLstElementData.GdList;
		List<Class541> list = new List<Class541>(gdList.Length);
		Class1849[] array2 = gdList;
		foreach (Class1849 @class in array2)
		{
			nameToIndexMap[@class.Name] = -(num++);
			list.Add(null);
		}
		num = 0;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Class1849[] array3 = gdList;
		foreach (Class1849 class2 in array3)
		{
			string name = class2.Name;
			Class541 class3 = new Class541(name, (class2.Fmla != null) ? class2.Fmla : "val 0", nameToIndexMap, list);
			list[num++] = class3;
			nameToIndexMap[name] = -(num + 11);
			if (dictionary.ContainsKey(name))
			{
				int num2 = 0;
				string text = name;
				do
				{
					text = $"{text}dup{num2++}";
				}
				while (dictionary.ContainsKey(text));
				class3.Name = text;
			}
			dictionary[class3.Name] = class3.Name;
		}
		return list;
	}

	internal static Class888[] smethod_3(Class1824 cxnLstElementData, Dictionary<string, int> namesToIndexMap, List<Class541> geomGuides)
	{
		if (cxnLstElementData == null)
		{
			return null;
		}
		Class1823[] cxnList = cxnLstElementData.CxnList;
		Class888[] array = new Class888[cxnList.Length];
		int num = 0;
		Class1823[] array2 = cxnList;
		foreach (Class1823 @class in array2)
		{
			Class1782 pos = @class.Pos;
			string x = pos.X;
			string y = pos.Y;
			string ang = @class.Ang;
			array[num++] = new Class888(x, y, ang, namesToIndexMap, geomGuides);
		}
		return array;
	}

	internal static Class886[] smethod_4(Class1783 ahLstElementData, Dictionary<string, int> namesToIndexMap, List<Class541> geomGuides)
	{
		if (ahLstElementData == null)
		{
			return null;
		}
		Class886[] array = new Class886[ahLstElementData.AdjustHandleList.Length];
		for (int i = 0; i < ahLstElementData.AdjustHandleList.Length; i++)
		{
			Class2605 @class = ahLstElementData.AdjustHandleList[i];
			switch (@class.Name)
			{
			case "ahPolar":
			{
				Class1905 class3 = (Class1905)@class.Object;
				string x = class3.Pos.X;
				string y = class3.Pos.Y;
				string gdRefX = class3.GdRefR;
				string gdRefY = class3.GdRefAng;
				string minX = class3.MinR;
				string minY = class3.MinAng;
				string maxX = class3.MaxR;
				string maxY = class3.MaxAng;
				array[i] = new Class886(polar: true, gdRefX, minX, maxX, gdRefY, minY, maxY, x, y, namesToIndexMap, geomGuides);
				break;
			}
			case "ahXY":
			{
				Class1981 class2 = (Class1981)@class.Object;
				string x = class2.Pos.X;
				string y = class2.Pos.Y;
				string gdRefX = class2.GdRefX;
				string gdRefY = class2.GdRefY;
				string minX = class2.MinX;
				string minY = class2.MinY;
				string maxX = class2.MaxX;
				string maxY = class2.MaxY;
				array[i] = new Class886(polar: false, gdRefX, minX, maxX, gdRefY, minY, maxY, x, y, namesToIndexMap, geomGuides);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + @class.Name + "\"");
			}
		}
		return array;
	}

	public static void smethod_5(IGeometryShape geometryShape, Class1921 spPrElementData)
	{
		if (geometryShape.ShapeType == ShapeType.NotDefined)
		{
			return;
		}
		Class281 pPTXUnsupportedProps = ((GeometryShape)geometryShape).PPTXUnsupportedProps;
		Class342 geometry2DPPTXUnsupportedProps = pPTXUnsupportedProps.Geometry2DPPTXUnsupportedProps;
		Class541[] geomGuides = geometry2DPPTXUnsupportedProps.GeomGuides;
		Class341[] adjustments = geometry2DPPTXUnsupportedProps.Adjustments;
		Class886[] adjustHandles = geometry2DPPTXUnsupportedProps.AdjustHandles;
		Class888[] connSites = geometry2DPPTXUnsupportedProps.ConnSites;
		if (geometryShape.ShapeType == ShapeType.Custom)
		{
			Class1828 @class = (Class1828)spPrElementData.delegate2773_2("custGeom").Object;
			smethod_6(adjustments, @class.delegate1429_0);
			smethod_8(geomGuides, adjustments, @class.delegate1429_1);
			smethod_9(adjustHandles, geomGuides, adjustments, @class.delegate1228_0);
			smethod_10(connSites, geomGuides, adjustments, @class.delegate1351_0);
			Class887[] rectTopLeft = geometry2DPPTXUnsupportedProps.RectTopLeft;
			if (rectTopLeft != null)
			{
				Class1851 class2 = @class.delegate1432_0();
				class2.L = smethod_11(rectTopLeft[0].X, geomGuides, adjustments);
				class2.T = smethod_11(rectTopLeft[0].Y, geomGuides, adjustments);
				class2.R = smethod_11(geometry2DPPTXUnsupportedProps.RectBottomRight[0].X, geomGuides, adjustments);
				class2.B = smethod_11(geometry2DPPTXUnsupportedProps.RectBottomRight[0].Y, geomGuides, adjustments);
			}
			if (geometry2DPPTXUnsupportedProps.Paths != null)
			{
				Class516[] paths = geometry2DPPTXUnsupportedProps.Paths;
				foreach (Class516 path in paths)
				{
					Class972.smethod_0(path, @class.PathLst, geomGuides, adjustments);
				}
			}
		}
		else
		{
			Class1908 class3 = (Class1908)spPrElementData.delegate2773_2("prstGeom").Object;
			smethod_7(adjustments, class3.delegate1429_0());
			class3.Prst = geometry2DPPTXUnsupportedProps.RawPreset;
		}
	}

	internal static void smethod_6(Class341[] adjustments, Class1850.Delegate1429 addAvLst)
	{
		if (adjustments != null && adjustments.Length != 0)
		{
			smethod_7(adjustments, addAvLst());
		}
	}

	internal static void smethod_7(Class341[] adjustments, Class1850 avLstElementData)
	{
		if (adjustments == null || adjustments.Length == 0)
		{
			return;
		}
		foreach (Class341 @class in adjustments)
		{
			if (!@class.Copy)
			{
				Class1849 class2 = avLstElementData.delegate1426_0();
				class2.Name = @class.Name;
				class2.Fmla = "val " + XmlConvert.ToString(@class.RawValue);
			}
		}
	}

	internal static void smethod_8(Class541[] geometryGuides, Class341[] adjustments, Class1850.Delegate1429 addGdLst)
	{
		int num = 0;
		if (geometryGuides != null)
		{
			for (int i = 0; i < geometryGuides.Length; i++)
			{
				if (!geometryGuides[i].Autogenerated)
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			return;
		}
		Class1850 @class = addGdLst();
		foreach (Class541 class2 in geometryGuides)
		{
			if (!class2.Autogenerated)
			{
				Class1849 class3 = @class.delegate1426_0();
				class3.Name = class2.Name;
				class3.Fmla = Class955.smethod_0(class2, geometryGuides, adjustments);
			}
		}
	}

	internal static void smethod_9(Class886[] adjustHandles, Class541[] geometryGuides, Class341[] adjustments, Class1783.Delegate1228 addAhLst)
	{
		if (adjustHandles == null || adjustHandles.Length == 0)
		{
			return;
		}
		Class1783 @class = addAhLst();
		foreach (Class886 class2 in adjustHandles)
		{
			if (class2.bool_0)
			{
				Class1905 class3 = (Class1905)@class.delegate2773_0("ahPolar").Object;
				class3.GdRefR = smethod_11(class2.long_0, geometryGuides, adjustments);
				class3.GdRefAng = smethod_11(class2.long_3, geometryGuides, adjustments);
				class3.MinR = smethod_11(class2.long_1, geometryGuides, adjustments);
				class3.MinAng = smethod_11(class2.long_4, geometryGuides, adjustments);
				class3.MaxR = smethod_11(class2.long_2, geometryGuides, adjustments);
				class3.MaxAng = smethod_11(class2.long_5, geometryGuides, adjustments);
				class3.Pos.X = smethod_11(class2.class887_0.X, geometryGuides, adjustments);
				class3.Pos.Y = smethod_11(class2.class887_0.Y, geometryGuides, adjustments);
			}
			else
			{
				Class1981 class4 = (Class1981)@class.delegate2773_0("ahXY").Object;
				class4.GdRefX = smethod_11(class2.long_0, geometryGuides, adjustments);
				class4.GdRefY = smethod_11(class2.long_3, geometryGuides, adjustments);
				class4.MinX = smethod_11(class2.long_1, geometryGuides, adjustments);
				class4.MinY = smethod_11(class2.long_4, geometryGuides, adjustments);
				class4.MaxX = smethod_11(class2.long_2, geometryGuides, adjustments);
				class4.MaxY = smethod_11(class2.long_5, geometryGuides, adjustments);
				class4.Pos.X = smethod_11(class2.class887_0.X, geometryGuides, adjustments);
				class4.Pos.Y = smethod_11(class2.class887_0.Y, geometryGuides, adjustments);
			}
		}
	}

	internal static void smethod_10(Class888[] connSites, Class541[] geometryGuides, Class341[] adjustments, Class1824.Delegate1351 addCxnLst)
	{
		if (connSites != null && connSites.Length != 0)
		{
			Class1824 @class = addCxnLst();
			foreach (Class888 class2 in connSites)
			{
				Class1823 class3 = @class.delegate1348_0();
				class3.Pos.X = smethod_11(class2.Pos.X, geometryGuides, adjustments);
				class3.Pos.Y = smethod_11(class2.Pos.Y, geometryGuides, adjustments);
				class3.Ang = smethod_11(class2.Direction, geometryGuides, adjustments);
			}
		}
	}

	internal static string smethod_11(long value, Class541[] geomGuides, Class341[] values)
	{
		if (value < -27273042329600L)
		{
			if (value <= -27273042329612L)
			{
				return geomGuides[-27273042329612L - value].Name;
			}
			return string_0[-27273042329601L - value];
		}
		if (value <= 27273042316900L)
		{
			return XmlConvert.ToString(value);
		}
		if (value == long.MaxValue)
		{
			return "";
		}
		return values[value - 27273042316900L - 1L].Name;
	}
}
