using System;
using Aspose.Cells;
using ns14;

namespace ns2;

internal class Class1345
{
	public static Class530 smethod_0(string string_0, WorkbookSettings workbookSettings_0)
	{
		Class512 @class = workbookSettings_0.method_3().method_6();
		object obj = @class.ParseObject(string_0);
		if (obj != null)
		{
			return @class.method_0();
		}
		Class513 class2 = workbookSettings_0.method_3().method_7();
		obj = class2.ParseObject(string_0);
		if (obj != null)
		{
			if (CellsHelper.GetDoubleFromDateTime((DateTime)obj, workbookSettings_0.Date1904) < 0.0)
			{
				return null;
			}
			return class2.method_0();
		}
		return null;
	}

	public static Class518 Format(object object_0, string string_0, WorkbookSettings workbookSettings_0)
	{
		return workbookSettings_0.method_3().Format(string_0, object_0, bool_1: false);
	}

	internal static string smethod_1(string string_0, WorkbookSettings workbookSettings_0)
	{
		if (workbookSettings_0.method_3().method_4().method_12())
		{
			return string_0;
		}
		char c = workbookSettings_0.method_3().method_4().method_2();
		char c2 = workbookSettings_0.method_3().method_4().method_3();
		char[] array = string_0.ToCharArray();
		int num = 0;
		bool flag = false;
		while (num < array.Length)
		{
			if (array[num] == c)
			{
				array[num] = '.';
				flag = true;
			}
			else
			{
				if (array[num] != c2)
				{
					num = Class487.smethod_1(array, num, array.Length);
					continue;
				}
				array[num] = ',';
				flag = true;
			}
			num++;
		}
		if (flag)
		{
			return new string(array);
		}
		return string_0;
	}

	internal static string smethod_2(string string_0, WorkbookSettings workbookSettings_0)
	{
		if (workbookSettings_0.method_3().method_4().method_12())
		{
			return string_0;
		}
		char c = workbookSettings_0.method_3().method_4().method_2();
		char c2 = workbookSettings_0.method_3().method_4().method_3();
		char[] array = string_0.ToCharArray();
		int num = 0;
		bool flag = false;
		while (num < array.Length)
		{
			if (array[num] == '.')
			{
				array[num] = c;
				flag = true;
			}
			else
			{
				if (array[num] != ';')
				{
					num = Class487.smethod_1(array, num, array.Length);
					continue;
				}
				array[num] = c2;
				flag = true;
			}
			num++;
		}
		if (flag)
		{
			return new string(array);
		}
		return string_0;
	}
}
