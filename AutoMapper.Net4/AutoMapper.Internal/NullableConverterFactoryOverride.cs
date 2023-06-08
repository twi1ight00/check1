using System;
using System.ComponentModel;

namespace AutoMapper.Internal;

public class NullableConverterFactoryOverride : INullableConverterFactory
{
	private class NullableConverterImpl : INullableConverter
	{
		private readonly NullableConverter _nullableConverter;

		public Type UnderlyingType => _nullableConverter.UnderlyingType;

		public NullableConverterImpl(NullableConverter nullableConverter)
		{
			_nullableConverter = nullableConverter;
		}

		public object ConvertFrom(object value)
		{
			return _nullableConverter.ConvertFrom(value);
		}
	}

	public INullableConverter Create(Type nullableType)
	{
		return new NullableConverterImpl(new NullableConverter(nullableType));
	}
}
