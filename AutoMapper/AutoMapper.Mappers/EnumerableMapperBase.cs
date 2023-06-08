using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapper.Mappers;

public abstract class EnumerableMapperBase<TEnumerable> : IObjectMapper where TEnumerable : IEnumerable
{
	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		if (context.IsSourceValueNull && mapper.ShouldMapSourceCollectionAsNull(context))
		{
			return null;
		}
		ICollection<object> collection = (((IEnumerable)context.SourceValue) ?? new object[0]).Cast<object>().ToList();
		Type elementType = TypeHelper.GetElementType(context.SourceType, collection);
		Type elementType2 = TypeHelper.GetElementType(context.DestinationType);
		int count = collection.Count;
		object orCreateDestinationObject = GetOrCreateDestinationObject(context, mapper, elementType2, count);
		TEnumerable enumerableFor = GetEnumerableFor(orCreateDestinationObject);
		ClearEnumerable(enumerableFor);
		int num = 0;
		foreach (object item in collection)
		{
			ResolutionContext context2 = context.CreateElementContext(null, item, elementType, elementType2, num);
			ResolutionResult resolutionResult = new ResolutionResult(context2);
			TypeMap typeMap = mapper.ConfigurationProvider.FindTypeMapFor(resolutionResult, elementType2);
			Type sourceElementType = ((typeMap != null) ? typeMap.SourceType : elementType);
			Type destinationElementType = ((typeMap != null) ? typeMap.DestinationType : elementType2);
			context2 = context.CreateElementContext(typeMap, item, sourceElementType, destinationElementType, num);
			object mappedValue = mapper.Map(context2);
			SetElementValue(enumerableFor, mappedValue, num);
			num++;
		}
		return orCreateDestinationObject;
	}

	protected virtual object GetOrCreateDestinationObject(ResolutionContext context, IMappingEngineRunner mapper, Type destElementType, int sourceLength)
	{
		return context.DestinationValue ?? CreateDestinationObject(context, destElementType, sourceLength, mapper);
	}

	protected virtual TEnumerable GetEnumerableFor(object destination)
	{
		return (TEnumerable)destination;
	}

	protected virtual void ClearEnumerable(TEnumerable enumerable)
	{
	}

	protected virtual object CreateDestinationObject(ResolutionContext context, Type destinationElementType, int count, IMappingEngineRunner mapper)
	{
		Type destinationType = context.DestinationType;
		if (!destinationType.IsInterface && !destinationType.IsArray)
		{
			return mapper.CreateObject(context);
		}
		return CreateDestinationObjectBase(destinationElementType, count);
	}

	public abstract bool IsMatch(ResolutionContext context);

	protected abstract void SetElementValue(TEnumerable destination, object mappedValue, int index);

	protected abstract TEnumerable CreateDestinationObjectBase(Type destElementType, int sourceLength);
}
