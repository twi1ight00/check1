using System.Globalization;
using System.Text.RegularExpressions;
using ns183;

namespace ns209;

internal class Class5478
{
	private Class5478()
	{
	}

	public static int[] smethod_0(string baseString, string separatorPattern)
	{
		if (string.IsNullOrEmpty(baseString))
		{
			return null;
		}
		if (string.IsNullOrEmpty(separatorPattern))
		{
			return new int[1] { int.Parse(baseString) };
		}
		string[] array = Regex.Split(baseString, separatorPattern);
		int num = array.Length;
		if (num == 0)
		{
			return null;
		}
		int[] array2 = new int[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = int.Parse(array[i]);
		}
		return array2;
	}

	public static double[] smethod_1(string baseString, string separatorPattern)
	{
		if (string.IsNullOrEmpty(baseString))
		{
			return null;
		}
		if (string.IsNullOrEmpty(separatorPattern))
		{
			return new double[1] { double.Parse(baseString, NumberStyles.Any, Class4985.smethod_0().Ci) };
		}
		string[] array = Regex.Split(baseString, separatorPattern);
		int num = array.Length;
		if (num == 0)
		{
			return null;
		}
		double[] array2 = new double[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = double.Parse(array[i], NumberStyles.Any, Class4985.smethod_0().Ci);
		}
		return array2;
	}
}
