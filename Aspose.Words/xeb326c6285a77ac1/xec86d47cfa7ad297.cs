using System;
using System.Collections;
using x1c8faa688b1f0b0c;
using x24ed092a62874e86;
using x5794c252ba25e723;
using x6b8130194ad714f7;
using x8b1f7613579e78d0;

namespace xeb326c6285a77ac1;

internal class xec86d47cfa7ad297
{
	private xccd21a509fce5a08 x0549cd0735dd3103;

	private double x8918dc7c534575e5 = -1.0;

	private ArrayList xcd6907068eacc4c5 = new ArrayList();

	private bool x69053e864bcfe419 = true;

	private double xd74c65b8d28b1740 = -1.0;

	public ArrayList xbec6323b03dae3ff => xcd6907068eacc4c5;

	public double xdc1bf80853046136
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

	public double xb0f146032f47c24e
	{
		get
		{
			return x8918dc7c534575e5;
		}
		set
		{
			x8918dc7c534575e5 = value;
		}
	}

	public bool x0e397c84d3b79406
	{
		get
		{
			return x69053e864bcfe419;
		}
		set
		{
			x69053e864bcfe419 = value;
		}
	}

	public xccd21a509fce5a08 x4eada1f74f43bddb
	{
		get
		{
			return x0549cd0735dd3103;
		}
		set
		{
			x0549cd0735dd3103 = value;
		}
	}

	internal void xbe03fdfd3b07bf15(xab391c46ff9a0a38 xe125219852864557, x9118c2b63bc20309 x0f7b23d1c393aed9)
	{
		if (x4eada1f74f43bddb != xccd21a509fce5a08.x4d0b9d4447ba7566)
		{
			FillApsPath(x0f7b23d1c393aed9, xe125219852864557);
		}
	}

	internal void xcafb944334ef1589(x87fba3f79fbaf7ab x5b4ab47d13c8ff54)
	{
		if (x5b4ab47d13c8ff54 != null)
		{
			xcd6907068eacc4c5.Add(x5b4ab47d13c8ff54);
		}
	}

	internal xab391c46ff9a0a38 xe406325e56f74b46(x9118c2b63bc20309 x7cc44cab9e9f8397)
	{
		if (!x0e397c84d3b79406 && x4eada1f74f43bddb == xccd21a509fce5a08.x4d0b9d4447ba7566)
		{
			return null;
		}
		try
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
			FillApsPath(x7cc44cab9e9f8397, xab391c46ff9a0a);
			if (x0e397c84d3b79406)
			{
				xab391c46ff9a0a.x9e5d5f9128c69a8f = x7cc44cab9e9f8397.x2f0c16e51db81725();
			}
			if (!x7cc44cab9e9f8397.x17b2b93b89a6dd3c)
			{
				xab391c46ff9a0a.x60465f602599d327 = xa3fa1ce4ffca3dc3(x7cc44cab9e9f8397, xab391c46ff9a0a);
			}
			if (xab391c46ff9a0a.x9e5d5f9128c69a8f == null && xab391c46ff9a0a.x60465f602599d327 == null)
			{
				return null;
			}
			return xab391c46ff9a0a;
		}
		catch (Exception)
		{
			return null;
		}
	}

	protected virtual void FillApsPath(x9118c2b63bc20309 drawingContext, xab391c46ff9a0a38 path)
	{
		drawingContext.x146e38eb2843246e(xdc1bf80853046136, xb0f146032f47c24e);
		x1cab6af0a41b70e2 x1cab6af0a41b70e = null;
		foreach (x87fba3f79fbaf7ab item in xbec6323b03dae3ff)
		{
			if (x1cab6af0a41b70e == null)
			{
				x1cab6af0a41b70e = new x1cab6af0a41b70e2();
			}
			item.xe406325e56f74b46(drawingContext, x1cab6af0a41b70e);
			bool flag = false;
			if (item is xf958427a037612b4)
			{
				flag = true;
			}
			if (item is xcb67af79081bd342 && x1cab6af0a41b70e.xd44988f225497f3a > 0)
			{
				flag = true;
			}
			if (flag)
			{
				x6ae9a2ea3afd9df3(path, x1cab6af0a41b70e);
				x1cab6af0a41b70e = null;
			}
		}
		if (x1cab6af0a41b70e != null)
		{
			x6ae9a2ea3afd9df3(path, x1cab6af0a41b70e);
		}
	}

	private xda4dde4038ab80db x45b4bbc7488427ce()
	{
		switch (x4eada1f74f43bddb)
		{
		case xccd21a509fce5a08.x46da58b3de4e2839:
			return new xc11f878785193b2d(x55c6a66cc28d5b86.x220dcfbc81260c16(0.6));
		case xccd21a509fce5a08.x552cd0de6020b826:
			return new xc11f878785193b2d(x55c6a66cc28d5b86.x220dcfbc81260c16(0.8));
		case xccd21a509fce5a08.xee31dbe578530a23:
			return new x3e6f71e8c6a41a90(x55c6a66cc28d5b86.x220dcfbc81260c16(0.6));
		case xccd21a509fce5a08.xcaa78dc1b39a80eb:
			return new x3e6f71e8c6a41a90(x55c6a66cc28d5b86.x220dcfbc81260c16(0.8));
		case xccd21a509fce5a08.x4d0b9d4447ba7566:
		case xccd21a509fce5a08.x7bdafb93fe98d0b5:
			return null;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private x845d6a068e0b03c5 xa3fa1ce4ffca3dc3(x9118c2b63bc20309 x7cc44cab9e9f8397, xab391c46ff9a0a38 xe125219852864557)
	{
		if (x4eada1f74f43bddb == xccd21a509fce5a08.x4d0b9d4447ba7566)
		{
			return null;
		}
		xda4dde4038ab80db xcbf24c118ac8aa0b = x45b4bbc7488427ce();
		return x7cc44cab9e9f8397.xa3fa1ce4ffca3dc3(xcbf24c118ac8aa0b, xe125219852864557);
	}

	private void x6ae9a2ea3afd9df3(xab391c46ff9a0a38 xe125219852864557, x1cab6af0a41b70e2 x6ac16bf6efd00832)
	{
		if (x6ac16bf6efd00832.xd44988f225497f3a > 0)
		{
			xe125219852864557.xd6b6ed77479ef68c(x6ac16bf6efd00832);
		}
	}
}
