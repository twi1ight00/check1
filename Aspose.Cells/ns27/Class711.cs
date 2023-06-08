using Aspose.Cells.Charts;
using ns7;

namespace ns27;

internal class Class711 : Class538
{
	internal Class711()
	{
		method_2(4159);
		method_0(2);
		byte_0 = new byte[2];
		byte_0[0] = 1;
	}

	internal void method_4(ChartType chartType_0, Class1387 class1387_0)
	{
		switch (chartType_0)
		{
		case ChartType.SurfaceWireframe3D:
		case ChartType.SurfaceContourWireframe:
			byte_0[0] = 0;
			break;
		}
		if (class1387_0.method_22())
		{
			byte_0[0] |= 2;
		}
	}
}
