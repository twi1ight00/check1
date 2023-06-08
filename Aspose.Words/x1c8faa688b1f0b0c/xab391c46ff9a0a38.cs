using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;

namespace x1c8faa688b1f0b0c;

internal class xab391c46ff9a0a38 : xbaec545ec01f92ca, x0c06161ccb9341e4
{
	private x31c19fcb724dfaf5 x635478a71ab964b3;

	private x845d6a068e0b03c5 xa31c8fed8093bc20;

	private xab391c46ff9a0a38 xa8548d289a49a30a;

	private x54366fa5f75a02f7 x06b983e52d670ed8;

	private FillMode x0549cd0735dd3103;

	public x31c19fcb724dfaf5 x9e5d5f9128c69a8f
	{
		get
		{
			return x635478a71ab964b3;
		}
		set
		{
			x635478a71ab964b3 = value;
		}
	}

	public x845d6a068e0b03c5 x60465f602599d327
	{
		get
		{
			return xa31c8fed8093bc20;
		}
		set
		{
			xa31c8fed8093bc20 = value;
		}
	}

	public xab391c46ff9a0a38 x0e1bf8242ad10272
	{
		get
		{
			return xa8548d289a49a30a;
		}
		set
		{
			xa8548d289a49a30a = value;
		}
	}

	public x54366fa5f75a02f7 x52dde376accdec7d
	{
		get
		{
			return x06b983e52d670ed8;
		}
		set
		{
			x06b983e52d670ed8 = value;
		}
	}

	public FillMode x4eada1f74f43bddb
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

	public bool x424546082eb650ba => ((base.xd44988f225497f3a > 0) ? ((x1cab6af0a41b70e2)base.get_xe6d4b1b411ed94b5(base.xd44988f225497f3a - 1)) : null)?.x5e6c52cb3256cc85 ?? false;

	public xab391c46ff9a0a38()
	{
	}

	public xab391c46ff9a0a38(x31c19fcb724dfaf5 pen)
	{
		x635478a71ab964b3 = pen;
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitPathStart(this);
		base.Accept(visitor);
		visitor.VisitPathEnd(this);
	}

	public static xab391c46ff9a0a38 xa7b580afa8756d69(PointF[] x6fa2570084b2ad39, bool x7a848427f2a9a3b5)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a39 = new xab391c46ff9a0a38();
		xab391c46ff9a0a39.xd6b6ed77479ef68c(x1cab6af0a41b70e2.xa7b580afa8756d69(x6fa2570084b2ad39, x7a848427f2a9a3b5));
		return xab391c46ff9a0a39;
	}

	public static xab391c46ff9a0a38 x7c89cd07f845b8e1(RectangleF x26545669838eb36e)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a39 = new xab391c46ff9a0a38();
		xab391c46ff9a0a39.xd6b6ed77479ef68c(x1cab6af0a41b70e2.x7c89cd07f845b8e1(x26545669838eb36e));
		return xab391c46ff9a0a39;
	}

	public static xab391c46ff9a0a38 x7c89cd07f845b8e1(RectangleF x26545669838eb36e, x31c19fcb724dfaf5 x90279591611601bc)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a39 = x7c89cd07f845b8e1(x26545669838eb36e);
		xab391c46ff9a0a39.x9e5d5f9128c69a8f = x90279591611601bc;
		return xab391c46ff9a0a39;
	}

	public static xab391c46ff9a0a38 xb471d14948c54f27(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a39 = new xab391c46ff9a0a38();
		xab391c46ff9a0a39.xd6b6ed77479ef68c(x1cab6af0a41b70e2.xb471d14948c54f27(x10aaa7cdfa38f254, xca09b6c2b5b18485));
		return xab391c46ff9a0a39;
	}

	public static xab391c46ff9a0a38 x5904a5d9ce1f12b8(PointF x0b433f30d6157b49, x31c19fcb724dfaf5 x90279591611601bc)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a39 = x7c89cd07f845b8e1(new RectangleF(x0b433f30d6157b49.X - 1f, x0b433f30d6157b49.Y - 1f, 2f, 2f));
		xab391c46ff9a0a39.x9e5d5f9128c69a8f = x90279591611601bc;
		return xab391c46ff9a0a39;
	}

	public void xaccac17571a8d9fa(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		for (int i = 0; i < base.xd44988f225497f3a; i++)
		{
			x1cab6af0a41b70e2 x1cab6af0a41b70e3 = (x1cab6af0a41b70e2)base.get_xe6d4b1b411ed94b5(i);
			x1cab6af0a41b70e3.xaccac17571a8d9fa(xa801ccff44b0c7eb);
		}
	}

	public xab391c46ff9a0a38 x8b61531c8ea35b85()
	{
		return x8b61531c8ea35b85(x1288426be0f0b745: true);
	}

	public xab391c46ff9a0a38 x8b61531c8ea35b85(bool x1288426be0f0b745)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a39 = new xab391c46ff9a0a38();
		xab391c46ff9a0a39.x635478a71ab964b3 = x635478a71ab964b3;
		xab391c46ff9a0a39.xa31c8fed8093bc20 = xa31c8fed8093bc20;
		xab391c46ff9a0a39.xa8548d289a49a30a = xa8548d289a49a30a;
		xab391c46ff9a0a39.x06b983e52d670ed8 = x06b983e52d670ed8;
		xab391c46ff9a0a39.x4eada1f74f43bddb = x0549cd0735dd3103;
		if (x1288426be0f0b745)
		{
			for (int i = 0; i < base.xd44988f225497f3a; i++)
			{
				x1cab6af0a41b70e2 x1cab6af0a41b70e3 = (x1cab6af0a41b70e2)base.get_xe6d4b1b411ed94b5(i);
				xab391c46ff9a0a39.xd6b6ed77479ef68c(x1cab6af0a41b70e3.x8b61531c8ea35b85());
			}
		}
		return xab391c46ff9a0a39;
	}
}
