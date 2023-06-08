using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Cells.Drawing;
using ns19;
using ns5;

namespace ns6;

internal class Class160 : IDisposable
{
	protected Interface42 interface42_0;

	protected bool bool_0;

	protected float float_0;

	protected float float_1;

	protected Class913 class913_0;

	protected float float_2;

	protected float float_3;

	protected float float_4;

	internal Class160()
	{
	}

	internal Class160(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
	{
		float_2 = 0f;
		interface42_0 = interface42_1;
		class913_0 = class913_1;
		float_0 = float_5;
		float_1 = float_6;
		float_3 = float_0;
		float_4 = float_1;
		switch (class913_0.AutoShapeType)
		{
		case AutoShapeType.DownRibbon:
			if (!class913_0.method_21())
			{
				class913_0.Rotation += 180;
				method_1(class913_0.Rotation);
			}
			else if (class913_0.Rotation > 0)
			{
				method_1(class913_0.Rotation);
			}
			return;
		case AutoShapeType.UpRibbon:
			if (class913_0.method_21())
			{
				class913_0.Rotation += 180;
				method_1(class913_0.Rotation);
			}
			else if (class913_0.Rotation > 0)
			{
				method_1(class913_0.Rotation);
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
			interface42_0.imethod_58(method_2(class913_0));
			return;
		case AutoShapeType.Line:
		case AutoShapeType.StraightConnector:
			return;
		}
		if (class913_0.Rotation > 0)
		{
			if (!class913_0.bool_4 && !class913_0.bool_6)
			{
				interface42_0.imethod_58(method_0(class913_0));
			}
			else
			{
				method_1(class913_1.Rotation);
			}
		}
	}

	private Matrix method_0(Class913 class913_1)
	{
		Matrix matrix = new Matrix();
		int rotation = class913_1.Rotation;
		float x;
		float y;
		if ((rotation >= 45 && rotation < 135) || (rotation >= 225 && rotation < 315))
		{
			x = class913_1.Y + class913_1.Height / 2f;
			y = class913_1.X + class913_1.Width / 2f;
		}
		else
		{
			x = class913_1.X + class913_1.Width / 2f;
			y = class913_1.Y + class913_1.Height / 2f;
		}
		matrix.RotateAt(rotation, new PointF(x, y));
		if ((rotation >= 45 && rotation < 135) || (rotation >= 225 && rotation < 315))
		{
			matrix.Translate(class913_1.Height / 2f - class913_1.Width / 2f, class913_1.Width / 2f - class913_1.Height / 2f);
		}
		return matrix;
	}

	internal virtual GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		return new GraphicsPath();
	}

	internal virtual void vmethod_1(Interface42 interface42_1, float float_5, float float_6, float float_7, float float_8)
	{
		RectangleF rectangleF_ = new RectangleF(float_5, float_6, float_7, float_8);
		GraphicsPath graphicsPath = vmethod_0(rectangleF_);
		class913_0.method_7(graphicsPath);
		SmoothingMode smoothingMode_ = interface42_1.imethod_54();
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		if (class913_0.Line.Weight >= 2f)
		{
			interface42_1.imethod_55(SmoothingMode.AntiAlias);
			interface42_1.imethod_55(SmoothingMode.HighQuality);
		}
		interface42_1.imethod_18(pen_, graphicsPath);
		interface42_1.imethod_55(smoothingMode_);
	}

	internal virtual void vmethod_2(Interface42 interface42_1, float float_5, float float_6, float float_7, float float_8)
	{
		RectangleF rectangleF_ = new RectangleF(float_5, float_6, float_7, float_8);
		GraphicsPath graphicsPath_ = vmethod_0(rectangleF_);
		SmoothingMode smoothingMode_ = interface42_1.imethod_54();
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath_);
		interface42_1.imethod_55(SmoothingMode.AntiAlias);
		interface42_1.imethod_33(brush_, graphicsPath_);
		interface42_1.imethod_55(smoothingMode_);
	}

	internal virtual void vmethod_3()
	{
		new RectangleF(float_0, float_1, class913_0.method_8().Width, class913_0.method_8().Height);
		if (!class913_0.Fill.method_0())
		{
			vmethod_2(interface42_0, float_0, float_1, class913_0.method_8().Width, class913_0.method_8().Height);
		}
		if (!class913_0.Line.method_0())
		{
			vmethod_1(interface42_0, float_0, float_1, class913_0.method_8().Width, class913_0.method_8().Height);
		}
		vmethod_4();
	}

	internal virtual void vmethod_4()
	{
		RectangleF rectangleF_ = class913_0.method_8();
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		float num = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		if (rectangleF_.Height < (float)class913_0.Font.Height)
		{
			float num2 = ((float)class913_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class913_0.Font.Height);
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}

	private void method_1(int int_0)
	{
		RectangleF rectangleF = new RectangleF(float_0, float_1, class913_0.method_8().Width, class913_0.method_8().Height);
		PointF pointF = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Y + rectangleF.Height / 2f);
		interface42_0.imethod_49(pointF.X, pointF.Y);
		interface42_0.imethod_45(int_0);
		interface42_0.imethod_49(0f - pointF.X, 0f - pointF.Y);
	}

	internal Matrix method_2(Class913 class913_1)
	{
		float num;
		float num2;
		if ((class913_1.Rotation >= 45 && class913_1.Rotation < 135) || (class913_1.Rotation >= 225 && class913_1.Rotation < 315))
		{
			num = class913_1.Y + class913_1.Height / 2f;
			num2 = class913_1.X + class913_1.Width / 2f;
		}
		else
		{
			num = class913_1.X + class913_1.Width / 2f;
			num2 = class913_1.Y + class913_1.Height / 2f;
		}
		Matrix matrix = new Matrix((!class913_1.method_23()) ? 1 : (-1), 0f, 0f, (!class913_1.method_21()) ? 1 : (-1), class913_1.method_23() ? (num * 2f) : 0f, class913_1.method_21() ? (num2 * 2f) : 0f);
		matrix.RotateAt((class913_1.method_23() ^ class913_1.method_21()) ? (-class913_1.Rotation) : class913_1.Rotation, new PointF(num, num2));
		if ((class913_1.Rotation >= 45 && class913_1.Rotation < 135) || (class913_1.Rotation >= 225 && class913_1.Rotation < 315))
		{
			if (!class913_1.bool_6 && !class913_1.bool_4)
			{
				matrix.Translate(class913_1.Height / 2f - class913_1.Width / 2f, class913_1.Width / 2f - class913_1.Height / 2f);
			}
			else if (class913_1.Rotation == 270 && !class913_1.method_21() && !class913_1.method_23())
			{
				matrix.Translate(class913_1.Height / 2f - class913_1.Width / 2f, class913_1.X + class913_1.Width / 2f);
			}
		}
		return matrix;
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

	~Class160()
	{
		Dispose(bool_1: true);
	}
}
