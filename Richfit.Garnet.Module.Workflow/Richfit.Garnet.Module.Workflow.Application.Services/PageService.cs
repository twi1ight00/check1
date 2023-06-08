using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

public class PageService : ServiceBase, IPageService
{
	private readonly IRepository<WF_PAGE> pageRepository = null;

	public PageService()
	{
		pageRepository = ServiceLocator.Instance.GetService<IRepository<WF_PAGE>>();
	}

	public IList<WF_PAGEDTO> GetPageByTemplateVersion(Guid version)
	{
		IOrderedEnumerable<WF_PAGE> query = from a in pageRepository.FindAll((WF_PAGE a) => a.TEMPLATE_ID == version && a.ISDEL == 0m)
			orderby a.VERSION_ID, a.VERSION_NUM
			select a;
		IList<WF_PAGEDTO> dtoList = new List<WF_PAGEDTO>();
		if (query.Any())
		{
			IEnumerable<WF_PAGE> top = query.Where((WF_PAGE a) => a.PARENT_PAGE_ID == Guid.Empty);
			foreach (WF_PAGE page in top)
			{
				WF_PAGEDTO topDto = page.AdaptAsDTO<WF_PAGEDTO>();
				dtoList.Add(topDto);
				Func<WF_PAGE, bool> predicate = (WF_PAGE a) => a.PARENT_PAGE_ID == page.PAGE_ID;
				IEnumerable<WF_PAGE> sub = query.Where(predicate);
				if (!sub.Any())
				{
					continue;
				}
				foreach (WF_PAGE subPage in sub)
				{
					topDto.pageList.Add(subPage.AdaptAsDTO<WF_PAGEDTO>());
				}
			}
		}
		return dtoList;
	}

	/// <summary>
	/// 增加一个表单
	/// </summary>
	public WF_PAGE SavePage(WF_PAGEDTO pageDTO)
	{
		if (pageDTO == null)
		{
			throw new ArgumentException("Addform方法参数不能为空！");
		}
		if (pageDTO.IsValid())
		{
			WF_PAGE page;
			if (pageDTO.IsCreate)
			{
				IList<WF_PAGE> query = pageRepository.FindAll((WF_PAGE a) => a.PARENT_PAGE_ID == pageDTO.PARENT_PAGE_ID && a.ISDEL == 0m);
				decimal version = 0m;
				if (query.Any())
				{
					decimal? max = query.Max((WF_PAGE a) => a.VERSION_NUM);
					if (max.HasValue)
					{
						version = max.Value + 1m;
					}
				}
				page = pageDTO.AdaptAsEntity<WF_PAGE>();
				page.VERSION_NUM = version;
				pageRepository.AddCommit(page);
				if (page.PARENT_PAGE_ID == Guid.Empty)
				{
					WF_PAGE wF_PAGE = new WF_PAGE();
					wF_PAGE.PAGE_NAME = page.PAGE_NAME;
					wF_PAGE.PARENT_PAGE_ID = page.PAGE_ID;
					wF_PAGE.VERSION_ID = page.VERSION_ID;
					wF_PAGE.VERSION_NAME = (string.IsNullOrEmpty(page.VERSION_NAME) ? page.PAGE_NAME : page.VERSION_NAME);
					wF_PAGE.VERSION_NUM = ++version;
					wF_PAGE.TEMPLATE_ID = page.TEMPLATE_ID;
					WF_PAGE pageSub = wF_PAGE;
					pageRepository.AddCommit(pageSub);
				}
			}
			else
			{
				page = pageRepository.GetByKey(pageDTO.PAGE_ID);
				page.VERSION_NAME = pageDTO.VERSION_NAME;
				page.VERSION_NUM = pageDTO.VERSION_NUM;
				page.PAGE_NAME = pageDTO.PAGE_NAME;
				page.ISDEL = pageDTO.ISDEL;
				pageRepository.UpdateCommit(page);
			}
			return page;
		}
		throw new ValidationException(pageDTO.GetInvalidMessages());
	}

	public WF_PAGEDTO FindById(Guid pageId)
	{
		WF_PAGE query = pageRepository.GetByKey(pageId);
		query.WF_FORM = query.WF_FORM.OrderBy((WF_FORM a) => a.SORT).ToList();
		foreach (WF_FORM form in query.WF_FORM)
		{
			form.WF_FORM_DEFINITION = (from a in form.WF_FORM_DEFINITION
				orderby a.ROWNUMBER, a.COLNUMBER
				select a).ToList();
		}
		return query.AdaptAsDTO<WF_PAGEDTO>();
	}
}
