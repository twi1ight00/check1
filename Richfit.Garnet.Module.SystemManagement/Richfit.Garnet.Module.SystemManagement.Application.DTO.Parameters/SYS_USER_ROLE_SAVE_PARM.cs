using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO.Parameters;

public class SYS_USER_ROLE_SAVE_PARM
{
	private IList<SYS_USER_ROLE> userRoleList;

	public IList<SYS_USER_ROLE> SYS_USER_ROLE { get; set; }

	public Guid USER_ID { get; set; }

	public SYS_USER_ROLE_SAVE_PARM()
	{
		userRoleList = new List<SYS_USER_ROLE>();
	}
}
