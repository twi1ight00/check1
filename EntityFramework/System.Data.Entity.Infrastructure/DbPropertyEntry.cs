using System.Data.Entity.Internal;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     A non-generic version of the <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry`2" /> class.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbPropertyEntry : DbMemberEntry
{
	private readonly InternalPropertyEntry _internalPropertyEntry;

	/// <summary>
	///     Gets the property name.
	/// </summary>
	/// <value>The property name.</value>
	public override string Name => _internalPropertyEntry.Name;

	/// <summary>
	///     Gets or sets the original value of this property.
	/// </summary>
	/// <value>The original value.</value>
	public object OriginalValue
	{
		get
		{
			return _internalPropertyEntry.OriginalValue;
		}
		set
		{
			_internalPropertyEntry.OriginalValue = value;
		}
	}

	/// <summary>
	///     Gets or sets the current value of this property.
	/// </summary>
	/// <value>The current value.</value>
	public override object CurrentValue
	{
		get
		{
			return _internalPropertyEntry.CurrentValue;
		}
		set
		{
			_internalPropertyEntry.CurrentValue = value;
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether the value of this property has been modified since
	///     it was loaded from the database.
	/// </summary>
	/// <value>
	///     <c>true</c> if this instance is modified; otherwise, <c>false</c>.
	/// </value>
	public bool IsModified
	{
		get
		{
			return _internalPropertyEntry.IsModified;
		}
		set
		{
			_internalPropertyEntry.IsModified = value;
		}
	}

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> to which this property belongs.
	/// </summary>
	/// <value>An entry for the entity that owns this property.</value>
	public override DbEntityEntry EntityEntry => new DbEntityEntry(_internalPropertyEntry.InternalEntityEntry);

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" /> of the property for which this is a nested property.
	///     This method will only return a non-null entry for properties of complex objects; it will
	///     return null for properties of the entity itself.
	/// </summary>
	/// <value>An entry for the parent complex property, or null if this is an entity property.</value>
	public DbComplexPropertyEntry ParentProperty
	{
		get
		{
			InternalPropertyEntry parentPropertyEntry = _internalPropertyEntry.ParentPropertyEntry;
			if (parentPropertyEntry == null)
			{
				return null;
			}
			return DbComplexPropertyEntry.Create(parentPropertyEntry);
		}
	}

	/// <summary>
	///     Gets the <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" /> backing this object.
	/// </summary>
	/// <value>The internal member entry.</value>
	internal override InternalMemberEntry InternalMemberEntry => _internalPropertyEntry;

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" /> from information in the given <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" />.
	///     Use this method in preference to the constructor since it may potentially create a subclass depending on
	///     the type of member represented by the InternalCollectionEntry instance.
	/// </summary>
	/// <param name="internalPropertyEntry">The internal property entry.</param>
	/// <returns>The new entry.</returns>
	internal static DbPropertyEntry Create(InternalPropertyEntry internalPropertyEntry)
	{
		return (DbPropertyEntry)internalPropertyEntry.CreateDbMemberEntry();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" /> class.
	/// </summary>
	/// <param name="internalPropertyEntry">The internal entry.</param>
	internal DbPropertyEntry(InternalPropertyEntry internalPropertyEntry)
	{
		_internalPropertyEntry = internalPropertyEntry;
	}

	/// <summary>
	///     Returns the equivalent generic <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry`2" /> object.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity on which the member is declared.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <returns>The equivalent generic object.</returns>
	public new DbPropertyEntry<TEntity, TProperty> Cast<TEntity, TProperty>() where TEntity : class
	{
		PropertyEntryMetadata entryMetadata = _internalPropertyEntry.EntryMetadata;
		if (!typeof(TEntity).IsAssignableFrom(entryMetadata.DeclaringType) || !typeof(TProperty).IsAssignableFrom(entryMetadata.ElementType))
		{
			throw Error.DbMember_BadTypeForCast(typeof(DbPropertyEntry).Name, typeof(TEntity).Name, typeof(TProperty).Name, entryMetadata.DeclaringType.Name, entryMetadata.MemberType.Name);
		}
		return DbPropertyEntry<TEntity, TProperty>.Create(_internalPropertyEntry);
	}
}
/// <summary>
///     Instances of this class are returned from the Property method of
///     <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> and allow access to the state of the scalar
///     or complex property.
/// </summary>
/// <typeparam name="TEntity">The type of the entity to which this property belongs.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbPropertyEntry<TEntity, TProperty> : DbMemberEntry<TEntity, TProperty> where TEntity : class
{
	private readonly InternalPropertyEntry _internalPropertyEntry;

	/// <summary>
	///     Gets the property name.
	/// </summary>
	/// <value>The property name.</value>
	public override string Name => _internalPropertyEntry.Name;

	/// <summary>
	///     Gets or sets the original value of this property.
	/// </summary>
	/// <value>The original value.</value>
	public TProperty OriginalValue
	{
		get
		{
			return (TProperty)_internalPropertyEntry.OriginalValue;
		}
		set
		{
			_internalPropertyEntry.OriginalValue = value;
		}
	}

	/// <summary>
	///     Gets or sets the current value of this property.
	/// </summary>
	/// <value>The current value.</value>
	public override TProperty CurrentValue
	{
		get
		{
			return (TProperty)_internalPropertyEntry.CurrentValue;
		}
		set
		{
			_internalPropertyEntry.CurrentValue = value;
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether the value of this property has been modified since
	///     it was loaded from the database.
	/// </summary>
	/// <value>
	///     <c>true</c> if this instance is modified; otherwise, <c>false</c>.
	/// </value>
	public bool IsModified
	{
		get
		{
			return _internalPropertyEntry.IsModified;
		}
		set
		{
			_internalPropertyEntry.IsModified = value;
		}
	}

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> to which this property belongs.
	/// </summary>
	/// <value>An entry for the entity that owns this property.</value>
	public override DbEntityEntry<TEntity> EntityEntry => new DbEntityEntry<TEntity>(_internalPropertyEntry.InternalEntityEntry);

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" /> of the property for which this is a nested property.
	///     This method will only return a non-null entry for properties of complex objects; it will
	///     return null for properties of the entity itself.
	/// </summary>
	/// <value>An entry for the parent complex property, or null if this is an entity property.</value>
	public DbComplexPropertyEntry ParentProperty
	{
		get
		{
			InternalPropertyEntry parentPropertyEntry = _internalPropertyEntry.ParentPropertyEntry;
			if (parentPropertyEntry == null)
			{
				return null;
			}
			return DbComplexPropertyEntry.Create(parentPropertyEntry);
		}
	}

	internal InternalPropertyEntry InternalPropertyEntry => _internalPropertyEntry;

	/// <summary>
	///     Gets the underlying <see cref="P:System.Data.Entity.Infrastructure.DbPropertyEntry`2.InternalPropertyEntry" /> as an <see cref="P:System.Data.Entity.Infrastructure.DbPropertyEntry`2.InternalMemberEntry" />.
	/// </summary>
	/// <value>The internal member entry.</value>
	internal override InternalMemberEntry InternalMemberEntry => InternalPropertyEntry;

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry`2" /> from information in the given <see cref="P:System.Data.Entity.Infrastructure.DbPropertyEntry`2.InternalPropertyEntry" />.
	///     Use this method in preference to the constructor since it may potentially create a subclass depending on
	///     the type of member represented by the InternalCollectionEntry instance.
	/// </summary>
	/// <param name="internalPropertyEntry">The internal property entry.</param>
	/// <returns>The new entry.</returns>
	internal static DbPropertyEntry<TEntity, TProperty> Create(InternalPropertyEntry internalPropertyEntry)
	{
		return (DbPropertyEntry<TEntity, TProperty>)internalPropertyEntry.CreateDbMemberEntry<TEntity, TProperty>();
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry`2" /> class.
	/// </summary>
	/// <param name="internalPropertyEntry">The internal entry.</param>
	internal DbPropertyEntry(InternalPropertyEntry internalPropertyEntry)
	{
		_internalPropertyEntry = internalPropertyEntry;
	}

	/// <summary>
	///     Returns a new instance of the non-generic <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" /> class for 
	///     the property represented by this object.
	/// </summary>
	/// <returns>A non-generic version.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Intentionally just implicit to reduce API clutter.")]
	public static implicit operator DbPropertyEntry(DbPropertyEntry<TEntity, TProperty> entry)
	{
		return DbPropertyEntry.Create(entry._internalPropertyEntry);
	}
}
