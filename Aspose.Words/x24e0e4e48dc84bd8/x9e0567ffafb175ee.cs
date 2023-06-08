using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x74500b509de15565;
using x85732faf56f7825d;
using xa7850104c8d8c135;
using xeb665d1aeef09d64;

namespace x24e0e4e48dc84bd8;

internal class x9e0567ffafb175ee
{
	private readonly x28a5d52551b64191 x7450cc1e48712286;

	private readonly x05ec9e59d7d139e6 x0557827b487b5834;

	private readonly x25d42836be873e27 x38c6a51d5e158139;

	private readonly x4e88096751fad171 xd995695f8e3419d6;

	public x9e0567ffafb175ee(Stream stream, x4e88096751fad171 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
		x7450cc1e48712286 = new x28a5d52551b64191(stream);
		x0557827b487b5834 = new x05ec9e59d7d139e6(x7450cc1e48712286, xd995695f8e3419d6);
		x38c6a51d5e158139 = new x25d42836be873e27(x7450cc1e48712286, xd995695f8e3419d6);
	}

	public object x5645da3ef786a86f(x6d569a893c7802a9 x4838119d9a997069, int x4d3e8dc385715cfb)
	{
		try
		{
			long num = x7450cc1e48712286.BaseStream.Position + x4d3e8dc385715cfb;
			return x4838119d9a997069 switch
			{
				x6d569a893c7802a9.x63e632c3936c1e60 => null, 
				x6d569a893c7802a9.x74e3fbafe23c6f1e => xce4f319b1642582f(num), 
				x6d569a893c7802a9.x62df0f2f19a34678 => xc785a8086f2ad706(num), 
				x6d569a893c7802a9.x1feef331f5ef868a => xe6dd7bd4e532d8a6(), 
				x6d569a893c7802a9.xeb05ffc693ee1cb0 => xb0ca02f411d7ca16(), 
				x6d569a893c7802a9.x7a148a53d81b32d7 => x264f3cba2f0b02e2(num), 
				x6d569a893c7802a9.x4591b443591bdf2e => xdafccb198ba91439(), 
				x6d569a893c7802a9.x38bd8731f7719ac3 => x88ac3bd8b9f71f3b(), 
				x6d569a893c7802a9.x0b5eed9943fed9ae => xd9eb4a37b76c4024(), 
				x6d569a893c7802a9.xdc92865f5681ed6b => x1cc6247a1905dafe(), 
				_ => null, 
			};
		}
		catch (Exception)
		{
			return null;
		}
	}

	public object x1cc6247a1905dafe()
	{
		return null;
	}

	public object xd9eb4a37b76c4024()
	{
		return null;
	}

	public x030508d4549c7599 x88ac3bd8b9f71f3b()
	{
		return x030508d4549c7599.x06b0e25aa6ad68a9(x7450cc1e48712286);
	}

	public xe39d06eee35dd23d xdafccb198ba91439()
	{
		x7450cc1e48712286.ReadInt32();
		float num = x7450cc1e48712286.ReadSingle();
		x60f0a0028c81b61c xec1dc110291a6af = (x60f0a0028c81b61c)x7450cc1e48712286.ReadInt32();
		FontStyle x44ecfea61c937b8e = (FontStyle)x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt32();
		int xb4ec4aba4b97eacf = x7450cc1e48712286.ReadInt32();
		string xa79a9f649c74f4a = x7450cc1e48712286.x2a1ea9d24e62bf84(xb4ec4aba4b97eacf);
		float xdb421875a5f5258b = (float)xd995695f8e3419d6.x5b13e3ca46964e0d.x645cd44df6f04941(num, xec1dc110291a6af);
		return x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753(xa79a9f649c74f4a, xdb421875a5f5258b, x44ecfea61c937b8e, "Microsoft Sans Serif");
	}

	public x273fb960e2b0a823 x264f3cba2f0b02e2(long x6de0d334b172ed56)
	{
		return x0557827b487b5834.x264f3cba2f0b02e2(x6de0d334b172ed56);
	}

	public Region xb0ca02f411d7ca16()
	{
		x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt32();
		return x678a99194f9a94ee();
	}

	private Region x678a99194f9a94ee()
	{
		x2d88eb4d32c20575 x2d88eb4d32c = (x2d88eb4d32c20575)x7450cc1e48712286.ReadInt32();
		switch (x2d88eb4d32c)
		{
		case x2d88eb4d32c20575.x45260ad4b94166f2:
			return new Region(new RectangleF(0f, 0f, 0f, 0f));
		case x2d88eb4d32c20575.xfeb3e6e41aa2cb20:
			return new Region();
		case x2d88eb4d32c20575.x632b457a1248cdb1:
		{
			x7450cc1e48712286.ReadInt32();
			xab391c46ff9a0a38 xab391c46ff9a0a = xe6dd7bd4e532d8a6();
			x5250236f9cf73045 x5250236f9cf = new x5250236f9cf73045();
			xab391c46ff9a0a.Accept(x5250236f9cf);
			return new Region(x5250236f9cf.x588bacbaa0ed1589);
		}
		case x2d88eb4d32c20575.xa07a9457a2ebbbfc:
		{
			RectangleF rect = x7450cc1e48712286.x3b0757d2103a91b5();
			return new Region(rect);
		}
		case x2d88eb4d32c20575.xb56b87770d51d55a:
		case x2d88eb4d32c20575.x46f0ec9f7f657efb:
		case x2d88eb4d32c20575.x4c5ede5040bbffe5:
		case x2d88eb4d32c20575.x799ceb8bdd5b54ef:
		case x2d88eb4d32c20575.x0542832297869ffb:
			return xe763e41d29f59dd7(x2d88eb4d32c);
		default:
			return new Region();
		}
	}

	private Region xe763e41d29f59dd7(x2d88eb4d32c20575 x43163d22e8cd5a71)
	{
		Region region = x678a99194f9a94ee();
		Region region2 = x678a99194f9a94ee();
		switch (x43163d22e8cd5a71)
		{
		case x2d88eb4d32c20575.x4c5ede5040bbffe5:
			region2.Xor(region);
			break;
		case x2d88eb4d32c20575.x799ceb8bdd5b54ef:
			region2.Complement(region);
			break;
		case x2d88eb4d32c20575.xb56b87770d51d55a:
			region2.Intersect(region);
			break;
		case x2d88eb4d32c20575.x46f0ec9f7f657efb:
			region2.Union(region);
			break;
		case x2d88eb4d32c20575.x0542832297869ffb:
			region2.Exclude(region);
			break;
		}
		return region2;
	}

	public xab391c46ff9a0a38 xe6dd7bd4e532d8a6()
	{
		return x38c6a51d5e158139.xe6dd7bd4e532d8a6();
	}

	public x31c19fcb724dfaf5 xc785a8086f2ad706(long xc19b53d0e6b697d3)
	{
		x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt32();
		x31c19fcb724dfaf5 x31c19fcb724dfaf = x51aa9e17b7e04b35();
		x31c19fcb724dfaf.x60465f602599d327 = xce4f319b1642582f(xc19b53d0e6b697d3);
		return x31c19fcb724dfaf;
	}

	public x845d6a068e0b03c5 xce4f319b1642582f(long xf64b978577df3f2d)
	{
		x7450cc1e48712286.ReadInt32();
		return (xe05c64a8e2a3e537)x7450cc1e48712286.ReadInt32() switch
		{
			xe05c64a8e2a3e537.x1a196717b0728018 => x922cac5f8853c472(), 
			xe05c64a8e2a3e537.x9f8e2cb7980f46e3 => x5b1bca528e9549a6(), 
			xe05c64a8e2a3e537.x59a719f7988c2a43 => xe257f7907403694a(xf64b978577df3f2d), 
			xe05c64a8e2a3e537.x5838182c12c13e51 => x44ba58ba07bfa828(), 
			xe05c64a8e2a3e537.x0ac7ea03d673fe9a => x1c66a46443d8bfb4(), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private x31c19fcb724dfaf5 x51aa9e17b7e04b35()
	{
		int num = x7450cc1e48712286.ReadInt32();
		x60f0a0028c81b61c xec1dc110291a6af = (x60f0a0028c81b61c)x7450cc1e48712286.ReadInt32();
		float num2 = x7450cc1e48712286.ReadSingle();
		x31c19fcb724dfaf5 x31c19fcb724dfaf = new x31c19fcb724dfaf5();
		x31c19fcb724dfaf.xdc1bf80853046136 = (float)xd995695f8e3419d6.x5b13e3ca46964e0d.x645cd44df6f04941(num2, xec1dc110291a6af);
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			x7450cc1e48712286.x8c1dae79b4f085c4();
		}
		if (((uint)num & 2u) != 0)
		{
			x31c19fcb724dfaf.x1e0dcb2cdd562cb2 = (LineCap)x7450cc1e48712286.ReadInt32();
		}
		if (((uint)num & 4u) != 0)
		{
			x31c19fcb724dfaf.xec7c14446b693774 = (LineCap)x7450cc1e48712286.ReadInt32();
		}
		if (((uint)num & 8u) != 0)
		{
			x31c19fcb724dfaf.x03a8df074279275f = (LineJoin)x7450cc1e48712286.ReadInt32();
		}
		if (((uint)num & 0x10u) != 0)
		{
			x31c19fcb724dfaf.x3372c2e5fab45e9a = x7450cc1e48712286.ReadSingle();
		}
		if (((uint)num & 0x20u) != 0)
		{
			x31c19fcb724dfaf.xca08e8eb525b8a1a = (DashStyle)x7450cc1e48712286.ReadInt32();
		}
		if (((uint)num & 0x40u) != 0)
		{
			x31c19fcb724dfaf.x9526ba50e2183e01 = (DashCap)x7450cc1e48712286.ReadInt32();
		}
		if (((uint)num & 0x80u) != 0)
		{
			x31c19fcb724dfaf.xc19b368b60309472 = x7450cc1e48712286.ReadSingle();
		}
		if (((uint)num & 0x100u) != 0)
		{
			x31c19fcb724dfaf.x358988d12e56bf69 = x1feb2db6c092cac9();
		}
		if (((uint)num & 0x200u) != 0)
		{
			x31c19fcb724dfaf.x9ba359ff37a3a63b = (PenAlignment)x7450cc1e48712286.ReadInt32();
		}
		if (((uint)num & 0x400u) != 0)
		{
			x31c19fcb724dfaf.x6fd1e71abf8b8121 = x427282f50e586f38();
		}
		if (((uint)num & 0x800u) != 0)
		{
			x87062cac93ac369c();
		}
		if (((uint)num & 0x1000u) != 0)
		{
			xb61d8555c29e4fa0();
		}
		return x31c19fcb724dfaf;
	}

	private void xb61d8555c29e4fa0()
	{
		int num = x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.BaseStream.Position += num;
	}

	private void x87062cac93ac369c()
	{
		int num = x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.BaseStream.Position += num;
	}

	private float[] x427282f50e586f38()
	{
		int x961016a387451f = x7450cc1e48712286.ReadInt32();
		return x7450cc1e48712286.x5472c0dae883be66(x961016a387451f);
	}

	private float[] x1feb2db6c092cac9()
	{
		int x961016a387451f = x7450cc1e48712286.ReadInt32();
		return x7450cc1e48712286.x5472c0dae883be66(x961016a387451f);
	}

	private x845d6a068e0b03c5 x1c66a46443d8bfb4()
	{
		int x39db9913986852f = x7450cc1e48712286.ReadInt32();
		WrapMode x349ff0df1e641b4e = (WrapMode)x7450cc1e48712286.ReadInt32();
		RectangleF rect = x7450cc1e48712286.x3b0757d2103a91b5();
		x26d9ecb4bdf0456d startColor = x7450cc1e48712286.x458cbe2343cf2fba();
		x26d9ecb4bdf0456d endColor = x7450cc1e48712286.x458cbe2343cf2fba();
		x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt32();
		x5f55370cc09dd787 x5f55370cc09dd = new x5f55370cc09dd787(rect, startColor, endColor);
		xa58fec995ecf2e27(x39db9913986852f, x5f55370cc09dd);
		x5f55370cc09dd.x349ff0df1e641b4e = x349ff0df1e641b4e;
		return x5f55370cc09dd;
	}

	private x845d6a068e0b03c5 x44ba58ba07bfa828()
	{
		int num = x7450cc1e48712286.ReadInt32();
		WrapMode x349ff0df1e641b4e = (WrapMode)x7450cc1e48712286.ReadInt32();
		x26d9ecb4bdf0456d xcd610bdad90237c = x7450cc1e48712286.x458cbe2343cf2fba();
		PointF centerPoint = x7450cc1e48712286.xa4a92a61b2092da6();
		int num2 = x7450cc1e48712286.ReadInt32();
		x26d9ecb4bdf0456d[] array = new x26d9ecb4bdf0456d[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = x7450cc1e48712286.x458cbe2343cf2fba();
		}
		xab391c46ff9a0a38 path = x719bc66992080d0d(num);
		xa587dcb499c221cc xa587dcb499c221cc = new xa587dcb499c221cc(path, centerPoint);
		xa587dcb499c221cc.xbd123a0db502b2b7 = array;
		xa587dcb499c221cc.xcd610bdad90237c0 = xcd610bdad90237c;
		xa58fec995ecf2e27(num, xa587dcb499c221cc);
		if (((uint)num & 0x40u) != 0)
		{
			x9f406ded10a795d5();
		}
		xa587dcb499c221cc.x349ff0df1e641b4e = x349ff0df1e641b4e;
		return xa587dcb499c221cc;
	}

	private void xa58fec995ecf2e27(int x39db9913986852f9, xf022bb98711420db xd8f1949f8950238a)
	{
		if (((uint)x39db9913986852f9 & 2u) != 0)
		{
			xd8f1949f8950238a.xaccac17571a8d9fa = x7450cc1e48712286.x8c1dae79b4f085c4();
		}
		if (((uint)x39db9913986852f9 & 4u) != 0)
		{
			xd8f1949f8950238a.xcc7b76ceb682651c = xf0c7c54408628d77();
		}
		else if (((uint)x39db9913986852f9 & 8u) != 0 || ((uint)x39db9913986852f9 & 0x10u) != 0)
		{
			int num = x7450cc1e48712286.ReadInt32();
			xd8f1949f8950238a.xa086f258e4907f49 = new float[num];
			xd8f1949f8950238a.x76dec2960c4aa9cc = new float[num];
			for (int i = 0; i < num; i++)
			{
				xd8f1949f8950238a.x76dec2960c4aa9cc[i] = x7450cc1e48712286.ReadSingle();
			}
			for (int j = 0; j < num; j++)
			{
				xd8f1949f8950238a.xa086f258e4907f49[j] = x7450cc1e48712286.ReadSingle();
			}
		}
	}

	private void x9f406ded10a795d5()
	{
		x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadSingle();
		x7450cc1e48712286.ReadSingle();
	}

	private xee3f81a88b302c10[] xf0c7c54408628d77()
	{
		int num = x7450cc1e48712286.ReadInt32();
		xee3f81a88b302c10[] array = new xee3f81a88b302c10[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new xee3f81a88b302c10();
		}
		for (int j = 0; j < num; j++)
		{
			array[j].xbe1e23e7d5b43370 = x7450cc1e48712286.ReadSingle();
		}
		for (int k = 0; k < num; k++)
		{
			array[k].x9b41425268471380 = x7450cc1e48712286.x458cbe2343cf2fba();
		}
		return array;
	}

	private xab391c46ff9a0a38 x719bc66992080d0d(int xebf45bdcaa1fd1e1)
	{
		if (((uint)xebf45bdcaa1fd1e1 & (true ? 1u : 0u)) != 0)
		{
			int num = x7450cc1e48712286.ReadInt32();
			long position = x7450cc1e48712286.BaseStream.Position;
			xab391c46ff9a0a38 result = x38c6a51d5e158139.xe6dd7bd4e532d8a6();
			x7450cc1e48712286.BaseStream.Position = position + num;
			return result;
		}
		return x38c6a51d5e158139.xc2ab51a3232e3fd7();
	}

	private x5e9754e56a4f759f xe257f7907403694a(long xf64b978577df3f2d)
	{
		int num = x7450cc1e48712286.ReadInt32();
		bool flag = (num & 2) != 0;
		WrapMode wrapMode = (WrapMode)x7450cc1e48712286.ReadInt32();
		x54366fa5f75a02f7 xaccac17571a8d9fa = null;
		if (flag)
		{
			xaccac17571a8d9fa = x7450cc1e48712286.x8c1dae79b4f085c4();
		}
		x273fb960e2b0a823 x273fb960e2b0a824 = x0557827b487b5834.x264f3cba2f0b02e2(xf64b978577df3f2d);
		x5e9754e56a4f759f x5e9754e56a4f759f = new x5e9754e56a4f759f(x273fb960e2b0a824.x90427ee74997bf7a, wrapMode);
		x5e9754e56a4f759f.xaccac17571a8d9fa = xaccac17571a8d9fa;
		return x5e9754e56a4f759f;
	}

	private x5bdb4ba66c23277c x5b1bca528e9549a6()
	{
		HatchStyle hatchStyle = (HatchStyle)x7450cc1e48712286.ReadInt32();
		x26d9ecb4bdf0456d foreColor = x7450cc1e48712286.x458cbe2343cf2fba();
		x26d9ecb4bdf0456d backColor = x7450cc1e48712286.x458cbe2343cf2fba();
		return new x5bdb4ba66c23277c(hatchStyle, foreColor, backColor);
	}

	private xc020fa2f5133cba8 x922cac5f8853c472()
	{
		x26d9ecb4bdf0456d color = x7450cc1e48712286.x458cbe2343cf2fba();
		return new xc020fa2f5133cba8(color);
	}
}
