using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO.Parameters;

[Serializable]
public class USER_ROLE_PARM
{
	/// <summary>
	/// 用户ID
	/// </summary>
	public Guid USER_ID { get; set; }

	/// <summary>
	/// 角色ID
	/// </summary>
	public Guid ROLE_ID { get; set; }

	public List<Guid> ORG_ID { get; set; }
}
