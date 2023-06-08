using System;
using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1150
{
	internal static bool smethod_0(ArrayList arrayList_0, Cell cell_0, ref int int_0)
	{
		switch (cell_0.Type)
		{
		case CellValueType.IsBool:
			arrayList_0.Add(cell_0.BoolValue ? 1.0 : 0.0);
			int_0++;
			break;
		case CellValueType.IsError:
			return false;
		case CellValueType.IsDateTime:
		case CellValueType.IsNumeric:
			arrayList_0.Add(cell_0.DoubleValue);
			int_0++;
			break;
		case CellValueType.IsString:
			int_0++;
			break;
		}
		return true;
	}

	internal static ArrayList smethod_1(ArrayList C8Records, bool ignore, PivotField dataField, bool[] flags, ConsolidationFunction function, Class1141 cache, int number, Class1165 item, out int count, out bool hasItem)
	{
		count = 0;
		hasItem = false;
		int baseIndex = dataField.BaseIndex;
		ArrayList arrayList = new ArrayList();
		if (baseIndex >= 0 && baseIndex < flags.Length)
		{
			if (flags[baseIndex])
			{
				Class1161 @class = (Class1161)cache.arrayList_0[baseIndex];
				ArrayList arrayList_ = @class.arrayList_0;
				if (arrayList_ == null || arrayList_.Count == 0)
				{
					count = 0;
					return arrayList;
				}
				for (int i = 0; i < C8Records.Count; i++)
				{
					Class1153 class2 = (Class1153)C8Records[i];
					if ((ignore && class2.bool_0) || class2.object_0[baseIndex] == null)
					{
						continue;
					}
					int num = (int)class2.object_0[baseIndex];
					if (num >= arrayList_.Count)
					{
						continue;
					}
					object object_ = ((Class1158)arrayList_[num]).object_0;
					if (object_ == null)
					{
						continue;
					}
					switch (function)
					{
					case ConsolidationFunction.CountNums:
						if (object_ is int || object_ is double)
						{
							count++;
						}
						continue;
					case ConsolidationFunction.Count:
						count++;
						continue;
					}
					if (object_ is int)
					{
						arrayList.Add((double)(int)object_);
						count++;
					}
					else if (object_ is double)
					{
						arrayList.Add(object_);
						count++;
					}
					else if (object_ is DateTime)
					{
						arrayList.Add(CellsHelper.GetDoubleFromDateTime((DateTime)object_, date1904: false));
						count++;
					}
					else
					{
						hasItem = true;
					}
				}
			}
			else
			{
				for (int j = 0; j < C8Records.Count; j++)
				{
					Class1153 class3 = (Class1153)C8Records[j];
					object obj = class3.object_0[baseIndex];
					if (obj == null)
					{
						continue;
					}
					switch (function)
					{
					case ConsolidationFunction.CountNums:
						if (obj is int || obj is double)
						{
							count++;
						}
						continue;
					case ConsolidationFunction.Count:
						count++;
						continue;
					}
					if (obj is int)
					{
						arrayList.Add((double)(int)obj);
						count++;
					}
					else if (obj is double)
					{
						arrayList.Add(obj);
						count++;
					}
					else if (obj is DateTime)
					{
						arrayList.Add(CellsHelper.GetDoubleFromDateTime((DateTime)obj, date1904: false));
						count++;
					}
					else
					{
						hasItem = true;
					}
				}
			}
			return arrayList;
		}
		return arrayList;
	}
}
