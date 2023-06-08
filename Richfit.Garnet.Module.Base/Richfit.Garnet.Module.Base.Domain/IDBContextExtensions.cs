using System.Data.Objects;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Base.Domain;

/// <summary>
/// 数据库上下文接口扩展类
/// </summary>
public static class IDBContextExtensions
{
	/// <summary>
	/// 判断当前数据库是否是Oracle数据库
	/// </summary>
	/// <param name="dbContext">当前数据库上下文</param>
	/// <returns>如果当前数据库是Oracle数据库返回true；否则返回false</returns>
	public static bool IsOracle(this IDBContext dbContext)
	{
		dbContext.GuardNotNull("Database Context");
		return dbContext.GetDatabaseType() == DBType.Oracle;
	}

	/// <summary>
	/// 获取当前数据库的实体数据上下文（ObjectContext）
	/// </summary>
	/// <returns>如果当前的数据库上下文基于Entity Framework，则返回ObjectContext；否则返回null。</returns>
	public static ObjectContext GetObjectContext(this IDBContext dbContext)
	{
		dbContext.GuardNotNull("Database Context");
		if (dbContext is IEntityFrameworkDBContext)
		{
			return dbContext.As<IEntityFrameworkDBContext>().GetObjectContext();
		}
		return null;
	}
}
