using System;
using System.Collections;
using Aspose;

namespace x4adf554d20d941a6;

internal abstract class x1073233de8252b3e : x398b3bd0acd94b61
{
	private bool xee89b9c849340ced;

	private bool x8f65746cccecfa9a;

	private x398b3bd0acd94b61 x7947a6fc7cce3424;

	private x398b3bd0acd94b61 x6d394320b25a5754;

	internal override int xf1d9b91c9700c401 => x8b8a0a04b3aeaf3a.xf1d9b91c9700c401;

	internal override bool xe5764fe5359a6d91
	{
		get
		{
			return x8f65746cccecfa9a;
		}
		set
		{
			x8f65746cccecfa9a = value;
		}
	}

	[JavaThrows(true)]
	internal virtual int x5c392d6ad6fe7e28 => 0;

	[JavaThrows(true)]
	internal virtual int x3dcafc2d758260e1 => 0;

	[JavaThrows(true)]
	internal virtual int xf159a68356fd5b23 => 0;

	[JavaThrows(true)]
	internal virtual int x169ccf570c1dc425 => 0;

	internal x398b3bd0acd94b61 x8b8a0a04b3aeaf3a
	{
		get
		{
			return x6d394320b25a5754;
		}
		set
		{
			x6d394320b25a5754 = value;
		}
	}

	internal x398b3bd0acd94b61 x7e2e5dd40daabc3b
	{
		get
		{
			return x7947a6fc7cce3424;
		}
		set
		{
			x7947a6fc7cce3424 = value;
		}
	}

	internal x1073233de8252b3e x3f424ec11646003b => (x1073233de8252b3e)xbc13914359462815;

	internal x1073233de8252b3e xeb2f651eb0d22a2c => (x1073233de8252b3e)x3e8d56eefc6dfdad;

	internal bool x7149c962c02931b3 => null == x8b8a0a04b3aeaf3a;

	internal bool xa852dd9d7ca8f04d
	{
		get
		{
			return xee89b9c849340ced;
		}
		set
		{
			xee89b9c849340ced = value;
		}
	}

	[JavaThrows(true)]
	internal virtual bool x8786efe6471e0521 => false;

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.x5538f9171399f8cb(this);
	}

	internal override x398b3bd0acd94b61 x8b61531c8ea35b85()
	{
		x1073233de8252b3e x1073233de8252b3e2 = (x1073233de8252b3e)base.x8b61531c8ea35b85();
		x1073233de8252b3e2.x8b8a0a04b3aeaf3a = null;
		x1073233de8252b3e2.x7e2e5dd40daabc3b = null;
		return x1073233de8252b3e2;
	}

	internal override bool x379ae16af0ba8e51(x6fcedf7742596b6c x03e443c02ed2213e)
	{
		if ((!x8f65746cccecfa9a && (x03e443c02ed2213e & x6fcedf7742596b6c.x293cb50ee4c2a32d) == 0) || xee89b9c849340ced)
		{
			return true;
		}
		xbba4ca0462c7486f.x78c73885bbb35810(x03e443c02ed2213e, this);
		xbba4ca0462c7486f.x3cd7806cce53256d(x03e443c02ed2213e, this);
		x2d6658ad60c6ebe9 = null;
		if ((x03e443c02ed2213e & x6fcedf7742596b6c.x3e67108daf4b5ec2) != 0)
		{
			if (xc255c495fd9232ca != null)
			{
				xc255c495fd9232ca.x379ae16af0ba8e51(x03e443c02ed2213e);
			}
			if (x53111d6596d16a99 != null)
			{
				x53111d6596d16a99.x379ae16af0ba8e51();
			}
		}
		if ((x03e443c02ed2213e & x6fcedf7742596b6c.x7da8495344a79eb8) != 0)
		{
			xe5764fe5359a6d91 = false;
		}
		if ((x03e443c02ed2213e & x6fcedf7742596b6c.x293cb50ee4c2a32d) != 0 && x954503abc583f675 != x954503abc583f675.x48cc0c3eaf9f5f05)
		{
			for (x398b3bd0acd94b61 x398b3bd0acd94b62 = x8b8a0a04b3aeaf3a; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xf432ece93e450408())
			{
				x398b3bd0acd94b62.x379ae16af0ba8e51(x03e443c02ed2213e | x6fcedf7742596b6c.x7da8495344a79eb8);
			}
		}
		return false;
	}

	protected int xf789336ec095168d()
	{
		x398b3bd0acd94b61 x398b3bd0acd94b62 = x8b8a0a04b3aeaf3a;
		while (x398b3bd0acd94b62.xe5764fe5359a6d91)
		{
			x398b3bd0acd94b61 x398b3bd0acd94b63 = x398b3bd0acd94b62.xf432ece93e450408();
			if (x398b3bd0acd94b63 == null || !x398b3bd0acd94b63.xe5764fe5359a6d91)
			{
				return x398b3bd0acd94b62.xc821290d7ecc08bf + Math.Max(x398b3bd0acd94b62.x319720dedc082a9d, x398b3bd0acd94b62.x851c2023f5f1cc29);
			}
			x398b3bd0acd94b62 = x398b3bd0acd94b63;
		}
		return 0;
	}

	internal virtual void xbc4db1b9481c1d31(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		xd7e5673853e47af4.xbd046d9206c82718(this);
		x379ae16af0ba8e51(x6fcedf7742596b6c.xa794cb4211c273f3);
		xd7e5673853e47af4.xc255c495fd9232ca = this;
		if (x7e2e5dd40daabc3b == null || xd7e5673853e47af4.x9b2bbd3d05bf558b() == x7e2e5dd40daabc3b)
		{
			x7e2e5dd40daabc3b = xd7e5673853e47af4;
		}
		if (x8b8a0a04b3aeaf3a == null || xd7e5673853e47af4.xf432ece93e450408() == x8b8a0a04b3aeaf3a)
		{
			x8b8a0a04b3aeaf3a = xd7e5673853e47af4;
		}
	}

	internal virtual void x844530889595db77(x398b3bd0acd94b61 xd7e5673853e47af4, bool x7e9711ec413a6aba)
	{
		xd7e5673853e47af4.x9da22225f9eb6ab2(this);
		x379ae16af0ba8e51(x6fcedf7742596b6c.xa794cb4211c273f3);
		if (x8b8a0a04b3aeaf3a == xd7e5673853e47af4)
		{
			x8b8a0a04b3aeaf3a = xd7e5673853e47af4.xf432ece93e450408();
		}
		if (x7e2e5dd40daabc3b == xd7e5673853e47af4)
		{
			x7e2e5dd40daabc3b = xd7e5673853e47af4.x9b2bbd3d05bf558b();
		}
		xd7e5673853e47af4.xc255c495fd9232ca = null;
		if (x7e9711ec413a6aba && x7149c962c02931b3)
		{
			x52b190e626f65140();
		}
	}

	internal virtual void x3f71587805cc24f1(x398b3bd0acd94b61 xd7e5673853e47af4, x1073233de8252b3e x9e4d7279252bee4a)
	{
		if (x9e4d7279252bee4a == this)
		{
			return;
		}
		if (x9e4d7279252bee4a == null)
		{
			x9e4d7279252bee4a = xfaf767ebc9bc84a6();
		}
		x9e4d7279252bee4a.x379ae16af0ba8e51(x6fcedf7742596b6c.x293cb50ee4c2a32d);
		bool flag = true;
		x1073233de8252b3e x1073233de8252b3e2 = x9e4d7279252bee4a.xeb2f651eb0d22a2c;
		while (flag && x1073233de8252b3e2 != null)
		{
			while (flag && x1073233de8252b3e2.x7e2e5dd40daabc3b != null)
			{
				if (x1073233de8252b3e2.x7e2e5dd40daabc3b == xd7e5673853e47af4)
				{
					flag = false;
				}
				x1073233de8252b3e2.x7e2e5dd40daabc3b.x9e19f5bd0a6dd5b7(x9e4d7279252bee4a);
			}
			x1073233de8252b3e2 = x1073233de8252b3e2.xeb2f651eb0d22a2c;
		}
	}

	internal void xf0ab0668f6325268(x398b3bd0acd94b61 xd7e5673853e47af4, x1073233de8252b3e x9e4d7279252bee4a)
	{
		if (xd7e5673853e47af4.xc255c495fd9232ca != x9e4d7279252bee4a)
		{
			bool x7e9711ec413a6aba = true;
			if (x954503abc583f675 == x954503abc583f675.x4c38e800e85b21ad)
			{
				x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)this;
				x852fe8bb5ac31098 x852fe8bb5ac31100 = (x852fe8bb5ac31098)x9e4d7279252bee4a;
				x7e9711ec413a6aba = x852fe8bb5ac31099.x902d63c74e3c13c4 != x852fe8bb5ac31100.x902d63c74e3c13c4;
			}
			x844530889595db77(xd7e5673853e47af4, x7e9711ec413a6aba);
			x9e4d7279252bee4a.xbc4db1b9481c1d31(xd7e5673853e47af4);
		}
	}

	internal x398b3bd0acd94b61[] xae38dac157c088d7(x398b3bd0acd94b61 x62584df2cb5d40dd, x398b3bd0acd94b61 x2aa5114a5da7d6c8)
	{
		if (x62584df2cb5d40dd == null)
		{
			x62584df2cb5d40dd = x8b8a0a04b3aeaf3a;
		}
		ArrayList arrayList = new ArrayList();
		while (x62584df2cb5d40dd != null && x2aa5114a5da7d6c8 != x62584df2cb5d40dd && this == x62584df2cb5d40dd.xc255c495fd9232ca)
		{
			arrayList.Add(x62584df2cb5d40dd);
			x62584df2cb5d40dd = x62584df2cb5d40dd.xf432ece93e450408();
		}
		x398b3bd0acd94b61[] array = new x398b3bd0acd94b61[arrayList.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (x398b3bd0acd94b61)arrayList[i];
		}
		return array;
	}

	internal bool x4a993bf1475ce55f(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		while (xd7e5673853e47af4 != null)
		{
			if (xd7e5673853e47af4 == this)
			{
				return true;
			}
			xd7e5673853e47af4 = xd7e5673853e47af4.xc255c495fd9232ca;
		}
		return false;
	}

	internal virtual void x7d6eba911a7a7f55()
	{
		for (x1073233de8252b3e x1073233de8252b3e2 = (x1073233de8252b3e)x8b8a0a04b3aeaf3a; x1073233de8252b3e2 != null; x1073233de8252b3e2 = (x1073233de8252b3e)x1073233de8252b3e2.xf432ece93e450408())
		{
			x1073233de8252b3e2.x7d6eba911a7a7f55();
		}
	}

	internal override void x53dd1a5b709966fe()
	{
		base.x53dd1a5b709966fe();
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = x8b8a0a04b3aeaf3a; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xf432ece93e450408())
		{
			x398b3bd0acd94b62.x53dd1a5b709966fe();
		}
	}

	internal void x8aff27aa52a84855()
	{
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = x3e8d56eefc6dfdad; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.x3e8d56eefc6dfdad)
		{
		}
	}

	internal void x54ff078143adfa48()
	{
		for (x398b3bd0acd94b61 x398b3bd0acd94b62 = x9b2bbd3d05bf558b(); x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.x9b2bbd3d05bf558b())
		{
		}
	}
}
