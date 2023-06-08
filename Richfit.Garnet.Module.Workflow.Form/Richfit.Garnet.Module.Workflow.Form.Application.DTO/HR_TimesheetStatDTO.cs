using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Application.DTO;

public class HR_TimesheetStatDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string MONTH { get; set; }

	public string MONTH_FROM { get; set; }

	public string MONTH_TO { get; set; }

	public string DEPARTMENT { get; set; }

	public string WROK_PLACE { get; set; }

	public decimal? BJ { get; set; }

	public decimal? TQJ { get; set; }

	public decimal? LYJ { get; set; }

	public decimal? NXJ { get; set; }

	public decimal? XXJ { get; set; }

	public decimal? HJ { get; set; }

	public decimal? SAJ { get; set; }

	public decimal? CJ { get; set; }

	public decimal? SJ { get; set; }

	public decimal? KG { get; set; }

	public decimal? HX { get; set; }

	public decimal? YHX { get; set; }
}
