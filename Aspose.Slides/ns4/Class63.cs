using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Slides;
using ns224;
using ns233;
using ns235;
using ns24;
using ns33;

namespace ns4;

internal sealed class Class63
{
	internal const float float_0 = 72f;

	private const float float_1 = 2.2f;

	private const float float_2 = 0.45454544f;

	private static readonly float[] float_3 = new float[5] { 0.014f, 0.033f, 0.096f, 0.2f, 0.333f };

	private static readonly float[] float_4 = new float[5] { 0.05f, 0.1f, 0.2f, 0.3f, 0.4f };

	private Color color_0;

	private Color color_1;

	private PointF pointF_0;

	private bool bool_0;

	private bool bool_1;

	private float float_5;

	private bool bool_2;

	private bool bool_3;

	private IShape ishape_0;

	private RectangleF rectangleF_0;

	private RectangleF rectangleF_1;

	private Class1148 class1148_0 = new Class1148();

	private Class1148 class1148_1 = new Class1148(0.5f, 0.5f, 0f, 0f);

	private GradientShape gradientShape_0;

	private short short_0;

	private short short_1;

	private short short_2;

	private short short_3;

	private bool bool_4;

	private SortedList<float, Color> sortedList_0;

	private short short_4;

	private PatternStyle patternStyle_0;

	private int int_0 = -1;

	private string string_0;

	private FillType fillType_0;

	private PictureFillMode pictureFillMode_0;

	private GraphicsPath graphicsPath_0;

	private Class64 class64_0;

	private RectangleAlignment rectangleAlignment_0;

	private WrapMode wrapMode_0;

	private float float_6 = 1f;

	private float float_7 = 1f;

	private float float_8;

	private float float_9;

	private Class6145 class6145_0;

	private static readonly Class1155 class1155_0 = new Class1155(TileFlip.NoFlip, WrapMode.Tile, TileFlip.FlipX, WrapMode.TileFlipX, TileFlip.FlipY, WrapMode.TileFlipY, TileFlip.FlipBoth, WrapMode.TileFlipXY, TileFlip.NotDefined, WrapMode.Tile);

	public Color ForeColor
	{
		get
		{
			if (bool_0)
			{
				return color_0;
			}
			return Color.White;
		}
		set
		{
			bool_0 = true;
			color_0 = value;
		}
	}

	public Color BackColor
	{
		get
		{
			if (bool_1)
			{
				return color_1;
			}
			return Color.White;
		}
		set
		{
			bool_1 = true;
			color_1 = value;
		}
	}

	public Enum4 GradientColorType
	{
		get
		{
			if (short_0 >= 0)
			{
				return (Enum4)short_0;
			}
			return Enum4.const_3;
		}
		set
		{
			short_0 = (short)value;
		}
	}

	public int GradientDegree
	{
		get
		{
			if (short_1 >= 0)
			{
				return short_1;
			}
			return 0;
		}
		set
		{
			short_1 = (short)value;
		}
	}

	public int GradientFillAngle
	{
		get
		{
			if (short_2 >= 0)
			{
				return short_2;
			}
			return 0;
		}
		set
		{
			short_2 = (short)value;
		}
	}

	public int GradientFillFocus
	{
		get
		{
			if (short_3 >= -100)
			{
				return short_3;
			}
			return 0;
		}
		set
		{
			short_3 = (short)value;
		}
	}

	public Enum6 GradientStyle
	{
		get
		{
			if (short_4 >= 0)
			{
				return (Enum6)short_4;
			}
			return Enum6.const_1;
		}
		set
		{
			short_4 = (short)value;
		}
	}

	public SortedList<float, Color> RawGradientStops
	{
		get
		{
			if (sortedList_0 != null)
			{
				return new SortedList<float, Color>(sortedList_0);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				sortedList_0 = null;
				return;
			}
			int count = value.Count;
			SortedList<float, Color> sortedList = new SortedList<float, Color>(count);
			for (int i = 0; i < count; i++)
			{
				object obj = value.Keys[i];
				object obj2 = value.Values[i];
				if (obj is float && obj2 is Color)
				{
					sortedList.Add((float)obj, (Color)obj2);
				}
			}
			sortedList_0 = sortedList;
		}
	}

	public GradientShape GradientShape
	{
		get
		{
			return gradientShape_0;
		}
		set
		{
			gradientShape_0 = value;
		}
	}

	public GraphicsPath GradientGraphicsPath => graphicsPath_0;

	public PatternStyle PatternStyleEx
	{
		get
		{
			return patternStyle_0;
		}
		set
		{
			patternStyle_0 = value;
		}
	}

	public float TextureScaleX
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	public float TextureScaleY
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	public float TextureScaleOffsetX
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = value;
		}
	}

	public float TextureScaleOffsetY
	{
		get
		{
			return float_9;
		}
		set
		{
			float_9 = value;
		}
	}

	public RectangleAlignment TextureAlignment
	{
		get
		{
			return rectangleAlignment_0;
		}
		set
		{
			rectangleAlignment_0 = value;
		}
	}

	public int PictureId
	{
		get
		{
			if (int_0 >= 0)
			{
				return int_0;
			}
			if (string_0 != null)
			{
				return string_0.GetHashCode() & 0x7FFFFFFF;
			}
			return -1;
		}
		set
		{
			int_0 = (short)value;
		}
	}

	public string StringPictureId
	{
		get
		{
			if (int_0 >= 0)
			{
				return int_0.ToString("x");
			}
			return string_0;
		}
	}

	public FillType FillType
	{
		get
		{
			if (fillType_0 != FillType.NotDefined)
			{
				return fillType_0;
			}
			return FillType.NoFill;
		}
		set
		{
			fillType_0 = value;
		}
	}

	public PictureFillMode PictureFillMode => pictureFillMode_0;

	public RectangleF Rectangle
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	public RectangleF SourceRect => rectangleF_1;

	public Class1148 Tile => class1148_0;

	public Class1148 FillTo => class1148_1;

	public WrapMode TextureWrap => wrapMode_0;

	public PointF CenterPoint
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public float FillRotation
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	public IShape ShadeToShape
	{
		get
		{
			return ishape_0;
		}
		set
		{
			ishape_0 = value;
		}
	}

	public Class63(Color color)
	{
		Initialize(new RectangleF(0f, 0f, 0f, 0f));
		bool_0 = true;
		color_0 = color;
		fillType_0 = FillType.Solid;
	}

	internal Class63(Class64 image, RectangleF rect)
	{
		Initialize(rect);
		class64_0 = image;
		fillType_0 = FillType.Picture;
		pictureFillMode_0 = PictureFillMode.Stretch;
	}

	public Class63(Class67 arguments, params IFillParamSource[] fillprops)
	{
		Initialize(arguments, fillprops);
	}

	public Class63(Class67 arguments, FillFormatEffectiveDataPVITemp fillEffective)
	{
		graphicsPath_0 = arguments.GrPath;
		bool_0 = false;
		bool_1 = false;
		short_0 = -1;
		short_1 = -1;
		short_2 = -1;
		short_3 = -101;
		short_4 = -1;
		patternStyle_0 = PatternStyle.NotDefined;
		int_0 = -1;
		rectangleF_0 = arguments.Frame.Rectangle;
		pointF_0 = new PointF(arguments.Frame.CenterX, arguments.Frame.CenterY);
		switch (fillEffective.fillType_0)
		{
		case FillType.NotDefined:
			return;
		case FillType.NoFill:
			fillType_0 = FillType.NoFill;
			break;
		case FillType.Solid:
			fillType_0 = FillType.Solid;
			ForeColor = fillEffective.SolidFillColor;
			break;
		case FillType.Gradient:
		{
			Class58 @class = (Class58)fillEffective.GradientFormat;
			fillType_0 = FillType.Gradient;
			GradientShape = @class.GradientShape;
			switch (@class.GradientShape)
			{
			case GradientShape.Linear:
				short_4 = 1;
				break;
			case GradientShape.Rectangle:
			case GradientShape.Radial:
				short_4 = 6;
				class1148_0 = new Class1148(@class.TileRectangleInternal);
				class1148_1 = new Class1148(@class.FillToRectangleInternal);
				break;
			case GradientShape.Path:
				graphicsPath_0 = arguments.GrPath;
				short_4 = 6;
				class1148_0 = new Class1148(@class.TileRectangleInternal);
				class1148_1 = new Class1148(@class.FillToRectangleInternal);
				break;
			}
			if (class1148_1 != null && (class1148_1.Width < 0f || class1148_1.Height < 0f))
			{
				class1148_1 = new Class1148(class1148_1.X, class1148_1.Y, Math.Max(class1148_1.Width, 0f), Math.Max(class1148_1.Height, 0f));
			}
			short_3 = 0;
			short_2 = (short)(@class.LinearGradientAngle + 90f);
			if (float.IsNaN(short_2))
			{
				short_2 = 0;
			}
			if (short_2 < 0)
			{
				short_2 += 360;
			}
			bool_4 = @class.LinearGradientScaled;
			if (@class.GradientStops.Count != 0)
			{
				sortedList_0 = @class.method_5();
			}
			short_0 = 3;
			break;
		}
		case FillType.Pattern:
			fillType_0 = FillType.Pattern;
			ForeColor = fillEffective.class59_0.ForeColor;
			BackColor = fillEffective.class59_0.BackColor;
			patternStyle_0 = fillEffective.class59_0.PatternStyle;
			break;
		case FillType.Picture:
		{
			PictureFillFormatEffectiveDataPVITemp pictureFillFormatEffectiveDataPVITemp = (PictureFillFormatEffectiveDataPVITemp)fillEffective.PictureFillFormat;
			if (pictureFillFormatEffectiveDataPVITemp.Picture.Image != null)
			{
				float num = pictureFillFormatEffectiveDataPVITemp.CropRight + pictureFillFormatEffectiveDataPVITemp.CropLeft;
				float num2 = pictureFillFormatEffectiveDataPVITemp.CropBottom + pictureFillFormatEffectiveDataPVITemp.CropTop;
				num = ((num == 100f) ? 0.99f : (1f - num / 100f));
				num2 = ((num2 == 100f) ? 0.99f : (1f - num2 / 100f));
				RectangleF rect = new RectangleF(0f, 0f, rectangleF_0.Width / num, rectangleF_0.Height / num2);
				class64_0 = ((Class55)pictureFillFormatEffectiveDataPVITemp.Picture).method_3(arguments.UserToDevice, class1148_0.method_1(rect).Size, arguments.Rc);
				rectangleF_1 = pictureFillFormatEffectiveDataPVITemp.method_2(class64_0.Width, class64_0.Height);
				string_0 = class64_0.Code;
				class6145_0 = new Class6145((double)pictureFillFormatEffectiveDataPVITemp.CropLeft / 100.0, (double)pictureFillFormatEffectiveDataPVITemp.CropRight / 100.0, (double)pictureFillFormatEffectiveDataPVITemp.CropTop / 100.0, (double)pictureFillFormatEffectiveDataPVITemp.CropBottom / 100.0);
			}
			else
			{
				class64_0 = new Class64(new Bitmap(16, 16), "dummy");
				rectangleF_1 = new RectangleF(0f, 0f, 16f, 16f);
			}
			int_0 = -1;
			if (pictureFillFormatEffectiveDataPVITemp.PictureFillMode == PictureFillMode.Stretch)
			{
				fillType_0 = FillType.Picture;
				pictureFillMode_0 = PictureFillMode.Stretch;
				break;
			}
			fillType_0 = FillType.Picture;
			pictureFillMode_0 = PictureFillMode.Tile;
			if (pictureFillFormatEffectiveDataPVITemp.TileAlign != RectangleAlignment.NotDefined)
			{
				rectangleAlignment_0 = pictureFillFormatEffectiveDataPVITemp.TileAlign;
			}
			wrapMode_0 = (WrapMode)class1155_0[pictureFillFormatEffectiveDataPVITemp.TileFlip];
			float_8 = (float)pictureFillFormatEffectiveDataPVITemp.TileOffsetX;
			float_9 = (float)pictureFillFormatEffectiveDataPVITemp.TileOffsetY;
			float_6 = pictureFillFormatEffectiveDataPVITemp.TileScaleX;
			float_7 = pictureFillFormatEffectiveDataPVITemp.TileScaleY;
			break;
		}
		}
		if (fillEffective.RotateWithShape)
		{
			float_5 = 0f;
			return;
		}
		if (float.IsNaN(arguments.Frame.Rotation))
		{
			float_5 = 0f;
		}
		else
		{
			float_5 = 0f - arguments.Frame.Rotation;
		}
		bool_2 = arguments.Frame.FlipH == NullableBool.True;
		bool_3 = arguments.Frame.FlipV == NullableBool.True;
		if (bool_2 ^ bool_3)
		{
			float_5 = 0f - float_5;
		}
	}

	private void Initialize(Class67 arguments, params IFillParamSource[] fillprops)
	{
		graphicsPath_0 = arguments.GrPath;
		bool_0 = false;
		bool_1 = false;
		short_0 = -1;
		short_1 = -1;
		short_2 = -1;
		short_3 = -101;
		short_4 = -1;
		patternStyle_0 = PatternStyle.NotDefined;
		int_0 = -1;
		fillType_0 = FillType.NotDefined;
		rectangleF_0 = arguments.Frame.Rectangle;
		pointF_0 = new PointF(arguments.Frame.CenterX, arguments.Frame.CenterY);
		FloatColor styleColor = null;
		foreach (IFillParamSource fillprop in fillprops)
		{
			method_3(arguments, ref styleColor, fillprop);
		}
	}

	private void Initialize(RectangleF rectangle)
	{
		rectangleF_0 = rectangle;
		float x = rectangle.X + rectangle.Width / 2f;
		float y = rectangle.Y + rectangle.Height / 2f;
		pointF_0 = new PointF(x, y);
		graphicsPath_0 = null;
		bool_0 = false;
		bool_1 = false;
		short_0 = -1;
		short_1 = -1;
		short_2 = -1;
		short_3 = -101;
		bool_4 = true;
		short_4 = -1;
		patternStyle_0 = PatternStyle.NotDefined;
		int_0 = -1;
		fillType_0 = FillType.NotDefined;
		sortedList_0 = null;
	}

	private static RectangleF smethod_0(RectangleF rectangle)
	{
		int num = (int)Math.Floor(rectangle.Left);
		int num2 = (int)Math.Floor(rectangle.Top);
		int num3 = (int)Math.Ceiling(rectangle.Right);
		int num4 = (int)Math.Ceiling(rectangle.Bottom);
		return new RectangleF(num, num2, num3 - num, num4 - num2);
	}

	private static RectangleF smethod_1(RectangleF rectangle)
	{
		int num = (int)Math.Round(rectangle.Left);
		int num2 = (int)Math.Round(rectangle.Top);
		int num3 = (int)Math.Round(rectangle.Right);
		int num4 = (int)Math.Round(rectangle.Bottom);
		return new RectangleF(num, num2, num3 - num, num4 - num2);
	}

	private static RectangleF smethod_2(GraphicsPath gp, RectangleF bounds, float angle, float x, float y)
	{
		Matrix matrix = new Matrix();
		matrix.RotateAt(angle, new PointF(x, y));
		PointF[] array;
		if (gp != null && gp.PointCount > 2)
		{
			int pointCount = gp.PointCount;
			array = new PointF[pointCount];
			PointF[] pathPoints = gp.PathPoints;
			for (int i = 0; i < pointCount; i++)
			{
				ref PointF reference = ref array[i];
				reference = pathPoints[i];
			}
		}
		else
		{
			array = new PointF[4]
			{
				new PointF(bounds.Left, bounds.Top),
				new PointF(bounds.Right, bounds.Top),
				new PointF(bounds.Right, bounds.Bottom),
				new PointF(bounds.Left, bounds.Bottom)
			};
		}
		matrix.TransformPoints(array);
		float x2;
		float num = (x2 = array[0].X);
		float y2;
		float num2 = (y2 = array[0].Y);
		for (int j = 1; j < array.Length; j++)
		{
			if (num > array[j].X)
			{
				num = array[j].X;
			}
			if (x2 < array[j].X)
			{
				x2 = array[j].X;
			}
			if (num2 > array[j].Y)
			{
				num2 = array[j].Y;
			}
			if (y2 < array[j].Y)
			{
				y2 = array[j].Y;
			}
		}
		return new RectangleF(num, num2, x2 - num, y2 - num2);
	}

	public Class63 method_0(Class67 arguments, params IFillParamSource[] fillprops)
	{
		Class63 @class = (Class63)Clone();
		if (fillprops != null && fillprops.Length != 0)
		{
			FloatColor styleColor = new FloatColor(0f, 0f, 0f);
			for (int i = 0; i < fillprops.Length; i++)
			{
				@class.method_3(arguments, ref styleColor, fillprops[i]);
			}
		}
		return @class;
	}

	public Class63 method_1(Class67 arguments, IFillParamSource fillprop)
	{
		Class63 @class = (Class63)Clone();
		if (fillprop != null)
		{
			FloatColor styleColor = new FloatColor(0f, 0f, 0f);
			@class.method_3(arguments, ref styleColor, fillprop);
		}
		return @class;
	}

	public Class63 method_2(IShapeFrame shapeFrame)
	{
		Class63 @class = (Class63)Clone();
		@class.rectangleF_0 = shapeFrame.Rectangle;
		return @class;
	}

	public void method_3(Class67 arguments, ref FloatColor styleColor, IFillParamSource fillprop)
	{
		if (fillprop == null)
		{
			return;
		}
		if (fillprop is IFillFormat)
		{
			FillFormat fillFormat = (FillFormat)fillprop;
			switch (fillFormat.fillType_0)
			{
			case FillType.NotDefined:
				return;
			case FillType.NoFill:
				fillType_0 = FillType.NoFill;
				break;
			case FillType.Solid:
				fillType_0 = FillType.Solid;
				ForeColor = fillFormat.colorFormat_0.method_4(arguments.ColorMappingSlide, styleColor).Color;
				break;
			case FillType.Gradient:
				method_3(arguments, ref styleColor, fillFormat.GradientFormat);
				break;
			case FillType.Pattern:
				fillType_0 = FillType.Pattern;
				ForeColor = ((ColorFormat)fillFormat.patternFormat_0.ForeColor).method_4(arguments.ColorMappingSlide, styleColor).Color;
				BackColor = ((ColorFormat)fillFormat.patternFormat_0.BackColor).method_4(arguments.ColorMappingSlide, styleColor).Color;
				patternStyle_0 = fillFormat.patternFormat_0.PatternStyle;
				break;
			case FillType.Picture:
				method_3(arguments, ref styleColor, fillFormat.PictureFillFormat);
				break;
			}
			if (fillFormat.RotateWithShape == NullableBool.NotDefined)
			{
				return;
			}
			if (fillFormat.RotateWithShape == NullableBool.True)
			{
				float_5 = 0f;
				return;
			}
			if (float.IsNaN(arguments.Frame.Rotation))
			{
				float_5 = 0f;
			}
			else
			{
				float_5 = 0f - arguments.Frame.Rotation;
			}
			bool_2 = arguments.Frame.FlipH == NullableBool.True;
			bool_3 = arguments.Frame.FlipV == NullableBool.True;
			if (bool_2 ^ bool_3)
			{
				float_5 = 0f - float_5;
			}
		}
		else if (fillprop is ILineFillFormat)
		{
			LineFillFormat lineFillFormat = (LineFillFormat)fillprop;
			switch (lineFillFormat.fillType_0)
			{
			case FillType.NoFill:
				fillType_0 = FillType.NoFill;
				break;
			case FillType.Solid:
				fillType_0 = FillType.Solid;
				ForeColor = lineFillFormat.colorFormat_0.method_4(arguments.ColorMappingSlide, styleColor).Color;
				break;
			case FillType.Gradient:
				if (lineFillFormat.GradientFormat.GradientStops.Count < 2)
				{
					fillType_0 = FillType.Solid;
					ForeColor = styleColor.Color;
					break;
				}
				fillType_0 = FillType.Gradient;
				switch (lineFillFormat.GradientFormat.GradientShape)
				{
				case GradientShape.NotDefined:
				case GradientShape.Linear:
					short_4 = 1;
					break;
				case GradientShape.Rectangle:
				case GradientShape.Radial:
					switch (lineFillFormat.GradientFormat.GradientDirection)
					{
					case GradientDirection.FromCorner1:
						short_4 = 2;
						break;
					case GradientDirection.FromCorner2:
						short_4 = 3;
						break;
					case GradientDirection.FromCorner3:
						short_4 = 4;
						break;
					case GradientDirection.FromCorner4:
						short_4 = 5;
						break;
					case GradientDirection.FromCenter:
						short_4 = 6;
						break;
					}
					break;
				case GradientShape.Path:
					graphicsPath_0 = arguments.GrPath;
					break;
				}
				short_3 = 0;
				short_2 = (short)(lineFillFormat.GradientFormat.LinearGradientAngle + 90f);
				if (float.IsNaN(short_2))
				{
					short_2 = 0;
				}
				if (short_2 < 0)
				{
					short_2 += 360;
				}
				bool_4 = lineFillFormat.GradientFormat.LinearGradientScaled > NullableBool.False;
				sortedList_0 = new SortedList<float, Color>();
				foreach (IGradientStop gradientStop in lineFillFormat.GradientFormat.GradientStops)
				{
					sortedList_0.Add(gradientStop.Position, ((ColorFormat)gradientStop.Color).method_4(arguments.ColorMappingSlide, styleColor).Color);
				}
				short_0 = 3;
				break;
			case FillType.Pattern:
				fillType_0 = FillType.Pattern;
				ForeColor = ((ColorFormat)lineFillFormat.patternFormat_0.ForeColor).method_4(arguments.ColorMappingSlide, styleColor).Color;
				BackColor = ((ColorFormat)lineFillFormat.patternFormat_0.BackColor).method_4(arguments.ColorMappingSlide, styleColor).Color;
				patternStyle_0 = lineFillFormat.patternFormat_0.PatternStyle;
				break;
			}
		}
		else if (fillprop is IColorFormat)
		{
			ColorFormat colorFormat = (ColorFormat)fillprop;
			if (colorFormat.ColorType != ColorType.NotDefined)
			{
				ForeColor = colorFormat.method_4(arguments.ColorMappingSlide, styleColor).Color;
			}
		}
		else if (fillprop is IGradientFormat)
		{
			GradientFormat gradientFormat = (GradientFormat)fillprop;
			fillType_0 = FillType.Gradient;
			GradientShape = ((gradientFormat.GradientShape != GradientShape.NotDefined) ? gradientFormat.GradientShape : GradientShape.Linear);
			switch (gradientFormat.GradientShape)
			{
			case GradientShape.NotDefined:
			case GradientShape.Linear:
				short_4 = 1;
				break;
			case GradientShape.Rectangle:
			case GradientShape.Radial:
				short_4 = 6;
				class1148_0 = gradientFormat.TileRectangle;
				class1148_1 = new Class1148(gradientFormat.FillToRectangleX, gradientFormat.FillToRectangleY, gradientFormat.FillToRectangleWidth, gradientFormat.FillToRectangleHeight);
				break;
			case GradientShape.Path:
				graphicsPath_0 = arguments.GrPath;
				short_4 = 6;
				class1148_0 = gradientFormat.TileRectangle;
				class1148_1 = new Class1148(gradientFormat.FillToRectangleX, gradientFormat.FillToRectangleY, gradientFormat.FillToRectangleWidth, gradientFormat.FillToRectangleHeight);
				break;
			}
			if (class1148_1 != null && (class1148_1.Width < 0f || class1148_1.Height < 0f))
			{
				class1148_1 = new Class1148(class1148_1.X, class1148_1.Y, Math.Max(class1148_1.Width, 0f), Math.Max(class1148_1.Height, 0f));
			}
			short_3 = 0;
			short_2 = (short)(gradientFormat.LinearGradientAngle + 90f);
			if (float.IsNaN(short_2))
			{
				short_2 = 0;
			}
			if (short_2 < 0)
			{
				short_2 += 360;
			}
			bool_4 = gradientFormat.LinearGradientScaled > NullableBool.False;
			if (gradientFormat.GradientStops.Count != 0)
			{
				sortedList_0 = gradientFormat.method_2(arguments.ColorMappingSlide, styleColor);
			}
			short_0 = 3;
		}
		else if (fillprop is IPictureFillFormat)
		{
			PictureFillFormat pictureFillFormat = (PictureFillFormat)fillprop;
			if (pictureFillFormat.Picture.Image != null)
			{
				float num = pictureFillFormat.CropRight + pictureFillFormat.CropLeft;
				float num2 = pictureFillFormat.CropBottom + pictureFillFormat.CropTop;
				num = ((num == 100f) ? 0.99f : (1f - num / 100f));
				num2 = ((num2 == 100f) ? 0.99f : (1f - num2 / 100f));
				RectangleF rect = new RectangleF(0f, 0f, rectangleF_0.Width / num, rectangleF_0.Height / num2);
				class64_0 = ((Picture)pictureFillFormat.Picture).method_2(arguments.UserToDevice, class1148_0.method_1(rect).Size, arguments.Rc, arguments.ColorMappingSlide, styleColor);
				rectangleF_1 = pictureFillFormat.method_0(class64_0.Width, class64_0.Height);
				string_0 = class64_0.Code;
				class6145_0 = new Class6145((double)pictureFillFormat.CropLeft / 100.0, (double)pictureFillFormat.CropRight / 100.0, (double)pictureFillFormat.CropTop / 100.0, (double)pictureFillFormat.CropBottom / 100.0);
			}
			else
			{
				class64_0 = new Class64(new Bitmap(16, 16), "dummy");
				rectangleF_1 = new RectangleF(0f, 0f, 16f, 16f);
			}
			int_0 = -1;
			if (pictureFillFormat.PictureFillMode == PictureFillMode.Stretch)
			{
				fillType_0 = FillType.Picture;
				pictureFillMode_0 = PictureFillMode.Stretch;
				return;
			}
			fillType_0 = FillType.Picture;
			pictureFillMode_0 = PictureFillMode.Tile;
			if (pictureFillFormat.TileAlign != RectangleAlignment.NotDefined)
			{
				rectangleAlignment_0 = pictureFillFormat.TileAlign;
			}
			wrapMode_0 = (WrapMode)class1155_0[pictureFillFormat.TileFlip];
			float_8 = (float)pictureFillFormat.TileOffsetX;
			float_9 = (float)pictureFillFormat.TileOffsetY;
			float_6 = pictureFillFormat.TileScaleX;
			float_7 = pictureFillFormat.TileScaleY;
		}
		else if (fillprop is FloatColor)
		{
			FloatColor floatColor = (FloatColor)fillprop;
			ForeColor = floatColor.Color;
		}
		else if (fillprop is Class493)
		{
			Class493 @class = (Class493)fillprop;
			if (@class.floatColor_0 != null)
			{
				styleColor = @class.floatColor_0;
			}
			method_3(arguments, ref styleColor, @class.ifillFormat_0);
		}
	}

	public RectangleF method_4(float dpi)
	{
		method_18();
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float num = (float)class64_0.Image.Height * dpi / class64_0.VerticalResolution * float_7;
		float num2 = (float)class64_0.Image.Width * dpi / class64_0.HorizontalResolution * float_6;
		switch (rectangleAlignment_0)
		{
		case RectangleAlignment.Top:
			x = rectangleF_0.Left + (rectangleF_0.Width - num2) / 2f;
			break;
		case RectangleAlignment.TopRight:
			x = rectangleF_0.Right - num2;
			break;
		case RectangleAlignment.Left:
			y = rectangleF_0.Top + (rectangleF_0.Height - num) / 2f;
			break;
		case RectangleAlignment.Center:
			x = rectangleF_0.Left + (rectangleF_0.Width - num2) / 2f;
			y = rectangleF_0.Top + (rectangleF_0.Height - num) / 2f;
			break;
		case RectangleAlignment.Right:
			x = rectangleF_0.Right - num2;
			y = rectangleF_0.Top + (rectangleF_0.Height - num) / 2f;
			break;
		case RectangleAlignment.BottomLeft:
			y = rectangleF_0.Bottom - num;
			break;
		case RectangleAlignment.Bottom:
			x = rectangleF_0.Left + (rectangleF_0.Width - num2) / 2f;
			y = rectangleF_0.Bottom - num;
			break;
		case RectangleAlignment.BottomRight:
			x = rectangleF_0.Right - num2;
			y = rectangleF_0.Bottom - num;
			break;
		}
		return new RectangleF(x, y, num2, num);
	}

	internal static ColorBlend smethod_3(SortedList<float, Color> gradientStops)
	{
		if (gradientStops == null)
		{
			return null;
		}
		int count = gradientStops.Count;
		int num = count;
		int num2 = 0;
		if (gradientStops.Keys[0] > 0f)
		{
			num2 = 1;
			num++;
		}
		if (gradientStops.Keys[count - 1] < 1f)
		{
			num++;
		}
		ColorBlend colorBlend = new ColorBlend(num);
		if (num2 > 0)
		{
			colorBlend.Positions[0] = 0f;
			ref Color reference = ref colorBlend.Colors[0];
			reference = gradientStops.Values[0];
		}
		for (int i = 0; i < count; i++)
		{
			colorBlend.Positions[num2 + i] = gradientStops.Keys[i];
			ref Color reference2 = ref colorBlend.Colors[num2 + i];
			reference2 = gradientStops.Values[i];
		}
		if (num2 + count < num)
		{
			colorBlend.Positions[num2 + count] = 1f;
			ref Color reference3 = ref colorBlend.Colors[num2 + count];
			reference3 = gradientStops.Values[count - 1];
		}
		return colorBlend;
	}

	public Class5990 method_5()
	{
		return method_6(96f);
	}

	public Class5990 method_6(float dpi)
	{
		float width = Rectangle.Width;
		float height = Rectangle.Height;
		if (Rectangle.Width == 0f)
		{
			width = 1f;
		}
		if (Rectangle.Height == 0f)
		{
			height = 1f;
		}
		Rectangle = new RectangleF(Rectangle.Location, new SizeF(width, height));
		switch (FillType)
		{
		default:
			return new Class5997(Class5998.smethod_0(Color.Transparent));
		case FillType.Solid:
			return method_7();
		case FillType.Gradient:
			return method_8(dpi);
		case FillType.Pattern:
			try
			{
				Class5995 class3;
				using (Bitmap bitmap = (Bitmap)method_16())
				{
					using MemoryStream memoryStream = new MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Bmp);
					class3 = new Class5995(memoryStream.ToArray());
				}
				class3.Transform = new Class6002();
				if ((double)Math.Abs(FillRotation) > 0.1)
				{
					class3.Transform.method_7(CenterPoint.X, CenterPoint.Y, MatrixOrder.Prepend);
					class3.Transform.method_11(FillRotation, MatrixOrder.Prepend);
					class3.Transform.method_7(0f - CenterPoint.X, 0f - CenterPoint.Y, MatrixOrder.Prepend);
				}
				if (bool_2 || bool_3)
				{
					class3.Transform.method_9(Class1170.smethod_5((!bool_2) ? 1 : (-1), (!bool_3) ? 1 : (-1), pointF_0.X, CenterPoint.Y), MatrixOrder.Prepend);
				}
				class3.Transform.method_6(dpi / 72f, dpi / 72f);
				return class3;
			}
			catch (Exception ex3)
			{
				Class1165.smethod_28(ex3);
			}
			return method_7();
		case FillType.Picture:
			if (pictureFillMode_0 == PictureFillMode.Stretch)
			{
				try
				{
					RectangleF rectangleF = ((float_5 == 0f) ? rectangleF_0 : smethod_2(graphicsPath_0, rectangleF_0, 0f - float_5, pointF_0.X, pointF_0.Y));
					byte[] imageBytes;
					if (method_18() is Metafile img)
					{
						imageBytes = Class1159.smethod_4(img, new SizeF(SourceRect.Width, SourceRect.Height), class6145_0, isReturnIncreasedImage: true);
						rectangleF_1.Width *= 4f;
						rectangleF_1.Height *= 4f;
						rectangleF_1.X = 0f;
						rectangleF_1.Y = 0f;
					}
					else
					{
						imageBytes = method_20();
					}
					Class5995 @class = new Class5995(imageBytes, WrapMode.Clamp);
					if ((double)Math.Abs(FillRotation) > 0.1)
					{
						float x = CenterPoint.X;
						float y = CenterPoint.Y;
						@class.Transform.method_7(x, y, MatrixOrder.Prepend);
						@class.Transform.method_11(FillRotation, MatrixOrder.Prepend);
						@class.Transform.method_7(0f - x, 0f - y, MatrixOrder.Prepend);
					}
					if (@class.Transform == null)
					{
						@class.Transform = new Class6002();
					}
					if (bool_2 || bool_3)
					{
						@class.Transform.method_9(Class1170.smethod_5((!bool_2) ? 1 : (-1), (!bool_3) ? 1 : (-1), pointF_0.X, CenterPoint.Y), MatrixOrder.Prepend);
					}
					@class.Transform.method_7(rectangleF.X, rectangleF.Y, MatrixOrder.Prepend);
					@class.Transform.method_5(rectangleF.Width / SourceRect.Width, rectangleF.Height / SourceRect.Height, MatrixOrder.Prepend);
					@class.Transform.method_7(0f - SourceRect.X, 0f - SourceRect.Y, MatrixOrder.Prepend);
					return @class;
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
				return method_7();
			}
			try
			{
				RectangleF rectangleF2 = ((float_5 == 0f) ? rectangleF_0 : smethod_2(graphicsPath_0, rectangleF_0, 0f - float_5, pointF_0.X, pointF_0.Y));
				Image image = method_18();
				Class5995 class2 = new Class5995(method_20());
				float num = rectangleF2.X;
				float num2 = rectangleF2.Y;
				float num3 = image.HorizontalResolution;
				float num4 = image.VerticalResolution;
				if (image is Metafile)
				{
					num4 = 96f;
					num3 = 96f;
				}
				float num5 = (float)image.Width * dpi / num3 * float_6;
				float num6 = (float)image.Height * dpi / num4 * float_7;
				switch (TextureAlignment)
				{
				case RectangleAlignment.Top:
					num = rectangleF2.Left + (rectangleF2.Width - num5) / 2f;
					break;
				case RectangleAlignment.TopRight:
					num = rectangleF2.Right - num5;
					break;
				case RectangleAlignment.Left:
					num2 = rectangleF2.Top + (rectangleF2.Height - num6) / 2f;
					break;
				case RectangleAlignment.Center:
					num = rectangleF2.Left + (rectangleF2.Width - num5) / 2f;
					num2 = rectangleF2.Top + (rectangleF2.Height - num6) / 2f;
					break;
				case RectangleAlignment.Right:
					num = rectangleF2.Right - num5;
					num2 = rectangleF2.Top + (rectangleF2.Height - num6) / 2f;
					break;
				case RectangleAlignment.BottomLeft:
					num2 = rectangleF2.Bottom - num6;
					break;
				case RectangleAlignment.Bottom:
					num = rectangleF2.Left + (rectangleF2.Width - num5) / 2f;
					num2 = rectangleF2.Bottom - num6;
					break;
				case RectangleAlignment.BottomRight:
					num = rectangleF2.Right - num5;
					num2 = rectangleF2.Bottom - num6;
					break;
				}
				class2.WrapMode = TextureWrap;
				if ((double)Math.Abs(FillRotation) > 0.1)
				{
					class2.Transform.method_7(CenterPoint.X, CenterPoint.Y, MatrixOrder.Prepend);
					class2.Transform.method_11(FillRotation, MatrixOrder.Prepend);
					class2.Transform.method_7(0f - CenterPoint.X, 0f - CenterPoint.Y, MatrixOrder.Prepend);
				}
				if (bool_2 || bool_3)
				{
					class2.Transform.method_9(Class1170.smethod_5((!bool_2) ? 1 : (-1), (!bool_3) ? 1 : (-1), pointF_0.X, CenterPoint.Y), MatrixOrder.Prepend);
				}
				class2.Transform.method_7(num + TextureScaleOffsetX, num2 + TextureScaleOffsetY, MatrixOrder.Prepend);
				class2.Transform.method_6(dpi / num3 * float_6, dpi / num4 * float_7);
				return class2;
			}
			catch (Exception ex2)
			{
				Class1165.smethod_28(ex2);
			}
			return method_7();
		}
	}

	public Class5990 method_7()
	{
		return new Class5997(Class5998.smethod_0(ForeColor));
	}

	public Class5990 method_8(float dpi)
	{
		float width = Rectangle.Width;
		float height = Rectangle.Height;
		if (Rectangle.Width == 0f)
		{
			width = 1f;
		}
		if (Rectangle.Height == 0f)
		{
			height = 1f;
		}
		RectangleF rectangleF = new RectangleF(Rectangle.Location, new SizeF(width, height));
		float num = method_21();
		ColorBlend colorBlend = smethod_3(method_15(emulateWhenNone: true));
		if (GradientStyle == Enum6.const_2)
		{
			RectangleF rectangle = rectangleF_0;
			if ((double)Math.Abs(float_5) > 0.1 || bool_2 || bool_3)
			{
				double num2 = (double)num / 180.0 * Math.PI;
				double num3 = Math.Cos(num2);
				double num4 = Math.Sin(num2);
				if (bool_2)
				{
					num3 = 0.0 - num3;
				}
				if (bool_3)
				{
					num4 = 0.0 - num4;
				}
				num = (float)(Math.Atan2(num4, num3) * 180.0 / Math.PI);
				if (graphicsPath_0 != null)
				{
					GraphicsPath graphicsPath = (GraphicsPath)graphicsPath_0.Clone();
					graphicsPath.Flatten();
					rectangle = smethod_2(graphicsPath, rectangleF_0, 0f - float_5, CenterPoint.X, CenterPoint.Y);
					rectangle = smethod_2(null, rectangle, 0f - num, CenterPoint.X, CenterPoint.Y);
					graphicsPath.Dispose();
				}
				else
				{
					rectangle = smethod_2(null, rectangleF_0, 0f - float_5, CenterPoint.X, CenterPoint.Y);
					rectangle = smethod_2(null, rectangle, 0f - num, CenterPoint.X, CenterPoint.Y);
				}
				rectangle = smethod_2(null, new RectangleF(rectangle.X, CenterPoint.Y, rectangle.Width, 0f), num + float_5, CenterPoint.X, CenterPoint.Y);
				if (rectangle.Width < 1f)
				{
					rectangle.Width = 1f;
				}
				if (rectangle.Height < 1f)
				{
					rectangle.Height = 1f;
				}
				num += float_5;
			}
			float num5 = dpi / 72f;
			if (num5 > 1f)
			{
				rectangle.Inflate(num5, num5);
			}
			Class5993 @class = new Class5993(smethod_0(rectangle), Class5998.smethod_0(colorBlend.Colors[0]), Class5998.smethod_0(colorBlend.Colors[colorBlend.Colors.Length - 1]));
			@class.Angle = num;
			if (colorBlend != null)
			{
				Class6000[] array = new Class6000[colorBlend.Colors.Length];
				for (int i = 0; i < colorBlend.Colors.Length; i++)
				{
					array[i] = new Class6000(Class5998.smethod_0(colorBlend.Colors[i]), colorBlend.Positions[i]);
				}
				@class.InterpolationColors = array;
			}
			return @class;
		}
		if ((double)Math.Abs(FillRotation) > 0.1)
		{
			rectangleF = smethod_0(smethod_2(graphicsPath_0, rectangleF, num - FillRotation, CenterPoint.X, CenterPoint.Y));
		}
		PointF[] points = new PointF[4]
		{
			new PointF(rectangleF.Left, rectangleF.Top),
			new PointF(rectangleF.Right, rectangleF.Top),
			new PointF(rectangleF.Right, rectangleF.Bottom),
			new PointF(rectangleF.Left, rectangleF.Bottom)
		};
		float num6 = FillRotation;
		GraphicsPath graphicsPath2 = GradientGraphicsPath;
		RectangleF rect = Tile.method_1(rectangleF);
		float num7 = FillTo.X + FillTo.Width / 2f;
		float num8 = FillTo.Y + FillTo.Height / 2f;
		float val = Math.Max(num7 - Tile.Left, Tile.Right - num7) * 2f;
		float val2 = Math.Max(num8 - Tile.Top, Tile.Bottom - num8) * 2f;
		float num9 = Math.Max(val, val2);
		num7 = rectangleF.X + num7 * rectangleF.Width;
		num8 = rectangleF.Y + num8 * rectangleF.Height;
		switch (GradientShape)
		{
		case GradientShape.Rectangle:
			graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddRectangle(rect);
			break;
		case GradientShape.Radial:
		{
			graphicsPath2 = new GraphicsPath();
			float num10 = (float)Math.Sqrt(2.0) * num9;
			graphicsPath2.AddEllipse(num7 - rect.Width * num10 / 2f, num8 - rect.Height * num10 / 2f, rect.Width * num10, rect.Height * num10);
			if (colorBlend != null)
			{
				float num11 = 1f / num9;
				float[] positions = colorBlend.Positions;
				for (int j = 1; j < positions.Length; j++)
				{
					positions[j] = 1f - (1f - positions[j]) * num11;
				}
				colorBlend.Positions = positions;
			}
			break;
		}
		case GradientShape.Path:
			num6 = 0f;
			break;
		}
		PointF focusScales = new PointF(FillTo.Width, FillTo.Height);
		Class5994 class2;
		if (graphicsPath2 != null && graphicsPath2.PointCount > 0 && GradientStyle == Enum6.const_7)
		{
			Class6217 path = Class6217.smethod_0(graphicsPath2.PathPoints, isClosed: true);
			class2 = new Class5994(path, default(PointF));
		}
		else
		{
			Class6217 path2 = Class6217.smethod_0(points, isClosed: true);
			class2 = new Class5994(path2, default(PointF));
		}
		switch (GradientStyle)
		{
		case Enum6.const_3:
			class2.CenterPoint = new PointF(rectangleF.Left, rectangleF.Top);
			break;
		case Enum6.const_4:
			class2.CenterPoint = new PointF(rectangleF.Right, rectangleF.Top);
			break;
		case Enum6.const_5:
			class2.CenterPoint = new PointF(rectangleF.Left, rectangleF.Bottom);
			break;
		case Enum6.const_6:
			class2.CenterPoint = new PointF(rectangleF.Right, rectangleF.Bottom);
			break;
		default:
			class2.CenterPoint = new PointF(num7, num8);
			class2.FocusScales = focusScales;
			break;
		}
		if (colorBlend != null)
		{
			Class6000[] array2 = new Class6000[colorBlend.Colors.Length];
			for (int k = 0; k < colorBlend.Colors.Length; k++)
			{
				array2[k] = new Class6000(Class5998.smethod_0(colorBlend.Colors[k]), colorBlend.Positions[k]);
			}
			class2.InterpolationColors = array2;
		}
		if ((double)Math.Abs(num6) > 0.1)
		{
			float x = CenterPoint.X;
			float y = CenterPoint.Y;
			class2.Transform.method_7(x, y, MatrixOrder.Prepend);
			class2.Transform.method_11(num6, MatrixOrder.Prepend);
			class2.Transform.method_7(0f - x, 0f - y, MatrixOrder.Prepend);
		}
		if (bool_2 || bool_3)
		{
			class2.Transform.method_9(Class1170.smethod_5((!bool_2) ? 1 : (-1), (!bool_3) ? 1 : (-1), pointF_0.X, CenterPoint.Y), MatrixOrder.Prepend);
		}
		return class2;
	}

	public Brush method_9()
	{
		return method_13(72f);
	}

	public Brush method_10()
	{
		return new SolidBrush(ForeColor);
	}

	public Brush method_11()
	{
		if (rectangleF_0.Width == 0f)
		{
			rectangleF_0.Width = 1f;
		}
		if (rectangleF_0.Height == 0f)
		{
			rectangleF_0.Height = 1f;
		}
		Color color = ForeColor;
		Color color2 = BackColor;
		float num = method_21();
		float num2 = (float)GradientFillFocus / 100f;
		Enum4 gradientColorType = GradientColorType;
		if (gradientColorType == Enum4.const_2)
		{
			color = ForeColor;
			int gradientDegree = GradientDegree;
			int red;
			int green;
			int blue;
			if (gradientDegree < 10)
			{
				red = color.R * gradientDegree / 9;
				green = color.G * gradientDegree / 9;
				blue = color.B * gradientDegree / 9;
			}
			else
			{
				red = (255 - color.R) * (gradientDegree - 9) / 10 + color.R;
				green = (255 - color.G) * (gradientDegree - 9) / 10 + color.G;
				blue = (255 - color.B) * (gradientDegree - 9) / 10 + color.B;
			}
			color2 = Color.FromArgb(BackColor.A, red, green, blue);
		}
		if (num2 < 0f)
		{
			Color color3 = color;
			color = color2;
			color2 = color3;
		}
		ColorBlend colorBlend = smethod_3(method_15(emulateWhenNone: true));
		if (GradientStyle == Enum6.const_2)
		{
			RectangleF rectangle = rectangleF_0;
			if ((double)Math.Abs(float_5) > 0.1 || bool_2 || bool_3)
			{
				double num3 = (double)num / 180.0 * Math.PI;
				double num4 = Math.Cos(num3);
				double num5 = Math.Sin(num3);
				if (bool_2)
				{
					num4 = 0.0 - num4;
				}
				if (bool_3)
				{
					num5 = 0.0 - num5;
				}
				num = (float)(Math.Atan2(num5, num4) * 180.0 / Math.PI);
				if (graphicsPath_0 != null)
				{
					GraphicsPath graphicsPath = (GraphicsPath)graphicsPath_0.Clone();
					graphicsPath.Flatten();
					rectangle = smethod_2(graphicsPath, rectangleF_0, 0f - float_5, CenterPoint.X, CenterPoint.Y);
					rectangle = smethod_2(null, rectangle, 0f - num, CenterPoint.X, CenterPoint.Y);
					graphicsPath.Dispose();
				}
				else
				{
					rectangle = smethod_2(null, rectangleF_0, 0f - float_5, CenterPoint.X, CenterPoint.Y);
					rectangle = smethod_2(null, rectangle, 0f - num, CenterPoint.X, CenterPoint.Y);
				}
				rectangle = smethod_2(null, new RectangleF(rectangle.X, CenterPoint.Y, rectangle.Width, 0f), num + float_5, CenterPoint.X, CenterPoint.Y);
				if (rectangle.Width < 1f)
				{
					rectangle.Width = 1f;
				}
				if (rectangle.Height < 1f)
				{
					rectangle.Height = 1f;
				}
				num += float_5;
			}
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(smethod_0(rectangle), color, color2, num);
			linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
			if (colorBlend != null)
			{
				linearGradientBrush.InterpolationColors = colorBlend;
			}
			else
			{
				linearGradientBrush.SetSigmaBellShape(Math.Abs(num2), 1f);
			}
			return linearGradientBrush;
		}
		RectangleF rect = ((float_5 == 0f) ? rectangleF_0 : smethod_2(graphicsPath_0, rectangleF_0, 0f - float_5, pointF_0.X, pointF_0.Y));
		PointF[] points = new PointF[4]
		{
			new PointF(rect.Left, rect.Top),
			new PointF(rect.Right, rect.Top),
			new PointF(rect.Right, rect.Bottom),
			new PointF(rect.Left, rect.Bottom)
		};
		float num6 = float_5;
		GraphicsPath graphicsPath2 = graphicsPath_0;
		RectangleF rect2 = class1148_0.method_1(rect);
		float num7 = class1148_1.X + class1148_1.Width / 2f;
		float num8 = class1148_1.Y + class1148_1.Height / 2f;
		float val = Math.Max(num7 - class1148_0.Left, class1148_0.Right - num7) * 2f;
		float val2 = Math.Max(num8 - class1148_0.Top, class1148_0.Bottom - num8) * 2f;
		float num9 = Math.Max(val, val2);
		num7 = rect.X + num7 * rect.Width;
		num8 = rect.Y + num8 * rect.Height;
		switch (GradientShape)
		{
		case GradientShape.Rectangle:
			graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddRectangle(rect2);
			break;
		case GradientShape.Radial:
		{
			graphicsPath2 = new GraphicsPath();
			float num10 = (float)Math.Sqrt(2.0) * num9;
			graphicsPath2.AddEllipse(num7 - rect2.Width * num10 / 2f, num8 - rect2.Height * num10 / 2f, rect2.Width * num10, rect2.Height * num10);
			if (colorBlend != null)
			{
				float num11 = 1f / num9;
				float[] positions = colorBlend.Positions;
				for (int i = 1; i < positions.Length; i++)
				{
					positions[i] = 1f - (1f - positions[i]) * num11;
				}
				colorBlend.Positions = positions;
			}
			break;
		}
		case GradientShape.Path:
			num6 = 0f;
			break;
		}
		PointF focusScales = new PointF(class1148_1.Width, class1148_1.Height);
		PathGradientBrush pathGradientBrush = ((graphicsPath2 == null || graphicsPath2.PointCount <= 0 || GradientStyle != Enum6.const_7) ? new PathGradientBrush(points) : new PathGradientBrush(graphicsPath2));
		pathGradientBrush.SurroundColors = new Color[1] { color2 };
		pathGradientBrush.CenterColor = color;
		switch (GradientStyle)
		{
		default:
			pathGradientBrush.CenterPoint = new PointF(num7, num8);
			pathGradientBrush.FocusScales = focusScales;
			break;
		case Enum6.const_3:
			pathGradientBrush.CenterPoint = new PointF(rect.Left, rect.Top);
			break;
		case Enum6.const_4:
			pathGradientBrush.CenterPoint = new PointF(rect.Right, rect.Top);
			break;
		case Enum6.const_5:
			pathGradientBrush.CenterPoint = new PointF(rect.Left, rect.Bottom);
			break;
		case Enum6.const_6:
			pathGradientBrush.CenterPoint = new PointF(rect.Right, rect.Bottom);
			break;
		}
		if (colorBlend != null)
		{
			pathGradientBrush.FocusScales = new PointF(class1148_1.Width / 10f, class1148_1.Height / 10f);
			pathGradientBrush.InterpolationColors = colorBlend;
		}
		else
		{
			pathGradientBrush.SetSigmaBellShape(Math.Abs(num2), 1f);
		}
		if ((double)Math.Abs(num6) > 0.1)
		{
			float x = pointF_0.X;
			float y = pointF_0.Y;
			pathGradientBrush.TranslateTransform(x, y, MatrixOrder.Prepend);
			pathGradientBrush.RotateTransform(num6, MatrixOrder.Prepend);
			pathGradientBrush.TranslateTransform(0f - x, 0f - y, MatrixOrder.Prepend);
		}
		if (bool_2 || bool_3)
		{
			pathGradientBrush.MultiplyTransform(Class1170.smethod_4((!bool_2) ? 1 : (-1), (!bool_3) ? 1 : (-1), pointF_0.X, CenterPoint.Y), MatrixOrder.Prepend);
		}
		if (ShadeToShape != null)
		{
			method_12(pathGradientBrush);
		}
		return pathGradientBrush;
	}

	private void method_12(PathGradientBrush brush)
	{
		float x = ShadeToShape.X + ShadeToShape.Width / 2f;
		float y = ShadeToShape.Y + ShadeToShape.Height / 2f;
		PointF centerPoint = new PointF(x, y);
		float num = Math.Max(ShadeToShape.X - rectangleF_0.X, rectangleF_0.Width - ShadeToShape.Width);
		float num2 = Math.Max(ShadeToShape.Y - rectangleF_0.Y, rectangleF_0.Height - ShadeToShape.Height);
		float y2 = num / rectangleF_0.Width;
		float x2 = num2 / rectangleF_0.Height;
		brush.FocusScales = new PointF(x2, y2);
		brush.CenterPoint = centerPoint;
	}

	public Brush method_13(float dpi)
	{
		if (rectangleF_0.Width == 0f)
		{
			rectangleF_0.Width = 1f;
		}
		if (rectangleF_0.Height == 0f)
		{
			rectangleF_0.Height = 1f;
		}
		switch (FillType)
		{
		default:
			return (Brush)Brushes.Transparent.Clone();
		case FillType.Solid:
			return method_10();
		case FillType.Gradient:
			return method_11();
		case FillType.Pattern:
			try
			{
				Bitmap bitmap2 = (Bitmap)method_16();
				TextureBrush textureBrush3 = new TextureBrush(bitmap2);
				if ((double)Math.Abs(float_5) > 0.1)
				{
					textureBrush3.TranslateTransform(pointF_0.X, pointF_0.Y, MatrixOrder.Prepend);
					textureBrush3.RotateTransform(float_5, MatrixOrder.Prepend);
					textureBrush3.TranslateTransform(0f - pointF_0.X, 0f - pointF_0.Y, MatrixOrder.Prepend);
				}
				if (bool_2 || bool_3)
				{
					textureBrush3.MultiplyTransform(Class1170.smethod_4((!bool_2) ? 1 : (-1), (!bool_3) ? 1 : (-1), pointF_0.X, CenterPoint.Y), MatrixOrder.Prepend);
				}
				textureBrush3.ScaleTransform(dpi / 72f, dpi / 72f);
				bitmap2.Dispose();
				return textureBrush3;
			}
			catch (Exception ex3)
			{
				Class1165.smethod_28(ex3);
			}
			return method_10();
		case FillType.Picture:
			if (pictureFillMode_0 == PictureFillMode.Stretch)
			{
				try
				{
					RectangleF rectangleF = ((float_5 == 0f) ? rectangleF_0 : smethod_2(graphicsPath_0, rectangleF_0, 0f - float_5, pointF_0.X, pointF_0.Y));
					Image image = method_18();
					TextureBrush textureBrush;
					if (image is Metafile)
					{
						Bitmap bitmap = Class1159.smethod_2(image, new SizeF(rectangleF.Width, rectangleF.Height), class6145_0, null, isReturnIncreasedImage: true);
						rectangleF_1 = new RectangleF(0f, 0f, bitmap.Width, bitmap.Height);
						textureBrush = new TextureBrush(bitmap, WrapMode.Clamp, new Rectangle(0, 0, (int)rectangleF_1.Width, (int)rectangleF_1.Height));
					}
					else
					{
						textureBrush = new TextureBrush(image, WrapMode.Clamp, new Rectangle(0, 0, class64_0.Width, class64_0.Height));
					}
					if ((double)Math.Abs(float_5) > 0.1)
					{
						float x = pointF_0.X;
						float y = pointF_0.Y;
						textureBrush.TranslateTransform(x, y, MatrixOrder.Prepend);
						textureBrush.RotateTransform(float_5, MatrixOrder.Prepend);
						textureBrush.TranslateTransform(0f - x, 0f - y, MatrixOrder.Prepend);
					}
					if (bool_2 || bool_3)
					{
						textureBrush.MultiplyTransform(Class1170.smethod_4((!bool_2) ? 1 : (-1), (!bool_3) ? 1 : (-1), pointF_0.X, CenterPoint.Y), MatrixOrder.Prepend);
					}
					textureBrush.TranslateTransform(rectangleF.X, rectangleF.Y, MatrixOrder.Prepend);
					textureBrush.ScaleTransform(rectangleF.Width / rectangleF_1.Width, rectangleF.Height / rectangleF_1.Height, MatrixOrder.Prepend);
					textureBrush.TranslateTransform(0f - rectangleF_1.X, 0f - rectangleF_1.Y, MatrixOrder.Prepend);
					return textureBrush;
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
				}
				return method_10();
			}
			try
			{
				Image image2 = method_18();
				TextureBrush textureBrush2 = new TextureBrush(image2);
				float num = rectangleF_0.X;
				float num2 = rectangleF_0.Y;
				float num3 = image2.HorizontalResolution;
				float num4 = image2.VerticalResolution;
				if (image2 is Metafile)
				{
					num4 = 96f;
					num3 = 96f;
				}
				float num5 = (float)textureBrush2.Image.Width * dpi / num3 * float_6;
				float num6 = (float)textureBrush2.Image.Height * dpi / num4 * float_7;
				RectangleF rectangleF2 = ((float_5 == 0f) ? rectangleF_0 : smethod_2(graphicsPath_0, rectangleF_0, 0f - float_5, pointF_0.X, pointF_0.Y));
				switch (rectangleAlignment_0)
				{
				case RectangleAlignment.Top:
					num = rectangleF2.Left + (rectangleF2.Width - num5) / 2f;
					break;
				case RectangleAlignment.TopRight:
					num = rectangleF2.Right - num5;
					break;
				case RectangleAlignment.Left:
					num2 = rectangleF2.Top + (rectangleF2.Height - num6) / 2f;
					break;
				case RectangleAlignment.Center:
					num = rectangleF2.Left + (rectangleF2.Width - num5) / 2f;
					num2 = rectangleF2.Top + (rectangleF2.Height - num6) / 2f;
					break;
				case RectangleAlignment.Right:
					num = rectangleF2.Right - num5;
					num2 = rectangleF2.Top + (rectangleF2.Height - num6) / 2f;
					break;
				case RectangleAlignment.BottomLeft:
					num2 = rectangleF2.Bottom - num6;
					break;
				case RectangleAlignment.Bottom:
					num = rectangleF2.Left + (rectangleF2.Width - num5) / 2f;
					num2 = rectangleF2.Bottom - num6;
					break;
				case RectangleAlignment.BottomRight:
					num = rectangleF2.Right - num5;
					num2 = rectangleF2.Bottom - num6;
					break;
				}
				textureBrush2.WrapMode = wrapMode_0;
				if ((double)Math.Abs(float_5) > 0.1)
				{
					textureBrush2.TranslateTransform(pointF_0.X, pointF_0.Y, MatrixOrder.Prepend);
					textureBrush2.RotateTransform(float_5, MatrixOrder.Prepend);
					textureBrush2.TranslateTransform(0f - pointF_0.X, 0f - pointF_0.Y, MatrixOrder.Prepend);
				}
				if (bool_2 || bool_3)
				{
					textureBrush2.MultiplyTransform(Class1170.smethod_4((!bool_2) ? 1 : (-1), (!bool_3) ? 1 : (-1), pointF_0.X, CenterPoint.Y), MatrixOrder.Prepend);
				}
				textureBrush2.TranslateTransform(num + float_8, num2 + float_9, MatrixOrder.Prepend);
				textureBrush2.ScaleTransform(dpi / num3 * float_6, dpi / num4 * float_7);
				return textureBrush2;
			}
			catch (Exception ex2)
			{
				Class1165.smethod_28(ex2);
			}
			return method_10();
		}
	}

	internal static SortedList<float, Color> smethod_4(SortedList<float, Color> gradientStops)
	{
		if (gradientStops.Count < 2)
		{
			return null;
		}
		SortedList<float, Color> sortedList = new SortedList<float, Color>();
		float num = -1f;
		Color value = Color.Empty;
		foreach (float key in gradientStops.Keys)
		{
			float num2 = key;
			if (!sortedList.ContainsKey(num2))
			{
				sortedList.Add(num2, gradientStops[num2]);
			}
			if (num2 >= num)
			{
				num = num2;
				value = gradientStops[num2];
			}
		}
		if (sortedList.Keys[sortedList.Count - 1] < 1f)
		{
			sortedList.Add(1f, value);
		}
		if (gradientStops.Count == 2 && sortedList.Count == 2 && sortedList.Keys[0] == 0f && sortedList.Keys[1] == 1f)
		{
			FloatColor floatColor = new FloatColor(sortedList.Values[0]);
			FloatColor floatColor2 = new FloatColor(sortedList.Values[1]);
			if (!floatColor2.Equals(floatColor))
			{
				float num3 = smethod_5(floatColor.float_0);
				float num4 = smethod_5(floatColor.float_1);
				float num5 = smethod_5(floatColor.float_2);
				float num6 = smethod_5(floatColor.float_3);
				float num7 = smethod_5(floatColor2.float_0);
				float num8 = smethod_5(floatColor2.float_1);
				float num9 = smethod_5(floatColor2.float_2);
				float num10 = smethod_5(floatColor2.float_3);
				sortedList.Capacity = 2 + float_3.Length * 2;
				for (int i = 0; i < float_3.Length; i++)
				{
					sortedList.Add(float_4[i], new FloatColor(smethod_6(num3 + (num7 - num3) * float_3[i]), smethod_6(num4 + (num8 - num4) * float_3[i]), smethod_6(num5 + (num9 - num5) * float_3[i]), smethod_6(num6 + (num10 - num6) * float_3[i])).Color);
					sortedList.Add(1f - float_4[i], new FloatColor(smethod_6(num3 + (num7 - num3) * (1f - float_3[i])), smethod_6(num4 + (num8 - num4) * (1f - float_3[i])), smethod_6(num5 + (num9 - num5) * (1f - float_3[i])), smethod_6(num6 + (num10 - num6) * (1f - float_3[i]))).Color);
				}
			}
		}
		return sortedList;
	}

	private static float smethod_5(float component)
	{
		return (float)Math.Pow(component, 2.200000047683716);
	}

	private static float smethod_6(float component)
	{
		return (float)Math.Pow(component, 0.4545454446934474);
	}

	public SortedList<float, Color> method_14()
	{
		return method_15(emulateWhenNone: false);
	}

	public SortedList<float, Color> method_15(bool emulateWhenNone)
	{
		SortedList<float, Color> sortedList = RawGradientStops;
		if (sortedList == null)
		{
			if (!emulateWhenNone)
			{
				return null;
			}
			Color foreColor = ForeColor;
			Color value = BackColor;
			if (GradientColorType == Enum4.const_2)
			{
				int gradientDegree = GradientDegree;
				int red;
				int green;
				int blue;
				if (gradientDegree < 10)
				{
					red = foreColor.R * gradientDegree / 9;
					green = foreColor.G * gradientDegree / 9;
					blue = foreColor.B * gradientDegree / 9;
				}
				else
				{
					red = (255 - foreColor.R) * (gradientDegree - 9) / 10 + foreColor.R;
					green = (255 - foreColor.G) * (gradientDegree - 9) / 10 + foreColor.G;
					blue = (255 - foreColor.B) * (gradientDegree - 9) / 10 + foreColor.B;
				}
				value = Color.FromArgb(BackColor.A, red, green, blue);
			}
			sortedList = new SortedList<float, Color>(2);
			sortedList[0f] = foreColor;
			sortedList[1f] = value;
		}
		SortedList<float, Color> sortedList2 = sortedList;
		float num = (float)GradientFillFocus / 100f;
		float num2 = num;
		if (GradientStyle != Enum6.const_2 && GradientStyle != Enum6.const_7)
		{
			num2 = 1f - num;
		}
		if (num2 != 1f)
		{
			int count = sortedList.Count;
			if (num2 % 1f == 0f)
			{
				sortedList2 = new SortedList<float, Color>(count);
				for (int i = 0; i < count; i++)
				{
					sortedList2[1f - sortedList.Keys[i]] = sortedList.Values[i];
				}
			}
			else
			{
				sortedList2 = new SortedList<float, Color>(count * 2);
				float num3 = num2 % 1f;
				if (num3 > 0f)
				{
					for (int j = 0; j < count; j++)
					{
						sortedList2[sortedList.Keys[j] * num3] = sortedList.Values[j];
						sortedList2[num3 + (1f - sortedList.Keys[j]) * (1f - num3)] = sortedList.Values[j];
					}
				}
				else
				{
					num3 = 1f + num3;
					for (int k = 0; k < count; k++)
					{
						sortedList2[(1f - sortedList.Keys[k]) * num3] = sortedList.Values[k];
						sortedList2[num3 + sortedList.Keys[k] * (1f - num3)] = sortedList.Values[k];
					}
				}
			}
		}
		return smethod_4(sortedList2);
	}

	public Image method_16()
	{
		if (FillType != FillType.Pattern)
		{
			throw new InvalidOperationException("GetPatternImage for " + FillType.ToString() + " filling called");
		}
		Bitmap bitmap;
		try
		{
			bitmap = (Bitmap)method_18();
			if (bitmap != null)
			{
				bitmap.Clone();
				Color backColor = BackColor;
				Color foreColor = ForeColor;
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if (bitmap.GetPixel(i, j).ToArgb() == Color.Black.ToArgb())
						{
							bitmap.SetPixel(i, j, backColor);
						}
						else
						{
							bitmap.SetPixel(i, j, foreColor);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			bitmap = null;
		}
		if (bitmap == null)
		{
			bitmap = PatternFormat.smethod_1(indexed: false, patternStyle_0, BackColor, ForeColor);
		}
		return bitmap;
	}

	public Class64 method_17()
	{
		return class64_0;
	}

	public Image method_18()
	{
		return method_17()?.Image;
	}

	public void method_19(Class64 image)
	{
		class64_0 = image;
		string_0 = image.Code;
	}

	public byte[] method_20()
	{
		return method_17()?.ImageData;
	}

	public float method_21()
	{
		float num = (float)GradientFillAngle + 90f;
		if (!bool_4)
		{
			return num;
		}
		double num2 = Math.Cos((double)(num / 180f) * Math.PI);
		double num3 = Math.Sin((double)(num / 180f) * Math.PI);
		num2 *= (double)rectangleF_0.Height;
		num3 *= (double)rectangleF_0.Width;
		num = (float)(Math.Atan2(num3, num2) * 180.0 / Math.PI);
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	public object Clone()
	{
		return MemberwiseClone();
	}
}
