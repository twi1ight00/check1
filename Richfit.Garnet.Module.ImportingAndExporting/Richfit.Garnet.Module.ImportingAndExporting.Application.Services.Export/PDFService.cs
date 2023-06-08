using System.IO;
using System.Web;
using Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Export;

public class PDFService : IExport
{
	private HttpContext context;

	public PDFService(HttpContext context)
	{
		this.context = context;
	}

	public string Export(ExportDTO parameter)
	{
		string templateType = Path.GetExtension(parameter.TemplatePath);
		if (templateType == ".xls" || templateType == ".xlsx")
		{
			ExcelService excelService = new ExcelService(context);
			return excelService.Export(parameter, isPdf: true);
		}
		WordService wordService = new WordService(context);
		return wordService.Export(parameter, isPdf: true);
	}
}
