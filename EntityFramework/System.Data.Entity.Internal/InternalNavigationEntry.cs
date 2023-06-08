using System.Data.Entity.Resources;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     Base class for <see cref="T:System.Data.Entity.Internal.InternalCollectionEntry" /> and <see cref="T:System.Data.Entity.Internal.InternalReferenceEntry" />
///     containing common code for collection and reference navigation property entries.
/// </summary>
internal abstract class InternalNavigationEntry : InternalMemberEntry
{
	private IRelatedEnd _relatedEnd;

	private Func<object, object> _getter;

	private bool _triedToGetGetter;

	private Action<object, object> _setter;

	private bool _triedToGetSetter;

	/// <summary>
	///     Calls IsLoaded on the underlying <see cref="T:System.Data.Objects.DataClasses.IRelatedEnd" />.
	/// </summary>
	public bool IsLoaded
	{
		get
		{
			ValidateNotDetached("IsLoaded");
			return _relatedEnd.IsLoaded;
		}
	}

	/// <summary>
	///     Gets the related end, which will be null if the entity is not being tracked.
	/// </summary>
	/// <value>The related end.</value>
	protected IRelatedEnd RelatedEnd
	{
		get
		{
			if (_relatedEnd == null && !InternalEntityEntry.IsDetached)
			{
				_relatedEnd = InternalEntityEntry.GetRelatedEnd(Name);
			}
			return _relatedEnd;
		}
	}

	/// <summary>
	///     Gets or sets the current value of the navigation property.  The current value is
	///     the entity that the navigation property references or the collection of references
	///     for a collection property.
	///     This property is virtual so that it can be mocked.
	/// </summary>
	/// <value>The current value.</value>
	public override object CurrentValue
	{
		get
		{
			if (Getter == null)
			{
				ValidateNotDetached("CurrentValue");
				return GetNavigationPropertyFromRelatedEnd(InternalEntityEntry.Entity);
			}
			return Getter(InternalEntityEntry.Entity);
		}
	}

	/// <summary>
	///     Gets a delegate that can be used to get the value of the property directly from the entity.
	///     Returns null if the property does not have an accessible getter.
	/// </summary>
	/// <value>The getter delegate, or null.</value>
	protected Func<object, object> Getter
	{
		get
		{
			if (!_triedToGetGetter)
			{
				DbHelpers.GetPropertyGetters(InternalEntityEntry.EntityType).TryGetValue(Name, out _getter);
				_triedToGetGetter = true;
			}
			return _getter;
		}
	}

	/// <summary>
	///     Gets a delegate that can be used to set the value of the property directly on the entity.
	///     Returns null if the property does not have an accessible setter.
	/// </summary>
	/// <value>The setter delegate, or null.</value>
	protected Action<object, object> Setter
	{
		get
		{
			if (!_triedToGetSetter)
			{
				DbHelpers.GetPropertySetters(InternalEntityEntry.EntityType).TryGetValue(Name, out _setter);
				_triedToGetSetter = true;
			}
			return _setter;
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalNavigationEntry" /> class.
	/// </summary>
	/// <param name="internalEntityEntry">The internal entity entry.</param>
	/// <param name="navigationMetadata">The navigation metadata.</param>
	protected InternalNavigationEntry(InternalEntityEntry internalEntityEntry, NavigationEntryMetadata navigationMetadata)
		: base(internalEntityEntry, navigationMetadata)
	{
	}

	/// <summary>
	///     Calls Load on the underlying <see cref="T:System.Data.Objects.DataClasses.IRelatedEnd" />.
	/// </summary>
	public void Load()
	{
		ValidateNotDetached("Load");
		_relatedEnd.Load();
	}

	/// <summary>
	///     Uses CreateSourceQuery on the underlying <see cref="P:System.Data.Entity.Internal.InternalNavigationEntry.RelatedEnd" /> to create a query for this
	///     navigation property.
	/// </summary>
	public IQueryable Query()
	{
		ValidateNotDetached("Query");
		return (IQueryable)_relatedEnd.CreateSourceQuery();
	}

	/// <summary>
	///     Gets the navigation property value from the <see cref="T:System.Data.Objects.DataClasses.IRelatedEnd" /> object.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns>The navigation property value.</returns>
	protected abstract object GetNavigationPropertyFromRelatedEnd(object entity);

	/// <summary>
	///     Validates that the owning entity entry is associated with an underlying <see cref="T:System.Data.Objects.ObjectStateEntry" /> and
	///     is not just wrapping a non-attached entity.
	///     If the entity is not detached, then the RelatedEnd for this navigation property is obtained.
	/// </summary>
	private void ValidateNotDetached(string method)
	{
		if (_relatedEnd == null)
		{
			if (InternalEntityEntry.IsDetached)
			{
				throw Error.DbPropertyEntry_NotSupportedForDetached(method, Name, InternalEntityEntry.EntityType.Name);
			}
			_relatedEnd = InternalEntityEntry.GetRelatedEnd(Name);
		}
	}
}
