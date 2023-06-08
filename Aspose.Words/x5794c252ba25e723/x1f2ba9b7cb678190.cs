using System;
using System.Reflection;
using x6c95d9cf46ff5f25;

namespace x5794c252ba25e723;

[DefaultMember("Item")]
internal class x1f2ba9b7cb678190
{
	public const int x23b0343396dd51f7 = 5;

	private readonly float[,] x7286375b31f8bb61 = new float[5, 5];

	public bool xb22bde0e9b6be655
	{
		get
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					float num = x7286375b31f8bb61[i, j];
					if ((i == j && num != 1f) || (i != j && num != 0f))
					{
						return false;
					}
				}
			}
			return true;
		}
	}

	public float xe6d4b1b411ed94b5
	{
		get
		{
			return x7286375b31f8bb61[x78a7603cacf2ae22, xbeb0e74fd1e3aefb];
		}
		set
		{
			if (x78a7603cacf2ae22 > 4 || xbeb0e74fd1e3aefb > 4)
			{
				throw new IndexOutOfRangeException("DrColorMatrix has size 5x5.");
			}
			x7286375b31f8bb61[x78a7603cacf2ae22, xbeb0e74fd1e3aefb] = value;
		}
	}

	public x1f2ba9b7cb678190()
		: this(initializeWithIdentityMatrix: true)
	{
	}

	public x1f2ba9b7cb678190(float[][] colorMatrix)
	{
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				x7286375b31f8bb61[i, j] = colorMatrix[i][j];
			}
		}
	}

	private x1f2ba9b7cb678190(bool initializeWithIdentityMatrix)
	{
		if (initializeWithIdentityMatrix)
		{
			for (int i = 0; i < 5; i++)
			{
				x7286375b31f8bb61[i, i] = 1f;
			}
		}
	}

	public static x1f2ba9b7cb678190 x490e30087768649f(x1f2ba9b7cb678190 x6d222484fabe70f5, x1f2ba9b7cb678190 x136977dc5ec23d18)
	{
		if (x6d222484fabe70f5 == null)
		{
			throw new ArgumentNullException("leftMatrix");
		}
		if (x136977dc5ec23d18 == null)
		{
			throw new ArgumentNullException("rightMatrix");
		}
		x1f2ba9b7cb678190 x1f2ba9b7cb678191 = new x1f2ba9b7cb678190(initializeWithIdentityMatrix: false);
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				for (int k = 0; k < 5; k++)
				{
					x1f2ba9b7cb678191.get_xe6d4b1b411ed94b5(i, j) += x6d222484fabe70f5.get_xe6d4b1b411ed94b5(i, k) * x136977dc5ec23d18.get_xe6d4b1b411ed94b5(k, j);
				}
			}
		}
		return x1f2ba9b7cb678191;
	}

	public static x26d9ecb4bdf0456d x30864e0aab264e78(x26d9ecb4bdf0456d x6c50a99faab7d741, x1f2ba9b7cb678190 x8039d626ac56f33d)
	{
		int r = x15e971129fd80714.xffd822a191639f47((float)x6c50a99faab7d741.xc613adc4330033f3 * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(0, 0) + (float)x6c50a99faab7d741.x26463655896fd90a * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(1, 0) + (float)x6c50a99faab7d741.x8e8f6cc6a0756b05 * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(2, 0) + (float)x6c50a99faab7d741.xda71bf6f7c07c3bc * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(3, 0) + 255f * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(4, 0));
		int g = x15e971129fd80714.xffd822a191639f47((float)x6c50a99faab7d741.xc613adc4330033f3 * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(0, 1) + (float)x6c50a99faab7d741.x26463655896fd90a * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(1, 1) + (float)x6c50a99faab7d741.x8e8f6cc6a0756b05 * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(2, 1) + (float)x6c50a99faab7d741.xda71bf6f7c07c3bc * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(3, 1) + 255f * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(4, 1));
		int b = x15e971129fd80714.xffd822a191639f47((float)x6c50a99faab7d741.xc613adc4330033f3 * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(0, 2) + (float)x6c50a99faab7d741.x26463655896fd90a * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(1, 2) + (float)x6c50a99faab7d741.x8e8f6cc6a0756b05 * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(2, 2) + (float)x6c50a99faab7d741.xda71bf6f7c07c3bc * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(3, 2) + 255f * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(4, 2));
		int a = x15e971129fd80714.xffd822a191639f47((float)x6c50a99faab7d741.xc613adc4330033f3 * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(0, 3) + (float)x6c50a99faab7d741.x26463655896fd90a * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(1, 3) + (float)x6c50a99faab7d741.x8e8f6cc6a0756b05 * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(2, 3) + (float)x6c50a99faab7d741.xda71bf6f7c07c3bc * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(3, 3) + 255f * x8039d626ac56f33d.get_xe6d4b1b411ed94b5(4, 3));
		return new x26d9ecb4bdf0456d(a, r, g, b);
	}
}
