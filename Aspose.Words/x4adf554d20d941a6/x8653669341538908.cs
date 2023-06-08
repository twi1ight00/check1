using System.Drawing;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x8653669341538908
{
	private static readonly int x5c022f6b19a23d76 = x4574ea26106f0edb.x8d50b8a62ba1cd84(1.3);

	private readonly xf6937c72cebe4ad1 x03d592937b5e7bd3;

	internal xc8e01097217ac9d2 x92e7e5f35452590d
	{
		get
		{
			if (!x0f08225887d52683)
			{
				return xc8e01097217ac9d2.x45260ad4b94166f2;
			}
			return xfdc1a17f479acc42.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Left);
		}
	}

	internal xc8e01097217ac9d2 x0924cade9dc2d296
	{
		get
		{
			if (!x0f08225887d52683)
			{
				return xc8e01097217ac9d2.x45260ad4b94166f2;
			}
			return xfdc1a17f479acc42.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Right);
		}
	}

	internal xc8e01097217ac9d2 x9d329a00f2c534a8
	{
		get
		{
			if (xedd20abd47db3ccc(xcc36986f44d69e8f: false))
			{
				return ((x8d9303345f12a846)xfdc1a17f479acc42.x3e8d56eefc6dfdad).xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Horizontal);
			}
			if (x03d592937b5e7bd3.x708cb8686d32e467 && !x5566e2d2acbd1fbe.xd707791130626739(x03d592937b5e7bd3.x9c9d9095366398e8.x5566e2d2acbd1fbe))
			{
				return xfdc1a17f479acc42.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Top);
			}
			return xc8e01097217ac9d2.x45260ad4b94166f2;
		}
	}

	internal xc8e01097217ac9d2 x3903fbc9023c861c
	{
		get
		{
			if (!xedd20abd47db3ccc(xcc36986f44d69e8f: true) && x03d592937b5e7bd3.x55b6066f30988caf && !x5566e2d2acbd1fbe.xd707791130626739(x03d592937b5e7bd3.x9c9d9095366398e8.x5566e2d2acbd1fbe))
			{
				return xfdc1a17f479acc42.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Bottom);
			}
			return xc8e01097217ac9d2.x45260ad4b94166f2;
		}
	}

	internal int xa847225444f8728d
	{
		get
		{
			if (xedd20abd47db3ccc(xcc36986f44d69e8f: true))
			{
				return x4574ea26106f0edb.x8d50b8a62ba1cd84(xfdc1a17f479acc42.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Horizontal).x58316dde3396e982);
			}
			return x3903fbc9023c861c.x0b5855089a074d93;
		}
	}

	private bool x0f08225887d52683
	{
		get
		{
			if (x5566e2d2acbd1fbe.xd707791130626739(x03d592937b5e7bd3.x9c9d9095366398e8.x5566e2d2acbd1fbe))
			{
				return false;
			}
			x56410a8dd70087c5 x9c9d9095366398e = x03d592937b5e7bd3.x9c9d9095366398e8;
			if (x9c9d9095366398e.x5566e2d2acbd1fbe != 21788 && x9c9d9095366398e.x5566e2d2acbd1fbe != 21779)
			{
				return true;
			}
			if (x03d592937b5e7bd3.x957cd3867cc3a9f3 && x03d592937b5e7bd3.xd40b2068334ae37c)
			{
				return true;
			}
			return false;
		}
	}

	private x8d9303345f12a846 xfdc1a17f479acc42 => x03d592937b5e7bd3.x406d8cd2af514771;

	internal x8653669341538908(xf6937c72cebe4ad1 line)
	{
		x03d592937b5e7bd3 = line;
	}

	internal Rectangle xac997a026eea3281()
	{
		int num = x4574ea26106f0edb.x8d50b8a62ba1cd84(0.5);
		return x3557aa8566455ba9.x357582c772cd02ee(x03d592937b5e7bd3, -num, x03d592937b5e7bd3.xb0f146032f47c24e + 2 * num);
	}

	internal Rectangle xe6cffb3d72baa311()
	{
		int left = x7dde73b45af02539() - x4574ea26106f0edb.x8d50b8a62ba1cd84(x92e7e5f35452590d.x58316dde3396e982) - x5c022f6b19a23d76;
		int right = x03d592937b5e7bd3.xdc1bf80853046136 + x4574ea26106f0edb.x8d50b8a62ba1cd84(x0924cade9dc2d296.x58316dde3396e982) + x5c022f6b19a23d76;
		int num = 0;
		if (!x20e68f59609eb76f(xcc36986f44d69e8f: false))
		{
			num += x03d592937b5e7bd3.x4e0afe70adcb4c39.xb5ed9629008a9978;
			num += x03d592937b5e7bd3.x4e0afe70adcb4c39.x9d329a00f2c534a8;
			num -= x4574ea26106f0edb.x8d50b8a62ba1cd84(x9d329a00f2c534a8.x58316dde3396e982);
		}
		int num2 = x03d592937b5e7bd3.xb0f146032f47c24e;
		if (!x20e68f59609eb76f(xcc36986f44d69e8f: true) && !x0a4f10c4cefd1687(x03d592937b5e7bd3))
		{
			num2 -= x03d592937b5e7bd3.x4e0afe70adcb4c39.x853fb708c04424c4;
			num2 -= x03d592937b5e7bd3.x4e0afe70adcb4c39.x3903fbc9023c861c;
			num2 += x4574ea26106f0edb.x8d50b8a62ba1cd84(x3903fbc9023c861c.x58316dde3396e982);
		}
		return Rectangle.FromLTRB(left, num, right, num2);
	}

	internal Rectangle x1049a67c4c918fe0()
	{
		int left = x7dde73b45af02539() - x92e7e5f35452590d.x0b5855089a074d93 - x5c022f6b19a23d76;
		int right = x03d592937b5e7bd3.xdc1bf80853046136 + x0924cade9dc2d296.x0b5855089a074d93 + x5c022f6b19a23d76;
		bool x7149c962c02931b = xfdc1a17f479acc42.xa79651e2f1a1416e.x554aca059bdf6d48.x7149c962c02931b3;
		int top = ((!xedd20abd47db3ccc(xcc36986f44d69e8f: false) && (!x7149c962c02931b || x9d329a00f2c534a8.xa853df7acdb217c8)) ? x03d592937b5e7bd3.x4e0afe70adcb4c39.xb5ed9629008a9978 : 0);
		int bottom = x03d592937b5e7bd3.xb0f146032f47c24e - ((!xedd20abd47db3ccc(xcc36986f44d69e8f: true) && !x0a4f10c4cefd1687(x03d592937b5e7bd3) && (!x7149c962c02931b || x3903fbc9023c861c.xa853df7acdb217c8)) ? x03d592937b5e7bd3.x4e0afe70adcb4c39.x853fb708c04424c4 : 0);
		return Rectangle.FromLTRB(left, top, right, bottom);
	}

	private static bool x0a4f10c4cefd1687(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		if (x311e7a92306d7199.x55b6066f30988caf && xa7a98231d4a67a0f.x1f634e91b242c296(x311e7a92306d7199) > 0)
		{
			return xa7a98231d4a67a0f.x9e990a54752db80d(x311e7a92306d7199.x406d8cd2af514771) == null;
		}
		return false;
	}

	internal bool xedd20abd47db3ccc(bool xcc36986f44d69e8f)
	{
		if (!xfdc1a17f479acc42.xedd20abd47db3ccc(xcc36986f44d69e8f))
		{
			return false;
		}
		if (!xcc36986f44d69e8f || !x03d592937b5e7bd3.x55b6066f30988caf || x03d592937b5e7bd3.xd40b2068334ae37c)
		{
			if (!xcc36986f44d69e8f && x03d592937b5e7bd3.xc0e56f2fca892328)
			{
				return !x03d592937b5e7bd3.x957cd3867cc3a9f3;
			}
			return false;
		}
		return true;
	}

	private int x7dde73b45af02539()
	{
		if (!x03d592937b5e7bd3.x708cb8686d32e467)
		{
			if (xfdc1a17f479acc42.xa79651e2f1a1416e.xc7d7e186f0ace1e0 >= 0)
			{
				return 0;
			}
			return xfdc1a17f479acc42.xa79651e2f1a1416e.xc7d7e186f0ace1e0;
		}
		if (xfdc1a17f479acc42.xa79651e2f1a1416e.xc7d7e186f0ace1e0 <= 0)
		{
			return 0;
		}
		return -xfdc1a17f479acc42.xa79651e2f1a1416e.xc7d7e186f0ace1e0;
	}

	private bool x20e68f59609eb76f(bool xcc36986f44d69e8f)
	{
		if (!xedd20abd47db3ccc(xcc36986f44d69e8f))
		{
			return false;
		}
		if (xcc36986f44d69e8f)
		{
			if (xfdc1a17f479acc42.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Horizontal).xa853df7acdb217c8)
			{
				return true;
			}
			x8d9303345f12a846 x8d9303345f12a847 = (x8d9303345f12a846)xfdc1a17f479acc42.xbc13914359462815;
			return !x8d9303345f12a847.xa79651e2f1a1416e.x554aca059bdf6d48.x7149c962c02931b3;
		}
		x8d9303345f12a846 x8d9303345f12a848 = (x8d9303345f12a846)xfdc1a17f479acc42.x3e8d56eefc6dfdad;
		if (x8d9303345f12a848.xa79651e2f1a1416e.xb70a9d14469748bf.get_xe6d4b1b411ed94b5(BorderType.Horizontal).xa853df7acdb217c8)
		{
			return true;
		}
		return !x8d9303345f12a848.xa79651e2f1a1416e.x554aca059bdf6d48.x7149c962c02931b3;
	}
}
