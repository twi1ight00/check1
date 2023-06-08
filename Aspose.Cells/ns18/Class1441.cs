using System.Drawing;

namespace ns18;

internal class Class1441
{
	private int int_0;

	private PointF pointF_0;

	internal Class1441(int int_1, PointF pointF_1)
	{
		int_0 = int_1;
		pointF_0 = pointF_1;
	}

	internal void method_0(Class1446 class1446_0)
	{
		class1446_0.Write("[{0} /XYZ {1} 0]", Class1446.smethod_6(int_0), Class1446.smethod_2(pointF_0));
	}
}
