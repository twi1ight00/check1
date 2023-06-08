using System;
using System.Linq;

namespace AutoMapper.Internal;

public class EnumNameValueMapperFactoryOverride : IEnumNameValueMapperFactory
{
	private class EnumVameValueMapper : IEnumNameValueMapper
	{
		public bool IsMatch(Type enumDestinationType, string sourceValue)
		{
			return !Enum.GetNames(enumDestinationType).Contains(sourceValue);
		}

		public object Convert(Type enumSourceType, Type enumDestinationType, ResolutionContext context)
		{
			Type underlyingType = Enum.GetUnderlyingType(enumSourceType);
			object value = System.Convert.ChangeType(context.SourceValue, underlyingType);
			return Enum.ToObject(context.DestinationType, value);
		}
	}

	public IEnumNameValueMapper Create()
	{
		return new EnumVameValueMapper();
	}
}
