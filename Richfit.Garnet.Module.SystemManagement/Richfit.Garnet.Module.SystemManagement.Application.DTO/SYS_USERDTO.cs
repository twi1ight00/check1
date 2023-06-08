using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

[Serializable]
public class SYS_USERDTO : DTOBase
{
	/// <summary>
	/// 用户ID
	/// </summary>
	public Guid USER_ID { get; set; }

	/// <summary>
	/// 域ID
	/// </summary>
	public Guid? DOMAIN_ID { get; set; }

	/// <summary>
	/// 域名称
	/// </summary>
	public string DOMAIN_NAME { get; set; }

	/// <summary>
	/// 用户账户
	/// </summary>
	public string LOGON_NAME { get; set; }

	/// <summary>
	/// 用户名称
	/// </summary>
	public string DISPLAY_NAME { get; set; }

	/// <summary>
	/// 邮箱
	/// </summary>
	public string MAIL { get; set; }

	/// <summary>
	/// 用户密码
	/// </summary>
	public string USER_PASSWORD { get; set; }

	/// <summary>
	/// 用户类型
	/// </summary>
	public decimal? USER_TYPE { get; set; }

	/// <summary>
	/// 用户类型名称
	/// </summary>
	public string USER_TYPE_NAME { get; set; }

	/// <summary>
	/// 排序
	/// </summary>
	public decimal SORT { get; set; }

	/// <summary>
	/// 备注
	/// </summary>
	public string NOTE { get; set; }

	/// <summary>
	/// 删除标志
	/// </summary>
	public decimal ISDEL { get; set; }

	/// <summary>
	/// 组织机构ID
	/// </summary>
	public Guid? ORG_ID { get; set; }

	/// <summary>
	/// 角色ID
	/// </summary>
	public Guid? ROLE_ID { get; set; }

	/// <summary>
	/// 用户与机构对应的唯一标识,Add by DZG 2013-4-26
	/// </summary>
	public decimal? USER_IDENTITY_TYPE { get; set; }

	public string USER_IDENTITY_NAME { get; set; }

	/// <summary>
	/// 组织机构名称
	/// </summary>
	public string ORG_NAME { get; set; }

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

	/// <summary>
	/// 是否禁用
	/// </summary>
	public decimal IS_FORBIDDEN { get; set; }

	/// <summary>
	/// 是否禁用名称
	/// </summary>
	public string IS_FORBIDDEN_NAME { get; set; }
}
