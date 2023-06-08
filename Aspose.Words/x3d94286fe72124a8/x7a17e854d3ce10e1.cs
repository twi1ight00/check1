using System;
using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x7a17e854d3ce10e1
{
	internal static void x45fe46d51e17bed9(x60c040f35bb272aa xaee3ebf4b42e0632, x60c040f35bb272aa x9eb75f670006cc2a)
	{
		int count = x9eb75f670006cc2a.x4d7474e8f1849803.Count;
		int count2 = xaee3ebf4b42e0632.x4d7474e8f1849803.Count;
		if (count2 > 1 && count > 1 && !x37d2d88f96f87b47.xd0fdca5aa42d16bc((PointF)x9eb75f670006cc2a.x4d7474e8f1849803[count - 1], (PointF)xaee3ebf4b42e0632.x4d7474e8f1849803[0]))
		{
			x48cc0c3eaf9f5f05 x7f5704d71690aff = new x48cc0c3eaf9f5f05((PointF)x9eb75f670006cc2a.x4d7474e8f1849803[count - 2], (PointF)x9eb75f670006cc2a.x4d7474e8f1849803[count - 1]);
			x48cc0c3eaf9f5f05 xef563966899b6b = new x48cc0c3eaf9f5f05((PointF)xaee3ebf4b42e0632.x4d7474e8f1849803[0], (PointF)xaee3ebf4b42e0632.x4d7474e8f1849803[1]);
			PointF[] array = new PointF[1] { PointF.Empty };
			if (x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b, array, xf6b46a641abf7d02: true))
			{
				x9eb75f670006cc2a.x4d7474e8f1849803[count - 1] = array[0];
				xaee3ebf4b42e0632.x4d7474e8f1849803[0] = array[0];
			}
		}
	}

	internal static x67293147609631f8[] x88708cef126ae8cf(x60c040f35bb272aa x0861076177854fb1, x67293147609631f8[] x51efd71b3cdcbf9c, bool x3c12013af6b066fd)
	{
		if (x0861076177854fb1.x4d7474e8f1849803.Count < 2)
		{
			return x51efd71b3cdcbf9c;
		}
		ArrayList arrayList = new ArrayList();
		PointF pointF;
		PointF pointF2;
		if (x3c12013af6b066fd)
		{
			pointF = (PointF)x0861076177854fb1.x4d7474e8f1849803[0];
			pointF2 = (PointF)x0861076177854fb1.x4d7474e8f1849803[1];
		}
		else
		{
			pointF = (PointF)x0861076177854fb1.x4d7474e8f1849803[x0861076177854fb1.x4d7474e8f1849803.Count - 2];
			pointF2 = (PointF)x0861076177854fb1.x4d7474e8f1849803[x0861076177854fb1.x4d7474e8f1849803.Count - 1];
		}
		PointF[] x6fa2570084b2ad = new PointF[2] { pointF, pointF2 };
		if (!xc883d0dad69e9e05(x0861076177854fb1, x51efd71b3cdcbf9c, x3c12013af6b066fd, x6fa2570084b2ad, arrayList))
		{
			xeab7024545ca778d(x0861076177854fb1, x51efd71b3cdcbf9c, x3c12013af6b066fd, x6fa2570084b2ad);
		}
		return (x67293147609631f8[])arrayList.ToArray(typeof(x67293147609631f8));
	}

	private static void xeab7024545ca778d(x60c040f35bb272aa x0861076177854fb1, x67293147609631f8[] x51efd71b3cdcbf9c, bool x3c12013af6b066fd, PointF[] x6fa2570084b2ad39)
	{
		x67293147609631f8 x67293147609631f = (x3c12013af6b066fd ? x51efd71b3cdcbf9c[^1] : x51efd71b3cdcbf9c[0]);
		x48cc0c3eaf9f5f05 x7f5704d71690aff = new x48cc0c3eaf9f5f05(x6fa2570084b2ad39[0], x6fa2570084b2ad39[1]);
		x48cc0c3eaf9f5f05 xef563966899b6b = (x3c12013af6b066fd ? new x48cc0c3eaf9f5f05(x67293147609631f.x2f997a78d547d657, x67293147609631f.x2271dea312f4a835) : new x48cc0c3eaf9f5f05(x67293147609631f.x2f997a78d547d657, x67293147609631f.xaf4e0fbe61814cf5));
		PointF[] array = new PointF[1] { PointF.Empty };
		x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b, array);
		ref PointF reference = ref array[0];
		reference = xf683153da3c42565(x51efd71b3cdcbf9c, x3c12013af6b066fd, x6fa2570084b2ad39, array[0]);
		if (x3c12013af6b066fd)
		{
			x0861076177854fb1.x4d7474e8f1849803[0] = array[0];
		}
		else
		{
			x0861076177854fb1.x4d7474e8f1849803[x0861076177854fb1.x4d7474e8f1849803.Count - 1] = array[0];
		}
	}

	internal static PointF xf683153da3c42565(x67293147609631f8[] x51efd71b3cdcbf9c, bool x3c12013af6b066fd, PointF[] x6fa2570084b2ad39, PointF xd368f5b253dc8875)
	{
		float num = x37d2d88f96f87b47.x69e3accf817415e7(x51efd71b3cdcbf9c);
		PointF x5bc3b3e534cfe6dc = (x3c12013af6b066fd ? x51efd71b3cdcbf9c[^1].x2271dea312f4a835 : x51efd71b3cdcbf9c[0].xaf4e0fbe61814cf5);
		float num2 = x37d2d88f96f87b47.x5af88e61b614ce62(xd368f5b253dc8875, x5bc3b3e534cfe6dc);
		float num3 = num;
		if (num2 <= num3)
		{
			return xd368f5b253dc8875;
		}
		x48cc0c3eaf9f5f05 x48cc0c3eaf9f5f6 = new x48cc0c3eaf9f5f05(x6fa2570084b2ad39[0], x6fa2570084b2ad39[1]);
		if (xd368f5b253dc8875.X < (x3c12013af6b066fd ? x6fa2570084b2ad39[0].X : x6fa2570084b2ad39[1].X))
		{
			num3 *= -1f;
		}
		PointF[] array = new PointF[1] { PointF.Empty };
		x48cc0c3eaf9f5f6.x4a4f2059e53968cf(x3c12013af6b066fd ? x6fa2570084b2ad39[0] : x6fa2570084b2ad39[1], num3, array);
		return array[0];
	}

	private static bool xc883d0dad69e9e05(x60c040f35bb272aa x0861076177854fb1, x67293147609631f8[] x51efd71b3cdcbf9c, bool x3c12013af6b066fd, PointF[] x6fa2570084b2ad39, ArrayList x90544e263812bc87)
	{
		bool flag = false;
		int num = ((!x3c12013af6b066fd) ? (x51efd71b3cdcbf9c.Length - 1) : 0);
		while (x3c12013af6b066fd ? (num < x51efd71b3cdcbf9c.Length) : (num > -1))
		{
			x67293147609631f8 x67293147609631f = x51efd71b3cdcbf9c[num];
			x6a17e4a87b609da7 x6a17e4a87b609da8 = x985162806d1f6faa(x6fa2570084b2ad39[0], x6fa2570084b2ad39[1], x67293147609631f);
			if (x6a17e4a87b609da8.x6e93b8ed0215d172)
			{
				x67293147609631f = x45f510e35e56fcfd(x3c12013af6b066fd, x67293147609631f, x6a17e4a87b609da8, x0861076177854fb1);
				flag = true;
			}
			x90544e263812bc87.Add(x67293147609631f);
			if (flag)
			{
				break;
			}
			num = ((!x3c12013af6b066fd) ? (num - 1) : (num + 1));
		}
		return flag;
	}

	private static x67293147609631f8 x45f510e35e56fcfd(bool x3c12013af6b066fd, x67293147609631f8 xb4b05b124e47bc0f, x6a17e4a87b609da7 x68465d6e49167f2a, x60c040f35bb272aa x0861076177854fb1)
	{
		if (x3c12013af6b066fd)
		{
			x0861076177854fb1.x4d7474e8f1849803[0] = x68465d6e49167f2a.xa3fcbdd38f2ce050[0];
		}
		else
		{
			x0861076177854fb1.x4d7474e8f1849803[x0861076177854fb1.x4d7474e8f1849803.Count - 1] = x68465d6e49167f2a.xa3fcbdd38f2ce050[0];
		}
		x67293147609631f8[] array = x356a1aee81fb019c(xb4b05b124e47bc0f, x68465d6e49167f2a.xfd40c4e850df5469[0]);
		xb4b05b124e47bc0f = ((!x3c12013af6b066fd) ? ((array.Length > 1) ? array[1] : array[0]) : array[0]);
		return xb4b05b124e47bc0f;
	}

	internal static x782108ccba597138 x0a09fa2690680f34(x67293147609631f8[] x119a4bc486ae9d03, x67293147609631f8[] xe798aaaf2fbc9c63, bool x85542bc98c560fba)
	{
		x782108ccba597138 x782108ccba597139 = new x782108ccba597138();
		x782108ccba597139.x301bd5096298138a = x85542bc98c560fba;
		x782108ccba597139.x9714425dc22d7dee = !x85542bc98c560fba;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		bool flag = x47b7be8a8cb0c578(x119a4bc486ae9d03, xe798aaaf2fbc9c63, arrayList, arrayList2, x85542bc98c560fba);
		x782108ccba597139.xe320f2f577e6ced9 = (x67293147609631f8[])arrayList.ToArray(typeof(x67293147609631f8));
		x782108ccba597139.x9cd2d8ec0df9c7c1 = (x67293147609631f8[])arrayList2.ToArray(typeof(x67293147609631f8));
		if (!flag)
		{
			x56bef2c59f36f247(x119a4bc486ae9d03, xe798aaaf2fbc9c63, x85542bc98c560fba, x782108ccba597139);
		}
		return x782108ccba597139;
	}

	private static void x56bef2c59f36f247(x67293147609631f8[] x119a4bc486ae9d03, x67293147609631f8[] xe798aaaf2fbc9c63, bool x85542bc98c560fba, x782108ccba597138 xe9627bbd2316c800)
	{
		PointF[] array = new PointF[1] { PointF.Empty };
		float x274503c7c54fac3a = x37d2d88f96f87b47.x5af88e61b614ce62(x85542bc98c560fba ? x119a4bc486ae9d03[0].xaf4e0fbe61814cf5 : x119a4bc486ae9d03[^1].x2271dea312f4a835, (!x85542bc98c560fba) ? xe798aaaf2fbc9c63[0].xaf4e0fbe61814cf5 : xe798aaaf2fbc9c63[^1].x2271dea312f4a835);
		if (!x37d2d88f96f87b47.xe1aec5445964a68c(x274503c7c54fac3a, 0f))
		{
			x48cc0c3eaf9f5f05 x7f5704d71690aff = x94f374e133349f4d(x119a4bc486ae9d03, x85542bc98c560fba);
			x48cc0c3eaf9f5f05 xef563966899b6b = x94f374e133349f4d(xe798aaaf2fbc9c63, !x85542bc98c560fba);
			x48cc0c3eaf9f5f05.x07aa36934bec95f1(x7f5704d71690aff, xef563966899b6b, array);
		}
		if (array[0] != PointF.Empty)
		{
			xe9627bbd2316c800.x43e7db181a6b7a7e = true;
			xe9627bbd2316c800.xe0124b8a28cdb2f5 = array[0];
		}
	}

	private static x48cc0c3eaf9f5f05 x94f374e133349f4d(x67293147609631f8[] x51efd71b3cdcbf9c, bool xdf036717650cd5b5)
	{
		if (!xdf036717650cd5b5)
		{
			return new x48cc0c3eaf9f5f05(x51efd71b3cdcbf9c[^1].x2271dea312f4a835, x51efd71b3cdcbf9c[^1].x2f997a78d547d657);
		}
		return new x48cc0c3eaf9f5f05(x51efd71b3cdcbf9c[0].x2f997a78d547d657, x51efd71b3cdcbf9c[0].xaf4e0fbe61814cf5);
	}

	private static bool x47b7be8a8cb0c578(x67293147609631f8[] x119a4bc486ae9d03, x67293147609631f8[] xe798aaaf2fbc9c63, ArrayList xf4405994cf4d16ce, ArrayList x0e915d2683488180, bool x85542bc98c560fba)
	{
		bool flag = false;
		int num = (x85542bc98c560fba ? (x119a4bc486ae9d03.Length - 1) : 0);
		while (x85542bc98c560fba ? (num > -1) : (num < x119a4bc486ae9d03.Length))
		{
			x67293147609631f8 x27a28247e50a4cec = x119a4bc486ae9d03[num];
			x0e915d2683488180.Clear();
			x9658c5adb216d1cb x9658c5adb216d1cb2 = x9658c5adb216d1cb.x43e7db181a6b7a7e();
			x27a28247e50a4cec = xdd4f48b18196323b(x27a28247e50a4cec, xe798aaaf2fbc9c63, x0e915d2683488180, x85542bc98c560fba, x9658c5adb216d1cb2);
			flag = x9658c5adb216d1cb2.x6e93b8ed0215d172;
			xf4405994cf4d16ce.Add(x27a28247e50a4cec);
			if (flag)
			{
				break;
			}
			num = ((!x85542bc98c560fba) ? (num + 1) : (num - 1));
		}
		return flag;
	}

	private static x67293147609631f8 xdd4f48b18196323b(x67293147609631f8 x27a28247e50a4cec, x67293147609631f8[] xe798aaaf2fbc9c63, ArrayList x0e915d2683488180, bool x85542bc98c560fba, x9658c5adb216d1cb x7d95d971d8923f4c)
	{
		int num = ((!x85542bc98c560fba) ? (xe798aaaf2fbc9c63.Length - 1) : 0);
		while ((!x85542bc98c560fba) ? (num > -1) : (num < xe798aaaf2fbc9c63.Length))
		{
			x67293147609631f8 x67293147609631f = xe798aaaf2fbc9c63[num];
			x9658c5adb216d1cb x9658c5adb216d1cb2 = x6cd7f82cf135b0d7(x27a28247e50a4cec, x67293147609631f);
			if (x9658c5adb216d1cb2.x6e93b8ed0215d172)
			{
				x27a28247e50a4cec = xa68d9d49535479e3(x27a28247e50a4cec, x67293147609631f, x0e915d2683488180, x85542bc98c560fba, x9658c5adb216d1cb2);
				x7d95d971d8923f4c.x6e93b8ed0215d172 = true;
				break;
			}
			x0e915d2683488180.Add(x67293147609631f);
			num = (x85542bc98c560fba ? (num + 1) : (num - 1));
		}
		return x27a28247e50a4cec;
	}

	private static x67293147609631f8 xa68d9d49535479e3(x67293147609631f8 x27a28247e50a4cec, x67293147609631f8 x49a00f8c05254d7b, ArrayList x0e915d2683488180, bool x85542bc98c560fba, x9658c5adb216d1cb x7d95d971d8923f4c)
	{
		float num = float.MinValue;
		int num2 = 0;
		for (int i = 0; i < x7d95d971d8923f4c.x8a261cc1dcc8df70.Length; i++)
		{
			if ((x85542bc98c560fba && x7d95d971d8923f4c.x8a261cc1dcc8df70[i] > num) || (!x85542bc98c560fba && x7d95d971d8923f4c.x8a261cc1dcc8df70[i] <= num))
			{
				num = x7d95d971d8923f4c.x8a261cc1dcc8df70[i];
				num2 = i;
			}
		}
		float x3201d6d15a = x7d95d971d8923f4c.x8a261cc1dcc8df70[num2];
		float x3201d6d15a2 = x7d95d971d8923f4c.x0588143eef5e79ed[num2];
		x67293147609631f8[] array = x356a1aee81fb019c(x27a28247e50a4cec, x3201d6d15a);
		x67293147609631f8[] array2 = x356a1aee81fb019c(x49a00f8c05254d7b, x3201d6d15a2);
		if (!x85542bc98c560fba)
		{
			x27a28247e50a4cec = array[0];
			x49a00f8c05254d7b = ((array2.Length > 1) ? array2[1] : array2[0]);
		}
		else
		{
			x27a28247e50a4cec = ((array.Length > 1) ? array[1] : array[0]);
			x49a00f8c05254d7b = array2[0];
		}
		x0e915d2683488180.Add(x49a00f8c05254d7b);
		return x27a28247e50a4cec;
	}

	internal static void x682dd48c960b2fce(x67293147609631f8[] x011027fdb46be048)
	{
		if (x011027fdb46be048.Length < 2)
		{
			return;
		}
		for (int i = 0; i < x011027fdb46be048.Length - 1; i++)
		{
			x9658c5adb216d1cb x9658c5adb216d1cb2 = x6cd7f82cf135b0d7(x011027fdb46be048[i], x011027fdb46be048[i + 1]);
			if (x9658c5adb216d1cb2.x6e93b8ed0215d172)
			{
				x67293147609631f8[] array = x356a1aee81fb019c(x011027fdb46be048[i], x9658c5adb216d1cb2.x8a261cc1dcc8df70[0]);
				ref x67293147609631f8 reference = ref x011027fdb46be048[i];
				reference = array[0];
				array = x356a1aee81fb019c(x011027fdb46be048[i + 1], x9658c5adb216d1cb2.x0588143eef5e79ed[0]);
				ref x67293147609631f8 reference2 = ref x011027fdb46be048[i + 1];
				reference2 = ((array.Length > 1) ? array[1] : array[0]);
			}
			x011027fdb46be048[i].x2271dea312f4a835 = x011027fdb46be048[i + 1].xaf4e0fbe61814cf5;
		}
	}

	private static x9658c5adb216d1cb x6cd7f82cf135b0d7(x67293147609631f8 x27a28247e50a4cec, x67293147609631f8 x49a00f8c05254d7b)
	{
		ArrayList arrayList = new ArrayList();
		x05426b792478523c x05426b792478523c = new x05426b792478523c();
		x05426b792478523c x05426b792478523c2 = new x05426b792478523c();
		xe91453d7ce8ee689 x40c1be1d37eae = new xe91453d7ce8ee689(x27a28247e50a4cec);
		xe91453d7ce8ee689 x0092995e00271a = new xe91453d7ce8ee689(x49a00f8c05254d7b);
		xcf958695dce855f9(x40c1be1d37eae, x0092995e00271a, arrayList, x05426b792478523c);
		x1b728d8c7b6d96bc(x40c1be1d37eae, x0092995e00271a, x05426b792478523c, x05426b792478523c2);
		if (x05426b792478523c.Count == 0)
		{
			return x9658c5adb216d1cb.x43e7db181a6b7a7e();
		}
		return new x9658c5adb216d1cb(intersect: true, x05426b792478523c.Count, x05426b792478523c2.ToArray(), x05426b792478523c.ToArray(), (PointF[])arrayList.ToArray(typeof(PointF)));
	}

	private static void x1b728d8c7b6d96bc(xe91453d7ce8ee689 x40c1be1d37eae041, xe91453d7ce8ee689 x0092995e00271a37, x05426b792478523c x6758bde6d4c21c9c, x05426b792478523c x3a6b23db925323ae)
	{
		PointF x1553750ef11ea3bd = x40c1be1d37eae041.x1553750ef11ea3bd;
		PointF x6327cc1340abe = x40c1be1d37eae041.x6327cc1340abe864;
		PointF x57b4a37fc3a75e2d = x40c1be1d37eae041.x57b4a37fc3a75e2d;
		PointF x1553750ef11ea3bd2 = x0092995e00271a37.x1553750ef11ea3bd;
		PointF x6327cc1340abe2 = x0092995e00271a37.x6327cc1340abe864;
		PointF x57b4a37fc3a75e2d2 = x0092995e00271a37.x57b4a37fc3a75e2d;
		for (int i = 0; i < x6758bde6d4c21c9c.Count; i++)
		{
			float num = x6758bde6d4c21c9c[i];
			double[] array = new xed704ccd900d004b(0f - x1553750ef11ea3bd.X, 0f - x6327cc1340abe.X, 0f - x57b4a37fc3a75e2d.X + x57b4a37fc3a75e2d2.X + x6327cc1340abe2.X * num + x1553750ef11ea3bd2.X * num * num).x4869b1f82941a468();
			for (int j = 0; j < array.Length; j++)
			{
				float num2 = (float)array[j];
				if (!(num2 < 0f) && !(num2 > 1f))
				{
					x3a6b23db925323ae.Add(num2);
					break;
				}
			}
		}
	}

	private static void xcf958695dce855f9(xe91453d7ce8ee689 x40c1be1d37eae041, xe91453d7ce8ee689 x0092995e00271a37, ArrayList x7d95d971d8923f4c, x05426b792478523c x6758bde6d4c21c9c)
	{
		PointF x1553750ef11ea3bd = x40c1be1d37eae041.x1553750ef11ea3bd;
		PointF x6327cc1340abe = x40c1be1d37eae041.x6327cc1340abe864;
		PointF x57b4a37fc3a75e2d = x40c1be1d37eae041.x57b4a37fc3a75e2d;
		PointF x1553750ef11ea3bd2 = x0092995e00271a37.x1553750ef11ea3bd;
		PointF x6327cc1340abe2 = x0092995e00271a37.x6327cc1340abe864;
		PointF x57b4a37fc3a75e2d2 = x0092995e00271a37.x57b4a37fc3a75e2d;
		double num = x1553750ef11ea3bd.X * x6327cc1340abe.Y - x6327cc1340abe.X * x1553750ef11ea3bd.Y;
		double num2 = x1553750ef11ea3bd2.X * x6327cc1340abe.Y - x6327cc1340abe.X * x1553750ef11ea3bd2.Y;
		double num3 = x6327cc1340abe2.X * x6327cc1340abe.Y - x6327cc1340abe.X * x6327cc1340abe2.Y;
		double num4 = x6327cc1340abe.X * (x57b4a37fc3a75e2d.Y - x57b4a37fc3a75e2d2.Y) + x6327cc1340abe.Y * (0f - x57b4a37fc3a75e2d.X + x57b4a37fc3a75e2d2.X);
		double num5 = x1553750ef11ea3bd2.X * x1553750ef11ea3bd.Y - x1553750ef11ea3bd.X * x1553750ef11ea3bd2.Y;
		double num6 = x6327cc1340abe2.X * x1553750ef11ea3bd.Y - x1553750ef11ea3bd.X * x6327cc1340abe2.Y;
		double num7 = x1553750ef11ea3bd.X * (x57b4a37fc3a75e2d.Y - x57b4a37fc3a75e2d2.Y) + x1553750ef11ea3bd.Y * (0f - x57b4a37fc3a75e2d.X + x57b4a37fc3a75e2d2.X);
		xed704ccd900d004b xed704ccd900d004b2 = new xed704ccd900d004b((0.0 - num5) * num5, -2.0 * num5 * num6, num * num2 - num6 * num6 - 2.0 * num5 * num7, num * num3 - 2.0 * num6 * num7, num * num4 - num7 * num7);
		double[] x698325e0a07dd = xed704ccd900d004b2.x4869b1f82941a468();
		x40ab79c47d6bbed9(x40c1be1d37eae041, x0092995e00271a37, x698325e0a07dd, x7d95d971d8923f4c, x6758bde6d4c21c9c);
	}

	private static void x40ab79c47d6bbed9(xe91453d7ce8ee689 x40c1be1d37eae041, xe91453d7ce8ee689 x0092995e00271a37, double[] x698325e0a07dd969, ArrayList x7d95d971d8923f4c, x05426b792478523c x6758bde6d4c21c9c)
	{
		PointF x1553750ef11ea3bd = x40c1be1d37eae041.x1553750ef11ea3bd;
		PointF x6327cc1340abe = x40c1be1d37eae041.x6327cc1340abe864;
		PointF x57b4a37fc3a75e2d = x40c1be1d37eae041.x57b4a37fc3a75e2d;
		PointF x1553750ef11ea3bd2 = x0092995e00271a37.x1553750ef11ea3bd;
		PointF x6327cc1340abe2 = x0092995e00271a37.x6327cc1340abe864;
		PointF x57b4a37fc3a75e2d2 = x0092995e00271a37.x57b4a37fc3a75e2d;
		foreach (double num in x698325e0a07dd969)
		{
			if (num < 0.0 || num > 1.0)
			{
				continue;
			}
			double[] array = new xed704ccd900d004b(0f - x1553750ef11ea3bd.X, 0f - x6327cc1340abe.X, (double)(0f - x57b4a37fc3a75e2d.X + x57b4a37fc3a75e2d2.X) + num * (double)x6327cc1340abe2.X + num * num * (double)x1553750ef11ea3bd2.X).x4869b1f82941a468();
			double[] array2 = new xed704ccd900d004b(0f - x1553750ef11ea3bd.Y, 0f - x6327cc1340abe.Y, (double)(0f - x57b4a37fc3a75e2d.Y + x57b4a37fc3a75e2d2.Y) + num * (double)x6327cc1340abe2.Y + num * num * (double)x1553750ef11ea3bd2.Y).x4869b1f82941a468();
			if (array.Length > 0 && array2.Length > 0)
			{
				for (int j = 0; j < array.Length && !xdad58bdbd7a97dde(x0092995e00271a37, array[j], array2, x7d95d971d8923f4c, x6758bde6d4c21c9c, num); j++)
				{
				}
			}
		}
	}

	private static bool xdad58bdbd7a97dde(xe91453d7ce8ee689 x0092995e00271a37, double xdea4a27b5a016b77, double[] x5644514387fe8e7b, ArrayList x7d95d971d8923f4c, x05426b792478523c x6758bde6d4c21c9c, double xe4115acdf4fbfccc)
	{
		if (0.0 > xdea4a27b5a016b77 || xdea4a27b5a016b77 > 1.0)
		{
			return false;
		}
		PointF x1553750ef11ea3bd = x0092995e00271a37.x1553750ef11ea3bd;
		PointF x6327cc1340abe = x0092995e00271a37.x6327cc1340abe864;
		PointF x57b4a37fc3a75e2d = x0092995e00271a37.x57b4a37fc3a75e2d;
		bool result = false;
		for (int i = 0; i < x5644514387fe8e7b.Length; i++)
		{
			if (!(Math.Abs(xdea4a27b5a016b77 - x5644514387fe8e7b[i]) >= 0.0001))
			{
				float x = (float)((double)x1553750ef11ea3bd.X * xe4115acdf4fbfccc * xe4115acdf4fbfccc + (double)x6327cc1340abe.X * xe4115acdf4fbfccc + (double)x57b4a37fc3a75e2d.X);
				float y = (float)((double)x1553750ef11ea3bd.Y * xe4115acdf4fbfccc * xe4115acdf4fbfccc + (double)x6327cc1340abe.Y * xe4115acdf4fbfccc + (double)x57b4a37fc3a75e2d.Y);
				x7d95d971d8923f4c.Add(new PointF(x, y));
				x6758bde6d4c21c9c.Add((float)xe4115acdf4fbfccc);
				result = true;
				break;
			}
		}
		return result;
	}

	private static x6a17e4a87b609da7 x985162806d1f6faa(PointF x5b7969c220651942, PointF x42c063e3af99e3ae, x67293147609631f8 xb4b05b124e47bc0f)
	{
		xe91453d7ce8ee689 x04c4d4e44b = new xe91453d7ce8ee689(xb4b05b124e47bc0f);
		bool xf044dc404ee = x37d2d88f96f87b47.xe1aec5445964a68c(x42c063e3af99e3ae.Y, x5b7969c220651942.Y);
		double[] x698325e0a07dd = x5d7a6aed84bb7bab(x5b7969c220651942, x42c063e3af99e3ae, x04c4d4e44b, xf044dc404ee);
		return x72b68e0260215a55(x5b7969c220651942, x42c063e3af99e3ae, x04c4d4e44b, x698325e0a07dd, xf044dc404ee);
	}

	private static double[] x5d7a6aed84bb7bab(PointF x5b7969c220651942, PointF x42c063e3af99e3ae, xe91453d7ce8ee689 x04c4d4e44b164791, bool xf044dc404ee85142)
	{
		if (xf044dc404ee85142)
		{
			return new xed704ccd900d004b(x04c4d4e44b164791.x1553750ef11ea3bd.Y, x04c4d4e44b164791.x6327cc1340abe864.Y, x04c4d4e44b164791.x57b4a37fc3a75e2d.Y - x5b7969c220651942.Y).x4869b1f82941a468();
		}
		float num = (x42c063e3af99e3ae.X - x5b7969c220651942.X) / (x42c063e3af99e3ae.Y - x5b7969c220651942.Y);
		return new xed704ccd900d004b(num * x04c4d4e44b164791.x1553750ef11ea3bd.Y - x04c4d4e44b164791.x1553750ef11ea3bd.X, num * x04c4d4e44b164791.x6327cc1340abe864.Y - x04c4d4e44b164791.x6327cc1340abe864.X, num * x04c4d4e44b164791.x57b4a37fc3a75e2d.Y - num * x5b7969c220651942.Y + x5b7969c220651942.X - x04c4d4e44b164791.x57b4a37fc3a75e2d.X).x4869b1f82941a468();
	}

	private static x6a17e4a87b609da7 x72b68e0260215a55(PointF x5b7969c220651942, PointF x42c063e3af99e3ae, xe91453d7ce8ee689 x04c4d4e44b164791, double[] x698325e0a07dd969, bool xf044dc404ee85142)
	{
		int num = x698325e0a07dd969.Length;
		if (num == 0)
		{
			return x6a17e4a87b609da7.x43e7db181a6b7a7e();
		}
		bool firstOnSegmentLine = false;
		bool secondOnSegmentLine = false;
		int num2 = 0;
		PointF[] array = new PointF[2]
		{
			PointF.Empty,
			PointF.Empty
		};
		float[] array2 = new float[2];
		for (int i = 0; i < num; i++)
		{
			float num3 = (float)x698325e0a07dd969[i];
			if (!(num3 < 0f) && !(num3 > 1f))
			{
				num2++;
				array2[num2 - 1] = num3;
				float num4 = xe693497a08361a4b(num3, x5b7969c220651942, x42c063e3af99e3ae, x04c4d4e44b164791, xf044dc404ee85142);
				bool flag = num4 > 0f || num4 < 1f;
				if (num2 == 1)
				{
					firstOnSegmentLine = flag;
				}
				else
				{
					secondOnSegmentLine = flag;
				}
				ref PointF reference = ref array[num2 - 1];
				reference = x04c4d4e44b164791.x4e38d47a828e5204(num3);
			}
		}
		if (num2 == 0)
		{
			return x6a17e4a87b609da7.x43e7db181a6b7a7e();
		}
		return new x6a17e4a87b609da7(intersect: true, firstOnSegmentLine, secondOnSegmentLine, num2, array, array2);
	}

	private static float xe693497a08361a4b(float xc301afa072787492, PointF x5b7969c220651942, PointF x42c063e3af99e3ae, xe91453d7ce8ee689 x04c4d4e44b164791, bool x8a45f1122e39b31b)
	{
		float num = (x8a45f1122e39b31b ? x42c063e3af99e3ae.X : x42c063e3af99e3ae.Y);
		float num2 = (x8a45f1122e39b31b ? x5b7969c220651942.X : x5b7969c220651942.Y);
		PointF pointF = x04c4d4e44b164791.x4e38d47a828e5204(xc301afa072787492);
		return (x8a45f1122e39b31b ? pointF.X : (pointF.Y - num2)) / (num - num2);
	}

	private static x67293147609631f8[] x356a1aee81fb019c(x67293147609631f8 x337e217cb3ba0627, float x3201d6d15a947682)
	{
		if (x3201d6d15a947682 < 0f || x3201d6d15a947682 > 1f)
		{
			return null;
		}
		if (x3201d6d15a947682 == 0f || x3201d6d15a947682 == 1f)
		{
			return new x67293147609631f8[1] { x337e217cb3ba0627 };
		}
		x48cc0c3eaf9f5f05 x311e7a92306d = new x48cc0c3eaf9f5f05(x337e217cb3ba0627.xaf4e0fbe61814cf5, x337e217cb3ba0627.x2f997a78d547d657);
		x48cc0c3eaf9f5f05 x311e7a92306d2 = new x48cc0c3eaf9f5f05(x337e217cb3ba0627.x2f997a78d547d657, x337e217cb3ba0627.x2271dea312f4a835);
		float xf7b90603456caad = x37d2d88f96f87b47.x5af88e61b614ce62(x337e217cb3ba0627.xaf4e0fbe61814cf5, x337e217cb3ba0627.x2f997a78d547d657);
		float xf7b90603456caad2 = x37d2d88f96f87b47.x5af88e61b614ce62(x337e217cb3ba0627.x2f997a78d547d657, x337e217cb3ba0627.x2271dea312f4a835);
		PointF xb87b7305ef2b = x5bee5280de3b9221(x311e7a92306d, x337e217cb3ba0627, x3201d6d15a947682, xf7b90603456caad, x761b632b6ce0028f: true);
		PointF xb87b7305ef2b2 = x5bee5280de3b9221(x311e7a92306d2, x337e217cb3ba0627, x3201d6d15a947682, xf7b90603456caad2, x761b632b6ce0028f: false);
		xe91453d7ce8ee689 xe91453d7ce8ee690 = new xe91453d7ce8ee689(x337e217cb3ba0627);
		PointF pointF = xe91453d7ce8ee690.x4e38d47a828e5204(x3201d6d15a947682);
		x67293147609631f8 x67293147609631f = xc7ced42ce3e22331(x337e217cb3ba0627.xaf4e0fbe61814cf5, xb87b7305ef2b, pointF);
		x67293147609631f8 x67293147609631f2 = xc7ced42ce3e22331(pointF, xb87b7305ef2b2, x337e217cb3ba0627.x2271dea312f4a835);
		return new x67293147609631f8[2] { x67293147609631f, x67293147609631f2 };
	}

	private static x67293147609631f8 xc7ced42ce3e22331(PointF xcb09bd0cee4909a3, PointF xb87b7305ef2b2389, PointF xa2da454aa40879d2)
	{
		x67293147609631f8 result = default(x67293147609631f8);
		result.xaf4e0fbe61814cf5 = xcb09bd0cee4909a3;
		result.x2f997a78d547d657 = xb87b7305ef2b2389;
		result.x2271dea312f4a835 = xa2da454aa40879d2;
		return result;
	}

	private static PointF x5bee5280de3b9221(x48cc0c3eaf9f5f05 x311e7a92306d7199, x67293147609631f8 xb4b05b124e47bc0f, float x3201d6d15a947682, float xf7b90603456caad3, bool x761b632b6ce0028f)
	{
		bool flag = ((x311e7a92306d7199.x73539c44b735b7aa != 0f || x311e7a92306d7199.x4d29b8b35306c675) ? (x761b632b6ce0028f ? (xb4b05b124e47bc0f.x2f997a78d547d657.Y > xb4b05b124e47bc0f.xaf4e0fbe61814cf5.Y) : (xb4b05b124e47bc0f.x2271dea312f4a835.Y > xb4b05b124e47bc0f.x2f997a78d547d657.Y)) : (x761b632b6ce0028f ? (xb4b05b124e47bc0f.x2f997a78d547d657.X > xb4b05b124e47bc0f.xaf4e0fbe61814cf5.X) : (xb4b05b124e47bc0f.x2271dea312f4a835.X > xb4b05b124e47bc0f.x2f997a78d547d657.X)));
		PointF[] array = new PointF[1] { PointF.Empty };
		float num = -1f;
		if (flag)
		{
			num = 1f;
		}
		x311e7a92306d7199.x4a4f2059e53968cf(x761b632b6ce0028f ? xb4b05b124e47bc0f.xaf4e0fbe61814cf5 : xb4b05b124e47bc0f.x2f997a78d547d657, num * x3201d6d15a947682 * xf7b90603456caad3, array);
		return array[0];
	}
}
