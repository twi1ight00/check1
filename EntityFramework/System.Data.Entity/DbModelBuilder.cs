using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Mappers;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;

namespace System.Data.Entity;

/// <summary>
///     DbModelBuilder is used to map CLR classes to a database schema.
///     This code centric approach to building an Entity Data Model (EDM) model is known as 'Code First'.
/// </summary>
/// <remarks>
///     DbModelBuilder is typically used to configure a model by overriding <see cref="M:System.Data.Entity.DbContext.OnModelCreating(System.Data.Entity.DbModelBuilder)" />. 
///     You can also use DbModelBuilder independently of DbContext to build a model and then construct a 
///     <see cref="T:System.Data.Entity.DbContext" /> or <see cref="T:System.Data.Objects.ObjectContext" />.
///     The recommended approach, however, is to use OnModelCreating in <see cref="T:System.Data.Entity.DbContext" /> as
///     the workflow is more intuitive and takes care of common tasks, such as caching the created model.
///
///     Types that form your model are registered with DbModelBuilder and optional configuration can be
///     performed by applying data annotations to your classes and/or using the fluent style DbModelBuilder
///     API. 
///
///     When the Build method is called a set of conventions are run to discover the initial model.
///     These conventions will automatically discover aspects of the model, such as primary keys, and
///     will also process any data annotations that were specified on your classes. Finally
///     any configuration that was performed using the DbModelBuilder API is applied. 
///
///     Configuration done via the DbModelBuilder API takes precedence over data annotations which 
///     in turn take precedence over the default conventions.
/// </remarks>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
public class DbModelBuilder
{
	private readonly System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration _modelConfiguration;

	private readonly ConventionsConfiguration _conventionsConfiguration;

	private readonly DbModelBuilderVersion _modelBuilderVersion;

	private readonly object _lock;

	/// <summary>
	///     Provides access to the settings of this DbModelBuilder that deal with conventions.
	/// </summary>
	public virtual ConventionsConfiguration Conventions => _conventionsConfiguration;

	/// <summary>
	///     Gets the <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar" /> for this DbModelBuilder. 
	///     The registrar allows derived entity and complex type configurations to be registered with this builder.
	/// </summary>
	public virtual ConfigurationRegistrar Configurations => new ConfigurationRegistrar(_modelConfiguration);

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	internal DbModelBuilderVersion Version => _modelBuilderVersion;

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	internal System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration ModelConfiguration => _modelConfiguration;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.DbModelBuilder" /> class. 
	///
	///     The process of discovering the initial model will use the set of conventions included 
	///     in the most recent version of the Entity Framework installed on your machine.
	/// </summary>
	/// <remarks>
	///     Upgrading to newer versions of the Entity Framework may cause breaking changes 
	///     in your application because new conventions may cause the initial model to be 
	///     configured differently. There is an alternate constructor that allows a specific 
	///     version of conventions to be specified.
	/// </remarks>
	public DbModelBuilder()
		: this(new System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration())
	{
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.DbModelBuilder" /> class that will use 
	///     a specific set of conventions to discover the initial model.
	/// </summary>
	/// <param name="modelBuilderVersion">The version of conventions to be used.</param>
	public DbModelBuilder(DbModelBuilderVersion modelBuilderVersion)
	{
		__ContractsRuntime.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(DbModelBuilderVersion), modelBuilderVersion), null, "Enum.IsDefined(typeof(DbModelBuilderVersion), modelBuilderVersion)");
		this._002Ector(new System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration(), modelBuilderVersion);
	}

	internal DbModelBuilder(System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration, DbModelBuilderVersion modelBuilderVersion = DbModelBuilderVersion.Latest)
		: this(modelConfiguration, new ConventionsConfiguration(), modelBuilderVersion)
	{
	}

	private DbModelBuilder(System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration, ConventionsConfiguration conventionsConfiguration, DbModelBuilderVersion modelBuilderVersion = DbModelBuilderVersion.Latest)
	{
		_lock = new object();
		base._002Ector();
		_modelConfiguration = modelConfiguration;
		_conventionsConfiguration = conventionsConfiguration;
		_modelBuilderVersion = modelBuilderVersion;
	}

	private DbModelBuilder(DbModelBuilder source)
	{
		_lock = new object();
		base._002Ector();
		_modelConfiguration = source._modelConfiguration.Clone();
		_conventionsConfiguration = source._conventionsConfiguration.Clone();
		_modelBuilderVersion = source._modelBuilderVersion;
	}

	internal virtual DbModelBuilder Clone()
	{
		lock (_lock)
		{
			return new DbModelBuilder(this);
		}
	}

	/// <summary>
	///     Excludes a type from the model. This is used to remove types from the model that were added 
	///     by convention during initial model discovery.
	/// </summary>
	/// <typeparam name="T">The type to be excluded.</typeparam>
	/// <returns>The same DbModelBuilder instance so that multiple calls can be chained.</returns>
	public virtual DbModelBuilder Ignore<T>() where T : class
	{
		_modelConfiguration.Ignore(typeof(T));
		return this;
	}

	/// <summary>
	///     Excludes a type(s) from the model. This is used to remove types from the model that were added 
	///     by convention during initial model discovery.
	/// </summary>
	/// <param name="types">The types to be excluded from the model.</param>
	/// <returns>The same DbModelBuilder instance so that multiple calls can be chained.</returns>
	public virtual DbModelBuilder Ignore(IEnumerable<Type> types)
	{
		RuntimeFailureMethods.Requires(types != null, null, "types != null");
		foreach (Type type in types)
		{
			_modelConfiguration.Ignore(type);
		}
		return this;
	}

	/// <summary>
	///     Registers an entity type as part of the model and returns an object that can be used to
	///     configure the entity. This method can be called multiple times for the same entity to
	///     perform multiple lines of configuration.
	/// </summary>
	/// <typeparam name="TEntityType">The type to be registered or configured.</typeparam>
	/// <returns>The configuration object for the specified entity type.</returns>
	public virtual EntityTypeConfiguration<TEntityType> Entity<TEntityType>() where TEntityType : class
	{
		System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration = _modelConfiguration;
		bool explicitEntity = true;
		return new EntityTypeConfiguration<TEntityType>(modelConfiguration.Entity(typeof(TEntityType), explicitEntity));
	}

	/// <summary>
	///     Registers a type as an entity in the model and returns an object that can be used to
	///     configure the entity. This method can be called multiple times for the same type to
	///     perform multiple lines of configuration.
	/// </summary>
	/// <param name="entityType">The type to be registered or configured.</param>
	/// <returns>The configuration object for the specified entity type.</returns>
	internal virtual EntityTypeConfiguration Entity(Type entityType)
	{
		EntityTypeConfiguration entityTypeConfiguration = _modelConfiguration.Entity(entityType);
		entityTypeConfiguration.IsReplaceable = true;
		return entityTypeConfiguration;
	}

	/// <summary>
	///     Registers a type as a complex type in the model and returns an object that can be used to
	///     configure the complex type. This method can be called multiple times for the same type to
	///     perform multiple lines of configuration.
	/// </summary>
	/// <typeparam name="TComplexType">The type to be registered or configured.</typeparam>
	/// <returns>The configuration object for the specified complex type.</returns>
	public virtual ComplexTypeConfiguration<TComplexType> ComplexType<TComplexType>() where TComplexType : class
	{
		return new ComplexTypeConfiguration<TComplexType>(_modelConfiguration.ComplexType(typeof(TComplexType)));
	}

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbModel" /> based on the configuration performed using this builder.
	///     The connection is used to determine the database provider being used as this
	///     affects the database layer of the generated model.
	/// </summary>
	/// <param name="providerConnection">Connection to use to determine provider information.</param>
	/// <returns>The model that was built.</returns>
	public virtual DbModel Build(DbConnection providerConnection)
	{
		RuntimeFailureMethods.Requires(providerConnection != null, null, "providerConnection != null");
		DbProviderManifest providerManifest;
		DbProviderInfo providerInfo = providerConnection.GetProviderInfo(out providerManifest);
		return Build(providerManifest, providerInfo);
	}

	/// <summary>
	///     Creates a <see cref="T:System.Data.Entity.Infrastructure.DbModel" /> based on the configuration performed using this builder.
	///     Provider information must be specified because this affects the database layer of the generated model.
	///     For SqlClient the invariant name is 'System.Data.SqlClient' and the manifest token is the version year (i.e. '2005', '2008' etc.)
	/// </summary>
	/// <param name="providerInfo">The database provider that the model will be used with.</param>
	/// <returns>The model that was built.</returns>
	public virtual DbModel Build(DbProviderInfo providerInfo)
	{
		RuntimeFailureMethods.Requires(providerInfo != null, null, "providerInfo != null");
		DbProviderManifest providerManifest = GetProviderManifest(providerInfo);
		return Build(providerManifest, providerInfo);
	}

	private DbModel Build(DbProviderManifest providerManifest, DbProviderInfo providerInfo)
	{
		EdmModel model = new EdmModel().Initialize();
		model.SetProviderInfo(providerInfo);
		_conventionsConfiguration.ApplyModelConfiguration(_modelConfiguration);
		_modelConfiguration.NormalizeConfigurations();
		MapTypes(model);
		_modelConfiguration.Configure(model);
		_conventionsConfiguration.ApplyModel(model);
		model.ValidateCsdl();
		DbDatabaseMapping dbDatabaseMapping = model.GenerateDatabaseMapping(providerManifest);
		_modelConfiguration.Configure(dbDatabaseMapping, providerManifest);
		_conventionsConfiguration.ApplyDatabase(dbDatabaseMapping.Database);
		_conventionsConfiguration.ApplyMapping(dbDatabaseMapping);
		dbDatabaseMapping.Database.SetProviderInfo(providerInfo);
		return new DbModel(dbDatabaseMapping, Clone());
	}

	private static DbProviderManifest GetProviderManifest(DbProviderInfo providerInfo)
	{
		DbProviderFactory factory = DbProviderFactories.GetFactory(providerInfo.ProviderInvariantName);
		DbProviderServices providerServices = DbProviderServices.GetProviderServices(factory.CreateConnection());
		return providerServices.GetProviderManifest(providerInfo.ProviderManifestToken);
	}

	private void MapTypes(EdmModel model)
	{
		TypeMapper typeMapper = new TypeMapper(new MappingContext(_modelConfiguration, _conventionsConfiguration, model));
		_modelConfiguration.Entities.Where((Type type) => typeMapper.MapEntityType(type) == null).Each(delegate(Type t)
		{
			throw Error.InvalidEntityType(t);
		});
		_modelConfiguration.ComplexTypes.Where((Type type) => typeMapper.MapComplexType(type) == null).Each(delegate(Type t)
		{
			throw Error.InvalidComplexType(t);
		});
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
