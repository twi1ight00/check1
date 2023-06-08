using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns19;
using ns22;
using ns3;
using ns33;

namespace ns34;

internal class Class853 : IDisposable
{
	protected float float_0;

	protected float float_1;

	protected float float_2;

	protected float float_3;

	protected float float_4;

	protected float float_5;

	protected Class854[] class854_0;

	protected ArrayList arrayList_0 = new ArrayList();

	protected double[] double_0 = new double[0];

	protected Class830 class830_0;

	protected Color[] color_0 = new Color[12]
	{
		Color.Red,
		Color.Green,
		Color.Blue,
		Color.Yellow,
		Color.Purple,
		Color.Olive,
		Color.Navy,
		Color.Aqua,
		Color.Lime,
		Color.Maroon,
		Color.Teal,
		Color.Fuchsia
	};

	protected string[] string_0;

	protected Font font_0;

	protected Color color_1 = SystemColors.WindowText;

	protected float[] float_6 = new float[1];

	protected Enum50 enum50_0 = Enum50.const_1;

	protected float float_7 = 1f;

	protected Enum51 enum51_0;

	protected bool bool_0 = true;

	protected int int_0 = -1;

	private bool bool_1;

	public double[] Values
	{
		set
		{
			double_0 = value;
		}
	}

	public Color ForeColor
	{
		set
		{
			color_1 = value;
		}
	}

	protected Class853()
	{
	}

	public Class853(float float_8, float float_9, float float_10, float float_11, double[] double_1)
		: this()
	{
		float_0 = float_8;
		float_1 = float_9;
		float_2 = float_10;
		float_3 = float_11;
		Values = double_1;
	}

	public Class853(float float_8, float float_9, float float_10, float float_11, double[] double_1, float float_12)
		: this(float_8, float_9, float_10, float_11, double_1)
	{
		float_4 = float_12;
	}

	public Class853(float float_8, float float_9, float float_10, float float_11, double[] double_1, Color[] color_2, float float_12)
		: this(float_8, float_9, float_10, float_11, double_1, float_12)
	{
		color_0 = color_2;
	}

	public Class853(float float_8, float float_9, float float_10, float float_11, double[] double_1, Color[] color_2, float float_12, string[] string_1)
		: this(float_8, float_9, float_10, float_11, double_1, color_2, float_12)
	{
		string_0 = string_1;
	}

	public Class853(float float_8, float float_9, float float_10, float float_11, double[] double_1, Color[] color_2, float float_12, string[] string_1, Class830 class830_1)
		: this(float_8, float_9, float_10, float_11, double_1, color_2, float_12, string_1)
	{
		class830_0 = class830_1;
	}

	~Class853()
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
		if (bool_1)
		{
			return;
		}
		if (bool_2)
		{
			Class854[] array = class854_0;
			foreach (Class854 @class in array)
			{
				@class.Dispose();
			}
		}
		bool_1 = true;
	}

	[SpecialName]
	public void method_0(float[] float_8)
	{
		float_6 = float_8;
	}

	[SpecialName]
	public void method_1(float float_8)
	{
		float_5 = float_8 % 360f;
		if (float_5 < 0f)
		{
			float_5 += 360f;
		}
	}

	internal void method_2(Class844 class844_0)
	{
		Class830 @class = class844_0.method_9();
		int rotation = class844_0.Chart.Rotation;
		method_1(rotation - 90);
		float[] array = new float[@class.Count];
		for (int i = 0; i < @class.Count; i++)
		{
			array[i] = @class[i].Explosion / 100f;
		}
		method_0(array);
		Class832 class2 = class844_0.method_2();
		font_0 = class2.method_0().Font;
		ForeColor = class2.method_0().FontColor;
		vmethod_1();
		if (bool_0)
		{
			RectangleF rectangleF_ = method_13();
			method_14(rectangleF_);
		}
	}

	public void Draw(Interface42 interface42_0)
	{
		method_21(interface42_0);
		if (float_4 > 0f)
		{
			method_20(interface42_0);
		}
		method_22(interface42_0);
	}

	public virtual void vmethod_0(Interface42 interface42_0)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		Class821 chart = class830_0.Chart;
		double num = 0.0;
		double[] array = double_0;
		foreach (double num2 in array)
		{
			num += num2;
		}
		GraphicsPath graphicsPath_ = method_8();
		RectangleF rectangleF_ = Class1181.smethod_1(graphicsPath_);
		Class854[] array2 = class854_0;
		foreach (Class854 @class in array2)
		{
			if (@class == null || @class.Text.Length < 1)
			{
				continue;
			}
			Class831 class2 = @class.method_19();
			Class844 class3 = class2.method_1().method_0();
			Class832 class4 = class2.method_6();
			if (!class4.method_1())
			{
				continue;
			}
			double num3 = ((num != 0.0) ? (Math.Abs(class2.YValue) / num) : 0.01);
			float num4 = ((!class4.method_0().method_2().IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f));
			float num5 = chart.Height;
			SizeF sizeF = Struct59.smethod_25(interface42_0, chart.method_7(), class3.Index, class2.Index, num3, num4, num5, 0.0);
			RectangleF empty = RectangleF.Empty;
			PointF pointF_ = PointF.Empty;
			bool flag = false;
			Enum74 @enum = class4.vmethod_0();
			float dlAngle;
			while (!flag)
			{
				switch (@enum)
				{
				case Enum74.const_9:
				{
					pointF_ = @class.vmethod_0(0.5f, out dlAngle);
					method_3(@class, ref pointF_, dlAngle, sizeF);
					RectangleF rectangleF_2 = new RectangleF(Struct63.smethod_3(pointF_.X), Struct63.smethod_3(pointF_.Y), Struct63.smethod_3(sizeF.Width), Struct63.smethod_3(sizeF.Height));
					chart.method_29(ref rectangleF_2);
					class4.method_0().rectangle_1 = Struct63.smethod_21(Rectangle.Round(rectangleF_2));
					class4.method_0().method_9();
					pointF_ = new PointF(class4.method_0().rectangle_0.X, class4.method_0().rectangle_0.Y);
					flag = true;
					continue;
				}
				case Enum74.const_1:
					pointF_ = @class.vmethod_0(0.25f, out dlAngle);
					pointF_.X -= sizeF.Width / 2f;
					pointF_.Y -= sizeF.Height / 2f;
					flag = true;
					continue;
				case Enum74.const_3:
				{
					float param_r = 0.485f;
					pointF_ = @class.vmethod_0(param_r, out dlAngle);
					method_4(@class, ref pointF_, dlAngle, sizeF);
					flag = true;
					continue;
				}
				case Enum74.const_4:
					pointF_ = @class.vmethod_0(0.5f, out dlAngle);
					method_3(@class, ref pointF_, dlAngle, sizeF);
					flag = true;
					continue;
				}
				float param_r2 = 0.47f;
				pointF_ = @class.vmethod_0(param_r2, out dlAngle);
				method_4(@class, ref pointF_, dlAngle, sizeF);
				if (method_9(interface42_0, @class, new RectangleF(pointF_, sizeF)))
				{
					flag = true;
					continue;
				}
				PointF pointF = method_10(interface42_0, @class, sizeF, dlAngle);
				if (pointF.IsEmpty)
				{
					flag = false;
					@enum = Enum74.const_4;
				}
				else
				{
					pointF_ = pointF;
					flag = true;
				}
			}
			empty = new RectangleF(pointF_, sizeF);
			chart.method_29(ref empty);
			Struct59.smethod_26(interface42_0, chart, class3.Index, class2.Index, num3, empty, 0.0);
			if (class2.method_1().method_0().HasLeaderLines && class4.vmethod_0() == Enum74.const_9)
			{
				PointF pointF_2 = @class.vmethod_0(0.5f, out dlAngle);
				if (dlAngle >= 0f && dlAngle <= 180f)
				{
					pointF_2.Y += @class.method_9();
				}
				method_5(interface42_0, rectangleF_, @class, class2.method_1().method_0().method_14(), empty, pointF_2);
			}
		}
	}

	private void method_3(Class854 class854_1, ref PointF pointF_0, float float_8, SizeF sizeF_0)
	{
		if ((double)float_8 > 67.5 && (double)float_8 < 112.5)
		{
			pointF_0.X = (float)((double)pointF_0.X - ((double)float_8 - 67.5) * (double)sizeF_0.Width / 45.0);
		}
		else if ((double)float_8 >= 112.5 && (double)float_8 <= 247.5)
		{
			pointF_0.X -= sizeF_0.Width;
		}
		else if ((double)float_8 > 247.5 && (double)float_8 < 292.5)
		{
			pointF_0.X = (float)((double)(pointF_0.X - sizeF_0.Width) + ((double)float_8 - 247.5) * (double)sizeF_0.Width / 45.0);
		}
		if (float_8 >= 0f && float_8 <= 180f)
		{
			pointF_0.Y += class854_1.method_9();
		}
		else if (float_8 < 225f && float_8 > 180f)
		{
			pointF_0.Y -= (float_8 - 135f) * sizeF_0.Height / 90f;
		}
		else if (float_8 >= 225f && float_8 <= 315f)
		{
			pointF_0.Y -= sizeF_0.Height;
		}
		else if (float_8 > 315f && float_8 <= 360f)
		{
			pointF_0.Y = pointF_0.Y - sizeF_0.Height + (float_8 - 315f) * sizeF_0.Height / 90f;
		}
	}

	private void method_4(Class854 class854_1, ref PointF pointF_0, float float_8, SizeF sizeF_0)
	{
		if ((double)float_8 > 67.5 && (double)float_8 < 112.5)
		{
			pointF_0.X = (float)((double)pointF_0.X - (112.5 - (double)float_8) * (double)sizeF_0.Width / 45.0);
		}
		else if ((double)float_8 > 247.5 && (double)float_8 < 292.5)
		{
			pointF_0.X = (float)((double)pointF_0.X - ((double)float_8 - 247.5) * (double)sizeF_0.Width / 45.0);
		}
		else if ((double)float_8 <= 67.5 || (double)float_8 >= 292.5)
		{
			pointF_0.X -= sizeF_0.Width;
		}
		if ((double)float_8 < 22.5)
		{
			pointF_0.Y = pointF_0.Y - sizeF_0.Height / 2f - float_8 * sizeF_0.Height / 45f;
		}
		else if ((double)float_8 > 337.5)
		{
			pointF_0.Y = pointF_0.Y - sizeF_0.Height / 2f + (360f - float_8) * sizeF_0.Height / 45f;
		}
		else if ((double)float_8 > 157.5 && (double)float_8 < 202.5)
		{
			pointF_0.Y = (float)((double)pointF_0.Y - (202.5 - (double)float_8) * (double)sizeF_0.Height / 45.0);
		}
		else if ((double)float_8 <= 157.5 && (double)float_8 >= 22.5)
		{
			pointF_0.Y -= sizeF_0.Height;
		}
	}

	private void method_5(Interface42 interface42_0, RectangleF rectangleF_0, Class854 class854_1, Class840 class840_0, RectangleF rectangleF_1, PointF pointF_0)
	{
		float num = class854_1.method_8().Width / 2f * 0.05f;
		PointF pointF = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + rectangleF_0.Height / 2f);
		PointF pt = pointF_0;
		if (pointF_0.X < pointF.X)
		{
			pt.X -= 1f;
		}
		else
		{
			pt.X += 1f;
		}
		if (pointF_0.Y < pointF.Y)
		{
			pt.Y -= 1f;
		}
		else
		{
			pt.Y += 1f;
		}
		PointF pt2 = new PointF(rectangleF_1.Left, rectangleF_1.Top + rectangleF_1.Height / 3f);
		PointF pt3 = new PointF(rectangleF_1.Left + rectangleF_1.Width / 3f, rectangleF_1.Top);
		PointF pt4 = new PointF(rectangleF_1.Right, rectangleF_1.Top + rectangleF_1.Height / 3f);
		PointF pt5 = new PointF(rectangleF_1.Left + rectangleF_1.Width / 3f, rectangleF_1.Bottom);
		int num2 = method_7(pointF_0, rectangleF_1);
		Pen pen = null;
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF empty = PointF.Empty;
		switch (num2)
		{
		case 1:
			empty = new PointF(pt4.X + num, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath8 = new GraphicsPath();
				graphicsPath8.AddLine(pt4, empty);
				graphicsPath8.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath8);
				graphicsPath8.Dispose();
			}
			break;
		case 2:
			empty = new PointF(pt4.X + num, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddLine(pt4, empty);
				graphicsPath5.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath5);
				graphicsPath5.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + num);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			pen?.Dispose();
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddLine(pt5, empty);
				graphicsPath6.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath6);
				graphicsPath6.Dispose();
			}
			break;
		case 3:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + num);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(pt5, empty);
				graphicsPath4.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath4);
				graphicsPath4.Dispose();
			}
			break;
		case 4:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - num, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath12 = new GraphicsPath();
				graphicsPath12.AddLine(pt2, empty);
				graphicsPath12.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath12);
				graphicsPath12.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + num);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			pen?.Dispose();
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath13 = new GraphicsPath();
				graphicsPath13.AddLine(pt5, empty);
				graphicsPath13.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath13);
				graphicsPath13.Dispose();
			}
			break;
		case 5:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - num, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath11 = new GraphicsPath();
				graphicsPath11.AddLine(pt2, empty);
				graphicsPath11.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath11);
				graphicsPath11.Dispose();
			}
			break;
		case 6:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - num, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath9 = new GraphicsPath();
				graphicsPath9.AddLine(pt2, empty);
				graphicsPath9.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath9);
				graphicsPath9.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - num);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			pen?.Dispose();
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath10 = new GraphicsPath();
				graphicsPath10.AddLine(pt3, empty);
				graphicsPath10.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath10);
				graphicsPath10.Dispose();
			}
			break;
		case 7:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - num);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath7 = new GraphicsPath();
				graphicsPath7.AddLine(pt3, empty);
				graphicsPath7.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath7);
				graphicsPath7.Dispose();
			}
			break;
		case 8:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt4.X + num, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddLine(pt4, empty);
				graphicsPath2.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath2);
				graphicsPath2.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - num);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			pen?.Dispose();
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (method_6(interface42_0, graphicsPath) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddLine(pt3, empty);
				graphicsPath3.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath3);
				graphicsPath3.Dispose();
			}
			break;
		}
		pen?.Dispose();
		pen = null;
	}

	private bool method_6(Interface42 interface42_0, GraphicsPath graphicsPath_0)
	{
		Class854[] array = class854_0;
		foreach (Class854 @class in array)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(@class.method_8().X, @class.method_8().Y, @class.method_8().Width, @class.method_8().Height, @class.method_1(), @class.method_2());
			using (Region region = new Region(graphicsPath_0))
			{
				region.Intersect(graphicsPath);
				if (!interface42_0.imethod_0().imethod_1(region))
				{
					return false;
				}
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPie(@class.method_8().X, @class.method_8().Y + @class.method_9(), @class.method_8().Width, @class.method_8().Height, @class.method_1(), @class.method_2());
			using Region region2 = new Region(graphicsPath_0);
			region2.Intersect(graphicsPath2);
			if (!interface42_0.imethod_0().imethod_1(region2))
			{
				return false;
			}
		}
		return true;
	}

	private int method_7(PointF pointF_0, RectangleF rectangleF_0)
	{
		int num = 0;
		if (rectangleF_0.Right < pointF_0.X)
		{
			if (rectangleF_0.Bottom < pointF_0.Y)
			{
				return 2;
			}
			if (rectangleF_0.Top > pointF_0.Y)
			{
				return 8;
			}
			return 1;
		}
		if (rectangleF_0.Left > pointF_0.X)
		{
			if (rectangleF_0.Bottom < pointF_0.Y)
			{
				return 4;
			}
			if (rectangleF_0.Top > pointF_0.Y)
			{
				return 6;
			}
			return 5;
		}
		if (rectangleF_0.Bottom < pointF_0.Y)
		{
			return 3;
		}
		if (rectangleF_0.Top > pointF_0.Y)
		{
			return 7;
		}
		return 0;
	}

	private GraphicsPath method_8()
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		Class854[] array = class854_0;
		foreach (Class854 @class in array)
		{
			graphicsPath.AddPie(@class.method_8().X, @class.method_8().Y, @class.method_8().Width, @class.method_8().Height, @class.method_1(), @class.method_2());
			graphicsPath.AddPie(@class.method_8().X, @class.method_8().Y + @class.method_9(), @class.method_8().Width, @class.method_8().Height, @class.method_1(), @class.method_2());
		}
		return graphicsPath;
	}

	private bool method_9(Interface42 interface42_0, Class854 class854_1, RectangleF rectangleF_0)
	{
		rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(new RectangleF(float_0, float_1, float_2, float_3));
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddPie(class854_1.method_8().X, class854_1.method_8().Y, class854_1.method_8().Width, class854_1.method_8().Height, class854_1.method_1(), class854_1.method_2());
		using Region region = new Region(graphicsPath);
		region.Xor(graphicsPath2);
		if (class854_1.method_19().method_6().method_0()
			.method_2()
			.Formatting == Enum71.const_0 || class854_1.method_19().method_6().method_0()
			.method_2()
			.Color.IsEmpty)
		{
			rectangleF_0.Inflate(-Struct51.int_0, -Struct51.int_0);
		}
		region.Intersect(rectangleF_0);
		if (interface42_0.imethod_0().imethod_1(region))
		{
			region.Dispose();
			return true;
		}
		region.Dispose();
		return false;
	}

	private PointF method_10(Interface42 interface42_0, Class854 class854_1, SizeF sizeF_0, float float_8)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0.5f;
		bool flag = false;
		if (!(float_8 < 90f) && (!(float_8 >= 180f) || float_8 >= 270f))
		{
			Class854 @class = method_11(class854_1, 0f);
			flag = false;
			while (@class.method_6() > class854_1.method_6() - class854_1.method_7() / 2f)
			{
				@class = method_11(@class, 0f - num3);
				RectangleF rectangleF_ = method_12(@class, sizeF_0);
				num -= num3;
				if (method_9(interface42_0, class854_1, rectangleF_))
				{
					num2 -= num3;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					@class = method_11(class854_1, 0f);
					@class = method_11(@class, num - num2 / 2f);
					return method_12(@class, sizeF_0).Location;
				}
			}
			@class = method_11(class854_1, 0f);
			flag = false;
			while (@class.method_6() < class854_1.method_6() + class854_1.method_7() / 2f)
			{
				@class = method_11(@class, num3);
				RectangleF rectangleF_2 = method_12(@class, sizeF_0);
				num += num3;
				if (method_9(interface42_0, class854_1, rectangleF_2))
				{
					num2 += num3;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					@class = method_11(class854_1, 0f);
					@class = method_11(@class, num - num2 / 2f);
					return method_12(@class, sizeF_0).Location;
				}
			}
		}
		else
		{
			Class854 class2 = method_11(class854_1, 0f);
			flag = false;
			while (class2.method_6() < class854_1.method_6() + class854_1.method_7() / 2f)
			{
				class2 = method_11(class2, num3);
				RectangleF rectangleF_3 = method_12(class2, sizeF_0);
				num += num3;
				if (method_9(interface42_0, class854_1, rectangleF_3))
				{
					num2 += num3;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					class2 = method_11(class854_1, 0f);
					class2 = method_11(class2, num - num2 / 2f);
					return method_12(class2, sizeF_0).Location;
				}
			}
			class2 = method_11(class854_1, 0f);
			flag = false;
			while (class2.method_6() > class854_1.method_6() - class854_1.method_7() / 2f)
			{
				class2 = method_11(class2, 0f - num3);
				RectangleF rectangleF_4 = method_12(class2, sizeF_0);
				num -= num3;
				if (method_9(interface42_0, class854_1, rectangleF_4))
				{
					num2 -= num3;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					class2 = method_11(class854_1, 0f);
					class2 = method_11(class2, num - num2 / 2f);
					return method_12(class2, sizeF_0).Location;
				}
			}
		}
		return PointF.Empty;
	}

	private Class854 method_11(Class854 class854_1, float float_8)
	{
		return class854_1.method_0(float_8);
	}

	private RectangleF method_12(Class854 class854_1, SizeF sizeF_0)
	{
		float param_r = 0.485f;
		float dlAngle;
		PointF location = class854_1.vmethod_0(param_r, out dlAngle);
		if (dlAngle <= 90f || dlAngle >= 270f)
		{
			location.X -= sizeF_0.Width;
		}
		if (dlAngle >= 0f && dlAngle <= 180f)
		{
			location.Y -= sizeF_0.Height;
		}
		return new RectangleF(location, sizeF_0);
	}

	protected RectangleF method_13()
	{
		RectangleF rectangleF = class854_0[0].method_18();
		for (int i = 1; i < class854_0.Length; i++)
		{
			rectangleF = RectangleF.Union(rectangleF, class854_0[i].method_18());
		}
		return rectangleF;
	}

	protected void method_14(RectangleF rectangleF_0)
	{
		float num = this.float_2 / rectangleF_0.Width;
		float num2 = this.float_3 / rectangleF_0.Height;
		float num3 = rectangleF_0.X - float_0;
		float num4 = rectangleF_0.Y - float_1;
		Class854[] array = class854_0;
		foreach (Class854 @class in array)
		{
			float num5 = @class.method_8().X - num3;
			float float_ = @class.method_8().Y - num4;
			float float_2 = @class.method_8().Width * num;
			float float_3 = @class.method_8().Height * num2;
			float float_4 = @class.method_9() * num2;
			@class.method_11(num5, float_, float_2, float_3, float_4);
		}
	}

	[SpecialName]
	protected float method_15()
	{
		float num = 0f;
		for (int i = 0; i < float_6.Length && i < double_0.Length; i++)
		{
			if (float_6[i] > num)
			{
				num = float_6[i];
			}
		}
		return num;
	}

	[SpecialName]
	protected SizeF method_16()
	{
		float num = 1f + method_15();
		float width = float_2 / num;
		float height = float_3 / num * (1f - float_4);
		return new SizeF(width, height);
	}

	[SpecialName]
	protected SizeF method_17()
	{
		float num = method_15();
		float width = method_16().Width * num;
		float height = method_16().Height * num;
		return new SizeF(width, height);
	}

	[SpecialName]
	protected float method_18()
	{
		return float_3 / (1f + method_15()) * float_4;
	}

	protected virtual void vmethod_1()
	{
		double num = 0.0;
		double[] array = double_0;
		foreach (double num2 in array)
		{
			num += num2;
		}
		SizeF sizeF = method_16();
		SizeF sizeF2 = method_17();
		int num3 = float_6.Length - 1;
		method_15();
		ArrayList arrayList = new ArrayList();
		arrayList_0.Clear();
		int num4 = 0;
		int num5 = -1;
		int num6 = 0;
		double num7 = float_5;
		for (int j = 0; j < double_0.Length; j++)
		{
			double num8 = double_0[j];
			double num9 = num8 / num * 360.0;
			float num10 = float_6[num6];
			float num11 = float_6[num6];
			if (num10 > 0f)
			{
				SizeF sizeF3 = method_19((float)(num7 + num9 / 2.0), float_6[num6]);
				num10 = sizeF3.Width;
				num11 = sizeF3.Height;
			}
			Class854 @class = null;
			if (j == int_0)
			{
				@class = vmethod_3(float_0 + sizeF2.Width / 2f + num10, float_1 + sizeF2.Height / 2f + num11, sizeF.Width, sizeF.Height, method_18(), (float)(num7 % 360.0), (float)num9, color_0[num4], enum51_0, enum50_0, float_7);
			}
			else
			{
				Class831 class831_ = ((class830_0 == null || j >= class830_0.Count) ? null : class830_0.method_1(j));
				@class = vmethod_2(float_0 + sizeF2.Width / 2f + num10, float_1 + sizeF2.Height / 2f + num11, sizeF.Width, sizeF.Height, method_18(), (float)(num7 % 360.0), (float)num9, color_0[num4], enum51_0, enum50_0, float_7, class831_);
			}
			@class.Text = string_0[j];
			if (num5 <= -1 && (!(num7 <= 270.0) || !(num7 + num9 > 270.0)) && (!(num7 >= 270.0) || num7 + num9 <= 630.0))
			{
				arrayList.Add(@class);
				arrayList_0.Add(j);
			}
			else
			{
				num5++;
				arrayList.Insert(num5, @class);
				arrayList_0.Insert(num5, j);
			}
			if (num6 < num3)
			{
				num6++;
			}
			num4++;
			if (num4 >= color_0.Length)
			{
				num4 = 0;
			}
			num7 += num9;
			if (num7 > 360.0)
			{
				num7 -= 360.0;
			}
		}
		class854_0 = (Class854[])arrayList.ToArray(typeof(Class854));
	}

	protected virtual Class854 vmethod_2(float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, Color color_2, Enum51 enum51_1, Enum50 enum50_1, float float_15, Class831 class831_0)
	{
		return new Class854(float_8, float_9, float_10, float_11, float_12, float_13 % 360f, float_14, color_2, enum51_1, enum50_1, float_15, class831_0);
	}

	protected virtual Class854 vmethod_3(float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, Color color_2, Enum51 enum51_1, Enum50 enum50_1, float float_15)
	{
		Color color = Struct54.smethod_0(color_2, Struct54.float_0);
		return new Class854(float_8, float_9, float_10, float_11, float_12, float_13 % 360f, float_14, color, enum51_1, enum50_1, float_15);
	}

	protected SizeF method_19(float float_8, float float_9)
	{
		if (float_9 == 0f)
		{
			return SizeF.Empty;
		}
		float width = (float)((double)(method_16().Width * float_9 / 2f) * Math.Cos((double)float_8 * Math.PI / 180.0));
		float height = (float)((double)(method_16().Height * float_9 / 2f) * Math.Sin((double)float_8 * Math.PI / 180.0));
		return new SizeF(width, height);
	}

	protected void method_20(Interface42 interface42_0)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(class854_0);
		Class854 @class = null;
		if (class854_0[0].method_1() > 90f && class854_0[0].method_1() <= 270f && class854_0[0].method_1() + class854_0[0].method_2() > 450f)
		{
			@class = (Class854)arrayList[0];
			Class854[] array = @class.Split(0f);
			arrayList[0] = array[0];
			if (array[1].method_2() > 0f)
			{
				arrayList.Insert(1, array[1]);
			}
		}
		else if ((class854_0[0].method_1() > 270f && class854_0[0].method_1() + class854_0[0].method_2() > 450f) || (class854_0[0].method_1() < 90f && class854_0[0].method_1() + class854_0[0].method_2() > 270f))
		{
			@class = (Class854)arrayList[0];
			Class854[] array2 = @class.Split(180f);
			arrayList[0] = array2[1];
			if (array2[1].method_2() > 0f)
			{
				arrayList.Add(array2[0]);
			}
		}
		@class = (Class854)arrayList[0];
		@class.method_10(interface42_0);
		int num = 1;
		int num2 = arrayList.Count - 1;
		while (num < num2)
		{
			Class854 class2 = (Class854)arrayList[num2];
			float num3 = class2.method_1() - 90f;
			if (num3 > 180f || num3 < 0f)
			{
				num3 = 0f;
			}
			Class854 class3 = (Class854)arrayList[num];
			float num4 = (450f - class3.method_5()) % 360f;
			if (num4 > 180f || num4 < 0f)
			{
				num4 = 0f;
			}
			if (num4 >= num3)
			{
				class3.method_10(interface42_0);
				num++;
			}
			else if (num4 < num3)
			{
				class2.method_10(interface42_0);
				num2--;
			}
		}
		@class = (Class854)arrayList[num2];
		@class.method_10(interface42_0);
	}

	protected void method_21(Interface42 interface42_0)
	{
		Class854[] array = class854_0;
		foreach (Class854 @class in array)
		{
			@class.method_16(interface42_0);
		}
	}

	protected void method_22(Interface42 interface42_0)
	{
		Class854[] array = class854_0;
		foreach (Class854 @class in array)
		{
			@class.method_17(interface42_0);
		}
	}
}
