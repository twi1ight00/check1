using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns19;
using ns22;
using ns3;
using ns31;

namespace ns32;

internal class Class818 : IDisposable
{
	protected float float_0;

	protected float float_1;

	protected float float_2;

	protected float float_3;

	protected float float_4;

	protected float float_5;

	protected Class819[] class819_0;

	protected ArrayList arrayList_0 = new ArrayList();

	protected double[] double_0 = new double[0];

	protected Class795 class795_0;

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

	protected Enum48 enum48_0 = Enum48.const_1;

	protected float float_7 = 1f;

	protected Enum49 enum49_0;

	protected bool bool_0;

	protected int int_0 = -1;

	private bool bool_1;

	public double[] Values
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Font Font
	{
		set
		{
			font_0 = value;
		}
	}

	public Color ForeColor
	{
		set
		{
			color_1 = value;
		}
	}

	public float Width => float_2;

	public float Height => float_3;

	public float X => float_0;

	public float Y => float_1;

	protected Class818()
	{
	}

	public Class818(float float_8, float float_9, float float_10, float float_11, double[] double_1)
		: this()
	{
		float_0 = float_8;
		float_1 = float_9;
		float_2 = float_10;
		float_3 = float_11;
		Values = double_1;
	}

	public Class818(float float_8, float float_9, float float_10, float float_11, double[] double_1, float float_12)
		: this(float_8, float_9, float_10, float_11, double_1)
	{
		float_4 = float_12;
	}

	public Class818(float float_8, float float_9, float float_10, float float_11, double[] double_1, Color[] color_2, float float_12)
		: this(float_8, float_9, float_10, float_11, double_1, float_12)
	{
		color_0 = color_2;
	}

	public Class818(float float_8, float float_9, float float_10, float float_11, double[] double_1, Color[] color_2, float float_12, string[] string_1)
		: this(float_8, float_9, float_10, float_11, double_1, color_2, float_12)
	{
		string_0 = string_1;
	}

	public Class818(float float_8, float float_9, float float_10, float float_11, double[] double_1, Color[] color_2, float float_12, string[] string_1, Class795 class795_1)
		: this(float_8, float_9, float_10, float_11, double_1, color_2, float_12, string_1)
	{
		class795_0 = class795_1;
	}

	~Class818()
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
			Class819[] array = class819_0;
			foreach (Class819 @class in array)
			{
				@class.Dispose();
			}
		}
		bool_1 = true;
	}

	[SpecialName]
	public Class795 method_0()
	{
		return class795_0;
	}

	[SpecialName]
	public void method_1(float[] float_8)
	{
		float_6 = float_8;
	}

	[SpecialName]
	public void method_2(float float_8)
	{
		float_5 = float_8 % 360f;
		if (float_5 < 0f)
		{
			float_5 += 360f;
		}
	}

	[SpecialName]
	internal Class819[] method_3()
	{
		return class819_0;
	}

	internal void method_4(Class810 class810_0)
	{
		Class795 @class = class810_0.method_10();
		int rotation = class810_0.Chart.Rotation;
		method_2(rotation - 90);
		float[] array = new float[@class.Count];
		for (int i = 0; i < @class.Count; i++)
		{
			array[i] = @class[i].Explosion / 100f;
		}
		method_1(array);
		Class798 class2 = class810_0.method_3();
		Font = class2.method_0().Font;
		ForeColor = class2.method_0().FontColor;
		vmethod_1();
		if (bool_0)
		{
			RectangleF rectangleF_ = method_11();
			method_12(rectangleF_);
		}
	}

	public void Draw(Interface42 interface42_0)
	{
		method_19(interface42_0);
		if (float_4 > 0f)
		{
			method_18(interface42_0);
		}
		method_20(interface42_0);
	}

	public virtual void vmethod_0(Interface42 interface42_0)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		Class787 chart = class795_0.Chart;
		double num = 0.0;
		double[] array = double_0;
		foreach (double num2 in array)
		{
			num += num2;
		}
		GraphicsPath graphicsPath_ = method_10();
		RectangleF rectangleF_ = Class1181.smethod_1(graphicsPath_);
		Class819[] array2 = class819_0;
		foreach (Class819 @class in array2)
		{
			if (@class == null || @class.Text.Length < 1)
			{
				continue;
			}
			Class796 class2 = @class.method_14();
			Class810 class3 = class2.method_1().method_0();
			Class798 class4 = class2.method_6();
			double num3 = ((num != 0.0) ? (Math.Abs(class2.YValue) / num) : 0.01);
			float num4 = (chart.method_8().imethod_0() ? ((!class4.method_0().method_2().IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f)) : ((!class4.method_0().method_2().IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f)));
			float num5 = chart.Height;
			SizeF sizeF = Struct35.smethod_38(interface42_0, chart.method_7(), class3.Index, class2.Index, num3, num4, num5, 0.0);
			RectangleF empty = RectangleF.Empty;
			PointF pointF_;
			float dlAngle;
			switch (class4.vmethod_0())
			{
			case Enum74.const_9:
			{
				int offAngel = 0;
				float num7 = (float)Math.Sin((double)chart.Elevation * Math.PI / 180.0);
				if (!class4.method_0().imethod_0())
				{
					offAngel = class4.method_0().X;
				}
				float num8 = 0f;
				if (!class4.method_0().vmethod_2())
				{
					num8 = (float)class4.method_0().Y / 500f;
				}
				pointF_ = @class.vmethod_1(0.5f + num8 / 2f, offAngel, out dlAngle);
				method_6(@class, ref pointF_, dlAngle, sizeF);
				float num9 = X + Width / 2f;
				float num10 = Y + Height / 2f;
				pointF_.X -= num9;
				pointF_.Y -= num10;
				PointF pointF = method_5(@class, sizeF);
				pointF.X -= num9;
				pointF.Y -= num10;
				pointF_.X = pointF.X + (pointF_.X - pointF.X) * num7;
				if (class4.method_0().Y < 0 && float_6[@class.method_14().Index] == 0f)
				{
					if (pointF_.Y < 0f)
					{
						pointF_.Y -= @class.method_4() * num7;
					}
					else
					{
						pointF_.Y += @class.method_4() * num7;
					}
				}
				pointF_.X += num9;
				pointF_.Y += num10;
				break;
			}
			case Enum74.const_1:
				pointF_ = @class.vmethod_0(0.25f, out dlAngle);
				pointF_.X -= sizeF.Width / 2f;
				pointF_.Y -= sizeF.Height / 2f;
				break;
			default:
				pointF_ = @class.vmethod_0(0.5f, out dlAngle);
				method_6(@class, ref pointF_, dlAngle, sizeF);
				break;
			case Enum74.const_3:
			{
				pointF_ = @class.vmethod_0(0.5f, out dlAngle);
				double num6 = (double)dlAngle * Math.PI / 180.0;
				if (dlAngle > 270f || dlAngle < 90f)
				{
					pointF_.X -= (float)((double)sizeF.Width * Math.Cos(num6));
				}
				if (dlAngle > 0f && dlAngle < 180f)
				{
					pointF_.Y -= (float)((double)sizeF.Height * Math.Sin(num6));
				}
				break;
			}
			}
			empty = new RectangleF(pointF_, sizeF);
			Struct35.smethod_39(interface42_0, chart, class3.Index, class2.Index, num3, empty, 0.0);
			if (class2.method_1().method_0().HasLeaderLines && class4.vmethod_0() == Enum74.const_9)
			{
				PointF pointF_2 = @class.vmethod_0(0.5f, out dlAngle);
				if (dlAngle >= 0f && dlAngle <= 180f)
				{
					pointF_2.Y += @class.method_4();
				}
				method_7(interface42_0, rectangleF_, @class, class2.method_1().method_0().method_15(), empty, pointF_2);
			}
		}
	}

	private PointF method_5(Class819 class819_1, SizeF sizeF_0)
	{
		float dlAngle;
		PointF pointF_ = class819_1.vmethod_0(0.5f, out dlAngle);
		method_6(class819_1, ref pointF_, dlAngle, sizeF_0);
		return pointF_;
	}

	private void method_6(Class819 class819_1, ref PointF pointF_0, float float_8, SizeF sizeF_0)
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
			pointF_0.Y += class819_1.method_4();
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

	private void method_7(Interface42 interface42_0, RectangleF rectangleF_0, Class819 class819_1, Class806 class806_0, RectangleF rectangleF_1, PointF pointF_0)
	{
		float num = class819_1.method_3().Width / 2f * 0.05f;
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
		PointF pt2 = new PointF(rectangleF_1.Left, rectangleF_1.Top + rectangleF_1.Height / 2f);
		PointF pt3 = new PointF(rectangleF_1.Left + rectangleF_1.Width / 2f, rectangleF_1.Top);
		PointF pt4 = new PointF(rectangleF_1.Right, rectangleF_1.Top + rectangleF_1.Height / 2f);
		PointF pt5 = new PointF(rectangleF_1.Left + rectangleF_1.Width / 2f, rectangleF_1.Bottom);
		int num2 = method_9(pointF_0, rectangleF_1);
		using Pen pen = Struct29.smethod_5(class806_0);
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF empty = PointF.Empty;
		switch (num2)
		{
		case 1:
			empty = new PointF(pt4.X + num, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath7 = new GraphicsPath();
				graphicsPath7.AddLine(pt4, empty);
				graphicsPath7.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath7);
				graphicsPath7.Dispose();
			}
			break;
		case 2:
			empty = new PointF(pt4.X + num, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath8 = new GraphicsPath();
				graphicsPath8.AddLine(pt4, empty);
				graphicsPath8.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath8);
				graphicsPath8.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + num);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath9 = new GraphicsPath();
				graphicsPath9.AddLine(pt5, empty);
				graphicsPath9.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath9);
				graphicsPath9.Dispose();
			}
			break;
		case 3:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + num);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddLine(pt5, empty);
				graphicsPath6.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath6);
				graphicsPath6.Dispose();
			}
			break;
		case 4:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - num, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.X >= pointF_0.X)
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
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.Y <= pointF_0.Y)
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
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath10 = new GraphicsPath();
				graphicsPath10.AddLine(pt2, empty);
				graphicsPath10.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath10);
				graphicsPath10.Dispose();
			}
			break;
		case 6:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - num, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(pt2, empty);
				graphicsPath4.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath4);
				graphicsPath4.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - num);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddLine(pt3, empty);
				graphicsPath5.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath5);
				graphicsPath5.Dispose();
			}
			break;
		case 7:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - num);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath11 = new GraphicsPath();
				graphicsPath11.AddLine(pt3, empty);
				graphicsPath11.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath11);
				graphicsPath11.Dispose();
			}
			break;
		case 8:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt4.X + num, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.X <= pointF_0.X)
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
			graphicsPath.Widen(pen);
			if (method_8(interface42_0, graphicsPath) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddLine(pt3, empty);
				graphicsPath3.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath3);
				graphicsPath3.Dispose();
			}
			break;
		}
	}

	private bool method_8(Interface42 interface42_0, GraphicsPath graphicsPath_0)
	{
		Class819[] array = class819_0;
		foreach (Class819 @class in array)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(@class.method_3().X, @class.method_3().Y, @class.method_3().Width, @class.method_3().Height, @class.method_0(), @class.method_1());
			using (Region region = new Region(graphicsPath_0))
			{
				region.Intersect(graphicsPath);
				if (!interface42_0.imethod_0().imethod_1(region))
				{
					return false;
				}
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPie(@class.method_3().X, @class.method_3().Y + @class.method_4(), @class.method_3().Width, @class.method_3().Height, @class.method_0(), @class.method_1());
			using Region region2 = new Region(graphicsPath_0);
			region2.Intersect(graphicsPath2);
			if (!interface42_0.imethod_0().imethod_1(region2))
			{
				return false;
			}
		}
		return true;
	}

	private int method_9(PointF pointF_0, RectangleF rectangleF_0)
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

	private GraphicsPath method_10()
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		Class819[] array = class819_0;
		foreach (Class819 @class in array)
		{
			graphicsPath.AddPie(@class.method_3().X, @class.method_3().Y, @class.method_3().Width, @class.method_3().Height, @class.method_0(), @class.method_1());
			graphicsPath.AddPie(@class.method_3().X, @class.method_3().Y + @class.method_4(), @class.method_3().Width, @class.method_3().Height, @class.method_0(), @class.method_1());
		}
		return graphicsPath;
	}

	protected RectangleF method_11()
	{
		RectangleF rectangleF = class819_0[0].method_13();
		for (int i = 1; i < class819_0.Length; i++)
		{
			rectangleF = RectangleF.Union(rectangleF, class819_0[i].method_13());
		}
		return rectangleF;
	}

	protected void method_12(RectangleF rectangleF_0)
	{
		float num = this.float_2 / rectangleF_0.Width;
		float num2 = this.float_3 / rectangleF_0.Height;
		float num3 = rectangleF_0.X - float_0;
		float num4 = rectangleF_0.Y - float_1;
		Class819[] array = class819_0;
		foreach (Class819 @class in array)
		{
			float num5 = @class.method_3().X - num3;
			float num6 = @class.method_3().Y - num4;
			float float_ = @class.method_3().Width * num;
			float float_2 = @class.method_3().Height * num2;
			float float_3 = @class.method_4() * num2;
			@class.method_6(num5, num6, float_, float_2, float_3);
		}
	}

	[SpecialName]
	protected float method_13()
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
	protected SizeF method_14()
	{
		float num = 1f + method_13();
		float width = float_2 / num;
		float height = float_3 / num * (1f - float_4);
		return new SizeF(width, height);
	}

	[SpecialName]
	protected SizeF method_15()
	{
		float num = method_13();
		float width = method_14().Width * num;
		float height = method_14().Height * num;
		return new SizeF(width, height);
	}

	[SpecialName]
	protected float method_16()
	{
		return float_3 / (1f + method_13()) * float_4;
	}

	protected virtual void vmethod_1()
	{
		double num = 0.0;
		double[] array = double_0;
		foreach (double num2 in array)
		{
			num += num2;
		}
		SizeF sizeF = method_14();
		SizeF sizeF2 = method_15();
		int num3 = float_6.Length - 1;
		method_13();
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
			if (num == 0.0)
			{
				num9 = 0.0;
			}
			float num10 = float_6[num6];
			float num11 = float_6[num6];
			if (num10 > 0f)
			{
				SizeF sizeF3 = method_17((float)(num7 + num9 / 2.0), float_6[num6]);
				num10 = sizeF3.Width;
				num11 = sizeF3.Height;
			}
			Class819 @class = null;
			if (j == int_0)
			{
				Class796 class796_ = ((class795_0 == null || j >= class795_0.Count) ? null : class795_0.method_1(j));
				@class = vmethod_3(float_0 + sizeF2.Width / 2f + num10, float_1 + sizeF2.Height / 2f + num11, sizeF.Width, sizeF.Height, method_16(), (float)(num7 % 360.0), (float)num9, color_0[num4], enum49_0, enum48_0, float_7, class796_);
			}
			else
			{
				Class796 class796_2 = ((class795_0 == null || j >= class795_0.Count) ? null : class795_0.method_1(j));
				@class = vmethod_2(float_0 + sizeF2.Width / 2f + num10, float_1 + sizeF2.Height / 2f + num11, sizeF.Width, sizeF.Height, method_16(), (float)(num7 % 360.0), (float)num9, color_0[num4], enum49_0, enum48_0, float_7, class796_2);
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
		class819_0 = (Class819[])arrayList.ToArray(typeof(Class819));
	}

	protected virtual Class819 vmethod_2(float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, Color color_2, Enum49 enum49_1, Enum48 enum48_1, float float_15, Class796 class796_0)
	{
		return new Class819(float_8, float_9, float_10, float_11, float_12, float_13 % 360f, float_14, color_2, enum49_1, enum48_1, float_15, class796_0);
	}

	protected virtual Class819 vmethod_3(float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, Color color_2, Enum49 enum49_1, Enum48 enum48_1, float float_15, Class796 class796_0)
	{
		Color color = Struct30.smethod_0(color_2, Struct30.float_0);
		Class819 @class = new Class819(float_8, float_9, float_10, float_11, float_12, float_13 % 360f, float_14, color, enum49_1, enum48_1, float_15);
		@class.method_15(class796_0);
		return @class;
	}

	protected SizeF method_17(float float_8, float float_9)
	{
		if (float_9 == 0f)
		{
			return SizeF.Empty;
		}
		float width = (float)((double)(method_14().Width * float_9 / 2f) * Math.Cos((double)float_8 * Math.PI / 180.0));
		float height = (float)((double)(method_14().Height * float_9 / 2f) * Math.Sin((double)float_8 * Math.PI / 180.0));
		return new SizeF(width, height);
	}

	protected void method_18(Interface42 interface42_0)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(class819_0);
		Class819 @class = null;
		if (class819_0[0].method_0() > 90f && class819_0[0].method_0() <= 270f && class819_0[0].method_0() + class819_0[0].method_1() > 450f)
		{
			@class = (Class819)arrayList[0];
			Class819[] array = @class.Split(0f);
			arrayList[0] = array[0];
			if (array[1].method_1() > 0f)
			{
				arrayList.Insert(1, array[1]);
			}
		}
		else if ((class819_0[0].method_0() > 270f && class819_0[0].method_0() + class819_0[0].method_1() > 450f) || (class819_0[0].method_0() < 90f && class819_0[0].method_0() + class819_0[0].method_1() > 270f))
		{
			@class = (Class819)arrayList[0];
			Class819[] array2 = @class.Split(180f);
			arrayList[0] = array2[1];
			if (array2[1].method_1() > 0f)
			{
				arrayList.Add(array2[0]);
			}
		}
		@class = (Class819)arrayList[0];
		@class.method_5(interface42_0);
		int num = 1;
		int num2 = arrayList.Count - 1;
		while (num < num2)
		{
			Class819 class2 = (Class819)arrayList[num2];
			float num3 = class2.method_0() - 90f;
			if (num3 > 180f || num3 < 0f)
			{
				num3 = 0f;
			}
			Class819 class3 = (Class819)arrayList[num];
			float num4 = (450f - class3.method_2()) % 360f;
			if (num4 > 180f || num4 < 0f)
			{
				num4 = 0f;
			}
			if (num4 >= num3)
			{
				class3.method_5(interface42_0);
				num++;
			}
			else if (num4 < num3)
			{
				class2.method_5(interface42_0);
				num2--;
			}
		}
		@class = (Class819)arrayList[num2];
		@class.method_5(interface42_0);
	}

	protected void method_19(Interface42 interface42_0)
	{
		Class819[] array = class819_0;
		foreach (Class819 @class in array)
		{
			@class.method_11(interface42_0);
		}
	}

	protected void method_20(Interface42 interface42_0)
	{
		Class819[] array = class819_0;
		foreach (Class819 @class in array)
		{
			@class.method_12(interface42_0);
		}
	}
}
