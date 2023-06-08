using System.Drawing;

namespace ns67;

internal sealed class Class3444 : Class3443
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	public double WidthRadius
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

	public double HeightRadius
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

	public double StartAngle
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

	public double SwingAngle
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

	public Class3444(double widthRadius, double heightRadius, double startAngle, double swingAngle)
	{
		StartAngle = startAngle;
		HeightRadius = heightRadius;
		WidthRadius = widthRadius;
		SwingAngle = swingAngle;
	}

	public override Class3443 vmethod_0()
	{
		return new Class3444(double_1, double_0, double_2, double_3);
	}

	internal override Struct159 vmethod_1(Class3062 dest, Struct159 startingPoint)
	{
		if (double_1 == 0.0 && double_0 == 0.0)
		{
			return new Struct159(startingPoint.X, startingPoint.Y);
		}
		PointF pointF = dest.method_8(startingPoint.X, startingPoint.Y, double_1, double_0, double_2 / 60000.0, double_3 / 60000.0);
		return new Struct159(pointF.X, pointF.Y);
	}
}
