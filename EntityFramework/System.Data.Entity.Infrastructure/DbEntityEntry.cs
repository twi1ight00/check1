using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Instances of this class provide access to information about and control of entities that
///     are being tracked by the <see cref="T:System.Data.Entity.DbContext" />.  Use the Entity or Entities methods of
///     the context to obtain objects of this type.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbEntityEntry<TEntity> where TEntity : class
{
	private readonly InternalEntityEntry _internalEntityEntry;

	/// <summary>
	///     Gets the entity.
	/// </summary>
	/// <value>The entity.</value>
	public TEntity Entity => (TEntity)_internalEntityEntry.Entity;

	/// <summary>
	///     Gets or sets the state of the entity.
	/// </summary>
	/// <value>The state.</value>
	public EntityState State
	{
		get
		{
			return _internalEntityEntry.State;
		}
		set
		{
			_internalEntityEntry.State = value;
		}
	}

	/// <summary>
	///     Gets the current property values for the tracked entity represented by this object.
	/// </summary>
	/// <value>The current values.</value>
	public DbPropertyValues CurrentValues => new DbPropertyValues(_internalEntityEntry.CurrentValues);

	/// <summary>
	///     Gets the original property values for the tracked entity represented by this object.
	///     The original values are usually the entity's property values as they were when last queried from
	///     the database.
	/// </summary>
	/// <value>The original values.</value>
	public DbPropertyValues OriginalValues => new DbPropertyValues(_internalEntityEntry.OriginalValues);

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> class.
	/// </summary>
	/// <param name="internalEntityEntry">The internal entry.</param>
	internal DbEntityEntry(InternalEntityEntry internalEntityEntry)
	{
		_internalEntityEntry = internalEntityEntry;
	}

	/// <summary>
	///     Queries the database for copies of the values of the tracked entity as they currently exist in the database.
	///     Note that changing the values in the returned dictionary will not update the values in the database.
	///     If the entity is not found in the database then null is returned.
	/// </summary>
	/// <returns>The store values.</returns>
	public DbPropertyValues GetDatabaseValues()
	{
		InternalPropertyValues databaseValues = _internalEntityEntry.GetDatabaseValues();
		if (databaseValues != null)
		{
			return new DbPropertyValues(databaseValues);
		}
		return null;
	}

	/// <summary>
	///     Reloads the entity from the database overwriting any property values with values from the database.
	///     The entity will be in the Unchanged state after calling this method.
	/// </summary>
	public void Reload()
	{
		_internalEntityEntry.Reload();
	}

	/// <summary>
	///     Gets an object that represents the reference (i.e. non-collection) navigation property from this
	///     entity to another entity.
	/// </summary>
	/// <param name="navigationProperty">The name of the navigation property.</param>
	/// <returns>An object representing the navigation property.</returns>
	public DbReferenceEntry Reference(string navigationProperty)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(navigationProperty), null, "!String.IsNullOrWhiteSpace(navigationProperty)");
		return DbReferenceEntry.Create(_internalEntityEntry.Reference(navigationProperty));
	}

	/// <summary>
	///     Gets an object that represents the reference (i.e. non-collection) navigation property from this
	///     entity to another entity.
	/// </summary>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <param name="navigationProperty">The name of the navigation property.</param>
	/// <returns>An object representing the navigation property.</returns>
	public DbReferenceEntry<TEntity, TProperty> Reference<TProperty>(string navigationProperty) where TProperty : class
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(navigationProperty), null, "!String.IsNullOrWhiteSpace(navigationProperty)");
		return DbReferenceEntry<TEntity, TProperty>.Create(_internalEntityEntry.Reference(navigationProperty, typeof(TProperty)));
	}

	/// <summary>
	///     Gets an object that represents the reference (i.e. non-collection) navigation property from this
	///     entity to another entity.
	/// </summary>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <param name="navigationProperty">An expression representing the navigation property.</param>
	/// <returns>An object representing the navigation property.</returns>
	public DbReferenceEntry<TEntity, TProperty> Reference<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty) where TProperty : class
	{
		RuntimeFailureMethods.Requires(navigationProperty != null, null, "navigationProperty != null");
		return DbReferenceEntry<TEntity, TProperty>.Create(_internalEntityEntry.Reference(DbHelpers.ParsePropertySelector(navigationProperty, "Reference", "navigationProperty"), typeof(TProperty)));
	}

	/// <summary>
	///     Gets an object that represents the collection navigation property from this
	///     entity to a collection of related entities.
	/// </summary>
	/// <param name="navigationProperty">The name of the navigation property.</param>
	/// <returns>An object representing the navigation property.</returns>
	public DbCollectionEntry Collection(string navigationProperty)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(navigationProperty), null, "!String.IsNullOrWhiteSpace(navigationProperty)");
		return DbCollectionEntry.Create(_internalEntityEntry.Collection(navigationProperty));
	}

	/// <summary>
	///     Gets an object that represents the collection navigation property from this
	///     entity to a collection of related entities.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
	/// <param name="navigationProperty">The name of the navigation property.</param>
	/// <returns>An object representing the navigation property.</returns>
	public DbCollectionEntry<TEntity, TElement> Collection<TElement>(string navigationProperty) where TElement : class
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(navigationProperty), null, "!String.IsNullOrWhiteSpace(navigationProperty)");
		return DbCollectionEntry<TEntity, TElement>.Create(_internalEntityEntry.Collection(navigationProperty, typeof(TElement)));
	}

	/// <summary>
	///     Gets an object that represents the collection navigation property from this
	///     entity to a collection of related entities.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
	/// <param name="navigationProperty">An expression representing the navigation property.</param>
	/// <returns>An object representing the navigation property.</returns>
	public DbCollectionEntry<TEntity, TElement> Collection<TElement>(Expression<Func<TEntity, ICollection<TElement>>> navigationProperty) where TElement : class
	{
		RuntimeFailureMethods.Requires(navigationProperty != null, null, "navigationProperty != null");
		return Collection<TElement>(DbHelpers.ParsePropertySelector(navigationProperty, "Collection", "navigationProperty"));
	}

	/// <summary>
	///     Gets an object that represents a scalar or complex property of this entity.
	/// </summary>
	/// <param name="propertyName">The name of the property.</param>
	/// <returns>An object representing the property.</returns>
	public DbPropertyEntry Property(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return DbPropertyEntry.Create(_internalEntityEntry.Property(propertyName));
	}

	/// <summary>
	///     Gets an object that represents a scalar or complex property of this entity.
	/// </summary>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <param name="propertyName">The name of the property.</param>
	/// <returns>An object representing the property.</returns>
	public DbPropertyEntry<TEntity, TProperty> Property<TProperty>(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return DbPropertyEntry<TEntity, TProperty>.Create(_internalEntityEntry.Property(propertyName, typeof(TProperty)));
	}

	/// <summary>
	///     Gets an object that represents a scalar or complex property of this entity.
	/// </summary>
	/// <typeparam name="TProperty">The type of the property.</typeparam>
	/// <param name="navigationProperty">An expression representing the property.</param>
	/// <returns>An object representing the property.</returns>
	[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#", Justification = "Rule predates more fluent naming conventions.")]
	public DbPropertyEntry<TEntity, TProperty> Property<TProperty>(Expression<Func<TEntity, TProperty>> property)
	{
		RuntimeFailureMethods.Requires(property != null, null, "property != null");
		return Property<TProperty>(DbHelpers.ParsePropertySelector(property, "Property", "property"));
	}

	/// <summary>
	///     Gets an object that represents a complex property of this entity.
	/// </summary>
	/// <param name="propertyName">The name of the complex property.</param>
	/// <returns>An object representing the complex property.</returns>
	public DbComplexPropertyEntry ComplexProperty(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		InternalEntityEntry internalEntityEntry = _internalEntityEntry;
		bool requireComplex = true;
		return DbComplexPropertyEntry.Create(internalEntityEntry.Property(propertyName, null, requireComplex));
	}

	/// <summary>
	///     Gets an object that represents a complex property of this entity.
	/// </summary>
	/// <typeparam name="TComplexProperty">The type of the complex property.</typeparam>
	/// <param name="propertyName">The name of the complex property.</param>
	/// <returns>An object representing the complex property.</returns>
	public DbComplexPropertyEntry<TEntity, TComplexProperty> ComplexProperty<TComplexProperty>(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		InternalEntityEntry internalEntityEntry = _internalEntityEntry;
		bool requireComplex = true;
		return DbComplexPropertyEntry<TEntity, TComplexProperty>.Create(internalEntityEntry.Property(propertyName, typeof(TComplexProperty), requireComplex));
	}

	/// <summary>
	///     Gets an object that represents a complex property of this entity.
	/// </summary>
	/// <typeparam name="TComplexProperty">The type of the complex property.</typeparam>
	/// <param name="navigationProperty">An expression representing the complex property.</param>
	/// <returns>An object representing the complex property.</returns>
	[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#", Justification = "Rule predates more fluent naming conventions.")]
	public DbComplexPropertyEntry<TEntity, TComplexProperty> ComplexProperty<TComplexProperty>(Expression<Func<TEntity, TComplexProperty>> property)
	{
		RuntimeFailureMethods.Requires(property != null, null, "property != null");
		return ComplexProperty<TComplexProperty>(DbHelpers.ParsePropertySelector(property, "Property", "property"));
	}

	/// <summary>
	///     Gets an object that represents a member of the entity.  The runtime type of the returned object will
	///     vary depending on what kind of member is asked for.  The currently supported member types and their return
	///     types are:
	///     Reference navigation property: <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry" />.
	///     Collection navigation property: <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry" />.
	///     Primitive/scalar property: <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" />.
	///     Complex property: <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry" />.
	/// </summary>
	/// <param name="propertyName">The name of the member.</param>
	/// <returns>An object representing the member.</returns>
	public DbMemberEntry Member(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return DbMemberEntry.Create(_internalEntityEntry.Member(propertyName));
	}

	/// <summary>
	///     Gets an object that represents a member of the entity.  The runtime type of the returned object will
	///     vary depending on what kind of member is asked for.  The currently supported member types and their return
	///     types are:
	///     Reference navigation property: <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry`2" />.
	///     Collection navigation property: <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry`2" />.
	///     Primitive/scalar property: <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry`2" />.
	///     Complex property: <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry`2" />.
	/// </summary>
	/// <typeparam name="TMember">The type of the member.</typeparam>
	/// <param name="propertyName">The name of the member.</param>
	/// <returns>An object representing the member.</returns>
	public DbMemberEntry<TEntity, TMember> Member<TMember>(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return _internalEntityEntry.Member(propertyName, typeof(TMember)).CreateDbMemberEntry<TEntity, TMember>();
	}

	/// <summary>
	///     Returns a new instance of the non-generic <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> class for 
	///     the tracked entity represented by this object.
	/// </summary>
	/// <returns>A non-generic version.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Intentionally just implicit to reduce API clutter.")]
	public static implicit operator DbEntityEntry(DbEntityEntry<TEntity> entry)
	{
		return new DbEntityEntry(entry._internalEntityEntry);
	}

	/// <summary>
	///     Validates this <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> instance and returns validation result.
	/// </summary>
	/// <returns>
	///     Entity validation result. Possibly null if 
	///     <see cref="M:System.Data.Entity.DbContext.ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry,System.Collections.Generic.IDictionary{System.Object,System.Object})" /> method is overridden.
	/// </returns>
	public DbEntityValidationResult GetValidationResult()
	{
		return _internalEntityEntry.InternalContext.Owner.CallValidateEntity(this, null);
	}

	/// <summary>
	///     Determines whether the specified <see cref="T:System.Object" /> is equal to this instance.
	///     Two <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> instances are considered equal if they are both entries for
	///     the same entity on the same <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <param name="obj">The <see cref="T:System.Object" /> to compare with this instance.</param>
	/// <returns>
	///     <c>true</c> if the specified <see cref="T:System.Object" /> is equal to this instance; otherwise, <c>false</c>.
	/// </returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj) || obj.GetType() != typeof(DbEntityEntry<TEntity>))
		{
			return false;
		}
		return Equals((DbEntityEntry<TEntity>)obj);
	}

	/// <summary>
	///     Determines whether the specified <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> is equal to this instance.
	///     Two <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> instances are considered equal if they are both entries for
	///     the same entity on the same <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <param name="other">The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> to compare with this instance.</param>
	/// <returns>
	///     <c>true</c> if the specified <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> is equal to this instance; otherwise, <c>false</c>.
	/// </returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool Equals(DbEntityEntry<TEntity> other)
	{
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (!object.ReferenceEquals(null, other))
		{
			return _internalEntityEntry.Equals(other._internalEntityEntry);
		}
		return false;
	}

	/// <summary>
	///     Returns a hash code for this instance.
	/// </summary>
	/// <returns>
	///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
	/// </returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return _internalEntityEntry.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
/// <summary>
///     A non-generic version of the <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> class.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbEntityEntry
{
	private readonly InternalEntityEntry _internalEntityEntry;

	/// <summary>
	///     Gets the entity.
	/// </summary>
	/// <value>The entity.</value>
	public object Entity => _internalEntityEntry.Entity;

	/// <summary>
	///     Gets or sets the state of the entity.
	/// </summary>
	/// <value>The state.</value>
	public EntityState State
	{
		get
		{
			return _internalEntityEntry.State;
		}
		set
		{
			_internalEntityEntry.State = value;
		}
	}

	/// <summary>
	///     Gets the current property values for the tracked entity represented by this object.
	/// </summary>
	/// <value>The current values.</value>
	public DbPropertyValues CurrentValues => new DbPropertyValues(_internalEntityEntry.CurrentValues);

	/// <summary>
	///     Gets the original property values for the tracked entity represented by this object.
	///     The original values are usually the entity's property values as they were when last queried from
	///     the database.
	/// </summary>
	/// <value>The original values.</value>
	public DbPropertyValues OriginalValues => new DbPropertyValues(_internalEntityEntry.OriginalValues);

	/// <summary>
	///     Gets InternalEntityEntry object for this DbEntityEntry instance.
	/// </summary>
	internal InternalEntityEntry InternalEntry => _internalEntityEntry;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> class.
	/// </summary>
	/// <param name="internalEntityEntry">The internal entry.</param>
	internal DbEntityEntry(InternalEntityEntry internalEntityEntry)
	{
		_internalEntityEntry = internalEntityEntry;
	}

	/// <summary>
	///     Queries the database for copies of the values of the tracked entity as they currently exist in the database.
	///     Note that changing the values in the returned dictionary will not update the values in the database.
	///     If the entity is not found in the database then null is returned.
	/// </summary>
	/// <returns>The store values.</returns>
	public DbPropertyValues GetDatabaseValues()
	{
		InternalPropertyValues databaseValues = _internalEntityEntry.GetDatabaseValues();
		if (databaseValues != null)
		{
			return new DbPropertyValues(databaseValues);
		}
		return null;
	}

	/// <summary>
	///     Reloads the entity from the database overwriting any property values with values from the database.
	///     The entity will be in the Unchanged state after calling this method.
	/// </summary>
	public void Reload()
	{
		_internalEntityEntry.Reload();
	}

	/// <summary>
	///     Gets an object that represents the reference (i.e. non-collection) navigation property from this
	///     entity to another entity.
	/// </summary>
	/// <param name="navigationProperty">The name of the navigation property.</param>
	/// <returns>An object representing the navigation property.</returns>
	public DbReferenceEntry Reference(string navigationProperty)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(navigationProperty), null, "!String.IsNullOrWhiteSpace(navigationProperty)");
		return DbReferenceEntry.Create(_internalEntityEntry.Reference(navigationProperty));
	}

	/// <summary>
	///     Gets an object that represents the collection navigation property from this
	///     entity to a collection of related entities.
	/// </summary>
	/// <param name="navigationProperty">The name of the navigation property.</param>
	/// <returns>An object representing the navigation property.</returns>
	public DbCollectionEntry Collection(string navigationProperty)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(navigationProperty), null, "!String.IsNullOrWhiteSpace(navigationProperty)");
		return DbCollectionEntry.Create(_internalEntityEntry.Collection(navigationProperty));
	}

	/// <summary>
	///     Gets an object that represents a scalar or complex property of this entity.
	/// </summary>
	/// <param name="propertyName">The name of the property.</param>
	/// <returns>An object representing the property.</returns>
	public DbPropertyEntry Property(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return DbPropertyEntry.Create(_internalEntityEntry.Property(propertyName));
	}

	/// <summary>
	///     Gets an object that represents a complex property of this entity.
	/// </summary>
	/// <param name="propertyName">The name of the complex property.</param>
	/// <returns>An object representing the complex property.</returns>
	public DbComplexPropertyEntry ComplexProperty(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		InternalEntityEntry internalEntityEntry = _internalEntityEntry;
		bool requireComplex = true;
		return DbComplexPropertyEntry.Create(internalEntityEntry.Property(propertyName, null, requireComplex));
	}

	/// <summary>
	///     Gets an object that represents a member of the entity.  The runtime type of the returned object will
	///     vary depending on what kind of member is asked for.  The currently supported member types and their return
	///     types are:
	///     Reference navigation property: <see cref="T:System.Data.Entity.Infrastructure.DbReferenceEntry" />.
	///     Collection navigation property: <see cref="T:System.Data.Entity.Infrastructure.DbCollectionEntry" />.
	///     Primitive/scalar property: <see cref="T:System.Data.Entity.Infrastructure.DbPropertyEntry" />.
	///     Complex property: <see cref="T:System.Data.Entity.Infrastructure.DbComplexPropertyEntry" />.
	/// </summary>
	/// <param name="propertyName">The name of the member.</param>
	/// <returns>An object representing the member.</returns>
	public DbMemberEntry Member(string propertyName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
		return DbMemberEntry.Create(_internalEntityEntry.Member(propertyName));
	}

	/// <summary>
	///     Returns a new instance of the generic <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" /> class for the given
	///     generic type for the tracked entity represented by this object.
	///     Note that the type of the tracked entity must be compatible with the generic type or
	///     an exception will be thrown.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <returns>A generic version.</returns>
	public DbEntityEntry<TEntity> Cast<TEntity>() where TEntity : class
	{
		if (!typeof(TEntity).IsAssignableFrom(_internalEntityEntry.EntityType))
		{
			throw Error.DbEntity_BadTypeForCast(typeof(DbEntityEntry).Name, typeof(TEntity).Name, _internalEntityEntry.EntityType.Name);
		}
		return new DbEntityEntry<TEntity>(_internalEntityEntry);
	}

	/// <summary>
	///     Validates this <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> instance and returns validation result.
	/// </summary>
	/// <returns>
	///     Entity validation result. Possibly null if 
	///     <see cref="M:System.Data.Entity.DbContext.ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry,System.Collections.Generic.IDictionary{System.Object,System.Object})" /> method is overridden.
	/// </returns>
	public DbEntityValidationResult GetValidationResult()
	{
		return _internalEntityEntry.InternalContext.Owner.CallValidateEntity(this, null);
	}

	/// <summary>
	///     Determines whether the specified <see cref="T:System.Object" /> is equal to this instance.
	///     Two <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> instances are considered equal if they are both entries for
	///     the same entity on the same <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <param name="obj">The <see cref="T:System.Object" /> to compare with this instance.</param>
	/// <returns>
	///     <c>true</c> if the specified <see cref="T:System.Object" /> is equal to this instance; otherwise, <c>false</c>.
	/// </returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj) || obj.GetType() != typeof(DbEntityEntry))
		{
			return false;
		}
		return Equals((DbEntityEntry)obj);
	}

	/// <summary>
	///     Determines whether the specified <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> is equal to this instance.
	///     Two <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> instances are considered equal if they are both entries for
	///     the same entity on the same <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <param name="other">The <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> to compare with this instance.</param>
	/// <returns>
	///     <c>true</c> if the specified <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> is equal to this instance; otherwise, <c>false</c>.
	/// </returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool Equals(DbEntityEntry other)
	{
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (!object.ReferenceEquals(null, other))
		{
			return _internalEntityEntry.Equals(other._internalEntityEntry);
		}
		return false;
	}

	/// <summary>
	///     Returns a hash code for this instance.
	/// </summary>
	/// <returns>
	///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
	/// </returns>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return _internalEntityEntry.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
