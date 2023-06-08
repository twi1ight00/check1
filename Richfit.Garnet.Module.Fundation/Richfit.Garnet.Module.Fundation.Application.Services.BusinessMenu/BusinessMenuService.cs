using System.Collections.Generic;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;

/// <summary>
/// 业务菜单服务接口实现
/// </summary>
public class BusinessMenuService : ServiceBase, IBusinessMenuService
{
	private readonly SqlRepository menuBusinessRepository = ServiceLocator.Instance.GetService<SqlRepository>();

	public IList<MenuDTO> GetAllMenus()
	{
		string sqlExpress = menuBusinessRepository.GetSqlConfig("GetAllMenus", GetType());
		return menuBusinessRepository.ExecuteQuery<MenuDTO>(sqlExpress, new object[0]);
	}

	public IList<BusinessDTO> GetAllBusiness()
	{
		string sqlExpress = menuBusinessRepository.GetSqlConfig("GetAllBusiness", GetType());
		return menuBusinessRepository.ExecuteQuery<BusinessDTO>(sqlExpress, new object[0]);
	}
}
