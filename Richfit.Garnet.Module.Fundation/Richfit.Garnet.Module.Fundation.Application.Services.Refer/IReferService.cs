using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Refer;

/// <summary>
/// 获取引用数据服务
/// </summary>
public interface IReferService
{
	/// <summary>
	/// 查询表引用数据
	/// </summary>
	/// <param name="TableName">表名</param>
	/// <param name="DisplayColumn">用于显示的字段名</param>
	/// <param name="ValueColumn">用于存值的字段名</param>
	/// <param name="Conditions">查询条件</param>
	/// <param name="OrderBy"></param>
	/// <returns>数据结果</returns>
	QueryResult<IDataObject> QuerySelectRefer(string TableName, string DisplayColumn, string ValueColumn, QueryCondition Conditions, string OrderBy);

	/// <summary>
	/// 查询表自引用数据
	/// </summary>
	/// <param name="TableName">表名</param>
	/// <param name="ColumnName">字段名</param>
	/// <param name="Conditions">查询条件</param>
	/// <param name="LikeSQL">模糊匹配语句</param>
	/// <returns>数据结果</returns>
	QueryResult<SelfReferDTO> QuerySelfReferList(string TableName, string ColumnName, QueryCondition Conditions, string LikeSQL);
}
