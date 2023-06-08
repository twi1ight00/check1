using System;
using System.Collections;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class EnumerableMapper : EnumerableMapperBase<IList>
{
	public override bool IsMatch(ResolutionContext context)
	{
		if (context.DestinationType.IsEnumerableType())
		{
			return context.SourceType.IsEnumerableType();
		}
		return false;
	}

	protected override void SetElementValue(IList destination, object mappedValue, int index)
	{
		destination.Add(mappedValue);
	}

	protected override void ClearEnumerable(IList enumerable)
	{
		enumerable.Clear();
	}

	protected override IList CreateDestinationObjectBase(Type destElementType, int sourceLength)
	{
		return ObjectCreator.CreateList(destElementType);
	}
}
