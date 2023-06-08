using System;
using System.Collections;
using System.Reflection;
using x13f1efc79617a47b;

namespace x4adf554d20d941a6;

[DefaultMember("Item")]
internal class xf3f447691ab38eee
{
	private x591c1d6e66408377 x48154453a08515ea;

	private x591c1d6e66408377 x147e76d0f1854537;

	private x3923a5fd933905d6 xc7d28a9d010ccced;

	private int x212ae880d15d2ed1 = -1;

	private int x57d3c0a64c1df452 = -1;

	private int xa6783d35566f8810 = -1;

	internal object x35cfcea4890f4e7d => x02ebdc12ebf86805;

	internal object x02ebdc12ebf86805 => xea7be2c7fab7809b(x5889562db4f087eb: false).x02ebdc12ebf86805;

	internal object xbc13914359462815 => xea7be2c7fab7809b(x5889562db4f087eb: true).x6e64c31f094eb1d7?.x02ebdc12ebf86805;

	internal object x3e8d56eefc6dfdad => xea7be2c7fab7809b(x5889562db4f087eb: true).xe660eb6ec8beb0b4?.x02ebdc12ebf86805;

	internal int x12cb12b5d2cad53d
	{
		get
		{
			xea7be2c7fab7809b(x5889562db4f087eb: true);
			return x212ae880d15d2ed1;
		}
	}

	internal int x9fd888e65466818c
	{
		get
		{
			x591c1d6e66408377 x591c1d6e66408378 = xea7be2c7fab7809b(x5889562db4f087eb: true);
			return x212ae880d15d2ed1 + x591c1d6e66408378.x1be93eed8950d961;
		}
	}

	internal int xd1bdf42207dd3638
	{
		get
		{
			xea7be2c7fab7809b(x5889562db4f087eb: true);
			return x57d3c0a64c1df452;
		}
	}

	internal int x1be93eed8950d961
	{
		get
		{
			return xea7be2c7fab7809b(x5889562db4f087eb: true).x1be93eed8950d961;
		}
		set
		{
			xea7be2c7fab7809b(x5889562db4f087eb: true).xd6d0700e6673d965(value);
			x461c3bf969128260();
		}
	}

	internal bool xaea770a91df1e1ea => xea7be2c7fab7809b(x5889562db4f087eb: true).xe660eb6ec8beb0b4 == null;

	internal bool x45ef6ccec2bafbfc => xea7be2c7fab7809b(x5889562db4f087eb: true).x6e64c31f094eb1d7 == null;

	internal bool x30d6662e83251ab4 => null == x40212106aad8a8b0;

	internal bool x7149c962c02931b3 => x29e7ace4c90f74cd.x7149c962c02931b3;

	internal bool x65fd966a6b330c28 => xea7be2c7fab7809b(x5889562db4f087eb: false).x65fd966a6b330c28;

	internal bool xd5bbb2ab5553d8fb
	{
		get
		{
			if (x40212106aad8a8b0 == null)
			{
				return xf4a074b47b476983 != null;
			}
			return false;
		}
	}

	internal int xd44988f225497f3a
	{
		get
		{
			if (!x7149c962c02931b3)
			{
				return x29e7ace4c90f74cd.xd44988f225497f3a;
			}
			return 0;
		}
	}

	internal int x851fcfc17df82b1b
	{
		get
		{
			if (!x7149c962c02931b3)
			{
				return x29e7ace4c90f74cd.x1be93eed8950d961;
			}
			return 0;
		}
	}

	internal object xe6d4b1b411ed94b5
	{
		get
		{
			if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= xd44988f225497f3a)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (xc0c4c459c6ccbd00 == xd1bdf42207dd3638)
			{
				return x02ebdc12ebf86805;
			}
			int x959806ebd6fe6e4d;
			return xc7d28a9d010ccced.xe8e30285aadb80e2(xc0c4c459c6ccbd00, out x959806ebd6fe6e4d).x02ebdc12ebf86805;
		}
		set
		{
			if (!x5ac0827b4f4f9da7(xc0c4c459c6ccbd00))
			{
				throw new ArgumentOutOfRangeException("index");
			}
			x7367fd2718f95052(value, 1);
		}
	}

	private x591c1d6e66408377 x40212106aad8a8b0
	{
		get
		{
			x00023b62d86f44fb();
			return x48154453a08515ea;
		}
		set
		{
			x461c3bf969128260();
			x48154453a08515ea = value;
		}
	}

	private x591c1d6e66408377 xf4a074b47b476983
	{
		get
		{
			x00023b62d86f44fb();
			return x147e76d0f1854537;
		}
		set
		{
			x461c3bf969128260();
			x147e76d0f1854537 = value;
		}
	}

	private x591c1d6e66408377 x29e7ace4c90f74cd => xc7d28a9d010ccced.x29e7ace4c90f74cd;

	internal xf3f447691ab38eee()
		: this(isEasy: false)
	{
	}

	internal xf3f447691ab38eee(bool isEasy)
	{
		xc7d28a9d010ccced = new x3923a5fd933905d6(isEasy);
	}

	internal void x74f5a1ef3906e23c()
	{
		xf4a074b47b476983 = null;
		x40212106aad8a8b0 = null;
		x57d3c0a64c1df452 = -1;
		x212ae880d15d2ed1 = -1;
	}

	internal bool x47f176deff0d42e2()
	{
		if (x7149c962c02931b3)
		{
			return false;
		}
		x591c1d6e66408377 x591c1d6e66408378 = x40212106aad8a8b0;
		if (x591c1d6e66408378 == null)
		{
			if (xf4a074b47b476983 == null)
			{
				return x6cfb41b4bd00d940();
			}
			return false;
		}
		x57d3c0a64c1df452++;
		x212ae880d15d2ed1 += x591c1d6e66408378.x1be93eed8950d961;
		xf4a074b47b476983 = x591c1d6e66408378;
		x40212106aad8a8b0 = x40212106aad8a8b0.x6e64c31f094eb1d7;
		return x40212106aad8a8b0 != null;
	}

	internal bool x355eaee82ffc1f46()
	{
		if (x7149c962c02931b3)
		{
			return false;
		}
		x591c1d6e66408377 x591c1d6e66408378 = xf4a074b47b476983;
		if (x591c1d6e66408378 == null)
		{
			if (x40212106aad8a8b0 == null)
			{
				return false;
			}
			x57d3c0a64c1df452 = -1;
			x212ae880d15d2ed1 = -1;
			x40212106aad8a8b0 = null;
			return false;
		}
		x57d3c0a64c1df452--;
		x212ae880d15d2ed1 -= x591c1d6e66408378.x1be93eed8950d961;
		x40212106aad8a8b0 = x591c1d6e66408378;
		xf4a074b47b476983 = xf4a074b47b476983.xe660eb6ec8beb0b4;
		return true;
	}

	internal bool x6cfb41b4bd00d940()
	{
		if (x7149c962c02931b3)
		{
			return false;
		}
		x40212106aad8a8b0 = xc7d28a9d010ccced.xe8e30285aadb80e2(x57d3c0a64c1df452 = 0, out x212ae880d15d2ed1);
		xf4a074b47b476983 = null;
		return true;
	}

	internal bool x77a51022b61a6b12()
	{
		if (x7149c962c02931b3)
		{
			return false;
		}
		x40212106aad8a8b0 = xc7d28a9d010ccced.xe8e30285aadb80e2(x57d3c0a64c1df452 = x29e7ace4c90f74cd.xd44988f225497f3a - 1, out x212ae880d15d2ed1);
		xf4a074b47b476983 = x40212106aad8a8b0.xe660eb6ec8beb0b4;
		return true;
	}

	internal bool xd8b11076ff837685(object xf377779f33c1c51a)
	{
		x2a47d72617257c5b();
		if (x40212106aad8a8b0 != null && x35cfcea4890f4e7d == xf377779f33c1c51a)
		{
			return true;
		}
		x591c1d6e66408377 x591c1d6e66408378 = x02b56011810c316c(xf377779f33c1c51a);
		if (x591c1d6e66408378 == null)
		{
			return false;
		}
		x40212106aad8a8b0 = x591c1d6e66408378;
		xc7d28a9d010ccced.x34c9e5c6515a01be(x591c1d6e66408378, out x212ae880d15d2ed1, out x57d3c0a64c1df452);
		xf4a074b47b476983 = x591c1d6e66408378.xe660eb6ec8beb0b4;
		return true;
	}

	internal bool x09bc5a81d8da69cf(int x10aaa7cdfa38f254)
	{
		if (x7149c962c02931b3)
		{
			return false;
		}
		if (0 > x10aaa7cdfa38f254 || x10aaa7cdfa38f254 > x851fcfc17df82b1b)
		{
			return false;
		}
		x591c1d6e66408377 x591c1d6e66408378 = xc7d28a9d010ccced.xc45b21733534efc0(x10aaa7cdfa38f254, out x212ae880d15d2ed1, out x57d3c0a64c1df452);
		if (x10aaa7cdfa38f254 == x851fcfc17df82b1b && 0 < x591c1d6e66408378.x1be93eed8950d961)
		{
			return false;
		}
		x40212106aad8a8b0 = x591c1d6e66408378;
		xf4a074b47b476983 = x591c1d6e66408378.xe660eb6ec8beb0b4;
		return true;
	}

	internal bool x5ac0827b4f4f9da7(int xc0c4c459c6ccbd00)
	{
		if (x7149c962c02931b3)
		{
			return false;
		}
		if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= xd44988f225497f3a)
		{
			return false;
		}
		x40212106aad8a8b0 = xc7d28a9d010ccced.xe8e30285aadb80e2(x57d3c0a64c1df452 = xc0c4c459c6ccbd00, out x212ae880d15d2ed1);
		xf4a074b47b476983 = x40212106aad8a8b0.xe660eb6ec8beb0b4;
		return true;
	}

	internal void x7367fd2718f95052(object xf377779f33c1c51a, int x961016a387451f05)
	{
		x591c1d6e66408377 x591c1d6e66408378 = xea7be2c7fab7809b(x5889562db4f087eb: true);
		xde11bc5d740d3ee3(x591c1d6e66408378);
		x591c1d6e66408378.x02ebdc12ebf86805 = xf377779f33c1c51a;
		x1be93eed8950d961 = x961016a387451f05;
		x2a0cb95ab84ba877(x591c1d6e66408378);
	}

	internal bool xef23aa45e7612fdd(object xf377779f33c1c51a, int x961016a387451f05)
	{
		if (x961016a387451f05 < 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		x591c1d6e66408377 x591c1d6e66408378 = x29e7ace4c90f74cd;
		if (x591c1d6e66408378.x7149c962c02931b3)
		{
			xf4a074b47b476983 = x591c1d6e66408378;
			x591c1d6e66408378.x02ebdc12ebf86805 = xf377779f33c1c51a;
			x591c1d6e66408378.xd6d0700e6673d965(x961016a387451f05);
			x2a0cb95ab84ba877(x591c1d6e66408378);
			x212ae880d15d2ed1 = x961016a387451f05;
			x57d3c0a64c1df452 = 1;
		}
		else
		{
			x591c1d6e66408377 x591c1d6e66408379 = x40212106aad8a8b0;
			x591c1d6e66408377 x591c1d6e66408380 = xf4a074b47b476983;
			if (x591c1d6e66408379 == null && x591c1d6e66408380 == null)
			{
				return false;
			}
			if (x591c1d6e66408379 == null)
			{
				xf4a074b47b476983 = x591c1d6e66408380.x917b69030691beda(xf377779f33c1c51a, x961016a387451f05).x6e64c31f094eb1d7;
				x2a0cb95ab84ba877(xf4a074b47b476983);
			}
			else
			{
				x40212106aad8a8b0 = x591c1d6e66408379.xef23aa45e7612fdd(xf377779f33c1c51a, x961016a387451f05);
				xf4a074b47b476983 = x40212106aad8a8b0.xe660eb6ec8beb0b4;
				x2a0cb95ab84ba877(xf4a074b47b476983);
			}
			x57d3c0a64c1df452++;
			x212ae880d15d2ed1 += x961016a387451f05;
		}
		return true;
	}

	internal bool x917b69030691beda(object xf377779f33c1c51a, int x961016a387451f05)
	{
		if (0 > x961016a387451f05)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		x591c1d6e66408377 x591c1d6e66408378 = x29e7ace4c90f74cd;
		if (x591c1d6e66408378.x7149c962c02931b3)
		{
			x591c1d6e66408378.x02ebdc12ebf86805 = xf377779f33c1c51a;
			x591c1d6e66408378.xd6d0700e6673d965(x961016a387451f05);
			x2a0cb95ab84ba877(x591c1d6e66408378);
		}
		else
		{
			x591c1d6e66408377 x591c1d6e66408379 = x40212106aad8a8b0;
			if (x591c1d6e66408379 == null && xf4a074b47b476983 != null)
			{
				return false;
			}
			if (x591c1d6e66408379 == null)
			{
				x2a0cb95ab84ba877(xc7d28a9d010ccced.xe8e30285aadb80e2(0, out var _).xef23aa45e7612fdd(xf377779f33c1c51a, x961016a387451f05).xe660eb6ec8beb0b4);
			}
			else
			{
				x40212106aad8a8b0 = x591c1d6e66408379.x917b69030691beda(xf377779f33c1c51a, x961016a387451f05);
				x2a0cb95ab84ba877(x40212106aad8a8b0.x6e64c31f094eb1d7);
			}
		}
		return true;
	}

	internal bool x240a962b838217cd()
	{
		x591c1d6e66408377 x591c1d6e66408378 = xea7be2c7fab7809b(x5889562db4f087eb: true);
		xde11bc5d740d3ee3(x591c1d6e66408378);
		if (x591c1d6e66408378 != null)
		{
			x40212106aad8a8b0 = x591c1d6e66408378.xddae736767606eb7();
		}
		if (x7149c962c02931b3)
		{
			x74f5a1ef3906e23c();
		}
		x591c1d6e66408378 = x40212106aad8a8b0;
		if (x591c1d6e66408378 == null)
		{
			return false;
		}
		xf4a074b47b476983 = x591c1d6e66408378.xe660eb6ec8beb0b4;
		return true;
	}

	internal xf3f447691ab38eee x8b61531c8ea35b85()
	{
		xf3f447691ab38eee xf3f447691ab38eee2 = new xf3f447691ab38eee();
		xf3f447691ab38eee2.xef60925995ccc50b(this);
		return xf3f447691ab38eee2;
	}

	internal static bool x9978ad5f8a55aa53(xf3f447691ab38eee x54d7f876d24eeeed, xf3f447691ab38eee x85a72f5e2a81f699)
	{
		if (x54d7f876d24eeeed == null || x85a72f5e2a81f699 == null)
		{
			return false;
		}
		if (x54d7f876d24eeeed.x40212106aad8a8b0 == x85a72f5e2a81f699.x40212106aad8a8b0)
		{
			return x54d7f876d24eeeed.x57d3c0a64c1df452 == x85a72f5e2a81f699.x57d3c0a64c1df452;
		}
		return false;
	}

	internal static object x83f07df6a659e05b(xf3f447691ab38eee xd435475894411eea, object xa59bff7708de3a18)
	{
		xf3f447691ab38eee xf3f447691ab38eee2 = xd435475894411eea.x8b61531c8ea35b85();
		if (!xf3f447691ab38eee2.xd8b11076ff837685(xa59bff7708de3a18))
		{
			throw new InvalidOperationException();
		}
		if (!xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			return null;
		}
		return xf3f447691ab38eee2.x35cfcea4890f4e7d;
	}

	internal static object xda0d8384ac6ee2cb(xf3f447691ab38eee xd435475894411eea, object xa59bff7708de3a18)
	{
		xf3f447691ab38eee xf3f447691ab38eee2 = xd435475894411eea.x8b61531c8ea35b85();
		if (!xf3f447691ab38eee2.xd8b11076ff837685(xa59bff7708de3a18))
		{
			throw new InvalidOperationException();
		}
		if (!xf3f447691ab38eee2.x355eaee82ffc1f46())
		{
			return null;
		}
		return xf3f447691ab38eee2.x35cfcea4890f4e7d;
	}

	internal void x0fe4f26e70030075(Array x9d5750eb2d6373bc, int xc0c4c459c6ccbd00)
	{
		ArrayList arrayList = new ArrayList();
		xf3f447691ab38eee xf3f447691ab38eee2 = x8b61531c8ea35b85();
		xf3f447691ab38eee2.x74f5a1ef3906e23c();
		while (xf3f447691ab38eee2.x47f176deff0d42e2())
		{
			arrayList.Add(xf3f447691ab38eee2.x02ebdc12ebf86805);
		}
		arrayList.CopyTo(x9d5750eb2d6373bc, xc0c4c459c6ccbd00);
	}

	private bool xef60925995ccc50b(xf3f447691ab38eee xd435475894411eea)
	{
		if (xd435475894411eea.xc7d28a9d010ccced == xc7d28a9d010ccced || x7149c962c02931b3)
		{
			xc7d28a9d010ccced = xd435475894411eea.xc7d28a9d010ccced;
			x40212106aad8a8b0 = xd435475894411eea.x40212106aad8a8b0;
			xf4a074b47b476983 = xd435475894411eea.xf4a074b47b476983;
			x57d3c0a64c1df452 = xd435475894411eea.x57d3c0a64c1df452;
			x212ae880d15d2ed1 = xd435475894411eea.x212ae880d15d2ed1;
			xa6783d35566f8810 = xd435475894411eea.xa6783d35566f8810;
			return true;
		}
		return false;
	}

	private bool x461c3bf969128260()
	{
		if (xa6783d35566f8810 == xc7d28a9d010ccced.xc1bae07e5c2f641d)
		{
			return false;
		}
		xa6783d35566f8810 = xc7d28a9d010ccced.xc1bae07e5c2f641d;
		return true;
	}

	private void x2a47d72617257c5b()
	{
		if (xc7d28a9d010ccced.xbfff49744222e934)
		{
			throw new InvalidOperationException("Collection doesn't support this method.");
		}
	}

	private x591c1d6e66408377 xea7be2c7fab7809b(bool x5889562db4f087eb)
	{
		x591c1d6e66408377 x591c1d6e66408378 = x40212106aad8a8b0;
		if (x591c1d6e66408378 == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kolblpccfpjcppadpohdhkodnofeepmeojdfjokfhobgfjigfnpgeoghonnhlneilmlibncjenjjnhakjmhkjlokolflglmlbldmplkmghbn", 1797462934)));
		}
		if (x5889562db4f087eb && x591c1d6e66408378.x65fd966a6b330c28)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kbjjjeakdehkaeokadflgdmljddmcojmocbnobindcpnlbgogbnoecepnmkpdbcakbjaempapahbnaoblleceamceaddaakdgpaebphelpoegkffmomfoodgnjkgoobhpnihjnphbjgibnniknejenljbnckhmjkcmalanhlcmolfmfmbmmmohdn", 748460247)));
		}
		return x591c1d6e66408378;
	}

	private x591c1d6e66408377 x02b56011810c316c(object xf377779f33c1c51a)
	{
		return xc7d28a9d010ccced.x02b56011810c316c(xf377779f33c1c51a);
	}

	private void x2a0cb95ab84ba877(x591c1d6e66408377 xda5bf54deb817e37)
	{
		xc7d28a9d010ccced.x2a0cb95ab84ba877(xda5bf54deb817e37);
	}

	private void xde11bc5d740d3ee3(x591c1d6e66408377 xda5bf54deb817e37)
	{
		xc7d28a9d010ccced.xde11bc5d740d3ee3(xda5bf54deb817e37);
	}

	private void x00023b62d86f44fb()
	{
		if (!x461c3bf969128260())
		{
			return;
		}
		if (x7149c962c02931b3)
		{
			x48154453a08515ea = null;
			x147e76d0f1854537 = null;
			x57d3c0a64c1df452 = -1;
			x212ae880d15d2ed1 = -1;
			x461c3bf969128260();
		}
		else if (x48154453a08515ea == null)
		{
			if (x147e76d0f1854537 != null)
			{
				if (0 >= xd44988f225497f3a)
				{
					x48154453a08515ea = null;
					x147e76d0f1854537 = null;
					x57d3c0a64c1df452 = -1;
					x212ae880d15d2ed1 = -1;
				}
				else
				{
					x147e76d0f1854537 = xc7d28a9d010ccced.xe8e30285aadb80e2(xd44988f225497f3a - 1, out x212ae880d15d2ed1);
					x212ae880d15d2ed1 += x147e76d0f1854537.x1be93eed8950d961;
					x57d3c0a64c1df452++;
				}
			}
		}
		else if (x57d3c0a64c1df452 > xd44988f225497f3a - 1)
		{
			x48154453a08515ea = null;
			x147e76d0f1854537 = xc7d28a9d010ccced.xe8e30285aadb80e2(xd44988f225497f3a - 1, out x212ae880d15d2ed1);
			x212ae880d15d2ed1 += x147e76d0f1854537.x1be93eed8950d961;
			x57d3c0a64c1df452++;
		}
		else
		{
			x48154453a08515ea = xc7d28a9d010ccced.xe8e30285aadb80e2(x57d3c0a64c1df452, out x212ae880d15d2ed1);
			x147e76d0f1854537 = ((0 >= x57d3c0a64c1df452) ? null : x48154453a08515ea.xe660eb6ec8beb0b4);
		}
	}
}
