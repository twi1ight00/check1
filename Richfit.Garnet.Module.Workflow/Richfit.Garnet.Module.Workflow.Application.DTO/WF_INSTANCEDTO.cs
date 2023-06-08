using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Components;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_INSTANCEDTO : DTOBase
{
	public Guid? INSTANCE_ID { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public string TEMPLATE_NAME { get; set; }

	public string IMGURL { get; set; }

	public Guid FORM_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public string INSTANCE_NAME { get; set; }

	public string TABLE_NAME { get; set; }

	public decimal? RUN_STATE { get; set; }

	public Guid START_USER_ID { get; set; }

	public string START_USER_NAME { get; set; }

	public Guid PARENT_INSTANCE_ID { get; set; }

	public DateTime? START_TIME { get; set; }

	public DateTime? FINISH_TIME { get; set; }

	public Guid PARENT_ACTIVITY_ID { get; set; }

	public decimal? CLIENT_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string WORKITEM_NAME { get; set; }

	public string SENDER_USER_NAME { get; set; }

	public string RUN_STATE_NAME { get; set; }

	public decimal? ACTIVITY_TYPE { get; set; }

	public Guid? ACTIVITY_ID { get; set; }

	public string ACTIVITY_NAME { get; set; }

	public string FORM_DATA { get; set; }

	public DateTime? SEND_TIME { get; set; }

	public List<WF_WORKITEMDTO> WF_WORKITEM { get; set; }

	public Guid? WORKITEM_ID { get; set; }

	public Guid? TEMPLATE_VERSION_ID { get; set; }

	public DateTime? CUR_STOP_TIME { get; set; }

	public string CUR_STOP_TIME_DISPLAY
	{
		get
		{
			if (CUR_STOP_TIME.HasValue)
			{
				TimeSpan ts = DateTime.Now - CUR_STOP_TIME.Value;
				string[] ss = $"{ts:G}".Split(':');
				string result = "";
				if (Convert.ToInt32(ss[0]) != 0)
				{
					result = result + ss[0] + "天";
				}
				if (Convert.ToInt32(ss[1]) == 0)
				{
					if (result != "")
					{
						result = result + ss[1] + "小时";
					}
				}
				else
				{
					result = result + ss[1] + "小时";
				}
				return result + ss[2] + "分钟";
			}
			return "";
		}
	}

	public string CUR_HANDLER
	{
		get
		{
			decimal? rUN_STATE = RUN_STATE;
			if (rUN_STATE.GetValueOrDefault() != 0m || !rUN_STATE.HasValue)
			{
				return string.Empty;
			}
			if (!WORKITEM_ID.HasValue)
			{
				return string.Empty;
			}
			IEnumerable<WF_WORKITEM_HANDLER> handlers = new InstanceService().GetWorkItemById(WORKITEM_ID.Value).WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a, long b)
			{
				decimal? hANDLE_RESULT = a.HANDLE_RESULT;
				return hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue;
			});
			string users = string.Empty;
			foreach (WF_WORKITEM_HANDLER handler in handlers)
			{
				if (users.Length > 0)
				{
					users += ",";
				}
				users += handler.USER_NAME;
			}
			return users;
		}
	}

	public bool IsGoBack { get; set; }

	public List<NEXT_ACTIVITY> backactivitys { get; set; }

	/// <summary>
	/// 在线公文
	/// </summary>
	public string FILE_NAME { get; set; }

	/// <summary>
	/// 在线公文
	/// </summary>
	public string SUBJECT { get; set; }

	public int? ATTCOUNT { get; set; }

	public string CURRENT_ACTIVITY { get; set; }

	public string CURRENT_HANDLER_ID { get; set; }

	public string CURRENT_HANDLER_NAME { get; set; }

	public List<WF_INSTANCE_ACTIVITYDTO> WF_INSTANCE_ACTIVITY { get; set; }
}
