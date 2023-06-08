using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SystemManagement.Domain.Models;

public class SYS_MENU : Entity
{
	public Guid MENU_ID { get; set; }

	public string MENU_URL { get; set; }

	public string TITLE_IMAGE_URL { get; set; }

	public decimal SORT { get; set; }

	public decimal? OPEN_MODE { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public decimal? IS_SHORT_CUT { get; set; }

	public string SHORT_CUT_IMAGE_URL { get; set; }

	public string SILVERLIGHT_IMAGE_URL { get; set; }

	public string SILVERLIGHT_ASSEMBLY { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public virtual SYS_BUSINESS SYS_BUSINESS { get; set; }
}
