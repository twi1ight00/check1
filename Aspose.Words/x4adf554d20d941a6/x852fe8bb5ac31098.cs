using System;
using System.Collections;
using System.Drawing;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x852fe8bb5ac31098 : x3d1ad8ce75f0db3a
{
	private xfbaf55d356868e77 x62c4f83d54f16980;

	private xd37fbb663b35a9f2 x32e0b0d8ae8d9e5f;

	private x41744f5ec654abee xb36e3f9b3f81a1ae;

	private int xc794f0423760ac5a;

	private x852fe8bb5ac31098 x9886858906e51a59;

	private bool x8bde59ad8b76db37;

	internal override x954503abc583f675 x954503abc583f675 => x954503abc583f675.x4c38e800e85b21ad;

	internal override xfbaf55d356868e77 x8faff3564372193a
	{
		get
		{
			if (x62c4f83d54f16980 == null)
			{
				x62c4f83d54f16980 = new xfbaf55d356868e77(this);
			}
			return x62c4f83d54f16980;
		}
		set
		{
			x62c4f83d54f16980 = value;
		}
	}

	internal override int xbcd477821fdbd81b
	{
		get
		{
			if (!xe5764fe5359a6d91)
			{
				return 0;
			}
			if (xc794f0423760ac5a == int.MinValue)
			{
				x398b3bd0acd94b61 x398b3bd0acd94b62 = xe0a65b356d2eb477(null);
				xc794f0423760ac5a = ((!base.x7149c962c02931b3) ? (x398b3bd0acd94b62.xc821290d7ecc08bf + Math.Max(x398b3bd0acd94b62.x319720dedc082a9d, x398b3bd0acd94b62.x851c2023f5f1cc29)) : 0);
			}
			return xc794f0423760ac5a;
		}
		set
		{
			xc794f0423760ac5a = value;
		}
	}

	internal override int x851c2023f5f1cc29
	{
		get
		{
			if (base.x7149c962c02931b3)
			{
				return 0;
			}
			x398b3bd0acd94b61 x398b3bd0acd94b62 = base.x7e2e5dd40daabc3b;
			if (base.x7e2e5dd40daabc3b.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
			{
				xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)base.x7e2e5dd40daabc3b;
				if (xf6937c72cebe4ad2.xe1a70206fe31f495() && !xf6937c72cebe4ad2.x149175c6cbc422b6())
				{
					if (base.x7e2e5dd40daabc3b == base.x8b8a0a04b3aeaf3a)
					{
						return 0;
					}
					x398b3bd0acd94b62 = x398b3bd0acd94b62.x9b2bbd3d05bf558b();
				}
			}
			return x398b3bd0acd94b62.xc821290d7ecc08bf + x398b3bd0acd94b62.x851c2023f5f1cc29;
		}
	}

	internal override int xf1d9b91c9700c401
	{
		get
		{
			if (!base.x7149c962c02931b3)
			{
				return base.x8b8a0a04b3aeaf3a.xf1d9b91c9700c401;
			}
			if (xe202d610ff4b6eca != null)
			{
				return xe202d610ff4b6eca.xf1d9b91c9700c401;
			}
			return xd8eb808d98017237(x2709983bf2ac093e: true)?.xf1d9b91c9700c401 ?? x3c1c340351d94fbd.x874c84c476778297.x1be93eed8950d961;
		}
	}

	internal override x4fdf549af9de6b97 x2d6658ad60c6ebe9
	{
		get
		{
			if (base.x2d6658ad60c6ebe9 == null)
			{
				xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
				ArrayList c = x3557aa8566455ba9.xc8eb0bace318b17e(this);
				x3557aa8566455ba9.x4957afcfd180c1b6(this, out var x241924dcc793876e, out var xca7a68ec9d87fd);
				xca7a68ec9d87fd.AddRange(c);
				xca7a68ec9d87fd.AddRange(x241924dcc793876e);
				int num = x3c6a5dd2a8130b74(this);
				x4fdf549af9de6b97 x4fdf549af9de6b = x72bd1f47182d0db1(this, num);
				if (x4fdf549af9de6b != null)
				{
					xca7a68ec9d87fd.Add(x4fdf549af9de6b);
					num += x4574ea26106f0edb.x8d50b8a62ba1cd84(2.0);
				}
				Rectangle xd1cff1e8f8666dbe = new Rectangle(-num, 0, xdc1bf80853046136 + num + xd624bff38c6aa886(this), xb0f146032f47c24e);
				x3557aa8566455ba9.x323e603293c20c04(xb8e7e788f6d, xd1cff1e8f8666dbe);
				x3557aa8566455ba9.xce92de628aa023cf(xb8e7e788f6d, x8df91a2f90079e88, xc821290d7ecc08bf);
				xb8e7e788f6d.xf82029c4e8b4cfc3((x4fdf549af9de6b97[])xca7a68ec9d87fd.ToArray(typeof(x4fdf549af9de6b97)));
				base.x2d6658ad60c6ebe9 = xb8e7e788f6d;
			}
			return base.x2d6658ad60c6ebe9;
		}
	}

	internal bool xdd62b6960d1f1486
	{
		get
		{
			if (x2c8c6741422a1298.x4af2add38e634ad4 != null)
			{
				return x2c8c6741422a1298.x4af2add38e634ad4.xd50f1a4545290fea == x902d63c74e3c13c4;
			}
			return false;
		}
	}

	internal x852fe8bb5ac31098 x902d63c74e3c13c4
	{
		get
		{
			return x9886858906e51a59;
		}
		set
		{
			x9886858906e51a59 = value;
		}
	}

	internal x852fe8bb5ac31098 xe202d610ff4b6eca => (x852fe8bb5ac31098)xbc13914359462815;

	internal x852fe8bb5ac31098 xa7cb6e8d24f405a4 => (x852fe8bb5ac31098)x3e8d56eefc6dfdad;

	internal xf6689e0eed33812c x3c1c340351d94fbd => (xf6689e0eed33812c)base.x332a8eedb847940d;

	internal xc7f90d9c7c51cede xe38820c59d60221a => (xc7f90d9c7c51cede)xc255c495fd9232ca;

	internal bool xca2d66057ac8daf2
	{
		get
		{
			if (xe202d610ff4b6eca != null)
			{
				return xe202d610ff4b6eca.x902d63c74e3c13c4 != x902d63c74e3c13c4;
			}
			return true;
		}
	}

	internal bool x76356d21d04ad431
	{
		get
		{
			if (xa7cb6e8d24f405a4 != null)
			{
				return xa7cb6e8d24f405a4.x902d63c74e3c13c4 != x902d63c74e3c13c4;
			}
			return true;
		}
	}

	internal bool x057ec8a18573254e => x902d63c74e3c13c4 == this;

	internal bool x719d3883357016d7 => this == xe38820c59d60221a.xb78c16d5f2d4f2f7;

	internal bool x35dcdaa8bc9d8066 => x3c1c340351d94fbd.x279da4adfba57f2d.x902d63c74e3c13c4 == x902d63c74e3c13c4;

	internal bool x70038175c6265c03 => x3c1c340351d94fbd.xb78c16d5f2d4f2f7.x902d63c74e3c13c4 == x902d63c74e3c13c4;

	internal bool x96b7fc879febe549
	{
		get
		{
			xf6689e0eed33812c x0d6e7e3547c7244f = x3c1c340351d94fbd.x0d6e7e3547c7244f;
			if (x35dcdaa8bc9d8066 && x0d6e7e3547c7244f != null && x0d6e7e3547c7244f.x25416a65ee993a54)
			{
				return x0d6e7e3547c7244f.xf48cd6e82340ac70.xe95664527db59e6e == SectionStart.Continuous;
			}
			return false;
		}
	}

	internal bool x651d91030eb7e7dc => xe38820c59d60221a.xb77b86477036a450 == x902d63c74e3c13c4;

	internal bool x0254c0720c5ee994 => xe38820c59d60221a.xf4861c9f1c09a8e7 == x902d63c74e3c13c4;

	internal x41744f5ec654abee x69d28a4aeef83a6f
	{
		get
		{
			return xb36e3f9b3f81a1ae;
		}
		set
		{
			if (xb36e3f9b3f81a1ae != null)
			{
				xb36e3f9b3f81a1ae.xc255c495fd9232ca = null;
			}
			if (value != null)
			{
				value.xc255c495fd9232ca = this;
			}
			xb36e3f9b3f81a1ae = value;
		}
	}

	internal xd37fbb663b35a9f2 xd90ac7fcbe961761
	{
		get
		{
			return x32e0b0d8ae8d9e5f;
		}
		set
		{
			if (x32e0b0d8ae8d9e5f != null)
			{
				x32e0b0d8ae8d9e5f.xc255c495fd9232ca = null;
			}
			if (value != null)
			{
				value.xc255c495fd9232ca = this;
			}
			x32e0b0d8ae8d9e5f = value;
		}
	}

	internal bool x6c98ade5b8f05ba3
	{
		get
		{
			return x8bde59ad8b76db37;
		}
		set
		{
			x8bde59ad8b76db37 = value;
		}
	}

	internal override bool x8786efe6471e0521 => x3c1c340351d94fbd.xf48cd6e82340ac70.x3a7473f820dd300b;

	internal override x398b3bd0acd94b61 xf432ece93e450408()
	{
		if (xe202d610ff4b6eca != null)
		{
			if (xe202d610ff4b6eca.xe38820c59d60221a != xe38820c59d60221a)
			{
				return null;
			}
			return xe202d610ff4b6eca;
		}
		x852fe8bb5ac31098 x852fe8bb5ac31099 = xd8eb808d98017237(x2709983bf2ac093e: true);
		if (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.xe38820c59d60221a == xe38820c59d60221a)
		{
			return x852fe8bb5ac31099;
		}
		return null;
	}

	internal override x398b3bd0acd94b61 x9b2bbd3d05bf558b()
	{
		if (xa7cb6e8d24f405a4 != null)
		{
			if (xa7cb6e8d24f405a4.xe38820c59d60221a != xe38820c59d60221a)
			{
				return null;
			}
			return xa7cb6e8d24f405a4;
		}
		x852fe8bb5ac31098 x852fe8bb5ac31099 = xe300dfe99be5b628(x2709983bf2ac093e: true);
		if (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.xe38820c59d60221a == xe38820c59d60221a)
		{
			return x852fe8bb5ac31099.x5458a425704f77fe();
		}
		return null;
	}

	internal override x1073233de8252b3e xfaf767ebc9bc84a6()
	{
		x852fe8bb5ac31098 x1ec81c4ce7413e = x5458a425704f77fe();
		x852fe8bb5ac31098[] array = x4fbd7c9db3969bce();
		for (int i = 0; i < array.Length; i++)
		{
			x3c1c340351d94fbd.xbc4db1b9481c1d31(x1ec81c4ce7413e, null, array[i], x502d59bacbd3e16e: true);
			x1ec81c4ce7413e = array[i];
		}
		return xd8eb808d98017237(x2709983bf2ac093e: false);
	}

	internal override void x3f71587805cc24f1(x398b3bd0acd94b61 xd7e5673853e47af4, x1073233de8252b3e x9e4d7279252bee4a)
	{
		if (x9e4d7279252bee4a == this)
		{
			return;
		}
		if (x9e4d7279252bee4a == null)
		{
			x9e4d7279252bee4a = xfaf767ebc9bc84a6();
		}
		x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)x9e4d7279252bee4a;
		if (!x2e5d97642b066554.x597e08db0a64a976(this, x852fe8bb5ac31099))
		{
			base.x3f71587805cc24f1(xd7e5673853e47af4, x9e4d7279252bee4a);
			return;
		}
		x398b3bd0acd94b61[] array = xae38dac157c088d7(null, xd7e5673853e47af4);
		x2e5d97642b066554.xbc843e6d2f8d6fe7(this, x9e4d7279252bee4a);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].xc255c495fd9232ca = this;
		}
		x82dd502013e451bb();
		x852fe8bb5ac31099.x82dd502013e451bb();
		x9e4d7279252bee4a.x8b8a0a04b3aeaf3a = xd7e5673853e47af4;
		x9e4d7279252bee4a.x7e2e5dd40daabc3b = base.x7e2e5dd40daabc3b;
		x53cb1139c5c64ee6 x53cb1139c5c64ee7 = (x53cb1139c5c64ee6)(base.x7e2e5dd40daabc3b = ((array.Length <= 0) ? null : ((x53cb1139c5c64ee6)array[^1])));
		if (x53cb1139c5c64ee7 == null)
		{
			base.x8b8a0a04b3aeaf3a = null;
		}
		xbba4ca0462c7486f.x1e82eb8399b05aec(xd7e5673853e47af4);
		if (xd10a74dc90155765())
		{
			x52b190e626f65140();
		}
	}

	private void x82dd502013e451bb()
	{
		if (x69d28a4aeef83a6f != null)
		{
			x69d28a4aeef83a6f.xc255c495fd9232ca = this;
		}
		if (xd90ac7fcbe961761 != null)
		{
			xd90ac7fcbe961761.xc255c495fd9232ca = this;
		}
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.xfd8c390a19c15ed4(this);
	}

	internal override bool x379ae16af0ba8e51(x6fcedf7742596b6c x03e443c02ed2213e)
	{
		if (base.x379ae16af0ba8e51(x03e443c02ed2213e))
		{
			return true;
		}
		if ((x03e443c02ed2213e & x6fcedf7742596b6c.x293cb50ee4c2a32d) != 0)
		{
			if (x69d28a4aeef83a6f != null)
			{
				x69d28a4aeef83a6f.x379ae16af0ba8e51(x03e443c02ed2213e);
			}
			if (xd90ac7fcbe961761 != null)
			{
				xd90ac7fcbe961761.x379ae16af0ba8e51(x03e443c02ed2213e);
			}
		}
		x0338412f4c07680b(this);
		return false;
	}

	internal void xd925d4a185f42cf1()
	{
		Point point = x3c1c340351d94fbd.x8f752b61013f63db(xe38820c59d60221a);
		int x = point.X;
		x852fe8bb5ac31098 x852fe8bb5ac31099 = this;
		int num = 0;
		int num2;
		if (x651d91030eb7e7dc)
		{
			num2 = xe38820c59d60221a.xd985b37e5f570f69;
		}
		else if (x6c98ade5b8f05ba3)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31100 = xe300dfe99be5b628(x2709983bf2ac093e: true);
			num2 = x852fe8bb5ac31100.xc821290d7ecc08bf;
			int num3 = xe38820c59d60221a.xd7fab63fabd0a319 - num2;
			x852fe8bb5ac31098 x852fe8bb5ac31101 = this;
			do
			{
				x852fe8bb5ac31101.x8df91a2f90079e88 = x852fe8bb5ac31100.x8df91a2f90079e88;
				x852fe8bb5ac31101.xdc1bf80853046136 = x852fe8bb5ac31100.xdc1bf80853046136;
				x852fe8bb5ac31101.xc821290d7ecc08bf = num2;
				x852fe8bb5ac31101.xb0f146032f47c24e = num3;
				x852fe8bb5ac31100 = x852fe8bb5ac31100.xe202d610ff4b6eca;
				x = x852fe8bb5ac31100.x8df91a2f90079e88;
				num++;
				x852fe8bb5ac31101 = x852fe8bb5ac31101.xe202d610ff4b6eca;
			}
			while (x852fe8bb5ac31101.x6c98ade5b8f05ba3);
			x852fe8bb5ac31099 = x852fe8bb5ac31101;
		}
		else
		{
			num2 = 0;
			x852fe8bb5ac31098 x852fe8bb5ac31102 = this;
			do
			{
				x852fe8bb5ac31102 = x852fe8bb5ac31102.xe300dfe99be5b628(x2709983bf2ac093e: true);
				for (x852fe8bb5ac31098 x852fe8bb5ac31103 = x852fe8bb5ac31102; x852fe8bb5ac31103 != null; x852fe8bb5ac31103 = x852fe8bb5ac31103.xe202d610ff4b6eca)
				{
					num2 = Math.Max(num2, x852fe8bb5ac31103.x9bcb07e204e30218);
				}
			}
			while (x852fe8bb5ac31102.x6c98ade5b8f05ba3);
		}
		int num4 = xe38820c59d60221a.xd7fab63fabd0a319 - num2;
		int num5 = num;
		int[] x78427d61ba29da6a = x3c1c340351d94fbd.xf48cd6e82340ac70.x78427d61ba29da6a;
		int num6 = x;
		x852fe8bb5ac31098 x852fe8bb5ac31104 = x852fe8bb5ac31099;
		while (x852fe8bb5ac31104 != null && x852fe8bb5ac31104.x902d63c74e3c13c4 == x902d63c74e3c13c4)
		{
			x852fe8bb5ac31104.x8df91a2f90079e88 = num6;
			x852fe8bb5ac31104.xdc1bf80853046136 = x78427d61ba29da6a[num5];
			x852fe8bb5ac31104.xc821290d7ecc08bf = num2;
			x852fe8bb5ac31104.xb0f146032f47c24e = num4;
			num6 = x852fe8bb5ac31104.x419ba17a5322627b + x3c1c340351d94fbd.xf48cd6e82340ac70.x0d71ce357d91dc77[num5];
			if (x8786efe6471e0521)
			{
				x852fe8bb5ac31104.x8df91a2f90079e88 = x69941bd1c058351f.x3b4006b36c0f801e(x852fe8bb5ac31104, point.X, point.Y);
			}
			x852fe8bb5ac31104 = x852fe8bb5ac31104.xe202d610ff4b6eca;
			num5++;
		}
	}

	internal x852fe8bb5ac31098 xd8eb808d98017237(bool x2709983bf2ac093e)
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = this;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == x902d63c74e3c13c4)
		{
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
		if (x852fe8bb5ac31099 == null && x2709983bf2ac093e)
		{
			xf6689e0eed33812c x0d6e7e3547c7244f = x3c1c340351d94fbd.x0d6e7e3547c7244f;
			while (x0d6e7e3547c7244f != null && x0d6e7e3547c7244f.xb78c16d5f2d4f2f7 == null)
			{
				x0d6e7e3547c7244f = x0d6e7e3547c7244f.x0d6e7e3547c7244f;
			}
			if (x0d6e7e3547c7244f != null)
			{
				x852fe8bb5ac31099 = x0d6e7e3547c7244f.xb78c16d5f2d4f2f7;
			}
		}
		if (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.xe38820c59d60221a == null)
		{
			return x852fe8bb5ac31099.xd8eb808d98017237(x2709983bf2ac093e);
		}
		return x852fe8bb5ac31099;
	}

	internal x852fe8bb5ac31098 xe300dfe99be5b628(bool x2709983bf2ac093e)
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4.xa7cb6e8d24f405a4;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099 != x852fe8bb5ac31099.x902d63c74e3c13c4)
		{
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xa7cb6e8d24f405a4;
		}
		if (x852fe8bb5ac31099 == null && x2709983bf2ac093e && x3c1c340351d94fbd.x488a096134880397 != null)
		{
			xf6689e0eed33812c x488a096134880397 = x3c1c340351d94fbd.x488a096134880397;
			while (x488a096134880397 != null && x488a096134880397.x279da4adfba57f2d == null)
			{
				x488a096134880397 = x488a096134880397.x488a096134880397;
			}
			if (x488a096134880397 != null)
			{
				x852fe8bb5ac31099 = x488a096134880397.x279da4adfba57f2d.x902d63c74e3c13c4;
			}
		}
		if (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.xe38820c59d60221a == null)
		{
			return x852fe8bb5ac31099.xe300dfe99be5b628(x2709983bf2ac093e);
		}
		return x852fe8bb5ac31099;
	}

	internal void x05d2302b6c276f0b(int xbcea506a33cf9111)
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == x902d63c74e3c13c4)
		{
			x852fe8bb5ac31099.xb0f146032f47c24e = xbcea506a33cf9111;
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
	}

	internal int xa8c2682cb8534de2()
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4;
		int num = 0;
		while (this != x852fe8bb5ac31099)
		{
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
			num++;
		}
		return num;
	}

	internal bool x345fbad4ac42bc22()
	{
		if (x5d30045af3da9a92.x6d1ba731495bf109(base.x332a8eedb847940d))
		{
			return false;
		}
		if (x3c1c340351d94fbd.xf48cd6e82340ac70.xd9248a16053b5d85 != FootnoteLocation.BottomOfPage)
		{
			return false;
		}
		if (!x9f30d5bed860fc9f())
		{
			return false;
		}
		return true;
	}

	internal bool xe555546649482e02()
	{
		if (x96b7fc879febe549)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4;
			while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == x902d63c74e3c13c4)
			{
				if (!x852fe8bb5ac31099.x7149c962c02931b3 && x852fe8bb5ac31099.x7e2e5dd40daabc3b.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
				{
					xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)x852fe8bb5ac31099.x7e2e5dd40daabc3b;
					x56410a8dd70087c5 x028068b313735e = xf6937c72cebe4ad2.x028068b313735e89;
					if (x5566e2d2acbd1fbe.xd707791130626739(x028068b313735e.x5566e2d2acbd1fbe))
					{
						return true;
					}
					if (x5566e2d2acbd1fbe.x32874f91c454ea5e(x028068b313735e.x5566e2d2acbd1fbe))
					{
						return false;
					}
				}
				x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
			}
		}
		return false;
	}

	internal bool x0ac0d07d9ef85b2b()
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == x902d63c74e3c13c4)
		{
			if (x852fe8bb5ac31099.x8b8a0a04b3aeaf3a != null || x852fe8bb5ac31099.x7e2e5dd40daabc3b != null)
			{
				return false;
			}
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
		return true;
	}

	internal bool xd10a74dc90155765()
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == x902d63c74e3c13c4)
		{
			if (!x852fe8bb5ac31099.x7149c962c02931b3)
			{
				return false;
			}
			if (x852fe8bb5ac31099.x69d28a4aeef83a6f != null)
			{
				return false;
			}
			if (x852fe8bb5ac31099.xd90ac7fcbe961761 != null)
			{
				return false;
			}
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
		return true;
	}

	internal bool x9f30d5bed860fc9f()
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == x902d63c74e3c13c4)
		{
			if (x852fe8bb5ac31099.x69d28a4aeef83a6f != null)
			{
				return true;
			}
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
		return false;
	}

	internal x852fe8bb5ac31098[] x1981d893a47031a5()
	{
		ArrayList arrayList = new ArrayList();
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == x902d63c74e3c13c4)
		{
			arrayList.Add(x852fe8bb5ac31099);
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
		return (x852fe8bb5ac31098[])arrayList.ToArray(typeof(x852fe8bb5ac31098));
	}

	internal bool x36922ecc460c7838()
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x902d63c74e3c13c4;
		while (x852fe8bb5ac31099 != null && x852fe8bb5ac31099.x902d63c74e3c13c4 == x902d63c74e3c13c4)
		{
			if (!x852fe8bb5ac31099.xe5764fe5359a6d91 || (x852fe8bb5ac31099.x69d28a4aeef83a6f != null && !x852fe8bb5ac31099.x69d28a4aeef83a6f.xe5764fe5359a6d91) || (x852fe8bb5ac31099.xd90ac7fcbe961761 != null && !x852fe8bb5ac31099.xd90ac7fcbe961761.xe5764fe5359a6d91))
			{
				return true;
			}
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
		return false;
	}

	internal x852fe8bb5ac31098 x5458a425704f77fe()
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = this;
		while (x852fe8bb5ac31099 != null && !x852fe8bb5ac31099.xca2d66057ac8daf2)
		{
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca;
		}
		return x852fe8bb5ac31099;
	}

	internal xf6937c72cebe4ad1 x37aedaff9d1efb6e()
	{
		x1073233de8252b3e x1073233de8252b3e2 = base.x07a46e7d2f46bb0e;
		if (x1073233de8252b3e2 != null && x1073233de8252b3e2.x954503abc583f675 == x954503abc583f675.xa19781cfbe8b4961)
		{
			x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)x1073233de8252b3e2;
			for (x86accec882b7012a x86accec882b7012a2 = x694f001896973fe4.x96ac59f61797f5b9; x86accec882b7012a2 != null; x86accec882b7012a2 = (x86accec882b7012a)x86accec882b7012a2.xf432ece93e450408())
			{
				x1073233de8252b3e2 = x86accec882b7012a2;
				while (x1073233de8252b3e2 != null && x954503abc583f675.x48cc0c3eaf9f5f05 != x1073233de8252b3e2.x954503abc583f675)
				{
					x1073233de8252b3e2 = (x1073233de8252b3e)x1073233de8252b3e2.x8b8a0a04b3aeaf3a;
				}
				if (x1073233de8252b3e2 != null)
				{
					break;
				}
			}
		}
		return (xf6937c72cebe4ad1)x1073233de8252b3e2;
	}

	internal Rectangle x1181ecbaa7830017(StoryType xdbbf47b5e620c262)
	{
		x78752dd11b777af5 x78752dd11b777af6 = ((xdbbf47b5e620c262 == StoryType.Footnotes) ? ((x78752dd11b777af5)x69d28a4aeef83a6f) : ((x78752dd11b777af5)xd90ac7fcbe961761));
		if (x78752dd11b777af6 == null || x78752dd11b777af6.x7149c962c02931b3)
		{
			return Rectangle.Empty;
		}
		x1073233de8252b3e x43604484a3deae4f = x78752dd11b777af6.x43604484a3deae4f;
		return new Rectangle(x43604484a3deae4f.x8df91a2f90079e88, x43604484a3deae4f.xc821290d7ecc08bf + x78752dd11b777af6.xc821290d7ecc08bf, x43604484a3deae4f.xdc1bf80853046136, x43604484a3deae4f.xb0f146032f47c24e);
	}

	internal x852fe8bb5ac31098 xf26f3fd618be2d13()
	{
		if (xa7cb6e8d24f405a4 != null)
		{
			return xa7cb6e8d24f405a4;
		}
		if (x3c1c340351d94fbd.x488a096134880397 != null)
		{
			return x3c1c340351d94fbd.x488a096134880397.x279da4adfba57f2d;
		}
		return null;
	}

	internal x852fe8bb5ac31098 x4eca8015611fb7a9()
	{
		if (xe202d610ff4b6eca != null)
		{
			return xe202d610ff4b6eca;
		}
		if (x3c1c340351d94fbd.x0d6e7e3547c7244f != null)
		{
			return x3c1c340351d94fbd.x0d6e7e3547c7244f.xb78c16d5f2d4f2f7;
		}
		return null;
	}

	internal x852fe8bb5ac31098[] x4fbd7c9db3969bce()
	{
		int x6e1eb96b81362ebc = x3c1c340351d94fbd.xf48cd6e82340ac70.x6e1eb96b81362ebc;
		x852fe8bb5ac31098[] array = new x852fe8bb5ac31098[x6e1eb96b81362ebc];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new x852fe8bb5ac31098();
			array[i].x902d63c74e3c13c4 = array[0];
		}
		return array;
	}

	internal bool x575869e737bace19()
	{
		if (x76356d21d04ad431)
		{
			return false;
		}
		x852fe8bb5ac31098 x852fe8bb5ac31099 = xa7cb6e8d24f405a4;
		if (x852fe8bb5ac31099.x6c98ade5b8f05ba3)
		{
			return false;
		}
		while (x852fe8bb5ac31099.x7149c962c02931b3 && !x852fe8bb5ac31099.x057ec8a18573254e)
		{
			x852fe8bb5ac31099 = x852fe8bb5ac31099.xa7cb6e8d24f405a4;
		}
		if (x852fe8bb5ac31099.x7149c962c02931b3)
		{
			return false;
		}
		if (x852fe8bb5ac31099.x7e2e5dd40daabc3b.x954503abc583f675 != x954503abc583f675.x48cc0c3eaf9f5f05)
		{
			return false;
		}
		xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)x852fe8bb5ac31099.x7e2e5dd40daabc3b;
		if (xf6937c72cebe4ad2.x028068b313735e89.x5566e2d2acbd1fbe == 21861 || !x5566e2d2acbd1fbe.x7e15ddb01df552ee(xf6937c72cebe4ad2.x028068b313735e89.x5566e2d2acbd1fbe))
		{
			return xf6937c72cebe4ad2.x4cd18ddf2b737e11();
		}
		return true;
	}

	internal static bool x018e748365f67e41(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		x1073233de8252b3e x1073233de8252b3e2 = xd7e5673853e47af4.xc255c495fd9232ca;
		while (x1073233de8252b3e2 != null && x1073233de8252b3e2.x954503abc583f675 != x954503abc583f675.x4c38e800e85b21ad)
		{
			if (!x1073233de8252b3e2.xe5764fe5359a6d91)
			{
				return false;
			}
			x1073233de8252b3e2 = x1073233de8252b3e2.xc255c495fd9232ca;
		}
		return true;
	}

	internal static int xd1c4856f813b427c(x852fe8bb5ac31098 xb6842aa1e60562e1)
	{
		int num = 0;
		x852fe8bb5ac31098[] array = xb6842aa1e60562e1.x1981d893a47031a5();
		x852fe8bb5ac31098[] array2 = array;
		foreach (x852fe8bb5ac31098 x852fe8bb5ac31099 in array2)
		{
			if (x852fe8bb5ac31099.x7149c962c02931b3)
			{
				continue;
			}
			x398b3bd0acd94b61 x398b3bd0acd94b62 = x852fe8bb5ac31099.x7e2e5dd40daabc3b;
			if (x398b3bd0acd94b62 is xf6937c72cebe4ad1)
			{
				xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)x398b3bd0acd94b62;
				if (x5566e2d2acbd1fbe.x80b95148e8799434(xf6937c72cebe4ad2.x0eafd527bd1e778e.x5566e2d2acbd1fbe))
				{
					x398b3bd0acd94b62 = x398b3bd0acd94b62.x9b2bbd3d05bf558b();
				}
			}
			if (x398b3bd0acd94b62 != null)
			{
				num = Math.Max(num, x398b3bd0acd94b62.xc821290d7ecc08bf + x398b3bd0acd94b62.x851c2023f5f1cc29);
			}
		}
		return num;
	}

	private static xab391c46ff9a0a38 x72bd1f47182d0db1(x852fe8bb5ac31098 xe3e287548b3d01f5, int x6563ee35141f3c05)
	{
		if (xe3e287548b3d01f5.x7149c962c02931b3 || xe3e287548b3d01f5.x76356d21d04ad431 || !xe3e287548b3d01f5.x3c1c340351d94fbd.xf48cd6e82340ac70.x978429452a26becd)
		{
			return null;
		}
		int x = -x6563ee35141f3c05;
		int y = xd1c4856f813b427c(xe3e287548b3d01f5.x902d63c74e3c13c4);
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x4574ea26106f0edb.xc96d70553223ee04(new Point(x, 0)), x4574ea26106f0edb.xc96d70553223ee04(new Point(x, y)));
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
		return xab391c46ff9a0a;
	}

	private static int x3c6a5dd2a8130b74(x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		if (!xe3e287548b3d01f5.x76356d21d04ad431)
		{
			return xe3e287548b3d01f5.x3c1c340351d94fbd.xf48cd6e82340ac70.x0d71ce357d91dc77[xe3e287548b3d01f5.xa7cb6e8d24f405a4.xa8c2682cb8534de2()] / 2;
		}
		return xe3e287548b3d01f5.x8df91a2f90079e88;
	}

	private static int xd624bff38c6aa886(x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		if (!xe3e287548b3d01f5.xca2d66057ac8daf2)
		{
			return xe3e287548b3d01f5.x3c1c340351d94fbd.xf48cd6e82340ac70.x0d71ce357d91dc77[xe3e287548b3d01f5.xa8c2682cb8534de2()] / 2;
		}
		return xe3e287548b3d01f5.xe38820c59d60221a.xdc1bf80853046136 - xe3e287548b3d01f5.x419ba17a5322627b;
	}

	private static void x0338412f4c07680b(x852fe8bb5ac31098 x10aaa7cdfa38f254)
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = x10aaa7cdfa38f254;
		while (x852fe8bb5ac31099 != null)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31100 = null;
			for (x852fe8bb5ac31098 x852fe8bb5ac31101 = x852fe8bb5ac31099; x852fe8bb5ac31101 != null; x852fe8bb5ac31101 = x852fe8bb5ac31101.xe202d610ff4b6eca)
			{
				x852fe8bb5ac31101.x6c98ade5b8f05ba3 = false;
				x852fe8bb5ac31100 = x852fe8bb5ac31101;
			}
			x852fe8bb5ac31099 = x852fe8bb5ac31100.xd8eb808d98017237(x2709983bf2ac093e: true);
		}
	}
}
