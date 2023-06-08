using System.IO;
using Aspose.Words;
using xf989f31a236ff98c;

namespace xa604c4d210ae0581;

internal class x1df55585ec1be056
{
	internal const int x9e9c4f35f59e39a8 = 4;

	internal const int xdc9d8b5df2c0fcda = 8;

	internal static Border x002fafae3e338912(BinaryReader xe134235b3526fa75, Border x14cf9593b86ecbaa)
	{
		int xab266ea415f07c = xe134235b3526fa75.ReadByte();
		int num = xe134235b3526fa75.ReadByte();
		if (num != 255)
		{
			if (x14cf9593b86ecbaa == null)
			{
				x14cf9593b86ecbaa = new Border();
			}
			x14cf9593b86ecbaa.LineStyle = (LineStyle)num;
			x14cf9593b86ecbaa.xab266ea415f07c09 = xab266ea415f07c;
			x14cf9593b86ecbaa.x63b1a7c31a962459 = x195cb055715b526e.x5ab07bb8554e00d9((x88d38775104122b8)xe134235b3526fa75.ReadByte());
			int num2 = xe134235b3526fa75.ReadByte();
			x14cf9593b86ecbaa.x1f2d5df87a5c4f81 = (byte)(num2 & 0x1F);
			x14cf9593b86ecbaa.Shadow = (num2 & 0x20) != 0;
			x14cf9593b86ecbaa.x227665e444fb500a = (num2 & 0x40) != 0;
			return x14cf9593b86ecbaa;
		}
		xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		return null;
	}

	internal static Border x9b448ca00ed9c929(BinaryReader xe134235b3526fa75, Border x14cf9593b86ecbaa)
	{
		int xf5b6377cba = xe134235b3526fa75.ReadInt32();
		int xab266ea415f07c = xe134235b3526fa75.ReadByte();
		int num = xe134235b3526fa75.ReadByte();
		if (num != 255)
		{
			if (x14cf9593b86ecbaa == null)
			{
				x14cf9593b86ecbaa = new Border();
			}
			x14cf9593b86ecbaa.x63b1a7c31a962459 = x195cb055715b526e.xfa7086ee0c6b6330(xf5b6377cba);
			x14cf9593b86ecbaa.xab266ea415f07c09 = xab266ea415f07c;
			x14cf9593b86ecbaa.LineStyle = (LineStyle)num;
			int num2 = xe134235b3526fa75.ReadByte();
			x14cf9593b86ecbaa.x1f2d5df87a5c4f81 = (byte)(num2 & 0x1F);
			x14cf9593b86ecbaa.Shadow = (num2 & 0x20) != 0;
			x14cf9593b86ecbaa.x227665e444fb500a = (num2 & 0x40) != 0;
			xe134235b3526fa75.ReadByte();
			return x14cf9593b86ecbaa;
		}
		xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		return null;
	}

	internal static void x2beefb7099c2c239(Border x14cf9593b86ecbaa, BinaryWriter xbdfb620b7167944b, bool x10e248b4013349b1)
	{
		if (x14cf9593b86ecbaa != null)
		{
			xbdfb620b7167944b.Write((byte)x14cf9593b86ecbaa.xab266ea415f07c09);
			xbdfb620b7167944b.Write((byte)x7af6b1b6ce43ed9a(x14cf9593b86ecbaa.LineStyle, xd53e574f767ba643: false));
			xbdfb620b7167944b.Write((byte)x195cb055715b526e.xc3bcf5a9ad941428(x14cf9593b86ecbaa.x63b1a7c31a962459));
			int num = 0;
			num |= (x10e248b4013349b1 ? x14cf9593b86ecbaa.x1f2d5df87a5c4f81 : 0);
			num |= (x14cf9593b86ecbaa.Shadow ? 32 : 0) | (x14cf9593b86ecbaa.x227665e444fb500a ? 64 : 0);
			xbdfb620b7167944b.Write((byte)num);
		}
		else
		{
			xbdfb620b7167944b.Write(uint.MaxValue);
		}
	}

	internal static void x7cf486446cf04117(Border x14cf9593b86ecbaa, BinaryWriter xbdfb620b7167944b, bool x10e248b4013349b1)
	{
		if (x14cf9593b86ecbaa != null)
		{
			xbdfb620b7167944b.Write(x195cb055715b526e.x103636c839f725d7(x14cf9593b86ecbaa.x63b1a7c31a962459));
			xbdfb620b7167944b.Write((byte)x14cf9593b86ecbaa.xab266ea415f07c09);
			xbdfb620b7167944b.Write((byte)x7af6b1b6ce43ed9a(x14cf9593b86ecbaa.LineStyle, xd53e574f767ba643: true));
			int num = 0;
			num |= (x10e248b4013349b1 ? x14cf9593b86ecbaa.x1f2d5df87a5c4f81 : 0);
			num |= (x14cf9593b86ecbaa.Shadow ? 32 : 0) | (x14cf9593b86ecbaa.x227665e444fb500a ? 64 : 0);
			xbdfb620b7167944b.Write((byte)num);
			xbdfb620b7167944b.Write((byte)0);
		}
		else
		{
			xbdfb620b7167944b.Write(uint.MaxValue);
			xbdfb620b7167944b.Write(uint.MaxValue);
		}
	}

	private static LineStyle x7af6b1b6ce43ed9a(LineStyle x26516bbd7ae94699, bool xd53e574f767ba643)
	{
		switch (x26516bbd7ae94699)
		{
		case LineStyle.Outset:
		case LineStyle.Inset:
			if (!xd53e574f767ba643)
			{
				return LineStyle.Single;
			}
			return x26516bbd7ae94699;
		case LineStyle.Thick:
			return LineStyle.Single;
		default:
			return x26516bbd7ae94699;
		}
	}

	internal static void x6210059f049f0d48(Border x14cf9593b86ecbaa, BinaryWriter xbdfb620b7167944b, bool x10e248b4013349b1, bool x7c4bd54fe1ef29c6)
	{
		if (x7c4bd54fe1ef29c6)
		{
			x7cf486446cf04117(x14cf9593b86ecbaa, xbdfb620b7167944b, x10e248b4013349b1);
		}
		else
		{
			x2beefb7099c2c239(x14cf9593b86ecbaa, xbdfb620b7167944b, x10e248b4013349b1);
		}
	}

	internal static int x97fb3720381ebd96(bool x7c4bd54fe1ef29c6)
	{
		if (!x7c4bd54fe1ef29c6)
		{
			return 4;
		}
		return 8;
	}
}
