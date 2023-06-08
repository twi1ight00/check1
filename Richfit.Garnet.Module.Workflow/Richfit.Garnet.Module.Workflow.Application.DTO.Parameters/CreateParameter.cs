using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 创建工作流参数
/// </summary>
public class CreateParameter
{
	/// <summary>
	/// 当前用户
	/// </summary>
	public User USER_ID { get; set; }

	/// <summary>
	/// 实例ID
	/// </summary>
	public Guid INSTANCE_ID { get; set; }

	/// <summary>
	/// 实例标题
	/// </summary>
	public string INSTANCE_NAME { get; set; }

	/// <summary>
	/// 实例表名
	/// </summary>
	public string TABLE_NAME { get; set; }

	/// <summary>
	/// 模板ID
	/// </summary>
	public Guid TEMPLATE_ID { get; set; }

	/// <summary>
	/// 表单ID
	/// </summary>
	public Guid FORM_ID { get; set; }

	/// <summary>
	/// 父实例ID
	/// </summary>
	public Guid? PARENT_INSTANCE_ID { get; set; }

	/// <summary>
	/// 父活动ID
	/// </summary>
	public Guid? PARENT_ACTIVITY_ID { get; set; }
}
