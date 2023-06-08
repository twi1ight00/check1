using System.Collections.Generic;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Action;

/// <summary>
/// Action服务接口定义
/// </summary>
public interface IActionService
{
	/// <summary>
	/// 获得Action与Handler映射信息
	/// </summary>
	/// <returns></returns>
	IList<ActionHandlerDTO> GetAllActionHandlerMapping();

	/// <summary>
	/// 获得Action与Business映射信息
	/// </summary>
	/// <returns></returns>
	IList<ActionBusinessDTO> GetAllActionBusinessMapping();
}
