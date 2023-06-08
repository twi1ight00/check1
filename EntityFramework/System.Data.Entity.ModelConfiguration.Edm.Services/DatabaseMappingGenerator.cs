using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Metadata.Edm;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Services;

internal class DatabaseMappingGenerator
{
	private const string DiscriminatorColumnName = "Discriminator";

	internal const int DiscriminatorLength = 128;

	private readonly DbProviderManifest _providerManifest;

	public DatabaseMappingGenerator(DbProviderManifest providerManifest)
	{
		_providerManifest = providerManifest;
	}

	public DbDatabaseMapping Generate(EdmModel model)
	{
		DbDatabaseMapping dbDatabaseMapping = InitializeDatabaseMapping(model);
		GenerateEntityTypes(model, dbDatabaseMapping);
		GenerateDiscriminators(dbDatabaseMapping);
		GenerateAssociationTypes(model, dbDatabaseMapping);
		return dbDatabaseMapping;
	}

	private static DbDatabaseMapping InitializeDatabaseMapping(EdmModel model)
	{
		DbDatabaseMapping dbDatabaseMapping = new DbDatabaseMapping().Initialize(model, new DbDatabaseMetadata().Initialize());
		dbDatabaseMapping.EntityContainerMappings.Single().EntityContainer = model.Containers.Single();
		return dbDatabaseMapping;
	}

	private void GenerateEntityTypes(EdmModel model, DbDatabaseMapping databaseMapping)
	{
		foreach (EdmEntityType entityType in model.GetEntityTypes())
		{
			if (!entityType.IsAbstract)
			{
				new EntityTypeMappingGenerator(_providerManifest).Generate(entityType, databaseMapping);
			}
		}
	}

	private void GenerateDiscriminators(DbDatabaseMapping databaseMapping)
	{
		foreach (DbEntitySetMapping entitySetMapping in databaseMapping.GetEntitySetMappings())
		{
			if (entitySetMapping.EntityTypeMappings.Count == 1)
			{
				continue;
			}
			DbTableColumnMetadata dbTableColumnMetadata = entitySetMapping.EntityTypeMappings.First().TypeMappingFragments.Single().Table.AddColumn("Discriminator");
			InitializeDefaultDiscriminatorColumn(dbTableColumnMetadata);
			foreach (DbEntityTypeMapping entityTypeMapping in entitySetMapping.EntityTypeMappings)
			{
				DbEntityTypeMappingFragment dbEntityTypeMappingFragment = entityTypeMapping.TypeMappingFragments.Single();
				dbEntityTypeMappingFragment.SetDefaultDiscriminator(dbTableColumnMetadata);
				dbEntityTypeMappingFragment.AddDiscriminatorCondition(dbTableColumnMetadata, entityTypeMapping.EntityType.Name);
			}
		}
	}

	public void InitializeDefaultDiscriminatorColumn(DbTableColumnMetadata column)
	{
		DbProviderManifest providerManifest = _providerManifest;
		bool isUnicode = true;
		bool isFixedLength = false;
		int maxLength = 128;
		TypeUsage storeType = providerManifest.GetStoreType(TypeUsage.CreateStringTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.String), isUnicode, isFixedLength, maxLength));
		column.TypeName = storeType.EdmType.Name;
		column.Facets.MaxLength = 128;
		column.IsNullable = false;
	}

	private void GenerateAssociationTypes(EdmModel model, DbDatabaseMapping databaseMapping)
	{
		foreach (EdmAssociationType associationType in model.GetAssociationTypes())
		{
			new AssociationTypeMappingGenerator(_providerManifest).Generate(associationType, databaseMapping);
		}
	}
}
