using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.MessageCenter.Application.DTO;

public class MSG_CENTERDTO : DTOBase
{
	public Guid ID { get; set; }

	public List<Guid> IDs { get; set; }

	public string MSG_TITLE { get; set; }

	public decimal? MSG_TYPE { get; set; }

	public decimal? MSG_OPEN_TYPE { get; set; }

	public Guid? MSG_BUSINESS_ID { get; set; }

	public string MSG_SOURCE { get; set; }

	public DateTime? SEND_TIME { get; set; }

	public Guid? SEND_USER_ID { get; set; }

	public string SEND_USER_NAME { get; set; }

	public Guid? SEND_ORG_ID { get; set; }

	public string SEND_ORG_NAME { get; set; }

	public decimal ISDEL { get; set; }

	public decimal? ISIM { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<MSG_CENTER_USERDTO> MSG_CENTER_USER { get; set; }

	public Guid USER_ID { get; set; }

	public decimal ISREAD { get; set; }
}
