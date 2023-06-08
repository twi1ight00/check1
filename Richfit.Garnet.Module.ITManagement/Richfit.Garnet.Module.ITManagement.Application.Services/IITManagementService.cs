using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.ITManagement.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.Services;

public interface IITManagementService
{
	QueryResult<IT_ACCOUNTDTO> QueryAccountList(IT_ACCOUNTDTO queryCondition);

	IT_ACCOUNTDTO AddAccount(IT_ACCOUNTDTO deviceDTO);

	IT_STOCK_INDTO AddStockIn(IT_STOCK_INDTO stockInDTO);

	QueryResult<IT_STOCK_INDTO> GetStockINList(IT_STOCK_INDTO queryCondition);

	QueryResult<IT_STOCK_OUT_DETAILDTO> GetStockOutList(IT_STOCK_OUT_DETAILDTO queryCondition);

	QueryResult<IT_STOCK_IN_DETAILDTO> GetNoCheckInList(IT_STOCK_IN_DETAILDTO queryCondition);

	IT_ACCOUNTDTO UpdateAccount(IT_ACCOUNTDTO deviceDTO);

	void DeleteAccountByAccountID(string accountIds);

	IList<IT_MATERIALDTO> GetMaterialType(IT_MATERIALDTO queryCondition);

	bool IsNeedPurchase(string sqlIDs);

	IT_MATERIALDTO AddMaterialCheckIn(IT_MATERIALDTO materialDTO);

	QueryResult<IT_MATERIALDTO> GetCurrentMaterialList(IT_MATERIALDTO queryCondition);

	QueryResult<IT_MATERIAL_CHECKINDTO> GetMaterialCheckInList(IT_MATERIAL_CHECKINDTO queryCondition);

	QueryResult<IT_MATERIALDTO> QueryMaterialList(IT_MATERIALDTO materialDTO);

	IT_MATERIALDTO SaveMaterial(IT_MATERIALDTO s);

	IT_MATERIALDTO UpdateMaterialList(IT_MATERIALDTO materialDTO);
}
