using System.Collections.Generic;
using System.Linq;

namespace AutoMapper.Mappers;

public class TypeMapMapper : IObjectMapper
{
	private readonly IEnumerable<ITypeMapObjectMapper> _mappers;

	public TypeMapMapper(IEnumerable<ITypeMapObjectMapper> mappers)
	{
		_mappers = mappers;
	}

	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		context.TypeMap.Seal();
		ITypeMapObjectMapper typeMapObjectMapper = _mappers.First((ITypeMapObjectMapper objectMapper) => objectMapper.IsMatch(context, mapper));
		return (!context.TypeMap.ShouldAssignValue(context)) ? null : typeMapObjectMapper.Map(context, mapper);
	}

	public bool IsMatch(ResolutionContext context)
	{
		return context.TypeMap != null;
	}
}
