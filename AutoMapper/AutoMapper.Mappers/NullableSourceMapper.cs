using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class NullableSourceMapper : IObjectMapper
{
	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		return context.SourceValue ?? mapper.CreateObject(context);
	}

	public bool IsMatch(ResolutionContext context)
	{
		if (context.SourceType.IsNullableType())
		{
			return !context.DestinationType.IsNullableType();
		}
		return false;
	}
}
