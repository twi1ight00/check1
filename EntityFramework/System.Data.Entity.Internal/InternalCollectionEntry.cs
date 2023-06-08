using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Resources;
using System.Reflection;

namespace System.Data.Entity.Internal;

/// <summary>
///     The internal class used to implement <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry" /> and 
///     <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" />.
///     This internal class contains all the common implementation between the generic and non-generic
///     entry classes and also allows for a clean internal factoring without compromising the public API.
/// </summary>
internal class InternalCollectionEntry : InternalNavigationEntry
{
	private static readonly ConcurrentDictionary<Type, Func<InternalCollectionEntry, object>> EntryFactories = new ConcurrentDictionary<Type, Func<InternalCollectionEntry, object>>();

	/// <summary>
	///     Gets or sets the current value of the navigation property.  The current value is
	///     the entity that the navigation property references or the collection of references
	///     for a collection property.
	/// </summary>
	/// <value>The current value.</value>
	public override object CurrentValue
	{
		get
		{
			return base.CurrentValue;
		}
		set
		{
			if (base.Setter != null)
			{
				base.Setter(InternalEntityEntry.Entity, value);
			}
			else if (InternalEntityEntry.IsDetached || !object.ReferenceEquals(base.RelatedEnd, value))
			{
				throw Error.DbCollectionEntry_CannotSetCollectionProp(Name, InternalEntityEntry.Entity.GetType().ToString());
			}
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalCollectionEntry" /> class.
	/// </summary>
	/// <param name="internalEntityEntry">The internal entity entry.</param>
	/// <param name="navigationMetadata">The navigation metadata.</param>
	public InternalCollectionEntry(InternalEntityEntry internalEntityEntry, NavigationEntryMetadata navigationMetadata)
		: base(internalEntityEntry, navigationMetadata)
	{
	}

	/// <summary>
	///     Gets the navigation property value from the <see cref="T:System.Data.Objects.DataClasses.IRelatedEnd" /> object.
	///     Since for a collection the related end is an <see cref="T:System.Data.Objects.DataClasses.EntityCollection`1" />, it means
	///     that the internal representation of the navigation property is just the related end.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns>The navigation property value.</returns>
	protected override object GetNavigationPropertyFromRelatedEnd(object entity)
	{
		return base.RelatedEnd;
	}

	/// <summary>
	///     Creates a new non-generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry" /> backed by this internal entry.
	///     The runtime type of the DbMemberEntry created will be <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry" /> or a subtype of it.
	/// </summary>
	/// <returns>The new entry.</returns>
	public override DbMemberEntry CreateDbMemberEntry()
	{
		return new DbCollectionEntry(this);
	}

	/// <summary>
	///     Creates a new generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry`2" /> backed by this internal entry.
	///     The runtime type of the DbMemberEntry created will be <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" /> or a subtype of it.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <returns>The new entry.</returns>
	public override DbMemberEntry<TEntity, TProperty> CreateDbMemberEntry<TEntity, TProperty>()
	{
		return CreateDbCollectionEntry<TEntity, TProperty>(EntryMetadata.ElementType);
	}

	/// <summary>
	///     Creates a new generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry`2" /> backed by this internal entry.
	///     The actual subtype of the DbCollectionEntry created depends on the metadata of this internal entry.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TElement">The type of the element.</typeparam>
	/// <returns>The new entry.</returns>
	public virtual DbCollectionEntry<TEntity, TElement> CreateDbCollectionEntry<TEntity, TElement>() where TEntity : class
	{
		return new DbCollectionEntry<TEntity, TElement>(this);
	}

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" /> object for the given entity type
	///     and collection element type.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <param name="elementType">Type of the element.</param>
	/// <returns>The set.</returns>
	private DbMemberEntry<TEntity, TProperty> CreateDbCollectionEntry<TEntity, TProperty>(Type elementType) where TEntity : class
	{
		Type typeFromHandle = typeof(DbMemberEntry<TEntity, TProperty>);
		if (!EntryFactories.TryGetValue(typeFromHandle, out var value))
		{
			Type type = typeof(DbCollectionEntry<, >).MakeGenericType(typeof(TEntity), elementType);
			if (!typeFromHandle.IsAssignableFrom(type))
			{
				throw Error.DbEntityEntry_WrongGenericForCollectionNavProp(typeof(TProperty), Name, EntryMetadata.DeclaringType, typeof(ICollection<>).MakeGenericType(elementType));
			}
			MethodInfo method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.NonPublic, null, new Type[1] { typeof(InternalCollectionEntry) }, null);
			value = (Func<InternalCollectionEntry, object>)Delegate.CreateDelegate(typeof(Func<InternalCollectionEntry, object>), method);
			EntryFactories.TryAdd(typeFromHandle, value);
		}
		return (DbMemberEntry<TEntity, TProperty>)value(this);
	}
}
