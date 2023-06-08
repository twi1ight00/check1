using System.Collections.Generic;
using Richfit.Garnet.Common.Dynamic;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 导入项目值验证上下文，该上下文对象会被重用，不可缓存该对象
/// </summary>
public class ValueValidateContext
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
	/// 当前已导入的记录
	/// </summary>
	public IList<IDataObject> Records { get; internal set; }

	/// <summary>
	/// 当前导入的项目的数据行索引
	/// </summary>
	public int RowIndex { get; internal set; }

	/// <summary>
	/// 当前导入的项目值
	/// </summary>
	public object Value { get; set; }

	/// <summary>
	/// 是否有效
	/// </summary>
	public bool Error { get; set; }

	/// <summary>
	/// 异常信息
	/// </summary>
	public string ErrorMessage { get; set; }

	/// <summary>
	/// 默认初始化
	/// </summary>
	public ValueValidateContext()
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
		Records = null;
		RowIndex = -1;
		Value = null;
		Error = false;
		ErrorMessage = string.Empty;
	}
}
