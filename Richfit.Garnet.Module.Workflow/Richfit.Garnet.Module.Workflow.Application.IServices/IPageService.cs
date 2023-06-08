using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.IServices;

public interface IPageService
{
	IList<WF_PAGEDTO> GetPageByTemplateVersion(Guid versionId);

	WF_PAGE SavePage(WF_PAGEDTO pageDTO);

	WF_PAGEDTO FindById(Guid pageId);
}
