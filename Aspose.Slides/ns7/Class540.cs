using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns28;
using ns32;
using ns33;
using ns4;

namespace ns7;

internal class Class540
{
	private const double double_0 = 2.9088820866572157E-07;

	internal static object[] object_0 = new object[30]
	{
		0,
		1,
		1,
		0,
		2,
		2,
		3,
		4,
		4,
		9,
		5,
		8,
		6,
		3,
		7,
		Enum113.const_10,
		8,
		Enum113.const_5,
		9,
		Enum113.const_13,
		10,
		Enum113.const_7,
		11,
		Enum113.const_6,
		12,
		Enum113.const_12,
		13,
		Enum113.const_14,
		16,
		Enum113.const_15
	};

	private static readonly Class1155 class1155_0 = new Class1155(Enum271.const_0, ShapeElementFillSource.NoFill, Enum271.const_1, ShapeElementFillSource.Shape, Enum271.const_2, ShapeElementFillSource.Lighten, Enum271.const_3, ShapeElementFillSource.LightenLess, Enum271.const_4, ShapeElementFillSource.Darken, Enum271.const_5, ShapeElementFillSource.DarkenLess);

	public static readonly Class886[] class886_0 = new Class886[0];

	private Class342 class342_0 = new Class342();

	internal Class342 PPTXUnsupportedProps => class342_0;

	internal Class341[] Adjustments
	{
		get
		{
			return PPTXUnsupportedProps.Adjustments;
		}
		set
		{
			PPTXUnsupportedProps.Adjustments = value;
		}
	}

	internal Class888[] ConnSites
	{
		get
		{
			return PPTXUnsupportedProps.ConnSites;
		}
		set
		{
			PPTXUnsupportedProps.ConnSites = value;
		}
	}

	internal Class886[] AdjustHandles
	{
		get
		{
			return PPTXUnsupportedProps.AdjustHandles;
		}
		set
		{
			PPTXUnsupportedProps.AdjustHandles = value;
		}
	}

	internal Class541[] GeomGuides
	{
		get
		{
			return PPTXUnsupportedProps.GeomGuides;
		}
		set
		{
			PPTXUnsupportedProps.GeomGuides = value;
		}
	}

	internal Class516[] Paths
	{
		get
		{
			return PPTXUnsupportedProps.Paths;
		}
		set
		{
			PPTXUnsupportedProps.Paths = value;
		}
	}

	internal Class887[] RectTopLeft
	{
		get
		{
			return PPTXUnsupportedProps.RectTopLeft;
		}
		set
		{
			PPTXUnsupportedProps.RectTopLeft = value;
		}
	}

	internal Class887[] RectBottomRight
	{
		get
		{
			return PPTXUnsupportedProps.RectBottomRight;
		}
		set
		{
			PPTXUnsupportedProps.RectBottomRight = value;
		}
	}

	internal ShapeType RawPreset
	{
		get
		{
			return PPTXUnsupportedProps.RawPreset;
		}
		set
		{
			PPTXUnsupportedProps.RawPreset = value;
		}
	}

	private Class342 Template
	{
		get
		{
			return PPTXUnsupportedProps.Template;
		}
		set
		{
			PPTXUnsupportedProps.Template = value;
		}
	}

	internal ShapeType Preset
	{
		get
		{
			return RawPreset;
		}
		set
		{
			if (RawPreset != value && value != 0)
			{
				if (RawPreset == ShapeType.Custom)
				{
					Adjustments = null;
					ConnSites = null;
					AdjustHandles = class886_0;
					GeomGuides = null;
					Paths = null;
					RectTopLeft = null;
					RectBottomRight = null;
				}
				RawPreset = value;
				Template = Class542.smethod_0(RawPreset);
				if (Template != null)
				{
					Adjustments = smethod_0(Template.Adjustments);
				}
			}
		}
	}

	public Class540(GeometryShape parent)
	{
		parent.PPTXUnsupportedProps.Geometry2DPPTXUnsupportedProps = PPTXUnsupportedProps;
	}

	internal ShapeElement[] CreateShapeElements(Shape parent, float x, float y, float width, float height)
	{
		Class342 @class = PPTXUnsupportedProps;
		if (RawPreset != 0)
		{
			@class = Template;
		}
		if (@class == null)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(new RectangleF(x, y, width, height));
			graphicsPath.StartFigure();
			graphicsPath.AddLine(x, y, x + width, y + height);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(x, y + height, x + width, y);
			return new ShapeElement[1]
			{
				new ShapeElement(parent, graphicsPath, Enum116.const_0, invisibleForDecoration: false, ShapeElementFillSource.NoFill, ShapeElementStrokeSource.NoStroke, null)
			};
		}
		Class516[] paths = @class.Paths;
		ShapeElement[] array = new ShapeElement[paths.Length];
		method_1(width * 12700f, height * 12700f, out var guideValueFlags, out var guideValues);
		for (int i = 0; i < paths.Length; i++)
		{
			array[i] = new ShapeElement(parent, paths[i].method_2(PPTXUnsupportedProps, guideValues, guideValueFlags, x * 12700f, y * 12700f, width * 12700f, height * 12700f, out var hasClosedFigures), Enum116.const_0, !paths[i].ExtrusionOk, (ShapeElementFillSource)class1155_0[paths[i].FillMode], paths[i].Stroke ? ShapeElementStrokeSource.Shape : ShapeElementStrokeSource.NoStroke, null);
			array[i].bool_1 = hasClosedFigures;
		}
		return array;
	}

	internal RectangleF method_0(IShape parent, float x, float y, float width, float height)
	{
		Class342 @class = PPTXUnsupportedProps;
		if (RawPreset != 0)
		{
			@class = Template;
		}
		if (@class == null)
		{
			return new RectangleF(x, y, width, height);
		}
		method_1(width * 12700f, height * 12700f, out var guideValueFlags, out var guideValues);
		float num = x;
		float num2 = x + width;
		float num3 = y;
		float num4 = y + height;
		if (@class.RectTopLeft != null)
		{
			num = (@class.method_0(guideValues, guideValueFlags, @class.RectTopLeft[0].X) + x * 12700f) / 12700f;
			num3 = (@class.method_0(guideValues, guideValueFlags, @class.RectTopLeft[0].Y) + y * 12700f) / 12700f;
		}
		if (@class.RectBottomRight != null)
		{
			num2 = (@class.method_0(guideValues, guideValueFlags, @class.RectBottomRight[0].X) + x * 12700f) / 12700f;
			num4 = (@class.method_0(guideValues, guideValueFlags, @class.RectBottomRight[0].Y) + y * 12700f) / 12700f;
		}
		return new RectangleF(num, num3, num2 - num, num4 - num3);
	}

	internal void method_1(float width, float height, out Class342.Enum164[] guideValueFlags, out double[] guideValues)
	{
		Class342 @class = PPTXUnsupportedProps;
		if (RawPreset != 0)
		{
			@class = Template;
		}
		Class541[] geomGuides = @class.GeomGuides;
		guideValues = new double[geomGuides.Length + 11];
		guideValueFlags = new Class342.Enum164[geomGuides.Length + 11];
		guideValueFlags[7] = Class342.Enum164.flag_1;
		guideValueFlags[8] = Class342.Enum164.flag_3;
		guideValueFlags[9] = Class342.Enum164.flag_2;
		guideValueFlags[10] = Class342.Enum164.flag_4;
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < 11; i++)
		{
			guideValueFlags[i] |= Class342.Enum164.flag_5;
		}
		guideValues[0] = 21600000.0;
		guideValues[1] = width;
		guideValues[2] = height;
		guideValues[3] = ((width > height) ? height : width);
		guideValues[4] = ((width > height) ? width : height);
		guideValues[5] = width / 2f;
		guideValues[6] = height / 2f;
		guideValues[7] = 0.0;
		guideValues[8] = 0.0;
		guideValues[9] = width;
		guideValues[10] = height;
		int num3 = 10;
		int num4 = -1;
		int num5 = -1;
		int num6 = -1;
		int num7 = -1;
		while (num3 > 0 && num < guideValues.Length)
		{
			num2 = num;
			num = guideValues.Length;
			num3 = 0;
			for (int j = Math.Max(num2, 11); j < guideValues.Length; j++)
			{
				if ((guideValueFlags[j] & Class342.Enum164.flag_5) == Class342.Enum164.flag_5)
				{
					continue;
				}
				Class541 class2 = geomGuides[j - 11];
				Class342.Enum164 geomRef;
				double num8 = method_2(guideValues, guideValueFlags, class2.Data1, out geomRef);
				Class342.Enum164 geomRef2;
				double num9 = method_2(guideValues, guideValueFlags, class2.Data2, out geomRef2);
				Class342.Enum164 geomRef3;
				double num10 = method_2(guideValues, guideValueFlags, class2.Data3, out geomRef3);
				if (!double.IsNaN(num8) && !double.IsNaN(num9) && !double.IsNaN(num10))
				{
					switch (class2.Operation)
					{
					case Enum113.const_0:
						guideValues[j] = num8 * num9 / num10;
						break;
					case Enum113.const_1:
						guideValues[j] = num8 + num9 - num10;
						break;
					case Enum113.const_2:
						guideValues[j] = (num8 + num9) / num10;
						break;
					case Enum113.const_3:
						guideValues[j] = ((num8 > 0.0) ? num9 : num10);
						break;
					case Enum113.const_4:
						guideValues[j] = Math.Abs(num8);
						break;
					case Enum113.const_5:
						guideValues[j] = Math.Atan2(num9, num8) / 2.9088820866572157E-07;
						break;
					case Enum113.const_6:
						guideValues[j] = num8 * Math.Cos(Math.Atan2(num10, num9));
						break;
					case Enum113.const_7:
						guideValues[j] = num8 * Math.Cos(num9 * 2.9088820866572157E-07);
						break;
					case Enum113.const_8:
						guideValues[j] = Math.Max(num8, num9);
						break;
					case Enum113.const_9:
						guideValues[j] = Math.Min(num8, num9);
						break;
					case Enum113.const_10:
						guideValues[j] = Math.Sqrt(num8 * num8 + num9 * num9 + num10 * num10);
						break;
					case Enum113.const_11:
						guideValues[j] = ((num8 > num9) ? num8 : ((num9 > num10) ? num10 : num9));
						break;
					case Enum113.const_12:
						guideValues[j] = num8 * Math.Sin(Math.Atan2(num10, num9));
						break;
					case Enum113.const_13:
						guideValues[j] = num8 * Math.Sin(num9 * 2.9088820866572157E-07);
						break;
					case Enum113.const_14:
						guideValues[j] = Math.Sqrt(num8);
						break;
					case Enum113.const_15:
						guideValues[j] = num8 * Math.Tan(num9 * 2.9088820866572157E-07);
						break;
					case Enum113.const_16:
						guideValues[j] = num8;
						break;
					}
					switch (class2.Name)
					{
					case "xl":
						if (guideValues[j] > guideValues[7] && guideValues[j] < guideValues[9])
						{
							num4 = j;
						}
						break;
					case "xt":
						if (guideValues[j] > guideValues[7] && guideValues[j] < guideValues[9])
						{
							num5 = j;
						}
						break;
					case "xr":
						if (guideValues[j] > guideValues[7] && guideValues[j] < guideValues[9])
						{
							num6 = j;
						}
						break;
					case "xb":
						if (guideValues[j] > guideValues[7] && guideValues[j] < guideValues[9])
						{
							num7 = j;
						}
						break;
					case "yl":
						if (num4 > -1 && guideValues[j] > guideValues[8] && guideValues[j] < guideValues[10])
						{
							guideValues[num4] = guideValues[7];
						}
						break;
					case "yt":
						if (num5 > -1 && guideValues[j] > guideValues[8] && guideValues[j] < guideValues[10])
						{
							guideValues[j] = guideValues[8];
						}
						break;
					case "yr":
						if (num6 > -1 && guideValues[j] > guideValues[8] && guideValues[j] < guideValues[10])
						{
							guideValues[num6] = guideValues[9];
						}
						break;
					case "yb":
						if (num7 > -1 && guideValues[j] > guideValues[8] && guideValues[j] < guideValues[10])
						{
							guideValues[j] = guideValues[10];
						}
						break;
					}
					guideValueFlags[j] = geomRef | geomRef2 | geomRef3 | Class342.Enum164.flag_5;
					num3++;
				}
				else if (j < num)
				{
					num = j;
				}
			}
		}
	}

	private double method_2(double[] guideValues, Class342.Enum164[] guideFlags, long coordinate, out Class342.Enum164 geomRef)
	{
		geomRef = Class342.Enum164.flag_0;
		if (coordinate > 27273042316900L)
		{
			return Adjustments[coordinate - 27273042316900L - 1L].RawValue;
		}
		if (coordinate < -27273042329600L)
		{
			int num = (int)(-27273042329600L - coordinate - 1L);
			if ((guideFlags[num] & Class342.Enum164.flag_5) == Class342.Enum164.flag_5)
			{
				geomRef = guideFlags[num];
				return guideValues[num];
			}
			return double.NaN;
		}
		return coordinate;
	}

	internal static Class341[] smethod_0(Class341[] template)
	{
		Class341[] array = new Class341[template.Length];
		for (int i = 0; i < template.Length; i++)
		{
			array[i] = new Class341(template[i]);
		}
		return array;
	}

	internal void method_3(Class421 polygonElement)
	{
		RawPreset = ShapeType.Custom;
		Adjustments = new Class341[0];
		ConnSites = null;
		AdjustHandles = class886_0;
		GeomGuides = new Class541[0];
		Paths = null;
		RectTopLeft = null;
		RectBottomRight = null;
		List<Class516> list = new List<Class516>();
		list.Add(new Class516(polygonElement.Points, Math.Abs(polygonElement.ViewBox.Right - polygonElement.ViewBox.Left), Math.Abs(polygonElement.ViewBox.Top - polygonElement.ViewBox.Bottom)));
		Paths = list.ToArray();
	}

	internal void method_4(Class419 pathElement)
	{
		RawPreset = ShapeType.Custom;
		Adjustments = new Class341[0];
		ConnSites = null;
		AdjustHandles = class886_0;
		GeomGuides = new Class541[0];
		Paths = null;
		RectTopLeft = null;
		RectBottomRight = null;
		string text = pathElement.DPath.Trim();
		List<Class516> list = new List<Class516>();
		if (text.Length > 0)
		{
			list.Add(new Class516(text.Trim(), Math.Abs(pathElement.ViewBox.Right - pathElement.ViewBox.Left), Math.Abs(pathElement.ViewBox.Top - pathElement.ViewBox.Bottom)));
		}
		Paths = list.ToArray();
	}

	internal void method_5(Class382 shape)
	{
		RawPreset = ShapeType.Custom;
		if (shape.Geometry == null)
		{
			return;
		}
		Adjustments = null;
		ConnSites = null;
		AdjustHandles = class886_0;
		GeomGuides = null;
		Paths = null;
		RectTopLeft = null;
		RectBottomRight = null;
		Adjustments = new Class341[shape.Geometry.Modifs.Count];
		int num = 0;
		foreach (KeyValuePair<string, string> modif in shape.Geometry.Modifs)
		{
			Adjustments[num] = new Class341(modif.Key, modif.Value);
			num++;
		}
		num = 0;
		List<Class541> list = new List<Class541>(shape.Geometry.Equation.Count);
		for (num = 0; num < shape.Geometry.FunctionOrder.Count; num++)
		{
			list.Add(null);
			list[num] = new Class541(shape.Geometry.FunctionOrder[num], shape.Geometry.Equation[shape.Geometry.FunctionOrder[num]], shape.Geometry.dictionary_5, list);
		}
		GeomGuides = list.ToArray();
		string text = shape.Geometry.Path.Trim();
		string[] array = text.Split('N');
		List<Class516> list2 = new List<Class516>();
		for (num = 0; num < array.Length; num++)
		{
			if (array[num].Length > 0)
			{
				list2.Add(new Class516(array[num], Math.Abs(shape.Geometry.ViewBox.Right - shape.Geometry.ViewBox.Left), Math.Abs(shape.Geometry.ViewBox.Top - shape.Geometry.ViewBox.Bottom), shape.Geometry.dictionary_5, list, shape.Geometry.FunctionSum));
			}
		}
		Paths = list2.ToArray();
		RectTopLeft = new Class887[1];
		RectBottomRight = new Class887[1];
		RectTopLeft[0] = new Class887("0", "0", shape.Geometry.dictionary_5, list);
		RectBottomRight[0] = new Class887("w", "h", shape.Geometry.dictionary_5, list);
	}

	internal void method_6(Class382 newShape)
	{
		Class392 @class = (Class392)newShape.method_35("enhanced-geometry", Class465.string_9);
		string[] array = new string[0];
		if (Adjustments != null)
		{
			array = new string[Adjustments.Length];
			int num = 0;
			Class341[] adjustments = Adjustments;
			foreach (Class341 class2 in adjustments)
			{
				if (!class2.Copy)
				{
					@class.SetAttribute("modifiers", "draw", XmlConvert.ToString(class2.RawValue));
					array[num++] = class2.Name;
				}
			}
		}
		if (Paths != null)
		{
			string text = "";
			Class516[] paths = Paths;
			foreach (Class516 class3 in paths)
			{
				text = text + class3.method_0(GeomGuides, Adjustments, array) + " N ";
			}
			@class.SetAttribute("enhanced-path", "draw", text);
		}
		@class.SetAttribute("viewBox", "svg", "0 0 " + Paths[0].Width + " " + Paths[0].Height);
		if (GeomGuides == null)
		{
			return;
		}
		for (int k = 0; k < GeomGuides.Length; k++)
		{
			Class541 class4 = GeomGuides[k];
			if (!class4.Autogenerated)
			{
				Class393 class5 = (Class393)@class.method_35("equation", Class465.string_9);
				class5.SetAttribute("name", class4.Name);
				class5.SetAttribute("formula", class4.method_0(GeomGuides, Adjustments, array));
			}
		}
	}
}
