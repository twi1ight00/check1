using System.Collections.Generic;
using Richfit.Garnet.Module.HRManagement.Application.DTO;

namespace Richfit.Garnet.Module.HRManagement.Application.Services;

public interface IHRManagementService
{
	/// <summary>
	/// 导入数据保存到数据库
	/// </summary>
	/// <param name="dto"></param>
	/// <returns></returns>
	IList<S_TEMP_STO_HRMANAGEMENTDTO> InsertDataFromImport(IList<S_TEMP_STO_HRMANAGEMENTDTO> Listdto);
}
