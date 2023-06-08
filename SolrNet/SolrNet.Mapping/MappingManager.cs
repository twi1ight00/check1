using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SolrNet.Mapping;

/// <summary>
/// Manual mapping manager
/// </summary>
public class MappingManager : IMappingManager, IReadOnlyMappingManager
{
	private readonly IDictionary<Type, Dictionary<string, SolrFieldModel>> mappings = new Dictionary<Type, Dictionary<string, SolrFieldModel>>();

	private readonly IDictionary<Type, SolrFieldModel> uniqueKeys = new Dictionary<Type, SolrFieldModel>();

	public void Add(PropertyInfo property)
	{
		if (property == null)
		{
			throw new ArgumentNullException("property");
		}
		Add(property, property.Name);
	}

	public void Add(PropertyInfo property, string fieldName)
	{
		if (property == null)
		{
			throw new ArgumentNullException("property");
		}
		if (fieldName == null)
		{
			throw new ArgumentNullException("fieldName");
		}
		Add(property, fieldName, null);
	}

	public void Add(PropertyInfo property, string fieldName, float? boost)
	{
		if (property == null)
		{
			throw new ArgumentNullException("property");
		}
		if (fieldName == null)
		{
			throw new ArgumentNullException("fieldName");
		}
		Type declaringType = property.DeclaringType ?? property.ReflectedType;
		Dictionary<string, SolrFieldModel> solrFieldDict;
		if (!mappings.ContainsKey(declaringType))
		{
			solrFieldDict = new Dictionary<string, SolrFieldModel>();
			mappings[declaringType] = solrFieldDict;
		}
		else
		{
			solrFieldDict = mappings[declaringType];
		}
		KeyValuePair<string, SolrFieldModel> i = solrFieldDict.FirstOrDefault((KeyValuePair<string, SolrFieldModel> k) => k.Value.Property == property);
		if (i.Key != null)
		{
			solrFieldDict.Remove(i.Key);
		}
		SolrFieldModel fld = new SolrFieldModel(property, fieldName, boost);
		solrFieldDict[fieldName] = fld;
	}

	/// <summary>
	/// Gets all the SolrFieldModels mapped for this type
	/// </summary>
	/// <param name="type">Document type</param>
	/// <returns>Null if <paramref name="type" /> is not mapped</returns>
	public IDictionary<string, SolrFieldModel> GetFields(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		return mappings.Where((KeyValuePair<Type, Dictionary<string, SolrFieldModel>> m) => m.Key.IsAssignableFrom(type)).SelectMany((KeyValuePair<Type, Dictionary<string, SolrFieldModel>> kvp) => kvp.Value).ToDictionary((KeyValuePair<string, SolrFieldModel> pair) => pair.Key, (KeyValuePair<string, SolrFieldModel> pair) => pair.Value);
	}

	public void SetUniqueKey(PropertyInfo property)
	{
		if (property == null)
		{
			throw new ArgumentNullException("property");
		}
		Type declaringType = property.DeclaringType ?? property.ReflectedType;
		if (!mappings.ContainsKey(declaringType))
		{
			throw new ArgumentException($"Property '{declaringType}.{property.Name}' not mapped. Please use Add() to map it first");
		}
		Dictionary<string, SolrFieldModel> solrFieldDict = mappings[declaringType];
		SolrFieldModel theSolrFieldModel = (from kvp in solrFieldDict
			where kvp.Value.Property == property
			select kvp.Value).FirstOrDefault();
		if (theSolrFieldModel == null)
		{
			throw new ArgumentException($"Property '{declaringType}.{property.Name}' not mapped. Please use Add() to map it first");
		}
		uniqueKeys[declaringType] = theSolrFieldModel;
	}

	public SolrFieldModel GetUniqueKey(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		return (from k in uniqueKeys
			where k.Key.IsAssignableFrom(type)
			select k into x
			select x.Value).FirstOrDefault();
	}

	public ICollection<Type> GetRegisteredTypes()
	{
		return mappings.Select((KeyValuePair<Type, Dictionary<string, SolrFieldModel>> k) => k.Key).ToList();
	}
}
