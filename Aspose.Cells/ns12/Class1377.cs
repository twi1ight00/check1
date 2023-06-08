using System.Collections;
using System.Collections.Generic;
using Aspose.Cells;
using ns1;
using ns2;

namespace ns12;

internal class Class1377
{
	internal static int smethod_0(int int_0, WorksheetCollection worksheetCollection_0, WorksheetCollection worksheetCollection_1, Hashtable hashtable_0, Hashtable hashtable_1)
	{
		int num = worksheetCollection_0.method_32().method_12(int_0);
		int num2 = -1;
		if (hashtable_1[num] == null)
		{
			Class1718 @class = worksheetCollection_0.method_39()[num];
			string text = null;
			if (@class.method_12())
			{
				text = worksheetCollection_0.Workbook.FileName;
				if (text == null || text == "")
				{
					text = "Book1" + (worksheetCollection_0.Workbook.method_24() ? ".xlsx" : ".xls");
				}
				num2 = worksheetCollection_1.method_39().method_1(text);
			}
			else
			{
				num2 = worksheetCollection_1.method_39().method_2(@class);
			}
			if (num2 == -1)
			{
				num2 = worksheetCollection_1.method_39().AddCopy(worksheetCollection_1, worksheetCollection_0, num, hashtable_0);
			}
			hashtable_1.Add(num, num2);
		}
		else
		{
			num2 = (int)hashtable_1[num];
		}
		int num3 = -1;
		if (hashtable_0[int_0] == null)
		{
			Class1246 class2 = worksheetCollection_0.method_32()[int_0];
			return worksheetCollection_1.method_32().method_2((ushort)num2, class2.ushort_1, class2.ushort_2);
		}
		return (int)hashtable_0[int_0];
	}

	internal static object smethod_1(Class1661 class1661_0, WorksheetCollection worksheetCollection_0, int int_0, int int_1, int int_2, bool bool_0, Hashtable hashtable_0)
	{
		Class1718 @class = worksheetCollection_0.method_39()[int_0];
		Enum194 type = @class.Type;
		if (type == Enum194.const_0 && @class.method_0() != null && int_2 >= 0 && int_2 < @class.method_0().Count)
		{
			Class1653 class2 = (Class1653)@class.method_0()[int_2];
			int int_3 = 0;
			int int_4 = 0;
			int int_5 = 0;
			int int_6 = 0;
			int int_7 = 0;
			int int_8 = 0;
			if (class2.method_5() != null && class2.method_5().Length > 4)
			{
				if (class2.method_9(bool_0, ref int_7, ref int_8, ref int_3, ref int_4, ref int_5, ref int_6))
				{
					int_1 = int_7;
					if (@class.method_4() != null && int_1 >= 0 && int_1 <= @class.method_4().Length)
					{
						if (int_3 == int_4 && int_5 == int_6)
						{
							return smethod_3(worksheetCollection_0, int_0, int_1, int_3, int_5);
						}
						return smethod_2(class1661_0, int_0, worksheetCollection_0, int_1, int_3, int_5, int_4, int_6, hashtable_0, class2.Name.ToUpper());
					}
					return ErrorType.Ref;
				}
				return ErrorType.Ref;
			}
			return ErrorType.Name;
		}
		return ErrorType.Ref;
	}

	internal static object smethod_2(Class1661 class1661_0, int int_0, WorksheetCollection worksheetCollection_0, int int_1, int int_2, int int_3, int int_4, int int_5, Hashtable hashtable_0, string string_0)
	{
		Class1718 @class = worksheetCollection_0.method_39()[int_0];
		if (int_1 >= 0 && @class.method_4() != null && int_1 <= @class.method_4().Length)
		{
			Class1373 class2 = @class.method_10(int_1);
			bool flag = class2?.method_1() ?? false;
			string key;
			if (class1661_0.method_5() != null && (key = class1661_0.method_5().method_3()) != null)
			{
				if (Class1742.dictionary_99 == null)
				{
					Class1742.dictionary_99 = new Dictionary<string, int>(18)
					{
						{ "SUM", 0 },
						{ "COLUMN", 1 },
						{ "COLUMNS", 2 },
						{ "COUNT", 3 },
						{ "COUNTA", 4 },
						{ "OFFSET", 5 },
						{ "ROW", 6 },
						{ "ROWS", 7 },
						{ "SUMPRODUCT", 8 },
						{ "LOGEST", 9 },
						{ "CORREL", 10 },
						{ "MCORRELS", 11 },
						{ "REGRESSN", 12 },
						{ "PEARSON", 13 },
						{ "RSQ", 14 },
						{ "FREQUENCY", 15 },
						{ "FORECAST", 16 },
						{ "LINEST", 17 }
					};
				}
				if (Class1742.dictionary_99.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
					{
						double num2 = 0.0;
						if (flag)
						{
							int_4 = ((int_4 > class2.MaxRow) ? class2.MaxRow : int_4);
							for (int k = int_2; k <= int_4; k++)
							{
								Class1117 class4 = class2.method_3(k);
								if (class4 == null)
								{
									continue;
								}
								for (int l = int_3; l <= int_5; l++)
								{
									object obj2 = class4.method_10(l);
									if (obj2 != null)
									{
										if (obj2 is double)
										{
											num2 += (double)obj2;
										}
										else if (obj2 is int)
										{
											num2 += (double)(int)obj2;
										}
									}
								}
							}
						}
						return num2;
					}
					case 1:
						return (double)(int_3 + 1);
					case 2:
						return (double)(int_5 - int_3 + 1);
					case 3:
					case 4:
					{
						double num = 0.0;
						bool flag2 = class1661_0.method_5().method_3() == "COUNTA";
						for (int i = int_2; i <= int_4; i++)
						{
							Class1117 class3 = class2.method_3(i);
							if (class3 == null)
							{
								continue;
							}
							for (int j = int_3; j <= int_3; j++)
							{
								object obj = class3.method_10(j);
								if (obj != null)
								{
									if (flag2)
									{
										num += 1.0;
									}
									else if (obj is double)
									{
										num += 1.0;
									}
									else if (obj is int)
									{
										num += 1.0;
									}
								}
							}
						}
						return num;
					}
					case 5:
					{
						Struct87 @struct = default(Struct87);
						@struct.cellArea_0.StartRow = int_2;
						@struct.cellArea_0.EndRow = int_4;
						@struct.cellArea_0.StartColumn = int_3;
						@struct.cellArea_0.EndColumn = int_5;
						@struct.int_1 = int_1;
						@struct.int_0 = int_0;
						return @struct;
					}
					case 6:
						return (double)(int_2 + 1);
					case 7:
						return (double)(int_4 - int_2 + 1);
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:
						return smethod_4(class2, int_2, int_4, int_3, int_5);
					}
				}
			}
			if (class2 != null && class2.method_1())
			{
				string key2 = null;
				if (string_0 != null)
				{
					key2 = string_0 + "~" + int_0;
				}
				if (string_0 != null && hashtable_0[key2] != null)
				{
					return hashtable_0[key2];
				}
				int_2 = ((int_2 < class2.MinRow) ? class2.MinRow : int_2);
				int_4 = ((int_4 > class2.MaxRow) ? class2.MaxRow : int_4);
				object[][] array = new object[int_4 - int_2 + 1][];
				int num3 = 0;
				int m = class2.method_2(int_2, int_4);
				if (m != -1)
				{
					for (; m < class2.arrayList_0.Count; m++)
					{
						Class1117 class5 = (Class1117)class2.arrayList_0[m];
						if (class5.Index > int_4)
						{
							break;
						}
						num3 = class5.Index - int_2;
						array[num3] = class5.method_9(int_3, int_5);
					}
				}
				for (num3 = 0; num3 < array.Length; num3++)
				{
					if (array[num3] == null)
					{
						array[num3] = new object[int_5 - int_3 + 1];
					}
				}
				if (string_0 != null)
				{
					hashtable_0.Add(key2, array);
				}
				return array;
			}
			return null;
		}
		return ErrorType.Ref;
	}

	internal static object smethod_3(WorksheetCollection worksheetCollection_0, int int_0, int int_1, int int_2, int int_3)
	{
		Class1718 @class = worksheetCollection_0.method_39()[int_0];
		if (int_1 >= 0 && @class.method_4() != null && int_1 <= @class.method_4().Length)
		{
			return @class.method_10(int_1)?.method_4(int_2, int_3);
		}
		return ErrorType.Ref;
	}

	internal static object smethod_4(Class1373 class1373_0, int int_0, int int_1, int int_2, int int_3)
	{
		double[][] array = new double[int_2 - int_0 + 1][];
		if (class1373_0 != null && class1373_0.method_1())
		{
			for (int i = int_0; i <= int_2; i++)
			{
				Class1117 @class = class1373_0.method_3(i);
				if (@class != null)
				{
					array[i - int_0] = @class.method_8(int_1, int_3);
				}
			}
			for (int j = 0; j <= int_2 - int_0; j++)
			{
				if (array[j] == null)
				{
					array[j] = new double[int_3 - int_1 + 1];
				}
			}
			return array;
		}
		for (int k = 0; k <= int_2 - int_0; k++)
		{
			array[k] = new double[int_3 - int_1 + 1];
		}
		return array;
	}

	internal static object[][] smethod_5(Class1373 class1373_0, int int_0, int int_1, int int_2, int int_3)
	{
		object[][] array = new object[int_2 - int_0 + 1][];
		if (class1373_0 != null && class1373_0.method_1())
		{
			for (int i = int_0; i <= int_2; i++)
			{
				Class1117 @class = class1373_0.method_3(i);
				if (@class != null)
				{
					array[i - int_0] = @class.method_9(int_1, int_3);
				}
			}
			for (int j = 0; j <= int_2 - int_0; j++)
			{
				if (array[j] == null)
				{
					array[j] = new object[int_3 - int_1 + 1];
				}
			}
			return array;
		}
		for (int k = 0; k <= int_2 - int_0; k++)
		{
			array[k] = new object[int_3 - int_1 + 1];
		}
		return array;
	}
}
