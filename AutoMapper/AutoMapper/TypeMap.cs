using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper.Impl;

namespace AutoMapper;

/// <summary>
/// Main configuration object holding all mapping configuration for a source and destination type
/// </summary>
public class TypeMap
{
	private readonly IList<Action<object, object>> _afterMapActions = new List<Action<object, object>>();

	private readonly IList<Action<object, object>> _beforeMapActions = new List<Action<object, object>>();

	private readonly TypeInfo _destinationType;

	private readonly ISet<TypePair> _includedDerivedTypes = new HashSet<TypePair>();

	private readonly ThreadSafeList<PropertyMap> _propertyMaps = new ThreadSafeList<PropertyMap>();

	private readonly ThreadSafeList<SourceMemberConfig> _sourceMemberConfigs = new ThreadSafeList<SourceMemberConfig>();

	private readonly IList<PropertyMap> _inheritedMaps = new List<PropertyMap>();

	private PropertyMap[] _orderedPropertyMaps;

	private readonly TypeInfo _sourceType;

	private bool _sealed;

	private Func<ResolutionContext, bool> _condition;

	private ConstructorMap _constructorMap;

	public ConstructorMap ConstructorMap => _constructorMap;

	public Type SourceType => _sourceType.Type;

	public Type DestinationType => _destinationType.Type;

	public string Profile { get; set; }

	public Func<ResolutionContext, object> CustomMapper { get; private set; }

	public Action<object, object> BeforeMap => delegate(object src, object dest)
	{
		foreach (Action<object, object> beforeMapAction in _beforeMapActions)
		{
			beforeMapAction(src, dest);
		}
	};

	public Action<object, object> AfterMap => delegate(object src, object dest)
	{
		foreach (Action<object, object> afterMapAction in _afterMapActions)
		{
			afterMapAction(src, dest);
		}
	};

	public Func<ResolutionContext, object> DestinationCtor { get; set; }

	public List<string> IgnorePropertiesStartingWith { get; set; }

	public Type DestinationTypeOverride { get; set; }

	public bool ConstructDestinationUsingServiceLocator { get; set; }

	public MemberList ConfiguredMemberList { get; private set; }

	public TypeMap(TypeInfo sourceType, TypeInfo destinationType, MemberList memberList)
	{
		_sourceType = sourceType;
		_destinationType = destinationType;
		Profile = "";
		ConfiguredMemberList = memberList;
	}

	public IEnumerable<PropertyMap> GetPropertyMaps()
	{
		if (_sealed)
		{
			return _orderedPropertyMaps;
		}
		return _propertyMaps.Concat(_inheritedMaps);
	}

	public IEnumerable<PropertyMap> GetCustomPropertyMaps()
	{
		return _propertyMaps;
	}

	public void AddPropertyMap(PropertyMap propertyMap)
	{
		_propertyMaps.Add(propertyMap);
	}

	protected void AddInheritedMap(PropertyMap propertyMap)
	{
		_inheritedMaps.Add(propertyMap);
	}

	public void AddPropertyMap(IMemberAccessor destProperty, IEnumerable<IValueResolver> resolvers)
	{
		PropertyMap propertyMap = new PropertyMap(destProperty);
		resolvers.Each(propertyMap.ChainResolver);
		AddPropertyMap(propertyMap);
	}

	public string[] GetUnmappedPropertyNames()
	{
		IEnumerable<string> second = from pm in _propertyMaps
			where pm.IsMapped()
			select pm.DestinationProperty.Name;
		IEnumerable<string> second2 = from pm in _inheritedMaps
			where pm.IsMapped()
			select pm.DestinationProperty.Name;
		IEnumerable<string> source;
		if (ConfiguredMemberList == MemberList.Destination)
		{
			source = (from p in _destinationType.GetPublicWriteAccessors()
				select p.Name).Except(second).Except(second2);
		}
		else
		{
			IEnumerable<string> second3 = from pm in _propertyMaps
				where pm.IsMapped()
				where pm.CustomExpression != null
				where (object)pm.SourceMember != null
				select pm.SourceMember.Name;
			IEnumerable<string> second4 = from smc in _sourceMemberConfigs
				where smc.IsIgnored()
				select smc into pm
				select pm.SourceMember.Name;
			source = (from p in _sourceType.GetPublicReadAccessors()
				select p.Name).Except(second).Except(second2).Except(second3)
				.Except(second4);
		}
		return source.Where((string memberName) => !IgnorePropertiesStartingWith.Any(memberName.StartsWith)).ToArray();
	}

	public PropertyMap FindOrCreatePropertyMapFor(IMemberAccessor destinationProperty)
	{
		PropertyMap propertyMap = GetExistingPropertyMapFor(destinationProperty);
		if (propertyMap == null)
		{
			propertyMap = new PropertyMap(destinationProperty);
			AddPropertyMap(propertyMap);
		}
		return propertyMap;
	}

	public void IncludeDerivedTypes(Type derivedSourceType, Type derivedDestinationType)
	{
		_includedDerivedTypes.Add(new TypePair(derivedSourceType, derivedDestinationType));
	}

	public Type GetDerivedTypeFor(Type derivedSourceType)
	{
		TypePair typePair = _includedDerivedTypes.FirstOrDefault((TypePair tp) => (object)tp.SourceType == derivedSourceType);
		if (!typePair.Equals(default(TypePair)))
		{
			return typePair.DestinationType;
		}
		return DestinationType;
	}

	public bool TypeHasBeenIncluded(Type derivedSourceType, Type derivedDestinationType)
	{
		return _includedDerivedTypes.Contains(new TypePair(derivedSourceType, derivedDestinationType));
	}

	public bool HasDerivedTypesToInclude()
	{
		return _includedDerivedTypes.Any();
	}

	public void UseCustomMapper(Func<ResolutionContext, object> customMapper)
	{
		CustomMapper = customMapper;
		_propertyMaps.Clear();
	}

	public void AddBeforeMapAction(Action<object, object> beforeMap)
	{
		_beforeMapActions.Add(beforeMap);
	}

	public void AddAfterMapAction(Action<object, object> afterMap)
	{
		_afterMapActions.Add(afterMap);
	}

	public void Seal()
	{
		if (!_sealed)
		{
			_orderedPropertyMaps = (from map in _propertyMaps.Union(_inheritedMaps)
				orderby map.GetMappingOrder()
				select map).ToArray();
			_orderedPropertyMaps.Each(delegate(PropertyMap pm)
			{
				pm.Seal();
			});
			_sealed = true;
		}
	}

	public bool Equals(TypeMap other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other._sourceType, _sourceType))
		{
			return object.Equals(other._destinationType, _destinationType);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if ((object)obj.GetType() != typeof(TypeMap))
		{
			return false;
		}
		return Equals((TypeMap)obj);
	}

	public override int GetHashCode()
	{
		return (_sourceType.GetHashCode() * 397) ^ _destinationType.GetHashCode();
	}

	public PropertyMap GetExistingPropertyMapFor(IMemberAccessor destinationProperty)
	{
		return _propertyMaps.FirstOrDefault((PropertyMap pm) => pm.DestinationProperty.Name.Equals(destinationProperty.Name)) ?? _inheritedMaps.FirstOrDefault((PropertyMap pm) => pm.DestinationProperty.Name.Equals(destinationProperty.Name));
	}

	public void AddInheritedPropertyMap(PropertyMap mappedProperty)
	{
		_inheritedMaps.Add(mappedProperty);
	}

	public void InheritTypes(TypeMap inheritedTypeMap)
	{
		foreach (TypePair item in inheritedTypeMap._includedDerivedTypes.Where((TypePair includedDerivedType) => !_includedDerivedTypes.Contains(includedDerivedType)))
		{
			_includedDerivedTypes.Add(item);
		}
	}

	public void SetCondition(Func<ResolutionContext, bool> condition)
	{
		_condition = condition;
	}

	public bool ShouldAssignValue(ResolutionContext resolutionContext)
	{
		if (_condition != null)
		{
			return _condition(resolutionContext);
		}
		return true;
	}

	public void AddConstructorMap(ConstructorInfo constructorInfo, IEnumerable<ConstructorParameterMap> parameters)
	{
		ConstructorMap constructorMap = new ConstructorMap(constructorInfo, parameters);
		_constructorMap = constructorMap;
	}

	public SourceMemberConfig FindOrCreateSourceMemberConfigFor(MemberInfo sourceMember)
	{
		SourceMemberConfig sourceMemberConfig = _sourceMemberConfigs.FirstOrDefault((SourceMemberConfig smc) => (object)smc.SourceMember == sourceMember);
		if (sourceMemberConfig == null)
		{
			sourceMemberConfig = new SourceMemberConfig(sourceMember);
			_sourceMemberConfigs.Add(sourceMemberConfig);
		}
		return sourceMemberConfig;
	}
}
