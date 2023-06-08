using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.HRManagement.Application.DTO;

public class HR_FORMDTO : DTOBase
{
	public string columnName { get; set; }

	public string fieldName { get; set; }

	public string fieldValue { get; set; }

	public string type { get; set; }

	public string format { get; set; }

	public decimal? sort { get; set; }
}
