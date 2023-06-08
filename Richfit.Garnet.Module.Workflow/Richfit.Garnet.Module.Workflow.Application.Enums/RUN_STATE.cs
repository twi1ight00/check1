namespace Richfit.Garnet.Module.Workflow.Application.Enums;

/// <summary>
/// 运行状态枚举
/// </summary>
public enum RUN_STATE
{
	/// <summary>
	/// 运行中
	/// </summary>
	Running = 0,
	/// <summary>
	/// 完成
	/// </summary>
	Finished = 2,
	/// <summary>
	/// 挂起
	/// </summary>
	Suspended = 0x1000,
	/// <summary>
	/// 终止
	/// </summary>
	Terminated = 0x2000
}
