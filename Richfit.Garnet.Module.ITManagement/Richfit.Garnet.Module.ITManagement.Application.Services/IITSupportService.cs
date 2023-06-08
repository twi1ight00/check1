using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Domain.Models;

namespace Richfit.Garnet.Module.ITManagement.Application.Services;

public interface IITSupportService
{
	QueryResult<IT_SUPPORTMANGDTO> QueryGetAllItSupportList(IT_SUPPORTMANGDTO queryCondition);

	QueryResult<IT_SUPPORTMANGDTO> AllitSupportModelSearchList(IT_SUPPORTMANGDTO queryCondition);

	IT_SUPPORTMANG GetITAttachmentByID(Guid id);

	void ITSupportAddAttachment(IT_SUPPORTMANGDTO itSupportdto);

	void ITSupportDelAttachment(List<string> idList);
}
