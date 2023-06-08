using System;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Mappers;

public class ImplicitConversionOperatorMapper : IObjectMapper
{
	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		MethodInfo implicitConversionOperator = GetImplicitConversionOperator(context);
		return implicitConversionOperator.Invoke(null, new object[1] { context.SourceValue });
	}

	public bool IsMatch(ResolutionContext context)
	{
		MethodInfo implicitConversionOperator = GetImplicitConversionOperator(context);
		return (object)implicitConversionOperator != null;
	}

	private static MethodInfo GetImplicitConversionOperator(ResolutionContext context)
	{
		MethodInfo methodInfo = (from mi in context.SourceType.GetMethods(BindingFlags.Static | BindingFlags.Public)
			where mi.Name == "op_Implicit"
			where (object)mi.ReturnType == context.DestinationType
			select mi).FirstOrDefault();
		MethodInfo method = context.DestinationType.GetMethod("op_Implicit", new Type[1] { context.SourceType });
		return methodInfo ?? method;
	}
}
