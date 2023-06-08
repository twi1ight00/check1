using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.CodeTableManagement.Domain.Models;

public class SYS_CODE_TABLE : Entity
{
	public Guid CODE_TABLE_ID { get; set; }

	public string CODE_ID { get; set; }

	public decimal? STATUS { get; set; }

	public decimal? SORT { get; set; }

	public Guid? PARENT_CODE_TABLE_ID { get; set; }

	public string CODE_BUSINESS_NO { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_CODE_TABLE> SYS_CODE_TABLE1 { get; set; }

	public virtual SYS_CODE_TABLE SYS_CODE_TABLE2 { get; set; }

	public SYS_CODE_TABLE()
	{
		SYS_CODE_TABLE1 = new HashSet<SYS_CODE_TABLE>();
	}
}
