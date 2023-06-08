using System.Data.Entity.Internal;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Instances of this class are returned from the Reference method of
///     <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> and allow operations such as loading to
///     be performed on the an entity's reference navigation properties.
/// </summary>
/// <typeparam name="TEntity">The type of the entity to which this property belongs.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbReferenceEntry<TEntity, TProperty> : DbMemberEntry<TEntity, TProperty> where TEntity : class
{
	private readonly InternalReferenceEntry _internalReferenceEntry;

	/// <summary>
	///     Gets the property name.
	/// </summary>
	/// <value>The property name.</value>
	public override string Name => _internalReferenceEntry.Name;

	/// <summary>
	///     Gets or sets the current value of the navigation property.  The current value is
	///     the entity that the navigation property references.
	/// </summary>
	/// <value>The current value.</value>
	public override TProperty CurrentValue
	{
		get
		{
			return (TProperty)_internalReferenceEntry.CurrentValue;
		}
		set
		{
			_internalReferenceEntry.CurrentValue = value;
		}
	}

	/// <summary>
	///     Gets a value indicating whether the entity has been loaded from the database.
	/// </summary>
	/// <value><c>true</c> if the entity is loaded; otherwise, <c>false</c>.</value>
	public bool IsLoaded => _internalReferenceEntry.IsLoaded;

	/// <summary>
	///     Gets the underlying <see cref="T:System.Data.Entity.Internal.InternalReferenceEntry" /> as an <see cref="P:System.Data.Entity.Infrastructure.DbReferenceEntry`2.InternalMemberEntry" />.
	/// </summary>
	/// <value>The internal member entry.</value>
	internal override InternalMemberEntry InternalMemberEntry => _internalReferenceEntry;

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> to which this navigation property belongs.
	/// </summary>
	/// <value>An entry for the entity that owns this navigation property.</value>
	public override DbEntityEntry<TEntity> EntityEntry => new DbEntityEntry<TEntity>(_internalReferenceEntry.InternalEntityEntry);

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry`2" /> from information in the given <see cref="T:System.Data.Entity.Internal.InternalReferenceEntry" />.
	///     Use this method in preference to the constructor since it may potentially create a subclass depending on
	///     the type of member represented by the InternalCollectionEntry instance.
	/// </summary>
	/// <param name="internalReferenceEntry">The internal reference entry.</param>
	/// <returns>The new entry.</returns>
	internal static DbReferenceEntry<TEntity, TProperty> Create(InternalReferenceEntry internalReferenceEntry)
	{
		return (DbReferenceEntry<TEntity, TProperty>)internalReferenceEntry.CreateDbMemberEntry<TEntity, TProperty>();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry`2" /> class.
	/// </summary>
	/// <param name="internalReferenceEntry">The internal entry.</param>
	internal DbReferenceEntry(InternalReferenceEntry internalReferenceEntry)
	{
		_internalReferenceEntry = internalReferenceEntry;
	}

	/// <summary>
	///     Loads the entity from the database.
	///     Note that if the entity already exists in the context, then it will not overwritten with values from the database.
	/// </summary>
	public void Load()
	{
		_internalReferenceEntry.Load();
	}

	/// <summary>
	///     Returns the query that would be used to load this entity from the database.
	///     The returned query can be modified using LINQ to perform filtering or operations in the database.
	/// </summary>
	/// <returns>A query for the entity.</returns>
	public IQueryable<TProperty> Query()
	{
		return (IQueryable<TProperty>)_internalReferenceEntry.Query();
	}

	/// <summary>
	///     Returns a new instance of the non-generic <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry" /> class for 
	///     the navigation property represented by this object.
	/// </summary>
	/// <returns>A non-generic version.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Intentionally just implicit to reduce API clutter.")]
	public static implicit operator DbReferenceEntry(DbReferenceEntry<TEntity, TProperty> entry)
	{
		return DbReferenceEntry.Create(entry._internalReferenceEntry);
	}
}
/// <summary>
///     A non-generic version of the <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry`2" /> class.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbReferenceEntry : DbMemberEntry
{
	private readonly InternalReferenceEntry _internalReferenceEntry;

	/// <summary>
	///     Gets the property name.
	/// </summary>
	/// <value>The property name.</value>
	public override string Name => _internalReferenceEntry.Name;

	/// <summary>
	///     Gets or sets the current value of the navigation property.  The current value is
	///     the entity that the navigation property references.
	/// </summary>
	/// <value>The current value.</value>
	public override object CurrentValue
	{
		get
		{
			return _internalReferenceEntry.CurrentValue;
		}
		set
		{
			_internalReferenceEntry.CurrentValue = value;
		}
	}

	/// <summary>
	///     Gets a value indicating whether the entity has been loaded from the database.
	/// </summary>
	/// <value><c>true</c> if the entity is loaded; otherwise, <c>false</c>.</value>
	public bool IsLoaded => _internalReferenceEntry.IsLoaded;

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> to which this navigation property belongs.
	/// </summary>
	/// <value>An entry for the entity that owns this navigation property.</value>
	public override DbEntityEntry EntityEntry => new DbEntityEntry(_internalReferenceEntry.InternalEntityEntry);

	/// <summary>
	///     Gets the <see cref="T:System.Data.Entity.Internal.InternalReferenceEntry" /> backing this object as an <see cref="P:System.Data.Entity.Infrastructure.DbReferenceEntry.InternalMemberEntry" />.
	/// </summary>
	/// <value>The internal member entry.</value>
	internal override InternalMemberEntry InternalMemberEntry => _internalReferenceEntry;

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry" /> from information in the given <see cref="T:System.Data.Entity.Internal.InternalReferenceEntry" />.
	///     Use this method in preference to the constructor since it may potentially create a subclass depending on
	///     the type of member represented by the InternalCollectionEntry instance.
	/// </summary>
	/// <param name="internalReferenceEntry">The internal reference entry.</param>
	/// <returns>The new entry.</returns>
	internal static DbReferenceEntry Create(InternalReferenceEntry internalReferenceEntry)
	{
		return (DbReferenceEntry)internalReferenceEntry.CreateDbMemberEntry();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry" /> class.
	/// </summary>
	/// <param name="internalReferenceEntry">The internal entry.</param>
	internal DbReferenceEntry(InternalReferenceEntry internalReferenceEntry)
	{
		_internalReferenceEntry = internalReferenceEntry;
	}

	/// <summary>
	///     Loads the entity from the database.
	///     Note that if the entity already exists in the context, then it will not overwritten with values from the database.
	/// </summary>
	public void Load()
	{
		_internalReferenceEntry.Load();
	}

	/// <summary>
	///     Returns the query that would be used to load this entity from the database.
	///     The returned query can be modified using LINQ to perform filtering or operations in the database.
	/// </summary>
	/// <returns>A query for the entity.</returns>
	public IQueryable Query()
	{
		return _internalReferenceEntry.Query();
	}

	/// <summary>
	///     Returns the equivalent generic <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry`2" /> object.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity on which the member is declared.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <returns>The equivalent generic object.</returns>
	public new DbReferenceEntry<TEntity, TProperty> Cast<TEntity, TProperty>() where TEntity : class
	{
		MemberEntryMetadata entryMetadata = _internalReferenceEntry.EntryMetadata;
		if (!typeof(TEntity).IsAssignableFrom(entryMetadata.DeclaringType) || !typeof(TProperty).IsAssignableFrom(entryMetadata.ElementType))
		{
			throw Error.DbMember_BadTypeForCast(typeof(DbReferenceEntry).Name, typeof(TEntity).Name, typeof(TProperty).Name, entryMetadata.DeclaringType.Name, entryMetadata.MemberType.Name);
		}
		return DbReferenceEntry<TEntity, TProperty>.Create(_internalReferenceEntry);
	}
}
