using System.Collections.Generic;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;

/// <summary>
/// 业务菜单服务接口定义
/// </summary>
public interface IBusinessMenuService
{
	/// <summary>
	/// 获得所有菜单
	/// </summary>
	/// <returns></returns>
	IList<MenuDTO> GetAllMenus();

	/// <summary>
	/// 获得所有业务
	/// </summary>
	/// <returns></returns>
	IList<BusinessDTO> GetAllBusiness();
}
