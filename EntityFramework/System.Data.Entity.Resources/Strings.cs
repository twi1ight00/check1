using System.CodeDom.Compiler;

namespace System.Data.Entity.Resources;

/// <summary>
///    Strongly-typed and parameterized string resources.
/// </summary>
[GeneratedCode("Resources.tt", "1.0.0.0")]
internal static class Strings
{
	/// <summary>
	/// A string like "AutomaticMigration"
	/// </summary>
	internal static string AutomaticMigration => EntityRes.GetString("AutomaticMigration");

	/// <summary>
	/// A string like "BootstrapMigration"
	/// </summary>
	internal static string BootstrapMigration => EntityRes.GetString("BootstrapMigration");

	/// <summary>
	/// A string like "InitialCreate"
	/// </summary>
	internal static string InitialCreate => EntityRes.GetString("InitialCreate");

	/// <summary>
	/// A string like "Automatic migration was not applied because it would result in data loss."
	/// </summary>
	internal static string AutomaticDataLoss => EntityRes.GetString("AutomaticDataLoss");

	/// <summary>
	/// A string like "[Inserting migration history record]"
	/// </summary>
	internal static string LoggingHistoryInsert => EntityRes.GetString("LoggingHistoryInsert");

	/// <summary>
	/// A string like "[Deleting migration history record]"
	/// </summary>
	internal static string LoggingHistoryDelete => EntityRes.GetString("LoggingHistoryDelete");

	/// <summary>
	/// A string like "[Updating EdmMetadata model hash]"
	/// </summary>
	internal static string LoggingMetadataUpdate => EntityRes.GetString("LoggingMetadataUpdate");

	/// <summary>
	/// A string like "Running Seed method."
	/// </summary>
	internal static string LoggingSeedingDatabase => EntityRes.GetString("LoggingSeedingDatabase");

	/// <summary>
	/// A string like "No pending explicit migrations."
	/// </summary>
	internal static string LoggingNoExplicitMigrations => EntityRes.GetString("LoggingNoExplicitMigrations");

	/// <summary>
	/// A string like "Explicit"
	/// </summary>
	internal static string LoggingExplicit => EntityRes.GetString("LoggingExplicit");

	/// <summary>
	/// A string like "Upgrading history table."
	/// </summary>
	internal static string UpgradingHistoryTable => EntityRes.GetString("UpgradingHistoryTable");

	/// <summary>
	/// A string like "Cannot scaffold the next migration because the target database was created with a version of Code First earlier than EF 4.3 and does not contain the migrations history table. To start using migrations against this database, ensure the current model is compatible with the target database and execute the migrations Update process. (In Visual Studio you can use the Update-Database command from Package Manager Console to execute the migrations Update process)."
	/// </summary>
	internal static string MetadataOutOfDate => EntityRes.GetString("MetadataOutOfDate");

	/// <summary>
	/// A string like "Unable to update database to match the current model because there are pending changes and automatic migration is disabled. Either write the pending model changes to a code-based migration or enable automatic migration. Set DbMigrationsConfiguration.AutomaticMigrationsEnabled to true to enable automatic migration."
	/// </summary>
	internal static string AutomaticDisabledException => EntityRes.GetString("AutomaticDisabledException");

	/// <summary>
	/// A string like "Scripting the downgrade between two specified migrations is not supported."
	/// </summary>
	internal static string DownScriptWindowsNotSupported => EntityRes.GetString("DownScriptWindowsNotSupported");

	/// <summary>
	/// A string like "Direct column renaming is not supported by SQL Server Compact. To rename a column in SQL Server Compact, you will need to recreate it."
	/// </summary>
	internal static string SqlCeColumnRenameNotSupported => EntityRes.GetString("SqlCeColumnRenameNotSupported");

	/// <summary>
	/// A string like "One or more validation errors were detected during model generation:"
	/// </summary>
	internal static string ValidationHeader => EntityRes.GetString("ValidationHeader");

	/// <summary>
	/// A string like "A circular ComplexType hierarchy was detected. Self-referencing ComplexTypes are not supported."
	/// </summary>
	internal static string CircularComplexTypeHierarchy => EntityRes.GetString("CircularComplexTypeHierarchy");

	/// <summary>
	/// A string like "Connection to the database failed. The connection string is configured with an invalid LocalDB server name. This may have been set in 'global.asax' by a pre-release version of MVC4. The default connection factory is now set in web.config so the line in 'global.asax' starting with 'Database.DefaultConnectionFactory = ' should be removed. See http://go.microsoft.com/fwlink/?LinkId=243166 for details."
	/// </summary>
	internal static string BadLocalDBDatabaseName => EntityRes.GetString("BadLocalDBDatabaseName");

	/// <summary>
	/// A string like "An error occurred while getting provider information from the database. This can be caused by Entity Framework using an incorrect connection string. Check the inner exceptions for details and ensure that the connection string is correct."
	/// </summary>
	internal static string FailedToGetProviderInformation => EntityRes.GetString("FailedToGetProviderInformation");

	/// <summary>
	/// A string like "Setting IsModified to false for a modified property is not supported."
	/// </summary>
	internal static string DbPropertyEntry_CannotMarkPropertyUnmodified => EntityRes.GetString("DbPropertyEntry_CannotMarkPropertyUnmodified");

	/// <summary>
	/// A string like "An error occurred while saving entities that do not expose foreign key properties for their relationships. The EntityEntries property will return null because a single entity cannot be identified as the source of the exception. Handling of exceptions while saving can be made easier by exposing foreign key properties in your entity types. See the InnerException for details."
	/// </summary>
	internal static string DbContext_IndependentAssociationUpdateException => EntityRes.GetString("DbContext_IndependentAssociationUpdateException");

	/// <summary>
	/// A string like "The set of property value names is read-only."
	/// </summary>
	internal static string DbPropertyValues_PropertyValueNamesAreReadonly => EntityRes.GetString("DbPropertyValues_PropertyValueNamesAreReadonly");

	/// <summary>
	/// A string like "A property of a complex type must be set to an instance of the generic or non-generic DbPropertyValues class for that type."
	/// </summary>
	internal static string DbPropertyValues_AttemptToSetNonValuesOnComplexProperty => EntityRes.GetString("DbPropertyValues_AttemptToSetNonValuesOnComplexProperty");

	/// <summary>
	/// A string like "Model compatibility cannot be checked because the DbContext instance was not created using Code First patterns. DbContext instances created from an ObjectContext or using an EDMX file cannot be checked for compatibility."
	/// </summary>
	internal static string Database_NonCodeFirstCompatibilityCheck => EntityRes.GetString("Database_NonCodeFirstCompatibilityCheck");

	/// <summary>
	/// A string like "Model compatibility cannot be checked because the database does not contain model metadata. Model compatibility can only be checked for databases created using Code First or Code First Migrations."
	/// </summary>
	internal static string Database_NoDatabaseMetadata => EntityRes.GetString("Database_NoDatabaseMetadata");

	/// <summary>
	/// A string like "The context cannot be used while the model is being created."
	/// </summary>
	internal static string DbContext_ContextUsedInModelCreating => EntityRes.GetString("DbContext_ContextUsedInModelCreating");

	/// <summary>
	/// A string like "The DbContext class cannot be used with models that have multiple entity sets per type (MEST)."
	/// </summary>
	internal static string DbContext_MESTNotSupported => EntityRes.GetString("DbContext_MESTNotSupported");

	/// <summary>
	/// A string like "The operation cannot be completed because the DbContext has been disposed."
	/// </summary>
	internal static string DbContext_Disposed => EntityRes.GetString("DbContext_Disposed");

	/// <summary>
	/// A string like "The provider factory returned a null connection."
	/// </summary>
	internal static string DbContext_ProviderReturnedNullConnection => EntityRes.GetString("DbContext_ProviderReturnedNullConnection");

	/// <summary>
	/// A string like "The DbConnectionFactory instance returned a null connection."
	/// </summary>
	internal static string DbContext_ConnectionFactoryReturnedNullConnection => EntityRes.GetString("DbContext_ConnectionFactoryReturnedNullConnection");

	/// <summary>
	/// A string like "The number of primary key values passed must match number of primary key values defined on the entity."
	/// </summary>
	internal static string DbSet_WrongNumberOfKeyValuesPassed => EntityRes.GetString("DbSet_WrongNumberOfKeyValuesPassed");

	/// <summary>
	/// A string like "The type of one of the primary key values did not match the type defined in the entity. See inner exception for details."
	/// </summary>
	internal static string DbSet_WrongKeyValueType => EntityRes.GetString("DbSet_WrongKeyValueType");

	/// <summary>
	/// A string like "Multiple entities were found in the Added state that match the given primary key values."
	/// </summary>
	internal static string DbSet_MultipleAddedEntitiesFound => EntityRes.GetString("DbSet_MultipleAddedEntitiesFound");

	/// <summary>
	/// A string like "Data binding directly to a store query (DbSet, DbQuery, DbSqlQuery) is not supported. Instead populate a DbSet with data, for example by calling Load on the DbSet, and then bind to local data. For WPF bind to DbSet.Local. For WinForms bind to DbSet.Local.ToBindingList()."
	/// </summary>
	internal static string DbQuery_BindingToDbQueryNotSupported => EntityRes.GetString("DbQuery_BindingToDbQueryNotSupported");

	/// <summary>
	/// A string like "The Include path expression must refer to a navigation property defined on the type. Use dotted paths for reference navigation properties and the Select operator for collection navigation properties."
	/// </summary>
	internal static string DbExtensions_InvalidIncludePathExpression => EntityRes.GetString("DbExtensions_InvalidIncludePathExpression");

	/// <summary>
	/// A string like "Cannot initialize a DbContext from an entity connection string or an EntityConnection instance together with a DbCompiledModel. If an entity connection string or EntityConnection instance is used, then the model will be created from the metadata in the connection. If a DbCompiledModel is used, then the connection supplied should be a standard database connection (for example, a SqlConnection instance) rather than an entity connection."
	/// </summary>
	internal static string DbContext_ConnectionHasModel => EntityRes.GetString("DbContext_ConnectionHasModel");

	/// <summary>
	/// A string like "Using the same DbCompiledModel to create contexts against different types of database servers is not supported. Instead, create a separate DbCompiledModel for each type of server being used."
	/// </summary>
	internal static string CodeFirstCachedMetadataWorkspace_SameModelDifferentProvidersNotSupported => EntityRes.GetString("CodeFirstCachedMetadataWorkspace_SameModelDifferentProvidersNotSupported");

	/// <summary>
	/// A string like "Validation failed for one or more entities. See 'EntityValidationErrors' property for more details."
	/// </summary>
	internal static string DbEntityValidationException_ValidationFailed => EntityRes.GetString("DbEntityValidationException_ValidationFailed");

	/// <summary>
	/// A string like "An exception occurred while initializing the database. See the InnerException for details."
	/// </summary>
	internal static string Database_InitializationException => EntityRes.GetString("Database_InitializationException");

	/// <summary>
	/// A string like "Creating a DbModelBuilder or writing the EDMX from a DbContext created using an existing ObjectContext is not supported. EDMX can only be obtained from a Code First DbContext created without using an existing DbCompiledModel."
	/// </summary>
	internal static string EdmxWriter_EdmxFromObjectContextNotSupported => EntityRes.GetString("EdmxWriter_EdmxFromObjectContextNotSupported");

	/// <summary>
	/// A string like "Creating a DbModelBuilder or writing the EDMX from a DbContext created using Database First or Model First is not supported. EDMX can only be obtained from a Code First DbContext created without using an existing DbCompiledModel."
	/// </summary>
	internal static string EdmxWriter_EdmxFromModelFirstNotSupported => EntityRes.GetString("EdmxWriter_EdmxFromModelFirstNotSupported");

	/// <summary>
	/// A string like "Code generated using the T4 templates for Database First and Model First development may not work correctly if used in Code First mode. To continue using Database First or Model First ensure that the Entity Framework connection string is specified in the config file of executing application. To use these classes, that were generated from Database First or Model First, with Code First add any additional configuration using attributes or the DbModelBuilder API and then remove the code that throws this exception."
	/// </summary>
	internal static string UnintentionalCodeFirstException_Message => EntityRes.GetString("UnintentionalCodeFirstException_Message");

	/// <summary>
	/// A string like "NavigationProperty is not valid. The FromRole and ToRole are the same."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_BadNavigationPropertyRolesCannotBeTheSame => EntityRes.GetString("EdmModel_Validator_Semantic_BadNavigationPropertyRolesCannotBeTheSame");

	/// <summary>
	/// A string like "OnDelete can be specified on only one End of an EdmAssociation."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidOperationMultipleEndsInAssociation => EntityRes.GetString("EdmModel_Validator_Semantic_InvalidOperationMultipleEndsInAssociation");

	/// <summary>
	/// A string like "The number of properties in the Dependent and Principal Roles in a relationship constraint must be identical."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_MismatchNumberOfPropertiesinRelationshipConstraint => EntityRes.GetString("EdmModel_Validator_Semantic_MismatchNumberOfPropertiesinRelationshipConstraint");

	/// <summary>
	/// A string like "The name is missing or not valid."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_MissingName => EntityRes.GetString("EdmModel_Validator_Syntactic_MissingName");

	/// <summary>
	/// A string like "AssociationEnd must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmAssociationType_AssocationEndMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmAssociationType_AssocationEndMustNotBeNull");

	/// <summary>
	/// A string like "DependentEnd must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentEndMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentEndMustNotBeNull");

	/// <summary>
	/// A string like "DependentProperties must not be empty."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentPropertiesMustNotBeEmpty => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentPropertiesMustNotBeEmpty");

	/// <summary>
	/// A string like "Association must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmNavigationProperty_AssocationMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmNavigationProperty_AssocationMustNotBeNull");

	/// <summary>
	/// A string like "ResultEnd must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmNavigationProperty_ResultEndMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmNavigationProperty_ResultEndMustNotBeNull");

	/// <summary>
	/// A string like "EntityType must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmAssociationEnd_EntityTypeMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmAssociationEnd_EntityTypeMustNotBeNull");

	/// <summary>
	/// A string like "ElementType must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmEntitySet_ElementTypeMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmEntitySet_ElementTypeMustNotBeNull");

	/// <summary>
	/// A string like "ElementType must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmAssociationSet_ElementTypeMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmAssociationSet_ElementTypeMustNotBeNull");

	/// <summary>
	/// A string like "SourceSet must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmAssociationSet_SourceSetMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmAssociationSet_SourceSetMustNotBeNull");

	/// <summary>
	/// A string like "TargetSet must not be null."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmAssociationSet_TargetSetMustNotBeNull => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmAssociationSet_TargetSetMustNotBeNull");

	/// <summary>
	/// A string like "The type is not a valid EdmTypeReference."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmTypeReferenceNotValid => EntityRes.GetString("EdmModel_Validator_Syntactic_EdmTypeReferenceNotValid");

	/// <summary>
	/// A string like "Serializer can only serialize an EdmModel that has one EdmNamespace and one EdmEntityContainer."
	/// </summary>
	internal static string Serializer_OneNamespaceAndOneContainer => EntityRes.GetString("Serializer_OneNamespaceAndOneContainer");

	/// <summary>
	/// A string like "MaxLengthAttribute must have a Length value that is greater than zero. Use MaxLength() without parameters to  indicate that the string or array can have the maximum allowable length."
	/// </summary>
	internal static string MaxLengthAttribute_InvalidMaxLength => EntityRes.GetString("MaxLengthAttribute_InvalidMaxLength");

	/// <summary>
	/// A string like "MinLengthAttribute must have a Length value that is zero or greater."
	/// </summary>
	internal static string MinLengthAttribute_InvalidMinLength => EntityRes.GetString("MinLengthAttribute_InvalidMinLength");

	/// <summary>
	/// A string like "The connection can not be overridden because this context was created from an existing ObjectContext."
	/// </summary>
	internal static string EagerInternalContext_CannotSetConnectionInfo => EntityRes.GetString("EagerInternalContext_CannotSetConnectionInfo");

	/// <summary>
	/// A string like "Can not override the connection for this context with a standard DbConnection because the original connection was an EntityConnection."
	/// </summary>
	internal static string LazyInternalContext_CannotReplaceEfConnectionWithDbConnection => EntityRes.GetString("LazyInternalContext_CannotReplaceEfConnectionWithDbConnection");

	/// <summary>
	/// A string like "Can not override the connection for this context with an EntityConnection because the original connection was a standard DbConnection."
	/// </summary>
	internal static string LazyInternalContext_CannotReplaceDbConnectionWithEfConnection => EntityRes.GetString("LazyInternalContext_CannotReplaceDbConnectionWithEfConnection");

	/// <summary>
	/// A string like "Applying automatic migration: {0}."
	/// </summary>
	internal static string LoggingAutoMigrate(object p0)
	{
		return EntityRes.GetString("LoggingAutoMigrate", p0);
	}

	/// <summary>
	/// A string like "Reverting automatic migration: {0}."
	/// </summary>
	internal static string LoggingRevertAutoMigrate(object p0)
	{
		return EntityRes.GetString("LoggingRevertAutoMigrate", p0);
	}

	/// <summary>
	/// A string like "Applying explicit migration: {0}."
	/// </summary>
	internal static string LoggingApplyMigration(object p0)
	{
		return EntityRes.GetString("LoggingApplyMigration", p0);
	}

	/// <summary>
	/// A string like "Reverting explicit migration: {0}."
	/// </summary>
	internal static string LoggingRevertMigration(object p0)
	{
		return EntityRes.GetString("LoggingRevertMigration", p0);
	}

	/// <summary>
	/// A string like "Applying explicit migrations: [{1}]."
	/// </summary>
	internal static string LoggingPendingMigrations(object p0, object p1)
	{
		return EntityRes.GetString("LoggingPendingMigrations", p0, p1);
	}

	/// <summary>
	/// A string like "Reverting migrations: [{1}]."
	/// </summary>
	internal static string LoggingPendingMigrationsDown(object p0, object p1)
	{
		return EntityRes.GetString("LoggingPendingMigrationsDown", p0, p1);
	}

	/// <summary>
	/// A string like "Target database is already at version {0}."
	/// </summary>
	internal static string LoggingAlreadyAtTarget(object p0)
	{
		return EntityRes.GetString("LoggingAlreadyAtTarget", p0);
	}

	/// <summary>
	/// A string like "Target database is: {0}."
	/// </summary>
	internal static string LoggingTargetDatabase(object p0)
	{
		return EntityRes.GetString("LoggingTargetDatabase", p0);
	}

	/// <summary>
	/// A string like "'{1}' (DataSource: {0}, Provider: {2}, Origin: {3})"
	/// </summary>
	internal static string LoggingTargetDatabaseFormat(object p0, object p1, object p2, object p3)
	{
		return EntityRes.GetString("LoggingTargetDatabaseFormat", p0, p1, p2, p3);
	}

	/// <summary>
	/// A string like "The specified target migration '{0}' does not exist. Ensure that target migration refers to an existing migration id."
	/// </summary>
	internal static string MigrationNotFound(object p0)
	{
		return EntityRes.GetString("MigrationNotFound", p0);
	}

	/// <summary>
	/// A string like "The Foreign Key on table '{0}' with columns '{1}' could not be created because the principal key columns could not be determined. Use the AddForeignKey fluent API to fully specify the Foreign Key."
	/// </summary>
	internal static string PartialFkOperation(object p0, object p1)
	{
		return EntityRes.GetString("PartialFkOperation", p0, p1);
	}

	/// <summary>
	/// A string like "'{0}' is not a valid target migration. When targeting a previously applied automatic migration, use the full migration id including timestamp."
	/// </summary>
	internal static string AutoNotValidTarget(object p0)
	{
		return EntityRes.GetString("AutoNotValidTarget", p0);
	}

	/// <summary>
	/// A string like "'{0}' is not a valid migration. Explicit migrations must be used for both source and target when scripting the upgrade between them."
	/// </summary>
	internal static string AutoNotValidForScriptWindows(object p0)
	{
		return EntityRes.GetString("AutoNotValidForScriptWindows", p0);
	}

	/// <summary>
	/// A string like "The target context '{0}' is not constructible. Add a default constructor or provide an implementation of IDbContextFactory."
	/// </summary>
	internal static string ContextNotConstructible(object p0)
	{
		return EntityRes.GetString("ContextNotConstructible", p0);
	}

	/// <summary>
	/// A string like "The specified migration name '{0}' is ambiguous. Specify the full migration id including timestamp instead."
	/// </summary>
	internal static string AmbiguousMigrationName(object p0)
	{
		return EntityRes.GetString("AmbiguousMigrationName", p0);
	}

	/// <summary>
	/// A string like "The migrations configuration type '{0}' was not be found in the assembly '{1}'."
	/// </summary>
	internal static string AssemblyMigrator_NoConfigurationWithName(object p0, object p1)
	{
		return EntityRes.GetString("AssemblyMigrator_NoConfigurationWithName", p0, p1);
	}

	/// <summary>
	/// A string like "More than one migrations configuration type '{0}' was found in the assembly '{1}'. Specify the fully qualified name of the one to use."
	/// </summary>
	internal static string AssemblyMigrator_MultipleConfigurationsWithName(object p0, object p1)
	{
		return EntityRes.GetString("AssemblyMigrator_MultipleConfigurationsWithName", p0, p1);
	}

	/// <summary>
	/// A string like "No migrations configuration type was found in the assembly '{0}'. (In Visual Studio you can use the Enable-Migrations command from Package Manager Console to add a migrations configuration)."
	/// </summary>
	internal static string AssemblyMigrator_NoConfiguration(object p0)
	{
		return EntityRes.GetString("AssemblyMigrator_NoConfiguration", p0);
	}

	/// <summary>
	/// A string like "More than one migrations configuration type was found in the assembly '{0}'. Specify the name of the one to use."
	/// </summary>
	internal static string AssemblyMigrator_MultipleConfigurations(object p0)
	{
		return EntityRes.GetString("AssemblyMigrator_MultipleConfigurations", p0);
	}

	/// <summary>
	/// A string like "The type '{0}' is not a migrations configuration type."
	/// </summary>
	internal static string AssemblyMigrator_NonConfigurationType(object p0)
	{
		return EntityRes.GetString("AssemblyMigrator_NonConfigurationType", p0);
	}

	/// <summary>
	/// A string like "The migrations configuration type '{0}' must have a public default constructor."
	/// </summary>
	internal static string AssemblyMigrator_NoDefaultConstructor(object p0)
	{
		return EntityRes.GetString("AssemblyMigrator_NoDefaultConstructor", p0);
	}

	/// <summary>
	/// A string like "The migrations configuration type '{0}' must not be abstract."
	/// </summary>
	internal static string AssemblyMigrator_AbstractConfigurationType(object p0)
	{
		return EntityRes.GetString("AssemblyMigrator_AbstractConfigurationType", p0);
	}

	/// <summary>
	/// A string like "The migrations configuration type '{0}' must not be generic."
	/// </summary>
	internal static string AssemblyMigrator_GenericConfigurationType(object p0)
	{
		return EntityRes.GetString("AssemblyMigrator_GenericConfigurationType", p0);
	}

	/// <summary>
	/// A string like "In VB.NET projects, the migrations namespace '{0}' must be under the root namespace '{1}'. Update the migrations project's root namespace to allow classes under the migrations namespace to be added."
	/// </summary>
	internal static string MigrationsNamespaceNotUnderRootNamespace(object p0, object p1)
	{
		return EntityRes.GetString("MigrationsNamespaceNotUnderRootNamespace", p0, p1);
	}

	internal static string UnableToDispatchAddOrUpdate(object p0)
	{
		return EntityRes.GetString("UnableToDispatchAddOrUpdate", p0);
	}

	/// <summary>
	/// A string like "The argument '{0}' cannot be null, empty or contain only white space."
	/// </summary>
	internal static string ArgumentIsNullOrWhitespace(object p0)
	{
		return EntityRes.GetString("ArgumentIsNullOrWhitespace", p0);
	}

	/// <summary>
	/// A string like "The argument property '{0}' cannot be null."
	/// </summary>
	internal static string ArgumentPropertyIsNull(object p0)
	{
		return EntityRes.GetString("ArgumentPropertyIsNull", p0);
	}

	/// <summary>
	/// A string like "The precondition '{0}' failed. {1}"
	/// </summary>
	internal static string PreconditionFailed(object p0, object p1)
	{
		return EntityRes.GetString("PreconditionFailed", p0, p1);
	}

	/// <summary>
	/// A string like "The type '{0}' has already been configured as a complex type. It cannot be reconfigured as an entity type."
	/// </summary>
	internal static string EntityTypeConfigurationMismatch(object p0)
	{
		return EntityRes.GetString("EntityTypeConfigurationMismatch", p0);
	}

	/// <summary>
	/// A string like "The type '{0}' has already been configured as an entity type. It cannot be reconfigured as a complex type."
	/// </summary>
	internal static string ComplexTypeConfigurationMismatch(object p0)
	{
		return EntityRes.GetString("ComplexTypeConfigurationMismatch", p0);
	}

	/// <summary>
	/// A string like "The key component '{0}' is not a declared property on type '{1}'. Verify that it has not been explicitly excluded from the model and that it is a valid primitive property."
	/// </summary>
	internal static string KeyPropertyNotFound(object p0, object p1)
	{
		return EntityRes.GetString("KeyPropertyNotFound", p0, p1);
	}

	/// <summary>
	/// A string like "The foreign key component '{0}' is not a declared property on type '{1}'. Verify that it has not been explicitly excluded from the model and that it is a valid primitive property."
	/// </summary>
	internal static string ForeignKeyPropertyNotFound(object p0, object p1)
	{
		return EntityRes.GetString("ForeignKeyPropertyNotFound", p0, p1);
	}

	/// <summary>
	/// A string like "The property '{0}' is not a declared property on type '{1}'. Verify that the property has not been explicitly excluded from the model by using the Ignore method or NotMappedAttribute data annotation. Make sure that it is a valid primitive property."
	/// </summary>
	internal static string PropertyNotFound(object p0, object p1)
	{
		return EntityRes.GetString("PropertyNotFound", p0, p1);
	}

	/// <summary>
	/// A string like "The navigation property '{0}' is not a declared property on type '{1}'. Verify that it has not been explicitly excluded from the model and that it is a valid navigation property."
	/// </summary>
	internal static string NavigationPropertyNotFound(object p0, object p1)
	{
		return EntityRes.GetString("NavigationPropertyNotFound", p0, p1);
	}

	/// <summary>
	/// A string like "The expression '{0}' is not a valid property expression. The expression should represent a property: C#: 't =&gt; t.MyProperty'  VB.Net: 'Function(t) t.MyProperty'."
	/// </summary>
	internal static string InvalidPropertyExpression(object p0)
	{
		return EntityRes.GetString("InvalidPropertyExpression", p0);
	}

	/// <summary>
	/// A string like "The expression '{0}' is not a valid property expression. The expression should represent a property: C#: 't =&gt; t.MyProperty'  VB.Net: 'Function(t) t.MyProperty'. Use dotted paths for nested properties: C#: 't =&gt; t.MyProperty.MyProperty'  VB.Net: 'Function(t) t.MyProperty.MyProperty'."
	/// </summary>
	internal static string InvalidComplexPropertyExpression(object p0)
	{
		return EntityRes.GetString("InvalidComplexPropertyExpression", p0);
	}

	/// <summary>
	/// A string like "The properties expression '{0}' is not valid. The expression should represent a property: C#: 't =&gt; t.MyProperty'  VB.Net: 'Function(t) t.MyProperty'. When specifying multiple properties use an anonymous type: C#: 't =&gt; new {{ t.MyProperty1, t.MyProperty2 }}'  VB.Net: 'Function(t) New From {{ t.MyProperty1, t.MyProperty2 }}'."
	/// </summary>
	internal static string InvalidPropertiesExpression(object p0)
	{
		return EntityRes.GetString("InvalidPropertiesExpression", p0);
	}

	/// <summary>
	/// A string like "The properties expression '{0}' is not valid. The expression should represent a property: C#: 't =&gt; t.MyProperty'  VB.Net: 'Function(t) t.MyProperty'. When specifying multiple properties use an anonymous type: C#: 't =&gt; new {{ t.MyProperty1, t.MyProperty2 }}'  VB.Net: 'Function(t) New From {{ t.MyProperty1, t.MyProperty2 }}'."
	/// </summary>
	internal static string InvalidComplexPropertiesExpression(object p0)
	{
		return EntityRes.GetString("InvalidComplexPropertiesExpression", p0);
	}

	internal static string DuplicateStructuralTypeConfiguration(object p0)
	{
		return EntityRes.GetString("DuplicateStructuralTypeConfiguration", p0);
	}

	/// <summary>
	/// A string like "Conflicting configuration settings were specified for property '{0}' on type '{1}': {2}"
	/// </summary>
	internal static string ConflictingPropertyConfiguration(object p0, object p1, object p2)
	{
		return EntityRes.GetString("ConflictingPropertyConfiguration", p0, p1, p2);
	}

	/// <summary>
	/// A string like "Conflicting configuration settings were specified for column '{0}' on table '{1}': {2}"
	/// </summary>
	internal static string ConflictingColumnConfiguration(object p0, object p1, object p2)
	{
		return EntityRes.GetString("ConflictingColumnConfiguration", p0, p1, p2);
	}

	/// <summary>
	/// A string like "{0} = {1} conflicts with {2} = {3}"
	/// </summary>
	internal static string ConflictingConfigurationValue(object p0, object p1, object p2, object p3)
	{
		return EntityRes.GetString("ConflictingConfigurationValue", p0, p1, p2, p3);
	}

	/// <summary>
	/// A string like "The type '{0}' was not mapped. Check that the type has not been explicitly excluded by using the Ignore method or NotMappedAttribute data annotation. Verify that the type was defined as a class, is not primitive, nested or generic, and does not inherit from ComplexObject."
	/// </summary>
	internal static string InvalidComplexType(object p0)
	{
		return EntityRes.GetString("InvalidComplexType", p0);
	}

	/// <summary>
	/// A string like "The type '{0}' was not mapped. Check that the type has not been explicitly excluded by using the Ignore method or NotMappedAttribute data annotation. Verify that the type was defined as a class, is not primitive, nested or generic, and does not inherit from EntityObject."
	/// </summary>
	internal static string InvalidEntityType(object p0)
	{
		return EntityRes.GetString("InvalidEntityType", p0);
	}

	/// <summary>
	/// A string like "The navigation property '{0}' declared on type '{1}' cannot be the inverse of itself."
	/// </summary>
	internal static string NavigationInverseItself(object p0, object p1)
	{
		return EntityRes.GetString("NavigationInverseItself", p0, p1);
	}

	/// <summary>
	/// A string like "The navigation property '{0}' declared on type '{1}' has been configured with conflicting foreign keys."
	/// </summary>
	internal static string ConflictingConstraint(object p0, object p1)
	{
		return EntityRes.GetString("ConflictingConstraint", p0, p1);
	}

	/// <summary>
	/// A string like "Values of incompatible types ('{1}' and '{2}') were assigned to the '{0}' discriminator column. Values of the same type must be specified. To explicitly specify the type of the discriminator column use the HasColumnType method."
	/// </summary>
	internal static string ConflictingInferredColumnType(object p0, object p1, object p2)
	{
		return EntityRes.GetString("ConflictingInferredColumnType", p0, p1, p2);
	}

	/// <summary>
	/// A string like "The navigation property '{0}' declared on type '{1}' has been configured with conflicting mapping information."
	/// </summary>
	internal static string ConflictingMapping(object p0, object p1)
	{
		return EntityRes.GetString("ConflictingMapping", p0, p1);
	}

	/// <summary>
	/// A string like "The navigation property '{0}' declared on type '{1}' has been configured with conflicting cascade delete operations using 'WillCascadeOnDelete'."
	/// </summary>
	internal static string ConflictingCascadeDeleteOperation(object p0, object p1)
	{
		return EntityRes.GetString("ConflictingCascadeDeleteOperation", p0, p1);
	}

	/// <summary>
	/// A string like "The navigation property '{0}' declared on type '{1}' has been configured with conflicting multiplicities."
	/// </summary>
	internal static string ConflictingMultiplicities(object p0, object p1)
	{
		return EntityRes.GetString("ConflictingMultiplicities", p0, p1);
	}

	/// <summary>
	/// A string like "The MaxLengthAttribute on property '{0}' on type '{1} is not valid. The Length value must be greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length."
	/// </summary>
	internal static string MaxLengthAttributeConvention_InvalidMaxLength(object p0, object p1)
	{
		return EntityRes.GetString("MaxLengthAttributeConvention_InvalidMaxLength", p0, p1);
	}

	/// <summary>
	/// A string like "The StringLengthAttribute on property '{0}' on type '{1}' is not valid. The maximum length must be greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length."
	/// </summary>
	internal static string StringLengthAttributeConvention_InvalidMaximumLength(object p0, object p1)
	{
		return EntityRes.GetString("StringLengthAttributeConvention_InvalidMaximumLength", p0, p1);
	}

	/// <summary>
	/// A string like "Unable to determine composite primary key ordering for type '{0}'. Use the ColumnAttribute or the HasKey method to specify an order for composite primary keys."
	/// </summary>
	internal static string ModelGeneration_UnableToDetermineKeyOrder(object p0)
	{
		return EntityRes.GetString("ModelGeneration_UnableToDetermineKeyOrder", p0);
	}

	/// <summary>
	/// A string like "The ForeignKeyAttribute on property '{0}' on type '{1}' is not valid. Name must not be empty."
	/// </summary>
	internal static string ForeignKeyAttributeConvention_EmptyKey(object p0, object p1)
	{
		return EntityRes.GetString("ForeignKeyAttributeConvention_EmptyKey", p0, p1);
	}

	/// <summary>
	/// A string like "The ForeignKeyAttribute on property '{0}' on type '{1}' is not valid. The foreign key name '{2}' was not found on the dependent type '{3}'. The Name value should be a comma separated list of foreign key property names."
	/// </summary>
	internal static string ForeignKeyAttributeConvention_InvalidKey(object p0, object p1, object p2, object p3)
	{
		return EntityRes.GetString("ForeignKeyAttributeConvention_InvalidKey", p0, p1, p2, p3);
	}

	/// <summary>
	/// A string like "The ForeignKeyAttribute on property '{0}' on type '{1}' is not valid. The navigation property '{2}' was not found on the dependent type '{1}'. The Name value should be a valid navigation property name."
	/// </summary>
	internal static string ForeignKeyAttributeConvention_InvalidNavigationProperty(object p0, object p1, object p2)
	{
		return EntityRes.GetString("ForeignKeyAttributeConvention_InvalidNavigationProperty", p0, p1, p2);
	}

	/// <summary>
	/// A string like "Unable to determine a composite foreign key ordering for foreign key on type {0}. When using the ForeignKey data annotation on composite foreign key properties ensure order is specified by using the Column data annotation or the fluent API."
	/// </summary>
	internal static string ForeignKeyAttributeConvention_OrderRequired(object p0)
	{
		return EntityRes.GetString("ForeignKeyAttributeConvention_OrderRequired", p0);
	}

	/// <summary>
	/// A string like "The InversePropertyAttribute on property '{2}' on type '{3}' is not valid. The property '{0}' is not a valid navigation property on the related type '{1}'. Ensure that the property exists and is a valid reference or collection navigation property."
	/// </summary>
	internal static string InversePropertyAttributeConvention_PropertyNotFound(object p0, object p1, object p2, object p3)
	{
		return EntityRes.GetString("InversePropertyAttributeConvention_PropertyNotFound", p0, p1, p2, p3);
	}

	/// <summary>
	/// A string like "A relationship cannot be established from property '{0}' on type '{1}' to property '{0}' on type '{1}'. Check the values in the InversePropertyAttribute to ensure relationship definitions are unique and reference from one navigation property to its corresponding inverse navigation property."
	/// </summary>
	internal static string InversePropertyAttributeConvention_SelfInverseDetected(object p0, object p1)
	{
		return EntityRes.GetString("InversePropertyAttributeConvention_SelfInverseDetected", p0, p1);
	}

	/// <summary>
	/// A string like "\t{0}: {1}: {2}"
	/// </summary>
	internal static string ValidationItemFormat(object p0, object p1, object p2)
	{
		return EntityRes.GetString("ValidationItemFormat", p0, p1, p2);
	}

	/// <summary>
	/// A string like "A key is registered for the derived type '{0}'. Keys can only be registered for the root type '{1}'."
	/// </summary>
	internal static string KeyRegisteredOnDerivedType(object p0, object p1)
	{
		return EntityRes.GetString("KeyRegisteredOnDerivedType", p0, p1);
	}

	/// <summary>
	/// A string like "The {0} value '{1}' already exists in the user-defined dictionary."
	/// </summary>
	internal static string DuplicateEntryInUserDictionary(object p0, object p1)
	{
		return EntityRes.GetString("DuplicateEntryInUserDictionary", p0, p1);
	}

	/// <summary>
	/// A string like "The type '{0}' has already been mapped to table '{1}'. Specify all mapping aspects of a table in a single Map call."
	/// </summary>
	internal static string InvalidTableMapping(object p0, object p1)
	{
		return EntityRes.GetString("InvalidTableMapping", p0, p1);
	}

	/// <summary>
	/// A string like "Map was called more than once for type '{0}' and at least one of the calls didn't specify the target table name."
	/// </summary>
	internal static string InvalidTableMapping_NoTableName(object p0)
	{
		return EntityRes.GetString("InvalidTableMapping_NoTableName", p0);
	}

	/// <summary>
	/// A string like "The derived type '{0}' has already been mapped using the chaining syntax. A derived type can only be mapped once using the chaining syntax."
	/// </summary>
	internal static string InvalidChainedMappingSyntax(object p0)
	{
		return EntityRes.GetString("InvalidChainedMappingSyntax", p0);
	}

	/// <summary>
	/// A string like "An "is not null" condition cannot be specified on property '{0}' on type '{1}' because this property is not included in the model. Check that the property has not been explicitly excluded from the model by using the Ignore method or NotMappedAttribute data annotation."
	/// </summary>
	internal static string InvalidNotNullCondition(object p0, object p1)
	{
		return EntityRes.GetString("InvalidNotNullCondition", p0, p1);
	}

	/// <summary>
	/// A string like "Values of type '{0}' cannot be used as type discriminator values. Supported types include byte, signed byte, bool, int16, int32, int64, and string."
	/// </summary>
	internal static string InvalidDiscriminatorType(object p0)
	{
		return EntityRes.GetString("InvalidDiscriminatorType", p0);
	}

	/// <summary>
	/// A string like "Unable to add the convention '{0}'. Could not find an existing convention of type '{1}' in the current convention set."
	/// </summary>
	internal static string ConventionNotFound(object p0, object p1)
	{
		return EntityRes.GetString("ConventionNotFound", p0, p1);
	}

	/// <summary>
	/// A string like "Not all properties for type '{0}' have been mapped. Either map those properties or explicitly excluded them from the model."
	/// </summary>
	internal static string InvalidEntitySplittingProperties(object p0)
	{
		return EntityRes.GetString("InvalidEntitySplittingProperties", p0);
	}

	/// <summary>
	/// A string like "Unable to determine the provider name for connection of type '{0}'."
	/// </summary>
	internal static string ModelBuilder_ProviderNameNotFound(object p0)
	{
		return EntityRes.GetString("ModelBuilder_ProviderNameNotFound", p0);
	}

	/// <summary>
	/// A string like "The qualified table name '{0}' contains an invalid schema name. Schema names must have a non-zero length."
	/// </summary>
	internal static string ToTable_InvalidSchemaName(object p0)
	{
		return EntityRes.GetString("ToTable_InvalidSchemaName", p0);
	}

	/// <summary>
	/// A string like "The qualified table name '{0}' contains an invalid table name. Table names must have a non-zero length."
	/// </summary>
	internal static string ToTable_InvalidTableName(object p0)
	{
		return EntityRes.GetString("ToTable_InvalidTableName", p0);
	}

	/// <summary>
	/// A string like "Properties for type '{0}' can only be mapped once. Ensure the MapInheritedProperties method is only used during one call to the Map method."
	/// </summary>
	internal static string EntityMappingConfiguration_DuplicateMapInheritedProperties(object p0)
	{
		return EntityRes.GetString("EntityMappingConfiguration_DuplicateMapInheritedProperties", p0);
	}

	/// <summary>
	/// A string like "Properties for type '{0}' can only be mapped once. Ensure the Properties method is used and that repeated calls specify each non-key property only once."
	/// </summary>
	internal static string EntityMappingConfiguration_DuplicateMappedProperties(object p0)
	{
		return EntityRes.GetString("EntityMappingConfiguration_DuplicateMappedProperties", p0);
	}

	/// <summary>
	/// A string like "Properties for type '{0}' can only be mapped once. The non-key property '{1}' is mapped more than once. Ensure the Properties method specifies each non-key property only once."
	/// </summary>
	internal static string EntityMappingConfiguration_DuplicateMappedProperty(object p0, object p1)
	{
		return EntityRes.GetString("EntityMappingConfiguration_DuplicateMappedProperty", p0, p1);
	}

	/// <summary>
	/// A string like "The property '{1}' on type '{0}' cannot be mapped because it has been explicitly excluded from the model."
	/// </summary>
	internal static string EntityMappingConfiguration_CannotMapIgnoredProperty(object p0, object p1)
	{
		return EntityRes.GetString("EntityMappingConfiguration_CannotMapIgnoredProperty", p0, p1);
	}

	/// <summary>
	/// A string like "The entity types '{0}' and '{1}' cannot share table '{2}' because they are not in the same type hierarchy or do not have a valid one to one foreign key relationship with matching primary keys between them."
	/// </summary>
	internal static string EntityMappingConfiguration_InvalidTableSharing(object p0, object p1, object p2)
	{
		return EntityRes.GetString("EntityMappingConfiguration_InvalidTableSharing", p0, p1, p2);
	}

	/// <summary>
	/// A string like "The property '{0}' cannot be used as a key property on the entity '{1}' because the property type is not a valid key type. Only scalar types, string and byte[] are supported key types."
	/// </summary>
	internal static string ModelBuilder_KeyPropertiesMustBePrimitive(object p0, object p1)
	{
		return EntityRes.GetString("ModelBuilder_KeyPropertiesMustBePrimitive", p0, p1);
	}

	/// <summary>
	/// A string like "The specified table '{0}' was not found in the model. Ensure that the table name has been correctly specified."
	/// </summary>
	internal static string TableNotFound(object p0)
	{
		return EntityRes.GetString("TableNotFound", p0);
	}

	/// <summary>
	/// A string like "The specified association foreign key columns '{0}' are invalid. The number of columns specified must match the number of primary key columns."
	/// </summary>
	internal static string IncorrectColumnCount(object p0)
	{
		return EntityRes.GetString("IncorrectColumnCount", p0);
	}

	/// <summary>
	/// A string like "Unable to determine the principal end of an association between the types '{0}' and '{1}'. The principal end of this association must be explicitly configured using either the relationship fluent API or data annotations."
	/// </summary>
	internal static string UnableToDeterminePrincipal(object p0, object p1)
	{
		return EntityRes.GetString("UnableToDeterminePrincipal", p0, p1);
	}

	/// <summary>
	/// A string like "The abstract type '{0}' has no mapped descendents and so cannot be mapped. Either remove '{0}' from the model or add one or more types deriving from '{0}' to the model. "
	/// </summary>
	internal static string UnmappedAbstractType(object p0)
	{
		return EntityRes.GetString("UnmappedAbstractType", p0);
	}

	/// <summary>
	/// A string like "The type '{0}' cannot be mapped as defined because it maps inherited properties from types that use entity splitting or another form of inheritance. Either choose a different inheritance mapping strategy so as to not map inherited properties, or change all types in the hierarchy to map inherited properties and to not use splitting. "
	/// </summary>
	internal static string UnsupportedHybridInheritanceMapping(object p0)
	{
		return EntityRes.GetString("UnsupportedHybridInheritanceMapping", p0);
	}

	/// <summary>
	/// A string like "Cannot get value for property '{0}' from entity of type '{1}' because the property has no get accessor."
	/// </summary>
	internal static string DbPropertyEntry_CannotGetCurrentValue(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyEntry_CannotGetCurrentValue", p0, p1);
	}

	/// <summary>
	/// A string like "Cannot set value for property '{0}' on entity of type '{1}' because the property has no set accessor."
	/// </summary>
	internal static string DbPropertyEntry_CannotSetCurrentValue(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyEntry_CannotSetCurrentValue", p0, p1);
	}

	internal static string DbPropertyEntry_NotSupportedForDetached(object p0, object p1, object p2)
	{
		return EntityRes.GetString("DbPropertyEntry_NotSupportedForDetached", p0, p1, p2);
	}

	/// <summary>
	/// A string like "Cannot set value for property '{0}' on entity of type '{1}' because the property has no set accessor and is in the '{2}' state."
	/// </summary>
	internal static string DbPropertyEntry_SettingEntityRefNotSupported(object p0, object p1, object p2)
	{
		return EntityRes.GetString("DbPropertyEntry_SettingEntityRefNotSupported", p0, p1, p2);
	}

	/// <summary>
	/// A string like "Member '{0}' cannot be called for property '{1}' on entity of type '{2}' because the property is not part of the Entity Data Model."
	/// </summary>
	internal static string DbPropertyEntry_NotSupportedForPropertiesNotInTheModel(object p0, object p1, object p2)
	{
		return EntityRes.GetString("DbPropertyEntry_NotSupportedForPropertiesNotInTheModel", p0, p1, p2);
	}

	internal static string DbEntityEntry_NotSupportedForDetached(object p0, object p1)
	{
		return EntityRes.GetString("DbEntityEntry_NotSupportedForDetached", p0, p1);
	}

	/// <summary>
	/// A string like "Cannot call the {0} method for an entity of type '{1}' on a DbSet for entities of type '{2}'. Only entities of type '{2}' or derived from type '{2}' can be added, attached, or removed."
	/// </summary>
	internal static string DbSet_BadTypeForAddAttachRemove(object p0, object p1, object p2)
	{
		return EntityRes.GetString("DbSet_BadTypeForAddAttachRemove", p0, p1, p2);
	}

	/// <summary>
	/// A string like "Cannot call the Create method for the type '{0}' on a DbSet for entities of type '{1}'. Only entities of type '{1}' or derived from type '{1}' can be created."
	/// </summary>
	internal static string DbSet_BadTypeForCreate(object p0, object p1)
	{
		return EntityRes.GetString("DbSet_BadTypeForCreate", p0, p1);
	}

	internal static string DbEntity_BadTypeForCast(object p0, object p1, object p2)
	{
		return EntityRes.GetString("DbEntity_BadTypeForCast", p0, p1, p2);
	}

	internal static string DbMember_BadTypeForCast(object p0, object p1, object p2, object p3, object p4)
	{
		return EntityRes.GetString("DbMember_BadTypeForCast", p0, p1, p2, p3, p4);
	}

	/// <summary>
	/// A string like "The property '{0}' on type '{1}' is a collection navigation property. The Collection method should be used instead of the Reference method."
	/// </summary>
	internal static string DbEntityEntry_UsedReferenceForCollectionProp(object p0, object p1)
	{
		return EntityRes.GetString("DbEntityEntry_UsedReferenceForCollectionProp", p0, p1);
	}

	/// <summary>
	/// A string like "The property '{0}' on type '{1}' is a reference navigation property. The Reference method should be used instead of the Collection method."
	/// </summary>
	internal static string DbEntityEntry_UsedCollectionForReferenceProp(object p0, object p1)
	{
		return EntityRes.GetString("DbEntityEntry_UsedCollectionForReferenceProp", p0, p1);
	}

	/// <summary>
	/// A string like "The property '{0}' on type '{1}' is not a navigation property. The Reference and Collection methods can only be used with navigation properties. Use the Property or ComplexProperty method."
	/// </summary>
	internal static string DbEntityEntry_NotANavigationProperty(object p0, object p1)
	{
		return EntityRes.GetString("DbEntityEntry_NotANavigationProperty", p0, p1);
	}

	/// <summary>
	/// A string like "The property '{0}' on type '{1}' is not a primitive or complex property. The Property method can only be used with primitive or complex properties. Use the Reference or Collection method."
	/// </summary>
	internal static string DbEntityEntry_NotAScalarProperty(object p0, object p1)
	{
		return EntityRes.GetString("DbEntityEntry_NotAScalarProperty", p0, p1);
	}

	/// <summary>
	/// A string like "The property '{0}' on type '{1}' is not a complex property. The ComplexProperty method can only be used with complex properties. Use the Property, Reference or Collection method."
	/// </summary>
	internal static string DbEntityEntry_NotAComplexProperty(object p0, object p1)
	{
		return EntityRes.GetString("DbEntityEntry_NotAComplexProperty", p0, p1);
	}

	/// <summary>
	/// A string like "The property '{0}' on type '{1}' is not a primitive property, complex property, collection navigation property, or reference navigation property."
	/// </summary>
	internal static string DbEntityEntry_NotAProperty(object p0, object p1)
	{
		return EntityRes.GetString("DbEntityEntry_NotAProperty", p0, p1);
	}

	/// <summary>
	/// A string like ""The property '{0}' from the property path '{1}' is not a complex property on type '{2}'. Property paths must be composed of complex properties for all except the final property.""
	/// </summary>
	internal static string DbEntityEntry_DottedPartNotComplex(object p0, object p1, object p2)
	{
		return EntityRes.GetString("DbEntityEntry_DottedPartNotComplex", p0, p1, p2);
	}

	/// <summary>
	/// A string like ""The property path '{0}' cannot be used for navigation properties. Property paths can only be used to access primitive or complex properties.""
	/// </summary>
	internal static string DbEntityEntry_DottedPathMustBeProperty(object p0)
	{
		return EntityRes.GetString("DbEntityEntry_DottedPathMustBeProperty", p0);
	}

	/// <summary>
	/// A string like "The navigation property '{0}' on entity type '{1}' cannot be used for entities of type '{2}' because it refers to entities of type '{3}'."
	/// </summary>
	internal static string DbEntityEntry_WrongGenericForNavProp(object p0, object p1, object p2, object p3)
	{
		return EntityRes.GetString("DbEntityEntry_WrongGenericForNavProp", p0, p1, p2, p3);
	}

	/// <summary>
	/// A string like "The generic type argument '{0}' cannot be used with the Member method when accessing the collection navigation property '{1}' on entity type '{2}'. The generic type argument '{3}' must be used instead."
	/// </summary>
	internal static string DbEntityEntry_WrongGenericForCollectionNavProp(object p0, object p1, object p2, object p3)
	{
		return EntityRes.GetString("DbEntityEntry_WrongGenericForCollectionNavProp", p0, p1, p2, p3);
	}

	/// <summary>
	/// A string like "The property '{0}' on entity type '{1}' cannot be used for objects of type '{2}' because it is a property for objects of type '{3}'."
	/// </summary>
	internal static string DbEntityEntry_WrongGenericForProp(object p0, object p1, object p2, object p3)
	{
		return EntityRes.GetString("DbEntityEntry_WrongGenericForProp", p0, p1, p2, p3);
	}

	/// <summary>
	/// A string like "The expression passed to method {0} must represent a property defined on the type '{1}'."
	/// </summary>
	internal static string DbEntityEntry_BadPropertyExpression(object p0, object p1)
	{
		return EntityRes.GetString("DbEntityEntry_BadPropertyExpression", p0, p1);
	}

	/// <summary>
	/// A string like "{0} cannot be used for entities in the {1} state."
	/// </summary>
	internal static string DbPropertyValues_CannotGetValuesForState(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyValues_CannotGetValuesForState", p0, p1);
	}

	/// <summary>
	/// A string like "Cannot set non-nullable property '{0}' of type '{1}' to null on object of type '{2}'."
	/// </summary>
	internal static string DbPropertyValues_CannotSetNullValue(object p0, object p1, object p2)
	{
		return EntityRes.GetString("DbPropertyValues_CannotSetNullValue", p0, p1, p2);
	}

	/// <summary>
	/// A string like "The property '{0}' in the entity of type '{1}' is null. Store values cannot be obtained for an entity with a null complex property."
	/// </summary>
	internal static string DbPropertyValues_CannotGetStoreValuesWhenComplexPropertyIsNull(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyValues_CannotGetStoreValuesWhenComplexPropertyIsNull", p0, p1);
	}

	/// <summary>
	/// A string like "Cannot assign value of type '{0}' to property '{1}' of type '{2}' in property values for type '{3}'."
	/// </summary>
	internal static string DbPropertyValues_WrongTypeForAssignment(object p0, object p1, object p2, object p3)
	{
		return EntityRes.GetString("DbPropertyValues_WrongTypeForAssignment", p0, p1, p2, p3);
	}

	/// <summary>
	/// A string like "The '{0}' property does not exist or is not mapped for the type '{1}'."
	/// </summary>
	internal static string DbPropertyValues_PropertyDoesNotExist(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyValues_PropertyDoesNotExist", p0, p1);
	}

	/// <summary>
	/// A string like "Cannot copy values from DbPropertyValues for type '{0}' into DbPropertyValues for type '{1}'."
	/// </summary>
	internal static string DbPropertyValues_AttemptToSetValuesFromWrongObject(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyValues_AttemptToSetValuesFromWrongObject", p0, p1);
	}

	/// <summary>
	/// A string like "Cannot copy from property values for object of type '{0}' into property values for object of type '{1}'."
	/// </summary>
	internal static string DbPropertyValues_AttemptToSetValuesFromWrongType(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyValues_AttemptToSetValuesFromWrongType", p0, p1);
	}

	/// <summary>
	/// A string like "The value of the complex property '{0}' on entity of type '{1}' is null. Complex properties cannot be set to null and values cannot be set for null complex properties."
	/// </summary>
	internal static string DbPropertyValues_ComplexObjectCannotBeNull(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyValues_ComplexObjectCannotBeNull", p0, p1);
	}

	/// <summary>
	/// A string like "The value of the nested property values property '{0}' on the values for entity of type '{1}' is null. Nested property values cannot be set to null and values cannot be set for null complex properties."
	/// </summary>
	internal static string DbPropertyValues_NestedPropertyValuesNull(object p0, object p1)
	{
		return EntityRes.GetString("DbPropertyValues_NestedPropertyValuesNull", p0, p1);
	}

	/// <summary>
	/// A string like "The model backing the '{0}' context has changed since the database was created. Consider using Code First Migrations to update the database (http://go.microsoft.com/fwlink/?LinkId=238269)."
	/// </summary>
	internal static string DatabaseInitializationStrategy_ModelMismatch(object p0)
	{
		return EntityRes.GetString("DatabaseInitializationStrategy_ModelMismatch", p0);
	}

	/// <summary>
	/// A string like "Database '{0}' cannot be created because it already exists."
	/// </summary>
	internal static string Database_DatabaseAlreadyExists(object p0)
	{
		return EntityRes.GetString("Database_DatabaseAlreadyExists", p0);
	}

	internal static string Database_BadLegacyInitializerEntry(object p0, object p1)
	{
		return EntityRes.GetString("Database_BadLegacyInitializerEntry", p0, p1);
	}

	internal static string Database_InitializeFromLegacyConfigFailed(object p0, object p1)
	{
		return EntityRes.GetString("Database_InitializeFromLegacyConfigFailed", p0, p1);
	}

	/// <summary>
	/// A string like "Failed to set database initializer of type '{0}' for DbContext type '{1}' specified in the application configuration. See inner exception for details."
	/// </summary>
	internal static string Database_InitializeFromConfigFailed(object p0, object p1)
	{
		return EntityRes.GetString("Database_InitializeFromConfigFailed", p0, p1);
	}

	/// <summary>
	/// A string like "Configuration for DbContext type '{0}' is specified multiple times in the application configuration. Each context can only be configured once."
	/// </summary>
	internal static string ContextConfiguredMultipleTimes(object p0)
	{
		return EntityRes.GetString("ContextConfiguredMultipleTimes", p0);
	}

	/// <summary>
	/// A string like "Failed to set Database.DefaultConnectionFactory to an instance of the '{0}' type as specified in the application configuration. See inner exception for details."
	/// </summary>
	internal static string SetConnectionFactoryFromConfigFailed(object p0)
	{
		return EntityRes.GetString("SetConnectionFactoryFromConfigFailed", p0);
	}

	/// <summary>
	/// A string like "The type '{0}' could not be found. The type name must be an assembly-qualified name."
	/// </summary>
	internal static string Database_FailedToResolveType(object p0)
	{
		return EntityRes.GetString("Database_FailedToResolveType", p0);
	}

	/// <summary>
	/// A string like "The connection string '{0}' in the application's configuration file does not contain the required providerName attribute.""
	/// </summary>
	internal static string DbContext_ProviderNameMissing(object p0)
	{
		return EntityRes.GetString("DbContext_ProviderNameMissing", p0);
	}

	/// <summary>
	/// A string like "The entity found was of type {0} when an entity of type {1} was requested."
	/// </summary>
	internal static string DbSet_WrongEntityTypeFound(object p0, object p1)
	{
		return EntityRes.GetString("DbSet_WrongEntityTypeFound", p0, p1);
	}

	/// <summary>
	/// A string like "The type '{0}' is mapped as a complex type. The Set method, DbSet objects, and DbEntityEntry objects can only be used with entity types, not complex types."
	/// </summary>
	internal static string DbSet_DbSetUsedWithComplexType(object p0)
	{
		return EntityRes.GetString("DbSet_DbSetUsedWithComplexType", p0);
	}

	/// <summary>
	/// A string like "The type '{0}' is not attributed with EdmEntityTypeAttribute but is contained in an assembly attributed with EdmSchemaAttribute. POCO entities that do not use EdmEntityTypeAttribute cannot be contained in the same assembly as non-POCO entities that use EdmEntityTypeAttribute."
	/// </summary>
	internal static string DbSet_PocoAndNonPocoMixedInSameAssembly(object p0)
	{
		return EntityRes.GetString("DbSet_PocoAndNonPocoMixedInSameAssembly", p0);
	}

	/// <summary>
	/// A string like "The entity type {0} is not part of the model for the current context."
	/// </summary>
	internal static string DbSet_EntityTypeNotInModel(object p0)
	{
		return EntityRes.GetString("DbSet_EntityTypeNotInModel", p0);
	}

	/// <summary>
	/// A string like "No connection string named '{0}' could be found in the application config file."
	/// </summary>
	internal static string DbContext_ConnectionStringNotFound(object p0)
	{
		return EntityRes.GetString("DbContext_ConnectionStringNotFound", p0);
	}

	/// <summary>
	/// A string like "The collection navigation property '{0}' on the entity of type '{1}' cannot be set because the entity type does not define a navigation property with a set accessor."
	/// </summary>
	internal static string DbCollectionEntry_CannotSetCollectionProp(object p0, object p1)
	{
		return EntityRes.GetString("DbCollectionEntry_CannotSetCollectionProp", p0, p1);
	}

	/// <summary>
	/// A string like "Multiple object sets per type are not supported. The object sets '{0}' and '{1}' can both contain instances of type '{2}'."
	/// </summary>
	internal static string Mapping_MESTNotSupported(object p0, object p1, object p2)
	{
		return EntityRes.GetString("Mapping_MESTNotSupported", p0, p1, p2);
	}

	/// <summary>
	/// A string like "The context type '{0}' must have a public constructor taking an EntityConnection."
	/// </summary>
	internal static string DbModelBuilder_MissingRequiredCtor(object p0)
	{
		return EntityRes.GetString("DbModelBuilder_MissingRequiredCtor", p0);
	}

	/// <summary>
	/// A string like "An unexpected exception was thrown during validation of '{0}' when invoking {1}.IsValid. See the inner exception for details."
	/// </summary>
	internal static string DbUnexpectedValidationException_ValidationAttribute(object p0, object p1)
	{
		return EntityRes.GetString("DbUnexpectedValidationException_ValidationAttribute", p0, p1);
	}

	/// <summary>
	/// A string like "An unexpected exception was thrown during validation of '{0}' when invoking {1}.Validate. See the inner exception for details."
	/// </summary>
	internal static string DbUnexpectedValidationException_IValidatableObject(object p0, object p1)
	{
		return EntityRes.GetString("DbUnexpectedValidationException_IValidatableObject", p0, p1);
	}

	/// <summary>
	/// A string like "The database name '{0}' is not supported because it is an MDF file name. A full connection string must be provided to attach an MDF file."
	/// </summary>
	internal static string SqlConnectionFactory_MdfNotSupported(object p0)
	{
		return EntityRes.GetString("SqlConnectionFactory_MdfNotSupported", p0);
	}

	/// <summary>
	/// A string like "The context factory type '{0}' must have a public default constructor."
	/// </summary>
	internal static string DbContextServices_MissingDefaultCtor(object p0)
	{
		return EntityRes.GetString("DbContextServices_MissingDefaultCtor", p0);
	}

	/// <summary>
	/// A string like "The '{0}' property of EdmPrimitiveType is fixed and cannot be set."
	/// </summary>
	internal static string EdmPrimitiveType_SetPropertyNotSupported(object p0)
	{
		return EntityRes.GetString("EdmPrimitiveType_SetPropertyNotSupported", p0);
	}

	/// <summary>
	/// A string like "The namespace '{0}' is a system namespace and cannot be used by other schemas. Choose another namespace name."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_SystemNamespaceEncountered(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_SystemNamespaceEncountered", p0);
	}

	/// <summary>
	/// A string like "Role '{0}' in AssociationSets '{1}' and '{2}' refers to the same EntitySet '{3}' in EntityContainer '{4}'. Make sure that if two or more AssociationSets refer to the same AssociationType, the ends do not refer to the same EntitySet."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_SimilarRelationshipEnd(object p0, object p1, object p2, object p3, object p4)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_SimilarRelationshipEnd", p0, p1, p2, p3, p4);
	}

	/// <summary>
	/// A string like "The referenced EntitySet '{0}' for End '{1}' could not be found in the containing EntityContainer."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidEntitySetNameReference(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidEntitySetNameReference", p0, p1);
	}

	/// <summary>
	/// A string like "Type '{0}' is derived from type '{1}' that is the type for EntitySet '{2}'. Type '{0}' defines new concurrency requirements that are not allowed for subtypes of base EntitySet types."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_ConcurrencyRedefinedOnSubTypeOfEntitySetType(object p0, object p1, object p2)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_ConcurrencyRedefinedOnSubTypeOfEntitySetType", p0, p1, p2);
	}

	/// <summary>
	/// A string like "EntitySet '{0}' is based on type '{1}' that has no keys defined."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_EntitySetTypeHasNoKeys(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_EntitySetTypeHasNoKeys", p0, p1);
	}

	/// <summary>
	/// A string like "The end name  '{0}' is already defined."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_DuplicateEndName(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_DuplicateEndName", p0);
	}

	/// <summary>
	/// A string like "The key specified in EntityType '{0}' is not valid. Property '{1}' is referenced more than once in the Key element."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_DuplicatePropertyNameSpecifiedInEntityKey(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_DuplicatePropertyNameSpecifiedInEntityKey", p0, p1);
	}

	/// <summary>
	/// A string like "Property '{0}' has a CollectionKind specified but is not a collection property."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidCollectionKindNotCollection(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidCollectionKindNotCollection", p0);
	}

	/// <summary>
	/// A string like "Property '{0}' has a CollectionKind specified. CollectionKind is only supported in version 1.1 EDM models."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidCollectionKindNotV1_1(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidCollectionKindNotV1_1", p0);
	}

	/// <summary>
	/// A string like "ComplexType '{0}' is marked as abstract. Abstract ComplexTypes are only supported in version 1.1 EDM models."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidComplexTypeAbstract(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidComplexTypeAbstract", p0);
	}

	/// <summary>
	/// A string like "ComplexType '{0}' has a BaseType specified. ComplexType inheritance is only supported in version 1.1 EDM models."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidComplexTypePolymorphic(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidComplexTypePolymorphic", p0);
	}

	/// <summary>
	/// A string like "Key part '{0}' for type '{1}' is not valid. All parts of the key must be non-nullable."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidKeyNullablePart(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidKeyNullablePart", p0, p1);
	}

	/// <summary>
	/// A string like "The property '{0}' in EntityType '{1}' is not valid. All properties that are part of the EntityKey must be of PrimitiveType."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_EntityKeyMustBeScalar(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_EntityKeyMustBeScalar", p0, p1);
	}

	/// <summary>
	/// A string like "Key usage is not valid. The {0} class  cannot define keys because one of its base classes ('{1}') defines keys."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidKeyKeyDefinedInBaseClass(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidKeyKeyDefinedInBaseClass", p0, p1);
	}

	/// <summary>
	/// A string like "EntityType '{0}' has no key defined. Define the key for this EntityType."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_KeyMissingOnEntityType(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_KeyMissingOnEntityType", p0);
	}

	/// <summary>
	/// A string like "NavigationProperty is not valid. Role '{0}' or Role '{1}' is not defined in Relationship '{2}'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_BadNavigationPropertyUndefinedRole(object p0, object p1, object p2)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_BadNavigationPropertyUndefinedRole", p0, p1, p2);
	}

	/// <summary>
	/// A string like "End '{0}' on relationship '{1}' cannot have an operation specified because its multiplicity is '*'. Operations cannot be specified on ends with multiplicity '*'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_EndWithManyMultiplicityCannotHaveOperationsSpecified(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_EndWithManyMultiplicityCannotHaveOperationsSpecified", p0, p1);
	}

	/// <summary>
	/// A string like "Each Name and PluralName in a relationship must be unique. '{0}' is already defined."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_EndNameAlreadyDefinedDuplicate(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_EndNameAlreadyDefinedDuplicate", p0);
	}

	/// <summary>
	/// A string like "In relationship '{0}', the Principal and Dependent Role of the referential constraint refer to the same Role in the relationship type."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_SameRoleReferredInReferentialConstraint(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_SameRoleReferredInReferentialConstraint", p0);
	}

	/// <summary>
	/// A string like "Multiplicity is not valid in Role '{0}' in relationship '{1}'. Valid values for multiplicity for the Principal Role are '0..1' or '1'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleUpperBoundMustBeOne(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleUpperBoundMustBeOne", p0, p1);
	}

	/// <summary>
	/// A string like "Multiplicity is not valid in Role '{0}' in relationship '{1}'. Because all the properties in the Dependent Role are nullable, multiplicity of the Principal Role must be '0..1'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNullableV1(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNullableV1", p0, p1);
	}

	/// <summary>
	/// A string like "Multiplicity conflicts with the referential constraint in Role '{0}' in relationship '{1}'. Because at least one  of the properties in the Dependent Role is non-nullable, multiplicity of the Principal Role must be '1'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV1(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV1", p0, p1);
	}

	/// <summary>
	/// A string like "Multiplicity conflicts with the referential constraint in Role '{0}' in relationship '{1}'. Because all of the properties in the Dependent Role are non-nullable, multiplicity of the Principal Role must be '1'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV2(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV2", p0, p1);
	}

	/// <summary>
	/// A string like "Properties referred by the Dependent Role '{0}' must be a subset of the key of the EntityType '{1}' referred to by the Dependent Role in the referential constraint for relationship '{2}'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidToPropertyInRelationshipConstraint(object p0, object p1, object p2)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidToPropertyInRelationshipConstraint", p0, p1, p2);
	}

	/// <summary>
	/// A string like "Multiplicity is not valid in Role '{0}' in relationship '{1}'. Because the Dependent Role refers to the key properties, the upper bound of the multiplicity of the Dependent Role must be '1'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeOne(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeOne", p0, p1);
	}

	/// <summary>
	/// A string like "Multiplicity is not valid in Role '{0}' in relationship '{1}'. Because the Dependent Role properties are not the key properties, the upper bound of the multiplicity of the Dependent Role must be '*'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeMany(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeMany", p0, p1);
	}

	/// <summary>
	/// A string like "The types of all properties in the Dependent Role of a referential constraint must be the same as the corresponding property types in the Principal Role. The type of property '{0}' on entity '{1}' does not match the type of property '{2}' on entity '{3}' in the referential constraint '{4}'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_TypeMismatchRelationshipConstraint(object p0, object p1, object p2, object p3, object p4)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_TypeMismatchRelationshipConstraint", p0, p1, p2, p3, p4);
	}

	/// <summary>
	/// A string like "There is no property with name '{0}' defined in the type referred to by Role '{1}'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidPropertyInRelationshipConstraint(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidPropertyInRelationshipConstraint", p0, p1);
	}

	/// <summary>
	/// A string like "A nullable ComplexType is not supported. Property '{0}' must not allow nulls."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_NullableComplexType(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_NullableComplexType", p0);
	}

	/// <summary>
	/// A string like "A property cannot be of type '{0}'. The property type must be a ComplexType or a PrimitiveType."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidPropertyType(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidPropertyType", p0);
	}

	/// <summary>
	/// A string like "Each member name in an EntityContainer must be unique. A member with name '{0}' is already defined."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_DuplicateEntityContainerMemberName(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_DuplicateEntityContainerMemberName", p0);
	}

	/// <summary>
	/// A string like "Each type name in a schema must be unique. Type name '{0}' is already defined."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_TypeNameAlreadyDefinedDuplicate(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_TypeNameAlreadyDefinedDuplicate", p0);
	}

	/// <summary>
	/// A string like "Name '{0}' cannot be used in type '{1}'. Member names cannot be the same as their enclosing type."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidMemberNameMatchesTypeName(object p0, object p1)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidMemberNameMatchesTypeName", p0, p1);
	}

	/// <summary>
	/// A string like "Each property name in a type must be unique. Property name '{0}' is already defined."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_PropertyNameAlreadyDefinedDuplicate(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_PropertyNameAlreadyDefinedDuplicate", p0);
	}

	/// <summary>
	/// A string like "A cycle was detected in the type hierarchy of '{0}'."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_CycleInTypeHierarchy(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_CycleInTypeHierarchy", p0);
	}

	/// <summary>
	/// A string like "A property cannot be of type '{0}'. The property type must be a ComplexType, a PrimitiveType, or a CollectionType."
	/// </summary>
	internal static string EdmModel_Validator_Semantic_InvalidPropertyType_V1_1(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Semantic_InvalidPropertyType_V1_1", p0);
	}

	/// <summary>
	/// A string like "The specified name must not be longer than 480 characters: '{0}'."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmModel_NameIsTooLong(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Syntactic_EdmModel_NameIsTooLong", p0);
	}

	/// <summary>
	/// A string like "The specified name is not allowed: '{0}'."
	/// </summary>
	internal static string EdmModel_Validator_Syntactic_EdmModel_NameIsNotAllowed(object p0)
	{
		return EntityRes.GetString("EdmModel_Validator_Syntactic_EdmModel_NameIsNotAllowed", p0);
	}

	/// <summary>
	/// A string like "The field {0} must be a string or array type with a maximum length of '{1}'."
	/// </summary>
	internal static string MaxLengthAttribute_ValidationError(object p0, object p1)
	{
		return EntityRes.GetString("MaxLengthAttribute_ValidationError", p0, p1);
	}

	/// <summary>
	/// A string like "The field {0} must be a string or array type with a minimum length of '{1}'."
	/// </summary>
	internal static string MinLengthAttribute_ValidationError(object p0, object p1)
	{
		return EntityRes.GetString("MinLengthAttribute_ValidationError", p0, p1);
	}

	/// <summary>
	/// A string like "No connection string named '{0}' could be found in the application config file."
	/// </summary>
	internal static string DbConnectionInfo_ConnectionStringNotFound(object p0)
	{
		return EntityRes.GetString("DbConnectionInfo_ConnectionStringNotFound", p0);
	}
}
