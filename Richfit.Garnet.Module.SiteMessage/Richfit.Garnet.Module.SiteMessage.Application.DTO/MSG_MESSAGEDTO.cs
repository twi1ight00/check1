using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SiteMessage.Application.DTO;

public class MSG_MESSAGEDTO : DTOBase
{
	public Guid ID { get; set; }

	public string MESSAGE_TITLE { get; set; }

	public string MESSAGE_CONTENT { get; set; }

	public Guid SEND_USER_ID { get; set; }

	public Guid USER_ID { get; set; }

	public Guid MSG_MESSAGE_USER_ID { get; set; }

	public string SEND_USER_NAME { get; set; }

	public string R_USER_NAMES { get; set; }

	public Guid? SEND_ORG_ID { get; set; }

	public string SEND_ORG_NAME { get; set; }

	public decimal STATUS { get; set; }

	public decimal? SORT { get; set; }

	public decimal IS_DEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal IS_ATTACHMENT { get; set; }

	public List<Guid> MSG_MESSAGE_USER_IDs { get; set; }

	public List<MSG_MESSAGE_USERDTO> MSG_MESSAGE_USER { get; set; }
}
