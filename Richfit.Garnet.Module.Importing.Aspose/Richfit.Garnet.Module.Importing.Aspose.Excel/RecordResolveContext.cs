using System.Collections.Generic;
using Richfit.Garnet.Common.Dynamic;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 导入数据记录解析上下文，该上下文对象会被重用，不可缓存该对象
/// </summary>
public class RecordResolveContext
{
	/// <summary>
	/// 导入模版
	/// </summary>
	public AsposeExcelImportTemplate Template { get; internal set; }

	/// <summary>
	/// 当前导入数据记录的索引
	/// </summary>
	public int RowIndex { get; internal set; }

	/// <summary>
	/// 当前导入数据记录的值
	/// </summary>
	public IDictionary<string, string> RawValues { get; internal set; }

	/// <summary>
	/// 是否已经解析当前数据行
	/// </summary>
	public bool Resolved { get; set; }

	/// <summary>
	/// 处理中是否出现异常
	/// </summary>
	public bool Error { get; set; }

	/// <summary>
	/// 异常信息
	/// </summary>
	public string ErrorMessage { get; set; }

	/// <summary>
	/// 生成的数据记录
	/// </summary>
	public IDataObject ResultRecord { get; set; }

	/// <summary>
	/// 默认初始化
	/// </summary>
	public RecordResolveContext()
	{
		Reset();
	}

	/// <summary>
	/// 重置上下文状态
	/// </summary>
	public void Reset()
	{
		Template = null;
		RowIndex = -1;
		RawValues = null;
		Resolved = true;
		Error = false;
		ErrorMessage = string.Empty;
		ResultRecord = null;
	}
}
