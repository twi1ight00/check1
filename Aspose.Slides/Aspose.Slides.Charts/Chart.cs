using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Slides.Theme;
using ns11;
using ns2;
using ns25;
using ns34;
using ns35;
using ns36;
using ns37;
using ns38;
using ns7;

namespace Aspose.Slides.Charts;

public class Chart : GraphicalObject, IPresentationComponent, ISlideComponent, IChartComponent, IHyperlinkContainer, IShape, IGraphicalObject, IFormattedTextContainer, IThemeable, IOverrideThemeable, IChart
{
	private ChartWall chartWall_0;

	private ChartWall chartWall_1;

	private ChartWall chartWall_2;

	private ChartShapeType chartShapeType_0 = ChartShapeType.NotDefined;

	private StyleType styleType_0 = StyleType.Style2;

	private bool bool_1;

	private readonly ChartTitle chartTitle_0;

	private bool bool_2;

	private DataTable dataTable_0;

	private DisplayBlanksAsType displayBlanksAsType_0 = DisplayBlanksAsType.Zero;

	private Rotation3D rotation3D_0;

	private bool bool_3 = true;

	private Legend legend_0;

	private bool bool_4 = true;

	private ChartData chartData_0;

	private ChartPlotArea chartPlotArea_0;

	internal ChartType chartType_0;

	private bool bool_5;

	private bool bool_6;

	private readonly AxesManager axesManager_0;

	private readonly Class17 class17_0;

	private readonly ChartThemeManager chartThemeManager_0;

	private GroupShape groupShape_0;

	private bool bool_7;

	private static readonly object[] object_0 = new object[0];

	internal new Class288 PPTXUnsupportedProps => (Class288)base.PPTXUnsupportedProps;

	public bool PlotVisibleCellsOnly
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

	public DisplayBlanksAsType DisplayBlanksAs
	{
		get
		{
			return displayBlanksAsType_0;
		}
		set
		{
			displayBlanksAsType_0 = value;
		}
	}

	public IChartData ChartData => chartData_0;

	public bool HasTitle
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public IChartTitle ChartTitle => chartTitle_0;

	public bool HasDataTable
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool HasLegend
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public ILegend Legend => legend_0;

	public IDataTable ChartDataTable => dataTable_0;

	public StyleType Style
	{
		get
		{
			return styleType_0;
		}
		set
		{
			styleType_0 = value;
		}
	}

	public ChartType Type
	{
		get
		{
			method_25();
			return chartType_0;
		}
		set
		{
			if (value == ChartType.SeriesOfMixedTypes)
			{
				throw new InvalidOperationException("It's meaningless to assign ChartType.SeriesOfMixedTypes value to Chart.Type.");
			}
			chartType_0 = value;
			foreach (ChartSeries item in ChartData.Series)
			{
				item.Type = value;
			}
			axesManager_0.method_2();
		}
	}

	public IChartPlotArea PlotArea => chartPlotArea_0;

	public IRotation3D Rotation3D => rotation3D_0;

	public IChartWall BackWall => chartWall_0;

	public IChartWall SideWall => chartWall_1;

	public IChartWall Floor => chartWall_2;

	public IChartTextFormat TextFormat => class17_0.TextFormatOfAutoText;

	internal Class17 TextFormatManager => class17_0;

	public IOverrideThemeManager ThemeManager => chartThemeManager_0;

	public IGroupShape UserShapes
	{
		get
		{
			if (groupShape_0 == null)
			{
				groupShape_0 = new GroupShape(base.Slide);
				groupShape_0.shapeCollection_0 = shapeCollection_0;
			}
			method_26();
			return groupShape_0;
		}
	}

	public IAxesManager Axes => axesManager_0;

	IChart IChartComponent.Chart => this;

	IGraphicalObject IChart.AsIGraphicalObject => this;

	public IFormattedTextContainer AsIFormattedTextContainer => this;

	public IThemeable AsIThemeable => this;

	ISlideComponent IChartComponent.AsISlideComponent => this;

	ISlideComponent IThemeable.AsISlideComponent => this;

	IOverrideThemeable IChart.AsIOverrideThemeable => this;

	IThemeable IOverrideThemeable.AsIThemeable => this;

	internal Chart(IBaseSlide parent, ChartType type)
		: base(parent, new Class288())
	{
		lineFormat_0 = new LineFormat(this);
		threeDFormat_0 = new ThreeDFormat(this);
		effectFormat_0 = new EffectFormat(this);
		chartData_0 = new ChartData(this);
		axesManager_0 = new AxesManager(this);
		Type = type;
		class17_0 = new Class17(this);
		chartThemeManager_0 = new ChartThemeManager(this);
		chartTitle_0 = new ChartTitle(this);
		chartWall_0 = new ChartWall(this);
		chartWall_1 = new ChartWall(this);
		chartWall_2 = new ChartWall(this);
		legend_0 = new Legend(this);
		dataTable_0 = new DataTable(this);
		rotation3D_0 = new Rotation3D();
		chartPlotArea_0 = new ChartPlotArea(this);
	}

	internal Color method_14(Class17 textFormatManager, ITextFrame textForOverriding, Color colorToSet, Class740 chNew)
	{
		Color result = colorToSet;
		if (textFormatManager != null)
		{
			if (textFormatManager.TextFormatOfAutoText.PortionFormat.FillFormat.FillType != FillType.NotDefined)
			{
				if (textFormatManager.TextFormatOfAutoText.PortionFormat.FillFormat.FillType == FillType.Solid)
				{
					FillFormat fillFormat = (FillFormat)textFormatManager.TextFormatOfAutoText.PortionFormat.FillFormat;
					if (fillFormat.SolidFillColor.ColorType == ColorType.Scheme)
					{
						ColorFormat colorFormat = (bool_7 ? new ColorFormat(this, chNew.Themes.ThemeColors.Colors[fillFormat.colorFormat_0.int_0]) : new ColorFormat(this, ((Slide)base.Slide).method_2(fillFormat.SolidFillColor.SchemeColor).Color));
						((ColorOperationCollection)colorFormat.ColorTransform).list_0 = (fillFormat.colorFormat_0.ColorTransform as ColorOperationCollection).list_0;
						result = colorFormat.Color;
					}
					else
					{
						result = fillFormat.SolidFillColor.Color;
					}
				}
			}
			else
			{
				Class17 textFormatManagerInherited = textFormatManager.TextFormatManagerInherited;
				while (textFormatManagerInherited != null && textFormatManagerInherited.TextFormatOfAutoText.PortionFormat.FillFormat.FillType == FillType.NotDefined)
				{
					textFormatManagerInherited = textFormatManagerInherited.TextFormatManagerInherited;
				}
				if (textFormatManagerInherited != null && textFormatManagerInherited.TextFormatOfAutoText.PortionFormat.FillFormat.FillType == FillType.Solid)
				{
					FillFormat fillFormat2 = (FillFormat)textFormatManagerInherited.TextFormatOfAutoText.PortionFormat.FillFormat;
					if (fillFormat2.SolidFillColor.ColorType == ColorType.Scheme)
					{
						ColorFormat colorFormat2 = (bool_7 ? new ColorFormat(this, chNew.Themes.ThemeColors.Colors[fillFormat2.colorFormat_0.int_0]) : new ColorFormat(this, ((Slide)base.Slide).method_2(fillFormat2.SolidFillColor.SchemeColor).Color));
						((ColorOperationCollection)colorFormat2.ColorTransform).list_0 = (fillFormat2.colorFormat_0.ColorTransform as ColorOperationCollection).list_0;
						result = colorFormat2.Color;
					}
					else
					{
						result = fillFormat2.SolidFillColor.Color;
					}
				}
			}
		}
		if (textForOverriding != null && textForOverriding.Paragraphs.Count > 0)
		{
			if (textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType == FillType.Solid)
			{
				FillFormat fillFormat3 = textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat as FillFormat;
				if (fillFormat3.SolidFillColor.ColorType == ColorType.Scheme)
				{
					ColorFormat colorFormat3 = (bool_7 ? new ColorFormat(this, chNew.Themes.ThemeColors.Colors[fillFormat3.colorFormat_0.int_0]) : new ColorFormat(this, ((Slide)base.Slide).method_2(fillFormat3.SolidFillColor.SchemeColor).Color));
					((ColorOperationCollection)colorFormat3.ColorTransform).list_0 = (fillFormat3.colorFormat_0.ColorTransform as ColorOperationCollection).list_0;
					result = colorFormat3.Color;
				}
				else
				{
					result = fillFormat3.SolidFillColor.Color;
				}
			}
			if (textForOverriding.Paragraphs[0].Portions.Count > 0 && textForOverriding.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType == FillType.Solid)
			{
				FillFormat fillFormat4 = textForOverriding.Paragraphs[0].Portions[0].PortionFormat.FillFormat as FillFormat;
				if (fillFormat4.SolidFillColor.ColorType == ColorType.Scheme)
				{
					ColorFormat colorFormat4 = (bool_7 ? new ColorFormat(this, chNew.Themes.ThemeColors.Colors[fillFormat4.colorFormat_0.int_0]) : new ColorFormat(this, ((Slide)base.Slide).method_2(fillFormat4.SolidFillColor.SchemeColor).Color));
					((ColorOperationCollection)colorFormat4.ColorTransform).list_0 = (fillFormat4.colorFormat_0.ColorTransform as ColorOperationCollection).list_0;
					result = colorFormat4.Color;
				}
				else
				{
					result = fillFormat4.SolidFillColor.Color;
				}
			}
		}
		return result;
	}

	internal Font method_15(Class17 textFormatManager, ITextFrame textForOverriding, bool isBold, bool isTitle)
	{
		float size = (isTitle ? 18 : 10);
		if (textFormatManager != null)
		{
			if (!double.IsNaN(textFormatManager.TextFormatOfAutoText.PortionFormat.FontHeight))
			{
				size = textFormatManager.TextFormatOfAutoText.PortionFormat.FontHeight;
			}
			else
			{
				Class17 textFormatManagerInherited = textFormatManager.TextFormatManagerInherited;
				while (textFormatManagerInherited != null && double.IsNaN(textFormatManagerInherited.TextFormatOfAutoText.PortionFormat.FontHeight))
				{
					textFormatManagerInherited = textFormatManagerInherited.TextFormatManagerInherited;
				}
				if (textFormatManagerInherited != null)
				{
					size = textFormatManagerInherited.TextFormatOfAutoText.PortionFormat.FontHeight;
				}
			}
		}
		if (textForOverriding != null && textForOverriding.Paragraphs.Count > 0 && !double.IsNaN(textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight))
		{
			size = textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight;
		}
		IThemeEffectiveData themeEffectiveData = CreateThemeEffective();
		string fontName = themeEffectiveData.FontScheme.Minor.LatinFont.FontName;
		if (textFormatManager != null)
		{
			if (textFormatManager.TextFormatOfAutoText.PortionFormat.LatinFont != null && textFormatManager.TextFormatOfAutoText.PortionFormat.LatinFont.GetFontName(themeEffectiveData) != null)
			{
				fontName = textFormatManager.TextFormatOfAutoText.PortionFormat.LatinFont.GetFontName(themeEffectiveData);
			}
			else
			{
				Class17 textFormatManagerInherited2 = textFormatManager.TextFormatManagerInherited;
				while (textFormatManagerInherited2 != null && (textFormatManagerInherited2.TextFormatOfAutoText.PortionFormat.LatinFont == null || textFormatManagerInherited2.TextFormatOfAutoText.PortionFormat.LatinFont.GetFontName(themeEffectiveData) == null))
				{
					textFormatManagerInherited2 = textFormatManagerInherited2.TextFormatManagerInherited;
				}
				if (textFormatManagerInherited2 != null)
				{
					fontName = textFormatManagerInherited2.TextFormatOfAutoText.PortionFormat.LatinFont.GetFontName(themeEffectiveData);
				}
			}
		}
		if (textForOverriding != null && textForOverriding.Paragraphs.Count > 0)
		{
			if (textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont != null && textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont.GetFontName(themeEffectiveData) != null)
			{
				fontName = textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont.GetFontName(themeEffectiveData);
			}
			if (textForOverriding.Paragraphs[0].Portions.Count > 0 && textForOverriding.Paragraphs[0].Portions[0].PortionFormat.LatinFont != null && textForOverriding.Paragraphs[0].Portions[0].PortionFormat.LatinFont.GetFontName(themeEffectiveData) != null)
			{
				fontName = textForOverriding.Paragraphs[0].Portions[0].PortionFormat.LatinFont.GetFontName(themeEffectiveData);
			}
		}
		FontStyle fontStyle = (isBold ? FontStyle.Bold : FontStyle.Regular);
		if (textFormatManager != null)
		{
			if (textFormatManager.TextFormatOfAutoText.PortionFormat.FontItalic == NullableBool.True)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (textFormatManager.TextFormatOfAutoText.PortionFormat.FontBold != NullableBool.NotDefined)
			{
				fontStyle = ((textFormatManager.TextFormatOfAutoText.PortionFormat.FontBold == NullableBool.True) ? (fontStyle | FontStyle.Bold) : fontStyle);
			}
			else
			{
				Class17 textFormatManagerInherited3 = textFormatManager.TextFormatManagerInherited;
				while (textFormatManagerInherited3 != null && textFormatManagerInherited3.TextFormatOfAutoText.PortionFormat.FontBold == NullableBool.NotDefined)
				{
					textFormatManagerInherited3 = textFormatManagerInherited3.TextFormatManagerInherited;
				}
				if (textFormatManagerInherited3 != null)
				{
					fontStyle = ((textFormatManagerInherited3.TextFormatOfAutoText.PortionFormat.FontBold == NullableBool.True) ? FontStyle.Bold : FontStyle.Regular);
				}
			}
		}
		if (textForOverriding != null && textForOverriding.Paragraphs.Count > 0)
		{
			if (textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontBold != NullableBool.NotDefined)
			{
				fontStyle = ((textForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontBold == NullableBool.True) ? FontStyle.Bold : FontStyle.Regular);
			}
			if (textForOverriding.Paragraphs[0].Portions.Count > 0 && textForOverriding.Paragraphs[0].Portions[0].PortionFormat.FontBold != NullableBool.NotDefined)
			{
				fontStyle = ((textForOverriding.Paragraphs[0].Portions[0].PortionFormat.FontBold == NullableBool.True) ? FontStyle.Bold : FontStyle.Regular);
			}
		}
		return ((Presentation)base.Presentation).FontsManagerInternal.method_3(fontName, size, fontStyle);
	}

	internal void method_16(Interface6 fillArea, FillFormat fillFormat, Class740 chNew)
	{
		if (fillFormat == null)
		{
			return;
		}
		switch (fillFormat.FillType)
		{
		case FillType.NoFill:
			fillArea.Formatting = FillType.NoFill;
			break;
		case FillType.Solid:
			fillArea.Formatting = FillType.Solid;
			if (fillFormat.SolidFillColor.ColorType == ColorType.Scheme)
			{
				ColorFormat colorFormat = (bool_7 ? new ColorFormat(this, chNew.Themes.ThemeColors.Colors[fillFormat.colorFormat_0.int_0]) : new ColorFormat(this, ((Slide)base.Slide).method_2(fillFormat.SolidFillColor.SchemeColor).Color));
				((ColorOperationCollection)colorFormat.ColorTransform).list_0 = (fillFormat.colorFormat_0.ColorTransform as ColorOperationCollection).list_0;
				fillArea.ForegroundColor = colorFormat.Color;
			}
			else
			{
				fillArea.ForegroundColor = fillFormat.colorFormat_0.Color;
			}
			break;
		case FillType.Gradient:
			fillArea.Formatting = FillType.Gradient;
			fillArea.FillFormat.GradientFill.Angle = fillFormat.GradientFormat.LinearGradientAngle;
			fillArea.FillFormat.GradientFill.DirectionType = fillFormat.GradientFormat.GradientDirection;
			{
				foreach (GradientStop gradientStop in fillFormat.GradientFormat.GradientStops)
				{
					Color empty3 = Color.Empty;
					if (gradientStop.Color.ColorType == ColorType.Scheme)
					{
						ColorFormat colorFormat4 = (bool_7 ? new ColorFormat(this, chNew.Themes.ThemeColors.Colors[(gradientStop.Color as ColorFormat).int_0]) : new ColorFormat(this, ((Slide)base.Slide).method_2(gradientStop.Color.SchemeColor).Color));
						((ColorOperationCollection)colorFormat4.ColorTransform).list_0 = (gradientStop.Color.ColorTransform as ColorOperationCollection).list_0;
						empty3 = colorFormat4.Color;
					}
					else
					{
						empty3 = gradientStop.Color.Color;
					}
					fillArea.FillFormat.GradientFill.GradientStops.Add(empty3, gradientStop.Position * 100f);
				}
				break;
			}
		case FillType.Pattern:
		{
			fillArea.Formatting = FillType.Pattern;
			Color empty = Color.Empty;
			Color empty2 = Color.Empty;
			if (fillFormat.PatternFormat.ForeColor.ColorType == ColorType.Scheme)
			{
				ColorFormat colorFormat2 = (bool_7 ? new ColorFormat(this, chNew.Themes.ThemeColors.Colors[(fillFormat.PatternFormat.ForeColor as ColorFormat).int_0]) : new ColorFormat(this, ((Slide)base.Slide).method_2(fillFormat.PatternFormat.ForeColor.SchemeColor).Color));
				(colorFormat2.ColorTransform as ColorOperationCollection).list_0 = (fillFormat.PatternFormat.ForeColor.ColorTransform as ColorOperationCollection).list_0;
				empty = colorFormat2.Color;
			}
			else
			{
				empty = fillFormat.PatternFormat.ForeColor.Color;
			}
			if (fillFormat.PatternFormat.BackColor.ColorType == ColorType.Scheme)
			{
				ColorFormat colorFormat3 = (bool_7 ? new ColorFormat(this, chNew.Themes.ThemeColors.Colors[(fillFormat.PatternFormat.BackColor as ColorFormat).int_0]) : new ColorFormat(this, ((Slide)base.Slide).method_2(fillFormat.PatternFormat.BackColor.SchemeColor).Color));
				((ColorOperationCollection)colorFormat3.ColorTransform).list_0 = ((ColorOperationCollection)fillFormat.PatternFormat.BackColor.ColorTransform).list_0;
				empty2 = colorFormat3.Color;
			}
			else
			{
				empty2 = fillFormat.PatternFormat.BackColor.Color;
			}
			HatchStyle style = HatchStyle.DashedHorizontal;
			switch (fillFormat.PatternFormat.PatternStyle)
			{
			case PatternStyle.Percent05:
				style = HatchStyle.Percent05;
				break;
			case PatternStyle.Percent10:
				style = HatchStyle.Percent10;
				break;
			case PatternStyle.Percent20:
				style = HatchStyle.Percent20;
				break;
			case PatternStyle.Percent25:
				style = HatchStyle.Percent25;
				break;
			case PatternStyle.Percent30:
				style = HatchStyle.Percent30;
				break;
			case PatternStyle.Percent40:
				style = HatchStyle.Percent40;
				break;
			case PatternStyle.Percent50:
				style = HatchStyle.Percent50;
				break;
			case PatternStyle.Percent60:
				style = HatchStyle.Percent60;
				break;
			case PatternStyle.Percent70:
				style = HatchStyle.Percent70;
				break;
			case PatternStyle.Percent75:
				style = HatchStyle.Percent75;
				break;
			case PatternStyle.Percent80:
				style = HatchStyle.Percent80;
				break;
			case PatternStyle.Percent90:
				style = HatchStyle.Percent90;
				break;
			case PatternStyle.DarkHorizontal:
				style = HatchStyle.DarkHorizontal;
				break;
			case PatternStyle.DarkVertical:
				style = HatchStyle.DarkVertical;
				break;
			case PatternStyle.DarkDownwardDiagonal:
				style = HatchStyle.DarkDownwardDiagonal;
				break;
			case PatternStyle.DarkUpwardDiagonal:
				style = HatchStyle.DarkUpwardDiagonal;
				break;
			case PatternStyle.SmallCheckerBoard:
				style = HatchStyle.SmallCheckerBoard;
				break;
			case PatternStyle.Trellis:
				style = HatchStyle.Trellis;
				break;
			case PatternStyle.LightHorizontal:
				style = HatchStyle.LightHorizontal;
				break;
			case PatternStyle.LightVertical:
				style = HatchStyle.LightVertical;
				break;
			case PatternStyle.LightDownwardDiagonal:
				style = HatchStyle.LightDownwardDiagonal;
				break;
			case PatternStyle.LightUpwardDiagonal:
				style = HatchStyle.LightUpwardDiagonal;
				break;
			case PatternStyle.SmallGrid:
				style = HatchStyle.SmallGrid;
				break;
			case PatternStyle.DottedDiamond:
				style = HatchStyle.DottedDiamond;
				break;
			case PatternStyle.WideDownwardDiagonal:
				style = HatchStyle.WideDownwardDiagonal;
				break;
			case PatternStyle.WideUpwardDiagonal:
				style = HatchStyle.WideUpwardDiagonal;
				break;
			case PatternStyle.DashedDownwardDiagonal:
				style = HatchStyle.DashedDownwardDiagonal;
				break;
			case PatternStyle.DashedUpwardDiagonal:
				style = HatchStyle.DashedUpwardDiagonal;
				break;
			case PatternStyle.NarrowVertical:
				style = HatchStyle.Horizontal;
				break;
			case PatternStyle.NarrowHorizontal:
				style = HatchStyle.Cross;
				break;
			case PatternStyle.DashedVertical:
				style = HatchStyle.DashedVertical;
				break;
			case PatternStyle.DashedHorizontal:
				style = HatchStyle.DashedHorizontal;
				break;
			case PatternStyle.LargeConfetti:
				style = HatchStyle.LargeConfetti;
				break;
			case PatternStyle.LargeGrid:
				style = HatchStyle.Cross;
				break;
			case PatternStyle.HorizontalBrick:
				style = HatchStyle.HorizontalBrick;
				break;
			case PatternStyle.LargeCheckerBoard:
				style = HatchStyle.LargeCheckerBoard;
				break;
			case PatternStyle.SmallConfetti:
				style = HatchStyle.SmallConfetti;
				break;
			case PatternStyle.SolidDiamond:
				style = HatchStyle.SolidDiamond;
				break;
			case PatternStyle.DiagonalBrick:
				style = HatchStyle.DiagonalBrick;
				break;
			case PatternStyle.OutlinedDiamond:
				style = HatchStyle.OutlinedDiamond;
				break;
			case PatternStyle.Plaid:
				style = HatchStyle.Plaid;
				break;
			case PatternStyle.Sphere:
				style = HatchStyle.Sphere;
				break;
			case PatternStyle.Weave:
				style = HatchStyle.Weave;
				break;
			case PatternStyle.DottedGrid:
				style = HatchStyle.DottedGrid;
				break;
			case PatternStyle.Divot:
				style = HatchStyle.Divot;
				break;
			case PatternStyle.Shingle:
				style = HatchStyle.Shingle;
				break;
			case PatternStyle.Wave:
				style = HatchStyle.Wave;
				break;
			case PatternStyle.Horizontal:
				style = HatchStyle.Horizontal;
				break;
			case PatternStyle.Vertical:
				style = HatchStyle.Vertical;
				break;
			case PatternStyle.Cross:
				style = HatchStyle.Cross;
				break;
			case PatternStyle.DownwardDiagonal:
				style = HatchStyle.ForwardDiagonal;
				break;
			case PatternStyle.UpwardDiagonal:
				style = HatchStyle.LightUpwardDiagonal;
				break;
			case PatternStyle.DiagonalCross:
				style = HatchStyle.DiagonalCross;
				break;
			}
			fillArea.FillFormat.imethod_0(empty, empty2, style);
			break;
		}
		case FillType.Picture:
			fillArea.Formatting = FillType.Picture;
			fillArea.FillFormat.TextureFill.Image = fillFormat.PictureFillFormat.Picture.Image.SystemImage;
			if (fillFormat.PictureFillFormat.PictureFillMode == PictureFillMode.Tile)
			{
				fillArea.FillFormat.TextureFill.IsTiling = true;
			}
			break;
		}
	}

	internal override void vmethod_4(Class159 canvas, Class169 rc)
	{
		if (!base.Hidden)
		{
			Class740 c = method_17();
			ShapeFrame shapeFrame = method_4();
			float x = shapeFrame.X;
			float y = shapeFrame.Y;
			float width = shapeFrame.Width;
			float height = shapeFrame.Height;
			if (!float.IsNaN(x) && !float.IsNaN(y) && !float.IsNaN(width) && !float.IsNaN(height))
			{
				canvas.Transform = Shape.smethod_0(shapeFrame);
				MemoryStream memoryStream = smethod_3(c);
				PPImage pPImage = new PPImage(memoryStream.GetBuffer());
				canvas.vmethod_20(pPImage, new RectangleF(x, y, width, height), new RectangleF(0f, 0f, pPImage.image.Width, pPImage.image.Height), null);
				method_20(canvas, rc);
			}
		}
	}

	private Class740 method_17()
	{
		ChartType type = Type;
		Class740 @class = new Class740(null);
		@class.SourceChart = this;
		if (type != ChartType.SeriesOfMixedTypes)
		{
			@class.Type = type;
		}
		else if (ChartData.Series.Count > 0)
		{
			@class.Type = ChartData.Series[0].Type;
		}
		method_19(@class);
		@class.Width = (int)(base.Width / 72f * 96f);
		@class.Height = (int)(base.Height / 72f * 96f);
		foreach (ChartSeriesGroup seriesGroup in chartData_0.SeriesGroups)
		{
			foreach (ChartSeries item in seriesGroup.Series)
			{
				Class759 class2 = (Class759)@class.NSeries.Add(item.Type);
				if (ChartTypeCharacterizer.IsSeriesUsesValueCoordinate(item.Type))
				{
					for (int i = 0; i < item.DataPoints.Count; i++)
					{
						IDoubleChartValue value = item.DataPoints[i].Value;
						if (value.DataSourceType != 0 || value.AsCell != null)
						{
							class2.imethod_0((value.Data == null || double.IsNaN(value.ToDouble())) ? 0.0 : value.ToDouble());
							int index = class2.Points.Count - 1;
							class2.Points[index].YFormat = item.NumberFormatOfValues;
							if (value.Data == null || string.IsNullOrEmpty(value.Data.ToString()))
							{
								class2.Points[index].NotPlotted = true;
							}
						}
					}
				}
				if (ChartTypeCharacterizer.IsSeriesUsesYValueCoordinate(item.Type))
				{
					double[] array = new double[item.DataPoints.Count];
					double[] array2 = new double[item.DataPoints.Count];
					for (int j = 0; j < item.DataPoints.Count; j++)
					{
						IDoubleChartValue yValue = item.DataPoints[j].YValue;
						if (yValue.DataSourceType == DataSourceType.Worksheet && yValue.AsCell == null)
						{
							continue;
						}
						class2.imethod_0((yValue.Data == null || double.IsNaN(yValue.ToDouble())) ? 0.0 : yValue.ToDouble());
						int index2 = class2.Points.Count - 1;
						class2.Points[index2].YFormat = item.NumberFormatOfYValues;
						if (yValue.Data != null && !string.IsNullOrEmpty(yValue.Data.ToString()))
						{
							double num = item.DataPoints[j].XValue.ToDouble();
							if (double.IsNaN(num))
							{
								if (item.DataPoints[j].XValue.AsISingleCellChartValue.AsCell == null)
								{
									continue;
								}
								if (item.DataPoints[j].XValue.AsISingleCellChartValue.AsCell.Value == null)
								{
									class2.Points[index2].NotPlotted = true;
									continue;
								}
								num = j + 1;
							}
							array[j] = num;
							IDoubleChartValue bubbleSize = item.DataPoints[j].BubbleSize;
							if (bubbleSize.DataSourceType != 0 || bubbleSize.AsCell != null)
							{
								array2[j] = ((bubbleSize.Data == null || double.IsNaN(bubbleSize.ToDouble())) ? 0.0 : bubbleSize.ToDouble());
							}
						}
						else
						{
							class2.Points[index2].NotPlotted = true;
						}
					}
					class2.imethod_1(array);
					class2.imethod_2(array2);
				}
				for (int k = 0; k < class2.Points.Count; k++)
				{
					Interface12 @interface = class2.Points[k];
					@interface.XFormat = item.NumberFormatOfXValues;
					@interface.BubbleSizeFormat = item.NumberFormatOfBubbleSizes;
				}
				class2.BarShape = item.Bar3DShape;
				method_23(item, class2, @class);
			}
		}
		if (chartData_0.Categories.Count > 0)
		{
			method_18(chartData_0, @class.NSeries, secondaryCategories: false);
		}
		if (chartData_0.UseSecondaryCategories && chartData_0.SecondaryCategories.Count > 0)
		{
			method_18(chartData_0, @class.NSeries, secondaryCategories: true);
		}
		method_22(@class);
		method_21(@class);
		@class.IsInnerMode = true;
		if (chartPlotArea_0.IsLocationAutocalculated)
		{
			@class.PlotArea.IsXAuto = true;
			@class.PlotArea.IsYAuto = true;
			@class.PlotArea.IsSizeAuto = true;
		}
		else
		{
			@class.PlotArea.IsXAuto = false;
			@class.PlotArea.X = ((!float.IsNaN(chartPlotArea_0.XInternal)) ? ((int)(chartPlotArea_0.XInternal * 4000f)) : 0);
			@class.PlotArea.IsYAuto = false;
			@class.PlotArea.Y = ((!float.IsNaN(chartPlotArea_0.YInternal)) ? ((int)(chartPlotArea_0.YInternal * 4000f)) : 0);
			@class.PlotArea.IsSizeAuto = false;
			@class.PlotArea.Width = (float.IsNaN(chartPlotArea_0.WidthInternal) ? ((int)(base.Width * 4000f - (float)@class.PlotArea.X)) : ((int)(chartPlotArea_0.WidthInternal * 4000f)));
			@class.PlotArea.Height = (float.IsNaN(chartPlotArea_0.HeightInternal) ? ((int)(base.Height * 4000f - (float)@class.PlotArea.Y)) : ((int)(chartPlotArea_0.HeightInternal * 4000f)));
		}
		if (ChartData.Series.Count > 0)
		{
			@class.GapWidth = ChartData.Series[0].ParentSeriesGroup.GapWidth;
		}
		return @class;
	}

	private void method_18(ChartData chartData, Interface20 internalNSeries, bool secondaryCategories)
	{
		IChartCategoryCollection chartCategoryCollection = (secondaryCategories ? chartData.SecondaryCategories : chartData.Categories);
		Interface7 @interface = (secondaryCategories ? internalNSeries.Category2Labels : internalNSeries.CategoryLabels);
		Interface8[] array = new Interface8[chartCategoryCollection.GroupingLevelCount];
		for (int i = 0; i < chartCategoryCollection.Count; i++)
		{
			for (int num = chartCategoryCollection.GroupingLevelCount - 1; num >= 0; num--)
			{
				int num2 = chartCategoryCollection.GroupingLevelCount - 1 - num;
				object obj = ((chartCategoryCollection[i].GroupingLevels == null) ? chartCategoryCollection[i].Value : chartCategoryCollection[i].GroupingLevels[num].Value);
				if (array[num2] == null || obj != null || num2 == chartCategoryCollection.GroupingLevelCount - 1)
				{
					Interface8 interface2 = ((num2 != 0) ? array[num2 - 1].Children.imethod_0(obj) : @interface.imethod_0(obj ?? ""));
					if (obj == null)
					{
						interface2.IsNull = true;
					}
					for (int j = num2; j < chartCategoryCollection.GroupingLevelCount; j++)
					{
						array[j] = null;
					}
					array[num2] = interface2;
				}
			}
		}
	}

	private static MemoryStream smethod_2(Interface5 c)
	{
		MemoryStream memoryStream = new MemoryStream();
		Class792.smethod_1(Class792.int_0, c.ActualChartSize.Width, c.ActualChartSize.Height, ImageFormat.Png, null, memoryStream, c)?.imethod_0();
		return memoryStream;
	}

	private static MemoryStream smethod_3(Interface5 c)
	{
		MemoryStream memoryStream = new MemoryStream();
		Class792.smethod_1(Class792.int_0, c.ActualChartSize.Width, c.ActualChartSize.Height, ImageFormat.Emf, null, memoryStream, c)?.imethod_0();
		return memoryStream;
	}

	private void method_19(Class740 chNew)
	{
		Color[] array = new Color[12];
		if (PPTXUnsupportedProps.ColorMappingOverride.On && ThemeManager.IsOverrideThemeEnabled)
		{
			IColorScheme colorScheme = ThemeManager.OverrideTheme.ColorScheme;
			ref Color reference = ref array[0];
			reference = colorScheme.Light1.Color;
			ref Color reference2 = ref array[1];
			reference2 = colorScheme.Dark1.Color;
			ref Color reference3 = ref array[2];
			reference3 = colorScheme.Light2.Color;
			ref Color reference4 = ref array[3];
			reference4 = colorScheme.Dark2.Color;
			ref Color reference5 = ref array[4];
			reference5 = colorScheme.Accent1.Color;
			ref Color reference6 = ref array[5];
			reference6 = colorScheme.Accent2.Color;
			ref Color reference7 = ref array[6];
			reference7 = colorScheme.Accent3.Color;
			ref Color reference8 = ref array[7];
			reference8 = colorScheme.Accent4.Color;
			ref Color reference9 = ref array[8];
			reference9 = colorScheme.Accent5.Color;
			ref Color reference10 = ref array[9];
			reference10 = colorScheme.Accent6.Color;
			ref Color reference11 = ref array[10];
			reference11 = colorScheme.Hyperlink.Color;
			ref Color reference12 = ref array[11];
			reference12 = colorScheme.FollowedHyperlink.Color;
			bool_7 = true;
			chNew.imethod_1(array);
			chNew.StyleIndex = (int)(Style + 1);
		}
		else
		{
			IColorSchemeEffectiveData colorScheme2 = base.Slide.CreateThemeEffective().GetColorScheme(Color.Empty);
			ref Color reference13 = ref array[0];
			reference13 = colorScheme2.Light1;
			ref Color reference14 = ref array[1];
			reference14 = colorScheme2.Dark1;
			ref Color reference15 = ref array[2];
			reference15 = colorScheme2.Light2;
			ref Color reference16 = ref array[3];
			reference16 = colorScheme2.Dark2;
			ref Color reference17 = ref array[4];
			reference17 = colorScheme2.Accent1;
			ref Color reference18 = ref array[5];
			reference18 = colorScheme2.Accent2;
			ref Color reference19 = ref array[6];
			reference19 = colorScheme2.Accent3;
			ref Color reference20 = ref array[7];
			reference20 = colorScheme2.Accent4;
			ref Color reference21 = ref array[8];
			reference21 = colorScheme2.Accent5;
			ref Color reference22 = ref array[9];
			reference22 = colorScheme2.Accent6;
			ref Color reference23 = ref array[10];
			reference23 = colorScheme2.Hyperlink;
			ref Color reference24 = ref array[11];
			reference24 = colorScheme2.FollowedHyperlink;
			chNew.imethod_1(array);
			chNew.StyleIndex = (int)(Style + 1);
		}
	}

	private void method_20(Class159 canvas, Class169 rc)
	{
		if (groupShape_0 != null)
		{
			method_26();
			groupShape_0.vmethod_4(canvas, rc);
		}
	}

	private void method_21(Class740 chNew)
	{
		if (BackWall != null && BackWall.Format != null)
		{
			method_16(chNew.BackWalls.Area, (FillFormat)BackWall.Format.Fill, chNew);
		}
		if (SideWall != null && SideWall.Format != null)
		{
			method_16(chNew.SideWalls.Area, (FillFormat)SideWall.Format.Fill, chNew);
		}
		if (Floor != null && Floor.Format != null)
		{
			method_16(chNew.Floor.Area, (FillFormat)Floor.Format.Fill, chNew);
		}
		if (Rotation3D != null)
		{
			chNew.Elevation = Rotation3D.RotationX;
			chNew.Rotation = Rotation3D.RotationY;
		}
	}

	private void method_22(Class740 chNew)
	{
		chNew.IsRectangularCornered = PPTXUnsupportedProps.RoundedCorners;
		chNew.ChartArea.Border.LineStyle.Width = LineFormat.Width;
		if (chartPlotArea_0.Format.Line.FillFormat.FillType == FillType.Solid)
		{
			chNew.PlotArea.Border.Color = ((chartPlotArea_0.Format.Line.FillFormat.SolidFillColor.ColorType == ColorType.Scheme) ? ((BaseSlide)base.Slide).method_2(chartPlotArea_0.Format.Line.FillFormat.SolidFillColor.SchemeColor).Color : chartPlotArea_0.Format.Line.FillFormat.SolidFillColor.Color);
			chNew.PlotArea.Border.Formatting = FillType.Solid;
			chNew.PlotArea.Border.IsColorAuto = false;
		}
		else
		{
			chNew.PlotArea.Border.Formatting = FillType.NoFill;
		}
		method_16(chNew.PlotArea.Area, (FillFormat)chartPlotArea_0.Format.Fill, chNew);
	}

	private void method_23(ChartSeries ser, Class759 newSer, Class740 chNew)
	{
		newSer.SeriesIndex = (int)ser.PPTXUnsupportedProps.Idx;
		if (ser.Name.ToString() != "")
		{
			newSer.Name = ser.Name.ToString();
		}
		newSer.Overlap = ser.Overlap;
		if (ser.Labels != null && ser.Labels.IsVisible)
		{
			for (int i = 0; i < newSer.Points.Count; i++)
			{
				newSer.Points[i].DataLabels.ChartFrame.TextFont = method_15(((DataLabelFormat)((DataLabel)ser.Labels[i]).DataLabelFormat).TextFormatManager, ser.Labels[i].TextFrameForOverriding, isBold: false, isTitle: false);
				float rotationAngle = ((TextFrameFormat)ser.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat).RotationAngle;
				if (!float.IsNaN(rotationAngle))
				{
					newSer.Points[i].DataLabels.Rotation = (int)Math.Abs(rotationAngle);
				}
				IFillFormat fillFormat = ((DataLabelFormat)ser.Labels.DefaultDataLabelFormat).TextFormatManager.TextFormatOfAutoText.PortionFormat.FillFormat;
				if (fillFormat.FillType == FillType.Solid)
				{
					newSer.Points[i].DataLabels.ChartFrame.FontColor = fillFormat.SolidFillColor.Color;
				}
				newSer.Points[i].DataLabels.ChartFrame.FontColor = method_14(((DataLabelFormat)ser.Labels.DefaultDataLabelFormat).TextFormatManager, null, newSer.Points[i].DataLabels.ChartFrame.FontColor, chNew);
				newSer.Points[i].DataLabels.ChartFrame.TextFont = method_15(((DataLabelFormat)ser.Labels.DefaultDataLabelFormat).TextFormatManager, null, isBold: false, isTitle: false);
				newSer.Points[i].DataLabels.LabelPosition = ((ser.Labels.DefaultDataLabelFormat.Position != LegendDataLabelPosition.NotDefined) ? ser.Labels.DefaultDataLabelFormat.Position : Struct28.smethod_11(newSer.Type));
			}
			for (int j = 0; j < newSer.Points.Count; j++)
			{
				DataLabel dataLabel = (DataLabel)ser.DataPoints[j].Label;
				if (dataLabel.DataLabelFormat.ShowLegendKey)
				{
					newSer.Points[j].DataLabels.IsLegendKeyShown = true;
				}
				if (dataLabel.DataLabelFormat.ShowCategoryName)
				{
					newSer.Points[j].DataLabels.IsCategoryNameShown = true;
				}
				if (dataLabel.DataLabelFormat.ShowPercentage)
				{
					newSer.Points[j].DataLabels.IsPercentageShown = true;
				}
				if (dataLabel.DataLabelFormat.ShowValue)
				{
					newSer.Points[j].DataLabels.IsValueShown = true;
				}
				if (dataLabel.DataLabelFormat.ShowBubbleSize)
				{
					newSer.Points[j].DataLabels.IsBubbleSizeShown = true;
				}
				if (dataLabel.DataLabelFormat.ShowSeriesName)
				{
					newSer.Points[j].DataLabels.IsSeriesNameShown = true;
				}
				float num = ((dataLabel.TextFrameForOverriding == null) ? ((TextFrameFormat)((DataLabelFormat)dataLabel.DataLabelFormat).TextFormatManager.TextFormatOfAutoText.TextBlockFormat).RotationAngle : ((TextFrameFormat)dataLabel.TextFrameForOverriding.TextFrameFormat).PPTXUnsupportedProps.RotationAngle);
				if (!float.IsNaN(num))
				{
					newSer.Points[j].DataLabels.Rotation = (int)Math.Abs(num);
				}
				newSer.Points[j].DataLabels.ChartFrame.FontColor = method_14(((DataLabelFormat)dataLabel.DataLabelFormat).TextFormatManager, dataLabel.TextFrameForOverriding, newSer.Points[j].DataLabels.ChartFrame.FontColor, chNew);
				if (dataLabel.DataLabelFormat.NumberFormat != "")
				{
					newSer.Points[j].DataLabels.LinkedSource = false;
					newSer.Points[j].DataLabels.Format = dataLabel.DataLabelFormat.NumberFormat;
				}
				if (dataLabel.DataLabelFormat.Position != LegendDataLabelPosition.NotDefined)
				{
					newSer.Points[j].DataLabels.LabelPosition = dataLabel.DataLabelFormat.Position;
				}
				if (!float.IsNaN(dataLabel.X))
				{
					newSer.Points[j].DataLabels.ChartFrame.IsEdge = false;
					newSer.Points[j].DataLabels.ChartFrame.X = (int)(dataLabel.X * 4000f);
				}
				if (!float.IsNaN(dataLabel.Y))
				{
					newSer.Points[j].DataLabels.ChartFrame.IsEdge = false;
					newSer.Points[j].DataLabels.ChartFrame.Y = (int)(dataLabel.Y * 4000f);
				}
				if (dataLabel.TextFrameForOverriding != null && ((TextFrame)dataLabel.TextFrameForOverriding).TextInternal != "")
				{
					newSer.Points[j].DataLabels.Text = ((TextFrame)dataLabel.TextFrameForOverriding).TextInternal.Replace("\r", "\n");
				}
			}
		}
		if (ser.TrendLines != null && ser.TrendLines.Count > 0)
		{
			foreach (Trendline trendLine in ser.TrendLines)
			{
				newSer.Trendlines.Add(trendLine.TrendlineType);
				Interface23 @interface = newSer.Trendlines[0];
				if (trendLine.Format.Line.FillFormat.FillType == FillType.Solid)
				{
					@interface.Border.Formatting = FillType.Solid;
					@interface.Border.IsColorAuto = false;
					if (trendLine.Format.Line.FillFormat.SolidFillColor.SchemeColor != SchemeColor.NotDefined && trendLine.Format.Line.FillFormat.SolidFillColor.Color.Name == "ff000000")
					{
						ColorFormat colorFormat = ((Slide)base.Slide).method_2(trendLine.Format.Line.FillFormat.SolidFillColor.SchemeColor);
						((ColorOperationCollection)colorFormat.ColorTransform).list_0 = ((ColorOperationCollection)trendLine.Format.Line.FillFormat.SolidFillColor.ColorTransform).list_0;
						@interface.Border.Color = colorFormat.Color;
					}
					else
					{
						@interface.Border.Color = trendLine.Format.Line.FillFormat.SolidFillColor.Color;
					}
				}
				if (!double.IsNaN(trendLine.Format.Line.Width))
				{
					@interface.Border.LineStyle.Width = trendLine.Format.Line.Width;
				}
			}
		}
		if (ser.Format.Line.FillFormat.FillType == FillType.Solid)
		{
			newSer.Line.Formatting = FillType.Solid;
			newSer.Line.IsColorAuto = false;
			if (ser.Format.Line.FillFormat.SolidFillColor.ColorType == ColorType.Scheme)
			{
				ColorFormat colorFormat2 = new ColorFormat(this, chNew.Themes.ThemeColors.Colors[((ColorFormat)ser.Format.Line.FillFormat.SolidFillColor).int_0]);
				((ColorOperationCollection)colorFormat2.ColorTransform).list_0 = ((ColorOperationCollection)ser.Format.Line.FillFormat.SolidFillColor.ColorTransform).list_0;
				newSer.Line.Color = colorFormat2.Color;
			}
			else
			{
				newSer.Line.Color = ser.Format.Line.FillFormat.SolidFillColor.Color;
			}
		}
		if (!double.IsNaN(ser.Format.Line.Width))
		{
			newSer.Line.LineStyle.Width = ser.Format.Line.Width;
		}
		if (ser.Format.Line.FillFormat.FillType == FillType.NoFill)
		{
			newSer.Line.Formatting = FillType.NoFill;
		}
		if (ser.Format.Line.DashStyle != LineDashStyle.NotDefined)
		{
			newSer.Line.LineStyle.DashStyle = ser.Format.Line.DashStyle;
		}
		method_16(newSer.Area, (FillFormat)ser.Format.Fill, chNew);
		newSer.Marker.MarkerSize = ser.Marker.Size;
		newSer.Marker.MarkerStyle = ser.Marker.Symbol;
		if (ser.Marker.Format != null && ser.Marker.Format.Fill.FillType != FillType.NotDefined)
		{
			newSer.Marker.Area.ForegroundColor = ser.Marker.Format.Fill.SolidFillColor.Color;
			if (ser.Marker.Format.Fill.FillType == FillType.Solid)
			{
				newSer.Marker.Area.Formatting = FillType.Solid;
			}
			if (ser.Marker.Format.Fill.FillType == FillType.NoFill)
			{
				newSer.Marker.Area.Formatting = FillType.NoFill;
			}
			newSer.Marker.Border.Color = ser.Marker.Format.Fill.SolidFillColor.Color;
			newSer.Marker.Border.Formatting = FillType.Solid;
			newSer.Marker.Border.IsColorAuto = false;
		}
		if (ser.Marker.Format != null && ser.Marker.Format.Line.FillFormat.FillType != FillType.NotDefined)
		{
			if (ser.Marker.Format.Line.FillFormat.SolidFillColor.ColorType == ColorType.Scheme)
			{
				ColorFormat colorFormat3 = new ColorFormat(this, chNew.Themes.ThemeColors.Colors[((ColorFormat)ser.Marker.Format.Line.FillFormat.SolidFillColor).int_0]);
				((ColorOperationCollection)colorFormat3.ColorTransform).list_0 = ((ColorOperationCollection)ser.Marker.Format.Line.FillFormat.SolidFillColor.ColorTransform).list_0;
				newSer.Marker.Border.Color = colorFormat3.Color;
			}
			else
			{
				newSer.Marker.Border.Color = ser.Marker.Format.Line.FillFormat.SolidFillColor.Color;
			}
			newSer.Marker.Border.IsColorAuto = false;
			if (ser.Marker.Format.Line.FillFormat.FillType == FillType.Solid)
			{
				newSer.Marker.Border.Formatting = FillType.Solid;
			}
			if (ser.Marker.Format.Line.FillFormat.FillType == FillType.NoFill)
			{
				newSer.Marker.Border.Formatting = FillType.NoFill;
			}
		}
		newSer.HasSeriesLines = ser.HasSeriesLines;
		newSer.Area.InvertIfNegative = ser.InvertIfNegative;
		for (int k = 0; k < newSer.Points.Count; k++)
		{
			newSer.Points[k].Border.IsColorAuto = newSer.Line.IsColorAuto;
			newSer.Points[k].Border.Formatting = newSer.Line.Formatting;
			newSer.Points[k].Border.Color = newSer.Line.Color;
			newSer.Points[k].Border.LineStyle.Width = newSer.Line.LineStyle.Width;
			newSer.Points[k].Area.Formatting = newSer.Area.Formatting;
			newSer.Points[k].Area.ForegroundColor = newSer.Area.ForegroundColor;
			newSer.Points[k].Border.LineStyle.DashStyle = newSer.Line.LineStyle.DashStyle;
			newSer.Points[k].Border.Formatting = newSer.Line.Formatting;
			newSer.Points[k].Marker.MarkerSize = newSer.Marker.MarkerSize;
			newSer.Points[k].Marker.MarkerStyle = newSer.Marker.MarkerStyle;
			newSer.Points[k].Marker.Area.ForegroundColor = newSer.Marker.Area.ForegroundColor;
			newSer.Points[k].Marker.Area.Formatting = newSer.Marker.Area.Formatting;
			newSer.Points[k].Marker.Border.Color = newSer.Marker.Border.Color;
			newSer.Points[k].Marker.Border.Formatting = newSer.Marker.Border.Formatting;
			newSer.Points[k].Marker.Border.IsColorAuto = newSer.Marker.Border.IsColorAuto;
			newSer.Points[k].Area.InvertIfNegative = ser.InvertIfNegative;
		}
		for (int l = 0; l < newSer.Points.Count; l++)
		{
			IChartDataPoint chartDataPoint = ser.DataPoints[l];
			method_16(newSer.Points[l].Area, (FillFormat)chartDataPoint.Format.Fill, chNew);
			if (chartDataPoint.Format.Line.FillFormat.FillType == FillType.NoFill)
			{
				newSer.Points[l].Border.Formatting = FillType.NoFill;
			}
			if (chartDataPoint.Format.Line.FillFormat.FillType == FillType.Solid)
			{
				newSer.Points[l].Border.Formatting = FillType.Solid;
				newSer.Points[l].Border.IsColorAuto = false;
				if (chartDataPoint.Format.Line.FillFormat.SolidFillColor.SchemeColor != SchemeColor.NotDefined && chartDataPoint.Format.Line.FillFormat.SolidFillColor.Color.Name == "ff000000")
				{
					newSer.Points[l].Border.Color = ((BaseSlide)base.Slide).method_2(chartDataPoint.Format.Line.FillFormat.SolidFillColor.SchemeColor).Color;
				}
				else
				{
					newSer.Points[l].Border.Color = chartDataPoint.Format.Line.FillFormat.SolidFillColor.Color;
				}
			}
			if (!double.IsNaN(chartDataPoint.Format.Line.Width))
			{
				newSer.Points[l].Border.LineStyle.Width = chartDataPoint.Format.Line.Width;
			}
			if (chartDataPoint.Format.Line.DashStyle != LineDashStyle.NotDefined)
			{
				newSer.Points[l].Border.LineStyle.DashStyle = chartDataPoint.Format.Line.DashStyle;
			}
			newSer.Points[l].Explosion = ((chartDataPoint.Explosion == -1) ? ser.Explosion : chartDataPoint.Explosion);
		}
		IUpDownBarsManager upDownBars = ser.ParentSeriesGroup.UpDownBars;
		if (upDownBars.HasUpDownBars)
		{
			newSer.HasUpDownBars = true;
			method_16(newSer.UpBars.Area, (FillFormat)upDownBars.UpBarsFormat.Fill, chNew);
			if (upDownBars.UpBarsFormat.Line.FillFormat.FillType == FillType.Solid)
			{
				newSer.UpBars.Border.LineStyle.DashStyle = LineDashStyle.Solid;
				newSer.UpBars.Border.Color = upDownBars.UpBarsFormat.Line.FillFormat.SolidFillColor.Color;
			}
			method_16(newSer.UpBars.Area, (FillFormat)upDownBars.DownBarsFormat.Fill, chNew);
			if (upDownBars.DownBarsFormat.Line.FillFormat.FillType == FillType.Solid)
			{
				newSer.DownBars.Border.LineStyle.DashStyle = LineDashStyle.Solid;
				newSer.DownBars.Border.Color = upDownBars.DownBarsFormat.Line.FillFormat.SolidFillColor.Color;
			}
		}
		newSer.HasHighLowLines = ser.HasHiLowLines;
		newSer.PlotOnSecondAxis = ser.PlotOnSecondAxis;
		newSer.AngleOfFirstSlice = ser.FirstSliceAngle;
		if (ser.ErrorBarsXFormat != null)
		{
			method_24(ser.ErrorBarsXFormat, (Class752)newSer.XErrorBar, ser, xDir: true, chNew);
		}
		if (ser.ErrorBarsYFormat != null)
		{
			method_24(ser.ErrorBarsYFormat, (Class752)newSer.YErrorBar, ser, xDir: false, chNew);
		}
	}

	private void method_24(IErrorBarsFormat srcErrBar, Class752 newErrBar, IChartSeries ser, bool xDir, Class740 chNew)
	{
		newErrBar.IsVisible = srcErrBar.IsVisible;
		newErrBar.DisplayType = srcErrBar.Type;
		newErrBar.Type = srcErrBar.ValueType;
		newErrBar.Amount = srcErrBar.Value;
		newErrBar.ShowMarkerTTop = srcErrBar.HasEndCap;
		if (srcErrBar.ValueType == ErrorBarValueType.Custom)
		{
			for (int i = 0; i < ser.DataPoints.Count; i++)
			{
				IDoubleChartValue doubleChartValue = (xDir ? ((ChartDataPoint)ser.DataPoints[i]).ErrorBarsCustomValues.XMinus : ((ChartDataPoint)ser.DataPoints[i]).ErrorBarsCustomValues.YMinus);
				IDoubleChartValue doubleChartValue2 = (xDir ? ((ChartDataPoint)ser.DataPoints[i]).ErrorBarsCustomValues.XPlus : ((ChartDataPoint)ser.DataPoints[i]).ErrorBarsCustomValues.YPlus);
				newErrBar.MinusValue.Add((doubleChartValue.Data == null || double.IsNaN(doubleChartValue.ToDouble())) ? 0.0 : doubleChartValue.ToDouble());
				newErrBar.PlusValue.Add((doubleChartValue2.Data == null || double.IsNaN(doubleChartValue2.ToDouble())) ? 0.0 : doubleChartValue2.ToDouble());
			}
		}
		if (srcErrBar.Format.Line.FillFormat.FillType == FillType.NoFill)
		{
			newErrBar.Border.Formatting = FillType.NoFill;
		}
		if (srcErrBar.Format.Line.FillFormat.FillType == FillType.Solid)
		{
			newErrBar.Border.Formatting = FillType.Solid;
			newErrBar.Border.IsColorAuto = false;
			if (srcErrBar.Format.Line.FillFormat.SolidFillColor.ColorType == ColorType.Scheme)
			{
				ColorFormat colorFormat = new ColorFormat(this, chNew.Themes.ThemeColors.Colors[((ColorFormat)srcErrBar.Format.Line.FillFormat.SolidFillColor).int_0]);
				((ColorOperationCollection)colorFormat.ColorTransform).list_0 = ((ColorOperationCollection)srcErrBar.Format.Line.FillFormat.SolidFillColor.ColorTransform).list_0;
				newErrBar.Border.Color = colorFormat.Color;
			}
			else
			{
				newErrBar.Border.Color = srcErrBar.Format.Line.FillFormat.SolidFillColor.Color;
			}
		}
		if (srcErrBar.Format.Line.DashStyle != LineDashStyle.NotDefined)
		{
			newErrBar.Border.LineStyle.DashStyle = srcErrBar.Format.Line.DashStyle;
		}
		if (!double.IsNaN(srcErrBar.Format.Line.Width))
		{
			newErrBar.Border.LineStyle.Width = srcErrBar.Format.Line.Width;
		}
	}

	internal void method_25()
	{
		IChartSeriesCollection series = ChartData.Series;
		List<ChartType> list = new List<ChartType>();
		foreach (ChartSeries item in series)
		{
			if (!list.Contains(item.Type))
			{
				list.Add(item.Type);
			}
		}
		if (list.Count == 1)
		{
			chartType_0 = list[0];
		}
		else if (list.Count > 1)
		{
			chartType_0 = ChartType.SeriesOfMixedTypes;
		}
	}

	public IThemeEffectiveData CreateThemeEffective()
	{
		return ThemeManager.CreateThemeEffective();
	}

	private void method_26()
	{
		Class154 rawFrameImpl = RawFrameImpl;
		groupShape_0.RawFrameImpl.method_1(rawFrameImpl.X, rawFrameImpl.Y, rawFrameImpl.Width, rawFrameImpl.Height, rawFrameImpl.Rotation, rawFrameImpl.FlipH, rawFrameImpl.FlipV);
		groupShape_0.RawFrameImpl.method_5(0.0, 0.0, rawFrameImpl.Width, rawFrameImpl.Height);
	}

	internal void method_27()
	{
		uint minCol = uint.MaxValue;
		uint minRow = uint.MaxValue;
		uint maxCol = 0u;
		uint maxRow = 0u;
		method_28(ref minCol, ref minRow, ref maxCol, ref maxRow);
		minCol = maxCol;
		bool flag = false;
		foreach (ChartSeries item in ChartData.Series)
		{
			if (item.Name.DataSourceType == DataSourceType.Worksheet)
			{
				if (item.Name.AsCells.Count == 0)
				{
					flag = true;
					break;
				}
				foreach (ChartDataCell asCell in item.Name.AsCells)
				{
					method_29(ref minCol, ref minRow, ref maxCol, ref maxRow, asCell);
				}
			}
			foreach (IChartDataPoint dataPoint in item.DataPoints)
			{
				if (item.DataPoints.DataSourceTypeForValues == DataSourceType.Worksheet)
				{
					method_29(ref minCol, ref minRow, ref maxCol, ref maxRow, dataPoint.Value.AsCell);
				}
				if (item.DataPoints.DataSourceTypeForXValues == DataSourceType.Worksheet)
				{
					method_29(ref minCol, ref minRow, ref maxCol, ref maxRow, dataPoint.XValue.AsCell);
				}
				if (item.DataPoints.DataSourceTypeForYValues == DataSourceType.Worksheet)
				{
					method_29(ref minCol, ref minRow, ref maxCol, ref maxRow, dataPoint.YValue.AsCell);
				}
				if (item.DataPoints.DataSourceTypeForBubbleSizes == DataSourceType.Worksheet)
				{
					method_29(ref minCol, ref minRow, ref maxCol, ref maxRow, dataPoint.BubbleSize.AsCell);
				}
			}
		}
		if (minCol == uint.MaxValue && minRow == uint.MaxValue)
		{
			minCol = 0u;
			minRow = 0u;
		}
		Class1097 @class = null;
		Class809 class2 = null;
		if (!flag && ChartData.Series.Count > 0)
		{
			IChartDataPointCollection dataPoints = ChartData.Series[0].DataPoints;
			if (dataPoints.Count > 0)
			{
				if (dataPoints.DataSourceTypeForValues == DataSourceType.Worksheet && dataPoints[0].Value.AsCell != null)
				{
					class2 = ((ChartDataWorksheet)dataPoints[0].Value.AsCell.ChartDataWorksheet).class809_0;
					class2.Clear();
					@class = class2.Add();
				}
				else if (dataPoints.DataSourceTypeForXValues == DataSourceType.Worksheet && dataPoints[0].XValue.AsCell != null)
				{
					class2 = ((ChartDataWorksheet)dataPoints[0].XValue.AsCell.ChartDataWorksheet).class809_0;
					class2.Clear();
					@class = class2.Add();
				}
				else if (dataPoints.DataSourceTypeForYValues == DataSourceType.Worksheet && dataPoints[0].YValue.AsCell != null)
				{
					class2 = ((ChartDataWorksheet)dataPoints[0].YValue.AsCell.ChartDataWorksheet).class809_0;
					class2.Clear();
					@class = class2.Add();
				}
				else if (dataPoints.DataSourceTypeForBubbleSizes == DataSourceType.Worksheet && dataPoints[0].BubbleSize.AsCell != null)
				{
					class2 = ((ChartDataWorksheet)dataPoints[0].BubbleSize.AsCell.ChartDataWorksheet).class809_0;
					class2.Clear();
					@class = class2.Add();
				}
			}
		}
		if (@class != null)
		{
			@class.uint_0 = new uint[4] { minCol, minRow, maxCol, maxRow };
		}
	}

	private void method_28(ref uint minCol, ref uint minRow, ref uint maxCol, ref uint maxRow)
	{
		if (ChartData.Categories.UseCells)
		{
			foreach (ChartCategory category in ChartData.Categories)
			{
				for (int i = 0; i < ChartData.Categories.GroupingLevelCount; i++)
				{
					method_29(ref minCol, ref minRow, ref maxCol, ref maxRow, category.GroupingLevels[i]);
				}
			}
		}
		if (!ChartData.UseSecondaryCategories || !ChartData.SecondaryCategories.UseCells)
		{
			return;
		}
		foreach (ChartCategory secondaryCategory in ChartData.SecondaryCategories)
		{
			for (int j = 0; j < ChartData.SecondaryCategories.GroupingLevelCount; j++)
			{
				method_29(ref minCol, ref minRow, ref maxCol, ref maxRow, secondaryCategory.GroupingLevels[j]);
			}
		}
	}

	private void method_29(ref uint colMin, ref uint rowMin, ref uint colMax, ref uint rowMax, IChartDataCell cell)
	{
		if (cell != null)
		{
			if (cell.Column < colMin)
			{
				colMin = (uint)cell.Column;
			}
			if (cell.Row < rowMin)
			{
				rowMin = (uint)cell.Row;
			}
			if (cell.Column > colMax)
			{
				colMax = (uint)cell.Column;
			}
			if (cell.Row > rowMax)
			{
				rowMax = (uint)cell.Row;
			}
		}
	}
}
