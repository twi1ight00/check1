using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using ns16;
using ns18;
using ns56;

namespace ns8;

internal class Class849
{
	private readonly Class135 class135_0;

	private readonly SmartArt smartArt_0;

	private readonly Class837 class837_0;

	private readonly List<Class837> list_0;

	private readonly GroupShape groupShape_0;

	private Struct48 struct48_0;

	public Class135 RootLayout => class135_0;

	public SmartArt Target => smartArt_0;

	public GroupShape RootShape => groupShape_0;

	public Struct48 TargetSize => struct48_0;

	public Class849(SmartArt target, Class2171 rootLayout, Class836 rootData, Class1341 deserializationContext)
	{
		smartArt_0 = target;
		class135_0 = (Class135)Class116.smethod_0(this, rootLayout, null);
		RootLayout.vmethod_0(null, rootData);
		class837_0 = RootLayout.Points[0];
		class837_0.ConnectedWith.Add(rootData);
		list_0 = new List<Class837>();
		smethod_1(class837_0, list_0);
		groupShape_0 = new GroupShape(Target.Slide);
		groupShape_0.shapeCollection_0 = (ShapeCollection)Target.Slide.Shapes;
		ShapeCollection shapeCollection = (ShapeCollection)groupShape_0.Shapes;
		List<Class851> list = method_6();
		foreach (Class851 item in list)
		{
			shapeCollection.Add(item.Shape.AutoShapeInternal);
			Class1073 @class = ((item.Target.ConnectedWith.Count > 0) ? item.Target.ConnectedWith[0].DataPoint : item.Target.DataPoint);
			@class.method_0(item.Shape);
			ShapeType shapeType = item.Target.DataPoint.ShapeType;
			if (shapeType != ShapeType.NotDefined)
			{
				item.Shape.AutoShapeInternal.ShapeType = shapeType;
			}
		}
		method_7(list);
		method_5();
	}

	public void method_0(Class841 output)
	{
		class837_0.method_0(output);
	}

	public void method_1(Class840 output)
	{
		class837_0.vmethod_0(output);
	}

	public void method_2(SmartArtNode docRoot)
	{
		docRoot.method_0(list_0);
	}

	public Class837 method_3(string id)
	{
		foreach (Class837 item in list_0)
		{
			if (item is Class837 @class && @class.ModelId == id)
			{
				return @class;
			}
		}
		return null;
	}

	public void method_4()
	{
		struct48_0 = new Struct48(Target.Width, Target.Height);
		class837_0.method_40();
		class837_0.method_22(Enum305.const_62, TargetSize.Width);
		class837_0.method_22(Enum305.const_16, TargetSize.Height);
		RootLayout.method_1();
		RootLayout.method_6();
		if (class837_0.Algorithm.vmethod_4(class837_0, TargetSize))
		{
			class837_0.method_44();
			class837_0.method_26();
			RootLayout.method_6();
		}
		class837_0.method_42();
		class837_0.method_43();
	}

	public void method_5()
	{
		foreach (Class837 item in list_0)
		{
			if (item.ShapeContainer.Shape != null)
			{
				method_8(item);
				continue;
			}
			item.DataPoint.PropertySet.PresStyleIdx = 0;
			item.DataPoint.PropertySet.PresStyleCnt = 0;
		}
	}

	private List<Class851> method_6()
	{
		List<Class851> list = new List<Class851>();
		int num = 0;
		foreach (Class837 item in list_0)
		{
			if (item.ShapeContainer.Shape != null)
			{
				list.Add(item.ShapeContainer);
				item.ShapeContainer.OrderIndex = num;
				num++;
			}
		}
		list.Sort();
		return list;
	}

	private void method_7(List<Class851> containers)
	{
		Dictionary<string, List<Class837>> dictionary = new Dictionary<string, List<Class837>>();
		foreach (Class851 container in containers)
		{
			string text = container.Target.LayoutNode.StyleLabel;
			if (string.IsNullOrEmpty(text))
			{
				text = smethod_2(container.Target);
			}
			container.Target.DataPoint.PropertySet.PresStyleLbl = text;
			if (!dictionary.ContainsKey(text))
			{
				dictionary.Add(text, new List<Class837> { container.Target });
			}
			else
			{
				dictionary[text].Add(container.Target);
			}
			container.Target.DataPoint.PropertySet.PresStyleIdx = -1;
		}
		foreach (List<Class837> value in dictionary.Values)
		{
			int num = 0;
			for (int i = 0; i < value.Count; i++)
			{
				Class837 @class = value[i];
				if (@class.DataPoint.PropertySet.PresStyleIdx != -1)
				{
					continue;
				}
				@class.DataPoint.PropertySet.PresStyleIdx = num;
				Class836 class2 = ((@class.ConnectedWith.Count > 0) ? @class.ConnectedWith[0] : @class.AssociatedWith);
				if (class2.Type == Enum337.const_3)
				{
					Class837 class3 = (Class837)@class.Next;
					if (class3 != null && (class3.ConnectedWith.Contains(class2) || class3.AssociatedWith == class2) && class3.ShapeContainer.IsHidden)
					{
						class3.DataPoint.PropertySet.PresStyleIdx = num;
					}
				}
				else
				{
					foreach (Class837 item in value)
					{
						if (item != @class && (item.ConnectedWith.Contains(class2) || item.AssociatedWith == class2))
						{
							item.DataPoint.PropertySet.PresStyleIdx = num;
						}
					}
				}
				num++;
			}
			foreach (Class837 item2 in value)
			{
				item2.DataPoint.PropertySet.PresStyleCnt = num;
			}
		}
	}

	private void method_8(Class837 point)
	{
		AutoShape autoShapeInternal = point.ShapeContainer.Shape.AutoShapeInternal;
		bool flag = point.Algorithm is Class122 @class && !@class.IsTwoDimensionShape;
		string presStyleLbl = point.DataPoint.PropertySet.PresStyleLbl;
		Class2189 class2 = method_10(presStyleLbl);
		Class2162 class3 = method_11(presStyleLbl);
		if (class2 != null && class3 != null)
		{
			Class2605 color = class2.Style.FillRef.Color;
			Class2605 color2 = class2.Style.LnRef.Color;
			Class2605 color3 = class2.Style.FontRef.Color;
			uint idx = class2.Style.FillRef.Idx;
			uint idx2 = class2.Style.LnRef.Idx;
			int presStyleIdx = point.DataPoint.PropertySet.PresStyleIdx;
			int presStyleCnt = point.DataPoint.PropertySet.PresStyleCnt;
			if (class3.FillClrLst != null)
			{
				Class2605 class4 = method_12(class3.FillClrLst, presStyleIdx, presStyleCnt);
				if (class4 != null)
				{
					class2.Style.FillRef.Color = class4;
				}
				if (flag)
				{
					class2.Style.FillRef.Idx = 0u;
				}
			}
			if (class3.LinClrLst != null)
			{
				Class2605 class5 = method_12((!flag || class2.Style.LnRef.Idx != 0) ? class3.LinClrLst : class3.FillClrLst, presStyleIdx, presStyleCnt);
				if (class5 != null)
				{
					class2.Style.LnRef.Color = class5;
					if (flag && class2.Style.LnRef.Idx == 0)
					{
						class2.Style.LnRef.Idx = 1u;
					}
				}
			}
			if (class3.TxFillClrLst != null)
			{
				Class2605 class6 = method_12(class3.TxFillClrLst, presStyleIdx, presStyleCnt);
				if (class6 != null)
				{
					class2.Style.FontRef.Color = class6;
				}
			}
			Class984.smethod_0(autoShapeInternal, class2.Style);
			class2.Style.FillRef.Color = color;
			class2.Style.LnRef.Color = color2;
			class2.Style.FontRef.Color = color3;
			class2.Style.FillRef.Idx = idx;
			class2.Style.LnRef.Idx = idx2;
		}
		if (point.ShapeContainer.IsHidden)
		{
			autoShapeInternal.FillFormat.FillType = FillType.NoFill;
			autoShapeInternal.LineFormat.FillFormat.FillType = FillType.NoFill;
		}
		method_9(point, flag);
		point.ShapeContainer.Shape.method_1();
		Class1073 class7 = ((point.ConnectedWith.Count > 0) ? point.ConnectedWith[0].DataPoint : point.DataPoint);
		class7.method_0(point.ShapeContainer.Shape);
		if (point.ShapeContainer.IsHidden)
		{
			autoShapeInternal.FillFormat.FillType = FillType.NoFill;
			autoShapeInternal.LineFormat.FillFormat.FillType = FillType.NoFill;
		}
		method_9(point, flag);
	}

	private void method_9(Class837 point, bool isOneDimConnector)
	{
		if (point.ShapeContainer.BeginArrowheadStyle != LineArrowheadStyle.NotDefined)
		{
			point.ShapeContainer.Shape.AutoShapeInternal.LineFormat.BeginArrowheadStyle = point.ShapeContainer.BeginArrowheadStyle;
		}
		if (point.ShapeContainer.EndArrowheadStyle != LineArrowheadStyle.NotDefined)
		{
			point.ShapeContainer.Shape.AutoShapeInternal.LineFormat.EndArrowheadStyle = point.ShapeContainer.EndArrowheadStyle;
		}
		if (isOneDimConnector)
		{
			point.ShapeContainer.Shape.AutoShapeInternal.FillFormat.FillType = FillType.NoFill;
		}
	}

	private Class2189 method_10(string label)
	{
		Class2189[] styleLblList = Target.PPTXUnsupportedProps.StyleDefElementData.StyleLblList;
		int num = 0;
		Class2189 @class;
		while (true)
		{
			if (num < styleLblList.Length)
			{
				@class = styleLblList[num];
				if (@class.Name == label)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	private Class2162 method_11(string label)
	{
		Class2162[] styleLblList = Target.PPTXUnsupportedProps.ColorsDefElementData.StyleLblList;
		int num = 0;
		Class2162 @class;
		while (true)
		{
			if (num < styleLblList.Length)
			{
				@class = styleLblList[num];
				if (@class.Name == label)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	private Class2605 method_12(Class2155 styleColor, int index, int count)
	{
		Color color = Color.Empty;
		if (styleColor.Meth != 0)
		{
			if (styleColor.ColorList.Length > 1)
			{
				ColorFormat begin = smethod_0(styleColor.ColorList[0]);
				ColorFormat end = smethod_0(styleColor.ColorList[1]);
				color = ((styleColor.Meth == Enum328.const_2) ? method_14(begin, end, index, count) : ((styleColor.Meth != Enum328.const_1) ? smethod_0(styleColor.ColorList[index % styleColor.ColorList.Length]).method_5(Target.Slide, null) : method_13(begin, end, index, count)));
			}
			else if (styleColor.ColorList.Length > 0)
			{
				color = smethod_0(styleColor.ColorList[0]).method_5(Target.Slide, null);
			}
		}
		if (color == Color.Empty)
		{
			return null;
		}
		Class1926 @class = new Class1926();
		@class.Val = (uint)((color.R << 16) | (color.G << 8) | color.B);
		if (color.A != byte.MaxValue)
		{
			Class1901 class2 = new Class1901();
			class2.Val = (float)((double)(int)color.A * 100.0 / 255.0);
			@class.method_4(new Class2605("alpha", class2));
		}
		return new Class2605("srgbClr", @class);
	}

	private Color method_13(ColorFormat begin, ColorFormat end, int index, int count)
	{
		if (count == 0)
		{
			return begin.Color;
		}
		FloatColor floatColor = begin.method_4(Target.Slide, null);
		FloatColor floatColor2 = end.method_4(Target.Slide, null);
		float hue = 0f;
		float saturation = 0f;
		float luminance = 0f;
		float hue2 = 0f;
		float saturation2 = 0f;
		float luminance2 = 0f;
		ColorFormat.smethod_4(floatColor.float_1, floatColor.float_2, floatColor.float_3, out hue, out saturation, out luminance);
		ColorFormat.smethod_4(floatColor2.float_1, floatColor2.float_2, floatColor2.float_3, out hue2, out saturation2, out luminance2);
		float num = ((count - 1 == 0) ? 0f : ((float)index / (float)(count - 1)));
		float num2 = 1f - num;
		float hue3 = num2 * hue + num * hue2;
		float saturation3 = num2 * saturation + num * saturation2;
		float luminance3 = num2 * luminance + num * luminance2;
		FloatColor floatColor3 = ColorFormat.smethod_3(hue3, saturation3, luminance3);
		floatColor3.float_0 = num2 * floatColor.float_0 + num * floatColor2.float_0;
		return floatColor3.Color;
	}

	private Color method_14(ColorFormat begin, ColorFormat end, int index, int count)
	{
		FloatColor floatColor = begin.method_4(Target.Slide, null);
		FloatColor floatColor2 = end.method_4(Target.Slide, null);
		float hue = 0f;
		float saturation = 0f;
		float luminance = 0f;
		float hue2 = 0f;
		float saturation2 = 0f;
		float luminance2 = 0f;
		ColorFormat.smethod_4(floatColor.float_1, floatColor.float_2, floatColor.float_3, out hue, out saturation, out luminance);
		ColorFormat.smethod_4(floatColor2.float_1, floatColor2.float_2, floatColor2.float_3, out hue2, out saturation2, out luminance2);
		int num = (int)Math.Ceiling((float)count / 2f);
		bool flag;
		int num2 = ((flag = index >= num) ? (index - num + count % 2) : index);
		float num3 = ((num == 0) ? 0f : ((float)num2 / (float)num));
		float num4 = (flag ? (1f - num3) : num3);
		float num5 = (flag ? num3 : (1f - num3));
		float hue3 = num5 * hue + num4 * hue2;
		float saturation3 = num5 * saturation + num4 * saturation2;
		float luminance3 = num5 * luminance + num4 * luminance2;
		FloatColor floatColor3 = ColorFormat.smethod_3(hue3, saturation3, luminance3);
		floatColor3.float_0 = num5 * floatColor.float_0 + num4 * floatColor2.float_0;
		return floatColor3.Color;
	}

	private static ColorFormat smethod_0(Class2605 colorElementData)
	{
		IColorFormat colorFormat = new ColorFormat(null);
		Class930.smethod_1(colorFormat, colorElementData);
		return (ColorFormat)colorFormat;
	}

	private static void smethod_1(Class837 root, List<Class837> output)
	{
		output.Add(root);
		foreach (Class837 child in root.Children)
		{
			smethod_1(child, output);
		}
	}

	private static string smethod_2(Class837 point)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Class836 @class = ((point.ConnectedWith.Count > 0) ? point.ConnectedWith[0] : point.AssociatedWith);
		switch (@class.Type)
		{
		case Enum337.const_2:
			stringBuilder.Append("asst");
			break;
		default:
			stringBuilder.Append("node");
			break;
		case Enum337.const_5:
			stringBuilder.Append("parChTrans");
			break;
		case Enum337.const_6:
			stringBuilder.Append("sibTrans");
			break;
		}
		if (@class.Type == Enum337.const_6 || point.AssociatedWith.Type == Enum337.const_5)
		{
			stringBuilder.Append(point.Algorithm.IsTwoDimensionShape ? "2D" : "1D");
		}
		int num = @class.Level;
		if (num > 0 && @class.Type == Enum337.const_2)
		{
			num--;
		}
		else if (num == 0 && @class.Type == Enum337.const_3)
		{
			num = 1;
		}
		stringBuilder.Append(Math.Min(4, num));
		return stringBuilder.ToString();
	}
}
