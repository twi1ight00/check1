using System;
using System.Collections.Generic;
using System.Linq;
using cn.jpush.api;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.ScheduleManagement.Application.DTO;
using Richfit.Garnet.Module.ScheduleManagement.Domain.Models;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

namespace Richfit.Garnet.Module.ScheduleManagement.Application.Services;

public class ScheduleService : ServiceBase, IScheduleService
{
	private delegate void PushSCHNotificationToMobileDelegate(SCH_INFODTO schDTO);

	private readonly IRepository<SYS_USER> sysUserRepository;

	private readonly IRepository<SCH_PARTICIPANTS_USER> schParticipantsUserRepository;

	private readonly IRepository<SCH_INFO> schInfoRepository;

	private readonly IRepository<SCH_BELONGER_USER> schBelongerUserRepository;

	private readonly IRepository<SYS_USER> userRepository;

	private static readonly ILogger logExp = LoggerManager.GetLogger("Exception");

	public ScheduleService(IRepository<SCH_BELONGER_USER> schBelongerUserRepository, IRepository<SCH_INFO> schInfoRepository, IRepository<SCH_PARTICIPANTS_USER> schParticipantsUserRepository, IRepository<SYS_USER> sysUserRepository)
	{
		this.schBelongerUserRepository = schBelongerUserRepository;
		this.schInfoRepository = schInfoRepository;
		this.schParticipantsUserRepository = schParticipantsUserRepository;
		this.sysUserRepository = sysUserRepository;
		userRepository = ServiceLocator.Instance.GetService<IRepository<SYS_USER>>();
	}

	public SCH_INFODTO AddSchedule(SCH_INFODTO infoDTO)
	{
		if (infoDTO == null)
		{
			throw new ArgumentException("AddSchedule方法参数不能为空.");
		}
		if (infoDTO.IsValid())
		{
			SCH_INFO infoPOCO = infoDTO.AdaptAsEntity<SCH_INFO>();
			if (!string.IsNullOrEmpty(infoDTO.REMARK))
			{
				string[] userIdArray = infoDTO.REMARK.Split('、');
				if (userIdArray != null && userIdArray.Any())
				{
					userIdArray.ToList().ForEach(delegate(string uId)
					{
						SCH_PARTICIPANTS_USER item = new SCH_PARTICIPANTS_USER
						{
							USER_ID = Guid.Parse(uId),
							SCHEDULE_ID = infoDTO.SCHEDULE_ID
						};
						infoPOCO.SCH_PARTICIPANTS_USER.Add(item);
					});
				}
			}
			infoPOCO.SCHEDULE_ID = Guid.NewGuid();
			infoPOCO.CREATOR = SessionContext.UserInfo.UserID;
			infoPOCO.MODIFIER = SessionContext.UserInfo.UserID;
			schInfoRepository.AddCommit(infoPOCO);
			infoDTO = infoPOCO.AdaptAsDTO<SCH_INFODTO>();
			PushSCHNotificationToMobileDelegate del = PushSCHNotificationToMobile;
			del.BeginInvoke(infoDTO, null, null);
			updateWeekLeader(infoDTO);
			infoDTO.SCH_BELONGER_USER = null;
			infoDTO.SCH_PARTICIPANTS_USER = null;
			return infoDTO;
		}
		throw new ValidationException(infoDTO.GetInvalidMessages());
	}

	private void updateWeekLeader(SCH_INFODTO infoDTO)
	{
		DateTime schedule_date = infoDTO.SCHEDULE_DATE.Value;
		DateTime startWeek = schedule_date.AddDays(1 - Convert.ToInt32(schedule_date.DayOfWeek.ToString("d")));
		DateTime endWeek = startWeek.AddDays(6.0);
		SCH_INFODTO queryDTO = new SCH_INFODTO();
		queryDTO.BEGIN_TIME = startWeek;
		queryDTO.END_TIME = endWeek;
		IList<SCH_INFODTO> list = SqlQueryList<SCH_INFODTO>("SELECT * FROM (select info.* from sch_info info where info.isdel=0 ) WHERE BEGIN_TIME>=@BEGIN_TIME AND END_TIME<=@END_TIME ", queryDTO);
		if (list.Count <= 0)
		{
			return;
		}
		foreach (SCH_INFODTO info in list)
		{
			if (info.DUTY_LEADER != null && !info.DUTY_LEADER.Equals(infoDTO.DUTY_LEADER))
			{
				SCH_INFO tempPOCO = info.AdaptAsEntity<SCH_INFO>();
				tempPOCO.DUTY_LEADER = infoDTO.DUTY_LEADER;
				schInfoRepository.UpdateCommit(tempPOCO);
			}
		}
	}

	public SCH_INFODTO UpdateSchedule(SCH_INFODTO infoDTO)
	{
		if (infoDTO != null && infoDTO.SCHEDULE_ID != Guid.Empty)
		{
			if (infoDTO.IsValid())
			{
				SCH_INFO infoPOCO = schInfoRepository.GetByKey(infoDTO.SCHEDULE_ID);
				schInfoRepository.RemoveChild(infoPOCO.SCH_PARTICIPANTS_USER);
				schInfoRepository.UpdateCommit(infoPOCO, "SCH_PARTICIPANTS_USER");
				schInfoRepository.RemoveChild(infoPOCO.SCH_BELONGER_USER);
				schInfoRepository.UpdateCommit(infoPOCO, "SCH_BELONGER_USER");
				SCH_INFO persisted = schInfoRepository.GetByKey(infoDTO.SCHEDULE_ID);
				if (persisted == null)
				{
					throw new ValidationException("SystemManagement.Public.V_0004");
				}
				persisted.SCHEDULE_TITLE = infoDTO.SCHEDULE_TITLE;
				persisted.SCHEDULE_CONTENTS = infoDTO.SCHEDULE_CONTENTS;
				persisted.BEGIN_TIME = infoDTO.BEGIN_TIME;
				persisted.END_TIME = infoDTO.END_TIME;
				persisted.SCHEDULE_TYPE = infoDTO.SCHEDULE_TYPE;
				persisted.DISCLOSURE_LEVEL = infoDTO.DISCLOSURE_LEVEL;
				persisted.ISALLDAY = infoDTO.ISALLDAY;
				persisted.ISREPEAT = infoDTO.ISREPEAT;
				persisted.REMIND_MODE = infoDTO.REMIND_MODE;
				persisted.REMIND_TIME = infoDTO.REMIND_TIME;
				decimal? iSREPEAT = infoDTO.ISREPEAT;
				if (iSREPEAT.GetValueOrDefault() == 1m && iSREPEAT.HasValue)
				{
					persisted.ISREPEAT = infoDTO.ISREPEAT;
					persisted.REPEAT_INTERVAL = infoDTO.REPEAT_INTERVAL;
					persisted.REMIND_TIME = infoDTO.REMIND_TIME;
					persisted.ISSEND = infoDTO.ISSEND;
				}
				persisted.SCHEDULE_COLOR = infoDTO.SCHEDULE_COLOR;
				persisted.NOTE = infoDTO.NOTE;
				persisted.DUTY_LEADER_ID = infoDTO.DUTY_LEADER_ID;
				persisted.DUTY_LEADER = infoDTO.DUTY_LEADER;
				persisted.SCHEDULE_DATE = infoDTO.SCHEDULE_DATE;
				persisted.SCHEDULE_LOCATION_ID = infoDTO.SCHEDULE_LOCATION_ID;
				persisted.SCHEDULE_LOCATION = infoDTO.SCHEDULE_LOCATION;
				persisted.MODIFIER = SessionContext.UserInfo.UserID;
				persisted.REMARK = infoDTO.REMARK;
				persisted.USER_ID = infoDTO.USER_ID;
				persisted.USER_NAME = infoDTO.USER_NAME;
				persisted.ORG_ID = infoDTO.ORG_ID;
				persisted.ORG_NAME = infoDTO.ORG_NAME;
				persisted.PARTICIPANTS_NAME = infoDTO.PARTICIPANTS_NAME;
				persisted.PARTICIPANTS_NAME_STRING = infoDTO.PARTICIPANTS_NAME_STRING;
				if (!string.IsNullOrEmpty(infoDTO.REMARK))
				{
					string[] userIdArray = infoDTO.REMARK.Split('、');
					if (userIdArray != null && userIdArray.Any())
					{
						userIdArray.ToList().ForEach(delegate(string uId)
						{
							SCH_PARTICIPANTS_USER item2 = new SCH_PARTICIPANTS_USER
							{
								USER_ID = Guid.Parse(uId),
								SCHEDULE_ID = infoDTO.SCHEDULE_ID
							};
							persisted.SCH_PARTICIPANTS_USER.Add(item2);
						});
					}
				}
				if (!string.IsNullOrEmpty(infoDTO.OWNER))
				{
					string[] userIdArray = infoDTO.OWNER.Split(',');
					if (userIdArray != null && userIdArray.Any())
					{
						userIdArray.ToList().ForEach(delegate(string uId)
						{
							SCH_BELONGER_USER item = new SCH_BELONGER_USER
							{
								USER_ID = Guid.Parse(uId)
							};
							persisted.SCH_BELONGER_USER.Add(item);
						});
					}
				}
				schInfoRepository.UpdateCommit(persisted, "SCH_BELONGER_USER", "SCH_PARTICIPANTS_USER");
				infoDTO = persisted.AdaptAsDTO<SCH_INFODTO>();
				updateWeekLeader(infoDTO);
				infoDTO.SCH_BELONGER_USER = null;
				infoDTO.SCH_PARTICIPANTS_USER = null;
			}
			return infoDTO;
		}
		throw new ValidationException(infoDTO.GetInvalidMessages());
	}

	public void RemoveSchedule(string infoIds)
	{
		string[] infoIdArray = infoIds.Split(',');
		if (infoIdArray == null || !infoIdArray.Any())
		{
			return;
		}
		infoIdArray.ToList().ForEach(delegate(string infoId)
		{
			SCH_INFO byKey = schInfoRepository.GetByKey(Guid.Parse(infoId));
			if (byKey != null)
			{
				byKey.ISDEL = 1m;
				schInfoRepository.Update(byKey);
				schInfoRepository.RemoveChild(byKey.SCH_PARTICIPANTS_USER);
				schInfoRepository.RemoveChild(byKey.SCH_BELONGER_USER);
			}
		});
		schInfoRepository.DbContext.Commit();
	}

	public SCH_INFODTO GetScheduleByKey(Guid infoId)
	{
		SCH_INFO infoPOCO = schInfoRepository.GetByKey(infoId);
		SCH_INFODTO infoDTO = infoPOCO.AdaptAsDTO<SCH_INFODTO>();
		if (infoPOCO.SCH_PARTICIPANTS_USER.Count > 0)
		{
			IList<string> userIDs2 = new List<string>();
			IList<string> userNames2 = new List<string>();
			infoPOCO.SCH_PARTICIPANTS_USER.ToList().ForEach(delegate(SCH_PARTICIPANTS_USER user)
			{
				userIDs2.Add(user.USER_ID.ToString());
				userNames2.Add(user.SYS_USER.DISPLAY_NAME);
			});
			infoDTO.TAKER = string.Join(",", userIDs2.ToArray());
			infoDTO.TAKER_NAME = string.Join(",", userNames2.ToArray());
		}
		if (infoPOCO.SCH_BELONGER_USER.Count > 0)
		{
			IList<string> userIDs = new List<string>();
			IList<string> userNames = new List<string>();
			infoPOCO.SCH_BELONGER_USER.ToList().ForEach(delegate(SCH_BELONGER_USER user)
			{
				userIDs.Add(user.USER_ID.ToString());
				userNames.Add(user.SYS_USER.DISPLAY_NAME);
			});
			infoDTO.OWNER = string.Join(",", userIDs.ToArray());
			infoDTO.OWNER_NAME = string.Join(",", userNames.ToArray());
		}
		if (infoPOCO.REMIND_TIME.HasValue)
		{
			DateTime dt1 = infoPOCO.BEGIN_TIME.Value;
			DateTime dt2 = infoPOCO.REMIND_TIME.Value;
			TimeSpan ts = dt1 - dt2;
			infoDTO.BEFORE_DAYS = ts.Days;
			infoDTO.BEFORE_HOURS = ts.Hours;
			infoDTO.BEFORE_MINUTES = ts.Minutes;
		}
		infoDTO.SCH_PARTICIPANTS_USER = null;
		infoDTO.SCH_BELONGER_USER = null;
		infoDTO.SCH_BELONGER_USER = null;
		infoDTO.SCH_PARTICIPANTS_USER = null;
		return infoDTO;
	}

	public QueryResult<SCH_INFODTO> QueryScheduleList(SCH_INFODTO infoDTO)
	{
		return SqlQueryPager<SCH_INFODTO>("QueryScheduleList", infoDTO);
	}

	public QueryResult<SCH_INFODTO> GetScheduleCalendar(SCH_INFODTO queryCondition)
	{
		return SqlQueryPager<SCH_INFODTO>("GetScheduleCalendar", queryCondition);
	}

	public QueryResult<SCH_INFODTO> GetPersonScheduleCalendar(SCH_INFODTO queryCondition)
	{
		return SqlQueryPager<SCH_INFODTO>("GetPersonScheduleCalendar", queryCondition);
	}

	public IList<TREE_NODE> GetParticipantsUserTree(Guid infoId)
	{
		IList<SCH_PARTICIPANTS_USER> result = schParticipantsUserRepository.FindAll((SCH_PARTICIPANTS_USER a) => a.SCHEDULE_ID == infoId);
		IList<Guid> user = new List<Guid>();
		result.ToList().ForEach(delegate(SCH_PARTICIPANTS_USER a)
		{
			user.Add(a.USER_ID.Value);
		});
		return ServiceLocator.Instance.GetService<IOrgUserService>().GetOrgUserTree(null, -1, isFindUser: true, isAllowUserManyToOrg: false, isIncludeSelf: true, user);
	}

	public IList<TREE_NODE> GetBelongerUserTree(Guid infoId)
	{
		IList<SCH_BELONGER_USER> result = schBelongerUserRepository.FindAll((SCH_BELONGER_USER a) => a.SCHEDULE_ID == infoId);
		IList<Guid> user = new List<Guid>();
		result.ToList().ForEach(delegate(SCH_BELONGER_USER a)
		{
			user.Add(a.USER_ID.Value);
		});
		return ServiceLocator.Instance.GetService<IOrgUserService>().GetOrgUserTree(null, -1, isFindUser: true, isAllowUserManyToOrg: false, isIncludeSelf: true, user);
	}

	public SCH_INFODTO QuickSaveSchedule(SCH_INFODTO infoDTO)
	{
		if (infoDTO != null && infoDTO.SCHEDULE_ID != Guid.Empty && infoDTO.IsValid())
		{
			SCH_INFO persisted = schInfoRepository.GetByKey(infoDTO.SCHEDULE_ID);
			if (persisted == null)
			{
				throw new ValidationException("SystemManagement.Public.V_0004");
			}
			persisted.BEGIN_TIME = infoDTO.BEGIN_TIME;
			persisted.END_TIME = infoDTO.END_TIME;
			schInfoRepository.UpdateCommit(persisted);
			infoDTO = GetScheduleByKey(infoDTO.SCHEDULE_ID);
		}
		return infoDTO;
	}

	public SCH_INFODTO ChangeStateSchedule(SCH_INFODTO infoDTO)
	{
		if (infoDTO != null && infoDTO.SCHEDULE_ID != Guid.Empty && infoDTO.IsValid())
		{
			SCH_INFO persisted = schInfoRepository.GetByKey(infoDTO.SCHEDULE_ID);
			if (persisted == null)
			{
				throw new ValidationException("SystemManagement.Public.V_0004");
			}
			persisted.SCHEDULE_STATE = infoDTO.SCHEDULE_STATE;
			schInfoRepository.UpdateCommit(persisted);
			infoDTO = persisted.AdaptAsDTO<SCH_INFODTO>();
		}
		return infoDTO;
	}

	public string GetWeekDutyLeader(SCH_INFODTO infoDTO)
	{
		IList<SCH_INFO> result = schInfoRepository.FindAll((SCH_INFO a) => a.ISDEL == 0m && a.BEGIN_TIME >= infoDTO.BEGIN_TIME && a.END_TIME <= infoDTO.END_TIME);
		string dutyLeader = "";
		if (result.Count > 0)
		{
			result.ToList().ForEach(delegate(SCH_INFO info)
			{
				if (info.DUTY_LEADER != null && info.DUTY_LEADER != "")
				{
					dutyLeader = info.DUTY_LEADER;
				}
			});
		}
		return dutyLeader;
	}

	private void PushSCHNotificationToMobile(SCH_INFODTO schDTO)
	{
		if (!ConfigurationManager.System.Settings.GetSetting("EnableJPush", defaultValue: false) || schDTO == null)
		{
			return;
		}
		string AppKey = ConfigurationManager.System.Settings.GetSetting<string>("AppKey");
		string MasterSecret = ConfigurationManager.System.Settings.GetSetting<string>("MasterSecret");
		JPushClient client = new JPushClient(AppKey, MasterSecret);
		foreach (SCH_PARTICIPANTS_USERDTO paticipant in schDTO.SCH_PARTICIPANTS_USER)
		{
			string MessageContent = ConfigurationManager.System.Settings.GetSetting<string>("SCHMessageContent");
			SendPersonMeetingMessage(schDTO, paticipant, client, MessageContent);
		}
	}

	private void SendPersonMeetingMessage(SCH_INFODTO schDTO, SCH_PARTICIPANTS_USERDTO paticipant, JPushClient client, string MessageContent)
	{
		SYS_USER user = userRepository.GetByKey(paticipant.USER_ID.Value);
		PushPayload pushLoad = new PushPayload();
		pushLoad.platform = Platform.all();
		pushLoad.ResetOptionsApnsProduction(apnsProduction: true);
		pushLoad.audience = Audience.s_alias(paticipant.USER_ID.ToString().Replace("-", "").ToLower());
		AndroidNotification androidNotification = new AndroidNotification().AddExtra("Type", "Schedule").AddExtra("PARTICIPANTS_USER_ID", paticipant.PARTICIPANTS_USER_ID).AddExtra("SCHEDULE_ID", paticipant.SCHEDULE_ID)
			.AddExtra("SCHEDULE_TITLE", schDTO.SCHEDULE_TITLE)
			.AddExtra("SCHEDULE_CONTENTS", schDTO.SCHEDULE_CONTENTS)
			.AddExtra("USER_ID", paticipant.USER_ID)
			.AddExtra("USER_NAME", user.LOGON_NAME);
		IosNotification iosNotification = new IosNotification().AddExtra("Type", "Schedule").AddExtra("PARTICIPANTS_USER_ID", paticipant.PARTICIPANTS_USER_ID).AddExtra("SCHEDULE_ID", paticipant.SCHEDULE_ID)
			.AddExtra("SCHEDULE_TITLE", schDTO.SCHEDULE_TITLE)
			.AddExtra("SCHEDULE_CONTENTS", schDTO.SCHEDULE_CONTENTS)
			.AddExtra("USER_ID", paticipant.USER_ID)
			.AddExtra("USER_NAME", user.LOGON_NAME);
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
