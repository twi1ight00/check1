using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.SiteMessage.Domain.Models;

public class MSG_MESSAGE : Entity
{
	public Guid ID { get; set; }

	public string MESSAGE_TITLE { get; set; }

	public string MESSAGE_CONTENT { get; set; }

	public Guid SEND_USER_ID { get; set; }

	public string SEND_USER_NAME { get; set; }

	public Guid? SEND_ORG_ID { get; set; }

	public string SEND_ORG_NAME { get; set; }

	public decimal? SORT { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal IS_ATTACHMENT { get; set; }

	public string R_USER_NAMES { get; set; }

	public virtual ICollection<MSG_MESSAGE_USER> MSG_MESSAGE_USER { get; set; }

	public MSG_MESSAGE()
	{
		MSG_MESSAGE_USER = new HashSet<MSG_MESSAGE_USER>();
	}
}
