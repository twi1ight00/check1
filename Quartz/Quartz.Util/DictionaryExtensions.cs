using System.Collections.Generic;

namespace Quartz.Util;

/// <summary>
/// Extension methods for <see cref="T:System.Collections.Generic.IDictionary`2" />.
/// </summary>
public static class DictionaryExtensions
{
	/// <summary>
	/// Tries to read value and returns the value if successfully read. Otherwise return default value
	/// for value's type.
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	/// <param name="dictionary"></param>
	/// <param name="key"></param>
	/// <returns></returns>
	public static TValue TryGetAndReturn<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
	{
		if (!dictionary.TryGetValue(key, out var retValue))
		{
			retValue = default(TValue);
		}
		return retValue;
	}
}
