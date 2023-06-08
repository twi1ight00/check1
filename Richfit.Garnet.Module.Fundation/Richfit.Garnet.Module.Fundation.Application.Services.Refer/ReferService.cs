using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Refer;

/// <summary>
/// 获取引用数据服务
/// </summary>
public class ReferService : ServiceBase, IReferService
{
	private SqlRepository sqlRepository = ServiceLocator.Instance.GetService<SqlRepository>();

	/// <summary>
	/// 查询表引用数据
	/// </summary>
	/// <param name="tableName">表名</param>
	/// <param name="displayColumn">用于显示的字段名</param>
	/// <param name="valueColumn">用于存值的字段名</param>
	/// <param name="conditions">查询条件</param>
	/// <param name="orderBy"></param>
	/// <returns>数据结果</returns>
	public QueryResult<IDataObject> QuerySelectRefer(string tableName, string displayColumn, string valueColumn, QueryCondition conditions, string orderBy)
	{
		IXmlObjectConfiguration o = ConfigurationManager.CurrentPackage.Collection.Get<IXmlObjectConfiguration>("ReferTable");
		string strSql = "select " + displayColumn + " DisplayColumn," + valueColumn + " ValueColumn from " + tableName + " {0} ";
		if (!string.IsNullOrEmpty(orderBy))
		{
			strSql = strSql + " order by " + orderBy;
		}
		return DynamicSqlQuery(strSql, conditions, ParameterResolveRule.Null, ValueResolveRule.Null);
	}

	/// <summary>
	/// 查询表自引用数据
	/// </summary>
	/// <param name="tableName">表名</param>
	/// <param name="columnName">字段名</param>
	/// <param name="conditions">查询条件</param>
	/// <param name="likeSQL">模糊匹配语句</param>
	/// <returns>数据结果</returns>
	public QueryResult<SelfReferDTO> QuerySelfReferList(string tableName, string columnName, QueryCondition conditions, string likeSQL)
	{
		QueryResult<SelfReferDTO> queryResult = new QueryResult<SelfReferDTO>();
		SqlRepository sr = ServiceLocator.Instance.GetService<SqlRepository>();
		string strSql = string.Empty;
		IXmlObjectConfiguration o = ConfigurationManager.CurrentPackage.Collection.Get<IXmlObjectConfiguration>("ReferTable");
		if (!string.IsNullOrEmpty(likeSQL))
		{
			QueryItem like = new QueryItem();
			like.Key = columnName;
			like.Method = " Like ";
			like.Value = likeSQL;
			like.Type = "string";
			conditions.Add(like);
		}
		return SqlQuery<SelfReferDTO>("GetSelfReferColumn", conditions, ParameterResolveRule.Null, ValueResolveRule.Null, new string[2] { columnName, tableName });
	}
}
