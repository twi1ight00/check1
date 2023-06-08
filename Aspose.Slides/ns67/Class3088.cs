using System.Drawing;
using ns135;
using ns138;

namespace ns67;

internal sealed class Class3088 : Interface138, Interface139
{
	private readonly Class3062 class3062_0;

	private PointF pointF_0;

	public Class3088(Class3062 path)
	{
		class3062_0 = path;
	}

	public void imethod_0(Class4614 moveTo)
	{
		class3062_0.method_11();
		pointF_0.X = (float)moveTo.X;
		pointF_0.Y = (float)moveTo.Y;
	}

	public void imethod_1(Class4613 lineTo)
	{
		float num = (float)lineTo.X;
		float num2 = (float)lineTo.Y;
		class3062_0.method_4(pointF_0.X, pointF_0.Y, num, num2);
		pointF_0.X = num;
		pointF_0.Y = num2;
	}

	public void imethod_2(Class4612 curveTo)
	{
		float num = (float)curveTo.X3;
		float num2 = (float)curveTo.Y3;
		class3062_0.method_6(pointF_0.X, pointF_0.Y, (float)curveTo.X1, (float)curveTo.Y1, (float)curveTo.X2, (float)curveTo.Y2, num, num2);
		pointF_0.X = num;
		pointF_0.Y = num2;
	}

	public void imethod_3()
	{
		class3062_0.method_11();
	}
}
