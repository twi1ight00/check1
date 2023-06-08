using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

[Serializable]
public class ActionHandlerDTO : DTOBase
{
	public string ACTION_CODE { get; set; }

	public string ASSEMBLY_NAME { get; set; }

	/// <summary>
	/// Action是否需要权限验证，0：是；1：否
	/// </summary>
	public decimal PRIVIGE_VALIDATE_TYPE { get; set; }
}
