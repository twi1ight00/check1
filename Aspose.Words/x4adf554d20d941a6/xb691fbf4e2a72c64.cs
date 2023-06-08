using System;
using Aspose.Words.Tables;

namespace x4adf554d20d941a6;

internal class xb691fbf4e2a72c64
{
	private int x4e5af990e7597357;

	private int x7371b33543162018;

	private int x5745e31b23885473;

	private int x8c6321442dd06ede;

	private int x40b1befb6d815191;

	private int x354ff0a0e0bcbb70;

	private int x87766f56ff88394f;

	private int x7daa08a7cc637d21;

	internal void xd99ce1688879db11(x10da90eb9c780c82 x1ec770899c98a268, bool xf70073bbe8d156ac, int x3b3c76521f668fcb)
	{
		x51aaee836a366f91(x1ec770899c98a268, x3b3c76521f668fcb);
		if (0 < x4e5af990e7597357 && 0 < x8c6321442dd06ede)
		{
			x71395d249a551229(x1ec770899c98a268, x3b3c76521f668fcb);
		}
		if (0 < x4e5af990e7597357)
		{
			x03adc0f475318f3f(x1ec770899c98a268);
		}
		if (0 < x4e5af990e7597357 && 0 < x7371b33543162018)
		{
			x604676b7478f8d25(x1ec770899c98a268);
		}
		if (0 < x4e5af990e7597357 && xf70073bbe8d156ac && 5000 > x7daa08a7cc637d21)
		{
			x78a796b7013ca900(x1ec770899c98a268);
		}
		if (0 < x4e5af990e7597357 && 0 < x5745e31b23885473)
		{
			x284c10839a9d2983(x1ec770899c98a268);
		}
		if (0 < x4e5af990e7597357)
		{
			x80ee1aca9f23effc(x1ec770899c98a268);
		}
		if (0 > x4e5af990e7597357)
		{
			xcd9b8a4aced838df(x1ec770899c98a268);
		}
		if (0 > x4e5af990e7597357)
		{
			x4a2dedaaba1ddf5f(x1ec770899c98a268);
		}
		if (0 > x4e5af990e7597357)
		{
			x6be74e0f8782f149(x1ec770899c98a268);
		}
	}

	private void x51aaee836a366f91(x10da90eb9c780c82 x1ec770899c98a268, int x3b3c76521f668fcb)
	{
		x4e5af990e7597357 = x3b3c76521f668fcb - x1ec770899c98a268.x40a8cd925e306f1b;
		x7371b33543162018 = 0;
		x5745e31b23885473 = 0;
		x8c6321442dd06ede = 0;
		x40b1befb6d815191 = 0;
		x354ff0a0e0bcbb70 = 0;
		x87766f56ff88394f = 0;
		x7daa08a7cc637d21 = 0;
		for (int i = 0; i < x1ec770899c98a268.x6e1eb96b81362ebc; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			x5fe4b2f32948ed59.x97831d623b125b19 = Math.Max(x5fe4b2f32948ed59.x97831d623b125b19, x5fe4b2f32948ed59.x338567793328a5a6);
			x5fe4b2f32948ed59.xdc1bf80853046136 = x5fe4b2f32948ed59.x338567793328a5a6;
			x4e5af990e7597357 -= x5fe4b2f32948ed59.x338567793328a5a6;
			switch (x5fe4b2f32948ed59.x30db1c48b3c56061.Type)
			{
			case PreferredWidthType.Auto:
				x7371b33543162018++;
				x40b1befb6d815191 += x5fe4b2f32948ed59.x338567793328a5a6;
				x354ff0a0e0bcbb70 += x5fe4b2f32948ed59.x97831d623b125b19;
				break;
			case PreferredWidthType.Points:
				x5745e31b23885473++;
				x87766f56ff88394f += x5fe4b2f32948ed59.x97831d623b125b19;
				break;
			case PreferredWidthType.Percent:
				x8c6321442dd06ede++;
				x7daa08a7cc637d21 += x5fe4b2f32948ed59.x30db1c48b3c56061.x7680505e84ce0354;
				break;
			}
		}
	}

	private void x71395d249a551229(x10da90eb9c780c82 x1ec770899c98a268, int x3b3c76521f668fcb)
	{
		int num = x3b3c76521f668fcb - x1ec770899c98a268.x40a8cd925e306f1b;
		for (int i = 0; i < x1ec770899c98a268.x6e1eb96b81362ebc; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			if (x5fe4b2f32948ed59.x30db1c48b3c56061.x368bd9f7b8c336b4)
			{
				int num2 = Math.Max(x5fe4b2f32948ed59.x338567793328a5a6, (int)(x5fe4b2f32948ed59.x30db1c48b3c56061.Value * (double)num / 100.0));
				x4e5af990e7597357 += x5fe4b2f32948ed59.xdc1bf80853046136 - num2;
				x5fe4b2f32948ed59.xdc1bf80853046136 = num2;
			}
		}
	}

	private void x03adc0f475318f3f(x10da90eb9c780c82 x1ec770899c98a268)
	{
		for (int i = 0; i < x1ec770899c98a268.x6e1eb96b81362ebc; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			if (x5fe4b2f32948ed59.x30db1c48b3c56061.x08428aa3999da322 && x5fe4b2f32948ed59.x30db1c48b3c56061.xdf4645c89f0e47f6 > x5fe4b2f32948ed59.xdc1bf80853046136)
			{
				x4e5af990e7597357 += x5fe4b2f32948ed59.xdc1bf80853046136 - x5fe4b2f32948ed59.x30db1c48b3c56061.xdf4645c89f0e47f6;
				x5fe4b2f32948ed59.xdc1bf80853046136 = x5fe4b2f32948ed59.x30db1c48b3c56061.xdf4645c89f0e47f6;
			}
		}
	}

	private void x604676b7478f8d25(x10da90eb9c780c82 x1ec770899c98a268)
	{
		int num = x354ff0a0e0bcbb70;
		x4e5af990e7597357 += x40b1befb6d815191;
		for (int i = 0; i < x1ec770899c98a268.x6e1eb96b81362ebc; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			if (x5fe4b2f32948ed59.x30db1c48b3c56061.xa72bf798a679c0aa && num != 0)
			{
				int num2 = Math.Max(x5fe4b2f32948ed59.xdc1bf80853046136, x4e5af990e7597357 * x5fe4b2f32948ed59.x97831d623b125b19 / num);
				x4e5af990e7597357 -= num2;
				num -= x5fe4b2f32948ed59.x1e5325ab72cf7ec9;
				x5fe4b2f32948ed59.xdc1bf80853046136 = num2;
			}
		}
	}

	private void x78a796b7013ca900(x10da90eb9c780c82 x1ec770899c98a268)
	{
		for (int i = 0; i < x1ec770899c98a268.x6e1eb96b81362ebc; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			if (x5fe4b2f32948ed59.x30db1c48b3c56061.x368bd9f7b8c336b4)
			{
				int num = x4e5af990e7597357 * x5fe4b2f32948ed59.x30db1c48b3c56061.x7680505e84ce0354 / x7daa08a7cc637d21;
				x4e5af990e7597357 -= num;
				x7daa08a7cc637d21 -= x5fe4b2f32948ed59.x30db1c48b3c56061.x7680505e84ce0354;
				x5fe4b2f32948ed59.xdc1bf80853046136 += num;
				if (x4e5af990e7597357 == 0 || x7daa08a7cc637d21 == 0)
				{
					break;
				}
			}
		}
	}

	private void x284c10839a9d2983(x10da90eb9c780c82 x1ec770899c98a268)
	{
		for (int i = 0; i < x1ec770899c98a268.x6e1eb96b81362ebc; i++)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(i);
			if (x5fe4b2f32948ed59.x30db1c48b3c56061.x08428aa3999da322)
			{
				int num = x4e5af990e7597357 * x5fe4b2f32948ed59.x97831d623b125b19 / x87766f56ff88394f;
				x4e5af990e7597357 -= num;
				x87766f56ff88394f -= x5fe4b2f32948ed59.x97831d623b125b19;
				x5fe4b2f32948ed59.xdc1bf80853046136 += num;
			}
		}
	}

	private void x80ee1aca9f23effc(x10da90eb9c780c82 x1ec770899c98a268)
	{
		int num = x1ec770899c98a268.x6e1eb96b81362ebc;
		int xbeb0e74fd1e3aefb = num;
		while (0 < xbeb0e74fd1e3aefb--)
		{
			int num2 = x4e5af990e7597357 / num;
			x4e5af990e7597357 -= num2;
			num--;
			x1ec770899c98a268.xcda9277b4d19fd44(xbeb0e74fd1e3aefb).xdc1bf80853046136 += num2;
		}
	}

	private void xcd9b8a4aced838df(x10da90eb9c780c82 x1ec770899c98a268)
	{
		int num = 0;
		for (int num2 = x1ec770899c98a268.x6e1eb96b81362ebc - 1; num2 >= 0; num2--)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(num2);
			if (x5fe4b2f32948ed59.x30db1c48b3c56061.xa72bf798a679c0aa)
			{
				num += x5fe4b2f32948ed59.xdc1bf80853046136 - x5fe4b2f32948ed59.x338567793328a5a6;
			}
		}
		int num3 = x1ec770899c98a268.x6e1eb96b81362ebc - 1;
		while (num3 >= 0 && num > 0)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed60 = x1ec770899c98a268.xcda9277b4d19fd44(num3);
			if (x5fe4b2f32948ed60.x30db1c48b3c56061.xa72bf798a679c0aa)
			{
				int num4 = x5fe4b2f32948ed60.xdc1bf80853046136 - x5fe4b2f32948ed60.x338567793328a5a6;
				int num5 = x4e5af990e7597357 * num4 / num;
				x5fe4b2f32948ed60.xdc1bf80853046136 += num5;
				x4e5af990e7597357 -= num5;
				num -= num4;
				if (x4e5af990e7597357 >= 0)
				{
					break;
				}
			}
			num3--;
		}
	}

	private void x4a2dedaaba1ddf5f(x10da90eb9c780c82 x1ec770899c98a268)
	{
		int num = 0;
		for (int num2 = x1ec770899c98a268.x6e1eb96b81362ebc - 1; num2 >= 0; num2--)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(num2);
			if (x5fe4b2f32948ed59.x30db1c48b3c56061.x08428aa3999da322)
			{
				num += x5fe4b2f32948ed59.xdc1bf80853046136 - x5fe4b2f32948ed59.x338567793328a5a6;
			}
		}
		int num3 = x1ec770899c98a268.x6e1eb96b81362ebc - 1;
		while (num3 >= 0 && num > 0)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed60 = x1ec770899c98a268.xcda9277b4d19fd44(num3);
			if (x5fe4b2f32948ed60.x30db1c48b3c56061.x08428aa3999da322)
			{
				int num4 = x5fe4b2f32948ed60.xdc1bf80853046136 - x5fe4b2f32948ed60.x338567793328a5a6;
				int num5 = x4e5af990e7597357 * num4 / num;
				x5fe4b2f32948ed60.xdc1bf80853046136 += num5;
				x4e5af990e7597357 -= num5;
				num -= num4;
				if (x4e5af990e7597357 >= 0)
				{
					break;
				}
			}
			num3--;
		}
	}

	private void x6be74e0f8782f149(x10da90eb9c780c82 x1ec770899c98a268)
	{
		int num = 0;
		for (int num2 = x1ec770899c98a268.x6e1eb96b81362ebc - 1; num2 >= 0; num2--)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed59 = x1ec770899c98a268.xcda9277b4d19fd44(num2);
			if (x5fe4b2f32948ed59.x30db1c48b3c56061.x368bd9f7b8c336b4)
			{
				num += x5fe4b2f32948ed59.xdc1bf80853046136 - x5fe4b2f32948ed59.x338567793328a5a6;
			}
		}
		int num3 = x1ec770899c98a268.x6e1eb96b81362ebc - 1;
		while (num3 >= 0 && num > 0)
		{
			x5fe4b2f32948ed58 x5fe4b2f32948ed60 = x1ec770899c98a268.xcda9277b4d19fd44(num3);
			if (x5fe4b2f32948ed60.x30db1c48b3c56061.x368bd9f7b8c336b4)
			{
				int num4 = x5fe4b2f32948ed60.xdc1bf80853046136 - x5fe4b2f32948ed60.x338567793328a5a6;
				int num5 = x4e5af990e7597357 * num4 / num;
				x5fe4b2f32948ed60.xdc1bf80853046136 += num5;
				x4e5af990e7597357 -= num5;
				num -= num4;
				if (x4e5af990e7597357 >= 0)
				{
					break;
				}
			}
			num3--;
		}
	}
}
