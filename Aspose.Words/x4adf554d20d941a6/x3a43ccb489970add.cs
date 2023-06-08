using System.Collections;

namespace x4adf554d20d941a6;

internal class x3a43ccb489970add
{
	private const int x236cb0a4295bc034 = int.MinValue;

	private const int x4d0b9d4447ba7566 = 0;

	private const int xb0b4ff1622a01d12 = 1;

	private const int xd2f68ee6f47e9dfb = 2;

	private x56410a8dd70087c5 x576773fbf9307688;

	private ArrayList xf4534a93f13f6ff3;

	private int x8cedcaa9a62c6e39 = int.MinValue;

	internal bool xf599d2ce268e77d8 => xc866e8f51cba0359(x576773fbf9307688, xf4534a93f13f6ff3.Count);

	internal bool xa8cbabceca9f22ea => xc866e8f51cba0359(x12cb12b5d2cad53d, xf4534a93f13f6ff3.Count - 1);

	private int x28fcdc775a1d069c => x8cedcaa9a62c6e39;

	private x5c28fdcd27dee7d9 x12cb12b5d2cad53d
	{
		get
		{
			if (0 < xf4534a93f13f6ff3.Count)
			{
				return (x5c28fdcd27dee7d9)xf4534a93f13f6ff3[xf4534a93f13f6ff3.Count - 1];
			}
			return null;
		}
	}

	internal void xbc13914359462815(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x28fcdc775a1d069c != int.MinValue)
		{
			bool flag = x576773fbf9307688 is x5c28fdcd27dee7d9;
			bool flag2 = x5906905c888d3d98 is x5c28fdcd27dee7d9;
			if (flag && x576773fbf9307688.x6e414db5d060a816 == x6e414db5d060a816.x12cb12b5d2cad53d)
			{
				x105bb464c6f7ef5d();
			}
			if (flag2 && x5906905c888d3d98.x6e414db5d060a816 == x6e414db5d060a816.x9fd888e65466818c)
			{
				xd34fbbc45789217c();
				if (!flag || x5906905c888d3d98.x53819c070f6c4652 != x576773fbf9307688)
				{
					x8cedcaa9a62c6e39 = int.MinValue;
				}
			}
			else if (flag2 && x5906905c888d3d98.x6e414db5d060a816 == x6e414db5d060a816.x865739e9b580d3cf)
			{
				x8cedcaa9a62c6e39 = 1;
			}
			else if (flag && x576773fbf9307688.x6e414db5d060a816 == x6e414db5d060a816.x865739e9b580d3cf)
			{
				x8cedcaa9a62c6e39 = 2;
			}
			else if (flag && x576773fbf9307688.x6e414db5d060a816 == x6e414db5d060a816.x12cb12b5d2cad53d)
			{
				x8cedcaa9a62c6e39 = 1;
			}
		}
		if (x28fcdc775a1d069c == int.MinValue)
		{
			x4211d02569152984(x5906905c888d3d98);
		}
		x576773fbf9307688 = x5906905c888d3d98;
	}

	internal static bool x94b9aeac94664188(x5c28fdcd27dee7d9 xe01ae93d9fe5a880)
	{
		return false;
	}

	private static int x98f8b0704fcdff07(x5c28fdcd27dee7d9 xe01ae93d9fe5a880, x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (xe01ae93d9fe5a880 == null)
		{
			return 0;
		}
		x5c28fdcd27dee7d9 x275cb4c2185b = xe01ae93d9fe5a880.x275cb4c2185b2177;
		if (x275cb4c2185b == null)
		{
			return 1;
		}
		if (!x3c81b884cf5d3405.x888cbbd33c96afa3(x275cb4c2185b, x5906905c888d3d98))
		{
			return 1;
		}
		return 2;
	}

	private void x4211d02569152984(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (xf4534a93f13f6ff3 == null)
		{
			xf4534a93f13f6ff3 = new ArrayList();
			x56410a8dd70087c5 x56410a8dd70087c6 = x5906905c888d3d98;
			while (x56410a8dd70087c6 != null)
			{
				x56410a8dd70087c6 = x56410a8dd70087c6.x73ce1c9078892ff3(true);
				if (x56410a8dd70087c6 != null)
				{
					xf4534a93f13f6ff3.Add(x56410a8dd70087c6);
				}
			}
			xf4534a93f13f6ff3.Reverse();
		}
		x8cedcaa9a62c6e39 = x98f8b0704fcdff07(x12cb12b5d2cad53d, x5906905c888d3d98);
	}

	private void xd34fbbc45789217c()
	{
		xf4534a93f13f6ff3.RemoveAt(xf4534a93f13f6ff3.Count - 1);
	}

	private void x105bb464c6f7ef5d()
	{
		xf4534a93f13f6ff3.Add(x576773fbf9307688);
	}

	private bool xc866e8f51cba0359(x56410a8dd70087c5 x5906905c888d3d98, int x10f4d88af727adbc)
	{
		for (int num = x10f4d88af727adbc - 1; num >= 0; num--)
		{
			x5c28fdcd27dee7d9 x5c28fdcd27dee7d10 = (x5c28fdcd27dee7d9)xf4534a93f13f6ff3[num];
			if (xabb75c4c981ebb09(x5c28fdcd27dee7d10, x98f8b0704fcdff07(x5c28fdcd27dee7d10, x5906905c888d3d98)))
			{
				return true;
			}
			x5906905c888d3d98 = x5c28fdcd27dee7d10;
		}
		return false;
	}

	private static bool xabb75c4c981ebb09(x5c28fdcd27dee7d9 xe01ae93d9fe5a880, int x0f7b23d1c393aed9)
	{
		return x0f7b23d1c393aed9 switch
		{
			1 => !x94b9aeac94664188(xe01ae93d9fe5a880), 
			2 => x94b9aeac94664188(xe01ae93d9fe5a880), 
			_ => false, 
		};
	}
}
