using System;
using System.Data;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// 数据库上下文接口
/// </summary>
public interface IDBContext : IUnitOfWork, IDisposable, ISql, ISqlQueryConverter
{
	/// <summary>
	/// 获取当前数据库连接对象
	/// </summary>
	IDbConnection Connection { get; }

	/// <summary>
	/// 获取数据库类型
	/// </summary>
	/// <returns>数据库类型，DBType枚举</returns>
	DBType GetDatabaseType();
}
