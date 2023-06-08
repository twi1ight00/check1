using Aspose.Cells;
using ns16;
using ns57;

namespace ns2;

internal class Class1346
{
	internal Workbook workbook_0;

	internal bool HasRevisions
	{
		get
		{
			Class1317 @class = workbook_0.Worksheets.method_10();
			if (@class != null)
			{
				return @class.method_9().ContainsKey("Revision Log");
			}
			if (!workbook_0.Settings.method_7())
			{
				return false;
			}
			if (workbook_0.Worksheets.method_10() != null)
			{
				return workbook_0.Worksheets.method_10().method_9().GetStream("Revision Log") != null;
			}
			if (workbook_0.class1558_0 != null)
			{
				foreach (object item in workbook_0.class1558_0.arrayList_0)
				{
					Class1530 class2 = (Class1530)item;
					if (class2.string_2.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.revisionHeaders+xml") || class2.string_2.Equals("application/vnd.ms-excel.revisionHeaders"))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	internal Class1346(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
	}

	internal void AcceptAllRevisions()
	{
		workbook_0.Settings.method_8(bool_26: false);
		Class1317 @class = workbook_0.Worksheets.method_10();
		if (@class != null)
		{
			@class.method_9().Remove("Revision Log");
			@class.method_9().Remove("User Names");
			workbook_0.Worksheets.method_21().Clear();
			workbook_0.Worksheets.method_15(bool_4: false);
			workbook_0.Settings.Shared = false;
			for (int i = 0; i < workbook_0.Worksheets.Count; i++)
			{
				Worksheet worksheet = workbook_0.Worksheets[i];
				worksheet.method_20().Clear();
			}
		}
	}
}
