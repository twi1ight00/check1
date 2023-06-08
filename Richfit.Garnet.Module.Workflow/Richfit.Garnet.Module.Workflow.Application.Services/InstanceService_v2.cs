#define DEBUG
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Dapper;
using Richfit.Garnet.Common;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Base.Infrastructure.TimeZone;
using Richfit.Garnet.Module.Fundation.Domain.Models;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.Components;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Migration;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

public class InstanceService_v2 : ServiceBase
{
	private readonly IRepository<WF_INSTANCE> repositoryInstance = null;

	private readonly IRepository<WF_TEMPLATE> repositoryTemplate = null;

	private readonly IRepository<WF_PACKAGE> packageRepository = null;

	private readonly IRepository<WF_INSTANCE_ACTIVITY> repositoryInstanceActivity = null;

	private static ThreadLocal<Guid> currentSessionToken = new ThreadLocal<Guid>();

	private SqlRepository sqlRepository = ServiceLocator.Instance.GetService<SqlRepository>();

	private bool isSave = false;

	private WF_ACTIVITY wfActivity;

	private IRunWorkflow runWorkflow;

	private WF_TEMPLATE template;

	private WF_PACKAGE package;

	private bool needSave = false;

	private IDbConnection connection;

	private IDbTransaction transaction;

	private IList<SYS_USERDTO> userList;

	private IList<SYS_USER_ORG> userOrg;

	private IList<SYS_ORGDTO> orgList;

	private IList<Guid> errorList;

	private IList<WF_RULE> routes;

	/// <summary>
	/// 构造
	/// </summary> 
	public InstanceService_v2()
	{
		repositoryInstance = ServiceLocator.Instance.GetService<IRepository<WF_INSTANCE>>();
		repositoryTemplate = ServiceLocator.Instance.GetService<IRepository<WF_TEMPLATE>>();
		packageRepository = ServiceLocator.Instance.GetService<IRepository<WF_PACKAGE>>();
		repositoryInstanceActivity = ServiceLocator.Instance.GetService<IRepository<WF_INSTANCE_ACTIVITY>>();
	}

	/// <summary>
	/// 创建流程
	/// </summary>
	/// <param name="user">用户DTO</param>
	/// <param name="instanceId">当前实例ID</param>
	/// <param name="instanceTitle">实例名称</param>
	/// <param name="instanceTableName">实例表名称</param>
	/// <param name="templateId">模板ID</param>
	/// <param name="formId">表单ID</param>
	/// <param name="parentInstanceId">父模板ID</param>
	/// <param name="parentActivityId">父活动id</param>
	/// <returns>工作项ID</returns>
	public WF_INSTANCE CreateWorkflow(WF_INSTANCE instance, SubmitDTO submitDto)
	{
		if (instance.TEMPLATE_ID == Guid.Empty || !instance.TEMPLATE_ID.HasValue)
		{
			throw new CustomCodeException("模板ID不能为空");
		}
		if (1 == 0)
		{
			string[] array = new string[1];
			array[0] = "您没有创建此流程的权限";
			throw new ValidationException("SystemManagement.Public.E_0001", array);
		}
		instance.INSTANCE_ID = Guid.NewGuid();
		init(instance);
		WF_ACTIVITY startActivity = template.WF_ACTIVITY.SingleOrDefault(delegate(WF_ACTIVITY a)
		{
			decimal? aCTIVITY_TYPE = a.ACTIVITY_TYPE;
			return aCTIVITY_TYPE.GetValueOrDefault() == -1m && aCTIVITY_TYPE.HasValue;
		});
		instance.INSTANCE_NAME = runWorkflow.InstanceName(template.TEMPLATE_NAME, submitDto.FormData);
		instance.START_TIME = DateTime.Now;
		instance.RUN_STATE = 0m;
		instance.TEMPLATE_NAME = template.TEMPLATE_NAME;
		instance.PACKAGE_ID = package.PACKAGE_ID;
		instance.PACKAGE_NAME = package.PACKAGE_NAME;
		UserSessionInfo userInfo = SessionContext.UserInfo;
		string orgName = OrgUserCacheManager.GetOrgByKey(userInfo.BelongToOrgID).ORG_NAME;
		submitDto.Handler = new User
		{
			CURRENT_ORG_ID = userInfo.BelongToOrgID,
			CURRENT_ORG_NAME = orgName,
			PROXY_ORG_ID = userInfo.BelongToOrgID,
			PROXY_ORG_NAME = orgName,
			CURRENT_USER_ID = instance.START_USER_ID,
			CURRENT_USER_NAME = instance.START_USER_NAME,
			PROXY_USER_ID = instance.START_USER_ID,
			PROXY_USER_NAME = instance.START_USER_NAME
		};
		WF_RULE startRule = template.WF_RULE.SingleOrDefault(delegate(WF_RULE a)
		{
			int result;
			if (a.TO_ACTIVITY_ID == startActivity.ACTIVITY_ID && a.ISDEL == 0m)
			{
				decimal? rULE_TYPE = a.RULE_TYPE;
				result = ((rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		});
		WF_WORKITEM workItem = CreateWorkItem(instance, startActivity, startRule.RULE_ID, submitDto.Handler, new List<User> { submitDto.Handler });
		instance.WF_WORKITEM.Add(workItem);
		submitDto.InstanceId = instance.INSTANCE_ID;
		submitDto.InstanceId = instance.INSTANCE_ID;
		submitDto.WorkItemId = workItem.WORKITEM_ID;
		repositoryInstance.Add(instance);
		return Submit(instance, template, submitDto);
	}

	private void init(WF_INSTANCE instance)
	{
		if (runWorkflow == null)
		{
			template = WorkflowCacheManager.GetTemplateById(instance.TEMPLATE_ID.Value).AdaptAsEntity<WF_TEMPLATE>();
			package = packageRepository.GetByKey(template.PACKAGE_ID);
			Type t = Type.GetType($"{template.TEMPLATE_CODE_PATH},Richfit.Garnet.Module.Workflow.Form");
			runWorkflow = (IRunWorkflow)Activator.CreateInstance(t);
			runWorkflow.InstanceId = instance.INSTANCE_ID;
		}
	}

	public WF_INSTANCE Submit(SubmitDTO submitDto)
	{
		WF_INSTANCE currentInstance = repositoryInstance.GetByKey(submitDto.InstanceId);
		if (1 == 0)
		{
			string[] array = new string[1];
			array[0] = "无权限操作";
			throw new ValidationException("SystemManagement.Public.E_0001", array);
		}
		init(currentInstance);
		return Submit(currentInstance, template, submitDto);
	}

	private WF_INSTANCE Submit(WF_INSTANCE currentInstance, WF_TEMPLATE template, SubmitDTO submitDto)
	{
		wfActivity = submitDto.CurrentActivity;
		this.template = template;
		decimal? rUN_STATE = currentInstance.RUN_STATE;
		if (rUN_STATE.GetValueOrDefault() != 0m || !rUN_STATE.HasValue)
		{
			rUN_STATE = currentInstance.RUN_STATE;
			if (!(rUN_STATE.GetValueOrDefault() == 4096m) || !rUN_STATE.HasValue || submitDto.HandleResult != 0)
			{
				throw new ValidationException("SystemManagement.Public.E_0001", new string[1] { "当前流程异常" });
			}
		}
		if (submitDto.HandleResult == HANDLE_RESULT.Terminated || submitDto.HandleResult == HANDLE_RESULT.Suspended || submitDto.HandleResult == HANDLE_RESULT.None)
		{
			try
			{
				if (submitDto.HandleResult == HANDLE_RESULT.Terminated)
				{
					currentInstance.ISDEL = 1m;
				}
				if (!runWorkflow.SpecialOperation(template, currentInstance, submitDto.HandleResult))
				{
					throw new ValidationException("SystemManagement.Public.E_0001", new string[1] { "终止流程时更新业务数据出错" });
				}
				currentInstance.RUN_STATE = (int)submitDto.HandleResult;
			}
			catch (Exception)
			{
				throw;
			}
		}
		else
		{
			WF_WORKITEM currentWorkItem = currentInstance.WF_WORKITEM.SingleOrDefault((WF_WORKITEM a) => a.WORKITEM_ID == submitDto.WorkItemId);
			if (submitDto.HandleResult != HANDLE_RESULT.Retrieve)
			{
				rUN_STATE = currentWorkItem.WORKITEM_RUN_STATE;
				if (rUN_STATE.GetValueOrDefault() != 0m || !rUN_STATE.HasValue)
				{
					throw new ValidationException("SystemManagement.Public.E_0001", new string[1] { "当前工作项已被处理" });
				}
			}
			WF_ACTIVITY currentActivity = WorkflowCacheManager.GetActivityById(currentWorkItem.ACTIVITY_ID).AdaptAsEntity<WF_ACTIVITY>();
			if (submitDto.HandleResult == HANDLE_RESULT.Adopt)
			{
				runWorkflow.PrHandler(template, currentInstance, currentActivity, submitDto.FormData);
			}
			switch (submitDto.HandleResult)
			{
			case HANDLE_RESULT.None:
				currentInstance.RUN_STATE = 0m;
				break;
			case HANDLE_RESULT.Circulate:
			{
				WF_WORKITEM newItem = CreateWorkItem(currentInstance, currentActivity, Guid.Empty, submitDto.Handler, submitDto.Drivers.NextHandler, submitDto.HandleResult, currentWorkItem.WORKITEM_ID);
				currentInstance.WF_WORKITEM.Add(newItem);
				runWorkflow.SendMessage(currentInstance, newItem, currentActivity, submitDto.Handler);
				runWorkflow.SendToMsg(currentInstance, newItem, currentActivity, submitDto.Handler);
				break;
			}
			case HANDLE_RESULT.CountersignAgree:
			case HANDLE_RESULT.CountersignRefuse:
			{
				if (!FinishWorkItem(currentActivity, currentWorkItem, submitDto.Handler, submitDto.HandleResult, submitDto.Suggestion, FINISH_TYPE.All))
				{
					break;
				}
				WF_WORKITEM old = GetStartWorkItem(template, currentInstance, currentWorkItem.WORKITEM_ID);
				IEnumerable<WF_WORKITEM_HANDLER> query = old.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
				{
					decimal? hANDLE_RESULT2 = a.HANDLE_RESULT;
					return hANDLE_RESULT2.GetValueOrDefault() == 2m && hANDLE_RESULT2.HasValue && a.ISDEL == 0m;
				});
				WF_ACTIVITY activity = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == old.ACTIVITY_ID);
				List<User> toUser = new List<User>();
				foreach (WF_WORKITEM_HANDLER handler in query)
				{
					rUN_STATE = handler.HANDLE_RESULT;
					if (rUN_STATE.GetValueOrDefault() == 2m && rUN_STATE.HasValue)
					{
						toUser.Add(new User
						{
							CURRENT_USER_ID = handler.HANDLE_USER_ID.Value,
							CURRENT_USER_NAME = handler.HANDLE_USER_NAME
						});
					}
				}
				WF_WORKITEM newItem = CreateWorkItem(currentInstance, activity, Guid.Empty, submitDto.Handler, toUser, HANDLE_RESULT.None, currentWorkItem.WORKITEM_ID);
				currentInstance.WF_WORKITEM.Add(newItem);
				runWorkflow.SendMessage(currentInstance, newItem, activity, submitDto.Handler);
				runWorkflow.SendToMsg(currentInstance, newItem, activity, submitDto.Handler);
				break;
			}
			case HANDLE_RESULT.CirculateAdopt:
				FinishWorkItem(currentActivity, currentWorkItem, submitDto.Handler, submitDto.HandleResult, submitDto.Suggestion, FINISH_TYPE.All);
				break;
			case HANDLE_RESULT.Adopt:
				if (FinishWorkItem(currentActivity, currentWorkItem, submitDto.Handler, submitDto.HandleResult, submitDto.Suggestion))
				{
					HandleInstance(currentInstance, submitDto.CurrentActivity, currentWorkItem, submitDto.Handler, submitDto.Drivers, submitDto.FormData, submitDto.Suggestion, submitDto.RuleExpress);
				}
				else
				{
					if (isSave)
					{
						break;
					}
					if (Bit.pro((long)currentActivity.STATUS.Value, "0|2") != 1)
					{
						rUN_STATE = currentActivity.ACTIVITY_TYPE;
						if (!(rUN_STATE.GetValueOrDefault() == -1m) || !rUN_STATE.HasValue)
						{
							break;
						}
					}
					isSave = true;
					WF_ACTIVITY nextActivity = GetNextActivity(submitDto.Drivers.RuleId);
					runWorkflow.SaveData(template, currentInstance, nextActivity, submitDto.FormData);
					currentWorkItem.WF_DATA_HISTORY.Add(new WF_DATA_HISTORY
					{
						FORM_DATA = submitDto.FormData,
						WORKITEM_ID = currentWorkItem.WORKITEM_ID,
						HISTORY_ID = Guid.NewGuid()
					});
				}
				break;
			case HANDLE_RESULT.Return:
			{
				WF_ACTIVITY nextAcvity = GetNextActivity(submitDto.Drivers.RuleId);
				WF_WORKITEM targetItem = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
				{
					int result;
					if (a.ISDEL == 0m)
					{
						decimal? hANDLE_RESULT3 = a.HANDLE_RESULT;
						if (hANDLE_RESULT3.GetValueOrDefault() == 2m && hANDLE_RESULT3.HasValue)
						{
							result = ((a.ACTIVITY_ID == nextAcvity.ACTIVITY_ID) ? 1 : 0);
							goto IL_0054;
						}
					}
					result = 0;
					goto IL_0054;
					IL_0054:
					return (byte)result != 0;
				}).ToList()[0];
				List<User> nextUser = new List<User>();
				targetItem.WF_WORKITEM_HANDLER.ForEach(delegate(WF_WORKITEM_HANDLER a)
				{
					nextUser.Add(new User
					{
						CURRENT_USER_ID = a.USER_ID,
						CURRENT_USER_NAME = a.USER_NAME,
						PROXY_USER_ID = a.USER_ID,
						PROXY_USER_NAME = a.USER_NAME
					});
				});
				RemarkWorkItem(currentInstance, nextAcvity, currentWorkItem, HANDLE_RESULT.Return);
				FinishWorkItem(currentActivity, currentWorkItem, submitDto.Handler, submitDto.HandleResult, submitDto.Suggestion, FINISH_TYPE.Single);
				WF_WORKITEM newItem = CreateWorkItem(currentInstance, nextAcvity, submitDto.Drivers.RuleId, submitDto.Handler, nextUser, HANDLE_RESULT.None, currentWorkItem.WORKITEM_ID);
				newItem.GENERATE_TYPE = 1m;
				currentInstance.WF_WORKITEM.Add(newItem);
				runWorkflow.SendMessage(currentInstance, newItem, nextAcvity, submitDto.Handler);
				runWorkflow.SendToMsg(currentInstance, newItem, nextAcvity, submitDto.Handler);
				break;
			}
			case HANDLE_RESULT.Retrieve:
			{
				WF_ACTIVITY nextAcvity2 = submitDto.CurrentActivity;
				RemarkWorkItem(currentInstance, nextAcvity2, currentWorkItem, HANDLE_RESULT.Retrieve);
				IList<User> nextUser2 = new List<User>();
				currentWorkItem.WF_WORKITEM_HANDLER.ForEach(delegate(WF_WORKITEM_HANDLER a)
				{
					nextUser2.Add(new User
					{
						CURRENT_USER_ID = a.USER_ID,
						CURRENT_USER_NAME = a.USER_NAME,
						PROXY_USER_ID = a.USER_ID,
						PROXY_USER_NAME = a.USER_NAME
					});
				});
				FinishWorkItem(currentActivity, currentWorkItem, submitDto.Handler, submitDto.HandleResult, submitDto.Suggestion, FINISH_TYPE.Single);
				WF_WORKITEM newItem = CreateWorkItem(currentInstance, nextAcvity2, Guid.Empty, submitDto.Handler, nextUser2, HANDLE_RESULT.None, currentWorkItem.WORKITEM_ID);
				newItem.GENERATE_TYPE = 2m;
				currentInstance.WF_WORKITEM.Add(newItem);
				break;
			}
			case HANDLE_RESULT.TemporarySave:
				runWorkflow.SaveData(template, currentInstance, null, submitDto.FormData);
				currentInstance.INSTANCE_NAME = runWorkflow.InstanceName(template.TEMPLATE_NAME, submitDto.FormData);
				currentWorkItem.WF_DATA_HISTORY.Add(new WF_DATA_HISTORY
				{
					FORM_DATA = submitDto.FormData,
					WORKITEM_ID = currentWorkItem.WORKITEM_ID,
					HISTORY_ID = Guid.NewGuid()
				});
				break;
			}
			IEnumerable<WF_WORKITEM> cur_WI = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
			{
				decimal? hANDLE_RESULT = a.HANDLE_RESULT;
				return hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue;
			});
			string currentActivityName = "";
			string currentHandlerId = "";
			string currentHandlerName = "";
			if (cur_WI.Any())
			{
				foreach (WF_WORKITEM item2 in cur_WI)
				{
					ICollection<WF_ACTIVITY> wF_ACTIVITY = template.WF_ACTIVITY;
					Func<WF_ACTIVITY, bool> predicate = (WF_ACTIVITY a) => a.ACTIVITY_ID == item2.ACTIVITY_ID;
					currentActivityName = currentActivityName + wF_ACTIVITY.SingleOrDefault(predicate).ACTIVITY_NAME + ",";
					foreach (WF_WORKITEM_HANDLER h in item2.WF_WORKITEM_HANDLER)
					{
						rUN_STATE = h.HANDLE_RESULT;
						if (rUN_STATE.GetValueOrDefault() == 0m && rUN_STATE.HasValue)
						{
							currentHandlerId = string.Concat(currentHandlerId, h.USER_ID, ",");
							currentHandlerName = currentHandlerName + h.USER_NAME + ",";
						}
					}
				}
			}
			if (currentActivityName.Length > 0)
			{
				currentActivityName = currentActivityName.Substring(0, currentActivityName.Length - 1);
			}
			if (currentHandlerId.Length > 0)
			{
				currentHandlerId = currentHandlerId.Substring(0, currentHandlerId.Length - 1);
			}
			if (currentHandlerName.Length > 0)
			{
				currentHandlerName = currentHandlerName.Substring(0, currentHandlerName.Length - 1);
			}
			currentInstance.CURRENT_ACTIVITY = currentActivityName;
			currentInstance.CURRENT_HANDLER_ID = currentHandlerId;
			currentInstance.CURRENT_HANDLER_NAME = currentHandlerName;
			if (Bit.pro((long)currentActivity.STATUS.Value, "9|1") == 1 && submitDto.WF_INSTANCE_ACTIVITY != null && submitDto.WF_INSTANCE_ACTIVITY.Count > 0)
			{
				foreach (WF_INSTANCE_ACTIVITY item in submitDto.WF_INSTANCE_ACTIVITY)
				{
					repositoryInstanceActivity.FindAll((WF_INSTANCE_ACTIVITY a) => a.ACTIVITY_ID == item.ACTIVITY_ID && a.INSTANCE_ID == item.INSTANCE_ID)?.ForEach(delegate(WF_INSTANCE_ACTIVITY x)
					{
						repositoryInstanceActivity.Remove(x);
					});
					item.INSTANCE_ID = currentInstance.INSTANCE_ID;
					repositoryInstanceActivity.Add(item);
				}
				repositoryInstanceActivity.DbContext.Commit();
			}
		}
		repositoryInstance.DbContext.Commit();
		string id = Guid.NewGuid().ToString();
		string IP = ((!string.IsNullOrEmpty(SessionContext.IP)) ? SessionContext.IP : "No IP");
		string sql = "INSERT INTO SYS_LOG (LOG_ID, BUSINESS_TYPE, USER_ID, USER_NAME, ORG_ID, IP, DO_TIME, DATA,TOKEN) VALUES ('{0}', '{1}',f_guidtoraw('{2}'), '{3}', f_guidtoraw('{4}'), '{5}', timestamp'{6}', '{7}','{8}')";
		id = new Guid(id).ToOracleHex();
		Guid token = currentSessionToken.Value;
		string exeuteSql = string.Format(sql, id, template.TEMPLATE_NAME, SessionContext.UserInfo.UserID, SessionContext.UserInfo.UserName, SessionContext.UserInfo.BelongToOrgID, IP, $"{TimeZoneHelper.Now:yyyy-MM-dd HH:mm:ss}", "", token);
		sqlRepository.ExecuteCommand(exeuteSql.ToString());
		return repositoryInstance.GetByKey(currentInstance.INSTANCE_ID);
	}

	private void HandleInstance(WF_INSTANCE currentInstance, WF_ACTIVITY currentActivity, WF_WORKITEM workItem, User handler, Driver driver, string formData, string suggestion, string ruleExpress)
	{
		needSave = needSave || Bit.pro((long)currentActivity.STATUS.Value, "0|2") == 1;
		WF_ACTIVITY nextActivity = GetNextActivity(driver.RuleId);
		decimal? aCTIVITY_TYPE = currentActivity.ACTIVITY_TYPE;
		if (aCTIVITY_TYPE.GetValueOrDefault() == -1m && aCTIVITY_TYPE.HasValue)
		{
			currentInstance.INSTANCE_NAME = runWorkflow.InstanceName(template.TEMPLATE_NAME, formData);
		}
		if (driver.Next.Count > 0)
		{
			WF_WORKITEM item = CreateWorkItem(currentInstance, nextActivity, driver.RuleId, handler, new List<User> { handler }, HANDLE_RESULT.None, workItem.WORKITEM_ID);
			currentInstance.WF_WORKITEM.Add(item);
			FinishWorkItem(nextActivity, item, handler, HANDLE_RESULT.Adopt, suggestion, FINISH_TYPE.Single);
			{
				foreach (Driver subDriver in driver.Next)
				{
					HandleInstance(currentInstance, currentActivity, item, handler, subDriver, formData, suggestion, ruleExpress);
				}
				return;
			}
		}
		WF_WORKITEM currentItem = null;
		switch ((int)nextActivity.ACTIVITY_TYPE.Value)
		{
		case 4:
		{
			IEnumerable<WF_WORKITEM> itemList = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
			{
				int result3;
				if (a.ACTIVITY_ID == nextActivity.ACTIVITY_ID && a.ISDEL == 0m)
				{
					decimal? hANDLE_RESULT = a.HANDLE_RESULT;
					result3 = ((hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue) ? 1 : 0);
				}
				else
				{
					result3 = 0;
				}
				return (byte)result3 != 0;
			});
			Driver nextDriver;
			if (itemList.Any())
			{
				if (!CanFinish(template, currentInstance, nextActivity))
				{
					break;
				}
				WF_WORKITEM item = itemList.ToList()[0];
				Driver driver2 = new Driver();
				driver2.RuleId = template.WF_RULE.SingleOrDefault(delegate(WF_RULE a)
				{
					int result2;
					if (a.FROM_ACTIVITY_ID == nextActivity.ACTIVITY_ID && a.ISDEL == 0m)
					{
						decimal? rULE_TYPE2 = a.RULE_TYPE;
						result2 = ((rULE_TYPE2.GetValueOrDefault() == 0m && rULE_TYPE2.HasValue) ? 1 : 0);
					}
					else
					{
						result2 = 0;
					}
					return (byte)result2 != 0;
				}).RULE_ID;
				nextDriver = driver2;
				FinishWorkItem(nextActivity, item, handler, HANDLE_RESULT.Adopt, suggestion, FINISH_TYPE.Single);
				HandleInstance(currentInstance, nextActivity, item, handler, nextDriver, formData, suggestion, ruleExpress);
				return;
			}
			WF_WORKITEM newWorkItem = CreateWorkItem(currentInstance, nextActivity, driver.RuleId, handler, driver.NextHandler, HANDLE_RESULT.None, workItem.WORKITEM_ID);
			currentInstance.WF_WORKITEM.Add(newWorkItem);
			if (!CanFinish(template, currentInstance, nextActivity))
			{
				break;
			}
			Driver driver3 = new Driver();
			driver3.RuleId = template.WF_RULE.SingleOrDefault(delegate(WF_RULE a)
			{
				int result;
				if (a.FROM_ACTIVITY_ID == nextActivity.ACTIVITY_ID && a.ISDEL == 0m)
				{
					decimal? rULE_TYPE = a.RULE_TYPE;
					result = ((rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue) ? 1 : 0);
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}).RULE_ID;
			nextDriver = driver3;
			FinishWorkItem(nextActivity, newWorkItem, handler, HANDLE_RESULT.Adopt, suggestion, FINISH_TYPE.Single);
			HandleInstance(currentInstance, nextActivity, newWorkItem, handler, nextDriver, formData, suggestion, ruleExpress);
			return;
		}
		case 3:
		case 6:
			currentInstance.WF_WORKITEM.Add(CreateWorkItem(currentInstance, nextActivity, driver.RuleId, handler, driver.NextHandler, HANDLE_RESULT.None, workItem.WORKITEM_ID));
			break;
		case 100:
			currentItem = CreateWorkItem(currentInstance, nextActivity, driver.RuleId, handler, driver.NextHandler, HANDLE_RESULT.None, workItem.WORKITEM_ID);
			currentInstance.WF_WORKITEM.Add(currentItem);
			currentInstance.RUN_STATE = 2m;
			currentInstance.FINISH_TIME = DateTime.Now;
			break;
		default:
		{
			if (driver.NextHandler == null || driver.NextHandler.Count == 0)
			{
				driver.NextHandler = runWorkflow.GetNextHandler(template, currentInstance, nextActivity, currentInstance.ORG_ID, formData);
			}
			if (driver.NextHandler == null || driver.NextHandler.Count == 0)
			{
				throw new ValidationException("SystemManagement.Public.E_0001", new string[1] { "流程节点未配置处理人" });
			}
			WF_WORKITEM item = CreateWorkItem(currentInstance, nextActivity, driver.RuleId, handler, driver.NextHandler, HANDLE_RESULT.None, workItem.WORKITEM_ID);
			currentItem = item;
			currentInstance.WF_WORKITEM.Add(item);
			if (Bit.pro((long)nextActivity.STATUS.Value, "12|2") != 1)
			{
				break;
			}
			IList<Driver> driversForMerge = new WorkflowService().GetNextDrivers(template.AdaptAsDTO<WF_TEMPLATEDTO>(), nextActivity.AdaptAsDTO<WF_ACTIVITYDTO>(), ruleExpress);
			if (driversForMerge.Count != 1 || driversForMerge[0].Next.Count != 1)
			{
				break;
			}
			List<User> doUser = new List<User>();
			IEnumerable<WF_WORKITEM> items = currentInstance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
			{
				decimal? hANDLE_RESULT3 = a.HANDLE_RESULT;
				int result4;
				if (hANDLE_RESULT3.GetValueOrDefault() == 2m && hANDLE_RESULT3.HasValue)
				{
					hANDLE_RESULT3 = a.WORKITEM_RUN_STATE;
					result4 = ((hANDLE_RESULT3.GetValueOrDefault() == 2m && hANDLE_RESULT3.HasValue) ? 1 : 0);
				}
				else
				{
					result4 = 0;
				}
				return (byte)result4 != 0;
			});
			bool flag = false;
			foreach (WF_WORKITEM oldWorkItem in items)
			{
				IEnumerable<WF_WORKITEM_HANDLER> oldHandlers = oldWorkItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
				{
					decimal? hANDLE_RESULT2 = a.HANDLE_RESULT;
					return hANDLE_RESULT2.GetValueOrDefault() == 2m && hANDLE_RESULT2.HasValue;
				});
				if (oldHandlers.Count() <= 0)
				{
					continue;
				}
				foreach (WF_WORKITEM_HANDLER oldhandler in oldHandlers)
				{
					List<User> nextHandler = driver.NextHandler;
					Func<User, bool> predicate = (User a) => a.CURRENT_USER_ID == oldhandler.USER_ID;
					IEnumerable<User> tolist = nextHandler.Where(predicate);
					if (tolist != null && tolist.Count() > 0)
					{
						if (oldhandler.HANDLE_USER_ID == oldhandler.USER_ID)
						{
							flag = true;
						}
						if (flag)
						{
							User user2 = new User();
							user2.PROXY_USER_ID = oldhandler.USER_ID;
							user2.CURRENT_USER_ID = oldhandler.USER_ID;
							user2.PROXY_USER_NAME = oldhandler.HANDLE_USER_NAME;
							user2.CURRENT_USER_NAME = oldhandler.HANDLE_USER_NAME;
							User user1 = user2;
							doUser.Add(user1);
						}
					}
				}
			}
			if (!flag)
			{
				break;
			}
			FINISH_TYPE finishType = (FINISH_TYPE)Bit.pro((long)nextActivity.STATUS.Value, "24|2");
			if (finishType == FINISH_TYPE.Single)
			{
				FinishWorkItem(nextActivity, item, doUser[0], HANDLE_RESULT.Adopt, suggestion, FINISH_TYPE.Single);
				HandleInstance(currentInstance, nextActivity, item, doUser[0], driversForMerge[0].Next[0], formData, suggestion, ruleExpress);
				return;
			}
			HANDLE_RESULT handleResult = HANDLE_RESULT.Adopt;
			if (Bit.pro((long)nextActivity.STATUS.Value, "5|1") == 1)
			{
				handleResult = HANDLE_RESULT.CountersignAgree;
			}
			foreach (User _do in doUser)
			{
				FinishWorkItem(nextActivity, item, doUser[0], handleResult, suggestion, finishType);
			}
			aCTIVITY_TYPE = item.WORKITEM_RUN_STATE;
			if (aCTIVITY_TYPE.GetValueOrDefault() == 2m && aCTIVITY_TYPE.HasValue)
			{
				HandleInstance(currentInstance, nextActivity, item, doUser[0], driversForMerge[0].Next[0], formData, suggestion, ruleExpress);
			}
			return;
		}
		}
		if (isSave || !needSave)
		{
			aCTIVITY_TYPE = wfActivity.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() == -1m) || !aCTIVITY_TYPE.HasValue)
			{
				goto IL_09c8;
			}
		}
		isSave = true;
		runWorkflow.SaveData(template, currentInstance, nextActivity, formData);
		workItem.WF_DATA_HISTORY.Add(new WF_DATA_HISTORY
		{
			FORM_DATA = formData,
			WORKITEM_ID = workItem.WORKITEM_ID,
			HISTORY_ID = Guid.NewGuid()
		});
		goto IL_09c8;
		IL_09c8:
		runWorkflow.AfterHandler(template, currentInstance, nextActivity, formData);
		runWorkflow.SendMessage(currentInstance, currentItem, nextActivity, handler);
		runWorkflow.SendToMsg(currentInstance, currentItem, nextActivity, handler);
	}

	/// <summary>
	/// 取回、退回等标记工作项状态
	/// </summary>
	private void RemarkWorkItem(WF_INSTANCE currentInstance, WF_ACTIVITY nextActivity, WF_WORKITEM currentWorkItem, HANDLE_RESULT handleResult)
	{
		WF_TEMPLATEDTO currentTemplate = WorkflowCacheManager.GetTemplateById(currentInstance.TEMPLATE_ID.Value);
		IDictionary<Guid, Guid> pathClass = new Dictionary<Guid, Guid>();
		currentWorkItem.HANDLE_RESULT = (int)handleResult;
		currentWorkItem.WORKITEM_RUN_STATE = (int)handleResult;
		pathClass.Add(nextActivity.ACTIVITY_ID, nextActivity.ACTIVITY_ID);
		GeneratePath(currentTemplate, currentWorkItem.ACTIVITY_ID, nextActivity.ACTIVITY_ID, ref pathClass);
		MarkItem(currentInstance, pathClass, handleResult);
	}

	private void GeneratePath(WF_TEMPLATEDTO currentTemplate, Guid activityId, Guid currentActivityId, ref IDictionary<Guid, Guid> path)
	{
		IEnumerable<WF_RULEDTO> query = currentTemplate.WF_RULE.Where(delegate(WF_RULEDTO a)
		{
			int result;
			if (a.FROM_ACTIVITY_ID == currentActivityId && a.ISDEL == 0m)
			{
				decimal? rULE_TYPE = a.RULE_TYPE;
				result = ((rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		});
		if (query.Count() <= 0)
		{
			return;
		}
		IList<WF_RULEDTO> rules = query.ToList();
		foreach (WF_RULEDTO rule in rules)
		{
			if (!path.ContainsKey(rule.TO_ACTIVITY_ID))
			{
				path.Add(rule.TO_ACTIVITY_ID, rule.TO_ACTIVITY_ID);
				if (rule.TO_ACTIVITY_ID != activityId)
				{
					GeneratePath(currentTemplate, activityId, rule.TO_ACTIVITY_ID, ref path);
				}
			}
		}
	}

	/// <summary>
	/// 获取某个节点处理人
	/// </summary>
	private List<User> GetUserByActivityId(WF_INSTANCE currentInstance, Guid activityId)
	{
		List<User> handler = new List<User>();
		IEnumerable<WF_WORKITEM_HANDLER> userCollection = currentInstance.WF_WORKITEM.First(delegate(WF_WORKITEM a)
		{
			int result2;
			if (a.ACTIVITY_ID == activityId)
			{
				decimal? wORKITEM_RUN_STATE = a.WORKITEM_RUN_STATE;
				result2 = ((wORKITEM_RUN_STATE.GetValueOrDefault() == 2m && wORKITEM_RUN_STATE.HasValue) ? 1 : 0);
			}
			else
			{
				result2 = 0;
			}
			return (byte)result2 != 0;
		}).WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
		{
			decimal? hANDLE_RESULT = a.HANDLE_RESULT;
			int result;
			if (!(hANDLE_RESULT.GetValueOrDefault() == 2m) || !hANDLE_RESULT.HasValue)
			{
				hANDLE_RESULT = a.HANDLE_RESULT;
				result = ((hANDLE_RESULT.GetValueOrDefault() == 1024m && hANDLE_RESULT.HasValue) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		});
		foreach (WF_WORKITEM_HANDLER item in userCollection)
		{
			try
			{
				handler.Add(new User
				{
					CURRENT_USER_ID = item.HANDLE_USER_ID.Value,
					CURRENT_USER_NAME = item.HANDLE_USER_NAME,
					PROXY_USER_ID = item.HANDLE_USER_ID,
					PROXY_USER_NAME = item.HANDLE_USER_NAME
				});
			}
			catch
			{
			}
		}
		return handler;
	}

	private WF_ACTIVITY GetNextActivity(Guid ruleId)
	{
		WF_RULE rule = template.WF_RULE.SingleOrDefault((WF_RULE a) => a.RULE_ID == ruleId);
		return template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == rule.TO_ACTIVITY_ID);
	}

	/// <summary>
	/// 标记状态
	/// </summary>
	private void MarkItem(WF_INSTANCE currentInstance, IDictionary<Guid, Guid> paths, HANDLE_RESULT handleResult)
	{
		foreach (KeyValuePair<Guid, Guid> activityId in paths)
		{
			ICollection<WF_WORKITEM> wF_WORKITEM = currentInstance.WF_WORKITEM;
			Func<WF_WORKITEM, bool> predicate = delegate(WF_WORKITEM a)
			{
				Guid aCTIVITY_ID = a.ACTIVITY_ID;
				KeyValuePair<Guid, Guid> keyValuePair = activityId;
				return aCTIVITY_ID == keyValuePair.Key && a.ISDEL == 0m;
			};
			IEnumerable<WF_WORKITEM> query = wF_WORKITEM.Where(predicate);
			if (query.Count() <= 0)
			{
				continue;
			}
			foreach (WF_WORKITEM item in query)
			{
				MarkItem(item, handleResult);
			}
		}
	}

	/// <summary>
	/// 标记状态
	/// </summary>
	private void MarkItem(WF_WORKITEM workItem, HANDLE_RESULT handleResult)
	{
		decimal? wORKITEM_RUN_STATE = workItem.WORKITEM_RUN_STATE;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 2048m && wORKITEM_RUN_STATE.HasValue)
		{
			return;
		}
		wORKITEM_RUN_STATE = workItem.WORKITEM_RUN_STATE;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 1024m && wORKITEM_RUN_STATE.HasValue)
		{
			return;
		}
		wORKITEM_RUN_STATE = workItem.HANDLE_RESULT;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 16384m && wORKITEM_RUN_STATE.HasValue)
		{
			return;
		}
		wORKITEM_RUN_STATE = workItem.WORKITEM_RUN_STATE;
		if (wORKITEM_RUN_STATE.GetValueOrDefault() == 0m && wORKITEM_RUN_STATE.HasValue)
		{
			workItem.HANDLE_RESULT = 16384m;
			foreach (WF_WORKITEM_HANDLER item in workItem.WF_WORKITEM_HANDLER)
			{
				item.HANDLE_RESULT = 16384m;
			}
		}
		else
		{
			workItem.HANDLE_RESULT = (int)handleResult;
		}
		workItem.WORKITEM_RUN_STATE = (int)handleResult;
	}

	private WF_WORKITEM CreateWorkItem(WF_INSTANCE instance, WF_ACTIVITY activity, Guid ruleId, User currentHandler, IList<User> nextHandler, HANDLE_RESULT handleResult = HANDLE_RESULT.None, Guid? parentWorkItemId = null)
	{
		WF_WORKITEM workItem = new WF_WORKITEM();
		workItem.WORKITEM_ID = Guid.NewGuid();
		workItem.INSTANCE_ID = instance.INSTANCE_ID;
		workItem.ACTIVITY_ID = activity.ACTIVITY_ID;
		workItem.WORKITEM_NAME = activity.ACTIVITY_NAME;
		if (handleResult == HANDLE_RESULT.Circulate)
		{
			workItem.WORKITEM_NAME += "传阅";
		}
		workItem.WORKITEM_RUN_STATE = 0m;
		workItem.GENERATE_TYPE = 0m;
		workItem.SEND_TIME = DateTime.Now;
		workItem.HANDLE_RESULT = (int)handleResult;
		workItem.SENDER_USER_ID = currentHandler.CURRENT_USER_ID;
		workItem.SENDER_USER_NAME = currentHandler.CURRENT_USER_NAME;
		workItem.PARENT_WORKITEM_ID = parentWorkItemId;
		workItem.SORT = instance.WF_WORKITEM.Count();
		workItem.RULE_ID = ruleId;
		workItem.CREATOR = SessionContext.UserInfo.UserID;
		workItem.MODIFIER = SessionContext.UserInfo.UserID;
		workItem.CREATETIME = DateTime.Now;
		workItem.MODIFYTIME = DateTime.Now;
		workItem.ISDEL = 0m;
		if (nextHandler != null)
		{
			foreach (User user in nextHandler)
			{
				workItem.WF_WORKITEM_HANDLER.Add(CreateHandler(user, workItem, (!activity.STATUS.HasValue) ? 0 : ((long)activity.STATUS.Value)));
			}
		}
		return workItem;
	}

	private WF_WORKITEM_HANDLER CreateHandler(User user, WF_WORKITEM workItem, long status)
	{
		WF_WORKITEM_HANDLER wF_WORKITEM_HANDLER = new WF_WORKITEM_HANDLER();
		wF_WORKITEM_HANDLER.WORKITEM_HANDLER_ID = Guid.NewGuid();
		wF_WORKITEM_HANDLER.WORKITEM_ID = workItem.WORKITEM_ID;
		wF_WORKITEM_HANDLER.USER_ID = user.CURRENT_USER_ID;
		wF_WORKITEM_HANDLER.USER_NAME = user.CURRENT_USER_NAME;
		wF_WORKITEM_HANDLER.HANDLE_RESULT = 0m;
		wF_WORKITEM_HANDLER.SIGNATURE_MODE = Bit.pro(status, "8|2");
		wF_WORKITEM_HANDLER.INSTANCE_ID = workItem.INSTANCE_ID;
		wF_WORKITEM_HANDLER.WORKITEM_NAME = workItem.WORKITEM_NAME;
		wF_WORKITEM_HANDLER.CREATOR = SessionContext.UserInfo.UserID;
		wF_WORKITEM_HANDLER.MODIFIER = SessionContext.UserInfo.UserID;
		wF_WORKITEM_HANDLER.CREATETIME = DateTime.Now;
		wF_WORKITEM_HANDLER.MODIFYTIME = DateTime.Now;
		wF_WORKITEM_HANDLER.CLIENT_TYPE = ((!user.CLIENT_TYPE.HasValue) ? new decimal?(0m) : user.CLIENT_TYPE);
		wF_WORKITEM_HANDLER.ISDEL = 0m;
		return wF_WORKITEM_HANDLER;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="currentWorkItem"></param>
	/// <param name="user"></param>
	/// <param name="handleResult"></param>
	/// <param name="handleSuggestion"></param>
	/// <param name="finishType">完成方式，0 单一 1 百分比 2 全部</param>
	private bool FinishWorkItem(WF_ACTIVITY currentActivity, WF_WORKITEM currentWorkItem, User user, HANDLE_RESULT handleResult, string handleSuggestion, FINISH_TYPE? finishType = null)
	{
		if (currentWorkItem == null)
		{
			throw new CustomCodeException("工作项不能为null");
		}
		int count = currentWorkItem.WF_WORKITEM_HANDLER.Count();
		IEnumerable<WF_WORKITEM_HANDLER> unHandler = currentWorkItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
		{
			decimal? hANDLE_RESULT = a.HANDLE_RESULT;
			return hANDLE_RESULT.GetValueOrDefault() == 0m && hANDLE_RESULT.HasValue;
		});
		bool isfinish = false;
		if (!finishType.HasValue)
		{
			finishType = (FINISH_TYPE)Bit.pro((long)currentActivity.STATUS.Value, "24|2");
		}
		switch (finishType)
		{
		case FINISH_TYPE.Single:
			isfinish = true;
			break;
		case FINISH_TYPE.Percent:
			isfinish = (double)((count - unHandler.Count() + 1) / count) > (double)currentActivity.FINISH_NUMBER.Value / 100.0;
			break;
		case FINISH_TYPE.All:
			isfinish = unHandler.Count() == 1;
			break;
		case FINISH_TYPE.Quantity:
		{
			decimal num = count - unHandler.Count() + 1;
			decimal? fINISH_NUMBER = currentActivity.FINISH_NUMBER;
			isfinish = num == fINISH_NUMBER.GetValueOrDefault() && fINISH_NUMBER.HasValue;
			break;
		}
		}
		if (isfinish)
		{
			currentWorkItem.WORKITEM_RUN_STATE = (int)handleResult;
			currentWorkItem.HANDLE_RESULT = (int)handleResult;
		}
		foreach (WF_WORKITEM_HANDLER handler in unHandler)
		{
			Guid uSER_ID = handler.USER_ID;
			Guid? pROXY_USER_ID = user.PROXY_USER_ID;
			if (uSER_ID == pROXY_USER_ID)
			{
				handler.HANDLE_USER_ID = user.CURRENT_USER_ID;
				handler.HANDLE_USER_NAME = user.CURRENT_USER_NAME;
				handler.HANDLE_RESULT = (int)handleResult;
				handler.HANDLE_SUGGESTION = handleSuggestion;
				handler.HANDLE_TIME = DateTime.Now;
			}
			else if (isfinish)
			{
				decimal? fINISH_NUMBER = handler.HANDLE_RESULT;
				if (fINISH_NUMBER.GetValueOrDefault() == 0m && fINISH_NUMBER.HasValue)
				{
					handler.HANDLE_RESULT = 16384m;
				}
			}
		}
		return isfinish;
	}

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
		dtoinstance.WF_WORKITEM = dtoinstance.WF_WORKITEM.OrderBy((WF_WORKITEMDTO a) => a.SORT).ToList();
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
	/// 获取会签的发起工作项
	/// </summary>
	/// <param name="template"></param>
	/// <param name="instance"></param>
	/// <param name="currentWorkItemId"></param>
	/// <returns></returns>
	private WF_WORKITEM GetStartWorkItem(WF_TEMPLATE template, WF_INSTANCE instance, Guid currentWorkItemId)
	{
		return GetStartWorkItem(template.WF_ACTIVITY, instance.WF_WORKITEM, currentWorkItemId);
	}

	/// <summary>
	/// 获取会签的发起工作项
	/// </summary>
	/// <param name="template"></param>
	/// <param name="instance"></param>
	/// <param name="currentWorkItemId"></param>
	/// <returns></returns>
	private WF_WORKITEM GetStartWorkItem(ICollection<WF_ACTIVITY> activityList, ICollection<WF_WORKITEM> workItemList, Guid currentWorkItemId)
	{
		WF_WORKITEM item = workItemList.SingleOrDefault((WF_WORKITEM a) => a.WORKITEM_ID == currentWorkItemId);
		WF_WORKITEM parent = workItemList.SingleOrDefault(delegate(WF_WORKITEM a)
		{
			Guid wORKITEM_ID = a.WORKITEM_ID;
			Guid? pARENT_WORKITEM_ID = item.PARENT_WORKITEM_ID;
			return wORKITEM_ID == pARENT_WORKITEM_ID;
		});
		WF_ACTIVITY activity = activityList.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == parent.ACTIVITY_ID);
		decimal? aCTIVITY_TYPE = activity.ACTIVITY_TYPE;
		if (!(aCTIVITY_TYPE.GetValueOrDefault() == 0m) || !aCTIVITY_TYPE.HasValue)
		{
			aCTIVITY_TYPE = activity.ACTIVITY_TYPE;
			if (!(aCTIVITY_TYPE.GetValueOrDefault() == -1m) || !aCTIVITY_TYPE.HasValue)
			{
				return GetStartWorkItem(activityList, workItemList, parent.WORKITEM_ID);
			}
		}
		return parent;
	}

	private bool CanFinish(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY merge)
	{
		FINISH_TYPE finishType = (FINISH_TYPE)Bit.pro((long)merge.STATUS.Value, "24|2");
		switch (finishType)
		{
		case FINISH_TYPE.Single:
			return true;
		case FINISH_TYPE.All:
		{
			WF_ACTIVITY branch = template.WF_ACTIVITY.SingleOrDefault(delegate(WF_ACTIVITY a)
			{
				Guid aCTIVITY_ID = a.ACTIVITY_ID;
				Guid? bRANCH_ACTIVITY_ID = merge.BRANCH_ACTIVITY_ID;
				return aCTIVITY_ID == bRANCH_ACTIVITY_ID;
			});
			WF_WORKITEM item = (from a in instance.WF_WORKITEM.Where(delegate(WF_WORKITEM a)
				{
					int result;
					if (a.ACTIVITY_ID == branch.ACTIVITY_ID)
					{
						decimal? hANDLE_RESULT = a.HANDLE_RESULT;
						result = ((hANDLE_RESULT.GetValueOrDefault() == 2m && hANDLE_RESULT.HasValue) ? 1 : 0);
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				})
				orderby a.SORT descending
				select a).ToList()[0];
			return CanFinish(instance, item, merge);
		}
		case FINISH_TYPE.Quantity:
		{
			IEnumerable<WF_RULE> rules = template.WF_RULE.Where((WF_RULE a) => a.TO_ACTIVITY_ID == merge.ACTIVITY_ID);
			int count = 0;
			foreach (WF_RULE rule in rules)
			{
				ICollection<WF_WORKITEM> wF_WORKITEM = instance.WF_WORKITEM;
				Func<WF_WORKITEM, bool> predicate = delegate(WF_WORKITEM a)
				{
					int result2;
					if (a.ACTIVITY_ID == rule.FROM_ACTIVITY_ID && a.ISDEL == 0m)
					{
						decimal? wORKITEM_RUN_STATE = a.WORKITEM_RUN_STATE;
						result2 = ((wORKITEM_RUN_STATE.GetValueOrDefault() == 2m && wORKITEM_RUN_STATE.HasValue) ? 1 : 0);
					}
					else
					{
						result2 = 0;
					}
					return (byte)result2 != 0;
				};
				if (wF_WORKITEM.Where(predicate).Any())
				{
					count++;
				}
			}
			decimal num = count;
			decimal? fINISH_NUMBER = merge.FINISH_NUMBER;
			return num >= fINISH_NUMBER.GetValueOrDefault() && fINISH_NUMBER.HasValue;
		}
		default:
			return false;
		}
	}

	private bool CanFinish(WF_INSTANCE instance, WF_WORKITEM item, WF_ACTIVITY merge)
	{
		IEnumerable<WF_WORKITEM> query = instance.WF_WORKITEM.Where((WF_WORKITEM a) => a.PARENT_WORKITEM_ID == item.WORKITEM_ID);
		bool flag = true;
		if (query.Any())
		{
			foreach (WF_WORKITEM workItem in query)
			{
				decimal? wORKITEM_RUN_STATE = workItem.WORKITEM_RUN_STATE;
				if (wORKITEM_RUN_STATE.GetValueOrDefault() > 0m && wORKITEM_RUN_STATE.HasValue)
				{
					flag = flag && CanFinish(instance, workItem, merge);
					continue;
				}
				if (workItem.ACTIVITY_ID == merge.ACTIVITY_ID)
				{
					return true;
				}
				return false;
			}
		}
		return flag;
	}

	public object WorkflowDataMigration(IList<DataMigrationDTO> list)
	{
		connection = new SqlConnection(" Data Source=11.11.140.229,8080;Initial Catalog=RFOA_WFDB;Persist Security Info=True;User ID=rfoa;Password=rfoa");
		string dbName = "RFOA_DB";
		errorList = new List<Guid>();
		string s = "";
		try
		{
			connection.Open();
			userList = SqlQueryList<SYS_USERDTO>("select * from SYS_USER", null);
			userOrg = SqlQueryList<SYS_USER_ORG>("select * from SYS_USER_ORG where USER_IDENTITY_TYPE=1", null);
			orgList = SqlQueryList<SYS_ORGDTO>("select * from SYS_ORG ", null);
			foreach (DataMigrationDTO item in list)
			{
				if (item.newId.Length < 36)
				{
					item.newId = OracleToDotNet(item.newId);
					foreach (DataMigrationDTO activity in item.activitys)
					{
						activity.newId = OracleToDotNet(activity.newId);
					}
				}
				IList<WF_INSTANCE> instanceList = WorkflowDataMigration(item, dbName);
				repositoryInstance.AddCommit(instanceList);
			}
		}
		catch (Exception)
		{
			throw;
		}
		finally
		{
			connection.Close();
			if (errorList.Count > 0)
			{
				foreach (Guid guid in errorList)
				{
					s = string.Concat(s, guid, ",");
				}
			}
		}
		return new
		{
			result = ((errorList.Count == 0) ? true : false),
			template = list[0].oldId,
			error = s
		};
	}

	private IList<WF_INSTANCE> WorkflowDataMigration(DataMigrationDTO dto, string dbName)
	{
		string sql = $"SELECT  [InstanceID]      ,[InstanceTitle]      ,[InstanceTableName]      ,[TmpID]      ,t2.User_ID_New [StartUserID]      ,[StartUserName]      ,[RunState]      ,[CurrentWorkItemID]      ,[CurrentActivity]      ,[IsChildInstance]      ,[ParentInstanceID]      ,[ParentActivityID]      ,[NotifyParentFinished]      ,[StartTime]      ,[FinishTime]      ,[PlanFinishedTime]      ,[Priority]      ,[Urgency]      ,[LastActiveTime]      ,[MonitorType]      ,[MonitorID]     ,[MonitorID2]      ,[IsDeleted]  FROM [WFInstance] t1  INNER JOIN {dbName}.dbo.P_Auth_user t2 on t1.StartUserID=t2.User_ID WHERE TMPID='{dto.oldId}'";
		IEnumerable<WFInstance> query = connection.Query<WFInstance>(sql);
		template = WorkflowCacheManager.GetTemplateById(new Guid(dto.newId)).AdaptAsEntity<WF_TEMPLATE>();
		package = packageRepository.GetByKey(template.PACKAGE_ID);
		sql = $"select * from WFWorkItem where InstanceID in (select InstanceID from WFInstance where  TMPID='{dto.oldId}') ";
		IEnumerable<WFWorkItem> allWorkitemOldList = connection.Query<WFWorkItem>(sql);
		sql = string.Format("SELECT [RID]      ,[WorkItemID]      ,[InstanceID]      ,t2.User_ID_New as [ReceiverID]      ,[ReceiverName]     ,[ReceiverType]     ,t3.User_ID_New as [FinisherID]      ,[FinisherName]      ,[FinishTime]      ,[ApproveResult]      ,[ApproveSuggestion]      ,[IsHandled]      ,[HandleOrder]      ,[IsDeleted]      ,[CreateTime]  FROM [WFReceiver]t1  INNER JOIN {0}.dbo.P_Auth_user t2 on t1.ReceiverID=t2.User_ID   LEFT JOIN {0}.dbo.P_Auth_user t3 on t1.FinisherID=t3.User_ID where WorkItemID in (select WorkItemID from WFWorkItem where  InstanceID in (select InstanceID from WFInstance where  TMPID='{1}'))", dbName, dto.oldId);
		IEnumerable<WFReceiver> allReceiver = connection.Query<WFReceiver>(sql);
		string s = "2f1a45e1-4fb7-4770-8026-31e20cb747fb";
		string[] instanceIds = s.Split(',');
		Guid[] guids = new Guid[instanceIds.Length];
		for (int i = 0; i < instanceIds.Length; i++)
		{
			ref Guid reference = ref guids[i];
			reference = new Guid(instanceIds[i]);
		}
		IList<WF_INSTANCE> instanceList = new List<WF_INSTANCE>();
		if (query != null && query.Any())
		{
			int countFlag = 0;
			Guid currentActivityId = default(Guid);
			foreach (WFInstance item in query)
			{
				countFlag++;
				Console.WriteLine(countFlag);
				try
				{
					DateTime startTime = DateTime.Now;
					IList<WFWorkItem> workitemOldList = (from a in allWorkitemOldList
						where a.InstanceID == item.InstanceID
						orderby a.SendTime
						select a).ToList();
					IEnumerable<WFReceiver> receiver = allReceiver.Where((WFReceiver a) => a.InstanceID == item.InstanceID);
					IList<SYS_USERDTO> users = currentHandler(workitemOldList, receiver);
					string currentUserId = "";
					string currentUserName = "";
					int i = 0;
					foreach (SYS_USERDTO user in users)
					{
						if (i == 0)
						{
							currentUserId += user.USER_ID;
							currentUserName += user.DISPLAY_NAME;
						}
						else
						{
							currentUserId = currentUserId + "," + user.USER_ID;
							currentUserName = currentUserName + "," + user.DISPLAY_NAME;
							i++;
						}
					}
					Guid startUserId = new Guid(item.StartUserID);
					DataMigrationDTO migration = dto.activitys.SingleOrDefault((DataMigrationDTO a) => a.oldId == new Guid(item.CurrentActivity));
					if (migration == null)
					{
						throw new CustomCodeException("未配置节点:" + item.CurrentActivity);
					}
					ref Guid reference2 = ref currentActivityId;
					reference2 = new Guid(migration.newId);
					WF_ACTIVITY currentActivity = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == currentActivityId);
					SYS_ORGDTO startOrg = getUserOrg(startUserId);
					WF_INSTANCE wF_INSTANCE = new WF_INSTANCE();
					wF_INSTANCE.CREATETIME = item.StartTime.Value;
					wF_INSTANCE.MODIFYTIME = ((!item.FinishTime.HasValue) ? item.StartTime.Value : item.FinishTime.Value);
					wF_INSTANCE.ISDEL = (item.IsDeleted.HasValue ? item.IsDeleted.Value : 0);
					wF_INSTANCE.CREATOR = startUserId;
					wF_INSTANCE.MODIFIER = startUserId;
					wF_INSTANCE.CLIENT_TYPE = 0m;
					wF_INSTANCE.CURRENT_ACTIVITY = currentActivity.ACTIVITY_NAME;
					wF_INSTANCE.INSTANCE_NAME = item.InstanceTitle;
					wF_INSTANCE.FINISH_TIME = item.FinishTime;
					wF_INSTANCE.START_TIME = item.StartTime;
					wF_INSTANCE.START_USER_ID = new Guid(item.StartUserID);
					wF_INSTANCE.START_USER_NAME = item.StartUserName;
					wF_INSTANCE.PARENT_INSTANCE_ID = null;
					wF_INSTANCE.TABLE_NAME = item.InstanceTableName;
					wF_INSTANCE.INSTANCE_ID = new Guid(item.InstanceID);
					wF_INSTANCE.PACKAGE_ID = package.PACKAGE_ID;
					wF_INSTANCE.TEMPLATE_ID = template.TEMPLATE_ID;
					wF_INSTANCE.PACKAGE_NAME = package.PACKAGE_NAME;
					wF_INSTANCE.TEMPLATE_NAME = template.TEMPLATE_NAME;
					wF_INSTANCE.RUN_STATE = (int)translateRunState(item.RunState.Value);
					wF_INSTANCE.ORG_ID = startOrg.ORG_ID;
					wF_INSTANCE.ORG_NAME = startOrg.ORG_NAME;
					wF_INSTANCE.CURRENT_HANDLER_ID = currentUserId;
					wF_INSTANCE.CURRENT_HANDLER_NAME = currentUserName;
					WF_INSTANCE instance = wF_INSTANCE;
					if (dto.isJump)
					{
						int sort = 0;
						WorkflowDataMigration(instance, dto.activitys, workitemOldList, receiver, ref sort);
					}
					else
					{
						WFWorkItem oldStartItem = workitemOldList[0];
						int sort = 0;
						workitemOldList.RemoveAt(0);
						WorkflowDataMigration(instance, dto.activitys, workitemOldList, receiver, oldStartItem, null, ref sort);
					}
					instanceList.Add(instance);
					TimeSpan span = DateTime.Now - startTime;
					Debug.WriteLine(span);
					Debug.WriteLine(countFlag);
				}
				catch (Exception)
				{
					errorList.Add(new Guid(item.InstanceID));
				}
			}
		}
		return instanceList;
	}

	private void WorkflowDataMigration(WF_INSTANCE instance, List<DataMigrationDTO> activitysMapping, IList<WFWorkItem> workitems, IEnumerable<WFReceiver> receivers, ref int sort)
	{
		try
		{
			if (workitems.Count <= 0)
			{
				return;
			}
			WFWorkItem currentItem = workitems[0];
			DataMigrationDTO currentMap = activitysMapping.SingleOrDefault((DataMigrationDTO a) => a.oldId == new Guid(currentItem.ActivityID));
			WF_WORKITEM parentItem = ((instance.WF_WORKITEM.Count == 0) ? null : instance.WF_WORKITEM.ToList()[instance.WF_WORKITEM.Count - 1]);
			if (currentMap == null)
			{
				return;
			}
			Guid currentActivityId = default(Guid);
			ref Guid reference = ref currentActivityId;
			reference = new Guid(currentMap.newId);
			WF_ACTIVITY activity = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == currentActivityId);
			WF_WORKITEM wF_WORKITEM = new WF_WORKITEM();
			wF_WORKITEM.WORKITEM_ID = new Guid(currentItem.WorkItemID);
			wF_WORKITEM.ACTIVITY_ID = currentActivityId;
			wF_WORKITEM.CLIENT_TYPE = 0m;
			wF_WORKITEM.CREATETIME = currentItem.SendTime.Value;
			wF_WORKITEM.MODIFYTIME = currentItem.SendTime.Value;
			wF_WORKITEM.ISDEL = (currentItem.IsDeleted.HasValue ? currentItem.IsDeleted.Value : 0);
			wF_WORKITEM.GENERATE_TYPE = 0m;
			wF_WORKITEM.HANDLE_RESULT = (int)translateHandleResult(currentItem.WorkItemState.Value);
			wF_WORKITEM.INSTANCE_ID = instance.INSTANCE_ID;
			wF_WORKITEM.PARENT_WORKITEM_ID = ((instance.WF_WORKITEM.Count == 0) ? Guid.Empty : instance.WF_WORKITEM.ToList()[instance.WF_WORKITEM.Count - 1].WORKITEM_ID);
			wF_WORKITEM.SEND_TIME = currentItem.SendTime.Value;
			wF_WORKITEM.SORT = sort;
			wF_WORKITEM.WORKITEM_NAME = activity.ACTIVITY_NAME;
			wF_WORKITEM.WORKITEM_RUN_STATE = (int)translateHandleResult(currentItem.WorkItemState.Value);
			WF_WORKITEM workItem = wF_WORKITEM;
			sort++;
			IEnumerable<WFReceiver> query = receivers.Where((WFReceiver a) => a.WorkItemID == currentItem.WorkItemID);
			if (query != null && query.Any())
			{
				foreach (WFReceiver item in query)
				{
					IEnumerable<WF_WORKITEM_HANDLER> queryHandler = null;
					if (parentItem != null)
					{
						queryHandler = parentItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
						{
							decimal? hANDLE_RESULT = a.HANDLE_RESULT;
							return hANDLE_RESULT.GetValueOrDefault() > 0m && hANDLE_RESULT.HasValue;
						});
						if (queryHandler == null || queryHandler.Count() <= 0)
						{
							queryHandler = parentItem.WF_WORKITEM_HANDLER;
						}
					}
					Guid CREATOR = ((parentItem != null && queryHandler != null && queryHandler.Count() != 0 && queryHandler.ToList()[0].HANDLE_USER_ID.HasValue) ? queryHandler.ToList()[0].HANDLE_USER_ID.Value : new Guid(item.ReceiverID));
					Guid MODIFIER = CREATOR;
					int? isHandled = item.IsHandled;
					decimal? handle_result = ((isHandled.GetValueOrDefault() == 0 && isHandled.HasValue) ? new decimal?(0m) : workItem.HANDLE_RESULT);
					DateTime MODIFYTIME = ((!item.FinishTime.HasValue) ? item.CreateTime.Value : item.FinishTime.Value);
					Guid? HANDLE_USER_ID = (string.IsNullOrEmpty(item.FinisherID) ? null : new Guid?(new Guid(item.FinisherID)));
					WF_WORKITEM_HANDLER wF_WORKITEM_HANDLER = new WF_WORKITEM_HANDLER();
					wF_WORKITEM_HANDLER.INSTANCE_ID = instance.INSTANCE_ID;
					wF_WORKITEM_HANDLER.WORKITEM_NAME = workItem.WORKITEM_NAME;
					wF_WORKITEM_HANDLER.USER_NAME = item.ReceiverName;
					wF_WORKITEM_HANDLER.ISDEL = 0m;
					wF_WORKITEM_HANDLER.HANDLE_TIME = item.FinishTime;
					wF_WORKITEM_HANDLER.HANDLE_USER_ID = HANDLE_USER_ID;
					wF_WORKITEM_HANDLER.USER_ID = new Guid(item.ReceiverID);
					wF_WORKITEM_HANDLER.HANDLE_SUGGESTION = item.ApproveSuggestion;
					wF_WORKITEM_HANDLER.WORKITEM_ID = workItem.WORKITEM_ID;
					wF_WORKITEM_HANDLER.WORKITEM_HANDLER_ID = new Guid(item.RID);
					wF_WORKITEM_HANDLER.MODIFYTIME = MODIFYTIME;
					wF_WORKITEM_HANDLER.CREATOR = CREATOR;
					wF_WORKITEM_HANDLER.CLIENT_TYPE = 0m;
					wF_WORKITEM_HANDLER.CREATETIME = item.CreateTime.Value;
					wF_WORKITEM_HANDLER.MODIFIER = MODIFIER;
					wF_WORKITEM_HANDLER.HANDLE_RESULT = handle_result;
					wF_WORKITEM_HANDLER.HANDLE_USER_NAME = item.FinisherName;
					WF_WORKITEM_HANDLER wfHandler = wF_WORKITEM_HANDLER;
					workItem.WF_WORKITEM_HANDLER.Add(wfHandler);
				}
			}
			instance.WF_WORKITEM.Add(workItem);
			workitems.RemoveAt(0);
			WorkflowDataMigration(instance, activitysMapping, workitems, receivers, ref sort);
		}
		catch (Exception)
		{
			throw;
		}
	}

	private void WorkflowDataMigration(WF_INSTANCE instance, List<DataMigrationDTO> activitysMapping, IList<WFWorkItem> workitems, IEnumerable<WFReceiver> receivers, WFWorkItem currentItem, WF_WORKITEM parentItem, ref int sort)
	{
		DataMigrationDTO currentMap = activitysMapping.SingleOrDefault((DataMigrationDTO a) => a.oldId == new Guid(currentItem.ActivityID));
		Guid currentActivityId = default(Guid);
		ref Guid reference = ref currentActivityId;
		reference = new Guid(currentMap.newId);
		WF_ACTIVITY activity = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == currentActivityId);
		WF_RULE rule = null;
		if (parentItem != null)
		{
			Guid backActivityId = parentItem.ACTIVITY_ID;
			WF_ACTIVITY preActivity = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == backActivityId);
			try
			{
				rule = template.WF_RULE.SingleOrDefault((WF_RULE a) => a.TO_ACTIVITY_ID == currentActivityId && a.FROM_ACTIVITY_ID == backActivityId && a.ISDEL == 0m);
			}
			catch (Exception)
			{
				throw;
			}
			if (rule == null)
			{
				IList<WF_RULE> pre = new List<WF_RULE>();
				IList<WF_RULE> after = new List<WF_RULE>();
				GetPreActivity(ref pre, activity);
				GetAfterActivity(ref after, preActivity);
				IList<WF_RULE> list = pre.Intersect(after).ToList();
				GenerateWorkItem(instance, preActivity, activity, parentItem, list, ref sort);
				parentItem = instance.WF_WORKITEM.ToList()[instance.WF_WORKITEM.Count() - 1];
				rule = template.WF_RULE.SingleOrDefault((WF_RULE a) => a.TO_ACTIVITY_ID == currentActivityId && a.FROM_ACTIVITY_ID == parentItem.ACTIVITY_ID && a.ISDEL == 0m);
			}
		}
		else
		{
			IEnumerable<WF_RULE> ruleList = ((instance.WF_WORKITEM.Count != 0) ? template.WF_RULE.Where((WF_RULE a) => a.TO_ACTIVITY_ID == currentActivityId && a.FROM_ACTIVITY_ID == instance.WF_WORKITEM.ToList()[instance.WF_WORKITEM.Count - 1].ACTIVITY_ID && a.ISDEL == 0m) : template.WF_RULE.Where(delegate(WF_RULE a)
			{
				int result2;
				if (a.TO_ACTIVITY_ID == currentActivityId && a.ISDEL == 0m)
				{
					decimal? rULE_TYPE4 = a.RULE_TYPE;
					result2 = ((rULE_TYPE4.GetValueOrDefault() == 0m && rULE_TYPE4.HasValue) ? 1 : 0);
				}
				else
				{
					result2 = 0;
				}
				return (byte)result2 != 0;
			}));
			if (ruleList.Count() == 1)
			{
				rule = ruleList.ToList()[0];
			}
			else if (ruleList.Count() > 1)
			{
				HANDLE_RESULT result = translateHandleResult(currentItem.WorkItemState.Value);
				if (result == HANDLE_RESULT.Return)
				{
					rule = ruleList.Where(delegate(WF_RULE a)
					{
						decimal? rULE_TYPE3 = a.RULE_TYPE;
						return rULE_TYPE3.GetValueOrDefault() == 1m && rULE_TYPE3.HasValue;
					}).ToList()[0];
				}
				rule = ruleList.Where(delegate(WF_RULE a)
				{
					decimal? rULE_TYPE2 = a.RULE_TYPE;
					return rULE_TYPE2.GetValueOrDefault() == 0m && rULE_TYPE2.HasValue;
				}).ToList()[0];
			}
		}
		IEnumerable<WFReceiver> query = receivers.Where((WFReceiver a) => a.WorkItemID == currentItem.WorkItemID);
		WFReceiver rec = null;
		IEnumerable<WFReceiver> handler = query.Where((WFReceiver a) => a.IsHandled == 1);
		if (handler != null && handler.Any())
		{
			rec = handler.ToList()[0];
		}
		else
		{
			handler = query;
		}
		WF_WORKITEM_HANDLER parentHandler = null;
		if (parentItem != null)
		{
			IEnumerable<WF_WORKITEM_HANDLER> query2 = parentItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
			{
				decimal? hANDLE_RESULT2 = a.HANDLE_RESULT;
				return hANDLE_RESULT2.GetValueOrDefault() > 0m && hANDLE_RESULT2.HasValue;
			});
			if (query2 != null && query2.Any())
			{
				parentHandler = query2.ToList()[0];
			}
			if (parentHandler == null)
			{
				parentHandler = parentItem.WF_WORKITEM_HANDLER.ToList()[0];
			}
		}
		WF_WORKITEM workItem = new WF_WORKITEM
		{
			WORKITEM_ID = new Guid(currentItem.WorkItemID),
			ACTIVITY_ID = currentActivityId,
			CLIENT_TYPE = 0m,
			CREATETIME = currentItem.SendTime.Value,
			MODIFYTIME = currentItem.SendTime.Value,
			ISDEL = (currentItem.IsDeleted.HasValue ? currentItem.IsDeleted.Value : 0),
			GENERATE_TYPE = 0m,
			HANDLE_RESULT = (int)translateHandleResult(currentItem.WorkItemState.Value),
			INSTANCE_ID = instance.INSTANCE_ID,
			PARENT_WORKITEM_ID = ((parentItem == null) ? Guid.Empty : parentItem.WORKITEM_ID),
			SEND_TIME = currentItem.SendTime.Value,
			SORT = sort,
			WORKITEM_NAME = activity.ACTIVITY_NAME,
			WORKITEM_RUN_STATE = (int)translateHandleResult(currentItem.WorkItemState.Value),
			RULE_ID = (rule?.RULE_ID ?? Guid.Empty)
		};
		if (rule != null)
		{
			decimal? rULE_TYPE = rule.RULE_TYPE;
			if (rULE_TYPE.GetValueOrDefault() == 1m && rULE_TYPE.HasValue)
			{
				WF_WORKITEM tmp = instance.WF_WORKITEM.SingleOrDefault(delegate(WF_WORKITEM a)
				{
					Guid wORKITEM_ID = a.WORKITEM_ID;
					Guid? pARENT_WORKITEM_ID = workItem.PARENT_WORKITEM_ID;
					return wORKITEM_ID == pARENT_WORKITEM_ID;
				});
				if (tmp != null)
				{
					tmp.HANDLE_RESULT = 1024m;
					tmp.WORKITEM_RUN_STATE = 1024m;
				}
			}
		}
		workItem.CREATOR = parentHandler?.HANDLE_USER_ID.Value ?? instance.START_USER_ID;
		workItem.SENDER_USER_ID = workItem.CREATOR;
		workItem.MODIFIER = ((rec == null) ? workItem.CREATOR : new Guid(rec.FinisherID));
		workItem.SENDER_USER_NAME = ((parentHandler == null) ? instance.START_USER_NAME : parentHandler.HANDLE_USER_NAME);
		WFWorkItem nextWorkItem = null;
		if (workitems.Count > 0)
		{
			nextWorkItem = workitems[0];
			workitems.RemoveAt(0);
		}
		if (query != null && query.Any())
		{
			foreach (WFReceiver item in query)
			{
				IEnumerable<WF_WORKITEM_HANDLER> queryHandler = null;
				if (parentItem != null)
				{
					queryHandler = parentItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
					{
						decimal? hANDLE_RESULT = a.HANDLE_RESULT;
						return hANDLE_RESULT.GetValueOrDefault() > 0m && hANDLE_RESULT.HasValue;
					});
					if (queryHandler == null || queryHandler.Count() <= 0)
					{
						queryHandler = parentItem.WF_WORKITEM_HANDLER;
					}
				}
				WF_WORKITEM_HANDLER wF_WORKITEM_HANDLER = new WF_WORKITEM_HANDLER();
				wF_WORKITEM_HANDLER.INSTANCE_ID = instance.INSTANCE_ID;
				wF_WORKITEM_HANDLER.WORKITEM_NAME = workItem.WORKITEM_NAME;
				wF_WORKITEM_HANDLER.USER_NAME = item.ReceiverName;
				wF_WORKITEM_HANDLER.ISDEL = 0m;
				wF_WORKITEM_HANDLER.HANDLE_TIME = item.FinishTime;
				wF_WORKITEM_HANDLER.HANDLE_USER_ID = (string.IsNullOrEmpty(item.FinisherID) ? null : new Guid?(new Guid(item.FinisherID)));
				wF_WORKITEM_HANDLER.USER_ID = new Guid(item.ReceiverID);
				wF_WORKITEM_HANDLER.HANDLE_SUGGESTION = item.ApproveSuggestion;
				wF_WORKITEM_HANDLER.WORKITEM_ID = workItem.WORKITEM_ID;
				wF_WORKITEM_HANDLER.WORKITEM_HANDLER_ID = new Guid(item.RID);
				wF_WORKITEM_HANDLER.MODIFYTIME = ((!item.FinishTime.HasValue) ? item.CreateTime.Value : item.FinishTime.Value);
				wF_WORKITEM_HANDLER.CREATOR = ((parentItem == null || queryHandler.Count() == 0) ? new Guid(item.ReceiverID) : queryHandler.ToList()[0].HANDLE_USER_ID.Value);
				wF_WORKITEM_HANDLER.CLIENT_TYPE = 0m;
				wF_WORKITEM_HANDLER.CREATETIME = item.CreateTime.Value;
				wF_WORKITEM_HANDLER.MODIFIER = ((parentItem == null || queryHandler.Count() == 0) ? new Guid(item.ReceiverID) : queryHandler.ToList()[0].HANDLE_USER_ID.Value);
				int? isHandled = item.IsHandled;
				wF_WORKITEM_HANDLER.HANDLE_RESULT = ((isHandled.GetValueOrDefault() == 0 && isHandled.HasValue) ? new decimal?(0m) : workItem.HANDLE_RESULT);
				wF_WORKITEM_HANDLER.HANDLE_USER_NAME = item.FinisherName;
				WF_WORKITEM_HANDLER wfHandler = wF_WORKITEM_HANDLER;
				if (nextWorkItem != null && !wfHandler.HANDLE_USER_ID.HasValue)
				{
					wfHandler.HANDLE_TIME = item.CreateTime;
					wfHandler.HANDLE_USER_ID = new Guid(item.ReceiverID);
					wfHandler.HANDLE_USER_NAME = item.ReceiverName;
				}
				workItem.WF_WORKITEM_HANDLER.Add(wfHandler);
			}
		}
		instance.WF_WORKITEM.Add(workItem);
		if (currentMap.isJump && workitems.Count > 0)
		{
			nextWorkItem = workitems[0];
		}
		if (nextWorkItem != null)
		{
			query = receivers.Where((WFReceiver a) => a.WorkItemID == nextWorkItem.WorkItemID);
			if (query != null && query.Count() > 0)
			{
				sort++;
				WorkflowDataMigration(instance, activitysMapping, workitems, receivers, nextWorkItem, workItem, ref sort);
				return;
			}
			if (workitems.Count == 0)
			{
				sort++;
				WorkflowDataMigration(instance, activitysMapping, workitems, receivers, nextWorkItem, workItem, ref sort);
				return;
			}
			nextWorkItem = workitems[0];
			workItem.HANDLE_RESULT = 2m;
			workitems.RemoveAt(0);
			sort++;
			WorkflowDataMigration(instance, activitysMapping, workitems, receivers, nextWorkItem, workItem, ref sort);
		}
	}

	private void GenerateWorkItem(WF_INSTANCE instance, WF_ACTIVITY startAc, WF_ACTIVITY endAc, WF_WORKITEM parentWorkItem, IList<WF_RULE> ruleList, ref int sort)
	{
		WF_RULE rule = null;
		IEnumerable<WF_RULE> query2 = ruleList.Where((WF_RULE a) => a.FROM_ACTIVITY_ID == startAc.ACTIVITY_ID);
		if (query2 != null && query2.Count() > 0)
		{
			rule = query2.ToList()[0];
		}
		WF_ACTIVITY activity = ((rule == null) ? endAc : template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == rule.TO_ACTIVITY_ID));
		if (activity.ACTIVITY_ID == endAc.ACTIVITY_ID)
		{
			return;
		}
		IEnumerable<WF_WORKITEM_HANDLER> query = parentWorkItem.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER a)
		{
			decimal? hANDLE_RESULT = a.HANDLE_RESULT;
			int result;
			if (hANDLE_RESULT.GetValueOrDefault() != 16384m || !hANDLE_RESULT.HasValue)
			{
				hANDLE_RESULT = a.HANDLE_RESULT;
				result = ((hANDLE_RESULT.GetValueOrDefault() > 0m && hANDLE_RESULT.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		});
		WF_WORKITEM_HANDLER handler = null;
		handler = ((query == null || query.Count() <= 0) ? parentWorkItem.WF_WORKITEM_HANDLER.ToList()[0] : query.ToList()[0]);
		WF_WORKITEM wF_WORKITEM = new WF_WORKITEM();
		wF_WORKITEM.WORKITEM_ID = Guid.NewGuid();
		wF_WORKITEM.ACTIVITY_ID = activity.ACTIVITY_ID;
		wF_WORKITEM.CLIENT_TYPE = 0m;
		wF_WORKITEM.CREATETIME = handler.HANDLE_TIME.Value;
		wF_WORKITEM.MODIFYTIME = handler.HANDLE_TIME.Value;
		wF_WORKITEM.ISDEL = 0m;
		wF_WORKITEM.CREATOR = parentWorkItem.CREATOR;
		wF_WORKITEM.MODIFIER = parentWorkItem.MODIFIER;
		wF_WORKITEM.GENERATE_TYPE = 0m;
		wF_WORKITEM.HANDLE_RESULT = 2m;
		wF_WORKITEM.INSTANCE_ID = instance.INSTANCE_ID;
		wF_WORKITEM.PARENT_WORKITEM_ID = parentWorkItem.WORKITEM_ID;
		wF_WORKITEM.SEND_TIME = handler.HANDLE_TIME;
		wF_WORKITEM.SENDER_USER_ID = handler.HANDLE_USER_ID;
		wF_WORKITEM.SENDER_USER_NAME = handler.HANDLE_USER_NAME;
		wF_WORKITEM.SORT = sort;
		wF_WORKITEM.WORKITEM_NAME = activity.ACTIVITY_NAME;
		wF_WORKITEM.WORKITEM_RUN_STATE = 2m;
		wF_WORKITEM.RULE_ID = rule.RULE_ID;
		WF_WORKITEM workItem = wF_WORKITEM;
		WF_WORKITEM_HANDLER wF_WORKITEM_HANDLER = new WF_WORKITEM_HANDLER();
		wF_WORKITEM_HANDLER.WORKITEM_HANDLER_ID = Guid.NewGuid();
		wF_WORKITEM_HANDLER.CREATETIME = workItem.CREATETIME;
		wF_WORKITEM_HANDLER.MODIFYTIME = workItem.CREATETIME;
		wF_WORKITEM_HANDLER.USER_ID = handler.HANDLE_USER_ID.Value;
		wF_WORKITEM_HANDLER.USER_NAME = handler.HANDLE_USER_NAME;
		wF_WORKITEM_HANDLER.HANDLE_RESULT = 2m;
		wF_WORKITEM_HANDLER.CREATOR = handler.HANDLE_USER_ID.Value;
		wF_WORKITEM_HANDLER.MODIFIER = handler.HANDLE_USER_ID.Value;
		wF_WORKITEM_HANDLER.CLIENT_TYPE = 0m;
		wF_WORKITEM_HANDLER.HANDLE_SUGGESTION = "";
		wF_WORKITEM_HANDLER.HANDLE_TIME = handler.HANDLE_TIME;
		wF_WORKITEM_HANDLER.HANDLE_USER_ID = handler.HANDLE_USER_ID.Value;
		wF_WORKITEM_HANDLER.HANDLE_USER_NAME = handler.HANDLE_USER_NAME;
		wF_WORKITEM_HANDLER.INSTANCE_ID = instance.INSTANCE_ID;
		wF_WORKITEM_HANDLER.ISDEL = 0m;
		wF_WORKITEM_HANDLER.WORKITEM_ID = workItem.WORKITEM_ID;
		wF_WORKITEM_HANDLER.WORKITEM_NAME = workItem.WORKITEM_NAME;
		WF_WORKITEM_HANDLER whandler = wF_WORKITEM_HANDLER;
		workItem.WF_WORKITEM_HANDLER.Add(whandler);
		instance.WF_WORKITEM.Add(workItem);
		sort++;
		GenerateWorkItem(instance, activity, endAc, workItem, ruleList, ref sort);
	}

	private void GetPreActivity(ref IList<WF_RULE> ruleList, WF_ACTIVITY ac)
	{
		IList<WF_RULE> rules = template.WF_RULE.Where(delegate(WF_RULE a)
		{
			int result;
			if (a.TO_ACTIVITY_ID == ac.ACTIVITY_ID && a.ISDEL == 0m)
			{
				decimal? rULE_TYPE = a.RULE_TYPE;
				result = ((rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
		for (int i = 0; i < rules.Count; i++)
		{
			WF_RULE rule = rules[i];
			if (!ruleList.Contains(rule))
			{
				ruleList.Add(rule);
				WF_ACTIVITY wfac = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == rule.FROM_ACTIVITY_ID);
				GetPreActivity(ref ruleList, wfac);
			}
		}
	}

	private void GetAfterActivity(ref IList<WF_RULE> ruleList, WF_ACTIVITY ac)
	{
		IList<WF_RULE> rules = template.WF_RULE.Where(delegate(WF_RULE a)
		{
			int result;
			if (a.FROM_ACTIVITY_ID == ac.ACTIVITY_ID && a.ISDEL == 0m)
			{
				decimal? rULE_TYPE = a.RULE_TYPE;
				result = ((rULE_TYPE.GetValueOrDefault() == 0m && rULE_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
		for (int i = 0; i < rules.Count; i++)
		{
			WF_RULE rule = rules[i];
			if (!ruleList.Contains(rule))
			{
				ruleList.Add(rule);
				WF_ACTIVITY wfac = template.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITY a) => a.ACTIVITY_ID == rule.TO_ACTIVITY_ID);
				GetAfterActivity(ref ruleList, wfac);
			}
		}
	}

	private SYS_ORGDTO getUserOrg(Guid userId)
	{
		Guid orgId = userOrg.SingleOrDefault((SYS_USER_ORG a) => a.USER_ID == userId).ORG_ID;
		return orgList.SingleOrDefault((SYS_ORGDTO a) => a.ORG_ID == orgId);
	}

	private IList<SYS_USERDTO> currentHandler(IEnumerable<WFWorkItem> workitems, IEnumerable<WFReceiver> receivers)
	{
		WFWorkItem query = workitems.SingleOrDefault((WFWorkItem a) => a.IsNew == 1);
		IList<SYS_USERDTO> users = new List<SYS_USERDTO>();
		if (query != null)
		{
			IEnumerable<WFReceiver> currentReceiver = receivers.Where((WFReceiver a) => a.WorkItemID == query.WorkItemID);
			foreach (WFReceiver receiver in currentReceiver)
			{
				IList<SYS_USERDTO> source = userList;
				Func<SYS_USERDTO, bool> predicate = (SYS_USERDTO a) => a.USER_ID == new Guid(receiver.ReceiverID);
				source.Where(predicate);
			}
		}
		return users;
	}

	private RUN_STATE translateRunState(int status)
	{
		return status switch
		{
			1 => RUN_STATE.Running, 
			2 => RUN_STATE.Suspended, 
			3 => RUN_STATE.Running, 
			4 => RUN_STATE.Terminated, 
			5 => RUN_STATE.Finished, 
			_ => RUN_STATE.Running, 
		};
	}

	private HANDLE_RESULT translateHandleResult(int status)
	{
		return status switch
		{
			0 => HANDLE_RESULT.None, 
			1 => HANDLE_RESULT.Return, 
			2 => HANDLE_RESULT.Adopt, 
			_ => HANDLE_RESULT.None, 
		};
	}

	internal IDTO GetAccountDataByInstanceId(Guid instanceId, Guid? pId = null)
	{
		WF_INSTANCE instance = repositoryInstance.GetByKey(instanceId);
		WF_TEMPLATEDTO single = WorkflowCacheManager.GetTemplateById(instance.TEMPLATE_ID.Value);
		Type t = Type.GetType($"{single.TEMPLATE_CODE_PATH},Richfit.Garnet.Module.Workflow.Form");
		runWorkflow = (IRunWorkflow)Activator.CreateInstance(t);
		runWorkflow.InstanceId = instance.INSTANCE_ID;
		return runWorkflow.GetAccountDataByInstanceId(instanceId, pId);
	}

	internal void EditAccount(Guid instanceId, string formData)
	{
		WF_INSTANCE instance = repositoryInstance.GetByKey(instanceId);
		WF_TEMPLATEDTO single = WorkflowCacheManager.GetTemplateById(instance.TEMPLATE_ID.Value);
		Type t = Type.GetType($"{single.TEMPLATE_CODE_PATH},Richfit.Garnet.Module.Workflow.Form");
		runWorkflow = (IRunWorkflow)Activator.CreateInstance(t);
		runWorkflow.InstanceId = instance.INSTANCE_ID;
		runWorkflow.EditAccount(formData);
	}

	private string OracleToDotNet(string text)
	{
		byte[] bytes = ParseHex(text);
		return new Guid(bytes).ToString().ToUpperInvariant();
	}

	private byte[] ParseHex(string text)
	{
		byte[] ret = new byte[text.Length / 2];
		for (int i = 0; i < ret.Length; i++)
		{
			ret[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
		}
		return ret;
	}

	internal bool Authentication(WF_WORKITEMDTO instanceDTO)
	{
		instanceDTO.USER_ID = SessionContext.UserInfo.UserID;
		if (!instanceDTO.INSTANCE_ID.HasValue)
		{
			IList<WF_TEMPLATE> list = SqlQuery<WF_TEMPLATE>("GetAuthenticationStart", instanceDTO);
			return list.Count > 0;
		}
		IList<WF_WORKITEMDTO> itemList = SqlQuery<WF_WORKITEMDTO>("GetAuthenticationProve", instanceDTO);
		return itemList.Count > 0;
	}
}
