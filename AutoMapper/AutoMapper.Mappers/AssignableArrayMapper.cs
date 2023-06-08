namespace AutoMapper.Mappers;

public class AssignableArrayMapper : IObjectMapper
{
	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		if (context.SourceValue == null && !mapper.ShouldMapSourceValueAsNull(context))
		{
			return mapper.CreateObject(context);
		}
		return context.SourceValue;
	}

	public bool IsMatch(ResolutionContext context)
	{
		if (context.DestinationType.IsAssignableFrom(context.SourceType) && context.DestinationType.IsArray)
		{
			return context.SourceType.IsArray;
		}
		return false;
	}
}
