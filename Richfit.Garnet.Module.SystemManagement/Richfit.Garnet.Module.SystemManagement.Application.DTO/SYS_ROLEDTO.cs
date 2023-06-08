using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

[Serializable]
public class SYS_ROLEDTO : DTOBase
{
	public Guid ROLE_ID { get; set; }

	public string ROLE_NAME { get; set; }

	/// <summary>
	/// 0共享角色1私有角色
	/// </summary>
	public decimal ROLE_TYPE { get; set; }

	public Guid? ORG_ID { get; set; }

	public Guid? SOURCE_ORG_ID { get; set; }

	/// <summary>
	/// 使用组织结构
	/// </summary>
	public string USINGORGNAME { get; set; }

	/// <summary>
	/// 使用组织结构
	/// </summary>
	public string DISPLAY_NAME { get; set; }

	/// <summary>
	/// 角色类型名称
	/// </summary>
	public string ROLE_TYPE_NAME { get; set; }

	public string ORG_NAME { get; set; }

	/// <summary>
	/// 角色创建方式（继承上级，本级创建）
	/// </summary>
	public string ROLE_CREATE_TYPE { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public decimal? IS_CREATE_BY_SELF_ORG { get; set; }

	public Guid CREATOR { get; set; }

	public Guid ROLE_ORG_ID { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }
}
