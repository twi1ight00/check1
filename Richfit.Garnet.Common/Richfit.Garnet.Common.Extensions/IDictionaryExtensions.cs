using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// IDictionary泛型口扩展方法类
/// </summary>
public static class IDictionaryExtensions
{
	/// <summary>
	/// 向当前字典中添加键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">添加的值</param>
	/// <param name="keySelection">从添加的值中提取键的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static void Add<K, V>(this IDictionary<K, V> dictionary, V value, Func<V, K> keySelection)
	{
		dictionary.GuardNotNull("dictionary");
		keySelection.GuardNotNull("key selection");
		K key = keySelection(value);
		if (dictionary.ContainsKey(key))
		{
			throw new ArgumentException(Literals.MSG_DictionaryKeyExisted_1.FormatValue(key));
		}
		dictionary.Add(key, value);
	}

	/// <summary>
	/// 向当前字典中添加键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="item">添加的项目</param>
	/// <param name="keySelection">从添加的项目中提取键的方法</param>
	/// <param name="valueSelection">从添加的项目中提取值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static void Add<K, V, S>(this IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		dictionary.GuardNotNull("dictionary");
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		K key = keySelection(item);
		V value = valueSelection(item);
		if (dictionary.ContainsKey(key))
		{
			throw new ArgumentException(Literals.MSG_DictionaryKeyExisted_1.FormatValue(key));
		}
		dictionary.Add(key, value);
	}

	/// <summary>
	/// 向当前字典中添加键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static void Add<K, V>(this IDictionary<K, V> dictionary, Tuple<K, V> pair)
	{
		dictionary.GuardNotNull("dictionary");
		pair.GuardNotNull("pair");
		if (dictionary.ContainsKey(pair.Item1))
		{
			throw new ArgumentException(Literals.MSG_DictionaryKeyExisted_1.FormatValue(pair.Item1));
		}
		dictionary.Add(pair.Item1, pair.Item2);
	}

	/// <summary>
	/// 向当前字典中添加键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static void Add<K, V>(this IDictionary<K, V> dictionary, KeyValuePair<K, V> pair)
	{
		dictionary.GuardNotNull("dictionary");
		pair.GuardNotNull("pair");
		if (dictionary.ContainsKey(pair.Key))
		{
			throw new ArgumentException(Literals.MSG_DictionaryKeyExisted_1.FormatValue(pair.Key));
		}
		dictionary.Add(pair.Key, pair.Value);
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">添加的键</param>
	/// <param name="value">添加的值</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static V AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, K key, V value)
	{
		dictionary.GuardNotNull("dictionary");
		V oldValue;
		if (dictionary.ContainsKey(key))
		{
			oldValue = dictionary[key];
			dictionary[key] = value;
		}
		else
		{
			oldValue = default(V);
			dictionary.Add(key, value);
		}
		return oldValue;
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">添加的键</param>
	/// <param name="value">添加的值</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static void AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, K key, V value, Func<K, V, V> valueUpdating)
	{
		dictionary.GuardNotNull("dictionary");
		if (dictionary.ContainsKey(key))
		{
			dictionary[key] = (valueUpdating.IsNull() ? value : valueUpdating(key, dictionary[key]));
		}
		else
		{
			dictionary.Add(key, value);
		}
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">添加的值</param>
	/// <param name="keySelection">从添加的对象中提取键的方法</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static V AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, V value, Func<V, K> keySelection)
	{
		keySelection.GuardNotNull("key selection");
		return dictionary.AddOrUpdate(keySelection(value), value);
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">添加的值</param>
	/// <param name="keySelection">从添加的对象中提取键的方法</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static void AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, V value, Func<V, K> keySelection, Func<K, V, V> valueUpdating)
	{
		keySelection.GuardNotNull("key selection");
		dictionary.AddOrUpdate(keySelection(value), value, valueUpdating);
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="item">添加的项目</param>
	/// <param name="keySelection">从添加的对象中提取键的方法</param>
	/// <param name="valueSelection">从添加的对象中提取值的方法</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static V AddOrUpdate<K, V, S>(this IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		return dictionary.AddOrUpdate(keySelection(item), valueSelection(item));
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="item">添加的项目</param>
	/// <param name="keySelection">从添加的对象中提取键的方法</param>
	/// <param name="valueSelection">从添加的对象中提取值的方法</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static void AddOrUpdate<K, V, S>(this IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection, Func<K, V, V> valueUpdating)
	{
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		dictionary.AddOrUpdate(keySelection(item), valueSelection(item), valueUpdating);
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static V AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, Tuple<K, V> pair)
	{
		pair.GuardNotNull("pair");
		return dictionary.AddOrUpdate(pair.Item1, pair.Item2);
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static void AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, Tuple<K, V> pair, Func<K, V, V> valueUpdating)
	{
		pair.GuardNotNull("pair");
		dictionary.AddOrUpdate(pair.Item1, pair.Item2, valueUpdating);
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static V AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, KeyValuePair<K, V> pair)
	{
		pair.GuardNotNull("pair");
		return dictionary.AddOrUpdate(pair.Key, pair.Value);
	}

	/// <summary>
	/// 向当前字典中添加键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static void AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, KeyValuePair<K, V> pair, Func<K, V, V> valueUpdating)
	{
		pair.GuardNotNull("pair");
		dictionary.AddOrUpdate(pair.Key, pair.Value, valueUpdating);
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="keys">添加的键序列</param>
	/// <param name="values">添加的值序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键序列 <paramref name="keys" /> 为空；或者添加的值序列 <paramref name="values" /> 为空。</exception>
	public static void AddRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<K> keys, IEnumerable<V> values)
	{
		dictionary.GuardNotNull("dictionary");
		keys.GuardNotNull("keys");
		values.GuardNotNull("values");
		IEnumerator<K> keyEnumer = null;
		IEnumerator<V> valueEnumer = null;
		try
		{
			keyEnumer = keys.GetEnumerator();
			valueEnumer = values.GetEnumerator();
			while (keyEnumer.MoveNext() && valueEnumer.MoveNext())
			{
				dictionary.Add(keyEnumer.Current, valueEnumer.Current);
			}
		}
		finally
		{
			if (keyEnumer.IsNotNull())
			{
				keyEnumer.Dispose();
			}
			if (valueEnumer.IsNotNull())
			{
				valueEnumer.Dispose();
			}
		}
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="values">添加的值序列</param>
	/// <param name="keySelection">从添加的值中提取键的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的值序列 <paramref name="values" /> 为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static void AddRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<V> values, Func<V, K> keySelection)
	{
		dictionary.GuardNotNull("dictionary");
		values.GuardNotNull("values");
		keySelection.GuardNotNull("key selection");
		dictionary.AddRange(values.Select((V v) => keySelection(v)), values);
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="keySelection">从添加的项目中提取键的方法</param>
	/// <param name="valueSelection">从添加的项目中提取值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的项目序列 <paramref name="items" /> 为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static void AddRange<K, V, S>(this IDictionary<K, V> dictionary, IEnumerable<S> items, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		dictionary.GuardNotNull("dictionary");
		items.GuardNotNull("values");
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		dictionary.AddRange(items.Select((S x) => keySelection(x)), items.Select((S x) => valueSelection(x)));
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pairs" /> 为空。</exception>
	public static void AddRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<Tuple<K, V>> pairs)
	{
		dictionary.GuardNotNull("dictionary");
		pairs.GuardNotNull("pairs");
		dictionary.AddRange(pairs.Select((Tuple<K, V> x) => x.Item1), pairs.Select((Tuple<K, V> x) => x.Item2));
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pairs" /> 为空。</exception>
	public static void AddRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<KeyValuePair<K, V>> pairs)
	{
		dictionary.GuardNotNull("dictionary");
		pairs.GuardNotNull("pairs");
		dictionary.AddRange(pairs.Select((KeyValuePair<K, V> x) => x.Key), pairs.Select((KeyValuePair<K, V> x) => x.Value));
	}

	/// <summary>
	/// 向当前字典中添加多个键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="keys">添加的键序列</param>
	/// <param name="values">添加的值序列</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键序列 <paramref name="keys" /> 为空；或者添加的值序列 <paramref name="values" /> 为空。</exception>
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<K> keys, IEnumerable<V> values)
	{
		dictionary.GuardNotNull("dictionary");
		keys.GuardNotNull("keys");
		values.GuardNotNull("values");
		IEnumerator<K> keyEnumer = null;
		IEnumerator<V> valueEnumer = null;
		try
		{
			keyEnumer = keys.GetEnumerator();
			valueEnumer = values.GetEnumerator();
			while (keyEnumer.MoveNext() && valueEnumer.MoveNext())
			{
				yield return new KeyValuePair<K, V>(value: dictionary.AddOrUpdate(keyEnumer.Current, valueEnumer.Current), key: keyEnumer.Current);
			}
		}
		finally
		{
			if (keyEnumer.IsNotNull())
			{
				keyEnumer.Dispose();
			}
			if (valueEnumer.IsNotNull())
			{
				valueEnumer.Dispose();
			}
		}
	}

	/// <summary>
	/// 向当前字典中添加多个键值对；如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="keys">添加的键序列</param>
	/// <param name="values">添加的值序列</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键序列 <paramref name="keys" /> 为空；或者添加的值序列 <paramref name="values" /> 为空。</exception>
	public static void AddOrUpdateRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<K> keys, IEnumerable<V> values, Func<K, V, V> valueUpdating)
	{
		dictionary.GuardNotNull("dictionary");
		keys.GuardNotNull("keys");
		values.GuardNotNull("values");
		IEnumerator<K> keyEnumer = null;
		IEnumerator<V> valueEnumer = null;
		try
		{
			keyEnumer = keys.GetEnumerator();
			valueEnumer = values.GetEnumerator();
			while (keyEnumer.MoveNext() && valueEnumer.MoveNext())
			{
				dictionary.AddOrUpdate(keyEnumer.Current, valueEnumer.Current, valueUpdating);
			}
		}
		finally
		{
			if (keyEnumer.IsNotNull())
			{
				keyEnumer.Dispose();
			}
			if (valueEnumer.IsNotNull())
			{
				valueEnumer.Dispose();
			}
		}
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="values">添加的值序列</param>
	/// <param name="keySelection">从添加的值中提取键的方法</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的值序列 <paramref name="values" /> 为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<V> values, Func<V, K> keySelection)
	{
		dictionary.GuardNotNull("dictionary");
		values.GuardNotNull("values");
		keySelection.GuardNotNull("key selection");
		return dictionary.AddOrUpdateRange(values.Select((V v) => keySelection(v)), values);
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="values">添加的值序列</param>
	/// <param name="keySelection">从添加的值中提取键的方法</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的值序列 <paramref name="values" /> 为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static void AddOrUpdateRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<V> values, Func<V, K> keySelection, Func<K, V, V> valueUpdating)
	{
		dictionary.GuardNotNull("dictionary");
		values.GuardNotNull("values");
		keySelection.GuardNotNull("key selection");
		dictionary.AddOrUpdateRange(values.Select((V v) => keySelection(v)), values, valueUpdating);
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="keySelection">从添加的项目中提取键的方法</param>
	/// <param name="valueSelection">从添加的项目中提取值的方法</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的项目序列 <paramref name="items" /> 为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V, S>(this IDictionary<K, V> dictionary, IEnumerable<S> items, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		dictionary.GuardNotNull("dictionary");
		items.GuardNotNull("values");
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		return dictionary.AddOrUpdateRange(items.Select((S x) => keySelection(x)), items.Select((S x) => valueSelection(x)));
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="keySelection">从添加的项目中提取键的方法</param>
	/// <param name="valueSelection">从添加的项目中提取值的方法</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的项目序列 <paramref name="items" /> 为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static void AddOrUpdateRange<K, V, S>(this IDictionary<K, V> dictionary, IEnumerable<S> items, Func<S, K> keySelection, Func<S, V> valueSelection, Func<K, V, V> valueUpdating)
	{
		dictionary.GuardNotNull("dictionary");
		items.GuardNotNull("values");
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		dictionary.AddOrUpdateRange(items.Select((S x) => keySelection(x)), items.Select((S x) => valueSelection(x)), valueUpdating);
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对序列 <paramref name="pairs" /> 为空。</exception>
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<Tuple<K, V>> pairs)
	{
		dictionary.GuardNotNull("dictionary");
		pairs.GuardNotNull("pairs");
		return dictionary.AddOrUpdateRange(pairs.Select((Tuple<K, V> p) => p.Item1), pairs.Select((Tuple<K, V> p) => p.Item2));
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对序列 <paramref name="pairs" /> 为空。</exception>
	public static void AddOrUpdateRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<Tuple<K, V>> pairs, Func<K, V, V> valueUpdating)
	{
		dictionary.GuardNotNull("dictionary");
		pairs.GuardNotNull("pairs");
		dictionary.AddOrUpdateRange(pairs.Select((Tuple<K, V> p) => p.Item1), pairs.Select((Tuple<K, V> p) => p.Item2), valueUpdating);
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <returns>如果指定键值已经存在则返回现有的键值，否则返回添加的键值的类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对序列 <paramref name="pairs" /> 为空。</exception>
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<KeyValuePair<K, V>> pairs)
	{
		dictionary.GuardNotNull("dictionary");
		pairs.GuardNotNull("pairs");
		return dictionary.AddOrUpdateRange(pairs.Select((KeyValuePair<K, V> p) => p.Key), pairs.Select((KeyValuePair<K, V> p) => p.Value));
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则更新该键的值。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对序列 <paramref name="pairs" /> 为空。</exception>
	public static void AddOrUpdateRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<KeyValuePair<K, V>> pairs, Func<K, V, V> valueUpdating)
	{
		dictionary.GuardNotNull("dictionary");
		pairs.GuardNotNull("pairs");
		dictionary.AddOrUpdateRange(pairs.Select((KeyValuePair<K, V> p) => p.Key), pairs.Select((KeyValuePair<K, V> p) => p.Value), valueUpdating);
	}

	/// <summary>
	/// 检测当前字典中是否包含指定的键
	/// </summary>
	/// <typeparam name="K">字典键类型</typeparam>
	/// <typeparam name="V">字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">查找的键</param>
	/// <param name="equaliter">键相等比较器</param>
	/// <returns>如果当前字典中存在指定的键返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static bool ContainsKey<K, V>(this IDictionary<K, V> dictionary, K key, IEqualityComparer<K> equaliter)
	{
		dictionary.GuardNotNull("dictionary");
		return dictionary.Keys.Contains(key, equaliter);
	}

	/// <summary>
	/// 检测当前字典中是否包含指定的键
	/// </summary>
	/// <typeparam name="K">字典键类型</typeparam>
	/// <typeparam name="V">字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">查找的键</param>
	/// <param name="equalition">键相等比较方法</param>
	/// <returns>如果当前字典中存在指定的键返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static bool ContainsKey<K, V>(this IDictionary<K, V> dictionary, K key, Func<K, K, bool> equalition)
	{
		dictionary.GuardNotNull("dictionary");
		return dictionary.Keys.Contains(key, equalition);
	}

	/// <summary>
	/// 检测当前字典中是否包含指定的值
	/// </summary>
	/// <typeparam name="K">字典键类型</typeparam>
	/// <typeparam name="V">字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">查找的值</param>
	/// <returns>如果当前字典中存在指定的值返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static bool ContainsValue<K, V>(this IDictionary<K, V> dictionary, V value)
	{
		dictionary.GuardNotNull("dictionary");
		return dictionary.Values.Contains(value, EqualityComparer<V>.Default);
	}

	/// <summary>
	/// 检测当前字典中是否包含指定的值
	/// </summary>
	/// <typeparam name="K">字典键类型</typeparam>
	/// <typeparam name="V">字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">查找的值</param>
	/// <param name="equaliter">值相等比较器</param>
	/// <returns>如果当前字典中存在指定的值返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static bool ContainsValue<K, V>(this IDictionary<K, V> dictionary, V value, IEqualityComparer<V> equaliter)
	{
		dictionary.GuardNotNull("dictionary");
		return dictionary.Values.Contains(value, equaliter);
	}

	/// <summary>
	/// 检测当前字典中是否包含指定的值
	/// </summary>
	/// <typeparam name="K">字典键类型</typeparam>
	/// <typeparam name="V">字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">查找的值</param>
	/// <param name="equalition">值相等比较方法</param>
	/// <returns>如果当前字典中存在指定的值返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static bool ContainsValue<K, V>(this IDictionary<K, V> dictionary, V value, Func<V, V, bool> equalition)
	{
		dictionary.GuardNotNull("dictionary");
		return dictionary.Values.Contains(value, equalition);
	}

	/// <summary>
	/// 获取当前字典中指定键的值，如果指定键不存在则抛出 <see cref="T:System.Collections.Generic.KeyNotFoundException" />。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">获取值的键</param>
	/// <returns>当前字典中获取的指定键的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static V Get<K, V>(this IDictionary<K, V> dictionary, K key)
	{
		dictionary.GuardNotNull("dictionary");
		if (dictionary.ContainsKey(key))
		{
			return dictionary[key];
		}
		throw new KeyNotFoundException(Literals.MSG_DictionaryKeyNotFound_1.FormatValue(key));
	}

	/// <summary>
	/// 获取当前字典的键和值的数组，键和值的数组中的元素按顺寻一一对应。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <returns>当前字典的键和值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static Tuple<K[], V[]> GetKeyValues<K, V>(this IDictionary<K, V> dictionary)
	{
		dictionary.GuardNotNull("dictionary");
		List<K> ks = new List<K>(dictionary.Count);
		List<V> vs = new List<V>(dictionary.Count);
		foreach (KeyValuePair<K, V> kvp in dictionary)
		{
			ks.Add(kvp.Key);
			vs.Add(kvp.Value);
		}
		return new Tuple<K[], V[]>(ks.ToArray(), vs.ToArray());
	}

	/// <summary>
	/// 获取当前字典中指定键的值，如果指定的键不存在则添加 <paramref name="value" /> 指定的键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">获取值的键</param>
	/// <param name="value">指定的键不存在时，添加的默认值键值</param>
	/// <returns>当前字典中获取的指定键的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static V GetOrAdd<K, V>(this IDictionary<K, V> dictionary, K key, V value = default(V))
	{
		dictionary.GuardNotNull("dictionary");
		if (dictionary.ContainsKey(key))
		{
			return dictionary[key];
		}
		dictionary.Add(key, value);
		return value;
	}

	/// <summary>
	/// 获取当前字典中指定键的值，如果指定的键不存在则返回指定的默认值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">获取值的键</param>
	/// <param name="defaultValue">获取的键的默认值</param>
	/// <returns>当前字典中获取的指定键的值，或者值类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static V GetOrDefault<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue = default(V))
	{
		dictionary.GuardNotNull("dictionary");
		return dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
	}

	/// <summary>
	/// 将目标字典合并到当前字典中
	/// </summary>
	/// <typeparam name="K">字典的键类型</typeparam>
	/// <typeparam name="V">字典的值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="merging">合并的当前字典</param>
	/// <param name="overwrite">是否覆盖相同键的值</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者合并的目标字典 <paramref name="merging" /> 为空。</exception>
	public static void Merge<K, V>(this IDictionary<K, V> dictionary, IDictionary<K, V> merging, bool overwrite = false)
	{
		dictionary.GuardNotNull("dictionary");
		merging.GuardNotNull("target");
		foreach (KeyValuePair<K, V> kvp in merging)
		{
			if (dictionary.ContainsKey(kvp.Key) && overwrite)
			{
				dictionary[kvp.Key] = kvp.Value;
			}
			else
			{
				dictionary.Add(kvp.Key, kvp.Value);
			}
		}
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则抛出 <see cref="T:System.Collections.Generic.KeyNotFoundException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">设置的键</param>
	/// <param name="value">设置的值</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static void Set<K, V>(this IDictionary<K, V> dictionary, K key, V value)
	{
		dictionary.GuardNotNull("dictionary");
		if (dictionary.ContainsKey(key))
		{
			dictionary[key] = value;
			return;
		}
		throw new KeyNotFoundException(Literals.MSG_DictionaryKeyNotFound_1.FormatValue(key));
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典的键类型</typeparam>
	/// <typeparam name="V">当前字典的值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">设置的键</param>
	/// <param name="value">设置的值</param>
	/// <returns>如果指定的键存在则返回现有值，否则返回新设置的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static V SetOrAdd<K, V>(this IDictionary<K, V> dictionary, K key, V value)
	{
		dictionary.GuardNotNull("dictionary");
		V oldValue;
		if (dictionary.ContainsKey(key))
		{
			oldValue = dictionary[key];
			dictionary[key] = value;
		}
		else
		{
			oldValue = value;
			dictionary.Add(key, value);
		}
		return oldValue;
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典的键类型</typeparam>
	/// <typeparam name="V">当前字典的值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">设置的键</param>
	/// <param name="value">设置的值</param>
	/// <param name="valueUpdating">键值更新方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static void SetOrAdd<K, V>(this IDictionary<K, V> dictionary, K key, V value, Func<K, V, V> valueUpdating)
	{
		dictionary.GuardNotNull("dictionary");
		if (dictionary.ContainsKey(key))
		{
			dictionary[key] = (valueUpdating.IsNull() ? value : valueUpdating(key, dictionary[key]));
		}
		else
		{
			dictionary.Add(key, value);
		}
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">添加的值</param>
	/// <param name="keySelection">从添加的对象中提取键的方法</param>
	/// <returns>如果指定的键存在则返回现有值，否则返回新设置的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static V SetOrAdd<K, V>(this IDictionary<K, V> dictionary, V value, Func<V, K> keySelection)
	{
		keySelection.GuardNotNull("key selection");
		return dictionary.SetOrAdd(keySelection(value), value);
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">添加的值</param>
	/// <param name="keySelection">从添加的对象中提取键的方法</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static void SetOrAdd<K, V>(this IDictionary<K, V> dictionary, V value, Func<V, K> keySelection, Func<K, V, V> valueUpdating)
	{
		keySelection.GuardNotNull("key selection");
		dictionary.SetOrAdd(keySelection(value), value, valueUpdating);
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="item">添加的项目</param>
	/// <param name="keySelection">从添加的对象中提取键的方法</param>
	/// <param name="valueSelection">从添加的对象中提取值的方法</param>
	/// <returns>如果指定的键存在则返回现有值，否则返回新设置的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static V SetOrAdd<K, V, S>(this IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		return dictionary.SetOrAdd(keySelection(item), valueSelection(item));
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="item">添加的项目</param>
	/// <param name="keySelection">从添加的对象中提取键的方法</param>
	/// <param name="valueSelection">从添加的对象中提取值的方法</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static void SetOrAdd<K, V, S>(this IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection, Func<K, V, V> valueUpdating)
	{
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		dictionary.SetOrAdd(keySelection(item), valueSelection(item), valueUpdating);
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <returns>如果指定的键存在则返回现有值，否则返回新设置的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static V SetOrAdd<K, V>(this IDictionary<K, V> dictionary, Tuple<K, V> pair)
	{
		pair.GuardNotNull("pair");
		return dictionary.SetOrAdd(pair.Item1, pair.Item2);
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static void SetOrAdd<K, V>(this IDictionary<K, V> dictionary, Tuple<K, V> pair, Func<K, V, V> valueUpdating)
	{
		pair.GuardNotNull("pair");
		dictionary.SetOrAdd(pair.Item1, pair.Item2, valueUpdating);
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <returns>如果指定的键存在则返回现有值，否则返回新设置的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static V SetOrAdd<K, V>(this IDictionary<K, V> dictionary, KeyValuePair<K, V> pair)
	{
		pair.GuardNotNull("pair");
		return dictionary.SetOrAdd(pair.Key, pair.Value);
	}

	/// <summary>
	/// 设置当前字典中指定键的键值，如果指定的键不存在则添加该键值
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <param name="valueUpdating">当前添加的键存在时，根据现有键值生成新键值的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static void SetOrAdd<K, V>(this IDictionary<K, V> dictionary, KeyValuePair<K, V> pair, Func<K, V, V> valueUpdating)
	{
		pair.GuardNotNull("pair");
		dictionary.SetOrAdd(pair.Key, pair.Value, valueUpdating);
	}

	/// <summary>
	/// 尝试向当前字典中添加键值对，如果添加成功返回true，如果指定的键已经存在则返回false
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">添加的键</param>
	/// <param name="value">添加的值</param>
	/// <returns>如果添加成功返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static bool TryAdd<K, V>(this IDictionary<K, V> dictionary, K key, V value)
	{
		dictionary.GuardNotNull("dictionary");
		if (dictionary.ContainsKey(key))
		{
			return false;
		}
		dictionary.Add(key, value);
		return true;
	}

	/// <summary>
	/// 尝试向当前字典中添加键值对，如果添加成功返回true，如果指定的键已经存在则返回false
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">添加的值</param>
	/// <param name="keySelection">从添加的值中提取键的方法</param>
	/// <returns>如果添加成功返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static bool TryAdd<K, V>(this IDictionary<K, V> dictionary, V value, Func<V, K> keySelection)
	{
		keySelection.GuardNotNull("key selection");
		return dictionary.TryAdd(keySelection(value), value);
	}

	/// <summary>
	/// 尝试向当前字典中添加键值对，如果添加成功返回true，如果指定的键已经存在则返回false
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="item">添加的项目</param>
	/// <param name="keySelection">从添加的项目中提取键的方法</param>
	/// <param name="valueSelection">从添加的项目中提取值的方法</param>
	/// <returns>如果添加成功返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static bool TryAdd<K, V, S>(this IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		return dictionary.TryAdd(keySelection(item), valueSelection(item));
	}

	/// <summary>
	/// 尝试向当前字典中添加键值对，如果添加成功返回true，如果指定的键已经存在则返回false
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <returns>如果添加成功返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static bool TryAdd<K, V>(this IDictionary<K, V> dictionary, Tuple<K, V> pair)
	{
		pair.GuardNotNull("pair");
		return dictionary.TryAdd(pair.Item1, pair.Item2);
	}

	/// <summary>
	/// 尝试向当前字典中添加键值对，如果添加成功返回true，如果指定的键已经存在则返回false
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pair">添加的键值对</param>
	/// <returns>如果添加成功返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pair" /> 为空。</exception>
	public static bool TryAdd<K, V>(this IDictionary<K, V> dictionary, KeyValuePair<K, V> pair)
	{
		pair.GuardNotNull("pair");
		return dictionary.TryAdd(pair.Key, pair.Value);
	}

	/// <summary>
	/// 尝试向当前字典中添加多个键值对，忽略已经存在的键，返回成功添加的键值对的数量
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="keys">添加的键序列</param>
	/// <param name="values">添加的值序列</param>
	/// <returns>返回实际添加成功的键值对的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键序列 <paramref name="keys" /> 为空；或者添加的值序列 <paramref name="values" /> 为空。</exception>
	public static int TryAddRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<K> keys, IEnumerable<V> values)
	{
		dictionary.GuardNotNull("dictionary");
		keys.GuardNotNull("keys");
		values.GuardNotNull("values");
		IEnumerator<K> keyEnumer = null;
		IEnumerator<V> valueEnumer = null;
		int count = 0;
		try
		{
			keyEnumer = keys.GetEnumerator();
			valueEnumer = values.GetEnumerator();
			while (keyEnumer.MoveNext() && valueEnumer.MoveNext())
			{
				if (dictionary.TryAdd(keyEnumer.Current, valueEnumer.Current))
				{
					count++;
				}
			}
		}
		finally
		{
			if (keyEnumer.IsNotNull())
			{
				keyEnumer.Dispose();
			}
			if (valueEnumer.IsNotNull())
			{
				valueEnumer.Dispose();
			}
		}
		return count;
	}

	/// <summary>
	/// 尝试向当前字典中添加多个键值对，忽略已经存在的键，返回成功添加的键值对的数量
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="values">添加的值序列</param>
	/// <param name="keySelection">从添加的值中提取键的方法</param>
	/// <returns>返回实际添加成功的键值对的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的值序列 <paramref name="values" /> 为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static int TryAddRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<V> values, Func<V, K> keySelection)
	{
		dictionary.GuardNotNull("dictionary");
		values.GuardNotNull("values");
		keySelection.GuardNotNull("key selection");
		return dictionary.TryAddRange(values.Select((V v) => keySelection(v)), values);
	}

	/// <summary>
	/// 尝试向当前字典中添加多个键值对，忽略已经存在的键，返回成功添加的键值对的数量
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <typeparam name="S">添加的项目类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="keySelection">从添加的项目中提取键的方法</param>
	/// <param name="valueSelection">从添加的项目中提取值的方法</param>
	/// <returns>返回实际添加成功的键值对的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的项目序列 <paramref name="items" /> 为空；或者键提取方法 <paramref name="keySelection" /> 为空；或者值提取方法 <paramref name="valueSelection" /> 为空。</exception>
	public static int TryAddRange<K, V, S>(this IDictionary<K, V> dictionary, IEnumerable<S> items, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		dictionary.GuardNotNull("dictionary");
		items.GuardNotNull("values");
		keySelection.GuardNotNull("key selection");
		valueSelection.GuardNotNull("value selection");
		return dictionary.TryAddRange(items.Select((S x) => keySelection(x)), items.Select((S x) => valueSelection(x)));
	}

	/// <summary>
	/// 尝试向当前字典中添加多个键值对，忽略已经存在的键，返回成功添加的键值对的数量
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <returns>返回实际添加成功的键值对的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对序列 <paramref name="pairs" /> 为空；或者添加的键值对的键值 <see cref="P:System.Tuple`2.Item1" /> 为空。</exception>
	public static int TryAddRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<Tuple<K, V>> pairs)
	{
		dictionary.GuardNotNull("dictionary");
		pairs.GuardNotNull("pairs");
		return dictionary.TryAddRange(pairs.Select((Tuple<K, V> p) => p.Item1), pairs.Select((Tuple<K, V> p) => p.Item2));
	}

	/// <summary>
	/// 尝试向当前字典中添加多个键值对，忽略已经存在的键，返回成功添加的键值对的数量
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <returns>返回实际添加成功的键值对的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对序列 <paramref name="pairs" /> 为空；或者添加的键值对的键值 <see cref="P:System.Tuple`2.Item1" /> 为空。</exception>
	public static int TryAddRange<K, V>(this IDictionary<K, V> dictionary, IEnumerable<KeyValuePair<K, V>> pairs)
	{
		dictionary.GuardNotNull("dictionary");
		pairs.GuardNotNull("pairs");
		return dictionary.TryAddRange(pairs.Select((KeyValuePair<K, V> p) => p.Key), pairs.Select((KeyValuePair<K, V> p) => p.Value));
	}

	/// <summary>
	/// 尝试获取当前字典中指定键的值，如果指定的键值不存在则返回false。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">获取值的键</param>
	/// <param name="value">指定键的值，如果指定的键不存在则为其类型的默认值</param>
	/// <returns>如果获取成功获取指定键的值返回true，否则返回false。</returns>
	public static bool TryGet<K, V>(this IDictionary<K, V> dictionary, K key, out V value)
	{
		dictionary.GuardNotNull("dictionary");
		if (dictionary.ContainsKey(key))
		{
			value = dictionary[key];
			return true;
		}
		value = default(V);
		return false;
	}

	/// <summary>
	/// 尝试设置当前字典中指定的键值，如果指定的键不存在返回false
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="key">设置值的键</param>
	/// <param name="value">设置的值</param>
	/// <returns>如果获取成功设置指定键的值返回true，否则返回false。</returns>
	public static bool TrySet<K, V>(this IDictionary<K, V> dictionary, K key, V value)
	{
		dictionary.GuardNotNull("dictionary");
		if (dictionary.ContainsKey(key))
		{
			dictionary[key] = value;
			return true;
		}
		return false;
	}
}
