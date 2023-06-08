using System.Linq;
using System.Reflection;

namespace AutoMapper;

public class ConstructorParameterMap
{
	public ParameterInfo Parameter { get; private set; }

	public IMemberGetter[] SourceResolvers { get; private set; }

	public ConstructorParameterMap(ParameterInfo parameter, IMemberGetter[] sourceResolvers)
	{
		Parameter = parameter;
		SourceResolvers = sourceResolvers;
	}

	public ResolutionResult ResolveValue(ResolutionContext context)
	{
		ResolutionResult seed = new ResolutionResult(context);
		return SourceResolvers.Aggregate(seed, (ResolutionResult current, IMemberGetter resolver) => resolver.Resolve(current));
	}
}
