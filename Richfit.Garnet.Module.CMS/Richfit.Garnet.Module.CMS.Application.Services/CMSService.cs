using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.JScript;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.CMS.Application.DTO;
using Richfit.Garnet.Module.CMS.Domain.Models;
using Richfit.Garnet.Module.MessageCenter.Application.Services;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

namespace Richfit.Garnet.Module.CMS.Application.Services;

public class CMSService : ServiceBase, ICMSService
{
	private readonly IRepository<CMS_ARTICLE_DATA> articledataRepository;

	private readonly IRepository<CMS_ARTICLE> repository;

	private readonly IRepository<CMS_CATEGORY> categoryRepository;

	private readonly IRepository<CMS_COMMENT> commentRepository;

	private readonly IRepository<CMS_GUESTBOOK> guestbookRepository;

	private readonly IRepository<CMS_VIEW_AUDIT> viewauditRepository;

	private readonly IRepository<CMS_SCANNED> scannedRepository;

	public CMSService()
	{
		articledataRepository = ServiceLocator.Instance.GetService<IRepository<CMS_ARTICLE_DATA>>();
		repository = ServiceLocator.Instance.GetService<IRepository<CMS_ARTICLE>>();
		categoryRepository = ServiceLocator.Instance.GetService<IRepository<CMS_CATEGORY>>();
		commentRepository = ServiceLocator.Instance.GetService<IRepository<CMS_COMMENT>>();
		guestbookRepository = ServiceLocator.Instance.GetService<IRepository<CMS_GUESTBOOK>>();
		viewauditRepository = ServiceLocator.Instance.GetService<IRepository<CMS_VIEW_AUDIT>>();
		scannedRepository = ServiceLocator.Instance.GetService<IRepository<CMS_SCANNED>>();
	}

	public QueryResult<CMS_ARTICLEDTO> GetViewArticle(CMS_ARTICLEDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<CMS_ARTICLEDTO>("GetViewArticle", dto);
	}

	public QueryResult<CMS_ARTICLEDTO> GetViewArticleAdvance(CMS_ARTICLEDTO dto)
	{
		if (dto.USER_ID == Guid.Empty || !dto.USER_ID.HasValue)
		{
			dto.USER_ID = SessionContext.UserInfo.UserID;
		}
		return SqlQueryPager<CMS_ARTICLEDTO>("GetViewArticle_Advance", dto);
	}

	public QueryResult<CMS_ARTICLEDTO> GetArticle_Portal(CMS_ARTICLEDTO dto)
	{
		return SqlQueryPager<CMS_ARTICLEDTO>("GetArticle_Portal", dto);
	}

	public QueryResult<CMS_ARTICLEDTO> GetRegulationsInfo(CMS_ARTICLEDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<CMS_ARTICLEDTO>("GetRegulationsInfo", dto);
	}

	public QueryResult<CMS_ARTICLEDTO> GetRegulationsInfo_Ad(CMS_ARTICLEDTO dto)
	{
		if (dto.USER_ID == Guid.Empty || !dto.USER_ID.HasValue)
		{
			dto.USER_ID = SessionContext.UserInfo.UserID;
		}
		return SqlQueryPager<CMS_ARTICLEDTO>("GetRegulationsInfo_Ad", dto);
	}

	public QueryResult<CMS_ARTICLEDTO> GetMyArticlePager(CMS_ARTICLEDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<CMS_ARTICLEDTO>("GetALLArticle", dto);
	}

	public QueryResult<CMS_ARTICLEDTO> GetMyArticleAdvance(CMS_ARTICLEDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<CMS_ARTICLEDTO>("GetALLArticle_Advance", dto);
	}

	public QueryResult<CMS_ARTICLEDTO> GetAllArticlePager(CMS_ARTICLEDTO dto)
	{
		return SqlQueryPager<CMS_ARTICLEDTO>("GetALLArticle", dto);
	}

	public QueryResult<CMS_ARTICLEDTO> GetAllArticleAdvance(CMS_ARTICLEDTO dto)
	{
		return SqlQueryPager<CMS_ARTICLEDTO>("GetALLArticle_Advance", dto);
	}

	public IEnumerable<CMS_ARTICLEDTO> GetStatistics()
	{
		return SqlQuery<CMS_ARTICLEDTO>("GetStatistics", new { });
	}

	public IEnumerable<CMS_CATEGORYDTO> GetCategory(CMS_CATEGORYDTO dto)
	{
		return SqlQuery<CMS_CATEGORYDTO>("GetCategory", dto);
	}

	public Guid AddArticle(CMS_ARTICLEDTO dto)
	{
		dto.ID = Guid.NewGuid();
		dto.USER_ID = ((!dto.USER_ID.HasValue) ? SessionContext.UserInfo.UserID : new Guid("A0C53383-52E3-C154-32E2-08D2BFF301B7"));
		decimal? iS_BIRTHDAY = dto.IS_BIRTHDAY;
		if (iS_BIRTHDAY.GetValueOrDefault() == 1m && iS_BIRTHDAY.HasValue)
		{
			Random ran = new Random();
			int randKey = ran.Next(1, 100);
			if (randKey % 2 == 0)
			{
				WriteFileOne(dto.BIRTHDAY_USER);
			}
			else
			{
				WriteFileTwo(dto.BIRTHDAY_USER);
			}
		}
		dto.USER_NAME = (string.IsNullOrEmpty(dto.USER_NAME) ? SessionContext.UserInfo.UserName : dto.USER_NAME);
		dto.ORG_ID = ((!dto.ORG_ID.HasValue) ? new Guid?(SessionContext.UserInfo.BelongToOrgID) : dto.ORG_ID);
		dto.ORG_NAME = OrgUserCacheManager.GetOrgByKey(dto.ORG_ID.Value).ORG_NAME;
		dto.HITS = 0m;
		iS_BIRTHDAY = dto.AUDIT_STATUS;
		if (iS_BIRTHDAY.GetValueOrDefault() == 1m && iS_BIRTHDAY.HasValue)
		{
			IList<CMS_ARTICLE> articleweight = repository.FindAll((CMS_ARTICLE a) => a.WEIGHT == (decimal?)2m);
			if (articleweight == null || articleweight.Count() == 0)
			{
				dto.WEIGHT_SORT = 1m;
			}
			else
			{
				articleweight[0].WEIGHT = 1m;
				dto.WEIGHT_SORT = articleweight[0].WEIGHT_SORT + 1m;
			}
			dto.WEIGHT = 2m;
		}
		else
		{
			dto.WEIGHT = 0m;
			dto.WEIGHT_SORT = 0m;
		}
		if (string.IsNullOrEmpty(dto.KEYWORDS))
		{
			dto.KEYWORDS = dto.TITLE;
		}
		dto.CREATOR = SessionContext.UserInfo.UserID;
		dto.MODIFIER = SessionContext.UserInfo.UserID;
		CMS_ARTICLE article = dto.AdaptAsEntity<CMS_ARTICLE>();
		repository.AddCommit(article);
		ChangeAuditStatus(dto);
		return dto.ID;
	}

	public Guid UpateArticle(CMS_ARTICLEDTO dto)
	{
		CMS_ARTICLE poco = dto.AdaptAsEntity<CMS_ARTICLE>();
		dto.USER_ID = SessionContext.UserInfo.UserID;
		dto.USER_NAME = SessionContext.UserInfo.UserName;
		dto.ORG_ID = SessionContext.UserInfo.BelongToOrgID;
		dto.ORG_NAME = OrgUserCacheManager.GetOrgByKey(SessionContext.UserInfo.BelongToOrgID).ORG_NAME;
		CMS_ARTICLE article = repository.GetByKey(dto.ID);
		article.TITLE = dto.TITLE;
		article.NOTICE_TYPE = dto.NOTICE_TYPE;
		article.ENDDATE = dto.ENDDATE;
		List<Guid> list = new List<Guid>();
		list.Add(new Guid("ec5da105-a299-8949-a84c-4d22cf2a15eb"));
		list.Add(new Guid("05c7398b-fb51-884f-87c1-634f90e88d34"));
		list.Add(new Guid("fbef574c-1df8-7b43-ad0f-5f2879268818"));
		list.Add(new Guid("90948fa2-e260-bc4a-8195-7fad3781b9fc"));
		list.Add(new Guid("a9c225e2-ee53-5e46-af64-fa1f25a3ab59"));
		list.Add(new Guid("41b72fba-028d-ed45-94ad-bb25b403cced"));
		List<Guid> lsGuid = list;
		if (lsGuid.Contains(dto.PARENT_ID))
		{
			article.ORG_ID = dto.CMS_VIEW_AUDIT[0].VIEW_ID;
			article.ORG_NAME = dto.CMS_VIEW_AUDIT[0].VIEW_NAME;
		}
		else
		{
			article.ORG_ID = dto.ORG_ID;
			article.ORG_NAME = dto.ORG_NAME;
		}
		if (string.IsNullOrEmpty(dto.KEYWORDS))
		{
			article.KEYWORDS = dto.TITLE;
		}
		else
		{
			article.KEYWORDS = dto.KEYWORDS;
		}
		decimal? aUDIT_STATUS = dto.AUDIT_STATUS;
		if (aUDIT_STATUS.GetValueOrDefault() == 1m && aUDIT_STATUS.HasValue)
		{
			IList<CMS_ARTICLE> articleweight = repository.FindAll((CMS_ARTICLE a) => a.WEIGHT == (decimal?)2m);
			if (articleweight == null || articleweight.Count() == 0)
			{
				article.WEIGHT_SORT = 1m;
			}
			else
			{
				articleweight[0].WEIGHT = 1m;
				dto.WEIGHT_SORT = articleweight[0].WEIGHT_SORT + 1m;
			}
			article.WEIGHT = 2m;
		}
		else
		{
			article.WEIGHT = 0m;
			article.WEIGHT_SORT = 0m;
		}
		article.IS_COMMENT = dto.IS_COMMENT;
		article.CATEGORY_ID = dto.CATEGORY_ID;
		article.AUDIT_STATUS = dto.AUDIT_STATUS;
		article.IS_IMAGE = dto.IS_IMAGE;
		article.IS_MAINPAGE = dto.IS_MAINPAGE;
		article.IS_TOP = dto.IS_TOP;
		article.IS_ENDDATE = dto.IS_ENDDATE;
		article.ENDDATE = dto.ENDDATE;
		article.IS_SHORT_MESSAGE = dto.IS_SHORT_MESSAGE;
		article.CMS_ARTICLE_DATA.CONTENT = dto.CMS_ARTICLE_DATA.CONTENT;
		repository.RemoveChild(article.CMS_VIEW_AUDIT);
		repository.AddChild((IEnumerable<CMS_VIEW_AUDIT>)poco.CMS_VIEW_AUDIT);
		repository.RemoveChild(article.CMS_AUDIT);
		foreach (CMS_AUDIT audit in poco.CMS_AUDIT)
		{
			audit.ARTICLE_ID = dto.ID;
			audit.AUDIT_ID = Guid.NewGuid();
		}
		repository.AddChild((IEnumerable<CMS_AUDIT>)poco.CMS_AUDIT);
		repository.Update(article, "CMS_ARTICLE", "CMS_ARTICLE_DATA", "CMS_AUDIT");
		repository.DbContext.Commit();
		ChangeAuditStatus(dto);
		return dto.ID;
	}

	public void Generate(Guid? id)
	{
		IList<CMS_ARTICLEDTO> articles = SqlQuery<CMS_ARTICLEDTO>("GetArticleByID", new CMS_ARTICLEDTO());
		if (id.HasValue)
		{
			articles = articles.Where(delegate(CMS_ARTICLEDTO a)
			{
				Guid iD = a.ID;
				Guid? guid = id;
				return iD == guid;
			}).ToList();
		}
		foreach (CMS_ARTICLEDTO article in articles)
		{
			if (article.CATEGORY_ID == Guid.Parse("7cfa5bb1-5c79-b74a-94d3-1d3028fc4af2"))
			{
				CMS_ARTICLE newArticle = repository.GetByKey(article.ID);
				string PUB_USER_INFO = "";
				List<CMS_AUDIT> lsAu = newArticle.CMS_AUDIT.ToList();
				for (int i = 0; i < lsAu.Count; i++)
				{
					string text = PUB_USER_INFO;
					PUB_USER_INFO = text + lsAu[i].ORG_NAME + "     " + lsAu[i].USER_NAME + "<br/>";
				}
				publish(article.ID.ToString(), article.TITLE, article.HITS.ToString(), article.USER_NAME, article.ORG_NAME, article.AUDIT_DATE.Value, GlobalObject.unescape(article.CONTENT), article.IS_COMMENT, article.CATEGORY_ID, article.P_NAME, PUB_USER_INFO);
			}
			else
			{
				publish(article.ID.ToString(), article.TITLE, article.HITS.ToString(), article.USER_NAME, article.ORG_NAME, article.AUDIT_DATE.Value, GlobalObject.unescape(article.CONTENT), article.IS_COMMENT, article.CATEGORY_ID, article.P_NAME);
			}
		}
	}

	private void publish(string template, string path, string id, string title, string hits, string username, string orgName, DateTime time, string content, decimal? isComment, Guid catId, string categoryName, string pubUserInfo = "")
	{
		string htmlname = id + ".html";
		Dictionary<string, string> dic = new Dictionary<string, string>();
		Html h = new Html();
		string message = string.Empty;
		dic.Add("ARTICLE_ID", id);
		dic.Add("TITLE", title);
		dic.Add("HITS", hits);
		dic.Add("ORG_NAME", orgName);
		dic.Add("CATEGORY_NAME", categoryName);
		dic.Add("USER_NAME", username);
		dic.Add("AUDIT_DATE", time.ToString("yyyy-MM-dd HH:mm"));
		dic.Add("CONTENT", content);
		dic.Add("IS_COMMENT", isComment.ToString());
		dic.Add("PUB_USER_INFO", pubUserInfo);
		if (!h.Create(template, path, htmlname, dic, ref message))
		{
		}
		if (catId == new Guid("CDF1485A-4A6F-C417-571D-08CF62CB0EB1"))
		{
			htmlname = time.ToString("yyyyMMdd") + ".html";
			if (h.Create(template, path, htmlname, dic, ref message))
			{
			}
		}
	}

	private void publish(string id, string title, string hits, string username, string orgName, DateTime time, string content, decimal? isComment, Guid catId, string categoryName, string pubUserInfo = "")
	{
		publish("/cms/tmp.html", "/cms/", id, title, hits, username, orgName, time, content, isComment, catId, categoryName, pubUserInfo);
		publish("/cms/tmp.mobile.html", "/cms/mobile/", id, title, hits, username, orgName, time, content, isComment, catId, categoryName, pubUserInfo);
	}

	public void ChangeAuditStatus(CMS_ARTICLEDTO dto)
	{
		CMS_ARTICLE article = repository.GetByKey(dto.ID);
		string PUB_USER_INFO = "";
		List<CMS_AUDIT> lsAu = article.CMS_AUDIT.ToList();
		for (int i = 0; i < lsAu.Count; i++)
		{
			string text = PUB_USER_INFO;
			PUB_USER_INFO = text + lsAu[i].ORG_NAME + "     " + lsAu[i].USER_NAME + "<br/>";
		}
		article.USER_ID = SessionContext.UserInfo.UserID;
		article.USER_NAME = SessionContext.UserInfo.UserName;
		article.AUDIT_STATUS = dto.AUDIT_STATUS;
		if (!article.AUDIT_DATE.HasValue)
		{
			article.AUDIT_DATE = DateTime.Now;
		}
		IList<CMS_ARTICLEDTO> list = SqlQuery<CMS_ARTICLEDTO>("GetArticleCategoryByID", dto);
		if (list.Count == 0)
		{
			return;
		}
		CMS_ARTICLEDTO articledto = list[0];
		publish(article.ID.ToString(), article.TITLE, article.HITS.ToString(), article.USER_NAME, article.ORG_NAME, article.AUDIT_DATE.Value, GlobalObject.unescape(article.CMS_ARTICLE_DATA.CONTENT), article.IS_COMMENT, article.CATEGORY_ID, articledto.P_NAME, PUB_USER_INFO);
		decimal? iS_SHORT_MESSAGE = article.IS_SHORT_MESSAGE;
		if (iS_SHORT_MESSAGE.GetValueOrDefault() == 1m && iS_SHORT_MESSAGE.HasValue)
		{
			iS_SHORT_MESSAGE = article.AUDIT_STATUS;
			if (iS_SHORT_MESSAGE.GetValueOrDefault() == 1m && iS_SHORT_MESSAGE.HasValue)
			{
				try
				{
					string strSetID = ((article.CATEGORY_ID == Guid.Parse("C306B0DA-7E14-D148-A270-B1A195CCAF7C")) ? "PubNoNoticeAppID" : ((article.CATEGORY_ID == Guid.Parse("7CFA5BB1-5C79-B74A-94D3-1D3028FC4AF2")) ? "PubNoDynamicAppID" : ""));
					string strSetKey = ((article.CATEGORY_ID == Guid.Parse("C306B0DA-7E14-D148-A270-B1A195CCAF7C")) ? "PubNoNoticeAppKey" : ((article.CATEGORY_ID == Guid.Parse("7CFA5BB1-5C79-B74A-94D3-1D3028FC4AF2")) ? "PubNoDynamicAppKey" : ""));
					if (strSetID != "" && strSetKey != "")
					{
						string pubNoID = ConfigurationManager.System.Settings.GetSetting<string>(strSetID);
						string pubNoKey = ConfigurationManager.System.Settings.GetSetting<string>(strSetKey);
						string url = ConfigurationManager.System.Settings.GetSetting<string>("SerUrl");
						iS_SHORT_MESSAGE = article.IS_PUBLISH;
						if (iS_SHORT_MESSAGE.GetValueOrDefault() == 0m && iS_SHORT_MESSAGE.HasValue)
						{
							ServiceBase.log.Debug("发送瑞信推送");
							new SendMeassageToRuiXin().SendPubNoToRuiXin(article.TITLE, string.Concat(url, "/cms/mobile/", article.ID, ".html"), pubNoID, pubNoKey);
						}
						else
						{
							ServiceBase.log.Debug("未发送瑞信推送");
						}
					}
					article.IS_PUBLISH = 1m;
					repository.UpdateCommit(article);
					return;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
		ServiceBase.log.Debug("不是发布");
		repository.UpdateCommit(article);
	}

	public IList<TREE_NODE> GetAuthorizationOrg(CMS_ARTICLEDTO parameter)
	{
		IList<CMS_VIEW_AUDIT> result = viewauditRepository.FindAll((CMS_VIEW_AUDIT a) => a.ARTICLE_ID == parameter.ID && a.VIEW_TYPE == 1m);
		IList<Guid> org = new List<Guid>();
		result.ForEach(delegate(CMS_VIEW_AUDIT a)
		{
			org.Add(a.VIEW_ID);
		});
		return ServiceLocator.Instance.GetService<IOrgUserService>().GetOrgUserTree(null, -1, isFindUser: false, isAllowUserManyToOrg: false, isIncludeSelf: true, org);
	}

	public IList<TREE_NODE> GetAuthorizationUser(CMS_ARTICLEDTO parameter)
	{
		IList<CMS_VIEW_AUDIT> result = viewauditRepository.FindAll((CMS_VIEW_AUDIT a) => a.ARTICLE_ID == parameter.ID && a.VIEW_TYPE == 0m);
		IList<Guid> user = new List<Guid>();
		result.ForEach(delegate(CMS_VIEW_AUDIT a)
		{
			user.Add(a.VIEW_ID);
		});
		return ServiceLocator.Instance.GetService<IOrgUserService>().GetOrgUserTree(null, -1, isFindUser: true, isAllowUserManyToOrg: false, isIncludeSelf: true, user);
	}

	public CMS_ARTICLEDTO GetArticleByID(Guid guid)
	{
		return repository.GetByKey(guid).AdaptAsDTO<CMS_ARTICLEDTO>();
	}

	public void DeleteArticle(CMS_ARTICLEDTO dto)
	{
		foreach (Guid item in dto.IDs)
		{
			CMS_ARTICLE article = repository.GetByKey(item);
			article.IS_DEL = 1m;
			repository.UpdateCommit(article);
		}
	}

	public IList<CMS_COMMENTDTO> GetArticleComment(CMS_COMMENTDTO dto)
	{
		return SqlQuery<CMS_COMMENTDTO>("GetALLArticleComment", dto);
	}

	public QueryResult<CMS_COMMENTDTO> GetArticleCommentPager(CMS_COMMENTDTO dto)
	{
		return SqlQueryPager<CMS_COMMENTDTO>("GetALLArticleCommentPager", dto);
	}

	public void DeleteArticleComment(CMS_COMMENTDTO dto)
	{
		CMS_COMMENT article = commentRepository.GetByKey(dto.ID);
		commentRepository.Remove(article);
		commentRepository.DbContext.Commit();
	}

	public void AddArticleComment(CMS_COMMENTDTO dto)
	{
		dto.USER_ID = SessionContext.UserInfo.UserID;
		dto.USER_NAME = SessionContext.UserInfo.UserName;
		dto.AUDIT_USER_ID = SessionContext.UserInfo.UserID;
		dto.AUDIT_USER_NAME = OrgUserCacheManager.GetOrgByKey(SessionContext.UserInfo.BelongToOrgID).ORG_NAME;
		dto.ID = Guid.NewGuid();
		dto.IP = "";
		dto.CREATE_DATE = DateTime.Now;
		commentRepository.AddCommit(dto.AdaptAsEntity<CMS_COMMENT>());
	}

	public decimal ChangeHits(CMS_ARTICLEDTO dto)
	{
		CMS_ARTICLE article = repository.GetByKey(dto.ID);
		article.HITS += 1m;
		repository.UpdateCommit(article);
		try
		{
			IList<CMS_SCANNED> scanned = scannedRepository.FindAll((CMS_SCANNED a) => a.ARTICLE_ID == dto.ID && a.USER_ID == SessionContext.UserInfo.UserID);
			if (scanned.Count == 0)
			{
				scannedRepository.AddCommit(new CMS_SCANNED
				{
					ARTICLE_ID = dto.ID,
					USER_ID = SessionContext.UserInfo.UserID,
					IS_DEL = 0m
				});
			}
		}
		catch (Exception)
		{
		}
		return article.HITS.Value;
	}

	public void TOP(CMS_ARTICLEDTO dto)
	{
		CMS_ARTICLE article = repository.GetByKey(dto.ID);
		IList<CMS_ARTICLE> articleweight = repository.FindAll((CMS_ARTICLE a) => a.WEIGHT == (decimal?)2m);
		if (articleweight == null || articleweight.Count() == 0)
		{
			article.WEIGHT_SORT = 1m;
		}
		else
		{
			articleweight[0].WEIGHT = 1m;
			article.WEIGHT_SORT = articleweight[0].WEIGHT_SORT + 1m;
		}
		article.WEIGHT = 2m;
		repository.UpdateCommit(articleweight);
		repository.UpdateCommit(article);
	}

	public void CancelTop(CMS_ARTICLEDTO dto)
	{
		CMS_ARTICLE article = repository.GetByKey(dto.ID);
		article.WEIGHT_SORT = 0m;
		article.WEIGHT = 0m;
		repository.UpdateCommit(article);
	}

	public CMS_ARTICLE_DATADTO GetArticleForMobileByID(Guid guid)
	{
		IList<CMS_ARTICLE_DATADTO> list = SqlQuery<CMS_ARTICLE_DATADTO>("GetArticleForMobileByID", new CMS_ARTICLE_DATADTO
		{
			ID = guid
		});
		if (list.Count > 0)
		{
			CMS_ARTICLE_DATADTO result = list[0];
			try
			{
				IList<CMS_SCANNED> scanned = scannedRepository.FindAll((CMS_SCANNED a) => a.ARTICLE_ID == result.ID && a.USER_ID == SessionContext.UserInfo.UserID);
				if (scanned.Count == 0)
				{
					scannedRepository.AddCommit(new CMS_SCANNED
					{
						ARTICLE_ID = result.ID,
						USER_ID = SessionContext.UserInfo.UserID,
						IS_DEL = 0m
					});
				}
			}
			catch (Exception)
			{
			}
			string html = GlobalObject.unescape(result.CONTENT);
			html = html.Replace("\u3000", "").Replace("\r\n    ", "").Replace("&nbsp;", "")
				.Replace("</span>", "");
			MatchCollection titleMatch = Regex.Matches(html, "<span[^>]*>");
			foreach (Match t in titleMatch)
			{
				html = html.Replace(t.Value, "");
			}
			titleMatch = Regex.Matches(html, "<p></p>");
			foreach (Match t in titleMatch)
			{
				html = html.Replace(t.Value, "");
			}
			titleMatch = Regex.Matches(html, "<p[^>]*>");
			foreach (Match t in titleMatch)
			{
				if (!Regex.Match(t.Value, "<p[^>]*color[^>]*>").Success)
				{
					html = ((!Regex.Match(t.Value, "<p[^>]*center[^>]*>").Success) ? ((!Regex.Match(t.Value, "<p[^>]*text-align: right[^>]*>").Success) ? ((!Regex.Match(t.Value, "<p[^>]*margin-right:0[^>]*>").Success) ? ((!Regex.Match(t.Value, "<p[^>]*margin-right[^>]*>").Success) ? ((!Regex.Match(t.Value, "<p[^>]*right[^>]*>").Success) ? html.Replace(t.Value, "<p style='text-align: left; line-height: 1.7em; text-indent: 2em; font-family: FangSong; font-size: 18px; margin-top: 10px; margin-bottom: 10px;'>") : html.Replace(t.Value, "<p style='text-align: right; line-height: 1.7em; font-family: FangSong; font-size: 18px; margin-top: 10px; margin-right: 20px; margin-bottom: 10px;'>")) : html.Replace(t.Value, "<p style='text-align: left; line-height: 1.7em; font-family: FangSong; font-size: 18px; margin-top: 10px; margin-right: 20px; margin-bottom: 10px;'>")) : html.Replace(t.Value, "<p style='text-align: left; line-height: 1.7em; font-family: FangSong; font-size: 18px; margin-top: 10px; margin-right: 20px; margin-bottom: 10px;'>")) : html.Replace(t.Value, "<p style='text-align: right; line-height: 1.7em; font-family: FangSong; font-size: 18px; margin-top: 10px; margin-right: 20px; margin-bottom: 10px;'>")) : html.Replace(t.Value, "<p style='text-align: center; line-height: 1.7em; text-indent: 0em; font-family: FangSong; font-size: 22px; margin-top: 15px; margin-bottom: 20px;'>"));
				}
			}
			titleMatch = Regex.Matches(html, "<img[^>]*");
			foreach (Match t in titleMatch)
			{
				html = html.Replace(t.Value, t.Value + " style='width:100%;height:auto;' ");
			}
			result.CONTENT = GlobalObject.escape(html);
			return result;
		}
		return new CMS_ARTICLE_DATADTO();
	}

	public string GetCategoryForMobileIndexByUserId()
	{
		IList<CMS_ARTICLEMDTO> list = SqlQuery<CMS_ARTICLEMDTO>("GetCategoryForMobileIndexByUserId", new CMS_ARTICLEDTO
		{
			USER_ID = SessionContext.UserInfo.UserID
		});
		IList<CMS_ARTICLEMDTO> piclist = SqlQuery<CMS_ARTICLEMDTO>("GetPicForMobileIndexByUserId", new CMS_ARTICLEDTO
		{
			USER_ID = SessionContext.UserInfo.UserID
		});
		IOrderedEnumerable<CMS_ARTICLEMDTO> tzggList = from article in list
			where article.CATEGORY_NAME == "通知公告"
			orderby article.AUDIT_DATE descending
			select article;
		IOrderedEnumerable<CMS_ARTICLEMDTO> zxdtList = from article in list
			where article.CATEGORY_NAME == "中心动态"
			orderby article.AUDIT_DATE descending
			select article;
		IOrderedEnumerable<CMS_ARTICLEMDTO> sjtzList = from article in list
			where article.CATEGORY_NAME == "审计通知"
			orderby article.AUDIT_DATE descending
			select article;
		IOrderedEnumerable<CMS_ARTICLEMDTO> picList = piclist.OrderByDescending((CMS_ARTICLEMDTO article) => article.AUDIT_DATE);
		return new
		{
			TZGG = tzggList.Take(3),
			ZXDT = zxdtList.Take(3),
			SJTZ = sjtzList.Take(3),
			TPXW = picList.Take(4)
		}.JsonSerialize();
	}

	public IList<COUNTDTO> GetCountForMobileByUserId()
	{
		return SqlQuery<COUNTDTO>("GetCountForMobileByUserId", new COUNTDTO
		{
			USER_ID = SessionContext.UserInfo.UserID
		});
	}

	public QueryResult<CMS_ARTICLEMDTO> GetArticleForMobileIndexByUserIdAndCategoryId(CMS_ARTICLEDTO parameter)
	{
		parameter.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<CMS_ARTICLEMDTO>("GetArticleForMobileIndexByUserIdAndCategoryId", parameter);
	}

	public IList<CMS_ARTICLEDTO> GetMyArticle_Export(CMS_ARTICLEDTO queryCondition)
	{
		decimal? iS_ADMIN = queryCondition.IS_ADMIN;
		if (iS_ADMIN.GetValueOrDefault() != 1m || !iS_ADMIN.HasValue)
		{
			return SqlQuery<CMS_ARTICLEDTO>("GetMyArticle_Export", queryCondition);
		}
		return SqlQuery<CMS_ARTICLEDTO>("GetMyArticle_Export_Admin", queryCondition);
	}

	private void WriteFileOne(string name)
	{
		string path = HttpContext.Current.Server.MapPath("/cms/birthday/temp/") + "0001.jpg";
		Image image = Image.FromFile(path);
		Image newFile = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppRgb);
		Graphics graphics = Graphics.FromImage(newFile);
		graphics.DrawImage(image, 0, 0, image.Width, image.Height);
		Font font = new Font("微软雅黑", 20f);
		Brush brush = new SolidBrush(Color.Yellow);
		graphics.DrawString(name, font, brush, 173f, 575f);
		graphics.DrawString(DateTime.Now.Year.ToString(), font, brush, 535f, 915f);
		if (DateTime.Now.Month < 10)
		{
			graphics.DrawString(DateTime.Now.Month.ToString(), font, brush, 635f, 915f);
		}
		else
		{
			graphics.DrawString(DateTime.Now.Month.ToString(), font, brush, 625f, 915f);
		}
		if (DateTime.Now.Day < 10)
		{
			graphics.DrawString(DateTime.Now.Day.ToString(), font, brush, 690f, 915f);
		}
		else
		{
			graphics.DrawString(DateTime.Now.Day.ToString(), font, brush, 680f, 915f);
		}
		graphics.Dispose();
		Image saveImage = newFile.GetThumbnailImage(image.Width, image.Height, null, IntPtr.Zero);
		image.Dispose();
		saveImage.Save(string.Format(HttpContext.Current.Server.MapPath("/cms/birthday/") + "/{0}.gif", DateTime.Now.ToString("yyyyMMdd")), ImageFormat.Gif);
	}

	private void WriteFileTwo(string name)
	{
		string path = HttpContext.Current.Server.MapPath("/cms/birthday/temp/") + "0002.jpg";
		Image image = Image.FromFile(path);
		Image newFile = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppRgb);
		Graphics graphics = Graphics.FromImage(newFile);
		graphics.DrawImage(image, 0, 0, image.Width, image.Height);
		Font font = new Font("隶书", 40f);
		Font fontDate = new Font("微软雅黑", 20f);
		Brush brush = new SolidBrush(Color.Black);
		graphics.DrawString(name, font, brush, 200f, 740f);
		graphics.DrawString(DateTime.Now.Year.ToString(), fontDate, brush, 695f, 1158f);
		if (DateTime.Now.Month < 10)
		{
			graphics.DrawString(DateTime.Now.Month.ToString(), fontDate, brush, 800f, 1158f);
		}
		else
		{
			graphics.DrawString(DateTime.Now.Month.ToString(), fontDate, brush, 790f, 1158f);
		}
		if (DateTime.Now.Day < 10)
		{
			graphics.DrawString(DateTime.Now.Day.ToString(), fontDate, brush, 865f, 1158f);
		}
		else
		{
			graphics.DrawString(DateTime.Now.Day.ToString(), fontDate, brush, 855f, 1158f);
		}
		graphics.Dispose();
		Image saveImage = newFile.GetThumbnailImage(image.Width, image.Height, null, IntPtr.Zero);
		image.Dispose();
		saveImage.Save(string.Format(HttpContext.Current.Server.MapPath("/cms/birthday/") + "/{0}.gif", DateTime.Now.ToString("yyyyMMdd")), ImageFormat.Gif);
	}

	public IList<CMS_ARTICLEDTO> GetImageArticle(CMS_ARTICLEDTO parameter)
	{
		parameter.IS_TOP = 1m;
		IList<CMS_ARTICLEDTO> listTop = SqlQuery<CMS_ARTICLEDTO>("GetImageArticle", parameter);
		foreach (CMS_ARTICLEDTO item in listTop)
		{
			item.CMS_ARTICLE_DATA = articledataRepository.GetByKey(item.ID).AdaptAsDTO<CMS_ARTICLE_DATADTO>();
		}
		decimal num = listTop.Count;
		decimal? cOUNT = parameter.COUNT;
		if (num < cOUNT.GetValueOrDefault() && cOUNT.HasValue)
		{
			parameter.COUNT -= (decimal?)listTop.Count;
			parameter.IS_TOP = 0m;
			IList<CMS_ARTICLEDTO> listNotTop = SqlQuery<CMS_ARTICLEDTO>("GetImageArticle", parameter);
			foreach (CMS_ARTICLEDTO item in listNotTop)
			{
				item.CMS_ARTICLE_DATA = articledataRepository.GetByKey(item.ID).AdaptAsDTO<CMS_ARTICLE_DATADTO>();
			}
			foreach (CMS_ARTICLEDTO item in listNotTop)
			{
				listTop.Add(item);
			}
		}
		return listTop;
	}

	public IList<CMS_ARTICLEDTO> GetAllArticleByType(CMS_ARTICLEDTO parameter)
	{
		parameter.IS_TOP = 1m;
		IList<CMS_ARTICLEDTO> listTop = SqlQuery<CMS_ARTICLEDTO>("GetALLArticleByType", parameter);
		decimal num = listTop.Count;
		decimal? cOUNT = parameter.COUNT;
		if (num < cOUNT.GetValueOrDefault() && cOUNT.HasValue)
		{
			parameter.COUNT -= (decimal?)listTop.Count;
			parameter.IS_TOP = 0m;
			IList<CMS_ARTICLEDTO> listNotTop = (listNotTop = SqlQuery<CMS_ARTICLEDTO>("GetALLArticleByType", parameter));
			if (listNotTop.Count > 0)
			{
				foreach (CMS_ARTICLEDTO item in listNotTop)
				{
					listTop.Add(item);
				}
			}
		}
		return listTop;
	}

	public int GetArticleCount(CMS_ARTICLEDTO parameter)
	{
		return SqlQuery<CMS_ARTICLEDTO>("GetArticleCount", parameter).Count;
	}

	public IList<CMS_ARTICLEDTO> GetArticleMore(CMS_ARTICLEDTO parameter)
	{
		return SqlQuery<CMS_ARTICLEDTO>("GetArticleMore", parameter);
	}

	public object CODE()
	{
		CMS_ARTICLEDTO dto = new CMS_ARTICLEDTO();
		dto.PageSize = int.MaxValue;
		IList<CMS_ARTICLEDTO> articleList = SqlQuery<CMS_ARTICLEDTO>("GetALLArticle", null, (string a) => "SELECT * FROM  CMS_ARTICLE");
		int i = 0;
		foreach (CMS_ARTICLEDTO item in articleList)
		{
			CMS_ARTICLE_DATA data = articledataRepository.GetByKey(item.ID);
			if (data == null || string.IsNullOrEmpty(data.CONTENT))
			{
				bool flag = true;
				if (data == null)
				{
					data = new CMS_ARTICLE_DATA();
					flag = false;
				}
				data.ID = item.ID;
				data.CONTENT = GlobalObject.escape(" ");
				if (flag)
				{
					articledataRepository.UpdateCommit(data);
				}
				else
				{
					articledataRepository.AddCommit(data);
				}
			}
		}
		return i;
	}
}
