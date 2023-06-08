using System.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     A concrete implementation of <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" /> used for properties of entities.
/// </summary>
internal class InternalEntityPropertyEntry : InternalPropertyEntry
{
	/// <summary>
	///     Returns parent property, or null if this is a property on the top-level entity.
	/// </summary>
	public override InternalPropertyEntry ParentPropertyEntry => null;

	/// <summary>
	///     Gets the current values of the parent entity.
	///     That is, the current values that contains the value for this property.
	/// </summary>
	/// <value>The parent current values.</value>
	public override InternalPropertyValues ParentCurrentValues => InternalEntityEntry.CurrentValues;

	/// <summary>
	///     Gets the original values of the parent entity.
	///     That is, the original values that contains the value for this property.
	/// </summary>
	/// <value>The parent original values.</value>
	public override InternalPropertyValues ParentOriginalValues => InternalEntityEntry.OriginalValues;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalEntityPropertyEntry" /> class.
	/// </summary>
	/// <param name="internalEntityEntry">The internal entry.</param>
	/// <param name="propertyMetadata">The property info.</param>
	public InternalEntityPropertyEntry(InternalEntityEntry internalEntityEntry, PropertyEntryMetadata propertyMetadata)
		: base(internalEntityEntry, propertyMetadata)
	{
	}

	/// <summary>
	///     Creates a delegate that will get the value of this property.
	/// </summary>
	/// <returns>The delegate.</returns>
	protected override Func<object, object> CreateGetter()
	{
		DbHelpers.GetPropertyGetters(InternalEntityEntry.EntityType).TryGetValue(Name, out var value);
		return value;
	}

	/// <summary>
	///     Creates a delegate that will set the value of this property.
	/// </summary>
	/// <returns>The delegate.</returns>
	protected override Action<object, object> CreateSetter()
	{
		DbHelpers.GetPropertySetters(InternalEntityEntry.EntityType).TryGetValue(Name, out var value);
		return value;
	}

	/// <summary>
	///     Returns true if the property of the entity that this property is ultimately part
	///     of is set as modified.  Since this is a property of an entity this method returns
	///     true if the property is modified.
	/// </summary>
	/// <returns>True if the entity property is modified.</returns>
	public override bool EntityPropertyIsModified()
	{
		return InternalEntityEntry.ObjectStateEntry.GetModifiedProperties().Contains(Name);
	}

	/// <summary>
	///     Sets the property of the entity that this property is ultimately part of to modified.
	///     Since this is a property of an entity this method marks it as modified.
	/// </summary>
	public override void SetEntityPropertyModified()
	{
		InternalEntityEntry.ObjectStateEntry.SetModifiedProperty(Name);
	}
}
