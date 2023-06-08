using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.MessageCenter.Domain.Models;

public class MSG_CENTER_USER : Entity
{
	public Guid ID { get; set; }

	public Guid? MSG_CENTER_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public decimal ISREAD { get; set; }

	public DateTime? READ_TIME { get; set; }

	public decimal SORT { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal ISIM { get; set; }

	public virtual MSG_CENTER MSG_CENTER { get; set; }
}
