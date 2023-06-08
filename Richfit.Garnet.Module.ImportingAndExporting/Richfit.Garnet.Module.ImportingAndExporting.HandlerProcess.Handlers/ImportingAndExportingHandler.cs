using System;
using System.Web;
using Microsoft.JScript;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;
using Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Export;
using Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Import;

namespace Richfit.Garnet.Module.ImportingAndExporting.HandlerProcess.Handlers;

public class ImportingAndExportingHandler : HandlerBase
{
	private HttpContext context;

	public override void ProcessRequest(HttpContext context)
	{
		this.context = context;
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "ImportingAndExporting_WPSImporting":
					break;
				case "ImportingAndExporting_WPSExporting":
					WPSExporting(handlerResult);
					break;
				case "ImportingAndExporting_FillWord":
					break;
				case "ImportingAndExporting_ExcelImporting":
					ExcelImporting(handlerResult);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			handlerResult = HandleException(ex);
		}
		context.Response.Write(handlerResult.ToJson());
	}

	private void ExcelImporting(ResponseData handlerResult)
	{
		ImportDTO importDto = base.RequestData.Data.JsonDeserialize<ImportDTO>(new JsonConverter[0]);
		ImportService improt = new ImportService(importDto);
		string filePath = context.Server.MapPath("\\" + GlobalObject.unescape(importDto.FilePath));
		handlerResult.Data = improt.Import(filePath).JsonSerialize();
	}

	private void WPSExporting(ResponseData handlerResult)
	{
		ExportDTO parameter = base.RequestData.Data.JsonDeserialize<ExportDTO>(new JsonConverter[0]);
		if (string.IsNullOrEmpty(parameter.Type))
		{
			parameter.Type = "Excel";
		}
		Type type = Type.GetType($"Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Export.{parameter.Type}Service");
		if (type != null)
		{
			IExport export = (IExport)Activator.CreateInstance(type, context);
			handlerResult.Data = export.Export(parameter);
		}
	}
}
