using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Exporting.Aspose.Properties;

namespace Richfit.Garnet.Module.Exporting.Aspose.Excel;

/// <summary>
/// 导出器接口扩展方法
/// </summary>
public static class IExporterExtensions
{
	/// <summary>
	/// Test
	/// </summary>
	/// <param name="exporter"></param>
	public static void Test(this IExporter exporter)
	{
		AsposeExcelExporter excelExporter = exporter as AsposeExcelExporter;
		excelExporter.GuardNotNull(null, Literals.MSG_E_InvalidExporter);
		excelExporter.Test();
	}
}
