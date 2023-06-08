using System.Drawing;
using ns235;

namespace ns259;

internal class Class6408 : Interface295
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

	public Class6408()
	{
	}

	public Class6408(Class6410 point)
	{
		class6410_0 = point;
	}

	public void imethod_0(Interface296 context, Class6218 figure)
	{
		PointF currentPoint = context.imethod_0(class6410_0);
		context.CurrentPoint = currentPoint;
	}
}
