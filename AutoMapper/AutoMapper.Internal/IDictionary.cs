using System;

namespace AutoMapper.Internal;

public interface IDictionary<TKey, TValue>
{
	TValue this[TKey key] { get; set; }

	TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory);

	bool TryGetValue(TKey key, out TValue value);

	TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);

	bool TryRemove(TKey key, out TValue value);
}
