using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_HANDLER : Entity
{
	public Guid HANDLER_ID { get; set; }

	public Guid LIBRARY_ID { get; set; }

	public string HANDLER_NAME { get; set; }

	public string HANDLER_FULL_NAME { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual ICollection<SYS_ACTION> SYS_ACTION { get; set; }

	public virtual SYS_LIBRARY SYS_LIBRARY { get; set; }

	public SYS_HANDLER()
	{
		SYS_ACTION = new HashSet<SYS_ACTION>();
	}
}
