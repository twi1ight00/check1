using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.OnlineOffice.Application.DTO;
using Richfit.Garnet.Module.OnlineOffice.Domain.Models;

namespace Richfit.Garnet.Module.OnlineOffice.Application.Services;

public class OnlineOfficeService : ServiceBase, IOnlineOfficeService
{
	private readonly IRepository<OL_OFFICE> repository;

	public OnlineOfficeService(IRepository<OL_OFFICE> olOfficeRepository)
	{
		repository = olOfficeRepository;
	}

	public OL_OFFICEDTO GetOnlineOfficeByObjId(Guid objId)
	{
		IList<OL_OFFICEDTO> list = SqlQuery<OL_OFFICEDTO>("GetOnlineOfficeByObjId", new { objId });
		if (list != null && list.Count > 0)
		{
			return list[0];
		}
		return null;
	}

	public void UpateOnlineOffice(OL_OFFICEDTO dto)
	{
		if (dto == null)
		{
			throw new ArgumentException("SaveOnlineOffice方法参数不能为空！");
		}
		if (dto.IsValid())
		{
			OL_OFFICE old = repository.Find((OL_OFFICE a) => a.ID == dto.ID);
			old.OBJ_ID = dto.OBJ_ID;
			old.SUBJECT = dto.SUBJECT;
			repository.UpdateCommit(old);
			return;
		}
		throw new ValidationException(dto.GetInvalidMessages());
	}

	public Guid SaveOnlineOffice(OL_OFFICEDTO dto)
	{
		if (dto == null)
		{
			throw new ArgumentException("SaveOnlineOffice方法参数不能为空！");
		}
		if (dto.IsValid())
		{
			OL_OFFICE poco = dto.AdaptAsEntity<OL_OFFICE>();
			if (dto.IsCreate)
			{
				poco.FILE_SIXE = 1024m;
				poco.OBJ_ID = Guid.NewGuid();
				repository.AddCommit(poco);
				return poco.ID;
			}
			OL_OFFICE old = repository.Find((OL_OFFICE a) => a.ID == poco.ID);
			old.OBJ_ID = dto.OBJ_ID;
			old.FILE_NAME = dto.FILE_NAME;
			old.SUBJECT = dto.SUBJECT;
			repository.UpdateCommit(old);
			return old.ID;
		}
		throw new ValidationException(dto.GetInvalidMessages());
	}

	public void DelTempOnlineOfficeById(OL_OFFICEDTO dto)
	{
		foreach (Guid item in dto.IDs)
		{
			OL_OFFICE office = repository.GetByKey(item);
			office.IS_DEL = 1m;
			repository.UpdateCommit(office);
		}
	}

	public IList<OL_OFFICEDTO> GetTempOnlineOfficeByUserId(OL_OFFICEDTO dto)
	{
		return SqlQuery<OL_OFFICEDTO>("GetTempOnlineOfficeByUserId", dto);
	}

	public IList<OL_TEMPLATE_FILEDTO> GetTemplateFileByObjId(OL_TEMPLATE_FILE_MAPPINGDTO dto)
	{
		return SqlQuery<OL_TEMPLATE_FILEDTO>("GetTemplateFileByObjId", dto);
	}

	public void UpdateOnlineOfficeById(OL_OFFICEDTO dto)
	{
		if (dto == null)
		{
			throw new ArgumentException("SaveOnlineOffice方法参数不能为空！");
		}
		if (dto.IsValid())
		{
			OL_OFFICE old = repository.Find((OL_OFFICE a) => a.ID == dto.ID);
			old.OBJ_ID = dto.OBJ_ID;
			old.FILE_NAME = dto.FILE_NAME;
			old.SUBJECT = dto.SUBJECT;
			old.STATUS = dto.STATUS;
			repository.UpdateCommit(old);
			return;
		}
		throw new ValidationException(dto.GetInvalidMessages());
	}
}
