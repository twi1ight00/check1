using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Edm.Internal;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class EntityMappingService
{
	private readonly DbDatabaseMapping _databaseMapping;

	private Dictionary<DbTableMetadata, TableMapping> _tableMappings;

	private SortedEntityTypeIndex _entityTypes;

	public EntityMappingService(DbDatabaseMapping databaseMapping)
	{
		_databaseMapping = databaseMapping;
	}

	public void Configure()
	{
		Analyze();
		Transform();
	}

	/// <summary>
	///     Populate the table mapping structure
	/// </summary>
	private void Analyze()
	{
		_tableMappings = new Dictionary<DbTableMetadata, TableMapping>();
		_entityTypes = new SortedEntityTypeIndex();
		foreach (DbEntitySetMapping item in _databaseMapping.EntityContainerMappings.SelectMany((DbEntityContainerMapping ecm) => ecm.EntitySetMappings))
		{
			foreach (DbEntityTypeMapping entityTypeMapping in item.EntityTypeMappings)
			{
				_entityTypes.Add(item.EntitySet, entityTypeMapping.EntityType);
				foreach (DbEntityTypeMappingFragment typeMappingFragment in entityTypeMapping.TypeMappingFragments)
				{
					TableMapping tableMapping = FindOrCreateTableMapping(typeMappingFragment.Table);
					tableMapping.AddEntityTypeMappingFragment(item.EntitySet, entityTypeMapping.EntityType, typeMappingFragment);
				}
			}
		}
	}

	private void Transform()
	{
		foreach (EdmEntitySet entitySet in _entityTypes.GetEntitySets())
		{
			Dictionary<TableMapping, Dictionary<EdmEntityType, DbEntityTypeMapping>> dictionary = new Dictionary<TableMapping, Dictionary<EdmEntityType, DbEntityTypeMapping>>();
			EdmEntityType entityType;
			foreach (EdmEntityType entityType2 in _entityTypes.GetEntityTypes(entitySet))
			{
				entityType = entityType2;
				foreach (TableMapping item2 in _tableMappings.Values.Where((TableMapping tm) => tm.EntityTypes.Contains(entitySet, entityType)))
				{
					if (!dictionary.TryGetValue(item2, out var value))
					{
						value = new Dictionary<EdmEntityType, DbEntityTypeMapping>();
						dictionary.Add(item2, value);
					}
					RemoveRedundantDefaultDiscriminators(item2);
					bool isRoot = item2.EntityTypes.IsRoot(entitySet, entityType);
					bool flag = DetermineRequiresIsTypeOf(item2, entitySet, entityType);
					bool flag2 = false;
					if (!FindPropertyEntityTypeMapping(item2, entitySet, entityType, flag, out var propertiesTypeMapping, out var propertiesTypeMappingFragment))
					{
						continue;
					}
					flag2 = DetermineRequiresSplitEntityTypeMapping(item2, entityType, isRoot, flag, propertiesTypeMapping);
					DbEntityTypeMapping dbEntityTypeMapping = FindConditionTypeMapping(entityType, flag2, propertiesTypeMapping);
					DbEntityTypeMappingFragment dbEntityTypeMappingFragment = FindConditionTypeMappingFragment(item2, propertiesTypeMappingFragment, dbEntityTypeMapping);
					if (flag)
					{
						if (!propertiesTypeMapping.IsHierarchyMapping)
						{
							DbEntityTypeMapping dbEntityTypeMapping2 = _databaseMapping.GetEntityTypeMappings(entityType).SingleOrDefault((DbEntityTypeMapping etm) => etm.IsHierarchyMapping);
							if (dbEntityTypeMapping2 == null)
							{
								if (propertiesTypeMapping.TypeMappingFragments.Count > 1)
								{
									DbEntityTypeMapping dbEntityTypeMapping3 = propertiesTypeMapping.Clone();
									DbEntitySetMapping dbEntitySetMapping = _databaseMapping.GetEntitySetMappings().Single((DbEntitySetMapping esm) => esm.EntityTypeMappings.Contains(propertiesTypeMapping));
									dbEntitySetMapping.EntityTypeMappings.Add(dbEntityTypeMapping3);
									DbEntityTypeMappingFragment[] array = propertiesTypeMapping.TypeMappingFragments.Where((DbEntityTypeMappingFragment tmf) => tmf != propertiesTypeMappingFragment).ToArray();
									foreach (DbEntityTypeMappingFragment item in array)
									{
										propertiesTypeMapping.TypeMappingFragments.Remove(item);
										dbEntityTypeMapping3.TypeMappingFragments.Add(item);
									}
								}
								propertiesTypeMapping.IsHierarchyMapping = true;
							}
							else
							{
								propertiesTypeMapping.TypeMappingFragments.Remove(propertiesTypeMappingFragment);
								if (propertiesTypeMapping.TypeMappingFragments.Count == 0)
								{
									_databaseMapping.GetEntitySetMapping(entitySet).EntityTypeMappings.Remove(propertiesTypeMapping);
								}
								propertiesTypeMapping = dbEntityTypeMapping2;
								propertiesTypeMapping.TypeMappingFragments.Add(propertiesTypeMappingFragment);
							}
						}
						value.Add(entityType, propertiesTypeMapping);
					}
					ConfigureTypeMappings(item2, value, entityType, propertiesTypeMappingFragment, dbEntityTypeMappingFragment);
					if (propertiesTypeMappingFragment.IsUnmappedPropertiesFragment() && propertiesTypeMappingFragment.PropertyMappings.All((DbEdmPropertyMapping pm) => entityType.GetKeyProperties().Contains(pm.PropertyPath.First())))
					{
						RemoveFragment(entitySet, propertiesTypeMapping, propertiesTypeMappingFragment);
						if (flag2 && dbEntityTypeMappingFragment.PropertyMappings.All((DbEdmPropertyMapping pm) => entityType.GetKeyProperties().Contains(pm.PropertyPath.First())))
						{
							RemoveFragment(entitySet, dbEntityTypeMapping, dbEntityTypeMappingFragment);
						}
					}
					EntityMappingConfiguration.CleanupUnmappedArtifacts(_databaseMapping, item2.Table);
				}
			}
			ConfigureAssociationSetMappingForeignKeys(entitySet);
		}
	}

	/// <summary>
	///     Sets nullability for association set mappings' foreign keys for 1:* and 1:0..1 associations
	///     when no base types share the the association set mapping's table
	/// </summary>
	private void ConfigureAssociationSetMappingForeignKeys(EdmEntitySet entitySet)
	{
		foreach (DbAssociationSetMapping item in from asm in _databaseMapping.EntityContainerMappings.SelectMany((DbEntityContainerMapping ecm) => ecm.AssociationSetMappings)
			where (asm.AssociationSet.SourceSet == entitySet || asm.AssociationSet.TargetSet == entitySet) && asm.AssociationSet.ElementType.IsRequiredToNonRequired()
			select asm)
		{
			item.AssociationSet.ElementType.TryGuessPrincipalAndDependentEnds(out var _, out var dependentEnd);
			if ((dependentEnd != item.AssociationSet.ElementType.SourceEnd || item.AssociationSet.SourceSet != entitySet) && (dependentEnd != item.AssociationSet.ElementType.TargetEnd || item.AssociationSet.TargetSet != entitySet))
			{
				continue;
			}
			DbAssociationEndMapping dbAssociationEndMapping = ((item.SourceEndMapping.AssociationEnd == dependentEnd) ? item.TargetEndMapping : item.SourceEndMapping);
			IEnumerable<EdmEntityType> source = from et in _tableMappings[item.Table].EntityTypes.GetEntityTypes(entitySet)
				where et != dependentEnd.EntityType && (et.IsAncestorOf(dependentEnd.EntityType) || !dependentEnd.EntityType.IsAncestorOf(et))
				select et;
			if (source.Count() == 0 || source.All((EdmEntityType et) => et.IsAbstract))
			{
				dbAssociationEndMapping.PropertyMappings.Each((DbEdmPropertyMapping pm) => pm.Column.IsNullable = false);
			}
		}
	}

	/// <summary>
	///     Makes sure only the required property mappings are present
	/// </summary>
	private void ConfigureTypeMappings(TableMapping tableMapping, Dictionary<EdmEntityType, DbEntityTypeMapping> rootMappings, EdmEntityType entityType, DbEntityTypeMappingFragment propertiesTypeMappingFragment, DbEntityTypeMappingFragment conditionTypeMappingFragment)
	{
		List<DbEdmPropertyMapping> list = new List<DbEdmPropertyMapping>(propertiesTypeMappingFragment.PropertyMappings.Where((DbEdmPropertyMapping pm) => !pm.Column.IsPrimaryKeyColumn));
		List<DbColumnCondition> list2 = new List<DbColumnCondition>(propertiesTypeMappingFragment.ColumnConditions);
		_003C_003Ef__AnonymousType9<DbTableColumnMetadata, PropertyMappingSpecification> columnMapping;
		foreach (var item in from cm in tableMapping.ColumnMappings
			from pm in cm.PropertyMappings
			where pm.EntityType == entityType
			select new
			{
				Column = cm.Column,
				Property = pm
			})
		{
			columnMapping = item;
			if (columnMapping.Property.PropertyPath != null && !IsRootTypeMapping(rootMappings, columnMapping.Property.EntityType, columnMapping.Property.PropertyPath))
			{
				DbEdmPropertyMapping dbEdmPropertyMapping = propertiesTypeMappingFragment.PropertyMappings.SingleOrDefault((DbEdmPropertyMapping x) => x.PropertyPath == columnMapping.Property.PropertyPath);
				if (dbEdmPropertyMapping != null)
				{
					list.Remove(dbEdmPropertyMapping);
				}
				else
				{
					DbEdmPropertyMapping dbEdmPropertyMapping2 = new DbEdmPropertyMapping();
					dbEdmPropertyMapping2.Column = columnMapping.Column;
					dbEdmPropertyMapping2.PropertyPath = columnMapping.Property.PropertyPath;
					dbEdmPropertyMapping = dbEdmPropertyMapping2;
					propertiesTypeMappingFragment.PropertyMappings.Add(dbEdmPropertyMapping);
				}
			}
			if (columnMapping.Property.Conditions == null)
			{
				continue;
			}
			foreach (DbColumnCondition condition in columnMapping.Property.Conditions)
			{
				if (conditionTypeMappingFragment.ColumnConditions.Contains(condition))
				{
					list2.Remove(condition);
				}
				else if (!entityType.IsAbstract)
				{
					conditionTypeMappingFragment.ColumnConditions.Add(condition);
				}
			}
		}
		foreach (DbEdmPropertyMapping item2 in list)
		{
			propertiesTypeMappingFragment.PropertyMappings.Remove(item2);
		}
		foreach (DbColumnCondition item3 in list2)
		{
			conditionTypeMappingFragment.ColumnConditions.Remove(item3);
		}
		if (entityType.IsAbstract)
		{
			propertiesTypeMappingFragment.ColumnConditions.Clear();
		}
	}

	private static DbEntityTypeMappingFragment FindConditionTypeMappingFragment(TableMapping tableMapping, DbEntityTypeMappingFragment propertiesTypeMappingFragment, DbEntityTypeMapping conditionTypeMapping)
	{
		DbEntityTypeMappingFragment dbEntityTypeMappingFragment = conditionTypeMapping.TypeMappingFragments.SingleOrDefault((DbEntityTypeMappingFragment x) => x.Table == tableMapping.Table);
		if (dbEntityTypeMappingFragment == null)
		{
			dbEntityTypeMappingFragment = EntityMappingOperations.CreateTypeMappingFragment(conditionTypeMapping, propertiesTypeMappingFragment, tableMapping.Table);
			dbEntityTypeMappingFragment.SetIsConditionOnlyFragment(isConditionOnlyFragment: true);
			if (propertiesTypeMappingFragment.GetDefaultDiscriminator() != null)
			{
				dbEntityTypeMappingFragment.SetDefaultDiscriminator(propertiesTypeMappingFragment.GetDefaultDiscriminator());
				propertiesTypeMappingFragment.RemoveDefaultDiscriminatorAnnotation();
			}
		}
		return dbEntityTypeMappingFragment;
	}

	private DbEntityTypeMapping FindConditionTypeMapping(EdmEntityType entityType, bool requiresSplit, DbEntityTypeMapping propertiesTypeMapping)
	{
		DbEntityTypeMapping dbEntityTypeMapping = propertiesTypeMapping;
		if (requiresSplit)
		{
			if (!entityType.IsAbstract)
			{
				dbEntityTypeMapping = propertiesTypeMapping.Clone();
				dbEntityTypeMapping.IsHierarchyMapping = false;
				DbEntitySetMapping dbEntitySetMapping = _databaseMapping.GetEntitySetMappings().Single((DbEntitySetMapping esm) => esm.EntityTypeMappings.Contains(propertiesTypeMapping));
				dbEntitySetMapping.EntityTypeMappings.Add(dbEntityTypeMapping);
			}
			propertiesTypeMapping.TypeMappingFragments.Each(delegate(DbEntityTypeMappingFragment tmf)
			{
				tmf.ColumnConditions.Clear();
			});
		}
		return dbEntityTypeMapping;
	}

	private bool DetermineRequiresIsTypeOf(TableMapping tableMapping, EdmEntitySet entitySet, EdmEntityType entityType)
	{
		if (entityType.IsRootOfSet(tableMapping.EntityTypes.GetEntityTypes(entitySet)))
		{
			if (!tableMapping.ColumnMappings.Any((ColumnMapping cm) => cm.PropertyMappings.Any((PropertyMappingSpecification pm) => pm.EntityType == entityType) && cm.PropertyMappings.Any((PropertyMappingSpecification pm) => entityType.IsAncestorOf(pm.EntityType))))
			{
				return _tableMappings.Values.Any((TableMapping tm) => tm != tableMapping && tm.Table.ForeignKeyConstraints.Any((DbForeignKeyConstraintMetadata fk) => fk.GetIsTypeConstraint() && fk.PrincipalTable == tableMapping.Table));
			}
			return true;
		}
		return false;
	}

	private bool DetermineRequiresSplitEntityTypeMapping(TableMapping tableMapping, EdmEntityType entityType, bool isRoot, bool requiresIsTypeOf, DbEntityTypeMapping propertiesTypeMapping)
	{
		if (requiresIsTypeOf)
		{
			return HasConditions(tableMapping, entityType);
		}
		return false;
	}

	/// <summary>
	///     Determines if the table and entity type need mapping, and if not, removes the existing entity type mapping
	/// </summary>
	private bool FindPropertyEntityTypeMapping(TableMapping tableMapping, EdmEntitySet entitySet, EdmEntityType entityType, bool requiresIsTypeOf, out DbEntityTypeMapping entityTypeMapping, out DbEntityTypeMappingFragment fragment)
	{
		entityTypeMapping = null;
		fragment = null;
		var anon = (from etm in _databaseMapping.GetEntityTypeMappings(entityType)
			from tmf in etm.TypeMappingFragments
			where tmf.Table == tableMapping.Table
			select new
			{
				TypeMapping = etm,
				Fragment = tmf
			}).SingleOrDefault();
		if (anon != null)
		{
			entityTypeMapping = anon.TypeMapping;
			fragment = anon.Fragment;
			if (!requiresIsTypeOf && entityType.IsAbstract)
			{
				RemoveFragment(entitySet, anon.TypeMapping, anon.Fragment);
				return false;
			}
			return true;
		}
		return false;
	}

	private void RemoveFragment(EdmEntitySet entitySet, DbEntityTypeMapping entityTypeMapping, DbEntityTypeMappingFragment fragment)
	{
		DbTableColumnMetadata defaultDiscriminator = fragment.GetDefaultDiscriminator();
		if (defaultDiscriminator != null && entityTypeMapping.EntityType.BaseType != null)
		{
			ColumnMapping columnMapping = _tableMappings[fragment.Table].ColumnMappings.SingleOrDefault((ColumnMapping cm) => cm.Column == defaultDiscriminator);
			if (columnMapping != null)
			{
				PropertyMappingSpecification propertyMappingSpecification = columnMapping.PropertyMappings.SingleOrDefault((PropertyMappingSpecification pm) => pm.EntityType == entityTypeMapping.EntityType);
				if (propertyMappingSpecification != null)
				{
					columnMapping.PropertyMappings.Remove(propertyMappingSpecification);
				}
			}
			defaultDiscriminator.IsNullable = true;
		}
		entityTypeMapping.TypeMappingFragments.Remove(fragment);
		if (!entityTypeMapping.TypeMappingFragments.Any())
		{
			_databaseMapping.GetEntitySetMapping(entitySet).EntityTypeMappings.Remove(entityTypeMapping);
		}
	}

	private void RemoveRedundantDefaultDiscriminators(TableMapping tableMapping)
	{
		EdmEntitySet entitySet;
		foreach (EdmEntitySet entitySet2 in tableMapping.EntityTypes.GetEntitySets())
		{
			entitySet = entitySet2;
			(from cm in tableMapping.ColumnMappings
				from pm in cm.PropertyMappings
				where cm.PropertyMappings.Where((PropertyMappingSpecification pm1) => tableMapping.EntityTypes.GetEntityTypes(entitySet).Contains(pm1.EntityType)).Count((PropertyMappingSpecification pms) => pms.IsDefaultDiscriminatorCondition) == 1
				select new
				{
					ColumnMapping = cm,
					PropertyMapping = pm
				}).ToArray().Each(x =>
			{
				x.PropertyMapping.Conditions.Clear();
				if (x.PropertyMapping.PropertyPath == null)
				{
					x.ColumnMapping.PropertyMappings.Remove(x.PropertyMapping);
				}
			});
		}
	}

	private bool HasConditions(TableMapping tableMapping, EdmEntityType entityType)
	{
		return tableMapping.ColumnMappings.SelectMany((ColumnMapping cm) => cm.PropertyMappings).Any((PropertyMappingSpecification pm) => pm.EntityType == entityType && pm.Conditions.Count > 0);
	}

	private bool IsRootTypeMapping(Dictionary<EdmEntityType, DbEntityTypeMapping> rootMappings, EdmEntityType entityType, IList<EdmProperty> propertyPath)
	{
		for (EdmEntityType baseType = entityType.BaseType; baseType != null; baseType = baseType.BaseType)
		{
			if (rootMappings.TryGetValue(baseType, out var value))
			{
				return value.TypeMappingFragments.SelectMany((DbEntityTypeMappingFragment etmf) => etmf.PropertyMappings).Any((DbEdmPropertyMapping pm) => pm.PropertyPath.SequenceEqual(propertyPath));
			}
		}
		return false;
	}

	private TableMapping FindOrCreateTableMapping(DbTableMetadata table)
	{
		if (!_tableMappings.TryGetValue(table, out var value))
		{
			value = new TableMapping(table);
			_tableMappings.Add(table, value);
		}
		return value;
	}
}
