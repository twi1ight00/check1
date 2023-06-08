using x5794c252ba25e723;

namespace x6c95d9cf46ff5f25;

internal class x05445f08a0a17687
{
	private static readonly double[] xcafb93ac16c2dbb8 = new double[9] { 0.4360747, 0.3850649, 0.1430804, 0.2225045, 0.7168786, 0.0606169, 0.0139322, 0.0971045, 0.7141733 };

	private static readonly double[] xf65077947ed50908 = new double[9] { 3.1338561, -1.6168667, -0.4906146, -0.9787684, 1.9161415, 0.033454, 0.0719453, -0.2289914, 1.4052427 };

	private x05445f08a0a17687()
	{
	}

	public static x26d9ecb4bdf0456d x82410676ea092625(x26d9ecb4bdf0456d x6d9a095d183b6b50, x26d9ecb4bdf0456d x60a2487f840b534c, double x607a3f96d060de40)
	{
		if (x607a3f96d060de40 == 0.0)
		{
			return x60a2487f840b534c;
		}
		if (x607a3f96d060de40 == 1.0)
		{
			return x6d9a095d183b6b50;
		}
		double[] array = xebcf83b00134300b(x6d9a095d183b6b50);
		double[] array2 = xebcf83b00134300b(x60a2487f840b534c);
		for (int i = 0; i < 3; i++)
		{
			array2[i] = array[i] * x607a3f96d060de40 + array2[i] * (1.0 - x607a3f96d060de40);
		}
		return x1659cb35054965d4(array2);
	}

	internal static double[] xebcf83b00134300b(x26d9ecb4bdf0456d x64757caafc3acbfb)
	{
		return x15e971129fd80714.x31b513267896ac22(xcafb93ac16c2dbb8, x13fd50d6a130a211.xf49df313f3311164(x64757caafc3acbfb));
	}

	internal static x26d9ecb4bdf0456d x1659cb35054965d4(double[] x903e4ab5a280bdd2)
	{
		return x13fd50d6a130a211.xad84963169a664d8(x15e971129fd80714.x31b513267896ac22(xf65077947ed50908, x903e4ab5a280bdd2));
	}
}
