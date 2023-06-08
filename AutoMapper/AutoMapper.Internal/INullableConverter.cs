using System;

namespace AutoMapper.Internal;

public interface INullableConverter
{
	Type UnderlyingType { get; }

	object ConvertFrom(object value);
}
