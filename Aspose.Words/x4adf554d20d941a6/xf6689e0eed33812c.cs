using System;
using System.Drawing;
using Aspose.Words;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xf6689e0eed33812c : xe0e644109215bf44
{
	private int x0b7e72a26f7327bd;

	private int x2e45ff5f0a2948db;

	private x398b3bd0acd94b61 x36ccd5de42275385;

	private x398b3bd0acd94b61 x4cd7424d920eaa9b;

	private x852fe8bb5ac31098 xb9034aaf42c9fc3c;

	private x852fe8bb5ac31098 x6587ead361935fb6;

	internal override x398b3bd0acd94b61 x8b8a0a04b3aeaf3a
	{
		get
		{
			return xb78c16d5f2d4f2f7;
		}
		set
		{
			xb78c16d5f2d4f2f7 = (x852fe8bb5ac31098)value;
		}
	}

	internal override x398b3bd0acd94b61 x7e2e5dd40daabc3b
	{
		get
		{
			return x279da4adfba57f2d;
		}
		set
		{
			x279da4adfba57f2d = (x852fe8bb5ac31098)value;
		}
	}

	internal override xcf9d359063aa93f2 x705ed5f9769744e5
	{
		set
		{
			if (x86a0dde4c22f516b != null && x86a0dde4c22f516b.x7149c962c02931b3)
			{
				x86a0dde4c22f516b.x52b190e626f65140();
			}
			xacf1bb6be5092987 x8f9d3ffcb9383cde = (xacf1bb6be5092987)value;
			xbba4ca0462c7486f.xe20e358641383748(this, x8f9d3ffcb9383cde);
			base.x705ed5f9769744e5 = value;
		}
	}

	internal override bool x5af8cb4dea1554b6
	{
		get
		{
			if (xb78c16d5f2d4f2f7 == null)
			{
				return null == x86a0dde4c22f516b;
			}
			return false;
		}
	}

	internal xc7f90d9c7c51cede x86a0dde4c22f516b
	{
		get
		{
			return (xc7f90d9c7c51cede)x36ccd5de42275385;
		}
		set
		{
			x36ccd5de42275385 = value;
		}
	}

	internal xc7f90d9c7c51cede x6d202aeb53f9cc93
	{
		get
		{
			return (xc7f90d9c7c51cede)x4cd7424d920eaa9b;
		}
		set
		{
			x4cd7424d920eaa9b = value;
		}
	}

	internal x852fe8bb5ac31098 xb78c16d5f2d4f2f7
	{
		get
		{
			return xb9034aaf42c9fc3c;
		}
		set
		{
			xb9034aaf42c9fc3c = value;
		}
	}

	internal x852fe8bb5ac31098 x279da4adfba57f2d
	{
		get
		{
			return x6587ead361935fb6;
		}
		set
		{
			x6587ead361935fb6 = value;
		}
	}

	internal xf6689e0eed33812c x0d6e7e3547c7244f => (xf6689e0eed33812c)base.xbc13914359462815;

	internal xf6689e0eed33812c x488a096134880397 => (xf6689e0eed33812c)base.x3e8d56eefc6dfdad;

	internal xacf1bb6be5092987 xf48cd6e82340ac70 => (xacf1bb6be5092987)x705ed5f9769744e5;

	internal x7c5d33e87d9dfc05 x874c84c476778297 => (x7c5d33e87d9dfc05)base.x332a8eedb847940d;

	internal int xf48b3ab5b294290c
	{
		get
		{
			Point point = x8f752b61013f63db(null);
			return Math.Max(0, point.Y - point.X);
		}
	}

	internal x2c0c9a4fb5b11521 x2c0c9a4fb5b11521 => ((x8d9303345f12a846)base.x88fee64dba8223f9).x2be2727bb322530e.x2c0c9a4fb5b11521;

	internal bool x25416a65ee993a54
	{
		get
		{
			if (!base.xc0e56f2fca892328)
			{
				return xa574fa8fe9296a1e(x488a096134880397.xf48cd6e82340ac70, xf48cd6e82340ac70);
			}
			return false;
		}
	}

	internal bool xf4ffaff1fc42f255
	{
		get
		{
			if (x0b7e72a26f7327bd == 0)
			{
				x0b7e72a26f7327bd = (xf94ea9a352e3e95f(StoryType.Footnotes) ? 1 : (-1));
			}
			return x0b7e72a26f7327bd > 0;
		}
	}

	internal bool x7aa2dc85faa80029
	{
		get
		{
			if (x2e45ff5f0a2948db == 0)
			{
				x2e45ff5f0a2948db = (xf94ea9a352e3e95f(StoryType.Endnotes) ? 1 : (-1));
			}
			return x2e45ff5f0a2948db > 0;
		}
	}

	internal override xc63cc34daaa2e2d9 x8b61531c8ea35b85()
	{
		xf6689e0eed33812c xf6689e0eed33812c2 = new xf6689e0eed33812c();
		xf6689e0eed33812c2.x705ed5f9769744e5 = x705ed5f9769744e5;
		return xf6689e0eed33812c2;
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x9a3a83b8a319b0ce(this);
	}

	internal override void x379ae16af0ba8e51()
	{
		base.x379ae16af0ba8e51();
		x0b7e72a26f7327bd = 0;
		x2e45ff5f0a2948db = 0;
	}

	internal override void xbc4db1b9481c1d31(x398b3bd0acd94b61 x1ec81c4ce7413e94, x398b3bd0acd94b61 xcc36986f44d69e8f, x398b3bd0acd94b61 xd7e5673853e47af4, bool x502d59bacbd3e16e)
	{
		if (xd7e5673853e47af4.x954503abc583f675 == x954503abc583f675.x4c38e800e85b21ad)
		{
			base.xbc4db1b9481c1d31(x1ec81c4ce7413e94, xcc36986f44d69e8f, xd7e5673853e47af4, x502d59bacbd3e16e);
		}
		else if (xd7e5673853e47af4.x954503abc583f675 == x954503abc583f675.xa65184d44a47025b)
		{
			if (xcc36986f44d69e8f == null && x1ec81c4ce7413e94 == null)
			{
				xcc36986f44d69e8f = x8169504189d1b21a();
			}
			if (xcc36986f44d69e8f == null && x1ec81c4ce7413e94 == null)
			{
				x1ec81c4ce7413e94 = x689dd9e8ff9ab4ee();
			}
			x32d613897fb9e89d(x1ec81c4ce7413e94, xcc36986f44d69e8f, xd7e5673853e47af4, ref x36ccd5de42275385, ref x4cd7424d920eaa9b);
			base.x332a8eedb847940d.xbc4db1b9481c1d31(x1ec81c4ce7413e94, xcc36986f44d69e8f, xd7e5673853e47af4, x502d59bacbd3e16e);
		}
	}

	internal override void x844530889595db77(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		switch (xd7e5673853e47af4.x954503abc583f675)
		{
		case x954503abc583f675.xa65184d44a47025b:
			base.x332a8eedb847940d.x844530889595db77(xd7e5673853e47af4);
			if (xd7e5673853e47af4.xbc13914359462815 != null)
			{
				xd7e5673853e47af4.xbc13914359462815.x3e8d56eefc6dfdad = xd7e5673853e47af4.x3e8d56eefc6dfdad;
			}
			if (xd7e5673853e47af4.x3e8d56eefc6dfdad != null)
			{
				xd7e5673853e47af4.x3e8d56eefc6dfdad.xbc13914359462815 = xd7e5673853e47af4.xbc13914359462815;
			}
			if (xd7e5673853e47af4 == x86a0dde4c22f516b)
			{
				x86a0dde4c22f516b = x86a0dde4c22f516b.x3d695937fd09df4b;
				if (x86a0dde4c22f516b != null && this != x86a0dde4c22f516b.x3c1c340351d94fbd)
				{
					x86a0dde4c22f516b = null;
				}
			}
			if (xd7e5673853e47af4 == x6d202aeb53f9cc93)
			{
				x6d202aeb53f9cc93 = x6d202aeb53f9cc93.x8f28a0c767ea3058;
				if (x6d202aeb53f9cc93 != null && this != x6d202aeb53f9cc93.x3c1c340351d94fbd)
				{
					x6d202aeb53f9cc93 = null;
				}
			}
			xd7e5673853e47af4.x332a8eedb847940d = null;
			break;
		case x954503abc583f675.x4c38e800e85b21ad:
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xd7e5673853e47af4;
			if (x852fe8bb5ac31099.xd10a74dc90155765())
			{
				x852fe8bb5ac31098[] array = x852fe8bb5ac31099.x1981d893a47031a5();
				if (xb78c16d5f2d4f2f7 == array[0])
				{
					xb78c16d5f2d4f2f7 = array[^1].xe202d610ff4b6eca;
				}
				if (x279da4adfba57f2d == array[^1])
				{
					x279da4adfba57f2d = array[0].xa7cb6e8d24f405a4;
				}
				if (array[0].x3e8d56eefc6dfdad != null)
				{
					array[0].x3e8d56eefc6dfdad.xbc13914359462815 = array[^1].xbc13914359462815;
				}
				if (array[^1].xbc13914359462815 != null)
				{
					array[^1].xbc13914359462815.x3e8d56eefc6dfdad = array[0].x3e8d56eefc6dfdad;
				}
				x852fe8bb5ac31098[] array2 = array;
				foreach (x852fe8bb5ac31098 x852fe8bb5ac31100 in array2)
				{
					x852fe8bb5ac31100.x332a8eedb847940d = null;
					x852fe8bb5ac31100.xbc13914359462815 = null;
					x852fe8bb5ac31100.x3e8d56eefc6dfdad = null;
					x852fe8bb5ac31100.x902d63c74e3c13c4 = null;
				}
			}
			break;
		}
		}
	}

	internal override x1073233de8252b3e x8db1e90bce56e416(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		if (xd7e5673853e47af4.x954503abc583f675 == x954503abc583f675.xa65184d44a47025b)
		{
			return null;
		}
		if (xd7e5673853e47af4.x954503abc583f675 != x954503abc583f675.x4c38e800e85b21ad)
		{
			return x2c79962f8e577d03((x1073233de8252b3e)xd7e5673853e47af4);
		}
		return xf47a265a80cede4a((x852fe8bb5ac31098)xd7e5673853e47af4);
	}

	internal Point x8f752b61013f63db(xc7f90d9c7c51cede xbbe2f7d7c86e0379)
	{
		x7c5d33e87d9dfc05 x7c5d33e87d9dfc6 = x874c84c476778297;
		int num = x5c28fdcd27dee7d9.xb5da8902547ab3e9((xbbe2f7d7c86e0379 != null) ? xbbe2f7d7c86e0379 : x86a0dde4c22f516b);
		bool flag = x0d299f323d241756.x7e32f71c3f39b6bc(num);
		int num2 = xf48cd6e82340ac70.x3fa6fa3075fd558f;
		int num3 = xf48cd6e82340ac70.xc8a7b7ce5c5279ee;
		if (x7c5d33e87d9dfc6.xde015839cc88f18d.x43c3a2f12150cda0 && !flag)
		{
			num2 = num3;
			num3 = xf48cd6e82340ac70.x3fa6fa3075fd558f;
		}
		int num4 = (x7c5d33e87d9dfc6.xde015839cc88f18d.xed289fa06fb7362c ? xf48cd6e82340ac70.x22f21a828a652fc4 : 0);
		if (xb132649a4fcd1812(flag))
		{
			num3 += num4;
		}
		else
		{
			num2 += num4;
		}
		return new Point(num3, xf48cd6e82340ac70.x3114e27f80122981 - num2);
	}

	internal static bool xa574fa8fe9296a1e(xacf1bb6be5092987 x977c45b0d9c82da2, xacf1bb6be5092987 x74551b590d6ef9a3)
	{
		if (x977c45b0d9c82da2.x3114e27f80122981 != x74551b590d6ef9a3.x3114e27f80122981 || x977c45b0d9c82da2.x995a78d99ada0d0c != x74551b590d6ef9a3.x995a78d99ada0d0c)
		{
			return false;
		}
		if (x977c45b0d9c82da2.xb81f492cce31314c != 0 && x74551b590d6ef9a3.xb81f492cce31314c != 0 && x977c45b0d9c82da2.xb81f492cce31314c != x74551b590d6ef9a3.xb81f492cce31314c)
		{
			return false;
		}
		if (x74551b590d6ef9a3.xe95664527db59e6e != 0)
		{
			if (x74551b590d6ef9a3.xe95664527db59e6e == SectionStart.NewColumn && x74551b590d6ef9a3.x6e1eb96b81362ebc > 1)
			{
				return x977c45b0d9c82da2.x6e1eb96b81362ebc == x74551b590d6ef9a3.x6e1eb96b81362ebc;
			}
			return false;
		}
		return true;
	}

	private x1073233de8252b3e xf47a265a80cede4a(x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		if (!xe3e287548b3d01f5.x057ec8a18573254e)
		{
			return xe3e287548b3d01f5.x902d63c74e3c13c4.xe38820c59d60221a;
		}
		if (x86a0dde4c22f516b != null && x86a0dde4c22f516b == x6d202aeb53f9cc93 && x86a0dde4c22f516b.x7149c962c02931b3)
		{
			return x86a0dde4c22f516b;
		}
		x852fe8bb5ac31098 x852fe8bb5ac31099 = xe3e287548b3d01f5.xe300dfe99be5b628(x2709983bf2ac093e: true);
		x852fe8bb5ac31098 x852fe8bb5ac31100 = xe3e287548b3d01f5.xd8eb808d98017237(x2709983bf2ac093e: true);
		xc7f90d9c7c51cede xc7f90d9c7c51cede2 = null;
		if (x852fe8bb5ac31099 == null && x852fe8bb5ac31100 == null)
		{
			xc7f90d9c7c51cede2 = new xc7f90d9c7c51cede();
			xbc4db1b9481c1d31(null, null, xc7f90d9c7c51cede2, x502d59bacbd3e16e: true);
			return xc7f90d9c7c51cede2;
		}
		xd06d3bea8939d096 xd06d3bea8939d97 = xb2b63301d0777314(x852fe8bb5ac31099, x852fe8bb5ac31100);
		bool flag = (xd06d3bea8939d97 & xd06d3bea8939d096.xfe44a05bc1a52c0e) == xd06d3bea8939d096.x3e8d56eefc6dfdad;
		switch (xd06d3bea8939d97 & ~xd06d3bea8939d096.xfe44a05bc1a52c0e)
		{
		case xd06d3bea8939d096.x3df13c9311a0ba9b:
			x852fe8bb5ac31099.xe38820c59d60221a.x3df13c9311a0ba9b(x852fe8bb5ac31099);
			xc7f90d9c7c51cede2 = (flag ? x852fe8bb5ac31099.xe38820c59d60221a : x852fe8bb5ac31100.xe38820c59d60221a);
			break;
		case xd06d3bea8939d096.xd6b6ed77479ef68c:
			xc7f90d9c7c51cede2 = new xc7f90d9c7c51cede();
			if (!flag && x852fe8bb5ac31100.xe38820c59d60221a != x852fe8bb5ac31100.x3c1c340351d94fbd.x86a0dde4c22f516b)
			{
				xbc4db1b9481c1d31(null, x852fe8bb5ac31100.x3c1c340351d94fbd.x86a0dde4c22f516b, xc7f90d9c7c51cede2, x502d59bacbd3e16e: true);
			}
			else
			{
				xbc4db1b9481c1d31(flag ? x852fe8bb5ac31099.xe38820c59d60221a : null, flag ? null : x852fe8bb5ac31100.xe38820c59d60221a, xc7f90d9c7c51cede2, x502d59bacbd3e16e: true);
			}
			break;
		case xd06d3bea8939d096.xc2b2e6b4f0f36c4e:
			xc7f90d9c7c51cede2 = (flag ? x852fe8bb5ac31099.xe38820c59d60221a : x852fe8bb5ac31100.xe38820c59d60221a);
			break;
		}
		if (x86a0dde4c22f516b == null || x86a0dde4c22f516b.x8f28a0c767ea3058 == xc7f90d9c7c51cede2)
		{
			x86a0dde4c22f516b = xc7f90d9c7c51cede2;
		}
		if (x6d202aeb53f9cc93 == null || x6d202aeb53f9cc93.x3d695937fd09df4b == xc7f90d9c7c51cede2)
		{
			x6d202aeb53f9cc93 = xc7f90d9c7c51cede2;
		}
		return xc7f90d9c7c51cede2;
	}

	private xd06d3bea8939d096 xb2b63301d0777314(x852fe8bb5ac31098 x1ec81c4ce7413e94, x852fe8bb5ac31098 xcc36986f44d69e8f)
	{
		if (x1ec81c4ce7413e94 == null && xcc36986f44d69e8f == null)
		{
			throw new InvalidOperationException();
		}
		if (xcc36986f44d69e8f == null)
		{
			if (this == x1ec81c4ce7413e94.x3c1c340351d94fbd || !x25416a65ee993a54)
			{
				return xd06d3bea8939d096.xd6b6ed77479ef68c | xd06d3bea8939d096.x3e8d56eefc6dfdad;
			}
			return xd06d3bea8939d096.xc2b2e6b4f0f36c4e | xd06d3bea8939d096.x3e8d56eefc6dfdad;
		}
		if (x1ec81c4ce7413e94 == null)
		{
			if (this == xcc36986f44d69e8f.x3c1c340351d94fbd || !xcc36986f44d69e8f.x3c1c340351d94fbd.x25416a65ee993a54)
			{
				return xd06d3bea8939d096.xd6b6ed77479ef68c | xd06d3bea8939d096.xbc13914359462815;
			}
			return xd06d3bea8939d096.xc2b2e6b4f0f36c4e | xd06d3bea8939d096.xbc13914359462815;
		}
		if (this == x1ec81c4ce7413e94.x3c1c340351d94fbd && this == xcc36986f44d69e8f.x3c1c340351d94fbd)
		{
			return xd06d3bea8939d096.xd6b6ed77479ef68c | xd06d3bea8939d096.x3e8d56eefc6dfdad;
		}
		if (this != x1ec81c4ce7413e94.x3c1c340351d94fbd && this != xcc36986f44d69e8f.x3c1c340351d94fbd)
		{
			if (x1ec81c4ce7413e94.xe38820c59d60221a == xcc36986f44d69e8f.xe38820c59d60221a)
			{
				if (x25416a65ee993a54)
				{
					return xd06d3bea8939d096.xc2b2e6b4f0f36c4e | xd06d3bea8939d096.x3e8d56eefc6dfdad;
				}
				return xd06d3bea8939d096.x3df13c9311a0ba9b | xd06d3bea8939d096.xbc13914359462815;
			}
			if (!x25416a65ee993a54)
			{
				if (xcc36986f44d69e8f.x3c1c340351d94fbd.x25416a65ee993a54)
				{
					return xd06d3bea8939d096.xc2b2e6b4f0f36c4e | xd06d3bea8939d096.xbc13914359462815;
				}
				return xd06d3bea8939d096.xd6b6ed77479ef68c | xd06d3bea8939d096.x3e8d56eefc6dfdad;
			}
			return xd06d3bea8939d096.xc2b2e6b4f0f36c4e | xd06d3bea8939d096.x3e8d56eefc6dfdad;
		}
		if (this != x1ec81c4ce7413e94.x3c1c340351d94fbd)
		{
			if (x1ec81c4ce7413e94.xe38820c59d60221a == xcc36986f44d69e8f.xe38820c59d60221a)
			{
				return xd06d3bea8939d096.x3df13c9311a0ba9b | xd06d3bea8939d096.x3e8d56eefc6dfdad;
			}
			if (x25416a65ee993a54)
			{
				return xd06d3bea8939d096.xc2b2e6b4f0f36c4e | xd06d3bea8939d096.x3e8d56eefc6dfdad;
			}
			return xd06d3bea8939d096.xd6b6ed77479ef68c | xd06d3bea8939d096.x3e8d56eefc6dfdad;
		}
		if (x1ec81c4ce7413e94.xe38820c59d60221a == xcc36986f44d69e8f.xe38820c59d60221a)
		{
			return xd06d3bea8939d096.x3df13c9311a0ba9b | xd06d3bea8939d096.xbc13914359462815;
		}
		if (xcc36986f44d69e8f.x3c1c340351d94fbd.x25416a65ee993a54)
		{
			return xd06d3bea8939d096.xc2b2e6b4f0f36c4e | xd06d3bea8939d096.xbc13914359462815;
		}
		return xd06d3bea8939d096.xd6b6ed77479ef68c | xd06d3bea8939d096.x3e8d56eefc6dfdad;
	}

	private x1073233de8252b3e x2c79962f8e577d03(x1073233de8252b3e xd7e5673853e47af4)
	{
		if (xb78c16d5f2d4f2f7 == null)
		{
			return x5d94b7b09969b646();
		}
		return xf4056147bc600053(xd7e5673853e47af4);
	}

	private x1073233de8252b3e x5d94b7b09969b646()
	{
		int x6e1eb96b81362ebc = xf48cd6e82340ac70.x6e1eb96b81362ebc;
		x852fe8bb5ac31098 x852fe8bb5ac31099 = null;
		while (0 < x6e1eb96b81362ebc--)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31100 = new x852fe8bb5ac31098();
			x852fe8bb5ac31100.x902d63c74e3c13c4 = ((x852fe8bb5ac31099 == null) ? x852fe8bb5ac31100 : x852fe8bb5ac31099.x902d63c74e3c13c4);
			xbc4db1b9481c1d31(x852fe8bb5ac31099, null, x852fe8bb5ac31100, x502d59bacbd3e16e: true);
			x852fe8bb5ac31099 = x852fe8bb5ac31100;
		}
		return xb78c16d5f2d4f2f7;
	}

	private x1073233de8252b3e xf4056147bc600053(x1073233de8252b3e xd7e5673853e47af4)
	{
		x1073233de8252b3e x1073233de8252b3e2 = xed77dfb32ff42060(xd7e5673853e47af4);
		if (x1073233de8252b3e2 == null)
		{
			x1073233de8252b3e2 = xcdbc2d1119be4621(xd7e5673853e47af4);
		}
		if (x1073233de8252b3e2 != null)
		{
			return x1073233de8252b3e2.xc255c495fd9232ca;
		}
		return xb78c16d5f2d4f2f7;
	}

	private xc7f90d9c7c51cede x689dd9e8ff9ab4ee()
	{
		xf6689e0eed33812c xf6689e0eed33812c2 = x488a096134880397;
		while (xf6689e0eed33812c2 != null && (xf6689e0eed33812c2.x6d202aeb53f9cc93 == null || x86a0dde4c22f516b == xf6689e0eed33812c2.x6d202aeb53f9cc93))
		{
			xf6689e0eed33812c2 = xf6689e0eed33812c2.x488a096134880397;
		}
		return xf6689e0eed33812c2?.x6d202aeb53f9cc93;
	}

	private xc7f90d9c7c51cede x8169504189d1b21a()
	{
		xf6689e0eed33812c xf6689e0eed33812c2 = x0d6e7e3547c7244f;
		while (xf6689e0eed33812c2 != null && (xf6689e0eed33812c2.x86a0dde4c22f516b == null || x6d202aeb53f9cc93 == xf6689e0eed33812c2.x86a0dde4c22f516b))
		{
			xf6689e0eed33812c2 = xf6689e0eed33812c2.x0d6e7e3547c7244f;
		}
		return xf6689e0eed33812c2?.x86a0dde4c22f516b;
	}

	private static x1073233de8252b3e xcdbc2d1119be4621(x1073233de8252b3e xd7e5673853e47af4)
	{
		x1073233de8252b3e x1073233de8252b3e2 = xd7e5673853e47af4;
		while (x1073233de8252b3e2 != null)
		{
			x1073233de8252b3e2 = x1073233de8252b3e2.xf34a54c031e96d83();
			if (x1073233de8252b3e2 != null && x1073233de8252b3e2.xc255c495fd9232ca != null)
			{
				break;
			}
		}
		return x1073233de8252b3e2;
	}

	private static x1073233de8252b3e xed77dfb32ff42060(x1073233de8252b3e xd7e5673853e47af4)
	{
		x1073233de8252b3e x1073233de8252b3e2 = xd7e5673853e47af4;
		while (x1073233de8252b3e2 != null)
		{
			x1073233de8252b3e2 = (x1073233de8252b3e)x1073233de8252b3e2.x7433e54c9b496d4d();
			if (x1073233de8252b3e2 != null && x1073233de8252b3e2.xc255c495fd9232ca != null)
			{
				break;
			}
		}
		return x1073233de8252b3e2;
	}

	private bool xf94ea9a352e3e95f(StoryType xdbbf47b5e620c262)
	{
		x8d9303345f12a846 x8d9303345f12a847 = (x8d9303345f12a846)base.x88fee64dba8223f9;
		x56410a8dd70087c5 x2be2727bb322530e = x8d9303345f12a847.x2be2727bb322530e;
		xf3f447691ab38eee xf3f447691ab38eee2 = x874c84c476778297.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		if (!xf3f447691ab38eee2.xd8b11076ff837685(x2be2727bb322530e))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gbonbdfoldmoiddpgdkpidbabohalcpakcgbocnbkbecaokc", 1048436179)));
		}
		while (xf3f447691ab38eee2.x355eaee82ffc1f46())
		{
			x2be2727bb322530e = (x56410a8dd70087c5)xf3f447691ab38eee2.x35cfcea4890f4e7d;
			if (x5566e2d2acbd1fbe.x74f5d3c8c1c169b6(x2be2727bb322530e.x5566e2d2acbd1fbe))
			{
				break;
			}
			if (x2be2727bb322530e.x00fa20d37841acd0 && x2be2727bb322530e is x92361dccfa0347fd && x2be2727bb322530e.xc0a853db762872fe == xdbbf47b5e620c262)
			{
				return true;
			}
		}
		return false;
	}

	private bool xb132649a4fcd1812(bool xbc603ebf7284f9b1)
	{
		if (xf48cd6e82340ac70.x279db1ca1dc68028)
		{
			bool x1b0b470b47c0d = x874c84c476778297.xde015839cc88f18d.x1b0b470b47c0d859;
			if (!xbc603ebf7284f9b1)
			{
				return x1b0b470b47c0d;
			}
			return false;
		}
		return xbc603ebf7284f9b1;
	}
}
