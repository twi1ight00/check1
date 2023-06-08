using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.OnlineOffice.Domain.Models;

public class OL_OFFICE : Entity
{
	public Guid ID { get; set; }

	public Guid OBJ_ID { get; set; }

	public string FILE_NAME { get; set; }

	public string SUBJECT { get; set; }

	public decimal FILE_SIXE { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public decimal STATUS { get; set; }

	public Guid TEMPLATE_FILE_ID { get; set; }
}
