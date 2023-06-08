using System;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Workflow.Extend.Application.DTO.Parameters;

/// <summary>
/// 我的申请
/// </summary>
public class MyApplyParameter : QueryObjectBase
{
	private DateTime? end_time;

	/// <summary>
	/// 流程名称
	/// </summary>
	[ParameterConfig("INSTANCE_NAME", "string", " Like ")]
	public string INSTANCE_NAME { get; set; }

	/// <summary>
	/// 流程状态
	/// </summary>
	[ParameterConfig("RUN_STATE", "number", " = ")]
	public int? RUN_STATE { get; set; }

	/// <summary>
	/// 发起时间起
	/// </summary>
	[ParameterConfig("START_TIME", "date", " >= ")]
	public DateTime? START_TIME { get; set; }

	/// <summary>
	/// 至
	/// </summary>
	[ParameterConfig("START_TIME", "date", " <= ")]
	public DateTime? END_TIME
	{
		get
		{
			return end_time;
		}
		set
		{
			if (value.HasValue)
			{
				end_time = value.Value.AddDays(1.0);
			}
		}
	}

	/// <summary>
	/// 申请人
	/// </summary>
	[ParameterConfig("START_USER_ID", "guid", " = ")]
	public Guid START_USER_ID { get; set; }

	/// <summary>
	/// 业务单据
	/// </summary>
	[ParameterConfig("FORM_ID", "guid", " = ")]
	public Guid? FORM_ID { get; set; }

	/// <summary>
	/// 版本
	/// </summary>
	[ParameterConfig("VERSION_ID", "guid", " = ")]
	public Guid? VERSION_ID { get; set; }
}
