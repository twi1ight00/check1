using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SolrNet.Attributes;

namespace SolrNet.Mapping;

/// <summary>
/// Gets mapping info from attributes like <see cref="T:SolrNet.Attributes.SolrFieldAttribute" /> and <see cref="T:SolrNet.Attributes.SolrUniqueKeyAttribute" />
/// </summary>
public class AttributesMappingManager : IReadOnlyMappingManager
{
	public virtual IEnumerable<KeyValuePair<PropertyInfo, T[]>> GetPropertiesWithAttribute<T>(Type type) where T : Attribute
	{
		PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
		IEnumerable<KeyValuePair<PropertyInfo, T[]>> kvAttrs = props.Select((PropertyInfo prop) => new KeyValuePair<PropertyInfo, T[]>(prop, GetCustomAttributes<T>(prop)));
		return kvAttrs.Where((KeyValuePair<PropertyInfo, T[]> kv) => kv.Value.Length > 0);
	}

	public IDictionary<string, SolrFieldModel> GetFields(Type type)
	{
		IEnumerable<KeyValuePair<PropertyInfo, SolrFieldAttribute[]>> propsAttrs = GetPropertiesWithAttribute<SolrFieldAttribute>(type);
		return (from kv in propsAttrs
			select new SolrFieldModel(kv.Key, kv.Value[0].FieldName ?? kv.Key.Name, kv.Value[0].Boost) into m
			select new KeyValuePair<string, SolrFieldModel>(m.FieldName, m)).ToDictionary((KeyValuePair<string, SolrFieldModel> kv) => kv.Key, (KeyValuePair<string, SolrFieldModel> kv) => kv.Value);
	}

	public virtual T[] GetCustomAttributes<T>(PropertyInfo prop) where T : Attribute
	{
		return (T[])prop.GetCustomAttributes(typeof(T), inherit: true);
	}

	public SolrFieldModel GetUniqueKey(Type type)
	{
		IEnumerable<KeyValuePair<PropertyInfo, SolrUniqueKeyAttribute[]>> propsAttrs = GetPropertiesWithAttribute<SolrUniqueKeyAttribute>(type);
		IEnumerable<SolrFieldModel> fields = propsAttrs.Select((KeyValuePair<PropertyInfo, SolrUniqueKeyAttribute[]> kv) => new SolrFieldModel(kv.Key, kv.Value[0].FieldName ?? kv.Key.Name));
		return fields.FirstOrDefault();
	}

	public ICollection<Type> GetRegisteredTypes()
	{
		List<Type> types = new List<Type>();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly a in assemblies)
		{
			try
			{
				Type[] types2 = a.GetTypes();
				foreach (Type t in types2)
				{
					if (GetFields(t).Count > 0)
					{
						types.Add(t);
					}
				}
			}
			catch (ReflectionTypeLoadException)
			{
			}
		}
		return types;
	}
}
