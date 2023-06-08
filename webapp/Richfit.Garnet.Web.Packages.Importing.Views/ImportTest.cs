using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Importing;
using Richfit.Garnet.Module.Importing.Aspose.Excel;

namespace Richfit.Garnet.Web.Packages.Importing.Views;

public class ImportTest : Page
{
	private static bool hasInitialized = false;

	protected HtmlForm form1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!hasInitialized)
		{
			ImportManager.Initialize(ConfigurationManager.System);
			hasInitialized = true;
		}
		AsposeExcelImporter importer = ImportManager.Default.GetImporter("ExcelImporter") as AsposeExcelImporter;
		Stream result = null;
		using (FileStream fs = File.OpenRead("D:\\Richfit.Projects\\Garnet\\Temp\\导入测试数据.xlsx"))
		{
			AsposeExcelImportOptions asposeExcelImportOptions = new AsposeExcelImportOptions();
			asposeExcelImportOptions.ImportFileName = "导入测试数据.xlsx";
			AsposeExcelImportOptions options = asposeExcelImportOptions;
			importer.ImportFromTemplate(fs, "Test", options, out result);
		}
		if (result.IsNotNull())
		{
			result.SaveFile("c:\\result.xls");
		}
	}
}
