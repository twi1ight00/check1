using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

[Serializable]
public class ActionBusinessDTO : DTOBase
{
	public string ACTION_CODE { get; set; }

	public Guid BUSINESS_ID { get; set; }
}
