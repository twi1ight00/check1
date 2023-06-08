using Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Dynamic;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query.Converter;

/// <summary>
/// 动态查询条件转化Sql接口
/// </summary>
public interface IDynamicQueryConverter
{
	/// <summary>
	/// 获取查询块对应的Sql表述
	/// </summary>
	/// <param name="queryBlock"></param>
	/// <returns></returns>
	string GetWhereSqlClause(IQueryBlock queryBlock);

	/// <summary>
	/// 获取查询块中的Sql参数值
	/// </summary>
	/// <param name="queryBlock"></param>
	/// <returns></returns>
	object[] GetWhereSqlParamValue(IQueryBlock queryBlock);
}
