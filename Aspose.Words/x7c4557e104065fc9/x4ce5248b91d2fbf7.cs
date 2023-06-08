using Aspose.Words;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x7c4557e104065fc9;

internal class x4ce5248b91d2fbf7
{
	private x4ce5248b91d2fbf7()
	{
	}

	internal static void x6392b9ac6bc562f4(string x250224921a47c2f5, xedac08b4826d3056 xf9eaf76facf8149b, Shading x12b7f8e5698b30a6)
	{
		if (x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "background"))
		{
			xd83a7c48d5e4bbe3(xf9eaf76facf8149b, x12b7f8e5698b30a6);
		}
		else if (x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "background-color"))
		{
			x515aae5f695c6606(xf9eaf76facf8149b, x12b7f8e5698b30a6);
		}
		else if (!x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "background-image") && !x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "background-repeat") && !x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "background-attachment"))
		{
			x0d299f323d241756.x90637a473b1ceaaa(x250224921a47c2f5, "background-position");
		}
	}

	private static void xd83a7c48d5e4bbe3(xedac08b4826d3056 xf9eaf76facf8149b, Shading x12b7f8e5698b30a6)
	{
		x1e40528755c1f053 x73cad9ab753bf0fa = xf9eaf76facf8149b.x73cad9ab753bf0fa;
		if (x73cad9ab753bf0fa == x1e40528755c1f053.xf8569aac1192e1a0)
		{
			x0a4437fb7b6e1adb x0a4437fb7b6e1adb = xf9eaf76facf8149b.xae38dac157c088d7();
			{
				foreach (xedac08b4826d3056 item in x0a4437fb7b6e1adb)
				{
					xd83a7c48d5e4bbe3(item, x12b7f8e5698b30a6);
				}
				return;
			}
		}
		x515aae5f695c6606(xf9eaf76facf8149b, x12b7f8e5698b30a6);
	}

	private static bool x515aae5f695c6606(xedac08b4826d3056 xf9eaf76facf8149b, Shading x12b7f8e5698b30a6)
	{
		x1e40528755c1f053 x73cad9ab753bf0fa = xf9eaf76facf8149b.x73cad9ab753bf0fa;
		if (x73cad9ab753bf0fa == x1e40528755c1f053.x9b41425268471380)
		{
			x12b7f8e5698b30a6.Texture = TextureIndex.TextureNone;
			x12b7f8e5698b30a6.x0e18178ac4b2272f = xf9eaf76facf8149b.xef50a938c8b9c7fd();
			return true;
		}
		return false;
	}

	internal static void xdd58192800f83cee(Shading x12b7f8e5698b30a6, xa3fc7dcdc8182ff6 x44ecfea61c937b8e)
	{
		if (x12b7f8e5698b30a6 != null && x12b7f8e5698b30a6.xa853df7acdb217c8)
		{
			x44ecfea61c937b8e.xf4868abd18f579a7("background-color", x11c1a563debd033a(x12b7f8e5698b30a6));
		}
	}

	private static x26d9ecb4bdf0456d x11c1a563debd033a(Shading x12b7f8e5698b30a6)
	{
		switch (x12b7f8e5698b30a6.Texture)
		{
		case TextureIndex.TextureNone:
		case TextureIndex.TextureNil:
			return x12b7f8e5698b30a6.x0e18178ac4b2272f;
		case TextureIndex.TextureSolid:
			return x12b7f8e5698b30a6.xc290f60df004e384;
		default:
		{
			double x607a3f96d060de = xb7dbd7bb3ed97d5b.x73ef7a6dac3d681b(x12b7f8e5698b30a6.Texture);
			x26d9ecb4bdf0456d x60a2487f840b534c = (x12b7f8e5698b30a6.x0e18178ac4b2272f.x7149c962c02931b3 ? x26d9ecb4bdf0456d.x8f02f53f1587477d : x12b7f8e5698b30a6.x0e18178ac4b2272f);
			return xb7dbd7bb3ed97d5b.x87e2b03b45effe52(x12b7f8e5698b30a6.xc290f60df004e384, x60a2487f840b534c, x607a3f96d060de);
		}
		}
	}
}
