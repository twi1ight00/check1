using System;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace x722d80085b19d13f;

internal class x01f345749770e63a
{
	private const double x080dbdf13654c3c9 = 8.0;

	private readonly int xc7f11e42fdf798cb;

	private readonly x01f345749770e63a x61f4810b9328cb8d;

	private readonly TxtSaveOptions x1cb867f3d40f3203;

	private xf167a284a47d2590 x047f3d74dc5f5da7;

	private Cell x8b7d11433ac1b550;

	private int x90e87e15dff39b39;

	private int x912d2719fafd87ee;

	private int x3ad693712d209bea;

	internal xf167a284a47d2590 x734991a6e63a780b
	{
		get
		{
			if (x047f3d74dc5f5da7 == null)
			{
				x047f3d74dc5f5da7 = ((x61f4810b9328cb8d != null) ? x61f4810b9328cb8d.x734991a6e63a780b : new xf167a284a47d2590());
			}
			return x047f3d74dc5f5da7;
		}
	}

	private int x01754a2f9e820e5e => x734991a6e63a780b.xf9ea3b8d9198b0cc.Length - xf1d62bb8c15e3f69;

	private int xa4a31c18a541dd90 => Math.Max(x01754a2f9e820e5e, 0);

	private int xc858a6961d252ef9 => xb0ac4982b0626275() - xa4a31c18a541dd90;

	private int xf1d62bb8c15e3f69 => xa8e021446057c073 + x90e87e15dff39b39;

	private int xa8e021446057c073
	{
		get
		{
			if (x61f4810b9328cb8d == null)
			{
				return 0;
			}
			return x61f4810b9328cb8d.xf1d62bb8c15e3f69;
		}
	}

	internal x01f345749770e63a(Table table, x01f345749770e63a parentBuilder, TxtSaveOptions saveOptions)
	{
		xc7f11e42fdf798cb = x6dfe4cc440adef45(Math.Max(table.LeftIndent, 0.0));
		x61f4810b9328cb8d = parentBuilder;
		x1cb867f3d40f3203 = saveOptions;
		if (parentBuilder != null)
		{
			x912d2719fafd87ee = x734991a6e63a780b.x356b85d0f5cf3f6f;
			x3ad693712d209bea = x734991a6e63a780b.x356b85d0f5cf3f6f;
		}
	}

	internal void x5e3f44647fcfb8fc(Row xa806b754814b9ae0)
	{
		x8b7d11433ac1b550 = null;
		x90e87e15dff39b39 = xc7f11e42fdf798cb;
	}

	internal void xbdbbc98113b6b783()
	{
		x912d2719fafd87ee = x3ad693712d209bea;
	}

	internal bool xcbc713eb2e22657d(Cell xe6de5e5fa2d44af5)
	{
		x8b7d11433ac1b550 = xe6de5e5fa2d44af5;
		if (x753603653e5f0f86())
		{
			return false;
		}
		x734991a6e63a780b.x356b85d0f5cf3f6f = x912d2719fafd87ee;
		return true;
	}

	internal void x2a78a52ede7f4385()
	{
		if (!x753603653e5f0f86())
		{
			x90e87e15dff39b39 += xb0ac4982b0626275();
			x3ad693712d209bea = Math.Max(x3ad693712d209bea, x734991a6e63a780b.x356b85d0f5cf3f6f);
		}
	}

	private bool x753603653e5f0f86()
	{
		return x8b7d11433ac1b550.xf8cef531dae89ea3.x61127d98597c4898;
	}

	internal void xe4fd28685b34ecc7(string xb41faee6912a2313)
	{
		if (xb41faee6912a2313 == x1cb867f3d40f3203.ParagraphBreak)
		{
			x047f3d74dc5f5da7.x356b85d0f5cf3f6f++;
		}
		else if (xb41faee6912a2313.Length <= xc858a6961d252ef9)
		{
			x0097bfd7cb640579(xb41faee6912a2313);
		}
		else
		{
			x53d39342dc45172d(xb41faee6912a2313);
		}
	}

	private void x53d39342dc45172d(string xb41faee6912a2313)
	{
		int num;
		for (int i = 0; i < xb41faee6912a2313.Length; i += num)
		{
			num = xb176f67652e8f9e8(xb41faee6912a2313, i);
			string xb41faee6912a2314 = xb41faee6912a2313.Substring(i, num);
			x0097bfd7cb640579(xb41faee6912a2314);
			x734991a6e63a780b.x356b85d0f5cf3f6f++;
		}
	}

	private int xb176f67652e8f9e8(string xb41faee6912a2313, int x572f24abeb0300ea)
	{
		int num = 0;
		int num2 = Math.Min(xb41faee6912a2313.Length - x572f24abeb0300ea, xc858a6961d252ef9);
		bool flag = !char.IsWhiteSpace(xb41faee6912a2313[x572f24abeb0300ea]);
		for (int i = 0; i < num2; i++)
		{
			int num3 = x572f24abeb0300ea + i;
			char c = xb41faee6912a2313[num3];
			if (char.IsWhiteSpace(c))
			{
				if (flag)
				{
					num = num3;
					flag = false;
				}
			}
			else
			{
				flag = true;
			}
		}
		if (num == 0)
		{
			return num2;
		}
		return num - x572f24abeb0300ea;
	}

	private void x0097bfd7cb640579(string xb41faee6912a2313)
	{
		if (x01754a2f9e820e5e < 0)
		{
			x047f3d74dc5f5da7.xf9ea3b8d9198b0cc.Append(' ', -x01754a2f9e820e5e);
		}
		x734991a6e63a780b.xf9ea3b8d9198b0cc.Append(xb41faee6912a2313);
	}

	private int xb0ac4982b0626275()
	{
		if (x8b7d11433ac1b550 == null)
		{
			return 0;
		}
		double x6fa2570084b2ad = x4574ea26106f0edb.x0e1fdb362561ddb2(x46f71f175b1e3f68());
		return Math.Max(x6dfe4cc440adef45(x6fa2570084b2ad), 1);
	}

	private int x46f71f175b1e3f68()
	{
		xf8cef531dae89ea3 xf8cef531dae89ea = x8b7d11433ac1b550.xf8cef531dae89ea3;
		if (xf8cef531dae89ea.x338a5e6ab7c5595e == CellMerge.None)
		{
			return xf8cef531dae89ea.xdc1bf80853046136;
		}
		int num = xf8cef531dae89ea.xdc1bf80853046136;
		Cell xb2e852052ab1c1be = x8b7d11433ac1b550.xb2e852052ab1c1be;
		while (xb2e852052ab1c1be != null && xb2e852052ab1c1be.xf8cef531dae89ea3.x338a5e6ab7c5595e == CellMerge.Previous)
		{
			num += xb2e852052ab1c1be.xf8cef531dae89ea3.xdc1bf80853046136;
			xb2e852052ab1c1be = xb2e852052ab1c1be.xb2e852052ab1c1be;
		}
		return num;
	}

	private static int x6dfe4cc440adef45(double x6fa2570084b2ad39)
	{
		return (int)(x6fa2570084b2ad39 / 8.0);
	}
}
