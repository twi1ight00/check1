using System;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns12;

namespace ns29;

internal class Class775
{
	internal static Regex regex_0 = new Regex("\\[[=><]+\\S+\\]");

	internal static Regex regex_1 = new Regex("(\\S*)(\\[[=><]+\\S+\\])(\\S*)");

	public static string GetFormat(ref double double_0, string string_0)
	{
		string[] array = string_0.Split(';');
		if (array.Length == 1)
		{
			return string_0;
		}
		if (regex_0.IsMatch(string_0))
		{
			for (int i = 0; i < array.Length; i++)
			{
				Match match = regex_1.Match(array[i]);
				if (match.Success)
				{
					string value = match.Groups[2].Value;
					string result = match.Groups[1].Value + match.Groups[3].Value;
					object[] array2 = Class1662.smethod_6(value.Substring(1, value.Length - 2));
					double num = 0.0;
					if (array2[1] is double)
					{
						num = (double)array2[1];
					}
					else
					{
						if (!(array2[1] is DateTime))
						{
							continue;
						}
						num = CellsHelper.GetDoubleFromDateTime((DateTime)array2[1], date1904: false);
					}
					if (Class1662.smethod_4(double_0, num, (string)array2[0]))
					{
						if (num < 0.0)
						{
							double_0 = Math.Abs(double_0);
						}
						return result;
					}
					continue;
				}
				if (array[i].Equals(""))
				{
					return "\"\"";
				}
				return array[i];
			}
		}
		if (double_0 > 0.0)
		{
			return array[0];
		}
		if (double_0 < 0.0)
		{
			double_0 = Math.Abs(double_0);
			return array[1];
		}
		if (array.Length < 3)
		{
			return array[0];
		}
		return array[2];
	}
}
