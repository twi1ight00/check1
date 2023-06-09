using System;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class ArrayMapper : EnumerableMapperBase<Array>
{
	public override bool IsMatch(ResolutionContext context)
	{
		if (context.DestinationType.IsArray)
		{
			return context.SourceType.IsEnumerableType();
		}
		return false;
	}

	protected override void ClearEnumerable(Array enumerable)
	{
	}

	protected override void SetElementValue(Array destination, object mappedValue, int index)
	{
		destination.SetValue(mappedValue, index);
	}

	protected override Array CreateDestinationObjectBase(Type destElementType, int sourceLength)
	{
		throw new NotImplementedException();
	}

	protected override object GetOrCreateDestinationObject(ResolutionContext context, IMappingEngineRunner mapper, Type destElementType, int sourceLength)
	{
		return ObjectCreator.CreateArray(destElementType, sourceLength);
	}
}
