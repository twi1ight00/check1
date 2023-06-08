using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Math;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class xe22a4a9a14e524d7 : x57df270da83ea6de
{
	private readonly int x660741034f534cfd;

	private float[] xb398bdc5852d7902;

	private float x12d104c7fde0fc6c;

	private float x09e17f172ea14529;

	internal float x79e0368f9606a712
	{
		get
		{
			return x12d104c7fde0fc6c;
		}
		set
		{
			x12d104c7fde0fc6c = value;
		}
	}

	internal int x6e1eb96b81362ebc => x660741034f534cfd;

	internal xe22a4a9a14e524d7(OfficeMath officeMath)
		: this(officeMath, ((xa097a2be55e6fe20)officeMath.x52642f91ccdeeb35).xe9e7cd52b91094f9.xd44988f225497f3a)
	{
	}

	internal xe22a4a9a14e524d7(OfficeMath officeMath, int columns)
		: base(officeMath)
	{
		x660741034f534cfd = columns;
		xb398bdc5852d7902 = new float[x660741034f534cfd];
		x12d104c7fde0fc6c = x3bd4ea4979815149(officeMath);
		x09e17f172ea14529 = xc756f558fe16ab43(officeMath);
	}

	private static float x3bd4ea4979815149(OfficeMath x203bd7b4a3be8d02)
	{
		if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 != x3e68720d12325f49.x30727a59b1643735)
		{
			return x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43;
		}
		xa097a2be55e6fe20 xa097a2be55e6fe = (xa097a2be55e6fe20)x203bd7b4a3be8d02.x52642f91ccdeeb35;
		return xa097a2be55e6fe.xad645df76d47a6b8 switch
		{
			x77581da1860d0f9e.xed04125998cff5a8 => (float)x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43 * 1.5f, 
			x77581da1860d0f9e.x94c083f2813272f4 => (float)x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43 * 2f, 
			x77581da1860d0f9e.x91043c6e17767336 => (float)(x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43 * xa097a2be55e6fe.x042eb39cc7d00f5c) / 2f, 
			x77581da1860d0f9e.xa2f940ce8051d6bd => (float)x4574ea26106f0edb.x0e1fdb362561ddb2(xa097a2be55e6fe.x042eb39cc7d00f5c), 
			_ => x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43, 
		};
	}

	private static float xc756f558fe16ab43(OfficeMath x203bd7b4a3be8d02)
	{
		x77581da1860d0f9e x77581da1860d0f9e = x77581da1860d0f9e.x63374d6ffed4adeb;
		float num = 0f;
		if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x30727a59b1643735)
		{
			xa097a2be55e6fe20 xa097a2be55e6fe = (xa097a2be55e6fe20)x203bd7b4a3be8d02.x52642f91ccdeeb35;
			x77581da1860d0f9e = xa097a2be55e6fe.x8359894e750846dc;
			num = xa097a2be55e6fe.x5c2893a9ae3a9fc2;
		}
		else
		{
			if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 != x3e68720d12325f49.xd4e45a1fccac675d)
			{
				return 0f;
			}
			xad19b25167c52eb8 xad19b25167c52eb = (xad19b25167c52eb8)x203bd7b4a3be8d02.x52642f91ccdeeb35;
			x77581da1860d0f9e = xad19b25167c52eb.x8359894e750846dc;
			num = xad19b25167c52eb.x5c2893a9ae3a9fc2;
		}
		return x77581da1860d0f9e switch
		{
			x77581da1860d0f9e.xed04125998cff5a8 => (float)x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43 * 0.5f, 
			x77581da1860d0f9e.x94c083f2813272f4 => x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43, 
			x77581da1860d0f9e.x91043c6e17767336 => (float)x203bd7b4a3be8d02.xeedad81aaed42a76.x437e3b626c0fdd43 * (num / 2f - 1f), 
			x77581da1860d0f9e.xa2f940ce8051d6bd => (float)x4574ea26106f0edb.x0e1fdb362561ddb2(num), 
			_ => 0f, 
		};
	}

	internal override void xb7ae55095fddecd9()
	{
		x62084450a0785b90();
		float num = x6ae4612a8469678e.Width;
		for (int i = 0; i < x660741034f534cfd; i++)
		{
			num += xb398bdc5852d7902[i] + ((i < x660741034f534cfd - 1) ? x79e0368f9606a712 : 0f);
		}
		float num2 = x6ae4612a8469678e.Height;
		for (int j = 0; j < base.xf2453c298c5de6f5.Count; j++)
		{
			x57df270da83ea6de x57df270da83ea6de2 = (x57df270da83ea6de)base.xf2453c298c5de6f5[j];
			base.xefb7a8f84373ac04.xd6b6ed77479ef68c(x57df270da83ea6de2.xefb7a8f84373ac04);
			if (x57df270da83ea6de2.xefb7a8f84373ac04.x52dde376accdec7d == null)
			{
				x57df270da83ea6de2.xefb7a8f84373ac04.x52dde376accdec7d = new x54366fa5f75a02f7();
			}
			num2 += ((j > 0) ? x09e17f172ea14529 : 0f);
			x57df270da83ea6de2.xefb7a8f84373ac04.x52dde376accdec7d.xce92de628aa023cf(0f, num2, MatrixOrder.Append);
			num2 += x57df270da83ea6de2.x6ae4612a8469678e.Height;
		}
		x6ae4612a8469678e = new RectangleF(x6ae4612a8469678e.X, x6ae4612a8469678e.Y, num, num2);
		x0d0b253c1c496217();
	}

	private void x0d0b253c1c496217()
	{
		if (base.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x30727a59b1643735 || base.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.xd4e45a1fccac675d)
		{
			switch ((xb474f98b96852a6e)base.xc48e358ce4f81353.x52642f91ccdeeb35.xfe91eeeafcb3026a(15230))
			{
			case xb474f98b96852a6e.x9bcb07e204e30218:
			{
				x57df270da83ea6de x57df270da83ea6de3 = (x57df270da83ea6de)base.xf2453c298c5de6f5[base.xf2453c298c5de6f5.Count - 1];
				base.x43a729b39a97938d = x6ae4612a8469678e.Height - (x57df270da83ea6de3.x6ae4612a8469678e.Height - x57df270da83ea6de3.x43a729b39a97938d);
				break;
			}
			case xb474f98b96852a6e.xe360b1885d8d4a41:
			{
				x57df270da83ea6de x57df270da83ea6de2 = (x57df270da83ea6de)base.xf2453c298c5de6f5[0];
				base.x43a729b39a97938d = x57df270da83ea6de2.x43a729b39a97938d;
				break;
			}
			case xb474f98b96852a6e.x58d2ccae3c5cfd08:
				break;
			}
		}
	}

	internal override void x62084450a0785b90()
	{
		foreach (x1dfdb69b4a79e67d item in base.xf2453c298c5de6f5)
		{
			item.x62084450a0785b90();
		}
		foreach (x1dfdb69b4a79e67d item2 in base.xf2453c298c5de6f5)
		{
			item2.xb7ae55095fddecd9();
		}
	}

	internal void xa79d36cfb8b92ea1(x57df270da83ea6de xde860fba55c41d76, int xbeb0e74fd1e3aefb)
	{
		xb398bdc5852d7902[xbeb0e74fd1e3aefb] = ((xb398bdc5852d7902[xbeb0e74fd1e3aefb] > xde860fba55c41d76.x6ae4612a8469678e.Width) ? xb398bdc5852d7902[xbeb0e74fd1e3aefb] : xde860fba55c41d76.x6ae4612a8469678e.Width);
	}

	internal float x3a2949e4f384d864(int xbeb0e74fd1e3aefb)
	{
		return xb398bdc5852d7902[xbeb0e74fd1e3aefb];
	}
}
