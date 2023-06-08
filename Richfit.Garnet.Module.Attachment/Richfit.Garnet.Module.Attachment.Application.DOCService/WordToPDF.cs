using System;
using Microsoft.Office.Interop.Word;

namespace Richfit.Garnet.Module.Attachment.Application.DOCService;

public class WordToPDF : IDOCTOPDF
{
	public bool ConvertToPDF(string sourcePath, string targetPath)
	{
		bool result = false;
		WdExportFormat exportFormat = WdExportFormat.wdExportFormatPDF;
		object paramMissing = Type.Missing;
		ApplicationClass wordApplication = new ApplicationClass();
		Document wordDocument = null;
		try
		{
			object paramSourceDocPath = sourcePath;
			WdExportFormat paramExportFormat = exportFormat;
			bool paramOpenAfterExport = false;
			WdExportOptimizeFor paramExportOptimizeFor = WdExportOptimizeFor.wdExportOptimizeForPrint;
			WdExportRange paramExportRange = WdExportRange.wdExportAllDocument;
			int paramStartPage = 0;
			int paramEndPage = 0;
			WdExportItem paramExportItem = WdExportItem.wdExportDocumentContent;
			bool paramIncludeDocProps = true;
			bool paramKeepIRM = true;
			WdExportCreateBookmarks paramCreateBookmarks = WdExportCreateBookmarks.wdExportCreateWordBookmarks;
			bool paramDocStructureTags = true;
			bool paramBitmapMissingFonts = true;
			bool paramUseISO19005_1 = false;
			wordDocument = wordApplication.Documents.Open(ref paramSourceDocPath, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing);
			wordDocument?.ExportAsFixedFormat(targetPath, paramExportFormat, paramOpenAfterExport, paramExportOptimizeFor, paramExportRange, paramStartPage, paramEndPage, paramExportItem, paramIncludeDocProps, paramKeepIRM, paramCreateBookmarks, paramDocStructureTags, paramBitmapMissingFonts, paramUseISO19005_1, ref paramMissing);
			result = true;
		}
		catch
		{
			result = false;
		}
		finally
		{
			if (wordDocument != null)
			{
				wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
				wordDocument = null;
			}
			if (wordApplication != null)
			{
				wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
				wordApplication = null;
			}
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
		return result;
	}
}
