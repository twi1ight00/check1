using System;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Workflow.Extend.Application.DTO.Parameters;

/// <summary>
/// 我的待办
/// </summary>
public class MyWorkItemParameter : QueryObjectBase
{
	/// <summary>
	/// 流程名称
	/// </summary>
	[ParameterConfig("INSTANCE_NAME", "string", " Like ")]
	public string INSTANCE_NAME { get; set; }

	/// <summary>
	/// 申请人
	/// </summary>
	[ParameterConfig("START_USER_NAME", "string", " Like ")]
	public string START_USER_NAME { get; set; }

	/// <summary>
	/// 提交人
	/// </summary>
	[ParameterConfig("SENDER_USER_NAME", "string", " Like ")]
	public string SENDER_USER_NAME { get; set; }

	/// <summary>
	/// 发起时间起
	/// </summary>
	[ParameterConfig("START_TIME", "date", " >= ")]
	public DateTime? START_TIME { get; set; }

	/// <summary>
	/// 发起时间至
	/// </summary>
	[ParameterConfig("START_TIME", "date", " <= ")]
	public DateTime? END_TIME { get; set; }

	/// <summary>
	/// 待办处理人
	/// </summary>
	[ParameterConfig("USER_ID", "guid", " = ")]
	public Guid? USER_ID { get; set; }

	/// <summary>
	/// 授权待办处理人
	/// </summary>
	[ParameterConfig("Proxy_USER_ID", "guid", " = ")]
	public Guid? Proxy_USER_ID { get; set; }

	/// <summary>
	/// 申请部门
	/// </summary>
	[ParameterConfig("ORG_ID", "guid", " = ")]
	public Guid? ORG_ID { get; set; }

	/// <summary>
	/// 申请部门
	/// </summary>
	[ParameterConfig("ORG_NAME", "string", " Like ")]
	public string ORG_NAME { get; set; }

	/// <summary>
	/// 操作日期起
	/// </summary>
	[ParameterConfig("SEND_TIME", "date", " >= ")]
	public DateTime? SEND_TIME_START { get; set; }

	/// <summary>
	/// 操作日期至
	/// </summary>
	[ParameterConfig("SEND_TIME", "date", " <= ")]
	public DateTime? SEND_TIME_END { get; set; }

	/// <summary>
	/// 单据类型
	/// </summary>
	[ParameterConfig("FORM_ID", "guid", " = ")]
	public Guid? FORM_ID { get; set; }

	/// <summary>
	/// 版本
	/// </summary>
	[ParameterConfig("VERSION_ID", "guid", " = ")]
	public Guid? VERSION_ID { get; set; }
}
