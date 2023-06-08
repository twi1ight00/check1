using System.Collections;
using System.Collections.ObjectModel;

namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     A non-generic interface implemented by <see cref="T:System.Data.Entity.Internal.Linq.InternalSet`1" /> that allows operations on
///     any set object without knowing the type to which it applies.
/// </summary>
internal interface IInternalSet : IInternalQuery
{
	void Attach(object entity);

	void Add(object entity);

	void Remove(object entity);

	void Initialize();

	void TryInitialize();

	IEnumerable ExecuteSqlQuery(string sql, bool asNoTracking, object[] parameters);
}
/// <summary>
///     An interface implemented by <see cref="T:System.Data.Entity.Internal.Linq.InternalSet`1" />.
/// </summary>
internal interface IInternalSet<TEntity> : IInternalSet, IInternalQuery<TEntity>, IInternalQuery where TEntity : class
{
	ObservableCollection<TEntity> Local { get; }

	TEntity Find(params object[] keyValues);

	TEntity Create();

	TEntity Create(Type derivedEntityType);
}
