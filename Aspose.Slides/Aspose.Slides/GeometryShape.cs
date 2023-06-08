using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Aspose.Slides.Effects;
using Aspose.Slides.Theme;
using ns11;
using ns12;
using ns224;
using ns24;
using ns28;
using ns4;
using ns5;
using ns7;

namespace Aspose.Slides;

public abstract class GeometryShape : Shape, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape
{
	internal const int int_1 = 6;

	internal ShapeStyle shapeStyle_0;

	private readonly Class540 class540_0;

	private AdjustValueCollection adjustValueCollection_0;

	internal Class540 Geometry => class540_0;

	internal new Class281 PPTXUnsupportedProps => (Class281)base.PPTXUnsupportedProps;

	public IShapeStyle ShapeStyle => shapeStyle_0;

	public virtual ShapeType ShapeType
	{
		get
		{
			return class540_0.Preset;
		}
		set
		{
			class540_0.Preset = value;
		}
	}

	public IAdjustValueCollection Adjustments => adjustValueCollection_0;

	IShape IGeometryShape.AsIShape => this;

	internal GeometryShape(IBaseSlide parent)
		: this(parent, new Class281())
	{
	}

	internal GeometryShape(IBaseSlide parent, Class281 pptxUnsupportedProps)
		: base(parent, pptxUnsupportedProps)
	{
		lineFormat_0 = new LineFormat(this);
		threeDFormat_0 = new ThreeDFormat(this);
		effectFormat_0 = new EffectFormat(this);
		adjustValueCollection_0 = new AdjustValueCollection(this);
		class540_0 = new Class540(this);
		base.Transform2DInternal = new Class154();
	}

	internal void method_14()
	{
		shapeStyle_0 = new ShapeStyle(this);
	}

	internal override void vmethod_4(Class159 canvas, Class169 rc)
	{
		if (base.Hidden)
		{
			return;
		}
		if (base.HyperlinkClick != null)
		{
			canvas.vmethod_16(base.HyperlinkClick);
		}
		ShapeFrame shapeFrame = method_4();
		float x = shapeFrame.X;
		float y = shapeFrame.Y;
		float width = shapeFrame.Width;
		float height = shapeFrame.Height;
		if (float.IsNaN(x) || float.IsNaN(y) || float.IsNaN(width) || float.IsNaN(height))
		{
			return;
		}
		canvas.Transform = Shape.smethod_0(shapeFrame);
		Shape[] array = method_2();
		Class540 @class = class540_0;
		if (@class.Preset == ShapeType.NotDefined)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is GeometryShape geometryShape && geometryShape.class540_0.Preset != ShapeType.NotDefined)
				{
					@class = geometryShape.class540_0;
					break;
				}
			}
		}
		ShapeElement[] elems = @class.CreateShapeElements(this, x, y, width, height);
		method_17(canvas, rc, elems, shapeFrame, FillFormat, array);
		method_18(canvas, rc, elems, shapeFrame, array);
		if (base.HyperlinkClick != null)
		{
			canvas.vmethod_17();
		}
	}

	internal void method_15(Class159 canvas, Class169 rc, ShapeElement[] elems, ShapeFrame frame, IFillParamSource fillSource, Shape[] prototypes)
	{
		Class63[] fpCache = new Class63[6];
		for (int i = 0; i < elems.Length; i++)
		{
			if (elems[i].shapeElementFillSource_0 != 0)
			{
				Class63 fp = (Class63)vmethod_9(canvas, frame, elems[0].graphicsPath_0, fpCache, elems[i].shapeElementFillSource_0, fillSource, prototypes, rc).Clone();
				GraphicsPath graphicsPath = (GraphicsPath)elems[i].graphicsPath_0.Clone();
				if (EffectFormat.ReflectionEffect != null)
				{
					Reflection reflection = (Reflection)EffectFormat.ReflectionEffect;
					reflection.method_0(canvas, graphicsPath, fp, null, frame.Rectangle);
				}
			}
		}
		if (elems.Length == 0)
		{
			return;
		}
		Class66 @class = method_19(frame, canvas.Transform, elems[0].graphicsPath_0, prototypes, rc);
		Class66 class2;
		if (@class.BeginArrowheadStyle == LineArrowheadStyle.None && @class.EndArrowheadStyle == LineArrowheadStyle.None)
		{
			class2 = @class;
		}
		else
		{
			class2 = new Class66(@class);
			class2.BeginArrowheadStyle = LineArrowheadStyle.None;
			class2.EndArrowheadStyle = LineArrowheadStyle.None;
		}
		for (int j = 0; j < elems.Length; j++)
		{
			if (elems[j].StrokeSource != 0 && EffectFormat.ReflectionEffect != null)
			{
				GraphicsPath graphicsPath2 = (GraphicsPath)elems[j].graphicsPath_0.Clone();
				Reflection reflection2 = (Reflection)EffectFormat.ReflectionEffect;
				reflection2.method_0(canvas, graphicsPath2, null, elems[j].bool_1 ? class2 : @class, frame.Rectangle);
			}
		}
	}

	internal void method_16(Class159 canvas, Class169 rc, ShapeElement[] elems, ShapeFrame frame, IFillParamSource fillSource, Shape[] prototypes)
	{
		Class63[] fpCache = new Class63[6];
		for (int i = 0; i < elems.Length; i++)
		{
			if (elems[i].shapeElementFillSource_0 != 0)
			{
				Class63 fp = (Class63)vmethod_9(canvas, frame, elems[0].graphicsPath_0, fpCache, elems[i].shapeElementFillSource_0, fillSource, prototypes, rc).Clone();
				GraphicsPath graphicsPath = (GraphicsPath)elems[i].graphicsPath_0.Clone();
				if (EffectFormat.OuterShadowEffect != null)
				{
					OuterShadow outerShadow = (OuterShadow)EffectFormat.OuterShadowEffect;
					outerShadow.method_0(canvas, graphicsPath, fp, null, base.Frame.Rectangle);
				}
				if (EffectFormat.GlowEffect != null)
				{
					Glow glow = (Glow)EffectFormat.GlowEffect;
					glow.method_5(canvas, (BaseSlide)base.Slide, graphicsPath, fp, null, base.Frame.Rectangle);
				}
			}
		}
		if (elems.Length == 0)
		{
			return;
		}
		Class66 @class = method_19(frame, canvas.Transform, elems[0].graphicsPath_0, prototypes, rc);
		Class66 class2;
		if (@class.BeginArrowheadStyle == LineArrowheadStyle.None && @class.EndArrowheadStyle == LineArrowheadStyle.None)
		{
			class2 = @class;
		}
		else
		{
			class2 = new Class66(@class);
			class2.BeginArrowheadStyle = LineArrowheadStyle.None;
			class2.EndArrowheadStyle = LineArrowheadStyle.None;
		}
		for (int j = 0; j < elems.Length; j++)
		{
			if (elems[j].StrokeSource != 0)
			{
				if (EffectFormat.OuterShadowEffect != null)
				{
					GraphicsPath graphicsPath2 = (GraphicsPath)elems[j].graphicsPath_0.Clone();
					OuterShadow outerShadow2 = (OuterShadow)EffectFormat.OuterShadowEffect;
					outerShadow2.method_0(canvas, graphicsPath2, null, elems[j].bool_1 ? class2 : @class, frame.Rectangle);
				}
				if (EffectFormat.GlowEffect != null)
				{
					GraphicsPath graphicsPath3 = (GraphicsPath)elems[j].graphicsPath_0.Clone();
					Glow glow2 = (Glow)EffectFormat.GlowEffect;
					glow2.method_5(canvas, null, graphicsPath3, null, elems[j].bool_1 ? class2 : @class, frame.Rectangle);
				}
			}
		}
	}

	internal void method_17(Class159 canvas, Class169 rc, ShapeElement[] elems, ShapeFrame frame, IFillParamSource fillSource, Shape[] prototypes)
	{
		Class63[] fpCache = new Class63[6];
		RectangleF a = frame.Rectangle;
		for (int i = 0; i < elems.Length; i++)
		{
			if (elems[i].ElementType == Enum116.const_0 && elems[i].FillSource != 0)
			{
				GraphicsPath graphicsPath = (GraphicsPath)elems[i].GraphicsPath.Clone();
				graphicsPath.Flatten();
				a = RectangleF.Union(a, graphicsPath.GetBounds());
				graphicsPath.Dispose();
			}
		}
		Class164 @class = canvas as Class164;
		frame = new ShapeFrame(a.X, a.Y, a.Width, a.Height, frame.FlipH, frame.FlipV, frame.Rotation);
		int num = 0;
		Class63 class2;
		PictureFillFormat pictureFillFormat;
		while (true)
		{
			if (num >= elems.Length)
			{
				return;
			}
			if (elems[num].shapeElementFillSource_0 != 0)
			{
				class2 = vmethod_9(canvas, frame, elems[num].graphicsPath_0, fpCache, elems[num].shapeElementFillSource_0, fillSource, prototypes, rc);
				if (@class != null)
				{
					pictureFillFormat = fillSource as PictureFillFormat;
					if (!@class.SaveMetafileAsPng && pictureFillFormat != null && pictureFillFormat.Picture.Image.SystemImage is Metafile)
					{
						break;
					}
				}
				canvas.vmethod_5(elems[num].graphicsPath_0, null, class2);
			}
			num++;
		}
		@class.vmethod_21(pictureFillFormat.Picture.Image, class2.Rectangle, null);
	}

	internal void method_18(Class159 canvas, Class169 rc, ShapeElement[] elems, ShapeFrame frame, Shape[] prototypes)
	{
		if (elems.Length == 0)
		{
			return;
		}
		Class66 @class = method_19(frame, canvas.Transform, elems[0].graphicsPath_0, prototypes, rc);
		Class66 class2;
		if (@class.BeginArrowheadStyle == LineArrowheadStyle.None && @class.EndArrowheadStyle == LineArrowheadStyle.None)
		{
			class2 = @class;
		}
		else
		{
			class2 = new Class66(@class);
			class2.BeginArrowheadStyle = LineArrowheadStyle.None;
			class2.EndArrowheadStyle = LineArrowheadStyle.None;
		}
		for (int i = 0; i < elems.Length; i++)
		{
			if (elems[i].StrokeSource != 0)
			{
				canvas.vmethod_5(elems[i].graphicsPath_0, elems[i].bool_1 ? class2 : @class, null);
			}
		}
	}

	internal Class66 method_19(ShapeFrame frame, Class6002 userToDevice, GraphicsPath path, Shape[] protos, Class169 rc)
	{
		ILineParamSource[] array = new ILineParamSource[protos.Length * 2 + 2];
		int num = 0;
		for (int i = 0; i < protos.Length; i++)
		{
			if (protos[i] is GeometryShape geometryShape)
			{
				array[num++] = geometryShape.method_22(rc.RenderingSlide);
			}
			array[num++] = (LineFormat)protos[i].LineFormat;
		}
		array[num++] = method_22(rc.RenderingSlide);
		array[num] = (LineFormat)LineFormat;
		return new Class66(new Class67(frame, userToDevice, path, rc.RenderingSlide, rc), array);
	}

	internal virtual Class63 vmethod_9(Class159 canvas, ShapeFrame frame, GraphicsPath path, Class63[] fpCache, ShapeElementFillSource fillSource, IFillParamSource shapeFill, Shape[] protos, Class169 rc)
	{
		Class63 @class = fpCache[(uint)fillSource];
		if (@class != null)
		{
			return @class;
		}
		IBaseSlide renderingSlide = rc.RenderingSlide;
		switch (fillSource)
		{
		default:
			return null;
		case ShapeElementFillSource.Shape:
			if (!Class21.bool_0 && !(shapeFill is PictureFillFormat))
			{
				FillFormatEffectiveDataPVITemp fillFormatEffectiveDataPVITemp = fillFormat_0.method_4();
				IShapeFrame frame2 = ((!fillFormatEffectiveDataPVITemp.bool_1 || !base.IsGrouped) ? frame : base.ParentGroupInternal.Frame);
				GraphicsPath grPath = ((!fillFormatEffectiveDataPVITemp.bool_1 || !base.IsGrouped) ? path : null);
				@class = new Class63(new Class67(frame2, canvas.Transform, grPath, base.Slide, rc), fillFormatEffectiveDataPVITemp);
			}
			else
			{
				IFillParamSource[] array = new IFillParamSource[protos.Length * 2 + 2];
				int num12 = 0;
				for (int num13 = protos.Length - 1; num13 >= 0; num13--)
				{
					if (protos[num13] is GeometryShape geometryShape)
					{
						array[num12++] = geometryShape.method_21(renderingSlide);
					}
					array[num12++] = protos[num13].FillFormat;
				}
				array[num12++] = method_21(renderingSlide);
				array[num12++] = shapeFill;
				bool flag = false;
				for (num12--; num12 > 0; num12--)
				{
					IFillFormat fillFormat = array[num12] as FillFormat;
					if (fillFormat == null && array[num12] is Class493)
					{
						fillFormat = ((Class493)array[num12]).ifillFormat_0;
					}
					if (fillFormat != null)
					{
						if (fillFormat.FillType == FillType.Group)
						{
							flag = true;
							break;
						}
						if (fillFormat.FillType != FillType.NotDefined)
						{
							break;
						}
					}
				}
				@class = ((!flag) ? new Class63(new Class67(frame, canvas.Transform, path, base.Slide, rc), array) : ((!base.IsGrouped) ? null : base.ParentGroupInternal.method_19(canvas.Transform, rc)));
			}
			fpCache[(uint)fillSource] = @class;
			return @class;
		case ShapeElementFillSource.Lighten:
		case ShapeElementFillSource.LightenLess:
		case ShapeElementFillSource.Darken:
		case ShapeElementFillSource.DarkenLess:
			@class = vmethod_9(canvas, frame, path, fpCache, ShapeElementFillSource.Shape, shapeFill, protos, rc);
			@class = (Class63)@class.Clone();
			switch (@class.FillType)
			{
			case FillType.Solid:
				@class.ForeColor = method_20(@class.ForeColor, fillSource);
				break;
			case FillType.Gradient:
			{
				SortedList<float, Color> rawGradientStops = @class.RawGradientStops;
				for (int k = 0; k < rawGradientStops.Count; k++)
				{
					rawGradientStops[rawGradientStops.Keys[k]] = method_20(rawGradientStops.Values[k], fillSource);
				}
				@class.RawGradientStops = rawGradientStops;
				break;
			}
			case FillType.Pattern:
				@class.ForeColor = method_20(@class.ForeColor, fillSource);
				@class.BackColor = method_20(@class.BackColor, fillSource);
				break;
			case FillType.Picture:
			{
				Image image = @class.method_18();
				string text = rc.method_2(image);
				if (text == null)
				{
					break;
				}
				int num = 0;
				switch (fillSource)
				{
				case ShapeElementFillSource.Lighten:
					num = -6;
					break;
				case ShapeElementFillSource.LightenLess:
					num = -8;
					break;
				case ShapeElementFillSource.Darken:
					num = 6;
					break;
				case ShapeElementFillSource.DarkenLess:
					num = 8;
					break;
				}
				text = text + " " + num;
				Class64 class2 = rc.method_0(text);
				if (class2 == null)
				{
					Bitmap bitmap = (image as Bitmap) ?? new Bitmap(image);
					Class190 class3 = Class190.smethod_0(bitmap);
					if (num > 0)
					{
						for (int i = 0; i < class3.Bits.Length; i++)
						{
							int num2 = class3.Bits[i];
							int num3 = (num2 >> 24) & 0xFF;
							int num4 = ((num2 >> 16) & 0xFF) / 10 * num;
							int num5 = ((num2 >> 8) & 0xFF) / 10 * num;
							int num6 = (num2 & 0xFF) / 10 * num;
							class3.Bits[i] = (num3 << 24) + (num4 << 16) + (num5 << 8) + num6;
						}
					}
					else
					{
						num = -num;
						for (int j = 0; j < class3.Bits.Length; j++)
						{
							int num7 = class3.Bits[j];
							int num8 = (num7 >> 24) & 0xFF;
							int num9 = 255 - (255 - ((num7 >> 16) & 0xFF)) / 10 * num;
							int num10 = 255 - (255 - ((num7 >> 8) & 0xFF)) / 10 * num;
							int num11 = 255 - (255 - (num7 & 0xFF)) / 10 * num;
							class3.Bits[j] = (num8 << 24) + (num9 << 16) + (num10 << 8) + num11;
						}
					}
					class2 = new Class64(class3.method_4(), text);
					rc.method_1(text, class2);
				}
				@class.method_19(class2);
				break;
			}
			}
			fpCache[(uint)fillSource] = @class;
			return @class;
		}
	}

	private Color method_20(Color c, ShapeElementFillSource fillSource)
	{
		return fillSource switch
		{
			ShapeElementFillSource.Lighten => Color.FromArgb(c.A, 255 - (255 - c.R) * 6 / 10, 255 - (255 - c.G) * 6 / 10, 255 - (255 - c.B) * 6 / 10), 
			ShapeElementFillSource.LightenLess => Color.FromArgb(c.A, 255 - (255 - c.R) * 8 / 10, 255 - (255 - c.G) * 8 / 10, 255 - (255 - c.B) * 8 / 10), 
			ShapeElementFillSource.Darken => Color.FromArgb(c.A, c.R * 6 / 10, c.G * 6 / 10, c.B * 6 / 10), 
			ShapeElementFillSource.DarkenLess => Color.FromArgb(c.A, c.R * 8 / 10, c.G * 8 / 10, c.B * 8 / 10), 
			_ => c, 
		};
	}

	public IShapeElement[] CreateShapeElements()
	{
		ShapeFrame shapeFrame = method_4();
		float x = shapeFrame.X;
		float y = shapeFrame.Y;
		float width = shapeFrame.Width;
		float height = shapeFrame.Height;
		if (!float.IsNaN(x) && !float.IsNaN(y) && !float.IsNaN(width) && !float.IsNaN(height))
		{
			Shape[] array = method_2();
			Class540 @class = class540_0;
			if (@class.Preset == ShapeType.NotDefined)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is GeometryShape geometryShape && geometryShape.class540_0.Preset != ShapeType.NotDefined)
					{
						@class = geometryShape.class540_0;
						break;
					}
				}
			}
			return @class.CreateShapeElements(this, x, y, width, height);
		}
		return null;
	}

	internal static Dictionary<ShapeType, ShapeType> smethod_2(params ShapeType[] types)
	{
		Dictionary<ShapeType, ShapeType> dictionary = new Dictionary<ShapeType, ShapeType>(types.Length);
		for (int i = 0; i < types.Length; i++)
		{
			dictionary.Add(types[i], types[i]);
		}
		return dictionary;
	}

	internal Class493 method_21(IBaseSlide colorMappingSlide)
	{
		ThemeEffectiveData themeEffectiveData = (ThemeEffectiveData)base.Slide.CreateThemeEffective();
		IShapeStyle shapeStyle = ShapeStyle;
		if (themeEffectiveData != null && shapeStyle != null)
		{
			return themeEffectiveData.method_3(colorMappingSlide, shapeStyle.FillStyleIndex, (ColorFormat)shapeStyle.FillColor);
		}
		return null;
	}

	internal Class512 method_22(IBaseSlide colorMappingSlide)
	{
		ThemeEffectiveData themeEffectiveData = (ThemeEffectiveData)base.Slide.CreateThemeEffective();
		IShapeStyle shapeStyle = ShapeStyle;
		if (themeEffectiveData != null && shapeStyle != null)
		{
			return themeEffectiveData.method_5(colorMappingSlide, shapeStyle.LineStyleIndex, (ColorFormat)shapeStyle.LineColor);
		}
		return null;
	}

	internal Class492 method_23(IBaseSlide colorMappingSlide)
	{
		ThemeEffectiveData themeEffectiveData = (ThemeEffectiveData)base.Slide.CreateThemeEffective();
		IShapeStyle shapeStyle = ShapeStyle;
		if (themeEffectiveData != null && shapeStyle != null)
		{
			return themeEffectiveData.method_6(colorMappingSlide, shapeStyle.EffectStyleIndex, (ColorFormat)shapeStyle.EffectColor);
		}
		return null;
	}

	internal Class539 method_24(BaseSlide colorMappingSlide)
	{
		ThemeEffectiveData themeEffectiveData = (ThemeEffectiveData)base.Slide.CreateThemeEffective();
		IShapeStyle shapeStyle = ShapeStyle;
		if (themeEffectiveData != null && shapeStyle != null)
		{
			return themeEffectiveData.method_7(colorMappingSlide, shapeStyle.EffectStyleIndex, (ColorFormat)shapeStyle.EffectColor);
		}
		return null;
	}

	internal override LineFormatEffectiveData vmethod_0()
	{
		Shape[] array = method_2();
		LineFormatEffectiveData lineFormatEffectiveData = new LineFormatEffectiveData();
		FloatColor floatColor_ = FloatColor.floatColor_0;
		Class512 @class;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is GeometryShape geometryShape)
			{
				@class = geometryShape.method_22(base.SlideInternal);
				if (@class != null)
				{
					floatColor_ = @class.floatColor_0;
					lineFormatEffectiveData.method_1(@class.lineFormat_0, base.SlideInternal, floatColor_);
				}
			}
			lineFormatEffectiveData.method_1(array[i].LineFormat, base.SlideInternal, floatColor_);
		}
		@class = method_22(base.SlideInternal);
		if (@class != null)
		{
			floatColor_ = @class.floatColor_0;
			lineFormatEffectiveData.method_1(@class.lineFormat_0, base.SlideInternal, floatColor_);
		}
		lineFormatEffectiveData.method_1(LineFormat, base.SlideInternal, floatColor_);
		return lineFormatEffectiveData;
	}

	internal override FillFormatEffectiveData vmethod_1()
	{
		Shape[] array = method_2();
		FillFormatEffectiveData fillFormatEffectiveData = new FillFormatEffectiveData();
		FloatColor styleColor = FloatColor.floatColor_1;
		bool flag = false;
		Class493 @class;
		for (int num = array.Length - 1; num >= 0; num--)
		{
			if (array[num] is GeometryShape geometryShape)
			{
				@class = geometryShape.method_21(base.SlideInternal);
				if (@class != null)
				{
					styleColor = @class.floatColor_0;
					if (@class.ifillFormat_0.FillType == FillType.Group)
					{
						flag = true;
					}
					else if (@class.ifillFormat_0.FillType != FillType.NotDefined)
					{
						flag = false;
						fillFormatEffectiveData.method_1(@class.ifillFormat_0, base.SlideInternal, styleColor);
					}
				}
			}
			if (array[num].FillFormat.FillType == FillType.Group)
			{
				flag = true;
			}
			else if (array[num].FillFormat.FillType != FillType.NotDefined)
			{
				flag = false;
				fillFormatEffectiveData.method_1(array[num].FillFormat, base.SlideInternal, styleColor);
			}
		}
		@class = method_21(base.SlideInternal);
		if (@class != null)
		{
			styleColor = @class.floatColor_0;
			if (@class.ifillFormat_0.FillType == FillType.Group)
			{
				flag = true;
			}
			else if (@class.ifillFormat_0.FillType != FillType.NotDefined)
			{
				flag = false;
				fillFormatEffectiveData.method_1(@class.ifillFormat_0, base.SlideInternal, styleColor);
			}
		}
		if (FillFormat.FillType == FillType.Group)
		{
			flag = true;
		}
		else if (FillFormat.FillType != FillType.NotDefined)
		{
			flag = false;
			fillFormatEffectiveData.method_1(FillFormat, base.SlideInternal, styleColor);
		}
		if (flag)
		{
			if (base.IsGrouped)
			{
				return base.ParentGroupInternal.method_20();
			}
			fillFormatEffectiveData = new FillFormatEffectiveData();
			fillFormatEffectiveData.fillType_0 = FillType.NoFill;
		}
		return fillFormatEffectiveData;
	}

	internal override EffectFormatEffectiveData vmethod_2()
	{
		Shape[] array = method_2();
		EffectFormatEffectiveData effectFormatEffectiveData = new EffectFormatEffectiveData();
		FloatColor styleColor = FloatColor.floatColor_1;
		Class492 @class;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is GeometryShape geometryShape)
			{
				@class = geometryShape.method_23(base.SlideInternal);
				if (@class != null)
				{
					styleColor = @class.floatColor_0;
					effectFormatEffectiveData.method_1(@class.ieffectFormat_0, base.SlideInternal, styleColor);
				}
			}
			effectFormatEffectiveData.method_1(array[i].EffectFormat, base.SlideInternal, styleColor);
		}
		@class = method_23(base.SlideInternal);
		if (@class != null)
		{
			styleColor = @class.floatColor_0;
			effectFormatEffectiveData.method_1(@class.ieffectFormat_0, base.SlideInternal, styleColor);
		}
		effectFormatEffectiveData.method_1(EffectFormat, base.SlideInternal, styleColor);
		return effectFormatEffectiveData;
	}

	internal override ThreeDFormatEffectiveData vmethod_3()
	{
		Shape[] array = method_2();
		ThreeDFormatEffectiveData threeDFormatEffectiveData = new ThreeDFormatEffectiveData();
		FloatColor styleColor = FloatColor.floatColor_1;
		Class539 @class;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is GeometryShape geometryShape)
			{
				@class = geometryShape.method_24(base.SlideInternal);
				if (@class != null)
				{
					styleColor = @class.floatColor_0;
					threeDFormatEffectiveData.method_0((ThreeDFormat)@class.ithreeDFormat_0, base.SlideInternal, styleColor);
				}
			}
			threeDFormatEffectiveData.method_0(array[i].threeDFormat_0, base.SlideInternal, styleColor);
		}
		@class = method_24(base.SlideInternal);
		if (@class != null)
		{
			styleColor = @class.floatColor_0;
			threeDFormatEffectiveData.method_0((ThreeDFormat)@class.ithreeDFormat_0, base.SlideInternal, styleColor);
		}
		threeDFormatEffectiveData.method_0(threeDFormat_0, base.SlideInternal, styleColor);
		return threeDFormatEffectiveData;
	}

	internal static Dictionary<ShapeType, ShapeType> smethod_3(bool inverse, params ShapeType[] types)
	{
		if (!inverse)
		{
			return smethod_2(types);
		}
		Dictionary<ShapeType, ShapeType> dictionary = smethod_2((ShapeType[])Enum.GetValues(typeof(ShapeType)));
		for (int i = 0; i < types.Length; i++)
		{
			dictionary.Remove(types[i]);
		}
		return dictionary;
	}

	internal virtual void vmethod_10(Class437 style, Class437 textStyle, Class476 package, Class369 shape)
	{
		if (style != null)
		{
			fillFormat_0.method_2(style.GraphicProperties.FillProperties, package);
			if (style.ParentStyleName != null)
			{
				lineFormat_0.method_2(style.ParentStyleName, package);
			}
			lineFormat_0.method_2(style, package);
		}
	}

	internal void method_25(Class437 style, Class476 odpPackage, Shape[] protos)
	{
		ILineParamSource[] array = new ILineParamSource[protos.Length * 2 + 2];
		int num = 0;
		for (int i = 0; i < protos.Length; i++)
		{
			if (protos[i] is GeometryShape geometryShape)
			{
				array[num++] = geometryShape.method_22(base.Slide);
			}
			array[num++] = (LineFormat)protos[i].LineFormat;
		}
		array[num++] = method_22(base.Slide);
		array[num] = (LineFormat)LineFormat;
		Class474 @class = new Class474(array);
		@class.method_1(style, odpPackage);
	}

	internal virtual void vmethod_11(Class437 style, Class476 odpPackage, Shape[] protos)
	{
		IFillParamSource[] array = new IFillParamSource[protos.Length * 2 + 2];
		int num = 0;
		for (int i = 0; i < protos.Length; i++)
		{
			if (protos[i] is GeometryShape geometryShape)
			{
				array[num++] = geometryShape.method_21(base.Slide);
			}
			array[num++] = protos[i].FillFormat;
		}
		array[num++] = method_21(base.Slide);
		array[num] = FillFormat;
		Class469 @class = new Class469(array);
		@class.method_1(style.GraphicProperties.FillProperties, (BaseSlide)base.Slide, odpPackage, FloatColor.floatColor_0);
	}

	internal virtual void vmethod_12(Class437 style, Class476 odpPackage, Class369 shape)
	{
		style.method_37();
		Shape[] protos = method_2();
		vmethod_11(style, odpPackage, protos);
		method_25(style, odpPackage, protos);
	}
}
