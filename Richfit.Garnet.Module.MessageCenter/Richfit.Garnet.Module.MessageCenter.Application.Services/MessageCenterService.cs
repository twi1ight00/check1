using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Domain.Models;

namespace Richfit.Garnet.Module.MessageCenter.Application.Services;

public class MessageCenterService : ServiceBase, IMessageCenterService
{
	private readonly IRepository<MSG_CENTER_USER> msgCenterUserRepository;

	private readonly IRepository<MSG_CENTER> msgCenterRepository;

	public MessageCenterService()
	{
		msgCenterRepository = ServiceLocator.Instance.GetService<IRepository<MSG_CENTER>>();
		msgCenterUserRepository = ServiceLocator.Instance.GetService<IRepository<MSG_CENTER_USER>>();
	}

	public bool AddMessage(MSG_CENTERDTO dto)
	{
		try
		{
			msgCenterRepository.AddCommit(dto.AdaptAsEntity<MSG_CENTER>());
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public QueryResult<MSG_CENTERDTO> GetMessageByCurrentUser(MSG_CENTERDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<MSG_CENTERDTO>("GetMessageCenterByCurrentUser", dto);
	}

	public QueryResult<MSG_CENTERDTO> GetMessageByCurrentUserAdvance(MSG_CENTERDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<MSG_CENTERDTO>("GetMessageByCurrentUserAdvance", dto);
	}

	public bool ReadMessage(List<Guid> msgIds)
	{
		try
		{
			foreach (Guid msgId in msgIds)
			{
				MSG_CENTER msg = msgCenterRepository.GetByKey(msgId);
				foreach (MSG_CENTER_USER item in msg.MSG_CENTER_USER)
				{
					if (item.USER_ID == SessionContext.UserInfo.UserID)
					{
						item.ISREAD = 1m;
					}
				}
				msgCenterRepository.UpdateCommit(msg);
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool ReadIM(Guid msgId)
	{
		try
		{
			MSG_CENTER msg = msgCenterRepository.GetByKey(msgId);
			foreach (MSG_CENTER_USER item in msg.MSG_CENTER_USER)
			{
				if (item.USER_ID == SessionContext.UserInfo.UserID)
				{
					item.ISIM = 1m;
				}
			}
			msgCenterRepository.UpdateCommit(msg);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public void DeleteMessage(MSG_CENTERDTO dto)
	{
		foreach (Guid msgId in dto.IDs)
		{
			try
			{
				MSG_CENTER msg = msgCenterRepository.GetByKey(msgId);
				foreach (MSG_CENTER_USER item in msg.MSG_CENTER_USER)
				{
					if (item.USER_ID == SessionContext.UserInfo.UserID)
					{
						item.ISDEL = 1m;
					}
				}
				msgCenterRepository.UpdateCommit(msg);
			}
			catch (Exception)
			{
			}
		}
	}
}
