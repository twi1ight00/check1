using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.CodeTableManagement.Application.DTO;
using Richfit.Garnet.Module.CodeTableManagement.Application.Services;

namespace Richfit.Garnet.Module.CodeTableManagement.HandlerProcess.Handlers;

/// <summary>
/// 码表请求处理类
/// </summary>
public class CodeTableHandler : HandlerBase
{
	/// <summary>
	/// 码表接口实例化
	/// </summary>
	private ICodeTableAppService codeTableAppService = ServiceLocator.Instance.GetService<ICodeTableAppService>();

	/// <summary>
	/// ProcessRequest
	/// </summary>
	/// <param name="context">context</param>
	public override void ProcessRequest(HttpContext context)
	{
		string action = base.RequestData.ActionCode;
		ResponseData responseData = new ResponseData();
		try
		{
			responseData.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "CodeTable_GetCodeTableList":
					GetCodeTableList(responseData);
					break;
				case "CodeTable_AddCodeTable":
					AddCodeTable(responseData);
					break;
				case "CodeTable_UpdateCodeTable":
					UpdateCodeTable(responseData);
					break;
				case "CodeTable_RemoveCodeTable":
					RemoveCodeTable(responseData);
					break;
				case "CodeTable_EnableCodeTable":
					EnableCodeTable(responseData);
					break;
				case "CodeTable_DisableCodeTable":
					DisableCodeTable(responseData);
					break;
				case "System_GetCodeTable":
					GetCodeTable(responseData);
					break;
				case "System_GetCodeMessByCodeID":
					GetCodeTableByCodeTableID(responseData);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			responseData = HandleException(ex);
		}
		context.Response.Write(responseData.ToJson());
	}

	/// <summary>
	/// 新增码表信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void AddCodeTable(ResponseData handlerResult)
	{
		CodeTableAdapterDTO codeTableAdapterDTO = DTOBase.DeserializeFromJson<CodeTableAdapterDTO>(base.RequestData.Data);
		CodeTableDTO codeTableDTO = codeTableAppService.AddCodeTable(codeTableAdapterDTO);
		if (codeTableDTO != null)
		{
			handlerResult.Data = codeTableDTO.ToJson();
		}
	}

	/// <summary>
	/// 更新码表信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void UpdateCodeTable(ResponseData handlerResult)
	{
		CodeTableAdapterDTO codeTableAdapterDTO = DTOBase.DeserializeFromJson<CodeTableAdapterDTO>(base.RequestData.Data);
		codeTableAppService.UpdateCodeTable(codeTableAdapterDTO);
	}

	/// <summary>
	/// 批量逻辑删除码表信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void RemoveCodeTable(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string codeTableId = dictionary["CODE_TABLE_ID"];
		codeTableAppService.RemoveCodeTable(codeTableId);
	}

	/// <summary>
	/// 启用码表信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void EnableCodeTable(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string codeTableId = dictionary["CODE_TABLE_ID"];
		codeTableAppService.EnableCodeTable(codeTableId);
	}

	/// <summary>
	/// 禁用码表信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void DisableCodeTable(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string codeTableId = dictionary["CODE_TABLE_ID"];
		codeTableAppService.DisableCodeTable(codeTableId);
	}

	/// <summary>
	/// 查询码表信息_通过SqlKey
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void GetCodeTableList(ResponseData handlerResult)
	{
		handlerResult.Data = codeTableAppService.QueryCodeTableList().ToJson();
	}

	private void GetCodeTable(ResponseData responseData)
	{
		string codeTableCode = base.RequestData.Data;
		if (!string.IsNullOrEmpty(codeTableCode))
		{
			IList<CodeTableDTO> codeTableList = CodeTableCacheManager.GetBindingData(codeTableCode);
			responseData.Data = codeTableList.ToJson();
		}
	}

	private void GetCodeTableByCodeTableID(ResponseData responseData)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string CodeTableId = dictionary["CodeTable_ID"];
		IList<CodeTableNameDTO> codeTableList = codeTableAppService.GetCodeTableName(CodeTableId);
		responseData.Data = codeTableList.ToJson();
	}
}
