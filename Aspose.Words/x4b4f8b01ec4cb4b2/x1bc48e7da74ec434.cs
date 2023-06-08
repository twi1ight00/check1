using Aspose.Words.Fonts;

namespace x4b4f8b01ec4cb4b2;

internal class x1bc48e7da74ec434
{
	private const int xd48d46fee05d8b74 = 2;

	private const int x777a804dce419107 = 4;

	private readonly x393d198b88cf5ed5[][] x3533d3fe4cfcefdc;

	internal x1bc48e7da74ec434()
	{
		x3533d3fe4cfcefdc = new x393d198b88cf5ed5[2][];
		for (int i = 0; i < 2; i++)
		{
			x3533d3fe4cfcefdc[i] = new x393d198b88cf5ed5[4];
		}
	}

	internal x1bc48e7da74ec434 x8b61531c8ea35b85()
	{
		x1bc48e7da74ec434 x1bc48e7da74ec435 = new x1bc48e7da74ec434();
		for (int i = 0; i < x3533d3fe4cfcefdc.Length; i++)
		{
			x1bc48e7da74ec435.x3533d3fe4cfcefdc[i] = (x393d198b88cf5ed5[])x3533d3fe4cfcefdc[i].Clone();
		}
		return x1bc48e7da74ec435;
	}

	internal void xd5da23b762ce52a2(x1bc48e7da74ec434 x29295ceaab271327)
	{
		for (int i = 0; i < 2; i++)
		{
			x393d198b88cf5ed5[] array = x29295ceaab271327.x3533d3fe4cfcefdc[i];
			for (int j = 0; j < 4; j++)
			{
				x393d198b88cf5ed5 x393d198b88cf5ed6 = array[j];
				if (x393d198b88cf5ed6 != null)
				{
					x393d198b88cf5ed5 x393d198b88cf5ed7 = x3533d3fe4cfcefdc[i][j];
					if (x393d198b88cf5ed7 == null || (x393d198b88cf5ed7.xf485d4dac21a6985 && !x393d198b88cf5ed6.xf485d4dac21a6985))
					{
						x3533d3fe4cfcefdc[i][j] = x393d198b88cf5ed6;
					}
				}
			}
		}
	}

	internal x393d198b88cf5ed5[] x6a81c6e12edbe4cb(EmbeddedFontFormat x39960861338bf735)
	{
		return x3533d3fe4cfcefdc[(int)x39960861338bf735];
	}

	internal x393d198b88cf5ed5 x38758cbbee49e4cb(EmbeddedFontFormat x39960861338bf735, EmbeddedFontStyle xb8d36db9ad45116a)
	{
		return x3533d3fe4cfcefdc[(int)x39960861338bf735][(int)xb8d36db9ad45116a];
	}

	internal void xd6b6ed77479ef68c(x393d198b88cf5ed5 x26094932cf7a9139)
	{
		x3533d3fe4cfcefdc[(int)x26094932cf7a9139.xa890d2fd18bed2bc][(int)x26094932cf7a9139.xfe2178c1f916f36c] = x26094932cf7a9139;
	}
}
