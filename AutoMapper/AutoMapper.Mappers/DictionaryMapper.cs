using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class DictionaryMapper : IObjectMapper
{
	private static readonly Type KvpType = typeof(KeyValuePair<, >);

	public bool IsMatch(ResolutionContext context)
	{
		if (context.SourceType.IsDictionaryType())
		{
			return context.DestinationType.IsDictionaryType();
		}
		return false;
	}

	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		if (context.IsSourceValueNull && mapper.ShouldMapSourceCollectionAsNull(context))
		{
			return null;
		}
		IEnumerable source = ((IEnumerable)context.SourceValue) ?? new object[0];
		IEnumerable<object> enumerable = source.Cast<object>();
		Type dictionaryType = context.SourceType.GetDictionaryType();
		Type type = dictionaryType.GetGenericArguments()[0];
		Type type2 = dictionaryType.GetGenericArguments()[1];
		Type sourceKvpType = KvpType.MakeGenericType(type, type2);
		Type dictionaryType2 = context.DestinationType.GetDictionaryType();
		Type type3 = dictionaryType2.GetGenericArguments()[0];
		Type type4 = dictionaryType2.GetGenericArguments()[1];
		IEnumerable<DictionaryEntry> source2 = enumerable.OfType<DictionaryEntry>();
		if (source2.Any())
		{
			enumerable = source2.Select((DictionaryEntry e) => Activator.CreateInstance(sourceKvpType, e.Key, e.Value));
		}
		object obj = ObjectCreator.CreateDictionary(context.DestinationType, type3, type4);
		int num = 0;
		foreach (object item in enumerable)
		{
			object value = sourceKvpType.GetProperty("Key").GetValue(item, new object[0]);
			object value2 = sourceKvpType.GetProperty("Value").GetValue(item, new object[0]);
			TypeMap elementTypeMap = mapper.ConfigurationProvider.FindTypeMapFor(value, null, type, type3);
			TypeMap elementTypeMap2 = mapper.ConfigurationProvider.FindTypeMapFor(value2, null, type2, type4);
			ResolutionContext context2 = context.CreateElementContext(elementTypeMap, value, type, type3, num);
			ResolutionContext context3 = context.CreateElementContext(elementTypeMap2, value2, type2, type4, num);
			object obj2 = mapper.Map(context2);
			object obj3 = mapper.Map(context3);
			dictionaryType2.GetMethod("Add").Invoke(obj, new object[2] { obj2, obj3 });
			num++;
		}
		return obj;
	}
}
