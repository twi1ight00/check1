using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class WF_META_TABLESIMPLEDTO
{
	public Guid META_TABLE_ID { get; set; }

	public Guid TEMPLATE_ID { get; set; }

	public string TABLE_NAME { get; set; }

	public string TABLE_DB_NAME { get; set; }

	public Guid? PARENT_TABLE_ID { get; set; }
}
