using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Initialization;

/// <summary>
/// 系统首页初始化所需配置信息对象
/// </summary>
public class InitializationConfig
{
	/// <summary>
	/// 导航配置，来源于配置文件，暂支持三种，TreeMenu,RibbonMenu,DropDownMenu
	/// </summary>
	public string Navigation { get; set; }

	/// <summary>
	/// 用户Session信息
	/// </summary>
	public UserSessionInfo UserSessionInfo { get; set; }

	/// <summary>
	/// 用户所属的机构列表
	/// </summary>
	public IList<UserOrgDTO> UserExistInOrg { get; set; }

	/// <summary>
	/// UI多语信息
	/// </summary>
	public IList<SYS_LOCALIZINGDTO> UILocalizing { get; set; }
}
