using System.Drawing.Drawing2D;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace xf269d97e8a02e911;

internal class xb6b31e10a27b56a2 : xbadcaf18b423f918
{
	private int x4b088f70e8b96620;

	private xf68da7ebd6244f01 x5d9fbd9603e9dee5;

	private x26d9ecb4bdf0456d xfd2ce88fa11a1590;

	private x26d9ecb4bdf0456d x673d591644543f05;

	private x8f323f14cd8c4c87 x1466148dad621cc1;

	private x845d6a068e0b03c5 xa31c8fed8093bc20;

	private byte[] xd08494dce3b2b550;

	private WrapMode x95f514a4b958699a;

	x1c26f4f3c6f98ecc xbadcaf18b423f918.xfae96ceb2d396a78 => x1c26f4f3c6f98ecc.x60465f602599d327;

	public int x7efbe0a2dc0d335f
	{
		get
		{
			return x4b088f70e8b96620;
		}
		set
		{
			x4b088f70e8b96620 = value;
		}
	}

	internal xf68da7ebd6244f01 xfe2178c1f916f36c
	{
		get
		{
			return x5d9fbd9603e9dee5;
		}
		set
		{
			x5d9fbd9603e9dee5 = value;
		}
	}

	internal x26d9ecb4bdf0456d x7dd793a62d047456
	{
		get
		{
			return xfd2ce88fa11a1590;
		}
		set
		{
			xfd2ce88fa11a1590 = value;
		}
	}

	internal x26d9ecb4bdf0456d xf83c69bb98e96a69
	{
		get
		{
			return x673d591644543f05;
		}
		set
		{
			x673d591644543f05 = value;
		}
	}

	internal x8f323f14cd8c4c87 xcf97c012aacdf16b
	{
		get
		{
			return x1466148dad621cc1;
		}
		set
		{
			x1466148dad621cc1 = value;
		}
	}

	internal xb6b31e10a27b56a2()
	{
		x5d9fbd9603e9dee5 = xf68da7ebd6244f01.xb8751dec55f64252;
		xfd2ce88fa11a1590 = x26d9ecb4bdf0456d.x8f02f53f1587477d;
		x673d591644543f05 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		x1466148dad621cc1 = x8f323f14cd8c4c87.x3bce7c87328df8da;
	}

	internal void xda72e69795827549(xa1f7a3d42bca7cb8 xe134235b3526fa75)
	{
		x5d9fbd9603e9dee5 = (xf68da7ebd6244f01)xe134235b3526fa75.ReadInt16();
		xfd2ce88fa11a1590 = xe134235b3526fa75.x07d1b52af8293592();
		x1466148dad621cc1 = (x8f323f14cd8c4c87)xe134235b3526fa75.ReadInt16();
	}

	internal void xca29b0d786deb760(xa1f7a3d42bca7cb8 xe134235b3526fa75)
	{
		x5d9fbd9603e9dee5 = xf68da7ebd6244f01.x00af7d27e354cbb1;
		x95f514a4b958699a = WrapMode.Tile;
		xd08494dce3b2b550 = xe134235b3526fa75.ReadBytes((int)xe134235b3526fa75.BaseStream.Length);
	}

	internal void x27093997fc9d86ae(xa1f7a3d42bca7cb8 xe134235b3526fa75)
	{
		x5d9fbd9603e9dee5 = xf68da7ebd6244f01.x00af7d27e354cbb1;
		x95f514a4b958699a = WrapMode.Tile;
		int xf3df8caccbf90f = (int)(xe134235b3526fa75.BaseStream.Length - xe134235b3526fa75.BaseStream.Position);
		xd08494dce3b2b550 = xdd1b8f14cc8ba86d.x10e7a0599aa303ae(xe134235b3526fa75, xf3df8caccbf90f);
	}

	internal void x5023e134b4415253(x28a5d52551b64191 xe134235b3526fa75)
	{
		x4b088f70e8b96620 = xe134235b3526fa75.ReadInt32();
		x5d9fbd9603e9dee5 = (xf68da7ebd6244f01)xe134235b3526fa75.ReadUInt32();
		xfd2ce88fa11a1590 = xe134235b3526fa75.x07d1b52af8293592();
		x1466148dad621cc1 = (x8f323f14cd8c4c87)xe134235b3526fa75.ReadInt32();
	}

	internal void x443a37a2dda295f7(x28a5d52551b64191 xe134235b3526fa75)
	{
		int num = (int)xe134235b3526fa75.BaseStream.Position - 8;
		x4b088f70e8b96620 = xe134235b3526fa75.ReadInt32();
		x5d9fbd9603e9dee5 = xf68da7ebd6244f01.x00af7d27e354cbb1;
		x95f514a4b958699a = WrapMode.Tile;
		xe134235b3526fa75.ReadInt32();
		int num2 = xe134235b3526fa75.ReadInt32();
		int xe873ef11b0a8e5d = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		int xced22864f0ce3ee = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.BaseStream.Position = num + num2;
		xd08494dce3b2b550 = xdd1b8f14cc8ba86d.x10e7a0599aa303ae(xe134235b3526fa75, xe873ef11b0a8e5d, xced22864f0ce3ee);
	}

	internal void x1cca13a55b481b11(x28a5d52551b64191 xe134235b3526fa75, x26d9ecb4bdf0456d x53218bf919efffd4, x26d9ecb4bdf0456d x824bfb65f06865bd)
	{
		int num = (int)xe134235b3526fa75.BaseStream.Position - 8;
		x4b088f70e8b96620 = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		int num2 = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		int num3 = xe134235b3526fa75.ReadInt32();
		int x0bdd6c63d4872aa = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.BaseStream.Position = num + num2;
		x915c8f78319ef101 x915c8f78319ef = new x915c8f78319ef101();
		x915c8f78319ef.x06b0e25aa6ad68a9(xe134235b3526fa75);
		if (x915c8f78319ef.xce53a4f2835cab70 == 1)
		{
			x26d9ecb4bdf0456d[] xc9808022f4ecf = new x26d9ecb4bdf0456d[2] { x53218bf919efffd4, x824bfb65f06865bd };
			x5d9fbd9603e9dee5 = xf68da7ebd6244f01.x00af7d27e354cbb1;
			x95f514a4b958699a = WrapMode.Tile;
			xe134235b3526fa75.BaseStream.Position = num + num3;
			xd08494dce3b2b550 = xdd1b8f14cc8ba86d.xb84bf905df8c2961(x915c8f78319ef, xc9808022f4ecf, xe134235b3526fa75, x0bdd6c63d4872aa);
		}
	}

	internal x845d6a068e0b03c5 x4fc034c6f36cbd4c(x54366fa5f75a02f7 x4a1f588fedbc8141)
	{
		switch (x5d9fbd9603e9dee5)
		{
		case xf68da7ebd6244f01.xe6f652a9fd917f11:
			return null;
		case xf68da7ebd6244f01.xb8751dec55f64252:
			xa31c8fed8093bc20 = new xc020fa2f5133cba8(xfd2ce88fa11a1590);
			break;
		case xf68da7ebd6244f01.x0e10fd73b5faa124:
			xa31c8fed8093bc20 = new x5bdb4ba66c23277c((HatchStyle)x1466148dad621cc1, xfd2ce88fa11a1590, x673d591644543f05);
			break;
		case xf68da7ebd6244f01.x00af7d27e354cbb1:
		{
			x5e9754e56a4f759f x5e9754e56a4f759f = new x5e9754e56a4f759f(xd08494dce3b2b550, x95f514a4b958699a);
			x5e9754e56a4f759f.xaccac17571a8d9fa = x4a1f588fedbc8141;
			xa31c8fed8093bc20 = x5e9754e56a4f759f;
			break;
		}
		}
		return xa31c8fed8093bc20;
	}
}
