using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ITManagement.Domain.Models;

public class IT_ACCOUNT : Entity
{
	public Guid IT_ACCOUNT_ID { get; set; }

	public string REMARK { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public Guid? DEVICE_TYPE_ID { get; set; }

	public string DEVICE_TYPE_NAME { get; set; }

	public string DEVICE_SPECIFICATION { get; set; }

	public string DEVICE_SEQ { get; set; }

	public DateTime? BUY_DATE { get; set; }

	public DateTime? ALLOCATE_DATE { get; set; }

	public Guid? KEEP_TYPE_ID { get; set; }

	public string KEEP_TYPE_NAME { get; set; }

	public string KEEP_DESCRIPTION { get; set; }

	public string ASSURANCE_YEAR { get; set; }

	public decimal? BUY_PRICE { get; set; }

	public DateTime? EMPLOYEE_BUY_DATE { get; set; }

	public decimal? LEFT_VALUE { get; set; }

	public decimal? IS_BUY { get; set; }

	public decimal? IS_CHECK { get; set; }

	public DateTime? ACCOUNT_DATE { get; set; }
}
