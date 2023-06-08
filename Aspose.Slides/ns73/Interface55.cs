namespace ns73;

internal interface Interface55<T> : Interface54 where T : struct
{
	string imethod_2(T value);

	T imethod_3(string value);

	bool TryGetValue(string stringValue, out T value);
}
