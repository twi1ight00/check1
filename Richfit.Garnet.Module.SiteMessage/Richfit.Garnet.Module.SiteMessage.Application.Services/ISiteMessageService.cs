using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.SiteMessage.Application.DTO;

namespace Richfit.Garnet.Module.SiteMessage.Application.Services;

public interface ISiteMessageService
{
	QueryResult<MSG_MESSAGEDTO> GetSendMessage(MSG_MESSAGEDTO parameter);

	QueryResult<MSG_MESSAGEDTO> GetReceiveMessageAdvance(MSG_MESSAGEDTO parameter);

	QueryResult<MSG_MESSAGEDTO> SendMessageAdvance(MSG_MESSAGEDTO parameter);

	Guid SendMessage(MSG_MESSAGEDTO parameter);

	QueryResult<MSG_MESSAGEDTO> GetReceiveMessage(MSG_MESSAGEDTO parameter);

	IList<TREE_NODE> GetAuthorizationUser(MSG_MESSAGEDTO parameter);

	MSG_MESSAGEDTO GetMessageById(MSG_MESSAGEDTO parameter);

	bool DeleteMessage(MSG_MESSAGEDTO parameter);

	bool ChangeMessageStatus(MSG_MESSAGEDTO parameter);

	QueryResult<MSG_MESSAGE_USERDTO> GetMessageStatusByMsgId(MSG_MESSAGE_USERDTO parameter);
}
