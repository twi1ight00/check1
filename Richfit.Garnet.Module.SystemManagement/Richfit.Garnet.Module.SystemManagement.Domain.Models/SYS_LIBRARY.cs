using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_LIBRARY : Entity
{
	public Guid LIBRARY_ID { get; set; }

	public string LIBRARY_NAME { get; set; }

	public string ASSEMBLY_NAME { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_BUSINESS> SYS_BUSINESS { get; set; }

	public virtual ICollection<SYS_HANDLER> SYS_HANDLER { get; set; }

	public SYS_LIBRARY()
	{
		SYS_BUSINESS = new HashSet<SYS_BUSINESS>();
		SYS_HANDLER = new HashSet<SYS_HANDLER>();
	}
}
