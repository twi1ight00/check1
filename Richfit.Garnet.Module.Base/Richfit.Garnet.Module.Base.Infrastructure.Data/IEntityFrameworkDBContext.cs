using System;
using System.Data.Entity;
using System.Data.Objects;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// EntityFramework数据库上下文接口
/// </summary>
public interface IEntityFrameworkDBContext : IDBContext, IUnitOfWork, IDisposable, ISql, ISqlQueryConverter
{
	/// <summary>
	/// Returns a IDbSet instance for access to entities of the given type in the context, 
	/// the ObjectStateManager, and the underlying store. 
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <returns></returns>
	DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

	/// <summary>
	/// Attach this item into "ObjectStateManager"
	/// </summary>
	/// <typeparam name="TEntity">The type of entity</typeparam>
	/// <param name="entity">The item </param>
	void Attach<TEntity>(TEntity entity) where TEntity : class;

	/// <summary>
	/// Set object as modified
	/// </summary>
	/// <typeparam name="TEntity">The type of entity</typeparam>
	/// <param name="entity">The entity item to set as modifed</param>
	void SetModified<TEntity>(TEntity entity) where TEntity : class;

	/// <summary>
	/// Apply current values in <paramref name="original" />
	/// </summary>
	/// <typeparam name="TEntity">The type of entity</typeparam>
	/// <param name="original">The original entity</param>
	/// <param name="current">The current entity</param>
	void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;

	/// <summary>
	/// 获得ObjectContext对象
	/// </summary>
	/// <returns></returns>
	ObjectContext GetObjectContext();
}
