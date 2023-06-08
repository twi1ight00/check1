using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

[Serializable]
public class UserOrgDTO : DTOBase
{
	public Guid USER_ORG_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public Guid USER_ID { get; set; }

	public string ORG_NAME { get; set; }

	/// <summary>
	/// 0 次要标志 1为主要标志
	/// </summary>
	public decimal? USER_IDENTITY_TYPE { get; set; }
}
