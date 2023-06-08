using System;

namespace Richfit.Garnet.Module.Workflow.Application.IServices;

public interface IDTO
{
	string UpdateSql { get; set; }

	string AddSql { get; set; }

	string FindPage { get; set; }

	string FindByInstance { get; set; }

	Guid? BUSINESS_ID { get; set; }

	Guid? USER_ID { get; set; }

	int SearchType { get; set; }

	string FindList(string parm);
}
