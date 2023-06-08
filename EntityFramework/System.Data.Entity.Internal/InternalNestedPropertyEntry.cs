namespace System.Data.Entity.Internal;

/// <summary>
///     A concrete implementation of <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" /> used for properties of complex objects.
/// </summary>
internal class InternalNestedPropertyEntry : InternalPropertyEntry
{
	private readonly InternalPropertyEntry _parentPropertyEntry;

	/// <summary>
	///     Returns parent property, or null if this is a property on the top-level entity.
	/// </summary>
	public override InternalPropertyEntry ParentPropertyEntry => _parentPropertyEntry;

	/// <summary>
	///     Gets the current values of the parent complex property.
	///     That is, the current values that contains the value for this property.
	/// </summary>
	/// <value>The parent current values.</value>
	public override InternalPropertyValues ParentCurrentValues
	{
		get
		{
			object obj = _parentPropertyEntry.ParentCurrentValues[_parentPropertyEntry.Name];
			return (InternalPropertyValues)obj;
		}
	}

	/// <summary>
	///     Gets the original values of the parent complex property.
	///     That is, the original values that contains the value for this property.
	/// </summary>
	/// <value>The parent original values.</value>
	public override InternalPropertyValues ParentOriginalValues
	{
		get
		{
			object obj = _parentPropertyEntry.ParentOriginalValues[_parentPropertyEntry.Name];
			return (InternalPropertyValues)obj;
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalNestedPropertyEntry" /> class.
	/// </summary>
	/// <param name="parentPropertyEntry">The parent property entry.</param>
	/// <param name="propertyMetadata">The property metadata.</param>
	public InternalNestedPropertyEntry(InternalPropertyEntry parentPropertyEntry, PropertyEntryMetadata propertyMetadata)
		: base(parentPropertyEntry.InternalEntityEntry, propertyMetadata)
	{
		_parentPropertyEntry = parentPropertyEntry;
	}

	/// <summary>
	///     Creates a delegate that will get the value of this property.
	/// </summary>
	/// <returns>The delegate.</returns>
	protected override Func<object, object> CreateGetter()
	{
		Func<object, object> parentGetter = _parentPropertyEntry.Getter;
		if (parentGetter == null)
		{
			return null;
		}
		if (!DbHelpers.GetPropertyGetters(base.EntryMetadata.DeclaringType).TryGetValue(Name, out var getter))
		{
			return null;
		}
		return (object o) => getter(parentGetter(o));
	}

	/// <summary>
	///     Creates a delegate that will set the value of this property.
	/// </summary>
	/// <returns>The delegate.</returns>
	protected override Action<object, object> CreateSetter()
	{
		Func<object, object> parentGetter = _parentPropertyEntry.Getter;
		if (parentGetter == null)
		{
			return null;
		}
		if (!DbHelpers.GetPropertySetters(base.EntryMetadata.DeclaringType).TryGetValue(Name, out var setter))
		{
			return null;
		}
		return delegate(object o, object v)
		{
			setter(parentGetter(o), v);
		};
	}

	/// <summary>
	///     Returns true if the property of the entity that this property is ultimately part
	///     of is set as modified.  Since this is a property of a complex object
	///     this method returns true if the top-level complex property on the entity is modified.
	/// </summary>
	/// <returns>True if the entity property is modified.</returns>
	public override bool EntityPropertyIsModified()
	{
		return _parentPropertyEntry.EntityPropertyIsModified();
	}

	/// <summary>
	///     Sets the property of the entity that this property is ultimately part of to modified.
	///     Since this is a property of a complex object this method marks the top-level
	///     complex property as modified.
	/// </summary>
	public override void SetEntityPropertyModified()
	{
		_parentPropertyEntry.SetEntityPropertyModified();
	}
}
