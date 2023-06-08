using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Internal;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Returned by the ChangeTracker method of <see cref="T:System.Data.Entity.DbContext" /> to provide access to features of
///     the context that are related to change tracking of entities.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public class DbChangeTracker
{
	private readonly InternalContext _internalContext;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbChangeTracker" /> class.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	internal DbChangeTracker(InternalContext internalContext)
	{
		_internalContext = internalContext;
	}

	/// <summary>
	///     Gets <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> objects for all the entities tracked by this context.
	/// </summary>
	/// <returns>The entries.</returns>
	public IEnumerable<DbEntityEntry> Entries()
	{
		return from e in _internalContext.GetStateEntries()
			select new DbEntityEntry(new InternalEntityEntry(_internalContext, e));
	}

	/// <summary>
	///     Gets <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> objects for all the entities of the given type
	///     tracked by this context.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <returns>The entries.</returns>
	public IEnumerable<DbEntityEntry<TEntity>> Entries<TEntity>() where TEntity : class
	{
		return from e in _internalContext.GetStateEntries<TEntity>()
			select new DbEntityEntry<TEntity>(new InternalEntityEntry(_internalContext, e));
	}

	/// <summary>
	///     Detects changes made to the properties and relationships of POCO entities.  Note that some types of
	///     entity (such as change tracking proxies and entities that derive from <see cref="T:System.Data.Objects.DataClasses.EntityObject" />)
	///     report changes automatically and a call to DetectChanges is not normally needed for these types of entities.
	///     Also note that normally DetectChanges is called automatically by many of the methods of <see cref="T:System.Data.Entity.DbContext" />
	///     and its related classes such that it is rare that this method will need to be called explicitly.
	///     However, it may be desirable, usually for performance reasons, to turn off this automatic calling of
	///     DetectChanges using the AutoDetectChangesEnabled flag from <see cref="P:System.Data.Entity.DbContext.Configuration" />.
	/// </summary>
	public void DetectChanges()
	{
		InternalContext internalContext = _internalContext;
		bool force = true;
		internalContext.DetectChanges(force);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
