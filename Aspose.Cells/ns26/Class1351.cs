using Aspose.Cells;

namespace ns26;

internal class Class1351
{
	internal string string_0;

	internal string string_1;

	internal bool bool_0;

	internal bool bool_1;

	internal string[] string_2;

	internal string[] string_3;

	internal string[] string_4;

	internal string[] string_5;

	internal void method_0(PageSetup pageSetup_0, Class1489 class1489_0)
	{
		if (string_1 == null)
		{
			string_1 = "Default";
		}
		Class1099 @class = (Class1099)class1489_0.class1350_0.hashtable_0[string_1];
		@class.method_1(pageSetup_0);
		if (string_2 != null)
		{
			for (int i = 0; i < string_2.Length; i++)
			{
				if (string_2[i] != null && string_2[i].Length != 0)
				{
					pageSetup_0.SetHeader(i, string_2[i]);
				}
			}
		}
		if (string_3 != null)
		{
			for (int j = 0; j < string_3.Length; j++)
			{
				if (string_3[j] != null && string_3[j].Length != 0)
				{
					pageSetup_0.SetFooter(j, string_3[j]);
				}
			}
		}
		if (!bool_0 || !bool_1)
		{
			return;
		}
		pageSetup_0.IsHFDiffOddEven = true;
		if (string_4 != null)
		{
			for (int k = 0; k < string_4.Length; k++)
			{
				if (string_4[k] != null && string_4[k].Length != 0)
				{
					pageSetup_0.SetEvenHeader(k, string_4[k]);
				}
			}
		}
		if (string_5 == null)
		{
			return;
		}
		for (int l = 0; l < string_5.Length; l++)
		{
			if (string_5[l] != null && string_5[l].Length != 0)
			{
				pageSetup_0.SetEvenFooter(l, string_5[l]);
			}
		}
	}
}
