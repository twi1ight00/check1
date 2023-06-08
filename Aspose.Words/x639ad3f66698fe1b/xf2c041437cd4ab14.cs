using Aspose.Words;
using x28925c9b27b37a46;
using x556d8f9846e43329;

namespace x639ad3f66698fe1b;

internal class xf2c041437cd4ab14
{
	private xf2c041437cd4ab14()
	{
	}

	internal static void x6210059f049f0d48(x21f0d20d41203be1 x0f7b23d1c393aed9, Shading x12b7f8e5698b30a6, string x165d27091131dfeb, string xb0387128afe33eb1, string x241c74cdf100fcb8, string x32f5c378eac679b1)
	{
		if (!x12b7f8e5698b30a6.xa853df7acdb217c8)
		{
			return;
		}
		xbfd162a6d47f59a4 xe1410f585439c7d = x0f7b23d1c393aed9.xe1410f585439c7d4;
		switch (x12b7f8e5698b30a6.Texture)
		{
		case TextureIndex.TextureNone:
		case TextureIndex.TextureNil:
			xe1410f585439c7d.x4d14ee33f46b5913(x241c74cdf100fcb8, x0f7b23d1c393aed9.xc15cf5804dbd5bbe(x12b7f8e5698b30a6.xc290f60df004e384), 0);
			xe1410f585439c7d.x4d14ee33f46b5913(xb0387128afe33eb1, x0f7b23d1c393aed9.xc15cf5804dbd5bbe(x12b7f8e5698b30a6.x0e18178ac4b2272f));
			return;
		case TextureIndex.TextureSolid:
			xe1410f585439c7d.x4d14ee33f46b5913(x165d27091131dfeb, 10000);
			xe1410f585439c7d.x4d14ee33f46b5913(xb0387128afe33eb1, x0f7b23d1c393aed9.xc15cf5804dbd5bbe(x12b7f8e5698b30a6.x0e18178ac4b2272f), 0);
			xe1410f585439c7d.x4d14ee33f46b5913(x241c74cdf100fcb8, x0f7b23d1c393aed9.xc15cf5804dbd5bbe(x12b7f8e5698b30a6.xc290f60df004e384));
			return;
		}
		double xbcea506a33cf = xb7dbd7bb3ed97d5b.x73ef7a6dac3d681b(x12b7f8e5698b30a6.Texture);
		if (x32f5c378eac679b1 == null)
		{
			xe1410f585439c7d.x4d14ee33f46b5913(x165d27091131dfeb, xa0d3611565b2a1f2.x030d4b7389328010(xbcea506a33cf));
		}
		else
		{
			xe1410f585439c7d.x4d14ee33f46b5913(x32f5c378eac679b1);
		}
		xe1410f585439c7d.x4d14ee33f46b5913(xb0387128afe33eb1, x0f7b23d1c393aed9.xc15cf5804dbd5bbe(x12b7f8e5698b30a6.x0e18178ac4b2272f));
		xe1410f585439c7d.x4d14ee33f46b5913(x241c74cdf100fcb8, x0f7b23d1c393aed9.xc15cf5804dbd5bbe(x12b7f8e5698b30a6.xc290f60df004e384));
	}
}
