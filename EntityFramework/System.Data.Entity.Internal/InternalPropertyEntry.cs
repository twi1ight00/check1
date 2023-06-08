using System.Data.Entity.Infrastructure;
using System.Data.Entity.Resources;

namespace System.Data.Entity.Internal;

/// <summary>
///     The internal class used to implement <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" /> and 
///     <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry`2" />.
///     This internal class contains all the common implementation between the generic and non-generic
///     entry classes and also allows for a clean internal factoring without compromising the public API.
/// </summary>
internal abstract class InternalPropertyEntry : InternalMemberEntry
{
	private bool _getterIsCached;

	private Func<object, object> _getter;

	private bool _setterIsCached;

	private Action<object, object> _setter;

	/// <summary>
	///     Returns parent property, or null if this is a property on the top-level entity.
	/// </summary>
	public abstract InternalPropertyEntry ParentPropertyEntry { get; }

	/// <summary>
	///     Gets the current values of the parent entity or complex property.
	///     That is, the current values that contains the value for this property.
	/// </summary>
	/// <value>The parent current values.</value>
	public abstract InternalPropertyValues ParentCurrentValues { get; }

	/// <summary>
	///     Gets the original values of the parent entity or complex property.
	///     That is, the original values that contains the value for this property.
	/// </summary>
	/// <value>The parent original values.</value>
	public abstract InternalPropertyValues ParentOriginalValues { get; }

	/// <summary>
	///     A delegate that reads the value of this property.
	///     May be null if there is no way to set the value due to missing accessors on the type.
	/// </summary>
	public Func<object, object> Getter
	{
		get
		{
			if (!_getterIsCached)
			{
				_getter = CreateGetter();
				_getterIsCached = true;
			}
			return _getter;
		}
	}

	/// <summary>
	///     A delegate that sets the value of this property.
	///     May be null if there is no way to set the value due to missing accessors on the type.
	/// </summary>
	public Action<object, object> Setter
	{
		get
		{
			if (!_setterIsCached)
			{
				_setter = CreateSetter();
				_setterIsCached = true;
			}
			return _setter;
		}
	}

	/// <summary>
	///     Gets or sets the original value.
	///     Note that complex properties are returned as objects, not property values.
	/// </summary>
	public object OriginalValue
	{
		get
		{
			ValidateNotDetachedAndInModel("OriginalValue");
			object obj = ParentOriginalValues[Name];
			if (obj is InternalPropertyValues internalPropertyValues)
			{
				obj = internalPropertyValues.ToObject();
			}
			return obj;
		}
		set
		{
			ValidateNotDetachedAndInModel("OriginalValue");
			CheckNotSettingComplexPropertyToNull(value);
			SetPropertyValueUsingValues(ParentOriginalValues, value);
		}
	}

	/// <summary>
	///     Gets or sets the current value.
	///     Note that complex properties are returned as objects, not property values.
	///     Also, for complex properties, the object returned is the actual complex object from the entity
	///     and setting the complex object causes the actual object passed to be set onto the entity.
	/// </summary>
	/// <value>The current value.</value>
	public override object CurrentValue
	{
		get
		{
			if (Getter != null)
			{
				return Getter(InternalEntityEntry.Entity);
			}
			if (!InternalEntityEntry.IsDetached && EntryMetadata.IsMapped)
			{
				object obj = ParentCurrentValues[Name];
				if (obj is InternalPropertyValues internalPropertyValues)
				{
					obj = internalPropertyValues.ToObject();
				}
				return obj;
			}
			throw Error.DbPropertyEntry_CannotGetCurrentValue(Name, base.EntryMetadata.DeclaringType.Name);
		}
		set
		{
			CheckNotSettingComplexPropertyToNull(value);
			if (!EntryMetadata.IsMapped || InternalEntityEntry.IsDetached || InternalEntityEntry.State == EntityState.Deleted)
			{
				if (!SetCurrentValueOnClrObject(value))
				{
					throw Error.DbPropertyEntry_CannotSetCurrentValue(Name, base.EntryMetadata.DeclaringType.Name);
				}
				return;
			}
			SetPropertyValueUsingValues(ParentCurrentValues, value);
			if (EntryMetadata.IsComplex)
			{
				SetCurrentValueOnClrObject(value);
			}
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether this property is modified.
	/// </summary>
	public bool IsModified
	{
		get
		{
			if (InternalEntityEntry.IsDetached || !EntryMetadata.IsMapped)
			{
				return false;
			}
			return EntityPropertyIsModified();
		}
		set
		{
			ValidateNotDetachedAndInModel("IsModified");
			if (value)
			{
				SetEntityPropertyModified();
			}
			else if (IsModified)
			{
				throw Error.DbPropertyEntry_CannotMarkPropertyUnmodified();
			}
		}
	}

	/// <summary>
	///     Gets the property metadata.
	/// </summary>
	/// <value>The property metadata.</value>
	public new PropertyEntryMetadata EntryMetadata => (PropertyEntryMetadata)base.EntryMetadata;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" /> class.
	/// </summary>
	/// <param name="internalEntityEntry">The internal entry.</param>
	/// <param name="propertyMetadata">The property info.</param>
	protected InternalPropertyEntry(InternalEntityEntry internalEntityEntry, PropertyEntryMetadata propertyMetadata)
		: base(internalEntityEntry, propertyMetadata)
	{
	}

	/// <summary>
	///     Creates a delegate that will get the value of this property.
	/// </summary>
	/// <returns>The delegate.</returns>
	protected abstract Func<object, object> CreateGetter();

	/// <summary>
	///     Creates a delegate that will set the value of this property.
	/// </summary>
	/// <returns>The delegate.</returns>
	protected abstract Action<object, object> CreateSetter();

	/// <summary>
	///     Returns true if the property of the entity that this property is ultimately part
	///     of is set as modified.  If this is a property of an entity, then this method returns
	///     true if the property is modified.  If this is a property of a complex object, then
	///     this method returns true if the top-level complex property on the entity is modified.
	/// </summary>
	/// <returns>True if the entity property is modified.</returns>
	public abstract bool EntityPropertyIsModified();

	/// <summary>
	///     Sets the property of the entity that this property is ultimately part of to modified.
	///     If this is a property of an entity, then this method marks it as modified.
	///     If this is a property of a complex object, then this method marks the top-level
	///     complex property as modified.
	/// </summary>
	public abstract void SetEntityPropertyModified();

	/// <summary>
	///     Throws if the user attempts to set a complex property to null.
	/// </summary>
	/// <param name="value">The value.</param>
	private void CheckNotSettingComplexPropertyToNull(object value)
	{
		if (value == null && EntryMetadata.IsComplex)
		{
			throw Error.DbPropertyValues_ComplexObjectCannotBeNull(Name, base.EntryMetadata.DeclaringType.Name);
		}
	}

	/// <summary>
	///     Sets the given value directly onto the underlying entity object.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>True if the property had a setter that we could attempt to call; false if no setter was available.</returns>
	private bool SetCurrentValueOnClrObject(object value)
	{
		if (Setter == null)
		{
			return false;
		}
		if (Getter == null || !DbHelpers.KeyValuesEqual(value, Getter(InternalEntityEntry.Entity)))
		{
			Setter(InternalEntityEntry.Entity, value);
			if (EntryMetadata.IsMapped && (InternalEntityEntry.State == EntityState.Modified || InternalEntityEntry.State == EntityState.Unchanged))
			{
				IsModified = true;
			}
		}
		return true;
	}

	/// <summary>
	///     Sets the property value, potentially by setting individual nested values for a complex
	///     property.
	/// </summary>
	/// <param name="value">The value.</param>
	private void SetPropertyValueUsingValues(InternalPropertyValues internalValues, object value)
	{
		if (internalValues[Name] is InternalPropertyValues internalPropertyValues)
		{
			if (!internalPropertyValues.ObjectType.IsAssignableFrom(value.GetType()))
			{
				throw Error.DbPropertyValues_AttemptToSetValuesFromWrongObject(value.GetType().Name, internalPropertyValues.ObjectType.Name);
			}
			internalPropertyValues.SetValues(value);
		}
		else
		{
			internalValues[Name] = value;
		}
	}

	/// <summary>
	///     Gets an internal object representing a scalar or complex property of this property,
	///     which must be a mapped complex property.
	///     This method is virtual to allow mocking.
	/// </summary>
	/// <param name="property">The property.</param>
	/// <param name="requestedType">The type of object requested, which may be null or 'object' if any type can be accepted.</param>
	/// <param name="requireComplex">if set to <c>true</c> then the found property must be a complex property.</param>
	/// <returns>The entry.</returns>
	public virtual InternalPropertyEntry Property(string property, Type requestedType = null, bool requireComplex = false)
	{
		if (EntryMetadata.IsMapped)
		{
			_ = EntryMetadata.IsComplex;
		}
		else
			_ = 0;
		return InternalEntityEntry.Property(this, property, requestedType ?? typeof(object), requireComplex);
	}

	/// <summary>
	///     Validates that the owning entity entry is associated with an underlying <see cref="T:System.Data.Objects.ObjectStateEntry" /> and
	///     is not just wrapping a non-attached entity.
	/// </summary>
	private void ValidateNotDetachedAndInModel(string method)
	{
		if (!EntryMetadata.IsMapped)
		{
			throw Error.DbPropertyEntry_NotSupportedForPropertiesNotInTheModel(method, base.EntryMetadata.MemberName, InternalEntityEntry.EntityType.Name);
		}
		if (InternalEntityEntry.IsDetached)
		{
			throw Error.DbPropertyEntry_NotSupportedForDetached(method, base.EntryMetadata.MemberName, InternalEntityEntry.EntityType.Name);
		}
	}

	/// <summary>
	///     Creates a new non-generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry" /> backed by this internal entry.
	///     The runtime type of the DbMemberEntry created will be <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" /> or a subtype of it.
	/// </summary>
	/// <returns>The new entry.</returns>
	public override DbMemberEntry CreateDbMemberEntry()
	{
		if (!EntryMetadata.IsComplex)
		{
			return new DbPropertyEntry(this);
		}
		return new DbComplexPropertyEntry(this);
	}

	/// <summary>
	///     Creates a new generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry`2" /> backed by this internal entry.
	///     The runtime type of the DbMemberEntry created will be <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry`2" /> or a subtype of it.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <returns>The new entry.</returns>
	public override DbMemberEntry<TEntity, TProperty> CreateDbMemberEntry<TEntity, TProperty>()
	{
		if (!EntryMetadata.IsComplex)
		{
			return new DbPropertyEntry<TEntity, TProperty>(this);
		}
		return new DbComplexPropertyEntry<TEntity, TProperty>(this);
	}
}
