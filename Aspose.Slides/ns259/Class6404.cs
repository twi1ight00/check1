using System;
using System.Drawing;
using ns218;
using ns235;

namespace ns259;

internal class Class6404 : Interface295
{
	private Class6403 class6403_0;

	private Class6402 class6402_0;

	private Class6402 class6402_1;

	private Class6403 class6403_1;

	internal Class6403 HeightRadius
	{
		get
		{
			return class6403_0;
		}
		set
		{
			class6403_0 = value;
		}
	}

	internal Class6403 WidthRadius
	{
		get
		{
			return class6403_1;
		}
		set
		{
			class6403_1 = value;
		}
	}

	internal Class6402 StartAngle
	{
		get
		{
			return class6402_0;
		}
		set
		{
			class6402_0 = value;
		}
	}

	internal Class6402 SwingAngle
	{
		get
		{
			return class6402_1;
		}
		set
		{
			class6402_1 = value;
		}
	}

	public void imethod_0(Interface296 context, Class6218 figure)
	{
		if (!(Math.Abs(HeightRadius.method_0(context.GuideValueProvider)) < 1.0) && Math.Abs(WidthRadius.method_0(context.GuideValueProvider)) >= 1.0)
		{
			double num = StartAngle.method_1(context.GuideValueProvider);
			double radians = SwingAngle.method_1(context.GuideValueProvider);
			PointF currentPoint = context.CurrentPoint;
			double num2 = context.imethod_1(HeightRadius, isXCoordinate: false);
			double num3 = context.imethod_1(WidthRadius, isXCoordinate: true);
			double num4 = Math.Atan2(1.0 / num2 * Math.Sin(num), 1.0 / num3 * Math.Cos(num));
			double num5 = (double)currentPoint.X - num3 * Math.Cos(num4);
			double num6 = (double)currentPoint.Y - num2 * Math.Sin(num4);
			double num7 = num5 - num3;
			double num8 = num6 - num2;
			RectangleF bounds = new RectangleF((float)num7, (float)num8, (float)(num3 * 2.0), (float)(num2 * 2.0));
			Class6173 @class = new Class6173(bounds, Class5963.smethod_1(num), Class5963.smethod_1(radians));
			figure.method_5(@class);
			context.CurrentPoint = @class.method_1();
		}
	}
}
