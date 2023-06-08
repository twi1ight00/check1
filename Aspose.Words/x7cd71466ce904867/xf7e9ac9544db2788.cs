using System.Drawing;
using x1c8faa688b1f0b0c;
using x4dc96876c552a593;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x7cd71466ce904867;

internal abstract class xf7e9ac9544db2788 : x5725b63233877cf4, x06c9fc923c2ea3ef
{
	protected xe39d06eee35dd23d x83cd810ab70afec3;

	protected string x2b9c3f93d8888ad2;

	protected double xd74c65b8d28b1740;

	private double xb2481c788615bc4f;

	private double x11782780fcf0fd17;

	private double xa05ac4bc2dfd6d7b;

	private x91f0f9c35f99edd9 xd02fb4af47acab90;

	private xe9a355a58980e0a4 xd995695f8e3419d6;

	private xd67056cdc9587a61 xc67369e42f67472e;

	private double x7cf290e345b9b3cf;

	public xd67056cdc9587a61 x77dc43988eaceb1c => xc67369e42f67472e;

	public double xdc1bf80853046136 => xd74c65b8d28b1740;

	public x91f0f9c35f99edd9 x160a0bf4de8f6bd0
	{
		get
		{
			return xd02fb4af47acab90;
		}
		set
		{
			xd02fb4af47acab90 = value;
		}
	}

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

	public double x84bbacdc1fc0efd2 => xa05ac4bc2dfd6d7b;

	public double x3f80ed349f729542 => xb2481c788615bc4f;

	public double xc9f7bec53c29c691 => x11782780fcf0fd17;

	public double xb0f146032f47c24e => xb2481c788615bc4f + x11782780fcf0fd17;

	protected x7423ef514d81c23e x8fb6a748ef46ad8f => xd02fb4af47acab90.x8fb6a748ef46ad8f;

	protected xf7e9ac9544db2788(xe9a355a58980e0a4 serviceLocator, x91f0f9c35f99edd9 run, x84f077c4a21fdc06 tokenIterator)
	{
		xd995695f8e3419d6 = serviceLocator;
		xd02fb4af47acab90 = run;
		x2b9c3f93d8888ad2 = tokenIterator.xecdb691bd5b6abb3;
		xc67369e42f67472e = tokenIterator.x77dc43988eaceb1c;
		x2f9881556fe66cc1();
	}

	public override string ToString()
	{
		return GetText();
	}

	public xcc8c7739d82c63ba xe406325e56f74b46()
	{
		SizeF size = new SizeF((float)xdc1bf80853046136, (float)x3f80ed349f729542);
		double num = x4574ea26106f0edb.x3aa08882c9feaf96(x8fb6a748ef46ad8f.x9ba60a33bc3988dc.x5842b5fc61b80e47);
		PointF origin = new PointF((float)x8df91a2f90079e88, 0f);
		x681deb4f3dee2e6f x681deb4f3dee2e6f2 = xd995695f8e3419d6.x068d6c6371066131();
		x26d9ecb4bdf0456d color = x681deb4f3dee2e6f2.xc0c1f48845315e30(x8fb6a748ef46ad8f);
		x26d9ecb4bdf0456d outlineColor = x681deb4f3dee2e6f2.x33c8377c4846b3c6(x8fb6a748ef46ad8f);
		return new xcc8c7739d82c63ba(x83cd810ab70afec3, color, outlineColor, origin, GetText(), size, (float)num);
	}

	protected abstract string GetText();

	protected abstract void MeasureWidth();

	private void x2f9881556fe66cc1()
	{
		x50c62c86bee67716();
		MeasureWidth();
	}

	private void x50c62c86bee67716()
	{
		x83cd810ab70afec3 = xd995695f8e3419d6.x6162cb3c334a0508().xef51a39b06006bb9(x8fb6a748ef46ad8f);
		if (x83cd810ab70afec3 != null)
		{
			xa05ac4bc2dfd6d7b = x4574ea26106f0edb.x3aa08882c9feaf96(x83cd810ab70afec3.x8a25c402b95f9dea);
			xb2481c788615bc4f = x4574ea26106f0edb.x3aa08882c9feaf96(x83cd810ab70afec3.xd9ac1486133b5a4e);
			x11782780fcf0fd17 = x4574ea26106f0edb.x3aa08882c9feaf96(x83cd810ab70afec3.x6b0006bdae665f50);
		}
	}
}
