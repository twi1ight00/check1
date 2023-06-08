using System;

namespace AutoMapper.Internal;

public class NullableConverterFactory : INullableConverterFactory
{
	private class NullableConverterImpl : INullableConverter
	{
		private readonly Type _nullableType;

		private readonly Type _underlyingType;

		public Type UnderlyingType => _underlyingType;

		public NullableConverterImpl(Type nullableType)
		{
			_nullableType = nullableType;
			_underlyingType = Nullable.GetUnderlyingType(_nullableType);
		}

		public object ConvertFrom(object value)
		{
			if (value == null)
			{
				return Activator.CreateInstance(_nullableType);
			}
			if ((object)value.GetType() == UnderlyingType)
			{
				return Activator.CreateInstance(_nullableType, value);
			}
			return Activator.CreateInstance(_nullableType, Convert.ChangeType(value, UnderlyingType, null));
		}
	}

	public INullableConverter Create(Type nullableType)
	{
		return new NullableConverterImpl(nullableType);
	}
}
