using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.JScript;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Domain.Models;

namespace Richfit.Garnet.Module.ITManagement.Application.Services;

public class ITSupportService : ServiceBase, IITSupportService
{
	private readonly IRepository<IT_SUPPORTMANG> itSupportmangRepository;

	public ITSupportService(IRepository<IT_SUPPORTMANG> itSupportmangRepository)
	{
		this.itSupportmangRepository = itSupportmangRepository;
	}

	public QueryResult<IT_SUPPORTMANGDTO> QueryGetAllItSupportList(IT_SUPPORTMANGDTO queryCondition)
	{
		return SqlQueryPager<IT_SUPPORTMANGDTO>("GetAllItSupportList", queryCondition);
	}

	public QueryResult<IT_SUPPORTMANGDTO> AllitSupportModelSearchList(IT_SUPPORTMANGDTO queryCondition)
	{
		return SqlQueryPager<IT_SUPPORTMANGDTO>("AllitSupportModelSearchList", queryCondition);
	}

	public IT_SUPPORTMANG GetITAttachmentByID(Guid id)
	{
		return itSupportmangRepository.GetByKey(id);
	}

	public void ITSupportAddAttachment(IT_SUPPORTMANGDTO itSupportdto)
	{
		if (itSupportdto == null)
		{
			throw new ArgumentException("AddFile方法参数不能为空！");
		}
		if (itSupportdto.IsValid())
		{
			DateTime date = DateTime.Now;
			IT_SUPPORTMANG itattachment = itSupportdto.AdaptAsEntity<IT_SUPPORTMANG>();
			itattachment.IT_SUPPORTMANG_NAME = GlobalObject.unescape(itattachment.IT_SUPPORTMANG_NAME);
			FileInfo fileInfo = new FileInfo(itattachment.FILE_RELATIVE_PATH);
			int index = itattachment.IT_SUPPORTMANG_NAME.LastIndexOf('.');
			itattachment.FILE_TYPE = ((index > -1) ? itattachment.IT_SUPPORTMANG_NAME.Substring(index + 1, itattachment.IT_SUPPORTMANG_NAME.Length - index - 1) : "");
			Guid? cREATOR = (itattachment.MODIFIER = SessionContext.UserInfo.UserID);
			itattachment.CREATOR = cREATOR;
			DateTime? cREATETIME = (itattachment.MODIFYTIME = DateTime.Now);
			itattachment.CREATETIME = cREATETIME;
			itattachment.ISDEL = 0m;
			IT_SUPPORTMANG AttachmentIDPOCO = itSupportmangRepository.GetByKey(itattachment.IT_SUPPORTMANG_ID);
			if (AttachmentIDPOCO != null)
			{
				AttachmentIDPOCO.IT_SUPPORTMANG_TYPE_ID = itattachment.IT_SUPPORTMANG_TYPE_ID;
				AttachmentIDPOCO.IT_SUPPORTMANG_TYPE_NAME = itattachment.IT_SUPPORTMANG_TYPE_NAME;
				AttachmentIDPOCO.REMARK = itattachment.REMARK;
				AttachmentIDPOCO.FILE_RELATIVE_PATH = itattachment.FILE_RELATIVE_PATH;
				itSupportmangRepository.UpdateCommit(AttachmentIDPOCO);
			}
			else
			{
				itSupportmangRepository.AddCommit(itattachment);
			}
			return;
		}
		throw new ValidationException(itSupportdto.GetInvalidMessages());
	}

	public void ITSupportDelAttachment(List<string> idList)
	{
		foreach (string item in idList)
		{
			IT_SUPPORTMANG itSupport = itSupportmangRepository.GetByKey(Guid.Parse(item));
			itSupport.ISDEL = 1m;
			itSupportmangRepository.UpdateCommit(itSupport);
		}
	}
}
