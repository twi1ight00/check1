using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

[Serializable]
public class SaveAccountParameter
{
	public string HTML { get; set; }

	public Guid META_TABLE_ID { get; set; }

	public List<WF_METADATADTO> WF_METADATA { get; set; }
}
