using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

/// <summary>
/// SelfReferDTO 为自参照控件，前端对应DTO类
/// </summary>
[Serializable]
public class SelfReferDTO : DTOBase
{
	public string TEXT { get; set; }
}
