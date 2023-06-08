using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class HashSetMapper : IObjectMapper
{
	private class EnumerableMapper<TCollection, TElement> : EnumerableMapperBase<TCollection> where TCollection : ISet<TElement>
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
			object obj = ((!typeof(TCollection).IsInterface) ? ObjectCreator.CreateDefaultValue(typeof(TCollection)) : new HashSet<TElement>());
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
		return context.SourceType.IsEnumerableType() && IsSetType(context.DestinationType);
	}

	private static bool IsSetType(Type type)
	{
		if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ISet<>))
		{
			return true;
		}
		IEnumerable<Type> source = from t in type.GetInterfaces()
			where t.IsGenericType
			select t;
		IEnumerable<Type> source2 = source.Select((Type t) => t.GetGenericTypeDefinition());
		return source2.Any((Type t) => t == typeof(ISet<>));
	}
}
