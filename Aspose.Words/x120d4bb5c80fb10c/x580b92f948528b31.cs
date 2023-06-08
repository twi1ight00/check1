using System.Collections;
using System.Drawing;
using x3d94286fe72124a8;
using x6c95d9cf46ff5f25;

namespace x120d4bb5c80fb10c;

internal class x580b92f948528b31
{
	private x03d68de1c2f74051 x0aff47ced75afbfa;

	private int xb460ba50908b22ad;

	private int x6bba923d76e22774;

	private int x7518fd664eb4b4a7;

	private bool x4b0a912096d4a39e;

	private x36a104d1298f9767 x9014e5f69e2c91d7;

	private ArrayList x1758951097a16d8f;

	private xb2f06c7846241795[] x393d6fbdfeece734;

	private xb2f06c7846241795[] x7bbce1dfec39c2a5;

	private PointF x5c36fe8fffe60018;

	private PointF xd3b134605d3ffe2c;

	private x48cc0c3eaf9f5f05 x978a2822add53761;

	private x48cc0c3eaf9f5f05 xc443e543bb010f9b;

	internal static void x1cfcddd0e5e25d12(x03d68de1c2f74051 xe41c5c767887b961)
	{
		if (xe41c5c767887b961 != null && xe41c5c767887b961.xe161fd465603c384 >= 4)
		{
			x580b92f948528b31 x580b92f948528b32 = new x580b92f948528b31();
			x580b92f948528b32.x0aff47ced75afbfa = xe41c5c767887b961;
			x580b92f948528b32.xdeb0dfb471616072();
		}
	}

	private void xdeb0dfb471616072()
	{
		xf124be17f086b15e();
		x1de58c7f2b814d6c();
		x4c46c7536b325f36();
	}

	private void xf124be17f086b15e()
	{
		x0aff47ced75afbfa.x638f09a63b4c2c2c(x2c8de54beeb6f890: true);
		xb460ba50908b22ad = x0aff47ced75afbfa.x3fc82f9493755797;
		x6bba923d76e22774 = x0aff47ced75afbfa.x8712a541c1c434f8;
		x7518fd664eb4b4a7 = x0aff47ced75afbfa.xe161fd465603c384;
		x393d6fbdfeece734 = x424bef5c9df6a4fe(xb460ba50908b22ad, x6bba923d76e22774);
		x7bbce1dfec39c2a5 = x424bef5c9df6a4fe(x6bba923d76e22774, xb460ba50908b22ad);
		x4b0a912096d4a39e = true;
		x9014e5f69e2c91d7 = null;
		x1758951097a16d8f = new ArrayList();
		x5c36fe8fffe60018 = x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(x0aff47ced75afbfa.x8c048278b4338c82).x755f16bdf92ce7c4;
		xd3b134605d3ffe2c = x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(x0aff47ced75afbfa.xad14e18a8527909a).x755f16bdf92ce7c4;
		x978a2822add53761 = x48cc0c3eaf9f5f05.x45a443e47a0dd312(x5c36fe8fffe60018, x294960ca9b3799f2: false);
		xc443e543bb010f9b = x48cc0c3eaf9f5f05.x45a443e47a0dd312(xd3b134605d3ffe2c, x294960ca9b3799f2: false);
	}

	private void x1de58c7f2b814d6c()
	{
		for (int i = 0; i < x7518fd664eb4b4a7 - 1; i++)
		{
			int num = x5138ebdd7c56c151(xb460ba50908b22ad + i);
			int num2 = x5138ebdd7c56c151(num + 1);
			PointF x755f16bdf92ce7c = x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(num).x755f16bdf92ce7c4;
			PointF x755f16bdf92ce7c2 = x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(num2).x755f16bdf92ce7c4;
			if (num2 == x6bba923d76e22774)
			{
				xfa4917a819e9fe76(x755f16bdf92ce7c2);
			}
			else
			{
				x81816433f53d97d0(x755f16bdf92ce7c2, x755f16bdf92ce7c, num, num2, i == x7518fd664eb4b4a7 - 2);
			}
		}
	}

	private int x5138ebdd7c56c151(int xc0c4c459c6ccbd00)
	{
		return x0aff47ced75afbfa.x5138ebdd7c56c151(xc0c4c459c6ccbd00);
	}

	private void xfa4917a819e9fe76(PointF x65b755323c1fef84)
	{
		if (x9014e5f69e2c91d7 != null)
		{
			x9014e5f69e2c91d7.x4d182cac3db00a2e = x65b755323c1fef84;
			x1758951097a16d8f.Add(x9014e5f69e2c91d7);
		}
		x9014e5f69e2c91d7 = null;
		x4b0a912096d4a39e = false;
	}

	private void x81816433f53d97d0(PointF xcecb8058aa0ba5c0, PointF xcb09bd0cee4909a3, int xc0c4c459c6ccbd00, int x021c87837254037c, bool xa9feef23982c638c)
	{
		if (x13f90b6a4588c382(xcecb8058aa0ba5c0, x4b0a912096d4a39e ? (x74f1cb404994df6a(xb460ba50908b22ad, x021c87837254037c) + 1) : (x74f1cb404994df6a(x6bba923d76e22774, x021c87837254037c) + 1), x4b0a912096d4a39e ? x393d6fbdfeece734 : x7bbce1dfec39c2a5, x4b0a912096d4a39e ? x978a2822add53761 : xc443e543bb010f9b))
		{
			if (x9014e5f69e2c91d7 == null)
			{
				x43621dbd0b1352c1(xcecb8058aa0ba5c0, xcb09bd0cee4909a3, x021c87837254037c, xc0c4c459c6ccbd00, xa9feef23982c638c);
			}
			else
			{
				x38eaf594877d0ef5(xcecb8058aa0ba5c0, x021c87837254037c, xa9feef23982c638c);
			}
		}
		else if (x9014e5f69e2c91d7 != null)
		{
			x2d6a6b54eb409b24(xcecb8058aa0ba5c0);
		}
	}

	private void x43621dbd0b1352c1(PointF xcecb8058aa0ba5c0, PointF xcb09bd0cee4909a3, int x021c87837254037c, int xc0c4c459c6ccbd00, bool xa9feef23982c638c)
	{
		x9014e5f69e2c91d7 = new x36a104d1298f9767();
		x9014e5f69e2c91d7.x70c8db2af7777d54 = x4b0a912096d4a39e;
		x9014e5f69e2c91d7.x761445bca289bae4 = xc0c4c459c6ccbd00;
		x9014e5f69e2c91d7.xaf4e0fbe61814cf5 = xcb09bd0cee4909a3;
		x9014e5f69e2c91d7.x5a5087cc0668ce37 = xcecb8058aa0ba5c0;
		x9014e5f69e2c91d7.x341c31bf403430e7 = xcecb8058aa0ba5c0;
		x9014e5f69e2c91d7.x42b78f8356bf11c7++;
		if (xa9feef23982c638c)
		{
			x2d6a6b54eb409b24(x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(x5138ebdd7c56c151(x021c87837254037c + 1)).x755f16bdf92ce7c4);
		}
	}

	private void x38eaf594877d0ef5(PointF xcecb8058aa0ba5c0, int x021c87837254037c, bool xa9feef23982c638c)
	{
		x9014e5f69e2c91d7.x341c31bf403430e7 = xcecb8058aa0ba5c0;
		x9014e5f69e2c91d7.x42b78f8356bf11c7++;
		if (xa9feef23982c638c)
		{
			x2d6a6b54eb409b24(x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(x5138ebdd7c56c151(x021c87837254037c + 1)).x755f16bdf92ce7c4);
		}
	}

	private void x2d6a6b54eb409b24(PointF xcecb8058aa0ba5c0)
	{
		x9014e5f69e2c91d7.x4d182cac3db00a2e = xcecb8058aa0ba5c0;
		x1758951097a16d8f.Add(x9014e5f69e2c91d7);
		x9014e5f69e2c91d7 = null;
	}

	private xb2f06c7846241795[] x424bef5c9df6a4fe(int xd4f974c06ffa392b, int x4fc5a88ee8968c44)
	{
		int num = x74f1cb404994df6a(xd4f974c06ffa392b, x4fc5a88ee8968c44);
		num++;
		xb2f06c7846241795[] array = new xb2f06c7846241795[num];
		for (int i = 0; i < num; i++)
		{
			int xc0c4c459c6ccbd = x5138ebdd7c56c151(xd4f974c06ffa392b + i);
			int xc0c4c459c6ccbd2 = x5138ebdd7c56c151(xd4f974c06ffa392b + i + 1);
			xb2f06c7846241795 xb2f06c7846241795 = new xb2f06c7846241795(x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd).x755f16bdf92ce7c4, x0aff47ced75afbfa.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd2).x755f16bdf92ce7c4);
			array[i] = xb2f06c7846241795;
		}
		return array;
	}

	private int x74f1cb404994df6a(int xd4f974c06ffa392b, int x4fc5a88ee8968c44)
	{
		int num = 0;
		for (int num2 = x5138ebdd7c56c151(xd4f974c06ffa392b + 1); num2 != x4fc5a88ee8968c44; num2 = x5138ebdd7c56c151(num2 + 1))
		{
			num++;
		}
		return num;
	}

	private static bool x13f90b6a4588c382(PointF xcecb8058aa0ba5c0, int xd82bd1b2135d653a, xb2f06c7846241795[] xf32ad9fb70fa57f2, x48cc0c3eaf9f5f05 xcd6fc0cab2663c01)
	{
		x48cc0c3eaf9f5f05 xef563966899b6b = x48cc0c3eaf9f5f05.x45a443e47a0dd312(xcecb8058aa0ba5c0, x294960ca9b3799f2: true);
		PointF[] array = new PointF[1] { PointF.Empty };
		if (!x48cc0c3eaf9f5f05.x07aa36934bec95f1(xcd6fc0cab2663c01, xef563966899b6b, array, xf6b46a641abf7d02: true))
		{
			return false;
		}
		return x13f90b6a4588c382(new xb2f06c7846241795(xcecb8058aa0ba5c0, array[0]), xd82bd1b2135d653a, xf32ad9fb70fa57f2);
	}

	private static bool x13f90b6a4588c382(xb2f06c7846241795 xb3882f35545dc4f7, int xd82bd1b2135d653a, xb2f06c7846241795[] xf32ad9fb70fa57f2)
	{
		PointF[] x6fa2570084b2ad = new PointF[1] { PointF.Empty };
		for (int i = 0; i < xf32ad9fb70fa57f2.Length; i++)
		{
			if (i != xd82bd1b2135d653a - 1 && i != xd82bd1b2135d653a && xb2f06c7846241795.x07aa36934bec95f1(xf32ad9fb70fa57f2[i], xb3882f35545dc4f7, x6fa2570084b2ad, x0dc87af0058e6b62: true))
			{
				return true;
			}
		}
		return false;
	}

	private void x4c46c7536b325f36()
	{
		ArrayList arrayList = new ArrayList();
		foreach (x36a104d1298f9767 item in x1758951097a16d8f)
		{
			xcb8232edbcba4e6f(item, arrayList);
			xbf516a428635832c(item);
			arrayList.Add(item);
		}
	}

	private static void xcb8232edbcba4e6f(x36a104d1298f9767 xcc309bf1bc9ab2c1, ArrayList x412d84024b6d7510)
	{
		foreach (x36a104d1298f9767 item in x412d84024b6d7510)
		{
			if (item.x761445bca289bae4 < xcc309bf1bc9ab2c1.x761445bca289bae4)
			{
				xcc309bf1bc9ab2c1.x761445bca289bae4 -= item.x42b78f8356bf11c7 - 1;
			}
		}
	}

	private void xbf516a428635832c(x36a104d1298f9767 xcc309bf1bc9ab2c1)
	{
		int xc0c4c459c6ccbd = x5138ebdd7c56c151(xcc309bf1bc9ab2c1.x761445bca289bae4 + 1);
		for (int i = 0; i < xcc309bf1bc9ab2c1.x42b78f8356bf11c7; i++)
		{
			x0aff47ced75afbfa.x81b9866957faac98(xc0c4c459c6ccbd);
		}
		if (x37d2d88f96f87b47.xe1aec5445964a68c(xcc309bf1bc9ab2c1.xaf4e0fbe61814cf5.Y, xcc309bf1bc9ab2c1.x4d182cac3db00a2e.Y))
		{
			xcc309bf1bc9ab2c1.x42b78f8356bf11c7++;
			return;
		}
		bool flag = ((xcc309bf1bc9ab2c1.xaf4e0fbe61814cf5.X < xcc309bf1bc9ab2c1.x4d182cac3db00a2e.X) ? xcc309bf1bc9ab2c1.x70c8db2af7777d54 : (!xcc309bf1bc9ab2c1.x70c8db2af7777d54));
		PointF x2f7096dac971d6ec = (flag ? xcc309bf1bc9ab2c1.xaf4e0fbe61814cf5 : xcc309bf1bc9ab2c1.x4d182cac3db00a2e);
		x48cc0c3eaf9f5f05 x7f5704d71690aff = x48cc0c3eaf9f5f05.x45a443e47a0dd312(x2f7096dac971d6ec, x294960ca9b3799f2: true);
		x48cc0c3eaf9f5f05 xef563966899b6b = new x48cc0c3eaf9f5f05(flag ? xcc309bf1bc9ab2c1.x341c31bf403430e7 : xcc309bf1bc9ab2c1.x5a5087cc0668ce37, flag ? xcc309bf1bc9ab2c1.x4d182cac3db00a2e : xcc309bf1bc9ab2c1.xaf4e0fbe61814cf5);
		PointF[] array = new PointF[1] { PointF.Empty };
		x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b, array);
		x0aff47ced75afbfa.x5c433c89069df74f(xc0c4c459c6ccbd, new x319a5291e0303fb7(array[0]));
	}
}
