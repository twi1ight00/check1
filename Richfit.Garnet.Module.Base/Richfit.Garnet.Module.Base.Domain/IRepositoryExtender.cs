using System;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Module.Base.Infrastructure.Data;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Base.Domain;

/// <summary>
/// 仓储（Repository）扩展接口
/// </summary>
/// <remarks>本接口定义仓储与<see cref="T:Richfit.Garnet.Module.Base.Domain.Entity">数据实体</see>无关的扩展方法</remarks>
public interface IRepositoryExtender : ISql, ISqlQueryConverter
{
	/// <summary>
	/// 获得SQL配置文件中某个键值对应的SQL语句
	/// </summary>
	/// <param name="sqlKey">SQL语句的键值</param>
	/// <param name="type">调用者类型，调用者类型是获取的SQL语句所属功能包中的类型。</param>
	/// <returns>SQL语句文本</returns>
	string GetSqlConfig(string sqlKey, Type type);

	/// <summary>
	/// 获得SQL配置文件中某个键值对应的SQL语句
	/// </summary>
	/// <param name="sqlKey">SQL语句的键值</param>
	/// <param name="type">调用者类型，调用者类型是获取的SQL语句所属功能包中的类型。</param>
	/// <returns>SQL语句对象</returns>
	SqlStatement GetSqlStatement(string sqlKey, Type type);
}
