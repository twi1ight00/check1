using System;
using System.IO;
using Aspose.Cells;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Exporting.Aspose.Excel;

/// <summary>
/// 基于Aspose组件的Excel导出器
/// </summary>
public class AsposeExcelExporter : AsposeExporter
{
	/// <summary>
	/// 模版位置
	/// </summary>
	public string TemplateLocation { get; private set; }

	/// <summary>
	/// 初始化指定名称的导出器
	/// </summary>
	/// <param name="name">导出器名称</param>
	public AsposeExcelExporter(string name)
		: base(name)
	{
	}

	/// <summary>
	/// 使用指定配置初始化导出器
	/// </summary>
	/// <param name="view">导出器配置源</param>
	public AsposeExcelExporter(AsposeExcelExportConfigurationView view)
		: base(view)
	{
	}

	/// <summary>
	/// 加载导出器配置
	/// </summary>
	/// <param name="view">配置视图</param>
	protected override void LoadConfiguration(IConfigurationView view)
	{
		AsposeExcelExportConfigurationView configurationView = view as AsposeExcelExportConfigurationView;
		if (configurationView.IsNull())
		{
			TemplateLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template");
		}
		else
		{
			TemplateLocation = configurationView.TemplateLocation;
		}
	}

	/// <summary>
	/// 获取当前使用的配置视图
	/// </summary>
	/// <param name="configuration"></param>
	/// <returns></returns>
	protected override IConfigurationView GetConfigurationView(IViewsConfiguration configuration)
	{
		return configuration.GetView<AsposeExcelExportConfigurationView>(base.Name);
	}

	/// <summary>
	/// 清理导出器
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			TemplateLocation = string.Empty;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// Test
	/// </summary>
	public void Test()
	{
		Workbook book = new Workbook();
		book.Save("Test.xlsx".BuildPath(TemplateLocation), SaveFormat.Xlsx);
	}
}
