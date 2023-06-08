using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

[Serializable]
public class DomainDTO : DTOBase
{
	public Guid DOMAIN_ID { get; set; }

	public string DOMAIN_NAME { get; set; }

	public string DOMAIN_ADDRESS { get; set; }

	public string DOMAIN_ACCOUNT { get; set; }

	public string DOMAIN_PWD { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal? SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
