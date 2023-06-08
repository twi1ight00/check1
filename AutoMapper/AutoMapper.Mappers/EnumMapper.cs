using System;
using AutoMapper.Internal;

namespace AutoMapper.Mappers;

public class EnumMapper : IObjectMapper
{
	private static readonly INullableConverterFactory NullableConverterFactory = PlatformAdapter.Resolve<INullableConverterFactory>();

	private static readonly IEnumNameValueMapperFactory EnumNameValueMapperFactory = PlatformAdapter.Resolve<IEnumNameValueMapperFactory>(throwIfNotFound: false);

	public object Map(ResolutionContext context, IMappingEngineRunner mapper)
	{
		bool toEnum = false;
		Type enumerationType = TypeHelper.GetEnumerationType(context.SourceType);
		Type enumerationType2 = TypeHelper.GetEnumerationType(context.DestinationType);
		if (EnumToStringMapping(context, ref toEnum))
		{
			if (context.SourceValue == null)
			{
				return mapper.CreateObject(context);
			}
			if (toEnum)
			{
				string value = context.SourceValue.ToString();
				if (string.IsNullOrEmpty(value))
				{
					return mapper.CreateObject(context);
				}
				return Enum.Parse(enumerationType2, value, ignoreCase: true);
			}
			return Enum.GetName(enumerationType, context.SourceValue);
		}
		if (EnumToEnumMapping(context))
		{
			if (context.SourceValue == null)
			{
				if (mapper.ShouldMapSourceValueAsNull(context) && context.DestinationType.IsNullableType())
				{
					return null;
				}
				return mapper.CreateObject(context);
			}
			if (!Enum.IsDefined(enumerationType, context.SourceValue))
			{
				return Enum.ToObject(enumerationType2, context.SourceValue);
			}
			if (FeatureDetector.IsEnumGetNamesSupported)
			{
				IEnumNameValueMapper enumNameValueMapper = EnumNameValueMapperFactory.Create();
				if (enumNameValueMapper.IsMatch(enumerationType2, context.SourceValue.ToString()))
				{
					return enumNameValueMapper.Convert(enumerationType, enumerationType2, context);
				}
			}
			return Enum.Parse(enumerationType2, Enum.GetName(enumerationType, context.SourceValue), ignoreCase: true);
		}
		if (EnumToUnderlyingTypeMapping(context, ref toEnum))
		{
			if (toEnum)
			{
				return Enum.Parse(enumerationType2, context.SourceValue.ToString(), ignoreCase: true);
			}
			if (EnumToNullableTypeMapping(context))
			{
				return ConvertEnumToNullableType(context);
			}
			return Convert.ChangeType(context.SourceValue, context.DestinationType, null);
		}
		return null;
	}

	public bool IsMatch(ResolutionContext context)
	{
		bool toEnum = false;
		if (!EnumToStringMapping(context, ref toEnum) && !EnumToEnumMapping(context))
		{
			return EnumToUnderlyingTypeMapping(context, ref toEnum);
		}
		return true;
	}

	private static bool EnumToEnumMapping(ResolutionContext context)
	{
		Type enumerationType = TypeHelper.GetEnumerationType(context.SourceType);
		Type enumerationType2 = TypeHelper.GetEnumerationType(context.DestinationType);
		if ((object)enumerationType != null)
		{
			return (object)enumerationType2 != null;
		}
		return false;
	}

	private static bool EnumToUnderlyingTypeMapping(ResolutionContext context, ref bool toEnum)
	{
		Type enumerationType = TypeHelper.GetEnumerationType(context.SourceType);
		Type enumerationType2 = TypeHelper.GetEnumerationType(context.DestinationType);
		if ((object)enumerationType != null)
		{
			return context.DestinationType.IsAssignableFrom(Enum.GetUnderlyingType(enumerationType));
		}
		if ((object)enumerationType2 != null)
		{
			toEnum = true;
			return context.SourceType.IsAssignableFrom(Enum.GetUnderlyingType(enumerationType2));
		}
		return false;
	}

	private static bool EnumToStringMapping(ResolutionContext context, ref bool toEnum)
	{
		Type enumerationType = TypeHelper.GetEnumerationType(context.SourceType);
		Type enumerationType2 = TypeHelper.GetEnumerationType(context.DestinationType);
		if ((object)enumerationType != null)
		{
			return context.DestinationType.IsAssignableFrom(typeof(string));
		}
		if ((object)enumerationType2 != null)
		{
			toEnum = true;
			return context.SourceType.IsAssignableFrom(typeof(string));
		}
		return false;
	}

	private static bool EnumToNullableTypeMapping(ResolutionContext context)
	{
		if (!context.DestinationType.IsGenericType)
		{
			return false;
		}
		Type genericTypeDefinition = context.DestinationType.GetGenericTypeDefinition();
		return genericTypeDefinition.Equals(typeof(Nullable<>));
	}

	private static object ConvertEnumToNullableType(ResolutionContext context)
	{
		INullableConverter nullableConverter = NullableConverterFactory.Create(context.DestinationType);
		if (context.IsSourceValueNull)
		{
			return nullableConverter.ConvertFrom(context.SourceValue);
		}
		Type underlyingType = nullableConverter.UnderlyingType;
		return Convert.ChangeType(context.SourceValue, underlyingType, null);
	}
}
