using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class ReadOnlyCollectionMapper : IObjectMapper
{
	private class EnumerableMapper<TElement> : EnumerableMapperBase<IList<TElement>>
	{
		private readonly IList<TElement> inner = new List<TElement>();

		public override bool IsMatch(ResolutionContext context)
		{
			throw new NotImplementedException();
		}

		protected override void SetElementValue(IList<TElement> elements, object mappedValue, int index)
		{
			inner.Add((TElement)mappedValue);
		}

		protected override IList<TElement> GetEnumerableFor(object destination)
		{
			return inner;
		}

		protected override IList<TElement> CreateDestinationObjectBase(Type destElementType, int sourceLength)
		{
			throw new NotImplementedException();
		}

		protected override object CreateDestinationObject(ResolutionContext context, Type destinationElementType, int count, IMappingEngineRunner mapper)
		{
			return new ReadOnlyCollection<TElement>(inner);
		}
	}

	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		Type typeFromHandle = typeof(EnumerableMapper<>);
		Type elementType = TypeHelper.GetElementType(context.DestinationType);
		Type type = typeFromHandle.MakeGenericType(elementType);
		IObjectMapper objectMapper = (IObjectMapper)Activator.CreateInstance(type);
		ResolutionContext context2 = context.CreateMemberContext(context.TypeMap, context.SourceValue, null, context.SourceType, context.PropertyMap);
		return objectMapper.Map(context2, mapper);
	}

	public bool IsMatch(ResolutionContext context)
	{
		if (!context.SourceType.IsEnumerableType() || !context.DestinationType.IsGenericType)
		{
			return false;
		}
		Type genericTypeDefinition = context.DestinationType.GetGenericTypeDefinition();
		if ((object)genericTypeDefinition == typeof(ReadOnlyCollection<>))
		{
			return true;
		}
		return false;
	}
}
