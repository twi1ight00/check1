using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoMapper;

/// <summary>
/// Provides a named configuration for maps. Naming conventions become scoped per profile.
/// </summary>
public class Profile : IProfileExpression, IFormatterExpression, IMappingOptions
{
	private ConfigurationStore _configurator;

	public virtual string ProfileName { get; private set; }

	public bool AllowNullDestinationValues
	{
		get
		{
			return GetProfile().AllowNullDestinationValues;
		}
		set
		{
			GetProfile().AllowNullDestinationValues = value;
		}
	}

	public bool AllowNullCollections
	{
		get
		{
			return GetProfile().AllowNullCollections;
		}
		set
		{
			GetProfile().AllowNullCollections = value;
		}
	}

	public INamingConvention SourceMemberNamingConvention
	{
		get
		{
			return GetProfile().SourceMemberNamingConvention;
		}
		set
		{
			GetProfile().SourceMemberNamingConvention = value;
		}
	}

	public INamingConvention DestinationMemberNamingConvention
	{
		get
		{
			return GetProfile().DestinationMemberNamingConvention;
		}
		set
		{
			GetProfile().DestinationMemberNamingConvention = value;
		}
	}

	public IEnumerable<string> Prefixes => GetProfile().Prefixes;

	public IEnumerable<string> Postfixes => GetProfile().Postfixes;

	public IEnumerable<string> DestinationPrefixes => GetProfile().DestinationPrefixes;

	public IEnumerable<string> DestinationPostfixes => GetProfile().DestinationPostfixes;

	public IEnumerable<AliasedMember> Aliases
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public bool ConstructorMappingEnabled => _configurator.ConstructorMappingEnabled;

	public bool DataReaderMapperYieldReturnEnabled => _configurator.DataReaderMapperYieldReturnEnabled;

	public IEnumerable<MethodInfo> SourceExtensionMethods => GetProfile().SourceExtensionMethods;

	internal Profile(string profileName)
	{
		ProfileName = profileName;
	}

	protected Profile()
	{
		ProfileName = GetType().FullName;
	}

	public void DisableConstructorMapping()
	{
		GetProfile().ConstructorMappingEnabled = false;
	}

	public void IncludeSourceExtensionMethods(Assembly assembly)
	{
		GetProfile().IncludeSourceExtensionMethods(assembly);
	}

	public IFormatterCtorExpression<TValueFormatter> AddFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		return GetProfile().AddFormatter<TValueFormatter>();
	}

	public IFormatterCtorExpression AddFormatter(Type valueFormatterType)
	{
		return GetProfile().AddFormatter(valueFormatterType);
	}

	public void AddFormatter(IValueFormatter formatter)
	{
		GetProfile().AddFormatter(formatter);
	}

	public void AddFormatExpression(Func<ResolutionContext, string> formatExpression)
	{
		GetProfile().AddFormatExpression(formatExpression);
	}

	public void SkipFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		GetProfile().SkipFormatter<TValueFormatter>();
	}

	public IFormatterExpression ForSourceType<TSource>()
	{
		return GetProfile().ForSourceType<TSource>();
	}

	public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
	{
		return CreateMap<TSource, TDestination>(MemberList.Destination);
	}

	public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>(MemberList memberList)
	{
		return _configurator.CreateMap<TSource, TDestination>(ProfileName, memberList);
	}

	public IMappingExpression CreateMap(Type sourceType, Type destinationType)
	{
		return CreateMap(sourceType, destinationType, MemberList.Destination);
	}

	public IMappingExpression CreateMap(Type sourceType, Type destinationType, MemberList memberList)
	{
		return _configurator.CreateMap(sourceType, destinationType, memberList, ProfileName);
	}

	public void RecognizeAlias(string original, string alias)
	{
		GetProfile().RecognizeAlias(original, alias);
	}

	public void RecognizePrefixes(params string[] prefixes)
	{
		GetProfile().RecognizePrefixes(prefixes);
	}

	public void RecognizePostfixes(params string[] postfixes)
	{
		GetProfile().RecognizePostfixes(postfixes);
	}

	public void RecognizeDestinationPrefixes(params string[] prefixes)
	{
		GetProfile().RecognizeDestinationPrefixes(prefixes);
	}

	public void RecognizeDestinationPostfixes(params string[] postfixes)
	{
		GetProfile().RecognizeDestinationPostfixes(postfixes);
	}

	public void AddGlobalIgnore(string propertyNameStartingWith)
	{
		_configurator.AddGlobalIgnore(propertyNameStartingWith);
	}

	/// <summary>
	/// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
	/// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
	/// </summary>
	protected internal virtual void Configure()
	{
	}

	public void Initialize(ConfigurationStore configurator)
	{
		_configurator = configurator;
	}

	private FormatterExpression GetProfile()
	{
		return _configurator.GetProfile(ProfileName);
	}
}
