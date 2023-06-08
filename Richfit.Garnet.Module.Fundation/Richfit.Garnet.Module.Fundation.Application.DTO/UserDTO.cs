using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

[Serializable]
public class UserDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public string LOGON_NAME { get; set; }

	public string DISPLAY_NAME { get; set; }

	public string USER_PASSWORD { get; set; }

	public Guid? DOMAIN_ID { get; set; }

	public string DOMAIN_NAME { get; set; }

	public decimal? USER_TYPE { get; set; }

	public string USERTYPENAME { get; set; }

	public decimal? SORT { get; set; }

	public int IsMobile { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public string ORG_NAME { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	/// <summary>
	/// 是否禁用
	/// </summary>
	public decimal IS_FORBIDDEN { get; set; }

	/// <summary>
	/// 扩展字段1
	/// </summary>
	public string EXTEND1 { get; set; }

	/// <summary>
	/// 扩展字段2
	/// </summary>
	public string EXTEND2 { get; set; }

	/// <summary>
	/// 扩展字段3
	/// </summary>
	public string EXTEND3 { get; set; }

	/// <summary>
	/// 扩展字段4
	/// </summary>
	public string EXTEND4 { get; set; }

	/// <summary>
	/// 扩展字段5
	/// </summary>
	public string EXTEND5 { get; set; }

	public Guid ORG_ID { get; set; }
}
