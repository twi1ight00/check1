using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Impl;
using AutoMapper.Internal;
using AutoMapper.Mappers;

namespace AutoMapper;

public class MappingEngine : IMappingEngine, IDisposable, IMappingEngineRunner
{
	private static readonly IDictionaryFactory DictionaryFactory = PlatformAdapter.Resolve<IDictionaryFactory>();

	private static readonly IProxyGeneratorFactory ProxyGeneratorFactory = PlatformAdapter.Resolve<IProxyGeneratorFactory>();

	private bool _disposed;

	private readonly IConfigurationProvider _configurationProvider;

	private readonly IObjectMapper[] _mappers;

	private readonly AutoMapper.Internal.IDictionary<TypePair, IObjectMapper> _objectMapperCache = DictionaryFactory.CreateDictionary<TypePair, IObjectMapper>();

	private readonly Func<Type, object> _serviceCtor;

	public IConfigurationProvider ConfigurationProvider => _configurationProvider;

	public MappingEngine(IConfigurationProvider configurationProvider)
		: this(configurationProvider, DictionaryFactory.CreateDictionary<TypePair, IObjectMapper>(), configurationProvider.ServiceCtor)
	{
	}

	public MappingEngine(IConfigurationProvider configurationProvider, AutoMapper.Internal.IDictionary<TypePair, IObjectMapper> objectMapperCache, Func<Type, object> serviceCtor)
	{
		_configurationProvider = configurationProvider;
		_objectMapperCache = objectMapperCache;
		_serviceCtor = serviceCtor;
		_mappers = configurationProvider.GetMappers();
		_configurationProvider.TypeMapCreated += ClearTypeMap;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing && _configurationProvider != null)
			{
				_configurationProvider.TypeMapCreated -= ClearTypeMap;
			}
			_disposed = true;
		}
	}

	public TDestination Map<TDestination>(object source)
	{
		return Map<TDestination>(source, DefaultMappingOptions);
	}

	public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
	{
		TDestination result = default(TDestination);
		if (source != null)
		{
			Type type = source.GetType();
			Type typeFromHandle = typeof(TDestination);
			return (TDestination)Map(source, type, typeFromHandle, opts);
		}
		return result;
	}

	public TDestination Map<TSource, TDestination>(TSource source)
	{
		Type typeFromHandle = typeof(TSource);
		Type typeFromHandle2 = typeof(TDestination);
		return (TDestination)Map(source, typeFromHandle, typeFromHandle2, DefaultMappingOptions);
	}

	public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions> opts)
	{
		Type typeFromHandle = typeof(TSource);
		Type typeFromHandle2 = typeof(TDestination);
		return (TDestination)Map(source, typeFromHandle, typeFromHandle2, opts);
	}

	public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
	{
		return Map(source, destination, DefaultMappingOptions);
	}

	public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions> opts)
	{
		Type typeFromHandle = typeof(TSource);
		Type typeFromHandle2 = typeof(TDestination);
		return (TDestination)Map(source, destination, typeFromHandle, typeFromHandle2, opts);
	}

	public object Map(object source, Type sourceType, Type destinationType)
	{
		return Map(source, sourceType, destinationType, DefaultMappingOptions);
	}

	public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
	{
		TypeMap typeMap = ConfigurationProvider.FindTypeMapFor(source, null, sourceType, destinationType);
		MappingOperationOptions mappingOperationOptions = new MappingOperationOptions();
		opts(mappingOperationOptions);
		ResolutionContext context = new ResolutionContext(typeMap, source, sourceType, destinationType, mappingOperationOptions);
		return ((IMappingEngineRunner)this).Map(context);
	}

	public object Map(object source, object destination, Type sourceType, Type destinationType)
	{
		return Map(source, destination, sourceType, destinationType, DefaultMappingOptions);
	}

	public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
	{
		TypeMap typeMap = ConfigurationProvider.FindTypeMapFor(source, destination, sourceType, destinationType);
		MappingOperationOptions mappingOperationOptions = new MappingOperationOptions();
		opts(mappingOperationOptions);
		ResolutionContext context = new ResolutionContext(typeMap, source, destination, sourceType, destinationType, mappingOperationOptions);
		return ((IMappingEngineRunner)this).Map(context);
	}

	public TDestination DynamicMap<TSource, TDestination>(TSource source)
	{
		Type typeFromHandle = typeof(TSource);
		Type typeFromHandle2 = typeof(TDestination);
		return (TDestination)DynamicMap(source, typeFromHandle, typeFromHandle2);
	}

	public void DynamicMap<TSource, TDestination>(TSource source, TDestination destination)
	{
		Type typeFromHandle = typeof(TSource);
		Type typeFromHandle2 = typeof(TDestination);
		DynamicMap(source, destination, typeFromHandle, typeFromHandle2);
	}

	public TDestination DynamicMap<TDestination>(object source)
	{
		Type sourceType = ((source == null) ? typeof(object) : source.GetType());
		Type typeFromHandle = typeof(TDestination);
		return (TDestination)DynamicMap(source, sourceType, typeFromHandle);
	}

	public object DynamicMap(object source, Type sourceType, Type destinationType)
	{
		TypeMap typeMap = ConfigurationProvider.FindTypeMapFor(source, null, sourceType, destinationType) ?? ConfigurationProvider.CreateTypeMap(sourceType, destinationType);
		ResolutionContext context = new ResolutionContext(typeMap, source, sourceType, destinationType, new MappingOperationOptions
		{
			CreateMissingTypeMaps = true
		});
		return ((IMappingEngineRunner)this).Map(context);
	}

	public void DynamicMap(object source, object destination, Type sourceType, Type destinationType)
	{
		TypeMap typeMap = ConfigurationProvider.FindTypeMapFor(source, destination, sourceType, destinationType) ?? ConfigurationProvider.CreateTypeMap(sourceType, destinationType);
		ResolutionContext context = new ResolutionContext(typeMap, source, destination, sourceType, destinationType, new MappingOperationOptions
		{
			CreateMissingTypeMaps = true
		});
		((IMappingEngineRunner)this).Map(context);
	}

	public TDestination Map<TSource, TDestination>(ResolutionContext parentContext, TSource source)
	{
		Type typeFromHandle = typeof(TDestination);
		Type typeFromHandle2 = typeof(TSource);
		TypeMap memberTypeMap = ConfigurationProvider.FindTypeMapFor(source, null, typeFromHandle2, typeFromHandle);
		ResolutionContext context = parentContext.CreateTypeContext(memberTypeMap, source, null, typeFromHandle2, typeFromHandle);
		return (TDestination)((IMappingEngineRunner)this).Map(context);
	}

	object IMappingEngineRunner.Map(ResolutionContext context)
	{
		try
		{
			TypePair key = new TypePair(context.SourceType, context.DestinationType);
			Func<TypePair, IObjectMapper> valueFactory = (TypePair tp) => _mappers.FirstOrDefault((IObjectMapper mapper) => mapper.IsMatch(context));
			IObjectMapper orAdd = _objectMapperCache.GetOrAdd(key, valueFactory);
			if (orAdd == null)
			{
				if (!context.Options.CreateMissingTypeMaps)
				{
					if (context.SourceValue != null)
					{
						throw new AutoMapperMappingException(context, "Missing type map configuration or unsupported mapping.");
					}
					return ObjectCreator.CreateDefaultValue(context.DestinationType);
				}
				TypeMap memberTypeMap = ConfigurationProvider.CreateTypeMap(context.SourceType, context.DestinationType);
				context = context.CreateTypeContext(memberTypeMap, context.SourceValue, context.DestinationValue, context.SourceType, context.DestinationType);
				orAdd = _objectMapperCache.GetOrAdd(key, valueFactory);
			}
			return orAdd.Map(context, this);
		}
		catch (AutoMapperMappingException)
		{
			throw;
		}
		catch (Exception inner)
		{
			throw new AutoMapperMappingException(context, inner);
		}
	}

	string IMappingEngineRunner.FormatValue(ResolutionContext context)
	{
		TypeMap contextTypeMap = context.GetContextTypeMap();
		IFormatterConfiguration formatterConfiguration = ((contextTypeMap != null) ? ConfigurationProvider.GetProfileConfiguration(contextTypeMap.Profile) : ConfigurationProvider.GetProfileConfiguration(""));
		object sourceValue = context.SourceValue;
		string text = context.SourceValue.ToNullSafeString();
		IEnumerable<IValueFormatter> formattersToApply = formatterConfiguration.GetFormattersToApply(context);
		foreach (IValueFormatter item in formattersToApply)
		{
			text = item.FormatValue(context.CreateValueContext(sourceValue));
			sourceValue = text;
		}
		if (text == null && !((IMappingEngineRunner)this).ShouldMapSourceValueAsNull(context))
		{
			return string.Empty;
		}
		return text;
	}

	object IMappingEngineRunner.CreateObject(ResolutionContext context)
	{
		TypeMap typeMap = context.TypeMap;
		Type type = context.DestinationType;
		if (typeMap != null)
		{
			if (typeMap.DestinationCtor != null)
			{
				return typeMap.DestinationCtor(context);
			}
			if (typeMap.ConstructDestinationUsingServiceLocator)
			{
				return context.Options.ServiceCtor(type);
			}
			if (typeMap.ConstructorMap != null)
			{
				return typeMap.ConstructorMap.ResolveValue(context, this);
			}
		}
		if (context.DestinationValue != null)
		{
			return context.DestinationValue;
		}
		if (type.IsInterface)
		{
			type = ProxyGeneratorFactory.Create().GetProxyType(type);
		}
		return ObjectCreator.CreateObject(type);
	}

	bool IMappingEngineRunner.ShouldMapSourceValueAsNull(ResolutionContext context)
	{
		if (context.DestinationType.IsValueType && !context.DestinationType.IsNullableType())
		{
			return false;
		}
		TypeMap contextTypeMap = context.GetContextTypeMap();
		if (contextTypeMap != null)
		{
			return ConfigurationProvider.GetProfileConfiguration(contextTypeMap.Profile).MapNullSourceValuesAsNull;
		}
		return ConfigurationProvider.MapNullSourceValuesAsNull;
	}

	bool IMappingEngineRunner.ShouldMapSourceCollectionAsNull(ResolutionContext context)
	{
		TypeMap contextTypeMap = context.GetContextTypeMap();
		if (contextTypeMap != null)
		{
			return ConfigurationProvider.GetProfileConfiguration(contextTypeMap.Profile).MapNullSourceCollectionsAsNull;
		}
		return ConfigurationProvider.MapNullSourceCollectionsAsNull;
	}

	private void ClearTypeMap(object sender, TypeMapCreatedEventArgs e)
	{
		_objectMapperCache.TryRemove(new TypePair(e.TypeMap.SourceType, e.TypeMap.DestinationType), out var _);
	}

	private void DefaultMappingOptions(IMappingOperationOptions opts)
	{
		opts.ConstructServicesUsing(_serviceCtor);
	}
}
