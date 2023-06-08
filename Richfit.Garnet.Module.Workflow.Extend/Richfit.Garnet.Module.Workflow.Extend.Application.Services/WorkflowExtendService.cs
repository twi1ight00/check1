using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.Components;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Extend.Application.DTO.Parameters;

namespace Richfit.Garnet.Module.Workflow.Extend.Application.Services;

/// <summary>
/// 工作流服务 
/// </summary>
public class WorkflowExtendService : ServiceBase
{
	/// <summary>
	/// 获取
	/// </summary>
	/// <param name="instanceId">实例ID</param>
	/// <param name="handleResult">处理结果</param>
	/// <returns>WF_INSTANCEDTO</returns>
	public WF_INSTANCEDTO GetInstanceById(Guid instanceId, int? handleResult = null)
	{
		WF_INSTANCEDTO dtoinstance = new InstanceService().GetInstanceById(instanceId).AdaptAsDTO<WF_INSTANCEDTO>();
		dtoinstance.WF_WORKITEM.RemoveAll(delegate(WF_WORKITEMDTO x)
		{
			int result2;
			if (!(x.ISDEL == 1m))
			{
				decimal? hANDLE_RESULT2 = x.HANDLE_RESULT;
				result2 = ((hANDLE_RESULT2.GetValueOrDefault() == 16384m && hANDLE_RESULT2.HasValue) ? 1 : 0);
			}
			else
			{
				result2 = 1;
			}
			return (byte)result2 != 0;
		});
		if (handleResult.HasValue)
		{
			dtoinstance.WF_WORKITEM.RemoveAll(delegate(WF_WORKITEMDTO x)
			{
				decimal? wORKITEM_RUN_STATE = x.WORKITEM_RUN_STATE;
				int? num = handleResult;
				return wORKITEM_RUN_STATE.GetValueOrDefault() != (decimal)num.GetValueOrDefault() || wORKITEM_RUN_STATE.HasValue != num.HasValue;
			});
		}
		dtoinstance.WF_WORKITEM = dtoinstance.WF_WORKITEM.OrderBy((WF_WORKITEMDTO a) => a.CREATETIME).ToList();
		foreach (WF_WORKITEMDTO workItem in dtoinstance.WF_WORKITEM)
		{
			workItem.ACTIVITY_TYPE = WorkflowCacheManager.GetActivityById(workItem.ACTIVITY_ID).ACTIVITY_TYPE;
			workItem.WF_WORKITEM_HANDLER.RemoveAll(delegate(WF_WORKITEM_HANDLERDTO x)
			{
				int result;
				if (!(x.ISDEL == 1m))
				{
					decimal? hANDLE_RESULT = x.HANDLE_RESULT;
					result = ((hANDLE_RESULT.GetValueOrDefault() == 16384m && hANDLE_RESULT.HasValue) ? 1 : 0);
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			});
			workItem.WF_WORKITEM_HANDLER = workItem.WF_WORKITEM_HANDLER.OrderBy((WF_WORKITEM_HANDLERDTO a) => a.HANDLE_TIME).ToList();
		}
		return dtoinstance;
	}

	/// <summary>
	/// 获取工作项
	/// </summary>
	/// <param name="workItemId">工作项</param>
	/// <returns>WF_WORKITEMDTO</returns>
	public WF_WORKITEMDTO GetWorkItemById(Guid workItemId)
	{
		return new InstanceService().GetWorkItemById(workItemId).AdaptAsDTO<WF_WORKITEMDTO>();
	}

	/// <summary>
	/// 获取已办流程
	/// </summary>
	/// <param name="parameter">查询参数</param>
	/// <returns><see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /></returns>
	public QueryResult<WF_INSTANCEDTO> GetMyWorkflowByParameter(MyWorkflowParameter parameter)
	{
		if (parameter.IsNull())
		{
			return new QueryResult<WF_INSTANCEDTO>();
		}
		return SqlQueryResult<WF_INSTANCEDTO>("GetMyWorkflowByParameter", parameter.ToQueryCondition());
	}

	/// <summary>
	/// 获取已办流程
	/// </summary>
	/// <param name="parameter">查询参数</param>
	/// <returns><see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /></returns>
	public QueryResult<WF_INSTANCEDTO> GetMyWorkflow(WF_WORKITEMDTO dto)
	{
		InstanceService instanceService = new InstanceService();
		return SqlQueryPager<WF_INSTANCEDTO>("GetMyWorkflow", dto);
	}

	/// <summary>
	/// 获取已办流程
	/// </summary>
	/// <param name="parameter">查询参数</param>
	/// <returns><see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /></returns>
	public QueryResult<WF_INSTANCEDTO> GetMyWorkflowForMobile(WF_WORKITEMDTO dto)
	{
		InstanceService instanceService = new InstanceService();
		QueryResult<WF_INSTANCEDTO> result = SqlQueryPager<WF_INSTANCEDTO>("GetMyWorkflowForMobile", dto);
		foreach (WF_INSTANCEDTO item in result.List)
		{
			decimal? rUN_STATE = item.RUN_STATE;
			if (rUN_STATE.GetValueOrDefault() == 0m && rUN_STATE.HasValue)
			{
				List<NEXT_ACTIVITY> backactivitys = new List<NEXT_ACTIVITY>();
				instanceService.GetBackActivity(item.INSTANCE_ID.Value, item.ACTIVITY_ID.Value, dto.USER_ID, 1, ref backactivitys);
				if (backactivitys.Count <= 0)
				{
					item.IsGoBack = false;
					continue;
				}
				item.IsGoBack = true;
				item.backactivitys = backactivitys;
			}
			else
			{
				item.IsGoBack = false;
			}
		}
		return result;
	}

	/// <summary>
	/// 获取已办流程
	/// </summary>
	/// <param name="parameter">查询参数</param>
	/// <returns><see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /></returns>
	public QueryResult<WF_INSTANCEDTO> GetMyWorkflow_Advance(WF_WORKITEMDTO dto)
	{
		InstanceService instanceService = new InstanceService();
		return SqlQueryPager<WF_INSTANCEDTO>("GetMyWorkflow_Advance", dto);
	}

	/// <summary>
	/// 获取待办事项
	/// </summary>
	/// <param name="parameter">查询参数</param>
	public QueryResult<WF_WORKITEMDTO> GetWorkItemPager(WF_WORKITEMDTO dto)
	{
		return SqlQueryPager<WF_WORKITEMDTO>((dto.SearchType == 0) ? "GetWorkItemPager" : "GetWorkItemPager_Advance", dto);
	}

	/// <summary>
	/// 获取待办事项
	/// </summary>
	/// <param name="parameter">查询参数</param>
	public QueryResult<WF_WORKITEMDTO> GetWorkItemPager(WF_WORKITEMDTO dto, bool isMobile)
	{
		return SqlQueryPager<WF_WORKITEMDTO>("GetWorkItemPagerRuiXin", dto);
	}

	private string HttpPost(string Url, string postDataStr)
	{
		try
		{
			string ret = string.Empty;
			Encoding dataEncode = Encoding.Default;
			byte[] byteArray = dataEncode.GetBytes(postDataStr);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(Url));
			webReq.Method = "POST";
			webReq.ContentType = "application/x-www-form-urlencoded";
			webReq.Timeout = 8000;
			webReq.ContentLength = byteArray.Length;
			Stream newStream = webReq.GetRequestStream();
			newStream.Write(byteArray, 0, byteArray.Length);
			newStream.Close();
			HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
			StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
			ret = sr.ReadToEnd();
			sr.Close();
			response.Close();
			newStream.Close();
			return ret;
		}
		catch (Exception ex)
		{
			ServiceBase.log.Debug("请问老系统数据发生问题，" + ex.Message);
			return null;
		}
	}

	/// <summary>
	/// 获取待办事项
	/// </summary>
	/// <param name="parameter">查询参数</param>
	public QueryResult<WF_WORKITEMDTO> GetWorkItemPager_Advance(WF_WORKITEMDTO dto)
	{
		return SqlQueryPager<WF_WORKITEMDTO>("GetWorkItemPager_Advance", dto);
	}

	/// <summary>
	/// 流程监控
	/// </summary>
	/// <param name="parameter">查询参数</param>
	/// <returns><see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /></returns>
	public QueryResult<WF_INSTANCEDTO> GetWorkflowMonitorByParameter(WorkflowMonitorParameter parameter)
	{
		InstanceService instanceService = new InstanceService();
		if (parameter.IsNull())
		{
			return new QueryResult<WF_INSTANCEDTO>();
		}
		QueryResult<WF_INSTANCEDTO> result = SqlQueryPager<WF_INSTANCEDTO>("GetWorkflowMonitorByParameterSimple", parameter);
		foreach (WF_INSTANCEDTO item in result.List)
		{
		}
		return result;
	}

	/// <summary>
	/// 流程监控
	/// </summary>
	/// <param name="parameter">查询参数</param>
	/// <returns><see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /></returns>
	public QueryResult<WF_INSTANCEDTO> GetWorkflowMonitorByParameterAdvance(WorkflowMonitorParameter parameter)
	{
		InstanceService instanceService = new InstanceService();
		if (parameter.IsNull())
		{
			return new QueryResult<WF_INSTANCEDTO>();
		}
		return SqlQueryPager<WF_INSTANCEDTO>("GetWorkflowMonitorByParameterAdvance", parameter);
	}

	/// <summary>
	/// 获取流程查询
	/// </summary>
	/// <param name="parameter">参数</param>
	/// <returns><see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /></returns>
	public QueryResult<WF_INSTANCEDTO> GetWorkflowSearch(WorkflowSearchParameter parameter)
	{
		if (parameter.IsNull())
		{
			return new QueryResult<WF_INSTANCEDTO>();
		}
		return SqlQueryResult<WF_INSTANCEDTO>("GetWorkflowSearchByParameter", parameter.ToQueryCondition());
	}

	/// <summary>
	/// 获取我的申请
	/// </summary>
	/// <param name="parameter">参数</param>
	/// <returns><see cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult`1" /></returns>
	public QueryResult<WF_INSTANCEDTO> GetMyApply(MyApplyParameter parameter)
	{
		if (parameter.IsNull())
		{
			return new QueryResult<WF_INSTANCEDTO>();
		}
		return SqlQueryResult<WF_INSTANCEDTO>("GetMyApplyByParameter", parameter.ToQueryCondition());
	}

	/// <summary>
	/// 获取实例活动参与人
	/// </summary>
	/// <param name="instanceId">实例ID</param>
	/// <returns><see cref="T:System.Collections.Generic.IList`1" /></returns>
	public IList<WF_INSTANCE_ACTIVITYDTO> GetInstanceActivityByInstanceId(Guid instanceId)
	{
		List<WF_INSTANCE_ACTIVITYDTO> returnValue = new List<WF_INSTANCE_ACTIVITYDTO>();
		List<WF_INSTANCE_ACTIVITY> value = new InstanceParticipantService().GetInstanceActivityByInstanceId(instanceId);
		value.ForEach(delegate(WF_INSTANCE_ACTIVITY x)
		{
			returnValue.Add(x.AdaptAsDTO<WF_INSTANCE_ACTIVITYDTO>());
		});
		return returnValue;
	}

	/// <summary>
	/// 保存实例活动参与人
	/// </summary>
	/// <param name="dto">数据</param>
	public void SaveInstanceActivity(IList<WF_INSTANCE_ACTIVITYDTO> dto)
	{
		List<WF_INSTANCE_ACTIVITY> saveValue = new List<WF_INSTANCE_ACTIVITY>();
		dto.ForEach(delegate(WF_INSTANCE_ACTIVITYDTO x)
		{
			saveValue.Add(x.AdaptAsEntity<WF_INSTANCE_ACTIVITY>());
		});
		new InstanceParticipantService().SaveInstanceActivity(saveValue);
	}

	public IList<WF_PACKAGEDTO> GetAllPackage()
	{
		return ServiceLocator.Instance.GetService<IPackageService>().GetPackageByParameter(new QueryCondition()).List;
	}

	public QueryResult<WF_INSTANCEDTO> GetMyApplication(WF_WORKITEMDTO dto)
	{
		return SqlQueryPager<WF_INSTANCEDTO>("GetMyApplication", dto);
	}

	public QueryResult<WF_INSTANCEDTO> GetMyApproval(WF_WORKITEMDTO dto)
	{
		return SqlQueryPager<WF_INSTANCEDTO>("GetMyApproval", dto);
	}
}
