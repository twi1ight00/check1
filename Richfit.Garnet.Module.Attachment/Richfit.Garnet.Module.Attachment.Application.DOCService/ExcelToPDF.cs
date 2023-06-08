using System;
using Microsoft.Office.Interop.Excel;

namespace Richfit.Garnet.Module.Attachment.Application.DOCService;

public class ExcelToPDF : IDOCTOPDF
{
	public bool ConvertToPDF(string sourcePath, string targetPath)
	{
		bool result = false;
		XlFixedFormatType targetType = XlFixedFormatType.xlTypePDF;
		object missing = Type.Missing;
		ApplicationClass application = null;
		Workbook workBook = null;
		try
		{
			application = new ApplicationClass();
			object type = targetType;
			workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
			workBook.ExportAsFixedFormat(targetType, targetPath, XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
			result = true;
		}
		catch
		{
			result = false;
		}
		finally
		{
			if (workBook != null)
			{
				workBook.Close(true, missing, missing);
				workBook = null;
			}
			if (application != null)
			{
				application.Quit();
				application = null;
			}
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
		return result;
	}
}
