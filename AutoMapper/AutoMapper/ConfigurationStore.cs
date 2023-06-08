using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper.Impl;
using AutoMapper.Internal;
using AutoMapper.Mappers;

namespace AutoMapper;

public class ConfigurationStore : IConfigurationProvider, IProfileConfiguration, IConfiguration, IProfileExpression, IFormatterExpression, IMappingOptions
{
	internal const string DefaultProfileName = "";

	private static readonly IDictionaryFactory DictionaryFactory = PlatformAdapter.Resolve<IDictionaryFactory>();

	private readonly ITypeMapFactory _typeMapFactory;

	private readonly IEnumerable<IObjectMapper> _mappers;

	private readonly ThreadSafeList<TypeMap> _typeMaps = new ThreadSafeList<TypeMap>();

	private readonly AutoMapper.Internal.IDictionary<TypePair, TypeMap> _typeMapCache = DictionaryFactory.CreateDictionary<TypePair, TypeMap>();

	private readonly AutoMapper.Internal.IDictionary<string, FormatterExpression> _formatterProfiles = DictionaryFactory.CreateDictionary<string, FormatterExpression>();

	private Func<Type, object> _serviceCtor = ObjectCreator.CreateObject;

	private readonly List<string> _globalIgnore;

	public Func<Type, object> ServiceCtor => _serviceCtor;

	public bool AllowNullDestinationValues
	{
		get
		{
			return GetProfile("").AllowNullDestinationValues;
		}
		set
		{
			GetProfile("").AllowNullDestinationValues = value;
		}
	}

	public bool AllowNullCollections
	{
		get
		{
			return GetProfile("").AllowNullCollections;
		}
		set
		{
			GetProfile("").AllowNullCollections = value;
		}
	}

	public INamingConvention SourceMemberNamingConvention
	{
		get
		{
			return GetProfile("").SourceMemberNamingConvention;
		}
		set
		{
			GetProfile("").SourceMemberNamingConvention = value;
		}
	}

	public INamingConvention DestinationMemberNamingConvention
	{
		get
		{
			return GetProfile("").DestinationMemberNamingConvention;
		}
		set
		{
			GetProfile("").DestinationMemberNamingConvention = value;
		}
	}

	public IEnumerable<string> Prefixes => GetProfile("").Prefixes;

	public IEnumerable<string> Postfixes => GetProfile("").Postfixes;

	public IEnumerable<string> DestinationPrefixes => GetProfile("").DestinationPrefixes;

	public IEnumerable<string> DestinationPostfixes => GetProfile("").DestinationPostfixes;

	public IEnumerable<AliasedMember> Aliases => GetProfile("").Aliases;

	public bool ConstructorMappingEnabled => GetProfile("").ConstructorMappingEnabled;

	public bool DataReaderMapperYieldReturnEnabled => GetProfile("").DataReaderMapperYieldReturnEnabled;

	public IEnumerable<MethodInfo> SourceExtensionMethods => GetProfile("").SourceExtensionMethods;

	bool IProfileConfiguration.MapNullSourceValuesAsNull => AllowNullDestinationValues;

	bool IProfileConfiguration.MapNullSourceCollectionsAsNull => AllowNullCollections;

	public event EventHandler<TypeMapCreatedEventArgs> TypeMapCreated;

	public ConfigurationStore(ITypeMapFactory typeMapFactory, IEnumerable<IObjectMapper> mappers)
	{
		_typeMapFactory = typeMapFactory;
		_mappers = mappers;
		_globalIgnore = new List<string>();
	}

	public void IncludeSourceExtensionMethods(Assembly assembly)
	{
		GetProfile("").IncludeSourceExtensionMethods(assembly);
	}

	public IProfileExpression CreateProfile(string profileName)
	{
		Profile profile = new Profile(profileName);
		profile.Initialize(this);
		return profile;
	}

	public void CreateProfile(string profileName, Action<IProfileExpression> profileConfiguration)
	{
		Profile profile = new Profile(profileName);
		profile.Initialize(this);
		profileConfiguration(profile);
	}

	public void AddProfile(Profile profile)
	{
		profile.Initialize(this);
		profile.Configure();
	}

	public void AddProfile<TProfile>() where TProfile : Profile, new()
	{
		AddProfile(new TProfile());
	}

	public void ConstructServicesUsing(Func<Type, object> constructor)
	{
		_serviceCtor = constructor;
	}

	public void DisableConstructorMapping()
	{
		GetProfile("").ConstructorMappingEnabled = false;
	}

	public void EnableYieldReturnForDataReaderMapper()
	{
		GetProfile("").DataReaderMapperYieldReturnEnabled = true;
	}

	public void Seal()
	{
		_typeMaps.Each(delegate(TypeMap typeMap)
		{
			typeMap.Seal();
		});
	}

	public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
	{
		return CreateMap<TSource, TDestination>("");
	}

	public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>(MemberList memberList)
	{
		return CreateMap<TSource, TDestination>("", memberList);
	}

	public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>(string profileName)
	{
		return CreateMap<TSource, TDestination>(profileName, MemberList.Destination);
	}

	public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>(string profileName, MemberList memberList)
	{
		TypeMap typeMap = CreateTypeMap(typeof(TSource), typeof(TDestination), profileName, memberList);
		return CreateMappingExpression<TSource, TDestination>(typeMap);
	}

	public IMappingExpression CreateMap(Type sourceType, Type destinationType)
	{
		return CreateMap(sourceType, destinationType, MemberList.Destination);
	}

	public IMappingExpression CreateMap(Type sourceType, Type destinationType, MemberList memberList)
	{
		return CreateMap(sourceType, destinationType, memberList, "");
	}

	public IMappingExpression CreateMap(Type sourceType, Type destinationType, MemberList memberList, string profileName)
	{
		TypeMap typeMap = CreateTypeMap(sourceType, destinationType, profileName, memberList);
		return CreateMappingExpression(typeMap, destinationType);
	}

	public void RecognizePrefixes(params string[] prefixes)
	{
		GetProfile("").RecognizePrefixes(prefixes);
	}

	public void RecognizePostfixes(params string[] postfixes)
	{
		GetProfile("").RecognizePostfixes(postfixes);
	}

	public void RecognizeAlias(string original, string alias)
	{
		GetProfile("").RecognizeAlias(original, alias);
	}

	public void RecognizeDestinationPrefixes(params string[] prefixes)
	{
		GetProfile("").RecognizeDestinationPrefixes(prefixes);
	}

	public void RecognizeDestinationPostfixes(params string[] postfixes)
	{
		GetProfile("").RecognizeDestinationPostfixes(postfixes);
	}

	public TypeMap CreateTypeMap(Type source, Type destination)
	{
		return CreateTypeMap(source, destination, "", MemberList.Destination);
	}

	public TypeMap CreateTypeMap(Type source, Type destination, string profileName, MemberList memberList)
	{
		TypeMap typeMap = FindExplicitlyDefinedTypeMap(source, destination);
		if (typeMap == null)
		{
			FormatterExpression profile = GetProfile(profileName);
			typeMap = _typeMapFactory.CreateTypeMap(source, destination, profile, memberList);
			typeMap.Profile = profileName;
			typeMap.IgnorePropertiesStartingWith = _globalIgnore;
			IncludeBaseMappings(source, destination, typeMap);
			_typeMaps.Add(typeMap);
			TypePair key = new TypePair(source, destination);
			_typeMapCache.AddOrUpdate(key, typeMap, (TypePair tp, TypeMap tm) => typeMap);
			OnTypeMapCreated(typeMap);
		}
		return typeMap;
	}

	private void IncludeBaseMappings(Type source, Type destination, TypeMap typeMap)
	{
		foreach (TypeMap item in _typeMaps.Where((TypeMap t) => t.TypeHasBeenIncluded(source, destination)))
		{
			foreach (PropertyMap inheritedMappedProperty in from m in item.GetPropertyMaps()
				where m.IsMapped()
				select m)
			{
				IEnumerable<PropertyMap> propertyMaps = typeMap.GetPropertyMaps();
				Func<PropertyMap, bool> predicate = (PropertyMap m) => m.DestinationProperty.Name == inheritedMappedProperty.DestinationProperty.Name;
				PropertyMap propertyMap = propertyMaps.SingleOrDefault(predicate);
				if (propertyMap != null && inheritedMappedProperty.HasCustomValueResolver)
				{
					propertyMap.AssignCustomValueResolver(inheritedMappedProperty.GetSourceValueResolvers().First());
				}
				else if (propertyMap == null)
				{
					PropertyMap mappedProperty = new PropertyMap(inheritedMappedProperty);
					typeMap.AddInheritedPropertyMap(mappedProperty);
				}
			}
			if (item.BeforeMap != null)
			{
				typeMap.AddBeforeMapAction(item.BeforeMap);
			}
			if (item.AfterMap != null)
			{
				typeMap.AddAfterMapAction(item.AfterMap);
			}
		}
	}

	public IFormatterCtorExpression<TValueFormatter> AddFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		return GetProfile("").AddFormatter<TValueFormatter>();
	}

	public IFormatterCtorExpression AddFormatter(Type valueFormatterType)
	{
		return GetProfile("").AddFormatter(valueFormatterType);
	}

	public void AddFormatter(IValueFormatter formatter)
	{
		GetProfile("").AddFormatter(formatter);
	}

	public void AddFormatExpression(Func<ResolutionContext, string> formatExpression)
	{
		GetProfile("").AddFormatExpression(formatExpression);
	}

	public void SkipFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		GetProfile("").SkipFormatter<TValueFormatter>();
	}

	public IFormatterExpression ForSourceType<TSource>()
	{
		return GetProfile("").ForSourceType<TSource>();
	}

	public TypeMap[] GetAllTypeMaps()
	{
		return _typeMaps.ToArray();
	}

	public TypeMap FindTypeMapFor(Type sourceType, Type destinationType)
	{
		return FindTypeMapFor(null, null, sourceType, destinationType);
	}

	public TypeMap FindTypeMapFor(object source, object destination, Type sourceType, Type destinationType)
	{
		TypePair key = new TypePair(sourceType, destinationType);
		if (!_typeMapCache.TryGetValue(key, out var value))
		{
			value = FindTypeMap(source, destination, sourceType, destinationType, "");
			if (source == null || (object)source.GetType() == sourceType)
			{
				_typeMapCache[key] = value;
			}
		}
		else if (source != null && value != null && !value.SourceType.IsAssignableFrom(source.GetType()))
		{
			value = FindTypeMapFor(source, destination, source.GetType(), destinationType);
		}
		if (value == null && destination != null && (object)destination.GetType() != destinationType)
		{
			value = FindTypeMapFor(source, destination, sourceType, destination.GetType());
		}
		if (value != null && (object)value.DestinationTypeOverride != null)
		{
			return FindTypeMapFor(source, destination, sourceType, value.DestinationTypeOverride);
		}
		if (value != null && value.HasDerivedTypesToInclude() && source != null && (object)source.GetType() != sourceType)
		{
			Type potentialSourceType = source.GetType();
			IEnumerable<TypeMap> source2 = _typeMaps.Where((TypeMap t) => destinationType.IsAssignableFrom(t.DestinationType) && t.SourceType.IsAssignableFrom(source.GetType()) && (destinationType.IsAssignableFrom(t.DestinationType) || (object)t.GetDerivedTypeFor(potentialSourceType) != null));
			TypeMap potentialDestTypeMap = source2.OrderByDescending((TypeMap t) => GetInheritanceDepth(t.DestinationType)).FirstOrDefault();
			List<TypeMap> list = source2.Where((TypeMap t) => (object)t.DestinationType == potentialDestTypeMap.DestinationType).ToList();
			if (list.Count > 1)
			{
				potentialDestTypeMap = list.OrderByDescending((TypeMap t) => GetInheritanceDepth(t.SourceType)).FirstOrDefault();
			}
			if (potentialDestTypeMap == value)
			{
				return value;
			}
			Type destinationType2 = potentialDestTypeMap.DestinationType;
			TypeMap typeMap = FindExplicitlyDefinedTypeMap(potentialSourceType, destinationType2);
			if (typeMap == null)
			{
				Type sourceType2 = (((object)destinationType2 != destinationType) ? potentialSourceType : value.SourceType);
				value = FindTypeMap(source, destination, sourceType2, destinationType2, "");
			}
			else
			{
				value = typeMap;
			}
		}
		return value;
	}

	private static int GetInheritanceDepth(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		return InheritanceTree(type).Count();
	}

	private static IEnumerable<Type> InheritanceTree(Type type)
	{
		while ((object)type != null)
		{
			yield return type;
			type = type.BaseType;
		}
	}

	public TypeMap FindTypeMapFor(ResolutionResult resolutionResult, Type destinationType)
	{
		return FindTypeMapFor(resolutionResult.Value, null, resolutionResult.Type, destinationType) ?? FindTypeMapFor(resolutionResult.Value, null, resolutionResult.MemberType, destinationType);
	}

	public IFormatterConfiguration GetProfileConfiguration(string profileName)
	{
		return GetProfile(profileName);
	}

	public void AssertConfigurationIsValid(TypeMap typeMap)
	{
		AssertConfigurationIsValid(Enumerable.Repeat(typeMap, 1));
	}

	public void AssertConfigurationIsValid(string profileName)
	{
		AssertConfigurationIsValid(_typeMaps.Where((TypeMap typeMap) => typeMap.Profile == profileName));
	}

	public void AssertConfigurationIsValid()
	{
		AssertConfigurationIsValid(_typeMaps);
	}

	public IObjectMapper[] GetMappers()
	{
		return _mappers.ToArray();
	}

	private IMappingExpression<TSource, TDestination> CreateMappingExpression<TSource, TDestination>(TypeMap typeMap)
	{
		IMappingExpression<TSource, TDestination> mappingExpression = new MappingExpression<TSource, TDestination>(typeMap, _serviceCtor, this);
		TypeInfo typeInfo = new TypeInfo(typeof(TDestination));
		foreach (MemberInfo publicWriteAccessor in typeInfo.GetPublicWriteAccessors())
		{
			object[] customAttributes = publicWriteAccessor.GetCustomAttributes(inherit: true);
			if (customAttributes.Any((object x) => x is IgnoreMapAttribute))
			{
				mappingExpression = mappingExpression.ForMember(publicWriteAccessor.Name, delegate(IMemberConfigurationExpression<TSource> y)
				{
					y.Ignore();
				});
			}
		}
		return mappingExpression;
	}

	private IMappingExpression CreateMappingExpression(TypeMap typeMap, Type destinationType)
	{
		IMappingExpression mappingExpression = new MappingExpression(typeMap, _serviceCtor);
		TypeInfo typeInfo = new TypeInfo(destinationType);
		foreach (MemberInfo publicWriteAccessor in typeInfo.GetPublicWriteAccessors())
		{
			object[] customAttributes = publicWriteAccessor.GetCustomAttributes(inherit: true);
			if (customAttributes.Any((object x) => x is IgnoreMapAttribute))
			{
				mappingExpression = mappingExpression.ForMember(publicWriteAccessor.Name, delegate(IMemberConfigurationExpression y)
				{
					y.Ignore();
				});
			}
		}
		return mappingExpression;
	}

	private void AssertConfigurationIsValid(IEnumerable<TypeMap> typeMaps)
	{
		AutoMapperConfigurationException.TypeMapConfigErrors[] array = (from typeMap in typeMaps
			where ShouldCheckMap(typeMap)
			let unmappedPropertyNames = typeMap.GetUnmappedPropertyNames()
			where unmappedPropertyNames.Length > 0
			select new AutoMapperConfigurationException.TypeMapConfigErrors(typeMap, unmappedPropertyNames)).ToArray();
		if (array.Any())
		{
			throw new AutoMapperConfigurationException(array);
		}
		List<TypeMap> typeMapsChecked = new List<TypeMap>();
		foreach (TypeMap item in (IEnumerable<TypeMap>)_typeMaps)
		{
			DryRunTypeMap(typeMapsChecked, new ResolutionContext(item, null, item.SourceType, item.DestinationType, new MappingOperationOptions()));
		}
	}

	private static bool ShouldCheckMap(TypeMap typeMap)
	{
		if (typeMap.CustomMapper == null)
		{
			return !FeatureDetector.IsIDataRecordType(typeMap.SourceType);
		}
		return false;
	}

	private TypeMap FindTypeMap(object source, object destination, Type sourceType, Type destinationType, string profileName)
	{
		TypeMap typeMap = FindExplicitlyDefinedTypeMap(sourceType, destinationType);
		if (typeMap == null && destinationType.IsNullableType())
		{
			typeMap = FindExplicitlyDefinedTypeMap(sourceType, destinationType.GetTypeOfNullable());
		}
		if (typeMap == null)
		{
			typeMap = _typeMaps.FirstOrDefault((TypeMap x) => (object)x.SourceType == sourceType && (object)x.GetDerivedTypeFor(sourceType) == destinationType);
			if (typeMap == null)
			{
				Type[] interfaces = sourceType.GetInterfaces();
				foreach (Type sourceType2 in interfaces)
				{
					typeMap = ((IConfigurationProvider)this).FindTypeMapFor(source, destination, sourceType2, destinationType);
					if (typeMap != null)
					{
						Type derivedTypeFor = typeMap.GetDerivedTypeFor(sourceType);
						if ((object)derivedTypeFor != destinationType)
						{
							typeMap = CreateTypeMap(sourceType, derivedTypeFor, profileName, typeMap.ConfiguredMemberList);
						}
						break;
					}
				}
				if ((object)sourceType.BaseType != null && typeMap == null)
				{
					typeMap = ((IConfigurationProvider)this).FindTypeMapFor(source, destination, sourceType.BaseType, destinationType);
				}
			}
		}
		return typeMap;
	}

	private TypeMap FindExplicitlyDefinedTypeMap(Type sourceType, Type destinationType)
	{
		return _typeMaps.FirstOrDefault((TypeMap x) => (object)x.DestinationType == destinationType && (object)x.SourceType == sourceType);
	}

	private void DryRunTypeMap(ICollection<TypeMap> typeMapsChecked, ResolutionContext context)
	{
		if (context.TypeMap != null)
		{
			typeMapsChecked.Add(context.TypeMap);
		}
		IObjectMapper objectMapper = GetMappers().FirstOrDefault((IObjectMapper mapper) => mapper.IsMatch(context));
		if (objectMapper == null && context.SourceType.IsNullableType())
		{
			ResolutionContext nullableContext = context.CreateValueContext(null, Nullable.GetUnderlyingType(context.SourceType));
			objectMapper = GetMappers().FirstOrDefault((IObjectMapper mapper) => mapper.IsMatch(nullableContext));
		}
		if (objectMapper == null)
		{
			throw new AutoMapperConfigurationException(context);
		}
		if (objectMapper is TypeMapMapper)
		{
			foreach (PropertyMap propertyMap in context.TypeMap.GetPropertyMaps())
			{
				if (!propertyMap.IsIgnored())
				{
					IMemberResolver memberResolver = propertyMap.GetSourceValueResolvers().OfType<IMemberResolver>().LastOrDefault();
					if (memberResolver != null)
					{
						Type memberType = memberResolver.MemberType;
						Type memberType2 = propertyMap.DestinationProperty.MemberType;
						TypeMap memberTypeMap = ((IConfigurationProvider)this).FindTypeMapFor(memberType, memberType2);
						if (!typeMapsChecked.Any((TypeMap typeMap) => object.Equals(typeMap, memberTypeMap)))
						{
							ResolutionContext context2 = context.CreateMemberContext(memberTypeMap, null, null, memberType, propertyMap);
							DryRunTypeMap(typeMapsChecked, context2);
						}
					}
				}
			}
			return;
		}
		if (objectMapper is ArrayMapper || objectMapper is EnumerableMapper || objectMapper is CollectionMapper)
		{
			Type elementType = TypeHelper.GetElementType(context.SourceType);
			Type elementType2 = TypeHelper.GetElementType(context.DestinationType);
			TypeMap itemTypeMap = ((IConfigurationProvider)this).FindTypeMapFor(elementType, elementType2);
			if (!typeMapsChecked.Any((TypeMap typeMap) => object.Equals(typeMap, itemTypeMap)))
			{
				ResolutionContext context3 = context.CreateElementContext(itemTypeMap, null, elementType, elementType2, 0);
				DryRunTypeMap(typeMapsChecked, context3);
			}
		}
	}

	protected void OnTypeMapCreated(TypeMap typeMap)
	{
		this.TypeMapCreated?.Invoke(this, new TypeMapCreatedEventArgs(typeMap));
	}

	internal FormatterExpression GetProfile(string profileName)
	{
		return _formatterProfiles.GetOrAdd(profileName, (string name) => new FormatterExpression((Type t) => (IValueFormatter)_serviceCtor(t)));
	}

	public void AddGlobalIgnore(string startingwith)
	{
		_globalIgnore.Add(startingwith);
	}
}
