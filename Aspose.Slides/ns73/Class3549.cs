using System;

namespace ns73;

internal abstract class Class3549<T> : Interface55<T>, Interface54 where T : struct
{
	public abstract string imethod_2(T value);

	public abstract bool TryGetValue(string token, out T value);

	public T imethod_3(string value)
	{
		if (!TryGetValue(value, out var value2))
		{
			throw new ArgumentException("value");
		}
		return value2;
	}

	string Interface54.imethod_0(object value)
	{
		return imethod_2((T)value);
	}

	object Interface54.imethod_1(string value)
	{
		return imethod_3(value);
	}
}
