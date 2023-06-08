using System;
using System.Collections;
using Aspose.Words;
using xf9a9481c3f63a419;

namespace x4adf554d20d941a6;

internal class xf6207a235a46d7fd
{
	private x56410a8dd70087c5 xfe0dcbd6c719ddb1;

	private int xce56266b1a1a323b;

	private int x2d5b7e143568cfba;

	private TabAlignment x758c1e6036006f26;

	private bool x954a46d03cd6162d;

	private readonly Hashtable x08951d296c579801 = new Hashtable();

	internal x56410a8dd70087c5 x95436fa1a80836b7 => xfe0dcbd6c719ddb1;

	internal int xb2946d16fde7a800 => x2d5b7e143568cfba;

	internal bool xd3798e6f6f855196 => x954a46d03cd6162d;

	internal int x88c036fa7c385f8e(xf6937c72cebe4ad1 x311e7a92306d7199, int xbfb9ad5ef64f6dc5, x56410a8dd70087c5 x5906905c888d3d98, int x6475f0bcaa202a8f)
	{
		xc0e747af79894e12 xc0e747af79894e13 = (xc0e747af79894e12)x5906905c888d3d98;
		int num = (x311e7a92306d7199.x8786efe6471e0521 ? (x311e7a92306d7199.xc255c495fd9232ca.xdc1bf80853046136 - x311e7a92306d7199.x419ba17a5322627b) : x311e7a92306d7199.x8df91a2f90079e88);
		xc1231aad908a60dd xc1231aad908a60dd2 = (xc0e747af79894e13.xd685b0558e5e035b ? xc1231aad908a60dd.x859bba88f7c4aefd(x311e7a92306d7199, (x55d93e4cdc939ebf)xc0e747af79894e13, x6475f0bcaa202a8f + num) : xc1231aad908a60dd.x38758cbbee49e4cb(x311e7a92306d7199, x5906905c888d3d98, x6475f0bcaa202a8f + num - xbfb9ad5ef64f6dc5));
		x2d5b7e143568cfba = xc1231aad908a60dd2.xc23e48392ede9acb;
		x758c1e6036006f26 = xc1231aad908a60dd2.x9ba359ff37a3a63b;
		x954a46d03cd6162d = xc1231aad908a60dd2.xd3798e6f6f855196;
		if (x954a46d03cd6162d)
		{
			x5906905c888d3d98.x902d63c74e3c13c4 = xc1231aad908a60dd2.x902d63c74e3c13c4;
		}
		TabAlignment tabAlignment = x758c1e6036006f26;
		if (tabAlignment == TabAlignment.Left || tabAlignment == TabAlignment.List)
		{
			int num2 = x2d5b7e143568cfba + x5906905c888d3d98.x18a5b26861559704;
			xcd55c6ca59cdb4d1(x5906905c888d3d98, num2);
			return num2;
		}
		xfe0dcbd6c719ddb1 = x5906905c888d3d98;
		xce56266b1a1a323b = x6475f0bcaa202a8f;
		return 0;
	}

	internal int x6d71d88c13c53a1b(x56410a8dd70087c5 x5906905c888d3d98, int x6475f0bcaa202a8f)
	{
		if (x5566e2d2acbd1fbe.x6634ed9c1dfbdfce(x5906905c888d3d98.x5566e2d2acbd1fbe))
		{
			int num = 0;
			x56410a8dd70087c5 x12e57449accbce = x5906905c888d3d98.x12e57449accbce52;
			while (x12e57449accbce != null && x12e57449accbce.xfc6971c7d8314663 == xfc6971c7d8314663.x3e1feffd8ca6feb2)
			{
				num += x12e57449accbce.xdc1bf80853046136;
				x12e57449accbce = x12e57449accbce.x12e57449accbce52;
			}
			if (0 < num)
			{
				x6475f0bcaa202a8f -= num;
			}
		}
		int num2 = x6475f0bcaa202a8f - xce56266b1a1a323b;
		if (num2 < 0)
		{
			num2 = 0;
		}
		int num3 = x758c1e6036006f26 switch
		{
			TabAlignment.Right => x2d5b7e143568cfba - num2, 
			TabAlignment.Center => x2d5b7e143568cfba - num2 / 2 + x95436fa1a80836b7.x18a5b26861559704 / 2, 
			TabAlignment.Decimal => x7ae1c2a94ab507cb(x95436fa1a80836b7, x5906905c888d3d98, x2d5b7e143568cfba), 
			_ => throw new InvalidOperationException("Unexpected tab stop alignment value."), 
		};
		int num4 = x95436fa1a80836b7.x08c3e4e0729e675a + x95436fa1a80836b7.x18a5b26861559704;
		if (num3 < num4)
		{
			num3 = num4;
		}
		xcd55c6ca59cdb4d1(x95436fa1a80836b7, num3);
		return xce56266b1a1a323b + num3;
	}

	internal void x2a3d3b0e4a6f33d5(xf6937c72cebe4ad1 x311e7a92306d7199)
	{
		foreach (DictionaryEntry item in x08951d296c579801)
		{
			xc0e747af79894e12 xc0e747af79894e13 = (xc0e747af79894e12)item.Key;
			if (xc0e747af79894e13.x00fa20d37841acd0 && xc0e747af79894e13.xc255c495fd9232ca == x311e7a92306d7199)
			{
				xc0e747af79894e13.x887b872a95caaab5 = (int)item.Value;
			}
		}
		x08951d296c579801.Clear();
	}

	internal void x74f5a1ef3906e23c()
	{
		xfe0dcbd6c719ddb1 = null;
		xce56266b1a1a323b = 0;
		x2d5b7e143568cfba = 0;
		x758c1e6036006f26 = TabAlignment.Left;
	}

	private static int x7ae1c2a94ab507cb(x56410a8dd70087c5 x882eb2ce70ec1c88, x56410a8dd70087c5 x939545c74b6f0497, int x8e6c8ced4d5356b9)
	{
		xf0b374f4c0172a4c xf0b374f4c0172a4c2 = new xf0b374f4c0172a4c(x882eb2ce70ec1c88.x61712f0b4f5455af, null);
		xf0b374f4c0172a4c2.x6cfb41b4bd00d940();
		char c = xca004f56614e2431.xaccdf4f36d70782c();
		char c2 = xca004f56614e2431.x34467b042ad8c56e();
		x56410a8dd70087c5 x61712f0b4f5455af = xf0b374f4c0172a4c2.x56410a8dd70087c5;
		while (x61712f0b4f5455af != null && x61712f0b4f5455af != x939545c74b6f0497 && !x5566e2d2acbd1fbe.xdf6487d5ff34ad70(x61712f0b4f5455af.x5566e2d2acbd1fbe))
		{
			x61712f0b4f5455af = x61712f0b4f5455af.x61712f0b4f5455af;
		}
		bool flag = x5566e2d2acbd1fbe.xdf6487d5ff34ad70(x61712f0b4f5455af.x5566e2d2acbd1fbe) && char.IsDigit(x61712f0b4f5455af.xf9ad6fb78355fe13[0]);
		int num = 0;
		while (xf0b374f4c0172a4c2.x56410a8dd70087c5 != x939545c74b6f0497)
		{
			if (x5566e2d2acbd1fbe.xdf6487d5ff34ad70(xf0b374f4c0172a4c2.x56410a8dd70087c5.x5566e2d2acbd1fbe))
			{
				if (xf0b374f4c0172a4c2.x067d56aec20cdd99 == c || (flag && !char.IsDigit(xf0b374f4c0172a4c2.x067d56aec20cdd99) && xf0b374f4c0172a4c2.x067d56aec20cdd99 != c2))
				{
					break;
				}
				if (!flag && char.IsDigit(xf0b374f4c0172a4c2.x067d56aec20cdd99))
				{
					flag = true;
				}
				num += xf0b374f4c0172a4c2.xc7c6550a888abaf3();
			}
			else
			{
				num += xf0b374f4c0172a4c2.x56410a8dd70087c5.x887b872a95caaab5;
			}
			if (!xf0b374f4c0172a4c2.x47f176deff0d42e2())
			{
				break;
			}
		}
		x8e6c8ced4d5356b9 = Math.Max(0, x8e6c8ced4d5356b9 - num);
		return x8e6c8ced4d5356b9;
	}

	private void xcd55c6ca59cdb4d1(x56410a8dd70087c5 xf476cf5d47b0cb4c, int x8e6c8ced4d5356b9)
	{
		x08951d296c579801[xf476cf5d47b0cb4c] = Math.Max(0, x8e6c8ced4d5356b9 - xf476cf5d47b0cb4c.x08c3e4e0729e675a - xf476cf5d47b0cb4c.x18a5b26861559704);
	}
}
