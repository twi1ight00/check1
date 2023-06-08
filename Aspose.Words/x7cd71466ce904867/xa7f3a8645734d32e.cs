using System.Collections;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace x7cd71466ce904867;

internal abstract class xa7f3a8645734d32e : xd1d18a01676074c6
{
	private readonly xe9a355a58980e0a4 xd995695f8e3419d6;

	private readonly x7cd9263b5da819f7 x89e78434620b2eb6 = new x7cd9263b5da819f7();

	private double x0be2e1701ee0682c;

	private double x63dfb717ec9e6016;

	private ArrayList x183155ddf15f3d3b = new ArrayList();

	private double x7cf290e345b9b3cf;

	public double x8df91a2f90079e88
	{
		get
		{
			return x7cf290e345b9b3cf;
		}
		set
		{
			x7cf290e345b9b3cf = value;
		}
	}

	public double xbd07e3206ab4c3fa => x63dfb717ec9e6016;

	public ArrayList xad6183fd48a39389 => x183155ddf15f3d3b;

	public abstract x644902f73993c0f3 x3146d638ec378671 { get; }

	public x5725b63233877cf4 x6cee542cebddb262 => x89e78434620b2eb6;

	public double x3e40dd6cc0f0c7e1
	{
		get
		{
			return x0be2e1701ee0682c;
		}
		set
		{
			x0be2e1701ee0682c = value;
		}
	}

	protected xa7f3a8645734d32e(xe9a355a58980e0a4 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
	}

	public override string ToString()
	{
		return string.Concat(xad6183fd48a39389.ToArray());
	}

	public xb8e7e788f6d59708 xe406325e56f74b46()
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		foreach (x06c9fc923c2ea3ef item in x183155ddf15f3d3b)
		{
			xcc8c7739d82c63ba xcc8c7739d82c63ba = item.xe406325e56f74b46();
			if (xcc8c7739d82c63ba != null)
			{
				xb8e7e788f6d.xd6b6ed77479ef68c(xcc8c7739d82c63ba);
			}
		}
		xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
		xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf((float)x8df91a2f90079e88, 0f);
		return xb8e7e788f6d;
	}

	public void xc288754f3b64ccca(x06c9fc923c2ea3ef x1461f66625b49913)
	{
		x1461f66625b49913.x8df91a2f90079e88 = xbd07e3206ab4c3fa;
		x63dfb717ec9e6016 += x1461f66625b49913.xdc1bf80853046136;
		x0be2e1701ee0682c = x63dfb717ec9e6016;
		x89e78434620b2eb6.xd6b6ed77479ef68c(x1461f66625b49913);
		x183155ddf15f3d3b.Add(x1461f66625b49913);
	}
}
