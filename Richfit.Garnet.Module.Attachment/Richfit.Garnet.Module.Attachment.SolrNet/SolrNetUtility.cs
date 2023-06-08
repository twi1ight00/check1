using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Practices.ServiceLocation;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Impl;

namespace Richfit.Garnet.Module.Attachment.SolrNet;

public sealed class SolrNetUtility
{
	private static readonly SolrNetUtility instance;

	public static SolrNetUtility Instance => instance;

	static SolrNetUtility()
	{
		instance = new SolrNetUtility();
	}

	private SolrNetUtility()
	{
		string solrpath = ConfigurationManager.AppSettings["SolrPath"];
		string userName = ConfigurationManager.AppSettings["userName"];
		string password = ConfigurationManager.AppSettings["password"];
		SolrConnection conn = new SolrConnection(solrpath, userName, password);
		Startup.Init<SOLRNETDTO>(conn);
	}

	/// <summary>
	/// 添加文档索引(word)
	/// </summary>
	/// <param name="path">路径</param>
	/// <param name="mimeType">mime类型</param>
	public void IndexDocs(string path, string mimeType)
	{
		ISolrOperations<SOLRNETDTO> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SOLRNETDTO>>();
		List<string> files = (from f in Directory.GetFiles(path, "*.*")
			where f.ToLower().EndsWith("docx")
			select f).ToList();
		foreach (string fileurl in files)
		{
			using FileStream file = File.OpenRead(fileurl);
			ExtractResponse response = solr.Extract(new ExtractParameters((FileStream)(object)file, Path.GetFileName(fileurl))
			{
				AutoCommit = true,
				ExtractFormat = ExtractFormat.Text,
				StreamType = mimeType,
				Fields = new ExtractField[2]
				{
					new ExtractField("create_time", DateTime.Now.ToString()),
					new ExtractField("title", Path.GetFileNameWithoutExtension(fileurl))
				}
			});
		}
	}

	/// <summary>
	/// 添加单个文档索引（word）
	/// </summary>
	/// <param name="path">路径</param>
	/// <param name="mimeType">mime类型</param>
	/// <param name="userList">权限用户列表</param>
	public void IndexDoc(string path, string mimeType, string title, string sourceFileExtension, string FILE_RELATIVE_PATH)
	{
		ISolrOperations<SOLRNETDTO> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SOLRNETDTO>>();
		using FileStream file = File.OpenRead(path);
		List<ExtractField> list = new List<ExtractField>();
		list.Add(new ExtractField("create_time", DateTime.Now.ToString()));
		list.Add(new ExtractField("title", title));
		list.Add(new ExtractField("source_file_extension", sourceFileExtension));
		list.Add(new ExtractField("file_relative_path", FILE_RELATIVE_PATH));
		List<ExtractField> extraList = list;
		ExtractResponse response = solr.Extract(new ExtractParameters((FileStream)(object)file, Path.GetFileName(path))
		{
			AutoCommit = true,
			ExtractFormat = ExtractFormat.Text,
			StreamType = mimeType,
			Fields = (IEnumerable<ExtractField>)extraList
		});
	}

	/// <summary>
	/// 删除索引
	/// </summary>
	/// <param name="id">id</param>
	public void Delete(string delId)
	{
		ISolrOperations<SOLRNETDTO> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SOLRNETDTO>>();
		SOLRNETDTO sOLRNETDTO = new SOLRNETDTO();
		sOLRNETDTO.id = delId;
		SOLRNETDTO p = sOLRNETDTO;
		solr.Delete(p);
		solr.Commit();
	}

	/// <summary>
	/// 查询数据（分页返回数据）
	/// </summary>
	/// <param name="title">标题</param>
	/// <param name="content">内容</param>
	/// <param name="pageIndex">开始项目(前端传过来的pageIndex)</param>
	/// <param name="pageNum">每页显示数量</param>
	public QueryResult<SOLRNETDTO> Query(SOLRNETDTO solrnetdto)
	{
		ISolrOperations<SOLRNETDTO> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SOLRNETDTO>>();
		QueryOptions options = new QueryOptions();
		HighlightingParameters high = new HighlightingParameters();
		high.Fields = (ICollection<string>)new List<string> { "title", "content" };
		high.BeforeTerm = "<font color='red'><b>";
		high.AfterTerm = "</b></font>";
		high.Fragsize = new int?(200);
		options.Highlight = high;
		List<ISolrQuery> query = new List<ISolrQuery>();
		Regex regExp = new Regex("^[0-9]*$");
		string[] keyArr = solrnetdto.solrkeyword.Split(' ');
		string[] SortBy = solrnetdto.SortBy.Split(',');
		if (!string.IsNullOrEmpty(solrnetdto.solrkeyword))
		{
			List<ISolrQuery> ar = new List<ISolrQuery>();
			string[] array = keyArr;
			foreach (string item2 in array)
			{
				if (!string.IsNullOrEmpty(item2))
				{
					if (regExp.IsMatch(item2))
					{
						SolrQueryByField sl = new SolrQueryByField("title", string.Format("{0}{1}{2}", "*", item2, "*"));
						sl.Quoted = false;
						ar.Add(sl);
					}
					else
					{
						ar.Add(new SolrQueryByField("title", item2));
					}
				}
			}
			query.Add(new SolrMultipleCriteriaQuery((IEnumerable<ISolrQuery>)ar, "AND"));
			List<ISolrQuery> ar2 = new List<ISolrQuery>();
			array = keyArr;
			foreach (string item2 in array)
			{
				if (!string.IsNullOrEmpty(item2))
				{
					ar2.Add(new SolrQueryByField("content", item2));
				}
			}
			query.Add(new SolrMultipleCriteriaQuery((IEnumerable<ISolrQuery>)ar2, "AND"));
		}
		for (int i = 0; i < SortBy.Length; i++)
		{
			string[] nameBy = SortBy[i].Split(' ');
			if (nameBy[1].ToUpper() == "DESC")
			{
				options.AddOrder(new SortOrder(nameBy[0], Order.DESC));
			}
			else
			{
				options.AddOrder(new SortOrder(nameBy[0], Order.ASC));
			}
		}
		List<KeyValuePair<string, string>> extraParams = new List<KeyValuePair<string, string>>();
		extraParams.Add(new KeyValuePair<string, string>("defType", "edismax"));
		extraParams.Add(new KeyValuePair<string, string>("mm", "80%"));
		options.ExtraParams = (IEnumerable<KeyValuePair<string, string>>)extraParams;
		SolrMultipleCriteriaQuery qTBO = new SolrMultipleCriteriaQuery((IEnumerable<ISolrQuery>)query, "OR");
		SolrQueryResults<SOLRNETDTO> results = solr.Query(qTBO, options);
		IDictionary<string, HighlightedSnippets> highlights = (IDictionary<string, HighlightedSnippets>)results.Highlights;
		string emptyStr = "<span></span>";
		foreach (SOLRNETDTO item in (List<SOLRNETDTO>)(object)results)
		{
			if (highlights[item.id.ToString()].Count > 0)
			{
				bool isVal;
				string[] array;
				if (((ICollection<ICollection<string>>)highlights[item.id.ToString()].Values).Count == 2)
				{
					isVal = false;
					array = keyArr;
					foreach (string ic in array)
					{
						if (string.IsNullOrEmpty(ic))
						{
							continue;
						}
						if (regExp.IsMatch(ic))
						{
							if (!isVal)
							{
								isVal = true;
								item.title = ((IEnumerable<ICollection<string>>)highlights[item.id.ToString()].Values).ToList()[0].ToList()[0];
								item.title = item.title.Replace("<font color='red'><b>", "").Replace("</b></font>", "").Replace(ic, string.Format("{0}{1}{2}", "<font color='red'><b>", ic, "</b></font>"));
							}
							else
							{
								item.title = item.title.Replace(ic, string.Format("{0}{1}{2}", "<font color='red'><b>", ic, "</b></font>"));
							}
						}
						else
						{
							isVal = true;
							item.title = item.title.Replace(ic, string.Format("{0}{1}{2}", "<font color='red'><b>", ic, "</b></font>"));
						}
					}
					item.color = ((IEnumerable<ICollection<string>>)highlights[item.id.ToString()].Values).ToList()[1].ToList()[0];
					continue;
				}
				item.color = ((IEnumerable<ICollection<string>>)highlights[item.id.ToString()].Values).ToList()[0].ToList()[0];
				if (!(((IEnumerable<string>)highlights[item.id.ToString()].Keys).ToList()[0] == "title"))
				{
					continue;
				}
				isVal = false;
				array = keyArr;
				foreach (string ic in array)
				{
					if (string.IsNullOrEmpty(ic))
					{
						continue;
					}
					if (regExp.IsMatch(ic))
					{
						if (!isVal)
						{
							isVal = true;
							item.title = ((IEnumerable<ICollection<string>>)highlights[item.id.ToString()].Values).ToList()[0].ToList()[0];
							item.title = item.title.Replace("<font color='red'><b>", "").Replace("</b></font>", "").Replace(ic, string.Format("{0}{1}{2}", "<font color='red'><b>", ic, "</b></font>"));
						}
						else
						{
							item.title = item.title.Replace(ic, string.Format("{0}{1}{2}", "<font color='red'><b>", ic, "</b></font>"));
						}
					}
					else
					{
						isVal = true;
						item.title = item.title.Replace(ic, string.Format("{0}{1}{2}", "<font color='red'><b>", ic, "</b></font>"));
					}
				}
				item.color = emptyStr;
			}
			else
			{
				item.color = emptyStr;
			}
		}
		SolrFacetPivotQuery solrFacetPivotQuery = new SolrFacetPivotQuery();
		solrFacetPivotQuery.Fields = new PivotFields[1]
		{
			new PivotFields("color", "category")
		};
		solrFacetPivotQuery.MinCount = new int?(1);
		SolrFacetPivotQuery facetPivotQuery = solrFacetPivotQuery;
		QueryResult<SOLRNETDTO> re = new QueryResult<SOLRNETDTO>();
		int total = results.NumFound;
		re.List = ((IEnumerable<SOLRNETDTO>)results).Skip(solrnetdto.PageIndex * solrnetdto.PageSize).Take(solrnetdto.PageSize).ToList();
		re.RecordCount = total;
		return re;
	}

	/// <summary>
	/// 根据ID查找solr数据
	/// </summary>
	/// <param name="id">solr_id</param>
	/// <returns></returns>
	public List<SOLRNETDTO> QueryById(string id)
	{
		ISolrOperations<SOLRNETDTO> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SOLRNETDTO>>();
		return (List<SOLRNETDTO>)(object)solr.Query(new SolrQuery(string.Format("{0}:{1}", "id", id)));
	}
}
