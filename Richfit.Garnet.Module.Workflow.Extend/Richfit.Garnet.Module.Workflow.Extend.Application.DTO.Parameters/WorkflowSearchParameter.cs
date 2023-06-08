using System;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Workflow.Extend.Application.DTO.Parameters;

/// <summary>
/// 流程查询参数
/// </summary>
public class WorkflowSearchParameter : QueryObjectBase
{
	private DateTime? end_time;

	private DateTime? handle_time_end;

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
	/// 申请人
	/// </summary>
	[ParameterConfig("START_USER_NAME", "string", " Like ")]
	public string START_USER_NAME { get; set; }

	/// <summary>
	/// 申请部门
	/// </summary>
	[ParameterConfig("ORG_NAME", "string", " Like ")]
	public string ORG_NAME { get; set; }

	/// <summary>
	/// 申请时间起
	/// </summary>
	[ParameterConfig("START_TIME", "date", " >= ")]
	public DateTime? START_TIME { get; set; }

	/// <summary>
	/// 申请时间至
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
	/// 审核人
	/// </summary>
	[ParameterConfig("HANDLE_USER_NAME", "string", " Like ")]
	public string HANDLE_USER_NAME { get; set; }

	/// <summary>
	/// 审核时间起
	/// </summary>
	[ParameterConfig("HANDLE_TIME", "date", " >= ")]
	public DateTime? HANDLE_TIME_START { get; set; }

	/// <summary>
	/// 审核时间至
	/// </summary>
	[ParameterConfig("HANDLE_TIME", "date", " <= ")]
	public DateTime? HANDLE_TIME_END
	{
		get
		{
			return handle_time_end;
		}
		set
		{
			if (value.HasValue)
			{
				handle_time_end = value.Value.AddDays(1.0);
			}
		}
	}

	/// <summary>
	/// 版本
	/// </summary>
	[ParameterConfig("VERSION_ID", "guid", " = ")]
	public Guid? VERSION_ID { get; set; }
}
