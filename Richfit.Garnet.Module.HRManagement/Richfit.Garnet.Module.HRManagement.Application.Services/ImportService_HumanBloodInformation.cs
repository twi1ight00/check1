using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.HRManagement.Application.DTO;
using Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;
using Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Import;

namespace Richfit.Garnet.Module.HRManagement.Application.Services;

public class ImportService_HumanBloodInformation : IImportService
{
	private IHRManagementService HRManagementService = ServiceLocator.Instance.GetService<IHRManagementService>();

	public Type GetDTOTpe()
	{
		return typeof(S_TEMP_STO_HRMANAGEMENTDTO);
	}

	public object Validate(DataRow dr, string colName, string value, ref ValidateInfo validate)
	{
		switch (colName)
		{
		case "PERSON_ID":
			if (value == null || value == "")
			{
				validate.Result = false;
				validate.Message = "人员编号不允许为空";
				return value;
			}
			return value;
		case "WORKING_START_DATE":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "PRACTICE_DATE":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "BIRTHDAY":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "PARTY_TIME":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "CONTRACT_EXPIRY_DATE":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "CONTRACT_VALIDITY_DATE":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "JOIN_RUI_TUO":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "QUALIFY_TIME":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "GRADUAION_TIME":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		case "WORK_TIME":
			try
			{
				if (value != null && value != "")
				{
					Convert.ToDateTime(value);
					return value;
				}
				return value;
			}
			catch (Exception)
			{
				validate.Result = false;
				validate.Message = "无法转换为日期";
				return value;
			}
		default:
			throw new NotImplementedException();
		}
	}

	public ImportResult Save(IList result, ref ImportResult importResult)
	{
		IList<S_TEMP_STO_HRMANAGEMENTDTO> detailList = (IList<S_TEMP_STO_HRMANAGEMENTDTO>)result;
		importResult.List = HRManagementService.InsertDataFromImport(detailList).ToList();
		return importResult;
	}
}
