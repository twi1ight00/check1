using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Edm;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class SortedEntityTypeIndex
{
	private static readonly EdmEntityType[] EmptyTypes = new EdmEntityType[0];

	private readonly Dictionary<EdmEntitySet, List<EdmEntityType>> _entityTypes;

	public SortedEntityTypeIndex()
	{
		_entityTypes = new Dictionary<EdmEntitySet, List<EdmEntityType>>();
	}

	public void Add(EdmEntitySet entitySet, EdmEntityType entityType)
	{
		int i = 0;
		if (!_entityTypes.TryGetValue(entitySet, out var value))
		{
			value = new List<EdmEntityType>();
			_entityTypes.Add(entitySet, value);
		}
		for (; i < value.Count; i++)
		{
			if (value[i] == entityType)
			{
				return;
			}
			if (entityType.IsAncestorOf(value[i]))
			{
				break;
			}
		}
		value.Insert(i, entityType);
	}

	public bool Contains(EdmEntitySet entitySet, EdmEntityType entityType)
	{
		if (_entityTypes.TryGetValue(entitySet, out var value))
		{
			return value.Contains(entityType);
		}
		return false;
	}

	public bool IsRoot(EdmEntitySet entitySet, EdmEntityType entityType)
	{
		bool result = true;
		List<EdmEntityType> list = _entityTypes[entitySet];
		foreach (EdmEntityType item in list)
		{
			if (item != entityType && item.IsAncestorOf(entityType))
			{
				result = false;
			}
		}
		return result;
	}

	public IEnumerable<EdmEntitySet> GetEntitySets()
	{
		return _entityTypes.Keys;
	}

	public IEnumerable<EdmEntityType> GetEntityTypes(EdmEntitySet entitySet)
	{
		if (_entityTypes.TryGetValue(entitySet, out var value))
		{
			return value;
		}
		return EmptyTypes;
	}
}
