using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.DTO;

[Serializable]
public class VersionInfoDTO : DTOBase
{
	public int NEED_UPDATE { get; set; }

	public string OS { get; set; }

	public string CURRENT_VERSION { get; set; }

	public string UPDATE_INFO { get; set; }

	public string INSTALL_URL { get; set; }
}
