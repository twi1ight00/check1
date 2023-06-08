namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 数据记录保存上下文，该上下文对象会被重用，不可缓存该对象
/// </summary>
public class RecordSaveContext
{
	/// <summary>
	/// 获取导入模版
	/// </summary>
	public AsposeExcelImportTemplate Template { get; internal set; }

	/// <summary>
	/// 获取当前导入的数据记录
	/// </summary>
	public object Record { get; set; }

	/// <summary>
	/// 获取或者设置是否已经保存
	/// </summary>
	public bool Saved { get; set; }

	/// <summary>
	/// 错误消息
	/// </summary>
	public string ErrorMessage { get; set; }

	/// <summary>
	/// 默认初始化
	/// </summary>
	public RecordSaveContext()
	{
		Reset();
	}

	/// <summary>
	/// 重置上下文状态
	/// </summary>
	public void Reset()
	{
		Template = null;
		Record = null;
		Saved = false;
		ErrorMessage = string.Empty;
	}
}
