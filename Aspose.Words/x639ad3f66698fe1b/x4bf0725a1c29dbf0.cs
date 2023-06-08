using Aspose.Words;
using x556d8f9846e43329;
using x6c95d9cf46ff5f25;

namespace x639ad3f66698fe1b;

internal class x4bf0725a1c29dbf0
{
	private x4bf0725a1c29dbf0()
	{
	}

	internal static void x6210059f049f0d48(x21f0d20d41203be1 x0f7b23d1c393aed9, Border x14cf9593b86ecbaa)
	{
		if (x14cf9593b86ecbaa.IsVisible)
		{
			xf3de23fd492ab916(x0f7b23d1c393aed9, x14cf9593b86ecbaa);
		}
	}

	internal static void xf3de23fd492ab916(x21f0d20d41203be1 x0f7b23d1c393aed9, Border x14cf9593b86ecbaa)
	{
		xbfd162a6d47f59a4 xe1410f585439c7d = x0f7b23d1c393aed9.xe1410f585439c7d4;
		int num = 0;
		if (x14cf9593b86ecbaa.xbca512cb9f5a451a)
		{
			xe1410f585439c7d.x4d14ee33f46b5913("\\brdrart", xa0d3611565b2a1f2.xf89753ddd8c66e66(x14cf9593b86ecbaa.LineStyle));
			num = xa0d3611565b2a1f2.xdf0828e8d289b651(x14cf9593b86ecbaa.LineWidth);
		}
		else
		{
			xe1410f585439c7d.x4d14ee33f46b5913(x1cf55bf1c1c040ec.x4d0cb3d370d3a24f(x14cf9593b86ecbaa.LineStyle));
			num = x4574ea26106f0edb.x88bf16f2386d633e(x14cf9593b86ecbaa.LineWidth);
		}
		xe1410f585439c7d.x4d14ee33f46b5913("\\brdrw", num);
		xe1410f585439c7d.x4d14ee33f46b5913("\\brdrcf", x0f7b23d1c393aed9.xc15cf5804dbd5bbe(x14cf9593b86ecbaa.x63b1a7c31a962459));
		xe1410f585439c7d.x4d14ee33f46b5913("\\brsp", x4574ea26106f0edb.x88bf16f2386d633e(x14cf9593b86ecbaa.DistanceFromText));
		xe1410f585439c7d.xb8aea59edd4060ce("\\brdrframe", x14cf9593b86ecbaa.x227665e444fb500a);
		xe1410f585439c7d.xb8aea59edd4060ce("\\brdrsh", x14cf9593b86ecbaa.Shadow);
	}
}
