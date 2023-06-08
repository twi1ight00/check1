using System;
using System.Configuration;
using System.Xml.Linq;
using Richfit.Garnet.Common.Configuration.Views;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Exporting.Aspose.Properties;

namespace Richfit.Garnet.Module.Exporting.Aspose.Excel;

/// <summary>
/// 基于Aspose的Excel导出配置视图
/// </summary>
public class AsposeExcelExportConfigurationView : ConfigurationView
{
	/// <summary>
	/// 获取或者设置模版位置
	/// </summary>
	public string TemplateLocation { get; set; }

	/// <summary>
	/// 初始化默认配置视图
	/// </summary>
	public AsposeExcelExportConfigurationView()
	{
	}

	/// <summary>
	/// 初始化配置视图
	/// </summary>
	/// <param name="xml">视图数据</param>
	public AsposeExcelExportConfigurationView(string xml)
	{
		Deserialize(xml);
	}

	/// <summary>
	/// 将视图序列化为Xml格式的配置数据
	/// </summary>
	/// <returns>Xml结构化对象</returns>
	protected override XElement SerializeView()
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// 将Xml格式的配置数据反序列化为视图对象
	/// </summary>
	/// <param name="root">Xml格式配置数据对象</param>
	protected override void DeserializeView(XElement root)
	{
		XElement templates = root.Element("templates").GuardNotNull(typeof(ConfigurationErrorsException), Literals.MSG_E_InvalidExporterConfiguration);
		XAttribute location = templates.Attribute("location");
		if (location.IsNull())
		{
			TemplateLocation = base.Owner.File.FullName;
			return;
		}
		TemplateLocation = location.Value;
		if (TemplateLocation.IsRelativePath())
		{
			TemplateLocation = TemplateLocation.BuildPath(base.Owner.File.FullName);
		}
	}
}
