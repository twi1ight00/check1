using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

[Serializable]
public class SYS_USERINFODTO : DTOBase
{
	/// <summary>
	/// 用户ID
	/// </summary>
	public Guid USER_ID { get; set; }

	/// <summary>
	/// 用户账户
	/// </summary>
	public string LOGON_NAME { get; set; }

	/// <summary>
	/// 用户名称
	/// </summary>
	public string DISPLAY_NAME { get; set; }

	/// <summary>
	/// 组织机构ID
	/// </summary>
	public Guid? ORG_ID { get; set; }

	/// <summary>
	/// 组织机构名称
	/// </summary>
	public string ORG_NAME { get; set; }

	/// <summary>
	/// 扩展字段1
	/// </summary>
	public string EXTEND1 { get; set; }
}
