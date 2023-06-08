using System.IO;
using Aspose.Words;
using x5794c252ba25e723;
using xf989f31a236ff98c;

namespace xa604c4d210ae0581;

internal class x075263c82f5cad54
{
	internal const int x9e9c4f35f59e39a8 = 2;

	internal const int xdc9d8b5df2c0fcda = 10;

	internal static Shading x002fafae3e338912(BinaryReader xe134235b3526fa75, Shading x12b7f8e5698b30a6)
	{
		if (x12b7f8e5698b30a6 == null)
		{
			x12b7f8e5698b30a6 = new Shading();
		}
		int num = xe134235b3526fa75.ReadUInt16();
		x12b7f8e5698b30a6.xc290f60df004e384 = x195cb055715b526e.x5ab07bb8554e00d9((x88d38775104122b8)(num & 0x1F));
		x12b7f8e5698b30a6.x0e18178ac4b2272f = x195cb055715b526e.x5ab07bb8554e00d9((x88d38775104122b8)((num & 0x3E0) >> 5));
		x12b7f8e5698b30a6.Texture = (TextureIndex)((num & 0xFC00) >> 10);
		return x12b7f8e5698b30a6;
	}

	internal static Shading x9b448ca00ed9c929(BinaryReader xe134235b3526fa75, Shading x12b7f8e5698b30a6)
	{
		if (x12b7f8e5698b30a6 == null)
		{
			x12b7f8e5698b30a6 = new Shading();
		}
		x12b7f8e5698b30a6.xc290f60df004e384 = x195cb055715b526e.xfa7086ee0c6b6330(xe134235b3526fa75.ReadInt32());
		x12b7f8e5698b30a6.x0e18178ac4b2272f = x195cb055715b526e.xfa7086ee0c6b6330(xe134235b3526fa75.ReadInt32());
		x12b7f8e5698b30a6.Texture = (TextureIndex)xe134235b3526fa75.ReadUInt16();
		if (x12b7f8e5698b30a6.Texture == TextureIndex.TextureNil)
		{
			x12b7f8e5698b30a6.x0e18178ac4b2272f = x26d9ecb4bdf0456d.x45260ad4b94166f2;
			x12b7f8e5698b30a6.xc290f60df004e384 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		return x12b7f8e5698b30a6;
	}

	internal static void x2beefb7099c2c239(Shading x12b7f8e5698b30a6, BinaryWriter xbdfb620b7167944b)
	{
		int num = 0;
		if (x12b7f8e5698b30a6.Texture == TextureIndex.TextureNil)
		{
			num = 65535;
		}
		else
		{
			num |= (int)x195cb055715b526e.xc3bcf5a9ad941428(x12b7f8e5698b30a6.xc290f60df004e384);
			num |= (int)x195cb055715b526e.xc3bcf5a9ad941428(x12b7f8e5698b30a6.x0e18178ac4b2272f) << 5;
			num |= (int)x12b7f8e5698b30a6.Texture << 10;
		}
		xbdfb620b7167944b.Write((ushort)num);
	}

	internal static void x7cf486446cf04117(Shading x12b7f8e5698b30a6, BinaryWriter xbdfb620b7167944b)
	{
		if (x12b7f8e5698b30a6.Texture == TextureIndex.TextureNil)
		{
			xbdfb620b7167944b.Write(uint.MaxValue);
			xbdfb620b7167944b.Write(uint.MaxValue);
			xbdfb620b7167944b.Write(ushort.MaxValue);
		}
		else
		{
			xbdfb620b7167944b.Write(x195cb055715b526e.x103636c839f725d7(x12b7f8e5698b30a6.xc290f60df004e384));
			xbdfb620b7167944b.Write(x195cb055715b526e.x103636c839f725d7(x12b7f8e5698b30a6.x0e18178ac4b2272f));
			xbdfb620b7167944b.Write((ushort)x12b7f8e5698b30a6.Texture);
		}
	}

	internal static void x6210059f049f0d48(Shading x12b7f8e5698b30a6, BinaryWriter xbdfb620b7167944b, bool x7c4bd54fe1ef29c6)
	{
		if (x7c4bd54fe1ef29c6)
		{
			x7cf486446cf04117(x12b7f8e5698b30a6, xbdfb620b7167944b);
		}
		else
		{
			x2beefb7099c2c239(x12b7f8e5698b30a6, xbdfb620b7167944b);
		}
	}

	internal static int x97fb3720381ebd96(bool x7c4bd54fe1ef29c6)
	{
		if (!x7c4bd54fe1ef29c6)
		{
			return 2;
		}
		return 10;
	}
}
