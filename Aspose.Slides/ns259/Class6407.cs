using System.Drawing;
using ns235;

namespace ns259;

internal class Class6407 : Interface295
{
	private Class6410 class6410_0;

	internal Class6410 Point
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

	public Class6407()
	{
	}

	public Class6407(Class6410 point)
	{
		class6410_0 = point;
	}

	public void imethod_0(Interface296 context, Class6218 figure)
	{
		PointF pointF = context.imethod_0(class6410_0);
		figure.method_2(context.CurrentPoint, pointF);
		context.CurrentPoint = pointF;
	}
}
