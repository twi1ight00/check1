using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Supervise.Application.DTO;

public class SUP_PORJECT_USERDTO : DTOBase
{
	public Guid PORJECT_USER_ID { get; set; }

	public Guid? PORJECT_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public decimal TYPE_ID { get; set; }
}
