using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Edm.Serialization;
using System.Data.Mapping;
using System.Data.Metadata.Edm;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;

[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
internal static class DbDatabaseMappingExtensions
{
	internal static DbDatabaseMapping Initialize(this DbDatabaseMapping databaseMapping, EdmModel model, DbDatabaseMetadata database)
	{
		databaseMapping.Model = model;
		databaseMapping.Database = database;
		DbEntityContainerMapping dbEntityContainerMapping = new DbEntityContainerMapping();
		dbEntityContainerMapping.EntityContainer = model.Containers.Single();
		DbEntityContainerMapping item = dbEntityContainerMapping;
		databaseMapping.EntityContainerMappings.Add(item);
		return databaseMapping;
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	internal static MetadataWorkspace ToMetadataWorkspace(this DbDatabaseMapping databaseMapping)
	{
		MetadataWorkspace metadataWorkspace = new MetadataWorkspace();
		EdmItemCollection edmItemCollection = databaseMapping.Model.ToEdmItemCollection();
		StoreItemCollection storeItemCollection = databaseMapping.Database.ToStoreItemCollection();
		StorageMappingItemCollection collection = databaseMapping.ToStorageMappingItemCollection(edmItemCollection, storeItemCollection);
		metadataWorkspace.RegisterItemCollection(edmItemCollection);
		metadataWorkspace.RegisterItemCollection(storeItemCollection);
		metadataWorkspace.RegisterItemCollection(collection);
		return metadataWorkspace;
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	internal static StorageMappingItemCollection ToStorageMappingItemCollection(this DbDatabaseMapping databaseMapping)
	{
		return databaseMapping.ToStorageMappingItemCollection(databaseMapping.Model.ToEdmItemCollection(), databaseMapping.Database.ToStoreItemCollection());
	}

	private static StorageMappingItemCollection ToStorageMappingItemCollection(this DbDatabaseMapping databaseMapping, EdmItemCollection itemCollection, StoreItemCollection storeItemCollection)
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings
		{
			Indent = true
		}))
		{
			new MslSerializer().Serialize(databaseMapping, xmlWriter);
		}
		using XmlReader xmlReader = XmlReader.Create(new StringReader(stringBuilder.ToString()));
		return new StorageMappingItemCollection(itemCollection, storeItemCollection, new XmlReader[1] { xmlReader });
	}

	internal static DbEntityTypeMapping GetEntityTypeMapping(this DbDatabaseMapping databaseMapping, EdmEntityType entityType)
	{
		IEnumerable<DbEntityTypeMapping> entityTypeMappings = databaseMapping.GetEntityTypeMappings(entityType);
		if (entityTypeMappings.Count() <= 1)
		{
			return entityTypeMappings.SingleOrDefault();
		}
		return entityTypeMappings.SingleOrDefault((DbEntityTypeMapping m) => m.IsHierarchyMapping);
	}

	internal static IEnumerable<DbEntityTypeMapping> GetEntityTypeMappings(this DbDatabaseMapping databaseMapping, EdmEntityType entityType)
	{
		return from esm in databaseMapping.EntityContainerMappings.Single().EntitySetMappings
			from etm in esm.EntityTypeMappings
			where etm.EntityType == entityType
			select etm;
	}

	internal static DbEntityTypeMapping GetEntityTypeMapping(this DbDatabaseMapping databaseMapping, Type entityType)
	{
		IEnumerable<DbEntityTypeMapping> source = from esm in databaseMapping.EntityContainerMappings.Single().EntitySetMappings
			from etm in esm.EntityTypeMappings
			where etm.GetClrType() == entityType
			select etm;
		if (source.Count() <= 1)
		{
			return source.SingleOrDefault();
		}
		return source.SingleOrDefault((DbEntityTypeMapping m) => m.IsHierarchyMapping);
	}

	internal static IEnumerable<Tuple<DbEdmPropertyMapping, DbTableMetadata>> GetComplexPropertyMappings(this DbDatabaseMapping databaseMapping, Type complexType)
	{
		return from esm in databaseMapping.EntityContainerMappings.Single().EntitySetMappings
			from etm in esm.EntityTypeMappings
			from etmf in etm.TypeMappingFragments
			from epm in etmf.PropertyMappings
			where epm.PropertyPath.Any((System.Data.Entity.Edm.EdmProperty p) => p.PropertyType.IsComplexType && p.PropertyType.ComplexType.GetClrType() == complexType)
			select Tuple.Create(epm, etmf.Table);
	}

	internal static DbEntitySetMapping GetEntitySetMapping(this DbDatabaseMapping databaseMapping, EdmEntitySet entitySet)
	{
		return databaseMapping.EntityContainerMappings.Single().EntitySetMappings.SingleOrDefault((DbEntitySetMapping e) => e.EntitySet == entitySet);
	}

	internal static IEnumerable<DbEntitySetMapping> GetEntitySetMappings(this DbDatabaseMapping databaseMapping)
	{
		return databaseMapping.EntityContainerMappings.Single().EntitySetMappings;
	}

	internal static IEnumerable<DbAssociationSetMapping> GetAssociationSetMappings(this DbDatabaseMapping databaseMapping)
	{
		return databaseMapping.EntityContainerMappings.Single().AssociationSetMappings;
	}

	internal static DbEntitySetMapping AddEntitySetMapping(this DbDatabaseMapping databaseMapping, EdmEntitySet entitySet)
	{
		DbEntitySetMapping dbEntitySetMapping = new DbEntitySetMapping();
		dbEntitySetMapping.EntitySet = entitySet;
		DbEntitySetMapping dbEntitySetMapping2 = dbEntitySetMapping;
		databaseMapping.EntityContainerMappings.Single().EntitySetMappings.Add(dbEntitySetMapping2);
		return dbEntitySetMapping2;
	}

	internal static DbAssociationSetMapping AddAssociationSetMapping(this DbDatabaseMapping databaseMapping, EdmAssociationSet associationSet)
	{
		DbAssociationSetMapping dbAssociationSetMapping = new DbAssociationSetMapping();
		dbAssociationSetMapping.AssociationSet = associationSet;
		DbAssociationSetMapping dbAssociationSetMapping2 = dbAssociationSetMapping.Initialize();
		databaseMapping.EntityContainerMappings.Single().AssociationSetMappings.Add(dbAssociationSetMapping2);
		return dbAssociationSetMapping2;
	}
}
