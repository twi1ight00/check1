using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Localizing.Domain.Models;

public class SYS_LANGUAGE : Entity
{
	public Guid LANGUAGE_ID { get; set; }

	public string LANGUAGE_NAME { get; set; }

	public string CULTURE { get; set; }

	public decimal IS_USE { get; set; }

	public decimal? SORT { get; set; }

	public virtual ICollection<SYS_LOCALIZING> SYS_LOCALIZING { get; set; }

	public SYS_LANGUAGE()
	{
		SYS_LOCALIZING = new HashSet<SYS_LOCALIZING>();
	}
}
