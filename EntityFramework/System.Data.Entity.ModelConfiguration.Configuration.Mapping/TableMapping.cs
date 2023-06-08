using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Diagnostics;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

[DebuggerDisplay("{Table.Name}")]
internal class TableMapping
{
	private readonly DbTableMetadata _table;

	private readonly SortedEntityTypeIndex _entityTypes;

	private readonly List<ColumnMapping> _columns;

	public DbTableMetadata Table => _table;

	public SortedEntityTypeIndex EntityTypes => _entityTypes;

	public IEnumerable<ColumnMapping> ColumnMappings => _columns;

	public TableMapping(DbTableMetadata table)
	{
		_table = table;
		_entityTypes = new SortedEntityTypeIndex();
		_columns = new List<ColumnMapping>();
	}

	public void AddEntityTypeMappingFragment(EdmEntitySet entitySet, EdmEntityType entityType, DbEntityTypeMappingFragment fragment)
	{
		_entityTypes.Add(entitySet, entityType);
		DbTableColumnMetadata defaultDiscriminatorColumn = fragment.GetDefaultDiscriminator();
		if (defaultDiscriminatorColumn != null)
		{
			fragment.ColumnConditions.SingleOrDefault((DbColumnCondition cc) => cc.Column == defaultDiscriminatorColumn);
		}
		DbEdmPropertyMapping pm2;
		foreach (DbEdmPropertyMapping propertyMapping in fragment.PropertyMappings)
		{
			pm2 = propertyMapping;
			ColumnMapping columnMapping = FindOrCreateColumnMapping(pm2.Column);
			columnMapping.AddMapping(entityType, pm2.PropertyPath, fragment.ColumnConditions.Where((DbColumnCondition cc) => cc.Column == pm2.Column), defaultDiscriminatorColumn == pm2.Column);
		}
		foreach (DbColumnCondition item in fragment.ColumnConditions.Where((DbColumnCondition cc) => !fragment.PropertyMappings.Any((DbEdmPropertyMapping pm) => pm.Column == cc.Column)))
		{
			ColumnMapping columnMapping2 = FindOrCreateColumnMapping(item.Column);
			columnMapping2.AddMapping(entityType, null, new DbColumnCondition[1] { item }, defaultDiscriminatorColumn == item.Column);
		}
	}

	private ColumnMapping FindOrCreateColumnMapping(DbTableColumnMetadata column)
	{
		ColumnMapping columnMapping = _columns.SingleOrDefault((ColumnMapping c) => c.Column == column);
		if (columnMapping == null)
		{
			columnMapping = new ColumnMapping(column);
			_columns.Add(columnMapping);
		}
		return columnMapping;
	}
}
