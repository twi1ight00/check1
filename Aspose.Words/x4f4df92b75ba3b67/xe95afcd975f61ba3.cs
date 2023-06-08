using System;
using System.IO;

namespace x4f4df92b75ba3b67;

internal class xe95afcd975f61ba3
{
	private int x150096710045cd80;

	private int x0738aa2d26c025e6;

	private byte[] x0f0d05778fc608df;

	private byte[] x8b57725e190131b5;

	private int x416daa5f27da7c5c;

	private int x660741034f534cfd;

	private int x8205f1a5866d469c;

	private x78a77d442e16bfcb xc95e25b32501a226;

	private x78a77d442e16bfcb x13772380bb6159c2;

	public xe95afcd975f61ba3(x78a77d442e16bfcb predictor, int colors, int columns, int bpp)
	{
		x72265cd62c22d100(colors, bpp);
		x416daa5f27da7c5c = colors;
		x660741034f534cfd = columns;
		x8205f1a5866d469c = bpp;
		xc95e25b32501a226 = predictor;
	}

	public MemoryStream x550781f8db1cf5f2(MemoryStream x337e217cb3ba0627)
	{
		MemoryStream memoryStream = new MemoryStream((int)((double)x337e217cb3ba0627.Length + Math.Round((double)x337e217cb3ba0627.Length / (double)(x416daa5f27da7c5c * x660741034f534cfd))));
		x337e217cb3ba0627.Position = 0L;
		memoryStream.Position = 0L;
		x0738aa2d26c025e6 = (int)((double)x416daa5f27da7c5c * Math.Round((double)x8205f1a5866d469c / 8.0));
		x150096710045cd80 = x0738aa2d26c025e6 * x660741034f534cfd;
		x0f0d05778fc608df = new byte[x150096710045cd80];
		x8b57725e190131b5 = new byte[x150096710045cd80];
		for (int i = 0; i < x0738aa2d26c025e6; i++)
		{
			x8b57725e190131b5[i] = 0;
		}
		byte[] array = new byte[x150096710045cd80];
		while (x337e217cb3ba0627.Position < x337e217cb3ba0627.Length)
		{
			for (int j = 0; j < x150096710045cd80; j++)
			{
				int num = x337e217cb3ba0627.ReadByte();
				if (num == -1)
				{
					break;
				}
				x0f0d05778fc608df[j] = (byte)num;
			}
			x13772380bb6159c2 = ((xc95e25b32501a226 == x78a77d442e16bfcb.xb1a9c37804ac83d7) ? xd6b38c004c8bdac0() : xc95e25b32501a226);
			for (int k = 0; k < x150096710045cd80; k++)
			{
				array[k] = xedcd7c0b6075ad32(x13772380bb6159c2, x0f0d05778fc608df[k], k);
			}
			for (int l = 0; l < x150096710045cd80; l++)
			{
				x8b57725e190131b5[l] = x0f0d05778fc608df[l];
			}
			memoryStream.WriteByte(x82af55b1592c86c6(x13772380bb6159c2));
			memoryStream.Write(array, 0, x150096710045cd80);
		}
		return memoryStream;
	}

	private static byte x82af55b1592c86c6(x78a77d442e16bfcb x914b98f3ded66993)
	{
		return x914b98f3ded66993 switch
		{
			x78a77d442e16bfcb.x23b58036890a1f7a => 0, 
			x78a77d442e16bfcb.xba2f4dbbf5f3f5ff => 1, 
			x78a77d442e16bfcb.xf2d671d1d1668a42 => 2, 
			x78a77d442e16bfcb.x7a95dafdbe0725af => 3, 
			x78a77d442e16bfcb.x298ca06b895fb903 => 4, 
			_ => throw new ArgumentException("Unsupported predictor type"), 
		};
	}

	private x78a77d442e16bfcb xd6b38c004c8bdac0()
	{
		x78a77d442e16bfcb result = x78a77d442e16bfcb.xc19713a99141b6ee;
		double num = double.PositiveInfinity;
		byte[] array = new byte[x150096710045cd80];
		for (x78a77d442e16bfcb x78a77d442e16bfcb2 = x78a77d442e16bfcb.x23b58036890a1f7a; x78a77d442e16bfcb2 != x78a77d442e16bfcb.xb1a9c37804ac83d7; x78a77d442e16bfcb2++)
		{
			for (int i = 0; i < x150096710045cd80; i++)
			{
				array[i] = x0f0d05778fc608df[i];
			}
			for (int j = 0; j < x150096710045cd80; j++)
			{
				array[j] = xedcd7c0b6075ad32(x78a77d442e16bfcb2, array[j], j);
			}
			double num2 = 0.0;
			for (int k = 0; k < x150096710045cd80; k++)
			{
				num2 += (double)(int)array[k];
			}
			num2 /= (double)x150096710045cd80;
			if (num2 < num)
			{
				result = x78a77d442e16bfcb2;
				num = num2;
			}
		}
		return result;
	}

	private byte xedcd7c0b6075ad32(x78a77d442e16bfcb xcb72c06af8e28315, int x4d24d61a0c675cb2, int xa3355ced27ba170a)
	{
		return xcb72c06af8e28315 switch
		{
			x78a77d442e16bfcb.x23b58036890a1f7a => (byte)x4d24d61a0c675cb2, 
			x78a77d442e16bfcb.xc19713a99141b6ee => xc17750c1f5ad7d25(x4d24d61a0c675cb2, xa3355ced27ba170a), 
			x78a77d442e16bfcb.xba2f4dbbf5f3f5ff => x15f73c8dc01628f7(x4d24d61a0c675cb2, xa3355ced27ba170a), 
			x78a77d442e16bfcb.xf2d671d1d1668a42 => x9de4b2ade29bb5dd(x4d24d61a0c675cb2, xa3355ced27ba170a), 
			x78a77d442e16bfcb.x7a95dafdbe0725af => xc17750c1f5ad7d25(x4d24d61a0c675cb2, xa3355ced27ba170a), 
			x78a77d442e16bfcb.x298ca06b895fb903 => xb151c44db970a8b8(x4d24d61a0c675cb2, xa3355ced27ba170a), 
			_ => throw new InvalidOperationException("Please report exception."), 
		};
	}

	private byte x15f73c8dc01628f7(int x4d24d61a0c675cb2, int xa3355ced27ba170a)
	{
		int num = ((xa3355ced27ba170a - x0738aa2d26c025e6 >= 0) ? x0f0d05778fc608df[xa3355ced27ba170a - x0738aa2d26c025e6] : 0);
		return (byte)((x4d24d61a0c675cb2 - num) % 256);
	}

	private byte x9de4b2ade29bb5dd(int x4d24d61a0c675cb2, int xa3355ced27ba170a)
	{
		int num = x8b57725e190131b5[xa3355ced27ba170a];
		return (byte)((x4d24d61a0c675cb2 - num) % 256);
	}

	private byte xc17750c1f5ad7d25(int x4d24d61a0c675cb2, int xa3355ced27ba170a)
	{
		int num = ((xa3355ced27ba170a - x0738aa2d26c025e6 >= 0) ? x0f0d05778fc608df[xa3355ced27ba170a - x0738aa2d26c025e6] : 0);
		num = (num + x8b57725e190131b5[xa3355ced27ba170a]) / 2;
		return (byte)(Math.Floor((double)(x4d24d61a0c675cb2 - num)) % 256.0);
	}

	private byte xb151c44db970a8b8(int x4d24d61a0c675cb2, int xa3355ced27ba170a)
	{
		int x19218ffab70283ef = ((xa3355ced27ba170a - x0738aa2d26c025e6 >= 0) ? x0f0d05778fc608df[xa3355ced27ba170a - x0738aa2d26c025e6] : 0);
		int x3c4da2980d043c = ((xa3355ced27ba170a - x0738aa2d26c025e6 >= 0) ? x8b57725e190131b5[xa3355ced27ba170a - x0738aa2d26c025e6] : 0);
		int xe7ebe10fa44d8d = x8b57725e190131b5[xa3355ced27ba170a];
		return (byte)((x4d24d61a0c675cb2 - x741e7061496f280c(x19218ffab70283ef, xe7ebe10fa44d8d, x3c4da2980d043c)) % 256);
	}

	private static int x741e7061496f280c(int x19218ffab70283ef, int xe7ebe10fa44d8d49, int x3c4da2980d043c95)
	{
		int num = x19218ffab70283ef + xe7ebe10fa44d8d49 - x3c4da2980d043c95;
		int num2 = Math.Abs(num - x19218ffab70283ef);
		int num3 = Math.Abs(num - xe7ebe10fa44d8d49);
		int num4 = Math.Abs(num - x3c4da2980d043c95);
		if (num2 <= num3 && num2 <= num4)
		{
			return x19218ffab70283ef;
		}
		if (num3 <= num4)
		{
			return xe7ebe10fa44d8d49;
		}
		return x3c4da2980d043c95;
	}

	private static void x72265cd62c22d100(int xa70c7ccd3278240f, int x5c1479d50c3706b8)
	{
		if (xa70c7ccd3278240f > 4 || xa70c7ccd3278240f < 1)
		{
			throw new ArgumentException("Invalid color.");
		}
		switch (x5c1479d50c3706b8)
		{
		case 1:
		case 2:
		case 4:
		case 8:
			return;
		}
		throw new ArgumentException("Invalid bpp.");
	}
}
