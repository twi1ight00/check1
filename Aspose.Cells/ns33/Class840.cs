using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns3;
using ns34;

namespace ns33;

internal class Class840 : ICloneable, Interface25
{
	private Class821 class821_0;

	private Enum57 enum57_0;

	private Color color_0;

	private Class839 class839_0;

	private Enum71 enum71_0;

	private bool bool_0;

	private bool bool_1 = true;

	private Class857 class857_0;

	private bool bool_2 = true;

	public Color Color
	{
		get
		{
			if (enum71_0 == Enum71.const_0)
			{
				return Color.Empty;
			}
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Interface24 LineStyle => class839_0;

	public Enum71 Formatting
	{
		get
		{
			return enum71_0;
		}
		set
		{
			if (value != Enum71.const_3)
			{
				class857_0 = null;
			}
			enum71_0 = value;
		}
	}

	public Interface35 GradientFill
	{
		get
		{
			if (class857_0 == null)
			{
				class857_0 = new Class857();
				Formatting = Enum71.const_3;
			}
			return class857_0;
		}
	}

	internal Class821 Chart => class821_0;

	public bool IsVisible
	{
		get
		{
			if (enum71_0 == Enum71.const_0)
			{
				return false;
			}
			return true;
		}
	}

	internal int Width
	{
		get
		{
			if (Formatting == Enum71.const_0)
			{
				return 0;
			}
			int num = Struct63.smethod_4(class839_0.Width);
			if (num < 1)
			{
				num = 1;
			}
			return num;
		}
	}

	internal Class840(Class821 class821_1, Enum57 enum57_1)
	{
		enum71_0 = Enum71.const_1;
		class821_0 = class821_1;
		enum57_0 = enum57_1;
		color_0 = Color.Empty;
		class839_0 = new Class839();
		bool_0 = false;
	}

	[SpecialName]
	public Class839 method_0()
	{
		return class839_0;
	}

	[SpecialName]
	public void method_1(Class839 class839_1)
	{
		class839_0 = class839_1;
	}

	[SpecialName]
	internal Class857 method_2()
	{
		return class857_0;
	}

	[SpecialName]
	internal void method_3(Class857 class857_1)
	{
		class857_0 = class857_1;
	}

	public bool method_4(Class840 class840_0)
	{
		if (IsVisible != class840_0.IsVisible)
		{
			return false;
		}
		if (IsVisible && class840_0.IsVisible)
		{
			if (Formatting != class840_0.Formatting)
			{
				return false;
			}
			if (Formatting == Enum71.const_3)
			{
				if (!method_2().method_4(class840_0.method_2()))
				{
					return false;
				}
			}
			else
			{
				if (!Color.Equals(class840_0.Color))
				{
					return false;
				}
				if (!class839_0.method_0(class840_0.method_0()))
				{
					return false;
				}
			}
		}
		return true;
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_1;
	}

	[SpecialName]
	public void imethod_0(bool bool_3)
	{
		bool_1 = bool_3;
	}

	internal void method_5(Color color_1)
	{
		if ((bool_1 && enum71_0 != 0) || enum71_0 == Enum71.const_1)
		{
			Color = color_1;
		}
	}

	internal void method_6()
	{
		if (!bool_2 || !bool_1)
		{
			return;
		}
		switch (enum57_0)
		{
		case Enum57.const_3:
			if (class821_0.imethod_7() <= 32)
			{
				color_0 = class821_0.method_16().method_0().method_2("tx1");
				color_0 = class821_0.method_16().method_0().method_6(color_0, 0.5);
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class821_0.imethod_7() <= 40)
			{
				color_0 = class821_0.method_16().method_0().method_2("dk1");
				color_0 = class821_0.method_16().method_0().method_6(color_0, 0.5);
				color_0 = Color.FromArgb(255, color_0);
			}
			else
			{
				color_0 = class821_0.method_16().method_0().method_2("dk1");
				color_0 = class821_0.method_16().method_0().method_6(color_0, 0.9);
				color_0 = Color.FromArgb(255, color_0);
			}
			break;
		case Enum57.const_6:
			color_0 = Color.Empty;
			break;
		case Enum57.const_0:
		case Enum57.const_2:
		case Enum57.const_4:
		case Enum57.const_5:
		case Enum57.const_13:
			if (class821_0.imethod_7() <= 32)
			{
				color_0 = class821_0.method_16().method_0().method_2("tx1");
				color_0 = class821_0.method_16().method_0().method_6(color_0, 0.75);
				color_0 = Color.FromArgb(255, color_0);
			}
			else
			{
				color_0 = class821_0.method_16().method_0().method_2("dk1");
				color_0 = class821_0.method_16().method_0().method_6(color_0, 0.75);
				color_0 = Color.FromArgb(255, color_0);
			}
			break;
		case Enum57.const_1:
		case Enum57.const_10:
		case Enum57.const_11:
		case Enum57.const_12:
		case Enum57.const_14:
		case Enum57.const_15:
			color_0 = Color.Empty;
			break;
		case Enum57.const_16:
		case Enum57.const_17:
			if (class821_0.imethod_7() <= 16)
			{
				color_0 = class821_0.method_16().method_0().method_2("tx1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class821_0.imethod_7() <= 32)
			{
				color_0 = Color.Empty;
			}
			else if (class821_0.imethod_7() <= 34)
			{
				color_0 = class821_0.method_16().method_0().method_2("dk1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class821_0.imethod_7() <= 40)
			{
				int num = class821_0.imethod_7() - 34;
				color_0 = class821_0.method_16().method_0().method_2("accent" + num);
				color_0 = class821_0.method_16().method_0().method_7(color_0, 0.25);
				color_0 = Color.FromArgb(255, color_0);
			}
			else
			{
				color_0 = Color.Empty;
			}
			break;
		case Enum57.const_18:
		case Enum57.const_19:
		case Enum57.const_20:
		case Enum57.const_21:
		case Enum57.const_22:
		case Enum57.const_23:
			if (class821_0.imethod_7() <= 32)
			{
				color_0 = class821_0.method_16().method_0().method_2("tx1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class821_0.imethod_7() <= 34)
			{
				color_0 = class821_0.method_16().method_0().method_2("dk1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else if (class821_0.imethod_7() <= 40)
			{
				color_0 = class821_0.method_16().method_0().method_2("dk1");
				color_0 = Color.FromArgb(255, color_0);
			}
			else
			{
				color_0 = class821_0.method_16().method_0().method_2("lt1");
				color_0 = Color.FromArgb(255, color_0);
			}
			break;
		}
		bool_2 = false;
	}

	public object Clone()
	{
		Class840 @class = new Class840(class821_0, enum57_0);
		method_6();
		@class.Color = Color;
		@class.imethod_0(vmethod_0());
		@class.method_1((Class839)method_0().Clone());
		@class.Formatting = Formatting;
		@class.method_3(class857_0);
		return @class;
	}

	internal void method_7(float float_0, float float_1, float float_2, float float_3)
	{
		method_8(new PointF(float_0, float_1), new PointF(float_2, float_3));
	}

	internal void method_8(PointF pointF_0, PointF pointF_1)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(pointF_0, pointF_1);
		method_11(graphicsPath);
	}

	internal void method_9(Rectangle rectangle_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		method_10(rectangleF_);
	}

	internal void method_10(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF_0);
		method_11(graphicsPath);
	}

	internal void method_11(GraphicsPath graphicsPath_0)
	{
		method_6();
		if (method_17())
		{
			GraphicsPath graphicsPath_ = (GraphicsPath)graphicsPath_0.Clone();
			Pen pen = method_12(graphicsPath_0);
			class821_0.imethod_0().imethod_18(pen, graphicsPath_);
			pen.Dispose();
		}
	}

	internal Pen method_12(GraphicsPath graphicsPath_0)
	{
		method_6();
		if (!method_17())
		{
			return new Pen(Color.Empty);
		}
		Pen pen = method_13();
		Enum71 formatting = Formatting;
		if (formatting == Enum71.const_3)
		{
			if (GradientFill != null)
			{
				Brush brush = method_2().method_1(graphicsPath_0, pen, bool_0: false, 1f);
				Pen pen2 = new Pen(brush, Width);
				method_14(pen2);
				return pen2;
			}
			return pen;
		}
		return pen;
	}

	private Pen method_13()
	{
		if (!method_17())
		{
			return new Pen(Color.Empty);
		}
		Pen pen = (pen = new Pen(Color, Width));
		method_14(pen);
		return pen;
	}

	private void method_14(Pen pen_0)
	{
		Class839 @class = method_0();
		pen_0.DashCap = DashCap.Round;
		switch (@class.DashStyle)
		{
		case Enum79.const_0:
			pen_0.DashStyle = DashStyle.Custom;
			pen_0.DashPattern = new float[2] { 4f, 3f };
			break;
		case Enum79.const_1:
			pen_0.DashStyle = DashStyle.Custom;
			pen_0.DashPattern = new float[4] { 4f, 3f, 1f, 3f };
			break;
		case Enum79.const_2:
			pen_0.DashStyle = DashStyle.Custom;
			pen_0.DashPattern = new float[2] { 8f, 3f };
			break;
		case Enum79.const_3:
			pen_0.DashStyle = DashStyle.Custom;
			pen_0.DashPattern = new float[4] { 8f, 3f, 1f, 3f };
			break;
		case Enum79.const_4:
			pen_0.DashStyle = DashStyle.Custom;
			pen_0.DashPattern = new float[6] { 8f, 3f, 1f, 3f, 1f, 3f };
			break;
		case Enum79.const_5:
			pen_0.DashStyle = DashStyle.Dot;
			pen_0.DashCap = DashCap.Round;
			break;
		case Enum79.const_6:
			pen_0.DashStyle = DashStyle.Solid;
			break;
		case Enum79.const_7:
			pen_0.DashStyle = DashStyle.Custom;
			pen_0.DashPattern = new float[2] { 3f, 1f };
			break;
		}
		switch (@class.vmethod_0())
		{
		case Enum78.const_1:
			pen_0.CompoundArray = new float[6]
			{
				0f,
				1f / 6f,
				1f / 3f,
				2f / 3f,
				5f / 6f,
				1f
			};
			break;
		case Enum78.const_2:
			pen_0.CompoundArray = new float[4] { 0f, 0.2f, 0.4f, 1f };
			break;
		case Enum78.const_3:
			pen_0.CompoundArray = new float[4] { 0f, 0.6f, 0.8f, 1f };
			break;
		case Enum78.const_4:
			pen_0.CompoundArray = new float[4]
			{
				0f,
				1f / 3f,
				2f / 3f,
				1f
			};
			break;
		}
		method_15(pen_0, @class);
	}

	private void method_15(Pen pen_0, Class839 class839_1)
	{
		if (class839_1.vmethod_3() != 0)
		{
			method_16(pen_0, class839_1.vmethod_3(), class839_1.vmethod_4(), class839_1.vmethod_5(), bool_3: true);
		}
		if (class839_1.vmethod_6() != 0)
		{
			method_16(pen_0, class839_1.vmethod_6(), class839_1.vmethod_7(), class839_1.vmethod_8(), bool_3: false);
		}
	}

	private void method_16(Pen pen_0, Enum59 enum59_0, Enum60 enum60_0, Enum58 enum58_0, bool bool_3)
	{
		float num = 0f;
		float num2 = 0f;
		num = enum60_0 switch
		{
			Enum60.const_0 => 2f, 
			Enum60.const_1 => 3f, 
			_ => 5f, 
		};
		num2 = enum58_0 switch
		{
			Enum58.const_0 => 2f, 
			Enum58.const_1 => 3f, 
			_ => 5f, 
		};
		switch (enum59_0)
		{
		case Enum59.const_1:
		{
			AdjustableArrowCap adjustableArrowCap = new AdjustableArrowCap(num, num2);
			if (bool_3)
			{
				pen_0.CustomStartCap = adjustableArrowCap;
			}
			else
			{
				pen_0.CustomEndCap = adjustableArrowCap;
			}
			break;
		}
		case Enum59.const_2:
		{
			AdjustableArrowCap adjustableArrowCap = new AdjustableArrowCap(num, num2);
			adjustableArrowCap.MiddleInset = 0.9f;
			if (bool_3)
			{
				pen_0.CustomStartCap = adjustableArrowCap;
			}
			else
			{
				pen_0.CustomEndCap = adjustableArrowCap;
			}
			break;
		}
		case Enum59.const_3:
			if (bool_3)
			{
				pen_0.StartCap = LineCap.DiamondAnchor;
			}
			else
			{
				pen_0.EndCap = LineCap.DiamondAnchor;
			}
			break;
		case Enum59.const_4:
			if (bool_3)
			{
				pen_0.StartCap = LineCap.RoundAnchor;
			}
			else
			{
				pen_0.EndCap = LineCap.RoundAnchor;
			}
			break;
		case Enum59.const_5:
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(new PointF(num / 2f, 0f - num2), new PointF(0f, 0f));
			graphicsPath.AddLine(new PointF((0f - num) / 2f, 0f - num2), new PointF(0f, 0f));
			CustomLineCap customLineCap = new CustomLineCap(null, graphicsPath);
			customLineCap.BaseCap = LineCap.Flat;
			customLineCap.StrokeJoin = LineJoin.Round;
			customLineCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
			if (bool_3)
			{
				pen_0.CustomStartCap = customLineCap;
			}
			else
			{
				pen_0.CustomEndCap = customLineCap;
			}
			break;
		}
		}
	}

	internal bool method_17()
	{
		if (!IsVisible)
		{
			return false;
		}
		if (Width <= 0)
		{
			return false;
		}
		if (!Color.IsEmpty && Color.A != 0)
		{
			return true;
		}
		return false;
	}
}
