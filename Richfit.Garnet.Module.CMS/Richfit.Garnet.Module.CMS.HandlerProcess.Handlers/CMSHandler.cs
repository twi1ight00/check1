using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.CMS.Application.DTO;
using Richfit.Garnet.Module.CMS.Application.Services;

namespace Richfit.Garnet.Module.CMS.HandlerProcess.Handlers;

public class CMSHandler : HandlerBase
{
	private ICMSService cmsService = ServiceLocator.Instance.GetService<ICMSService>();

	public override void ProcessRequest(HttpContext context)
	{
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "GetArticleByParameter":
					GetArticlePager(handlerResult);
					break;
				case "GetCategory":
					GetCategory(handlerResult);
					break;
				case "GetAuthorizationUser":
					GetAuthorizationUser(handlerResult);
					break;
				case "GetAuthorizationOrg":
					GetAuthorizationOrg(handlerResult);
					break;
				case "PublishArticle":
					PublishArticle(handlerResult);
					break;
				case "GetArticleByID":
					GetArticleByID(handlerResult);
					break;
				case "CMS_ChangeAuditStatus":
					ChangeAuditStatus(handlerResult);
					break;
				case "CMS_UpateArticle":
					UpateArticle(handlerResult);
					break;
				case "CMS_GetArticle":
					GetArticle(handlerResult);
					break;
				case "CMS_GetAllArticle":
					GetAllArticle(handlerResult);
					break;
				case "CMS_DeleteArticle":
					DeleteArticle(handlerResult);
					break;
				case "CMS_GetMyArticlePager":
					GetMyArticlePager(handlerResult);
					break;
				case "CMS_GetArticleComment":
					GetArticleComment(handlerResult);
					break;
				case "CMS_AddArticleComment":
					AddArticleComment(handlerResult);
					break;
				case "CMS_DeleteArticleComment":
					DeleteArticleComment(handlerResult);
					break;
				case "CMS_ChangeHits":
					ChangeHits(handlerResult);
					break;
				case "CMS_TOP":
					TOP(handlerResult);
					break;
				case "CMS_CANCELTOP":
					CANCELTOP(handlerResult);
					break;
				case "CMS_PUBLISH_ALL":
					ALL(handlerResult);
					break;
				case "CMS_GetAllArticle_Advance":
					GetAllArticleAdvance(handlerResult);
					break;
				case "CMS_GetMyArticle_Advance":
					GetMyArticleAdvance(handlerResult);
					break;
				case "CMS_GetViewArticle_Advance":
					GetViewArticleAdvance(handlerResult);
					break;
				case "CMS_GetArticle_Portal":
					GetArticle_Portal(handlerResult);
					break;
				case "CMS_STATISTICS":
					GetStatistics(handlerResult);
					break;
				case "CMS_GetArticleForMobileByID":
					GetArticleForMobileByID(handlerResult);
					break;
				case "CMS_GetArticleForMobileIndexByUserIdAndCategoryId":
					GetArticleForMobileIndexByUserIdAndCategoryId(handlerResult);
					break;
				case "CMS_GetCategoryForMobileIndexByUserId":
					GetCategoryForMobileIndexByUserId(handlerResult);
					break;
				case "CMS_GetCountForMobileByUserId":
					GetCountForMobileByUserId(handlerResult);
					break;
				case "CMS_GetArticleCommentPager":
					GetArticleCommentPager(handlerResult);
					break;
				case "CMS_GetRegulationsInfo":
					GetRegulationsInfo(handlerResult);
					break;
				case "CMS_GetRegulationsInfo_Ad":
					GetRegulationsInfo_Ad(handlerResult);
					break;
				case "CMS_GetMyArticle_Export":
					GetMyArticle_Export(handlerResult);
					break;
				case "CMS_GetImageArticle":
					GetImageArticle(handlerResult);
					break;
				case "CMS_GetAllArticleByType":
					GetAllArticleByType(handlerResult);
					break;
				case "CMS_GetArticleCount":
					GetArticleCount(handlerResult);
					break;
				case "CMS_GetArticleMore":
					GetArticleMore(handlerResult);
					break;
				case "CMS_CODE":
					CODE(handlerResult);
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

	private void CODE(ResponseData handlerResult)
	{
		handlerResult.Data = cmsService.CODE().JsonSerialize();
	}

	private void GetArticleMore(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetArticleMore(parameter).JsonSerialize();
	}

	private void GetArticleCount(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = "{\"COUNT\":\"" + cmsService.GetArticleCount(parameter) + "\"}";
	}

	private void GetAllArticleByType(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetAllArticleByType(parameter).JsonSerialize();
	}

	private void GetImageArticle(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetImageArticle(parameter).JsonSerialize();
	}

	private void GetMyArticle_Export(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO condition = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetMyArticle_Export(condition).JsonSerialize();
	}

	private void GetRegulationsInfo(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetRegulationsInfo(parameter).JsonSerialize();
	}

	private void GetRegulationsInfo_Ad(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetRegulationsInfo_Ad(parameter).JsonSerialize();
	}

	private void GetCountForMobileByUserId(ResponseData handlerResult)
	{
		handlerResult.Data = cmsService.GetCountForMobileByUserId().JsonSerialize();
	}

	private void GetArticleForMobileIndexByUserIdAndCategoryId(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetArticleForMobileIndexByUserIdAndCategoryId(parameter).JsonSerialize();
	}

	private void GetCategoryForMobileIndexByUserId(ResponseData handlerResult)
	{
		handlerResult.Data = cmsService.GetCategoryForMobileIndexByUserId();
	}

	private void GetArticleForMobileByID(ResponseData handlerResult)
	{
		CMS_ARTICLE_DATADTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLE_DATADTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetArticleForMobileByID(parameter.ID).JsonSerialize();
	}

	private void GetStatistics(ResponseData handlerResult)
	{
		handlerResult.Data = cmsService.GetStatistics().JsonSerialize();
	}

	private void GetAllArticleAdvance(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetAllArticleAdvance(parameter).JsonSerialize();
	}

	private void GetMyArticleAdvance(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetMyArticleAdvance(parameter).JsonSerialize();
	}

	private void GetViewArticleAdvance(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetViewArticleAdvance(parameter).JsonSerialize();
	}

	private void GetArticle_Portal(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetArticle_Portal(parameter).JsonSerialize();
	}

	private void ALL(ResponseData handlerResult)
	{
		Dictionary<string, Guid?> parameter = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid?>>(new JsonConverter[0]);
		if (!parameter["ID"].HasValue)
		{
			cmsService.Generate(null);
		}
		else
		{
			cmsService.Generate(parameter["ID"]);
		}
	}

	private void CANCELTOP(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		cmsService.CancelTop(parameter);
	}

	private void TOP(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		cmsService.TOP(parameter);
	}

	private void ChangeHits(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.ChangeHits(parameter).ToString();
	}

	private void DeleteArticleComment(ResponseData handlerResult)
	{
		CMS_COMMENTDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_COMMENTDTO>(new JsonConverter[0]);
		cmsService.DeleteArticleComment(parameter);
	}

	private void AddArticleComment(ResponseData handlerResult)
	{
		CMS_COMMENTDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_COMMENTDTO>(new JsonConverter[0]);
		cmsService.AddArticleComment(parameter);
	}

	private void GetArticleComment(ResponseData handlerResult)
	{
		CMS_COMMENTDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_COMMENTDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetArticleComment(parameter).JsonSerialize();
	}

	private void GetArticleCommentPager(ResponseData handlerResult)
	{
		CMS_COMMENTDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_COMMENTDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetArticleCommentPager(parameter).JsonSerialize();
	}

	private void GetMyArticlePager(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetMyArticlePager(parameter).JsonSerialize();
	}

	private void DeleteArticle(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		cmsService.DeleteArticle(parameter);
	}

	private void GetAllArticle(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetAllArticlePager(parameter).JsonSerialize();
	}

	private void GetArticle(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetViewArticle(parameter).JsonSerialize();
	}

	private void UpateArticle(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.UpateArticle(parameter).JsonSerialize();
	}

	private void ChangeAuditStatus(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		cmsService.ChangeAuditStatus(parameter);
	}

	private void GetArticleByID(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetArticleByID(parameter.ID).JsonSerialize();
	}

	private void PublishArticle(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.AddArticle(parameter).JsonSerialize();
	}

	private void GetAuthorizationOrg(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetAuthorizationOrg(parameter).JsonSerialize();
	}

	private void GetAuthorizationUser(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetAuthorizationUser(parameter).JsonSerialize();
	}

	private void GetCategory(ResponseData handlerResult)
	{
		CMS_CATEGORYDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_CATEGORYDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetCategory(parameter).JsonSerialize();
	}

	private void GetArticlePager(ResponseData handlerResult)
	{
		CMS_ARTICLEDTO parameter = base.RequestData.Data.JsonDeserialize<CMS_ARTICLEDTO>(new JsonConverter[0]);
		handlerResult.Data = cmsService.GetViewArticle(parameter).JsonSerialize();
	}
}
