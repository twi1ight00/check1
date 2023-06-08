using System.CodeDom.Compiler;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace System.Data.Entity.Resources;

/// <summary>
///    AutoGenerated resource class. Usage:
///
///        string s = EntityRes.GetString(EntityRes.MyIdenfitier);
/// </summary>
[GeneratedCode("Resources.tt", "1.0.0.0")]
internal sealed class EntityRes
{
	internal const string AutomaticMigration = "AutomaticMigration";

	internal const string BootstrapMigration = "BootstrapMigration";

	internal const string InitialCreate = "InitialCreate";

	internal const string AutomaticDataLoss = "AutomaticDataLoss";

	internal const string LoggingAutoMigrate = "LoggingAutoMigrate";

	internal const string LoggingRevertAutoMigrate = "LoggingRevertAutoMigrate";

	internal const string LoggingApplyMigration = "LoggingApplyMigration";

	internal const string LoggingRevertMigration = "LoggingRevertMigration";

	internal const string LoggingHistoryInsert = "LoggingHistoryInsert";

	internal const string LoggingHistoryDelete = "LoggingHistoryDelete";

	internal const string LoggingMetadataUpdate = "LoggingMetadataUpdate";

	internal const string LoggingSeedingDatabase = "LoggingSeedingDatabase";

	internal const string LoggingPendingMigrations = "LoggingPendingMigrations";

	internal const string LoggingPendingMigrationsDown = "LoggingPendingMigrationsDown";

	internal const string LoggingNoExplicitMigrations = "LoggingNoExplicitMigrations";

	internal const string LoggingAlreadyAtTarget = "LoggingAlreadyAtTarget";

	internal const string LoggingTargetDatabase = "LoggingTargetDatabase";

	internal const string LoggingTargetDatabaseFormat = "LoggingTargetDatabaseFormat";

	internal const string LoggingExplicit = "LoggingExplicit";

	internal const string UpgradingHistoryTable = "UpgradingHistoryTable";

	internal const string MetadataOutOfDate = "MetadataOutOfDate";

	internal const string MigrationNotFound = "MigrationNotFound";

	internal const string PartialFkOperation = "PartialFkOperation";

	internal const string AutoNotValidTarget = "AutoNotValidTarget";

	internal const string AutoNotValidForScriptWindows = "AutoNotValidForScriptWindows";

	internal const string ContextNotConstructible = "ContextNotConstructible";

	internal const string AmbiguousMigrationName = "AmbiguousMigrationName";

	internal const string AutomaticDisabledException = "AutomaticDisabledException";

	internal const string DownScriptWindowsNotSupported = "DownScriptWindowsNotSupported";

	internal const string AssemblyMigrator_NoConfigurationWithName = "AssemblyMigrator_NoConfigurationWithName";

	internal const string AssemblyMigrator_MultipleConfigurationsWithName = "AssemblyMigrator_MultipleConfigurationsWithName";

	internal const string AssemblyMigrator_NoConfiguration = "AssemblyMigrator_NoConfiguration";

	internal const string AssemblyMigrator_MultipleConfigurations = "AssemblyMigrator_MultipleConfigurations";

	internal const string AssemblyMigrator_NonConfigurationType = "AssemblyMigrator_NonConfigurationType";

	internal const string AssemblyMigrator_NoDefaultConstructor = "AssemblyMigrator_NoDefaultConstructor";

	internal const string AssemblyMigrator_AbstractConfigurationType = "AssemblyMigrator_AbstractConfigurationType";

	internal const string AssemblyMigrator_GenericConfigurationType = "AssemblyMigrator_GenericConfigurationType";

	internal const string SqlCeColumnRenameNotSupported = "SqlCeColumnRenameNotSupported";

	internal const string MigrationsNamespaceNotUnderRootNamespace = "MigrationsNamespaceNotUnderRootNamespace";

	internal const string UnableToDispatchAddOrUpdate = "UnableToDispatchAddOrUpdate";

	internal const string ArgumentIsNullOrWhitespace = "ArgumentIsNullOrWhitespace";

	internal const string ArgumentPropertyIsNull = "ArgumentPropertyIsNull";

	internal const string PreconditionFailed = "PreconditionFailed";

	internal const string EntityTypeConfigurationMismatch = "EntityTypeConfigurationMismatch";

	internal const string ComplexTypeConfigurationMismatch = "ComplexTypeConfigurationMismatch";

	internal const string KeyPropertyNotFound = "KeyPropertyNotFound";

	internal const string ForeignKeyPropertyNotFound = "ForeignKeyPropertyNotFound";

	internal const string PropertyNotFound = "PropertyNotFound";

	internal const string NavigationPropertyNotFound = "NavigationPropertyNotFound";

	internal const string InvalidPropertyExpression = "InvalidPropertyExpression";

	internal const string InvalidComplexPropertyExpression = "InvalidComplexPropertyExpression";

	internal const string InvalidPropertiesExpression = "InvalidPropertiesExpression";

	internal const string InvalidComplexPropertiesExpression = "InvalidComplexPropertiesExpression";

	internal const string DuplicateStructuralTypeConfiguration = "DuplicateStructuralTypeConfiguration";

	internal const string ConflictingPropertyConfiguration = "ConflictingPropertyConfiguration";

	internal const string ConflictingColumnConfiguration = "ConflictingColumnConfiguration";

	internal const string ConflictingConfigurationValue = "ConflictingConfigurationValue";

	internal const string InvalidComplexType = "InvalidComplexType";

	internal const string InvalidEntityType = "InvalidEntityType";

	internal const string NavigationInverseItself = "NavigationInverseItself";

	internal const string ConflictingConstraint = "ConflictingConstraint";

	internal const string ConflictingInferredColumnType = "ConflictingInferredColumnType";

	internal const string ConflictingMapping = "ConflictingMapping";

	internal const string ConflictingCascadeDeleteOperation = "ConflictingCascadeDeleteOperation";

	internal const string ConflictingMultiplicities = "ConflictingMultiplicities";

	internal const string MaxLengthAttributeConvention_InvalidMaxLength = "MaxLengthAttributeConvention_InvalidMaxLength";

	internal const string StringLengthAttributeConvention_InvalidMaximumLength = "StringLengthAttributeConvention_InvalidMaximumLength";

	internal const string ModelGeneration_UnableToDetermineKeyOrder = "ModelGeneration_UnableToDetermineKeyOrder";

	internal const string ForeignKeyAttributeConvention_EmptyKey = "ForeignKeyAttributeConvention_EmptyKey";

	internal const string ForeignKeyAttributeConvention_InvalidKey = "ForeignKeyAttributeConvention_InvalidKey";

	internal const string ForeignKeyAttributeConvention_InvalidNavigationProperty = "ForeignKeyAttributeConvention_InvalidNavigationProperty";

	internal const string ForeignKeyAttributeConvention_OrderRequired = "ForeignKeyAttributeConvention_OrderRequired";

	internal const string InversePropertyAttributeConvention_PropertyNotFound = "InversePropertyAttributeConvention_PropertyNotFound";

	internal const string InversePropertyAttributeConvention_SelfInverseDetected = "InversePropertyAttributeConvention_SelfInverseDetected";

	internal const string ValidationHeader = "ValidationHeader";

	internal const string ValidationItemFormat = "ValidationItemFormat";

	internal const string KeyRegisteredOnDerivedType = "KeyRegisteredOnDerivedType";

	internal const string DuplicateEntryInUserDictionary = "DuplicateEntryInUserDictionary";

	internal const string InvalidTableMapping = "InvalidTableMapping";

	internal const string InvalidTableMapping_NoTableName = "InvalidTableMapping_NoTableName";

	internal const string InvalidChainedMappingSyntax = "InvalidChainedMappingSyntax";

	internal const string InvalidNotNullCondition = "InvalidNotNullCondition";

	internal const string InvalidDiscriminatorType = "InvalidDiscriminatorType";

	internal const string ConventionNotFound = "ConventionNotFound";

	internal const string InvalidEntitySplittingProperties = "InvalidEntitySplittingProperties";

	internal const string ModelBuilder_ProviderNameNotFound = "ModelBuilder_ProviderNameNotFound";

	internal const string ToTable_InvalidSchemaName = "ToTable_InvalidSchemaName";

	internal const string ToTable_InvalidTableName = "ToTable_InvalidTableName";

	internal const string EntityMappingConfiguration_DuplicateMapInheritedProperties = "EntityMappingConfiguration_DuplicateMapInheritedProperties";

	internal const string EntityMappingConfiguration_DuplicateMappedProperties = "EntityMappingConfiguration_DuplicateMappedProperties";

	internal const string EntityMappingConfiguration_DuplicateMappedProperty = "EntityMappingConfiguration_DuplicateMappedProperty";

	internal const string EntityMappingConfiguration_CannotMapIgnoredProperty = "EntityMappingConfiguration_CannotMapIgnoredProperty";

	internal const string EntityMappingConfiguration_InvalidTableSharing = "EntityMappingConfiguration_InvalidTableSharing";

	internal const string ModelBuilder_KeyPropertiesMustBePrimitive = "ModelBuilder_KeyPropertiesMustBePrimitive";

	internal const string TableNotFound = "TableNotFound";

	internal const string IncorrectColumnCount = "IncorrectColumnCount";

	internal const string CircularComplexTypeHierarchy = "CircularComplexTypeHierarchy";

	internal const string UnableToDeterminePrincipal = "UnableToDeterminePrincipal";

	internal const string UnmappedAbstractType = "UnmappedAbstractType";

	internal const string UnsupportedHybridInheritanceMapping = "UnsupportedHybridInheritanceMapping";

	internal const string BadLocalDBDatabaseName = "BadLocalDBDatabaseName";

	internal const string FailedToGetProviderInformation = "FailedToGetProviderInformation";

	internal const string DbPropertyEntry_CannotGetCurrentValue = "DbPropertyEntry_CannotGetCurrentValue";

	internal const string DbPropertyEntry_CannotSetCurrentValue = "DbPropertyEntry_CannotSetCurrentValue";

	internal const string DbPropertyEntry_NotSupportedForDetached = "DbPropertyEntry_NotSupportedForDetached";

	internal const string DbPropertyEntry_SettingEntityRefNotSupported = "DbPropertyEntry_SettingEntityRefNotSupported";

	internal const string DbPropertyEntry_NotSupportedForPropertiesNotInTheModel = "DbPropertyEntry_NotSupportedForPropertiesNotInTheModel";

	internal const string DbEntityEntry_NotSupportedForDetached = "DbEntityEntry_NotSupportedForDetached";

	internal const string DbSet_BadTypeForAddAttachRemove = "DbSet_BadTypeForAddAttachRemove";

	internal const string DbSet_BadTypeForCreate = "DbSet_BadTypeForCreate";

	internal const string DbEntity_BadTypeForCast = "DbEntity_BadTypeForCast";

	internal const string DbMember_BadTypeForCast = "DbMember_BadTypeForCast";

	internal const string DbEntityEntry_UsedReferenceForCollectionProp = "DbEntityEntry_UsedReferenceForCollectionProp";

	internal const string DbEntityEntry_UsedCollectionForReferenceProp = "DbEntityEntry_UsedCollectionForReferenceProp";

	internal const string DbEntityEntry_NotANavigationProperty = "DbEntityEntry_NotANavigationProperty";

	internal const string DbEntityEntry_NotAScalarProperty = "DbEntityEntry_NotAScalarProperty";

	internal const string DbEntityEntry_NotAComplexProperty = "DbEntityEntry_NotAComplexProperty";

	internal const string DbEntityEntry_NotAProperty = "DbEntityEntry_NotAProperty";

	internal const string DbEntityEntry_DottedPartNotComplex = "DbEntityEntry_DottedPartNotComplex";

	internal const string DbEntityEntry_DottedPathMustBeProperty = "DbEntityEntry_DottedPathMustBeProperty";

	internal const string DbEntityEntry_WrongGenericForNavProp = "DbEntityEntry_WrongGenericForNavProp";

	internal const string DbEntityEntry_WrongGenericForCollectionNavProp = "DbEntityEntry_WrongGenericForCollectionNavProp";

	internal const string DbEntityEntry_WrongGenericForProp = "DbEntityEntry_WrongGenericForProp";

	internal const string DbPropertyEntry_CannotMarkPropertyUnmodified = "DbPropertyEntry_CannotMarkPropertyUnmodified";

	internal const string DbEntityEntry_BadPropertyExpression = "DbEntityEntry_BadPropertyExpression";

	internal const string DbContext_IndependentAssociationUpdateException = "DbContext_IndependentAssociationUpdateException";

	internal const string DbPropertyValues_CannotGetValuesForState = "DbPropertyValues_CannotGetValuesForState";

	internal const string DbPropertyValues_CannotSetNullValue = "DbPropertyValues_CannotSetNullValue";

	internal const string DbPropertyValues_CannotGetStoreValuesWhenComplexPropertyIsNull = "DbPropertyValues_CannotGetStoreValuesWhenComplexPropertyIsNull";

	internal const string DbPropertyValues_WrongTypeForAssignment = "DbPropertyValues_WrongTypeForAssignment";

	internal const string DbPropertyValues_PropertyValueNamesAreReadonly = "DbPropertyValues_PropertyValueNamesAreReadonly";

	internal const string DbPropertyValues_PropertyDoesNotExist = "DbPropertyValues_PropertyDoesNotExist";

	internal const string DbPropertyValues_AttemptToSetValuesFromWrongObject = "DbPropertyValues_AttemptToSetValuesFromWrongObject";

	internal const string DbPropertyValues_AttemptToSetValuesFromWrongType = "DbPropertyValues_AttemptToSetValuesFromWrongType";

	internal const string DbPropertyValues_AttemptToSetNonValuesOnComplexProperty = "DbPropertyValues_AttemptToSetNonValuesOnComplexProperty";

	internal const string DbPropertyValues_ComplexObjectCannotBeNull = "DbPropertyValues_ComplexObjectCannotBeNull";

	internal const string DbPropertyValues_NestedPropertyValuesNull = "DbPropertyValues_NestedPropertyValuesNull";

	internal const string DatabaseInitializationStrategy_ModelMismatch = "DatabaseInitializationStrategy_ModelMismatch";

	internal const string Database_DatabaseAlreadyExists = "Database_DatabaseAlreadyExists";

	internal const string Database_NonCodeFirstCompatibilityCheck = "Database_NonCodeFirstCompatibilityCheck";

	internal const string Database_NoDatabaseMetadata = "Database_NoDatabaseMetadata";

	internal const string Database_BadLegacyInitializerEntry = "Database_BadLegacyInitializerEntry";

	internal const string Database_InitializeFromLegacyConfigFailed = "Database_InitializeFromLegacyConfigFailed";

	internal const string Database_InitializeFromConfigFailed = "Database_InitializeFromConfigFailed";

	internal const string ContextConfiguredMultipleTimes = "ContextConfiguredMultipleTimes";

	internal const string SetConnectionFactoryFromConfigFailed = "SetConnectionFactoryFromConfigFailed";

	internal const string Database_FailedToResolveType = "Database_FailedToResolveType";

	internal const string DbContext_ContextUsedInModelCreating = "DbContext_ContextUsedInModelCreating";

	internal const string DbContext_MESTNotSupported = "DbContext_MESTNotSupported";

	internal const string DbContext_Disposed = "DbContext_Disposed";

	internal const string DbContext_ProviderReturnedNullConnection = "DbContext_ProviderReturnedNullConnection";

	internal const string DbContext_ProviderNameMissing = "DbContext_ProviderNameMissing";

	internal const string DbContext_ConnectionFactoryReturnedNullConnection = "DbContext_ConnectionFactoryReturnedNullConnection";

	internal const string DbSet_WrongNumberOfKeyValuesPassed = "DbSet_WrongNumberOfKeyValuesPassed";

	internal const string DbSet_WrongKeyValueType = "DbSet_WrongKeyValueType";

	internal const string DbSet_WrongEntityTypeFound = "DbSet_WrongEntityTypeFound";

	internal const string DbSet_MultipleAddedEntitiesFound = "DbSet_MultipleAddedEntitiesFound";

	internal const string DbSet_DbSetUsedWithComplexType = "DbSet_DbSetUsedWithComplexType";

	internal const string DbSet_PocoAndNonPocoMixedInSameAssembly = "DbSet_PocoAndNonPocoMixedInSameAssembly";

	internal const string DbSet_EntityTypeNotInModel = "DbSet_EntityTypeNotInModel";

	internal const string DbQuery_BindingToDbQueryNotSupported = "DbQuery_BindingToDbQueryNotSupported";

	internal const string DbExtensions_InvalidIncludePathExpression = "DbExtensions_InvalidIncludePathExpression";

	internal const string DbContext_ConnectionStringNotFound = "DbContext_ConnectionStringNotFound";

	internal const string DbContext_ConnectionHasModel = "DbContext_ConnectionHasModel";

	internal const string DbCollectionEntry_CannotSetCollectionProp = "DbCollectionEntry_CannotSetCollectionProp";

	internal const string CodeFirstCachedMetadataWorkspace_SameModelDifferentProvidersNotSupported = "CodeFirstCachedMetadataWorkspace_SameModelDifferentProvidersNotSupported";

	internal const string Mapping_MESTNotSupported = "Mapping_MESTNotSupported";

	internal const string DbModelBuilder_MissingRequiredCtor = "DbModelBuilder_MissingRequiredCtor";

	internal const string DbEntityValidationException_ValidationFailed = "DbEntityValidationException_ValidationFailed";

	internal const string DbUnexpectedValidationException_ValidationAttribute = "DbUnexpectedValidationException_ValidationAttribute";

	internal const string DbUnexpectedValidationException_IValidatableObject = "DbUnexpectedValidationException_IValidatableObject";

	internal const string SqlConnectionFactory_MdfNotSupported = "SqlConnectionFactory_MdfNotSupported";

	internal const string Database_InitializationException = "Database_InitializationException";

	internal const string EdmxWriter_EdmxFromObjectContextNotSupported = "EdmxWriter_EdmxFromObjectContextNotSupported";

	internal const string EdmxWriter_EdmxFromModelFirstNotSupported = "EdmxWriter_EdmxFromModelFirstNotSupported";

	internal const string UnintentionalCodeFirstException_Message = "UnintentionalCodeFirstException_Message";

	internal const string DbContextServices_MissingDefaultCtor = "DbContextServices_MissingDefaultCtor";

	internal const string EdmPrimitiveType_SetPropertyNotSupported = "EdmPrimitiveType_SetPropertyNotSupported";

	internal const string EdmModel_Validator_Semantic_SystemNamespaceEncountered = "EdmModel_Validator_Semantic_SystemNamespaceEncountered";

	internal const string EdmModel_Validator_Semantic_SimilarRelationshipEnd = "EdmModel_Validator_Semantic_SimilarRelationshipEnd";

	internal const string EdmModel_Validator_Semantic_InvalidEntitySetNameReference = "EdmModel_Validator_Semantic_InvalidEntitySetNameReference";

	internal const string EdmModel_Validator_Semantic_ConcurrencyRedefinedOnSubTypeOfEntitySetType = "EdmModel_Validator_Semantic_ConcurrencyRedefinedOnSubTypeOfEntitySetType";

	internal const string EdmModel_Validator_Semantic_EntitySetTypeHasNoKeys = "EdmModel_Validator_Semantic_EntitySetTypeHasNoKeys";

	internal const string EdmModel_Validator_Semantic_DuplicateEndName = "EdmModel_Validator_Semantic_DuplicateEndName";

	internal const string EdmModel_Validator_Semantic_DuplicatePropertyNameSpecifiedInEntityKey = "EdmModel_Validator_Semantic_DuplicatePropertyNameSpecifiedInEntityKey";

	internal const string EdmModel_Validator_Semantic_InvalidCollectionKindNotCollection = "EdmModel_Validator_Semantic_InvalidCollectionKindNotCollection";

	internal const string EdmModel_Validator_Semantic_InvalidCollectionKindNotV1_1 = "EdmModel_Validator_Semantic_InvalidCollectionKindNotV1_1";

	internal const string EdmModel_Validator_Semantic_InvalidComplexTypeAbstract = "EdmModel_Validator_Semantic_InvalidComplexTypeAbstract";

	internal const string EdmModel_Validator_Semantic_InvalidComplexTypePolymorphic = "EdmModel_Validator_Semantic_InvalidComplexTypePolymorphic";

	internal const string EdmModel_Validator_Semantic_InvalidKeyNullablePart = "EdmModel_Validator_Semantic_InvalidKeyNullablePart";

	internal const string EdmModel_Validator_Semantic_EntityKeyMustBeScalar = "EdmModel_Validator_Semantic_EntityKeyMustBeScalar";

	internal const string EdmModel_Validator_Semantic_InvalidKeyKeyDefinedInBaseClass = "EdmModel_Validator_Semantic_InvalidKeyKeyDefinedInBaseClass";

	internal const string EdmModel_Validator_Semantic_KeyMissingOnEntityType = "EdmModel_Validator_Semantic_KeyMissingOnEntityType";

	internal const string EdmModel_Validator_Semantic_BadNavigationPropertyUndefinedRole = "EdmModel_Validator_Semantic_BadNavigationPropertyUndefinedRole";

	internal const string EdmModel_Validator_Semantic_BadNavigationPropertyRolesCannotBeTheSame = "EdmModel_Validator_Semantic_BadNavigationPropertyRolesCannotBeTheSame";

	internal const string EdmModel_Validator_Semantic_InvalidOperationMultipleEndsInAssociation = "EdmModel_Validator_Semantic_InvalidOperationMultipleEndsInAssociation";

	internal const string EdmModel_Validator_Semantic_EndWithManyMultiplicityCannotHaveOperationsSpecified = "EdmModel_Validator_Semantic_EndWithManyMultiplicityCannotHaveOperationsSpecified";

	internal const string EdmModel_Validator_Semantic_EndNameAlreadyDefinedDuplicate = "EdmModel_Validator_Semantic_EndNameAlreadyDefinedDuplicate";

	internal const string EdmModel_Validator_Semantic_SameRoleReferredInReferentialConstraint = "EdmModel_Validator_Semantic_SameRoleReferredInReferentialConstraint";

	internal const string EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleUpperBoundMustBeOne = "EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleUpperBoundMustBeOne";

	internal const string EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNullableV1 = "EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNullableV1";

	internal const string EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV1 = "EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV1";

	internal const string EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV2 = "EdmModel_Validator_Semantic_InvalidMultiplicityFromRoleToPropertyNonNullableV2";

	internal const string EdmModel_Validator_Semantic_InvalidToPropertyInRelationshipConstraint = "EdmModel_Validator_Semantic_InvalidToPropertyInRelationshipConstraint";

	internal const string EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeOne = "EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeOne";

	internal const string EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeMany = "EdmModel_Validator_Semantic_InvalidMultiplicityToRoleUpperBoundMustBeMany";

	internal const string EdmModel_Validator_Semantic_MismatchNumberOfPropertiesinRelationshipConstraint = "EdmModel_Validator_Semantic_MismatchNumberOfPropertiesinRelationshipConstraint";

	internal const string EdmModel_Validator_Semantic_TypeMismatchRelationshipConstraint = "EdmModel_Validator_Semantic_TypeMismatchRelationshipConstraint";

	internal const string EdmModel_Validator_Semantic_InvalidPropertyInRelationshipConstraint = "EdmModel_Validator_Semantic_InvalidPropertyInRelationshipConstraint";

	internal const string EdmModel_Validator_Semantic_NullableComplexType = "EdmModel_Validator_Semantic_NullableComplexType";

	internal const string EdmModel_Validator_Semantic_InvalidPropertyType = "EdmModel_Validator_Semantic_InvalidPropertyType";

	internal const string EdmModel_Validator_Semantic_DuplicateEntityContainerMemberName = "EdmModel_Validator_Semantic_DuplicateEntityContainerMemberName";

	internal const string EdmModel_Validator_Semantic_TypeNameAlreadyDefinedDuplicate = "EdmModel_Validator_Semantic_TypeNameAlreadyDefinedDuplicate";

	internal const string EdmModel_Validator_Semantic_InvalidMemberNameMatchesTypeName = "EdmModel_Validator_Semantic_InvalidMemberNameMatchesTypeName";

	internal const string EdmModel_Validator_Semantic_PropertyNameAlreadyDefinedDuplicate = "EdmModel_Validator_Semantic_PropertyNameAlreadyDefinedDuplicate";

	internal const string EdmModel_Validator_Semantic_CycleInTypeHierarchy = "EdmModel_Validator_Semantic_CycleInTypeHierarchy";

	internal const string EdmModel_Validator_Semantic_InvalidPropertyType_V1_1 = "EdmModel_Validator_Semantic_InvalidPropertyType_V1_1";

	internal const string EdmModel_Validator_Syntactic_MissingName = "EdmModel_Validator_Syntactic_MissingName";

	internal const string EdmModel_Validator_Syntactic_EdmModel_NameIsTooLong = "EdmModel_Validator_Syntactic_EdmModel_NameIsTooLong";

	internal const string EdmModel_Validator_Syntactic_EdmModel_NameIsNotAllowed = "EdmModel_Validator_Syntactic_EdmModel_NameIsNotAllowed";

	internal const string EdmModel_Validator_Syntactic_EdmAssociationType_AssocationEndMustNotBeNull = "EdmModel_Validator_Syntactic_EdmAssociationType_AssocationEndMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentEndMustNotBeNull = "EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentEndMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentPropertiesMustNotBeEmpty = "EdmModel_Validator_Syntactic_EdmAssociationConstraint_DependentPropertiesMustNotBeEmpty";

	internal const string EdmModel_Validator_Syntactic_EdmNavigationProperty_AssocationMustNotBeNull = "EdmModel_Validator_Syntactic_EdmNavigationProperty_AssocationMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmNavigationProperty_ResultEndMustNotBeNull = "EdmModel_Validator_Syntactic_EdmNavigationProperty_ResultEndMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmAssociationEnd_EntityTypeMustNotBeNull = "EdmModel_Validator_Syntactic_EdmAssociationEnd_EntityTypeMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmEntitySet_ElementTypeMustNotBeNull = "EdmModel_Validator_Syntactic_EdmEntitySet_ElementTypeMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmAssociationSet_ElementTypeMustNotBeNull = "EdmModel_Validator_Syntactic_EdmAssociationSet_ElementTypeMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmAssociationSet_SourceSetMustNotBeNull = "EdmModel_Validator_Syntactic_EdmAssociationSet_SourceSetMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmAssociationSet_TargetSetMustNotBeNull = "EdmModel_Validator_Syntactic_EdmAssociationSet_TargetSetMustNotBeNull";

	internal const string EdmModel_Validator_Syntactic_EdmTypeReferenceNotValid = "EdmModel_Validator_Syntactic_EdmTypeReferenceNotValid";

	internal const string Serializer_OneNamespaceAndOneContainer = "Serializer_OneNamespaceAndOneContainer";

	internal const string MaxLengthAttribute_ValidationError = "MaxLengthAttribute_ValidationError";

	internal const string MaxLengthAttribute_InvalidMaxLength = "MaxLengthAttribute_InvalidMaxLength";

	internal const string MinLengthAttribute_ValidationError = "MinLengthAttribute_ValidationError";

	internal const string MinLengthAttribute_InvalidMinLength = "MinLengthAttribute_InvalidMinLength";

	internal const string DbConnectionInfo_ConnectionStringNotFound = "DbConnectionInfo_ConnectionStringNotFound";

	internal const string EagerInternalContext_CannotSetConnectionInfo = "EagerInternalContext_CannotSetConnectionInfo";

	internal const string LazyInternalContext_CannotReplaceEfConnectionWithDbConnection = "LazyInternalContext_CannotReplaceEfConnectionWithDbConnection";

	internal const string LazyInternalContext_CannotReplaceDbConnectionWithEfConnection = "LazyInternalContext_CannotReplaceDbConnectionWithEfConnection";

	private static EntityRes loader;

	private ResourceManager resources;

	private static CultureInfo Culture => null;

	public static ResourceManager Resources => GetLoader().resources;

	internal EntityRes()
	{
		resources = new ResourceManager("System.Data.Entity.Properties.Resources", GetType().Assembly);
	}

	private static EntityRes GetLoader()
	{
		if (loader == null)
		{
			EntityRes value = new EntityRes();
			Interlocked.CompareExchange(ref loader, value, null);
		}
		return loader;
	}

	public static string GetString(string name, params object[] args)
	{
		EntityRes entityRes = GetLoader();
		if (entityRes == null)
		{
			return null;
		}
		string @string = entityRes.resources.GetString(name, Culture);
		if (args != null && args.Length > 0)
		{
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] is string text && text.Length > 1024)
				{
					args[i] = text.Substring(0, 1021) + "...";
				}
			}
			return string.Format(CultureInfo.CurrentCulture, @string, args);
		}
		return @string;
	}

	public static string GetString(string name)
	{
		return GetLoader()?.resources.GetString(name, Culture);
	}

	public static string GetString(string name, out bool usedFallback)
	{
		usedFallback = false;
		return GetString(name);
	}

	public static object GetObject(string name)
	{
		return GetLoader()?.resources.GetObject(name, Culture);
	}
}