using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Localizing.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.Services;

namespace Richfit.Garnet.Module.Localizing.HandlerProcess.Handlers;

/// <summary>
/// 系统多语翻译
/// </summary>
public class LocalizingHandler : HandlerBase
{
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
				case "SystemLogin_GetLoginLocalizing":
					GetLoginLocalizing(responseData);
					break;
				case "SystemLogin_GetLoginTimeZone":
					GetTimeZone(responseData);
					break;
				case "System_GetAllLocalizing":
					GetUILocalizing(responseData);
					break;
				case "System_GetAvailableLanguage":
					GetAvailableLanguage(responseData);
					break;
				case "System_GetSystemDataType":
					GetSystemDataType(responseData);
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
	/// 获取所有前端UI的多语信息
	/// </summary>
	/// <param name="responseData"></param>
	/// <returns></returns>
	private void GetUILocalizing(ResponseData responseData)
	{
		IList<SYS_LOCALIZINGDTO> localizingDTOList = LocalizingCacheManager.GetUserUILocalizing();
		responseData.Data = localizingDTOList.JsonSerialize();
	}

	/// <summary>
	/// 获得可用的语言列表
	/// </summary>
	/// <param name="responseData"></param>
	private void GetAvailableLanguage(ResponseData responseData)
	{
		bool enableMultiLanguage = ConfigurationManager.System.Settings.EnableMultiLanguage;
		IList<SYS_LANGUAGEDTO> languageDTOList = new List<SYS_LANGUAGEDTO>();
		languageDTOList = ((!enableMultiLanguage) ? (from x in LocalizingCacheManager.GetAllLanguage()
			where x.CULTURE.Equals(ConfigurationManager.System.Settings.DefaultCulture.ToString())
			orderby x.SORT
			select x).ToList() : (from x in LocalizingCacheManager.GetAllLanguage()
			orderby x.SORT
			select x).ToList());
		responseData.Data = languageDTOList.JsonSerialize();
	}

	private void GetSystemDataType(ResponseData responseData)
	{
		string systemDataType = base.RequestData.Data;
		if (!string.IsNullOrEmpty(systemDataType))
		{
			IList<SYS_LOCALIZINGDTO> localizingList = LocalizingCacheManager.GetSystemData(systemDataType);
			responseData.Data = localizingList.ToJson();
		}
	}

	/// <summary>
	/// 获取登录页面所有语言的多语信息
	/// </summary>
	/// <returns></returns>
	private void GetLoginLocalizing(ResponseData responseData)
	{
		string culture = base.RequestData.Data;
		List<SYS_LOCALIZINGDTO> localizingDTOList = new List<SYS_LOCALIZINGDTO>();
		localizingDTOList.AddRange(LocalizingCacheManager.GetLocalizing("SystemManagement", "Login", culture));
		responseData.Data = localizingDTOList.JsonSerialize();
	}

	/// <summary>
	/// 获得某语言类型的时区信息
	/// </summary>
	/// <param name="responseData"></param>
	private void GetTimeZone(ResponseData responseData)
	{
		string culture = base.RequestData.Data;
		IList<SYS_LOCALIZINGDTO> languageDTOList = LocalizingCacheManager.GetSystemData("ZoneType", culture);
		responseData.Data = languageDTOList.JsonSerialize();
	}
}
