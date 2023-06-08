using System.IO;

namespace x4f4df92b75ba3b67;

internal class xae0e17c5b80c840f : x8fbf0a5e230a8cae
{
	private const int xd31b2acb4f7d2eab = 5021;

	private const int x9216fc626738d3ff = 256;

	private const int x9128741dd92648ce = 257;

	private const int xba3cf3fce1d56df3 = -1;

	private const int xc154d3d211ea8510 = 12;

	private MemoryStream x733fadcc15d71411;

	private readonly int[] xe43f356c64e7f2cd;

	private readonly int[] x2fc975c8c18698df;

	private readonly byte[] x4137b4fb598b598a;

	private int xa74d0caa20593f88;

	private int x179a17403b53f7b9;

	private int x05a6b177182d1e8e;

	private xe95afcd975f61ba3 x5c884f9ec10d7f35;

	public xae0e17c5b80c840f(Stream outputStream)
		: base(outputStream)
	{
		xe43f356c64e7f2cd = new int[5021];
		x2fc975c8c18698df = new int[5021];
		x4137b4fb598b598a = new byte[5021];
	}

	public xae0e17c5b80c840f(Stream outputStream, x78a77d442e16bfcb predictor, int colors, int columns, int bpp)
		: this(outputStream)
	{
		if (predictor != x78a77d442e16bfcb.xc19713a99141b6ee)
		{
			x5c884f9ec10d7f35 = new xe95afcd975f61ba3(predictor, colors, columns, bpp);
		}
		else
		{
			x5c884f9ec10d7f35 = null;
		}
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		if (x5c884f9ec10d7f35 != null)
		{
			x733fadcc15d71411 = x5c884f9ec10d7f35.x550781f8db1cf5f2(new MemoryStream(srcBuffer, srcOffset, srcCount));
			x733fadcc15d71411.Position = 0L;
		}
		else
		{
			x733fadcc15d71411 = new MemoryStream(srcBuffer, srcOffset, srcCount);
		}
		xd9c092b74a3b6044();
		x4289397d818e0555();
		x8291881ef07bb5c7();
	}

	private void xd9c092b74a3b6044()
	{
		xa74d0caa20593f88 = 0;
		x179a17403b53f7b9 = 128;
		x05a6b177182d1e8e = 9;
	}

	private void x4289397d818e0555()
	{
		for (int i = 0; i < xe43f356c64e7f2cd.Length; i++)
		{
			xe43f356c64e7f2cd[i] = -1;
		}
	}

	private void x26af3224a80cf248()
	{
		if (x179a17403b53f7b9 != 128)
		{
			x6169576fb3c218d3.WriteByte((byte)xa74d0caa20593f88);
		}
	}

	private void x1485d1261faf8961(bool x2dd7de7c7b0ddad5)
	{
		if (x2dd7de7c7b0ddad5)
		{
			xa74d0caa20593f88 |= x179a17403b53f7b9;
		}
		x179a17403b53f7b9 >>= 1;
		if (x179a17403b53f7b9 == 0)
		{
			x6169576fb3c218d3.WriteByte((byte)xa74d0caa20593f88);
			xa74d0caa20593f88 = 0;
			x179a17403b53f7b9 = 128;
		}
	}

	private void xd49142d008cda9ad(int x9035cf16181332fc)
	{
		for (int num = 1 << x05a6b177182d1e8e - 1; num != 0; num >>= 1)
		{
			x1485d1261faf8961((num & x9035cf16181332fc) != 0);
		}
	}

	private void x8291881ef07bb5c7()
	{
		int num = 258;
		int num2 = x733fadcc15d71411.ReadByte();
		if (num2 == -1)
		{
			num2 = 257;
		}
		xd49142d008cda9ad(256);
		int num3;
		while ((num3 = x733fadcc15d71411.ReadByte()) != -1)
		{
			int num4 = xe983b14fdf6b22a2(num2, num3);
			if (num == 1 << x05a6b177182d1e8e)
			{
				if (x05a6b177182d1e8e < 12)
				{
					x05a6b177182d1e8e++;
				}
				else
				{
					num = 258;
					x4289397d818e0555();
					xd49142d008cda9ad(256);
					x05a6b177182d1e8e = 9;
				}
			}
			if (xe43f356c64e7f2cd[num4] != -1)
			{
				num2 = xe43f356c64e7f2cd[num4];
				continue;
			}
			xe43f356c64e7f2cd[num4] = num++;
			x2fc975c8c18698df[num4] = num2;
			x4137b4fb598b598a[num4] = (byte)num3;
			xd49142d008cda9ad(num2);
			num2 = num3;
		}
		xd49142d008cda9ad(num2);
		xd49142d008cda9ad(257);
		x26af3224a80cf248();
	}

	private int xe983b14fdf6b22a2(int x928891bcdd71402c, int x12f11d52c2c4d003)
	{
		int num = (x12f11d52c2c4d003 << x05a6b177182d1e8e - 8) ^ x928891bcdd71402c;
		int num2 = ((num == 0) ? 1 : (5021 - num));
		while (xe43f356c64e7f2cd[num] != -1 && (x2fc975c8c18698df[num] != x928891bcdd71402c || x4137b4fb598b598a[num] != (byte)x12f11d52c2c4d003))
		{
			num -= num2;
			if (num < 0)
			{
				num += 5021;
			}
		}
		return num;
	}
}
