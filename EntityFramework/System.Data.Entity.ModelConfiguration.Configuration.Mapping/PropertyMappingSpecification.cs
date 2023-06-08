using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db.Mapping;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class PropertyMappingSpecification
{
	private readonly EdmEntityType _entityType;

	private readonly IList<EdmProperty> _propertyPath;

	private readonly IList<DbColumnCondition> _conditions;

	private readonly bool _isDefaultDiscriminatorCondition;

	public EdmEntityType EntityType => _entityType;

	public IList<EdmProperty> PropertyPath => _propertyPath;

	public IList<DbColumnCondition> Conditions => _conditions;

	public bool IsDefaultDiscriminatorCondition => _isDefaultDiscriminatorCondition;

	public PropertyMappingSpecification(EdmEntityType entityType, IList<EdmProperty> propertyPath, IList<DbColumnCondition> conditions, bool isDefaultDiscriminatorCondition)
	{
		_entityType = entityType;
		_propertyPath = propertyPath;
		_conditions = conditions;
		_isDefaultDiscriminatorCondition = isDefaultDiscriminatorCondition;
	}
}
