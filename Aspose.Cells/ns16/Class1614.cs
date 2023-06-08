using Aspose.Cells;

namespace ns16;

internal class Class1614
{
	internal static void smethod_0(Workbook workbook_0)
	{
		workbook_0.Settings.bool_0 = true;
		try
		{
			Class1615 @class = new Class1615(workbook_0);
			@class.Read();
		}
		finally
		{
			workbook_0.Settings.bool_0 = false;
			workbook_0.class1558_0.class1553_0.Close();
		}
	}
}
