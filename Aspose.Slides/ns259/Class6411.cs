using System.Drawing;
using ns235;

namespace ns259;

internal class Class6411 : Interface295
{
	private Class6410 class6410_0;

	private Class6410 class6410_1;

	internal Class6410 ControlPoint
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

	internal Class6410 EndPoint
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

	internal Class6411(Class6410[] pathPoints)
	{
		if (pathPoints.Length > 0)
		{
			ControlPoint = ((pathPoints[0] != null) ? pathPoints[0] : new Class6410());
		}
		if (pathPoints.Length > 1)
		{
			EndPoint = ((pathPoints[1] != null) ? pathPoints[1] : new Class6410());
		}
	}

	public void imethod_0(Interface296 context, Class6218 figure)
	{
		PointF quadP = context.imethod_0(ControlPoint);
		PointF pointF = context.imethod_0(EndPoint);
		Class6222 node = new Class6222(context.CurrentPoint, quadP, pointF);
		figure.Add(node);
		context.CurrentPoint = pointF;
	}
}
