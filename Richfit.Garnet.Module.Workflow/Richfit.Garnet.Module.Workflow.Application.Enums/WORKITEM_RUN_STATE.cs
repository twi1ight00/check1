using System.ComponentModel;

namespace Richfit.Garnet.Module.Workflow.Application.Enums;

/// <summary>
/// 运行状态枚举
/// </summary>
public enum WORKITEM_RUN_STATE
{
	/// <summary>
	/// 运行中
	/// </summary>
	None = 0,
	/// <summary>
	/// 通过
	/// </summary>
	[Description("通过")]
	Adopt = 2,
	/// <summary>
	/// 转批
	/// </summary>
	[Description("转批")]
	Transfer = 4,
	/// <summary>
	/// 传阅
	/// </summary>
	[Description("传阅")]
	Circulate = 8,
	/// <summary>
	/// 阅办
	/// </summary>
	[Description("阅办")]
	CirculateAdopt = 0x10,
	/// <summary>
	/// 退回
	/// </summary>
	[Description("退回")]
	Return = 0x400,
	/// <summary>
	/// 取回
	/// </summary>
	[Description("取回")]
	Retrieve = 0x800,
	/// <summary>
	/// 挂起
	/// </summary>
	[Description("挂起")]
	Suspended = 0x1000,
	/// <summary>
	/// 终止
	/// </summary>
	[Description("终止")]
	Terminated = 0x2000,
	/// <summary>
	/// 会签
	/// </summary>
	[Description("会签")]
	Countersign = 0x8000
}
