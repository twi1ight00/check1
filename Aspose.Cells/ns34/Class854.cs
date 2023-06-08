using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns19;
using ns33;

namespace ns34;

internal class Class854 : IDisposable, ICloneable
{
	private struct Struct58
	{
		private float float_0;

		private float float_1;

		private PointF pointF_0;

		private PointF pointF_1;

		public Struct58(float float_2, float float_3, PointF pointF_2, PointF pointF_3)
		{
			float_0 = float_2;
			float_1 = float_3;
			pointF_0 = pointF_2;
			pointF_1 = pointF_3;
		}

		[SpecialName]
		public float method_0()
		{
			return float_0;
		}

		[SpecialName]
		public float method_1()
		{
			return float_1;
		}

		[SpecialName]
		public PointF method_2()
		{
			return pointF_0;
		}

		[SpecialName]
		public PointF method_3()
		{
			return pointF_1;
		}
	}

	private float float_0;

	internal bool bool_0;

	protected RectangleF rectangleF_0;

	protected float float_1;

	protected float float_2;

	protected float float_3;

	private float float_4;

	private float float_5;

	private Color color_0 = Color.Empty;

	private Enum51 enum51_0;

	private Enum50 enum50_0;

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

	protected Class855 class855_0 = Class855.class855_0;

	protected Class855 class855_1 = Class855.class855_0;

	private string string_0;

	private bool bool_1;

	private static float float_6 = 20f;

	private Class831 class831_0;

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

	protected Class854()
	{
	}

	public Class854(float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, Color color_1, Enum51 enum51_1, Enum50 enum50_1)
		: this()
	{
		float_4 = float_12;
		float_5 = float_13;
		color_0 = color_1;
		enum51_0 = enum51_1;
		enum50_0 = enum50_1;
		Color color = Struct55.smethod_0(enum50_1, color_1);
		pen_0 = new Pen(color);
		pen_0.LineJoin = LineJoin.Round;
		method_25(float_7, float_8, float_9, float_10, float_11);
	}

	public Class854(float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, Color color_1, Enum51 enum51_1, Enum50 enum50_1, float float_14, Class831 class831_1)
		: this(float_7, float_8, float_9, float_10, float_11, float_12, float_13, color_1, enum51_1, enum50_1, float_14)
	{
		class831_0 = class831_1;
		if (class831_1 != null)
		{
			RectangleF rect = new RectangleF(float_7, float_8, float_9, float_10);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rect);
			pen_0 = class831_1.method_4().method_12(graphicsPath);
		}
	}

	public Class854(RectangleF rectangleF_1, float float_7, float float_8, float float_9, Color color_1, Enum51 enum51_1, Enum50 enum50_1, float float_10, Class831 class831_1)
		: this(rectangleF_1.X, rectangleF_1.Y, rectangleF_1.Width, rectangleF_1.Height, float_7, float_8, float_9, color_1, enum51_1, enum50_1, float_10, class831_1)
	{
	}

	public Class854(float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, Color color_1, Enum51 enum51_1, Enum50 enum50_1, float float_14)
		: this(float_7, float_8, float_9, float_10, float_11, float_12, float_13, color_1, enum51_1, enum50_1)
	{
		pen_0.Width = float_14;
	}

	~Class854()
	{
		Dispose(bool_2: false);
	}

	public void Dispose()
	{
		Dispose(bool_2: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_2)
	{
		if (!bool_1)
		{
			if (bool_2)
			{
				pen_0.Dispose();
				method_20();
				class855_0.Dispose();
				class855_1.Dispose();
			}
			bool_1 = true;
		}
	}

	public object Clone()
	{
		return new Class854(method_8(), method_9(), method_1(), method_2(), color_0, enum51_0, enum50_0, pen_0.Width, class831_0);
	}

	public Class854 method_0(float float_7)
	{
		return new Class854(method_8(), method_9(), float_4 + float_7, float_5, color_0, enum51_0, enum50_0, pen_0.Width, class831_0);
	}

	[SpecialName]
	public float method_1()
	{
		return float_2;
	}

	[SpecialName]
	public float method_2()
	{
		return float_3;
	}

	[SpecialName]
	public float method_3()
	{
		return float_0;
	}

	[SpecialName]
	public void method_4(float float_7)
	{
		float_0 = float_7;
	}

	[SpecialName]
	public float method_5()
	{
		return (float_2 + float_3) % 360f;
	}

	[SpecialName]
	internal float method_6()
	{
		return float_4;
	}

	[SpecialName]
	internal float method_7()
	{
		return float_5;
	}

	public virtual PointF vmethod_0(float param_r, out float dlAngle)
	{
		PointF empty = PointF.Empty;
		if (method_2() >= 180f)
		{
			dlAngle = method_23(method_1()) + method_2() / 2f;
			empty = method_24(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		else
		{
			float num = (pointF_2.X + pointF_4.X) / 2f;
			float num2 = (pointF_2.Y + pointF_4.Y) / 2f;
			float float_ = (float)(Math.Atan2(num2 - pointF_0.Y, num - pointF_0.X) * 180.0 / Math.PI);
			dlAngle = method_23(float_);
			empty = method_24(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		dlAngle %= 360f;
		if (dlAngle < 0f)
		{
			dlAngle += 360f;
		}
		return empty;
	}

	[SpecialName]
	internal RectangleF method_8()
	{
		return rectangleF_0;
	}

	[SpecialName]
	internal float method_9()
	{
		return float_1;
	}

	internal void method_10(Interface42 interface42_0)
	{
		method_15(interface42_0);
		if (method_1() > 90f && method_1() < 270f)
		{
			method_13(interface42_0);
			method_12(interface42_0);
		}
		else
		{
			method_12(interface42_0);
			method_13(interface42_0);
		}
		method_14(interface42_0);
	}

	internal Class854[] Split(float float_7)
	{
		if (method_1() != float_7 && method_5() != float_7)
		{
			method_22(float_7);
			float num = method_23(method_1());
			float float_8 = (float_7 - num + 360f) % 360f;
			Class854 @class = new Class854(method_8(), method_9(), num, float_8, color_0, enum51_0, enum50_0, pen_0.Width, class831_0);
			@class.method_4(method_2());
			@class.bool_0 = true;
			if (method_2() == 360f)
			{
				@class.method_27(bool_2: false, bool_3: false);
			}
			else
			{
				@class.method_27(bool_2: true, bool_3: false);
			}
			float_8 = method_23(method_5()) - float_7;
			Class854 class2 = new Class854(method_8(), method_9(), float_7, float_8, color_0, enum51_0, enum50_0, pen_0.Width, class831_0);
			class2.method_4(method_2());
			class2.bool_0 = true;
			if (method_2() == 360f)
			{
				class2.method_27(bool_2: false, bool_3: false);
			}
			else
			{
				class2.method_27(bool_2: false, bool_3: true);
			}
			return new Class854[2] { @class, class2 };
		}
		return new Class854[1] { (Class854)Clone() };
	}

	internal void method_11(float float_7, float float_8, float float_9, float float_10, float float_11)
	{
		method_25(float_7, float_8, float_9, float_10, float_11);
	}

	internal void method_12(Interface42 interface42_0)
	{
		if (class855_0 != null)
		{
			if (method_1() > 90f && method_1() < 270f)
			{
				class855_0.Draw(interface42_0, pen_0, brush_2, class831_0);
			}
			else
			{
				class855_0.Draw(interface42_0, pen_0, brush_0, class831_0);
			}
		}
	}

	internal void method_13(Interface42 interface42_0)
	{
		if (class855_1 != null)
		{
			if (method_5() > 90f && method_5() < 270f)
			{
				class855_1.Draw(interface42_0, pen_0, brush_0, class831_0);
			}
			else
			{
				class855_1.Draw(interface42_0, pen_0, brush_3, class831_0);
			}
		}
	}

	internal void method_14(Interface42 interface42_0)
	{
		Struct58[] array = method_28();
		Struct58[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Struct58 @struct = array2[i];
			method_21(interface42_0, pen_0, brush_4, @struct.method_0(), @struct.method_1(), @struct.method_2(), @struct.method_3());
		}
	}

	internal void method_15(Interface42 interface42_0)
	{
		Struct58[] array = method_29();
		Struct58[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Struct58 @struct = array2[i];
			method_21(interface42_0, pen_0, brush_0, @struct.method_0(), @struct.method_1(), @struct.method_2(), @struct.method_3());
		}
	}

	internal void method_16(Interface42 interface42_0)
	{
		if (class831_0 != null)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
			class831_0.method_3().method_9(graphicsPath);
		}
		if (class831_0 != null)
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
			class831_0.method_4().method_11(graphicsPath2);
		}
	}

	internal void method_17(Interface42 interface42_0)
	{
		Brush brush = null;
		if (class831_0 != null)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
			brush = class831_0.method_3().method_13(graphicsPath);
			class831_0.method_3().method_9(graphicsPath);
		}
		if (class831_0 == null)
		{
			return;
		}
		GraphicsPath graphicsPath2 = new GraphicsPath();
		if (float_3 == 360f)
		{
			graphicsPath2.AddArc(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
		}
		else
		{
			graphicsPath2.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_2, float_3);
		}
		if (class831_0.method_4().method_12(graphicsPath2).Color.A != 0)
		{
			class831_0.method_4().method_11(graphicsPath2);
		}
		else if (brush != null)
		{
			using (Pen pen = new Pen(brush, 1f))
			{
				interface42_0.imethod_18(pen, graphicsPath2);
			}
		}
	}

	internal RectangleF method_18()
	{
		RectangleF result = new RectangleF(pointF_2.X, pointF_2.Y, 0f, 0f);
		if (float_2 == 0f || float_2 + float_3 >= 360f)
		{
			Struct56.smethod_1(ref result, rectangleF_0.Right);
		}
		if ((float_2 <= 90f && float_2 + float_3 >= 90f) || float_2 + float_3 >= 450f)
		{
			Struct56.smethod_2(ref result, rectangleF_0.Bottom + method_9());
		}
		if ((float_2 <= 180f && float_2 + float_3 >= 180f) || float_2 + float_3 >= 540f)
		{
			Struct56.smethod_1(ref result, rectangleF_0.Left);
		}
		if ((float_2 <= 270f && float_2 + float_3 >= 270f) || float_2 + float_3 >= 630f)
		{
			Struct56.smethod_2(ref result, rectangleF_0.Top);
		}
		Struct56.smethod_0(ref result, pointF_0);
		Struct56.smethod_0(ref result, pointF_1);
		Struct56.smethod_0(ref result, pointF_2);
		Struct56.smethod_0(ref result, pointF_3);
		Struct56.smethod_0(ref result, pointF_4);
		Struct56.smethod_0(ref result, pointF_5);
		return result;
	}

	[SpecialName]
	internal Class831 method_19()
	{
		return class831_0;
	}

	protected virtual void vmethod_1(Color color_1, Enum51 enum51_1)
	{
		brush_0 = new SolidBrush(color_1);
		brush_1 = new SolidBrush(Struct54.smethod_0(color_1, Struct54.float_0));
		switch (enum51_1)
		{
		case Enum51.const_0:
		{
			Color color = Color.FromArgb((int)color_1.R / 2, (int)color_1.G / 2, (int)color_1.B / 2);
			brush_2 = (brush_3 = (brush_4 = new SolidBrush(color)));
			break;
		}
		case Enum51.const_1:
			brush_2 = (brush_3 = (brush_4 = new SolidBrush(Struct54.smethod_0(color_1, 0f - Struct54.float_0))));
			break;
		case Enum51.const_2:
		{
			double num = float_2 - 180f - float_6;
			if (num < 0.0)
			{
				num += 360.0;
			}
			brush_2 = vmethod_2(color_1, num);
			num = float_2 + float_3 - float_6;
			if (num < 0.0)
			{
				num += 360.0;
			}
			brush_3 = vmethod_2(color_1, num);
			brush_4 = vmethod_3(color_1);
			break;
		}
		}
	}

	protected void method_20()
	{
		brush_0.Dispose();
		brush_2.Dispose();
		brush_3.Dispose();
		brush_4.Dispose();
		brush_1.Dispose();
	}

	protected virtual Brush vmethod_2(Color color_1, double double_0)
	{
		return new SolidBrush(Struct54.smethod_0(color_1, 0f - (float)((double)Struct54.float_0 * (1.0 - 0.8 * Math.Cos(double_0 * Math.PI / 180.0)))));
	}

	protected virtual Brush vmethod_3(Color color_1)
	{
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = new Color[3]
		{
			Struct54.smethod_0(color_1, (0f - Struct54.float_0) / 2f),
			color_1,
			Struct54.smethod_0(color_1, 0f - Struct54.float_0)
		};
		colorBlend.Positions = new float[3] { 0f, 0.1f, 1f };
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangleF_0, Color.Blue, Color.White, LinearGradientMode.Horizontal);
		linearGradientBrush.InterpolationColors = colorBlend;
		return linearGradientBrush;
	}

	protected void method_21(Interface42 interface42_0, Pen pen_1, Brush brush_5, float float_7, float float_8, PointF pointF_6, PointF pointF_7)
	{
		float num = 0.5f;
		if (class831_0 != null)
		{
			GraphicsPath graphicsPath_ = method_31(float_7, float_8, pointF_6, pointF_7);
			if (bool_0)
			{
				GraphicsPath graphicsPath_2 = method_30(float_7, float_8, pointF_6, pointF_7);
				class831_0.method_3().method_11(graphicsPath_, num, graphicsPath_2);
			}
			else
			{
				class831_0.method_3().method_10(graphicsPath_, num);
			}
		}
		if (class831_0 == null)
		{
			return;
		}
		ArrayList arrayList = method_32(float_7, float_8, pointF_6, pointF_7, method_3());
		foreach (GraphicsPath item in arrayList)
		{
			class831_0.method_4().method_11(item);
		}
	}

	protected float method_22(float float_7)
	{
		double x = (double)rectangleF_0.Width * Math.Cos((double)float_7 * Math.PI / 180.0);
		double y = (double)rectangleF_0.Height * Math.Sin((double)float_7 * Math.PI / 180.0);
		float num = (float)(Math.Atan2(y, x) * 180.0 / Math.PI);
		if (num < 0f)
		{
			return num + 360f;
		}
		return num;
	}

	protected float method_23(float float_7)
	{
		double x = (double)rectangleF_0.Height * Math.Cos((double)float_7 * Math.PI / 180.0);
		double y = (double)rectangleF_0.Width * Math.Sin((double)float_7 * Math.PI / 180.0);
		float num = (float)(Math.Atan2(y, x) * 180.0 / Math.PI);
		if (num < 0f)
		{
			return num + 360f;
		}
		return num;
	}

	protected PointF method_24(float float_7, float float_8, float float_9, float float_10, float float_11)
	{
		double num = (double)float_11 * Math.PI / 180.0;
		return new PointF(float_7 + (float)((double)float_9 * Math.Cos(num)), float_8 + (float)((double)float_10 * Math.Sin(num)));
	}

	private void method_25(float float_7, float float_8, float float_9, float float_10, float float_11)
	{
		rectangleF_0 = new RectangleF(float_7, float_8, float_9, float_10);
		float_1 = float_11;
		float_2 = method_22(float_4);
		float_3 = float_5;
		if (float_3 % 180f != 0f)
		{
			float_3 = method_22(float_4 + float_5) - float_2;
		}
		if (float_3 < 0f)
		{
			float_3 += 360f;
		}
		vmethod_1(color_0, enum51_0);
		float num = float_7 + float_9 / 2f;
		float num2 = float_8 + float_10 / 2f;
		pointF_0 = new PointF(num, num2);
		pointF_1 = new PointF(num, num2 + float_11);
		pointF_2 = method_24(num, num2, float_9 / 2f, float_10 / 2f, float_4);
		pointF_3 = new PointF(pointF_2.X, pointF_2.Y + float_11);
		pointF_4 = method_24(num, num2, float_9 / 2f, float_10 / 2f, float_4 + float_5);
		pointF_5 = new PointF(pointF_4.X, pointF_4.Y + float_11);
		method_26();
	}

	private void method_26()
	{
		method_27(bool_2: true, bool_3: true);
	}

	private void method_27(bool bool_2, bool bool_3)
	{
		if (bool_2)
		{
			class855_0 = new Class855(pointF_0, pointF_2, pointF_3, pointF_1, float_3 != 180f);
		}
		else
		{
			class855_0 = Class855.class855_0;
		}
		if (bool_3)
		{
			class855_1 = new Class855(pointF_0, pointF_4, pointF_5, pointF_1, float_3 != 180f);
		}
		else
		{
			class855_1 = Class855.class855_0;
		}
	}

	private Struct58[] method_28()
	{
		ArrayList arrayList = new ArrayList();
		if (float_3 != 0f && (!(float_2 >= 180f) || !(float_2 + float_3 <= 360f)))
		{
			if (method_1() < 180f)
			{
				float num = float_2;
				PointF pointF = new PointF(pointF_2.X, pointF_2.Y);
				float num2 = method_5();
				PointF pointF2 = new PointF(pointF_4.X, pointF_4.Y);
				if (float_2 + float_3 > 180f)
				{
					num2 = 180f;
					pointF2.X = rectangleF_0.X;
					pointF2.Y = pointF_0.Y;
				}
				arrayList.Add(new Struct58(num, num2, pointF, pointF2));
			}
			if (float_2 + float_3 > 360f)
			{
				float num3 = 0f;
				PointF pointF3 = new PointF(rectangleF_0.Right, pointF_0.Y);
				float num4 = method_5();
				PointF pointF4 = new PointF(pointF_4.X, pointF_4.Y);
				if (num4 > 180f)
				{
					num4 = 180f;
					pointF4.X = rectangleF_0.Left;
					pointF4.Y = pointF_0.Y;
				}
				arrayList.Add(new Struct58(num3, num4, pointF3, pointF4));
			}
		}
		return (Struct58[])arrayList.ToArray(typeof(Struct58));
	}

	private Struct58[] method_29()
	{
		ArrayList arrayList = new ArrayList();
		if (float_3 != 0f && (!(float_2 >= 0f) || !(float_2 + float_3 <= 180f)) && float_2 + float_3 > 180f)
		{
			float num = float_2;
			PointF pointF = new PointF(pointF_2.X, pointF_2.Y);
			float num2 = float_2 + float_3;
			PointF pointF2 = new PointF(pointF_4.X, pointF_4.Y);
			if (num < 180f)
			{
				num = 180f;
				pointF.X = rectangleF_0.Left;
				pointF.Y = pointF_0.Y;
			}
			if (num2 > 360f)
			{
				num2 = 360f;
				pointF2.X = rectangleF_0.Right;
				pointF2.Y = pointF_0.Y;
			}
			arrayList.Add(new Struct58(num, num2, pointF, pointF2));
			if (float_2 < 360f && float_2 + float_3 > 540f)
			{
				num = 180f;
				pointF = new PointF(rectangleF_0.Left, pointF_0.Y);
				num2 = method_5();
				pointF2 = new PointF(pointF_4.X, pointF_4.Y);
				arrayList.Add(new Struct58(num, num2, pointF, pointF2));
			}
		}
		return (Struct58[])arrayList.ToArray(typeof(Struct58));
	}

	private GraphicsPath method_30(float float_7, float float_8, PointF pointF_6, PointF pointF_7)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(rectangleF_0, float_7, method_3());
		graphicsPath.AddArc(rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, float_8, 0f - method_3());
		return graphicsPath;
	}

	private GraphicsPath method_31(float float_7, float float_8, PointF pointF_6, PointF pointF_7)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(rectangleF_0, float_7, float_8 - float_7);
		graphicsPath.AddLine(pointF_7.X, pointF_7.Y, pointF_7.X, pointF_7.Y + float_1);
		graphicsPath.AddArc(rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, float_8, float_7 - float_8);
		graphicsPath.AddLine(pointF_6.X, pointF_6.Y + float_1, pointF_6.X, pointF_6.Y);
		return graphicsPath;
	}

	private ArrayList method_32(float float_7, float float_8, PointF pointF_6, PointF pointF_7, float float_9)
	{
		ArrayList arrayList = new ArrayList();
		if (float_9 != 360f)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(rectangleF_0, float_7, float_8 - float_7);
			graphicsPath.AddLine(pointF_7.X, pointF_7.Y, pointF_7.X, pointF_7.Y + float_1);
			graphicsPath.AddArc(rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, float_8, float_7 - float_8);
			graphicsPath.AddLine(pointF_6.X, pointF_6.Y + float_1, pointF_6.X, pointF_6.Y);
			arrayList.Add(graphicsPath);
		}
		else
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddArc(rectangleF_0, float_7, float_8 - float_7);
			arrayList.Add(graphicsPath2);
			GraphicsPath graphicsPath3 = new GraphicsPath();
			graphicsPath3.AddArc(rectangleF_0.X, rectangleF_0.Y + float_1, rectangleF_0.Width, rectangleF_0.Height, float_8, float_7 - float_8);
			arrayList.Add(graphicsPath3);
			int num = (int)Math.Round(float_7, MidpointRounding.AwayFromZero);
			if (num % 180 == 0)
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(pointF_6.X, pointF_6.Y + float_1, pointF_6.X, pointF_6.Y);
				arrayList.Add(graphicsPath4);
			}
			int num2 = (int)Math.Round(float_8, MidpointRounding.AwayFromZero);
			if (num2 % 180 == 0)
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddLine(pointF_7.X, pointF_7.Y, pointF_7.X, pointF_7.Y + float_1);
				arrayList.Add(graphicsPath5);
			}
		}
		return arrayList;
	}
}
