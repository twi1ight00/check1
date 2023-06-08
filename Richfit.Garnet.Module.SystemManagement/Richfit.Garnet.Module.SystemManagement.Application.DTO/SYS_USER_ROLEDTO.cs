using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

[Serializable]
public class SYS_USER_ROLEDTO : DTOBase
{
	public Guid USER_ROLE_ID { get; set; }

	/// <summary>
	/// 用户ID
	/// </summary>
	public Guid USER_ID { get; set; }

	/// <summary>
	/// 组织机构ID
	/// </summary>
	public Guid ORG_ID { get; set; }

	/// <summary>
	/// 角色ID
	/// </summary>
	public Guid ROLE_ID { get; set; }
}
