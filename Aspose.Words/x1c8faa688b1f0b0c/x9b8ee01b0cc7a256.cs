using System;
using System.Collections;
using System.Drawing;

namespace x1c8faa688b1f0b0c;

internal class x9b8ee01b0cc7a256
{
	private int x053b53fdac3b8a36;

	private double[] x08f5249e6e681572 = new double[4];

	public RectangleF x55fe8a62afa91ade(x519b1bd0625473ff x311b46c396890b2f)
	{
		if (x311b46c396890b2f == null)
		{
			return RectangleF.Empty;
		}
		x9fe47a4de491f4aa x56b911bdb6515aed = x311b46c396890b2f.x56b911bdb6515aed;
		return x55fe8a62afa91ade(x56b911bdb6515aed.xaf4e0fbe61814cf5, x56b911bdb6515aed.xc7cf0e43653f9c41, x56b911bdb6515aed.xf52fe1c3cad11afd, x56b911bdb6515aed.x2271dea312f4a835);
	}

	public RectangleF x55fe8a62afa91ade(PointF x54acfcf5460fb360, PointF x17a676523ef9e177, PointF x360bf7f1eb33feef, PointF x08eef91ccd7eb033)
	{
		if (x54acfcf5460fb360 == x17a676523ef9e177 && x54acfcf5460fb360 == x360bf7f1eb33feef && x54acfcf5460fb360 == x08eef91ccd7eb033)
		{
			return new RectangleF(x54acfcf5460fb360, SizeF.Empty);
		}
		x053b53fdac3b8a36 = 0;
		xd220eb3b9fd4e7aa(x54acfcf5460fb360, x17a676523ef9e177, x360bf7f1eb33feef, x08eef91ccd7eb033);
		ArrayList x06b4849f65f5a9e = xf91c2ceaeb7305a2(x54acfcf5460fb360, x17a676523ef9e177, x360bf7f1eb33feef, x08eef91ccd7eb033);
		return x59f5c51015d4d2c2(x06b4849f65f5a9e);
	}

	private static double xf91c5bff97d90881(double x36b103723e703d06, double x54acfcf5460fb360, double x08eef91ccd7eb033, double xb4dca84a6a127efd, double x3201d6d15a947682)
	{
		return (xb4dca84a6a127efd - 3.0 * x08eef91ccd7eb033 + 3.0 * x54acfcf5460fb360 - x36b103723e703d06) * Math.Pow(x3201d6d15a947682, 3.0) + (3.0 * x08eef91ccd7eb033 - 6.0 * x54acfcf5460fb360 + 3.0 * x36b103723e703d06) * Math.Pow(x3201d6d15a947682, 2.0) + (3.0 * x54acfcf5460fb360 - 3.0 * x36b103723e703d06) * x3201d6d15a947682 + x36b103723e703d06;
	}

	private static double xda71bf6f7c07c3bc(double x36b103723e703d06, double x54acfcf5460fb360, double x08eef91ccd7eb033, double xb4dca84a6a127efd)
	{
		return 3.0 * xb4dca84a6a127efd - 9.0 * x08eef91ccd7eb033 + 9.0 * x54acfcf5460fb360 - 3.0 * x36b103723e703d06;
	}

	private static double x8e8f6cc6a0756b05(double x36b103723e703d06, double x54acfcf5460fb360, double x08eef91ccd7eb033)
	{
		return 6.0 * x08eef91ccd7eb033 - 12.0 * x54acfcf5460fb360 + 6.0 * x36b103723e703d06;
	}

	private static double x857912840ffd015f(double x36b103723e703d06, double x54acfcf5460fb360)
	{
		return 3.0 * x54acfcf5460fb360 - 3.0 * x36b103723e703d06;
	}

	private static double x3122d79fa5906409(double x19218ffab70283ef, double xe7ebe10fa44d8d49, double x3c4da2980d043c95)
	{
		return Math.Pow(xe7ebe10fa44d8d49, 2.0) - 4.0 * x19218ffab70283ef * x3c4da2980d043c95;
	}

	private static double x4a0247540204944b(double x19218ffab70283ef, double xe7ebe10fa44d8d49, double x3c4da2980d043c95, bool xe4115acdf4fbfccc)
	{
		double d = x3122d79fa5906409(x19218ffab70283ef, xe7ebe10fa44d8d49, x3c4da2980d043c95);
		return (0.0 - xe7ebe10fa44d8d49 + Math.Sqrt(d) * (xe4115acdf4fbfccc ? 1.0 : (-1.0))) / (2.0 * x19218ffab70283ef);
	}

	private void xd220eb3b9fd4e7aa(PointF x54acfcf5460fb360, PointF x17a676523ef9e177, PointF x360bf7f1eb33feef, PointF x08eef91ccd7eb033)
	{
		double x19218ffab70283ef = xda71bf6f7c07c3bc(x54acfcf5460fb360.X, x17a676523ef9e177.X, x360bf7f1eb33feef.X, x08eef91ccd7eb033.X);
		double xe7ebe10fa44d8d = x8e8f6cc6a0756b05(x54acfcf5460fb360.X, x17a676523ef9e177.X, x360bf7f1eb33feef.X);
		double x3c4da2980d043c = x857912840ffd015f(x54acfcf5460fb360.X, x17a676523ef9e177.X);
		double x19218ffab70283ef2 = xda71bf6f7c07c3bc(x54acfcf5460fb360.Y, x17a676523ef9e177.Y, x360bf7f1eb33feef.Y, x08eef91ccd7eb033.Y);
		double xe7ebe10fa44d8d2 = x8e8f6cc6a0756b05(x54acfcf5460fb360.Y, x17a676523ef9e177.Y, x360bf7f1eb33feef.Y);
		double x3c4da2980d043c2 = x857912840ffd015f(x54acfcf5460fb360.Y, x17a676523ef9e177.Y);
		x22c1a1a99dd27273(x19218ffab70283ef, xe7ebe10fa44d8d, x3c4da2980d043c);
		x22c1a1a99dd27273(x19218ffab70283ef2, xe7ebe10fa44d8d2, x3c4da2980d043c2);
	}

	private ArrayList xf91c2ceaeb7305a2(PointF x54acfcf5460fb360, PointF x17a676523ef9e177, PointF x360bf7f1eb33feef, PointF x08eef91ccd7eb033)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(x54acfcf5460fb360);
		arrayList.Add(x08eef91ccd7eb033);
		for (int i = 0; i < x053b53fdac3b8a36; i++)
		{
			double x3201d6d15a = x08f5249e6e681572[i];
			double num = xf91c5bff97d90881(x54acfcf5460fb360.X, x17a676523ef9e177.X, x360bf7f1eb33feef.X, x08eef91ccd7eb033.X, x3201d6d15a);
			double num2 = xf91c5bff97d90881(x54acfcf5460fb360.Y, x17a676523ef9e177.Y, x360bf7f1eb33feef.Y, x08eef91ccd7eb033.Y, x3201d6d15a);
			PointF pointF = new PointF((float)num, (float)num2);
			arrayList.Add(pointF);
		}
		return arrayList;
	}

	private RectangleF x59f5c51015d4d2c2(ArrayList x06b4849f65f5a9e4)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		foreach (PointF item in x06b4849f65f5a9e4)
		{
			num = Math.Min(item.X, num);
			num2 = Math.Min(item.Y, num2);
			num3 = Math.Max(item.X, num3);
			num4 = Math.Max(item.Y, num4);
		}
		return new RectangleF(num, num2, num3 - num, num4 - num2);
	}

	private void x22c1a1a99dd27273(double x19218ffab70283ef, double xe7ebe10fa44d8d49, double x3c4da2980d043c95)
	{
		double num = x3122d79fa5906409(x19218ffab70283ef, xe7ebe10fa44d8d49, x3c4da2980d043c95);
		if (num < 0.0)
		{
			return;
		}
		if (x19218ffab70283ef == 0.0)
		{
			if (xe7ebe10fa44d8d49 != 0.0)
			{
				xe7b6e60eac460955((0.0 - x3c4da2980d043c95) / xe7ebe10fa44d8d49);
			}
		}
		else if (num == 0.0)
		{
			xe7b6e60eac460955(x4a0247540204944b(x19218ffab70283ef, xe7ebe10fa44d8d49, x3c4da2980d043c95, xe4115acdf4fbfccc: true));
		}
		else
		{
			xe7b6e60eac460955(x4a0247540204944b(x19218ffab70283ef, xe7ebe10fa44d8d49, x3c4da2980d043c95, xe4115acdf4fbfccc: true));
			xe7b6e60eac460955(x4a0247540204944b(x19218ffab70283ef, xe7ebe10fa44d8d49, x3c4da2980d043c95, xe4115acdf4fbfccc: false));
		}
	}

	private void xe7b6e60eac460955(double xc301afa072787492)
	{
		if (!(xc301afa072787492 < 0.0) && !(1.0 < xc301afa072787492))
		{
			x08f5249e6e681572[x053b53fdac3b8a36] = xc301afa072787492;
			x053b53fdac3b8a36++;
		}
	}
}
