using System;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;

namespace Richfit.Garnet.Module.Attachment.Application.DOCService;

public class PPTToPDF : IDOCTOPDF
{
	/// <summary>
	/// 把PowerPoing文件转换成PDF格式文件
	/// </summary>
	/// <param name="sourcePath">源文件路径</param>
	/// <param name="targetPath">目标文件路径</param>
	/// <returns>true=转换成功</returns>
	public bool ConvertToPDF(string sourcePath, string targetPath)
	{
		PpSaveAsFileType targetFileType = PpSaveAsFileType.ppSaveAsPDF;
		object missing = Type.Missing;
		ApplicationClass application = null;
		Presentation persentation = null;
		try
		{
			application = new ApplicationClass();
			persentation = application.Presentations.Open(sourcePath, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
			persentation.SaveAs(targetPath, targetFileType, MsoTriState.msoTrue);
			return true;
		}
		catch
		{
			return false;
		}
		finally
		{
			if (persentation != null)
			{
				persentation.Close();
				persentation = null;
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
	}
}
