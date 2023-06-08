using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

[Serializable]
public class SYS_LOGDTO : DTOBase
{
	public Guid LOG_ID { get; set; }

	public string BUSINESS_TYPE { get; set; }

	public string DATA { get; set; }

	public string IP { get; set; }

	public Guid? ORG_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public DateTime? DO_TIME { get; set; }

	public string TOKEN { get; set; }
}
