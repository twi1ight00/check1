using System;
using System.Drawing.Drawing2D;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace xf269d97e8a02e911;

internal class xd8229e5e57d947ce : xbadcaf18b423f918
{
	private enum xe1d5faf1f20436da
	{
		x4d0b9d4447ba7566,
		xb8751dec55f64252,
		x0e10fd73b5faa124,
		xb164d2d775e7acfd
	}

	private xd6748f351bb3d69f x5d9fbd9603e9dee5;

	private float xd74c65b8d28b1740;

	private x26d9ecb4bdf0456d x78e4acec873c7675;

	private int x4b088f70e8b96620;

	private x8f323f14cd8c4c87 xea8e15119e58f0c1;

	private byte[] xd08494dce3b2b550;

	private xe1d5faf1f20436da xb874be416f92d0ba;

	x1c26f4f3c6f98ecc xbadcaf18b423f918.xfae96ceb2d396a78 => x1c26f4f3c6f98ecc.x9e5d5f9128c69a8f;

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

	internal xd6748f351bb3d69f xfe2178c1f916f36c
	{
		set
		{
			x5d9fbd9603e9dee5 = value;
			x083f27da82f8b6d1();
		}
	}

	internal x26d9ecb4bdf0456d x9b41425268471380
	{
		set
		{
			x78e4acec873c7675 = value;
		}
	}

	internal xd8229e5e57d947ce()
	{
		x5d9fbd9603e9dee5 = xd6748f351bb3d69f.xb8751dec55f64252;
		xd74c65b8d28b1740 = 1f;
		x78e4acec873c7675 = x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		xea8e15119e58f0c1 = x8f323f14cd8c4c87.x3bce7c87328df8da;
		xb874be416f92d0ba = xe1d5faf1f20436da.xb8751dec55f64252;
	}

	internal void xda72e69795827549(xa1f7a3d42bca7cb8 xe134235b3526fa75)
	{
		x5d9fbd9603e9dee5 = (xd6748f351bb3d69f)xe134235b3526fa75.ReadInt16();
		xd74c65b8d28b1740 = Math.Max(xe134235b3526fa75.ReadInt16(), (short)1);
		xe134235b3526fa75.ReadInt16();
		x78e4acec873c7675 = xe134235b3526fa75.x07d1b52af8293592();
		x083f27da82f8b6d1();
	}

	internal void x5023e134b4415253(x28a5d52551b64191 xe134235b3526fa75)
	{
		x4b088f70e8b96620 = xe134235b3526fa75.ReadInt32();
		x5d9fbd9603e9dee5 = (xd6748f351bb3d69f)xe134235b3526fa75.ReadInt32();
		xd74c65b8d28b1740 = Math.Max(xe134235b3526fa75.ReadInt32(), 1);
		xe134235b3526fa75.ReadInt32();
		x78e4acec873c7675 = xe134235b3526fa75.x07d1b52af8293592();
		x083f27da82f8b6d1();
	}

	internal void xdb946be4ae137bb7(x28a5d52551b64191 xe134235b3526fa75)
	{
		x4b088f70e8b96620 = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		int xe873ef11b0a8e5d = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		int xced22864f0ce3ee = xe134235b3526fa75.ReadInt32();
		x5d9fbd9603e9dee5 = (xd6748f351bb3d69f)xe134235b3526fa75.ReadUInt32();
		xd74c65b8d28b1740 = Math.Max(xe134235b3526fa75.ReadInt32(), 1);
		xf68da7ebd6244f01 xf68da7ebd6244f = (xf68da7ebd6244f01)xe134235b3526fa75.ReadUInt32();
		if (xf68da7ebd6244f == xf68da7ebd6244f01.xb8751dec55f64252 || xf68da7ebd6244f == xf68da7ebd6244f01.x0e10fd73b5faa124)
		{
			x78e4acec873c7675 = xe134235b3526fa75.x07d1b52af8293592();
		}
		else
		{
			xe134235b3526fa75.ReadInt32();
		}
		xea8e15119e58f0c1 = (x8f323f14cd8c4c87)xe134235b3526fa75.ReadInt32();
		if ((xf68da7ebd6244f & xf68da7ebd6244f01.x0e10fd73b5faa124) == xf68da7ebd6244f01.x0e10fd73b5faa124)
		{
			xb874be416f92d0ba = xe1d5faf1f20436da.x0e10fd73b5faa124;
		}
		xe134235b3526fa75.xdba4185013f2ac84();
		if (xf68da7ebd6244f == xf68da7ebd6244f01.xdd197d155a7df6a5)
		{
			xb874be416f92d0ba = xe1d5faf1f20436da.xb164d2d775e7acfd;
			xe134235b3526fa75.ReadInt32();
			xd08494dce3b2b550 = xdd1b8f14cc8ba86d.x10e7a0599aa303ae(xe134235b3526fa75, xe873ef11b0a8e5d, xced22864f0ce3ee);
		}
		x083f27da82f8b6d1();
	}

	internal x31c19fcb724dfaf5 x2de37a091bfef3b4(x26d9ecb4bdf0456d x154083d58301ef75)
	{
		x31c19fcb724dfaf5 result = null;
		switch (xb874be416f92d0ba)
		{
		case xe1d5faf1f20436da.x4d0b9d4447ba7566:
			return result;
		case xe1d5faf1f20436da.x0e10fd73b5faa124:
		{
			x845d6a068e0b03c5 brush = new x5bdb4ba66c23277c((HatchStyle)xea8e15119e58f0c1, x78e4acec873c7675, x154083d58301ef75);
			result = new x31c19fcb724dfaf5(brush, xd74c65b8d28b1740);
			break;
		}
		case xe1d5faf1f20436da.xb164d2d775e7acfd:
		{
			x845d6a068e0b03c5 brush = new x5e9754e56a4f759f(xd08494dce3b2b550, WrapMode.Tile);
			result = new x31c19fcb724dfaf5(brush, xd74c65b8d28b1740);
			break;
		}
		default:
			result = new x31c19fcb724dfaf5(x78e4acec873c7675, xd74c65b8d28b1740);
			break;
		}
		x82b30391a5f3a801(result, x5d9fbd9603e9dee5 & xd6748f351bb3d69f.xff0ac14a26e83968);
		x38d48f89ba0ffc5c(result, x5d9fbd9603e9dee5 & xd6748f351bb3d69f.x420f0dd94efdb047);
		x3430608a76344d08(result, x5d9fbd9603e9dee5 & xd6748f351bb3d69f.xe7ba46a226b2bfb9);
		return result;
	}

	private void x083f27da82f8b6d1()
	{
		if ((x5d9fbd9603e9dee5 & xd6748f351bb3d69f.xff0ac14a26e83968) == xd6748f351bb3d69f.xe6f652a9fd917f11)
		{
			xb874be416f92d0ba = xe1d5faf1f20436da.x4d0b9d4447ba7566;
		}
	}

	private static void x82b30391a5f3a801(x31c19fcb724dfaf5 x90279591611601bc, xd6748f351bb3d69f x44ecfea61c937b8e)
	{
		switch (x44ecfea61c937b8e)
		{
		case xd6748f351bb3d69f.xb8751dec55f64252:
			x90279591611601bc.xca08e8eb525b8a1a = DashStyle.Solid;
			break;
		case xd6748f351bb3d69f.x35078e8db43b001f:
			x90279591611601bc.xca08e8eb525b8a1a = DashStyle.Dash;
			break;
		case xd6748f351bb3d69f.x3cb6807e93737c2d:
			x90279591611601bc.xca08e8eb525b8a1a = DashStyle.Dot;
			break;
		case xd6748f351bb3d69f.x41084163454410db:
			x90279591611601bc.xca08e8eb525b8a1a = DashStyle.DashDot;
			break;
		case xd6748f351bb3d69f.x030841c36ce786b8:
			x90279591611601bc.xca08e8eb525b8a1a = DashStyle.DashDotDot;
			break;
		}
	}

	private static void x38d48f89ba0ffc5c(x31c19fcb724dfaf5 x90279591611601bc, xd6748f351bb3d69f x44ecfea61c937b8e)
	{
		LineCap xec7c14446b = (x90279591611601bc.x1e0dcb2cdd562cb2 = x44ecfea61c937b8e switch
		{
			xd6748f351bb3d69f.xb8751dec55f64252 => LineCap.Round, 
			xd6748f351bb3d69f.x0924c7a9a3de1815 => LineCap.Square, 
			xd6748f351bb3d69f.x49cf7cc429538958 => LineCap.Flat, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("phnefjefpilfpicgnijgcjahgihhfdohcifiehmikhdjjckjlgbkbhikegpknbglnfnlifemeglmbbcnbgjnpfaobghobfoohefpnamp", 1678658858))), 
		});
		x90279591611601bc.xec7c14446b693774 = xec7c14446b;
	}

	private static void x3430608a76344d08(x31c19fcb724dfaf5 x90279591611601bc, xd6748f351bb3d69f x44ecfea61c937b8e)
	{
		switch (x44ecfea61c937b8e)
		{
		case xd6748f351bb3d69f.xb8751dec55f64252:
			x90279591611601bc.x03a8df074279275f = LineJoin.Round;
			break;
		case xd6748f351bb3d69f.x2551cdfefacddbf8:
			x90279591611601bc.x03a8df074279275f = LineJoin.Bevel;
			break;
		case xd6748f351bb3d69f.x7f3860bd49447cb9:
			x90279591611601bc.x03a8df074279275f = LineJoin.Miter;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jnpcpogdjondjoeeholemocfaojfpiagmnhgomogenfhdimhkmdimmkidmbjfmijehpjemgkcmnkemelelllkkcmahjm", 429207428)));
		}
	}
}
