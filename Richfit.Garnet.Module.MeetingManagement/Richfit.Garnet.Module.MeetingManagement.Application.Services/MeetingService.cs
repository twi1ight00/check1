using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using cn.jpush.api;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.MeetingManagement.Application.DTO;
using Richfit.Garnet.Module.MeetingManagement.Domain.Models;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Application.Services;
using Richfit.Garnet.Module.ScheduleManagement.Domain.Models;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.RoleManagement;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;
using Richfit.Garnet.Module.Workflow.Application.Components;
using Richfit.Garnet.Module.Workflow.Form.Application.DTO;

namespace Richfit.Garnet.Module.MeetingManagement.Application.Services;

public class MeetingService : ServiceBase, IMeetingService
{
	private delegate void PushMeetingNotificationToMobileDelegate(MM_MEETING_APPLY meetingPOCO, MM_MEETING_APPLY oldMeetingRepeat, IList<MM_MEETING_PARTICIPANTS> oldRemoveMList);

	private static readonly ILogger logExp = LoggerManager.GetLogger("Exception");

	private ISystemUserService userService = ServiceLocator.Instance.GetService<ISystemUserService>();

	private readonly IRepository<MM_MEETING_APPLY> meetingRepository;

	private readonly IRepository<MM_MEETING_PARTICIPANTS> meetingParticipantsRepository;

	private readonly IRepository<SCH_INFO> schInfoRepository;

	private readonly IRepository<SCH_PARTICIPANTS_USER> schParticipantsUserRepository;

	private readonly IRepository<SYS_USER> userRepository;

	public MeetingService(IRepository<MM_MEETING_APPLY> repositoryMeeting, IRepository<MM_MEETING_PARTICIPANTS> repositoryMeetingParticipants, IRepository<SYS_USER> repositoryUser)
	{
		meetingRepository = repositoryMeeting;
		meetingParticipantsRepository = repositoryMeetingParticipants;
		schInfoRepository = ServiceLocator.Instance.GetService<IRepository<SCH_INFO>>();
		schParticipantsUserRepository = ServiceLocator.Instance.GetService<IRepository<SCH_PARTICIPANTS_USER>>();
		userRepository = ServiceLocator.Instance.GetService<IRepository<SYS_USER>>();
	}

	public QueryResult<MM_MEETING_APPLYDTO> QueryMeetingRecordList(MM_MEETING_APPLYDTO queryCondition)
	{
		return SqlQueryPager<MM_MEETING_APPLYDTO>("GetMeetingAllList", queryCondition);
	}

	public MM_MEETING_APPLYDTO AddMeetingRecord(MM_MEETING_APPLYDTO meetingDTO)
	{
		if (meetingDTO == null)
		{
			throw new ArgumentException("AddMeetingRecord方法参数不能为空.");
		}
		if (meetingDTO.IsValid())
		{
			bool flag = false;
			MM_MEETING_APPLY oldMeetingRepeat = new MM_MEETING_APPLY();
			IList<MM_MEETING_PARTICIPANTS> oldRemoveMList = new List<MM_MEETING_PARTICIPANTS>();
			DateTime dtStart = meetingDTO.BEGIN_TIME.Value;
			DateTime dtEnd = meetingDTO.END_TIME.Value;
			IList<MM_MEETING_APPLY> result = meetingRepository.FindAll((MM_MEETING_APPLY a) => a.MEETING_ROOM_ID == meetingDTO.MEETING_ROOM_ID && a.BEGIN_TIME < dtEnd && a.END_TIME > dtStart && a.ISDEL == (decimal?)0m);
			if (result.Count > 0)
			{
				IRoleAppService roleService = ServiceLocator.Instance.GetService<IRoleAppService>();
				IList<SYS_ROLEDTO> listRole = roleService.GetRoleByUser(SessionContext.UserInfo.UserID);
				listRole.ToList().ForEach(delegate(SYS_ROLEDTO role)
				{
					if (role.ROLE_ID.ToString().ToUpper() == "AB9EA7EB-643D-CEDA-8515-08D6F8803062")
					{
						flag = true;
					}
				});
				if (!flag)
				{
					throw new ArgumentException("会议时间与其他会议重复，请重新选择。");
				}
				result.ToList().ForEach(delegate(MM_MEETING_APPLY meetingRepeat)
				{
					oldMeetingRepeat = meetingRepeat;
					meetingRepeat.ISDEL = 1m;
					IList<MM_MEETING_PARTICIPANTS> list2 = (oldRemoveMList = meetingParticipantsRepository.FindAll((MM_MEETING_PARTICIPANTS x) => x.MEETING_APPLY_ID == meetingRepeat.MEETING_APPLY_ID));
					if (list2.Count > 0)
					{
						meetingParticipantsRepository.RemoveCommit(list2);
					}
					SCH_INFO byKey = schInfoRepository.GetByKey(meetingRepeat.MEETING_APPLY_ID);
					if (byKey != null)
					{
						byKey.ISDEL = 1m;
					}
					schInfoRepository.UpdateCommit(byKey);
					IList<SCH_PARTICIPANTS_USER> list3 = schParticipantsUserRepository.FindAll((SCH_PARTICIPANTS_USER x) => x.SCHEDULE_ID == meetingRepeat.MEETING_APPLY_ID);
					if (list3.Count > 0)
					{
						schParticipantsUserRepository.RemoveCommit(list3);
					}
				});
				meetingRepository.UpdateCommit(result);
			}
			MM_MEETING_APPLY meetingPOCO = meetingDTO.AdaptAsEntity<MM_MEETING_APPLY>();
			if (!string.IsNullOrEmpty(meetingPOCO.REMARK))
			{
				string[] userIdArray = meetingPOCO.REMARK.Split('、');
				if (userIdArray != null && userIdArray.Any())
				{
					userIdArray.ToList().ForEach(delegate(string uId)
					{
						MM_MEETING_PARTICIPANTS item2 = new MM_MEETING_PARTICIPANTS
						{
							USER_ID = Guid.Parse(uId),
							MEETING_APPLY_ID = meetingPOCO.MEETING_APPLY_ID
						};
						meetingPOCO.MM_MEETING_PARTICIPANTS.Add(item2);
					});
				}
			}
			meetingPOCO.MEETING_APPLY_ID = Guid.NewGuid();
			meetingPOCO.CREATOR = SessionContext.UserInfo.UserID;
			meetingPOCO.MODIFIER = SessionContext.UserInfo.UserID;
			meetingRepository.AddCommit(meetingPOCO);
			SCH_INFO infoPOCO = new SCH_INFO();
			infoPOCO.SCHEDULE_ID = meetingPOCO.MEETING_APPLY_ID;
			infoPOCO.SCHEDULE_TITLE = "会议：" + meetingPOCO.MEETING_TITLE;
			infoPOCO.SCHEDULE_CONTENTS = meetingPOCO.MEETING_CONTENTS;
			infoPOCO.BEGIN_TIME = meetingPOCO.BEGIN_TIME;
			infoPOCO.END_TIME = meetingPOCO.END_TIME;
			infoPOCO.SCHEDULE_TYPE = 2m;
			infoPOCO.DISCLOSURE_LEVEL = 2m;
			infoPOCO.SCHEDULE_STATE = 0m;
			infoPOCO.ISALLDAY = 0m;
			infoPOCO.ISREPEAT = meetingPOCO.IS_REPEAT;
			infoPOCO.REMIND_MODE = meetingPOCO.REMIND_MODE;
			infoPOCO.REMIND_TIME = meetingPOCO.REMIND_TIME;
			infoPOCO.CREATOR = SessionContext.UserInfo.UserID;
			infoPOCO.MODIFIER = SessionContext.UserInfo.UserID;
			infoPOCO.SCHEDULE_DATE = meetingPOCO.RESERVE_DATE;
			infoPOCO.SCHEDULE_LOCATION_ID = meetingPOCO.MEETING_ROOM_ID;
			infoPOCO.PARTICIPANTS_NAME = meetingPOCO.PARTICIPANTS_NAME;
			infoPOCO.PARTICIPANTS_NAME_STRING = meetingPOCO.PARTICIPANTS_NAME_STRING;
			infoPOCO.REMARK = meetingPOCO.REMARK;
			infoPOCO.USER_ID = meetingPOCO.USER_ID;
			infoPOCO.USER_NAME = meetingPOCO.USER_NAME;
			infoPOCO.ORG_ID = meetingPOCO.ORG_ID;
			infoPOCO.ORG_NAME = meetingPOCO.ORG_NAME;
			infoPOCO.ORG_DATAS = meetingPOCO.ORG_DATAS;
			infoPOCO.ORG_NAMES = meetingPOCO.ORG_NAMES;
			infoPOCO.ORG_IDS = meetingPOCO.ORG_IDS;
			decimal? iS_REPEAT = meetingPOCO.IS_REPEAT;
			if (iS_REPEAT.GetValueOrDefault() == 1m && iS_REPEAT.HasValue)
			{
				infoPOCO.ISREPEAT = meetingPOCO.IS_REPEAT;
				infoPOCO.REPEAT_INTERVAL = meetingPOCO.REPEAT_INTERVAL;
				infoPOCO.REMIND_TIME = meetingPOCO.REMIND_TIME;
				infoPOCO.ISSEND = meetingPOCO.IS_SEND;
			}
			infoPOCO.SCHEDULE_COLOR = 0m;
			infoPOCO.NOTE = meetingPOCO.REMARK;
			if (!string.IsNullOrEmpty(meetingPOCO.REMARK))
			{
				string[] userIdArray = meetingPOCO.REMARK.Split('、');
				if (userIdArray != null && userIdArray.Any())
				{
					userIdArray.ToList().ForEach(delegate(string uId)
					{
						SCH_PARTICIPANTS_USER item = new SCH_PARTICIPANTS_USER
						{
							USER_ID = Guid.Parse(uId),
							SCHEDULE_ID = infoPOCO.SCHEDULE_ID
						};
						infoPOCO.SCH_PARTICIPANTS_USER.Add(item);
					});
				}
			}
			schInfoRepository.AddCommit(infoPOCO);
			if (!meetingPOCO.ORG_IDS.Equals(""))
			{
				string[] list = meetingPOCO.ORG_IDS.Split(",");
				if (list.Length > 0)
				{
					string[] array = list;
					foreach (string orgID in array)
					{
						IList<SYS_USERDTO> userList = QueryUserList(orgID);
						foreach (SYS_USERDTO userItem in userList)
						{
							MM_MEETING_PARTICIPANTS paticipant = new MM_MEETING_PARTICIPANTS();
							paticipant.USER_ID = userItem.USER_ID;
							paticipant.MEETING_APPLY_ID = meetingPOCO.MEETING_APPLY_ID;
							paticipant.MEETING_PARTICIPANTS_ID = default(Guid);
							meetingPOCO.MM_MEETING_PARTICIPANTS.Add(paticipant);
						}
					}
				}
			}
			PushMeetingNotificationToMobileDelegate del = PushMeetingNotificationToMobile;
			del.BeginInvoke(meetingPOCO, oldMeetingRepeat, oldRemoveMList, null, null);
			meetingDTO = meetingPOCO.AdaptAsDTO<MM_MEETING_APPLYDTO>();
			return meetingDTO;
		}
		throw new ValidationException(meetingDTO.GetInvalidMessages());
	}

	public MM_MEETING_APPLYDTO UpdateMeetingRecord(MM_MEETING_APPLYDTO meetingDTO)
	{
		if (meetingDTO == null || meetingDTO.MEETING_APPLY_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateMeetingRecord方法参数不能为空.");
		}
		if (meetingDTO.IsValid())
		{
			bool flag = false;
			MM_MEETING_APPLY oldMeetingRepeat = new MM_MEETING_APPLY();
			IList<MM_MEETING_PARTICIPANTS> oldRemoveMList = new List<MM_MEETING_PARTICIPANTS>();
			DateTime dtStart = meetingDTO.BEGIN_TIME.Value;
			DateTime dtEnd = meetingDTO.END_TIME.Value;
			IList<MM_MEETING_APPLY> result = meetingRepository.FindAll((MM_MEETING_APPLY a) => a.MEETING_ROOM_ID == meetingDTO.MEETING_ROOM_ID && a.BEGIN_TIME < dtEnd && a.END_TIME > dtStart && a.ISDEL == (decimal?)0m && a.MEETING_APPLY_ID != meetingDTO.MEETING_APPLY_ID);
			if (result.Count > 0)
			{
				IRoleAppService roleService = ServiceLocator.Instance.GetService<IRoleAppService>();
				IList<SYS_ROLEDTO> listRole = roleService.GetRoleByUser(SessionContext.UserInfo.UserID);
				listRole.ToList().ForEach(delegate(SYS_ROLEDTO role)
				{
					if (role.ROLE_ID.ToString().ToUpper() == "AB9EA7EB-643D-CEDA-8515-08D6F8803062")
					{
						flag = true;
					}
				});
				if (!flag)
				{
					throw new ArgumentException("会议时间与其他会议重复，请重新选择。");
				}
				result.ToList().ForEach(delegate(MM_MEETING_APPLY meetingRepeat)
				{
					oldMeetingRepeat = meetingRepeat;
					meetingRepeat.ISDEL = 1m;
					IList<MM_MEETING_PARTICIPANTS> list2 = (oldRemoveMList = meetingParticipantsRepository.FindAll((MM_MEETING_PARTICIPANTS x) => x.MEETING_APPLY_ID == meetingRepeat.MEETING_APPLY_ID));
					if (list2.Count > 0)
					{
						meetingParticipantsRepository.RemoveCommit(list2);
					}
					SCH_INFO byKey = schInfoRepository.GetByKey(meetingRepeat.MEETING_APPLY_ID);
					if (byKey != null)
					{
						byKey.ISDEL = 1m;
					}
					schInfoRepository.UpdateCommit(byKey);
					IList<SCH_PARTICIPANTS_USER> list3 = schParticipantsUserRepository.FindAll((SCH_PARTICIPANTS_USER x) => x.SCHEDULE_ID == meetingRepeat.MEETING_APPLY_ID);
					if (list3.Count > 0)
					{
						schParticipantsUserRepository.RemoveCommit(list3);
					}
				});
				meetingRepository.UpdateCommit(result);
			}
			MM_MEETING_APPLY persisted = meetingRepository.GetByKey(meetingDTO.MEETING_APPLY_ID);
			if (persisted != null)
			{
				MM_MEETING_APPLY meetingPOCO = meetingDTO.AdaptAsEntity<MM_MEETING_APPLY>();
				if (persisted.IsUpdateConflict(meetingPOCO))
				{
					throw new ArgumentException("数据已过期，请刷新重试");
				}
				MM_MEETING_APPLY newMeetingPOCO = persisted;
				newMeetingPOCO.MODIFIER = SessionContext.UserInfo.UserID;
				newMeetingPOCO.REMARK = meetingDTO.REMARK;
				newMeetingPOCO.USER_ID = meetingDTO.USER_ID;
				newMeetingPOCO.USER_NAME = meetingDTO.USER_NAME;
				newMeetingPOCO.ORG_ID = meetingDTO.ORG_ID;
				newMeetingPOCO.ORG_NAME = meetingDTO.ORG_NAME;
				newMeetingPOCO.MEETING_ROOM_LOCATION = meetingDTO.MEETING_ROOM_LOCATION;
				newMeetingPOCO.MEETING_ROOM_TYPE = meetingDTO.MEETING_ROOM_TYPE;
				newMeetingPOCO.MEETING_ROOM_ID = meetingDTO.MEETING_ROOM_ID;
				newMeetingPOCO.MEETING_ROOM_NAME = meetingDTO.MEETING_ROOM_NAME;
				newMeetingPOCO.RESERVE_DATE = meetingDTO.RESERVE_DATE.Value;
				newMeetingPOCO.MEETING_CONTENTS = meetingDTO.MEETING_CONTENTS;
				newMeetingPOCO.MEETING_TITLE = meetingDTO.MEETING_TITLE;
				newMeetingPOCO.BEGIN_TIME = meetingDTO.BEGIN_TIME.Value;
				newMeetingPOCO.END_TIME = meetingDTO.END_TIME.Value;
				newMeetingPOCO.MEETING_STATE = meetingDTO.MEETING_STATE;
				newMeetingPOCO.REMIND_MODE = meetingDTO.REMIND_MODE;
				if (meetingDTO.REMIND_TIME.HasValue)
				{
					newMeetingPOCO.REMIND_TIME = meetingDTO.REMIND_TIME.Value;
				}
				newMeetingPOCO.IS_REPEAT = meetingDTO.IS_REPEAT;
				newMeetingPOCO.REPEAT_INTERVAL = meetingDTO.REPEAT_INTERVAL;
				newMeetingPOCO.MEETING_COLOR = meetingDTO.MEETING_COLOR;
				newMeetingPOCO.IS_SEND = meetingDTO.IS_SEND;
				newMeetingPOCO.PARTICIPANTS_NAME = meetingDTO.PARTICIPANTS_NAME;
				newMeetingPOCO.PARTICIPANTS_NAME_STRING = meetingDTO.PARTICIPANTS_NAME_STRING;
				newMeetingPOCO.ORG_DATAS = meetingDTO.ORG_DATAS;
				newMeetingPOCO.ORG_NAMES = meetingDTO.ORG_NAMES;
				newMeetingPOCO.ORG_IDS = meetingDTO.ORG_IDS;
				meetingRepository.UpdateCommit(newMeetingPOCO);
				IList<MM_MEETING_PARTICIPANTS> removeParticipantsList = meetingParticipantsRepository.FindAll((MM_MEETING_PARTICIPANTS x) => x.MEETING_APPLY_ID == meetingDTO.MEETING_APPLY_ID);
				if (removeParticipantsList.Count > 0)
				{
					meetingParticipantsRepository.RemoveCommit(removeParticipantsList);
				}
				if (!string.IsNullOrEmpty(meetingPOCO.REMARK))
				{
					string[] userIdArray = meetingPOCO.REMARK.Split('、');
					if (userIdArray != null && userIdArray.Any())
					{
						userIdArray.ToList().ForEach(delegate(string uId)
						{
							MM_MEETING_PARTICIPANTS item2 = new MM_MEETING_PARTICIPANTS
							{
								USER_ID = Guid.Parse(uId),
								MEETING_APPLY_ID = meetingPOCO.MEETING_APPLY_ID
							};
							meetingPOCO.MM_MEETING_PARTICIPANTS.Add(item2);
						});
					}
				}
				meetingParticipantsRepository.AddCommit(meetingPOCO.MM_MEETING_PARTICIPANTS);
				SCH_INFO schedule = schInfoRepository.GetByKey(meetingDTO.MEETING_APPLY_ID);
				if (schedule != null)
				{
					schedule.SCHEDULE_TITLE = "会议：" + meetingPOCO.MEETING_TITLE;
					schedule.SCHEDULE_CONTENTS = meetingPOCO.MEETING_CONTENTS;
					schedule.BEGIN_TIME = meetingPOCO.BEGIN_TIME;
					schedule.END_TIME = meetingPOCO.END_TIME;
					schedule.ISREPEAT = meetingPOCO.IS_REPEAT;
					schedule.REMIND_MODE = meetingPOCO.REMIND_MODE;
					schedule.REMIND_TIME = meetingPOCO.REMIND_TIME;
					schedule.MODIFIER = SessionContext.UserInfo.UserID;
					schedule.SCHEDULE_DATE = meetingPOCO.RESERVE_DATE;
					schedule.SCHEDULE_LOCATION_ID = meetingPOCO.MEETING_ROOM_ID;
					schedule.PARTICIPANTS_NAME_STRING = meetingPOCO.PARTICIPANTS_NAME_STRING;
					schedule.ORG_DATAS = meetingPOCO.ORG_DATAS;
					schedule.ORG_NAMES = meetingPOCO.ORG_NAMES;
					schedule.ORG_IDS = meetingPOCO.ORG_IDS;
					decimal? iS_REPEAT = meetingPOCO.IS_REPEAT;
					if (iS_REPEAT.GetValueOrDefault() == 1m && iS_REPEAT.HasValue)
					{
						schedule.ISREPEAT = meetingPOCO.IS_REPEAT;
						schedule.REPEAT_INTERVAL = meetingPOCO.REPEAT_INTERVAL;
						schedule.REMIND_TIME = meetingPOCO.REMIND_TIME;
						schedule.ISSEND = meetingPOCO.IS_SEND;
					}
					schedule.NOTE = meetingPOCO.REMARK;
				}
				schInfoRepository.UpdateCommit(schedule);
				IList<SCH_PARTICIPANTS_USER> removeScheduleUserList = schParticipantsUserRepository.FindAll((SCH_PARTICIPANTS_USER x) => x.SCHEDULE_ID == meetingDTO.MEETING_APPLY_ID);
				if (removeScheduleUserList.Count > 0)
				{
					schParticipantsUserRepository.RemoveCommit(removeScheduleUserList);
				}
				if (!string.IsNullOrEmpty(meetingPOCO.REMARK))
				{
					string[] userIdArray = meetingPOCO.REMARK.Split('、');
					if (userIdArray != null && userIdArray.Any())
					{
						userIdArray.ToList().ForEach(delegate(string uId)
						{
							SCH_PARTICIPANTS_USER item = new SCH_PARTICIPANTS_USER
							{
								USER_ID = Guid.Parse(uId),
								SCHEDULE_ID = schedule.SCHEDULE_ID
							};
							schedule.SCH_PARTICIPANTS_USER.Add(item);
						});
					}
				}
				schParticipantsUserRepository.AddCommit(schedule.SCH_PARTICIPANTS_USER);
				if (!meetingPOCO.ORG_IDS.Equals(""))
				{
					string[] list = meetingPOCO.ORG_IDS.Split(",");
					if (list.Length > 0)
					{
						string[] array = list;
						foreach (string orgID in array)
						{
							IList<SYS_USERDTO> userList = QueryUserList(orgID);
							foreach (SYS_USERDTO userItem in userList)
							{
								MM_MEETING_PARTICIPANTS paticipant = new MM_MEETING_PARTICIPANTS();
								paticipant.USER_ID = userItem.USER_ID;
								paticipant.MEETING_APPLY_ID = meetingPOCO.MEETING_APPLY_ID;
								paticipant.MEETING_PARTICIPANTS_ID = default(Guid);
								meetingPOCO.MM_MEETING_PARTICIPANTS.Add(paticipant);
							}
						}
					}
				}
				PushMeetingNotificationToMobileDelegate del = PushMeetingNotificationToMobile;
				del.BeginInvoke(meetingPOCO, oldMeetingRepeat, oldRemoveMList, null, null);
				meetingDTO = newMeetingPOCO.AdaptAsDTO<MM_MEETING_APPLYDTO>();
				return meetingDTO;
			}
			throw new ArgumentException("UpdateMeeting不存在相关的实体对象.");
		}
		throw new ValidationException(meetingDTO.GetInvalidMessages());
	}

	public void DeleteMeetingRecordByKeyIDs(string keyIds)
	{
		string[] idArray = keyIds.Split(",", removeEmptyEntries: true);
		if (idArray == null || !idArray.Any())
		{
			return;
		}
		idArray.ForEach(delegate(string x)
		{
			Guid id = Guid.Parse(x);
			MM_MEETING_APPLY entity = meetingRepository.Find((MM_MEETING_APPLY a) => a.MEETING_APPLY_ID == id && a.ISDEL == (decimal?)0m);
			if (entity != null)
			{
				entity.ISDEL = 1m;
				meetingRepository.UpdateCommit(entity);
				IList<MM_MEETING_PARTICIPANTS> list = meetingParticipantsRepository.FindAll((MM_MEETING_PARTICIPANTS b) => b.MEETING_APPLY_ID == entity.MEETING_APPLY_ID);
				if (list.Count > 0)
				{
					meetingParticipantsRepository.RemoveCommit(list);
				}
			}
		});
	}

	protected void SendEmail(MM_MEETING_APPLY meetingPOCO, string mailTemplateName)
	{
		bool enableSendMail = ConfigurationManager.System.Settings.GetSetting("EnableSendMail", defaultValue: false);
		string strMailServer = ConfigurationManager.System.Settings.GetSetting("SendMail_ServerAddress").ToString();
		string strUserAccount = ConfigurationManager.System.Settings.GetSetting("SendMail_UserAccount").ToString();
		string strUserPassword = ConfigurationManager.System.Settings.GetSetting("SendMail_UserPassword").ToString();
		if (!enableSendMail)
		{
			return;
		}
		EmailService emailService = new EmailService();
		WF_MAILDTO mailDTO = new WF_MAILDTO();
		string path = HttpContext.Current.Server.MapPath("/Packages/MeetingManagement/Config/MailTemplate.xml");
		XmlDocument doc = new XmlDocument();
		XmlReaderSettings settings = new XmlReaderSettings();
		settings.IgnoreComments = true;
		XmlReader reader = XmlReader.Create(path, settings);
		doc.Load(reader);
		XmlNode xn = doc.SelectSingleNode("MailInfo");
		foreach (XmlNode node in xn.ChildNodes)
		{
			if (((XmlElement)node).GetAttribute("Name") == mailTemplateName)
			{
				XmlElement element = (XmlElement)node;
				mailDTO.TYPE = element.GetAttribute("Type");
				mailDTO.NAME = element.GetAttribute("Name");
				XmlNodeList xnl0 = element.ChildNodes;
				mailDTO.TITLE = xnl0.Item(0).InnerText;
				mailDTO.BODY = xnl0.Item(1).InnerText;
			}
		}
		if (string.IsNullOrEmpty(meetingPOCO.REMARK))
		{
			return;
		}
		string[] userIdArray = meetingPOCO.REMARK.Split('、');
		if (userIdArray == null || !userIdArray.Any())
		{
			return;
		}
		foreach (string uId in userIdArray.ToList())
		{
			SYS_USER user = userRepository.GetByKey(Guid.Parse(uId));
			string strToUserAccount = user.EXTEND3;
			if (!string.IsNullOrEmpty(strToUserAccount))
			{
				string strTitle = mailDTO.TITLE;
				string strBody = mailDTO.BODY;
				string title = meetingPOCO.MEETING_TITLE;
				string contents = meetingPOCO.MEETING_CONTENTS;
				string fromUser = meetingPOCO.USER_NAME;
				string date = string.Concat(meetingPOCO.BEGIN_TIME, "到", meetingPOCO.END_TIME);
				strTitle = string.Format(strTitle, user.DISPLAY_NAME);
				strBody = string.Format(strBody, user.DISPLAY_NAME, title, contents, fromUser, date);
				emailService.SendToEmail(meetingPOCO.MEETING_APPLY_ID, null, strMailServer, strToUserAccount, strUserAccount, strUserPassword, strTitle, strBody);
			}
		}
	}

	private void PushMeetingNotificationToMobile(MM_MEETING_APPLY meetingPOCO, MM_MEETING_APPLY oldMeetingRepeat, IList<MM_MEETING_PARTICIPANTS> oldRemoveMList)
	{
		if (!ConfigurationManager.System.Settings.GetSetting("EnableJPush", defaultValue: false) || meetingPOCO == null)
		{
			return;
		}
		string AppKey = ConfigurationManager.System.Settings.GetSetting<string>("AppKey");
		string MasterSecret = ConfigurationManager.System.Settings.GetSetting<string>("MasterSecret");
		JPushClient client = new JPushClient(AppKey, MasterSecret);
		if (oldMeetingRepeat != null && oldRemoveMList.Count > 0)
		{
			string MessageContent = "会议： " + oldMeetingRepeat.MEETING_TITLE + " 己取消，请查看！";
			foreach (MM_MEETING_PARTICIPANTS paticipant in oldRemoveMList)
			{
				SendPersonMeetingMessage(oldMeetingRepeat, paticipant, client, MessageContent);
			}
		}
		foreach (MM_MEETING_PARTICIPANTS paticipant in meetingPOCO.MM_MEETING_PARTICIPANTS)
		{
			string MessageContent = ConfigurationManager.System.Settings.GetSetting<string>("MeetingMessageContent");
			SendPersonMeetingMessage(meetingPOCO, paticipant, client, MessageContent);
		}
	}

	private IList<SYS_USERDTO> QueryUserList(string orgID)
	{
		QueryCondition queryCondition = new QueryCondition();
		QueryItem item1 = new QueryItem();
		item1.Type = "guid";
		item1.Value = orgID;
		item1.Key = "ORG_ID";
		item1.Method = "=";
		queryCondition.Add(item1);
		QueryItem item2 = new QueryItem();
		item2.Type = "string";
		item2.Value = "0";
		item2.Key = "IS_CREATE_BY_SELF_ORG";
		item2.Method = "=";
		queryCondition.Add(item2);
		queryCondition.PagingSetting = null;
		QueryResult<SYS_USERDTO> list = userService.QueryUserList(queryCondition);
		return list.List;
	}

	private void SendPersonMeetingMessage(MM_MEETING_APPLY meetingPOCO, MM_MEETING_PARTICIPANTS paticipant, JPushClient client, string MessageContent)
	{
		SYS_USERDTO user = userService.GetUserById(paticipant.USER_ID.Value);
		CNPCTaskListDTO cnpcTaskList = new SendMeassageToRuiXin().GetCNPCTaskList(user.LOGON_NAME);
		PushPayload pushLoad = new PushPayload();
		pushLoad.platform = Platform.all();
		pushLoad.ResetOptionsApnsProduction(apnsProduction: true);
		pushLoad.audience = Audience.s_alias(paticipant.USER_ID.ToString().Replace("-", "").ToLower());
		AndroidNotification androidNotification = new AndroidNotification().AddExtra("Type", "Meeting").AddExtra("MEETING_PARTICIPANTS_ID", paticipant.MEETING_PARTICIPANTS_ID).AddExtra("MEETING_APPLY_ID", paticipant.MEETING_APPLY_ID)
			.AddExtra("MEETING_ROOM_ID", meetingPOCO.MEETING_ROOM_ID)
			.AddExtra("RESERVE_DATE", meetingPOCO.RESERVE_DATE)
			.AddExtra("USER_ID", user.USER_ID)
			.AddExtra("USER_NAME", user.DISPLAY_NAME)
			.AddExtra("MEETING_TITLE", meetingPOCO.MEETING_TITLE)
			.AddExtra("MEETING_CONTENTS", meetingPOCO.MEETING_CONTENTS);
		IosNotification iosNotification = new IosNotification().AddExtra("Type", "Meeting").AddExtra("MEETING_PARTICIPANTS_ID", paticipant.MEETING_PARTICIPANTS_ID).AddExtra("MEETING_APPLY_ID", paticipant.MEETING_APPLY_ID)
			.AddExtra("MEETING_ROOM_ID", meetingPOCO.MEETING_ROOM_ID)
			.AddExtra("RESERVE_DATE", meetingPOCO.RESERVE_DATE)
			.AddExtra("USER_ID", user.USER_ID)
			.AddExtra("USER_NAME", user.DISPLAY_NAME)
			.AddExtra("MEETING_TITLE", meetingPOCO.MEETING_TITLE)
			.AddExtra("MEETING_CONTENTS", meetingPOCO.MEETING_CONTENTS);
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
