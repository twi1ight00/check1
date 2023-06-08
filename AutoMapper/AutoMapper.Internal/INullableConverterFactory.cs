using System;

namespace AutoMapper.Internal;

public interface INullableConverterFactory
{
	INullableConverter Create(Type nullableType);
}
