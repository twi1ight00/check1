using System;
using System.Linq;

namespace AutoMapper.Mappers;

public class FlagsEnumMapper : IObjectMapper
{
	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		Type enumerationType = TypeHelper.GetEnumerationType(context.DestinationType);
		if (context.SourceValue == null)
		{
			return mapper.CreateObject(context);
		}
		return Enum.Parse(enumerationType, context.SourceValue.ToString(), ignoreCase: true);
	}

	public bool IsMatch(ResolutionContext context)
	{
		Type enumerationType = TypeHelper.GetEnumerationType(context.SourceType);
		Type enumerationType2 = TypeHelper.GetEnumerationType(context.DestinationType);
		if ((object)enumerationType != null && (object)enumerationType2 != null && enumerationType.GetCustomAttributes(typeof(FlagsAttribute), inherit: false).Any())
		{
			return enumerationType2.GetCustomAttributes(typeof(FlagsAttribute), inherit: false).Any();
		}
		return false;
	}
}
