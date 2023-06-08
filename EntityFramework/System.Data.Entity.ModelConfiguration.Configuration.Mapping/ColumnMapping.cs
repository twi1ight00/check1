using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Diagnostics;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

[DebuggerDisplay("{Column.Name}")]
internal class ColumnMapping
{
	private readonly DbTableColumnMetadata _column;

	private readonly List<PropertyMappingSpecification> _propertyMappings;

	public DbTableColumnMetadata Column => _column;

	public IList<PropertyMappingSpecification> PropertyMappings => _propertyMappings;

	public ColumnMapping(DbTableColumnMetadata column)
	{
		_column = column;
		_propertyMappings = new List<PropertyMappingSpecification>();
	}

	public void AddMapping(EdmEntityType entityType, IList<EdmProperty> propertyPath, IEnumerable<DbColumnCondition> conditions, bool isDefaultDiscriminatorCondition)
	{
		_propertyMappings.Add(new PropertyMappingSpecification(entityType, propertyPath, conditions.ToList(), isDefaultDiscriminatorCondition));
	}
}
