using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns35;
using ns37;

namespace ns38;

internal class Class768 : IDisposable, ICloneable
{
	private struct Struct36
	{
		private float float_0;

		private float float_1;

		private PointF pointF_0;

		private PointF pointF_1;

		public float StartAngle => float_0;

		public float EndAngle => float_1;

		public PointF StartPoint => pointF_0;

		public PointF EndPoint => pointF_1;

		public Struct36(float startAngle, float endAngle, PointF startPoint, PointF endPoint)
		{
			float_0 = startAngle;
			float_1 = endAngle;
			pointF_0 = startPoint;
			pointF_1 = endPoint;
		}
	}

	private float float_0;

	internal bool bool_0;

	internal bool bool_1;

	protected RectangleF rectangleF_0;

	protected float float_1;

	protected float float_2;

	protected float float_3;

	private float float_4;

	private float float_5;

	private Color color_0 = Color.Empty;

	private Enum139 enum139_0;

	private Enum138 enum138_0;

	protected Brush brush_0;

	protected Brush brush_1;

	protected Brush brush_2;

	protected Brush brush_3;

	protected Brush brush_4;

	protected Pen pen_0;

	protected PointF pointF_0;

	protected PointF pointF_1;

	protected PointF pointF_2;

	protected PointF pointF_3;

	protected PointF pointF_4;

	protected PointF pointF_5;

	protected Class769 class769_0 = Class769.class769_0;

	protected Class769 class769_1 = Class769.class769_0;

	private string string_0;

	private bool bool_2;

	private static float float_6 = 20f;

	private Class748 class748_0;

	public float StartAngle => float_2;

	public float SweepAngle => float_3;

	public float OriginalSweepAngle
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float EndAngle => (float_2 + float_3) % 360f;

	internal float AcctualStartAngle => float_4;

	internal float AcctualSweepAngle => float_5;

	public string Text
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

	internal Color SurfaceColor => color_0;

	internal Enum139 ShadowStyle => enum139_0;

	internal Enum138 EdgeColorType => enum138_0;

	internal Pen Pen => pen_0;

	internal RectangleF BoundingRectangle
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

	internal float SliceHeight
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	internal Class748 ChartPoint => class748_0;

	protected Class768()
	{
	}

	public Class768(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, float startAngle, float sweepAngle, Color surfaceColor)
		: this(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, 0f, startAngle, sweepAngle, surfaceColor, Enum139.const_0, Enum138.const_0)
	{
	}

	public Class768(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, float sliceHeight, float startAngle, float sweepAngle, Color surfaceColor, Enum139 shadowStyle, Enum138 edgeColorType)
		: this()
	{
		float_4 = startAngle;
		float_5 = sweepAngle;
		color_0 = surfaceColor;
		enum139_0 = shadowStyle;
		enum138_0 = edgeColorType;
		Color color = Struct33.smethod_0(edgeColorType, surfaceColor);
		pen_0 = new Pen(color);
		pen_0.LineJoin = LineJoin.Round;
		method_24(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, sliceHeight);
	}

	public Class768(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, float sliceHeight, float startAngle, float sweepAngle, Color surfaceColor, Enum139 shadowStyle, Enum138 edgeColorType, float edgeLineWidth, Class748 chartPoint)
		: this(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, sliceHeight, startAngle, sweepAngle, surfaceColor, shadowStyle, edgeColorType, edgeLineWidth)
	{
		class748_0 = chartPoint;
		if (chartPoint != null)
		{
			RectangleF rect = new RectangleF(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rect);
			pen_0 = chartPoint.BorderInternal.method_9(graphicsPath);
		}
	}

	public Class768(RectangleF boundingRect, float sliceHeight, float startAngle, float sweepAngle, Color surfaceColor, Enum139 shadowStyle, Enum138 edgeColorType, float edgeLineWidth, Class748 chartPoint)
		: this(boundingRect.X, boundingRect.Y, boundingRect.Width, boundingRect.Height, sliceHeight, startAngle, sweepAngle, surfaceColor, shadowStyle, edgeColorType, edgeLineWidth, chartPoint)
	{
	}

	public Class768(RectangleF boundingRect, float sliceHeight, float startAngle, float sweepAngle, Color surfaceColor, Enum139 shadowStyle, Enum138 edgeColorType)
		: this(boundingRect.X, boundingRect.Y, boundingRect.Width, boundingRect.Height, sliceHeight, startAngle, sweepAngle, surfaceColor, shadowStyle, edgeColorType)
	{
	}

	public Class768(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, float sliceHeight, float startAngle, float sweepAngle, Color surfaceColor, Enum139 shadowStyle, Enum138 edgeColorType, float edgeLineWidth)
		: this(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, sliceHeight, startAngle, sweepAngle, surfaceColor, shadowStyle, edgeColorType)
	{
		pen_0.Width = edgeLineWidth;
	}

	public Class768(Rectangle boundingRect, float sliceHeight, float startAngle, float sweepAngle, Color surfaceColor, Enum139 shadowStyle, Enum138 edgeColorType, float edgeLineWidth)
		: this(boundingRect.X, boundingRect.Y, boundingRect.Width, boundingRect.Height, sliceHeight, startAngle, sweepAngle, surfaceColor, shadowStyle, edgeColorType, edgeLineWidth)
	{
	}

	~Class768()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_2)
		{
			if (disposing)
			{
				pen_0.Dispose();
				method_19();
				class769_0.Dispose();
				class769_1.Dispose();
			}
			bool_2 = true;
		}
	}

	public object Clone()
	{
		return new Class768(BoundingRectangle, SliceHeight, StartAngle, SweepAngle, color_0, enum139_0, enum138_0, pen_0.Width, class748_0);
	}

	public Class768 method_0(float angle)
	{
		return new Class768(BoundingRectangle, SliceHeight, float_4 + angle, float_5, color_0, enum139_0, enum138_0, pen_0.Width, class748_0);
	}

	public void method_1(Interface32 graphics)
	{
		method_11(graphics);
		method_3(graphics);
	}

	public bool Contains(PointF point)
	{
		if (method_14(point))
		{
			return true;
		}
		if (method_15(point))
		{
			return true;
		}
		if (class769_0.Contains(point))
		{
			return true;
		}
		if (class769_1.Contains(point))
		{
			return true;
		}
		return false;
	}

	public virtual PointF vmethod_0()
	{
		if (SweepAngle >= 180f)
		{
			return method_23(pointF_0.X, pointF_0.Y, rectangleF_0.Width / 3f, rectangleF_0.Height / 3f, method_22(StartAngle) + SweepAngle / 2f);
		}
		float num = (pointF_2.X + pointF_4.X) / 2f;
		float num2 = (pointF_2.Y + pointF_4.Y) / 2f;
		float transformedAngle = (float)(Math.Atan2(num2 - pointF_0.Y, num - pointF_0.X) * 180.0 / Math.PI);
		return method_23(pointF_0.X, pointF_0.Y, rectangleF_0.Width / 3f, rectangleF_0.Height / 3f, method_22(transformedAngle));
	}

	public virtual PointF vmethod_1(float param_r, out float dlAngle)
	{
		PointF empty = PointF.Empty;
		if (SweepAngle >= 180f)
		{
			dlAngle = method_22(StartAngle) + SweepAngle / 2f;
			empty = method_23(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		else
		{
			float num = (pointF_2.X + pointF_4.X) / 2f;
			float num2 = (pointF_2.Y + pointF_4.Y) / 2f;
			float transformedAngle = (float)(Math.Atan2(num2 - pointF_0.Y, num - pointF_0.X) * 180.0 / Math.PI);
			dlAngle = method_22(transformedAngle);
			empty = method_23(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		dlAngle %= 360f;
		if (dlAngle < 0f)
		{
			dlAngle += 360f;
		}
		return empty;
	}

	public virtual PointF vmethod_2(float param_r, int offAngel, out float dlAngle)
	{
		PointF empty = PointF.Empty;
		if (SweepAngle >= 180f)
		{
			dlAngle = method_22(StartAngle) + SweepAngle / 2f;
			dlAngle += offAngel;
			empty = method_23(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		else
		{
			float num = (pointF_2.X + pointF_4.X) / 2f;
			float num2 = (pointF_2.Y + pointF_4.Y) / 2f;
			float transformedAngle = (float)(Math.Atan2(num2 - pointF_0.Y, num - pointF_0.X) * 180.0 / Math.PI);
			dlAngle = method_22(transformedAngle);
			dlAngle += offAngel;
			empty = method_23(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		dlAngle %= 360f;
		if (dlAngle < 0f)
		{
			dlAngle += 360f;
		}
		return empty;
	}

	public float method_2()
	{
		float num;
		if (SweepAngle >= 180f)
		{
			num = method_22(StartAngle) + SweepAngle / 2f;
		}
		else
		{
			float num2 = (pointF_2.X + pointF_4.X) / 2f;
			float num3 = (pointF_2.Y + pointF_4.Y) / 2f;
			float transformedAngle = (float)(Math.Atan2(num3 - pointF_0.Y, num2 - pointF_0.X) * 180.0 / Math.PI);
			num = method_22(transformedAngle);
		}
		num %= 360f;
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	internal void method_3(Interface32 graphics)
	{
		method_10(graphics);
		if (StartAngle > 90f && StartAngle < 270f)
		{
			method_8(graphics);
			method_7(graphics);
		}
		else
		{
			method_7(graphics);
			method_8(graphics);
		}
		method_9(graphics);
	}

	internal Class768[] method_4(float splitAngle)
	{
		if (StartAngle != splitAngle && EndAngle != splitAngle)
		{
			method_21(splitAngle);
			float num = method_22(StartAngle);
			float sweepAngle = (splitAngle - num + 360f) % 360f;
			Class768 @class = new Class768(BoundingRectangle, SliceHeight, num, sweepAngle, color_0, enum139_0, enum138_0, pen_0.Width, class748_0);
			@class.OriginalSweepAngle = SweepAngle;
			@class.bool_0 = true;
			if (SweepAngle == 360f)
			{
				@class.method_26(startSideExists: false, endSideExists: false);
			}
			else
			{
				@class.method_26(startSideExists: true, endSideExists: false);
			}
			sweepAngle = method_22(EndAngle) - splitAngle;
			Class768 class2 = new Class768(BoundingRectangle, SliceHeight, splitAngle, sweepAngle, color_0, enum139_0, enum138_0, pen_0.Width, class748_0);
			class2.OriginalSweepAngle = SweepAngle;
			class2.bool_0 = true;
			if (SweepAngle == 360f)
			{
				class2.method_26(startSideExists: false, endSideExists: false);
			}
			else
			{
				class2.method_26(startSideExists: false, endSideExists: true);
			}
			return new Class768[2] { @class, class2 };
		}
		return new Class768[1] { (Class768)Clone() };
	}

	private Class768[] method_5()
	{
		if (StartAngle >= 90f && StartAngle < 180f)
		{
			if (EndAngle > 180f)
			{
				Class768[] array = method_4(180f);
				array[0].bool_1 = true;
				return array;
			}
			bool_1 = true;
		}
		else if (EndAngle > 90f && EndAngle <= 180f)
		{
			if (StartAngle < 90f)
			{
				Class768[] array2 = method_4(90f);
				array2[1].bool_1 = true;
				return array2;
			}
			bool_1 = true;
		}
		return null;
	}

	internal void method_6(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, float sliceHeight)
	{
		method_24(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect, sliceHeight);
	}

	internal void method_7(Interface32 graphics)
	{
		if (class769_0 != null)
		{
			if (StartAngle > 90f && StartAngle < 270f)
			{
				class769_0.method_0(graphics, pen_0, brush_2, class748_0);
			}
			else
			{
				class769_0.method_0(graphics, pen_0, brush_0, class748_0);
			}
		}
	}

	internal void method_8(Interface32 graphics)
	{
		if (class769_1 != null)
		{
			if (EndAngle > 90f && EndAngle < 270f)
			{
				class769_1.method_0(graphics, pen_0, brush_0, class748_0);
			}
			else
			{
				class769_1.method_0(graphics, pen_0, brush_3, class748_0);
			}
		}
	}

	internal void method_9(Interface32 graphics)
	{
		Struct36[] array = method_27();
		Struct36[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Struct36 @struct = array2[i];
			method_20(graphics, pen_0, brush_4, @struct.StartAngle, @struct.EndAngle, @struct.StartPoint, @struct.EndPoint);
		}
	}

	internal void method_10(Interface32 graphics)
	{
		Struct36[] array = method_28();
		Struct36[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Struct36 @struct = array2[i];
			method_20(graphics, pen_0, brush_0, @struct.StartAngle, @struct.EndAngle, @struct.StartPoint, @struct.EndPoint);
		}
	}

	internal void method_11(Interface32 graphics)
	{
		if (class748_0 != null)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
			class748_0.AreaInternal.method_6(graphicsPath);
		}
		if (class748_0 != null)
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			if (float_3 == 360f)
			{
				graphicsPath2.AddArc(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
			}
			else
			{
				graphicsPath2.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
			}
			class748_0.BorderInternal.method_8(graphicsPath2);
		}
	}

	internal void method_12(Interface32 graphics)
	{
		if (class748_0 != null)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
			class748_0.AreaInternal.method_6(graphicsPath);
		}
		if (class748_0 != null)
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			if (float_3 == 360f)
			{
				graphicsPath2.AddArc(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
			}
			else
			{
				graphicsPath2.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
			}
			class748_0.BorderInternal.method_8(graphicsPath2);
		}
	}

	internal RectangleF method_13()
	{
		RectangleF rect = new RectangleF(pointF_2.X, pointF_2.Y, 0f, 0f);
		if (float_2 == 0f || float_2 + float_3 >= 360f)
		{
			Struct34.smethod_1(ref rect, rectangleF_0.Right);
		}
		if ((float_2 <= 90f && float_2 + float_3 >= 90f) || float_2 + float_3 >= 450f)
		{
			Struct34.smethod_2(ref rect, rectangleF_0.Bottom + SliceHeight);
		}
		if ((float_2 <= 180f && float_2 + float_3 >= 180f) || float_2 + float_3 >= 540f)
		{
			Struct34.smethod_1(ref rect, rectangleF_0.Left);
		}
		if ((float_2 <= 270f && float_2 + float_3 >= 270f) || float_2 + float_3 >= 630f)
		{
			Struct34.smethod_2(ref rect, rectangleF_0.Top);
		}
		Struct34.smethod_0(ref rect, pointF_0);
		Struct34.smethod_0(ref rect, pointF_1);
		Struct34.smethod_0(ref rect, pointF_2);
		Struct34.smethod_0(ref rect, pointF_3);
		Struct34.smethod_0(ref rect, pointF_4);
		Struct34.smethod_0(ref rect, pointF_5);
		return rect;
	}

	internal bool method_14(PointF point)
	{
		return method_33(point, rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
	}

	internal bool method_15(PointF point)
	{
		Struct36[] array = method_27();
		Struct36[] array2 = array;
		int num = 0;
		while (true)
		{
			if (num < array2.Length)
			{
				Struct36 @struct = array2[num];
				if (method_32(point, @struct.StartAngle, @struct.EndAngle, @struct.StartPoint, @struct.EndPoint))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal bool method_16(PointF point)
	{
		if (float_1 > 0f)
		{
			return class769_0.Contains(point);
		}
		return false;
	}

	internal bool method_17(PointF point)
	{
		if (float_1 > 0f)
		{
			return class769_1.Contains(point);
		}
		return false;
	}

	internal bool method_18(PointF point)
	{
		if (float_1 > 0f)
		{
			return method_33(point, rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
		}
		return false;
	}

	protected virtual void vmethod_3(Color surfaceColor, Enum139 shadowStyle)
	{
		brush_0 = new SolidBrush(surfaceColor);
		brush_1 = new SolidBrush(Struct32.smethod_0(surfaceColor, Struct32.float_0));
		switch (shadowStyle)
		{
		case Enum139.const_0:
		{
			Color color = Color.FromArgb((int)surfaceColor.R / 2, (int)surfaceColor.G / 2, (int)surfaceColor.B / 2);
			brush_2 = (brush_3 = (brush_4 = new SolidBrush(color)));
			break;
		}
		case Enum139.const_1:
			brush_2 = (brush_3 = (brush_4 = new SolidBrush(Struct32.smethod_0(surfaceColor, 0f - Struct32.float_0))));
			break;
		case Enum139.const_2:
		{
			double num = float_2 - 180f - float_6;
			if (num < 0.0)
			{
				num += 360.0;
			}
			brush_2 = vmethod_4(surfaceColor, num);
			num = float_2 + float_3 - float_6;
			if (num < 0.0)
			{
				num += 360.0;
			}
			brush_3 = vmethod_4(surfaceColor, num);
			brush_4 = vmethod_5(surfaceColor);
			break;
		}
		}
	}

	protected void method_19()
	{
		brush_0.Dispose();
		brush_2.Dispose();
		brush_3.Dispose();
		brush_4.Dispose();
		brush_1.Dispose();
	}

	protected virtual Brush vmethod_4(Color color, double angle)
	{
		return new SolidBrush(Struct32.smethod_0(color, 0f - (float)((double)Struct32.float_0 * (1.0 - 0.8 * Math.Cos(angle * Math.PI / 180.0)))));
	}

	protected virtual Brush vmethod_5(Color color)
	{
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = new Color[3]
		{
			Struct32.smethod_0(color, (0f - Struct32.float_0) / 2f),
			color,
			Struct32.smethod_0(color, 0f - Struct32.float_0)
		};
		colorBlend.Positions = new float[3] { 0f, 0.1f, 1f };
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangleF_0, Color.Blue, Color.White, LinearGradientMode.Horizontal);
		linearGradientBrush.InterpolationColors = colorBlend;
		return linearGradientBrush;
	}

	protected void method_20(Interface32 graphics, Pen pen, Brush brush, float startAngle, float endAngle, PointF pointStart, PointF pointEnd)
	{
		float colorGene = 0.5f;
		if (class748_0 != null)
		{
			GraphicsPath graphicsPath = method_30(startAngle, endAngle, pointStart, pointEnd);
			if (bool_0)
			{
				GraphicsPath brushPath = method_29(startAngle, endAngle, pointStart, pointEnd);
				class748_0.AreaInternal.method_11(graphicsPath, colorGene, brushPath);
			}
			else
			{
				class748_0.AreaInternal.method_7(graphicsPath, colorGene);
			}
		}
		if (class748_0 == null)
		{
			return;
		}
		ArrayList arrayList = method_31(startAngle, endAngle, pointStart, pointEnd, OriginalSweepAngle);
		foreach (GraphicsPath item in arrayList)
		{
			class748_0.BorderInternal.method_8(item);
		}
	}

	protected float method_21(float angle)
	{
		double x = (double)rectangleF_0.Width * Math.Cos((double)angle * Math.PI / 180.0);
		double y = (double)rectangleF_0.Height * Math.Sin((double)angle * Math.PI / 180.0);
		float num = (float)(Math.Atan2(y, x) * 180.0 / Math.PI);
		if (num < 0f)
		{
			return num + 360f;
		}
		return num;
	}

	protected float method_22(float transformedAngle)
	{
		double x = (double)rectangleF_0.Height * Math.Cos((double)transformedAngle * Math.PI / 180.0);
		double y = (double)rectangleF_0.Width * Math.Sin((double)transformedAngle * Math.PI / 180.0);
		float num = (float)(Math.Atan2(y, x) * 180.0 / Math.PI);
		if (num < 0f)
		{
			return num + 360f;
		}
		return num;
	}

	protected PointF method_23(float xCenter, float yCenter, float semiMajor, float semiMinor, float angleDegrees)
	{
		double num = (double)angleDegrees * Math.PI / 180.0;
		return new PointF(xCenter + (float)((double)semiMajor * Math.Cos(num)), yCenter + (float)((double)semiMinor * Math.Sin(num)));
	}

	private void method_24(float xBoundingRect, float yBoundingRect, float widthBoundingRect, float heightBoundingRect, float sliceHeight)
	{
		rectangleF_0 = new RectangleF(xBoundingRect, yBoundingRect, widthBoundingRect, heightBoundingRect);
		float_1 = sliceHeight;
		float_2 = method_21(float_4);
		float_3 = float_5;
		if (float_3 % 180f != 0f)
		{
			float_3 = method_21(float_4 + float_5) - float_2;
		}
		if (float_3 < 0f)
		{
			float_3 += 360f;
		}
		vmethod_3(color_0, enum139_0);
		float num = xBoundingRect + widthBoundingRect / 2f;
		float num2 = yBoundingRect + heightBoundingRect / 2f;
		pointF_0 = new PointF(num, num2);
		pointF_1 = new PointF(num, num2 + sliceHeight);
		pointF_2 = method_23(num, num2, widthBoundingRect / 2f, heightBoundingRect / 2f, float_4);
		pointF_3 = new PointF(pointF_2.X, pointF_2.Y + sliceHeight);
		pointF_4 = method_23(num, num2, widthBoundingRect / 2f, heightBoundingRect / 2f, float_4 + float_5);
		pointF_5 = new PointF(pointF_4.X, pointF_4.Y + sliceHeight);
		method_25();
	}

	private void method_25()
	{
		method_26(startSideExists: true, endSideExists: true);
	}

	private void method_26(bool startSideExists, bool endSideExists)
	{
		if (startSideExists)
		{
			class769_0 = new Class769(pointF_0, pointF_2, pointF_3, pointF_1, float_3 != 180f);
		}
		else
		{
			class769_0 = Class769.class769_0;
		}
		if (endSideExists)
		{
			class769_1 = new Class769(pointF_0, pointF_4, pointF_5, pointF_1, float_3 != 180f);
		}
		else
		{
			class769_1 = Class769.class769_0;
		}
	}

	private Struct36[] method_27()
	{
		ArrayList arrayList = new ArrayList();
		if (float_3 != 0f && (!(float_2 >= 180f) || !(float_2 + float_3 <= 360f)))
		{
			if (StartAngle < 180f)
			{
				float startAngle = float_2;
				PointF startPoint = new PointF(pointF_2.X, pointF_2.Y);
				float endAngle = EndAngle;
				PointF endPoint = new PointF(pointF_4.X, pointF_4.Y);
				if (float_2 + float_3 > 180f)
				{
					endAngle = 180f;
					endPoint.X = rectangleF_0.X;
					endPoint.Y = pointF_0.Y;
				}
				arrayList.Add(new Struct36(startAngle, endAngle, startPoint, endPoint));
			}
			if (float_2 + float_3 > 360f)
			{
				float startAngle2 = 0f;
				PointF startPoint2 = new PointF(rectangleF_0.Right, pointF_0.Y);
				float num = EndAngle;
				PointF endPoint2 = new PointF(pointF_4.X, pointF_4.Y);
				if (num > 180f)
				{
					num = 180f;
					endPoint2.X = rectangleF_0.Left;
					endPoint2.Y = pointF_0.Y;
				}
				arrayList.Add(new Struct36(startAngle2, num, startPoint2, endPoint2));
			}
		}
		return (Struct36[])arrayList.ToArray(typeof(Struct36));
	}

	private Struct36[] method_28()
	{
		ArrayList arrayList = new ArrayList();
		if (float_3 != 0f && (!(float_2 >= 0f) || !(float_2 + float_3 <= 180f)) && float_2 + float_3 > 180f)
		{
			float num = float_2;
			PointF startPoint = new PointF(pointF_2.X, pointF_2.Y);
			float num2 = float_2 + float_3;
			PointF endPoint = new PointF(pointF_4.X, pointF_4.Y);
			if (num < 180f)
			{
				num = 180f;
				startPoint.X = rectangleF_0.Left;
				startPoint.Y = pointF_0.Y;
			}
			if (num2 > 360f)
			{
				num2 = 360f;
				endPoint.X = rectangleF_0.Right;
				endPoint.Y = pointF_0.Y;
			}
			arrayList.Add(new Struct36(num, num2, startPoint, endPoint));
			if (float_2 < 360f && float_2 + float_3 > 540f)
			{
				num = 180f;
				startPoint = new PointF(rectangleF_0.Left, pointF_0.Y);
				num2 = EndAngle;
				endPoint = new PointF(pointF_4.X, pointF_4.Y);
				arrayList.Add(new Struct36(num, num2, startPoint, endPoint));
			}
		}
		return (Struct36[])arrayList.ToArray(typeof(Struct36));
	}

	private GraphicsPath method_29(float startAngle, float endAngle, PointF pointStart, PointF pointEnd)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(rectangleF_0, startAngle, OriginalSweepAngle);
		graphicsPath.AddArc(rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, endAngle, 0f - OriginalSweepAngle);
		return graphicsPath;
	}

	private GraphicsPath method_30(float startAngle, float endAngle, PointF pointStart, PointF pointEnd)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(rectangleF_0, startAngle, endAngle - startAngle);
		graphicsPath.AddLine(pointEnd.X, pointEnd.Y, pointEnd.X, pointEnd.Y + float_1);
		graphicsPath.AddArc(rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, endAngle, startAngle - endAngle);
		graphicsPath.AddLine(pointStart.X, pointStart.Y + float_1, pointStart.X, pointStart.Y);
		return graphicsPath;
	}

	private ArrayList method_31(float startAngle, float endAngle, PointF pointStart, PointF pointEnd, float originalSweepleAngle)
	{
		ArrayList arrayList = new ArrayList();
		if (originalSweepleAngle != 360f)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(rectangleF_0, startAngle, endAngle - startAngle);
			graphicsPath.AddLine(pointEnd.X, pointEnd.Y, pointEnd.X, pointEnd.Y + float_1);
			graphicsPath.AddArc(rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, endAngle, startAngle - endAngle);
			graphicsPath.AddLine(pointStart.X, pointStart.Y + float_1, pointStart.X, pointStart.Y);
			arrayList.Add(graphicsPath);
		}
		else
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddArc(rectangleF_0, startAngle, endAngle - startAngle);
			arrayList.Add(graphicsPath2);
			GraphicsPath graphicsPath3 = new GraphicsPath();
			graphicsPath3.AddArc(rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, endAngle, startAngle - endAngle);
			arrayList.Add(graphicsPath3);
			int num = (int)Math.Round(startAngle, MidpointRounding.AwayFromZero);
			if (num % 180 == 0)
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(pointStart.X, pointStart.Y + float_1, pointStart.X, pointStart.Y);
				arrayList.Add(graphicsPath4);
			}
			int num2 = (int)Math.Round(endAngle, MidpointRounding.AwayFromZero);
			if (num2 % 180 == 0)
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddLine(pointEnd.X, pointEnd.Y, pointEnd.X, pointEnd.Y + float_1);
				arrayList.Add(graphicsPath5);
			}
		}
		return arrayList;
	}

	private bool method_32(PointF point, float startAngle, float endAngle, PointF point1, PointF point2)
	{
		if (float_1 > 0f)
		{
			return Class769.Contains(point, new PointF[4]
			{
				point1,
				new PointF(point1.X, point1.Y + float_1),
				new PointF(point2.X, point2.Y + float_1),
				point2
			});
		}
		return false;
	}

	private bool method_33(PointF point, float xBoundingRectangle, float yBoundingRectangle, float widthBoundingRectangle, float heightBoundingRectangle, float startAngle, float sweepAngle)
	{
		double num = point.X - xBoundingRectangle - widthBoundingRectangle / 2f;
		double num2 = point.Y - yBoundingRectangle - heightBoundingRectangle / 2f;
		double num3 = Math.Atan2(num2, num);
		if (num3 < 0.0)
		{
			num3 += Math.PI * 2.0;
		}
		double num4 = num3 * 180.0 / Math.PI;
		if ((num4 >= (double)startAngle && num4 <= (double)(startAngle + sweepAngle)) || (startAngle + sweepAngle > 360f && num4 + 360.0 <= (double)(startAngle + sweepAngle)))
		{
			double num5 = Math.Sqrt(num2 * num2 + num * num);
			return method_34(num3) > num5;
		}
		return false;
	}

	private double method_34(double angle)
	{
		double num = rectangleF_0.Width / 2f;
		double num2 = rectangleF_0.Height / 2f;
		double num3 = num * num;
		double num4 = num2 * num2;
		double num5 = Math.Cos(angle);
		double num6 = Math.Sin(angle);
		return num * num2 / Math.Sqrt(num4 * num5 * num5 + num3 * num6 * num6);
	}
}
