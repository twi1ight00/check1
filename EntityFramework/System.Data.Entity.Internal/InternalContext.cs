using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Internal.Linq;
using System.Data.Entity.Internal.Validation;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Entity.Validation;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     An <see cref="T:System.Data.Entity.Internal.InternalContext" /> underlies every instance of <see cref="T:System.Data.Entity.DbContext" /> and wraps an
///     <see cref="P:System.Data.Entity.Internal.InternalContext.ObjectContext" /> instance.
///     The <see cref="T:System.Data.Entity.Internal.InternalContext" /> also acts to expose necessary information to other parts of the design in a
///     controlled manner without adding a lot of internal methods and properties to the <see cref="T:System.Data.Entity.DbContext" />
///     class itself.
///     Two concrete classes derive from this abstract class - <see cref="T:System.Data.Entity.Internal.LazyInternalContext" /> and
///     <see cref="T:System.Data.Entity.Internal.EagerInternalContext" />.
/// </summary>
internal abstract class InternalContext
{
	private static readonly MethodInfo InternalContext_CreateObjectAsObject = typeof(InternalContext).GetMethod("CreateObjectAsObject", BindingFlags.Instance | BindingFlags.NonPublic);

	private static readonly ConcurrentDictionary<Type, Func<InternalContext, object>> EntityFactories = new ConcurrentDictionary<Type, Func<InternalContext, object>>();

	private static readonly MethodInfo InternalContext_ExecuteSqlQueryAsIEnumerable = typeof(InternalContext).GetMethod("ExecuteSqlQueryAsIEnumerable", BindingFlags.Instance | BindingFlags.NonPublic);

	private static readonly ConcurrentDictionary<Type, Func<InternalContext, string, object[], IEnumerable>> QueryExecutors = new ConcurrentDictionary<Type, Func<InternalContext, string, object[], IEnumerable>>();

	private static readonly ConcurrentDictionary<Type, Func<InternalContext, IInternalSet, IInternalSetAdapter>> SetFactories = new ConcurrentDictionary<Type, Func<InternalContext, IInternalSet, IInternalSetAdapter>>();

	private AppConfig _appConfig = AppConfig.DefaultInstance;

	private readonly DbContext _owner;

	private IDictionary<Type, EntitySetTypePair> _entitySetMappings;

	private ObjectContext _tempObjectContext;

	private int _tempObjectContextCount;

	private readonly Dictionary<Type, IInternalSetAdapter> _genericSets = new Dictionary<Type, IInternalSetAdapter>();

	private readonly Dictionary<Type, IInternalSetAdapter> _nonGenericSets = new Dictionary<Type, IInternalSetAdapter>();

	private readonly ValidationProvider _validationProvider = new ValidationProvider();

	private bool _inInitializationAction;

	private bool _oSpaceLoadingForced;

	/// <summary>
	///     The public context instance that owns this internal context.
	/// </summary>
	public DbContext Owner => _owner;

	/// <summary>
	///     Returns the underlying <see cref="P:System.Data.Entity.Internal.InternalContext.ObjectContext" />.
	/// </summary>
	public abstract ObjectContext ObjectContext { get; }

	/// <summary>
	///     Gets the temp object context, or null if none has been set.
	/// </summary>
	/// <value>The temp object context.</value>
	protected ObjectContext TempObjectContext => _tempObjectContext;

	/// <summary>
	/// The compiled model created from the Code First pipeline, or null if Code First was
	/// not used to create this context.
	/// Causes the Code First pipeline to be run to create the model if it has not already been
	/// created.
	/// </summary>
	public virtual DbCompiledModel CodeFirstModel => null;

	/// <summary>
	///     Gets the default database initializer to use for this context if no other has been registered.
	///     For code first this property returns a <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1" /> instance.
	///     For database/model first, this property returns null.
	/// </summary>
	/// <value>The default initializer.</value>
	public abstract IDatabaseInitializer<DbContext> DefaultInitializer { get; }

	/// <summary>
	///     Gets or sets a value indicating whether lazy loading is enabled.
	/// </summary>
	public abstract bool LazyLoadingEnabled { get; set; }

	/// <summary>
	///     Gets or sets a value indicating whether proxy creation is enabled.
	/// </summary>
	public abstract bool ProxyCreationEnabled { get; set; }

	/// <summary>
	///     Gets or sets a value indicating whether DetectChanges is called automatically in the API.
	/// </summary>
	public bool AutoDetectChangesEnabled { get; set; }

	/// <summary>
	///     Gets or sets a value indicating whether to validate entities when <see cref="M:System.Data.Entity.DbContext.SaveChanges" /> is called.
	/// </summary>
	public bool ValidateOnSaveEnabled { get; set; }

	/// <summary>
	///     True if the context has been disposed.
	/// </summary>
	public bool IsDisposed { get; private set; }

	/// <summary>
	///     The connection underlying this context.  Accessing this property does not cause the context
	///     to be initialized, only its connection.
	/// </summary>
	public abstract DbConnection Connection { get; }

	/// <summary>
	/// The connection string as originally applied to the context. This is used to perform operations
	/// that need the connection string in a non-mutated form, such as with security info still intact.
	/// </summary>
	public abstract string OriginalConnectionString { get; }

	/// <summary>
	///     Returns the origin of the underlying connection string.
	/// </summary>
	public abstract DbConnectionStringOrigin ConnectionStringOrigin { get; }

	/// <summary>
	///     Gets or sets an object representing a config file used for looking for DefaultConnectionFactory entries,
	///     database intializers and connection strings.
	/// </summary>
	public virtual AppConfig AppConfig
	{
		get
		{
			CheckContextNotDisposed();
			return _appConfig;
		}
		set
		{
			CheckContextNotDisposed();
			_appConfig = value;
		}
	}

	/// <summary>
	///     Gets or sets the provider details to be used when building the EDM model.
	/// </summary>
	public virtual DbProviderInfo ModelProviderInfo
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets the provider name bsing used either using a cached value or getting it from
	/// the DbConnection in use.
	/// </summary>
	public virtual string ProviderName => Connection.GetProviderInvariantName();

	/// <summary>
	///     Gets the name of the underlying connection string.
	/// </summary>
	public virtual string ConnectionStringName => null;

	/// <summary>
	///     Gets or sets a custom OnModelCreating action.
	/// </summary>
	public virtual Action<DbModelBuilder> OnModelCreating
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	/// <summary>
	///     Gets the DatabaseOperations instance to use to perform Create/Delete/Exists operations
	///     against the database.
	///     Note that this virtual property can be mocked to help with unit testing.
	/// </summary>
	public virtual DatabaseOperations DatabaseOperations => new DatabaseOperations();

	/// <summary>
	///     Gets <see cref="P:System.Data.Entity.Internal.InternalContext.ValidationProvider" /> instance used to create validators and validation contexts.
	///     This property is virtual to allow mocking.
	/// </summary>
	public virtual ValidationProvider ValidationProvider => _validationProvider;

	/// <summary>
	///     Initializes the <see cref="T:System.Data.Entity.Internal.InternalContext" /> object with its <see cref="T:System.Data.Entity.DbContext" /> owner.
	/// </summary>
	/// <param name="owner">The owner <see cref="T:System.Data.Entity.DbContext" />.</param>
	protected InternalContext(DbContext owner)
	{
		_owner = owner;
		AutoDetectChangesEnabled = true;
		ValidateOnSaveEnabled = true;
	}

	/// <summary>
	///     Returns the underlying <see cref="P:System.Data.Entity.Internal.InternalContext.ObjectContext" /> without causing the underlying database to be created
	///     or the database initialization strategy to be executed.
	///     This is used to get a context that can then be used for database creation/initialization.
	/// </summary>
	public abstract ObjectContext GetObjectContextWithoutDatabaseInitialization();

	/// <summary>
	///     Creates a cloned ObjectContext suitable for use with DDL operations.
	/// </summary>
	public virtual ObjectContext CreateObjectContextForDdlOps()
	{
		InitializeContext();
		bool transferLoadedAssemblies = false;
		return DbHelpers.CloneObjectContext(GetObjectContextWithoutDatabaseInitialization(), OriginalConnectionString, transferLoadedAssemblies);
	}

	/// <summary>
	///     Creates a new temporary <see cref="P:System.Data.Entity.Internal.InternalContext.ObjectContext" /> based on the same metadata and connection as the real
	///     <see cref="P:System.Data.Entity.Internal.InternalContext.ObjectContext" /> and sets it as the context to use DisposeTempObjectContext is called.
	///     This allows this internal context and its DbContext to be used for transient operations
	///     such as initializing and seeding the database, after which it can be thrown away.
	///     This isolates the real <see cref="P:System.Data.Entity.Internal.InternalContext.ObjectContext" /> from any changes made and and saves performed.
	/// </summary>
	public virtual void UseTempObjectContext()
	{
		_tempObjectContextCount++;
		if (_tempObjectContext == null)
		{
			_tempObjectContext = DbHelpers.CloneObjectContext(GetObjectContextWithoutDatabaseInitialization(), OriginalConnectionString);
			InitializeEntitySetMappings();
		}
	}

	/// <summary>
	///     If a temporary ObjectContext was set with UseTempObjectContext, then this method disposes that context
	///     and returns this internal context and its DbContext to using the real ObjectContext.
	/// </summary>
	public virtual void DisposeTempObjectContext()
	{
		if (_tempObjectContextCount > 0 && --_tempObjectContextCount == 0 && _tempObjectContext != null)
		{
			ObjectContext tempObjectContext = _tempObjectContext;
			DbConnection storeConnection = ((EntityConnection)tempObjectContext.Connection).StoreConnection;
			_tempObjectContext = null;
			tempObjectContext.Dispose();
			storeConnection.Dispose();
			InitializeEntitySetMappings();
		}
	}

	/// <summary>
	/// Internal implementation of <see cref="M:System.Data.Entity.Database.CompatibleWithModel(System.Boolean)" />.
	/// </summary>
	/// <returns> True if the model hash in the context and the database match; false otherwise.</returns>
	public virtual bool CompatibleWithModel(bool throwIfNoMetadata)
	{
		return new ModelCompatibilityChecker().CompatibleWithModel(this, new ModelHashCalculator(), throwIfNoMetadata);
	}

	/// <summary>
	/// Called by methods of <see cref="T:System.Data.Entity.Database" /> to create a database either using the Migrations pipeline
	/// if possible and the core provider otherwise.
	/// </summary>
	/// <param name="objectContext">The context to use for core provider calls.</param>
	public virtual void CreateDatabase(ObjectContext objectContext)
	{
		new DatabaseCreator().CreateDatabase(this, (DbMigrationsConfiguration config, DbContext context) => new DbMigrator(config, context), objectContext);
	}

	/// <summary>
	/// Checks whether the given model (an EDMX document) matches the current model.
	/// </summary>
	public virtual bool ModelMatches(XDocument model)
	{
		EdmModelDiffer edmModelDiffer = new EdmModelDiffer();
		string connectionString = null;
		return !edmModelDiffer.Diff(model, Owner.GetModel(), connectionString).Any();
	}

	/// <summary>
	///     Queries the database for a model hash and returns it if found or returns null if the table
	///     or the row doesn't exist in the database.
	/// </summary>
	/// <returns>The model hash, or null if not found.</returns>
	public virtual string QueryForModelHash()
	{
		return new EdmMetadataRepository(OriginalConnectionString, DbProviderServices.GetProviderFactory(Connection)).QueryForModelHash((DbConnection c) => new EdmMetadataContext(c));
	}

	/// <summary>
	/// Queries the database for a model stored in the MigrationHistory table and returns it as an EDMX, or returns
	/// null if the database does not contain a model.
	/// </summary>
	public virtual XDocument QueryForModel()
	{
		return new HistoryRepository(OriginalConnectionString, DbProviderServices.GetProviderFactory(Connection)).GetLastModel();
	}

	/// <summary>
	///     Saves the model hash from the context to the database.
	/// </summary>
	public virtual void SaveMetadataToDatabase()
	{
		if (CodeFirstModel != null)
		{
			PerformInitializationAction(delegate
			{
				new HistoryRepository(OriginalConnectionString, DbProviderServices.GetProviderFactory(Connection)).BootstrapUsingEFProviderDdl(Owner.GetModel());
			});
		}
	}

	/// <summary>
	///     Performs the initialization action that may result in a <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> and
	///     handle the exception to provide more meaning to the user.
	/// </summary>
	/// <param name="action">The action.</param>
	public void PerformInitializationAction(Action action)
	{
		if (_inInitializationAction)
		{
			action();
			return;
		}
		try
		{
			_inInitializationAction = true;
			action();
		}
		catch (DataException innerException)
		{
			throw new DataException(Strings.Database_InitializationException, innerException);
		}
		finally
		{
			_inInitializationAction = false;
		}
	}

	/// <summary>
	///     Registers for the ObjectStateManagerChanged event on the underlying ObjectStateManager.
	///     This is a virtual method on this class so that it can be mocked.
	/// </summary>
	/// <param name="handler">The event handler.</param>
	public virtual void RegisterObjectStateManagerChangedEvent(CollectionChangeEventHandler handler)
	{
		ObjectContext.ObjectStateManager.ObjectStateManagerChanged += handler;
	}

	/// <summary>
	///     Checks whether or not the given object is in the context in any state other than Deleted.
	///     This is a virtual method on this class so that it can be mocked.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns><c>true</c> if the entity is in the context and not deleted; otherwise <c>false</c>.</returns>
	public virtual bool EntityInContextAndNotDeleted(object entity)
	{
		if (ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out var entry))
		{
			return entry.State != EntityState.Deleted;
		}
		return false;
	}

	/// <summary>
	///     Saves all changes made in this context to the underlying database.
	/// </summary>
	/// <returns>The number of objects written to the underlying database.</returns>
	public virtual int SaveChanges()
	{
		try
		{
			if (ValidateOnSaveEnabled)
			{
				IEnumerable<DbEntityValidationResult> validationErrors = Owner.GetValidationErrors();
				if (validationErrors.Any())
				{
					throw new DbEntityValidationException(Strings.DbEntityValidationException_ValidationFailed, validationErrors);
				}
			}
			bool flag = AutoDetectChangesEnabled && !ValidateOnSaveEnabled;
			System.Data.Objects.SaveOptions options = System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave | (flag ? System.Data.Objects.SaveOptions.DetectChangesBeforeSave : System.Data.Objects.SaveOptions.None);
			return ObjectContext.SaveChanges(options);
		}
		catch (UpdateException updateException)
		{
			throw WrapUpdateException(updateException);
		}
	}

	/// <summary>
	///     Initializes this instance, which means both the context is initialized and the underlying
	///     database is initialized.
	/// </summary>
	public void Initialize()
	{
		InitializeContext();
		InitializeDatabase();
	}

	/// <summary>
	///     Initializes the underlying ObjectContext but does not cause the database to be initialized.
	/// </summary>
	protected abstract void InitializeContext();

	/// <summary>
	///     Runs the <see cref="T:System.Data.Entity.IDatabaseInitializer`1" /> unless it has already been run or there
	///     is no initializer for this context type in which case this method does nothing.
	/// </summary>
	protected abstract void InitializeDatabase();

	/// <summary>
	///     Marks the database as having been initialized without actually running the <see cref="T:System.Data.Entity.IDatabaseInitializer`1" />.
	/// </summary>
	public abstract void MarkDatabaseInitialized();

	/// <summary>
	///     Runs the <see cref="T:System.Data.Entity.IDatabaseInitializer`1" /> if one has been set for this context type.
	///     Calling this method will always cause the initializer to run even if the database is marked
	///     as initialized.
	/// </summary>
	public void PerformDatabaseInitialization()
	{
		AppConfig.ApplyInitializers();
		Action<DbContext> executor = Owner.Database.InitializerDelegate;
		if (executor == null)
		{
			return;
		}
		try
		{
			UseTempObjectContext();
			PerformInitializationAction(delegate
			{
				executor(Owner);
			});
		}
		finally
		{
			DisposeTempObjectContext();
		}
	}

	/// <summary>
	///     Disposes the context. Override the DisposeContext method to perform
	///     additional work when disposing.
	/// </summary>
	public void Dispose()
	{
		DisposeContext();
		IsDisposed = true;
	}

	/// <summary>
	///     Performs additional work to dispose a context.  The default implementation
	///     does nothing.
	/// </summary>
	public virtual void DisposeContext()
	{
	}

	/// <summary>
	///     Calls DetectChanges on the underlying <see cref="P:System.Data.Entity.Internal.InternalContext.ObjectContext" /> if AutoDetectChangesEnabled is
	///     true or if force is set to true.
	/// </summary>
	/// <param name="force">if set to <c>true</c> then DetectChanges is called regardless of the value of AutoDetectChangesEnabled.</param>
	public virtual void DetectChanges(bool force = false)
	{
		if (AutoDetectChangesEnabled || force)
		{
			ObjectContext.DetectChanges();
		}
	}

	/// <summary>
	///     Returns the DbSet instance for the given entity type.
	///     This property is virtual and returns <see cref="T:System.Data.Entity.IDbSet`1" /> to that it can be mocked.
	/// </summary>
	/// <typeparam name="TEntity">The entity type for which a set should be returned.</typeparam>
	/// <returns>A set for the given entity type.</returns>
	public virtual IDbSet<TEntity> Set<TEntity>() where TEntity : class
	{
		if (!_genericSets.TryGetValue(typeof(TEntity), out var value))
		{
			IInternalSet internalSet = (_nonGenericSets.TryGetValue(typeof(TEntity), out value) ? value.InternalSet : new InternalSet<TEntity>(this));
			value = new DbSet<TEntity>((InternalSet<TEntity>)internalSet);
			_genericSets.Add(typeof(TEntity), value);
		}
		return (IDbSet<TEntity>)value;
	}

	/// <summary>
	///     Returns the non-generic <see cref="T:System.Data.Entity.DbSet" /> instance for the given entity type.
	///     This property is virtual and returns <see cref="T:System.Data.Entity.Internal.Linq.IInternalSetAdapter" /> to that it can be mocked.
	/// </summary>
	/// <param name="entityType">The entity type for which a set should be returned.</param>
	/// <returns>A set for the given entity type.</returns>
	public virtual IInternalSetAdapter Set(Type entityType)
	{
		if (!_nonGenericSets.TryGetValue(entityType, out var value))
		{
			value = CreateInternalSet(entityType, _genericSets.TryGetValue(entityType, out value) ? value.InternalSet : null);
			_nonGenericSets.Add(entityType, value);
		}
		return value;
	}

	/// <summary>
	///     Creates an internal set using an app domain cached delegate.
	/// </summary>
	/// <param name="entityType">Type of the entity.</param>
	/// <returns>The set.</returns>
	private IInternalSetAdapter CreateInternalSet(Type entityType, IInternalSet internalSet)
	{
		if (!SetFactories.TryGetValue(entityType, out var value))
		{
			if (entityType.IsValueType)
			{
				throw Error.DbSet_EntityTypeNotInModel(entityType.Name);
			}
			Type type = typeof(InternalDbSet<>).MakeGenericType(entityType);
			MethodInfo method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public, null, new Type[2]
			{
				typeof(InternalContext),
				typeof(IInternalSet)
			}, null);
			value = (Func<InternalContext, IInternalSet, IInternalSetAdapter>)Delegate.CreateDelegate(typeof(Func<InternalContext, IInternalSet, IInternalSetAdapter>), method);
			SetFactories.TryAdd(entityType, value);
		}
		return value(this, internalSet);
	}

	/// <summary>
	///     Returns the entity set and the base type for that entity set for the given type.
	///     This method does o-space loading if required and throws if the type is not in the model.
	/// </summary>
	/// <param name="entityType">The entity type to lookup.</param>
	/// <returns>The entity set and base type pair.</returns>
	public virtual EntitySetTypePair GetEntitySetAndBaseTypeForType(Type entityType)
	{
		Initialize();
		UpdateEntitySetMappingsForType(entityType);
		return _entitySetMappings[entityType];
	}

	/// <summary>
	/// Returns the entity set and the base type for that entity set for the given type if that
	/// type is mapped in the model, otherwise returns null.
	/// This method does o-space loading if required.
	/// </summary>
	/// <param name="entityType">The entity type to lookup.</param>
	/// <returns>The entity set and base type pair, or null if not found.</returns>
	public virtual EntitySetTypePair TryGetEntitySetAndBaseTypeForType(Type entityType)
	{
		Initialize();
		if (!TryUpdateEntitySetMappingsForType(entityType))
		{
			return null;
		}
		return _entitySetMappings[entityType];
	}

	/// <summary>
	///     Checks whether or not the given entity type is mapped in the model.
	/// </summary>
	/// <param name="entityType">The entity type to lookup.</param>
	/// <returns>True if the type is mapped as an entity; false otherwise.</returns>
	public virtual bool IsEntityTypeMapped(Type entityType)
	{
		Initialize();
		return TryUpdateEntitySetMappingsForType(entityType);
	}

	/// <summary>
	///     Gets the local entities of the type specified from the state manager.  That is, all
	///     Added, Modified, and Unchanged entities of the given type.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity to get.</typeparam>
	/// <returns>The entities.</returns>
	public virtual IEnumerable<TEntity> GetLocalEntities<TEntity>()
	{
		return from e in ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Unchanged | EntityState.Added | EntityState.Modified)
			where e.Entity is TEntity
			select (TEntity)e.Entity;
	}

	/// <summary>
	///     Executes the given SQL query against the database backing this context.  The results are not materialized as
	///     entities or tracked.
	/// </summary>
	/// <typeparam name="TElement">The type of the element.</typeparam>
	/// <param name="sql">The SQL.</param>
	/// <param name="parameters">The parameters.</param>
	/// <returns>The query results.</returns>
	public virtual IEnumerable<TElement> ExecuteSqlQuery<TElement>(string sql, object[] parameters)
	{
		Initialize();
		return ObjectContext.ExecuteStoreQuery<TElement>(sql, parameters);
	}

	/// <summary>
	///     Executes the given SQL query against the database backing this context.  The results are not materialized as
	///     entities or tracked.
	/// </summary>
	/// <param name="elementType">Type of the element.</param>
	/// <param name="sql">The SQL.</param>
	/// <param name="parameters">The parameters.</param>
	/// <returns>The query results.</returns>
	public virtual IEnumerable ExecuteSqlQuery(Type elementType, string sql, object[] parameters)
	{
		if (!QueryExecutors.TryGetValue(elementType, out var value))
		{
			MethodInfo method = InternalContext_ExecuteSqlQueryAsIEnumerable.MakeGenericMethod(elementType);
			value = (Func<InternalContext, string, object[], IEnumerable>)Delegate.CreateDelegate(typeof(Func<InternalContext, string, object[], IEnumerable>), method);
			QueryExecutors.TryAdd(elementType, value);
		}
		return value(this, sql, parameters);
	}

	/// <summary>
	///     Calls the generic ExecuteSqlQuery but with a non-generic return type so that it
	///     has the correct signature to be used with CreateDelegate above.
	/// </summary>
	private IEnumerable ExecuteSqlQueryAsIEnumerable<TElement>(string sql, object[] parameters)
	{
		return ExecuteSqlQuery<TElement>(sql, parameters);
	}

	/// <summary>
	///     Executes the given SQL command against the database backing this context.
	/// </summary>
	/// <param name="sql">The SQL.</param>
	/// <param name="parameters">The parameters.</param>
	/// <returns>The return value from the database.</returns>
	public virtual int ExecuteSqlCommand(string sql, object[] parameters)
	{
		Initialize();
		return ObjectContext.ExecuteStoreCommand(sql, parameters);
	}

	/// <summary>
	///     Gets the underlying <see cref="T:System.Data.Objects.ObjectStateEntry" /> for the given entity, or returns null if the entity isn't tracked by this context.
	///     This method is virtual so that it can be mocked.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns>The state entry or null.</returns>
	public virtual IEntityStateEntry GetStateEntry(object entity)
	{
		DetectChanges();
		if (!ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out var entry))
		{
			return null;
		}
		return new StateEntryAdapter(entry);
	}

	/// <summary>
	///     Gets the underlying <see cref="T:System.Data.Objects.ObjectStateEntry" /> objects for all entities tracked by
	///     this context.
	///     This method is virtual so that it can be mocked.
	/// </summary>
	/// <returns>State entries for all tracked entities.</returns>
	public virtual IEnumerable<IEntityStateEntry> GetStateEntries()
	{
		return GetStateEntries((ObjectStateEntry e) => e.Entity != null);
	}

	/// <summary>
	///     Gets the underlying <see cref="T:System.Data.Objects.ObjectStateEntry" /> objects for all entities of the given
	///     type tracked by this context.
	///     This method is virtual so that it can be mocked.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <returns>State entries for all tracked entities of the given type.</returns>
	public virtual IEnumerable<IEntityStateEntry> GetStateEntries<TEntity>() where TEntity : class
	{
		return GetStateEntries((ObjectStateEntry e) => e.Entity is TEntity);
	}

	/// <summary>
	///     Helper method that gets the underlying <see cref="T:System.Data.Objects.ObjectStateEntry" /> objects for all entities that
	///     match the given predicate.
	/// </summary>
	private IEnumerable<IEntityStateEntry> GetStateEntries(Func<ObjectStateEntry, bool> predicate)
	{
		DetectChanges();
		return from e in ObjectContext.ObjectStateManager.GetObjectStateEntries(~EntityState.Detached).Where(predicate)
			select new StateEntryAdapter(e);
	}

	/// <summary>
	///     Wraps the given <see cref="T:System.Data.UpdateException" /> in either a <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> or
	///     a <see cref="T:System.Data.Entity.Infrastructure.DbUpdateConcurrencyException" /> depending on the actual exception type and the state
	///     entries involved.
	/// </summary>
	/// <param name="updateException">The update exception.</param>
	/// <returns>A new exception wrapping the given exception.</returns>
	public virtual Exception WrapUpdateException(UpdateException updateException)
	{
		if (updateException.StateEntries.Any((ObjectStateEntry e) => e.Entity == null))
		{
			bool involvesIndependentAssociations = true;
			return new DbUpdateException(this, updateException, involvesIndependentAssociations);
		}
		if (!(updateException is OptimisticConcurrencyException innerException))
		{
			bool involvesIndependentAssociations2 = false;
			return new DbUpdateException(this, updateException, involvesIndependentAssociations2);
		}
		return new DbUpdateConcurrencyException(this, innerException);
	}

	/// <summary>
	///     Uses the underlying context to create an entity such that if the context is configured
	///     to create proxies and the entity is suitable then a proxy instance will be returned.
	///     This method is virtual so that it can be mocked.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <returns>The new entity instance.</returns>
	public virtual TEntity CreateObject<TEntity>() where TEntity : class
	{
		return ObjectContext.CreateObject<TEntity>();
	}

	/// <summary>
	///     Uses the underlying context to create an entity such that if the context is configured
	///     to create proxies and the entity is suitable then a proxy instance will be returned.
	///     This method is virtual so that it can be mocked.
	/// </summary>
	/// <param name="type">The type of entity to create.</param>
	/// <returns>The new entity instance.</returns>
	public virtual object CreateObject(Type type)
	{
		if (!EntityFactories.TryGetValue(type, out var value))
		{
			MethodInfo method = InternalContext_CreateObjectAsObject.MakeGenericMethod(type);
			value = (Func<InternalContext, object>)Delegate.CreateDelegate(typeof(Func<InternalContext, object>), method);
			EntityFactories.TryAdd(type, value);
		}
		return value(this);
	}

	/// <summary>
	///     This method is used by CreateDelegate to transform the CreateObject method with return type TEntity
	///     into a method with return type object which matches the required type of the delegate.
	/// </summary>
	private object CreateObjectAsObject<TEntity>() where TEntity : class
	{
		return CreateObject<TEntity>();
	}

	/// <summary>
	///     Replaces the connection that will be used by this context.
	///     The connection can only be changed before the context is initialized.
	/// </summary>
	/// <param name="connection">The new connection.</param>
	public abstract void OverrideConnection(IInternalConnection connection);

	/// <summary>
	///     Throws if the context has been disposed.
	/// </summary>
	protected void CheckContextNotDisposed()
	{
		if (IsDisposed)
		{
			throw Error.DbContext_Disposed();
		}
	}

	/// <summary>
	///     Checks whether or not the internal cache of types to entity sets has been initialized,
	///     and initializes it if necessary.
	/// </summary>
	protected void InitializeEntitySetMappings()
	{
		_entitySetMappings = new Dictionary<Type, EntitySetTypePair>();
		foreach (IInternalSetAdapter item in _genericSets.Values.Union(_nonGenericSets.Values))
		{
			item.InternalSet.ResetQuery();
		}
	}

	/// <summary>
	/// Forces all DbSets to be initialized, which in turn causes o-space loading to happen
	/// for any entity type for which we have a DbSet. This includes all DbSets that were
	/// discovered on the user's DbContext type.
	/// </summary>
	public void ForceOSpaceLoadingForKnownEntityTypes()
	{
		if (_oSpaceLoadingForced)
		{
			return;
		}
		_oSpaceLoadingForced = true;
		Initialize();
		foreach (IInternalSetAdapter item in _genericSets.Values.Union(_nonGenericSets.Values))
		{
			item.InternalSet.TryInitialize();
		}
	}

	/// <summary>
	///     Performs o-space loading for the type and returns false if the type is not in the model.
	/// </summary>
	private bool TryUpdateEntitySetMappingsForType(Type entityType)
	{
		if (_entitySetMappings.ContainsKey(entityType))
		{
			return true;
		}
		Type type = entityType;
		do
		{
			ObjectContext.MetadataWorkspace.LoadFromAssembly(type.Assembly);
			type = type.BaseType;
		}
		while (type != null && type != typeof(object));
		UpdateEntitySetMappings();
		return _entitySetMappings.ContainsKey(entityType);
	}

	/// <summary>
	///     Performs o-space loading for the type and throws if the type is not in the model.
	/// </summary>
	/// <param name="entityType">Type of the entity.</param>
	private void UpdateEntitySetMappingsForType(Type entityType)
	{
		if (!TryUpdateEntitySetMappingsForType(entityType))
		{
			if (IsComplexType(entityType))
			{
				throw Error.DbSet_DbSetUsedWithComplexType(entityType.Name);
			}
			if (IsPocoTypeInNonPocoAssembly(entityType))
			{
				throw Error.DbSet_PocoAndNonPocoMixedInSameAssembly(entityType.Name);
			}
			throw Error.DbSet_EntityTypeNotInModel(entityType.Name);
		}
	}

	/// <summary>
	///     Returns true if the given entity type does not have EdmEntityTypeAttribute but is in
	///     an assembly that has EdmSchemaAttribute.  This indicates mixing of POCO and EOCO in the
	///     same assembly, which is something that we don't support.
	/// </summary>
	private static bool IsPocoTypeInNonPocoAssembly(Type entityType)
	{
		Assembly assembly = entityType.Assembly;
		bool inherit = false;
		if (assembly.GetCustomAttributes(typeof(EdmSchemaAttribute), inherit).Any())
		{
			bool inherit2 = true;
			return !entityType.GetCustomAttributes(typeof(EdmEntityTypeAttribute), inherit2).Any();
		}
		return false;
	}

	/// <summary>
	///     Determines whether or not the given clrType is mapped to a complex type.  Assumes o-space loading has happened.
	/// </summary>
	private bool IsComplexType(Type clrType)
	{
		MetadataWorkspace metadataWorkspace = GetObjectContextWithoutDatabaseInitialization().MetadataWorkspace;
		ObjectItemCollection objectItemCollection = (ObjectItemCollection)metadataWorkspace.GetItemCollection(DataSpace.OSpace);
		ReadOnlyCollection<ComplexType> items = metadataWorkspace.GetItems<ComplexType>(DataSpace.OSpace);
		return items.Where((ComplexType t) => objectItemCollection.GetClrType(t) == clrType).Any();
	}

	/// <summary>
	///     Updates the cache of types to entity sets either for the first time or after potentially
	///     doing some o-space loading.
	/// </summary>
	private void UpdateEntitySetMappings()
	{
		MetadataWorkspace metadataWorkspace = GetObjectContextWithoutDatabaseInitialization().MetadataWorkspace;
		ObjectItemCollection objectItemCollection = (ObjectItemCollection)metadataWorkspace.GetItemCollection(DataSpace.OSpace);
		ReadOnlyCollection<EntityType> items = metadataWorkspace.GetItems<EntityType>(DataSpace.OSpace);
		Stack<EntityType> stack = new Stack<EntityType>();
		foreach (EntityType item in items)
		{
			stack.Clear();
			EntityType cspaceType = (EntityType)metadataWorkspace.GetEdmSpaceType(item);
			do
			{
				stack.Push(cspaceType);
				cspaceType = (EntityType)cspaceType.BaseType;
			}
			while (cspaceType != null);
			EntitySet entitySet = null;
			while (entitySet == null && stack.Count > 0)
			{
				cspaceType = stack.Pop();
				foreach (EntityContainer item2 in metadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace))
				{
					IEnumerable<EntitySetBase> source = item2.BaseEntitySets.Where((EntitySetBase s) => s.ElementType == cspaceType);
					int num = source.Count();
					if (num > 1 || (num == 1 && entitySet != null))
					{
						throw Error.DbContext_MESTNotSupported();
					}
					if (num == 1)
					{
						entitySet = (EntitySet)source.First();
					}
				}
			}
			if (entitySet != null)
			{
				EntityType objectSpaceType = (EntityType)metadataWorkspace.GetObjectSpaceType(cspaceType);
				Type clrType = objectItemCollection.GetClrType(item);
				Type clrType2 = objectItemCollection.GetClrType(objectSpaceType);
				_entitySetMappings[clrType] = new EntitySetTypePair(entitySet, clrType2);
			}
		}
	}
}
