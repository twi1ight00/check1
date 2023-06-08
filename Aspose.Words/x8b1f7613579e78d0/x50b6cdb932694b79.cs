using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace x8b1f7613579e78d0;

internal class x50b6cdb932694b79 : xf657893ca1fba53e
{
	private x60eea316590e7fe7 x19dabe5888a23181;

	private x4e8a02a4da77131a xf34ef61ecae1eb73;

	public bool xc8467090f98259e2 => true;

	public x60eea316590e7fe7 x0d779425940e20c1
	{
		get
		{
			if (x19dabe5888a23181 == null)
			{
				x19dabe5888a23181 = new x60eea316590e7fe7();
			}
			return x19dabe5888a23181;
		}
		set
		{
			x19dabe5888a23181 = value;
		}
	}

	public x4e8a02a4da77131a x632b457a1248cdb1
	{
		get
		{
			return xf34ef61ecae1eb73;
		}
		set
		{
			xf34ef61ecae1eb73 = value;
		}
	}

	public xf657893ca1fba53e x8b61531c8ea35b85()
	{
		x50b6cdb932694b79 x50b6cdb932694b80 = new x50b6cdb932694b79();
		x50b6cdb932694b80.x632b457a1248cdb1 = x632b457a1248cdb1;
		x50b6cdb932694b80.x0d779425940e20c1 = x0d779425940e20c1.x8b61531c8ea35b85();
		return x50b6cdb932694b80;
	}

	public xf022bb98711420db xa3fa1ce4ffca3dc3(RectangleF x7e5cb04f1604ec98, x8b545195dd56c1c7 xf1125c563ec28c45, bool xd491347fc3b06a1a)
	{
		PointF pointF = xf1258dabdc9341c4(xf1125c563ec28c45.x6a1f9e96254c40aa);
		xab391c46ff9a0a38 path = x8d60d99fd03ed306(xf1125c563ec28c45, x7e5cb04f1604ec98);
		xa587dcb499c221cc xa587dcb499c221cc = new xa587dcb499c221cc(path, pointF);
		if (xd491347fc3b06a1a)
		{
			xa587dcb499c221cc.xaccac17571a8d9fa = x82aca35e35e7bf31.x0fa1cea464b61ce1(xf1125c563ec28c45, pointF);
		}
		return xa587dcb499c221cc;
	}

	private x54366fa5f75a02f7 x31d9e63a66a43c60(RectangleF x19f7cce8c3e2c4f1, RectangleF x5d0f685e10815786)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(0f - x19f7cce8c3e2c4f1.X, 0f - x19f7cce8c3e2c4f1.Y, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783(x5d0f685e10815786.Width / x19f7cce8c3e2c4f1.Width, x5d0f685e10815786.Height / x19f7cce8c3e2c4f1.Height, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(x5d0f685e10815786.X, x5d0f685e10815786.Y, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	private PointF xf1258dabdc9341c4(RectangleF x7e5cb04f1604ec98)
	{
		RectangleF rectangleF = x0d779425940e20c1.xfaab97dd0218026f(x7e5cb04f1604ec98);
		return new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height / 2f);
	}

	private xab391c46ff9a0a38 x8d60d99fd03ed306(x8b545195dd56c1c7 xf1125c563ec28c45, RectangleF x7e5cb04f1604ec98)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = x632b457a1248cdb1 switch
		{
			x4e8a02a4da77131a.xa9993ed2e0c64574 => xd46effdc0e9ecf44(xf1125c563ec28c45), 
			x4e8a02a4da77131a.x4053bf44f19ab1e2 => xb5d832c5c4d7d085(xf1125c563ec28c45), 
			x4e8a02a4da77131a.x404d528fe2f10961 => xec99498b06599944(xf1125c563ec28c45), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		xdece8854408c886d(xf1125c563ec28c45, xab391c46ff9a0a, x7e5cb04f1604ec98);
		return xab391c46ff9a0a;
	}

	private xab391c46ff9a0a38 xec99498b06599944(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e2.x7c89cd07f845b8e1(xf1125c563ec28c45.x6a1f9e96254c40aa));
		return xab391c46ff9a0a;
	}

	private xab391c46ff9a0a38 xd46effdc0e9ecf44(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		if (xf1125c563ec28c45.x6cd7659ca2021746 == null)
		{
			return new xab391c46ff9a0a38();
		}
		return xf1125c563ec28c45.x6cd7659ca2021746.x8b61531c8ea35b85();
	}

	private xab391c46ff9a0a38 xb5d832c5c4d7d085(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		RectangleF x6a1f9e96254c40aa = xf1125c563ec28c45.x6a1f9e96254c40aa;
		PointF pointF = new PointF(x6a1f9e96254c40aa.Left + x6a1f9e96254c40aa.Width / 2f, x6a1f9e96254c40aa.Top + x6a1f9e96254c40aa.Height / 2f);
		float num = (float)Math.Sqrt((x6a1f9e96254c40aa.Left - pointF.X) * (x6a1f9e96254c40aa.Left - pointF.X) + (x6a1f9e96254c40aa.Top - pointF.Y) * (x6a1f9e96254c40aa.Top - pointF.Y));
		RectangleF bounds = new RectangleF(pointF.X - num, pointF.Y - num, num * 2f, num * 2f);
		x1cab6af0a41b70e.xb6e955ab98a0878c(new x1fb5d45c2d0b868a(bounds));
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		return xab391c46ff9a0a;
	}

	private void xdece8854408c886d(x8b545195dd56c1c7 xf1125c563ec28c45, xab391c46ff9a0a38 xe125219852864557, RectangleF x7e5cb04f1604ec98)
	{
		if (x632b457a1248cdb1 != 0)
		{
			x54366fa5f75a02f7 xa801ccff44b0c7eb = x31d9e63a66a43c60(xf1125c563ec28c45.x6a1f9e96254c40aa, x7e5cb04f1604ec98);
			xe125219852864557.xaccac17571a8d9fa(xa801ccff44b0c7eb);
		}
	}
}
