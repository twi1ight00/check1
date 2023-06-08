using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 流程查询
/// </summary>
public class WorkflowMonitorParameter : DTOBase
{
	private DateTime? end_time;

	private DateTime? handle_time_end;

	/// <summary>
	/// 流程名称
	/// </summary>      
	public string INSTANCE_NAME { get; set; }

	/// <summary>
	/// 流程状态
	/// </summary>     
	public int? RUN_STATE { get; set; }

	/// <summary>
	/// 申请人
	/// </summary>      
	public string START_USER_NAME { get; set; }

	/// <summary>
	/// 申请部门
	/// </summary>        
	public string ORG_NAME { get; set; }

	/// <summary>
	/// 申请部门
	/// </summary>        
	public Guid? ORG_ID { get; set; }

	public Guid? USER_ID { get; set; }

	/// <summary>
	/// 申请时间起
	/// </summary>      
	public DateTime? START_TIME { get; set; }

	/// <summary>
	/// 申请时间至
	/// </summary>
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
	public string HANDLE_USER_NAME { get; set; }

	public string CURRENT_HANDLER_NAME { get; set; }

	/// <summary>
	/// 审核时间起
	/// </summary>
	public DateTime? HANDLE_TIME_START { get; set; }

	/// <summary>
	/// 审核时间至
	/// </summary>
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
	public Guid? VERSION_ID { get; set; }

	public Guid? PACKAGE_ID { get; set; }

	public Guid? TEMPLATE_ID { get; set; }

	public decimal? ISSUPER_USER { get; set; }
}
