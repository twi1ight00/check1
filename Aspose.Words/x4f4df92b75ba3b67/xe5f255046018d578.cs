using System;

namespace x4f4df92b75ba3b67;

internal class xe5f255046018d578 : xbbf64dacc941f5e3
{
	private const int xba938a5f6885c544 = 256;

	private const int xde3eddf70cdd202d = 8;

	private readonly int xb2961e7e54ae4624 = 8;

	private readonly float[][] xd6583c1a53ad0ef1;

	private readonly int x569e4fd81ea190e4;

	protected override int FunctionType => 0;

	private xe5f255046018d578(x4882ae789be6e2ef context, int nInputs, int nOutputs, int nSamples, float[][] samples, float[] domain, float[] range)
		: base(context, nInputs, nOutputs, domain, range)
	{
		xd6583c1a53ad0ef1 = samples;
		x569e4fd81ea190e4 = nSamples;
	}

	internal static xe5f255046018d578 x1b45e56db81ccf88(x4882ae789be6e2ef x0f7b23d1c393aed9, float[][] xdc8f3f8857bee4c6, int x1d1c0c546db1820e, int x731b5c46b9896af3, int x2c175568b11e91fa)
	{
		int num = x731b5c46b9896af3 + x2c175568b11e91fa;
		float[] array = new float[num];
		float[] array2 = new float[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = float.PositiveInfinity;
			array2[i] = float.NegativeInfinity;
		}
		for (int j = 0; j < x1d1c0c546db1820e; j++)
		{
			for (int k = 0; k < num; k++)
			{
				if (array[k] > xdc8f3f8857bee4c6[j][k])
				{
					array[k] = xdc8f3f8857bee4c6[j][k];
				}
				if (array2[k] < xdc8f3f8857bee4c6[j][k])
				{
					array2[k] = xdc8f3f8857bee4c6[j][k];
				}
			}
		}
		float[] array3 = new float[x731b5c46b9896af3 * 2];
		float[] array4 = new float[x2c175568b11e91fa * 2];
		for (int l = 0; l < num; l++)
		{
			if (l < x731b5c46b9896af3)
			{
				array3[l * 2] = array[l];
				array3[l * 2 + 1] = array2[l];
			}
			else
			{
				array4[(l - x731b5c46b9896af3) * 2] = array[l];
				array4[(l - x731b5c46b9896af3) * 2 + 1] = array2[l];
			}
		}
		int[] array5 = new int[1] { x1d1c0c546db1820e };
		xdc8f3f8857bee4c6 = x3d7d7a40f87b8720(xdc8f3f8857bee4c6, array3, array4, array5, x731b5c46b9896af3, x2c175568b11e91fa);
		x1d1c0c546db1820e = array5[0];
		return new xe5f255046018d578(x0f7b23d1c393aed9, x731b5c46b9896af3, x2c175568b11e91fa, x1d1c0c546db1820e, xdc8f3f8857bee4c6, array3, array4);
	}

	private static float[][] x3d7d7a40f87b8720(float[][] xdc8f3f8857bee4c6, float[] x1cfaf5c97f48bfd1, float[] x9b10ace6509508c0, int[] x42c6588a9abba7c1, int x731b5c46b9896af3, int x2c175568b11e91fa)
	{
		if (x731b5c46b9896af3 != 1)
		{
			throw new NotImplementedException("Only support functions with one input variable.");
		}
		float[][] array = xdc8f3f8857bee4c6;
		float[] array2 = new float[x731b5c46b9896af3];
		if (x0becca1f24c611f0(xdc8f3f8857bee4c6, x42c6588a9abba7c1[0], x731b5c46b9896af3, array2))
		{
			array2[0] = (x1cfaf5c97f48bfd1[1] - x1cfaf5c97f48bfd1[0]) / 256f;
			array = new float[256][];
			for (int i = 0; i < 256; i++)
			{
				array[i] = new float[x731b5c46b9896af3 + x2c175568b11e91fa];
			}
			int num = -1;
			int num2 = 0;
			for (int j = 0; j < 256; j++)
			{
				array[j][0] = (float)j * array2[0];
				float num3 = xdc8f3f8857bee4c6[num2][0];
				float num4 = ((num >= 0) ? xdc8f3f8857bee4c6[num][0] : 0f);
				for (int k = x731b5c46b9896af3; k < x2c175568b11e91fa + x731b5c46b9896af3; k++)
				{
					float num5 = xdc8f3f8857bee4c6[num2][k];
					float num6 = ((num >= 0) ? xdc8f3f8857bee4c6[num][k] : 0f);
					if (num3 - num4 != 0f)
					{
						float num7 = num5 - num6;
						float num8 = num3 - num4;
						float num9 = array[j][0] - num4;
						array[j][k] = num7 / num8 * num9 + num6;
						if (array[j][k] < x9b10ace6509508c0[(k - x731b5c46b9896af3) * 2])
						{
							array[j][k] = x9b10ace6509508c0[(k - x731b5c46b9896af3) * 2];
						}
						if (array[j][k] > x9b10ace6509508c0[(k - x731b5c46b9896af3) * 2 + 1])
						{
							array[j][k] = x9b10ace6509508c0[(k - x731b5c46b9896af3) * 2 + 1];
						}
					}
					else
					{
						array[j][k] = num5;
					}
				}
				if (array[j][0] >= xdc8f3f8857bee4c6[num2][0])
				{
					num2++;
					num++;
				}
			}
			x42c6588a9abba7c1[0] = 256;
		}
		return array;
	}

	private static bool x0becca1f24c611f0(float[][] xdc8f3f8857bee4c6, int x1d1c0c546db1820e, int x731b5c46b9896af3, float[] x0dcf3abc9f383618)
	{
		bool result = false;
		for (int i = 0; i < x731b5c46b9896af3; i++)
		{
			x0dcf3abc9f383618[i] = float.PositiveInfinity;
		}
		for (int j = 1; j < x1d1c0c546db1820e; j++)
		{
			for (int k = 0; k < x731b5c46b9896af3; k++)
			{
				float num = xdc8f3f8857bee4c6[j][k] - xdc8f3f8857bee4c6[j - 1][k];
				if (num != x0dcf3abc9f383618[k] && x0dcf3abc9f383618[k] != float.PositiveInfinity)
				{
					result = true;
				}
				if (num < x0dcf3abc9f383618[k])
				{
					x0dcf3abc9f383618[k] = num;
				}
			}
		}
		return result;
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		base.x0a2e1f2c2da67e52(xbdfb620b7167944b);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Size", new int[1] { x569e4fd81ea190e4 });
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/BitsPerSample", xb2961e7e54ae4624);
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		if (xb2961e7e54ae4624 != 8)
		{
			throw new NotImplementedException("Only 8 bit per sample functions supported so far.");
		}
		byte[][] array = new byte[x569e4fd81ea190e4][];
		for (int i = 0; i < x569e4fd81ea190e4; i++)
		{
			array[i] = new byte[base.xab413bee118de3cd + base.x3f8e7a57d68071e3];
		}
		for (int j = 0; j < base.xab413bee118de3cd + base.x3f8e7a57d68071e3; j++)
		{
			double num;
			double num2;
			if (j < base.xab413bee118de3cd)
			{
				num = base.x9fba715a9f95491c[j * 2];
				num2 = base.x9fba715a9f95491c[j * 2 + 1];
			}
			else
			{
				num = base.x7d2e50686d249839[(j - base.xab413bee118de3cd) * 2];
				num2 = base.x7d2e50686d249839[(j - base.xab413bee118de3cd) * 2 + 1];
			}
			double num3 = ((num2 - num != 0.0) ? (255.0 / (num2 - num)) : 1.0);
			for (int k = 0; k < x569e4fd81ea190e4; k++)
			{
				double num4 = xd6583c1a53ad0ef1[k][j];
				array[k][j] = (byte)Math.Round((num4 - num) * num3);
			}
		}
		for (int l = 0; l < x569e4fd81ea190e4; l++)
		{
			for (int m = base.xab413bee118de3cd; m < base.xab413bee118de3cd + base.x3f8e7a57d68071e3; m++)
			{
				xc351d479ff7ee789(array[l][m]);
			}
		}
		base.WriteToPdf(writer);
	}
}
