using System.Collections.Generic;
using Richfit.Garnet.Module.Workflow.Application.DTO;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class ExportDTO
{
	public string TemplatePath { get; set; }

	public IList<ExportConfig> List { get; set; }

	public string Type { get; set; }

	public IList<WF_WORKITEMDTO> History { get; set; }

	public int? HistoryDirection { get; set; }

	public LabelInfo Label { get; set; }

	public bool IsHtml { get; set; }

	public string FileName { get; set; }

	public ExportDTO()
	{
		IsHtml = false;
	}
}
