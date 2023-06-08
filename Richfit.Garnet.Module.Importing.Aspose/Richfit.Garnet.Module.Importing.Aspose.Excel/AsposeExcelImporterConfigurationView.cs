using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Richfit.Garnet.Common.Configuration.Views;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Importing.Aspose.Properties;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 基于Aspose的Excel导入配置视图
/// </summary>
public class AsposeExcelImporterConfigurationView : ConfigurationView
{
	/// <summary>
	/// 导入选项数据
	/// </summary>
	private XElement xmlOptions;

	/// <summary>
	/// 导入选项对象
	/// </summary>
	private Lazy<AsposeExcelImportOptions> options;

	/// <summary>
	/// 导入模版数据
	/// </summary>
	private XElement xmlTemplates;

	/// <summary>
	/// 导入模版
	/// </summary>
	private Lazy<AsposeExcelImportTemplate[]> templates;

	/// <summary>
	/// 初始化默认配置视图
	/// </summary>
	public AsposeExcelImporterConfigurationView()
	{
	}

	/// <summary>
	/// 初始化配置视图
	/// </summary>
	/// <param name="xml">视图数据</param>
	public AsposeExcelImporterConfigurationView(string xml)
		: base(xml)
	{
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
		XElement options = root.Element("options");
		xmlOptions = options;
		this.options = new Lazy<AsposeExcelImportOptions>(() => LoadOptions(xmlOptions), LazyThreadSafetyMode.ExecutionAndPublication);
		XElement templates = root.Element("templates");
		xmlTemplates = templates;
		this.templates = new Lazy<AsposeExcelImportTemplate[]>(() => LoadTemplates(xmlTemplates), LazyThreadSafetyMode.ExecutionAndPublication);
	}

	/// <summary>
	/// 加载导入选项
	/// </summary>
	/// <param name="xmlOptions">导入选项的Xml数据</param>
	/// <returns></returns>
	private AsposeExcelImportOptions LoadOptions(XElement xmlOptions)
	{
		return xmlOptions.IsNull() ? new AsposeExcelImportOptions() : new AsposeExcelImportOptions(xmlOptions);
	}

	/// <summary>
	/// 获取导入选项
	/// </summary>
	/// <returns>选项对象</returns>
	public AsposeExcelImportOptions GetOptions()
	{
		return options.IsNull() ? null : options.Value;
	}

	/// <summary>
	/// 加载导入模版
	/// </summary>
	/// <param name="xmlTemplates">模版集合的Xml数据</param>
	/// <returns>导入模版数组</returns>
	private AsposeExcelImportTemplate[] LoadTemplates(XElement xmlTemplates)
	{
		if (xmlTemplates.IsNull())
		{
			return new AsposeExcelImportTemplate[0];
		}
		List<AsposeExcelImportTemplate> templates = new List<AsposeExcelImportTemplate>();
		string templateName;
		foreach (XElement xmlTemplate in xmlTemplates.Elements("template"))
		{
			XAttribute xmlTemplateName = xmlTemplate.Attribute("name").GuardNotNull(typeof(ConfigurationErrorsException), Literals.M_E_Template_PropertyMissing.FormatValue("", "name"));
			templateName = xmlTemplateName.Value;
			XAttribute xmlTemplateTitle = xmlTemplate.Attribute("title");
			string templateTitle = (xmlTemplateTitle.IsNull() ? string.Empty : xmlTemplateTitle.Value);
			if (templates.Any((AsposeExcelImportTemplate x) => x.Name.EqualOrdinal(templateName)))
			{
				throw new ConfigurationErrorsException(Literals.M_E_Template_Duplicate.FormatValue(templateName, templateTitle));
			}
			templates.Add(new AsposeExcelImportTemplate(xmlTemplate));
		}
		return templates.ToArray();
	}

	/// <summary>
	/// 获取导入模版
	/// </summary>
	/// <returns>导入模版对象</returns>
	public AsposeExcelImportTemplate[] GetTemplates()
	{
		return templates.IsNull() ? new AsposeExcelImportTemplate[0] : templates.Value;
	}
}
