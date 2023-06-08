using System;
using System.Collections.Generic;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.SlideShow;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Theme;
using ns22;
using ns24;
using ns28;
using ns4;

namespace Aspose.Slides;

public abstract class BaseSlide : IPresentationComponent, ISlideComponent, IThemeable, IBaseSlide
{
	private Presentation presentation_0;

	private uint uint_0 = 1u;

	private uint uint_1 = 1000u;

	private string string_0;

	private Background background_0;

	private readonly CustomData customData_0;

	private readonly ControlCollection controlCollection_0;

	private readonly AnimationTimeLine animationTimeLine_0;

	private readonly ulong ulong_0;

	private HyperlinkQueries hyperlinkQueries_0;

	internal SlideShowTransition slideShowTransition_0;

	internal Class518 class518_0;

	internal GroupShape groupShape_0;

	internal static readonly BaseSlide[] baseSlide_0 = new BaseSlide[0];

	internal static readonly Shape[] shape_0 = new Shape[0];

	internal abstract Class296 BaseSlidePPTXUnsupportedProps { get; }

	internal abstract Class262 BaseSlidePPTUnsupportedProps { get; }

	[Obsolete("Use Presentation property instead. Property will be removed after 01.09.2013.")]
	public IPresentation ParentPresentation => presentation_0;

	public IShapeCollection Shapes => groupShape_0.Shapes;

	public IControlCollection Controls => controlCollection_0;

	public virtual string Name
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

	public uint SlideId => BaseSlidePPTXUnsupportedProps.SlideId;

	internal ulong SlideInternalId => ulong_0;

	internal IThemeManager ThemeManagerInternal => Aspose.Slides.Theme.Theme.smethod_0(this);

	[Obsolete("Use CustomData.Tags instead. Will be removed after 01.09.2014.")]
	public ITagCollection Tags => customData_0.Tags;

	public ICustomData CustomData => customData_0;

	public IAnimationTimeLine Timeline => animationTimeLine_0;

	public virtual ISlideShowTransition SlideShowTransition => slideShowTransition_0;

	public IBackground Background => background_0;

	public IHyperlinkQueries HyperlinkQueries
	{
		get
		{
			if (hyperlinkQueries_0 == null)
			{
				hyperlinkQueries_0 = new HyperlinkQueries(this);
			}
			return hyperlinkQueries_0;
		}
	}

	internal uint NextShapeId => uint_0;

	internal virtual IBaseSlide[] BaseSlides => baseSlide_0;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	IThemeable IBaseSlide.AsIThemeable => this;

	ISlideComponent IThemeable.AsISlideComponent => this;

	public IPresentation Presentation => presentation_0;

	internal Presentation PresentationInternal
	{
		get
		{
			return presentation_0;
		}
		set
		{
			presentation_0 = value;
		}
	}

	IBaseSlide ISlideComponent.Slide => this;

	internal BaseSlide(Presentation parentPresentation)
	{
		BaseSlidePPTUnsupportedProps.method_0(this);
		presentation_0 = parentPresentation;
		ulong_0 = parentPresentation.method_18();
		customData_0 = new CustomData();
		controlCollection_0 = new ControlCollection(this);
		animationTimeLine_0 = new AnimationTimeLine(this);
		background_0 = new Background(this);
		groupShape_0 = new GroupShape(this);
		class518_0 = new Class518(this);
	}

	public virtual void JoinPortionsWithSameFormatting()
	{
		JoinPortionsWithSameFormatting(Shapes);
	}

	public virtual void JoinPortionsWithSameFormatting(IShapeCollection collection)
	{
		foreach (IShape item in collection)
		{
			if (item is ISmartArt smartArt)
			{
				foreach (SmartArtNode allNode in smartArt.AllNodes)
				{
					if (allNode.TextFrame != null)
					{
						allNode.TextFrame.JoinPortionsWithSameFormatting();
					}
				}
			}
			if (item is IAutoShape autoShape && autoShape.TextFrame != null)
			{
				autoShape.TextFrame.JoinPortionsWithSameFormatting();
			}
			if (item is ITable table)
			{
				for (int i = 0; i < table.Rows.Count; i++)
				{
					for (int j = 0; j < table.Columns.Count; j++)
					{
						table[j, i].TextFrame.JoinPortionsWithSameFormatting();
					}
				}
			}
			if (item is IChart chart)
			{
				if (chart.ChartTitle.TextFrameForOverriding != null)
				{
					chart.ChartTitle.TextFrameForOverriding.JoinPortionsWithSameFormatting();
				}
				if (chart.Axes.HorizontalAxis != null && chart.Axes.HorizontalAxis.Title.TextFrameForOverriding != null)
				{
					chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.JoinPortionsWithSameFormatting();
				}
				if (chart.Axes.SecondaryHorizontalAxis != null && chart.Axes.SecondaryHorizontalAxis.Title.TextFrameForOverriding != null)
				{
					chart.Axes.SecondaryHorizontalAxis.Title.TextFrameForOverriding.JoinPortionsWithSameFormatting();
				}
				if (chart.Axes.SecondaryVerticalAxis != null && chart.Axes.SecondaryVerticalAxis.Title.TextFrameForOverriding != null)
				{
					chart.Axes.SecondaryVerticalAxis.Title.TextFrameForOverriding.JoinPortionsWithSameFormatting();
				}
				if (chart.Axes.SeriesAxis != null && chart.Axes.SeriesAxis.Title.TextFrameForOverriding != null)
				{
					chart.Axes.SeriesAxis.Title.TextFrameForOverriding.JoinPortionsWithSameFormatting();
				}
				if (chart.Axes.VerticalAxis != null && chart.Axes.VerticalAxis.Title.TextFrameForOverriding != null)
				{
					chart.Axes.VerticalAxis.Title.TextFrameForOverriding.JoinPortionsWithSameFormatting();
				}
				foreach (IChartSeries item2 in chart.ChartData.Series)
				{
					if (item2.TrendLines != null)
					{
						foreach (ITrendline trendLine in item2.TrendLines)
						{
							if (trendLine.TextFrameForOverriding != null)
							{
								trendLine.TextFrameForOverriding.JoinPortionsWithSameFormatting();
							}
						}
					}
					foreach (IChartDataPoint dataPoint in item2.DataPoints)
					{
						if (dataPoint.Label != null && dataPoint.Label.TextFrameForOverriding != null)
						{
							dataPoint.Label.TextFrameForOverriding.JoinPortionsWithSameFormatting();
						}
					}
					foreach (IDataLabel label in item2.Labels)
					{
						if (label.TextFrameForOverriding != null)
						{
							label.TextFrameForOverriding.JoinPortionsWithSameFormatting();
						}
					}
				}
			}
			if (item is IGroupShape groupShape)
			{
				JoinPortionsWithSameFormatting(groupShape.Shapes);
			}
		}
	}

	internal void method_0(string spid)
	{
		if (spid.Length == 12)
		{
			uint_1 = Math.Max(uint_1, uint.Parse(spid.Remove(0, 8)) + 1);
		}
	}

	internal string method_1()
	{
		return $"_x0000_s{uint_1++:0000}";
	}

	internal ColorFormat method_2(SchemeColor color)
	{
		ColorSchemeIndex index = ((BaseThemeManager)ThemeManagerInternal).ColorMapping.method_1(color);
		return (ColorFormat)((ThemeEffectiveData)CreateThemeEffective()).ColorSchemeInternal[index];
	}

	public IThemeEffectiveData CreateThemeEffective()
	{
		return ThemeManagerInternal.CreateThemeEffective();
	}

	[Obsolete("Use ThemeManager.ApplyColorScheme(..) method instead. Will be removed after 01.09.2013.")]
	public abstract void ApplyColorScheme(ExtraColorScheme scheme);

	protected void InitSlideShowTransition()
	{
		slideShowTransition_0 = new SlideShowTransition(this);
	}

	internal List<Shape> method_3()
	{
		List<Shape> list = new List<Shape>();
		method_4(Shapes, list);
		return list;
	}

	private void method_4(IShapeCollection shapes, List<Shape> shapeList)
	{
		foreach (Shape shape in shapes)
		{
			shapeList.Add(shape);
			if (shape is GroupShape groupShape)
			{
				method_4(groupShape.Shapes, shapeList);
			}
		}
	}

	internal Shape method_5(PlaceholderType placeholderType)
	{
		List<Shape> list = method_3();
		foreach (Shape item in list)
		{
			if (item.Placeholder != null && item.Placeholder.Type == placeholderType)
			{
				return item;
			}
		}
		return null;
	}

	internal Shape method_6(uint index)
	{
		List<Shape> list = method_3();
		foreach (Shape item in list)
		{
			if (item.Placeholder != null && item.Placeholder.Index == index)
			{
				return item;
			}
		}
		return null;
	}

	public IShape FindShapeByAltText(string altText)
	{
		List<Shape> list = method_3();
		foreach (Shape item in list)
		{
			string alternativeText = item.AlternativeText;
			if (alternativeText != null && alternativeText.Equals(altText))
			{
				return item;
			}
		}
		return null;
	}

	internal void method_7(ITextStyle style)
	{
		List<Shape> list = method_3();
		foreach (Shape item in list)
		{
			if (item is AutoShape autoShape && autoShape.TextFrame != null && (!autoShape.IsTextHolder || ((Enum136)TextFrame.class1155_0[autoShape.Placeholder.Type] == Enum136.const_0 && autoShape.method_2().Length <= 0)))
			{
				((TextStyle)autoShape.TextFrame.TextFrameFormat.TextStyle).method_5(style, ParentPresentation.DefaultTextStyle);
			}
		}
	}

	internal void method_8(IBaseSlide sourceSlide)
	{
		int num = Math.Min(Shapes.Count, sourceSlide.Shapes.Count);
		for (int i = 0; i < num; i++)
		{
			AutoShape autoShape = sourceSlide.Shapes[i] as AutoShape;
			AutoShape autoShape2 = Shapes[i] as AutoShape;
			if (autoShape == null || autoShape2 == null || autoShape.TextFrame == null || autoShape.ShapeStyle == null)
			{
				continue;
			}
			FloatColor styleColor;
			IParagraphFormat[] array = ((TextFrame)autoShape.TextFrame).method_2(out styleColor);
			TextStyle textStyle = (TextStyle)autoShape2.TextFrame.TextFrameFormat.TextStyle;
			for (int j = 0; j < array.Length; j++)
			{
				IParagraphFormat paragraphFormat = textStyle.method_3(j);
				((ParagraphFormat)paragraphFormat).method_0((ParagraphFormat)array[j]);
				if (styleColor != null)
				{
					IFillFormat fillFormat = paragraphFormat.DefaultPortionFormat.FillFormat;
					fillFormat.FillType = FillType.Solid;
					fillFormat.SolidFillColor.ColorType = ColorType.RGB;
					fillFormat.SolidFillColor.Color = styleColor.Color;
				}
			}
		}
	}

	internal void method_9()
	{
		class518_0.method_2(this);
	}

	internal uint method_10()
	{
		lock (this)
		{
			return uint_0++;
		}
	}

	internal void method_11(uint newNextId, bool check)
	{
		lock (this)
		{
			if (check && newNextId <= uint_0)
			{
				throw new Exception();
			}
			uint_0 = newNextId;
		}
	}

	internal void method_12(Class369 page, Class476 package)
	{
		for (int num = Shapes.Count - 1; num >= 0; num--)
		{
			Shapes.RemoveAt(num);
		}
		if (page.LocalName == "master-page")
		{
			Name = (page as Class410).Name;
			(Background as Background).method_1((page as Class410).StyleName, package);
		}
		if (page.LocalName == "page")
		{
			Name = (page as Class416).Name;
			(Background as Background).method_1((page as Class416).StyleName, package);
		}
		((ShapeCollection)Shapes).method_18(page, package);
	}

	internal void method_13(Class369 elemPage, Class437 style, Class476 odpPackage, Class438 AutoStyles)
	{
		((ShapeCollection)Shapes).method_20(elemPage, odpPackage, AutoStyles);
	}

	internal virtual Shape[] vmethod_0(IPlaceholder placeholder)
	{
		return shape_0;
	}
}
