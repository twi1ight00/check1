using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoMapper;

public class FormatterExpression : IFormatterExpression, IFormatterConfiguration, IProfileConfiguration, IFormatterCtorConfigurator, IMappingOptions
{
	private readonly Func<Type, IValueFormatter> _formatterCtor;

	private readonly IList<IValueFormatter> _formatters = new List<IValueFormatter>();

	private readonly IDictionary<Type, IFormatterConfiguration> _typeSpecificFormatters = new Dictionary<Type, IFormatterConfiguration>();

	private readonly IList<Type> _formattersToSkip = new List<Type>();

	private readonly ISet<string> _prefixes = new HashSet<string>();

	private readonly ISet<string> _postfixes = new HashSet<string>();

	private readonly ISet<string> _destinationPrefixes = new HashSet<string>();

	private readonly ISet<string> _destinationPostfixes = new HashSet<string>();

	private readonly ISet<AliasedMember> _aliases = new HashSet<AliasedMember>();

	private readonly List<MethodInfo> _sourceExtensionMethods = new List<MethodInfo>();

	public bool AllowNullDestinationValues { get; set; }

	public bool AllowNullCollections { get; set; }

	public INamingConvention SourceMemberNamingConvention { get; set; }

	public INamingConvention DestinationMemberNamingConvention { get; set; }

	public IEnumerable<string> Prefixes => _prefixes;

	public IEnumerable<string> Postfixes => _postfixes;

	public IEnumerable<string> DestinationPrefixes => _destinationPrefixes;

	public IEnumerable<string> DestinationPostfixes => _destinationPostfixes;

	public IEnumerable<AliasedMember> Aliases => _aliases;

	public bool ConstructorMappingEnabled { get; set; }

	public bool DataReaderMapperYieldReturnEnabled { get; set; }

	public IEnumerable<MethodInfo> SourceExtensionMethods => _sourceExtensionMethods;

	public bool MapNullSourceValuesAsNull => AllowNullDestinationValues;

	public bool MapNullSourceCollectionsAsNull => AllowNullCollections;

	public FormatterExpression(Func<Type, IValueFormatter> formatterCtor)
	{
		_formatterCtor = formatterCtor;
		SourceMemberNamingConvention = new PascalCaseNamingConvention();
		DestinationMemberNamingConvention = new PascalCaseNamingConvention();
		RecognizePrefixes("Get");
		AllowNullDestinationValues = true;
		ConstructorMappingEnabled = true;
		IncludeSourceExtensionMethods(typeof(Enumerable).Assembly);
	}

	public IFormatterCtorExpression<TValueFormatter> AddFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		DeferredInstantiatedFormatter valueFormatter = new DeferredInstantiatedFormatter(BuildCtor(typeof(TValueFormatter)));
		AddFormatter(valueFormatter);
		return new FormatterCtorExpression<TValueFormatter>(this);
	}

	public IFormatterCtorExpression AddFormatter(Type valueFormatterType)
	{
		DeferredInstantiatedFormatter valueFormatter = new DeferredInstantiatedFormatter(BuildCtor(valueFormatterType));
		AddFormatter(valueFormatter);
		return new FormatterCtorExpression(valueFormatterType, this);
	}

	public void AddFormatter(IValueFormatter valueFormatter)
	{
		_formatters.Add(valueFormatter);
	}

	public void AddFormatExpression(Func<ResolutionContext, string> formatExpression)
	{
		_formatters.Add(new ExpressionValueFormatter(formatExpression));
	}

	public void SkipFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		_formattersToSkip.Add(typeof(TValueFormatter));
	}

	public IFormatterExpression ForSourceType<TSource>()
	{
		FormatterExpression formatterExpression = new FormatterExpression(_formatterCtor);
		_typeSpecificFormatters[typeof(TSource)] = formatterExpression;
		return formatterExpression;
	}

	public IValueFormatter[] GetFormatters()
	{
		return _formatters.ToArray();
	}

	public IDictionary<Type, IFormatterConfiguration> GetTypeSpecificFormatters()
	{
		return new Dictionary<Type, IFormatterConfiguration>(_typeSpecificFormatters);
	}

	public Type[] GetFormatterTypesToSkip()
	{
		return _formattersToSkip.ToArray();
	}

	public IEnumerable<IValueFormatter> GetFormattersToApply(ResolutionContext context)
	{
		return GetFormatters(context);
	}

	private IEnumerable<IValueFormatter> GetFormatters(ResolutionContext context)
	{
		Type valueType = context.SourceType;
		IFormatterConfiguration typeSpecificFormatterConfig;
		if (context.PropertyMap != null)
		{
			try
			{
				IValueFormatter[] formatters = context.PropertyMap.GetFormatters();
				for (int i = 0; i < formatters.Length; i++)
				{
					yield return formatters[i];
				}
			}
			finally
			{
			}
			if (GetTypeSpecificFormatters().TryGetValue(valueType, out typeSpecificFormatterConfig) && !context.PropertyMap.FormattersToSkipContains(typeSpecificFormatterConfig.GetType()))
			{
				foreach (IValueFormatter item in typeSpecificFormatterConfig.GetFormattersToApply(context))
				{
					yield return item;
				}
			}
		}
		else if (GetTypeSpecificFormatters().TryGetValue(valueType, out typeSpecificFormatterConfig))
		{
			foreach (IValueFormatter item2 in typeSpecificFormatterConfig.GetFormattersToApply(context))
			{
				yield return item2;
			}
		}
		try
		{
			IValueFormatter[] formatters2 = GetFormatters();
			foreach (IValueFormatter formatter in formatters2)
			{
				Type formatterType = GetFormatterType(formatter, context);
				if (CheckPropertyMapSkipList(context, formatterType) && CheckTypeSpecificSkipList(typeSpecificFormatterConfig, formatterType))
				{
					yield return formatter;
				}
			}
		}
		finally
		{
		}
	}

	public void ConstructFormatterBy(Type formatterType, Func<IValueFormatter> instantiator)
	{
		_formatters.RemoveAt(_formatters.Count - 1);
		_formatters.Add(new DeferredInstantiatedFormatter((ResolutionContext ctxt) => instantiator()));
	}

	public void IncludeSourceExtensionMethods(Assembly assembly)
	{
		_sourceExtensionMethods.AddRange(from method in (from type in assembly.GetTypes()
				where type.IsSealed && !type.IsGenericType && !type.IsNested
				select type).SelectMany((Type type) => type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
			where method.IsDefined(typeof(ExtensionAttribute), inherit: false)
			where method.GetParameters().Length == 1
			select method);
	}

	public void RecognizePrefixes(params string[] prefixes)
	{
		foreach (string item in prefixes)
		{
			_prefixes.Add(item);
		}
	}

	public void RecognizePostfixes(params string[] postfixes)
	{
		foreach (string item in postfixes)
		{
			_postfixes.Add(item);
		}
	}

	public void RecognizeAlias(string original, string alias)
	{
		_aliases.Add(new AliasedMember(original, alias));
	}

	public void RecognizeDestinationPrefixes(params string[] prefixes)
	{
		foreach (string item in prefixes)
		{
			_destinationPrefixes.Add(item);
		}
	}

	public void RecognizeDestinationPostfixes(params string[] postfixes)
	{
		foreach (string item in postfixes)
		{
			_destinationPostfixes.Add(item);
		}
	}

	private static Type GetFormatterType(IValueFormatter formatter, ResolutionContext context)
	{
		if (!(formatter is DeferredInstantiatedFormatter))
		{
			return formatter.GetType();
		}
		return ((DeferredInstantiatedFormatter)formatter).GetFormatterType(context);
	}

	private static bool CheckTypeSpecificSkipList(IFormatterConfiguration valueFormatter, Type formatterType)
	{
		if (valueFormatter == null)
		{
			return true;
		}
		return !valueFormatter.GetFormatterTypesToSkip().Contains(formatterType);
	}

	private static bool CheckPropertyMapSkipList(ResolutionContext context, Type formatterType)
	{
		if (context.PropertyMap == null)
		{
			return true;
		}
		return !context.PropertyMap.FormattersToSkipContains(formatterType);
	}

	private Func<ResolutionContext, IValueFormatter> BuildCtor(Type type)
	{
		return delegate(ResolutionContext context)
		{
			if (context.Options.ServiceCtor != null)
			{
				object obj = context.Options.ServiceCtor(type);
				if (obj != null)
				{
					return (IValueFormatter)obj;
				}
			}
			return _formatterCtor(type);
		};
	}

	private static string DefaultPrefixTransformer(string src, string prefix)
	{
		if (src == null || string.IsNullOrEmpty(prefix) || !src.StartsWith(prefix, StringComparison.Ordinal))
		{
			return src;
		}
		return src.Substring(prefix.Length);
	}

	private static string DefaultPostfixTransformer(string src, string postfix)
	{
		if (src == null || string.IsNullOrEmpty(postfix) || !src.EndsWith(postfix, StringComparison.Ordinal))
		{
			return src;
		}
		return src.Remove(src.Length - postfix.Length);
	}

	private static string DefaultAliasTransformer(string src, string original, string alias)
	{
		if (src == null || string.IsNullOrEmpty(original) || !string.Equals(src, original, StringComparison.Ordinal))
		{
			return src;
		}
		return alias;
	}

	private static string DefaultSourceMemberNameTransformer(string src)
	{
		if (src == null || !src.StartsWith("Get", StringComparison.Ordinal))
		{
			return src;
		}
		return src.Substring(3);
	}
}
