using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SolrNet.Mapping;

/// <summary>
/// Maps all properties in the class, with the same field name as the property.
/// Note that unique keys must be added manually.
/// </summary>
public class AllPropertiesMappingManager : IReadOnlyMappingManager
{
	private readonly IDictionary<Type, PropertyInfo> uniqueKeys = new Dictionary<Type, PropertyInfo>();

	public IDictionary<string, SolrFieldModel> GetFields(Type type)
	{
		PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
		return (from prop in props
			select new SolrFieldModel(prop, prop.Name) into m
			select new KeyValuePair<string, SolrFieldModel>(m.FieldName, m)).ToDictionary((KeyValuePair<string, SolrFieldModel> kv) => kv.Key, (KeyValuePair<string, SolrFieldModel> kv) => kv.Value);
	}

	public SolrFieldModel GetUniqueKey(Type type)
	{
		try
		{
			PropertyInfo propertyInfo = uniqueKeys[type];
			return new SolrFieldModel(propertyInfo, propertyInfo.Name);
		}
		catch (KeyNotFoundException)
		{
			return null;
		}
	}

	public ICollection<Type> GetRegisteredTypes()
	{
		return new List<Type>();
	}

	/// <summary>
	/// Sets the property that acts as unique key for a document type
	/// </summary>
	/// <param name="property">Unique key property</param>
	public void SetUniqueKey(PropertyInfo property)
	{
		if (property == null)
		{
			throw new ArgumentNullException("property");
		}
		Type t = property.ReflectedType;
		uniqueKeys[t] = property;
	}
}
