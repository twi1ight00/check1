using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns2;

namespace ns45;

internal class Class1159
{
	internal ConsolidationFunction consolidationFunction_0;

	internal PivotFieldDataDisplayFormat pivotFieldDataDisplayFormat_0;

	internal int int_0;

	internal int int_1;

	internal short short_0;

	internal string string_0;

	internal string string_1;

	internal PivotField pivotField_0;

	internal bool bool_0;

	internal string NumberFormat
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal string Name
	{
		get
		{
			if (bool_0)
			{
				return Class1130.smethod_8(consolidationFunction_0) + " of " + string_1;
			}
			return string_1;
		}
		set
		{
			string_1 = value;
			bool_0 = false;
		}
	}

	internal Class1159()
	{
	}

	internal Class1159(PivotField pivotField_1)
	{
		pivotField_0 = pivotField_1;
		bool_0 = true;
		if (pivotField_0.IsCalculatedField)
		{
			consolidationFunction_0 = ConsolidationFunction.Sum;
		}
		else if (pivotField_0.method_3())
		{
			consolidationFunction_0 = ConsolidationFunction.Sum;
		}
		else
		{
			consolidationFunction_0 = ConsolidationFunction.Count;
		}
		string_1 = pivotField_0.Name;
		string text = (Class1130.smethod_8(consolidationFunction_0) + " of " + string_1).ToLower();
		int length = text.Length;
		int num = 0;
		foreach (PivotField item in pivotField_0.pivotFieldCollection_0.arrayList_0)
		{
			string text2 = item.class1159_0.Name.ToLower();
			if (text2.Length < length || !text2.StartsWith(text))
			{
				continue;
			}
			if (text2.Length == length)
			{
				num = 1;
				continue;
			}
			bool flag = true;
			char[] array = text2.ToCharArray();
			for (int i = length; i < array.Length; i++)
			{
				if (array[i] < '0' || array[i] > '9')
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				int num2 = int.Parse(text2.Substring(length));
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		if (num != 0)
		{
			string_1 += num + 1;
		}
	}

	internal void Copy(Class1159 class1159_0)
	{
		consolidationFunction_0 = class1159_0.consolidationFunction_0;
		pivotFieldDataDisplayFormat_0 = class1159_0.pivotFieldDataDisplayFormat_0;
		int_0 = class1159_0.int_0;
		int_1 = class1159_0.int_1;
		short_0 = class1159_0.short_0;
		string_0 = class1159_0.NumberFormat;
		string_1 = class1159_0.string_1;
		bool_0 = class1159_0.bool_0;
	}
}
