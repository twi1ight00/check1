using System;
using System.Collections.Generic;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class CollectionMapper : IObjectMapper
{
	private class EnumerableMapper<TCollection, TElement> : EnumerableMapperBase<TCollection> where TCollection : ICollection<TElement>
	{
		public override bool IsMatch(ResolutionContext context)
		{
			throw new NotImplementedException();
		}

		protected override void SetElementValue(TCollection destination, object mappedValue, int index)
		{
			destination.Add((TElement)mappedValue);
		}

		protected override void ClearEnumerable(TCollection enumerable)
		{
			enumerable.Clear();
		}

		protected override TCollection CreateDestinationObjectBase(Type destElementType, int sourceLength)
		{
			object obj = ((!typeof(TCollection).IsInterface) ? ObjectCreator.CreateDefaultValue(typeof(TCollection)) : new List<TElement>());
			return (TCollection)obj;
		}
	}

	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		Type typeFromHandle = typeof(EnumerableMapper<, >);
		Type destinationType = context.DestinationType;
		Type elementType = TypeHelper.GetElementType(context.DestinationType);
		Type type = typeFromHandle.MakeGenericType(destinationType, elementType);
		IObjectMapper objectMapper = (IObjectMapper)Activator.CreateInstance(type);
		return objectMapper.Map(context, mapper);
	}

	public bool IsMatch(ResolutionContext context)
	{
		return context.SourceType.IsEnumerableType() && context.DestinationType.IsCollectionType();
	}
}
