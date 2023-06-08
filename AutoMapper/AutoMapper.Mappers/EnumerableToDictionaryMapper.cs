using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class EnumerableToDictionaryMapper : IObjectMapper
{
	private static readonly Type KvpType = typeof(KeyValuePair<, >);

	public bool IsMatch(ResolutionContext context)
	{
		if (context.DestinationType.IsDictionaryType() && context.SourceType.IsEnumerableType())
		{
			return !context.SourceType.IsDictionaryType();
		}
		return false;
	}

	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		IEnumerable enumerable = ((IEnumerable)context.SourceValue) ?? new object[0];
		IEnumerable<object> enumerable2 = enumerable.Cast<object>();
		Type elementType = TypeHelper.GetElementType(context.SourceType, enumerable);
		Type dictionaryType = context.DestinationType.GetDictionaryType();
		Type type = dictionaryType.GetGenericArguments()[0];
		Type type2 = dictionaryType.GetGenericArguments()[1];
		Type type3 = KvpType.MakeGenericType(type, type2);
		object obj = ObjectCreator.CreateDictionary(context.DestinationType, type, type2);
		int num = 0;
		foreach (object item in enumerable2)
		{
			TypeMap typeMap = mapper.ConfigurationProvider.FindTypeMapFor(item, null, elementType, type3);
			Type sourceElementType = ((typeMap != null) ? typeMap.SourceType : elementType);
			Type destinationElementType = ((typeMap != null) ? typeMap.DestinationType : type3);
			ResolutionContext context2 = context.CreateElementContext(typeMap, item, sourceElementType, destinationElementType, num);
			object obj2 = mapper.Map(context2);
			PropertyInfo property = obj2.GetType().GetProperty("Key");
			object value = property.GetValue(obj2, null);
			PropertyInfo property2 = obj2.GetType().GetProperty("Value");
			object value2 = property2.GetValue(obj2, null);
			dictionaryType.GetMethod("Add").Invoke(obj, new object[2] { value, value2 });
			num++;
		}
		return obj;
	}
}
