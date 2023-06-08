using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class AssociationMappingOperations
{
	private static void MoveAssociationSetMappingDependents(DbAssociationSetMapping asm, DbAssociationEndMapping dependentMapping, DbTableMetadata fromTable, DbTableMetadata toTable, bool useExistingColumns)
	{
		dependentMapping.PropertyMappings.Each(delegate(DbEdmPropertyMapping pm)
		{
			DbTableColumnMetadata oldColumn = pm.Column;
			pm.Column = TableOperations.MoveColumnAndAnyConstraints(asm.Table, toTable, oldColumn, useExistingColumns);
			asm.ColumnConditions.Where((DbColumnCondition cc) => cc.Column == oldColumn).Each((DbColumnCondition cc) => cc.Column = pm.Column);
		});
		asm.Table = toTable;
	}

	public static void MoveAllDeclaredAssociationSetMappings(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbTableMetadata fromTable, DbTableMetadata toTable, bool useExistingColumns)
	{
		DbAssociationSetMapping[] array = (from a in databaseMapping.EntityContainerMappings.SelectMany((DbEntityContainerMapping asm) => asm.AssociationSetMappings)
			where a.Table == fromTable && (a.AssociationSet.ElementType.SourceEnd.EntityType == entityType || a.AssociationSet.ElementType.TargetEnd.EntityType == entityType)
			select a).ToArray();
		foreach (DbAssociationSetMapping dbAssociationSetMapping in array)
		{
			if (!dbAssociationSetMapping.AssociationSet.ElementType.TryGuessPrincipalAndDependentEnds(out var _, out var dependentEnd))
			{
				dependentEnd = dbAssociationSetMapping.AssociationSet.ElementType.TargetEnd;
			}
			if (dependentEnd.EntityType == entityType)
			{
				DbAssociationEndMapping dependentMapping = ((dependentEnd == dbAssociationSetMapping.TargetEndMapping.AssociationEnd) ? dbAssociationSetMapping.SourceEndMapping : dbAssociationSetMapping.TargetEndMapping);
				MoveAssociationSetMappingDependents(dbAssociationSetMapping, dependentMapping, fromTable, toTable, useExistingColumns);
			}
		}
	}
}
