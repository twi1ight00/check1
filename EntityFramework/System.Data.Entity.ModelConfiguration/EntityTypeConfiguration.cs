using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace System.Data.Entity.ModelConfiguration;

/// <summary>
///     Allows configuration to be performed for an entity type in a model.
///
///     An EntityTypeConfiguration can be obtained via the Entity method on
///     <see cref="T:System.Data.Entity.DbModelBuilder" /> or a custom type derived from EntityTypeConfiguration
///     can be registered via the Configurations property on <see cref="T:System.Data.Entity.DbModelBuilder" />.
/// </summary>
public class EntityTypeConfiguration<TEntityType> : StructuralTypeConfiguration<TEntityType> where TEntityType : class
{
	private readonly EntityTypeConfiguration _entityTypeConfiguration;

	internal override StructuralTypeConfiguration Configuration => _entityTypeConfiguration;

	/// <summary>
	///     Initializes a new instance of EntityTypeConfiguration
	/// </summary>
	public EntityTypeConfiguration()
		: this(new EntityTypeConfiguration(typeof(TEntityType)))
	{
	}

	internal EntityTypeConfiguration(EntityTypeConfiguration entityTypeConfiguration)
	{
		_entityTypeConfiguration = entityTypeConfiguration;
	}

	internal override TPrimitivePropertyConfiguration Property<TPrimitivePropertyConfiguration>(LambdaExpression lambdaExpression)
	{
		return Configuration.Property(lambdaExpression.GetComplexPropertyAccess(), () => new TPrimitivePropertyConfiguration
		{
			OverridableConfigurationParts = OverridableConfigurationParts.None
		});
	}

	/// <summary>
	///     Configures the primary key property(s) for this entity type.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <param name="keyExpression">
	///     A lambda expression representing the property to be used as the primary key. 
	///     C#: t =&gt; t.Id   
	///     VB.Net: Function(t) t.Id
	///
	///     If the primary key is made up of multiple properties then specify an anonymous type including the properties. 
	///     C#: t =&gt; new { t.Id1, t.Id2 }
	///     VB.Net: Function(t) New From { t.Id1, t.Id2 }
	/// </param>
	/// <returns>The same EntityTypeConfiguration instance so that multiple calls can be chained.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public EntityTypeConfiguration<TEntityType> HasKey<TKey>(Expression<Func<TEntityType, TKey>> keyExpression)
	{
		RuntimeFailureMethods.Requires(keyExpression != null, null, "keyExpression != null");
		_entityTypeConfiguration.Key(from p in keyExpression.GetSimplePropertyAccessList()
			select p.Single());
		return this;
	}

	/// <summary>
	///     Configures the entity set name to be used for this entity type.
	///     The entity set name can only be configured for the base type in each set.
	/// </summary>
	/// <param name="entitySetName">The name of the entity set.</param>
	/// <returns>The same EntityTypeConfiguration instance so that multiple calls can be chained.</returns>
	public EntityTypeConfiguration<TEntityType> HasEntitySetName(string entitySetName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(entitySetName), null, "!string.IsNullOrWhiteSpace(entitySetName)");
		_entityTypeConfiguration.EntitySetName = entitySetName;
		return this;
	}

	/// <summary>
	///     Configures the table name that this entity type is mapped to.
	/// </summary>
	/// <param name="tableName">The name of the table.</param>
	public void ToTable(string tableName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(tableName), null, "!string.IsNullOrWhiteSpace(tableName)");
		string qualifiedName = tableName;
		ObjectExtensions.ParseQualifiedTableName(qualifiedName, out var schemaName, out tableName);
		_entityTypeConfiguration.ToTable(tableName, schemaName);
	}

	/// <summary>
	///     Configures the table name that this entity type is mapped to.
	/// </summary>
	/// <param name="tableName">The name of the table.</param>
	/// <param name="schemaName">The database schema of the table.</param>
	public void ToTable(string tableName, string schemaName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(tableName), null, "!string.IsNullOrWhiteSpace(tableName)");
		_entityTypeConfiguration.ToTable(tableName, schemaName);
	}

	/// <summary>
	///     Allows advanced configuration related to how this entity type is mapped to the database schema.
	///     By default, any configuration will also apply to any type derived from this entity type.
	///
	///     Derived types can be configured via the overload of Map that configures a derived type or
	///     by using an EntityTypeConfiguration for the derived type.
	///
	///     The properties of an entity can be split between multiple tables using multiple Map calls.
	///
	///     Calls to Map are additive, subsequent calls will not override configuration already preformed via Map.
	/// </summary>
	/// <param name="entityMappingConfigurationAction">An action that performs configuration against an <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.EntityMappingConfiguration`1" />.</param>
	/// <returns>The same EntityTypeConfiguration instance so that multiple calls can be chained.</returns>
	public EntityTypeConfiguration<TEntityType> Map(Action<EntityMappingConfiguration<TEntityType>> entityMappingConfigurationAction)
	{
		RuntimeFailureMethods.Requires(entityMappingConfigurationAction != null, null, "entityMappingConfigurationAction != null");
		EntityMappingConfiguration<TEntityType> entityMappingConfiguration = new EntityMappingConfiguration<TEntityType>();
		entityMappingConfigurationAction(entityMappingConfiguration);
		_entityTypeConfiguration.AddMappingConfiguration(entityMappingConfiguration.EntityMappingConfigurationInstance);
		return this;
	}

	/// <summary>
	///     Allows advanced configuration related to how a derived entity type is mapped to the database schema.
	///     Calls to Map are additive, subsequent calls will not override configuration already preformed via Map.
	/// </summary>
	/// <typeparam name="TDerived">The derived entity type to be configured.</typeparam>
	/// <param name="derivedTypeMapConfigurationAction">An action that performs configuration against an <see cref="T:System.Data.Entity.ModelConfiguration.Configuration.EntityMappingConfiguration`1" />.</param>
	/// <returns>The same EntityTypeConfiguration instance so that multiple calls can be chained.</returns>
	public EntityTypeConfiguration<TEntityType> Map<TDerived>(Action<EntityMappingConfiguration<TDerived>> derivedTypeMapConfigurationAction) where TDerived : class, TEntityType
	{
		RuntimeFailureMethods.Requires(derivedTypeMapConfigurationAction != null, null, "derivedTypeMapConfigurationAction != null");
		EntityMappingConfiguration<TDerived> entityMappingConfiguration = new EntityMappingConfiguration<TDerived>();
		derivedTypeMapConfigurationAction(entityMappingConfiguration);
		if (typeof(TDerived) == typeof(TEntityType))
		{
			_entityTypeConfiguration.AddMappingConfiguration(entityMappingConfiguration.EntityMappingConfigurationInstance);
		}
		else
		{
			_entityTypeConfiguration.AddSubTypeMappingConfiguration(typeof(TDerived), entityMappingConfiguration.EntityMappingConfigurationInstance);
		}
		return this;
	}

	/// <summary>
	///     Configures an optional relationship from this entity type.
	///     Instances of the entity type will be able to be saved to the database without this relationship being specified.
	///     The foreign key in the database will be nullable.
	/// </summary>
	/// <typeparam name="TTargetEntity">The type of the entity at the other end of the relationship.</typeparam>
	/// <param name="navigationPropertyExpression">
	///     A lambda expression representing the navigation property for the relationship.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to further configure the relationship.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public OptionalNavigationPropertyConfiguration<TEntityType, TTargetEntity> HasOptional<TTargetEntity>(Expression<Func<TEntityType, TTargetEntity>> navigationPropertyExpression) where TTargetEntity : class
	{
		RuntimeFailureMethods.Requires(navigationPropertyExpression != null, null, "navigationPropertyExpression != null");
		return new OptionalNavigationPropertyConfiguration<TEntityType, TTargetEntity>(_entityTypeConfiguration.Navigation(navigationPropertyExpression.GetSimplePropertyAccess().Single()));
	}

	/// <summary>
	///     Configures a required relationship from this entity type.
	///     Instances of the entity type will not be able to be saved to the database unless this relationship is specified.
	///     The foreign key in the database will be non-nullable.
	/// </summary>
	/// <typeparam name="TTargetEntity">The type of the entity at the other end of the relationship.</typeparam>
	/// <param name="navigationPropertyExpression">
	///     A lambda expression representing the navigation property for the relationship.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to further configure the relationship.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public RequiredNavigationPropertyConfiguration<TEntityType, TTargetEntity> HasRequired<TTargetEntity>(Expression<Func<TEntityType, TTargetEntity>> navigationPropertyExpression) where TTargetEntity : class
	{
		RuntimeFailureMethods.Requires(navigationPropertyExpression != null, null, "navigationPropertyExpression != null");
		return new RequiredNavigationPropertyConfiguration<TEntityType, TTargetEntity>(_entityTypeConfiguration.Navigation(navigationPropertyExpression.GetSimplePropertyAccess().Single()));
	}

	/// <summary>
	///     Configures a many relationship from this entity type.
	/// </summary>
	/// <typeparam name="TTargetEntity">The type of the entity at the other end of the relationship.</typeparam>
	/// <param name="navigationPropertyExpression">
	///     A lambda expression representing the navigation property for the relationship.
	///     C#: t =&gt; t.MyProperty   
	///     VB.Net: Function(t) t.MyProperty
	/// </param>
	/// <returns>A configuration object that can be used to further configure the relationship.</returns>
	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public ManyNavigationPropertyConfiguration<TEntityType, TTargetEntity> HasMany<TTargetEntity>(Expression<Func<TEntityType, ICollection<TTargetEntity>>> navigationPropertyExpression) where TTargetEntity : class
	{
		RuntimeFailureMethods.Requires(navigationPropertyExpression != null, null, "navigationPropertyExpression != null");
		return new ManyNavigationPropertyConfiguration<TEntityType, TTargetEntity>(_entityTypeConfiguration.Navigation(navigationPropertyExpression.GetSimplePropertyAccess().Single()));
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
