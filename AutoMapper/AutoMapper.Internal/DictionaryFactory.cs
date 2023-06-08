using System;
using System.Collections.Generic;

namespace AutoMapper.Internal;

public class DictionaryFactory : IDictionaryFactory
{
	private class DictionaryAdapter<TKey, TValue> : IDictionary<TKey, TValue>
	{
		private readonly Dictionary<TKey, TValue> _dictionary;

		public TValue this[TKey key]
		{
			get
			{
				lock (_dictionary)
				{
					return _dictionary[key];
				}
			}
			set
			{
				lock (_dictionary)
				{
					_dictionary[key] = value;
				}
			}
		}

		public DictionaryAdapter(Dictionary<TKey, TValue> dictionary)
		{
			_dictionary = dictionary;
		}

		public TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
		{
			lock (_dictionary)
			{
				TValue val = (_dictionary.ContainsKey(key) ? updateValueFactory(key, addValue) : addValue);
				_dictionary[key] = val;
				return val;
			}
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			lock (_dictionary)
			{
				return _dictionary.TryGetValue(key, out value);
			}
		}

		public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
		{
			lock (_dictionary)
			{
				if (_dictionary.ContainsKey(key))
				{
					return _dictionary[key];
				}
				TValue val = valueFactory(key);
				_dictionary[key] = val;
				return val;
			}
		}

		public bool TryRemove(TKey key, out TValue value)
		{
			lock (_dictionary)
			{
				if (!_dictionary.ContainsKey(key))
				{
					value = default(TValue);
					return false;
				}
				value = _dictionary[key];
				_dictionary.Remove(key);
				return true;
			}
		}
	}

	public IDictionary<TKey, TValue> CreateDictionary<TKey, TValue>()
	{
		return new DictionaryAdapter<TKey, TValue>(new Dictionary<TKey, TValue>());
	}
}
