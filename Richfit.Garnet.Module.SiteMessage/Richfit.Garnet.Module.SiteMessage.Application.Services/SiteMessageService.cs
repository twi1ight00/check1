using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.SiteMessage.Application.DTO;
using Richfit.Garnet.Module.SiteMessage.Domain.Models;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

namespace Richfit.Garnet.Module.SiteMessage.Application.Services;

public class SiteMessageService : ServiceBase, ISiteMessageService
{
	private readonly IRepository<MSG_MESSAGE_USER> mesMessageActionRepository;

	private readonly IRepository<MSG_MESSAGE> mesMessageRepository;

	public SiteMessageService()
	{
		mesMessageRepository = ServiceLocator.Instance.GetService<IRepository<MSG_MESSAGE>>();
		mesMessageActionRepository = ServiceLocator.Instance.GetService<IRepository<MSG_MESSAGE_USER>>();
	}

	public QueryResult<MSG_MESSAGEDTO> GetSendMessage(MSG_MESSAGEDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<MSG_MESSAGEDTO>("GetSendMessage", dto);
	}

	public QueryResult<MSG_MESSAGE_USERDTO> GetMessageStatusByMsgId(MSG_MESSAGE_USERDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<MSG_MESSAGE_USERDTO>("GetMessageStatusByMsgId", dto);
	}

	public Guid SendMessage(MSG_MESSAGEDTO dto)
	{
		dto.ID = Guid.NewGuid();
		dto.SEND_USER_ID = SessionContext.UserInfo.UserID;
		dto.SEND_USER_NAME = SessionContext.UserInfo.UserName;
		dto.SEND_ORG_ID = SessionContext.UserInfo.BelongToOrgID;
		dto.SEND_ORG_NAME = OrgUserCacheManager.GetOrgByKey(SessionContext.UserInfo.BelongToOrgID).ORG_NAME;
		dto.SORT = 0m;
		List<MSG_CENTER_USERDTO> user = new List<MSG_CENTER_USERDTO>();
		List<string> userIds = new List<string>();
		foreach (MSG_MESSAGE_USERDTO item in dto.MSG_MESSAGE_USER)
		{
			item.MESSAGE_ID = dto.ID;
			item.ORG_NAME = OrgUserCacheManager.GetOrgByKey(item.ORG_ID.Value).ORG_NAME;
			if (item.USER_TYPE == 1m)
			{
				user.Add(new MSG_CENTER_USERDTO
				{
					ISREAD = 0m,
					USER_ID = item.USER_ID,
					USER_NAME = item.USER_NAME,
					ISIM = 0m,
					SORT = 0m
				});
				userIds.Add(item.USER_ID.ToString().ToLower().Replace("-", "") + ConfigurationManager.System.Settings.GetSetting<string>("environment"));
			}
		}
		MSG_MESSAGE poco = dto.AdaptAsEntity<MSG_MESSAGE>();
		mesMessageRepository.AddCommit(poco);
		return dto.ID;
	}

	public QueryResult<MSG_MESSAGEDTO> GetReceiveMessage(MSG_MESSAGEDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<MSG_MESSAGEDTO>("GetReceiveMessage", dto);
	}

	public QueryResult<MSG_MESSAGEDTO> GetReceiveMessageAdvance(MSG_MESSAGEDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<MSG_MESSAGEDTO>("GetReceiveMessage_Advance", dto);
	}

	public QueryResult<MSG_MESSAGEDTO> SendMessageAdvance(MSG_MESSAGEDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<MSG_MESSAGEDTO>("GetSendMessage_Advance", dto);
	}

	public IList<TREE_NODE> GetAuthorizationUser(MSG_MESSAGEDTO parameter)
	{
		IList<MSG_MESSAGE_USER> result = mesMessageActionRepository.FindAll((MSG_MESSAGE_USER a) => a.MESSAGE_ID == parameter.ID && a.USER_TYPE == 1m && a.IS_DEL == 0m);
		IList<Guid> user = new List<Guid>();
		result.ForEach(delegate(MSG_MESSAGE_USER a)
		{
			user.Add(a.USER_ID);
		});
		return ServiceLocator.Instance.GetService<IOrgUserService>().GetOrgUserTree(null, -1, isFindUser: true, isAllowUserManyToOrg: false, isIncludeSelf: true, user);
	}

	public MSG_MESSAGEDTO GetMessageById(MSG_MESSAGEDTO parameter)
	{
		MSG_MESSAGE msg = mesMessageRepository.GetByKey(parameter.ID);
		foreach (MSG_MESSAGE_USER item in msg.MSG_MESSAGE_USER)
		{
			if (item.USER_ID == SessionContext.UserInfo.UserID)
			{
				item.STATUS = 1m;
			}
		}
		mesMessageRepository.UpdateCommit(msg);
		return msg.AdaptAsDTO<MSG_MESSAGEDTO>();
	}

	public bool DeleteMessage(MSG_MESSAGEDTO dto)
	{
		try
		{
			foreach (Guid item in dto.MSG_MESSAGE_USER_IDs)
			{
				MSG_MESSAGE_USER msg = mesMessageActionRepository.GetByKey(item);
				msg.IS_DEL = 1m;
				mesMessageActionRepository.UpdateCommit(msg);
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool ChangeMessageStatus(MSG_MESSAGEDTO dto)
	{
		try
		{
			MSG_MESSAGE_USER msg = mesMessageActionRepository.GetByKey(dto.MSG_MESSAGE_USER_ID);
			msg.STATUS = 1m;
			mesMessageActionRepository.UpdateCommit(msg);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
