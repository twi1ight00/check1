using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Resources;
using System.Data.EntityClient;
using System.Data.Objects;

namespace System.Data.Entity.Internal;

/// <summary>
///     An <see cref="T:System.Data.Entity.Internal.EagerInternalContext" /> is an <see cref="T:System.Data.Entity.Internal.InternalContext" /> where the <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" /> 
///     instance that it wraps is set immediately at construction time rather than being created lazily. In this case
///     the internal context may or may not own the <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" /> instance but will only dispose it
///     if it does own it.
/// </summary>
internal class EagerInternalContext : InternalContext
{
	private readonly ObjectContext _objectContext;

	private readonly bool _objectContextOwned;

	private readonly string _originalConnectionString;

	/// <summary>
	///     Returns the underlying <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" />.
	/// </summary>
	public override ObjectContext ObjectContext
	{
		get
		{
			Initialize();
			return base.TempObjectContext ?? _objectContext;
		}
	}

	/// <summary>
	///     Gets the default database initializer to use for this context if no other has been registered.
	///     For code first this property returns a <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1" /> instance.
	///     For database/model first, this property returns null.
	/// </summary>
	/// <value>The default initializer.</value>
	public override IDatabaseInitializer<DbContext> DefaultInitializer => null;

	/// <summary>
	///     The connection underlying this context.
	/// </summary>
	public override DbConnection Connection
	{
		get
		{
			CheckContextNotDisposed();
			return ((EntityConnection)_objectContext.Connection).StoreConnection;
		}
	}

	/// <summary>
	/// The connection string as originally applied to the context. This is used to perform operations
	/// that need the connection string in a non-mutated form, such as with security info still intact.
	/// </summary>
	public override string OriginalConnectionString => _originalConnectionString;

	/// <summary>
	///     Returns the origin of the underlying connection string.
	/// </summary>
	public override DbConnectionStringOrigin ConnectionStringOrigin => DbConnectionStringOrigin.UserCode;

	/// <summary>
	///     Gets or sets a value indicating whether lazy loading is enabled.  This is just a wrapper
	///     over the same flag in the underlying <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" />.
	/// </summary>
	public override bool LazyLoadingEnabled
	{
		get
		{
			return _objectContext.ContextOptions.LazyLoadingEnabled;
		}
		set
		{
			_objectContext.ContextOptions.LazyLoadingEnabled = value;
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether proxy creation is enabled.  This is just a wrapper
	///     over the same flag in the underlying ObjectContext.
	/// </summary>
	public override bool ProxyCreationEnabled
	{
		get
		{
			return _objectContext.ContextOptions.ProxyCreationEnabled;
		}
		set
		{
			_objectContext.ContextOptions.ProxyCreationEnabled = value;
		}
	}

	/// <summary>
	/// For mocking.
	/// </summary>
	public EagerInternalContext(DbContext owner)
		: base(owner)
	{
	}

	/// <summary>
	///     Constructs an <see cref="T:System.Data.Entity.Internal.EagerInternalContext" /> for an already existing <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" />.
	/// </summary>
	/// <param name="owner">The owner <see cref="T:System.Data.Entity.DbContext" />.</param>
	/// <param name="objectContext">The existing <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" />.</param>
	public EagerInternalContext(DbContext owner, ObjectContext objectContext, bool objectContextOwned)
		: base(owner)
	{
		_objectContext = objectContext;
		_objectContextOwned = objectContextOwned;
		_originalConnectionString = InternalConnection.AddAppNameCookieToConnectionString(_objectContext.Connection);
		InitializeEntitySetMappings();
	}

	/// <summary>
	///     Returns the underlying <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" /> without causing the underlying database to be created
	///     or the database initialization strategy to be executed.
	///     This is used to get a context that can then be used for database creation/initialization.
	/// </summary>
	public override ObjectContext GetObjectContextWithoutDatabaseInitialization()
	{
		InitializeContext();
		return base.TempObjectContext ?? _objectContext;
	}

	/// <summary>
	///     Does nothing, since the <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" /> already exists.
	/// </summary>
	protected override void InitializeContext()
	{
		CheckContextNotDisposed();
	}

	/// <summary>
	///     Does nothing since the database is always considered initialized if the <see cref="T:System.Data.Entity.DbContext" /> was created
	///     from an existing <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" />.
	/// </summary>
	public override void MarkDatabaseInitialized()
	{
	}

	/// <summary>
	///     Does nothing since the database is always considered initialized if the <see cref="T:System.Data.Entity.DbContext" /> was created
	///     from an existing <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" />.
	/// </summary>
	protected override void InitializeDatabase()
	{
	}

	/// <summary>
	///     Disposes the context. The underlying <see cref="P:System.Data.Entity.Internal.EagerInternalContext.ObjectContext" /> is also disposed if it is owned.
	/// </summary>
	public override void DisposeContext()
	{
		if (_objectContextOwned && !base.IsDisposed)
		{
			_objectContext.Dispose();
		}
	}

	/// <inheritdoc />
	public override void OverrideConnection(IInternalConnection connection)
	{
		throw Error.EagerInternalContext_CannotSetConnectionInfo();
	}
}
