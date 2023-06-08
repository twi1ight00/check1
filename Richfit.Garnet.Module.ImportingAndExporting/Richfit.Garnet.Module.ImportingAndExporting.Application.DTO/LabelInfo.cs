using System.Collections.Generic;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class LabelInfo
{
	public string Sheet { get; set; }

	public IList<LabelDataDTO> Data { get; set; }
}
