using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class SYS_MAIL_LOGDTO : DTOBase
{
	public Guid EMAIL_LOG_ID { get; set; }

	public string SERVER_IP { get; set; }

	public string MAIL_TO_ADDRESS { get; set; }

	public string MAIL_FROM_ADDRESS { get; set; }

	public string MAIL_FROM_PWD { get; set; }

	public string MAIL_SUBJECT { get; set; }

	public string MAIL_BODY { get; set; }

	public Guid OBJECT_ID { get; set; }

	public Guid? EXTEND_ID { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
