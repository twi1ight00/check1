using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns252;

namespace ns263;

internal class Class6473
{
	private bool bool_0;

	private double double_0;

	private Class6323 class6323_0 = new Class6323();

	private bool bool_1;

	private double double_1;

	private double double_2;

	private double double_3;

	public bool HorizontalFlip
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool VerticalFlip
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

	public Class6323 Rotation
	{
		get
		{
			return class6323_0;
		}
		set
		{
			class6323_0 = value;
		}
	}

	public double Width
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double Length
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

	public double X
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double Y
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public PointF TopLeft
	{
		get
		{
			return new PointF((float)X, (float)Y);
		}
		set
		{
			X = value.X;
			Y = value.Y;
		}
	}

	public RectangleF BoundingBox => new RectangleF((float)X, (float)Y, (float)Width, (float)Length);

	public virtual PointF OriginalCenterPoint => new PointF((float)(Width / 2.0), (float)(Length / 2.0));

	public virtual PointF CenterPoint => new PointF((float)(X + Width / 2.0), (float)(Y + Length / 2.0));

	public virtual float XScale => 1f;

	public virtual float YScale => 1f;

	public virtual double XOffset => X;

	public virtual double YOffset => Y;

	public SizeF method_0()
	{
		return new SizeF((float)Width, (float)Length);
	}

	public virtual Class6002 vmethod_0()
	{
		return new Class6002(1f, 0f, 0f, 1f, (float)X, (float)Y);
	}

	public virtual Class6002 vmethod_1()
	{
		Class6002 @class = vmethod_0();
		Class6002 tx = vmethod_2();
		@class.method_9(tx, MatrixOrder.Append);
		return @class;
	}

	public virtual Class6002 vmethod_2()
	{
		PointF centerPoint = CenterPoint;
		Class6002 @class = new Class6002();
		@class.method_7(0f - centerPoint.X, 0f - centerPoint.Y, MatrixOrder.Append);
		float scaleX = (HorizontalFlip ? (-1f) : 1f);
		float scaleY = (VerticalFlip ? (-1f) : 1f);
		@class.method_5(scaleX, scaleY, MatrixOrder.Append);
		@class.method_11((float)Rotation.ValueInDegrees, MatrixOrder.Append);
		@class.method_7(centerPoint.X, centerPoint.Y, MatrixOrder.Append);
		return @class;
	}

	public virtual void vmethod_3(double xscale, double yscale)
	{
		Class6002 @class = new Class6002();
		PointF centerPoint = CenterPoint;
		@class.method_7(0f - centerPoint.X, 0f - centerPoint.Y, MatrixOrder.Append);
		@class.method_5((float)xscale, (float)yscale, MatrixOrder.Append);
		@class.method_7(centerPoint.X, centerPoint.Y, MatrixOrder.Append);
		TopLeft = @class.method_2(TopLeft);
		double_1 *= xscale;
		double_0 *= yscale;
	}

	public virtual void vmethod_4(float dx, float dy)
	{
		double_2 += dx;
		double_3 += dy;
	}

	public virtual Class6473 Clone()
	{
		Class6473 @class = new Class6473();
		CopyTo(@class);
		return @class;
	}

	protected void CopyTo(Class6473 target)
	{
		target.bool_0 = bool_0;
		target.double_0 = double_0;
		target.class6323_0 = class6323_0;
		target.bool_1 = bool_1;
		target.double_1 = double_1;
		target.double_2 = double_2;
		target.double_3 = double_3;
	}
}
