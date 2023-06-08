using System;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;

namespace xa769c310fbec8a5a;

internal abstract class x48f737a219279f8c
{
	private x97a37e9b9fdfef4f x823c6b25cc2689d8;

	private x9dc5f51c709ef7a1 xf263b01e2956834c;

	private x97a37e9b9fdfef4f xd74c65b8d28b1740;

	public x97a37e9b9fdfef4f x1be93eed8950d961
	{
		get
		{
			return x823c6b25cc2689d8;
		}
		set
		{
			x823c6b25cc2689d8 = value;
		}
	}

	public x97a37e9b9fdfef4f xdc1bf80853046136
	{
		get
		{
			return xd74c65b8d28b1740;
		}
		set
		{
			xd74c65b8d28b1740 = value;
		}
	}

	public x9dc5f51c709ef7a1 x3146d638ec378671
	{
		get
		{
			return xf263b01e2956834c;
		}
		set
		{
			xf263b01e2956834c = value;
		}
	}

	public abstract void AdjustPen(x31c19fcb724dfaf5 pen);

	public abstract x48f737a219279f8c Clone();

	protected void x0fe4f26e70030075(x48f737a219279f8c x11d58b056c032b03)
	{
		x11d58b056c032b03.x1be93eed8950d961 = x1be93eed8950d961;
		x11d58b056c032b03.xdc1bf80853046136 = xdc1bf80853046136;
		x11d58b056c032b03.x3146d638ec378671 = x3146d638ec378671;
	}

	protected LineCap xa668a0cb34f98bd8()
	{
		switch (x3146d638ec378671)
		{
		case x9dc5f51c709ef7a1.x4d0b9d4447ba7566:
			return LineCap.Flat;
		case x9dc5f51c709ef7a1.x02c85a8205c3f73b:
			return LineCap.DiamondAnchor;
		case x9dc5f51c709ef7a1.x3602848af32bd30f:
			return LineCap.RoundAnchor;
		case x9dc5f51c709ef7a1.x8022aa025229a1e5:
		case x9dc5f51c709ef7a1.x2fd79cf9c61b7c9b:
		case x9dc5f51c709ef7a1.x154a90a487ca2cb4:
			return LineCap.ArrowAnchor;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}
}
