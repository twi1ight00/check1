using System.Text;
using xb1090543d168d647;

namespace x4adf554d20d941a6;

internal class x5a30de40811ce006
{
	internal static void x6a00974ede739608(x56410a8dd70087c5[] x6d394cddc56557db)
	{
		x6ec39b1b0c66f918[] xdcff38cbdd9cf = new x3e00076e2193f813(x25fef619676abd4c(x6d394cddc56557db)).xdcff38cbdd9cf395;
		int num = 0;
		int num2 = xdcff38cbdd9cf[num].xf9ad6fb78355fe13.Length;
		foreach (x56410a8dd70087c5 x56410a8dd70087c6 in x6d394cddc56557db)
		{
			int num3 = ((x56410a8dd70087c6.xf9ad6fb78355fe13 != null) ? x56410a8dd70087c6.xf9ad6fb78355fe13.Length : 0);
			if (num3 > 0 && num3 <= num2)
			{
				x56410a8dd70087c6.x3a03159a374ab4fd = (xdcff38cbdd9cf[num].x0b228ef3d2b6a257 ? 1 : 0);
				num2 -= num3;
			}
			if (num2 <= 0)
			{
				num++;
				if (xdcff38cbdd9cf.Length > num)
				{
					num2 = xdcff38cbdd9cf[num].xf9ad6fb78355fe13.Length;
				}
			}
		}
	}

	private static string x25fef619676abd4c(x56410a8dd70087c5[] x6d394cddc56557db)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (x56410a8dd70087c5 x56410a8dd70087c6 in x6d394cddc56557db)
		{
			stringBuilder.Append(x56410a8dd70087c6.xf9ad6fb78355fe13);
		}
		return stringBuilder.ToString();
	}
}
