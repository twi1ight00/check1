using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Internal.Validation;
using System.Data.Entity.Resources;
using System.Data.Entity.Validation;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Globalization;
using System.Linq;
using System.Text;

namespace System.Data.Entity.Internal;

/// <summary>
///     The internal class used to implement <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" />
///     and <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1" />.
///     This internal class contains all the common implementation between the generic and non-generic
///     entry classes and also allows for a clean internal factoring without compromising the public API.
/// </summary>
internal class InternalEntityEntry
{
	private readonly Type _entityType;

	private readonly InternalContext _internalContext;

	private readonly object _entity;

	private IEntityStateEntry _stateEntry;

	private EntityType _edmEntityType;

	/// <summary>
	///     Gets the tracked entity.
	///     This property is virtual to allow mocking.
	/// </summary>
	/// <value>The entity.</value>
	public virtual object Entity => _entity;

	/// <summary>
	///     Gets or sets the state of the entity.
	/// </summary>
	/// <value>The state.</value>
	public EntityState State
	{
		get
		{
			if (!IsDetached)
			{
				return _stateEntry.State;
			}
			return EntityState.Detached;
		}
		set
		{
			if (!IsDetached)
			{
				if (_stateEntry.State == EntityState.Modified && value == EntityState.Unchanged)
				{
					CurrentValues.SetValues(OriginalValues);
				}
				_stateEntry.ChangeState(value);
				return;
			}
			switch (value)
			{
			case EntityState.Added:
				_internalContext.Set(_entityType).InternalSet.Add(_entity);
				break;
			case EntityState.Unchanged:
				_internalContext.Set(_entityType).InternalSet.Attach(_entity);
				break;
			case EntityState.Deleted:
			case EntityState.Modified:
				_internalContext.Set(_entityType).InternalSet.Attach(_entity);
				_stateEntry = _internalContext.GetStateEntry(_entity);
				_stateEntry.ChangeState(value);
				break;
			}
		}
	}

	/// <summary>
	///     Gets the current property values for the tracked entity represented by this object.
	///     This property is virtual to allow mocking.
	/// </summary>
	/// <value>The current values.</value>
	public virtual InternalPropertyValues CurrentValues
	{
		get
		{
			ValidateStateToGetValues("CurrentValues", EntityState.Deleted);
			bool isEntity = true;
			return new DbDataRecordPropertyValues(_internalContext, _entityType, _stateEntry.CurrentValues, isEntity);
		}
	}

	/// <summary>
	///     Gets the original property values for the tracked entity represented by this object.
	///     The original values are usually the entity's property values as they were when last queried from
	///     the database.
	///     This property is virtual to allow mocking.
	/// </summary>
	/// <value>The original values.</value>
	public virtual InternalPropertyValues OriginalValues
	{
		get
		{
			ValidateStateToGetValues("OriginalValues", EntityState.Added);
			bool isEntity = true;
			return new DbDataRecordPropertyValues(_internalContext, _entityType, _stateEntry.GetUpdatableOriginalValues(), isEntity);
		}
	}

	/// <summary>
	///     Checks whether or not this entry is associated with an underlying <see cref="P:System.Data.Entity.Internal.InternalEntityEntry.ObjectStateEntry" /> or
	///     is just wrapping a non-attached entity.
	/// </summary>
	public virtual bool IsDetached
	{
		get
		{
			if (_stateEntry == null || _stateEntry.State == EntityState.Detached)
			{
				_stateEntry = _internalContext.GetStateEntry(_entity);
				if (_stateEntry == null)
				{
					return true;
				}
			}
			return false;
		}
	}

	/// <summary>
	///     Gets the type of the entity being tracked.
	/// </summary>
	/// <value>The type of the entity.</value>
	public virtual Type EntityType => _entityType;

	/// <summary>
	///     Gets the c-space entity type for this entity from the EDM.
	/// </summary>
	public virtual EntityType EdmEntityType
	{
		get
		{
			if (_edmEntityType == null)
			{
				MetadataWorkspace metadataWorkspace = _internalContext.ObjectContext.MetadataWorkspace;
				EntityType item = metadataWorkspace.GetItem<EntityType>(_entityType.FullName, DataSpace.OSpace);
				_edmEntityType = (EntityType)metadataWorkspace.GetEdmSpaceType(item);
			}
			return _edmEntityType;
		}
	}

	/// <summary>
	///     Gets the underlying object state entry.
	/// </summary>
	public IEntityStateEntry ObjectStateEntry => _stateEntry;

	/// <summary>
	///     Gets the internal context.
	/// </summary>
	/// <value>The internal context.</value>
	public InternalContext InternalContext => _internalContext;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalEntityEntry" /> class.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	/// <param name="stateEntry">The state entry.</param>
	public InternalEntityEntry(InternalContext internalContext, IEntityStateEntry stateEntry)
	{
		_internalContext = internalContext;
		_stateEntry = stateEntry;
		_entity = stateEntry.Entity;
		_entityType = ObjectContextTypeCache.GetObjectType(_entity.GetType());
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalEntityEntry" /> class for an
	///     entity which may or may not be attached to the context.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	/// <param name="entity">The entity.</param>
	public InternalEntityEntry(InternalContext internalContext, object entity)
	{
		_internalContext = internalContext;
		_entity = entity;
		_entityType = ObjectContextTypeCache.GetObjectType(_entity.GetType());
		_stateEntry = _internalContext.GetStateEntry(entity);
		if (_stateEntry == null)
		{
			_internalContext.Set(_entityType).InternalSet.Initialize();
		}
	}

	/// <summary>
	///     Queries the database for copies of the values of the tracked entity as they currently exist in the database.
	/// </summary>
	/// <returns>The store values.</returns>
	public InternalPropertyValues GetDatabaseValues()
	{
		ValidateStateToGetValues("GetDatabaseValues", EntityState.Added);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("SELECT ");
		AppendEntitySqlRow(stringBuilder, "X", OriginalValues);
		string text = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", new object[2]
		{
			DbHelpers.QuoteIdentifier(_stateEntry.EntitySet.EntityContainer.Name),
			DbHelpers.QuoteIdentifier(_stateEntry.EntitySet.Name)
		});
		string text2 = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", new object[2]
		{
			DbHelpers.QuoteIdentifier(EntityType.Namespace),
			DbHelpers.QuoteIdentifier(EntityType.Name)
		});
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " FROM (SELECT VALUE TREAT (Y AS {0}) FROM {1} AS Y) AS X WHERE ", new object[2] { text2, text });
		EntityKeyMember[] entityKeyValues = _stateEntry.EntityKey.EntityKeyValues;
		ObjectParameter[] array = new ObjectParameter[entityKeyValues.Length];
		for (int i = 0; i < entityKeyValues.Length; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(" AND ");
			}
			string text3 = string.Format(CultureInfo.InvariantCulture, "p{0}", new object[1] { i.ToString(CultureInfo.InvariantCulture) });
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "X.{0} = @{1}", new object[2]
			{
				DbHelpers.QuoteIdentifier(entityKeyValues[i].Key),
				text3
			});
			array[i] = new ObjectParameter(text3, entityKeyValues[i].Value);
		}
		DbDataRecord dbDataRecord = _internalContext.ObjectContext.CreateQuery<DbDataRecord>(stringBuilder.ToString(), array).SingleOrDefault();
		if (dbDataRecord != null)
		{
			return new ClonedPropertyValues(OriginalValues, dbDataRecord);
		}
		return null;
	}

	/// <summary>
	///     Appends a query for the properties in the entity to the given string builder that is being used to
	///     build the eSQL query.  This method may be called recursively to query for all the sub-properties of
	///     a complex property.
	/// </summary>
	/// <param name="queryBuilder">The query builder.</param>
	/// <param name="prefix">The qualifier with which to prefix each property name.</param>
	/// <param name="templateValues">The dictionary that acts as a template for the properties to query.</param>
	private void AppendEntitySqlRow(StringBuilder queryBuilder, string prefix, InternalPropertyValues templateValues)
	{
		bool flag = false;
		foreach (string propertyName in templateValues.PropertyNames)
		{
			if (flag)
			{
				queryBuilder.Append(", ");
			}
			else
			{
				flag = true;
			}
			string text = DbHelpers.QuoteIdentifier(propertyName);
			IPropertyValuesItem item = templateValues.GetItem(propertyName);
			if (item.IsComplex)
			{
				if (!(item.Value is InternalPropertyValues templateValues2))
				{
					throw Error.DbPropertyValues_CannotGetStoreValuesWhenComplexPropertyIsNull(propertyName, EntityType.Name);
				}
				queryBuilder.Append("ROW(");
				AppendEntitySqlRow(queryBuilder, string.Format(CultureInfo.InvariantCulture, "{0}.{1}", new object[2] { prefix, text }), templateValues2);
				queryBuilder.AppendFormat(CultureInfo.InvariantCulture, ") AS {0}", new object[1] { text });
			}
			else
			{
				queryBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}.{1} ", new object[2] { prefix, text });
			}
		}
	}

	/// <summary>
	///     Validates that a dictionary can be obtained for the state of the entity represented by this entry.
	/// </summary>
	/// <param name="method">The method name being used to request a dictionary.</param>
	/// <param name="invalidState">The state that is invalid for the request being processed.</param>
	private void ValidateStateToGetValues(string method, EntityState invalidState)
	{
		ValidateNotDetachedAndInitializeRelatedEnd(method);
		if (State == invalidState)
		{
			throw Error.DbPropertyValues_CannotGetValuesForState(method, State);
		}
	}

	/// <summary>
	///     Calls Refresh with StoreWins on the underlying state entry.
	/// </summary>
	public void Reload()
	{
		ValidateStateToGetValues("Reload", EntityState.Added);
		_internalContext.ObjectContext.Refresh(RefreshMode.StoreWins, Entity);
	}

	/// <summary>
	///     Gets an internal object representing a reference navigation property.
	///     This method is virtual to allow mocking.
	/// </summary>
	/// <param name="navigationProperty">The navigation property.</param>
	/// <param name="requestedType">The type of entity requested, which may be 'object' or null if any type can be accepted.</param>
	/// <returns>The entry.</returns>
	public virtual InternalReferenceEntry Reference(string navigationProperty, Type requestedType = null)
	{
		return (InternalReferenceEntry)ValidateAndGetNavigationMetadata(requireCollection: false, navigationProperty: navigationProperty, requestedType: requestedType ?? typeof(object)).CreateMemberEntry(this, null);
	}

	/// <summary>
	///     Gets an internal object representing a collection navigation property.
	///     This method is virtual to allow mocking.
	/// </summary>
	/// <param name="navigationProperty">The navigation property.</param>
	/// <param name="requestedType">The type of entity requested, which may be 'object' or null f any type can be accepted.</param>
	/// <returns>The entry.</returns>
	public virtual InternalCollectionEntry Collection(string navigationProperty, Type requestedType = null)
	{
		return (InternalCollectionEntry)ValidateAndGetNavigationMetadata(requireCollection: true, navigationProperty: navigationProperty, requestedType: requestedType ?? typeof(object)).CreateMemberEntry(this, null);
	}

	/// <summary>
	///     Gets an internal object representing a navigation, scalar, or complex property.
	///     This method is virtual to allow mocking.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <param name="requestedType">The type of entity requested, which may be 'object' if any type can be accepted.</param>
	/// <returns>The entry.</returns>
	public virtual InternalMemberEntry Member(string propertyName, Type requestedType = null)
	{
		requestedType = requestedType ?? typeof(object);
		IList<string> list = SplitName(propertyName);
		if (list.Count > 1)
		{
			bool requireComplex = false;
			return Property(null, propertyName, list, requestedType, requireComplex);
		}
		MemberEntryMetadata memberEntryMetadata = (MemberEntryMetadata)(((object)GetNavigationMetadata(propertyName)) ?? ((object)ValidateAndGetPropertyMetadata(propertyName, EntityType, requestedType)));
		if (memberEntryMetadata == null)
		{
			throw Error.DbEntityEntry_NotAProperty(propertyName, EntityType.Name);
		}
		if (memberEntryMetadata.MemberEntryType != MemberEntryType.CollectionNavigationProperty && !requestedType.IsAssignableFrom(memberEntryMetadata.MemberType))
		{
			throw Error.DbEntityEntry_WrongGenericForNavProp(propertyName, EntityType.Name, requestedType.Name, memberEntryMetadata.MemberType.Name);
		}
		return memberEntryMetadata.CreateMemberEntry(this, null);
	}

	/// <summary>
	///     Gets an internal object representing a scalar or complex property.
	///     This method is virtual to allow mocking.
	/// </summary>
	/// <param name="property">The property.</param>
	/// <param name="requestedType">The type of object requested, which may be null or 'object' if any type can be accepted.</param>
	/// <param name="requireComplex">if set to <c>true</c> then the found property must be a complex property.</param>
	/// <returns>The entry.</returns>
	public virtual InternalPropertyEntry Property(string property, Type requestedType = null, bool requireComplex = false)
	{
		return Property(null, property, requestedType ?? typeof(object), requireComplex);
	}

	/// <summary>
	///     Gets an internal object representing a scalar or complex property.
	///     The property may be a nested property on the given <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" />.
	/// </summary>
	/// <param name="parentProperty">The parent property entry, or null if this is a property directly on the entity.</param>
	/// <param name="propertyName">Name of the property.</param>
	/// <param name="requestedType">The type of object requested, which may be null or 'object' if any type can be accepted.</param>
	/// <param name="requireComplex">if set to <c>true</c> then the found property must be a complex property.</param>
	/// <returns>The entry.</returns>
	public InternalPropertyEntry Property(InternalPropertyEntry parentProperty, string propertyName, Type requestedType, bool requireComplex)
	{
		return Property(parentProperty, propertyName, SplitName(propertyName), requestedType, requireComplex);
	}

	/// <summary>
	///     Gets an internal object representing a scalar or complex property.
	///     The property may be a nested property on the given <see cref="T:System.Data.Entity.Internal.InternalPropertyEntry" />.
	/// </summary>
	/// <param name="parentProperty">The parent property entry, or null if this is a property directly on the entity.</param>
	/// <param name="propertyName">Name of the property.</param>
	/// <param name="properties">The property split out into its parts.</param>
	/// <param name="requestedType">The type of object requested, which may be null or 'object' if any type can be accepted.</param>
	/// <param name="requireComplex">if set to <c>true</c> then the found property must be a complex property.</param>
	/// <returns>The entry.</returns>
	private InternalPropertyEntry Property(InternalPropertyEntry parentProperty, string propertyName, IList<string> properties, Type requestedType, bool requireComplex)
	{
		bool flag = properties.Count > 1;
		Type requestedType2 = (flag ? typeof(object) : requestedType);
		Type type = ((parentProperty != null) ? parentProperty.EntryMetadata.ElementType : EntityType);
		PropertyEntryMetadata propertyEntryMetadata = ValidateAndGetPropertyMetadata(properties[0], type, requestedType2);
		if (propertyEntryMetadata == null || ((flag || requireComplex) && !propertyEntryMetadata.IsComplex))
		{
			if (flag)
			{
				throw Error.DbEntityEntry_DottedPartNotComplex(properties[0], propertyName, type.Name);
			}
			throw requireComplex ? Error.DbEntityEntry_NotAComplexProperty(properties[0], type.Name) : Error.DbEntityEntry_NotAScalarProperty(properties[0], type.Name);
		}
		InternalPropertyEntry internalPropertyEntry = (InternalPropertyEntry)propertyEntryMetadata.CreateMemberEntry(this, parentProperty);
		if (!flag)
		{
			return internalPropertyEntry;
		}
		return Property(internalPropertyEntry, propertyName, properties.Skip(1).ToList(), requestedType, requireComplex);
	}

	/// <summary>
	///     Checks that the given property name is a navigation property and is either a reference property or
	///     collection property according to the value of requireCollection.
	/// </summary>
	private NavigationEntryMetadata ValidateAndGetNavigationMetadata(string navigationProperty, Type requestedType, bool requireCollection)
	{
		if (SplitName(navigationProperty).Count != 1)
		{
			throw Error.DbEntityEntry_DottedPathMustBeProperty(navigationProperty);
		}
		NavigationEntryMetadata navigationMetadata = GetNavigationMetadata(navigationProperty);
		if (navigationMetadata == null)
		{
			throw Error.DbEntityEntry_NotANavigationProperty(navigationProperty, EntityType.Name);
		}
		if (requireCollection)
		{
			if (navigationMetadata.MemberEntryType == MemberEntryType.ReferenceNavigationProperty)
			{
				throw Error.DbEntityEntry_UsedCollectionForReferenceProp(navigationProperty, EntityType.Name);
			}
		}
		else if (navigationMetadata.MemberEntryType == MemberEntryType.CollectionNavigationProperty)
		{
			throw Error.DbEntityEntry_UsedReferenceForCollectionProp(navigationProperty, EntityType.Name);
		}
		if (!requestedType.IsAssignableFrom(navigationMetadata.ElementType))
		{
			throw Error.DbEntityEntry_WrongGenericForNavProp(navigationProperty, EntityType.Name, requestedType.Name, navigationMetadata.ElementType.Name);
		}
		return navigationMetadata;
	}

	/// <summary>
	///     Gets metadata for the given property if that property is a navigation property or returns null
	///     if it is not a navigation property.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>Navigation property metadata or null.</returns>
	public virtual NavigationEntryMetadata GetNavigationMetadata(string propertyName)
	{
		EdmEntityType.Members.TryGetValue(propertyName, ignoreCase: false, out var item);
		if (item is NavigationProperty navigationProperty)
		{
			return new NavigationEntryMetadata(EntityType, GetNavigationTargetType(navigationProperty), propertyName, navigationProperty.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many);
		}
		return null;
	}

	/// <summary>
	///     Gets the type of entity or entities at the target end of the given navigation property.
	/// </summary>
	/// <param name="navigationProperty">The navigation property.</param>
	/// <returns>The CLR type of the entity or entities at the other end.</returns>
	private Type GetNavigationTargetType(NavigationProperty navigationProperty)
	{
		MetadataWorkspace metadataWorkspace = _internalContext.ObjectContext.MetadataWorkspace;
		EntityType entityType = navigationProperty.RelationshipType.RelationshipEndMembers.Single((RelationshipEndMember e) => navigationProperty.ToEndMember.Name == e.Name).GetEntityType();
		StructuralType objectSpaceType = metadataWorkspace.GetObjectSpaceType(entityType);
		ObjectItemCollection objectItemCollection = (ObjectItemCollection)metadataWorkspace.GetItemCollection(DataSpace.OSpace);
		return objectItemCollection.GetClrType(objectSpaceType);
	}

	/// <summary>
	///     Gets the related end for the navigation property with the given name.
	/// </summary>
	/// <param name="navigationProperty">The navigation property.</param>
	/// <returns></returns>
	public virtual IRelatedEnd GetRelatedEnd(string navigationProperty)
	{
		EdmEntityType.Members.TryGetValue(navigationProperty, ignoreCase: false, out var item);
		NavigationProperty navigationProperty2 = (NavigationProperty)item;
		RelationshipManager relationshipManager = _internalContext.ObjectContext.ObjectStateManager.GetRelationshipManager(Entity);
		return relationshipManager.GetRelatedEnd(navigationProperty2.RelationshipType.FullName, navigationProperty2.ToEndMember.Name);
	}

	/// <summary>
	///     Uses EDM metadata to validate that the property name exists in the model and represents a scalar or
	///     complex property or exists in the CLR type.
	///     This method is public and virtual so that it can be mocked.
	/// </summary>
	/// <param name="propertyName">The property name.</param>
	/// <param name="declaringType">The type on which the property is declared.</param>
	/// <param name="requestedType">The type of object requested, which may be 'object' if any type can be accepted.</param>
	/// <returns>Metadata for the property.</returns>
	public virtual PropertyEntryMetadata ValidateAndGetPropertyMetadata(string propertyName, Type declaringType, Type requestedType)
	{
		return PropertyEntryMetadata.ValidateNameAndGetMetadata(_internalContext, declaringType, requestedType, propertyName);
	}

	/// <summary>
	///     Splits the given property name into parts delimited by dots.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>The parts of the name.</returns>
	private IList<string> SplitName(string propertyName)
	{
		return propertyName.Split('.');
	}

	/// <summary>
	///     Validates that this entry is associated with an underlying <see cref="P:System.Data.Entity.Internal.InternalEntityEntry.ObjectStateEntry" /> and
	///     is not just wrapping a non-attached entity.
	/// </summary>
	private void ValidateNotDetachedAndInitializeRelatedEnd(string method)
	{
		if (IsDetached)
		{
			throw Error.DbEntityEntry_NotSupportedForDetached(method, _entityType.Name);
		}
	}

	/// <summary>
	///     Validates entity represented by this entity entry.
	///     This method is virtual to allow mocking.
	/// </summary>
	/// <param name="items">User defined dictionary containing additional info for custom validation. This parameter is optional and can be null.</param>
	/// <returns><see cref="T:System.Data.Entity.Validation.DbEntityValidationResult" /> containing validation result. Never null.</returns>
	public virtual DbEntityValidationResult GetValidationResult(IDictionary<object, object> items)
	{
		EntityValidator entityValidator = InternalContext.ValidationProvider.GetEntityValidator(this);
		bool lazyLoadingEnabled = InternalContext.LazyLoadingEnabled;
		InternalContext.LazyLoadingEnabled = false;
		DbEntityValidationResult dbEntityValidationResult = null;
		try
		{
			return (entityValidator != null) ? entityValidator.Validate(InternalContext.ValidationProvider.GetEntityValidationContext(this, items)) : new DbEntityValidationResult(this, Enumerable.Empty<DbValidationError>());
		}
		finally
		{
			InternalContext.LazyLoadingEnabled = lazyLoadingEnabled;
		}
	}

	/// <summary>
	///     Determines whether the specified <see cref="T:System.Object" /> is equal to this instance.
	///     Two <see cref="T:System.Data.Entity.Internal.InternalEntityEntry" /> instances are considered equal if they are both entries for
	///     the same entity on the same <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <param name="obj">The <see cref="T:System.Object" /> to compare with this instance.</param>
	/// <returns>
	///     <c>true</c> if the specified <see cref="T:System.Object" /> is equal to this instance; otherwise, <c>false</c>.
	/// </returns>
	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj) || obj.GetType() != typeof(InternalEntityEntry))
		{
			return false;
		}
		return Equals((InternalEntityEntry)obj);
	}

	/// <summary>
	///     Determines whether the specified <see cref="T:System.Data.Entity.Internal.InternalEntityEntry" /> is equal to this instance.
	///     Two <see cref="T:System.Data.Entity.Internal.InternalEntityEntry" /> instances are considered equal if they are both entries for
	///     the same entity on the same <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <param name="other">The <see cref="T:System.Data.Entity.Internal.InternalEntityEntry" /> to compare with this instance.</param>
	/// <returns>
	///     <c>true</c> if the specified <see cref="T:System.Data.Entity.Internal.InternalEntityEntry" /> is equal to this instance; otherwise, <c>false</c>.
	/// </returns>
	public bool Equals(InternalEntityEntry other)
	{
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (!object.ReferenceEquals(null, other) && object.ReferenceEquals(_entity, other._entity))
		{
			return object.ReferenceEquals(_internalContext, other._internalContext);
		}
		return false;
	}

	/// <summary>
	///     Returns a hash code for this instance.
	/// </summary>
	/// <returns>
	///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
	/// </returns>
	public override int GetHashCode()
	{
		return _entity.GetHashCode();
	}
}
