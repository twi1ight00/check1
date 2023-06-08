namespace Richfit.Garnet.Module.Workflow.Application.Enums;

/// <summary>
/// 节点类型
/// </summary>
public enum ACTIVITY_TYPE
{
	/// <summary>
	/// 开始节点
	/// </summary>
	Start = -2,
	/// <summary>
	/// 起草节点
	/// </summary>
	Drafting = -1,
	/// <summary>
	/// 审批节点（包含并行和串行两种模式）
	/// </summary>
	Approval = 0,
	/// <summary>
	/// 自由节点
	/// </summary>
	Freedom = 1,
	/// <summary>
	/// 分支
	/// </summary>
	Branching = 3,
	/// <summary>
	/// 合并
	/// </summary>
	Merging = 4,
	/// <summary>
	/// 子流程
	/// </summary>
	Subprocesses = 5,
	/// <summary>
	/// 条件
	/// </summary>
	Condition = 6,
	/// <summary>
	/// 结束
	/// </summary>
	End = 100
}
