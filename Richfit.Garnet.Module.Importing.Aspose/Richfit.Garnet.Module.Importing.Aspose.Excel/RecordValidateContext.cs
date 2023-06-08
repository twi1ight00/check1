using System.Collections.Generic;
using Richfit.Garnet.Common.Dynamic;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 导入数据记录验证上下文，该上下文对象会被重用，不可缓存该对象
/// </summary>
public class RecordValidateContext
{
	/// <summary>
	/// 导入模版
	/// </summary>
	public AsposeExcelImportTemplate Template { get; internal set; }

	/// <summary>
	/// 已导入数据记录
	/// </summary>
	public IList<IDataObject> Records { get; internal set; }

	/// <summary>
	/// 当前导入数据记录的值
	/// </summary>
	public IDataObject Record { get; set; }

	/// <summary>
	/// 当前导入数据记录的索引
	/// </summary>
	public int RowIndex { get; internal set; }

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
	public RecordValidateContext()
	{
		Reset();
	}

	/// <summary>
	/// 重置上下文状态
	/// </summary>
	public void Reset()
	{
		Template = null;
		Records = null;
		Record = null;
		RowIndex = -1;
		Error = false;
		ErrorMessage = string.Empty;
	}
}
