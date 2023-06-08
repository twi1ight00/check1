using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Pivot;

namespace ns2;

internal class Class1337 : CollectionBase
{
	private WorksheetCollection worksheetCollection_0;

	public Style this[int int_0] => (Style)base.InnerList[int_0];

	internal Class1337(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	internal void method_0()
	{
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			Worksheet worksheet = worksheetCollection_0[i];
			if (worksheet.pivotTableCollection_0 != null)
			{
				for (int j = 0; j < worksheet.pivotTableCollection_0.Count; j++)
				{
					PivotTable pivotTable = worksheet.pivotTableCollection_0[j];
					PivotFormatConditionCollection pivotFormatConditionCollection_ = pivotTable.pivotFormatConditionCollection_0;
					if (pivotFormatConditionCollection_ == null || pivotFormatConditionCollection_.Count <= 0)
					{
						continue;
					}
					for (int k = 0; k < pivotFormatConditionCollection_.Count; k++)
					{
						PivotFormatCondition pivotFormatCondition = pivotFormatConditionCollection_[k];
						FormatConditionCollection formatConditionCollection_ = pivotFormatCondition.formatConditionCollection_0;
						for (int l = 0; l < formatConditionCollection_.Count; l++)
						{
							FormatCondition formatCondition = formatConditionCollection_[l];
							Style style_ = formatCondition.style_0;
							if (style_ != null)
							{
								formatCondition.method_7(Add(style_));
							}
						}
					}
				}
			}
			if (worksheet.conditionalFormattingCollection_0 != null)
			{
				for (int m = 0; m < worksheet.ConditionalFormattings.Count; m++)
				{
					FormatConditionCollection formatConditionCollection = worksheet.ConditionalFormattings[m];
					for (int n = 0; n < formatConditionCollection.Count; n++)
					{
						FormatCondition formatCondition2 = formatConditionCollection[n];
						Style style_2 = formatCondition2.style_0;
						if (style_2 != null)
						{
							formatCondition2.method_7(Add(style_2));
						}
					}
				}
			}
			if (worksheet.method_24() <= 0)
			{
				continue;
			}
			DataSorter dataSorter_ = worksheet.AutoFilter.dataSorter_0;
			if (dataSorter_ == null || dataSorter_.method_0().Count <= 0)
			{
				continue;
			}
			foreach (Class1108 item in dataSorter_.method_0())
			{
				switch (item.Type)
				{
				case Enum135.const_1:
					if (item.method_6() != null)
					{
						item.method_4(Add(item.method_6()));
					}
					break;
				case Enum135.const_2:
					if (item.method_8() != null)
					{
						item.method_4(Add(item.method_8()));
					}
					break;
				}
			}
		}
	}

	internal int Add(Style style_0)
	{
		if (style_0.method_5() == worksheetCollection_0)
		{
			for (int i = 0; i < base.InnerList.Count; i++)
			{
				Style style = (Style)base.InnerList[i];
				if (style_0 == style || (style_0.method_12() == style.method_12() && style_0.method_30(style)))
				{
					return i;
				}
			}
		}
		Style style2 = new Style(worksheetCollection_0);
		style2.Copy(style_0);
		base.InnerList.Add(style2);
		return base.InnerList.Count - 1;
	}

	internal int method_1(Style style_0)
	{
		base.InnerList.Add(style_0);
		return base.Count - 1;
	}
}
