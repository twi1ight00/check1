using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Domain.Models;

namespace Richfit.Garnet.Module.ITManagement.Application.Services;

public class ITManagementService : ServiceBase, IITManagementService
{
	private readonly IRepository<IT_ACCOUNT> accountRepository;

	private readonly IRepository<IT_MATERIAL_CHECKIN> materialRepository;

	private readonly IRepository<IT_MATERIAL> material_Repository;

	private readonly IRepository<IT_STOCK_IN> stockinRepository;

	protected SqlRepository repository;

	public ITManagementService(IRepository<IT_ACCOUNT> repositoryAccount, IRepository<IT_MATERIAL_CHECKIN> repositoryMaterial, IRepository<IT_MATERIAL> repository_material, IRepository<IT_STOCK_IN> repository_stockin)
	{
		accountRepository = repositoryAccount;
		materialRepository = repositoryMaterial;
		material_Repository = repository_material;
		stockinRepository = repository_stockin;
		repository = new SqlRepository(null);
	}

	public QueryResult<IT_ACCOUNTDTO> QueryAccountList(IT_ACCOUNTDTO queryCondition)
	{
		return SqlQueryPager<IT_ACCOUNTDTO>("GetAccountAllList", queryCondition);
	}

	public IT_ACCOUNTDTO AddAccount(IT_ACCOUNTDTO deviceDTO)
	{
		if (deviceDTO == null)
		{
			throw new ArgumentException("AddEmployee方法参数不能为空！");
		}
		if (deviceDTO.IsValid())
		{
			IT_ACCOUNT devicePOCO = deviceDTO.AdaptAsEntity<IT_ACCOUNT>();
			accountRepository.AddCommit(devicePOCO);
			deviceDTO = devicePOCO.AdaptAsDTO<IT_ACCOUNTDTO>();
			return deviceDTO;
		}
		throw new ValidationException(deviceDTO.GetInvalidMessages());
	}

	public IT_ACCOUNTDTO UpdateAccount(IT_ACCOUNTDTO deviceDTO)
	{
		if (deviceDTO == null || deviceDTO.IT_ACCOUNT_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateAccount方法参数不能为空！");
		}
		if (deviceDTO.IsValid())
		{
			IT_ACCOUNT persisted = accountRepository.GetByKey(deviceDTO.IT_ACCOUNT_ID);
			if (persisted != null)
			{
				IT_ACCOUNT accountPOCO = deviceDTO.AdaptAsEntity<IT_ACCOUNT>();
				if (persisted.IsUpdateConflict(accountPOCO))
				{
					throw new ArgumentException("数据已过期，请刷新重试！");
				}
				IT_ACCOUNT newAccountPOCO = persisted;
				newAccountPOCO.REMARK = deviceDTO.REMARK;
				newAccountPOCO.USER_ID = deviceDTO.USER_ID;
				newAccountPOCO.USER_NAME = deviceDTO.USER_NAME;
				newAccountPOCO.ORG_ID = deviceDTO.ORG_ID;
				newAccountPOCO.ORG_NAME = deviceDTO.ORG_NAME;
				newAccountPOCO.DEVICE_TYPE_ID = deviceDTO.DEVICE_TYPE_ID;
				newAccountPOCO.DEVICE_TYPE_NAME = deviceDTO.DEVICE_TYPE_NAME;
				newAccountPOCO.DEVICE_SPECIFICATION = deviceDTO.DEVICE_SPECIFICATION;
				newAccountPOCO.DEVICE_SEQ = deviceDTO.DEVICE_SEQ;
				newAccountPOCO.BUY_DATE = deviceDTO.BUY_DATE;
				newAccountPOCO.ALLOCATE_DATE = deviceDTO.ALLOCATE_DATE;
				newAccountPOCO.KEEP_TYPE_ID = deviceDTO.KEEP_TYPE_ID;
				newAccountPOCO.KEEP_TYPE_NAME = deviceDTO.KEEP_TYPE_NAME;
				newAccountPOCO.KEEP_DESCRIPTION = deviceDTO.KEEP_DESCRIPTION;
				newAccountPOCO.ASSURANCE_YEAR = deviceDTO.ASSURANCE_YEAR;
				newAccountPOCO.BUY_PRICE = deviceDTO.BUY_PRICE;
				newAccountPOCO.EMPLOYEE_BUY_DATE = deviceDTO.EMPLOYEE_BUY_DATE;
				newAccountPOCO.LEFT_VALUE = deviceDTO.LEFT_VALUE;
				newAccountPOCO.IS_BUY = deviceDTO.IS_BUY;
				newAccountPOCO.IS_CHECK = deviceDTO.IS_CHECK;
				newAccountPOCO.ACCOUNT_DATE = deviceDTO.ACCOUNT_DATE;
				accountRepository.UpdateCommit(newAccountPOCO);
				deviceDTO = newAccountPOCO.AdaptAsDTO<IT_ACCOUNTDTO>();
				return deviceDTO;
			}
			throw new ArgumentException("UpdateAccount不存在相关的实体对象！");
		}
		throw new ValidationException(deviceDTO.GetInvalidMessages());
	}

	public void DeleteAccountByAccountID(string accountIds)
	{
		string[] idArray = accountIds.Split(",", removeEmptyEntries: true);
		if (idArray == null || !idArray.Any())
		{
			return;
		}
		idArray.ForEach(delegate(string x)
		{
			Guid id = Guid.Parse(x);
			IT_ACCOUNT iT_ACCOUNT = accountRepository.Find((IT_ACCOUNT a) => a.IT_ACCOUNT_ID == id && a.ISDEL == (decimal?)0m);
			if (iT_ACCOUNT != null)
			{
				iT_ACCOUNT.ISDEL = 1m;
				accountRepository.UpdateCommit(iT_ACCOUNT);
			}
		});
	}

	public IList<IT_MATERIALDTO> GetMaterialType(IT_MATERIALDTO queryCondition)
	{
		return SqlQuery<IT_MATERIALDTO>("GetMaterialType", queryCondition);
	}

	public bool IsNeedPurchase(string sqlIDs)
	{
		bool flag = false;
		if (sqlIDs.Length > 1)
		{
			sqlIDs = sqlIDs.Substring(0, sqlIDs.Length - 1) + ")";
		}
		sqlIDs = $" IN {sqlIDs}";
		string sqlKey = "IsNeedPurchase";
		IList<IT_MATERIALDTO> result = SqlQuery<IT_MATERIALDTO>(sqlKey, null, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[1] { sqlIDs }).List;
		foreach (IT_MATERIALDTO dto in result)
		{
			decimal? lEFT_NO = dto.LEFT_NO;
			if (lEFT_NO.GetValueOrDefault() <= 0m && lEFT_NO.HasValue)
			{
				flag = true;
			}
		}
		return flag;
	}

	public IT_MATERIALDTO AddMaterialCheckIn(IT_MATERIALDTO materialDTO)
	{
		if (materialDTO == null)
		{
			throw new ArgumentException("AddMaterialCheckIn方法参数不能为空！");
		}
		if (materialDTO.IsValid())
		{
			IT_MATERIAL materialPOCO = materialDTO.AdaptAsEntity<IT_MATERIAL>();
			foreach (IT_MATERIAL_CHECKINDTO materialCheckIn in materialDTO.IT_MATERIAL_CHECKIN)
			{
				IT_MATERIAL_CHECKIN checkIn = new IT_MATERIAL_CHECKIN();
				checkIn.IT_MATERIAL_CHECKIN_ID = Guid.NewGuid();
				checkIn.IT_MATERIAL_ID = materialCheckIn.MATERIAL_TYPE_ID;
				checkIn.CHECK_IN_NO = materialCheckIn.MATERIAL_NUMBER;
				checkIn.REMARK = materialCheckIn.REMARK;
				checkIn.ISDEL = 0m;
				materialRepository.AddCommit(checkIn);
			}
			materialDTO = materialPOCO.AdaptAsDTO<IT_MATERIALDTO>();
			return materialDTO;
		}
		throw new ValidationException(materialDTO.GetInvalidMessages());
	}

	public QueryResult<IT_STOCK_INDTO> GetStockINList(IT_STOCK_INDTO queryCondition)
	{
		return SqlQueryPager<IT_STOCK_INDTO>("GetStockInList", queryCondition);
	}

	public IT_STOCK_INDTO GetStockInByID(IT_STOCK_INDTO dto)
	{
		IT_STOCK_IN entity = stockinRepository.Find((IT_STOCK_IN a) => a.IT_STOCK_IN_ID == dto.IT_STOCK_IN_ID);
		return entity.AdaptAsDTO<IT_STOCK_INDTO>();
	}

	public IList<IT_MATERIAL_APPLY_DETAILDTO> GetMaterialApplyList(IT_MATERIAL_APPLY_DETAILDTO queryCondition)
	{
		return SqlQuery<IT_MATERIAL_APPLY_DETAILDTO>("GetMaterialApplyList", queryCondition);
	}

	public QueryResult<IT_STOCK_IN_DETAILDTO> GetStockINDetailList(IT_STOCK_IN_DETAILDTO queryCondition)
	{
		return SqlQueryPager<IT_STOCK_IN_DETAILDTO>("GetStockInDetailList", queryCondition);
	}

	public QueryResult<IT_STOCK_OUT_DETAILDTO> GetStockOutList(IT_STOCK_OUT_DETAILDTO queryCondition)
	{
		return SqlQueryPager<IT_STOCK_OUT_DETAILDTO>("GetStockOutList", queryCondition);
	}

	public IList<IT_MATERIALDTO> GetMaterialList(IT_MATERIALDTO queryCondition)
	{
		string sqlString = "SELECT K.* FROM (SELECT H.*,STOCK_QUANTITY+CHECK_IN_NO_APPLY-MATERIAL_NUMBER_APPLY AS MATERIAL_NUMBER_LEFT FROM \r\n(\r\nSELECT T1.IT_MATERIAL_ID,T1.MATERIAL_NAME,T1.STOCK_QUANTITY,T1.IS_AVAILABLE,T1.REMARK,\r\nCASE WHEN T3.MATERIAL_NUMBER_APPLY IS NULL THEN 0 ELSE T3.MATERIAL_NUMBER_APPLY END AS MATERIAL_NUMBER_APPLY,\r\nCASE WHEN T4.CHECK_IN_NO_APPLY IS NULL THEN 0 ELSE T4.CHECK_IN_NO_APPLY END AS CHECK_IN_NO_APPLY\r\nFROM IT_MATERIAL T1\r\nLEFT JOIN \r\n(\r\n   --出库（申请中）\r\n   SELECT A.MATERIAL_TYPE_ID,T2.MATERIAL_NAME,SUM(A.MATERIAL_NUMBER) AS MATERIAL_NUMBER_APPLY FROM IT_MATERIAL_APPLY_DETAIL A\r\n   LEFT JOIN IT_MATERIAL_APPLY B ON A.IT_MATERIAL_APPLY_ID=B.IT_MATERIAL_APPLY_ID\r\n   LEFT JOIN WF_INSTANCE W ON B.INSTANCE_ID=W.INSTANCE_ID\r\n   LEFT JOIN IT_MATERIAL T2 ON A.MATERIAL_TYPE_ID=T2.IT_MATERIAL_ID\r\n   WHERE B.ISDEL=0 AND W.ISDEL=0 AND W.RUN_STATE=0 AND W.Current_Activity = '信息处受理人'\r\n   GROUP BY A.MATERIAL_TYPE_ID,T2.MATERIAL_NAME\r\n   )T3 ON T1.IT_MATERIAL_ID=T3.MATERIAL_TYPE_ID\r\nLEFT JOIN \r\n(\r\n   --入库（采购中）\r\n   SELECT A.MATERIAL_ID,T2.MATERIAL_NAME,SUM(A.MATERIAL_NUMBER) AS CHECK_IN_NO_APPLY FROM IT_PURCHASING_APPLY_DETAIL A\r\n   LEFT JOIN IT_PURCHASING_APPLY B ON A.IT_PURCHASING_APPLY_ID=B.IT_PURCHASING_APPLY_ID\r\n   LEFT JOIN WF_INSTANCE W ON B.INSTANCE_ID=W.INSTANCE_ID\r\n   LEFT JOIN IT_MATERIAL T2 ON A.MATERIAL_ID=T2.IT_MATERIAL_ID\r\n   WHERE A.CHECK_IN=0 and W.ISDEL=0 AND (W.RUN_STATE=2 OR W.RUN_STATE=0) \r\n   GROUP BY A.MATERIAL_ID,T2.MATERIAL_NAME\r\n)T4 ON T1.IT_MATERIAL_ID=T4.MATERIAL_ID\r\n\r\nWHERE T1.ISDEL=0\r\n   ) H) K WHERE K.MATERIAL_NUMBER_LEFT<0";
		return SqlQueryList<IT_MATERIALDTO>(sqlString, new object());
	}

	public QueryResult<IT_MATERIALDTO> GetCurrentMaterialList(IT_MATERIALDTO queryCondition)
	{
		return SqlQueryPager<IT_MATERIALDTO>("GetCurrentMaterialList", queryCondition);
	}

	public QueryResult<IT_STOCK_IN_DETAILDTO> GetNoCheckInList(IT_STOCK_IN_DETAILDTO queryCondition)
	{
		return SqlQueryPager<IT_STOCK_IN_DETAILDTO>("GetNoCheckInList", queryCondition);
	}

	public QueryResult<IT_MATERIAL_CHECKINDTO> GetMaterialCheckInList(IT_MATERIAL_CHECKINDTO queryCondition)
	{
		return SqlQueryPager<IT_MATERIAL_CHECKINDTO>("GetMaterialCheckInList", queryCondition);
	}

	public QueryResult<IT_MATERIALDTO> QueryMaterialList(IT_MATERIALDTO queryCondition)
	{
		return SqlQueryPager<IT_MATERIALDTO>("GetMaterialList", queryCondition);
	}

	public IT_MATERIALDTO SaveMaterial(IT_MATERIALDTO materialDTO)
	{
		if (materialDTO == null)
		{
			throw new ArgumentException("materialDTO方法参数不能为空！");
		}
		if (materialDTO.IsValid())
		{
			IT_MATERIAL materialPOCO = materialDTO.AdaptAsEntity<IT_MATERIAL>();
			material_Repository.AddCommit(materialPOCO);
			materialDTO = materialPOCO.AdaptAsDTO<IT_MATERIALDTO>();
			return materialDTO;
		}
		throw new ValidationException(materialDTO.GetInvalidMessages());
	}

	public IT_MATERIALDTO UpdateMaterialList(IT_MATERIALDTO materialDTO)
	{
		if (materialDTO == null || materialDTO.IT_MATERIAL_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateMaterialList方法参数不能为空！");
		}
		if (materialDTO.IsValid())
		{
			IT_MATERIAL persisted = material_Repository.GetByKey(materialDTO.IT_MATERIAL_ID);
			if (persisted != null)
			{
				IT_MATERIAL materialPOCO = materialDTO.AdaptAsEntity<IT_MATERIAL>();
				if (persisted.IsUpdateConflict(materialPOCO))
				{
					throw new ArgumentException("数据已过期，请刷新重试！");
				}
				IT_MATERIAL newmaterialPOCO = persisted;
				newmaterialPOCO.REMARK = materialDTO.REMARK;
				newmaterialPOCO.IS_AVAILABLE = materialDTO.IS_AVAILABLE;
				newmaterialPOCO.STOCK_QUANTITY = materialDTO.STOCK_QUANTITY;
				newmaterialPOCO.MATERIAL_NAME = materialDTO.MATERIAL_NAME;
				material_Repository.UpdateCommit(newmaterialPOCO);
				materialDTO = materialPOCO.AdaptAsDTO<IT_MATERIALDTO>();
				return materialDTO;
			}
			throw new ArgumentException("UpdateMaterialList不存在相关的实体对象！");
		}
		throw new ValidationException(materialDTO.GetInvalidMessages());
	}

	public IT_STOCK_INDTO AddStockIn(IT_STOCK_INDTO stockInDTO)
	{
		if (stockInDTO == null)
		{
			throw new ArgumentException("AddStockIn方法参数不能为空！");
		}
		if (stockInDTO.IsValid())
		{
			IT_STOCK_IN stockPOCO = stockInDTO.AdaptAsEntity<IT_STOCK_IN>();
			StringBuilder materialDetail = new StringBuilder("耗材入库-");
			stockPOCO.IT_STOCK_IN_NO = DateTime.Now.ToString("yyyyMMddHHmmssffff");
			foreach (IT_STOCK_IN_DETAIL detail in stockPOCO.IT_STOCK_IN_DETAIL)
			{
				string selectsql = "SELECT * FROM IT_MATERIAL WHERE  IT_MATERIAL_ID=:IT_MATERIAL_ID";
				IT_MATERIAL material = repository.ExecuteQuery<IT_MATERIAL>(selectsql, new
				{
					IT_MATERIAL_ID = detail.MATERIAL_ID
				}).FirstOrDefault();
				detail.STOCK_QUANTITY = material.STOCK_QUANTITY;
				material.STOCK_QUANTITY += detail.MATERIAL_NUMBER;
				string updatesql = "update IT_MATERIAL set STOCK_QUANTITY= " + material.STOCK_QUANTITY + " where IT_MATERIAL_ID=:IT_MATERIAL_ID";
				repository.ExecuteCommand(updatesql, new { material.IT_MATERIAL_ID });
				DateTime lastUpdate = DateTime.Now;
				ServiceBase.log.Info($"操作时间: {lastUpdate} 耗材{material.MATERIAL_NAME}库存{material.STOCK_QUANTITY}增加{detail.MATERIAL_NUMBER}");
				string updateSQsql = "update IT_PURCHASING_APPLY_DETAIL set CHECK_IN= 1 where IT_PURCHASING_APPLY_DETAIL_ID=:IT_PURCHASING_APPLY_DETAIL_ID";
				repository.ExecuteCommand(updateSQsql, new { detail.IT_PURCHASING_APPLY_DETAIL_ID });
				lastUpdate = DateTime.Now;
				ServiceBase.log.Info($"操作时间: {lastUpdate} 耗材{material.MATERIAL_NAME}库存{material.STOCK_QUANTITY}增加{detail.MATERIAL_NUMBER}");
				materialDetail.Append(detail.MATERIAL_NAME + "(" + detail.MATERIAL_NUMBER + ")");
			}
			stockPOCO.MATERIAL_DETAIL = materialDetail.ToString();
			stockinRepository.AddCommit(stockPOCO);
			stockInDTO = stockPOCO.AdaptAsDTO<IT_STOCK_INDTO>();
			return stockInDTO;
		}
		throw new ValidationException(stockInDTO.GetInvalidMessages());
	}
}
