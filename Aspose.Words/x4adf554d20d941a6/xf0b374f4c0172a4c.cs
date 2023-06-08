using System;

namespace x4adf554d20d941a6;

internal class xf0b374f4c0172a4c
{
	internal readonly x56410a8dd70087c5 x38ced5a01a389303;

	internal readonly x56410a8dd70087c5 x851fcfc17df82b1b;

	private x56410a8dd70087c5 xb01da31da3ec3cd2;

	private int x57d3c0a64c1df452 = -1;

	internal object x35cfcea4890f4e7d => x067d56aec20cdd99;

	internal char x067d56aec20cdd99
	{
		get
		{
			x8e354ff644f4bd11();
			return x56410a8dd70087c5.xf9ad6fb78355fe13[xd1bdf42207dd3638];
		}
	}

	internal bool x30d6662e83251ab4 => 0 > xd1bdf42207dd3638;

	internal bool x45ef6ccec2bafbfc
	{
		get
		{
			x8e354ff644f4bd11();
			if (!x3903fb3e01e2a14f)
			{
				return false;
			}
			if (x56410a8dd70087c5.x61712f0b4f5455af == null)
			{
				return true;
			}
			if (x851fcfc17df82b1b == x56410a8dd70087c5)
			{
				return true;
			}
			return null == x57b3c9e650685d36(x56410a8dd70087c5.x61712f0b4f5455af, x38ced5a01a389303, x851fcfc17df82b1b, xa17853d20c8c42bd: true, x4d2b4f056cf5bb8b: true);
		}
	}

	internal bool xaea770a91df1e1ea
	{
		get
		{
			x8e354ff644f4bd11();
			if (xd1bdf42207dd3638 != 0)
			{
				return false;
			}
			if (x56410a8dd70087c5.x7f6ad514996fb03a == null)
			{
				return true;
			}
			if (x38ced5a01a389303 == x56410a8dd70087c5)
			{
				return true;
			}
			return null == x57b3c9e650685d36(x56410a8dd70087c5.x7f6ad514996fb03a, x38ced5a01a389303, x851fcfc17df82b1b, xa17853d20c8c42bd: false, x4d2b4f056cf5bb8b: true);
		}
	}

	internal x56410a8dd70087c5 x56410a8dd70087c5 => xb01da31da3ec3cd2;

	internal bool x3903fb3e01e2a14f
	{
		get
		{
			if (!x30d6662e83251ab4)
			{
				return xd1bdf42207dd3638 >= x6c1910d0394e6db5 - 1;
			}
			return false;
		}
	}

	internal int xd1bdf42207dd3638 => x57d3c0a64c1df452;

	private int x6c1910d0394e6db5
	{
		get
		{
			if (25604 == x56410a8dd70087c5.x5566e2d2acbd1fbe)
			{
				return 1;
			}
			if (x5566e2d2acbd1fbe.x6634ed9c1dfbdfce(x56410a8dd70087c5.x5566e2d2acbd1fbe) || x5566e2d2acbd1fbe.x20072aabf75d4ae4(x56410a8dd70087c5.x5566e2d2acbd1fbe))
			{
				return 1;
			}
			if (xfc6971c7d8314663.xe9605a4bea014f21 == x56410a8dd70087c5.xfc6971c7d8314663)
			{
				return 1;
			}
			if (x56410a8dd70087c5 is x61ebdec02c254c25)
			{
				return 1;
			}
			if (x56410a8dd70087c5 is xeec4aad197284fc1)
			{
				return 1;
			}
			return x56410a8dd70087c5.xf9ad6fb78355fe13.Length;
		}
	}

	internal xf0b374f4c0172a4c(x56410a8dd70087c5 first, x56410a8dd70087c5 after)
	{
		x38ced5a01a389303 = first;
		x851fcfc17df82b1b = after;
		x74f5a1ef3906e23c();
	}

	internal xf0b374f4c0172a4c(xf0b374f4c0172a4c src)
	{
		x38ced5a01a389303 = src.x38ced5a01a389303;
		x851fcfc17df82b1b = src.x851fcfc17df82b1b;
		x57d3c0a64c1df452 = src.xd1bdf42207dd3638;
		xb01da31da3ec3cd2 = src.x56410a8dd70087c5;
	}

	internal void x74f5a1ef3906e23c()
	{
		xf067dcd5f2631e2c(x38ced5a01a389303, xa17853d20c8c42bd: true);
		x57d3c0a64c1df452 = -1;
	}

	internal bool x355eaee82ffc1f46()
	{
		if (x30d6662e83251ab4)
		{
			return x77a51022b61a6b12();
		}
		if (xaea770a91df1e1ea)
		{
			x74f5a1ef3906e23c();
			return false;
		}
		if (xd1bdf42207dd3638 == 0)
		{
			xf067dcd5f2631e2c(x56410a8dd70087c5.x7f6ad514996fb03a, xa17853d20c8c42bd: false);
			x57d3c0a64c1df452 = Math.Max(0, x6c1910d0394e6db5 - 1);
		}
		else
		{
			x57d3c0a64c1df452--;
		}
		return true;
	}

	public bool x47f176deff0d42e2()
	{
		if (x30d6662e83251ab4)
		{
			return x6cfb41b4bd00d940();
		}
		if (x45ef6ccec2bafbfc)
		{
			x74f5a1ef3906e23c();
			return false;
		}
		if (x3903fb3e01e2a14f)
		{
			xf067dcd5f2631e2c(x56410a8dd70087c5.x61712f0b4f5455af, xa17853d20c8c42bd: true);
			x57d3c0a64c1df452 = 0;
		}
		else
		{
			x57d3c0a64c1df452++;
		}
		return true;
	}

	internal bool x6cfb41b4bd00d940()
	{
		xf067dcd5f2631e2c(x38ced5a01a389303, xa17853d20c8c42bd: true);
		x57d3c0a64c1df452 = 0;
		return true;
	}

	internal bool x77a51022b61a6b12()
	{
		xf067dcd5f2631e2c((x851fcfc17df82b1b == null) ? x38ced5a01a389303.x406d8cd2af514771.x2be2727bb322530e : x851fcfc17df82b1b, xa17853d20c8c42bd: false);
		x57d3c0a64c1df452 = Math.Max(0, x6c1910d0394e6db5 - 1);
		return true;
	}

	internal bool xcd61e66a5417dbee(x56410a8dd70087c5 x5906905c888d3d98, bool x2718ffc1fa17413a)
	{
		xf067dcd5f2631e2c(x5906905c888d3d98, xa17853d20c8c42bd: true);
		x57d3c0a64c1df452 = (x2718ffc1fa17413a ? Math.Max(0, x6c1910d0394e6db5 - 1) : 0);
		return true;
	}

	internal int x795e09a07e435cf4()
	{
		x8e354ff644f4bd11();
		return x56410a8dd70087c5.x8df91a2f90079e88 + xb01da31da3ec3cd2.x795e09a07e435cf4(xd1bdf42207dd3638);
	}

	internal int xc7c6550a888abaf3()
	{
		x8e354ff644f4bd11();
		if (1 < x6c1910d0394e6db5)
		{
			return xb01da31da3ec3cd2.xc7c6550a888abaf3(xd1bdf42207dd3638);
		}
		return x56410a8dd70087c5.xdc1bf80853046136;
	}

	internal static x56410a8dd70087c5 x57b3c9e650685d36(x56410a8dd70087c5 x5906905c888d3d98, x56410a8dd70087c5 x62584df2cb5d40dd, x56410a8dd70087c5 x0e990edf4549ee50, bool xa17853d20c8c42bd, bool x4d2b4f056cf5bb8b)
	{
		while (x5906905c888d3d98 != null)
		{
			if (x4d2b4f056cf5bb8b && x5906905c888d3d98.x6e414db5d060a816 != 0)
			{
				x5906905c888d3d98.x3e04636bf524a4cf(xb9e48f11d7f06ec9.x56410a8dd70087c5);
			}
			if (xc3ecc5d00810ca16(x5906905c888d3d98))
			{
				break;
			}
			if (xa17853d20c8c42bd)
			{
				x5906905c888d3d98 = x5906905c888d3d98.x61712f0b4f5455af;
				if (x0e990edf4549ee50 == x5906905c888d3d98)
				{
					return null;
				}
			}
			else
			{
				if (x62584df2cb5d40dd == x5906905c888d3d98)
				{
					return null;
				}
				x5906905c888d3d98 = x5906905c888d3d98.x7f6ad514996fb03a;
			}
		}
		return x5906905c888d3d98;
	}

	internal static bool xc3ecc5d00810ca16(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98 != null && x5906905c888d3d98.x5566e2d2acbd1fbe != 0)
		{
			if (x5906905c888d3d98.x5566e2d2acbd1fbe == 25604)
			{
				return !x5906905c888d3d98.x34251722ab416841.x109e3389933c23a8.x6f6877b222ed4153;
			}
			return true;
		}
		return false;
	}

	private void x8e354ff644f4bd11()
	{
		if (x30d6662e83251ab4)
		{
			throw new InvalidOperationException();
		}
	}

	private void xf067dcd5f2631e2c(x56410a8dd70087c5 x5906905c888d3d98, bool xa17853d20c8c42bd)
	{
		xb01da31da3ec3cd2 = x57b3c9e650685d36(x5906905c888d3d98, x38ced5a01a389303, x851fcfc17df82b1b, xa17853d20c8c42bd, x4d2b4f056cf5bb8b: true);
	}
}
