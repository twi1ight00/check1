using System.Collections.Generic;
using System.Data.Entity.Internal;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Instances of this class are returned from the Collection method of
///     <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> and allow operations such as loading to
///     be performed on the an entity's collection navigation properties.
/// </summary>
/// <typeparam name="TEntity">The type of the entity to which this property belongs.</typeparam>
/// <typeparam name="TElement">The type of the element in the collection of entities.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbCollectionEntry<TEntity, TElement> : DbMemberEntry<TEntity, ICollection<TElement>> where TEntity : class
{
	private readonly InternalCollectionEntry _internalCollectionEntry;

	/// <summary>
	///     Gets the property name.
	/// </summary>
	/// <value>The property name.</value>
	public override string Name => _internalCollectionEntry.Name;

	/// <summary>
	///     Gets or sets the current value of the navigation property.  The current value is
	///     the entity that the navigation property references.
	/// </summary>
	/// <value>The current value.</value>
	[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
	public override ICollection<TElement> CurrentValue
	{
		get
		{
			return (ICollection<TElement>)_internalCollectionEntry.CurrentValue;
		}
		set
		{
			_internalCollectionEntry.CurrentValue = value;
		}
	}

	/// <summary>
	///     Gets a value indicating whether the collection of entities has been loaded from the database.
	/// </summary>
	/// <value><c>true</c> if the collection is loaded; otherwise, <c>false</c>.</value>
	public bool IsLoaded => _internalCollectionEntry.IsLoaded;

	/// <summary>
	///     Gets the underlying <see cref="T:System.Data.Entity.Internal.InternalCollectionEntry" /> as an <see cref="P:System.Data.Entity.Infrastructure.DbCollectionEntry`2.InternalMemberEntry" />.
	/// </summary>
	/// <value>The internal member entry.</value>
	internal override InternalMemberEntry InternalMemberEntry => _internalCollectionEntry;

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> to which this navigation property belongs.
	/// </summary>
	/// <value>An entry for the entity that owns this navigation property.</value>
	public override DbEntityEntry<TEntity> EntityEntry => new DbEntityEntry<TEntity>(_internalCollectionEntry.InternalEntityEntry);

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" /> from information in the given <see cref="T:System.Data.Entity.Internal.InternalCollectionEntry" />.
	///     Use this method in preference to the constructor since it may potentially create a subclass depending on
	///     the type of member represented by the InternalCollectionEntry instance.
	/// </summary>
	/// <param name="internalCollectionEntry">The internal collection entry.</param>
	/// <returns>The new entry.</returns>
	internal static DbCollectionEntry<TEntity, TElement> Create(InternalCollectionEntry internalCollectionEntry)
	{
		return internalCollectionEntry.CreateDbCollectionEntry<TEntity, TElement>();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" /> class.
	/// </summary>
	/// <param name="internalCollectionEntry">The internal entry.</param>
	internal DbCollectionEntry(InternalCollectionEntry internalCollectionEntry)
	{
		_internalCollectionEntry = internalCollectionEntry;
	}

	/// <summary>
	///     Loads the collection of entities from the database.
	///     Note that entities that already exist in the context are not overwritten with values from the database.
	/// </summary>
	public void Load()
	{
		_internalCollectionEntry.Load();
	}

	/// <summary>
	///     Returns the query that would be used to load this collection from the database.
	///     The returned query can be modified using LINQ to perform filtering or operations in the database, such
	///     as counting the number of entities in the collection in the database without actually loading them.
	/// </summary>
	/// <returns>A query for the collection.</returns>
	public IQueryable<TElement> Query()
	{
		return (IQueryable<TElement>)_internalCollectionEntry.Query();
	}

	/// <summary>
	///     Returns a new instance of the non-generic <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry" /> class for 
	///     the navigation property represented by this object.
	/// </summary>
	/// <returns>A non-generic version.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Intentionally just implicit to reduce API clutter.")]
	public static implicit operator DbCollectionEntry(DbCollectionEntry<TEntity, TElement> entry)
	{
		return DbCollectionEntry.Create(entry._internalCollectionEntry);
	}
}
/// <summary>
///     A non-generic version of the <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" /> class.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbCollectionEntry : DbMemberEntry
{
	private readonly InternalCollectionEntry _internalCollectionEntry;

	/// <summary>
	///     Gets the property name.
	/// </summary>
	/// <value>The property name.</value>
	public override string Name => _internalCollectionEntry.Name;

	/// <summary>
	///     Gets or sets the current value of the navigation property.  The current value is
	///     the entity that the navigation property references.
	/// </summary>
	/// <value>The current value.</value>
	public override object CurrentValue
	{
		get
		{
			return _internalCollectionEntry.CurrentValue;
		}
		set
		{
			_internalCollectionEntry.CurrentValue = value;
		}
	}

	/// <summary>
	///     Gets a value indicating whether the collection of entities has been loaded from the database.
	/// </summary>
	/// <value><c>true</c> if the collection is loaded; otherwise, <c>false</c>.</value>
	public bool IsLoaded => _internalCollectionEntry.IsLoaded;

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> to which this navigation property belongs.
	/// </summary>
	/// <value>An entry for the entity that owns this navigation property.</value>
	public override DbEntityEntry EntityEntry => new DbEntityEntry(_internalCollectionEntry.InternalEntityEntry);

	/// <summary>
	///     Gets the <see cref="T:System.Data.Entity.Internal.InternalCollectionEntry" /> backing this object as an <see cref="P:System.Data.Entity.Infrastructure.DbCollectionEntry.InternalMemberEntry" />.
	/// </summary>
	/// <value>The internal member entry.</value>
	internal override InternalMemberEntry InternalMemberEntry => _internalCollectionEntry;

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry" /> from information in the given <see cref="T:System.Data.Entity.Internal.InternalCollectionEntry" />.
	///     Use this method in preference to the constructor since it may potentially create a subclass depending on
	///     the type of member represented by the InternalCollectionEntry instance.
	/// </summary>
	/// <param name="internalCollectionEntry">The internal collection entry.</param>
	/// <returns>The new entry.</returns>
	internal static DbCollectionEntry Create(InternalCollectionEntry internalCollectionEntry)
	{
		return (DbCollectionEntry)internalCollectionEntry.CreateDbMemberEntry();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry" /> class.
	/// </summary>
	/// <param name="internalCollectionEntry">The internal entry.</param>
	internal DbCollectionEntry(InternalCollectionEntry internalCollectionEntry)
	{
		_internalCollectionEntry = internalCollectionEntry;
	}

	/// <summary>
	///     Loads the collection of entities from the database.
	///     Note that entities that already exist in the context are not overwritten with values from the database.
	/// </summary>
	public void Load()
	{
		_internalCollectionEntry.Load();
	}

	/// <summary>
	///     Returns the query that would be used to load this collection from the database.
	///     The returned query can be modified using LINQ to perform filtering or operations in the database, such
	///     as counting the number of entities in the collection in the database without actually loading them.
	/// </summary>
	/// <returns>A query for the collection.</returns>
	public IQueryable Query()
	{
		return _internalCollectionEntry.Query();
	}

	/// <summary>
	///     Returns the equivalent generic <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" /> object.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity on which the member is declared.</typeparam>
	/// <typeparam name="TElement">The type of the collection element.</typeparam>
	/// <returns>The equivalent generic object.</returns>
	public new DbCollectionEntry<TEntity, TElement> Cast<TEntity, TElement>() where TEntity : class
	{
		MemberEntryMetadata entryMetadata = _internalCollectionEntry.EntryMetadata;
		if (!typeof(TEntity).IsAssignableFrom(entryMetadata.DeclaringType) || !typeof(TElement).IsAssignableFrom(entryMetadata.ElementType))
		{
			throw Error.DbMember_BadTypeForCast(typeof(DbCollectionEntry).Name, typeof(TEntity).Name, typeof(TElement).Name, entryMetadata.DeclaringType.Name, entryMetadata.ElementType.Name);
		}
		return DbCollectionEntry<TEntity, TElement>.Create(_internalCollectionEntry);
	}
}
