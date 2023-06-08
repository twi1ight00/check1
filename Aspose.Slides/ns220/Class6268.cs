using System;
using System.Globalization;
using System.Text;
using ns235;

namespace ns220;

internal class Class6268 : Class6265.Class6267
{
	private static CultureInfo cultureInfo_0 = new CultureInfo("en-us");

	internal Class6268(Class6265 indices)
		: base(indices)
	{
	}

	private static string smethod_0(float val, float fontSize)
	{
		return Math.Round(val * 100f / fontSize, 4).ToString("R", cultureInfo_0);
	}

	internal string method_5(float fontSize)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < method_0(); i++)
		{
			method_4(i);
			float num = method_1(i);
			float num2 = method_2(i);
			float num3 = method_3(i);
			if (num != -1f)
			{
				stringBuilder.Append("," + smethod_0(num, fontSize));
			}
			else if (num2 != 0f || num3 != 0f)
			{
				stringBuilder.Append(",");
			}
			if (num2 != 0f)
			{
				stringBuilder.Append("," + smethod_0(num2, fontSize));
			}
			else if (num3 != 0f)
			{
				stringBuilder.Append(",");
			}
			if (num3 != 0f)
			{
				stringBuilder.Append("," + smethod_0(num3, fontSize));
			}
			stringBuilder.Append(";");
		}
		return stringBuilder.ToString().TrimEnd(';');
	}
}
