using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Internal.Validation;
using System.Data.Entity.Validation;
using System.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     Base class for all internal entries that represent different kinds of properties.
/// </summary>
internal abstract class InternalMemberEntry
{
	private readonly InternalEntityEntry _internalEntityEntry;

	private readonly MemberEntryMetadata _memberMetadata;

	/// <summary>
	///     Gets the property name.
	///     The property is virtual to allow mocking.
	/// </summary>
	/// <value>The property name.</value>
	public virtual string Name => _memberMetadata.MemberName;

	/// <summary>
	///     Gets or sets the current value of the navigation property.
	/// </summary>
	/// <value>The current value.</value>
	public abstract object CurrentValue { get; set; }

	/// <summary>
	///     Gets the internal entity entry property belongs to.
	///     This property is virtual to allow mocking.
	/// </summary>
	/// <value>The internal entity entry.</value>
	public virtual InternalEntityEntry InternalEntityEntry => _internalEntityEntry;

	/// <summary>
	///     Gets the entry metadata.
	/// </summary>
	/// <value>The entry metadata.</value>
	public virtual MemberEntryMetadata EntryMetadata => _memberMetadata;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalMemberEntry" /> class.
	/// </summary>
	/// <param name="internalEntityEntry">The internal entity entry.</param>
	/// <param name="memberMetadata">The member metadata.</param>
	protected InternalMemberEntry(InternalEntityEntry internalEntityEntry, MemberEntryMetadata memberMetadata)
	{
		_internalEntityEntry = internalEntityEntry;
		_memberMetadata = memberMetadata;
	}

	/// <summary>
	///     Validates this property.
	/// </summary>
	/// <returns>A sequence of validation errors for this property. Empty if no errors. Never null.</returns>
	public virtual IEnumerable<DbValidationError> GetValidationErrors()
	{
		ValidationProvider validationProvider = InternalEntityEntry.InternalContext.ValidationProvider;
		PropertyValidator propertyValidator = validationProvider.GetPropertyValidator(_internalEntityEntry, this);
		if (propertyValidator == null)
		{
			return Enumerable.Empty<DbValidationError>();
		}
		return propertyValidator.Validate(validationProvider.GetEntityValidationContext(_internalEntityEntry, null), this);
	}

	/// <summary>
	///     Creates a new non-generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry" /> backed by this internal entry.
	///     The actual subtype of the DbMemberEntry created depends on the metadata of this internal entry.
	/// </summary>
	/// <returns>The new entry.</returns>
	public abstract DbMemberEntry CreateDbMemberEntry();

	/// <summary>
	///     Creates a new generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry`2" /> backed by this internal entry.
	///     The actual subtype of the DbMemberEntry created depends on the metadata of this internal entry.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <returns>The new entry.</returns>
	public abstract DbMemberEntry<TEntity, TProperty> CreateDbMemberEntry<TEntity, TProperty>() where TEntity : class;
}
