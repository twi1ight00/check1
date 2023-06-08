using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;

namespace System.Data.Entity.Resources;

/// <summary>
///    Strongly-typed and parameterized exception factory.
/// </summary>
[GeneratedCode("Resources.tt", "1.0.0.0")]
internal static class Error
{
	/// <summary>
	/// Migrations.Infrastructure.AutomaticDataLossException with message like "Automatic migration was not applied because it would result in data loss."
	/// </summary>
	internal static Exception AutomaticDataLoss()
	{
		return new AutomaticDataLossException(Strings.AutomaticDataLoss);
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "Cannot scaffold the next migration because the target database was created with a version of Code First earlier than EF 4.3 and does not contain the migrations history table. To start using migrations against this database, ensure the current model is compatible with the target database and execute the migrations Update process. (In Visual Studio you can use the Update-Database command from Package Manager Console to execute the migrations Update process)."
	/// </summary>
	internal static Exception MetadataOutOfDate()
	{
		return new MigrationsException(Strings.MetadataOutOfDate);
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The specified target migration '{0}' does not exist. Ensure that target migration refers to an existing migration id."
	/// </summary>
	internal static Exception MigrationNotFound(object p0)
	{
		return new MigrationsException(Strings.MigrationNotFound(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The Foreign Key on table '{0}' with columns '{1}' could not be created because the principal key columns could not be determined. Use the AddForeignKey fluent API to fully specify the Foreign Key."
	/// </summary>
	internal static Exception PartialFkOperation(object p0, object p1)
	{
		return new MigrationsException(Strings.PartialFkOperation(p0, p1));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "'{0}' is not a valid target migration. When targeting a previously applied automatic migration, use the full migration id including timestamp."
	/// </summary>
	internal static Exception AutoNotValidTarget(object p0)
	{
		return new MigrationsException(Strings.AutoNotValidTarget(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "'{0}' is not a valid migration. Explicit migrations must be used for both source and target when scripting the upgrade between them."
	/// </summary>
	internal static Exception AutoNotValidForScriptWindows(object p0)
	{
		return new MigrationsException(Strings.AutoNotValidForScriptWindows(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The target context '{0}' is not constructible. Add a default constructor or provide an implementation of IDbContextFactory."
	/// </summary>
	internal static Exception ContextNotConstructible(object p0)
	{
		return new MigrationsException(Strings.ContextNotConstructible(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The specified migration name '{0}' is ambiguous. Specify the full migration id including timestamp instead."
	/// </summary>
	internal static Exception AmbiguousMigrationName(object p0)
	{
		return new MigrationsException(Strings.AmbiguousMigrationName(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.AutomaticMigrationsDisabledException with message like "Unable to update database to match the current model because there are pending changes and automatic migration is disabled. Either write the pending model changes to a code-based migration or enable automatic migration. Set DbMigrationsConfiguration.AutomaticMigrationsEnabled to true to enable automatic migration."
	/// </summary>
	internal static Exception AutomaticDisabledException()
	{
		return new AutomaticMigrationsDisabledException(Strings.AutomaticDisabledException);
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "Scripting the downgrade between two specified migrations is not supported."
	/// </summary>
	internal static Exception DownScriptWindowsNotSupported()
	{
		return new MigrationsException(Strings.DownScriptWindowsNotSupported);
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The migrations configuration type '{0}' was not be found in the assembly '{1}'."
	/// </summary>
	internal static Exception AssemblyMigrator_NoConfigurationWithName(object p0, object p1)
	{
		return new MigrationsException(Strings.AssemblyMigrator_NoConfigurationWithName(p0, p1));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "More than one migrations configuration type '{0}' was found in the assembly '{1}'. Specify the fully qualified name of the one to use."
	/// </summary>
	internal static Exception AssemblyMigrator_MultipleConfigurationsWithName(object p0, object p1)
	{
		return new MigrationsException(Strings.AssemblyMigrator_MultipleConfigurationsWithName(p0, p1));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "No migrations configuration type was found in the assembly '{0}'. (In Visual Studio you can use the Enable-Migrations command from Package Manager Console to add a migrations configuration)."
	/// </summary>
	internal static Exception AssemblyMigrator_NoConfiguration(object p0)
	{
		return new MigrationsException(Strings.AssemblyMigrator_NoConfiguration(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "More than one migrations configuration type was found in the assembly '{0}'. Specify the name of the one to use."
	/// </summary>
	internal static Exception AssemblyMigrator_MultipleConfigurations(object p0)
	{
		return new MigrationsException(Strings.AssemblyMigrator_MultipleConfigurations(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The type '{0}' is not a migrations configuration type."
	/// </summary>
	internal static Exception AssemblyMigrator_NonConfigurationType(object p0)
	{
		return new MigrationsException(Strings.AssemblyMigrator_NonConfigurationType(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The migrations configuration type '{0}' must have a public default constructor."
	/// </summary>
	internal static Exception AssemblyMigrator_NoDefaultConstructor(object p0)
	{
		return new MigrationsException(Strings.AssemblyMigrator_NoDefaultConstructor(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The migrations configuration type '{0}' must not be abstract."
	/// </summary>
	internal static Exception AssemblyMigrator_AbstractConfigurationType(object p0)
	{
		return new MigrationsException(Strings.AssemblyMigrator_AbstractConfigurationType(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "The migrations configuration type '{0}' must not be generic."
	/// </summary>
	internal static Exception AssemblyMigrator_GenericConfigurationType(object p0)
	{
		return new MigrationsException(Strings.AssemblyMigrator_GenericConfigurationType(p0));
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "Direct column renaming is not supported by SQL Server Compact. To rename a column in SQL Server Compact, you will need to recreate it."
	/// </summary>
	internal static Exception SqlCeColumnRenameNotSupported()
	{
		return new MigrationsException(Strings.SqlCeColumnRenameNotSupported);
	}

	/// <summary>
	/// Migrations.Infrastructure.MigrationsException with message like "In VB.NET projects, the migrations namespace '{0}' must be under the root namespace '{1}'. Update the migrations project's root namespace to allow classes under the migrations namespace to be added."
	/// </summary>
	internal static Exception MigrationsNamespaceNotUnderRootNamespace(object p0, object p1)
	{
		return new MigrationsException(Strings.MigrationsNamespaceNotUnderRootNamespace(p0, p1));
	}

	internal static Exception UnableToDispatchAddOrUpdate(object p0)
	{
		return new InvalidOperationException(Strings.UnableToDispatchAddOrUpdate(p0));
	}

	/// <summary>
	/// ArgumentException with message like "The argument '{0}' cannot be null, empty or contain only white space."
	/// </summary>
	internal static Exception ArgumentIsNullOrWhitespace(object p0)
	{
		return new ArgumentException(Strings.ArgumentIsNullOrWhitespace(p0));
	}

	/// <summary>
	/// ArgumentException with message like "The argument property '{0}' cannot be null."
	/// </summary>
	internal static Exception ArgumentPropertyIsNull(object p0)
	{
		return new ArgumentException(Strings.ArgumentPropertyIsNull(p0));
	}

	/// <summary>
	/// ArgumentException with message like "The precondition '{0}' failed. {1}"
	/// </summary>
	internal static Exception PreconditionFailed(object p0, object p1)
	{
		return new ArgumentException(Strings.PreconditionFailed(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The type '{0}' has already been configured as a complex type. It cannot be reconfigured as an entity type."
	/// </summary>
	internal static Exception EntityTypeConfigurationMismatch(object p0)
	{
		return new InvalidOperationException(Strings.EntityTypeConfigurationMismatch(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The type '{0}' has already been configured as an entity type. It cannot be reconfigured as a complex type."
	/// </summary>
	internal static Exception ComplexTypeConfigurationMismatch(object p0)
	{
		return new InvalidOperationException(Strings.ComplexTypeConfigurationMismatch(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The key component '{0}' is not a declared property on type '{1}'. Verify that it has not been explicitly excluded from the model and that it is a valid primitive property."
	/// </summary>
	internal static Exception KeyPropertyNotFound(object p0, object p1)
	{
		return new InvalidOperationException(Strings.KeyPropertyNotFound(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The foreign key component '{0}' is not a declared property on type '{1}'. Verify that it has not been explicitly excluded from the model and that it is a valid primitive property."
	/// </summary>
	internal static Exception ForeignKeyPropertyNotFound(object p0, object p1)
	{
		return new InvalidOperationException(Strings.ForeignKeyPropertyNotFound(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The property '{0}' is not a declared property on type '{1}'. Verify that the property has not been explicitly excluded from the model by using the Ignore method or NotMappedAttribute data annotation. Make sure that it is a valid primitive property."
	/// </summary>
	internal static Exception PropertyNotFound(object p0, object p1)
	{
		return new InvalidOperationException(Strings.PropertyNotFound(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The navigation property '{0}' is not a declared property on type '{1}'. Verify that it has not been explicitly excluded from the model and that it is a valid navigation property."
	/// </summary>
	internal static Exception NavigationPropertyNotFound(object p0, object p1)
	{
		return new InvalidOperationException(Strings.NavigationPropertyNotFound(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The expression '{0}' is not a valid property expression. The expression should represent a property: C#: 't =&gt; t.MyProperty'  VB.Net: 'Function(t) t.MyProperty'."
	/// </summary>
	internal static Exception InvalidPropertyExpression(object p0)
	{
		return new InvalidOperationException(Strings.InvalidPropertyExpression(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The expression '{0}' is not a valid property expression. The expression should represent a property: C#: 't =&gt; t.MyProperty'  VB.Net: 'Function(t) t.MyProperty'. Use dotted paths for nested properties: C#: 't =&gt; t.MyProperty.MyProperty'  VB.Net: 'Function(t) t.MyProperty.MyProperty'."
	/// </summary>
	internal static Exception InvalidComplexPropertyExpression(object p0)
	{
		return new InvalidOperationException(Strings.InvalidComplexPropertyExpression(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The properties expression '{0}' is not valid. The expression should represent a property: C#: 't =&gt; t.MyProperty'  VB.Net: 'Function(t) t.MyProperty'. When specifying multiple properties use an anonymous type: C#: 't =&gt; new {{ t.MyProperty1, t.MyProperty2 }}'  VB.Net: 'Function(t) New From {{ t.MyProperty1, t.MyProperty2 }}'."
	/// </summary>
	internal static Exception InvalidPropertiesExpression(object p0)
	{
		return new InvalidOperationException(Strings.InvalidPropertiesExpression(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The properties expression '{0}' is not valid. The expression should represent a property: C#: 't =&gt; t.MyProperty'  VB.Net: 'Function(t) t.MyProperty'. When specifying multiple properties use an anonymous type: C#: 't =&gt; new {{ t.MyProperty1, t.MyProperty2 }}'  VB.Net: 'Function(t) New From {{ t.MyProperty1, t.MyProperty2 }}'."
	/// </summary>
	internal static Exception InvalidComplexPropertiesExpression(object p0)
	{
		return new InvalidOperationException(Strings.InvalidComplexPropertiesExpression(p0));
	}

	internal static Exception DuplicateStructuralTypeConfiguration(object p0)
	{
		return new InvalidOperationException(Strings.DuplicateStructuralTypeConfiguration(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Conflicting configuration settings were specified for property '{0}' on type '{1}': {2}"
	/// </summary>
	internal static Exception ConflictingPropertyConfiguration(object p0, object p1, object p2)
	{
		return new InvalidOperationException(Strings.ConflictingPropertyConfiguration(p0, p1, p2));
	}

	/// <summary>
	/// InvalidOperationException with message like "Conflicting configuration settings were specified for column '{0}' on table '{1}': {2}"
	/// </summary>
	internal static Exception ConflictingColumnConfiguration(object p0, object p1, object p2)
	{
		return new InvalidOperationException(Strings.ConflictingColumnConfiguration(p0, p1, p2));
	}

	/// <summary>
	/// InvalidOperationException with message like "The type '{0}' was not mapped. Check that the type has not been explicitly excluded by using the Ignore method or NotMappedAttribute data annotation. Verify that the type was defined as a class, is not primitive, nested or generic, and does not inherit from ComplexObject."
	/// </summary>
	internal static Exception InvalidComplexType(object p0)
	{
		return new InvalidOperationException(Strings.InvalidComplexType(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The type '{0}' was not mapped. Check that the type has not been explicitly excluded by using the Ignore method or NotMappedAttribute data annotation. Verify that the type was defined as a class, is not primitive, nested or generic, and does not inherit from EntityObject."
	/// </summary>
	internal static Exception InvalidEntityType(object p0)
	{
		return new InvalidOperationException(Strings.InvalidEntityType(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The navigation property '{0}' declared on type '{1}' cannot be the inverse of itself."
	/// </summary>
	internal static Exception NavigationInverseItself(object p0, object p1)
	{
		return new InvalidOperationException(Strings.NavigationInverseItself(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The navigation property '{0}' declared on type '{1}' has been configured with conflicting foreign keys."
	/// </summary>
	internal static Exception ConflictingConstraint(object p0, object p1)
	{
		return new InvalidOperationException(Strings.ConflictingConstraint(p0, p1));
	}

	/// <summary>
	/// MappingException with message like "Values of incompatible types ('{1}' and '{2}') were assigned to the '{0}' discriminator column. Values of the same type must be specified. To explicitly specify the type of the discriminator column use the HasColumnType method."
	/// </summary>
	internal static Exception ConflictingInferredColumnType(object p0, object p1, object p2)
	{
		return new MappingException(Strings.ConflictingInferredColumnType(p0, p1, p2));
	}

	/// <summary>
	/// InvalidOperationException with message like "The navigation property '{0}' declared on type '{1}' has been configured with conflicting mapping information."
	/// </summary>
	internal static Exception ConflictingMapping(object p0, object p1)
	{
		return new InvalidOperationException(Strings.ConflictingMapping(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The navigation property '{0}' declared on type '{1}' has been configured with conflicting cascade delete operations using 'WillCascadeOnDelete'."
	/// </summary>
	internal static Exception ConflictingCascadeDeleteOperation(object p0, object p1)
	{
		return new InvalidOperationException(Strings.ConflictingCascadeDeleteOperation(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The navigation property '{0}' declared on type '{1}' has been configured with conflicting multiplicities."
	/// </summary>
	internal static Exception ConflictingMultiplicities(object p0, object p1)
	{
		return new InvalidOperationException(Strings.ConflictingMultiplicities(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The MaxLengthAttribute on property '{0}' on type '{1} is not valid. The Length value must be greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length."
	/// </summary>
	internal static Exception MaxLengthAttributeConvention_InvalidMaxLength(object p0, object p1)
	{
		return new InvalidOperationException(Strings.MaxLengthAttributeConvention_InvalidMaxLength(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The StringLengthAttribute on property '{0}' on type '{1}' is not valid. The maximum length must be greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length."
	/// </summary>
	internal static Exception StringLengthAttributeConvention_InvalidMaximumLength(object p0, object p1)
	{
		return new InvalidOperationException(Strings.StringLengthAttributeConvention_InvalidMaximumLength(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Unable to determine composite primary key ordering for type '{0}'. Use the ColumnAttribute or the HasKey method to specify an order for composite primary keys."
	/// </summary>
	internal static Exception ModelGeneration_UnableToDetermineKeyOrder(object p0)
	{
		return new InvalidOperationException(Strings.ModelGeneration_UnableToDetermineKeyOrder(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The ForeignKeyAttribute on property '{0}' on type '{1}' is not valid. Name must not be empty."
	/// </summary>
	internal static Exception ForeignKeyAttributeConvention_EmptyKey(object p0, object p1)
	{
		return new InvalidOperationException(Strings.ForeignKeyAttributeConvention_EmptyKey(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The ForeignKeyAttribute on property '{0}' on type '{1}' is not valid. The foreign key name '{2}' was not found on the dependent type '{3}'. The Name value should be a comma separated list of foreign key property names."
	/// </summary>
	internal static Exception ForeignKeyAttributeConvention_InvalidKey(object p0, object p1, object p2, object p3)
	{
		return new InvalidOperationException(Strings.ForeignKeyAttributeConvention_InvalidKey(p0, p1, p2, p3));
	}

	/// <summary>
	/// InvalidOperationException with message like "The ForeignKeyAttribute on property '{0}' on type '{1}' is not valid. The navigation property '{2}' was not found on the dependent type '{1}'. The Name value should be a valid navigation property name."
	/// </summary>
	internal static Exception ForeignKeyAttributeConvention_InvalidNavigationProperty(object p0, object p1, object p2)
	{
		return new InvalidOperationException(Strings.ForeignKeyAttributeConvention_InvalidNavigationProperty(p0, p1, p2));
	}

	/// <summary>
	/// InvalidOperationException with message like "Unable to determine a composite foreign key ordering for foreign key on type {0}. When using the ForeignKey data annotation on composite foreign key properties ensure order is specified by using the Column data annotation or the fluent API."
	/// </summary>
	internal static Exception ForeignKeyAttributeConvention_OrderRequired(object p0)
	{
		return new InvalidOperationException(Strings.ForeignKeyAttributeConvention_OrderRequired(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The InversePropertyAttribute on property '{2}' on type '{3}' is not valid. The property '{0}' is not a valid navigation property on the related type '{1}'. Ensure that the property exists and is a valid reference or collection navigation property."
	/// </summary>
	internal static Exception InversePropertyAttributeConvention_PropertyNotFound(object p0, object p1, object p2, object p3)
	{
		return new InvalidOperationException(Strings.InversePropertyAttributeConvention_PropertyNotFound(p0, p1, p2, p3));
	}

	/// <summary>
	/// InvalidOperationException with message like "A relationship cannot be established from property '{0}' on type '{1}' to property '{0}' on type '{1}'. Check the values in the InversePropertyAttribute to ensure relationship definitions are unique and reference from one navigation property to its corresponding inverse navigation property."
	/// </summary>
	internal static Exception InversePropertyAttributeConvention_SelfInverseDetected(object p0, object p1)
	{
		return new InvalidOperationException(Strings.InversePropertyAttributeConvention_SelfInverseDetected(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "A key is registered for the derived type '{0}'. Keys can only be registered for the root type '{1}'."
	/// </summary>
	internal static Exception KeyRegisteredOnDerivedType(object p0, object p1)
	{
		return new InvalidOperationException(Strings.KeyRegisteredOnDerivedType(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The type '{0}' has already been mapped to table '{1}'. Specify all mapping aspects of a table in a single Map call."
	/// </summary>
	internal static Exception InvalidTableMapping(object p0, object p1)
	{
		return new InvalidOperationException(Strings.InvalidTableMapping(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Map was called more than once for type '{0}' and at least one of the calls didn't specify the target table name."
	/// </summary>
	internal static Exception InvalidTableMapping_NoTableName(object p0)
	{
		return new InvalidOperationException(Strings.InvalidTableMapping_NoTableName(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The derived type '{0}' has already been mapped using the chaining syntax. A derived type can only be mapped once using the chaining syntax."
	/// </summary>
	internal static Exception InvalidChainedMappingSyntax(object p0)
	{
		return new InvalidOperationException(Strings.InvalidChainedMappingSyntax(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "An "is not null" condition cannot be specified on property '{0}' on type '{1}' because this property is not included in the model. Check that the property has not been explicitly excluded from the model by using the Ignore method or NotMappedAttribute data annotation."
	/// </summary>
	internal static Exception InvalidNotNullCondition(object p0, object p1)
	{
		return new InvalidOperationException(Strings.InvalidNotNullCondition(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "Values of type '{0}' cannot be used as type discriminator values. Supported types include byte, signed byte, bool, int16, int32, int64, and string."
	/// </summary>
	internal static Exception InvalidDiscriminatorType(object p0)
	{
		return new ArgumentException(Strings.InvalidDiscriminatorType(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Unable to add the convention '{0}'. Could not find an existing convention of type '{1}' in the current convention set."
	/// </summary>
	internal static Exception ConventionNotFound(object p0, object p1)
	{
		return new InvalidOperationException(Strings.ConventionNotFound(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Not all properties for type '{0}' have been mapped. Either map those properties or explicitly excluded them from the model."
	/// </summary>
	internal static Exception InvalidEntitySplittingProperties(object p0)
	{
		return new InvalidOperationException(Strings.InvalidEntitySplittingProperties(p0));
	}

	/// <summary>
	/// NotSupportedException with message like "Unable to determine the provider name for connection of type '{0}'."
	/// </summary>
	internal static Exception ModelBuilder_ProviderNameNotFound(object p0)
	{
		return new NotSupportedException(Strings.ModelBuilder_ProviderNameNotFound(p0));
	}

	/// <summary>
	/// ArgumentException with message like "The qualified table name '{0}' contains an invalid schema name. Schema names must have a non-zero length."
	/// </summary>
	internal static Exception ToTable_InvalidSchemaName(object p0)
	{
		return new ArgumentException(Strings.ToTable_InvalidSchemaName(p0));
	}

	/// <summary>
	/// ArgumentException with message like "The qualified table name '{0}' contains an invalid table name. Table names must have a non-zero length."
	/// </summary>
	internal static Exception ToTable_InvalidTableName(object p0)
	{
		return new ArgumentException(Strings.ToTable_InvalidTableName(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Properties for type '{0}' can only be mapped once. Ensure the MapInheritedProperties method is only used during one call to the Map method."
	/// </summary>
	internal static Exception EntityMappingConfiguration_DuplicateMapInheritedProperties(object p0)
	{
		return new InvalidOperationException(Strings.EntityMappingConfiguration_DuplicateMapInheritedProperties(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Properties for type '{0}' can only be mapped once. Ensure the Properties method is used and that repeated calls specify each non-key property only once."
	/// </summary>
	internal static Exception EntityMappingConfiguration_DuplicateMappedProperties(object p0)
	{
		return new InvalidOperationException(Strings.EntityMappingConfiguration_DuplicateMappedProperties(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Properties for type '{0}' can only be mapped once. The non-key property '{1}' is mapped more than once. Ensure the Properties method specifies each non-key property only once."
	/// </summary>
	internal static Exception EntityMappingConfiguration_DuplicateMappedProperty(object p0, object p1)
	{
		return new InvalidOperationException(Strings.EntityMappingConfiguration_DuplicateMappedProperty(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The property '{1}' on type '{0}' cannot be mapped because it has been explicitly excluded from the model."
	/// </summary>
	internal static Exception EntityMappingConfiguration_CannotMapIgnoredProperty(object p0, object p1)
	{
		return new InvalidOperationException(Strings.EntityMappingConfiguration_CannotMapIgnoredProperty(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The entity types '{0}' and '{1}' cannot share table '{2}' because they are not in the same type hierarchy or do not have a valid one to one foreign key relationship with matching primary keys between them."
	/// </summary>
	internal static Exception EntityMappingConfiguration_InvalidTableSharing(object p0, object p1, object p2)
	{
		return new InvalidOperationException(Strings.EntityMappingConfiguration_InvalidTableSharing(p0, p1, p2));
	}

	/// <summary>
	/// InvalidOperationException with message like "The property '{0}' cannot be used as a key property on the entity '{1}' because the property type is not a valid key type. Only scalar types, string and byte[] are supported key types."
	/// </summary>
	internal static Exception ModelBuilder_KeyPropertiesMustBePrimitive(object p0, object p1)
	{
		return new InvalidOperationException(Strings.ModelBuilder_KeyPropertiesMustBePrimitive(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The specified table '{0}' was not found in the model. Ensure that the table name has been correctly specified."
	/// </summary>
	internal static Exception TableNotFound(object p0)
	{
		return new InvalidOperationException(Strings.TableNotFound(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The specified association foreign key columns '{0}' are invalid. The number of columns specified must match the number of primary key columns."
	/// </summary>
	internal static Exception IncorrectColumnCount(object p0)
	{
		return new InvalidOperationException(Strings.IncorrectColumnCount(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "A circular ComplexType hierarchy was detected. Self-referencing ComplexTypes are not supported."
	/// </summary>
	internal static Exception CircularComplexTypeHierarchy()
	{
		return new InvalidOperationException(Strings.CircularComplexTypeHierarchy);
	}

	/// <summary>
	/// InvalidOperationException with message like "Unable to determine the principal end of an association between the types '{0}' and '{1}'. The principal end of this association must be explicitly configured using either the relationship fluent API or data annotations."
	/// </summary>
	internal static Exception UnableToDeterminePrincipal(object p0, object p1)
	{
		return new InvalidOperationException(Strings.UnableToDeterminePrincipal(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The abstract type '{0}' has no mapped descendents and so cannot be mapped. Either remove '{0}' from the model or add one or more types deriving from '{0}' to the model. "
	/// </summary>
	internal static Exception UnmappedAbstractType(object p0)
	{
		return new InvalidOperationException(Strings.UnmappedAbstractType(p0));
	}

	/// <summary>
	/// NotSupportedException with message like "The type '{0}' cannot be mapped as defined because it maps inherited properties from types that use entity splitting or another form of inheritance. Either choose a different inheritance mapping strategy so as to not map inherited properties, or change all types in the hierarchy to map inherited properties and to not use splitting. "
	/// </summary>
	internal static Exception UnsupportedHybridInheritanceMapping(object p0)
	{
		return new NotSupportedException(Strings.UnsupportedHybridInheritanceMapping(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Cannot get value for property '{0}' from entity of type '{1}' because the property has no get accessor."
	/// </summary>
	internal static Exception DbPropertyEntry_CannotGetCurrentValue(object p0, object p1)
	{
		return new InvalidOperationException(Strings.DbPropertyEntry_CannotGetCurrentValue(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Cannot set value for property '{0}' on entity of type '{1}' because the property has no set accessor."
	/// </summary>
	internal static Exception DbPropertyEntry_CannotSetCurrentValue(object p0, object p1)
	{
		return new InvalidOperationException(Strings.DbPropertyEntry_CannotSetCurrentValue(p0, p1));
	}

	internal static Exception DbPropertyEntry_NotSupportedForDetached(object p0, object p1, object p2)
	{
		return new InvalidOperationException(Strings.DbPropertyEntry_NotSupportedForDetached(p0, p1, p2));
	}

	/// <summary>
	/// NotSupportedException with message like "Cannot set value for property '{0}' on entity of type '{1}' because the property has no set accessor and is in the '{2}' state."
	/// </summary>
	internal static Exception DbPropertyEntry_SettingEntityRefNotSupported(object p0, object p1, object p2)
	{
		return new NotSupportedException(Strings.DbPropertyEntry_SettingEntityRefNotSupported(p0, p1, p2));
	}

	/// <summary>
	/// InvalidOperationException with message like "Member '{0}' cannot be called for property '{1}' on entity of type '{2}' because the property is not part of the Entity Data Model."
	/// </summary>
	internal static Exception DbPropertyEntry_NotSupportedForPropertiesNotInTheModel(object p0, object p1, object p2)
	{
		return new InvalidOperationException(Strings.DbPropertyEntry_NotSupportedForPropertiesNotInTheModel(p0, p1, p2));
	}

	internal static Exception DbEntityEntry_NotSupportedForDetached(object p0, object p1)
	{
		return new InvalidOperationException(Strings.DbEntityEntry_NotSupportedForDetached(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "Cannot call the {0} method for an entity of type '{1}' on a DbSet for entities of type '{2}'. Only entities of type '{2}' or derived from type '{2}' can be added, attached, or removed."
	/// </summary>
	internal static Exception DbSet_BadTypeForAddAttachRemove(object p0, object p1, object p2)
	{
		return new ArgumentException(Strings.DbSet_BadTypeForAddAttachRemove(p0, p1, p2));
	}

	/// <summary>
	/// ArgumentException with message like "Cannot call the Create method for the type '{0}' on a DbSet for entities of type '{1}'. Only entities of type '{1}' or derived from type '{1}' can be created."
	/// </summary>
	internal static Exception DbSet_BadTypeForCreate(object p0, object p1)
	{
		return new ArgumentException(Strings.DbSet_BadTypeForCreate(p0, p1));
	}

	internal static Exception DbEntity_BadTypeForCast(object p0, object p1, object p2)
	{
		return new InvalidCastException(Strings.DbEntity_BadTypeForCast(p0, p1, p2));
	}

	internal static Exception DbMember_BadTypeForCast(object p0, object p1, object p2, object p3, object p4)
	{
		return new InvalidCastException(Strings.DbMember_BadTypeForCast(p0, p1, p2, p3, p4));
	}

	/// <summary>
	/// ArgumentException with message like "The property '{0}' on type '{1}' is a collection navigation property. The Collection method should be used instead of the Reference method."
	/// </summary>
	internal static Exception DbEntityEntry_UsedReferenceForCollectionProp(object p0, object p1)
	{
		return new ArgumentException(Strings.DbEntityEntry_UsedReferenceForCollectionProp(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "The property '{0}' on type '{1}' is a reference navigation property. The Reference method should be used instead of the Collection method."
	/// </summary>
	internal static Exception DbEntityEntry_UsedCollectionForReferenceProp(object p0, object p1)
	{
		return new ArgumentException(Strings.DbEntityEntry_UsedCollectionForReferenceProp(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "The property '{0}' on type '{1}' is not a navigation property. The Reference and Collection methods can only be used with navigation properties. Use the Property or ComplexProperty method."
	/// </summary>
	internal static Exception DbEntityEntry_NotANavigationProperty(object p0, object p1)
	{
		return new ArgumentException(Strings.DbEntityEntry_NotANavigationProperty(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "The property '{0}' on type '{1}' is not a primitive or complex property. The Property method can only be used with primitive or complex properties. Use the Reference or Collection method."
	/// </summary>
	internal static Exception DbEntityEntry_NotAScalarProperty(object p0, object p1)
	{
		return new ArgumentException(Strings.DbEntityEntry_NotAScalarProperty(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "The property '{0}' on type '{1}' is not a complex property. The ComplexProperty method can only be used with complex properties. Use the Property, Reference or Collection method."
	/// </summary>
	internal static Exception DbEntityEntry_NotAComplexProperty(object p0, object p1)
	{
		return new ArgumentException(Strings.DbEntityEntry_NotAComplexProperty(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "The property '{0}' on type '{1}' is not a primitive property, complex property, collection navigation property, or reference navigation property."
	/// </summary>
	internal static Exception DbEntityEntry_NotAProperty(object p0, object p1)
	{
		return new ArgumentException(Strings.DbEntityEntry_NotAProperty(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like ""The property '{0}' from the property path '{1}' is not a complex property on type '{2}'. Property paths must be composed of complex properties for all except the final property.""
	/// </summary>
	internal static Exception DbEntityEntry_DottedPartNotComplex(object p0, object p1, object p2)
	{
		return new ArgumentException(Strings.DbEntityEntry_DottedPartNotComplex(p0, p1, p2));
	}

	/// <summary>
	/// ArgumentException with message like ""The property path '{0}' cannot be used for navigation properties. Property paths can only be used to access primitive or complex properties.""
	/// </summary>
	internal static Exception DbEntityEntry_DottedPathMustBeProperty(object p0)
	{
		return new ArgumentException(Strings.DbEntityEntry_DottedPathMustBeProperty(p0));
	}

	/// <summary>
	/// ArgumentException with message like "The navigation property '{0}' on entity type '{1}' cannot be used for entities of type '{2}' because it refers to entities of type '{3}'."
	/// </summary>
	internal static Exception DbEntityEntry_WrongGenericForNavProp(object p0, object p1, object p2, object p3)
	{
		return new ArgumentException(Strings.DbEntityEntry_WrongGenericForNavProp(p0, p1, p2, p3));
	}

	/// <summary>
	/// ArgumentException with message like "The generic type argument '{0}' cannot be used with the Member method when accessing the collection navigation property '{1}' on entity type '{2}'. The generic type argument '{3}' must be used instead."
	/// </summary>
	internal static Exception DbEntityEntry_WrongGenericForCollectionNavProp(object p0, object p1, object p2, object p3)
	{
		return new ArgumentException(Strings.DbEntityEntry_WrongGenericForCollectionNavProp(p0, p1, p2, p3));
	}

	/// <summary>
	/// ArgumentException with message like "The property '{0}' on entity type '{1}' cannot be used for objects of type '{2}' because it is a property for objects of type '{3}'."
	/// </summary>
	internal static Exception DbEntityEntry_WrongGenericForProp(object p0, object p1, object p2, object p3)
	{
		return new ArgumentException(Strings.DbEntityEntry_WrongGenericForProp(p0, p1, p2, p3));
	}

	/// <summary>
	/// NotSupportedException with message like "Setting IsModified to false for a modified property is not supported."
	/// </summary>
	internal static Exception DbPropertyEntry_CannotMarkPropertyUnmodified()
	{
		return new NotSupportedException(Strings.DbPropertyEntry_CannotMarkPropertyUnmodified);
	}

	/// <summary>
	/// ArgumentException with message like "The expression passed to method {0} must represent a property defined on the type '{1}'."
	/// </summary>
	internal static Exception DbEntityEntry_BadPropertyExpression(object p0, object p1)
	{
		return new ArgumentException(Strings.DbEntityEntry_BadPropertyExpression(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "{0} cannot be used for entities in the {1} state."
	/// </summary>
	internal static Exception DbPropertyValues_CannotGetValuesForState(object p0, object p1)
	{
		return new InvalidOperationException(Strings.DbPropertyValues_CannotGetValuesForState(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Cannot set non-nullable property '{0}' of type '{1}' to null on object of type '{2}'."
	/// </summary>
	internal static Exception DbPropertyValues_CannotSetNullValue(object p0, object p1, object p2)
	{
		return new InvalidOperationException(Strings.DbPropertyValues_CannotSetNullValue(p0, p1, p2));
	}

	/// <summary>
	/// InvalidOperationException with message like "The property '{0}' in the entity of type '{1}' is null. Store values cannot be obtained for an entity with a null complex property."
	/// </summary>
	internal static Exception DbPropertyValues_CannotGetStoreValuesWhenComplexPropertyIsNull(object p0, object p1)
	{
		return new InvalidOperationException(Strings.DbPropertyValues_CannotGetStoreValuesWhenComplexPropertyIsNull(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Cannot assign value of type '{0}' to property '{1}' of type '{2}' in property values for type '{3}'."
	/// </summary>
	internal static Exception DbPropertyValues_WrongTypeForAssignment(object p0, object p1, object p2, object p3)
	{
		return new InvalidOperationException(Strings.DbPropertyValues_WrongTypeForAssignment(p0, p1, p2, p3));
	}

	/// <summary>
	/// NotSupportedException with message like "The set of property value names is read-only."
	/// </summary>
	internal static Exception DbPropertyValues_PropertyValueNamesAreReadonly()
	{
		return new NotSupportedException(Strings.DbPropertyValues_PropertyValueNamesAreReadonly);
	}

	/// <summary>
	/// ArgumentException with message like "The '{0}' property does not exist or is not mapped for the type '{1}'."
	/// </summary>
	internal static Exception DbPropertyValues_PropertyDoesNotExist(object p0, object p1)
	{
		return new ArgumentException(Strings.DbPropertyValues_PropertyDoesNotExist(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "Cannot copy values from DbPropertyValues for type '{0}' into DbPropertyValues for type '{1}'."
	/// </summary>
	internal static Exception DbPropertyValues_AttemptToSetValuesFromWrongObject(object p0, object p1)
	{
		return new ArgumentException(Strings.DbPropertyValues_AttemptToSetValuesFromWrongObject(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "Cannot copy from property values for object of type '{0}' into property values for object of type '{1}'."
	/// </summary>
	internal static Exception DbPropertyValues_AttemptToSetValuesFromWrongType(object p0, object p1)
	{
		return new ArgumentException(Strings.DbPropertyValues_AttemptToSetValuesFromWrongType(p0, p1));
	}

	/// <summary>
	/// ArgumentException with message like "A property of a complex type must be set to an instance of the generic or non-generic DbPropertyValues class for that type."
	/// </summary>
	internal static Exception DbPropertyValues_AttemptToSetNonValuesOnComplexProperty()
	{
		return new ArgumentException(Strings.DbPropertyValues_AttemptToSetNonValuesOnComplexProperty);
	}

	/// <summary>
	/// InvalidOperationException with message like "The value of the complex property '{0}' on entity of type '{1}' is null. Complex properties cannot be set to null and values cannot be set for null complex properties."
	/// </summary>
	internal static Exception DbPropertyValues_ComplexObjectCannotBeNull(object p0, object p1)
	{
		return new InvalidOperationException(Strings.DbPropertyValues_ComplexObjectCannotBeNull(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The value of the nested property values property '{0}' on the values for entity of type '{1}' is null. Nested property values cannot be set to null and values cannot be set for null complex properties."
	/// </summary>
	internal static Exception DbPropertyValues_NestedPropertyValuesNull(object p0, object p1)
	{
		return new InvalidOperationException(Strings.DbPropertyValues_NestedPropertyValuesNull(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "The model backing the '{0}' context has changed since the database was created. Consider using Code First Migrations to update the database (http://go.microsoft.com/fwlink/?LinkId=238269)."
	/// </summary>
	internal static Exception DatabaseInitializationStrategy_ModelMismatch(object p0)
	{
		return new InvalidOperationException(Strings.DatabaseInitializationStrategy_ModelMismatch(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Database '{0}' cannot be created because it already exists."
	/// </summary>
	internal static Exception Database_DatabaseAlreadyExists(object p0)
	{
		return new InvalidOperationException(Strings.Database_DatabaseAlreadyExists(p0));
	}

	/// <summary>
	/// NotSupportedException with message like "Model compatibility cannot be checked because the DbContext instance was not created using Code First patterns. DbContext instances created from an ObjectContext or using an EDMX file cannot be checked for compatibility."
	/// </summary>
	internal static Exception Database_NonCodeFirstCompatibilityCheck()
	{
		return new NotSupportedException(Strings.Database_NonCodeFirstCompatibilityCheck);
	}

	/// <summary>
	/// NotSupportedException with message like "Model compatibility cannot be checked because the database does not contain model metadata. Model compatibility can only be checked for databases created using Code First or Code First Migrations."
	/// </summary>
	internal static Exception Database_NoDatabaseMetadata()
	{
		return new NotSupportedException(Strings.Database_NoDatabaseMetadata);
	}

	internal static Exception Database_BadLegacyInitializerEntry(object p0, object p1)
	{
		return new InvalidOperationException(Strings.Database_BadLegacyInitializerEntry(p0, p1));
	}

	internal static Exception Database_InitializeFromLegacyConfigFailed(object p0, object p1)
	{
		return new InvalidOperationException(Strings.Database_InitializeFromLegacyConfigFailed(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Failed to set database initializer of type '{0}' for DbContext type '{1}' specified in the application configuration. See inner exception for details."
	/// </summary>
	internal static Exception Database_InitializeFromConfigFailed(object p0, object p1)
	{
		return new InvalidOperationException(Strings.Database_InitializeFromConfigFailed(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Configuration for DbContext type '{0}' is specified multiple times in the application configuration. Each context can only be configured once."
	/// </summary>
	internal static Exception ContextConfiguredMultipleTimes(object p0)
	{
		return new InvalidOperationException(Strings.ContextConfiguredMultipleTimes(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Failed to set Database.DefaultConnectionFactory to an instance of the '{0}' type as specified in the application configuration. See inner exception for details."
	/// </summary>
	internal static Exception SetConnectionFactoryFromConfigFailed(object p0)
	{
		return new InvalidOperationException(Strings.SetConnectionFactoryFromConfigFailed(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The type '{0}' could not be found. The type name must be an assembly-qualified name."
	/// </summary>
	internal static Exception Database_FailedToResolveType(object p0)
	{
		return new InvalidOperationException(Strings.Database_FailedToResolveType(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The context cannot be used while the model is being created."
	/// </summary>
	internal static Exception DbContext_ContextUsedInModelCreating()
	{
		return new InvalidOperationException(Strings.DbContext_ContextUsedInModelCreating);
	}

	/// <summary>
	/// InvalidOperationException with message like "The DbContext class cannot be used with models that have multiple entity sets per type (MEST)."
	/// </summary>
	internal static Exception DbContext_MESTNotSupported()
	{
		return new InvalidOperationException(Strings.DbContext_MESTNotSupported);
	}

	/// <summary>
	/// InvalidOperationException with message like "The operation cannot be completed because the DbContext has been disposed."
	/// </summary>
	internal static Exception DbContext_Disposed()
	{
		return new InvalidOperationException(Strings.DbContext_Disposed);
	}

	/// <summary>
	/// InvalidOperationException with message like "The provider factory returned a null connection."
	/// </summary>
	internal static Exception DbContext_ProviderReturnedNullConnection()
	{
		return new InvalidOperationException(Strings.DbContext_ProviderReturnedNullConnection);
	}

	/// <summary>
	/// InvalidOperationException with message like "The connection string '{0}' in the application's configuration file does not contain the required providerName attribute.""
	/// </summary>
	internal static Exception DbContext_ProviderNameMissing(object p0)
	{
		return new InvalidOperationException(Strings.DbContext_ProviderNameMissing(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The DbConnectionFactory instance returned a null connection."
	/// </summary>
	internal static Exception DbContext_ConnectionFactoryReturnedNullConnection()
	{
		return new InvalidOperationException(Strings.DbContext_ConnectionFactoryReturnedNullConnection);
	}

	/// <summary>
	/// ArgumentException with message like "The number of primary key values passed must match number of primary key values defined on the entity."
	/// </summary>
	internal static Exception DbSet_WrongNumberOfKeyValuesPassed()
	{
		return new ArgumentException(Strings.DbSet_WrongNumberOfKeyValuesPassed);
	}

	/// <summary>
	/// ArgumentException with message like "The type of one of the primary key values did not match the type defined in the entity. See inner exception for details."
	/// </summary>
	internal static Exception DbSet_WrongKeyValueType()
	{
		return new ArgumentException(Strings.DbSet_WrongKeyValueType);
	}

	/// <summary>
	/// InvalidOperationException with message like "The entity found was of type {0} when an entity of type {1} was requested."
	/// </summary>
	internal static Exception DbSet_WrongEntityTypeFound(object p0, object p1)
	{
		return new InvalidOperationException(Strings.DbSet_WrongEntityTypeFound(p0, p1));
	}

	/// <summary>
	/// InvalidOperationException with message like "Multiple entities were found in the Added state that match the given primary key values."
	/// </summary>
	internal static Exception DbSet_MultipleAddedEntitiesFound()
	{
		return new InvalidOperationException(Strings.DbSet_MultipleAddedEntitiesFound);
	}

	/// <summary>
	/// InvalidOperationException with message like "The type '{0}' is mapped as a complex type. The Set method, DbSet objects, and DbEntityEntry objects can only be used with entity types, not complex types."
	/// </summary>
	internal static Exception DbSet_DbSetUsedWithComplexType(object p0)
	{
		return new InvalidOperationException(Strings.DbSet_DbSetUsedWithComplexType(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The type '{0}' is not attributed with EdmEntityTypeAttribute but is contained in an assembly attributed with EdmSchemaAttribute. POCO entities that do not use EdmEntityTypeAttribute cannot be contained in the same assembly as non-POCO entities that use EdmEntityTypeAttribute."
	/// </summary>
	internal static Exception DbSet_PocoAndNonPocoMixedInSameAssembly(object p0)
	{
		return new InvalidOperationException(Strings.DbSet_PocoAndNonPocoMixedInSameAssembly(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The entity type {0} is not part of the model for the current context."
	/// </summary>
	internal static Exception DbSet_EntityTypeNotInModel(object p0)
	{
		return new InvalidOperationException(Strings.DbSet_EntityTypeNotInModel(p0));
	}

	/// <summary>
	/// NotSupportedException with message like "Data binding directly to a store query (DbSet, DbQuery, DbSqlQuery) is not supported. Instead populate a DbSet with data, for example by calling Load on the DbSet, and then bind to local data. For WPF bind to DbSet.Local. For WinForms bind to DbSet.Local.ToBindingList()."
	/// </summary>
	internal static Exception DbQuery_BindingToDbQueryNotSupported()
	{
		return new NotSupportedException(Strings.DbQuery_BindingToDbQueryNotSupported);
	}

	/// <summary>
	/// ArgumentException with message like "The Include path expression must refer to a navigation property defined on the type. Use dotted paths for reference navigation properties and the Select operator for collection navigation properties."
	/// </summary>
	internal static Exception DbExtensions_InvalidIncludePathExpression()
	{
		return new ArgumentException(Strings.DbExtensions_InvalidIncludePathExpression);
	}

	/// <summary>
	/// InvalidOperationException with message like "No connection string named '{0}' could be found in the application config file."
	/// </summary>
	internal static Exception DbContext_ConnectionStringNotFound(object p0)
	{
		return new InvalidOperationException(Strings.DbContext_ConnectionStringNotFound(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "Cannot initialize a DbContext from an entity connection string or an EntityConnection instance together with a DbCompiledModel. If an entity connection string or EntityConnection instance is used, then the model will be created from the metadata in the connection. If a DbCompiledModel is used, then the connection supplied should be a standard database connection (for example, a SqlConnection instance) rather than an entity connection."
	/// </summary>
	internal static Exception DbContext_ConnectionHasModel()
	{
		return new InvalidOperationException(Strings.DbContext_ConnectionHasModel);
	}

	/// <summary>
	/// NotSupportedException with message like "The collection navigation property '{0}' on the entity of type '{1}' cannot be set because the entity type does not define a navigation property with a set accessor."
	/// </summary>
	internal static Exception DbCollectionEntry_CannotSetCollectionProp(object p0, object p1)
	{
		return new NotSupportedException(Strings.DbCollectionEntry_CannotSetCollectionProp(p0, p1));
	}

	/// <summary>
	/// NotSupportedException with message like "Using the same DbCompiledModel to create contexts against different types of database servers is not supported. Instead, create a separate DbCompiledModel for each type of server being used."
	/// </summary>
	internal static Exception CodeFirstCachedMetadataWorkspace_SameModelDifferentProvidersNotSupported()
	{
		return new NotSupportedException(Strings.CodeFirstCachedMetadataWorkspace_SameModelDifferentProvidersNotSupported);
	}

	/// <summary>
	/// InvalidOperationException with message like "Multiple object sets per type are not supported. The object sets '{0}' and '{1}' can both contain instances of type '{2}'."
	/// </summary>
	internal static Exception Mapping_MESTNotSupported(object p0, object p1, object p2)
	{
		return new InvalidOperationException(Strings.Mapping_MESTNotSupported(p0, p1, p2));
	}

	/// <summary>
	/// InvalidOperationException with message like "The context type '{0}' must have a public constructor taking an EntityConnection."
	/// </summary>
	internal static Exception DbModelBuilder_MissingRequiredCtor(object p0)
	{
		return new InvalidOperationException(Strings.DbModelBuilder_MissingRequiredCtor(p0));
	}

	/// <summary>
	/// NotSupportedException with message like "The database name '{0}' is not supported because it is an MDF file name. A full connection string must be provided to attach an MDF file."
	/// </summary>
	internal static Exception SqlConnectionFactory_MdfNotSupported(object p0)
	{
		return new NotSupportedException(Strings.SqlConnectionFactory_MdfNotSupported(p0));
	}

	/// <summary>
	/// DataException with message like "An exception occurred while initializing the database. See the InnerException for details."
	/// </summary>
	internal static Exception Database_InitializationException()
	{
		return new DataException(Strings.Database_InitializationException);
	}

	/// <summary>
	/// NotSupportedException with message like "Creating a DbModelBuilder or writing the EDMX from a DbContext created using an existing ObjectContext is not supported. EDMX can only be obtained from a Code First DbContext created without using an existing DbCompiledModel."
	/// </summary>
	internal static Exception EdmxWriter_EdmxFromObjectContextNotSupported()
	{
		return new NotSupportedException(Strings.EdmxWriter_EdmxFromObjectContextNotSupported);
	}

	/// <summary>
	/// NotSupportedException with message like "Creating a DbModelBuilder or writing the EDMX from a DbContext created using Database First or Model First is not supported. EDMX can only be obtained from a Code First DbContext created without using an existing DbCompiledModel."
	/// </summary>
	internal static Exception EdmxWriter_EdmxFromModelFirstNotSupported()
	{
		return new NotSupportedException(Strings.EdmxWriter_EdmxFromModelFirstNotSupported);
	}

	/// <summary>
	/// InvalidOperationException with message like "The context factory type '{0}' must have a public default constructor."
	/// </summary>
	internal static Exception DbContextServices_MissingDefaultCtor(object p0)
	{
		return new InvalidOperationException(Strings.DbContextServices_MissingDefaultCtor(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "MaxLengthAttribute must have a Length value that is greater than zero. Use MaxLength() without parameters to  indicate that the string or array can have the maximum allowable length."
	/// </summary>
	internal static Exception MaxLengthAttribute_InvalidMaxLength()
	{
		return new InvalidOperationException(Strings.MaxLengthAttribute_InvalidMaxLength);
	}

	/// <summary>
	/// InvalidOperationException with message like "MinLengthAttribute must have a Length value that is zero or greater."
	/// </summary>
	internal static Exception MinLengthAttribute_InvalidMinLength()
	{
		return new InvalidOperationException(Strings.MinLengthAttribute_InvalidMinLength);
	}

	/// <summary>
	/// InvalidOperationException with message like "No connection string named '{0}' could be found in the application config file."
	/// </summary>
	internal static Exception DbConnectionInfo_ConnectionStringNotFound(object p0)
	{
		return new InvalidOperationException(Strings.DbConnectionInfo_ConnectionStringNotFound(p0));
	}

	/// <summary>
	/// InvalidOperationException with message like "The connection can not be overridden because this context was created from an existing ObjectContext."
	/// </summary>
	internal static Exception EagerInternalContext_CannotSetConnectionInfo()
	{
		return new InvalidOperationException(Strings.EagerInternalContext_CannotSetConnectionInfo);
	}

	/// <summary>
	/// InvalidOperationException with message like "Can not override the connection for this context with a standard DbConnection because the original connection was an EntityConnection."
	/// </summary>
	internal static Exception LazyInternalContext_CannotReplaceEfConnectionWithDbConnection()
	{
		return new InvalidOperationException(Strings.LazyInternalContext_CannotReplaceEfConnectionWithDbConnection);
	}

	/// <summary>
	/// InvalidOperationException with message like "Can not override the connection for this context with an EntityConnection because the original connection was a standard DbConnection."
	/// </summary>
	internal static Exception LazyInternalContext_CannotReplaceDbConnectionWithEfConnection()
	{
		return new InvalidOperationException(Strings.LazyInternalContext_CannotReplaceDbConnectionWithEfConnection);
	}

	/// <summary>
	/// The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.
	/// </summary>
	internal static Exception ArgumentNull(string paramName)
	{
		return new ArgumentNullException(paramName);
	}

	/// <summary>
	/// The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.
	/// </summary>
	internal static Exception ArgumentOutOfRange(string paramName)
	{
		return new ArgumentOutOfRangeException(paramName);
	}

	/// <summary>
	/// The exception that is thrown when the author has yet to implement the logic at this point in the program. This can act as an exception based TODO tag.
	/// </summary>
	internal static Exception NotImplemented()
	{
		return new NotImplementedException();
	}

	/// <summary>
	/// The exception that is thrown when an invoked method is not supported, or when there is an attempt to read, seek, or write to a stream that does not support the invoked functionality. 
	/// </summary>
	internal static Exception NotSupported()
	{
		return new NotSupportedException();
	}
}
