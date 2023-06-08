using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns19;
using ns22;
using ns31;

namespace ns32;

internal class Class819 : IDisposable, ICloneable
{
	private struct Struct34
	{
		private float float_0;

		private float float_1;

		private PointF pointF_0;

		private PointF pointF_1;

		public Struct34(float float_2, float float_3, PointF pointF_2, PointF pointF_3)
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

	protected RectangleF rectangleF_0;

	protected float float_0;

	protected float float_1;

	protected float float_2;

	private float float_3;

	private float float_4;

	private Color color_0 = Color.Empty;

	private Enum49 enum49_0;

	private Enum48 enum48_0;

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

	protected Class820 class820_0 = Class820.class820_0;

	protected Class820 class820_1 = Class820.class820_0;

	private string string_0;

	private bool bool_0;

	private static float float_5 = 20f;

	private Class796 class796_0;

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

	protected Class819()
	{
	}

	public Class819(float float_6, float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, Color color_1, Enum49 enum49_1, Enum48 enum48_1)
		: this()
	{
		float_3 = float_11;
		float_4 = float_12;
		color_0 = color_1;
		enum49_0 = enum49_1;
		enum48_0 = enum48_1;
		Color color = Struct31.smethod_0(enum48_1, color_1);
		pen_0 = new Pen(color);
		pen_0.LineJoin = LineJoin.Round;
		method_21(float_6, float_7, float_8, float_9, float_10);
	}

	public Class819(float float_6, float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, Color color_1, Enum49 enum49_1, Enum48 enum48_1, float float_13, Class796 class796_1)
		: this(float_6, float_7, float_8, float_9, float_10, float_11, float_12, color_1, enum49_1, enum48_1, float_13)
	{
		class796_0 = class796_1;
		if (class796_1 != null)
		{
			pen_0 = Struct29.smethod_5(class796_1.method_4());
		}
	}

	public Class819(RectangleF rectangleF_1, float float_6, float float_7, float float_8, Color color_1, Enum49 enum49_1, Enum48 enum48_1)
		: this(rectangleF_1.X, rectangleF_1.Y, rectangleF_1.Width, rectangleF_1.Height, float_6, float_7, float_8, color_1, enum49_1, enum48_1)
	{
	}

	public Class819(float float_6, float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, Color color_1, Enum49 enum49_1, Enum48 enum48_1, float float_13)
		: this(float_6, float_7, float_8, float_9, float_10, float_11, float_12, color_1, enum49_1, enum48_1)
	{
		pen_0.Width = float_13;
	}

	~Class819()
	{
		Dispose(bool_1: false);
	}

	public void Dispose()
	{
		Dispose(bool_1: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_1)
	{
		if (!bool_0)
		{
			if (bool_1)
			{
				pen_0.Dispose();
				method_16();
				class820_0.Dispose();
				class820_1.Dispose();
			}
			bool_0 = true;
		}
	}

	public object Clone()
	{
		Class819 @class = new Class819(method_3(), method_4(), method_0(), method_1(), color_0, enum49_0, enum48_0);
		@class.method_15(method_14());
		return @class;
	}

	[SpecialName]
	public float method_0()
	{
		return float_1;
	}

	[SpecialName]
	public float method_1()
	{
		return float_2;
	}

	[SpecialName]
	public float method_2()
	{
		return (float_1 + float_2) % 360f;
	}

	public virtual PointF vmethod_0(float param_r, out float dlAngle)
	{
		PointF empty = PointF.Empty;
		if (method_1() >= 180f)
		{
			dlAngle = method_19(method_0()) + method_1() / 2f;
			empty = method_20(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		else
		{
			float num = (pointF_2.X + pointF_4.X) / 2f;
			float num2 = (pointF_2.Y + pointF_4.Y) / 2f;
			float float_ = (float)(Math.Atan2(num2 - pointF_0.Y, num - pointF_0.X) * 180.0 / Math.PI);
			dlAngle = method_19(float_);
			empty = method_20(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		dlAngle %= 360f;
		if (dlAngle < 0f)
		{
			dlAngle += 360f;
		}
		return empty;
	}

	public virtual PointF vmethod_1(float param_r, int offAngel, out float dlAngle)
	{
		PointF empty = PointF.Empty;
		if (method_1() >= 180f)
		{
			dlAngle = method_19(method_0()) + method_1() / 2f;
			dlAngle += offAngel;
			empty = method_20(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		else
		{
			float num = (pointF_2.X + pointF_4.X) / 2f;
			float num2 = (pointF_2.Y + pointF_4.Y) / 2f;
			float float_ = (float)(Math.Atan2(num2 - pointF_0.Y, num - pointF_0.X) * 180.0 / Math.PI);
			dlAngle = method_19(float_);
			dlAngle += offAngel;
			empty = method_20(pointF_0.X, pointF_0.Y, rectangleF_0.Width * param_r, rectangleF_0.Height * param_r, dlAngle);
		}
		dlAngle %= 360f;
		if (dlAngle < 0f)
		{
			dlAngle += 360f;
		}
		return empty;
	}

	[SpecialName]
	internal RectangleF method_3()
	{
		return rectangleF_0;
	}

	[SpecialName]
	internal float method_4()
	{
		return float_0;
	}

	internal void method_5(Interface42 interface42_0)
	{
		method_10(interface42_0);
		if (method_0() > 90f && method_0() < 270f)
		{
			method_8(interface42_0);
			method_7(interface42_0);
		}
		else
		{
			method_7(interface42_0);
			method_8(interface42_0);
		}
		method_9(interface42_0);
	}

	internal Class819[] Split(float float_6)
	{
		if (method_0() != float_6 && method_2() != float_6)
		{
			method_18(float_6);
			float num = method_19(method_0());
			float float_7 = (float_6 - num + 360f) % 360f;
			Class819 @class = new Class819(method_3(), method_4(), num, float_7, color_0, enum49_0, enum48_0);
			@class.method_15(class796_0);
			@class.method_23(bool_1: true, bool_2: false);
			float_7 = method_19(method_2()) - float_6;
			Class819 class2 = new Class819(method_3(), method_4(), float_6, float_7, color_0, enum49_0, enum48_0);
			class2.method_15(class796_0);
			class2.method_23(bool_1: false, bool_2: true);
			return new Class819[2] { @class, class2 };
		}
		return new Class819[1] { (Class819)Clone() };
	}

	internal void method_6(float float_6, float float_7, float float_8, float float_9, float float_10)
	{
		method_21(float_6, float_7, float_8, float_9, float_10);
	}

	internal void method_7(Interface42 interface42_0)
	{
		if (class820_0 != null)
		{
			if (method_0() > 90f && method_0() < 270f)
			{
				class820_0.Draw(interface42_0, pen_0, brush_2, class796_0);
			}
			else
			{
				class820_0.Draw(interface42_0, pen_0, brush_0, class796_0);
			}
		}
	}

	internal void method_8(Interface42 interface42_0)
	{
		if (class820_1 != null)
		{
			if (method_2() > 90f && method_2() < 270f)
			{
				class820_1.Draw(interface42_0, pen_0, brush_0, class796_0);
			}
			else
			{
				class820_1.Draw(interface42_0, pen_0, brush_3, class796_0);
			}
		}
	}

	internal void method_9(Interface42 interface42_0)
	{
		Struct34[] array = method_24();
		Struct34[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Struct34 @struct = array2[i];
			method_17(interface42_0, pen_0, brush_4, @struct.method_0(), @struct.method_1(), @struct.method_2(), @struct.method_3());
		}
	}

	internal void method_10(Interface42 interface42_0)
	{
		Struct34[] array = method_25();
		Struct34[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Struct34 @struct = array2[i];
			method_17(interface42_0, pen_0, brush_0, @struct.method_0(), @struct.method_1(), @struct.method_2(), @struct.method_3());
		}
	}

	internal void method_11(Interface42 interface42_0)
	{
		Brush brush = brush_0;
		Pen pen = pen_0;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPie(rectangleF_0.X, rectangleF_0.Y + float_0, rectangleF_0.Width, rectangleF_0.Height, float_1, float_2);
		if (class796_0 != null && class796_0.method_3().method_2())
		{
			brush = Struct18.smethod_1(class796_0.method_3(), Class1181.smethod_1(graphicsPath));
		}
		interface42_0.imethod_33(brush, graphicsPath);
		interface42_0.imethod_18(pen, graphicsPath);
	}

	internal void method_12(Interface42 interface42_0)
	{
		Brush brush = brush_0;
		Pen pen = pen_0;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, float_1, float_2);
		if (class796_0 != null && class796_0.method_3().method_2())
		{
			brush = Struct18.smethod_1(class796_0.method_3(), Class1181.smethod_1(graphicsPath));
		}
		interface42_0.imethod_33(brush, graphicsPath);
		if (pen.Color.A != 0)
		{
			interface42_0.imethod_18(pen, graphicsPath);
			return;
		}
		using Pen pen2 = new Pen(brush, 1f);
		interface42_0.imethod_18(pen2, graphicsPath);
	}

	internal RectangleF method_13()
	{
		RectangleF result = new RectangleF(pointF_2.X, pointF_2.Y, 0f, 0f);
		if (float_1 == 0f || float_1 + float_2 >= 360f)
		{
			Struct32.smethod_1(ref result, rectangleF_0.Right);
		}
		if ((float_1 <= 90f && float_1 + float_2 >= 90f) || float_1 + float_2 >= 450f)
		{
			Struct32.smethod_2(ref result, rectangleF_0.Bottom + method_4());
		}
		if ((float_1 <= 180f && float_1 + float_2 >= 180f) || float_1 + float_2 >= 540f)
		{
			Struct32.smethod_1(ref result, rectangleF_0.Left);
		}
		if ((float_1 <= 270f && float_1 + float_2 >= 270f) || float_1 + float_2 >= 630f)
		{
			Struct32.smethod_2(ref result, rectangleF_0.Top);
		}
		Struct32.smethod_0(ref result, pointF_0);
		Struct32.smethod_0(ref result, pointF_1);
		Struct32.smethod_0(ref result, pointF_2);
		Struct32.smethod_0(ref result, pointF_3);
		Struct32.smethod_0(ref result, pointF_4);
		Struct32.smethod_0(ref result, pointF_5);
		return result;
	}

	[SpecialName]
	internal Class796 method_14()
	{
		return class796_0;
	}

	[SpecialName]
	internal void method_15(Class796 class796_1)
	{
		class796_0 = class796_1;
	}

	protected virtual void vmethod_2(Color color_1, Enum49 enum49_1)
	{
		brush_0 = new SolidBrush(color_1);
		brush_1 = new SolidBrush(Struct30.smethod_0(color_1, Struct30.float_0));
		switch (enum49_1)
		{
		case Enum49.const_0:
		{
			Color color = Color.FromArgb((int)color_1.R / 2, (int)color_1.G / 2, (int)color_1.B / 2);
			brush_2 = (brush_3 = (brush_4 = new SolidBrush(color)));
			break;
		}
		case Enum49.const_1:
			brush_2 = (brush_3 = (brush_4 = new SolidBrush(Struct30.smethod_0(color_1, 0f - Struct30.float_0))));
			break;
		case Enum49.const_2:
		{
			double num = float_1 - 180f - float_5;
			if (num < 0.0)
			{
				num += 360.0;
			}
			brush_2 = vmethod_3(color_1, num);
			num = float_1 + float_2 - float_5;
			if (num < 0.0)
			{
				num += 360.0;
			}
			brush_3 = vmethod_3(color_1, num);
			brush_4 = vmethod_4(color_1);
			break;
		}
		}
	}

	protected void method_16()
	{
		brush_0.Dispose();
		brush_2.Dispose();
		brush_3.Dispose();
		brush_4.Dispose();
		brush_1.Dispose();
	}

	protected virtual Brush vmethod_3(Color color_1, double double_0)
	{
		return new SolidBrush(Struct30.smethod_0(color_1, 0f - (float)((double)Struct30.float_0 * (1.0 - 0.8 * Math.Cos(double_0 * Math.PI / 180.0)))));
	}

	protected virtual Brush vmethod_4(Color color_1)
	{
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = new Color[3]
		{
			Struct30.smethod_0(color_1, (0f - Struct30.float_0) / 2f),
			color_1,
			Struct30.smethod_0(color_1, 0f - Struct30.float_0)
		};
		colorBlend.Positions = new float[3] { 0f, 0.1f, 1f };
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangleF_0, Color.Blue, Color.White, LinearGradientMode.Horizontal);
		linearGradientBrush.InterpolationColors = colorBlend;
		return linearGradientBrush;
	}

	protected void method_17(Interface42 interface42_0, Pen pen_1, Brush brush_5, float float_6, float float_7, PointF pointF_6, PointF pointF_7)
	{
		GraphicsPath graphicsPath_ = method_26(float_6, float_7, pointF_6, pointF_7);
		if (class796_0 != null && class796_0.method_3().method_2())
		{
			brush_5 = Struct18.smethod_3(class796_0.method_3(), Class1181.smethod_1(graphicsPath_), 0.5f);
		}
		if (class796_0.method_3().Formatting != 0)
		{
			interface42_0.imethod_33(brush_5, graphicsPath_);
		}
		if (class796_0.method_4().IsVisible)
		{
			interface42_0.imethod_18(pen_1, graphicsPath_);
		}
	}

	protected float method_18(float float_6)
	{
		double x = (double)rectangleF_0.Width * Math.Cos((double)float_6 * Math.PI / 180.0);
		double y = (double)rectangleF_0.Height * Math.Sin((double)float_6 * Math.PI / 180.0);
		float num = (float)(Math.Atan2(y, x) * 180.0 / Math.PI);
		if (num < 0f)
		{
			return num + 360f;
		}
		return num;
	}

	protected float method_19(float float_6)
	{
		double x = (double)rectangleF_0.Height * Math.Cos((double)float_6 * Math.PI / 180.0);
		double y = (double)rectangleF_0.Width * Math.Sin((double)float_6 * Math.PI / 180.0);
		float num = (float)(Math.Atan2(y, x) * 180.0 / Math.PI);
		if (num < 0f)
		{
			return num + 360f;
		}
		return num;
	}

	protected PointF method_20(float float_6, float float_7, float float_8, float float_9, float float_10)
	{
		double num = (double)float_10 * Math.PI / 180.0;
		return new PointF(float_6 + (float)((double)float_8 * Math.Cos(num)), float_7 + (float)((double)float_9 * Math.Sin(num)));
	}

	private void method_21(float float_6, float float_7, float float_8, float float_9, float float_10)
	{
		rectangleF_0 = new RectangleF(float_6, float_7, float_8, float_9);
		float_0 = float_10;
		float_1 = method_18(float_3);
		float_2 = float_4;
		if (float_2 % 180f != 0f)
		{
			float_2 = method_18(float_3 + float_4) - float_1;
		}
		if (float_2 < 0f)
		{
			float_2 += 360f;
		}
		vmethod_2(color_0, enum49_0);
		float num = float_6 + float_8 / 2f;
		float num2 = float_7 + float_9 / 2f;
		pointF_0 = new PointF(num, num2);
		pointF_1 = new PointF(num, num2 + float_10);
		pointF_2 = method_20(num, num2, float_8 / 2f, float_9 / 2f, float_3);
		pointF_3 = new PointF(pointF_2.X, pointF_2.Y + float_10);
		pointF_4 = method_20(num, num2, float_8 / 2f, float_9 / 2f, float_3 + float_4);
		pointF_5 = new PointF(pointF_4.X, pointF_4.Y + float_10);
		method_22();
	}

	private void method_22()
	{
		method_23(bool_1: true, bool_2: true);
	}

	private void method_23(bool bool_1, bool bool_2)
	{
		if (bool_1)
		{
			class820_0 = new Class820(pointF_0, pointF_2, pointF_3, pointF_1, float_2 != 180f);
		}
		else
		{
			class820_0 = Class820.class820_0;
		}
		if (bool_2)
		{
			class820_1 = new Class820(pointF_0, pointF_4, pointF_5, pointF_1, float_2 != 180f);
		}
		else
		{
			class820_1 = Class820.class820_0;
		}
	}

	private Struct34[] method_24()
	{
		ArrayList arrayList = new ArrayList();
		if (float_2 != 0f && (!(float_1 >= 180f) || !(float_1 + float_2 <= 360f)))
		{
			if (method_0() < 180f)
			{
				float num = float_1;
				PointF pointF = new PointF(pointF_2.X, pointF_2.Y);
				float num2 = method_2();
				PointF pointF2 = new PointF(pointF_4.X, pointF_4.Y);
				if (float_1 + float_2 > 180f)
				{
					num2 = 180f;
					pointF2.X = rectangleF_0.X;
					pointF2.Y = pointF_0.Y;
				}
				arrayList.Add(new Struct34(num, num2, pointF, pointF2));
			}
			if (float_1 + float_2 > 360f)
			{
				float num3 = 0f;
				PointF pointF3 = new PointF(rectangleF_0.Right, pointF_0.Y);
				float num4 = method_2();
				PointF pointF4 = new PointF(pointF_4.X, pointF_4.Y);
				if (num4 > 180f)
				{
					num4 = 180f;
					pointF4.X = rectangleF_0.Left;
					pointF4.Y = pointF_0.Y;
				}
				arrayList.Add(new Struct34(num3, num4, pointF3, pointF4));
			}
		}
		return (Struct34[])arrayList.ToArray(typeof(Struct34));
	}

	private Struct34[] method_25()
	{
		ArrayList arrayList = new ArrayList();
		if (float_2 != 0f && (!(float_1 >= 0f) || !(float_1 + float_2 <= 180f)) && float_1 + float_2 > 180f)
		{
			float num = float_1;
			PointF pointF = new PointF(pointF_2.X, pointF_2.Y);
			float num2 = float_1 + float_2;
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
			arrayList.Add(new Struct34(num, num2, pointF, pointF2));
			if (float_1 < 360f && float_1 + float_2 > 540f)
			{
				num = 180f;
				pointF = new PointF(rectangleF_0.Left, pointF_0.Y);
				num2 = method_2();
				pointF2 = new PointF(pointF_4.X, pointF_4.Y);
				arrayList.Add(new Struct34(num, num2, pointF, pointF2));
			}
		}
		return (Struct34[])arrayList.ToArray(typeof(Struct34));
	}

	private GraphicsPath method_26(float float_6, float float_7, PointF pointF_6, PointF pointF_7)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(rectangleF_0, float_6, float_7 - float_6);
		graphicsPath.AddLine(pointF_7.X, pointF_7.Y, pointF_7.X, pointF_7.Y + float_0);
		graphicsPath.AddArc(rectangleF_0.X, rectangleF_0.Y + float_0, rectangleF_0.Width, rectangleF_0.Height, float_7, float_6 - float_7);
		graphicsPath.AddLine(pointF_6.X, pointF_6.Y + float_0, pointF_6.X, pointF_6.Y);
		return graphicsPath;
	}
}
