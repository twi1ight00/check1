using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper.Impl;

namespace AutoMapper;

public class MappingExpression : IMappingExpression, IMemberConfigurationExpression
{
	private class SourceMappingExpression : ISourceMemberConfigurationExpression
	{
		private readonly SourceMemberConfig _sourcePropertyConfig;

		public SourceMappingExpression(TypeMap typeMap, MemberInfo sourceMember)
		{
			_sourcePropertyConfig = typeMap.FindOrCreateSourceMemberConfigFor(sourceMember);
		}

		public void Ignore()
		{
			_sourcePropertyConfig.Ignore();
		}
	}

	private readonly TypeMap _typeMap;

	private readonly Func<Type, object> _typeConverterCtor;

	private PropertyMap _propertyMap;

	public MappingExpression(TypeMap typeMap, Func<Type, object> typeConverterCtor)
	{
		_typeMap = typeMap;
		_typeConverterCtor = typeConverterCtor;
	}

	public void ConvertUsing<TTypeConverter>()
	{
		ConvertUsing(typeof(TTypeConverter));
	}

	public void ConvertUsing(Type typeConverterType)
	{
		Type type = typeof(ITypeConverter<, >).MakeGenericType(_typeMap.SourceType, _typeMap.DestinationType);
		Type typeConverterType2 = (type.IsAssignableFrom(typeConverterType) ? type : typeConverterType);
		DeferredInstantiatedConverter @object = new DeferredInstantiatedConverter(typeConverterType2, BuildCtor<object>(typeConverterType));
		_typeMap.UseCustomMapper(@object.Convert);
	}

	public void As(Type typeOverride)
	{
		_typeMap.DestinationTypeOverride = typeOverride;
	}

	public IMappingExpression WithProfile(string profileName)
	{
		_typeMap.Profile = profileName;
		return this;
	}

	public IMappingExpression ForMember(string name, Action<IMemberConfigurationExpression> memberOptions)
	{
		IMemberAccessor memberAccessor = null;
		PropertyInfo property = _typeMap.DestinationType.GetProperty(name);
		if ((object)property != null)
		{
			memberAccessor = new PropertyAccessor(property);
		}
		if (memberAccessor == null)
		{
			FieldInfo field = _typeMap.DestinationType.GetField(name);
			memberAccessor = new FieldAccessor(field);
		}
		ForDestinationMember(memberAccessor, memberOptions);
		return new MappingExpression(_typeMap, _typeConverterCtor);
	}

	public IMappingExpression ForSourceMember(string sourceMemberName, Action<ISourceMemberConfigurationExpression> memberOptions)
	{
		MemberInfo sourceMember = _typeMap.SourceType.GetMember(sourceMemberName).First();
		SourceMappingExpression obj = new SourceMappingExpression(_typeMap, sourceMember);
		memberOptions(obj);
		return new MappingExpression(_typeMap, _typeConverterCtor);
	}

	private void ForDestinationMember(IMemberAccessor destinationProperty, Action<IMemberConfigurationExpression> memberOptions)
	{
		_propertyMap = _typeMap.FindOrCreatePropertyMapFor(destinationProperty);
		memberOptions(this);
	}

	public void MapFrom(string sourceMember)
	{
		MemberInfo[] member = _typeMap.SourceType.GetMember(sourceMember);
		if (!member.Any())
		{
			throw new AutoMapperConfigurationException(string.Format("Unable to find source member {0} on type {1}", new object[2]
			{
				sourceMember,
				_typeMap.SourceType.FullName
			}));
		}
		if (member.Skip(1).Any())
		{
			throw new AutoMapperConfigurationException(string.Format("Source member {0} is ambiguous on type {1}", new object[2]
			{
				sourceMember,
				_typeMap.SourceType.FullName
			}));
		}
		MemberInfo memberInfo = member.Single();
		_propertyMap.SourceMember = memberInfo;
		_propertyMap.AssignCustomValueResolver(memberInfo.ToMemberGetter());
	}

	public IResolutionExpression ResolveUsing(IValueResolver valueResolver)
	{
		_propertyMap.AssignCustomValueResolver(valueResolver);
		return new ResolutionExpression(_typeMap.SourceType, _propertyMap);
	}

	public IResolverConfigurationExpression ResolveUsing(Type valueResolverType)
	{
		DeferredInstantiatedResolver valueResolver = new DeferredInstantiatedResolver(BuildCtor<IValueResolver>(valueResolverType));
		ResolveUsing(valueResolver);
		return new ResolutionExpression(_typeMap.SourceType, _propertyMap);
	}

	public IResolverConfigurationExpression ResolveUsing<TValueResolver>()
	{
		DeferredInstantiatedResolver valueResolver = new DeferredInstantiatedResolver(BuildCtor<IValueResolver>(typeof(TValueResolver)));
		ResolveUsing(valueResolver);
		return new ResolutionExpression(_typeMap.SourceType, _propertyMap);
	}

	public void Ignore()
	{
		_propertyMap.Ignore();
	}

	private Func<ResolutionContext, TServiceType> BuildCtor<TServiceType>(Type type)
	{
		return delegate(ResolutionContext context)
		{
			if (context.Options.ServiceCtor != null)
			{
				object obj = context.Options.ServiceCtor(type);
				if (obj != null)
				{
					return (TServiceType)obj;
				}
			}
			return (TServiceType)_typeConverterCtor(type);
		};
	}
}
public class MappingExpression<TSource, TDestination> : IMappingExpression<TSource, TDestination>, IMemberConfigurationExpression<TSource>, IFormatterCtorConfigurator
{
	private class SourceMappingExpression : ISourceMemberConfigurationExpression<TSource>, ISourceMemberConfigurationExpression
	{
		private readonly SourceMemberConfig _sourcePropertyConfig;

		public SourceMappingExpression(TypeMap typeMap, MemberInfo memberInfo)
		{
			_sourcePropertyConfig = typeMap.FindOrCreateSourceMemberConfigFor(memberInfo);
		}

		public void Ignore()
		{
			_sourcePropertyConfig.Ignore();
		}
	}

	private readonly TypeMap _typeMap;

	private readonly Func<Type, object> _serviceCtor;

	private readonly IProfileExpression _configurationContainer;

	private PropertyMap _propertyMap;

	public MappingExpression(TypeMap typeMap, Func<Type, object> serviceCtor, IProfileExpression configurationContainer)
	{
		_typeMap = typeMap;
		_serviceCtor = serviceCtor;
		_configurationContainer = configurationContainer;
	}

	public IMappingExpression<TSource, TDestination> ForMember(Expression<Func<TDestination, object>> destinationMember, Action<IMemberConfigurationExpression<TSource>> memberOptions)
	{
		MemberInfo accessorCandidate = ReflectionHelper.FindProperty(destinationMember);
		IMemberAccessor destinationProperty = accessorCandidate.ToMemberAccessor();
		ForDestinationMember(destinationProperty, memberOptions);
		return new MappingExpression<TSource, TDestination>(_typeMap, _serviceCtor, _configurationContainer);
	}

	public IMappingExpression<TSource, TDestination> ForMember(string name, Action<IMemberConfigurationExpression<TSource>> memberOptions)
	{
		IMemberAccessor memberAccessor = null;
		PropertyInfo property = _typeMap.DestinationType.GetProperty(name);
		if ((object)property != null)
		{
			memberAccessor = new PropertyAccessor(property);
		}
		if (memberAccessor == null)
		{
			FieldInfo field = _typeMap.DestinationType.GetField(name);
			memberAccessor = new FieldAccessor(field);
		}
		ForDestinationMember(memberAccessor, memberOptions);
		return new MappingExpression<TSource, TDestination>(_typeMap, _serviceCtor, _configurationContainer);
	}

	public void ForAllMembers(Action<IMemberConfigurationExpression<TSource>> memberOptions)
	{
		TypeInfo typeInfo = new TypeInfo(_typeMap.DestinationType);
		typeInfo.GetPublicWriteAccessors().Each(delegate(MemberInfo acc)
		{
			ForDestinationMember(acc.ToMemberAccessor(), memberOptions);
		});
	}

	public IMappingExpression<TSource, TDestination> Include<TOtherSource, TOtherDestination>() where TOtherSource : TSource where TOtherDestination : TDestination
	{
		_typeMap.IncludeDerivedTypes(typeof(TOtherSource), typeof(TOtherDestination));
		return this;
	}

	public IMappingExpression<TSource, TDestination> WithProfile(string profileName)
	{
		_typeMap.Profile = profileName;
		return this;
	}

	public void SkipFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		_propertyMap.AddFormatterToSkip<TValueFormatter>();
	}

	public IFormatterCtorExpression<TValueFormatter> AddFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		DeferredInstantiatedFormatter formatter = new DeferredInstantiatedFormatter(BuildCtor<IValueFormatter>(typeof(TValueFormatter)));
		AddFormatter(formatter);
		return new FormatterCtorExpression<TValueFormatter>(this);
	}

	public IFormatterCtorExpression AddFormatter(Type valueFormatterType)
	{
		DeferredInstantiatedFormatter formatter = new DeferredInstantiatedFormatter(BuildCtor<IValueFormatter>(valueFormatterType));
		AddFormatter(formatter);
		return new FormatterCtorExpression(valueFormatterType, this);
	}

	public void AddFormatter(IValueFormatter formatter)
	{
		_propertyMap.AddFormatter(formatter);
	}

	public void NullSubstitute(object nullSubstitute)
	{
		_propertyMap.SetNullSubstitute(nullSubstitute);
	}

	public IResolverConfigurationExpression<TSource, TValueResolver> ResolveUsing<TValueResolver>() where TValueResolver : IValueResolver
	{
		DeferredInstantiatedResolver valueResolver = new DeferredInstantiatedResolver(BuildCtor<IValueResolver>(typeof(TValueResolver)));
		ResolveUsing(valueResolver);
		return new ResolutionExpression<TSource, TValueResolver>(_propertyMap);
	}

	public IResolverConfigurationExpression<TSource> ResolveUsing(Type valueResolverType)
	{
		DeferredInstantiatedResolver valueResolver = new DeferredInstantiatedResolver(BuildCtor<IValueResolver>(valueResolverType));
		ResolveUsing(valueResolver);
		return new ResolutionExpression<TSource>(_propertyMap);
	}

	public IResolutionExpression<TSource> ResolveUsing(IValueResolver valueResolver)
	{
		_propertyMap.AssignCustomValueResolver(valueResolver);
		return new ResolutionExpression<TSource>(_propertyMap);
	}

	public void ResolveUsing(Func<TSource, object> resolver)
	{
		_propertyMap.AssignCustomValueResolver(new DelegateBasedResolver<TSource>(resolver));
	}

	public void MapFrom<TMember>(Expression<Func<TSource, TMember>> sourceMember)
	{
		_propertyMap.SetCustomValueResolverExpression(sourceMember);
	}

	public void UseValue<TValue>(TValue value)
	{
		MapFrom((TSource src) => value);
	}

	public void UseValue(object value)
	{
		_propertyMap.AssignCustomValueResolver(new DelegateBasedResolver<TSource>((TSource src) => value));
	}

	public void Condition(Func<TSource, bool> condition)
	{
		Condition((ResolutionContext context) => condition((TSource)context.Parent.SourceValue));
	}

	public IMappingExpression<TSource, TDestination> MaxDepth(int depth)
	{
		_typeMap.SetCondition((ResolutionContext o) => PassesDepthCheck(o, depth));
		return this;
	}

	public IMappingExpression<TSource, TDestination> ConstructUsingServiceLocator()
	{
		_typeMap.ConstructDestinationUsingServiceLocator = true;
		return this;
	}

	public IMappingExpression<TDestination, TSource> ReverseMap()
	{
		return _configurationContainer.CreateMap<TDestination, TSource>(MemberList.Source);
	}

	public IMappingExpression<TSource, TDestination> ForSourceMember(Expression<Func<TSource, object>> sourceMember, Action<ISourceMemberConfigurationExpression<TSource>> memberOptions)
	{
		MemberInfo memberInfo = ReflectionHelper.FindProperty(sourceMember);
		SourceMappingExpression obj = new SourceMappingExpression(_typeMap, memberInfo);
		memberOptions(obj);
		return this;
	}

	public IMappingExpression<TSource, TDestination> ForSourceMember(string sourceMemberName, Action<ISourceMemberConfigurationExpression<TSource>> memberOptions)
	{
		MemberInfo memberInfo = _typeMap.SourceType.GetMember(sourceMemberName).First();
		SourceMappingExpression obj = new SourceMappingExpression(_typeMap, memberInfo);
		memberOptions(obj);
		return this;
	}

	private static bool PassesDepthCheck(ResolutionContext context, int maxDepth)
	{
		if (context.InstanceCache.ContainsKey(context))
		{
			return true;
		}
		ResolutionContext resolutionContext = context;
		int num = 1;
		while (resolutionContext.Parent != null)
		{
			if ((object)resolutionContext.SourceType == context.TypeMap.SourceType && (object)resolutionContext.DestinationType == context.TypeMap.DestinationType)
			{
				num++;
			}
			resolutionContext = resolutionContext.Parent;
		}
		return num <= maxDepth;
	}

	public void Condition(Func<ResolutionContext, bool> condition)
	{
		_propertyMap.ApplyCondition(condition);
	}

	public void Ignore()
	{
		_propertyMap.Ignore();
	}

	public void UseDestinationValue()
	{
		_propertyMap.UseDestinationValue = true;
	}

	public void DoNotUseDestinationValue()
	{
		_propertyMap.UseDestinationValue = false;
	}

	public void SetMappingOrder(int mappingOrder)
	{
		_propertyMap.SetMappingOrder(mappingOrder);
	}

	public void ConstructFormatterBy(Type formatterType, Func<IValueFormatter> instantiator)
	{
		_propertyMap.RemoveLastFormatter();
		_propertyMap.AddFormatter(new DeferredInstantiatedFormatter((ResolutionContext ctxt) => instantiator()));
	}

	public void ConvertUsing(Func<TSource, TDestination> mappingFunction)
	{
		_typeMap.UseCustomMapper((ResolutionContext source) => mappingFunction((TSource)source.SourceValue));
	}

	public void ConvertUsing(Func<ResolutionContext, TDestination> mappingFunction)
	{
		_typeMap.UseCustomMapper((ResolutionContext context) => mappingFunction(context));
	}

	public void ConvertUsing(Func<ResolutionContext, TSource, TDestination> mappingFunction)
	{
		_typeMap.UseCustomMapper((ResolutionContext source) => mappingFunction(source, (TSource)source.SourceValue));
	}

	public void ConvertUsing(ITypeConverter<TSource, TDestination> converter)
	{
		ConvertUsing(converter.Convert);
	}

	public void ConvertUsing<TTypeConverter>() where TTypeConverter : ITypeConverter<TSource, TDestination>
	{
		DeferredInstantiatedConverter<TSource, TDestination> @object = new DeferredInstantiatedConverter<TSource, TDestination>(BuildCtor<ITypeConverter<TSource, TDestination>>(typeof(TTypeConverter)));
		ConvertUsing(@object.Convert);
	}

	public IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction)
	{
		_typeMap.AddBeforeMapAction(delegate(object src, object dest)
		{
			beforeFunction((TSource)src, (TDestination)dest);
		});
		return this;
	}

	public IMappingExpression<TSource, TDestination> BeforeMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>
	{
		Action<TSource, TDestination> beforeFunction = delegate(TSource src, TDestination dest)
		{
			((TMappingAction)_serviceCtor(typeof(TMappingAction))).Process(src, dest);
		};
		return BeforeMap(beforeFunction);
	}

	public IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination> afterFunction)
	{
		_typeMap.AddAfterMapAction(delegate(object src, object dest)
		{
			afterFunction((TSource)src, (TDestination)dest);
		});
		return this;
	}

	public IMappingExpression<TSource, TDestination> AfterMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>
	{
		Action<TSource, TDestination> afterFunction = delegate(TSource src, TDestination dest)
		{
			((TMappingAction)_serviceCtor(typeof(TMappingAction))).Process(src, dest);
		};
		return AfterMap(afterFunction);
	}

	public IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, TDestination> ctor)
	{
		return ConstructUsing((ResolutionContext ctxt) => ctor((TSource)ctxt.SourceValue));
	}

	public IMappingExpression<TSource, TDestination> ConstructUsing(Func<ResolutionContext, TDestination> ctor)
	{
		_typeMap.DestinationCtor = (ResolutionContext ctxt) => ctor(ctxt);
		return this;
	}

	private void ForDestinationMember(IMemberAccessor destinationProperty, Action<IMemberConfigurationExpression<TSource>> memberOptions)
	{
		_propertyMap = _typeMap.FindOrCreatePropertyMapFor(destinationProperty);
		memberOptions(this);
	}

	public void As<T>()
	{
		_typeMap.DestinationTypeOverride = typeof(T);
	}

	private Func<ResolutionContext, TServiceType> BuildCtor<TServiceType>(Type type)
	{
		return delegate(ResolutionContext context)
		{
			if (context.Options.ServiceCtor != null)
			{
				object obj = context.Options.ServiceCtor(type);
				if (obj != null)
				{
					return (TServiceType)obj;
				}
			}
			return (TServiceType)_serviceCtor(type);
		};
	}
}
