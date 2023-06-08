using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.OnlineOffice.Domain.Models;

public class OL_TEMPLATE_FILE : Entity
{
	public Guid ID { get; set; }

	public string TEMPLATE_FILE_URL { get; set; }

	public string TEMPLATE_FILE_NAME { get; set; }

	public string TEMPLATE_DESCRIBE { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
