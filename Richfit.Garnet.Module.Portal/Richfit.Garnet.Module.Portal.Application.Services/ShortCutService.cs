using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Portal.Application.DTO;
using Richfit.Garnet.Module.Portal.Domain.Models;

namespace Richfit.Garnet.Module.Portal.Application.Services;

public class ShortCutService : ServiceBase, IShortCutService
{
	private readonly IRepository<SYS_SHORTCUT> sysShortcutRepository;

	public ShortCutService(IRepository<SYS_SHORTCUT> sysShortcutRepository)
	{
		this.sysShortcutRepository = sysShortcutRepository;
	}

	public QueryResult<SYS_SHORTCUTDTO> GetShortcuts()
	{
		QueryResult<SYS_SHORTCUTDTO> result = new QueryResult<SYS_SHORTCUTDTO>();
		ISpecification<SYS_SHORTCUT> specification = new ExpressionSpecification<SYS_SHORTCUT>((SYS_SHORTCUT s) => s.USER_ID == SessionContext.UserInfo.UserID);
		IEnumerable<SYS_SHORTCUT> shortcutList = sysShortcutRepository.FindAll(specification);
		List<SYS_SHORTCUTDTO> list = shortcutList.AdaptAsDTO<SYS_SHORTCUTDTO>();
		list.Sort();
		result.List = list;
		return result;
	}

	public void UpdateShortcuts(List<SYS_SHORTCUTDTO> shortcutDTOs)
	{
		ISpecification<SYS_SHORTCUT> specification = new ExpressionSpecification<SYS_SHORTCUT>((SYS_SHORTCUT s) => s.USER_ID == SessionContext.UserInfo.UserID);
		List<SYS_SHORTCUT> shortcutList = sysShortcutRepository.FindAll(specification) as List<SYS_SHORTCUT>;
		List<Guid> idlist = new List<Guid>();
		foreach (SYS_SHORTCUT shortcut in shortcutList)
		{
			Guid shortcutid2 = shortcut.SHORTCUT_ID;
			if (shortcutDTOs.FindIndex((SYS_SHORTCUTDTO a) => a.SHORTCUT_ID == shortcutid2) == -1)
			{
				idlist.Add(shortcutid2);
			}
		}
		foreach (Guid shortcutid in idlist)
		{
			SYS_SHORTCUT poco = sysShortcutRepository.GetByKey(shortcutid);
			sysShortcutRepository.Remove(poco);
		}
		foreach (SYS_SHORTCUTDTO dto in shortcutDTOs)
		{
			switch (dto.RecordState)
			{
			case RecordState.Added:
			{
				SYS_SHORTCUT poco = dto.AdaptAsEntity<SYS_SHORTCUT>();
				poco.USER_ID = SessionContext.UserInfo.UserID;
				sysShortcutRepository.Add(poco);
				break;
			}
			case RecordState.Modified:
			{
				SYS_SHORTCUT poco = sysShortcutRepository.GetByKey(dto.SHORTCUT_ID);
				poco.SORT = dto.SORT;
				poco.USER_ID = SessionContext.UserInfo.UserID;
				sysShortcutRepository.Update(poco);
				break;
			}
			case RecordState.Deleted:
			{
				SYS_SHORTCUT poco = sysShortcutRepository.GetByKey(dto.SHORTCUT_ID);
				sysShortcutRepository.Remove(poco);
				break;
			}
			}
		}
		sysShortcutRepository.DbContext.Commit();
	}
}
