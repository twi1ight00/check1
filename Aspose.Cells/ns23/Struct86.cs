using System;
using System.Runtime.InteropServices;
using ns7;

namespace ns23;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct86
{
	internal static void Sort(float[] float_0)
	{
		int num = float_0.Length;
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if (float_0[j] > float_0[num2])
				{
					num2 = j;
				}
			}
			float num3 = float_0[num2];
			float_0[num2] = float_0[i];
			float_0[i] = num3;
		}
	}

	internal static bool smethod_0(Class1310 class1310_0)
	{
		if (class1310_0.ToString() == "IsNumeric")
		{
			return true;
		}
		if (class1310_0.ToString() == "IsString")
		{
			return false;
		}
		if (class1310_0.ToString() == "IsNull")
		{
			return false;
		}
		return false;
	}

	internal static Enum21 smethod_1(Class1310[] class1310_0)
	{
		Enum21 result = Enum21.const_0;
		int num = class1310_0.Length;
		if (num <= 0)
		{
			return result;
		}
		int[] array = new int[num];
		Class1310 @class = null;
		for (int i = 0; i < num; i++)
		{
			@class = class1310_0[i];
			if (@class.ToString() == "IsString")
			{
				array[i] = 1;
			}
			else if (Convert.ToInt32(@class.object_0) >= 0)
			{
				array[i] = 1;
			}
			else
			{
				array[i] = 0;
			}
		}
		int num2 = array.Length;
		if (num2 > 0)
		{
			int num3 = 1;
			int num4 = 0;
			for (int j = 0; j < num2; j++)
			{
				num3 *= array[j];
			}
			if (num3 == 1)
			{
				result = Enum21.const_1;
			}
			for (int k = 0; k < num2; k++)
			{
				num4 += array[k];
			}
			if (num4 == 0)
			{
				result = Enum21.const_2;
			}
		}
		return result;
	}
}
