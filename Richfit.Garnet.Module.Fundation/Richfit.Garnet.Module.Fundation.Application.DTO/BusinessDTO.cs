using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

[Serializable]
public class BusinessDTO : DTOBase
{
	public Guid BUSINESS_ID { get; set; }

	public Guid? PARENT_BUSINESS_ID { get; set; }

	public string BUSINESS_CODE { get; set; }

	public string BUSINESS_NAME { get; set; }

	public string PARENT_BUSINESS_NAME { get; set; }
}
