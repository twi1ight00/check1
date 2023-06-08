using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Cells;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 基于Aspose组件的Excel导入器选项参数
/// </summary>
public class AsposeExcelImportOptions : ImportOptions
{
	/// <summary>
	/// 导入数据验证失败时，是否返回全部的数据（true），还是只返回错误数据（false）。
	/// </summary>
	public bool? ReturnAllDataOnError { get; set; }

	/// <summary>
	/// 是否对错误数据进行排序，如果排序（true）则错误数据将会放到导入数据的头部，如果不排序（false）将保持导入数据的原始顺序。
	/// </summary>
	public bool? SortErrorData { get; set; }

	/// <summary>
	/// 导入的文件名称
	/// </summary>
	public string ImportFileName { get; set; }

	/// <summary>
	/// 需要执行导入的模版名称
	/// </summary>
	public string ImportTemplateNames { get; set; }

	/// <summary>
	/// 导入的数据表解析处理
	/// </summary>
	public Action<SheetResolveContext> SheetResolve { get; set; }

	/// <summary>
	/// 导入的数据项目验证处理
	/// </summary>
	public Action<ValueValidateContext> ValueValidate { get; set; }

	/// <summary>
	/// 导入的数据项目值解析处理
	/// </summary>
	public Action<ValueResolveContext> ValueResolve { get; set; }

	/// <summary>
	/// 导入的数据记录验证处理
	/// </summary>
	public Action<RecordValidateContext> RecordValidate { get; set; }

	/// <summary>
	/// 导入的数据记录值解析处理
	/// </summary>
	public Action<RecordResolveContext> RecordResolve { get; set; }

	/// <summary>
	/// 数据记录保存处理
	/// </summary>
	public Action<RecordSaveContext> RecordSave { get; set; }

	/// <summary>
	/// 初始化默认设置
	/// </summary>
	public AsposeExcelImportOptions()
	{
		ImportTemplateNames = null;
		ReturnAllDataOnError = null;
		SortErrorData = null;
		ImportFileName = string.Empty;
		ImportTemplateNames = string.Empty;
	}

	/// <summary>
	/// 使用指定值初始化选项
	/// </summary>
	/// <param name="xml">Xml配置数据</param>
	public AsposeExcelImportOptions(string xml)
		: this()
	{
		LoadOptions(xml);
	}

	/// <summary>
	/// 使用指定值初始化选项
	/// </summary>
	/// <param name="xml">Xml配置数据对象</param>
	public AsposeExcelImportOptions(XElement xml)
		: this()
	{
		LoadOptions(xml);
	}

	/// <summary>
	/// 合并配置参数
	/// </summary>
	/// <param name="options">待合并的配置时参数</param>
	/// <return>合并后的当前对象</return>
	public AsposeExcelImportOptions MergeOptions(AsposeExcelImportOptions options)
	{
		options.GuardNotNull("options");
		if (ReturnAllDataOnError.IsNull() && options.ReturnAllDataOnError.IsNotNull())
		{
			ReturnAllDataOnError = options.ReturnAllDataOnError;
		}
		if (SortErrorData.IsNull() && options.SortErrorData.IsNotNull())
		{
			SortErrorData = options.SortErrorData;
		}
		return this;
	}

	/// <summary>
	/// 获取导入文件加载格式
	/// </summary>
	/// <returns></returns>
	public LoadFormat GetLoadFormat()
	{
		return FileFormatUtil.SaveFormatToLoadFormat(GetSaveFormat());
	}

	/// <summary>
	/// 获取导入文件保存格式
	/// </summary>
	/// <returns></returns>
	public SaveFormat GetSaveFormat()
	{
		string extension = Path.GetExtension(ImportFileName).IfNullOrEmpty("xls").Trim('.');
		return FileFormatUtil.ExtensionToSaveFormat(extension);
	}

	/// <summary>
	/// 需要执行导入的模版名称的数组
	/// </summary>
	/// <returns></returns>
	public string[] GetTemplateNames()
	{
		if (ImportTemplateNames.IsNull())
		{
			return new string[0];
		}
		return ImportTemplateNames.Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
	}
}
