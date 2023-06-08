using System;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Mappers;

public class ExplicitConversionOperatorMapper : IObjectMapper
{
	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		MethodInfo explicitConversionOperator = GetExplicitConversionOperator(context);
		return explicitConversionOperator.Invoke(null, new object[1] { context.SourceValue });
	}

	public bool IsMatch(ResolutionContext context)
	{
		MethodInfo explicitConversionOperator = GetExplicitConversionOperator(context);
		return (object)explicitConversionOperator != null;
	}

	private static MethodInfo GetExplicitConversionOperator(ResolutionContext context)
	{
		MethodInfo methodInfo = (from mi in context.SourceType.GetMethods(BindingFlags.Static | BindingFlags.Public)
			where mi.Name == "op_Explicit"
			where (object)mi.ReturnType == context.DestinationType
			select mi).FirstOrDefault();
		MethodInfo method = context.DestinationType.GetMethod("op_Explicit", new Type[1] { context.SourceType });
		return methodInfo ?? method;
	}
}
