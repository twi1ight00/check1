using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;

namespace Richfit.Garnet.Module.MessageCenter.Application.Services;

public interface IMessageCenterService
{
	QueryResult<MSG_CENTERDTO> GetMessageByCurrentUser(MSG_CENTERDTO parameter);

	QueryResult<MSG_CENTERDTO> GetMessageByCurrentUserAdvance(MSG_CENTERDTO parameter);

	bool ReadMessage(List<Guid> msgId);

	bool AddMessage(MSG_CENTERDTO dto);

	bool ReadIM(Guid id);

	void DeleteMessage(MSG_CENTERDTO parameter);
}
