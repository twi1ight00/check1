using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns11;
using ns12;
using ns18;
using ns224;
using ns24;
using ns28;
using ns4;
using ns7;

namespace Aspose.Slides;

public class AutoShape : GeometryShape, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape, IAutoShape
{
	private bool bool_1;

	private bool bool_2;

	private TextFrame textFrame_0;

	public new IAutoShapeLock ShapeLock => (IAutoShapeLock)base.ShapeLock;

	internal new Class285 PPTXUnsupportedProps => (Class285)base.PPTXUnsupportedProps;

	public ITextFrame TextFrame => TextFrameInternal;

	internal TextFrame TextFrameInternal
	{
		get
		{
			return textFrame_0;
		}
		set
		{
			textFrame_0 = value;
		}
	}

	internal override uint Version_OldMode => uint_0 + ((Presentation)base.Presentation).Version_OldMode + ((TextFrameInternal != null) ? TextFrameInternal.textFrameFormat_0.Version_OldMode : 0);

	public bool UseBackgroundFill
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

	internal bool IsTextBox
	{
		get
		{
			return PPTXUnsupportedProps.IsTextBox;
		}
		set
		{
			PPTXUnsupportedProps.IsTextBox = value;
		}
	}

	IGeometryShape IAutoShape.AsIGeometryShape => this;

	internal AutoShape(IBaseSlide parent)
		: base(parent, new Class285())
	{
		base.ShapeLock = new AutoShapeLock();
	}

	internal void method_26()
	{
		uint_1 = Version_OldMode;
	}

	internal override void vmethod_6()
	{
		if (TextFrameInternal != null && TextFrameInternal.Paragraphs.Count != 0 && TextFrameInternal.TextFrameFormat.AutofitType == TextAutofitType.Shape && !bool_2 && uint_1 != Version_OldMode && !Connector.dictionary_0.ContainsKey(ShapeType) && !((Presentation)base.Presentation).IsParsingInProgress)
		{
			bool_2 = true;
			float num = 0f;
			float num2 = 0f;
			switch (TextFrameInternal.Paragraphs[0].ParagraphFormat.Alignment)
			{
			case TextAlignment.Right:
				num = 1f;
				break;
			case TextAlignment.Center:
			case TextAlignment.Justify:
				num = 0.5f;
				break;
			}
			switch (TextFrameInternal.TextFrameFormat.AnchoringType)
			{
			case TextAnchorType.Bottom:
				num2 = 1f;
				break;
			case TextAnchorType.Center:
			case TextAnchorType.Distributed:
				num2 = 0.5f;
				break;
			}
			ShapeFrame shapeFrame = method_4();
			if (float.IsNaN(shapeFrame.CenterX + shapeFrame.CenterY))
			{
				bool_2 = false;
				return;
			}
			Shape[] prototypes = method_2();
			RectangleF textRect = method_32(shapeFrame, prototypes, out var lm, out var tm, out var rm, out var bm, out var protoFrames);
			Class6002 @class = smethod_4(shapeFrame, textRect, lm, tm, rm, bm, TextVerticalType.Horizontal, 0f);
			PointF[] array = new PointF[1]
			{
				new PointF(num * textRect.Width, num2 * textRect.Height)
			};
			@class.method_3(array);
			PointF pointF = array[0];
			TextFrameInternal.method_4(textRect.Width - lm - rm, textRect.Height - tm - bm, base.ShapeStyle, protoFrames, null);
			SizeF wantedSize = TextFrameInternal.WantedSize;
			method_28(prototypes, wantedSize.Width + lm + rm, wantedSize.Height + tm + bm);
			shapeFrame = method_4();
			@class = smethod_4(shapeFrame, textRect, lm, tm, rm, bm, TextVerticalType.Horizontal, 0f);
			textRect = method_32(shapeFrame, prototypes, out lm, out tm, out rm, out bm, out protoFrames);
			array[0].X = num * textRect.Width;
			array[0].Y = num2 * textRect.Height;
			@class.method_3(array);
			shapeFrame = new ShapeFrame(shapeFrame.X + pointF.X - array[0].X, shapeFrame.Y + pointF.Y - array[0].Y, shapeFrame.Width, shapeFrame.Height, shapeFrame.FlipH, shapeFrame.FlipV, shapeFrame.Rotation);
			method_6(shapeFrame);
			TextFrameInternal.class532_0 = null;
			bool_2 = false;
			method_26();
		}
	}

	private SizeF method_27(Shape[] prototypes, float width, float height)
	{
		if (width < 1f)
		{
			width = 1f;
		}
		if (height < 1f)
		{
			height = 1f;
		}
		RectangleF rectangleF = method_33(0f, 0f, width, height, prototypes, out var lm, out var tm, out var rm, out var bm, out var protoFrames);
		if (rectangleF.Width < 1f)
		{
			rectangleF.Width = 1f;
		}
		if (rectangleF.Height < 1f)
		{
			rectangleF.Height = 1f;
		}
		double num = (double)width / (double)height;
		double num2 = 1.0;
		double num3 = (double)rectangleF.Width / (double)rectangleF.Height;
		double num4 = num / num3;
		num4 *= num4;
		float num5;
		float num6;
		while (true)
		{
			num5 = (float)((double)width * num2);
			num6 = (float)((double)height / num2);
			rectangleF = method_33(0f, 0f, num5, num6, prototypes, out lm, out tm, out rm, out bm, out protoFrames);
			double num7 = (double)rectangleF.Width / (double)rectangleF.Height;
			if (!(Math.Abs(num7 - num) < 0.0001))
			{
				if ((num7 < num && num3 > num) || (num7 > num && num3 < num))
				{
					num4 = 1.0 / Math.Sqrt(num4);
				}
				num3 = num7;
				num2 *= num4;
				if (double.IsInfinity(num2) || num2 == 0.0)
				{
					throw new InvalidOperationException("Unexpected error calculating shape size. Please contact Aspose Pty Ltd.");
				}
				continue;
			}
			break;
		}
		float num8 = width / rectangleF.Width + 0.001f;
		return new SizeF(num5 * num8, num6 * num8);
	}

	internal void method_28(Shape[] prototypes, float width, float height)
	{
		if (TextFrameInternal != null)
		{
			SizeF sizeF = method_27(prototypes, width, height);
			ShapeFrame shapeFrame = (ShapeFrame)base.Frame;
			base.Frame = new ShapeFrame(shapeFrame.X, shapeFrame.Y, sizeF.Width, sizeF.Height, shapeFrame.FlipH, shapeFrame.FlipV, shapeFrame.Rotation);
		}
	}

	internal override void vmethod_4(Class159 canvas, Class169 rc)
	{
		try
		{
			rc.Hyperlink = base.HyperlinkClick;
			bool flag = false;
			GradientDirection gradientDirection = GradientDirection.NotDefined;
			if (base.Geometry.Preset == ShapeType.Custom && FillFormat.FillType == FillType.Gradient && FillFormat.GradientFormat != null && FillFormat.GradientFormat.GradientShape == GradientShape.Path)
			{
				flag = true;
				FillFormat.GradientFormat.GradientShape = GradientShape.Radial;
				gradientDirection = FillFormat.GradientFormat.GradientDirection;
				FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCenter;
			}
			base.vmethod_4(canvas, rc);
			if (flag)
			{
				FillFormat.GradientFormat.GradientShape = GradientShape.Path;
				FillFormat.GradientFormat.GradientDirection = gradientDirection;
			}
			if (base.Hidden || TextFrameInternal == null)
			{
				return;
			}
			method_30(out var frame, out var textRect, out var lm, out var tm, out var rm, out var bm, rc);
			Class6002 @class = smethod_4(frame, textRect, lm, tm, rm, bm, TextFrameInternal.textFrameFormat_0.InheritedTextVerticalType, TextFrameInternal.textFrameFormat_0.RotationAngle);
			Class520 textShape = TextFrameInternal.textFrameFormat_0.PPTXUnsupportedProps.TextShape;
			bool flag2 = false;
			if (textShape != null)
			{
				flag2 = textShape.TextShapeType != TextShapeType.NotDefined && textShape.TextShapeType != TextShapeType.Custom && textShape.TextShapeType != TextShapeType.None;
			}
			try
			{
				if (flag2)
				{
					using (Class179 class2 = new Class179(null))
					{
						class2.method_0(canvas, rc, this, @class);
						return;
					}
				}
				canvas.method_0(@class);
				TextFrameInternal.method_10(canvas, rc);
			}
			finally
			{
				if (!flag2)
				{
					canvas.method_1();
				}
				if (rc.Hyperlink != null)
				{
					rc.Hyperlink = null;
					canvas.vmethod_17();
				}
			}
		}
		finally
		{
			rc.Hyperlink = null;
		}
	}

	internal override Class63 vmethod_9(Class159 canvas, ShapeFrame frame, GraphicsPath path, Class63[] fpCache, ShapeElementFillSource fillSource, IFillParamSource shapeFill, Shape[] protos, Class169 rc)
	{
		if (bool_1)
		{
			return rc.BackgroundFill;
		}
		return base.vmethod_9(canvas, frame, path, fpCache, fillSource, shapeFill, protos, rc);
	}

	internal void method_29()
	{
		method_30(out var _, out var _, out var _, out var _, out var _, out var _, null);
	}

	private void method_30(out ShapeFrame frame, out RectangleF textRect, out float lm, out float tm, out float rm, out float bm, Class169 rc)
	{
		Shape[] prototypes = method_2();
		frame = method_4();
		textRect = method_32(frame, prototypes, out lm, out tm, out rm, out bm, out var protoFrames);
		if (PPTXUnsupportedProps.TxXfrm != null)
		{
			Class154 @class = new Class154();
			Class1021.smethod_1(@class, PPTXUnsupportedProps.TxXfrm);
			if (!double.IsNaN(RawFrameImpl.Rotation))
			{
				@class.Rotation = (double.IsNaN(@class.Rotation) ? 0f : @class.Rotation) + RawFrameImpl.Rotation;
			}
			@class.FlipH = ((@class.FlipH != NullableBool.NotDefined) ? @class.FlipH : NullableBool.False);
			@class.FlipV = ((@class.FlipV != NullableBool.NotDefined) ? @class.FlipV : NullableBool.False);
			frame = method_5(new ShapeFrame(@class.X, @class.Y, @class.Width, @class.Height, @class.FlipH, @class.FlipV, @class.Rotation));
			textRect = new RectangleF(frame.X, frame.Y, frame.Width, frame.Height);
		}
		TextFrameInternal.method_4(textRect.Width - lm - rm, textRect.Height - tm - bm, base.ShapeStyle, protoFrames, rc);
	}

	internal void method_31(TextFrame textFrameToUpdate)
	{
		Shape[] prototypes = method_2();
		ShapeFrame frame = method_4();
		method_32(frame, prototypes, out var lm, out var tm, out var rm, out var bm, out var protoFrames);
		textFrameToUpdate.TextFrameFormat.MarginLeft = lm;
		textFrameToUpdate.TextFrameFormat.MarginTop = tm;
		textFrameToUpdate.TextFrameFormat.MarginRight = rm;
		textFrameToUpdate.TextFrameFormat.MarginBottom = bm;
		TextFrameInternal.method_5(protoFrames, textFrameToUpdate);
	}

	private RectangleF method_32(ShapeFrame frame, Shape[] prototypes, out float lm, out float tm, out float rm, out float bm, out TextFrame[] protoFrames)
	{
		return method_33(frame.X, frame.Y, frame.Width, frame.Height, prototypes, out lm, out tm, out rm, out bm, out protoFrames);
	}

	private RectangleF method_33(float x, float y, float width, float height, Shape[] prototypes, out float lm, out float tm, out float rm, out float bm, out TextFrame[] protoFrames)
	{
		lm = (float)TextFrameInternal.TextFrameFormat.MarginLeft;
		tm = (float)TextFrameInternal.TextFrameFormat.MarginTop;
		rm = (float)TextFrameInternal.TextFrameFormat.MarginRight;
		bm = (float)TextFrameInternal.TextFrameFormat.MarginBottom;
		protoFrames = ((prototypes.Length == 0) ? null : new TextFrame[prototypes.Length]);
		for (int i = 0; i < prototypes.Length; i++)
		{
			if (prototypes[i] is AutoShape autoShape && autoShape.TextFrameInternal != null)
			{
				protoFrames[i] = autoShape.TextFrameInternal;
				if (float.IsNaN(lm))
				{
					lm = (float)autoShape.TextFrameInternal.TextFrameFormat.MarginLeft;
				}
				if (float.IsNaN(tm))
				{
					tm = (float)autoShape.TextFrameInternal.TextFrameFormat.MarginTop;
				}
				if (float.IsNaN(rm))
				{
					rm = (float)autoShape.TextFrameInternal.TextFrameFormat.MarginRight;
				}
				if (float.IsNaN(bm))
				{
					bm = (float)autoShape.TextFrameInternal.TextFrameFormat.MarginBottom;
				}
			}
		}
		if (float.IsNaN(lm + tm + rm + bm))
		{
			if (float.IsNaN(lm))
			{
				lm = 7.2f;
			}
			if (float.IsNaN(tm))
			{
				tm = 3.6f;
			}
			if (float.IsNaN(rm))
			{
				rm = 7.2f;
			}
			if (float.IsNaN(bm))
			{
				bm = 3.6f;
			}
		}
		Class540 geometry = base.Geometry;
		if (geometry.Preset == ShapeType.NotDefined)
		{
			for (int j = 0; j < prototypes.Length; j++)
			{
				if (prototypes[j] is GeometryShape geometryShape && geometryShape.Geometry.Preset != ShapeType.NotDefined)
				{
					geometry = geometryShape.Geometry;
					break;
				}
			}
		}
		return geometry.method_0(this, x, y, width, height);
	}

	private static Class6002 smethod_4(ShapeFrame frame, RectangleF textRect, float leftMargin, float topMargin, float rightMargin, float bottomMargin, TextVerticalType vertType, float textFrameAngle)
	{
		float num = frame.Rotation;
		if (float.IsNaN(num))
		{
			num = 0f;
		}
		if (!float.IsNaN(textFrameAngle))
		{
			num += textFrameAngle;
		}
		if (frame.FlipH == NullableBool.True || frame.FlipV == NullableBool.True)
		{
			textRect.Offset((frame.FlipH == NullableBool.True) ? ((frame.CenterX - textRect.X) * 2f - textRect.Width) : 0f, (frame.FlipV == NullableBool.True) ? ((frame.CenterY - textRect.Y) * 2f - textRect.Height) : 0f);
		}
		textFrameAngle %= 360f;
		if (textFrameAngle < 0f)
		{
			textFrameAngle += 360f;
		}
		if (textFrameAngle >= 135f && textFrameAngle < 225f)
		{
			textRect.Offset((frame.CenterX - textRect.X) * 2f - textRect.Width, (frame.CenterY - textRect.Y) * 2f - textRect.Height);
		}
		float num2;
		float num3;
		switch (vertType)
		{
		case TextVerticalType.Vertical270:
			num -= 90f;
			num2 = frame.CenterY - textRect.Bottom + bottomMargin;
			num3 = textRect.X - frame.CenterX + leftMargin;
			break;
		default:
			num2 = textRect.X - frame.CenterX + leftMargin;
			num3 = textRect.Y - frame.CenterY + topMargin;
			break;
		case TextVerticalType.Vertical:
		case TextVerticalType.EastAsianVertical:
		case TextVerticalType.MongolianVertical:
			num += 90f;
			num2 = textRect.Y - frame.CenterY + topMargin;
			num3 = frame.CenterX - textRect.Right + rightMargin;
			break;
		}
		Class6002 @class = new Class6002();
		@class.method_13((frame.FlipV == NullableBool.True) ? (num + 180f) : num, new PointF(frame.CenterX, frame.CenterY), MatrixOrder.Prepend);
		@class.method_7(frame.CenterX + num2, frame.CenterY + num3, MatrixOrder.Prepend);
		return @class;
	}

	public virtual ITextFrame AddTextFrame(string text)
	{
		if (TextFrameInternal == null)
		{
			TextFrameInternal = new TextFrame(this);
		}
		((ParagraphCollection)TextFrameInternal.Paragraphs).Text = text;
		return TextFrame;
	}

	internal override void vmethod_10(Class437 style, Class437 textStyle, Class476 package, Class369 shape)
	{
		base.vmethod_10(style, textStyle, package, shape);
		if (style != null)
		{
			((TextFrame)TextFrame).method_11(shape, style, textStyle);
		}
	}

	internal override void vmethod_11(Class437 style, Class476 odpPackage, Shape[] protos)
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
		array[num++] = FillFormat;
		Class469 @class = (UseBackgroundFill ? new Class469() : new Class469(array));
		@class.method_1(style.GraphicProperties.FillProperties, (BaseSlide)base.Slide, odpPackage, FloatColor.floatColor_0);
	}

	internal override void vmethod_12(Class437 style, Class476 odpPackage, Class369 shape)
	{
		base.vmethod_12(style, odpPackage, shape);
		((TextFrame)TextFrame).method_13(odpPackage, shape, (Class438)style.ParentNode, style);
	}
}
