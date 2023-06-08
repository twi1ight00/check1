using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Base.Application.Services;

/// <summary>
/// 应用服务基类接口
/// </summary>
public interface IServiceBase
{
	/// <summary>
	/// 根据实体主键查询单个对象实体，DTO返回
	/// </summary>
	/// <typeparam name="TDTO"></typeparam>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="id"></param>
	/// <param name="repository"></param>
	/// <returns></returns>
	TDTO GetDTOById<TDTO, TEntity>(object id, IRepository<TEntity> repository) where TDTO : DTOBase, new() where TEntity : Entity;

	/// <summary>
	/// 根据SQL键值和查询条件查询
	/// </summary>
	/// <typeparam name="TDTO">DTO类</typeparam>
	/// <typeparam name="TEntity">Entity类</typeparam>
	/// <param name="sqlKey">sqlKey</param>
	/// <param name="queryCondition">查询参数对象</param>
	/// <param name="repository">数据仓储</param>
	/// <returns>QueryResult</returns>
	QueryResult<TDTO> SqlQuery<TDTO, TEntity>(string sqlKey, QueryCondition queryCondition, IRepository<TEntity> repository) where TEntity : Entity;

	/// <summary>
	/// 根据SQL键值和查询条件查询
	/// </summary>
	/// <typeparam name="TDTO">DTO类</typeparam>
	/// <param name="sqlKey">sqlKey</param>
	/// <param name="queryCondition">查询参数对象</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化参数</param>
	/// <param name="beginIndex">查询条件中参与组织查询条件开始的索引位置</param>
	/// <returns>QueryResult</returns>
	QueryResult<TDTO> SqlQueryResult<TDTO>(string sqlKey, QueryCondition queryCondition, int beginIndex = 0, string[] formatParameters = null);

	/// <summary>
	/// 根据SQL键值和查询条件查询
	/// </summary>
	/// <typeparam name="TDTO">DTO类</typeparam>
	/// <typeparam name="TEntity">Entity类</typeparam>
	/// <param name="sqlKey">sqlKey</param>
	/// <param name="queryCondition">查询参数对象</param>
	/// <param name="formatParameters">自定义的Sql字符串格式化参数</param>
	/// <param name="repository">数据仓储</param>
	/// <param name="beginIndex">查询条件中参与组织查询条件开始的索引位置</param>
	/// <returns></returns>
	QueryResult<TDTO> SqlQuery<TDTO, TEntity>(string sqlKey, QueryCondition queryCondition, IRepository<TEntity> repository, int beginIndex = 0, string[] formatParameters = null) where TEntity : Entity;

	/// <summary>
	/// 根据查询条件进行实体查找
	/// </summary>
	/// <typeparam name="TDTO">DTO类</typeparam>
	/// <typeparam name="TEntity">Entity类</typeparam>
	/// <param name="queryCondition">查询参数对象</param>
	/// <param name="repository">数据仓储</param>
	/// <returns></returns>
	QueryResult<TDTO> EntityQuery<TDTO, TEntity>(QueryCondition queryCondition, IRepository<TEntity> repository) where TDTO : DTOBase, new() where TEntity : Entity;
}
