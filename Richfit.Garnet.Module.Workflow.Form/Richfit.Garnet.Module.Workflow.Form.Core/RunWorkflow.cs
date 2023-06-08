using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Xml;
using cn.jpush.api;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using Newtonsoft.Json;
using Richfit.Garnet.Common;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Email;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Application.Services;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.Components;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Message.entinfo;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Extend.Application.Services;
using Richfit.Garnet.Module.Workflow.Form.Application.DTO;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Core;

public class RunWorkflow : ServiceBase
{
	private delegate void PushNotificationToMobileDelegate(WF_INSTANCE currentInstance, WF_WORKITEM item, WF_ACTIVITY activity);

	private static readonly ILogger logExp = LoggerManager.GetLogger("Exception");

	private ISystemUserService userService = ServiceLocator.Instance.GetService<ISystemUserService>();

	protected SqlRepository repository;

	protected Guid instanceId;

	protected string strMailServer;

	protected string strUserAccount;

	protected string strUserPassword;

	public Guid InstanceId
	{
		get
		{
			return instanceId;
		}
		set
		{
			instanceId = value;
		}
	}

	public RunWorkflow()
	{
		repository = new SqlRepository(null);
	}

	protected List<User> GetActivityParticipantOnlyUser(WF_INSTANCE currentInstance, Guid? activityId, Guid? orgId, string participantType = "0")
	{
		ActivityService activityService = new ActivityService();
		InstanceParticipantService instanceParticipantService = new InstanceParticipantService();
		List<Guid> normalRoleIds = new List<Guid>();
		List<Guid> globalRoleIds = new List<Guid>();
		List<Guid> activitys = new List<Guid>();
		List<User> users = new List<User>();
		bool flag;
		if (participantType == "1")
		{
			activitys.Add(activityId.Value);
		}
		else
		{
			flag = 1 == 0;
			List<WF_INSTANCE_ACTIVITY> instanceActivitys = instanceParticipantService.GetInstanceActivityByInstanceId(instanceId, activityId.Value);
			WF_INSTANCE_ACTIVITY instanceActivity = null;
			if (instanceActivitys != null && instanceActivitys.Count() > 0)
			{
				instanceActivity = instanceActivitys.ToList()[0];
			}
			if (instanceActivity != null && instanceActivity.WF_INSTANCE_ACTIVITY_USER != null && instanceActivity.WF_INSTANCE_ACTIVITY_USER.Count() > 0)
			{
				instanceActivity.WF_INSTANCE_ACTIVITY_USER.ForEach(delegate(WF_INSTANCE_ACTIVITY_USER a)
				{
					users.Add(new User
					{
						CURRENT_USER_ID = a.USER_ID,
						CURRENT_USER_NAME = a.USER_NAME
					});
				});
				return users;
			}
			IList<WF_ACTIVITY_PARTICIPANTDTO> activityParticipantCollection = activityService.GetActivityParticipantByActivityId(activityId.Value);
			foreach (WF_ACTIVITY_PARTICIPANTDTO item4 in activityParticipantCollection)
			{
				switch (int.Parse(item4.PARTICIPANT_TYPE.ToString()))
				{
				case 0:
					normalRoleIds.Add(item4.PARTICIPANT_ID);
					break;
				case 1:
					globalRoleIds.Add(item4.PARTICIPANT_ID);
					break;
				case 2:
					activitys.Add(item4.PARTICIPANT_ID);
					break;
				}
			}
		}
		List<SYS_USERDTO> userDTO = new List<SYS_USERDTO>();
		QueryCondition queryCondition = new QueryCondition();
		if (normalRoleIds.Count > 0 || globalRoleIds.Count > 0)
		{
			queryCondition.Add(new QueryItem
			{
				Key = "ORG_ID",
				Value = orgId.ToString(),
				Method = " = ",
				Type = "guid"
			});
			List<string> normalRoleIdList = new List<string>();
			List<string> globalRoleIdList = new List<string>();
			normalRoleIds.ForEach(delegate(Guid a)
			{
				normalRoleIdList.Add(Utility.GetGuidString(a));
			});
			globalRoleIds.ForEach(delegate(Guid a)
			{
				globalRoleIdList.Add(Utility.GetGuidString(a));
			});
			queryCondition.Add(new QueryItem
			{
				Key = "NORMAL_ROLE_IDS",
				Value = normalRoleIdList.JoinString(","),
				Method = " Like ",
				Type = "string"
			});
			queryCondition.Add(new QueryItem
			{
				Key = "GLOBAL_ROLE_IDS",
				Value = globalRoleIdList.JoinString(","),
				Method = " Like ",
				Type = "string"
			});
			ResponseData result = AccessManager.ServiceAccess("Workflow", "SystemManagement_GetWorkflowParticipant", queryCondition.JsonSerialize());
			userDTO.AddRange(result.Data.JsonDeserialize<IList<SYS_USERDTO>>(new JsonConverter[0]));
		}
		flag = 1 == 0;
		foreach (Guid item3 in activitys)
		{
			queryCondition.Add(new QueryItem
			{
				Key = "ACTIVITY_ID",
				Value = item3.ToString(),
				Method = " = ",
				Type = "guid"
			});
			queryCondition.Add(new QueryItem
			{
				Key = "INSTANCE_ID",
				Value = instanceId.ToString(),
				Method = " = ",
				Type = "guid"
			});
			userDTO.AddRange(SqlQueryResult<SYS_USERDTO>("GetWorkflowParticipantByActivityID", queryCondition, typeof(InstanceService_v2)).List);
		}
		if (userDTO.Count == 0 && currentInstance != null)
		{
			foreach (Guid item2 in activitys)
			{
				ICollection<WF_WORKITEM> wF_WORKITEM = currentInstance.WF_WORKITEM;
				Func<WF_WORKITEM, bool> predicate = delegate(WF_WORKITEM a)
				{
					int result2;
					if (a.ACTIVITY_ID == item2)
					{
						decimal? hANDLE_RESULT2 = a.HANDLE_RESULT;
						result2 = ((hANDLE_RESULT2.GetValueOrDefault() == 2m && hANDLE_RESULT2.HasValue) ? 1 : 0);
					}
					else
					{
						result2 = 0;
					}
					return (byte)result2 != 0;
				};
				wF_WORKITEM.Where(predicate)?.ForEach(delegate(WF_WORKITEM a)
				{
					a.WF_WORKITEM_HANDLER.Where(delegate(WF_WORKITEM_HANDLER b)
					{
						decimal? hANDLE_RESULT = b.HANDLE_RESULT;
						return hANDLE_RESULT.GetValueOrDefault() == 2m && hANDLE_RESULT.HasValue;
					})?.ForEach(delegate(WF_WORKITEM_HANDLER handler)
					{
						users.Add(new User
						{
							CURRENT_USER_ID = handler.USER_ID,
							CURRENT_USER_NAME = handler.USER_NAME,
							PROXY_USER_ID = handler.USER_ID,
							PROXY_USER_NAME = handler.USER_NAME
						});
					});
				});
			}
		}
		foreach (SYS_USERDTO item in userDTO)
		{
			List<User> source = users;
			Func<User, bool> predicate2 = (User a) => a.CURRENT_USER_ID == item.USER_ID;
			IEnumerable<User> query = source.Where(predicate2);
			if (query == null || query.Count() <= 0)
			{
				users.Add(new User
				{
					CURRENT_USER_ID = item.USER_ID,
					CURRENT_USER_NAME = item.DISPLAY_NAME,
					PROXY_USER_ID = item.USER_ID,
					PROXY_USER_NAME = item.DISPLAY_NAME,
					CURRENT_ORG_ID = item.ORG_ID,
					CURRENT_ORG_NAME = item.ORG_NAME,
					PROXY_ORG_ID = item.ORG_ID,
					PROXY_ORG_NAME = item.ORG_NAME
				});
			}
		}
		return users;
	}

	protected bool Add<T>(T t) where T : IDTO
	{
		InitCreate(t);
		repository.ExecuteCommand(t.AddSql, t);
		return true;
	}

	protected bool Update<T>(T t) where T : IDTO
	{
		InitUpdate(t);
		repository.ExecuteCommand(t.UpdateSql, t);
		return true;
	}

	private void InitCreate<T>(T t)
	{
		Type type = t.GetType();
		PropertyInfo[] pis = type.GetProperties();
		Guid id = Guid.Empty;
		PropertyInfo[] array = pis;
		foreach (PropertyInfo propertyInfo in array)
		{
			object value = propertyInfo.GetValue(t);
			switch (propertyInfo.Name)
			{
			case "CREATOR":
				propertyInfo.SetValue(t, SessionContext.UserInfo.UserID);
				break;
			case "INSTANCE_ID":
				propertyInfo.SetValue(t, instanceId);
				break;
			case "CREATETIME":
				propertyInfo.SetValue(t, DateTime.Now);
				break;
			case "MODIFYTIME":
				propertyInfo.SetValue(t, DateTime.Now);
				break;
			case "MODIFIER":
				propertyInfo.SetValue(t, SessionContext.UserInfo.UserID);
				break;
			case "USER_ID":
				if (setId(value))
				{
					propertyInfo.SetValue(t, SessionContext.UserInfo.UserID);
				}
				break;
			case "USER_NAME":
				if (value == null || string.IsNullOrEmpty(value.ToString()))
				{
					propertyInfo.SetValue(t, SessionContext.UserInfo.UserName);
				}
				break;
			case "ORG_ID":
				if (setId(value))
				{
					propertyInfo.SetValue(t, SessionContext.UserInfo.BelongToOrgID);
				}
				break;
			case "ORG_NAME":
				if (value == null || string.IsNullOrEmpty(value.ToString()))
				{
					propertyInfo.SetValue(t, OrgUserCacheManager.GetOrgByKey(SessionContext.UserInfo.BelongToOrgID).ORG_NAME);
				}
				break;
			case "ISDEL":
				propertyInfo.SetValue(t, 0m);
				break;
			}
			IList<CustomAttributeData> attributeList = propertyInfo.GetCustomAttributesData();
			foreach (CustomAttributeData attribute in attributeList)
			{
				if (attribute.AttributeType == typeof(PrimaryAttribute) && setId(value))
				{
					id = Guid.NewGuid();
					propertyInfo.SetValue(t, Guid.NewGuid());
				}
			}
		}
	}

	private bool setId(object value)
	{
		if (value == null)
		{
			return true;
		}
		try
		{
			Guid guid = new Guid(value.ToString());
			return guid == Guid.NewGuid();
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void InitUpdate<T>(T t)
	{
		Type type = t.GetType();
		PropertyInfo[] pis = type.GetProperties();
		PropertyInfo[] array = pis;
		foreach (PropertyInfo propertyInfo in array)
		{
			object value = propertyInfo.GetValue(t);
			switch (propertyInfo.Name)
			{
			case "MODIFYTIME":
				propertyInfo.SetValue(t, DateTime.Now);
				break;
			case "MODIFIER":
				propertyInfo.SetValue(t, SessionContext.UserInfo.UserID);
				break;
			}
		}
	}

	internal T FindByInstanceId<T>(Guid instanceId) where T : IDTO
	{
		Type t = typeof(T);
		IDTO dto = (IDTO)Activator.CreateInstance(t);
		IList<T> dtoList = repository.ExecuteQuery<T>(dto.FindByInstance, new
		{
			INSTANCE_ID = instanceId
		});
		if (dtoList.Any())
		{
			return dtoList[0];
		}
		return default(T);
	}

	internal List<T> FindListByInstanceId<T>(Guid instanceId) where T : IDTO
	{
		Type t = typeof(T);
		IDTO dto = (IDTO)Activator.CreateInstance(t);
		IList<T> dtoList = repository.ExecuteQuery<T>(dto.FindByInstance, new
		{
			INSTANCE_ID = instanceId
		});
		if (dtoList != null)
		{
			return dtoList.ToList();
		}
		return new List<T>();
	}

	public virtual void SendMessage(WF_INSTANCE currentInstance, WF_WORKITEM item, WF_ACTIVITY activity, User senderUser, string emailTemplate = "NextApprover")
	{
		if (Bit.pro((long)activity.STATUS.Value, "11|1") == 1)
		{
			List<User> userList = new List<User>();
			foreach (WF_WORKITEM_HANDLER handler in item.WF_WORKITEM_HANDLER)
			{
				userList.Add(new User
				{
					CURRENT_USER_ID = handler.USER_ID
				});
			}
			SendEmail(currentInstance, item, userList, emailTemplate);
		}
		if (ConfigurationManager.System.Settings.GetSetting("EnableJPush", defaultValue: false))
		{
			PushNotificationToMobileDelegate del = PushNotificationToMobile;
			del.BeginInvoke(currentInstance, item, activity, null, null);
		}
	}

	public virtual void SendToMsg(WF_INSTANCE currentInstance, WF_WORKITEM workItem, WF_ACTIVITY nextActivity, User senderUser)
	{
		bool enableSendMail = ConfigurationManager.System.Settings.GetSetting("EnableSendMessage", defaultValue: false);
		string Sn = ConfigurationManager.System.Settings.GetSetting<string>("SendMessage_Sn");
		string Pwd = ConfigurationManager.System.Settings.GetSetting<string>("SendMessage_Pwd");
		if (!enableSendMail)
		{
			return;
		}
		string browserName = "";
		string IP = "";
		try
		{
			browserName = HttpContext.Current.Request.Browser.Browser + " " + HttpContext.Current.Request.Browser.Version;
			IP = GetCurrentUserHostAddress();
		}
		catch
		{
		}
		MessageService messageService = new MessageService();
		string path = HttpContext.Current.Server.MapPath("/Packages/WorkflowManagement/Config/MessageTemplate.xml");
		XmlDocument doc = new XmlDocument();
		XmlReaderSettings settings = new XmlReaderSettings();
		settings.IgnoreComments = true;
		XmlReader reader = XmlReader.Create(path, settings);
		doc.Load(reader);
		XmlNode xn = doc.SelectSingleNode("MessageInfo");
		List<WF_MESSAGEDTO> MessageList = new List<WF_MESSAGEDTO>();
		WF_MESSAGEDTO MessageDTO;
		foreach (XmlNode node in xn.ChildNodes)
		{
			XmlElement element = (XmlElement)node;
			MessageDTO = new WF_MESSAGEDTO();
			MessageDTO.TYPE = element.GetAttribute("Type");
			MessageDTO.NAME = element.GetAttribute("Name");
			MessageDTO.TEXT = element.SelectSingleNode("Text").InnerText;
			MessageList.Add(MessageDTO);
		}
		decimal? gENERATE_TYPE = workItem.GENERATE_TYPE;
		SqlRepository repository;
		string sqlExpress;
		global::_003C_003Ef__AnonymousType2<Guid> parm;
		if (gENERATE_TYPE.GetValueOrDefault() == 0m && gENERATE_TYPE.HasValue)
		{
			IList<HR_EMPLOYEEDTO> empDTOS = new List<HR_EMPLOYEEDTO>();
			foreach (WF_WORKITEM_HANDLER handler in workItem.WF_WORKITEM_HANDLER)
			{
				var parm2 = new
				{
					USER_ID = handler.USER_ID,
					RESOURCES_ID = currentInstance.TEMPLATE_ID
				};
				sqlExpress = this.repository.GetSqlConfig("GetMessageNoticeUser", typeof(WF_ACTIVITYDTO));
				IList<HR_EMPLOYEEDTO> temp = this.repository.ExecuteQuery<HR_EMPLOYEEDTO>(sqlExpress, parm2);
				empDTOS.AddRange(temp);
			}
			gENERATE_TYPE = nextActivity.ACTIVITY_TYPE;
			if (gENERATE_TYPE.GetValueOrDefault() == 100m && gENERATE_TYPE.HasValue)
			{
				MessageDTO = MessageList.Where((WF_MESSAGEDTO t) => t.TYPE == "Finished").FirstOrDefault();
				repository = new SqlRepository(null);
				sqlExpress = repository.GetSqlConfig("GetMessageNoticeUser", typeof(WF_ACTIVITYDTO));
				parm = new
				{
					USER_ID = currentInstance.START_USER_ID
				};
				HR_EMPLOYEEDTO empDTO2 = repository.ExecuteQuery<HR_EMPLOYEEDTO>(sqlExpress, parm).FirstOrDefault();
				if (empDTO2 != null && !string.IsNullOrEmpty(empDTO2.PHONE) && CheckPhoneIsAble(empDTO2.PHONE) && MessageDTO != null && !string.IsNullOrEmpty(MessageDTO.TEXT))
				{
					string Text3 = MessageDTO.TEXT;
					Text3 = string.Format(Text3, currentInstance.START_USER_NAME, currentInstance.INSTANCE_NAME);
					messageService.SendToMessage(() => new MessageInfo
					{
						Mobile = new string[1] { empDTO2.PHONE },
						Sn = Sn,
						Pwd = Pwd,
						Content = Text3
					}, currentInstance.INSTANCE_ID, workItem.WORKITEM_ID, IP, browserName);
				}
				return;
			}
			MessageDTO = MessageList.Where((WF_MESSAGEDTO t) => t.TYPE == "NextApprover").FirstOrDefault();
			if (MessageDTO == null)
			{
				return;
			}
			{
				foreach (HR_EMPLOYEEDTO item in empDTOS)
				{
					if (!string.IsNullOrEmpty(item.PHONE) && CheckPhoneIsAble(item.PHONE))
					{
						string Text2 = MessageDTO.TEXT;
						Text2 = string.Format(Text2, item.FULL_NAME, currentInstance.INSTANCE_NAME);
						messageService.SendToMessage(() => new MessageInfo
						{
							Mobile = new string[1] { item.PHONE },
							Sn = Sn,
							Pwd = Pwd,
							Content = Text2
						}, currentInstance.INSTANCE_ID, workItem.WORKITEM_ID, IP, browserName);
					}
				}
				return;
			}
		}
		gENERATE_TYPE = workItem.GENERATE_TYPE;
		if (!(gENERATE_TYPE.GetValueOrDefault() == 1m) || !gENERATE_TYPE.HasValue)
		{
			return;
		}
		MessageDTO = MessageList.Where((WF_MESSAGEDTO t) => t.TYPE == "Rejected").FirstOrDefault();
		repository = new SqlRepository(null);
		sqlExpress = repository.GetSqlConfig("GetMessageNoticeUser", typeof(WF_ACTIVITYDTO));
		parm = new
		{
			USER_ID = currentInstance.START_USER_ID
		};
		HR_EMPLOYEEDTO empDTO = repository.ExecuteQuery<HR_EMPLOYEEDTO>(sqlExpress, parm).FirstOrDefault();
		if (empDTO != null && !string.IsNullOrEmpty(empDTO.PHONE) && CheckPhoneIsAble(empDTO.PHONE) && MessageDTO != null && !string.IsNullOrEmpty(MessageDTO.TEXT))
		{
			string Text = MessageDTO.TEXT;
			Text = string.Format(Text, currentInstance.START_USER_NAME, currentInstance.INSTANCE_NAME);
			messageService.SendToMessage(() => new MessageInfo
			{
				Mobile = new string[1] { empDTO.PHONE },
				Sn = Sn,
				Pwd = Pwd,
				Content = Text
			}, currentInstance.INSTANCE_ID, workItem.WORKITEM_ID, IP, browserName);
		}
	}

	private string GetCurrentUserHostAddress()
	{
		string AddressIP = string.Empty;
		string hostName = Dns.GetHostName();
		IPAddress[] addresses = Dns.GetHostAddresses(hostName);
		for (int i = 0; i < addresses.Length; i++)
		{
			if (addresses[i].AddressFamily.ToString() == "InterNetwork")
			{
				AddressIP = addresses[i].ToString();
			}
		}
		return AddressIP;
	}

	private bool CheckPhoneIsAble(string input)
	{
		if (input.Length < 11)
		{
			return false;
		}
		string dianxin = "^1[3578][01379]\\d{8}$";
		Regex regexDX = new Regex(dianxin);
		string liantong = "^1[34578][01256]\\d{8}";
		Regex regexLT = new Regex(liantong);
		string yidong = "^(1[012345678]\\d{8}|1[345678][012356789]\\d{8})$";
		Regex regexYD = new Regex(yidong);
		if (regexDX.IsMatch(input) || regexLT.IsMatch(input) || regexYD.IsMatch(input))
		{
			return true;
		}
		return false;
	}

	private void PushNotificationToMobile(WF_INSTANCE currentInstance, WF_WORKITEM item, WF_ACTIVITY activity)
	{
		if (item.WF_WORKITEM_HANDLER.Count <= 0)
		{
			return;
		}
		string AppKey = ConfigurationManager.System.Settings.GetSetting<string>("AppKey");
		string MasterSecret = ConfigurationManager.System.Settings.GetSetting<string>("MasterSecret");
		string MessageContent = ConfigurationManager.System.Settings.GetSetting<string>("MessageContent");
		JPushClient client = new JPushClient(AppKey, MasterSecret);
		foreach (WF_WORKITEM_HANDLER handler in item.WF_WORKITEM_HANDLER)
		{
			WF_WORKITEMDTO wF_WORKITEMDTO = new WF_WORKITEMDTO();
			wF_WORKITEMDTO.USER_ID = handler.USER_ID;
			wF_WORKITEMDTO.ISMOBILE = 1m;
			wF_WORKITEMDTO.PageIndex = 0;
			wF_WORKITEMDTO.SortBy = "START_TIME DESC";
			WF_WORKITEMDTO paramTodo = wF_WORKITEMDTO;
			QueryResult<WF_WORKITEMDTO> sjzxTaskList = new WorkflowExtendService().GetWorkItemPager(paramTodo);
			SYS_USERDTO user = userService.GetUserById(handler.USER_ID);
			CNPCTaskListDTO cnpcTaskList = new SendMeassageToRuiXin().GetCNPCTaskList(user.LOGON_NAME);
			PushPayload pushLoad = new PushPayload();
			pushLoad.platform = Platform.all();
			pushLoad.ResetOptionsApnsProduction(apnsProduction: true);
			pushLoad.audience = Audience.s_alias(handler.USER_ID.ToString().Replace("-", "").ToLower());
			AndroidNotification androidNotification = new AndroidNotification().AddExtra("Type", "Todo").AddExtra("SJZXCount", (1 + sjzxTaskList.RecordCount).ToString()).AddExtra("CNPCCount", cnpcTaskList.TaskCount)
				.AddExtra("Ht_TaskCount", cnpcTaskList.Ht_TaskCount)
				.AddExtra("Gw_TaskCount", cnpcTaskList.Gw_TaskCount)
				.AddExtra("Bx_TaskCount", cnpcTaskList.Bx_TaskCount)
				.AddExtra("TemplateID", activity.TEMPLATE_ID)
				.AddExtra("ActivityID", item.ACTIVITY_ID)
				.AddExtra("InstanceID", item.INSTANCE_ID)
				.AddExtra("INSTANCE_NAME", currentInstance.INSTANCE_NAME)
				.AddExtra("WorkItemID", item.WORKITEM_ID)
				.AddExtra("PROXY_USER_ID", user.USER_ID)
				.AddExtra("PROXY_USER_NAME", user.DISPLAY_NAME)
				.AddExtra("PROXY_ORG_ID", currentInstance.ORG_ID)
				.AddExtra("PROXY_ORG_NAME", currentInstance.ORG_NAME);
			IosNotification iosNotification = new IosNotification().AddExtra("Type", "Todo").AddExtra("SJZXCount", (1 + sjzxTaskList.RecordCount).ToString()).AddExtra("CNPCCount", cnpcTaskList.TaskCount)
				.AddExtra("Ht_TaskCount", cnpcTaskList.Ht_TaskCount)
				.AddExtra("Gw_TaskCount", cnpcTaskList.Gw_TaskCount)
				.AddExtra("Bx_TaskCount", cnpcTaskList.Bx_TaskCount)
				.AddExtra("TemplateID", activity.TEMPLATE_ID)
				.AddExtra("ActivityID", item.ACTIVITY_ID)
				.AddExtra("InstanceID", item.INSTANCE_ID)
				.AddExtra("INSTANCE_NAME", currentInstance.INSTANCE_NAME)
				.AddExtra("WorkItemID", item.WORKITEM_ID)
				.AddExtra("PROXY_USER_ID", user.USER_ID)
				.AddExtra("PROXY_USER_NAME", user.DISPLAY_NAME)
				.AddExtra("PROXY_ORG_ID", currentInstance.ORG_ID)
				.AddExtra("PROXY_ORG_NAME", currentInstance.ORG_NAME);
			pushLoad.notification = new Notification().setAlert(MessageContent).setAndroid(androidNotification).setIos(iosNotification);
			try
			{
				MessageResult result = client.SendPush(pushLoad);
			}
			catch (APIRequestException e2)
			{
				logExp.Error("Error response from JPush server. Should review and fix it.");
				logExp.Error("HTTP Status: " + e2.Status);
				logExp.Error("Error Code: " + e2.ErrorCode);
				logExp.Error("Error Message: " + e2.ErrorMessage);
				logExp.Error("Audience: " + user.DISPLAY_NAME);
			}
			catch (APIConnectionException e)
			{
				logExp.Error("Failed to establish JPush API connection.");
				logExp.Error(e.Message);
			}
		}
	}

	private void SendToRuiXin(WF_INSTANCE currentInstance, WF_WORKITEM item, User senderUser)
	{
		WF_TEMPLATEDTO dtoTemplate = WorkflowCacheManager.GetTemplateById(currentInstance.TEMPLATE_ID.Value);
		WF_ACTIVITYDTO activity = dtoTemplate.WF_ACTIVITY.SingleOrDefault((WF_ACTIVITYDTO a) => a.ACTIVITY_ID == item.ACTIVITY_ID);
		if (Bit.pro((long)activity.STATUS.Value, "4|1") != 1)
		{
			return;
		}
		new Thread((ThreadStart)delegate
		{
			foreach (WF_WORKITEM_HANDLER current in item.WF_WORKITEM_HANDLER)
			{
				try
				{
					ResponseData responseData = AccessManager.ServiceAccess("Workflow", "SystemManagement_GetUserByKey", new { current.USER_ID }.JsonSerialize());
					SYS_USERDTO sYS_USERDTO = responseData.Data.JsonDeserialize<SYS_USERDTO>(new JsonConverter[0]);
					new SendMeassageToRuiXin().SendNoticeToRuiXin(currentInstance.INSTANCE_NAME, sYS_USERDTO.LOGON_NAME);
				}
				catch (Exception exception)
				{
					LogException(exception);
				}
			}
		}).Start();
	}

	public string PostRequest(string headValue, string url, string data)
	{
		byte[] bData = Encoding.Default.GetBytes(data);
		string strResult = string.Empty;
		HttpWebRequest hwRequest;
		try
		{
			hwRequest = (HttpWebRequest)WebRequest.Create(url);
			hwRequest.Timeout = 500000;
			hwRequest.Method = "POST";
			hwRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
			hwRequest.ContentLength = bData.Length;
			hwRequest.Headers.Add("serviceName", headValue);
			Stream smWrite = hwRequest.GetRequestStream();
			smWrite.Write(bData, 0, bData.Length);
			smWrite.Close();
		}
		catch (Exception err2)
		{
			LogException(err2);
			return strResult;
		}
		try
		{
			HttpWebResponse hwResponse = (HttpWebResponse)hwRequest.GetResponse();
			StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.UTF8);
			strResult = srReader.ReadToEnd();
			srReader.Close();
			hwResponse.Close();
		}
		catch (Exception err2)
		{
			LogException(err2);
		}
		return strResult;
	}

	private void LogException(Exception exception)
	{
		string exceptionMessage = GetExceptionMessage(exception);
		if (!string.IsNullOrEmpty(exceptionMessage))
		{
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = string.Format(exceptionMessage);
			logExp.Error(logEntry.ToJson());
		}
	}

	private string GetExceptionMessage(Exception exception)
	{
		StringBuilder sbErrors = new StringBuilder();
		if (exception.IsCustomCodeException())
		{
			CustomCodeException cce = exception as CustomCodeException;
			sbErrors.AppendLine("CustomCodeException:Code:" + cce.ErrorCode);
			sbErrors.AppendLine(GetExceptionMessage(cce.Exception));
		}
		else if (exception.IsValidationException())
		{
			ValidationException avee = exception as ValidationException;
			sbErrors.AppendLine("ValidationException:Code:" + avee.ValidateCode + "Messages:" + avee.ToString());
		}
		else if (exception.IsDbUpdateConcurrencyException())
		{
			DbUpdateConcurrencyException ex = (DbUpdateConcurrencyException)(object)exception;
			sbErrors.AppendLine("DbUpdateConcurrencyException:" + ex.Entries.First().Entity.GetType().Name);
		}
		else if (exception.IsDbEntityValidationException())
		{
			DbEntityValidationException deve = (DbEntityValidationException)(object)exception;
			foreach (DbEntityValidationResult eve in deve.EntityValidationErrors)
			{
				sbErrors.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
				foreach (DbValidationError ve in eve.ValidationErrors)
				{
					sbErrors.AppendFormat("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
				}
			}
		}
		else if (exception.IsSqlExecuteException())
		{
			sbErrors.Append("SqlExecuteException:" + (exception as SqlExecuteException).ToString());
		}
		sbErrors.AppendLine("Exception occured: " + exception.Message);
		sbErrors.AppendLine("StackTrace:" + Environment.StackTrace);
		return sbErrors.ToString();
	}

	public virtual void EditAccount(string dateJson)
	{
		throw new CustomCodeException("您尚未实现EditAccount接口");
	}

	protected void SendSiteMessage(WF_INSTANCE currentInstance, WF_WORKITEM item, User senderUser)
	{
		if (currentInstance == null)
		{
			return;
		}
		decimal? rUN_STATE = currentInstance.RUN_STATE;
		if (!(rUN_STATE.GetValueOrDefault() != 2m) && rUN_STATE.HasValue)
		{
			return;
		}
		IMessageCenterService MessageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();
		List<MSG_CENTER_USERDTO> msuser = new List<MSG_CENTER_USERDTO>();
		foreach (WF_WORKITEM_HANDLER handler in item.WF_WORKITEM_HANDLER)
		{
			msuser.Add(new MSG_CENTER_USERDTO
			{
				ISREAD = 0m,
				USER_ID = handler.USER_ID,
				USER_NAME = handler.USER_NAME,
				ISIM = 0m,
				SORT = 0m
			});
		}
		MessageCenterService.AddMessage(new MSG_CENTERDTO
		{
			SEND_USER_ID = senderUser.CURRENT_USER_ID,
			MSG_TITLE = currentInstance.INSTANCE_NAME,
			SEND_TIME = DateTime.Now,
			SEND_USER_NAME = senderUser.CURRENT_USER_NAME,
			SEND_ORG_ID = senderUser.CURRENT_ORG_ID,
			SEND_ORG_NAME = senderUser.CURRENT_ORG_NAME,
			MSG_TYPE = 1m,
			MSG_OPEN_TYPE = 2m,
			MSG_BUSINESS_ID = currentInstance.INSTANCE_ID,
			MSG_SOURCE = $"href?TemplateID={currentInstance.TEMPLATE_ID}&ActivityID={item.ACTIVITY_ID}&InstanceID={currentInstance.INSTANCE_ID}&WorkItemID={item.WORKITEM_ID}",
			MSG_CENTER_USER = msuser.ToList()
		});
	}

	protected void SendEmail(WF_INSTANCE currentInstance, WF_WORKITEM workItem, List<User> toUser, string mailTemplate)
	{
		if (toUser == null || toUser.Count == 0)
		{
			return;
		}
		strMailServer = ConfigurationManager.CurrentPackage.Settings.GetSetting("SendMail_ServerAddress").ToString();
		strUserAccount = ConfigurationManager.CurrentPackage.Settings.GetSetting("SendMail_UserAccount").ToString();
		strUserPassword = ConfigurationManager.CurrentPackage.Settings.GetSetting("SendMail_UserPassword").ToString();
		WF_MAILDTO dto = GetMailTemplate(mailTemplate);
		string sql = "";
		foreach (User item2 in toUser)
		{
			sql += $"f_guidtoraw('{item2.CURRENT_USER_ID}'),";
		}
		IList<HR> hrList = SqlQuery<HR>("GetUserEmail", null, (string a) => a.Replace("@USER_ID", sql));
		string strToUserAccount = "";
		foreach (HR item in hrList)
		{
			strToUserAccount = strToUserAccount + item.MAIL + ";";
		}
		string strTitle = string.Format(dto.TITLE, currentInstance.START_USER_NAME, currentInstance.INSTANCE_NAME);
		string strBody = string.Format(dto.BODY, currentInstance.START_USER_NAME, currentInstance.INSTANCE_NAME, currentInstance.START_USER_NAME + "/" + currentInstance.ORG_NAME + DateTime.Parse(currentInstance.START_TIME.ToString()).ToString("dd/MM/yyyy"));
		EmailManager.SendToEmail(strMailServer, strToUserAccount, strUserAccount, strUserPassword, strTitle, strBody);
	}

	protected WF_MAILDTO GetMailTemplate(string name)
	{
		string path = HttpContext.Current.Server.MapPath("/Packages/WorkflowForm/Config/MailInfo.xml");
		XmlDocument doc = new XmlDocument();
		XmlReaderSettings settings = new XmlReaderSettings();
		settings.IgnoreComments = true;
		XmlReader reader = XmlReader.Create(path, settings);
		doc.Load(reader);
		XmlNode xn = doc.SelectSingleNode("MailInfo");
		XmlNodeList list = xn.ChildNodes;
		foreach (XmlNode node in list)
		{
			if (((XmlElement)node).GetAttribute("Name") == name)
			{
				XmlElement element = (XmlElement)node;
				WF_MAILDTO mailDTO = new WF_MAILDTO();
				mailDTO.TYPE = element.GetAttribute("Type");
				mailDTO.NAME = element.GetAttribute("Name");
				XmlNodeList xnl0 = element.ChildNodes;
				mailDTO.TITLE = xnl0.Item(0).InnerText;
				mailDTO.BODY = xnl0.Item(1).InnerText;
				return mailDTO;
			}
		}
		throw new CustomCodeException("未找到邮件模板");
	}

	public virtual bool SpecialOperation(WF_TEMPLATE template, WF_INSTANCE instance, HANDLE_RESULT handleResult)
	{
		try
		{
			return true;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public virtual IDTO GetAccountDataByInstanceId(Guid instanceId, Guid? pid)
	{
		throw new CustomCodeException("您尚未实现GetAccountDataByInstanceId接口");
	}
}
