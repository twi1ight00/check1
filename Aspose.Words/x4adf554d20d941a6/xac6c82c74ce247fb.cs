using System;
using Aspose.Words;

namespace x4adf554d20d941a6;

internal abstract class xac6c82c74ce247fb : xc1e43d6be7c1713c
{
	private readonly x4e2f8bff72d83f71 xd1424e1a0bb4a72b;

	private xf3f447691ab38eee xb49921818fba1684;

	private x9c1c39fea4f7dcd1 x57c4f421a2435064;

	private int x975a9f4c5dd352ef;

	internal override x5a5e07e9fa12451a x5a5e07e9fa12451a => x5a5e07e9fa12451a.x53111d6596d16a99;

	internal override x4e2f8bff72d83f71 x2c8c6741422a1298 => xd1424e1a0bb4a72b;

	internal override xac6c82c74ce247fb x53111d6596d16a99 => this;

	internal int xe5a6c1d25602b220 => x975a9f4c5dd352ef;

	internal abstract StoryType xfe6cdb7c00822bd9 { get; }

	internal virtual bool x31fecf0961487c73 => true;

	internal virtual bool xf684fc5abe7ca67a => false;

	internal virtual bool x00ae9a426371c468 => false;

	internal int x1be93eed8950d961 => xb3a79d506b0e2f7f.x851fcfc17df82b1b;

	internal xf3f447691ab38eee xb3a79d506b0e2f7f
	{
		get
		{
			if (xb49921818fba1684 == null)
			{
				xb49921818fba1684 = new xf3f447691ab38eee();
			}
			return xb49921818fba1684;
		}
	}

	private bool x534ee0b3af8250b9
	{
		get
		{
			if (x57c4f421a2435064 != null)
			{
				return !x57c4f421a2435064.x7149c962c02931b3;
			}
			return false;
		}
	}

	private xe0e644109215bf44 x444be4b8c8c2ac63 => (xe0e644109215bf44)base.xa51d8d9790431b2b;

	private xe0e644109215bf44 xdfac74007cc0ddc8 => (xe0e644109215bf44)base.x88fee64dba8223f9;

	internal xac6c82c74ce247fb(x4e2f8bff72d83f71 documentLayout)
	{
		xd1424e1a0bb4a72b = documentLayout;
	}

	internal override void x633ccfccba9a2ba4()
	{
	}

	internal override void x0680d4cf02fbe4e3(object xe0292b9ed559da7d, x9352d7e557b05f9e xfbf34718e704c6bc)
	{
		if (x57c4f421a2435064 == null)
		{
			x57c4f421a2435064 = new x9c1c39fea4f7dcd1();
		}
		x57c4f421a2435064.xca34506722145a85(xe0292b9ed559da7d, xfbf34718e704c6bc);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x83b616de3d021401(this);
	}

	private static void xaab38e8fbc3d045c(int x26469c08e8e34aad)
	{
		if (x26469c08e8e34aad > 100000)
		{
			throw new InvalidOperationException("Infinite loop detected.");
		}
	}

	internal bool xc3819e13f60dd8e6(bool xfad304b5f8f3bb5b)
	{
		try
		{
			x51b09bddd13a48d7(2);
			do
			{
				if (x534ee0b3af8250b9)
				{
					x86363e17e0e2e60f(xfad304b5f8f3bb5b);
				}
				if (xe5764fe5359a6d91)
				{
					continue;
				}
				xaab38e8fbc3d045c(++x975a9f4c5dd352ef);
				int num = 0;
				xea876d525d28ff96 xea876d525d28ff97 = new xea876d525d28ff96();
				x398b3bd0acd94b61 x398b3bd0acd94b62 = x8b8a0a04b3aeaf3a;
				while (x398b3bd0acd94b62 != null)
				{
					xea876d525d28ff97.xc3819e13f60dd8e6(x398b3bd0acd94b62);
					if (!x398b3bd0acd94b62.x8c84b6fad60c11f5)
					{
						xaab38e8fbc3d045c(++num);
						x398b3bd0acd94b62 = x8b8a0a04b3aeaf3a;
					}
					else
					{
						x398b3bd0acd94b62 = x398b3bd0acd94b62.xbc13914359462815;
					}
				}
				xe5764fe5359a6d91 = true;
			}
			while (x534ee0b3af8250b9 && xfad304b5f8f3bb5b);
			return x534ee0b3af8250b9;
		}
		finally
		{
			x16d239165f7f2b5e();
		}
	}

	internal virtual x8d9303345f12a846 x4b2e8e22f36c8990(x41ac54db4e627dea x5906905c888d3d98)
	{
		x8d9303345f12a846 x8d9303345f12a847 = new x8d9303345f12a846();
		xe0e644109215bf44 xe0e644109215bf45;
		if (base.x909dc38ec7fc4d71)
		{
			xe0e644109215bf45 = xe0e644109215bf44.x6d9f6e0af7076f49(xfe6cdb7c00822bd9);
			x45a34609c70da3e5(null, null, xe0e644109215bf45);
			xe0e644109215bf45.x45a34609c70da3e5(null, null, x8d9303345f12a847);
		}
		else
		{
			xf3f447691ab38eee xf3f447691ab38eee2 = xb3a79d506b0e2f7f.x8b61531c8ea35b85();
			xf3f447691ab38eee2.x355eaee82ffc1f46();
			x41ac54db4e627dea x41ac54db4e627dea2 = (x41ac54db4e627dea)xf3f447691ab38eee2.x35cfcea4890f4e7d;
			x41ac54db4e627dea2.xf9f24914e9799bf9(x5906905c888d3d98);
			xe0e644109215bf45 = xdfac74007cc0ddc8;
			xe0e644109215bf45.x45a34609c70da3e5(xe0e644109215bf45.x88fee64dba8223f9, null, x8d9303345f12a847);
		}
		x8d9303345f12a847.x705ed5f9769744e5 = x5906905c888d3d98.xa79651e2f1a1416e;
		if (xf684fc5abe7ca67a)
		{
			xe0e644109215bf45.x705ed5f9769744e5 = x5906905c888d3d98.xa70fedcedcd0e1da;
			x705ed5f9769744e5 = x5906905c888d3d98.xc02a1028e62dfaf7;
		}
		return x8d9303345f12a847;
	}

	protected x8d9303345f12a846 x42c697007cbd48df(x41ac54db4e627dea x5906905c888d3d98)
	{
		xe0e644109215bf44 xe0e644109215bf45 = xe0e644109215bf44.x6d9f6e0af7076f49(xfe6cdb7c00822bd9);
		x45a34609c70da3e5(base.x88fee64dba8223f9, null, xe0e644109215bf45);
		x8d9303345f12a846 x8d9303345f12a847 = new x8d9303345f12a846();
		xe0e644109215bf45.x45a34609c70da3e5(null, null, x8d9303345f12a847);
		x8d9303345f12a847.x705ed5f9769744e5 = x5906905c888d3d98.xa79651e2f1a1416e;
		return x8d9303345f12a847;
	}

	internal void x521d36d9c4918b69()
	{
		if (!xf684fc5abe7ca67a)
		{
			x537642344a971881(this);
			return;
		}
		int num = -1;
		xc7f90d9c7c51cede xc7f90d9c7c51cede2 = null;
		for (xe0e644109215bf44 x185a13a95379e46d = x444be4b8c8c2ac63; x185a13a95379e46d != null; x185a13a95379e46d = x185a13a95379e46d.x185a13a95379e46d)
		{
			xf6689e0eed33812c xf6689e0eed33812c2 = (xf6689e0eed33812c)x185a13a95379e46d;
			xacf1bb6be5092987 xf48cd6e82340ac = xf6689e0eed33812c2.xf48cd6e82340ac70;
			if (xf48cd6e82340ac.x33683704df16e3dc <= 0)
			{
				x537642344a971881(x185a13a95379e46d);
			}
			else
			{
				if (num < 0 || xf48cd6e82340ac.x68f66930d0ba42cc == LineNumberRestartMode.RestartSection)
				{
					num = xf48cd6e82340ac.x5c85cf93a4f7077b;
				}
				for (xc63cc34daaa2e2d9 xc63cc34daaa2e2d10 = x185a13a95379e46d.xa51d8d9790431b2b; xc63cc34daaa2e2d10 != null; xc63cc34daaa2e2d10 = xc63cc34daaa2e2d10.xbc13914359462815)
				{
					if (xc63cc34daaa2e2d10.x5a5e07e9fa12451a == x5a5e07e9fa12451a.xfdc1a17f479acc42)
					{
						x8d9303345f12a846 x8d9303345f12a847 = (x8d9303345f12a846)xc63cc34daaa2e2d10;
						if (!x8d9303345f12a847.xa79651e2f1a1416e.x7acd3f5a41203a98)
						{
							for (xf6937c72cebe4ad1 xf6937c72cebe4ad2 = x8d9303345f12a847.x927910b7aed705e2; xf6937c72cebe4ad2 != null; xf6937c72cebe4ad2 = xf6937c72cebe4ad2.xbb84c6a76faa71e6)
							{
								xc7f90d9c7c51cede xc7f90d9c7c51cede3 = (xc7f90d9c7c51cede)xf6937c72cebe4ad2.xc255c495fd9232ca.xc255c495fd9232ca;
								if (xc7f90d9c7c51cede2 != xc7f90d9c7c51cede3 && xf48cd6e82340ac.x68f66930d0ba42cc == LineNumberRestartMode.RestartPage)
								{
									num = xf48cd6e82340ac.x5c85cf93a4f7077b;
								}
								xc7f90d9c7c51cede2 = xc7f90d9c7c51cede3;
								int num2 = ((num % xf48cd6e82340ac.x33683704df16e3dc == 0) ? 1 : (-1));
								xf6937c72cebe4ad2.x845183cdf0fdbeec = num2 * num;
								num++;
							}
							continue;
						}
					}
					x537642344a971881(xc63cc34daaa2e2d10);
				}
			}
		}
	}

	private void x86363e17e0e2e60f(bool xfad304b5f8f3bb5b)
	{
		x57c4f421a2435064.xbb7550bbb62a218c(xfad304b5f8f3bb5b);
	}

	private static void x537642344a971881(xc63cc34daaa2e2d9 x2612f62f94df47de)
	{
		if (x2612f62f94df47de.x5a5e07e9fa12451a == x5a5e07e9fa12451a.xfdc1a17f479acc42)
		{
			for (xf6937c72cebe4ad1 xf6937c72cebe4ad2 = ((x8d9303345f12a846)x2612f62f94df47de).x927910b7aed705e2; xf6937c72cebe4ad2 != null; xf6937c72cebe4ad2 = xf6937c72cebe4ad2.xbb84c6a76faa71e6)
			{
				xf6937c72cebe4ad2.x845183cdf0fdbeec = -1;
			}
		}
		else if (x2612f62f94df47de is xc1e43d6be7c1713c)
		{
			xc1e43d6be7c1713c xc1e43d6be7c1713c2 = (xc1e43d6be7c1713c)x2612f62f94df47de;
			for (xc63cc34daaa2e2d9 xc63cc34daaa2e2d10 = xc1e43d6be7c1713c2.xa51d8d9790431b2b; xc63cc34daaa2e2d10 != null; xc63cc34daaa2e2d10 = xc63cc34daaa2e2d10.xbc13914359462815)
			{
				x537642344a971881(xc63cc34daaa2e2d10);
			}
		}
	}
}
