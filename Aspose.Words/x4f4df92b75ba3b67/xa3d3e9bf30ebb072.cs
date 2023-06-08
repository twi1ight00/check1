using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class xa3d3e9bf30ebb072
{
	private readonly x4882ae789be6e2ef x8cedcaa9a62c6e39;

	private readonly x4d8917c8186e8cb2 xa49cef274042e702;

	private readonly xe21bbe9dfab6c4dd x64f784fc78cd5254;

	private static readonly float[] x0c857ae4925f9505 = new float[0];

	private static readonly float[] xd5d5a969e5a358e4 = new float[2] { 3f, 1f };

	private static readonly float[] x67a3b51c37a7dfa0 = new float[2] { 1f, 1f };

	private static readonly float[] x978316560939bc72 = new float[4] { 3f, 1f, 1f, 1f };

	private static readonly float[] x34912fc0dd3a0c80 = new float[6] { 3f, 1f, 1f, 1f, 1f, 1f };

	internal xa3d3e9bf30ebb072(x4882ae789be6e2ef context, xe21bbe9dfab6c4dd resources, x4d8917c8186e8cb2 stream)
	{
		x8cedcaa9a62c6e39 = context;
		x64f784fc78cd5254 = resources;
		xa49cef274042e702 = stream;
	}

	internal void xdaaa5fdab00f8843(x31c19fcb724dfaf5 x90279591611601bc)
	{
		x3a53bab86bc1dfad(x90279591611601bc.x60465f602599d327, x577adbf0cae935c5: true);
		x8cedcaa9a62c6e39.x147e079aca56accb.xb23a4cddc1d7ffe4(x90279591611601bc.xdc1bf80853046136, xa49cef274042e702);
		int num = x9d89494825ac6e74(x90279591611601bc);
		x8cedcaa9a62c6e39.x147e079aca56accb.xb713e6d18915b4f8(num, xa49cef274042e702);
		x8374eccca4e52e12(x90279591611601bc, num);
		int x116dc3c08b623a0b = x8c725e3e3cc2790b(x90279591611601bc);
		x8cedcaa9a62c6e39.x147e079aca56accb.x6372d209ad6773a9(x116dc3c08b623a0b, xa49cef274042e702);
		if (x90279591611601bc.x03a8df074279275f == LineJoin.MiterClipped)
		{
			x8cedcaa9a62c6e39.x147e079aca56accb.x03e6c22eeea17c94(x90279591611601bc.x3372c2e5fab45e9a, xa49cef274042e702);
		}
		if (x90279591611601bc.xca08e8eb525b8a1a != 0)
		{
			float[] xdfcb1f0b7a = xe456b7be60bdaedb(x90279591611601bc, num != 0);
			xa0ac706d9ec123f8(xdfcb1f0b7a, x90279591611601bc.xc19b368b60309472, xa49cef274042e702);
		}
		if (x90279591611601bc.x6fd1e71abf8b8121.Length > 0)
		{
			x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, "Compound lines are not supported. Using solid line instead.");
		}
	}

	private int x9d89494825ac6e74(x31c19fcb724dfaf5 x90279591611601bc)
	{
		switch (x90279591611601bc.x1e0dcb2cdd562cb2)
		{
		case LineCap.Round:
			return 1;
		case LineCap.Square:
			return 2;
		default:
			switch (x90279591611601bc.xec7c14446b693774)
			{
			case LineCap.Round:
				return 1;
			case LineCap.Square:
				return 2;
			default:
				if (x90279591611601bc.xca08e8eb525b8a1a != 0)
				{
					DashCap x9526ba50e2183e = x90279591611601bc.x9526ba50e2183e01;
					if (x9526ba50e2183e == DashCap.Round)
					{
						return 1;
					}
				}
				return 0;
			}
		}
	}

	private void x8374eccca4e52e12(x31c19fcb724dfaf5 x90279591611601bc, int x1f07e1cabb4eea49)
	{
		bool flag = !x6cbe5651d564de78(x90279591611601bc.x1e0dcb2cdd562cb2, x1f07e1cabb4eea49) || !x6cbe5651d564de78(x90279591611601bc.xec7c14446b693774, x1f07e1cabb4eea49);
		if (x90279591611601bc.xca08e8eb525b8a1a != 0)
		{
			flag = flag || !x094330be513361ae(x90279591611601bc.x9526ba50e2183e01, x1f07e1cabb4eea49);
		}
		if (flag)
		{
			x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, "Styles of line start, end or dash caps are unsupported and have been changed.");
		}
	}

	private bool x6cbe5651d564de78(LineCap x924d47924ddd687d, int x9b57f3f4cf08e558)
	{
		return x9b57f3f4cf08e558 switch
		{
			0 => x924d47924ddd687d == LineCap.Flat, 
			1 => x924d47924ddd687d == LineCap.Round, 
			2 => x924d47924ddd687d == LineCap.Square, 
			_ => false, 
		};
	}

	private bool x094330be513361ae(DashCap x88200c6807d3c74b, int x9b57f3f4cf08e558)
	{
		return x9b57f3f4cf08e558 switch
		{
			0 => x88200c6807d3c74b == DashCap.Flat, 
			1 => x88200c6807d3c74b == DashCap.Round, 
			_ => false, 
		};
	}

	private void xa0ac706d9ec123f8(float[] xdfcb1f0b7a774443, float x358e202b1be36c16, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		xcf18e5243f8d5fd3.xdfffe8e2cf9a7455(xdfcb1f0b7a774443);
		xcf18e5243f8d5fd3.x6210059f049f0d48(" ");
		xcf18e5243f8d5fd3.x6210059f049f0d48(xcd769e39c0788209.x355581fe14891d82(x358e202b1be36c16));
		xcf18e5243f8d5fd3.x6210059f049f0d48(" d ");
	}

	internal void x3a53bab86bc1dfad(x845d6a068e0b03c5 xd8f1949f8950238a, bool x577adbf0cae935c5)
	{
		if (xd8f1949f8950238a.x4bc21f84846f912d == x0b257a9fb413b6c3.xb8751dec55f64252)
		{
			x8600a0dba6e18e2f((xc020fa2f5133cba8)xd8f1949f8950238a, x577adbf0cae935c5);
			return;
		}
		x02cd5c9c8d54330e x02cd5c9c8d54330e2 = x64f784fc78cd5254.xf7268a8a4e82d147(xd8f1949f8950238a);
		if (x02cd5c9c8d54330e2 != null)
		{
			x8cedcaa9a62c6e39.x147e079aca56accb.xc4274d0e82b5988e(x02cd5c9c8d54330e2.xd160355ae2167ae9, x577adbf0cae935c5, xa49cef274042e702);
		}
		else
		{
			xe153b19b41116542(xd8f1949f8950238a, x577adbf0cae935c5);
		}
	}

	private void xe153b19b41116542(x845d6a068e0b03c5 xd8f1949f8950238a, bool x577adbf0cae935c5)
	{
		x26d9ecb4bdf0456d color = x26d9ecb4bdf0456d.x89fffa2751fdecbe;
		if (xd8f1949f8950238a is xa587dcb499c221cc)
		{
			xa587dcb499c221cc xa587dcb499c221cc = (xa587dcb499c221cc)xd8f1949f8950238a;
			if (xa587dcb499c221cc.xcc7b76ceb682651c != null && xa587dcb499c221cc.xcc7b76ceb682651c.Length > 0)
			{
				color = xa587dcb499c221cc.xcc7b76ceb682651c[0].x9b41425268471380;
			}
		}
		xc020fa2f5133cba8 xd8f1949f8950238a2 = new xc020fa2f5133cba8(color);
		x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, "Can't use specified brush. Using solid brush instead.");
		x8600a0dba6e18e2f(xd8f1949f8950238a2, x577adbf0cae935c5);
	}

	private void x8600a0dba6e18e2f(xc020fa2f5133cba8 xd8f1949f8950238a, bool x577adbf0cae935c5)
	{
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = xd8f1949f8950238a.x9b41425268471380;
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e && xd8f1949f8950238a.x9b41425268471380.xda71bf6f7c07c3bc < 255)
		{
			x26d9ecb4bdf0456d = x26d9ecb4bdf0456d.x2952bc8481699a0f(x26d9ecb4bdf0456d, x26d9ecb4bdf0456d.x8f02f53f1587477d);
			x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, "Transparency does not conforms with PDF/A standard. Transparent brush has been made opaque.");
		}
		x8cedcaa9a62c6e39.x147e079aca56accb.x2a037b343bdac965(x26d9ecb4bdf0456d, x577adbf0cae935c5, xa49cef274042e702);
	}

	internal void x27335b788ad093c5(byte[] x43e181e083db6cdf, RectangleF x26545669838eb36e, bool xe9177d3c2a7f695a, x02df97c06afacbf3 x5edc4e0499c937b4, xf276f6a75b584d31 xe4eb37da4d22423c)
	{
		x54366fa5f75a02f7 xe07cd29162a1bb = ((!xe9177d3c2a7f695a) ? new x54366fa5f75a02f7(x26545669838eb36e.Width, 0f, 0f, x26545669838eb36e.Height, x26545669838eb36e.X, x26545669838eb36e.Y) : new x54366fa5f75a02f7(x26545669838eb36e.Width, 0f, 0f, 0f - x26545669838eb36e.Height, x26545669838eb36e.X, x26545669838eb36e.Y + x26545669838eb36e.Height));
		x27335b788ad093c5(x43e181e083db6cdf, xe07cd29162a1bb, x5edc4e0499c937b4, xe4eb37da4d22423c);
	}

	internal void x27335b788ad093c5(byte[] x43e181e083db6cdf, x54366fa5f75a02f7 xe07cd29162a1bb51, x02df97c06afacbf3 x5edc4e0499c937b4, xf276f6a75b584d31 xe4eb37da4d22423c)
	{
		x8cedcaa9a62c6e39.x147e079aca56accb.xfa8268e52269b33f(xa49cef274042e702);
		x8cedcaa9a62c6e39.x147e079aca56accb.xc1291ef13d267082(xe07cd29162a1bb51, xa49cef274042e702);
		x9c3b5a148fe3d694 x9c3b5a148fe3d695 = x64f784fc78cd5254.x94682a775258c6c8(x43e181e083db6cdf, x5edc4e0499c937b4, xe4eb37da4d22423c);
		xa49cef274042e702.x241b3c2e8c3aaa86("/{0} Do", x9c3b5a148fe3d695.xd160355ae2167ae9);
		x8cedcaa9a62c6e39.x147e079aca56accb.x5040e9489a5cf554(xa49cef274042e702);
	}

	private static int x8c725e3e3cc2790b(x31c19fcb724dfaf5 x90279591611601bc)
	{
		return x90279591611601bc.x03a8df074279275f switch
		{
			LineJoin.Round => 1, 
			LineJoin.Bevel => 2, 
			_ => 0, 
		};
	}

	private static float[] xe456b7be60bdaedb(x31c19fcb724dfaf5 x90279591611601bc, bool xf157c93c9e70b64c)
	{
		float[] array = (float[])(x90279591611601bc.xca08e8eb525b8a1a switch
		{
			DashStyle.Solid => x0c857ae4925f9505, 
			DashStyle.Dash => xd5d5a969e5a358e4, 
			DashStyle.Dot => x67a3b51c37a7dfa0, 
			DashStyle.DashDot => x978316560939bc72, 
			DashStyle.DashDotDot => x34912fc0dd3a0c80, 
			DashStyle.Custom => x90279591611601bc.x358988d12e56bf69, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bdjpheaabehabeoapdfbeembiddchojcicbdccidbdpddcgeinmeicefgclficcgibjgoaahengh", 1054734556))), 
		}).Clone();
		xe0054a1fe601814e(x90279591611601bc, array, xf157c93c9e70b64c);
		return array;
	}

	private static void xe0054a1fe601814e(x31c19fcb724dfaf5 x90279591611601bc, float[] xa679552e30d81989, bool xf157c93c9e70b64c)
	{
		float num = Math.Max(x90279591611601bc.xdc1bf80853046136, 1f);
		for (int i = 0; i < xa679552e30d81989.Length; i++)
		{
			if (x0d299f323d241756.x7e32f71c3f39b6bc(i))
			{
				float num2 = xa679552e30d81989[i];
				if (xf157c93c9e70b64c)
				{
					num2 += 1f;
				}
				xa679552e30d81989[i] = num2 * num;
			}
			else
			{
				float num3 = xa679552e30d81989[i];
				if (xf157c93c9e70b64c)
				{
					num3 -= 1f;
				}
				xa679552e30d81989[i] = num3 * num;
			}
		}
	}
}
