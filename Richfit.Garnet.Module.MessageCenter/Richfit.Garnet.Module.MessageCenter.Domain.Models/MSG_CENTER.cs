using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.MessageCenter.Domain.Models;

public class MSG_CENTER : Entity
{
	public Guid ID { get; set; }

	public string MSG_TITLE { get; set; }

	public decimal? MSG_TYPE { get; set; }

	public Guid? MSG_BUSINESS_ID { get; set; }

	public string MSG_SOURCE { get; set; }

	public DateTime? SEND_TIME { get; set; }

	public Guid? SEND_USER_ID { get; set; }

	public string SEND_USER_NAME { get; set; }

	public Guid? SEND_ORG_ID { get; set; }

	public string SEND_ORG_NAME { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? MSG_OPEN_TYPE { get; set; }

	public virtual ICollection<MSG_CENTER_USER> MSG_CENTER_USER { get; set; }

	public MSG_CENTER()
	{
		MSG_CENTER_USER = new HashSet<MSG_CENTER_USER>();
	}
}
