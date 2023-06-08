using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns11;
using ns224;
using ns24;
using ns271;
using ns4;
using ns67;
using ns70;
using ns99;

namespace ns12;

internal class Class179 : IDisposable
{
	private const int int_0 = 12700;

	private const int int_1 = 60000;

	private const int int_2 = 100;

	private bool bool_0;

	private Interface53 interface53_0;

	public Class179(int width, int height)
		: this(new Class3470(width, height))
	{
	}

	public Class179(Interface53 device)
	{
		interface53_0 = device;
	}

	public void method_0(Class159 canvas, Class169 rc, AutoShape shape, Class6002 matrix)
	{
		method_2(((Presentation)shape.Presentation).FontsManagerInternal);
		try
		{
			Class3452 slide = new Class3452();
			Class3448 @class = smethod_15(shape.method_4());
			Class3433 class2 = new Class3433(slide, null, smethod_7(shape, @class));
			smethod_0(shape, class2.TextBody);
			using Class162 class3 = new Class162(canvas.Width, canvas.Height, canvas.DpiX / 8f, canvas.DpiY / 8f);
			matrix = matrix.Clone();
			matrix.method_13((float)(0.0 - @class.Rotation) / 60000f, new PointF((float)(@class.Offset.X + @class.Extents.Cx / 2.0) / 12700f, (float)(@class.Offset.Y + @class.Extents.Cy / 2.0) / 12700f), MatrixOrder.Append);
			class3.method_0(matrix);
			shape.TextFrameInternal.method_10(class3, rc);
			class2.TextBody.method_3(class3.CharPaths, class3.CharCoordinates);
			RectangleF bounds;
			GraphicsPath[] array = class2.TextBody.method_2(out bounds);
			for (int i = 0; i < array.Length; i++)
			{
				GraphicsPath graphicsPath = array[i];
				Class151 class4 = class3.CharParameters[i];
				if (graphicsPath.PointCount > 1 && class4.FontShadow)
				{
					Class6002 transform = canvas.Transform;
					double num = (double)class4.ShadowDirection * (Math.PI / 180.0);
					double shadowDistance = class4.ShadowDistance;
					double num2 = Math.Cos(num) * shadowDistance;
					double num3 = Math.Sin(num) * shadowDistance;
					canvas.method_2((float)num2, (float)num3);
					canvas.vmethod_5(graphicsPath, null, new Class63(class4.ShadowColor));
					canvas.Transform = transform;
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				GraphicsPath graphicsPath2 = array[j];
				if (graphicsPath2.PointCount > 1)
				{
					Class151 class5 = class3.CharParameters[j];
					if (class5.FontFill.FillType == FillType.Gradient)
					{
						class5.FontFill.Rectangle = bounds;
					}
					if (class5.FontOutline.class63_0.FillType == FillType.Gradient)
					{
						class5.FontOutline.class63_0.Rectangle = bounds;
					}
					canvas.vmethod_5(graphicsPath2, class5.FontOutline, class5.FontFill);
				}
			}
		}
		finally
		{
			Class3086.Instance.method_3();
		}
	}

	public void method_1(Class159 canvas, Class169 rc, GeometryShape shape, bool drawGeometry, bool drawText)
	{
		method_2(((Presentation)shape.Presentation).FontsManagerInternal);
		try
		{
			Class3452 @class = new Class3452();
			Class3448 srcTransform2D = smethod_15(shape.method_4());
			Class3433 class2 = new Class3433(@class, null, smethod_7(shape, srcTransform2D));
			smethod_1(shape, class2.Attributes);
			if (!drawGeometry)
			{
				class2.Attributes.ShapeFillMode = new Class3336();
			}
			AutoShape autoShape = shape as AutoShape;
			if (drawText && autoShape != null)
			{
				smethod_0(autoShape, class2.TextBody);
				using Class162 class3 = new Class162(canvas.Width, canvas.Height, canvas.DpiX / 8f, canvas.DpiY / 8f);
				autoShape.TextFrameInternal.method_10(class3, rc);
				class2.TextBody.method_3(class3.CharPaths, class3.CharCoordinates);
			}
			@class.method_0(interface53_0);
			using Bitmap img = interface53_0.imethod_4();
			canvas.vmethod_6(img, 0, 0);
		}
		finally
		{
			Class3086.Instance.method_3();
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing && interface53_0 != null)
			{
				interface53_0.Dispose();
			}
			bool_0 = true;
		}
	}

	private void method_2(Class54 fontsManager)
	{
		string[] array = Class6652.Instance.method_7();
		string[] array2 = array;
		foreach (string directory in array2)
		{
			Class3086.Instance.method_0(directory);
		}
		if (fontsManager.EmbeddedFonts == null)
		{
			return;
		}
		List<Class4408> list = fontsManager.EmbeddedFonts.method_4();
		foreach (Class4408 item in list)
		{
			Class3086.Instance.method_2(item);
		}
	}

	private static void smethod_0(AutoShape autoShape, Class3450 dest)
	{
		if (autoShape == null || autoShape.TextFrameInternal == null)
		{
			return;
		}
		TextFrame textFrameInternal = autoShape.TextFrameInternal;
		foreach (Paragraph paragraph in textFrameInternal.Paragraphs)
		{
			Class3451 @class = new Class3451();
			IParagraphFormatEffectiveData paragraphFormatEffectiveData = paragraph.CreateParagraphFormatEffective();
			Class3390 properties = @class.Properties;
			properties.Alignment = (Enum468)paragraphFormatEffectiveData.Alignment;
			properties.DefaultTabSize = paragraphFormatEffectiveData.DefaultTabSize;
			properties.FontAlignment = (Enum471)paragraphFormatEffectiveData.FontAlignment;
			properties.LeftMargin = new Class3383(paragraphFormatEffectiveData.MarginLeft * 12700f);
			properties.RightMargin = new Class3383(paragraphFormatEffectiveData.MarginRight * 12700f);
			properties.RightToLeft = properties.RightToLeft;
			dest.method_1(@class);
			foreach (Portion portion in paragraph.Portions)
			{
				if (portion.TextInternal != string.Empty)
				{
					IPortionFormatEffectiveData portionFormatEffectiveData = portion.CreatePortionFormatEffective();
					Class3406 class2 = new Class3406();
					class2.AlternativeLanguage = portionFormatEffectiveData.AlternativeLanguageId;
					class2.Bold = portionFormatEffectiveData.FontBold;
					class2.Capitalization = (Enum470)portionFormatEffectiveData.TextCapType;
					class2.ComplexScriptFont = ((portionFormatEffectiveData.ComplexScriptFont.FontName != null) ? new Class3449(portionFormatEffectiveData.ComplexScriptFont.FontName) : null);
					class2.EastAsianFont = ((portionFormatEffectiveData.EastAsianFont.FontName != string.Empty) ? new Class3449(portionFormatEffectiveData.EastAsianFont.FontName) : null);
					class2.FillMode = smethod_9(portionFormatEffectiveData.FillFormat);
					class2.FontSize = portionFormatEffectiveData.FontHeight * 100f;
					class2.Italics = portionFormatEffectiveData.FontItalic;
					class2.Kumimoji = portionFormatEffectiveData.Kumimoji;
					class2.Language = portionFormatEffectiveData.LanguageId;
					class2.LatinFont = ((portionFormatEffectiveData.LatinFont.FontName != string.Empty) ? new Class3449(portionFormatEffectiveData.LatinFont.FontName) : null);
					class2.LineFillMode = smethod_8(portionFormatEffectiveData.LineFormat.FillFormat);
					class2.LineStyle = new Class3441();
					smethod_2(portionFormatEffectiveData.LineFormat, class2.LineStyle);
					class2.NormalizeHeights = portionFormatEffectiveData.NormaliseHeight;
					class2.Strikethrough = (Enum472)portionFormatEffectiveData.StrikethroughType;
					class2.SymbolFont = ((portionFormatEffectiveData.SymbolFont.FontName != string.Empty) ? new Class3449(portionFormatEffectiveData.SymbolFont.FontName) : null);
					class2.Underline = (Enum474)portionFormatEffectiveData.FontUnderline;
					Class3424 class3 = new Class3424(portion.TextInternal);
					class3.RunProperties = class2;
					@class.method_1(class3);
				}
			}
		}
		Class520 textShape = textFrameInternal.textFrameFormat_0.PPTXUnsupportedProps.TextShape;
		if (textShape.TextShapeType == TextShapeType.NotDefined)
		{
			return;
		}
		Class3280 class4 = Class3280.smethod_12((Enum496)textShape.TextShapeType);
		if (textShape.class341_0 != null)
		{
			foreach (KeyValuePair<string, int> item in textShape.dictionary_0)
			{
				double value = textShape.class341_0[item.Value - 1].RawValue;
				class4.AdjustValues[item.Key] = value;
			}
		}
		dest.Properties.TextWarp = class4;
	}

	private static void smethod_1(GeometryShape src, Class3434 dest)
	{
		dest.ShapeFillMode = smethod_9(src.vmethod_1());
		ILineFormatEffectiveData src2 = src.CreateLineFormatEffective();
		dest.LineFillMode = smethod_8(src.CreateLineFormatEffective().FillFormat);
		smethod_2(src2, dest.LineStyle);
		smethod_3(src, dest);
		smethod_4(src, dest);
	}

	private static void smethod_2(ILineFormatEffectiveData src, Class3441 dest)
	{
		dest.LineJoinType = (Enum490)src.JoinStyle;
		if (src.DashStyle != LineDashStyle.NotDefined)
		{
			if (src.DashStyle == LineDashStyle.Custom)
			{
				dest.LineDash = new Class3438();
			}
			else
			{
				dest.LineDash = new Class3439((Enum484)src.DashStyle);
			}
		}
		dest.MeterJoinLimit = src.MiterLimit * 12700f;
		dest.LineWidth = src.Width * 12700.0;
		dest.StrokeAlignment = (Enum491)src.Alignment;
		dest.LineEndingCapType = (Enum486)src.CapStyle;
		dest.CompoundLineType = (Enum485)src.Style;
		dest.HeadEnd.Kind = (Enum487)src.BeginArrowheadStyle;
		dest.HeadEnd.Length = (Enum488)src.BeginArrowheadLength;
		dest.HeadEnd.Width = (Enum489)src.BeginArrowheadWidth;
		dest.TailEnd.Kind = (Enum487)src.EndArrowheadStyle;
		dest.TailEnd.Length = (Enum488)src.EndArrowheadLength;
		dest.TailEnd.Width = (Enum489)src.EndArrowheadWidth;
	}

	private static void smethod_3(GeometryShape src, Class3434 dest)
	{
		EffectFormatEffectiveData effectFormatEffectiveData = src.vmethod_2();
		if (!effectFormatEffectiveData.IsNoEffects)
		{
			Class3327 @class = new Class3327();
			if (effectFormatEffectiveData.BlurEffect != null)
			{
				IBlurEffectiveData blurEffect = effectFormatEffectiveData.BlurEffect;
				Class3345 class2 = new Class3345();
				class2.GrowBounds = blurEffect.Grow;
				class2.Radius = blurEffect.Radius * 12700.0;
				@class.Blur = class2;
			}
			if (effectFormatEffectiveData.FillOverlayEffect != null)
			{
				IFillOverlayEffectiveData fillOverlayEffect = effectFormatEffectiveData.FillOverlayEffect;
				Class3346 fillOverlay = new Class3346(smethod_9(fillOverlayEffect.FillFormat), (Enum462)fillOverlayEffect.Blend);
				@class.FillOverlay = fillOverlay;
			}
			if (effectFormatEffectiveData.GlowEffect != null)
			{
				IGlowEffectiveData glowEffect = effectFormatEffectiveData.GlowEffect;
				Class3362 class3 = new Class3362();
				class3.Color = smethod_12(glowEffect.Color);
				class3.Radius = glowEffect.Radius * 12700.0;
				@class.Glow = class3;
			}
			if (effectFormatEffectiveData.ReflectionEffect != null)
			{
				IReflectionEffectiveData reflectionEffect = effectFormatEffectiveData.ReflectionEffect;
				Class3363 class4 = new Class3363();
				class4.BlurRadius = reflectionEffect.BlurRadius * 12700.0;
				class4.Direction = reflectionEffect.Direction * 60000f;
				class4.Distance = reflectionEffect.Distance * 12700.0;
				class4.EndAlpha = reflectionEffect.EndReflectionOpacity;
				class4.EndPosition = reflectionEffect.EndPosAlpha;
				class4.FadeDirection = reflectionEffect.FadeDirection * 60000f;
				class4.HorizontalRatio = reflectionEffect.ScaleHorizontal;
				class4.HorizontalSkew = reflectionEffect.SkewHorizontal;
				class4.RotateWithShape = reflectionEffect.RotateShadowWithShape;
				class4.ShadowAlignment = (Enum463)reflectionEffect.RectangleAlign;
				class4.StartOpacity = reflectionEffect.StartReflectionOpacity;
				class4.StartPosition = reflectionEffect.StartPosAlpha;
				class4.VerticalRatio = reflectionEffect.ScaleVertical;
				class4.VerticalSkew = reflectionEffect.SkewVertical;
				@class.Reflection = class4;
			}
			if (effectFormatEffectiveData.SoftEdgeEffect != null)
			{
				ISoftEdgeEffectiveData softEdgeEffect = effectFormatEffectiveData.SoftEdgeEffect;
				Class3368 class5 = new Class3368();
				class5.Radius = softEdgeEffect.Radius * 12700.0;
				@class.SoftEdge = class5;
			}
			if (effectFormatEffectiveData.InnerShadowEffect != null)
			{
				IInnerShadowEffectiveData innerShadowEffect = effectFormatEffectiveData.InnerShadowEffect;
				Class3365 class6 = new Class3365();
				class6.BlurRadius = innerShadowEffect.BlurRadius * 12700.0;
				class6.Direction = innerShadowEffect.Direction * 60000f;
				class6.Color = smethod_12(innerShadowEffect.ShadowColor);
				class6.Distance = innerShadowEffect.Distance * 60000.0;
				@class.Shadow = class6;
			}
			else if (effectFormatEffectiveData.OuterShadowEffect != null)
			{
				IOuterShadowEffectiveData outerShadowEffect = effectFormatEffectiveData.OuterShadowEffect;
				Class3366 class7 = new Class3366();
				class7.BlurRadius = outerShadowEffect.BlurRadius * 12700.0;
				class7.Color = smethod_12(outerShadowEffect.ShadowColor);
				class7.HorizontalScalingFactor = outerShadowEffect.ScaleHorizontal;
				class7.HorizontalSkew = outerShadowEffect.SkewHorizontal;
				class7.RotateWithShape = outerShadowEffect.RotateShadowWithShape;
				class7.ShadowAlignment = (Enum463)outerShadowEffect.RectangleAlign;
				class7.ShadowDirection = outerShadowEffect.Direction * 60000f;
				class7.ShadowOffsetDistance = outerShadowEffect.Distance * 12700.0;
				class7.VerticalScalingFactor = outerShadowEffect.ScaleVertical;
				class7.VerticalSkew = outerShadowEffect.SkewVertical;
				@class.Shadow = class7;
			}
			else if (effectFormatEffectiveData.PresetShadowEffect != null)
			{
				IPresetShadowEffectiveData presetShadowEffect = effectFormatEffectiveData.PresetShadowEffect;
				Class3367 class8 = new Class3367();
				class8.Color = smethod_12(presetShadowEffect.ShadowColor);
				class8.Direction = presetShadowEffect.Direction * 60000f;
				class8.Distance = presetShadowEffect.Distance * 12700.0;
				class8.PresetShadow = (Enum464)presetShadowEffect.Preset;
				@class.Shadow = class8;
			}
		}
	}

	private static void smethod_4(GeometryShape src, Class3434 dest)
	{
		IThreeDFormat threeDFormat = src.ThreeDFormat;
		Class3372 @class = new Class3372();
		if (threeDFormat.Camera.CameraType != CameraPresetType.NotDefined)
		{
			@class.Camera = new Class3435((Enum481)threeDFormat.Camera.CameraType);
			@class.Camera.FieldOfView = threeDFormat.Camera.FieldOfViewAngle * 60000f;
			@class.Camera.Zoom = threeDFormat.Camera.Zoom;
			smethod_6(threeDFormat.Camera.GetRotation(), @class.Camera.Rotation);
		}
		if (threeDFormat.LightRig.LightType != LightRigPresetType.NotDefined)
		{
			@class.LightRig.RigType = (Enum483)threeDFormat.LightRig.LightType;
			@class.LightRig.Direction = (Enum482)threeDFormat.LightRig.Direction;
			smethod_6(threeDFormat.LightRig.GetRotation(), @class.LightRig.Rotation);
		}
		if (threeDFormat is ThreeDFormat)
		{
			ThreeDFormat threeDFormat2 = (ThreeDFormat)threeDFormat;
			@class.Backdrop = new Class3343();
			@class.Backdrop.Anchor = smethod_18(threeDFormat2.PPTXUnsupportedProps.BackdropPlane.AnchorPoint);
			@class.Backdrop.Normal = smethod_17(threeDFormat2.PPTXUnsupportedProps.BackdropPlane.NormalVector);
			@class.Backdrop.Up = smethod_17(threeDFormat2.PPTXUnsupportedProps.BackdropPlane.NormalVector);
			dest.KeepTextFlat = threeDFormat2.PPTXUnsupportedProps.FlatText;
			dest.FlatTextZ = (int)(threeDFormat2.PPTXUnsupportedProps.FlatTextZCoordinate * 12700f);
		}
		dest.Scene3D = @class;
		Class3374 class2 = new Class3374();
		class2.ShapeDepth = threeDFormat.Depth;
		class2.ExtrusionHeight = threeDFormat.ExtrusionHeight * 12700.0;
		class2.ExtrusionColor = smethod_12(threeDFormat.ExtrusionColor.Color);
		class2.ContourColor = smethod_12(threeDFormat.ContourColor.Color);
		class2.ContourWidth = threeDFormat.ContourWidth * 12700.0;
		class2.ShapeDepth = threeDFormat.Depth * 12700.0;
		if (threeDFormat.Material != MaterialPresetType.NotDefined)
		{
			class2.PresetMaterial = (Enum467)threeDFormat.Material;
		}
		if (threeDFormat.BevelBottom.BevelType != BevelPresetType.NotDefined)
		{
			class2.BottomBevel = smethod_19(threeDFormat.BevelBottom);
		}
		if (threeDFormat.BevelTop.BevelType != BevelPresetType.NotDefined)
		{
			class2.TopBevel = smethod_19(threeDFormat.BevelTop);
		}
		dest.Shape3DType = class2;
	}

	private static void smethod_5(GraphicsPath srcPath, Class3279 destGeometry)
	{
		PointF[] pathPoints = srcPath.PathPoints;
		byte[] pathTypes = srcPath.PathTypes;
		int pointCount = srcPath.PointCount;
		for (int i = 0; i < pointCount; i++)
		{
			byte b = pathTypes[i];
			if (b == 0)
			{
				Struct159 @struct = smethod_14(pathPoints[i]);
				destGeometry.method_3(@struct.X, @struct.Y);
			}
			if ((b & 3) == 3)
			{
				Struct159 struct2 = smethod_14(pathPoints[i]);
				Struct159 firstControlPoint = new Struct159(struct2.X, struct2.Y);
				i++;
				struct2 = smethod_14(pathPoints[i]);
				Struct159 secondControlPoint = new Struct159(struct2.X, struct2.Y);
				i++;
				struct2 = smethod_14(pathPoints[i]);
				b = pathTypes[i];
				Struct159 endingPoint = new Struct159(struct2.X, struct2.Y);
				destGeometry.method_6(firstControlPoint, secondControlPoint, endingPoint);
			}
			else if ((b & 1) == 1)
			{
				Struct159 struct3 = smethod_14(pathPoints[i]);
				destGeometry.method_4(struct3.X, struct3.Y);
			}
			if ((b & 0x80) == 128)
			{
				destGeometry.method_8();
			}
		}
	}

	private static void smethod_6(float[] src, Class3458 dest)
	{
		if (src != null && src.Length == 3)
		{
			dest.Latitude = src[0] * 60000f;
			dest.Longitude = src[1] * 60000f;
			dest.Revolution = src[2] * 60000f;
		}
	}

	private static Class3090 smethod_7(GeometryShape srcShape, Class3448 srcTransform2D)
	{
		if (srcShape.ShapeType != 0 && srcShape.ShapeType != ShapeType.NotDefined)
		{
			Class3091 @class = Class3091.smethod_13((Enum493)srcShape.ShapeType, srcTransform2D);
			{
				foreach (object adjustment in srcShape.Adjustments)
				{
					if (adjustment is Class341 class2)
					{
						@class.AdjustValues[class2.Name] = class2.RawValue;
					}
				}
				return @class;
			}
		}
		_ = srcTransform2D.Offset.X;
		_ = srcTransform2D.Offset.Y;
		double cx = srcTransform2D.Extents.Cx;
		double cy = srcTransform2D.Extents.Cy;
		Class3279 class3 = new Class3279(srcTransform2D);
		ShapeElement[] array = srcShape.Geometry.CreateShapeElements(srcShape, 0f, 0f, (float)cx / 12700f, (float)cy / 12700f);
		ShapeElement[] array2 = array;
		foreach (ShapeElement shapeElement in array2)
		{
			if (shapeElement.ElementType == Enum116.const_0)
			{
				class3.method_2(srcTransform2D.Extents.Cx, srcTransform2D.Extents.Cy, smethod_16(shapeElement.FillSource), extrusionOk: false, stroke: true);
				smethod_5(shapeElement.GraphicsPath, class3);
			}
		}
		return class3;
	}

	private static Class3331 smethod_8(ILineFillFormatEffectiveData fillData)
	{
		return smethod_10(fillData.FillType, fillData.SolidFillColor, fillData.GradientFormat, fillData.RotateWithShape, null, fillData.PatternFormat);
	}

	private static Class3331 smethod_9(IFillFormatEffectiveData fillData)
	{
		return smethod_10(fillData.FillType, fillData.SolidFillColor, fillData.GradientFormat, fillData.RotateWithShape, fillData.PictureFillFormat, fillData.PatternFormat);
	}

	private static Class3331 smethod_10(FillType type, Color solidColor, IGradientFormatEffectiveData gradient, bool rotateWithShape, IPictureFillFormatEffectiveData picture, IPatternFormatEffectiveData pattern)
	{
		Class3331 result = null;
		switch (type)
		{
		case FillType.NotDefined:
		case FillType.NoFill:
			result = new Class3336();
			break;
		case FillType.Solid:
			result = new Class3339(smethod_12(solidColor));
			break;
		case FillType.Gradient:
			result = smethod_13(gradient, rotateWithShape);
			break;
		case FillType.Pattern:
		case FillType.Picture:
			result = new Class3339(Class3453.smethod_1(0, 0, 0));
			break;
		}
		return result;
	}

	private static Color smethod_11(Class3453 color)
	{
		return Color.FromArgb((int)(color.Alpha * 255f), (int)(color.Red * 255f), (int)(color.Green * 255f), (int)(color.Blue * 255f));
	}

	private static Class3453 smethod_12(Color color)
	{
		return new Class3453((float)(int)color.R / 255f, (float)(int)color.G / 255f, (float)(int)color.B / 255f, (float)(int)color.A / 255f);
	}

	private static Class3332 smethod_13(IGradientFormatEffectiveData gradient, bool rotateWithShape)
	{
		Class3332 class2;
		if (gradient.GradientShape == GradientShape.Linear)
		{
			Class3333 @class = new Class3333(gradient.LinearGradientAngle * 60000f, gradient.LinearGradientScaled);
			foreach (IGradientStopEffectiveData gradientStop in gradient.GradientStops)
			{
				@class.GradientStopList.Add(new Class3329(smethod_12(gradientStop.Color), gradientStop.Position * 100f));
			}
			class2 = @class;
		}
		else
		{
			Class3334 class3 = new Class3334();
			class3.Path = (Enum460)gradient.GradientShape;
			foreach (IGradientStopEffectiveData gradientStop2 in gradient.GradientStops)
			{
				class3.GradientStopList.Add(new Class3329(smethod_12(gradientStop2.Color), gradientStop2.Position * 100f));
			}
			class2 = class3;
		}
		class2.TileFlip = (Enum461)gradient.TileFlip;
		class2.RotateWithShape = rotateWithShape;
		return class2;
	}

	private static Struct159 smethod_14(PointF point)
	{
		return new Struct159(point.X * 12700f, point.Y * 12700f);
	}

	private static Class3448 smethod_15(ShapeFrame frame)
	{
		float x = frame.X;
		float y = frame.Y;
		float width = frame.Width;
		float height = frame.Height;
		if (!float.IsNaN(x) && !float.IsNaN(y) && !float.IsNaN(width) && !float.IsNaN(height))
		{
			return new Class3448(new Class3456(x * 12700f, y * 12700f), new Class3455(width * 12700f, height * 12700f), frame.Rotation * 60000f, frame.FlipH == NullableBool.True, frame.FlipV == NullableBool.True);
		}
		return new Class3448();
	}

	private static Enum492 smethod_16(ShapeElementFillSource fillMode)
	{
		return fillMode switch
		{
			ShapeElementFillSource.NoFill => Enum492.const_5, 
			ShapeElementFillSource.Lighten => Enum492.const_3, 
			ShapeElementFillSource.LightenLess => Enum492.const_4, 
			ShapeElementFillSource.Darken => Enum492.const_1, 
			ShapeElementFillSource.DarkenLess => Enum492.const_2, 
			_ => Enum492.const_0, 
		};
	}

	private static Struct163 smethod_17(float[] array)
	{
		if (array != null && array.Length == 3)
		{
			return new Struct163(array[0], array[1], array[2]);
		}
		return default(Struct163);
	}

	private static Struct162 smethod_18(float[] array)
	{
		if (array != null && array.Length == 3)
		{
			return new Struct162(array[0], array[1], array[2]);
		}
		return default(Struct162);
	}

	private static Class3373 smethod_19(IShapeBevel bevel)
	{
		Class3373 @class = new Class3373();
		@class.PresetBevel = (Enum466)bevel.BevelType;
		@class.Height = bevel.Height * 12700.0;
		@class.Width = bevel.Width * 12700.0;
		return @class;
	}
}
