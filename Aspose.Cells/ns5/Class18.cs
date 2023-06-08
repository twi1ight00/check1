using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Cells.Drawing;
using ns19;

namespace ns5;

internal class Class18 : IDisposable
{
	protected Interface42 interface42_0;

	protected bool bool_0;

	protected float float_0;

	protected float float_1;

	protected Class898 class898_0;

	protected float float_2;

	protected float float_3;

	protected float float_4;

	internal Class18()
	{
	}

	internal Class18(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
	{
		float_2 = 0f;
		interface42_0 = interface42_1;
		class898_0 = class898_1;
		float_0 = float_5;
		float_1 = float_6;
		float_3 = float_0;
		float_4 = float_1;
		switch (class898_0.AutoShapeType)
		{
		case AutoShapeType.NotPrimitive:
			if (class898_0.Rotation == 270)
			{
				method_0(180);
			}
			else
			{
				method_0(class898_1.Rotation);
			}
			return;
		case AutoShapeType.DownRibbon:
			if (!class898_0.method_18())
			{
				class898_0.Rotation += 180;
				method_0(class898_0.Rotation);
			}
			else if (class898_0.Rotation > 0)
			{
				method_0(class898_0.Rotation);
			}
			return;
		case AutoShapeType.UpRibbon:
			if (class898_0.method_18())
			{
				class898_0.Rotation += 180;
				method_0(class898_0.Rotation);
			}
			else if (class898_0.Rotation > 0)
			{
				method_0(class898_0.Rotation);
			}
			return;
		case AutoShapeType.Line:
		case AutoShapeType.StraightConnector:
			if (class898_0.Height <= class898_0.Line.Weight)
			{
				method_0(class898_0.Rotation);
			}
			else if (class898_0.Width <= class898_0.Line.Weight)
			{
				interface42_0.imethod_58(method_2(class898_0));
			}
			else
			{
				method_0(class898_0.Rotation);
			}
			return;
		case AutoShapeType.BentConnector2:
		case AutoShapeType.ElbowConnector:
		case AutoShapeType.BentConnector4:
		case AutoShapeType.BentConnector5:
		case AutoShapeType.CurvedConnector2:
		case AutoShapeType.CurvedConnector:
		case AutoShapeType.CurvedConnector4:
		case AutoShapeType.CurvedConnector5:
			interface42_0.imethod_58(smethod_0(class898_0));
			return;
		}
		if (class898_0.Rotation > 0)
		{
			if (!class898_0.bool_3 && !class898_0.bool_5)
			{
				interface42_0.imethod_58(method_1(class898_0));
			}
			else
			{
				method_0(class898_1.Rotation);
			}
		}
	}

	internal virtual GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		return new GraphicsPath();
	}

	internal virtual void vmethod_1(Interface42 interface42_1, float float_5, float float_6, float float_7, float float_8)
	{
		RectangleF rectangleF_ = new RectangleF(float_5, float_6, float_7, float_8);
		GraphicsPath graphicsPath_ = vmethod_0(rectangleF_);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		SmoothingMode smoothingMode_ = interface42_1.imethod_54();
		if (class898_0.Line.Weight >= 2f)
		{
			interface42_1.imethod_55(SmoothingMode.AntiAlias);
			interface42_1.imethod_55(SmoothingMode.HighQuality);
		}
		interface42_1.imethod_18(pen_, graphicsPath_);
		interface42_1.imethod_55(smoothingMode_);
	}

	internal virtual void vmethod_2(Interface42 interface42_1, float float_5, float float_6, float float_7, float float_8)
	{
		RectangleF rectangleF_ = new RectangleF(float_5, float_6, float_7, float_8);
		GraphicsPath graphicsPath_ = vmethod_0(rectangleF_);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath_);
		SmoothingMode smoothingMode_ = interface42_1.imethod_54();
		interface42_1.imethod_55(SmoothingMode.AntiAlias);
		interface42_1.imethod_33(brush_, graphicsPath_);
		interface42_1.imethod_55(smoothingMode_);
	}

	internal virtual void vmethod_3()
	{
		new RectangleF(float_0, float_1, class898_0.method_7().Width, class898_0.method_7().Height);
		if (!class898_0.Fill.method_0())
		{
			vmethod_2(interface42_0, float_0, float_1, class898_0.method_7().Width, class898_0.method_7().Height);
		}
		if (!class898_0.Line.method_0())
		{
			vmethod_1(interface42_0, float_0, float_1, class898_0.method_7().Width, class898_0.method_7().Height);
		}
		vmethod_4();
	}

	internal virtual void vmethod_4()
	{
		interface42_0.ResetTransform();
		RectangleF rectangleF_ = class898_0.method_7();
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		float num = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin;
		rectangleF_.Width -= (float)class898_0.TextFrame.RightMargin;
		rectangleF_.Height -= (float)class898_0.TextFrame.BottomMargin;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}

	private void method_0(int int_0)
	{
		RectangleF rectangleF = new RectangleF(float_0, float_1, class898_0.method_7().Width, class898_0.method_7().Height);
		PointF pointF = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Y + rectangleF.Height / 2f);
		interface42_0.imethod_49(pointF.X, pointF.Y);
		interface42_0.imethod_45(int_0);
		interface42_0.imethod_49(0f - pointF.X, 0f - pointF.Y);
	}

	private Matrix method_1(Class898 class898_1)
	{
		Matrix matrix = new Matrix();
		int rotation = class898_1.Rotation;
		Math.Abs(class898_1.Width - class898_1.Height);
		float x;
		float y;
		if ((rotation >= 45 && rotation < 135) || (rotation >= 225 && rotation < 315))
		{
			x = class898_1.Y + class898_1.Height / 2f;
			y = class898_1.X + class898_1.Width / 2f;
		}
		else
		{
			x = class898_1.X + class898_1.Width / 2f;
			y = class898_1.Y + class898_1.Height / 2f;
		}
		matrix.RotateAt(rotation, new PointF(x, y));
		if ((rotation >= 45 && rotation < 135) || (rotation >= 225 && rotation < 315))
		{
			matrix.Translate(class898_1.Height / 2f - class898_1.Width / 2f, class898_1.Width / 2f - class898_1.Height / 2f);
		}
		return matrix;
	}

	internal static Matrix smethod_0(Class898 class898_1)
	{
		float num = 0f;
		float num2 = 0f;
		if ((class898_1.Rotation >= 45 && class898_1.Rotation < 135) || (class898_1.Rotation >= 225 && class898_1.Rotation < 315))
		{
			num = class898_1.Y + class898_1.Height / 2f;
			num2 = class898_1.X + class898_1.Width / 2f;
		}
		else
		{
			num = class898_1.X + class898_1.Width / 2f;
			num2 = class898_1.Y + class898_1.Height / 2f;
		}
		Matrix matrix = new Matrix((!class898_1.method_20()) ? 1 : (-1), 0f, 0f, (!class898_1.method_18()) ? 1 : (-1), class898_1.method_20() ? (num * 2f) : 0f, class898_1.method_18() ? (num2 * 2f) : 0f);
		matrix.RotateAt((class898_1.method_20() ^ class898_1.method_18()) ? (-class898_1.Rotation) : class898_1.Rotation, new PointF(num, num2));
		if ((class898_1.Rotation >= 45 && class898_1.Rotation < 135) || (class898_1.Rotation >= 225 && class898_1.Rotation < 315))
		{
			matrix.Translate(class898_1.Height / 2f - class898_1.Width / 2f, class898_1.Width / 2f - class898_1.Height / 2f);
		}
		return matrix;
	}

	private Matrix method_2(Class898 class898_1)
	{
		return new Matrix((!class898_1.method_20()) ? 1 : (-1), 0f, 0f, (!class898_1.method_18()) ? 1 : (-1), class898_1.method_20() ? class898_1.method_22().Width : 0f, class898_1.method_18() ? class898_1.method_22().Height : 0f);
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
			bool_0 = true;
		}
	}

	~Class18()
	{
		Dispose(bool_1: true);
	}
}
