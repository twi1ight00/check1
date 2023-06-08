using System.Drawing;
using System.Drawing.Drawing2D;
using ns218;
using ns224;
using ns252;

namespace ns263;

internal class Class6478
{
	private double double_0;

	private double double_1 = 1.0;

	private double double_2 = 1.0;

	private Class6002 class6002_0 = new Class6002();

	private Class6002 class6002_1 = new Class6002();

	private Class6473 class6473_0;

	private Class6473 class6473_1;

	private double double_3 = 1.0;

	private double double_4 = 1.0;

	public double AccumulatedXScale
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

	public double AccumulatedYScale
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double AccumulatedHorizontalFlip
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

	public double AccumulatedVerticalFlip
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

	public double AccumulatedAngle
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

	public Class6473 OriginalTransform
	{
		get
		{
			if (class6473_0 == null)
			{
				class6473_0 = new Class6473();
			}
			return class6473_0;
		}
		set
		{
			class6473_0 = value;
		}
	}

	public Class6473 Transform
	{
		get
		{
			if (class6473_1 == null)
			{
				class6473_1 = new Class6473();
			}
			return class6473_1;
		}
		set
		{
			class6473_1 = value;
		}
	}

	public Class6002 GroupFitMatrix
	{
		get
		{
			return class6002_1;
		}
		set
		{
			class6002_1 = value;
		}
	}

	public Class6002 RotateFlipMatrix
	{
		get
		{
			return class6002_0;
		}
		set
		{
			class6002_0 = value;
		}
	}

	public Class6478()
		: this(new Class6473())
	{
	}

	private Class6478(Class6473 transform)
	{
		OriginalTransform = transform;
		Transform = transform.Clone();
	}

	public Class6002 method_0()
	{
		PointF centerPoint = OriginalTransform.CenterPoint;
		PointF centerPoint2 = Transform.CenterPoint;
		centerPoint2 = RotateFlipMatrix.method_2(centerPoint2);
		Class6002 @class = new Class6002();
		@class.method_8(centerPoint2.X - centerPoint.X, centerPoint2.Y - centerPoint.Y);
		float x = OriginalTransform.OriginalCenterPoint.X;
		float y = OriginalTransform.OriginalCenterPoint.Y;
		@class.method_8(centerPoint.X - x, centerPoint.Y - y);
		return @class;
	}

	public Class6002 method_1()
	{
		Class6002 @class = new Class6002();
		float x = OriginalTransform.OriginalCenterPoint.X;
		float y = OriginalTransform.OriginalCenterPoint.Y;
		@class.method_7(0f - x, 0f - y, MatrixOrder.Append);
		@class.method_5((float)AccumulatedXScale, (float)AccumulatedYScale, MatrixOrder.Append);
		@class.method_5((float)AccumulatedHorizontalFlip, (float)AccumulatedVerticalFlip, MatrixOrder.Append);
		@class.method_11((float)Class5963.smethod_1(AccumulatedAngle), MatrixOrder.Append);
		@class.method_7(x, y, MatrixOrder.Append);
		return @class;
	}

	public Class6478 method_2(Class6473 transform)
	{
		Class6478 @class = new Class6478(transform);
		@class.method_4(this);
		@class.method_3(this);
		@class.method_6();
		@class.method_5(this);
		return @class;
	}

	private void method_3(Class6478 previousStage)
	{
		if (smethod_0(OriginalTransform.Rotation))
		{
			AccumulatedXScale = previousStage.AccumulatedYScale * (double)OriginalTransform.XScale;
			AccumulatedYScale = previousStage.AccumulatedXScale * (double)OriginalTransform.YScale;
		}
		else
		{
			AccumulatedXScale = previousStage.AccumulatedXScale * (double)OriginalTransform.XScale;
			AccumulatedYScale = previousStage.AccumulatedYScale * (double)OriginalTransform.YScale;
		}
	}

	private void method_4(Class6478 previousStage)
	{
		PointF centerPoint = Transform.CenterPoint;
		PointF pointF = previousStage.GroupFitMatrix.method_2(centerPoint);
		Transform.vmethod_4(pointF.X - centerPoint.X, pointF.Y - centerPoint.Y);
		if (smethod_0(OriginalTransform.Rotation))
		{
			Transform.vmethod_3(previousStage.AccumulatedYScale, previousStage.AccumulatedXScale);
		}
		else
		{
			Transform.vmethod_3(previousStage.AccumulatedXScale, previousStage.AccumulatedYScale);
		}
	}

	public static bool smethod_0(Class6323 angle)
	{
		double valueInDegrees = angle.ValueInDegrees;
		if (valueInDegrees >= 45.0 && !(valueInDegrees >= 135.0))
		{
			return true;
		}
		if (valueInDegrees >= 225.0)
		{
			return valueInDegrees < 315.0;
		}
		return false;
	}

	private void method_5(Class6478 previousStage)
	{
		Class6002 tx = Transform.vmethod_2();
		RotateFlipMatrix = previousStage.RotateFlipMatrix.Clone();
		RotateFlipMatrix.method_9(tx, MatrixOrder.Prepend);
		AccumulatedAngle = previousStage.AccumulatedAngle + OriginalTransform.Rotation.ValueInRadians;
		AccumulatedHorizontalFlip = previousStage.AccumulatedHorizontalFlip * (OriginalTransform.HorizontalFlip ? (-1.0) : 1.0);
		AccumulatedVerticalFlip = previousStage.AccumulatedVerticalFlip * (OriginalTransform.VerticalFlip ? (-1.0) : 1.0);
	}

	private void method_6()
	{
		if (Transform is Class6474 @class)
		{
			Class6474 class2 = (Class6474)OriginalTransform;
			float offsetX = @class.ChildrenCenterPoint.X - class2.ChildrenCenterPoint.X;
			float offsetY = @class.ChildrenCenterPoint.Y - class2.ChildrenCenterPoint.Y;
			GroupFitMatrix = @class.method_1(AccumulatedXScale, AccumulatedYScale);
			GroupFitMatrix.method_7(offsetX, offsetY, MatrixOrder.Prepend);
			@class.method_4();
		}
	}
}
