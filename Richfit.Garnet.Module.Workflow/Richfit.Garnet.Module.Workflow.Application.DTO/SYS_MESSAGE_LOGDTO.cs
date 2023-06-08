using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.DTO;

public class SYS_MESSAGE_LOGDTO : DTOBase
{
	public Guid ID { get; set; }

	public string IP { get; set; }

	public DateTime? CREATE_TIME { get; set; }

	public DateTime? SENDTIME { get; set; }

	public string BROWSER { get; set; }

	public string RRID { get; set; }

	public string SN { get; set; }

	public string PWD { get; set; }

	public DateTime? STIME { get; set; }

	public string CONTENT { get; set; }

	public string EXT { get; set; }

	public string MOBILE { get; set; }

	public string OBJECT_ID { get; set; }

	public string EXTEND_ID { get; set; }
}
