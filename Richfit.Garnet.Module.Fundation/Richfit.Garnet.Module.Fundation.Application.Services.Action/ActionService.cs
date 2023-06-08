using System.Collections.Generic;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Action;

/// <summary>
/// Action服务接口实现
/// </summary>
public class ActionService : IActionService
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly SqlRepository actionRepository = ServiceLocator.Instance.GetService<SqlRepository>();

	public IList<ActionHandlerDTO> GetAllActionHandlerMapping()
	{
		string sqlExpress = actionRepository.GetSqlConfig("GetActionHandlerMapping", GetType());
		return actionRepository.ExecuteQuery<ActionHandlerDTO>(sqlExpress, new object[0]);
	}

	public IList<ActionBusinessDTO> GetAllActionBusinessMapping()
	{
		string sqlExpress = actionRepository.GetSqlConfig("GetActionBusinessMapping", GetType());
		return actionRepository.ExecuteQuery<ActionBusinessDTO>(sqlExpress, new object[0]);
	}
}
