using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper.Internal;

namespace AutoMapper;

public class ConstructorMap
{
	private static readonly IDelegateFactory DelegateFactory = PlatformAdapter.Resolve<IDelegateFactory>();

	private readonly LateBoundParamsCtor _runtimeCtor;

	public ConstructorInfo Ctor { get; private set; }

	public IEnumerable<ConstructorParameterMap> CtorParams { get; private set; }

	public ConstructorMap(ConstructorInfo ctor, IEnumerable<ConstructorParameterMap> ctorParams)
	{
		Ctor = ctor;
		CtorParams = ctorParams;
		_runtimeCtor = DelegateFactory.CreateCtor(ctor, CtorParams);
	}

	public object ResolveValue(ResolutionContext context, IMappingEngineRunner mappingEngine)
	{
		List<object> list = new List<object>();
		foreach (ConstructorParameterMap ctorParam in CtorParams)
		{
			ResolutionResult resolutionResult = ctorParam.ResolveValue(context);
			Type type = resolutionResult.Type;
			Type parameterType = ctorParam.Parameter.ParameterType;
			TypeMap typeMap = mappingEngine.ConfigurationProvider.FindTypeMapFor(resolutionResult, parameterType);
			Type sourceType = ((typeMap != null) ? typeMap.SourceType : type);
			ResolutionContext context2 = context.CreateTypeContext(typeMap, resolutionResult.Value, null, sourceType, parameterType);
			object item = mappingEngine.Map(context2);
			list.Add(item);
		}
		return _runtimeCtor(list.ToArray());
	}
}
