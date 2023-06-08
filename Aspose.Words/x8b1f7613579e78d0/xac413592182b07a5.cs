using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;

namespace x8b1f7613579e78d0;

internal class xac413592182b07a5 : xc9689b5f2fdc3c03
{
	private x78cc79ebd76ad5d0 xbe63ce924b03850f;

	private double xa0980ee3c68b0d61;

	private x55c6a66cc28d5b86 x55f49a2aff808806 = x55c6a66cc28d5b86.x220dcfbc81260c16(1.0);

	private x89f9bde24c211d60 xa380e2b17ddfd84f;

	private double xf3bdd1a62da546b0;

	private x55c6a66cc28d5b86 xcf24cb8bb61eb980 = x55c6a66cc28d5b86.x220dcfbc81260c16(1.0);

	public x78cc79ebd76ad5d0 x9ba359ff37a3a63b
	{
		get
		{
			return xbe63ce924b03850f;
		}
		set
		{
			xbe63ce924b03850f = value;
		}
	}

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

	public x55c6a66cc28d5b86 x9ef4ea518c1e89de
	{
		get
		{
			return x55f49a2aff808806;
		}
		set
		{
			x55f49a2aff808806 = value;
		}
	}

	public x55c6a66cc28d5b86 x53b5497e1889efbc
	{
		get
		{
			return xcf24cb8bb61eb980;
		}
		set
		{
			xcf24cb8bb61eb980 = value;
		}
	}

	public double x3e6aca679d27dd62
	{
		get
		{
			return xa0980ee3c68b0d61;
		}
		set
		{
			xa0980ee3c68b0d61 = value;
		}
	}

	public double xccc150ee96ca9fe4
	{
		get
		{
			return xf3bdd1a62da546b0;
		}
		set
		{
			xf3bdd1a62da546b0 = value;
		}
	}

	public xc9689b5f2fdc3c03 x8b61531c8ea35b85()
	{
		xac413592182b07a5 xac413592182b07a6 = new xac413592182b07a5();
		xac413592182b07a6.x9ba359ff37a3a63b = x9ba359ff37a3a63b;
		xac413592182b07a6.x3e6aca679d27dd62 = x3e6aca679d27dd62;
		xac413592182b07a6.x9ef4ea518c1e89de = x9ef4ea518c1e89de;
		xac413592182b07a6.xccc150ee96ca9fe4 = xccc150ee96ca9fe4;
		xac413592182b07a6.x53b5497e1889efbc = x53b5497e1889efbc;
		xac413592182b07a6.x29461430415ce5f3 = x29461430415ce5f3;
		return xac413592182b07a6;
	}

	public void x99abbb429861fb9d(x5e9754e56a4f759f xd8f1949f8950238a, x8b545195dd56c1c7 xf1125c563ec28c45, xa2745adfabe0c674 x95dac044246123ac)
	{
		xc6defe7702d42f0b(xd8f1949f8950238a);
		xe4889845a990d27e(xd8f1949f8950238a, x95dac044246123ac);
		x08a10f24b31cb7dd(xd8f1949f8950238a, xf1125c563ec28c45, x95dac044246123ac);
		xd81c88bab54a39c5(xd8f1949f8950238a);
	}

	private void x08a10f24b31cb7dd(x5e9754e56a4f759f xd8f1949f8950238a, x8b545195dd56c1c7 xf1125c563ec28c45, xa2745adfabe0c674 x95dac044246123ac)
	{
		RectangleF x26545669838eb36e = new RectangleF(0f, 0f, x95dac044246123ac.xf0dac309e0310811, x95dac044246123ac.x46df0eb1a743eced);
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.x5152a5707921c783((float)x55f49a2aff808806.x71c5078172d72420, (float)xcf24cb8bb61eb980.x71c5078172d72420);
		x26545669838eb36e = x54366fa5f75a02f.xaccac17571a8d9fa(x26545669838eb36e);
		PointF pointF = x37d2d88f96f87b47.x0aa7e9f1585a5d1e(x26545669838eb36e);
		RectangleF x6a1f9e96254c40aa = xf1125c563ec28c45.x6a1f9e96254c40aa;
		x6a1f9e96254c40aa = new RectangleF(0f, 0f, x6a1f9e96254c40aa.Width, x6a1f9e96254c40aa.Height);
		PointF pointF2 = x37d2d88f96f87b47.x0aa7e9f1585a5d1e(x6a1f9e96254c40aa);
		float x3758cf4ee715d = 0f;
		float x6842879318972d9e = 0f;
		switch (x9ba359ff37a3a63b)
		{
		case x78cc79ebd76ad5d0.xe360b1885d8d4a41:
			x3758cf4ee715d = pointF2.X - pointF.X;
			break;
		case x78cc79ebd76ad5d0.x46c964a11610fa46:
			x3758cf4ee715d = x6a1f9e96254c40aa.Right - x26545669838eb36e.Right;
			break;
		case x78cc79ebd76ad5d0.x72d92bd1aff02e37:
			x6842879318972d9e = pointF2.Y - pointF.Y;
			break;
		case x78cc79ebd76ad5d0.x58d2ccae3c5cfd08:
			x3758cf4ee715d = pointF2.X - pointF.X;
			x6842879318972d9e = pointF2.Y - pointF.Y;
			break;
		case x78cc79ebd76ad5d0.x419ba17a5322627b:
			x6842879318972d9e = pointF2.Y - pointF.Y;
			x3758cf4ee715d = x6a1f9e96254c40aa.Right - x26545669838eb36e.Right;
			break;
		case x78cc79ebd76ad5d0.x2ec8395d97ae50dc:
			x6842879318972d9e = x6a1f9e96254c40aa.Bottom - x26545669838eb36e.Bottom;
			break;
		case x78cc79ebd76ad5d0.x9bcb07e204e30218:
			x6842879318972d9e = x6a1f9e96254c40aa.Bottom - x26545669838eb36e.Bottom;
			x3758cf4ee715d = pointF2.X - pointF.X;
			break;
		case x78cc79ebd76ad5d0.xbedfa137d9910ba4:
			x6842879318972d9e = x6a1f9e96254c40aa.Bottom - x26545669838eb36e.Bottom;
			x3758cf4ee715d = x6a1f9e96254c40aa.Right - x26545669838eb36e.Right;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		case x78cc79ebd76ad5d0.xc3ae914e60da748f:
			break;
		}
		xd8f1949f8950238a.xaccac17571a8d9fa.xce92de628aa023cf(x3758cf4ee715d, x6842879318972d9e, MatrixOrder.Append);
	}

	private void xe4889845a990d27e(x5e9754e56a4f759f xd8f1949f8950238a, xa2745adfabe0c674 x95dac044246123ac)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.x5152a5707921c783((float)x4574ea26106f0edb.xad2dd08366e0faf5(1.0, x95dac044246123ac.xf2b3620f7bfc9ed5), (float)x4574ea26106f0edb.xad2dd08366e0faf5(1.0, x95dac044246123ac.x5c6fc5693c6898cd));
		x54366fa5f75a02f.x5152a5707921c783((float)x55f49a2aff808806.x71c5078172d72420, (float)xcf24cb8bb61eb980.x71c5078172d72420);
		xd8f1949f8950238a.xaccac17571a8d9fa.x490e30087768649f(x54366fa5f75a02f, MatrixOrder.Append);
	}

	private void xc6defe7702d42f0b(x5e9754e56a4f759f xd8f1949f8950238a)
	{
		switch (x29461430415ce5f3)
		{
		case x89f9bde24c211d60.x4d0b9d4447ba7566:
			xd8f1949f8950238a.x349ff0df1e641b4e = WrapMode.Tile;
			break;
		case x89f9bde24c211d60.x3bce7c87328df8da:
			xd8f1949f8950238a.x349ff0df1e641b4e = WrapMode.TileFlipX;
			break;
		case x89f9bde24c211d60.x61c108cc44ef385a:
			xd8f1949f8950238a.x349ff0df1e641b4e = WrapMode.TileFlipY;
			break;
		case x89f9bde24c211d60.x79cd51c998aa495c:
			xd8f1949f8950238a.x349ff0df1e641b4e = WrapMode.TileFlipXY;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void xd81c88bab54a39c5(x5e9754e56a4f759f xd8f1949f8950238a)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf((float)x3e6aca679d27dd62, (float)xccc150ee96ca9fe4, MatrixOrder.Append);
		xd8f1949f8950238a.xaccac17571a8d9fa.x490e30087768649f(x54366fa5f75a02f, MatrixOrder.Append);
	}
}
