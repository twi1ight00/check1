using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Services;

internal class AssociationTypeMappingGenerator : StructuralTypeMappingGenerator
{
	public AssociationTypeMappingGenerator(DbProviderManifest providerManifest)
		: base(providerManifest)
	{
	}

	public void Generate(EdmAssociationType associationType, DbDatabaseMapping databaseMapping)
	{
		if (associationType.Constraint != null)
		{
			GenerateForeignKeyAssociationType(associationType, databaseMapping);
		}
		else if (associationType.IsManyToMany())
		{
			GenerateManyToManyAssociation(associationType, databaseMapping);
		}
		else
		{
			GenerateIndependentAssociationType(associationType, databaseMapping);
		}
	}

	private static void GenerateForeignKeyAssociationType(EdmAssociationType associationType, DbDatabaseMapping databaseMapping)
	{
		EdmAssociationEnd dependentEnd = associationType.Constraint.DependentEnd;
		EdmAssociationEnd otherEnd = associationType.GetOtherEnd(dependentEnd);
		DbEntityTypeMapping entityTypeMappingInHierarchy = StructuralTypeMappingGenerator.GetEntityTypeMappingInHierarchy(databaseMapping, otherEnd.EntityType);
		DbEntityTypeMapping entityTypeMappingInHierarchy2 = StructuralTypeMappingGenerator.GetEntityTypeMappingInHierarchy(databaseMapping, dependentEnd.EntityType);
		DbForeignKeyConstraintMetadata dbForeignKeyConstraintMetadata = new DbForeignKeyConstraintMetadata();
		dbForeignKeyConstraintMetadata.Name = associationType.Name;
		dbForeignKeyConstraintMetadata.PrincipalTable = entityTypeMappingInHierarchy.TypeMappingFragments.Single().Table;
		dbForeignKeyConstraintMetadata.DeleteAction = (DbOperationAction)(otherEnd.DeleteAction.HasValue ? otherEnd.DeleteAction.Value : EdmOperationAction.None);
		DbForeignKeyConstraintMetadata dbForeignKeyConstraintMetadata2 = dbForeignKeyConstraintMetadata;
		foreach (EdmProperty dependentProperty in associationType.Constraint.DependentProperties)
		{
			dbForeignKeyConstraintMetadata2.DependentColumns.Add(entityTypeMappingInHierarchy2.GetPropertyMapping(dependentProperty).Column);
		}
		dbForeignKeyConstraintMetadata2.SetAssociationType(associationType);
		entityTypeMappingInHierarchy2.TypeMappingFragments.Single().Table.ForeignKeyConstraints.Add(dbForeignKeyConstraintMetadata2);
	}

	private void GenerateManyToManyAssociation(EdmAssociationType associationType, DbDatabaseMapping databaseMapping)
	{
		EdmEntityType entityType = associationType.SourceEnd.EntityType;
		EdmEntityType entityType2 = associationType.TargetEnd.EntityType;
		DbTableMetadata dependentTable = databaseMapping.Database.AddTable(entityType.Name + entityType2.Name);
		DbAssociationSetMapping dbAssociationSetMapping = GenerateAssociationSetMapping(associationType, databaseMapping, associationType.SourceEnd, associationType.TargetEnd, dependentTable);
		bool isPrimaryKeyColumn = true;
		GenerateIndependentForeignKeyConstraint(databaseMapping, entityType, entityType2, dependentTable, dbAssociationSetMapping, dbAssociationSetMapping.SourceEndMapping, associationType.SourceEnd.Name, null, isPrimaryKeyColumn);
		bool isPrimaryKeyColumn2 = true;
		GenerateIndependentForeignKeyConstraint(databaseMapping, entityType2, entityType, dependentTable, dbAssociationSetMapping, dbAssociationSetMapping.TargetEndMapping, associationType.TargetEnd.Name, null, isPrimaryKeyColumn2);
	}

	private void GenerateIndependentAssociationType(EdmAssociationType associationType, DbDatabaseMapping databaseMapping)
	{
		if (!associationType.TryGuessPrincipalAndDependentEnds(out var principalEnd, out var dependentEnd))
		{
			if (!associationType.IsPrincipalConfigured())
			{
				throw Error.UnableToDeterminePrincipal(associationType.SourceEnd.EntityType.GetClrType(), associationType.TargetEnd.EntityType.GetClrType());
			}
			principalEnd = associationType.SourceEnd;
			dependentEnd = associationType.TargetEnd;
		}
		DbEntityTypeMapping entityTypeMappingInHierarchy = StructuralTypeMappingGenerator.GetEntityTypeMappingInHierarchy(databaseMapping, dependentEnd.EntityType);
		DbTableMetadata table = entityTypeMappingInHierarchy.TypeMappingFragments.First().Table;
		DbAssociationSetMapping dbAssociationSetMapping = GenerateAssociationSetMapping(associationType, databaseMapping, principalEnd, dependentEnd, table);
		GenerateIndependentForeignKeyConstraint(databaseMapping, principalEnd.EntityType, dependentEnd.EntityType, table, dbAssociationSetMapping, dbAssociationSetMapping.SourceEndMapping, associationType.Name, principalEnd);
		foreach (EdmProperty item in dependentEnd.EntityType.KeyProperties())
		{
			dbAssociationSetMapping.TargetEndMapping.PropertyMappings.Add(new DbEdmPropertyMapping
			{
				Column = entityTypeMappingInHierarchy.GetPropertyMapping(item).Column,
				PropertyPath = new EdmProperty[1] { item }
			});
		}
	}

	private static DbAssociationSetMapping GenerateAssociationSetMapping(EdmAssociationType associationType, DbDatabaseMapping databaseMapping, EdmAssociationEnd principalEnd, EdmAssociationEnd dependentEnd, DbTableMetadata dependentTable)
	{
		DbAssociationSetMapping dbAssociationSetMapping = databaseMapping.AddAssociationSetMapping(databaseMapping.Model.GetAssociationSet(associationType));
		dbAssociationSetMapping.Table = dependentTable;
		dbAssociationSetMapping.SourceEndMapping.AssociationEnd = principalEnd;
		dbAssociationSetMapping.TargetEndMapping.AssociationEnd = dependentEnd;
		return dbAssociationSetMapping;
	}

	private void GenerateIndependentForeignKeyConstraint(DbDatabaseMapping databaseMapping, EdmEntityType principalEntityType, EdmEntityType dependentEntityType, DbTableMetadata dependentTable, DbAssociationSetMapping associationSetMapping, DbAssociationEndMapping associationEndMapping, string name, EdmAssociationEnd principalEnd, bool isPrimaryKeyColumn = false)
	{
		DbTableMetadata table = StructuralTypeMappingGenerator.GetEntityTypeMappingInHierarchy(databaseMapping, principalEntityType).TypeMappingFragments.Single().Table;
		DbForeignKeyConstraintMetadata dbForeignKeyConstraintMetadata = new DbForeignKeyConstraintMetadata();
		dbForeignKeyConstraintMetadata.Name = name;
		dbForeignKeyConstraintMetadata.PrincipalTable = table;
		dbForeignKeyConstraintMetadata.DeleteAction = (DbOperationAction)(associationEndMapping.AssociationEnd.DeleteAction.HasValue ? associationEndMapping.AssociationEnd.DeleteAction.Value : EdmOperationAction.None);
		DbForeignKeyConstraintMetadata dbForeignKeyConstraintMetadata2 = dbForeignKeyConstraintMetadata;
		EdmNavigationProperty principalNavigationProperty = databaseMapping.Model.GetEntityTypes().SelectMany((EdmEntityType e) => e.DeclaredNavigationProperties).SingleOrDefault((EdmNavigationProperty n) => n.ResultEnd == principalEnd);
		GenerateIndependentForeignKeyColumns(principalEntityType, dependentEntityType, associationSetMapping, associationEndMapping, dependentTable, dbForeignKeyConstraintMetadata2, isPrimaryKeyColumn, principalNavigationProperty);
		dependentTable.ForeignKeyConstraints.Add(dbForeignKeyConstraintMetadata2);
	}

	private void GenerateIndependentForeignKeyColumns(EdmEntityType principalEntityType, EdmEntityType dependentEntityType, DbAssociationSetMapping associationSetMapping, DbAssociationEndMapping associationEndMapping, DbTableMetadata dependentTable, DbForeignKeyConstraintMetadata foreignKeyConstraint, bool isPrimaryKeyColumn, EdmNavigationProperty principalNavigationProperty)
	{
		foreach (EdmProperty item in principalEntityType.KeyProperties())
		{
			DbTableColumnMetadata dbTableColumnMetadata = dependentTable.AddColumn(((principalNavigationProperty != null) ? principalNavigationProperty.Name : principalEntityType.Name) + "_" + item.Name);
			MapTableColumn(item, dbTableColumnMetadata, isInstancePropertyOnDerivedType: false, isPrimaryKeyColumn);
			dbTableColumnMetadata.IsNullable = associationEndMapping.AssociationEnd.IsOptional() || (associationEndMapping.AssociationEnd.IsRequired() && dependentEntityType.BaseType != null);
			dbTableColumnMetadata.StoreGeneratedPattern = DbStoreGeneratedPattern.None;
			foreignKeyConstraint.DependentColumns.Add(dbTableColumnMetadata);
			associationEndMapping.PropertyMappings.Add(new DbEdmPropertyMapping
			{
				Column = dbTableColumnMetadata,
				PropertyPath = new EdmProperty[1] { item }
			});
			if (dbTableColumnMetadata.IsNullable)
			{
				associationSetMapping.ColumnConditions.Add(new DbColumnCondition
				{
					Column = dbTableColumnMetadata,
					IsNull = false
				});
			}
		}
	}
}
