using System;

namespace x6c95d9cf46ff5f25;

internal class x15e971129fd80714
{
	private x15e971129fd80714()
	{
	}

	public static double xcdc7b29a812dd7df(double x08d0a6023d4ad136)
	{
		return Math.PI / 180.0 * x08d0a6023d4ad136;
	}

	public static double xc9211137ad7bfa2a(double xbdcb5f8a10694ec1)
	{
		return 180.0 / Math.PI * xbdcb5f8a10694ec1;
	}

	public static double xe193c76ba76a5afc(double xbcea506a33cf9111, double x97edb4541d2ddc2e, double xdb117c7e5c899e75)
	{
		return Math.Min(Math.Max(xbcea506a33cf9111, x97edb4541d2ddc2e), xdb117c7e5c899e75);
	}

	public static float xe193c76ba76a5afc(float xbcea506a33cf9111, float x97edb4541d2ddc2e, float xdb117c7e5c899e75)
	{
		return Math.Min(Math.Max(xbcea506a33cf9111, x97edb4541d2ddc2e), xdb117c7e5c899e75);
	}

	public static double[] x31b513267896ac22(double[] x4ac6e6bd4014fc97, double[] xbedaca1c765625e2)
	{
		int num = xbedaca1c765625e2.Length;
		double[] array = new double[num];
		for (int i = 0; i < x4ac6e6bd4014fc97.Length; i++)
		{
			array[i / num] += x4ac6e6bd4014fc97[i] * xbedaca1c765625e2[i % num];
		}
		return array;
	}

	public static int x43fcc3f62534530b(double xbcea506a33cf9111)
	{
		return (int)Math.Round(xbcea506a33cf9111);
	}

	public static int xffd822a191639f47(double xbcea506a33cf9111)
	{
		return (int)xbcea506a33cf9111;
	}

	public static bool x5ab3b42bd288ad29(double xbcea506a33cf9111)
	{
		return Math.Abs(xbcea506a33cf9111) < double.Epsilon;
	}

	public static bool xd23801717be7f91e(double x77d17eeb695582c3, double x55ed5caacf5c2306)
	{
		return xd23801717be7f91e(x77d17eeb695582c3, x55ed5caacf5c2306, 1E-10);
	}

	public static bool xd23801717be7f91e(double x77d17eeb695582c3, double x55ed5caacf5c2306, double xc256ad1be81a2ec4)
	{
		return Math.Abs(x77d17eeb695582c3 - x55ed5caacf5c2306) < Math.Abs(xc256ad1be81a2ec4);
	}
}
