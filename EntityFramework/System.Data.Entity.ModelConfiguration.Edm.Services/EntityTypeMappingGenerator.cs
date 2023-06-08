using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Services;

internal class EntityTypeMappingGenerator : StructuralTypeMappingGenerator
{
	public EntityTypeMappingGenerator(DbProviderManifest providerManifest)
		: base(providerManifest)
	{
	}

	public void Generate(EdmEntityType entityType, DbDatabaseMapping databaseMapping)
	{
		EdmEntitySet entitySet = databaseMapping.Model.GetEntitySet(entityType);
		DbEntitySetMapping dbEntitySetMapping = databaseMapping.GetEntitySetMapping(entitySet) ?? databaseMapping.AddEntitySetMapping(entitySet);
		DbTableMetadata table = (dbEntitySetMapping.EntityTypeMappings.Any() ? dbEntitySetMapping.EntityTypeMappings.First().TypeMappingFragments.First().Table : databaseMapping.Database.AddTable(entityType.GetRootType().Name));
		DbEntityTypeMappingFragment dbEntityTypeMappingFragment = new DbEntityTypeMappingFragment();
		dbEntityTypeMappingFragment.Table = table;
		DbEntityTypeMappingFragment dbEntityTypeMappingFragment2 = dbEntityTypeMappingFragment;
		DbEntityTypeMapping dbEntityTypeMapping = new DbEntityTypeMapping();
		dbEntityTypeMapping.EntityType = entityType;
		dbEntityTypeMapping.IsHierarchyMapping = false;
		DbEntityTypeMapping dbEntityTypeMapping2 = dbEntityTypeMapping;
		dbEntityTypeMapping2.TypeMappingFragments.Add(dbEntityTypeMappingFragment2);
		dbEntityTypeMapping2.SetClrType(entityType.GetClrType());
		dbEntitySetMapping.EntityTypeMappings.Add(dbEntityTypeMapping2);
		new PropertyMappingGenerator(_providerManifest).Generate(entityType, entityType.Properties, dbEntitySetMapping, dbEntityTypeMappingFragment2, new List<EdmProperty>(), createNewColumn: false);
	}
}
