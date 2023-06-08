using System;
using System.Collections;
using System.Text;
using xb1090543d168d647;

namespace x4adf554d20d941a6;

internal class x3e00076e2193f813
{
	private class xdf6f0827f92220c5
	{
		private char xc2b4bf264603429d;

		private int xa7a5745cc82f270d;

		private xd2d2b731b30d7023 x3061ad27bc86f23c;

		public char xfb1fc02db7c42694
		{
			get
			{
				return xc2b4bf264603429d;
			}
			set
			{
				xc2b4bf264603429d = value;
			}
		}

		public int xbd9ab1dea014f991
		{
			get
			{
				return xa7a5745cc82f270d;
			}
			set
			{
				xa7a5745cc82f270d = value;
			}
		}

		public xd2d2b731b30d7023 xbf7d698e3d6d1a49
		{
			get
			{
				return x3061ad27bc86f23c;
			}
			set
			{
				x3061ad27bc86f23c = value;
			}
		}
	}

	private readonly string xed4a7b1500064e12;

	private x6ec39b1b0c66f918[] x12a03cf6a6ffda92;

	private byte x579118b655aa2c42;

	private xdf6f0827f92220c5[] xb9ac289783dd127b;

	private bool xba77159a9b62f799;

	public x6ec39b1b0c66f918[] xdcff38cbdd9cf395
	{
		get
		{
			if (x12a03cf6a6ffda92 == null)
			{
				xccdc427968c568fe();
				x1d3504d08215e809();
			}
			return x12a03cf6a6ffda92;
		}
	}

	public x3e00076e2193f813(string text)
	{
		xed4a7b1500064e12 = text;
	}

	private void xccdc427968c568fe()
	{
		for (int i = 0; i < xed4a7b1500064e12.Length; i++)
		{
			switch (xd9a6b2b6ada137e6.x839a041aa1476aed(xed4a7b1500064e12[i]))
			{
			case xd2d2b731b30d7023.xc613adc4330033f3:
			case xd2d2b731b30d7023.x97338636ab2fccfa:
				x579118b655aa2c42 = 1;
				return;
			case xd2d2b731b30d7023.xed846b3bb18ccf39:
				return;
			}
		}
	}

	private void x1d3504d08215e809()
	{
		xb9ac289783dd127b = new xdf6f0827f92220c5[xed4a7b1500064e12.Length];
		byte b = x579118b655aa2c42;
		xe037bb9eeffbd9db xe037bb9eeffbd9db = xe037bb9eeffbd9db.x3c8c01e56f70ee5c;
		Stack stack = new Stack();
		Stack stack2 = new Stack();
		for (int i = 0; i < xed4a7b1500064e12.Length; i++)
		{
			char c = xed4a7b1500064e12[i];
			xd2d2b731b30d7023 xd2d2b731b30d = xd9a6b2b6ada137e6.x839a041aa1476aed(c);
			xba77159a9b62f799 |= xd2d2b731b30d == xd2d2b731b30d7023.x97338636ab2fccfa || xd2d2b731b30d == xd2d2b731b30d7023.x8b8c96d3cd6915df;
			xb9ac289783dd127b[i] = new xdf6f0827f92220c5();
			xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = xd9a6b2b6ada137e6.x839a041aa1476aed(c);
			xb9ac289783dd127b[i].xfb1fc02db7c42694 = c;
			switch (c)
			{
			case '\u202b':
			case '\u202e':
				xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
				if (b < 60)
				{
					stack2.Push(b);
					stack.Push(xe037bb9eeffbd9db);
					b = (byte)(b + 1);
					b = (byte)(b | 1u);
					xe037bb9eeffbd9db = ((c != '\u202b') ? xe037bb9eeffbd9db.x0162ac4c6d60077b : xe037bb9eeffbd9db.x3c8c01e56f70ee5c);
				}
				continue;
			case '\u202a':
			case '\u202d':
				xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
				if (b < 59)
				{
					stack2.Push(b);
					stack.Push(xe037bb9eeffbd9db);
					b = (byte)(b | 1u);
					b = (byte)(b + 1);
					xe037bb9eeffbd9db = ((c != '\u202a') ? xe037bb9eeffbd9db.x2663bb9902ccd1fe : xe037bb9eeffbd9db.x3c8c01e56f70ee5c);
				}
				continue;
			default:
				if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 != xd2d2b731b30d7023.xc2d0cff69f25dfe2)
				{
					xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
					switch (xe037bb9eeffbd9db)
					{
					case xe037bb9eeffbd9db.x2663bb9902ccd1fe:
						xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.xed846b3bb18ccf39;
						break;
					case xe037bb9eeffbd9db.x0162ac4c6d60077b:
						xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.xc613adc4330033f3;
						break;
					}
					continue;
				}
				break;
			case '\u202c':
				break;
			}
			if (c == '\u202c')
			{
				xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
				if (stack2.Count > 0)
				{
					b = (byte)stack2.Pop();
					xe037bb9eeffbd9db = (xe037bb9eeffbd9db)stack.Pop();
				}
			}
			else if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xc2d0cff69f25dfe2)
			{
				xb9ac289783dd127b[i].xbd9ab1dea014f991 = b;
			}
		}
		int val = x579118b655aa2c42;
		int num = 0;
		while (num < xed4a7b1500064e12.Length)
		{
			int xbd9ab1dea014f = xb9ac289783dd127b[num].xbd9ab1dea014f991;
			xd2d2b731b30d7023 x706f68db49e9e = x5b1ffa197a8f3f19(Math.Max(val, xbd9ab1dea014f));
			int j;
			for (j = num + 1; j < xed4a7b1500064e12.Length && xb9ac289783dd127b[j].xbd9ab1dea014f991 == xbd9ab1dea014f; j++)
			{
			}
			int val2 = ((j < xed4a7b1500064e12.Length) ? xb9ac289783dd127b[j].xbd9ab1dea014f991 : x579118b655aa2c42);
			xd2d2b731b30d7023 x23fe1f362d57a5f = x5b1ffa197a8f3f19(Math.Max(val2, xbd9ab1dea014f));
			x6f7c5a1fad92e7e6(num, j, x706f68db49e9e, x23fe1f362d57a5f);
			x7c9df96429e230cf(num, j, x706f68db49e9e, x23fe1f362d57a5f, xbd9ab1dea014f);
			xf3c1f6aad9829cfb(num, j, xbd9ab1dea014f);
			val = xbd9ab1dea014f;
			num = j;
		}
		xbdf28729a34d7e00();
	}

	private static xd2d2b731b30d7023 x5b1ffa197a8f3f19(int x66bbd7ed8c65740d)
	{
		if (((uint)x66bbd7ed8c65740d & (true ? 1u : 0u)) != 0)
		{
			return xd2d2b731b30d7023.xc613adc4330033f3;
		}
		return xd2d2b731b30d7023.xed846b3bb18ccf39;
	}

	private void x6f7c5a1fad92e7e6(int x10aaa7cdfa38f254, int x18d5f4b2a0e4dfa3, xd2d2b731b30d7023 x706f68db49e9e323, xd2d2b731b30d7023 x23fe1f362d57a5f1)
	{
		xd2d2b731b30d7023 xbf7d698e3d6d1a = xd2d2b731b30d7023.x311782148482223b;
		for (int i = x10aaa7cdfa38f254; i < x18d5f4b2a0e4dfa3; i++)
		{
			if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xed846b3bb18ccf39 || xb9ac289783dd127b[i].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xc613adc4330033f3)
			{
				xbf7d698e3d6d1a = xd2d2b731b30d7023.x311782148482223b;
			}
			else if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x97338636ab2fccfa)
			{
				xbf7d698e3d6d1a = xd2d2b731b30d7023.x8b8c96d3cd6915df;
			}
			else if (xb9ac289783dd127b[i].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x311782148482223b)
			{
				xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = xbf7d698e3d6d1a;
			}
		}
		if (xba77159a9b62f799)
		{
			for (int j = x10aaa7cdfa38f254; j < x18d5f4b2a0e4dfa3; j++)
			{
				if (xb9ac289783dd127b[j].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x97338636ab2fccfa)
				{
					xb9ac289783dd127b[j].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.xc613adc4330033f3;
				}
			}
		}
		for (int k = x10aaa7cdfa38f254 + 1; k < x18d5f4b2a0e4dfa3 - 1; k++)
		{
			if (xb9ac289783dd127b[k].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x93d35165906c7521 || xb9ac289783dd127b[k].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x93cb071467f4b8f1)
			{
				xd2d2b731b30d7023 xbf7d698e3d6d1a2 = xb9ac289783dd127b[k - 1].xbf7d698e3d6d1a49;
				xd2d2b731b30d7023 xbf7d698e3d6d1a3 = xb9ac289783dd127b[k + 1].xbf7d698e3d6d1a49;
				if (xbf7d698e3d6d1a2 == xd2d2b731b30d7023.x311782148482223b && xbf7d698e3d6d1a3 == xd2d2b731b30d7023.x311782148482223b)
				{
					xb9ac289783dd127b[k].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.x311782148482223b;
				}
				else if (xb9ac289783dd127b[k].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x93cb071467f4b8f1 && xbf7d698e3d6d1a2 == xd2d2b731b30d7023.x8b8c96d3cd6915df && xbf7d698e3d6d1a3 == xd2d2b731b30d7023.x8b8c96d3cd6915df)
				{
					xb9ac289783dd127b[k].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.x8b8c96d3cd6915df;
				}
			}
		}
		for (int l = x10aaa7cdfa38f254; l < x18d5f4b2a0e4dfa3; l++)
		{
			if (xb9ac289783dd127b[l].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x1436c9411c3271c3)
			{
				int num = l;
				int num2 = x84665807add26725(num, x18d5f4b2a0e4dfa3, new xd2d2b731b30d7023[1] { xd2d2b731b30d7023.x1436c9411c3271c3 });
				xd2d2b731b30d7023 xd2d2b731b30d = ((num == x10aaa7cdfa38f254) ? x706f68db49e9e323 : xb9ac289783dd127b[num - 1].xbf7d698e3d6d1a49);
				if (xd2d2b731b30d != xd2d2b731b30d7023.x311782148482223b)
				{
					xd2d2b731b30d = ((num2 == x18d5f4b2a0e4dfa3) ? x23fe1f362d57a5f1 : xb9ac289783dd127b[num2].xbf7d698e3d6d1a49);
				}
				if (xd2d2b731b30d == xd2d2b731b30d7023.x311782148482223b)
				{
					xad31bbf5803efd51(num, num2, xd2d2b731b30d7023.x311782148482223b);
				}
				l = num2;
			}
		}
		for (int m = x10aaa7cdfa38f254; m < x18d5f4b2a0e4dfa3; m++)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a4 = xb9ac289783dd127b[m].xbf7d698e3d6d1a49;
			if (xbf7d698e3d6d1a4 == xd2d2b731b30d7023.x93d35165906c7521 || xbf7d698e3d6d1a4 == xd2d2b731b30d7023.x1436c9411c3271c3 || xbf7d698e3d6d1a4 == xd2d2b731b30d7023.x93cb071467f4b8f1)
			{
				xb9ac289783dd127b[m].xbf7d698e3d6d1a49 = xd2d2b731b30d7023.x9f8df74f70555214;
			}
		}
		xd2d2b731b30d7023 xbf7d698e3d6d1a5 = ((x706f68db49e9e323 != 0) ? xd2d2b731b30d7023.x311782148482223b : xd2d2b731b30d7023.xed846b3bb18ccf39);
		for (int n = x10aaa7cdfa38f254; n < x18d5f4b2a0e4dfa3; n++)
		{
			if (xb9ac289783dd127b[n].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xc613adc4330033f3)
			{
				xbf7d698e3d6d1a5 = xd2d2b731b30d7023.x311782148482223b;
			}
			else if (xb9ac289783dd127b[n].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.xed846b3bb18ccf39)
			{
				xbf7d698e3d6d1a5 = xd2d2b731b30d7023.xed846b3bb18ccf39;
			}
			else if (xb9ac289783dd127b[n].xbf7d698e3d6d1a49 == xd2d2b731b30d7023.x311782148482223b)
			{
				xb9ac289783dd127b[n].xbf7d698e3d6d1a49 = xbf7d698e3d6d1a5;
			}
		}
	}

	private void x7c9df96429e230cf(int x10aaa7cdfa38f254, int x18d5f4b2a0e4dfa3, xd2d2b731b30d7023 x706f68db49e9e323, xd2d2b731b30d7023 x23fe1f362d57a5f1, int x66bbd7ed8c65740d)
	{
		for (int i = x10aaa7cdfa38f254; i < x18d5f4b2a0e4dfa3; i++)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a = xb9ac289783dd127b[i].xbf7d698e3d6d1a49;
			if (xbf7d698e3d6d1a != xd2d2b731b30d7023.xc28c6a6e1d15307f && xbf7d698e3d6d1a != xd2d2b731b30d7023.x9f8df74f70555214 && xbf7d698e3d6d1a != xd2d2b731b30d7023.x8e8f6cc6a0756b05 && xbf7d698e3d6d1a != xd2d2b731b30d7023.x376fa6aec4a1bfe6)
			{
				continue;
			}
			int num = i;
			int num2 = x84665807add26725(num, x18d5f4b2a0e4dfa3, new xd2d2b731b30d7023[4]
			{
				xd2d2b731b30d7023.x8e8f6cc6a0756b05,
				xd2d2b731b30d7023.x376fa6aec4a1bfe6,
				xd2d2b731b30d7023.xc28c6a6e1d15307f,
				xd2d2b731b30d7023.x9f8df74f70555214
			});
			xd2d2b731b30d7023 xd2d2b731b30d;
			if (num == x10aaa7cdfa38f254)
			{
				xd2d2b731b30d = x706f68db49e9e323;
			}
			else
			{
				xd2d2b731b30d = xb9ac289783dd127b[num - 1].xbf7d698e3d6d1a49;
				if (xd2d2b731b30d == xd2d2b731b30d7023.x8b8c96d3cd6915df || xd2d2b731b30d == xd2d2b731b30d7023.x311782148482223b)
				{
					xd2d2b731b30d = xd2d2b731b30d7023.xc613adc4330033f3;
				}
			}
			xd2d2b731b30d7023 xd2d2b731b30d2;
			if (num2 == x18d5f4b2a0e4dfa3)
			{
				xd2d2b731b30d2 = x23fe1f362d57a5f1;
			}
			else
			{
				xd2d2b731b30d2 = xb9ac289783dd127b[num2].xbf7d698e3d6d1a49;
				if (xd2d2b731b30d2 == xd2d2b731b30d7023.x8b8c96d3cd6915df || xd2d2b731b30d2 == xd2d2b731b30d7023.x311782148482223b)
				{
					xd2d2b731b30d2 = xd2d2b731b30d7023.xc613adc4330033f3;
				}
			}
			xd2d2b731b30d7023 x7f0d0710aaf8b45b = ((xd2d2b731b30d != xd2d2b731b30d2) ? x5b1ffa197a8f3f19(x66bbd7ed8c65740d) : xd2d2b731b30d);
			xad31bbf5803efd51(num, num2, x7f0d0710aaf8b45b);
			i = num2;
		}
	}

	private void xf3c1f6aad9829cfb(int x10aaa7cdfa38f254, int x18d5f4b2a0e4dfa3, int x66bbd7ed8c65740d)
	{
		if ((x66bbd7ed8c65740d & 1) == 0)
		{
			for (int i = x10aaa7cdfa38f254; i < x18d5f4b2a0e4dfa3; i++)
			{
				switch (xb9ac289783dd127b[i].xbf7d698e3d6d1a49)
				{
				case xd2d2b731b30d7023.xc613adc4330033f3:
					xb9ac289783dd127b[i].xbd9ab1dea014f991 = xb9ac289783dd127b[i].xbd9ab1dea014f991 + 1;
					break;
				case xd2d2b731b30d7023.x311782148482223b:
				case xd2d2b731b30d7023.x8b8c96d3cd6915df:
					xb9ac289783dd127b[i].xbd9ab1dea014f991 = xb9ac289783dd127b[i].xbd9ab1dea014f991 + 2;
					break;
				}
			}
			return;
		}
		for (int j = x10aaa7cdfa38f254; j < x18d5f4b2a0e4dfa3; j++)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a = xb9ac289783dd127b[j].xbf7d698e3d6d1a49;
			if (xbf7d698e3d6d1a == xd2d2b731b30d7023.xed846b3bb18ccf39 || xbf7d698e3d6d1a == xd2d2b731b30d7023.x8b8c96d3cd6915df || xbf7d698e3d6d1a == xd2d2b731b30d7023.x311782148482223b)
			{
				xb9ac289783dd127b[j].xbd9ab1dea014f991 = xb9ac289783dd127b[j].xbd9ab1dea014f991 + 1;
			}
		}
	}

	private int x84665807add26725(int xc0c4c459c6ccbd00, int x18d5f4b2a0e4dfa3, xd2d2b731b30d7023[] x93721743ee3e07fc)
	{
		xc0c4c459c6ccbd00--;
		while (++xc0c4c459c6ccbd00 < x18d5f4b2a0e4dfa3)
		{
			xd2d2b731b30d7023 xbf7d698e3d6d1a = xb9ac289783dd127b[xc0c4c459c6ccbd00].xbf7d698e3d6d1a49;
			bool flag = false;
			for (int i = 0; i < x93721743ee3e07fc.Length; i++)
			{
				if (flag)
				{
					break;
				}
				if (xbf7d698e3d6d1a == x93721743ee3e07fc[i])
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return xc0c4c459c6ccbd00;
			}
		}
		return x18d5f4b2a0e4dfa3;
	}

	private void xad31bbf5803efd51(int x10aaa7cdfa38f254, int x18d5f4b2a0e4dfa3, xd2d2b731b30d7023 x7f0d0710aaf8b45b)
	{
		for (int i = x10aaa7cdfa38f254; i < x18d5f4b2a0e4dfa3; i++)
		{
			xb9ac289783dd127b[i].xbf7d698e3d6d1a49 = x7f0d0710aaf8b45b;
		}
	}

	private void xbdf28729a34d7e00()
	{
		int num = -1;
		StringBuilder stringBuilder = new StringBuilder();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < xb9ac289783dd127b.Length; i++)
		{
			if ("\u200f\u202b\u202e\u200e\u202a\u202d\u202c".IndexOf(xb9ac289783dd127b[i].xfb1fc02db7c42694) != -1)
			{
				continue;
			}
			if (xb9ac289783dd127b[i].xbd9ab1dea014f991 != num || num == -1)
			{
				if (num != -1)
				{
					arrayList.Add(new x6ec39b1b0c66f918(stringBuilder.ToString(), num));
				}
				stringBuilder = new StringBuilder();
				num = xb9ac289783dd127b[i].xbd9ab1dea014f991;
			}
			stringBuilder.Append(xb9ac289783dd127b[i].xfb1fc02db7c42694);
		}
		arrayList.Add(new x6ec39b1b0c66f918(stringBuilder.ToString(), num));
		x12a03cf6a6ffda92 = (x6ec39b1b0c66f918[])arrayList.ToArray(typeof(x6ec39b1b0c66f918));
	}
}
