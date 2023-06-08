using System;
using System.Collections.Generic;

namespace AutoMapper.Mappers;

public static class TypeMapObjectMapperRegistry
{
	private class CustomMapperStrategy : ITypeMapObjectMapper
	{
		public object Map(ResolutionContext context, IMappingEngineRunner mapper)
		{
			return context.TypeMap.CustomMapper(context);
		}

		public bool IsMatch(ResolutionContext context, IMappingEngineRunner mapper)
		{
			return context.TypeMap.CustomMapper != null;
		}
	}

	private class NullMappingStrategy : ITypeMapObjectMapper
	{
		public object Map(ResolutionContext context, IMappingEngineRunner mapper)
		{
			return null;
		}

		public bool IsMatch(ResolutionContext context, IMappingEngineRunner mapper)
		{
			IFormatterConfiguration profileConfiguration = mapper.ConfigurationProvider.GetProfileConfiguration(context.TypeMap.Profile);
			if (context.SourceValue == null)
			{
				return profileConfiguration.MapNullSourceValuesAsNull;
			}
			return false;
		}
	}

	private class CacheMappingStrategy : ITypeMapObjectMapper
	{
		public object Map(ResolutionContext context, IMappingEngineRunner mapper)
		{
			return context.InstanceCache[context];
		}

		public bool IsMatch(ResolutionContext context, IMappingEngineRunner mapper)
		{
			if (context.DestinationValue == null)
			{
				return context.InstanceCache.ContainsKey(context);
			}
			return false;
		}
	}

	private abstract class PropertyMapMappingStrategy : ITypeMapObjectMapper
	{
		public object Map(ResolutionContext context, IMappingEngineRunner mapper)
		{
			object mappedObject = GetMappedObject(context, mapper);
			if (context.SourceValue != null)
			{
				context.InstanceCache[context] = mappedObject;
			}
			context.TypeMap.BeforeMap(context.SourceValue, mappedObject);
			foreach (PropertyMap propertyMap in context.TypeMap.GetPropertyMaps())
			{
				MapPropertyValue(context.CreatePropertyMapContext(propertyMap), mapper, mappedObject, propertyMap);
			}
			mappedObject = ReassignValue(context, mappedObject);
			context.TypeMap.AfterMap(context.SourceValue, mappedObject);
			return mappedObject;
		}

		protected virtual object ReassignValue(ResolutionContext context, object o)
		{
			return o;
		}

		public abstract bool IsMatch(ResolutionContext context, IMappingEngineRunner mapper);

		protected abstract object GetMappedObject(ResolutionContext context, IMappingEngineRunner mapper);

		private void MapPropertyValue(ResolutionContext context, IMappingEngineRunner mapper, object mappedObject, PropertyMap propertyMap)
		{
			if (!propertyMap.CanResolveValue())
			{
				return;
			}
			Exception ex = null;
			ResolutionResult resolutionResult;
			try
			{
				resolutionResult = propertyMap.ResolveValue(context);
			}
			catch (AutoMapperMappingException)
			{
				throw;
			}
			catch (Exception inner)
			{
				ResolutionContext context2 = CreateErrorContext(context, propertyMap, null);
				ex = new AutoMapperMappingException(context2, inner);
				resolutionResult = new ResolutionResult(context);
			}
			if (resolutionResult.ShouldIgnore)
			{
				return;
			}
			object destinationValue = propertyMap.GetDestinationValue(mappedObject);
			Type type = resolutionResult.Type;
			Type memberType = propertyMap.DestinationProperty.MemberType;
			TypeMap typeMap = mapper.ConfigurationProvider.FindTypeMapFor(resolutionResult, memberType);
			Type sourceMemberType = ((typeMap != null) ? typeMap.SourceType : type);
			ResolutionContext context3 = context.CreateMemberContext(typeMap, resolutionResult.Value, destinationValue, sourceMemberType, propertyMap);
			if (!propertyMap.ShouldAssignValue(context3))
			{
				return;
			}
			if (ex != null)
			{
				throw ex;
			}
			try
			{
				object propertyValueToAssign = mapper.Map(context3);
				AssignValue(propertyMap, mappedObject, propertyValueToAssign);
			}
			catch (AutoMapperMappingException)
			{
				throw;
			}
			catch (Exception inner2)
			{
				throw new AutoMapperMappingException(context3, inner2);
			}
		}

		protected virtual void AssignValue(PropertyMap propertyMap, object mappedObject, object propertyValueToAssign)
		{
			if (propertyMap.CanBeSet)
			{
				propertyMap.DestinationProperty.SetValue(mappedObject, propertyValueToAssign);
			}
		}

		private ResolutionContext CreateErrorContext(ResolutionContext context, PropertyMap propertyMap, object destinationValue)
		{
			return context.CreateMemberContext(null, context.SourceValue, destinationValue, (context.SourceValue == null) ? typeof(object) : context.SourceValue.GetType(), propertyMap);
		}
	}

	private class NewObjectPropertyMapMappingStrategy : PropertyMapMappingStrategy
	{
		public override bool IsMatch(ResolutionContext context, IMappingEngineRunner mapper)
		{
			return context.DestinationValue == null;
		}

		protected override object GetMappedObject(ResolutionContext context, IMappingEngineRunner mapper)
		{
			return mapper.CreateObject(context);
		}
	}

	private class ExistingObjectMappingStrategy : PropertyMapMappingStrategy
	{
		public override bool IsMatch(ResolutionContext context, IMappingEngineRunner mapper)
		{
			return true;
		}

		protected override object GetMappedObject(ResolutionContext context, IMappingEngineRunner mapper)
		{
			return context.DestinationValue;
		}
	}

	private static readonly IList<ITypeMapObjectMapper> _mappers = new List<ITypeMapObjectMapper>
	{
		new CustomMapperStrategy(),
		new NullMappingStrategy(),
		new CacheMappingStrategy(),
		new NewObjectPropertyMapMappingStrategy(),
		new ExistingObjectMappingStrategy()
	};

	/// <summary>
	/// Extension point for mappers matching based on types configured by CreateMap
	/// </summary>
	public static IList<ITypeMapObjectMapper> Mappers => _mappers;
}
