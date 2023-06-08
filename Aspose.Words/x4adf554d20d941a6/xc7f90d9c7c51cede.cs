using System;
using System.Collections;
using System.Drawing;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xc7f90d9c7c51cede : x1073233de8252b3e
{
	private x46bd7081dec08b8e xf49591a44359232f;

	private x46bd7081dec08b8e x755b1846e8d9fcc5;

	private ArrayList[] xc72ddcbcaca479e2;

	private xd4c1d21f07094800 x44848d430b83e161;

	private xd6dfbe8f46b4e709 x48f83230a9ffd83c;

	private xd6dfbe8f46b4e709 xaa23858bdd31b2c3;

	internal override x954503abc583f675 x954503abc583f675 => x954503abc583f675.xa65184d44a47025b;

	internal override x4fdf549af9de6b97 x2d6658ad60c6ebe9
	{
		get
		{
			if (base.x2d6658ad60c6ebe9 == null)
			{
				xc67adcdbca121a26 xc67adcdbca121a = new xc67adcdbca121a26(x4574ea26106f0edb.xc96d70553223ee04(x56933a86bfcf89a1()), xef64f56541986736);
				ArrayList arrayList = new ArrayList();
				foreach (xa67197c42bddc7dc item in xe42bd130f1e95570[0])
				{
					arrayList.Add(item.x2d6658ad60c6ebe9);
				}
				if (x1ea60bde2b5d0d28 != null)
				{
					arrayList.Add(x1ea60bde2b5d0d28.x2d6658ad60c6ebe9);
				}
				if (x1d7b771e95a9abb5 != null)
				{
					arrayList.Add(x1d7b771e95a9abb5.x2d6658ad60c6ebe9);
				}
				foreach (xa67197c42bddc7dc item2 in xe42bd130f1e95570[1])
				{
					arrayList.Add(item2.x2d6658ad60c6ebe9);
				}
				arrayList.AddRange(x3557aa8566455ba9.xc8eb0bace318b17e(this));
				foreach (xa67197c42bddc7dc item3 in xe42bd130f1e95570[2])
				{
					arrayList.Add(item3.x2d6658ad60c6ebe9);
				}
				x1740478edaeaa566 x1740478edaeaa = x3557aa8566455ba9.xa86006fbc4aa4bd7(this);
				if (x1740478edaeaa != null)
				{
					xb8e7e788f6d59708 value = x3557aa8566455ba9.xbd2fa38a853bfaa0(x1740478edaeaa);
					if (x1740478edaeaa.xca170eff54278d9b)
					{
						arrayList.Add(value);
					}
					else
					{
						arrayList.Insert(0, value);
					}
				}
				xc67adcdbca121a.xf82029c4e8b4cfc3((x4fdf549af9de6b97[])arrayList.ToArray(typeof(x4fdf549af9de6b97)));
				base.x2d6658ad60c6ebe9 = xc67adcdbca121a;
			}
			return base.x2d6658ad60c6ebe9;
		}
		set
		{
			base.x2d6658ad60c6ebe9 = value;
			if (value != null || xc72ddcbcaca479e2 == null)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				foreach (xa67197c42bddc7dc item in xc72ddcbcaca479e2[i])
				{
					item.x2d6658ad60c6ebe9 = null;
				}
			}
		}
	}

	internal override bool x1cc53d8032f0fd33 => null == x8f28a0c767ea3058;

	internal override bool x4386483402206b24 => null == x3d695937fd09df4b;

	internal xc7f90d9c7c51cede x3d695937fd09df4b => (xc7f90d9c7c51cede)xbc13914359462815;

	internal xc7f90d9c7c51cede x8f28a0c767ea3058 => (xc7f90d9c7c51cede)x3e8d56eefc6dfdad;

	internal x852fe8bb5ac31098 xb78c16d5f2d4f2f7 => (x852fe8bb5ac31098)base.x8b8a0a04b3aeaf3a;

	internal x852fe8bb5ac31098 x279da4adfba57f2d => (x852fe8bb5ac31098)base.x7e2e5dd40daabc3b;

	internal x46bd7081dec08b8e x1ea60bde2b5d0d28
	{
		get
		{
			return xf49591a44359232f;
		}
		set
		{
			xf49591a44359232f = value;
		}
	}

	internal x46bd7081dec08b8e x1d7b771e95a9abb5
	{
		get
		{
			return x755b1846e8d9fcc5;
		}
		set
		{
			x755b1846e8d9fcc5 = value;
		}
	}

	internal int xe364b5f54bd2ec4c => x3c1c340351d94fbd.x8f752b61013f63db(this).X;

	internal int x5f6c85e261732738 => x3c1c340351d94fbd.x8f752b61013f63db(this).Y;

	internal int xd985b37e5f570f69
	{
		get
		{
			int xc07fe3840d9e6d = x3c1c340351d94fbd.xf48cd6e82340ac70.xc07fe3840d9e6d76;
			int num = xf2acd5518b0c681d(xc941868c59399d3e: true);
			if (xc07fe3840d9e6d >= 0)
			{
				return Math.Max((x1ea60bde2b5d0d28 != null) ? x1ea60bde2b5d0d28.x9bcb07e204e30218 : 0, num + xc07fe3840d9e6d);
			}
			return num - xc07fe3840d9e6d;
		}
	}

	internal int xd7fab63fabd0a319
	{
		get
		{
			int num = x3c1c340351d94fbd.xf48cd6e82340ac70.x995a78d99ada0d0c - Math.Max(0, x3c1c340351d94fbd.xf48cd6e82340ac70.x65011a5ae8c64a43);
			if (x1d7b771e95a9abb5 != null)
			{
				return Math.Min(x1d7b771e95a9abb5.xc821290d7ecc08bf, num);
			}
			return num;
		}
	}

	internal x852fe8bb5ac31098 xb77b86477036a450 => xb78c16d5f2d4f2f7;

	internal x852fe8bb5ac31098 xf4861c9f1c09a8e7
	{
		get
		{
			if (x279da4adfba57f2d != null)
			{
				return x279da4adfba57f2d.x902d63c74e3c13c4;
			}
			return null;
		}
	}

	internal xf6689e0eed33812c x3c1c340351d94fbd => (xf6689e0eed33812c)base.x332a8eedb847940d;

	internal ArrayList[] xe42bd130f1e95570
	{
		get
		{
			if (xc72ddcbcaca479e2 == null)
			{
				xc72ddcbcaca479e2 = new ArrayList[3]
				{
					new ArrayList(),
					new ArrayList(),
					new ArrayList()
				};
				if (x1ea60bde2b5d0d28 != null)
				{
					x12d2b80a113c2ab3(x1ea60bde2b5d0d28, xc72ddcbcaca479e2[0], xc72ddcbcaca479e2[1]);
				}
				if (x1d7b771e95a9abb5 != null)
				{
					x12d2b80a113c2ab3(x1d7b771e95a9abb5, xc72ddcbcaca479e2[0], xc72ddcbcaca479e2[1]);
				}
				xc72ddcbcaca479e2[0].Sort();
				xc72ddcbcaca479e2[1].Sort();
				ArrayList arrayList = new ArrayList();
				x12d2b80a113c2ab3(this, arrayList, xc72ddcbcaca479e2[2]);
				arrayList.Sort();
				xc72ddcbcaca479e2[1].AddRange(arrayList);
				xc72ddcbcaca479e2[2].Sort();
			}
			return xc72ddcbcaca479e2;
		}
	}

	internal int xef64f56541986736
	{
		get
		{
			xacf1bb6be5092987 xf48cd6e82340ac = x3c1c340351d94fbd.xf48cd6e82340ac70;
			if (!base.xc0e56f2fca892328)
			{
				return xf48cd6e82340ac.x781c87b545573ab1;
			}
			return xf48cd6e82340ac.xd8dd413f3526822a;
		}
	}

	internal Orientation x2c5926113e101674 => x3c1c340351d94fbd.xf48cd6e82340ac70.x2c5926113e101674;

	internal xd4c1d21f07094800 xd4c1d21f07094800 => xf9d5944b191eb276(x5aa7d09b258e0f23: true);

	internal xd6dfbe8f46b4e709 x9f0adc3a990eec79
	{
		get
		{
			if (x48f83230a9ffd83c == null)
			{
				x48f83230a9ffd83c = new xd6dfbe8f46b4e709();
			}
			return x48f83230a9ffd83c;
		}
	}

	internal xd6dfbe8f46b4e709 x358167681e04eecb
	{
		get
		{
			if (xaa23858bdd31b2c3 == null)
			{
				xaa23858bdd31b2c3 = new xd6dfbe8f46b4e709();
			}
			return xaa23858bdd31b2c3;
		}
	}

	internal override void xbc4db1b9481c1d31(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		x379ae16af0ba8e51(x6fcedf7742596b6c.xa794cb4211c273f3);
		x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xd7e5673853e47af4;
		x852fe8bb5ac31099.xc255c495fd9232ca = this;
		if (xb78c16d5f2d4f2f7 == null || x852fe8bb5ac31099.xf432ece93e450408() == xb78c16d5f2d4f2f7)
		{
			base.x8b8a0a04b3aeaf3a = x852fe8bb5ac31099;
		}
		if (x279da4adfba57f2d == null || x852fe8bb5ac31099.x9b2bbd3d05bf558b() == x279da4adfba57f2d)
		{
			base.x7e2e5dd40daabc3b = x852fe8bb5ac31099;
		}
		if (x852fe8bb5ac31099.x057ec8a18573254e)
		{
			if (xb77b86477036a450 != null)
			{
				base.x332a8eedb847940d = xb77b86477036a450.x332a8eedb847940d;
			}
			if (x852fe8bb5ac31099.x3c1c340351d94fbd.xb78c16d5f2d4f2f7 == x852fe8bb5ac31099)
			{
				x852fe8bb5ac31099.x3c1c340351d94fbd.x86a0dde4c22f516b = this;
			}
			if (x852fe8bb5ac31099.x3c1c340351d94fbd.x6d202aeb53f9cc93 == null)
			{
				x852fe8bb5ac31099.x3c1c340351d94fbd.x6d202aeb53f9cc93 = this;
			}
		}
	}

	internal override void x844530889595db77(x398b3bd0acd94b61 xd7e5673853e47af4, bool x7e9711ec413a6aba)
	{
		x379ae16af0ba8e51(x6fcedf7742596b6c.xa794cb4211c273f3);
		x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xd7e5673853e47af4;
		x852fe8bb5ac31098 x902d63c74e3c13c = x852fe8bb5ac31099.x902d63c74e3c13c4;
		if (x902d63c74e3c13c.xd10a74dc90155765())
		{
			x852fe8bb5ac31098 x852fe8bb5ac31100 = x902d63c74e3c13c.xd8eb808d98017237(x2709983bf2ac093e: true);
			xbba4ca0462c7486f.x5f7015b08b8f9e88(x852fe8bb5ac31100);
			if (x852fe8bb5ac31100 != null && x852fe8bb5ac31100.xe38820c59d60221a != this)
			{
				x852fe8bb5ac31100 = null;
			}
			x852fe8bb5ac31098 x852fe8bb5ac31101 = x902d63c74e3c13c.xe300dfe99be5b628(x2709983bf2ac093e: true);
			if (x852fe8bb5ac31101 != null && x852fe8bb5ac31101.xe38820c59d60221a != this)
			{
				x852fe8bb5ac31101 = null;
			}
			if (x902d63c74e3c13c == xf4861c9f1c09a8e7)
			{
				base.x7e2e5dd40daabc3b = x852fe8bb5ac31101?.x5458a425704f77fe();
			}
			if (x902d63c74e3c13c == xb77b86477036a450)
			{
				base.x8b8a0a04b3aeaf3a = x852fe8bb5ac31100;
			}
			if (xb77b86477036a450 != null)
			{
				base.x332a8eedb847940d = xb77b86477036a450.x332a8eedb847940d;
			}
			if (x902d63c74e3c13c.x3c1c340351d94fbd.x86a0dde4c22f516b == this)
			{
				x902d63c74e3c13c.x3c1c340351d94fbd.x86a0dde4c22f516b = ((x3d695937fd09df4b != null && x3d695937fd09df4b.x3c1c340351d94fbd == x902d63c74e3c13c.x3c1c340351d94fbd) ? x3d695937fd09df4b : null);
			}
			if (x902d63c74e3c13c.x3c1c340351d94fbd.x6d202aeb53f9cc93 == this)
			{
				x902d63c74e3c13c.x3c1c340351d94fbd.x6d202aeb53f9cc93 = ((x8f28a0c767ea3058 != null && x902d63c74e3c13c.x3c1c340351d94fbd.x86a0dde4c22f516b != null) ? x8f28a0c767ea3058 : null);
			}
			x852fe8bb5ac31098[] array = x902d63c74e3c13c.x1981d893a47031a5();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].xc255c495fd9232ca = null;
			}
			if (xb77b86477036a450 == null)
			{
				x52b190e626f65140();
			}
		}
	}

	internal void x3df13c9311a0ba9b(x852fe8bb5ac31098 xd7e5673853e47af4)
	{
		x852fe8bb5ac31098 x902d63c74e3c13c = xd7e5673853e47af4.x902d63c74e3c13c4;
		x852fe8bb5ac31098 x62584df2cb5d40dd = x902d63c74e3c13c.xd8eb808d98017237(x2709983bf2ac093e: true);
		base.x7e2e5dd40daabc3b = x902d63c74e3c13c.x5458a425704f77fe();
		xc7f90d9c7c51cede xc7f90d9c7c51cede2 = new xc7f90d9c7c51cede();
		x398b3bd0acd94b61[] array = xae38dac157c088d7(x62584df2cb5d40dd, null);
		for (int i = 0; i < array.Length; i++)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)array[i];
			x852fe8bb5ac31099.x379ae16af0ba8e51(x6fcedf7742596b6c.xa794cb4211c273f3);
			x852fe8bb5ac31099.xc255c495fd9232ca = xc7f90d9c7c51cede2;
		}
		xc7f90d9c7c51cede2.x8b8a0a04b3aeaf3a = array[0];
		xc7f90d9c7c51cede2.x7e2e5dd40daabc3b = array[^1];
		xc7f90d9c7c51cede2.x332a8eedb847940d = xc7f90d9c7c51cede2.xb78c16d5f2d4f2f7.x3c1c340351d94fbd;
		for (int j = 0; j < array.Length; j++)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31100 = (x852fe8bb5ac31098)array[j];
			if (x852fe8bb5ac31100.x057ec8a18573254e)
			{
				x852fe8bb5ac31100.x3c1c340351d94fbd.x86a0dde4c22f516b = x852fe8bb5ac31100.x3c1c340351d94fbd.xb78c16d5f2d4f2f7.xe38820c59d60221a;
				x852fe8bb5ac31100.x3c1c340351d94fbd.x6d202aeb53f9cc93 = x852fe8bb5ac31100.x3c1c340351d94fbd.x279da4adfba57f2d.xe38820c59d60221a;
				x852fe8bb5ac31100.x3c1c340351d94fbd.x379ae16af0ba8e51();
			}
		}
		xc7f90d9c7c51cede2.xb78c16d5f2d4f2f7.x3c1c340351d94fbd.xbc4db1b9481c1d31(this, null, xc7f90d9c7c51cede2, x502d59bacbd3e16e: true);
	}

	internal override void x3f71587805cc24f1(x398b3bd0acd94b61 xd7e5673853e47af4, x1073233de8252b3e x9e4d7279252bee4a)
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xd7e5673853e47af4;
		if (x852fe8bb5ac31099.x957cd3867cc3a9f3)
		{
			xc7f90d9c7c51cede xc7f90d9c7c51cede2 = new xc7f90d9c7c51cede();
			base.x332a8eedb847940d.xbc4db1b9481c1d31(this, xbc13914359462815, xc7f90d9c7c51cede2, x502d59bacbd3e16e: true);
			x398b3bd0acd94b61[] array = xae38dac157c088d7(null, null);
			for (int i = 0; i < array.Length; i++)
			{
				x852fe8bb5ac31098 x852fe8bb5ac31100 = (x852fe8bb5ac31098)array[i];
				x852fe8bb5ac31100.xc255c495fd9232ca = xc7f90d9c7c51cede2;
			}
			for (int j = 0; j < array.Length; j++)
			{
				x852fe8bb5ac31098 x852fe8bb5ac31101 = (x852fe8bb5ac31098)array[j];
				xf6689e0eed33812c xf6689e0eed33812c2 = x852fe8bb5ac31101.x3c1c340351d94fbd;
				if (xf6689e0eed33812c2.x6d202aeb53f9cc93 == this)
				{
					xf6689e0eed33812c2.x6d202aeb53f9cc93 = xc7f90d9c7c51cede2;
				}
				if (xf6689e0eed33812c2 != x3c1c340351d94fbd && xf6689e0eed33812c2.x86a0dde4c22f516b == this)
				{
					xf6689e0eed33812c2.x86a0dde4c22f516b = xc7f90d9c7c51cede2;
				}
			}
			xc7f90d9c7c51cede2.x8b8a0a04b3aeaf3a = array[0];
			xc7f90d9c7c51cede2.x7e2e5dd40daabc3b = array[^1];
			base.x8b8a0a04b3aeaf3a = null;
			base.x7e2e5dd40daabc3b = null;
		}
		else
		{
			x3df13c9311a0ba9b(x852fe8bb5ac31099);
		}
	}

	internal override bool x379ae16af0ba8e51(x6fcedf7742596b6c x03e443c02ed2213e)
	{
		if (base.x379ae16af0ba8e51(x03e443c02ed2213e))
		{
			return true;
		}
		if ((x03e443c02ed2213e & x6fcedf7742596b6c.x7da8495344a79eb8) != 0)
		{
			xc72ddcbcaca479e2 = null;
		}
		return false;
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x117fdc1164d859d2(this);
	}

	internal override Point x588d7683a6d1fbd5()
	{
		return x2206903f9421fd4b();
	}

	internal void x3fec45b92a70ba3a()
	{
		x8df91a2f90079e88 = 0;
		xc821290d7ecc08bf = ((!base.xc0e56f2fca892328) ? x3e8d56eefc6dfdad.x9bcb07e204e30218 : 0);
		xacf1bb6be5092987 xf48cd6e82340ac = x3c1c340351d94fbd.xf48cd6e82340ac70;
		xdc1bf80853046136 = xf48cd6e82340ac.x3114e27f80122981;
		xb0f146032f47c24e = xf48cd6e82340ac.x995a78d99ada0d0c;
	}

	internal int xf2acd5518b0c681d(bool xc941868c59399d3e)
	{
		if (xc941868c59399d3e != x3c1c340351d94fbd.x874c84c476778297.xde015839cc88f18d.xed289fa06fb7362c)
		{
			return x3c1c340351d94fbd.xf48cd6e82340ac70.x22f21a828a652fc4;
		}
		return 0;
	}

	internal x852fe8bb5ac31098[] x217b15e880e7d6ac(x852fe8bb5ac31098 x62584df2cb5d40dd, x852fe8bb5ac31098 x2aa5114a5da7d6c8)
	{
		if (x62584df2cb5d40dd == null)
		{
			x62584df2cb5d40dd = xb77b86477036a450;
		}
		ArrayList arrayList = new ArrayList();
		while (x62584df2cb5d40dd != null && this == x62584df2cb5d40dd.xe38820c59d60221a)
		{
			arrayList.Add(x62584df2cb5d40dd);
			if (x62584df2cb5d40dd == x2aa5114a5da7d6c8)
			{
				break;
			}
			x62584df2cb5d40dd = x62584df2cb5d40dd.xd8eb808d98017237(x2709983bf2ac093e: true);
		}
		return (x852fe8bb5ac31098[])arrayList.ToArray(typeof(x852fe8bb5ac31098));
	}

	internal int x5138ebdd7c56c151()
	{
		x7c5d33e87d9dfc05 x7c5d33e87d9dfc6 = (x7c5d33e87d9dfc05)x53111d6596d16a99;
		if (!x7c5d33e87d9dfc6.x0efc8c115f3f0df7.xd8b11076ff837685(this))
		{
			return -1;
		}
		return x7c5d33e87d9dfc6.x0efc8c115f3f0df7.xd1bdf42207dd3638;
	}

	internal xd4c1d21f07094800 xf9d5944b191eb276(bool x5aa7d09b258e0f23)
	{
		if (x44848d430b83e161 == null && x5aa7d09b258e0f23)
		{
			x44848d430b83e161 = new xd4c1d21f07094800(this);
		}
		return x44848d430b83e161;
	}

	internal bool x4b54027e70cb8d14()
	{
		if (x8f28a0c767ea3058 == null)
		{
			return false;
		}
		if (xb78c16d5f2d4f2f7 == null)
		{
			return false;
		}
		if (!xb78c16d5f2d4f2f7.xc0e56f2fca892328)
		{
			return false;
		}
		if (x3c1c340351d94fbd.xf48cd6e82340ac70.xe95664527db59e6e switch
		{
			SectionStart.OddPage => x0d299f323d241756.x7e32f71c3f39b6bc(x5c28fdcd27dee7d9.xb5da8902547ab3e9(this)) ? 1 : 0, 
			SectionStart.EvenPage => (!x0d299f323d241756.x7e32f71c3f39b6bc(x5c28fdcd27dee7d9.xb5da8902547ab3e9(this))) ? 1 : 0, 
			_ => 1, 
		} == 0)
		{
			return true;
		}
		x5d30045af3da9a92 xde015839cc88f18d = x2c8c6741422a1298.x80f061859cd048ae.xde015839cc88f18d;
		if (!xde015839cc88f18d.x43c3a2f12150cda0 && !xde015839cc88f18d.x1b0b470b47c0d859)
		{
			return false;
		}
		if (!x3c1c340351d94fbd.xf48cd6e82340ac70.x464e144455d016ba)
		{
			return false;
		}
		int num = x5c28fdcd27dee7d9.xb5da8902547ab3e9(x8f28a0c767ea3058);
		int num2 = x5c28fdcd27dee7d9.xb5da8902547ab3e9(this);
		return x0d299f323d241756.x7e32f71c3f39b6bc(num) == x0d299f323d241756.x7e32f71c3f39b6bc(num2);
	}

	private static void x12d2b80a113c2ab3(x1073233de8252b3e xd3311d815ca25f02, ArrayList x371464bec00b5a87, ArrayList x6360c6239aea0423)
	{
		if (xd3311d815ca25f02 == null)
		{
			return;
		}
		if (xd3311d815ca25f02.x954503abc583f675 != x954503abc583f675.x48cc0c3eaf9f5f05)
		{
			for (x398b3bd0acd94b61 x398b3bd0acd94b62 = xd3311d815ca25f02.x8b8a0a04b3aeaf3a; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xf432ece93e450408())
			{
				x12d2b80a113c2ab3((x1073233de8252b3e)x398b3bd0acd94b62, x371464bec00b5a87, x6360c6239aea0423);
			}
			return;
		}
		for (x398b3bd0acd94b61 x398b3bd0acd94b63 = xd3311d815ca25f02.x8b8a0a04b3aeaf3a; x398b3bd0acd94b63 != null; x398b3bd0acd94b63 = x398b3bd0acd94b63.xf432ece93e450408())
		{
			x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)x398b3bd0acd94b63;
			if (x56410a8dd70087c6.x5566e2d2acbd1fbe == 25604 && x56410a8dd70087c6.x34251722ab416841.x109e3389933c23a8.x6f6877b222ed4153)
			{
				x2762216e824a374b(x56410a8dd70087c6);
				if (x56410a8dd70087c6.x34251722ab416841.x39043a80f49a07e2 >= 0)
				{
					x6360c6239aea0423.Add(x56410a8dd70087c6);
				}
				else
				{
					x371464bec00b5a87.Add(x56410a8dd70087c6);
				}
			}
		}
	}

	private static void x2762216e824a374b(x56410a8dd70087c5 x5906905c888d3d98)
	{
		x109e3389933c23a8 x109e3389933c23a9 = x455088ba2e479f69.xdef7f68a22ec051d(x5906905c888d3d98);
		if (!x109e3389933c23a9.x5a3440516914ae4b)
		{
			x109e3389933c23a9.x2e6c3c7a54659350();
		}
	}
}
