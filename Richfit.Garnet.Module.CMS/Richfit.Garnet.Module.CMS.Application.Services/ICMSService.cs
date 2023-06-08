using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.CMS.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.Services;

public interface ICMSService
{
	QueryResult<CMS_ARTICLEDTO> GetRegulationsInfo(CMS_ARTICLEDTO dto);

	QueryResult<CMS_ARTICLEDTO> GetRegulationsInfo_Ad(CMS_ARTICLEDTO dto);

	QueryResult<CMS_ARTICLEDTO> GetViewArticle(CMS_ARTICLEDTO dto);

	QueryResult<CMS_ARTICLEDTO> GetViewArticleAdvance(CMS_ARTICLEDTO parameter);

	QueryResult<CMS_ARTICLEDTO> GetArticle_Portal(CMS_ARTICLEDTO parameter);

	IList<CMS_ARTICLEDTO> GetImageArticle(CMS_ARTICLEDTO parameter);

	IList<CMS_ARTICLEDTO> GetAllArticleByType(CMS_ARTICLEDTO parameter);

	int GetArticleCount(CMS_ARTICLEDTO parameter);

	IList<CMS_ARTICLEDTO> GetArticleMore(CMS_ARTICLEDTO parameter);

	QueryResult<CMS_ARTICLEDTO> GetMyArticlePager(CMS_ARTICLEDTO dto);

	QueryResult<CMS_ARTICLEDTO> GetMyArticleAdvance(CMS_ARTICLEDTO parameter);

	QueryResult<CMS_ARTICLEDTO> GetAllArticlePager(CMS_ARTICLEDTO dto);

	QueryResult<CMS_ARTICLEDTO> GetAllArticleAdvance(CMS_ARTICLEDTO parameter);

	IEnumerable<CMS_ARTICLEDTO> GetStatistics();

	IEnumerable<CMS_CATEGORYDTO> GetCategory(CMS_CATEGORYDTO dto);

	IList<TREE_NODE> GetAuthorizationOrg(CMS_ARTICLEDTO dto);

	IList<TREE_NODE> GetAuthorizationUser(CMS_ARTICLEDTO dto);

	Guid AddArticle(CMS_ARTICLEDTO dto);

	Guid UpateArticle(CMS_ARTICLEDTO dto);

	CMS_ARTICLEDTO GetArticleByID(Guid guid);

	void ChangeAuditStatus(CMS_ARTICLEDTO dto);

	void DeleteArticle(CMS_ARTICLEDTO dto);

	IList<CMS_COMMENTDTO> GetArticleComment(CMS_COMMENTDTO parameter);

	QueryResult<CMS_COMMENTDTO> GetArticleCommentPager(CMS_COMMENTDTO dto);

	void AddArticleComment(CMS_COMMENTDTO parameter);

	void DeleteArticleComment(CMS_COMMENTDTO parameter);

	decimal ChangeHits(CMS_ARTICLEDTO parameter);

	void TOP(CMS_ARTICLEDTO parameter);

	void CancelTop(CMS_ARTICLEDTO parameter);

	void Generate(Guid? id);

	CMS_ARTICLE_DATADTO GetArticleForMobileByID(Guid guid);

	string GetCategoryForMobileIndexByUserId();

	IList<COUNTDTO> GetCountForMobileByUserId();

	QueryResult<CMS_ARTICLEMDTO> GetArticleForMobileIndexByUserIdAndCategoryId(CMS_ARTICLEDTO parameter);

	IList<CMS_ARTICLEDTO> GetMyArticle_Export(CMS_ARTICLEDTO queryCondition);

	object CODE();
}
