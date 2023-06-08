using System;
using Aspose;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal abstract class x78752dd11b777af5 : x3d1ad8ce75f0db3a
{
	private x9a40326835ff6d69 x8298d7f8d08be8ed;

	private x1073233de8252b3e x2d83fc4dda6bbe2d;

	private int xc794f0423760ac5a = int.MinValue;

	internal override x1073233de8252b3e xc255c495fd9232ca
	{
		set
		{
			base.xc255c495fd9232ca = value;
			if (x8298d7f8d08be8ed != null)
			{
				x8298d7f8d08be8ed.xc255c495fd9232ca = value;
			}
		}
	}

	internal override int xb0f146032f47c24e
	{
		get
		{
			if (base.xb0f146032f47c24e == int.MinValue)
			{
				base.xb0f146032f47c24e = x6a738f346b3e7a5f();
			}
			return base.xb0f146032f47c24e;
		}
	}

	internal override int xbcd477821fdbd81b
	{
		get
		{
			if (xc794f0423760ac5a == int.MinValue)
			{
				xc794f0423760ac5a = xf789336ec095168d();
			}
			return xc794f0423760ac5a;
		}
		set
		{
			xc794f0423760ac5a = value;
		}
	}

	internal x4af4ee0384f9176a x60c79c2c8163b21e => (x4af4ee0384f9176a)base.x332a8eedb847940d;

	internal x9a40326835ff6d69 x43604484a3deae4f
	{
		get
		{
			if (x8298d7f8d08be8ed == null)
			{
				StoryType xdbbf47b5e620c = (GetIsContinuation() ? ContinuationSeparatorStoryType : SeparatorStoryType);
				x928803c35fad8dec x928803c35fad8dec2 = x2c8c6741422a1298.xd410c9b07f3bc70b.xa2711a6fcb6054d5(xdbbf47b5e620c);
				x8298d7f8d08be8ed = (x9a40326835ff6d69)x928803c35fad8dec2.x8b8a0a04b3aeaf3a;
				x8298d7f8d08be8ed.xdc1bf80853046136 = xdc1bf80853046136;
				x8298d7f8d08be8ed.xc255c495fd9232ca = xc255c495fd9232ca;
			}
			return x8298d7f8d08be8ed;
		}
	}

	internal x1073233de8252b3e xcb6bfda2755bdd2d
	{
		get
		{
			if (x2d83fc4dda6bbe2d == null)
			{
				x2d83fc4dda6bbe2d = new xf6937c72cebe4ad1();
				x2d83fc4dda6bbe2d.xb0f146032f47c24e = x4574ea26106f0edb.x8d50b8a62ba1cd84(0.0);
			}
			return x2d83fc4dda6bbe2d;
		}
	}

	protected abstract StoryType SeparatorStoryType { get; }

	protected abstract StoryType ContinuationSeparatorStoryType { get; }

	internal override void x52b190e626f65140()
	{
		if (xc255c495fd9232ca != null)
		{
			x60c79c2c8163b21e.x2eb651a26ca80730((x852fe8bb5ac31098)xc255c495fd9232ca, null);
			xc255c495fd9232ca = null;
		}
		if (base.x332a8eedb847940d != null)
		{
			base.x332a8eedb847940d.x844530889595db77(this);
		}
	}

	internal int x6a738f346b3e7a5f()
	{
		return x43604484a3deae4f.xb0f146032f47c24e + xf789336ec095168d() + xcb6bfda2755bdd2d.xb0f146032f47c24e;
	}

	internal override void xbc4db1b9481c1d31(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		xd7e5673853e47af4.xbd046d9206c82718(this);
		x379ae16af0ba8e51(x6fcedf7742596b6c.xa794cb4211c273f3);
		xd7e5673853e47af4.xc255c495fd9232ca = this;
		if (base.x7e2e5dd40daabc3b == null || x888cbbd33c96afa3(base.x7e2e5dd40daabc3b, xd7e5673853e47af4))
		{
			base.x7e2e5dd40daabc3b = xd7e5673853e47af4;
		}
		if (base.x8b8a0a04b3aeaf3a == null || x888cbbd33c96afa3(xd7e5673853e47af4, base.x8b8a0a04b3aeaf3a))
		{
			base.x8b8a0a04b3aeaf3a = xd7e5673853e47af4;
		}
	}

	[JavaThrows(true)]
	protected abstract bool GetIsContinuation();

	private static bool x888cbbd33c96afa3(x398b3bd0acd94b61 x36b103723e703d06, x398b3bd0acd94b61 x54acfcf5460fb360)
	{
		if (x36b103723e703d06.x332a8eedb847940d == x54acfcf5460fb360.x332a8eedb847940d)
		{
			for (x398b3bd0acd94b61 x398b3bd0acd94b62 = x36b103723e703d06.x332a8eedb847940d.x8b8a0a04b3aeaf3a; x398b3bd0acd94b62 != null; x398b3bd0acd94b62 = x398b3bd0acd94b62.xbc13914359462815)
			{
				if (x398b3bd0acd94b62 == x36b103723e703d06)
				{
					return true;
				}
				if (x398b3bd0acd94b62 == x54acfcf5460fb360)
				{
					return false;
				}
			}
			throw new InvalidOperationException();
		}
		x16dabaa37d19a5ec x16dabaa37d19a5ec2 = (x16dabaa37d19a5ec)x36b103723e703d06.x332a8eedb847940d.x5c76a7629364cf4d(x5a5e07e9fa12451a.x10d7a1cae426b158);
		x16dabaa37d19a5ec x16dabaa37d19a5ec3 = (x16dabaa37d19a5ec)x54acfcf5460fb360.x332a8eedb847940d.x5c76a7629364cf4d(x5a5e07e9fa12451a.x10d7a1cae426b158);
		if (x16dabaa37d19a5ec2 == x16dabaa37d19a5ec3)
		{
			xc63cc34daaa2e2d9 xc63cc34daaa2e2d10 = x36b103723e703d06.x332a8eedb847940d.x5c76a7629364cf4d(x5a5e07e9fa12451a.xa19781cfbe8b4961 | x5a5e07e9fa12451a.xfdc1a17f479acc42);
			xc63cc34daaa2e2d9 xc63cc34daaa2e2d11 = x54acfcf5460fb360.x332a8eedb847940d.x5c76a7629364cf4d(x5a5e07e9fa12451a.xa19781cfbe8b4961 | x5a5e07e9fa12451a.xfdc1a17f479acc42);
			if (xc63cc34daaa2e2d10.x5a5e07e9fa12451a != xc63cc34daaa2e2d11.x5a5e07e9fa12451a)
			{
				if (xc63cc34daaa2e2d10.x5a5e07e9fa12451a == x5a5e07e9fa12451a.xa19781cfbe8b4961)
				{
					xc63cc34daaa2e2d10 = xc63cc34daaa2e2d10.x332a8eedb847940d;
				}
				else
				{
					xc63cc34daaa2e2d11 = xc63cc34daaa2e2d11.x332a8eedb847940d;
				}
			}
			for (xc63cc34daaa2e2d9 xc63cc34daaa2e2d12 = xc63cc34daaa2e2d10; xc63cc34daaa2e2d12 != null; xc63cc34daaa2e2d12 = xc63cc34daaa2e2d12.xbc13914359462815)
			{
				if (xc63cc34daaa2e2d12 == xc63cc34daaa2e2d11)
				{
					return true;
				}
			}
			return false;
		}
		for (x16dabaa37d19a5ec x16dabaa37d19a5ec4 = (x16dabaa37d19a5ec)x16dabaa37d19a5ec2.xbc13914359462815; x16dabaa37d19a5ec4 != null; x16dabaa37d19a5ec4 = (x16dabaa37d19a5ec)x16dabaa37d19a5ec4.xbc13914359462815)
		{
			if (x16dabaa37d19a5ec4 == x16dabaa37d19a5ec3)
			{
				return true;
			}
		}
		return false;
	}
}
