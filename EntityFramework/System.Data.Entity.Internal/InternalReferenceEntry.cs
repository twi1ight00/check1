using System.Collections;
using System.Collections.Concurrent;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Resources;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.Internal;

/// <summary>
///     The internal class used to implement <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry" />,
///     and <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry`2" />.
///     This internal class contains all the common implementation between the generic and non-generic
///     entry classes and also allows for a clean internal factoring without compromising the public API.
/// </summary>
internal class InternalReferenceEntry : InternalNavigationEntry
{
	private static readonly ConcurrentDictionary<Type, Action<IRelatedEnd, object>> EntityReferenceValueSetters = new ConcurrentDictionary<Type, Action<IRelatedEnd, object>>();

	private static readonly MethodInfo SetValueOnEntityReferenceMethod = typeof(InternalReferenceEntry).GetMethod("SetValueOnEntityReference", BindingFlags.Static | BindingFlags.NonPublic);

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
			if (base.RelatedEnd != null && InternalEntityEntry.State != EntityState.Deleted)
			{
				SetNavigationPropertyOnRelatedEnd(value);
				return;
			}
			if (base.Setter != null)
			{
				base.Setter(InternalEntityEntry.Entity, value);
				return;
			}
			if (InternalEntityEntry.State == EntityState.Detached)
			{
				_ = 1;
			}
			else
				_ = InternalEntityEntry.State == EntityState.Deleted;
			throw Error.DbPropertyEntry_SettingEntityRefNotSupported(Name, InternalEntityEntry.EntityType.Name, InternalEntityEntry.State);
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalReferenceEntry" /> class.
	/// </summary>
	/// <param name="internalEntityEntry">The internal entity entry.</param>
	/// <param name="navigationMetadata">The navigation metadata.</param>
	public InternalReferenceEntry(InternalEntityEntry internalEntityEntry, NavigationEntryMetadata navigationMetadata)
		: base(internalEntityEntry, navigationMetadata)
	{
	}

	/// <summary>
	///     Gets the navigation property value from the <see cref="T:System.Data.Objects.DataClasses.IRelatedEnd" /> object.
	///     For reference navigation properties, this means getting the value from the
	///     <see cref="T:System.Data.Objects.DataClasses.EntityReference`1" /> object.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns>The navigation property value.</returns>
	protected override object GetNavigationPropertyFromRelatedEnd(object entity)
	{
		IEnumerator enumerator = base.RelatedEnd.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return null;
		}
		return enumerator.Current;
	}

	/// <summary>
	///     Sets the navigation property value onto the <see cref="T:System.Data.Objects.DataClasses.IRelatedEnd" /> object.
	///     For reference navigation properties, this means setting the value onto the
	///     <see cref="T:System.Data.Objects.DataClasses.EntityReference`1" /> object.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <param name="value">The value.</param>
	protected virtual void SetNavigationPropertyOnRelatedEnd(object value)
	{
		Type type = base.RelatedEnd.GetType();
		if (!EntityReferenceValueSetters.TryGetValue(type, out var value2))
		{
			MethodInfo method = SetValueOnEntityReferenceMethod.MakeGenericMethod(type.GetGenericArguments().Single());
			value2 = (Action<IRelatedEnd, object>)Delegate.CreateDelegate(typeof(Action<IRelatedEnd, object>), method);
			EntityReferenceValueSetters.TryAdd(type, value2);
		}
		value2(base.RelatedEnd, value);
	}

	/// <summary>
	///     Sets the given value on the given <see cref="T:System.Data.Objects.DataClasses.IRelatedEnd" /> which must be an
	///     <see cref="T:System.Data.Objects.DataClasses.EntityReference`1" />.
	///     This method is setup in such a way that it can easily be used by CreateDelegate without any
	///     dynamic code generation needed.
	/// </summary>
	/// <typeparam name="TRelatedEntity">The type of the related entity.</typeparam>
	/// <param name="entityReference">The entity reference.</param>
	/// <param name="value">The value.</param>
	private static void SetValueOnEntityReference<TRelatedEntity>(IRelatedEnd entityReference, object value) where TRelatedEntity : class
	{
		((EntityReference<TRelatedEntity>)entityReference).Value = (TRelatedEntity)value;
	}

	/// <summary>
	///     Creates a new non-generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry" /> backed by this internal entry.
	///     The runtime type of the DbMemberEntry created will be <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry" /> or a subtype of it.
	/// </summary>
	/// <returns>The new entry.</returns>
	public override DbMemberEntry CreateDbMemberEntry()
	{
		return new DbReferenceEntry(this);
	}

	/// <summary>
	///     Creates a new generic <see cref="T:System.Data.Entity.Infrastructure.DbMemberEntry`2" /> backed by this internal entry.
	///     The runtime type of the DbMemberEntry created will be <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry`2" /> or a subtype of it.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <returns>The new entry.</returns>
	public override DbMemberEntry<TEntity, TProperty> CreateDbMemberEntry<TEntity, TProperty>()
	{
		return new DbReferenceEntry<TEntity, TProperty>(this);
	}
}
