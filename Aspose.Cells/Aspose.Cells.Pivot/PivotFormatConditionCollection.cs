using System.Collections;

namespace Aspose.Cells.Pivot;

public class PivotFormatConditionCollection : CollectionBase
{
	internal Worksheet worksheet_0;

	internal PivotTable pivotTable_0;

	public PivotFormatCondition this[int index] => (PivotFormatCondition)base.InnerList[index];

	internal PivotFormatConditionCollection(PivotTable pivotTable_1, Worksheet worksheet_1)
	{
		pivotTable_0 = pivotTable_1;
		worksheet_0 = worksheet_1;
	}

	internal int method_0()
	{
		base.InnerList.Add(new PivotFormatCondition(this, bool_0: false));
		return base.Count - 1;
	}

	public int Add()
	{
		base.InnerList.Add(new PivotFormatCondition(this));
		return base.Count - 1;
	}

	internal bool method_1()
	{
		bool result = false;
		if (base.Count > 0)
		{
			for (int i = 0; i < base.Count; i++)
			{
				FormatConditionCollection formatConditionCollection_ = this[i].formatConditionCollection_0;
				foreach (FormatCondition item in formatConditionCollection_.method_0())
				{
					if (item.method_23())
					{
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}

	internal bool method_2()
	{
		bool result = false;
		if (base.Count > 0)
		{
			for (int i = 0; i < base.Count; i++)
			{
				FormatConditionCollection formatConditionCollection_ = this[i].formatConditionCollection_0;
				foreach (FormatCondition item in formatConditionCollection_.method_0())
				{
					if (item.Type == FormatConditionType.DataBar)
					{
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}
}
