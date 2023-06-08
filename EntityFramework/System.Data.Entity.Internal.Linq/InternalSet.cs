using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Data.Entity.Internal.Linq;

internal class InternalSet<TEntity> : InternalQuery<TEntity>, IInternalSet<TEntity>, IInternalSet, IInternalQuery<TEntity>, IInternalQuery where TEntity : class
{
	private DbLocalView<TEntity> _localView;

	private EntitySet _entitySet;

	private string _entitySetName;

	private string _quotedEntitySetName;

	private Type _baseType;

	/// <summary>
	///     Gets the ObservableCollection representing the local view for the set based on this query.
	/// </summary>
	public ObservableCollection<TEntity> Local
	{
		get
		{
			InternalContext.DetectChanges();
			return _localView ?? (_localView = new DbLocalView<TEntity>(InternalContext));
		}
	}

	/// <summary>
	///     The underlying ObjectQuery.  Accessing this property will trigger lazy initialization of the query.
	/// </summary>
	public override ObjectQuery<TEntity> ObjectQuery
	{
		get
		{
			Initialize();
			return base.ObjectQuery;
		}
	}

	/// <summary>
	///     The underlying EntitySet name.  Accessing this property will trigger lazy initialization of the query.
	/// </summary>
	public string EntitySetName
	{
		get
		{
			Initialize();
			return _entitySetName;
		}
	}

	/// <summary>
	///     The underlying EntitySet name, quoted for ESQL.  Accessing this property will trigger lazy initialization of the query.
	/// </summary>
	public string QuotedEntitySetName
	{
		get
		{
			Initialize();
			return _quotedEntitySetName;
		}
	}

	/// <summary>
	///     The underlying EntitySet.  Accessing this property will trigger lazy initialization of the query.
	/// </summary>
	public EntitySet EntitySet
	{
		get
		{
			Initialize();
			return _entitySet;
		}
	}

	/// <summary>
	///     The base type for the underlying entity set.  Accessing this property will trigger lazy initialization of the query.
	/// </summary>
	public Type EntitySetBaseType
	{
		get
		{
			Initialize();
			return _baseType;
		}
	}

	/// <summary>
	///     The underlying InternalContext.  Accessing this property will trigger lazy initialization of the query.
	/// </summary>
	public override InternalContext InternalContext
	{
		get
		{
			Initialize();
			return base.InternalContext;
		}
	}

	/// <summary>
	///     The LINQ query expression.
	/// </summary>
	public override Expression Expression
	{
		get
		{
			Initialize();
			return base.Expression;
		}
	}

	/// <summary>
	///     The LINQ query provider for the underlying <see cref="P:System.Data.Entity.Internal.Linq.InternalSet`1.ObjectQuery" />.
	/// </summary>
	public override IQueryProvider ObjectQueryProvider
	{
		get
		{
			Initialize();
			return base.ObjectQueryProvider;
		}
	}

	/// <summary>
	///     Creates a new query that will be backed by the given InternalContext.
	/// </summary>
	/// <param name="internalContext">The backing context.</param>
	public InternalSet(InternalContext internalContext)
		: base(internalContext)
	{
	}

	/// <summary>
	///     Resets the set to its uninitialized state so that it will be re-lazy initialized the next
	///     time it is used.  This allows the ObjectContext backing a DbContext to be switched out.
	/// </summary>
	public override void ResetQuery()
	{
		_entitySet = null;
		_localView = null;
		base.ResetQuery();
	}

	/// <summary>
	///     Finds an entity with the given primary key values.
	///     If an entity with the given primary key values exists in the context, then it is
	///     returned immediately without making a request to the store.  Otherwise, a request
	///     is made to the store for an entity with the given primary key values and this entity,
	///     if found, is attached to the context and returned.  If no entity is found in the
	///     context or the store, then null is returned.
	/// </summary>
	/// <remarks>
	///     The ordering of composite key values is as defined in the EDM, which is in turn as defined in
	///     the designer, by the Code First fluent API, or by the DataMember attribute.
	/// </remarks>
	/// <param name="keyValues">The values of the primary key for the entity to be found.</param>
	/// <returns>The entity found, or null.</returns>
	/// <exception cref="T:System.InvalidOperationException">Thrown if multiple entities exist in the context with the primary key values given.</exception>
	/// <exception cref="T:System.InvalidOperationException">Thrown if the type of entity is not part of the data model for this context.</exception>
	/// <exception cref="T:System.InvalidOperationException">Thrown if the types of the key values do not match the types of the key values for the entity type to be found.</exception>
	/// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
	public TEntity Find(params object[] keyValues)
	{
		InternalContext.DetectChanges();
		WrappedEntityKey key = new WrappedEntityKey(EntitySet, EntitySetName, keyValues, "keyValues");
		object obj = FindInStateManager(key) ?? FindInStore(key, "keyValues");
		if (obj != null && !(obj is TEntity))
		{
			throw Error.DbSet_WrongEntityTypeFound(obj.GetType().Name, typeof(TEntity).Name);
		}
		return (TEntity)obj;
	}

	/// <summary>
	///     Finds an entity in the state manager with the given primary key values, or returns null
	///     if no such entity can be found.  This includes looking for Added entities with the given
	///     key values.
	/// </summary>
	private object FindInStateManager(WrappedEntityKey key)
	{
		if (!key.HasNullValues && InternalContext.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(key.EntityKey, out var entry))
		{
			return entry.Entity;
		}
		object obj = null;
		foreach (ObjectStateEntry item in from e in InternalContext.ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
			where !e.IsRelationship && e.Entity != null && EntitySetBaseType.IsAssignableFrom(e.Entity.GetType())
			select e)
		{
			bool flag = true;
			foreach (KeyValuePair<string, object> keyValuePair in key.KeyValuePairs)
			{
				int ordinal = item.CurrentValues.GetOrdinal(keyValuePair.Key);
				if (!DbHelpers.KeyValuesEqual(keyValuePair.Value, item.CurrentValues.GetValue(ordinal)))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				if (obj != null)
				{
					throw Error.DbSet_MultipleAddedEntitiesFound();
				}
				obj = item.Entity;
			}
		}
		return obj;
	}

	/// <summary>
	///     Finds an entity in the store with the given primary key values, or returns null
	///     if no such entity can be found.  This code is adapted from TryGetObjectByKey to
	///     include type checking in the query.
	/// </summary>
	private object FindInStore(WrappedEntityKey key, string keyValuesParamName)
	{
		if (key.HasNullValues)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("SELECT VALUE X FROM {0} AS X WHERE ", QuotedEntitySetName);
		EntityKeyMember[] entityKeyValues = key.EntityKey.EntityKeyValues;
		ObjectParameter[] array = new ObjectParameter[entityKeyValues.Length];
		for (int i = 0; i < entityKeyValues.Length; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(" AND ");
			}
			string text = string.Format(CultureInfo.InvariantCulture, "p{0}", new object[1] { i.ToString(CultureInfo.InvariantCulture) });
			stringBuilder.AppendFormat("X.{0} = @{1}", DbHelpers.QuoteIdentifier(entityKeyValues[i].Key), text);
			array[i] = new ObjectParameter(text, entityKeyValues[i].Value);
		}
		try
		{
			return InternalContext.ObjectContext.CreateQuery<TEntity>(stringBuilder.ToString(), array).SingleOrDefault();
		}
		catch (EntitySqlException innerException)
		{
			throw new ArgumentException(Strings.DbSet_WrongKeyValueType, keyValuesParamName, innerException);
		}
	}

	/// <summary>
	///     Attaches the given entity to the context underlying the set.  That is, the entity is placed
	///     into the context in the Unchanged state, just as if it had been read from the database.
	/// </summary>
	/// <remarks>
	///     Attach is used to repopulate a context with an entity that is known to already exist in the database.
	///     SaveChanges will therefore not attempt to insert an attached entity into the database because
	///     it is assumed to already be there.
	///     Note that entities that are already in the context in some other state will have their state set
	///     to Unchanged.  Attach is a no-op if the entity is already in the context in the Unchanged state.
	///     This method is virtual so that it can be mocked.
	/// </remarks>
	/// <param name="entity">The entity to attach.</param>
	public virtual void Attach(object entity)
	{
		ActOnSet(delegate
		{
			InternalContext.ObjectContext.AttachTo(EntitySetName, entity);
		}, EntityState.Unchanged, entity, "Attach");
	}

	/// <summary>
	///     Adds the given entity to the context underlying the set in the Added state such that it will
	///     be inserted into the database when SaveChanges is called.
	/// </summary>
	/// <remarks>
	///     Note that entities that are already in the context in some other state will have their state set
	///     to Added.  Add is a no-op if the entity is already in the context in the Added state.
	///     This method is virtual so that it can be mocked.
	/// </remarks>
	/// <param name="entity">The entity to add.</param>
	public virtual void Add(object entity)
	{
		ActOnSet(delegate
		{
			InternalContext.ObjectContext.AddObject(EntitySetName, entity);
		}, EntityState.Added, entity, "Add");
	}

	/// <summary>
	///     Marks the given entity as Deleted such that it will be deleted from the database when SaveChanges
	///     is called.  Note that the entity must exist in the context in some other state before this method
	///     is called.
	/// </summary>
	/// <remarks>
	///     Note that if the entity exists in the context in the Added state, then this method
	///     will cause it to be detached from the context.  This is because an Added entity is assumed not to
	///     exist in the database such that trying to delete it does not make sense.
	///     This method is virtual so that it can be mocked.
	/// </remarks>
	/// <param name="entity">The entity to remove.</param>
	public virtual void Remove(object entity)
	{
		if (!(entity is TEntity))
		{
			throw Error.DbSet_BadTypeForAddAttachRemove("Remove", entity.GetType().Name, typeof(TEntity).Name);
		}
		InternalContext.DetectChanges();
		InternalContext.ObjectContext.DeleteObject(entity);
	}

	/// <summary>
	///     This method checks whether an entity is already in the context.  If it is, then the state
	///     is changed to the new state given.  If it isn't, then the action delegate is executed to
	///     either Add or Attach the entity.
	/// </summary>
	/// <param name="action">A delegate to Add or Attach the entity.</param>
	/// <param name="newState">The new state to give the entity if it is already in the context.</param>
	/// <param name="entity">The entity.</param>
	/// <param name="methodName">Name of the method.</param>
	private void ActOnSet(Action action, EntityState newState, object entity, string methodName)
	{
		if (!(entity is TEntity))
		{
			throw Error.DbSet_BadTypeForAddAttachRemove(methodName, entity.GetType().Name, typeof(TEntity).Name);
		}
		InternalContext.DetectChanges();
		if (InternalContext.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out var entry))
		{
			entry.ChangeState(newState);
		}
		else
		{
			action();
		}
	}

	/// <summary>
	///     Creates a new instance of an entity for the type of this set.
	///     Note that this instance is NOT added or attached to the set.
	///     The instance returned will be a proxy if the underlying context is configured to create
	///     proxies and the entity type meets the requirements for creating a proxy.
	/// </summary>
	/// <returns>The entity instance, which may be a proxy.</returns>
	public TEntity Create()
	{
		return InternalContext.CreateObject<TEntity>();
	}

	/// <summary>
	///     Creates a new instance of an entity for the type of this set or for a type derived
	///     from the type of this set.
	///     Note that this instance is NOT added or attached to the set.
	///     The instance returned will be a proxy if the underlying context is configured to create
	///     proxies and the entity type meets the requirements for creating a proxy.
	/// </summary>
	/// <param name="derivedEntityType">The type of entity to create.</param>
	/// <returns> The entity instance, which may be a proxy. </returns>
	public TEntity Create(Type derivedEntityType)
	{
		if (!typeof(TEntity).IsAssignableFrom(derivedEntityType))
		{
			throw Error.DbSet_BadTypeForCreate(derivedEntityType.Name, typeof(TEntity).Name);
		}
		return (TEntity)InternalContext.CreateObject(derivedEntityType);
	}

	/// <summary>
	///     Performs lazy initialization of the underlying ObjectContext, ObjectQuery, and EntitySet objects
	///     so that the query can be used.
	///     This method is virtual so that it can be mocked.
	/// </summary>
	public virtual void Initialize()
	{
		if (_entitySet == null)
		{
			InitializeUnderlyingTypes(base.InternalContext.GetEntitySetAndBaseTypeForType(typeof(TEntity)));
		}
	}

	/// <summary>
	/// Attempts to perform lazy initialization of the underlying ObjectContext, ObjectQuery, and EntitySet objects
	/// so that o-space loading has happened and the query can be used. This method doesn't throw if the type
	/// for the set is not mapped.
	/// </summary>
	public virtual void TryInitialize()
	{
		if (_entitySet == null)
		{
			EntitySetTypePair entitySetTypePair = base.InternalContext.TryGetEntitySetAndBaseTypeForType(typeof(TEntity));
			if (entitySetTypePair != null)
			{
				InitializeUnderlyingTypes(entitySetTypePair);
			}
		}
	}

	private void InitializeUnderlyingTypes(EntitySetTypePair pair)
	{
		_entitySet = pair.EntitySet;
		_baseType = pair.BaseType;
		_entitySetName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", new object[2]
		{
			_entitySet.EntityContainer.Name,
			_entitySet.Name
		});
		_quotedEntitySetName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", new object[2]
		{
			DbHelpers.QuoteIdentifier(_entitySet.EntityContainer.Name),
			DbHelpers.QuoteIdentifier(_entitySet.Name)
		});
		bool asNoTracking = false;
		InitializeQuery(CreateObjectQuery(asNoTracking));
	}

	/// <summary>
	///     Creates an underlying <see cref="T:System.Data.Objects.ObjectQuery`1" /> for this set.
	/// </summary>
	/// <param name="asNoTracking">if set to <c>true</c> then the query is set to be no-tracking.</param>
	/// <returns>The query.</returns>
	private ObjectQuery<TEntity> CreateObjectQuery(bool asNoTracking)
	{
		ObjectQuery<TEntity> objectQuery = InternalContext.ObjectContext.CreateQuery<TEntity>(_quotedEntitySetName, new ObjectParameter[0]);
		if (_baseType != typeof(TEntity))
		{
			objectQuery = objectQuery.OfType<TEntity>();
		}
		if (asNoTracking)
		{
			objectQuery.MergeOption = MergeOption.NoTracking;
		}
		return objectQuery;
	}

	/// <summary>
	///     Returns a <see cref="T:System.String" /> representation of the underlying query, equivalent
	///     to ToTraceString on ObjectQuery.
	/// </summary>
	/// <returns>
	///     The query string.
	/// </returns>
	public override string ToString()
	{
		Initialize();
		return base.ToString();
	}

	/// <summary>
	///     Updates the underlying ObjectQuery with the given include path.
	/// </summary>
	/// <param name="path">The include path.</param>
	/// <returns>A new query containing the defined include path.</returns>
	public override IInternalQuery<TEntity> Include(string path)
	{
		Initialize();
		return base.Include(path);
	}

	/// <summary>
	///     Returns a new query where the entities returned will not be cached in the <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <returns> A new query with NoTracking applied.</returns>
	public override IInternalQuery<TEntity> AsNoTracking()
	{
		Initialize();
		InternalContext internalContext = InternalContext;
		bool asNoTracking = true;
		return new InternalQuery<TEntity>(internalContext, CreateObjectQuery(asNoTracking));
	}

	/// <summary>
	///     Executes the given SQL query against the database materializing entities into the entity set that
	///     backs this set.
	/// </summary>
	/// <param name="sql">The SQL quey.</param>
	/// <param name="asNoTracking">if <c>true</c> then the entities are not tracked, otherwise they are.</param>
	/// <param name="parameters">The parameters.</param>
	/// <returns>The query results.</returns>
	public IEnumerable ExecuteSqlQuery(string sql, bool asNoTracking, object[] parameters)
	{
		Initialize();
		MergeOption mergeOption = (asNoTracking ? MergeOption.NoTracking : MergeOption.AppendOnly);
		return InternalContext.ObjectContext.ExecuteStoreQuery<TEntity>(sql, EntitySetName, mergeOption, parameters);
	}

	/// <summary>
	///     Gets the enumeration of this query causing it to be executed against the store.
	/// </summary>
	/// <returns>An enumerator for the query</returns>
	public override IEnumerator<TEntity> GetEnumerator()
	{
		Initialize();
		return base.GetEnumerator();
	}
}
