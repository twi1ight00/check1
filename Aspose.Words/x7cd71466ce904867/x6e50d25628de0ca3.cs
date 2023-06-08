using System;
using System.Collections;
using x4dc96876c552a593;

namespace x7cd71466ce904867;

internal class x6e50d25628de0ca3 : x99b53760bae959e6
{
	private ArrayList x183155ddf15f3d3b = new ArrayList();

	private xe9a355a58980e0a4 xd995695f8e3419d6;

	private xd7fbbc457ace2480 xc26e9211ed8375e2 = new xd7fbbc457ace2480();

	public ArrayList xad6183fd48a39389 => x183155ddf15f3d3b;

	public x6e50d25628de0ca3(xe9a355a58980e0a4 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
	}

	public void xfae21f55c59fd906(x91f0f9c35f99edd9 xb0e5d73738e62f9e)
	{
		x183155ddf15f3d3b.Clear();
		xc26e9211ed8375e2.x45f449c33b7ded61(xb0e5d73738e62f9e.xf9ad6fb78355fe13);
		while (xc26e9211ed8375e2.x47f176deff0d42e2())
		{
			x06c9fc923c2ea3ef value = xda3e2d9df6a4615e(xb0e5d73738e62f9e);
			x183155ddf15f3d3b.Add(value);
		}
	}

	public x06c9fc923c2ea3ef xda3e2d9df6a4615e(x91f0f9c35f99edd9 xb0e5d73738e62f9e)
	{
		switch (xc26e9211ed8375e2.x77dc43988eaceb1c)
		{
		case xd67056cdc9587a61.xe89828e8b8199286:
		case xd67056cdc9587a61.x3e1feffd8ca6feb2:
			return new x44bfa3a6ddccb27e(xd995695f8e3419d6, xb0e5d73738e62f9e, xc26e9211ed8375e2);
		case xd67056cdc9587a61.xcd42aad2332fa37b:
			return new x99c3c5d17ff8b930(xd995695f8e3419d6, xb0e5d73738e62f9e, xc26e9211ed8375e2);
		default:
			throw new ArgumentOutOfRangeException();
		}
	}
}
