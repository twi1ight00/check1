using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using xa6cc8e39f9a280d7;

namespace x8b1f7613579e78d0;

internal class x33ed2713f0bb8cae : x48d7478d49393961
{
	private xf657893ca1fba53e x36041e68292e37f3;

	private ArrayList x8dff743782b6d2d2;

	private bool xd9fece4c46822c29;

	private x89f9bde24c211d60 xa380e2b17ddfd84f;

	private x60eea316590e7fe7 xac78c97801f3e74e;

	public x89f9bde24c211d60 x29461430415ce5f3
	{
		get
		{
			return xa380e2b17ddfd84f;
		}
		set
		{
			xa380e2b17ddfd84f = value;
		}
	}

	public bool x3012fceed1fc4fbf
	{
		get
		{
			return xd9fece4c46822c29;
		}
		set
		{
			xd9fece4c46822c29 = value;
		}
	}

	public ArrayList xba3e7a0e3e0e3ebc
	{
		get
		{
			if (x8dff743782b6d2d2 == null)
			{
				x8dff743782b6d2d2 = new ArrayList();
			}
			return x8dff743782b6d2d2;
		}
		set
		{
			x8dff743782b6d2d2 = value;
		}
	}

	public xf657893ca1fba53e xfa366f41892e9371
	{
		get
		{
			if (x36041e68292e37f3 == null)
			{
				x36041e68292e37f3 = new xb13ce62097f50cdd();
			}
			return x36041e68292e37f3;
		}
		set
		{
			x36041e68292e37f3 = value;
		}
	}

	public x60eea316590e7fe7 xe6ea8e6898268fd2
	{
		get
		{
			if (xac78c97801f3e74e == null)
			{
				xac78c97801f3e74e = new x60eea316590e7fe7();
			}
			return xac78c97801f3e74e;
		}
		set
		{
			xac78c97801f3e74e = value;
		}
	}

	private bool x3c2048de64d5ee37
	{
		get
		{
			if (xc837a01d51faf94b != null)
			{
				return xc837a01d51faf94b.xbe1e23e7d5b43370.x71c5078172d72420 != 0.0;
			}
			return false;
		}
	}

	private bool x5d2c31bbdb18a68a
	{
		get
		{
			if (x3966875c027f838c != null)
			{
				return x3966875c027f838c.xbe1e23e7d5b43370.x71c5078172d72420 != 1.0;
			}
			return false;
		}
	}

	private x33ec819de630e85d xc837a01d51faf94b
	{
		get
		{
			if (xba3e7a0e3e0e3ebc.Count == 0)
			{
				return null;
			}
			return (x33ec819de630e85d)xba3e7a0e3e0e3ebc[0];
		}
	}

	private x33ec819de630e85d x3966875c027f838c
	{
		get
		{
			if (xba3e7a0e3e0e3ebc.Count == 0)
			{
				return null;
			}
			return (x33ec819de630e85d)xba3e7a0e3e0e3ebc[xba3e7a0e3e0e3ebc.Count - 1];
		}
	}

	public override x845d6a068e0b03c5 CreateBrush(x8b545195dd56c1c7 brushRenderingContext)
	{
		RectangleF x7e5cb04f1604ec = x3f8b5e4403add97f(brushRenderingContext);
		xf022bb98711420db xf022bb98711420db = xfa366f41892e9371.xa3fa1ce4ffca3dc3(x7e5cb04f1604ec, brushRenderingContext, x3012fceed1fc4fbf);
		xf022bb98711420db.xcc7b76ceb682651c = xc4f217c28cbd991f(brushRenderingContext);
		xf022bb98711420db.x349ff0df1e641b4e = WrapMode.TileFlipXY;
		return xf022bb98711420db;
	}

	public override void xbd7d8a7a0df4684a(xd7e8497b32a408b8 x8b80cdce7a15befe)
	{
		foreach (x33ec819de630e85d item in xba3e7a0e3e0e3ebc)
		{
			item.x9b41425268471380.xbd7d8a7a0df4684a(x8b80cdce7a15befe);
		}
	}

	public override x48d7478d49393961 Clone()
	{
		x33ed2713f0bb8cae x33ed2713f0bb8cae2 = new x33ed2713f0bb8cae();
		x33ed2713f0bb8cae2.x3012fceed1fc4fbf = x3012fceed1fc4fbf;
		x33ed2713f0bb8cae2.x29461430415ce5f3 = x29461430415ce5f3;
		foreach (x33ec819de630e85d item in xba3e7a0e3e0e3ebc)
		{
			x33ed2713f0bb8cae2.xba3e7a0e3e0e3ebc.Add(item.x8b61531c8ea35b85());
		}
		x33ed2713f0bb8cae2.xfa366f41892e9371 = xfa366f41892e9371.x8b61531c8ea35b85();
		x33ed2713f0bb8cae2.xe6ea8e6898268fd2 = xe6ea8e6898268fd2.x8b61531c8ea35b85();
		return x33ed2713f0bb8cae2;
	}

	public override x26d9ecb4bdf0456d GetSingleColor(x8b545195dd56c1c7 brushRenderingContext)
	{
		return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
	}

	private RectangleF x3f8b5e4403add97f(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		if (xac78c97801f3e74e != null)
		{
			return xe6ea8e6898268fd2.xfaab97dd0218026f(xf1125c563ec28c45.x6a1f9e96254c40aa);
		}
		return xf1125c563ec28c45.x6a1f9e96254c40aa;
	}

	private xee3f81a88b302c10[] xc4f217c28cbd991f(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		if (xba3e7a0e3e0e3ebc.Count == 0)
		{
			return null;
		}
		xee3f81a88b302c10[] array = x3124493735780519();
		x477124a5fb1821a7(array, xf1125c563ec28c45);
		x6e76996ee13ab1b2(array, xf1125c563ec28c45);
		x10999eca4a781bc9(array);
		return array;
	}

	private void x10999eca4a781bc9(xee3f81a88b302c10[] x1b1fb70da7688ab1)
	{
		if (xfa366f41892e9371.xc8467090f98259e2)
		{
			for (int i = 0; (float)i < (float)x1b1fb70da7688ab1.Length / 2f; i++)
			{
				x26d9ecb4bdf0456d x9b41425268471380 = x1b1fb70da7688ab1[i].x9b41425268471380;
				int num = x1b1fb70da7688ab1.Length - 1 - i;
				x1b1fb70da7688ab1[i] = new xee3f81a88b302c10(x1b1fb70da7688ab1[num].x9b41425268471380, x1b1fb70da7688ab1[i].xbe1e23e7d5b43370);
				x1b1fb70da7688ab1[num] = new xee3f81a88b302c10(x9b41425268471380, x1b1fb70da7688ab1[num].xbe1e23e7d5b43370);
			}
		}
	}

	private xee3f81a88b302c10[] x3124493735780519()
	{
		int num = xba3e7a0e3e0e3ebc.Count;
		if (x3c2048de64d5ee37)
		{
			num++;
		}
		if (x5d2c31bbdb18a68a)
		{
			num++;
		}
		return new xee3f81a88b302c10[num];
	}

	private void x6e76996ee13ab1b2(xee3f81a88b302c10[] x1b1fb70da7688ab1, x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		int num = (x3c2048de64d5ee37 ? 1 : 0);
		for (int i = 0; i < xba3e7a0e3e0e3ebc.Count; i++)
		{
			x33ec819de630e85d x33ec819de630e85d2 = (x33ec819de630e85d)xba3e7a0e3e0e3ebc[i];
			x1b1fb70da7688ab1[num + i] = x33ec819de630e85d2.xe6b81299dd1291b6(xf1125c563ec28c45.x2898a4fa3477fa50, xf1125c563ec28c45.x4b34cc8966adf8f7);
		}
	}

	private void x477124a5fb1821a7(xee3f81a88b302c10[] x1b1fb70da7688ab1, x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		if (x3c2048de64d5ee37)
		{
			x1b1fb70da7688ab1[0] = xc837a01d51faf94b.xe6b81299dd1291b6(0f, xf1125c563ec28c45.x2898a4fa3477fa50, xf1125c563ec28c45.x4b34cc8966adf8f7);
		}
		if (x5d2c31bbdb18a68a)
		{
			x1b1fb70da7688ab1[^1] = x3966875c027f838c.xe6b81299dd1291b6(0f, xf1125c563ec28c45.x2898a4fa3477fa50, xf1125c563ec28c45.x4b34cc8966adf8f7);
		}
	}
}
