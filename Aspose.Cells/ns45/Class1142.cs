using System;
using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1142 : CollectionBase
{
	internal WorksheetCollection worksheetCollection_0;

	internal int int_0;

	internal int int_1;

	public Class1141 this[int int_2] => (Class1141)base.InnerList[int_2];

	internal Class1142(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		int_0 = 0;
		int_1 = 0;
	}

	internal int Add(string string_0, Worksheet worksheet_0, bool bool_0)
	{
		if (bool_0)
		{
			int num = method_0(PivotTableSourceType.ListDatabase, new string[1] { string_0 });
			if (num != -1)
			{
				return num;
			}
		}
		int_0++;
		Class1141 class1141_ = new Class1141(this, PivotTableSourceType.ListDatabase, new string[1] { string_0 }, null, bool_2: false, int_0, worksheet_0);
		return Add(class1141_);
	}

	internal int Add(Class1141 class1141_0)
	{
		class1141_0.Index = int_1++;
		base.InnerList.Add(class1141_0);
		return base.Count - 1;
	}

	internal int Add(PivotTableSourceType pivotTableSourceType_0, string[] string_0, bool bool_0, PivotPageFields pivotPageFields_0)
	{
		int num = method_0(PivotTableSourceType.ListDatabase, string_0);
		if (num != -1)
		{
			return num;
		}
		int_0++;
		Class1141 class1141_ = new Class1141(this, pivotTableSourceType_0, string_0, pivotPageFields_0, bool_0, int_0, null);
		return Add(class1141_);
	}

	public int method_0(PivotTableSourceType pivotTableSourceType_0, string[] string_0)
	{
		int num = -1;
		bool flag = false;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class1141 @class = (Class1141)enumerator.Current;
				num++;
				flag = true;
				if (@class.class1139_0 != null && string_0 != null)
				{
					if (@class.pivotTableSourceType_0 == pivotTableSourceType_0 || @class.class1139_0.Length == string_0.Length)
					{
						for (int i = 0; i < string_0.Length; i++)
						{
							if (!string_0[i].Equals(@class.class1139_0[i].GetSource()))
							{
								flag = false;
								break;
							}
						}
					}
					if (flag)
					{
						return num;
					}
					continue;
				}
				return -1;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return -1;
	}

	internal Class1141 Add(Class1141 class1141_0, Worksheet worksheet_0)
	{
		if (class1141_0.class1142_0.worksheetCollection_0 == worksheetCollection_0)
		{
			class1141_0.int_5++;
			return class1141_0;
		}
		int num = method_0(class1141_0.pivotTableSourceType_0, class1141_0.method_22());
		if (num != -1)
		{
			this[num].int_5++;
			return this[num];
		}
		int_0++;
		Class1141 @class = new Class1141(this, int_0, worksheet_0);
		@class.Copy(class1141_0);
		Add(@class);
		return @class;
	}

	internal void InsertRows(int int_2, int int_3, Worksheet worksheet_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Class1141 @class = this[i];
			@class.InsertRows(int_2, int_3, worksheet_0);
		}
	}

	internal void method_1(Class1141 class1141_0)
	{
		base.InnerList.Add(class1141_0);
	}

	internal Class1141 method_2(int int_2)
	{
		int num = 0;
		Class1141 @class;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				@class = (Class1141)base.InnerList[num];
				if (@class.int_6 == int_2)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}
}
