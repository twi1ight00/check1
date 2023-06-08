using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Portal.Domain.Models;

public class SYS_SHORTCUT : Entity
{
	public Guid SHORTCUT_ID { get; set; }

	public Guid? MENU_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public decimal? SORT { get; set; }
}
