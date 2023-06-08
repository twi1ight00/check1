using System.Drawing;
using ns235;

namespace ns259;

internal class Class6406 : Interface295
{
	private Class6410 class6410_0;

	private Class6410 class6410_1;

	private Class6410 class6410_2;

	internal Class6410 ControlPoint1
	{
		get
		{
			return class6410_0;
		}
		set
		{
			class6410_0 = value;
		}
	}

	internal Class6410 ControlPoint2
	{
		get
		{
			return class6410_1;
		}
		set
		{
			class6410_1 = value;
		}
	}

	internal Class6410 EndPoint
	{
		get
		{
			return class6410_2;
		}
		set
		{
			class6410_2 = value;
		}
	}

	internal Class6406(Class6410[] pathPoints)
	{
		if (pathPoints.Length > 0)
		{
			ControlPoint1 = ((pathPoints[0] != null) ? pathPoints[0] : new Class6410());
		}
		if (pathPoints.Length > 1)
		{
			ControlPoint2 = ((pathPoints[1] != null) ? pathPoints[1] : new Class6410());
		}
		if (pathPoints.Length > 2)
		{
			EndPoint = ((pathPoints[2] != null) ? pathPoints[2] : new Class6410());
		}
	}

	public void imethod_0(Interface296 context, Class6218 figure)
	{
		PointF cubP = context.imethod_0(ControlPoint1);
		PointF cubP2 = context.imethod_0(ControlPoint2);
		PointF pointF = context.imethod_0(EndPoint);
		Class6222 node = new Class6222(context.CurrentPoint, cubP, cubP2, pointF);
		figure.Add(node);
		context.CurrentPoint = pointF;
	}
}
