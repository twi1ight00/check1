using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 导入项目值解析上下文，该上下文对象会被重用，不可缓存该对象
/// </summary>
public class ValueResolveContext
{
	/// <summary>
	/// 导入模版
	/// </summary>
	public AsposeExcelImportTemplate Template { get; internal set; }

	/// <summary>
	/// 当前导入项目
	/// </summary>
	public AsposeExcelImportTemplateItem Item { get; internal set; }

	/// <summary>
	/// 获取导入项目的数据行的索引
	/// </summary>
	public int RowIndex { get; internal set; }

	/// <summary>
	/// 当前导入项目原始值
	/// </summary>
	public string RawValue { get; internal set; }

	/// <summary>
	/// 当前导入项目原始值字典
	/// </summary>
	public Dictionary<string, string> RawValues { get; internal set; }

	/// <summary>
	/// 处理中是否出现异常
	/// </summary>
	public bool Error { get; set; }

	/// <summary>
	/// 异常信息
	/// </summary>
	public string ErrorMessage { get; set; }

	/// <summary>
	/// 解析结果值
	/// </summary>
	public object Result { get; set; }

	/// <summary>
	/// 默认初始化
	/// </summary>
	public ValueResolveContext()
	{
		Reset();
	}

	/// <summary>
	/// 重置上下文状态
	/// </summary>
	public void Reset()
	{
		Template = null;
		Item = null;
		RowIndex = -1;
		RawValue = string.Empty;
		Error = false;
		ErrorMessage = string.Empty;
		Result = null;
		if (RawValues.IsNull())
		{
			RawValues = new Dictionary<string, string>();
		}
		RawValues.Clear();
	}
}
