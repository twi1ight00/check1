using System;
using System.Drawing;

namespace x4adf554d20d941a6;

internal class x20de8d9377d7de69 : x6d3ade29d016f4ea
{
	private xf6937c72cebe4ad1 x03d592937b5e7bd3;

	private readonly x6d3ade29d016f4ea x328153a040358657 = new x6d3ade29d016f4ea();

	private xd4c1d21f07094800 x44848d430b83e161;

	internal void xc3819e13f60dd8e6(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		x03d592937b5e7bd3 = x311e7a92306d7199;
		x44848d430b83e161 = (x03d592937b5e7bd3.xbb1e16b61c007293 ? ((x86accec882b7012a)x03d592937b5e7bd3.xc255c495fd9232ca).xf9d5944b191eb276(x5aa7d09b258e0f23: false) : ((xc7f90d9c7c51cede)x03d592937b5e7bd3.xce4443deee105995(x954503abc583f675.xa65184d44a47025b)).xf9d5944b191eb276(x5aa7d09b258e0f23: false));
		x328153a040358657.xc3819e13f60dd8e6(x03d592937b5e7bd3, int.MinValue);
		if (!x03d592937b5e7bd3.x8c84b6fad60c11f5)
		{
			return;
		}
		x03d592937b5e7bd3.xe946632117cc83bb = x03d592937b5e7bd3.xc821290d7ecc08bf;
		Point xf7845a6fecd5afc = (x03d592937b5e7bd3.xbb1e16b61c007293 ? Point.Empty : x03d592937b5e7bd3.xc255c495fd9232ca.x588d7683a6d1fbd5());
		Rectangle x6e02bf4cd8dc8b = new Rectangle(xf7845a6fecd5afc.X + x03d592937b5e7bd3.xc255c495fd9232ca.x5c392d6ad6fe7e28, xf7845a6fecd5afc.Y + x03d592937b5e7bd3.xc255c495fd9232ca.x3dcafc2d758260e1, Math.Max(0, x03d592937b5e7bd3.xc255c495fd9232ca.xdc1bf80853046136 - x03d592937b5e7bd3.xc255c495fd9232ca.x5c392d6ad6fe7e28 - x03d592937b5e7bd3.xc255c495fd9232ca.xf159a68356fd5b23), 1073741823);
		if (x6e02bf4cd8dc8b.Width <= 0)
		{
			return;
		}
		int num = x03d592937b5e7bd3.xc821290d7ecc08bf;
		int num2 = Math.Max(1, x03d592937b5e7bd3.xb0f146032f47c24e);
		x3822c4a3772d4456 x3822c4a3772d4457 = xbb13dc484690ae9a(num, num2, num2 - 1, xf7845a6fecd5afc, x6e02bf4cd8dc8b);
		if (x3822c4a3772d4457.xd6abb2ab950b4d22.Length == 1 && x3822c4a3772d4457.xd6abb2ab950b4d22[0].Width == x6e02bf4cd8dc8b.Width)
		{
			return;
		}
		bool flag;
		do
		{
			int num3 = 0;
			do
			{
				x3822c4a3772d4457 = xbb13dc484690ae9a(num, num2, num3, xf7845a6fecd5afc, x6e02bf4cd8dc8b);
				bool x820ca3c9c1508d = x3822c4a3772d4457.xd6abb2ab950b4d22.Length > 1;
				int num4 = x542aa790045f9a08(x3822c4a3772d4457.xd6abb2ab950b4d22, x03d592937b5e7bd3, x820ca3c9c1508d);
				flag = 0 <= num4 && num4 <= x3822c4a3772d4457.xb0f146032f47c24e;
				if (!flag && x3822c4a3772d4457.xd6abb2ab950b4d22.Length > 0)
				{
					x03d592937b5e7bd3.xe946632117cc83bb = num;
				}
				num3 = x3822c4a3772d4457.xb0f146032f47c24e;
			}
			while (num3 < num2 && !flag);
			num = ((x3822c4a3772d4457.xd6abb2ab950b4d22.Length > 1) ? (num + num2) : x3822c4a3772d4457.x77873e6fb945e6f8);
		}
		while (!flag && num < 1073741823);
	}

	private int x542aa790045f9a08(Rectangle[] xc73463c8bc7be883, xf6937c72cebe4ad1 xb6842aa1e60562e1, bool x820ca3c9c1508d11)
	{
		xf6937c72cebe4ad1 xf6937c72cebe4ad2 = xb6842aa1e60562e1;
		bool flag = false;
		int num = 0;
		while (xf6937c72cebe4ad2 != null && num < xc73463c8bc7be883.Length)
		{
			bool flag2 = xb6842aa1e60562e1 == xf6937c72cebe4ad2 && !flag;
			int num2 = (flag2 ? x09608114085f8e09(xf6937c72cebe4ad2, xc73463c8bc7be883[num].X) : xc73463c8bc7be883[num].X);
			if (num2 < xc73463c8bc7be883[num].Right)
			{
				int num3 = xc871463718c4e4b3(xb6842aa1e60562e1, xc73463c8bc7be883[num].Right) - num2;
				if (num3 > 0)
				{
					xf6937c72cebe4ad2.xa852dd9d7ca8f04d = true;
					xf6937c72cebe4ad2.x8df91a2f90079e88 = num2;
					xf6937c72cebe4ad2.xdc1bf80853046136 = num3;
					flag = true;
					int xbfb9ad5ef64f6dc = (flag2 ? xc73463c8bc7be883[num].X : 0);
					x328153a040358657.xc3819e13f60dd8e6(xf6937c72cebe4ad2, xbfb9ad5ef64f6dc);
					xf6937c72cebe4ad2.xa852dd9d7ca8f04d = false;
					xf6937c72cebe4ad2.xc821290d7ecc08bf = xc73463c8bc7be883[num].Y;
					if (x820ca3c9c1508d11 && xf07d47c790bc0b83(xf6937c72cebe4ad2.x2be2727bb322530e))
					{
						xf6937c72cebe4ad2.xe5764fe5359a6d91 = false;
					}
					else
					{
						bool flag3 = x5566e2d2acbd1fbe.x6634ed9c1dfbdfce(xf6937c72cebe4ad2.x2be2727bb322530e.x5566e2d2acbd1fbe);
						xf6937c72cebe4ad2 = xf6937c72cebe4ad2.xbb84c6a76faa71e6;
						if (flag3)
						{
							break;
						}
					}
				}
			}
			num++;
		}
		if (xb6842aa1e60562e1 == xf6937c72cebe4ad2)
		{
			return -1;
		}
		int num4 = 0;
		for (xf6937c72cebe4ad1 xf6937c72cebe4ad3 = xb6842aa1e60562e1; xf6937c72cebe4ad3 != xf6937c72cebe4ad2; xf6937c72cebe4ad3 = xf6937c72cebe4ad3.xbb84c6a76faa71e6)
		{
			num4 = Math.Max(num4, xf6937c72cebe4ad3.xb0f146032f47c24e);
		}
		return num4;
	}

	private static int xc871463718c4e4b3(xf6937c72cebe4ad1 x311e7a92306d7199, int xc51ece8069fc7a51)
	{
		int num = x311e7a92306d7199.xc255c495fd9232ca.xdc1bf80853046136 - x311e7a92306d7199.xc255c495fd9232ca.xf159a68356fd5b23;
		int num2 = num - x311e7a92306d7199.x406d8cd2af514771.xa79651e2f1a1416e.x91e854e77522d9eb;
		if (xc51ece8069fc7a51 == num)
		{
			return num2;
		}
		return Math.Min(num2, xc51ece8069fc7a51);
	}

	private static int x09608114085f8e09(xf6937c72cebe4ad1 xb6842aa1e60562e1, int x65db79d46690068a)
	{
		if (xb6842aa1e60562e1.x149175c6cbc422b6())
		{
			return xb6842aa1e60562e1.x8df91a2f90079e88;
		}
		int num = xfd32adc83f7de856.x795e09a07e435cf4(xb6842aa1e60562e1);
		if (x65db79d46690068a <= xb6842aa1e60562e1.xc255c495fd9232ca.x5c392d6ad6fe7e28)
		{
			return num;
		}
		x41ccdd7753312e4f xa79651e2f1a1416e = xb6842aa1e60562e1.x406d8cd2af514771.xa79651e2f1a1416e;
		int xc0741c7ff92cf1aa = xa79651e2f1a1416e.xc0741c7ff92cf1aa;
		int xc7d7e186f0ace1e = xa79651e2f1a1416e.xc7d7e186f0ace1e0;
		bool flag = xc7d7e186f0ace1e >= 0;
		int val = ((!xb6842aa1e60562e1.x708cb8686d32e467) ? (flag ? x65db79d46690068a : (x65db79d46690068a + Math.Min(xc0741c7ff92cf1aa, 0))) : (flag ? (x65db79d46690068a + xc7d7e186f0ace1e) : (x65db79d46690068a + xc0741c7ff92cf1aa)));
		return Math.Max(val, num);
	}

	private static bool xf07d47c790bc0b83(x56410a8dd70087c5 x2aa5114a5da7d6c8)
	{
		if (!x5566e2d2acbd1fbe.xdf6487d5ff34ad70(x2aa5114a5da7d6c8.x5566e2d2acbd1fbe))
		{
			return false;
		}
		if (x2aa5114a5da7d6c8.x4a1a6d8b0aafa0fe == x4a1a6d8b0aafa0fe.xb70c4e1b6bf793bc)
		{
			return false;
		}
		switch (x2aa5114a5da7d6c8.xf9ad6fb78355fe13[x2aa5114a5da7d6c8.xf9ad6fb78355fe13.Length - 1])
		{
		case '-':
		case '–':
		case '—':
			return false;
		default:
		{
			if (x2aa5114a5da7d6c8.x5566e2d2acbd1fbe == 9752)
			{
				return false;
			}
			x56410a8dd70087c5 x56410a8dd70087c6 = xf0b374f4c0172a4c.x57b3c9e650685d36(x2aa5114a5da7d6c8.x61712f0b4f5455af, null, null, xa17853d20c8c42bd: true, x4d2b4f056cf5bb8b: false);
			return x5566e2d2acbd1fbe.xdf6487d5ff34ad70(x56410a8dd70087c6.x5566e2d2acbd1fbe);
		}
		}
	}

	private x3822c4a3772d4456 xbb13dc484690ae9a(int x1e218ceaee1bb583, int x4d5aabc7a55b12ba, int xcbb242d049e2b480, Point xf7845a6fecd5afc3, Rectangle x6e02bf4cd8dc8b80)
	{
		Rectangle rectangle = new Rectangle(x6e02bf4cd8dc8b80.X - xf7845a6fecd5afc3.X, x1e218ceaee1bb583, x6e02bf4cd8dc8b80.Width, x4d5aabc7a55b12ba);
		if (x44848d430b83e161 == null)
		{
			return new x3822c4a3772d4456(rectangle, x4d5aabc7a55b12ba);
		}
		if (!xf7845a6fecd5afc3.IsEmpty)
		{
			rectangle = new Rectangle(rectangle.X + xf7845a6fecd5afc3.X, rectangle.Y + xf7845a6fecd5afc3.Y, rectangle.Width, rectangle.Height);
		}
		x3822c4a3772d4456 x3822c4a3772d4457 = x44848d430b83e161.xbb13dc484690ae9a(rectangle, xcbb242d049e2b480);
		if (!xf7845a6fecd5afc3.IsEmpty)
		{
			return x3822c4a3772d4457.x9e19f5bd0a6dd5b7(xf7845a6fecd5afc3);
		}
		return x3822c4a3772d4457;
	}
}
