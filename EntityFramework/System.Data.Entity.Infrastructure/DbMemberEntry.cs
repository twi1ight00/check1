using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Internal;
using System.Data.Entity.Resources;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     This is an abstract base class use to represent a scalar or complex property, or a navigation property
///     of an entity.  Scalar and complex properties use the derived class <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" />,
///     reference navigation properties use the derived class <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry" />, and collection
///     navigation properties use the derived class <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry" />.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public abstract class DbMemberEntry
{
	/// <summary>
	///     Gets the name of the property.
	/// </summary>
	/// <value>The property name.</value>
	public abstract string Name { get; }

	/// <summary>
	///     Gets or sets the current value of this property.
	/// </summary>
	/// <value>The current value.</value>
	public abstract object CurrentValue { get; set; }

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> to which this member belongs.
	/// </summary>
	/// <value>An entry for the entity that owns this member.</value>
	public abstract DbEntityEntry EntityEntry { get; }

	/// <summary>
	///     Gets the <see cref="P:System.Data.Entity.Infrastructure.DbMemberEntry.InternalMemberEntry" /> backing this object.
	/// </summary>
	/// <value>The internal member entry.</value>
	internal abstract InternalMemberEntry InternalMemberEntry { get; }

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry" /> from information in the given <see cref="P:System.Data.Entity.Infrastructure.DbMemberEntry.InternalMemberEntry" />.
	///     This method will create an instance of the appropriate subclass depending on the metadata contained
	///     in the InternalMemberEntry instance.
	/// </summary>
	/// <param name="internalMemberEntry">The internal member entry.</param>
	/// <returns>The new entry.</returns>
	internal static DbMemberEntry Create(InternalMemberEntry internalMemberEntry)
	{
		return internalMemberEntry.CreateDbMemberEntry();
	}

	/// <summary>
	///     Validates this property.
	/// </summary>
	/// <returns>
	///     Collection of <see cref="T:System.Data.Entity.Validation.DbValidationError" /> objects. Never null. If the entity is valid the collection will be empty.
	/// </returns>
	public ICollection<DbValidationError> GetValidationErrors()
	{
		return InternalMemberEntry.GetValidationErrors().ToList();
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

	/// <summary>
	///     Returns the equivalent generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry`2" /> object.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity on which the member is declared.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <returns>The equivalent generic object.</returns>
	public DbMemberEntry<TEntity, TProperty> Cast<TEntity, TProperty>() where TEntity : class
	{
		MemberEntryMetadata entryMetadata = InternalMemberEntry.EntryMetadata;
		if (!typeof(TEntity).IsAssignableFrom(entryMetadata.DeclaringType) || !typeof(TProperty).IsAssignableFrom(entryMetadata.MemberType))
		{
			throw Error.DbMember_BadTypeForCast(typeof(DbMemberEntry).Name, typeof(TEntity).Name, typeof(TProperty).Name, entryMetadata.DeclaringType.Name, entryMetadata.MemberType.Name);
		}
		return DbMemberEntry<TEntity, TProperty>.Create(InternalMemberEntry);
	}
}
/// <summary>
///     This is an abstract base class use to represent a scalar or complex property, or a navigation property
///     of an entity.  Scalar and complex properties use the derived class <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry`2" />,
///     reference navigation properties use the derived class <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry`2" />, and collection
///     navigation properties use the derived class <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" />.
/// </summary>
/// <typeparam name="TEntity">The type of the entity to which this property belongs.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public abstract class DbMemberEntry<TEntity, TProperty> where TEntity : class
{
	public abstract string Name { get; }

	/// <summary>
	///     Gets or sets the current value of this property.
	/// </summary>
	/// <value>The current value.</value>
	public abstract TProperty CurrentValue { get; set; }

	/// <summary>
	///     Gets the underlying <see cref="P:System.Data.Entity.Infrastructure.DbMemberEntry`2.InternalMemberEntry" />.
	/// </summary>
	/// <value>The internal member entry.</value>
	internal abstract InternalMemberEntry InternalMemberEntry { get; }

	/// <summary>
	///     The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> to which this member belongs.
	/// </summary>
	/// <value>An entry for the entity that owns this member.</value>
	public abstract DbEntityEntry<TEntity> EntityEntry { get; }

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry`2" /> from information in the given <see cref="P:System.Data.Entity.Infrastructure.DbMemberEntry`2.InternalMemberEntry" />.
	///     This method will create an instance of the appropriate subclass depending on the metadata contained
	///     in the InternalMemberEntry instance.
	/// </summary>
	/// <param name="internalMemberEntry">The internal member entry.</param>
	/// <returns>The new entry.</returns>
	internal static DbMemberEntry<TEntity, TProperty> Create(InternalMemberEntry internalMemberEntry)
	{
		return internalMemberEntry.CreateDbMemberEntry<TEntity, TProperty>();
	}

	/// <summary>
	///     Returns a new instance of the non-generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry" /> class for 
	///     the property represented by this object.
	/// </summary>
	/// <returns>A non-generic version.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Intentionally just implicit to reduce API clutter.")]
	public static implicit operator DbMemberEntry(DbMemberEntry<TEntity, TProperty> entry)
	{
		return DbMemberEntry.Create(entry.InternalMemberEntry);
	}

	/// <summary>
	///     Validates this property.
	/// </summary>
	/// <returns>
	///     Collection of <see cref="T:System.Data.Entity.Validation.DbValidationError" /> objects. Never null. If the entity is valid the collection will be empty.
	/// </returns>
	public ICollection<DbValidationError> GetValidationErrors()
	{
		return InternalMemberEntry.GetValidationErrors().ToList();
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
