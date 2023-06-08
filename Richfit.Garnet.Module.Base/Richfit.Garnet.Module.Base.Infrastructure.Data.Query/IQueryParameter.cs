namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 强类型查询参数对象接口
/// </summary>
public interface IQueryParameter
{
	/// <summary>
	/// 是否启用分页查询
	/// </summary>
	bool IsPager { get; set; }

	/// <summary>
	/// 索引页.缺省1
	/// </summary>
	int PageIndex { get; set; }

	/// <summary>
	/// 单页记录数.缺省9999
	/// </summary>
	int PageSize { get; set; }

	/// <summary>
	/// 排序属性，对象查询时候必须与POCO对象属性名称相同，SQL查询时候必须与字段名称相同，多个属性逗号分割
	/// </summary>
	string SortBy { get; set; }

	/// <summary>
	/// 对应排序属性的排序顺序，多个逗号分割，只能是asc，desc形式，参考QuerySortOrder常量定义类
	/// </summary>
	string SortOrder { get; set; }

	/// <summary>
	/// 查询参数对象转化为QueryCondition对象
	/// </summary>
	/// <returns></returns>
	QueryCondition ToQueryCondition();
}
