using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class ForeignKeyPrimitiveOperations
{
	public static void UpdatePrincipalTables(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbTableMetadata fromTable, DbTableMetadata toTable, bool removeFks)
	{
		if (fromTable == toTable)
		{
			return;
		}
		List<EdmEntityType> entityTypes = new List<EdmEntityType> { entityType };
		if (removeFks)
		{
			entityTypes.Add(entityType.BaseType);
		}
		EdmAssociationType associationType;
		foreach (EdmAssociationType item in databaseMapping.Model.Namespaces.Single().AssociationTypes.Where((EdmAssociationType at) => entityTypes.Contains(at.SourceEnd.EntityType) || entityTypes.Contains(at.TargetEnd.EntityType)))
		{
			associationType = item;
			foreach (EdmEntityType item2 in entityTypes.Where((EdmEntityType e) => associationType.SourceEnd.EntityType == e || associationType.TargetEnd.EntityType == e))
			{
				UpdatePrincipalTables(databaseMapping, toTable, removeFks, associationType, item2);
			}
		}
	}

	private static void UpdatePrincipalTables(DbDatabaseMapping databaseMapping, DbTableMetadata toTable, bool removeFks, EdmAssociationType associationType, EdmEntityType et)
	{
		List<EdmAssociationEnd> list = new List<EdmAssociationEnd>();
		if (associationType.TryGuessPrincipalAndDependentEnds(out var principalEnd, out var _))
		{
			list.Add(principalEnd);
		}
		else if (associationType.SourceEnd.EndKind == EdmAssociationEndKind.Many && associationType.TargetEnd.EndKind == EdmAssociationEndKind.Many)
		{
			list.Add(associationType.SourceEnd);
			list.Add(associationType.TargetEnd);
		}
		else
		{
			list.Add(associationType.SourceEnd);
		}
		foreach (EdmAssociationEnd item in list)
		{
			if (item.EntityType != et)
			{
				continue;
			}
			IEnumerable<DbTableColumnMetadata> dependentColumns = null;
			DbTableMetadata table;
			if (associationType.Constraint != null)
			{
				EdmEntityType entityType = associationType.GetOtherEnd(item).EntityType;
				DbEntityTypeMapping entityTypeMapping = databaseMapping.GetEntityTypeMapping(entityType);
				if (entityTypeMapping == null)
				{
					EdmEntityType entityType2 = databaseMapping.Model.GetDerivedTypes(entityType).First((EdmEntityType dt) => !dt.IsAbstract);
					entityTypeMapping = databaseMapping.GetEntityTypeMapping(entityType2);
				}
				DbEntityTypeMappingFragment dbEntityTypeMappingFragment = entityTypeMapping.TypeMappingFragments.Where((DbEntityTypeMappingFragment tmf) => associationType.Constraint.DependentProperties.All((EdmProperty p) => tmf.PropertyMappings.Any((DbEdmPropertyMapping pm) => pm.PropertyPath.First() == p))).First();
				table = dbEntityTypeMappingFragment.Table;
				dependentColumns = from pm in dbEntityTypeMappingFragment.PropertyMappings
					where associationType.Constraint.DependentProperties.Contains(pm.PropertyPath.First())
					select pm.Column;
			}
			else
			{
				DbAssociationSetMapping dbAssociationSetMapping = databaseMapping.EntityContainerMappings.Single().AssociationSetMappings.Where((DbAssociationSetMapping asm) => asm.AssociationSet.ElementType == associationType).Single();
				table = dbAssociationSetMapping.Table;
				IList<DbEdmPropertyMapping> source = ((dbAssociationSetMapping.SourceEndMapping.AssociationEnd == item) ? dbAssociationSetMapping.SourceEndMapping.PropertyMappings : dbAssociationSetMapping.TargetEndMapping.PropertyMappings);
				dependentColumns = source.Select((DbEdmPropertyMapping pm) => pm.Column);
			}
			DbForeignKeyConstraintMetadata[] array = table.ForeignKeyConstraints.Where((DbForeignKeyConstraintMetadata fk) => fk.DependentColumns.SequenceEqual(dependentColumns)).ToArray();
			foreach (DbForeignKeyConstraintMetadata dbForeignKeyConstraintMetadata in array)
			{
				if (removeFks)
				{
					table.ForeignKeyConstraints.Remove(dbForeignKeyConstraintMetadata);
				}
				else
				{
					dbForeignKeyConstraintMetadata.PrincipalTable = toTable;
				}
			}
		}
	}

	/// <summary>
	///     Moves a foreign key constraint from oldTable to newTable and updates column references
	/// </summary>
	private static void MoveForeignKeyConstraint(DbTableMetadata fromTable, DbTableMetadata toTable, DbForeignKeyConstraintMetadata fk)
	{
		fromTable.ForeignKeyConstraints.Remove(fk);
		if (fk.PrincipalTable != toTable || !fk.DependentColumns.All((DbTableColumnMetadata c) => c.IsPrimaryKeyColumn))
		{
			DbTableColumnMetadata[] sourceColumns = fk.DependentColumns.ToArray();
			fk.DependentColumns.Clear();
			SetAllDependentColumns(fk, sourceColumns, toTable.Columns);
			if (!toTable.ContainsEquivalentForeignKey(fk))
			{
				toTable.ForeignKeyConstraints.Add(fk);
			}
		}
	}

	private static void CopyForeignKeyConstraint(DbDatabaseMetadata database, DbTableMetadata fromTable, DbTableMetadata toTable, DbForeignKeyConstraintMetadata fk)
	{
		DbForeignKeyConstraintMetadata dbForeignKeyConstraintMetadata = new DbForeignKeyConstraintMetadata();
		dbForeignKeyConstraintMetadata.DeleteAction = fk.DeleteAction;
		dbForeignKeyConstraintMetadata.Name = database.Schemas.Single().Tables.SelectMany((DbTableMetadata t) => t.ForeignKeyConstraints).UniquifyName(fk.Name);
		dbForeignKeyConstraintMetadata.PrincipalTable = fk.PrincipalTable;
		DbForeignKeyConstraintMetadata dbForeignKeyConstraintMetadata2 = dbForeignKeyConstraintMetadata;
		SetAllDependentColumns(dbForeignKeyConstraintMetadata2, fk.DependentColumns, toTable.Columns);
		if (!toTable.ContainsEquivalentForeignKey(dbForeignKeyConstraintMetadata2))
		{
			toTable.ForeignKeyConstraints.Add(dbForeignKeyConstraintMetadata2);
		}
	}

	private static void SetAllDependentColumns(DbForeignKeyConstraintMetadata fk, IEnumerable<DbTableColumnMetadata> sourceColumns, IEnumerable<DbTableColumnMetadata> destinationColumns)
	{
		DbTableColumnMetadata dc;
		foreach (DbTableColumnMetadata sourceColumn in sourceColumns)
		{
			dc = sourceColumn;
			fk.DependentColumns.Add(destinationColumns.Single((DbTableColumnMetadata c) => string.Equals(c.Name, dc.Name, StringComparison.Ordinal) || string.Equals(c.GetUnpreferredUniqueName(), dc.Name, StringComparison.Ordinal)));
		}
	}

	private static IEnumerable<DbForeignKeyConstraintMetadata> FindAllForeignKeyConstraintsForColumn(DbTableMetadata fromTable, DbTableMetadata toTable, DbTableColumnMetadata column)
	{
		return fromTable.ForeignKeyConstraints.Where((DbForeignKeyConstraintMetadata fk) => fk.DependentColumns.Contains(column) && fk.DependentColumns.All((DbTableColumnMetadata c) => toTable.Columns.Any((DbTableColumnMetadata nc) => string.Equals(nc.Name, c.Name, StringComparison.Ordinal) || string.Equals(nc.GetUnpreferredUniqueName(), c.Name, StringComparison.Ordinal))));
	}

	public static void CopyAllForeignKeyConstraintsForColumn(DbDatabaseMetadata database, DbTableMetadata fromTable, DbTableMetadata toTable, DbTableColumnMetadata column)
	{
		FindAllForeignKeyConstraintsForColumn(fromTable, toTable, column).ToArray().Each(delegate(DbForeignKeyConstraintMetadata fk)
		{
			CopyForeignKeyConstraint(database, fromTable, toTable, fk);
		});
	}

	public static void MoveAllDeclaredForeignKeyConstraintsForPrimaryKeyColumns(EdmEntityType entityType, DbTableMetadata fromTable, DbTableMetadata toTable)
	{
		foreach (DbTableColumnMetadata keyColumn in fromTable.KeyColumns)
		{
			FindAllForeignKeyConstraintsForColumn(fromTable, toTable, keyColumn).ToArray().Each(delegate(DbForeignKeyConstraintMetadata fk)
			{
				EdmAssociationType associationType = fk.GetAssociationType();
				if (associationType != null && associationType.Constraint.DependentEnd.EntityType == entityType && !fk.GetIsTypeConstraint())
				{
					MoveForeignKeyConstraint(fromTable, toTable, fk);
				}
			});
		}
	}

	public static void CopyAllForeignKeyConstraintsForPrimaryKeyColumns(DbDatabaseMetadata database, DbTableMetadata fromTable, DbTableMetadata toTable)
	{
		foreach (DbTableColumnMetadata keyColumn in fromTable.KeyColumns)
		{
			FindAllForeignKeyConstraintsForColumn(fromTable, toTable, keyColumn).ToArray().Each(delegate(DbForeignKeyConstraintMetadata fk)
			{
				if (!fk.GetIsTypeConstraint())
				{
					CopyForeignKeyConstraint(database, fromTable, toTable, fk);
				}
			});
		}
	}

	/// <summary>
	///     Move any FK constraints that are now completely in newTable and used to refer to oldColumn
	/// </summary>
	public static void MoveAllForeignKeyConstraintsForColumn(DbTableMetadata fromTable, DbTableMetadata toTable, DbTableColumnMetadata column)
	{
		FindAllForeignKeyConstraintsForColumn(fromTable, toTable, column).ToArray().Each(delegate(DbForeignKeyConstraintMetadata fk)
		{
			MoveForeignKeyConstraint(fromTable, toTable, fk);
		});
	}

	public static void RemoveAllForeignKeyConstraintsForColumn(DbTableMetadata table, DbTableColumnMetadata column)
	{
		table.ForeignKeyConstraints.Where((DbForeignKeyConstraintMetadata fk) => fk.DependentColumns.Contains(column)).ToArray().Each((DbForeignKeyConstraintMetadata fk) => table.ForeignKeyConstraints.Remove(fk));
	}
}
