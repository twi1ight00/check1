#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 集合辅助类
/// </summary>
public static class CollectionHelper
{
	/// <summary>
	/// 向当前集合中添加项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">向集合中添加的项目</param>
	/// <param name="times">项目添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void Add<T>(ICollection<T> collection, T item, int times)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			collection.Add(item);
		}
	}

	/// <summary>
	/// 向当前集合中添加项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">添加的项目的类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">向集合中添加的项目</param>
	/// <param name="evaluation">添加的项目值处理方法</param>
	/// <param name="times">项目添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目值处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void Add<T, V>(ICollection<T> collection, V item, Func<V, T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			collection.Add(evaluation(item));
		}
	}

	/// <summary>
	/// 向当前集合中添加项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="evaluation">项目值生成方法</param>
	/// <param name="times">项目添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目值生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void Add<T>(ICollection<T> collection, Func<T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			collection.Add(evaluation());
		}
	}

	/// <summary>
	/// 向当前集合中添加项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="evaluation">项目值生成方法</param>
	/// <param name="times">项目添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目值生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void Add<T>(ICollection<T> collection, Func<int, T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		for (int i = 0; i < times; i++)
		{
			collection.Add(evaluation(i));
		}
	}

	/// <summary>
	/// 向当前字典中添加键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="value">添加的值</param>
	/// <param name="keySelection">从添加的值中提取键的方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者键提取方法 <paramref name="keySelection" /> 为空。</exception>
	public static void Add<K, V>(IDictionary<K, V> dictionary, V value, Func<V, K> keySelection)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(keySelection, "key selection");
		K key = keySelection(value);
		if (dictionary.ContainsKey(key))
		{
			throw new ArgumentException(string.Format(Literals.MSG_DictionaryKeyExisted_1, key));
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
	public static void Add<K, V, S>(IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		K key = keySelection(item);
		V value = valueSelection(item);
		if (dictionary.ContainsKey(key))
		{
			throw new ArgumentException(string.Format(Literals.MSG_DictionaryKeyExisted_1, key));
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
	public static void Add<K, V>(IDictionary<K, V> dictionary, Tuple<K, V> pair)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pair, "pair");
		if (dictionary.ContainsKey(pair.Item1))
		{
			throw new ArgumentException(string.Format(Literals.MSG_DictionaryKeyExisted_1, pair.Item1));
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
	public static void Add<K, V>(IDictionary<K, V> dictionary, KeyValuePair<K, V> pair)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pair, "pair");
		if (dictionary.ContainsKey(pair.Key))
		{
			throw new ArgumentException(string.Format(Literals.MSG_DictionaryKeyExisted_1, pair.Key));
		}
		dictionary.Add(pair.Key, pair.Value);
	}

	/// <summary>
	/// 向当前集合中添加项目副本
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">添加的项目</param>
	/// <param name="copying">项目副本生成方法，默认为生成项目的浅表副本</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	public static void AddCopy<T>(ICollection<T> collection, T item, Func<T, T> copying = null)
	{
		AddCopy(collection, item, 1, copying);
	}

	/// <summary>
	/// 向当前集合中添加项目副本
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">添加的项目</param>
	/// <param name="times">项目添加的次数</param>
	/// <param name="copying">项目副本生成方法，默认为生成项目的浅表副本</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void AddCopy<T>(ICollection<T> collection, T item, int times, Func<T, T> copying = null)
	{
		Guard.AssertNotNull(collection, "collection");
		copying = ObjectHelper.IfNull(copying, (T x) => ObjectHelper.ShallowCopy(x));
		while (times-- > 0)
		{
			collection.Add(copying(item));
		}
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
	public static V AddOrUpdate<K, V>(IDictionary<K, V> dictionary, K key, V value)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
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
	public static void AddOrUpdate<K, V>(IDictionary<K, V> dictionary, K key, V value, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		if (dictionary.ContainsKey(key))
		{
			dictionary[key] = (ObjectHelper.IsNull(valueUpdating) ? value : valueUpdating(key, dictionary[key]));
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
	public static V AddOrUpdate<K, V>(IDictionary<K, V> dictionary, V value, Func<V, K> keySelection)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		return AddOrUpdate(dictionary, keySelection(value), value);
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
	public static void AddOrUpdate<K, V>(IDictionary<K, V> dictionary, V value, Func<V, K> keySelection, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		AddOrUpdate(dictionary, keySelection(value), value, valueUpdating);
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
	public static V AddOrUpdate<K, V, S>(IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		return AddOrUpdate(dictionary, keySelection(item), valueSelection(item));
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
	public static void AddOrUpdate<K, V, S>(IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		AddOrUpdate(dictionary, keySelection(item), valueSelection(item), valueUpdating);
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
	public static V AddOrUpdate<K, V>(IDictionary<K, V> dictionary, Tuple<K, V> pair)
	{
		Guard.AssertNotNull(pair, "pair");
		return AddOrUpdate(dictionary, pair.Item1, pair.Item2);
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
	public static void AddOrUpdate<K, V>(IDictionary<K, V> dictionary, Tuple<K, V> pair, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(pair, "pair");
		AddOrUpdate(dictionary, pair.Item1, pair.Item2, valueUpdating);
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
	public static V AddOrUpdate<K, V>(IDictionary<K, V> dictionary, KeyValuePair<K, V> pair)
	{
		Guard.AssertNotNull(pair, "pair");
		return AddOrUpdate(dictionary, pair.Key, pair.Value);
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
	public static void AddOrUpdate<K, V>(IDictionary<K, V> dictionary, KeyValuePair<K, V> pair, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(pair, "pair");
		AddOrUpdate(dictionary, pair.Key, pair.Value, valueUpdating);
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
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<K> keys, IEnumerable<V> values)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(values, "values");
		IEnumerator<K> keyEnumer = null;
		IEnumerator<V> valueEnumer = null;
		try
		{
			keyEnumer = keys.GetEnumerator();
			valueEnumer = values.GetEnumerator();
			while (keyEnumer.MoveNext() && valueEnumer.MoveNext())
			{
				yield return new KeyValuePair<K, V>(value: AddOrUpdate(dictionary, keyEnumer.Current, valueEnumer.Current), key: keyEnumer.Current);
			}
		}
		finally
		{
			if (ObjectHelper.IsNotNull(keyEnumer))
			{
				keyEnumer.Dispose();
			}
			if (ObjectHelper.IsNotNull(valueEnumer))
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
	public static void AddOrUpdateRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<K> keys, IEnumerable<V> values, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(values, "values");
		IEnumerator<K> keyEnumer = null;
		IEnumerator<V> valueEnumer = null;
		try
		{
			keyEnumer = keys.GetEnumerator();
			valueEnumer = values.GetEnumerator();
			while (keyEnumer.MoveNext() && valueEnumer.MoveNext())
			{
				AddOrUpdate(dictionary, keyEnumer.Current, valueEnumer.Current, valueUpdating);
			}
		}
		finally
		{
			if (ObjectHelper.IsNotNull(keyEnumer))
			{
				keyEnumer.Dispose();
			}
			if (ObjectHelper.IsNotNull(valueEnumer))
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
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<V> values, Func<V, K> keySelection)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(values, "values");
		Guard.AssertNotNull(keySelection, "key selection");
		return AddOrUpdateRange(dictionary, values.Select((V v) => keySelection(v)), values);
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
	public static void AddOrUpdateRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<V> values, Func<V, K> keySelection, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(values, "values");
		Guard.AssertNotNull(keySelection, "key selection");
		AddOrUpdateRange(dictionary, values.Select((V v) => keySelection(v)), values, valueUpdating);
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
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V, S>(IDictionary<K, V> dictionary, IEnumerable<S> items, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(items, "values");
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		return AddOrUpdateRange(dictionary, items.Select((S x) => keySelection(x)), items.Select((S x) => valueSelection(x)));
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
	public static void AddOrUpdateRange<K, V, S>(IDictionary<K, V> dictionary, IEnumerable<S> items, Func<S, K> keySelection, Func<S, V> valueSelection, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(items, "values");
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		AddOrUpdateRange(dictionary, items.Select((S x) => keySelection(x)), items.Select((S x) => valueSelection(x)), valueUpdating);
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
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<Tuple<K, V>> pairs)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pairs, "pairs");
		return AddOrUpdateRange(dictionary, pairs.Select((Tuple<K, V> p) => p.Item1), pairs.Select((Tuple<K, V> p) => p.Item2));
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
	public static void AddOrUpdateRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<Tuple<K, V>> pairs, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pairs, "pairs");
		AddOrUpdateRange(dictionary, pairs.Select((Tuple<K, V> p) => p.Item1), pairs.Select((Tuple<K, V> p) => p.Item2), valueUpdating);
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
	public static IEnumerable<KeyValuePair<K, V>> AddOrUpdateRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<KeyValuePair<K, V>> pairs)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pairs, "pairs");
		return AddOrUpdateRange(dictionary, pairs.Select((KeyValuePair<K, V> p) => p.Key), pairs.Select((KeyValuePair<K, V> p) => p.Value));
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
	public static void AddOrUpdateRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<KeyValuePair<K, V>> pairs, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pairs, "pairs");
		AddOrUpdateRange(dictionary, pairs.Select((KeyValuePair<K, V> p) => p.Key), pairs.Select((KeyValuePair<K, V> p) => p.Value), valueUpdating);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目数组 <paramref name="items" /> 为空。</exception>
	public static void AddRange<T>(ICollection<T> collection, params T[] items)
	{
		AddRange(collection, items, 1);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="times">项目序列添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数 <paramref name="items" /> 小于0。</exception>
	public static void AddRange<T>(ICollection<T> collection, IEnumerable<T> items, int times = 1)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			foreach (T item in items)
			{
				collection.Add(item);
			}
		}
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">添加的项目序列</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="evaluation">项目值处理方法</param>
	/// <param name="times">项目序列添加次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数</exception>
	public static void AddRange<T, V>(ICollection<T> collection, IEnumerable<V> items, Func<V, T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		AddRange(collection, items, (V x, int i) => evaluation(x), times);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">添加的项目序列</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="evaluation">项目值处理方法</param>
	/// <param name="times">项目序列添加次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数</exception>
	public static void AddRange<T, V>(ICollection<T> collection, IEnumerable<V> items, Func<V, int, T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			int index = 0;
			foreach (V item in items)
			{
				collection.Add(evaluation(item, index++));
			}
		}
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
	public static void AddRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<K> keys, IEnumerable<V> values)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(values, "values");
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
			if (ObjectHelper.IsNotNull(keyEnumer))
			{
				keyEnumer.Dispose();
			}
			if (ObjectHelper.IsNotNull(valueEnumer))
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
	public static void AddRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<V> values, Func<V, K> keySelection)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(values, "values");
		Guard.AssertNotNull(keySelection, "key selection");
		AddRange(dictionary, values.Select((V v) => keySelection(v)), values);
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
	public static void AddRange<K, V, S>(IDictionary<K, V> dictionary, IEnumerable<S> items, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(items, "values");
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		AddRange(dictionary, items.Select((S x) => keySelection(x)), items.Select((S x) => valueSelection(x)));
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pairs" /> 为空。</exception>
	public static void AddRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<Tuple<K, V>> pairs)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pairs, "pairs");
		AddRange(dictionary, pairs.Select((Tuple<K, V> x) => x.Item1), pairs.Select((Tuple<K, V> x) => x.Item2));
	}

	/// <summary>
	/// 向当前字典中添加多个键值对，如果指定的键已经存在则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <param name="pairs">添加的键值对序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空；或者添加的键值对 <paramref name="pairs" /> 为空。</exception>
	public static void AddRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<KeyValuePair<K, V>> pairs)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pairs, "pairs");
		AddRange(dictionary, pairs.Select((KeyValuePair<K, V> x) => x.Key), pairs.Select((KeyValuePair<K, V> x) => x.Value));
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="copying">项目复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="copying" /> 为空。</exception>
	public static void AddRangeCopy<T>(ICollection<T> collection, IEnumerable<T> items, Func<T, T> copying)
	{
		AddRangeCopy(collection, items, 1, copying);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="copying">项目复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="copying" /> 为空。</exception>
	public static void AddRangeCopy<T>(ICollection<T> collection, IEnumerable<T> items, Func<T, int, T> copying)
	{
		AddRangeCopy(collection, items, 1, copying);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="times">项目序列添加次数</param>
	/// <param name="copying">项目复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void AddRangeCopy<T>(ICollection<T> collection, IEnumerable<T> items, int times, Func<T, T> copying = null)
	{
		copying = ObjectHelper.IfNull(copying, (T x) => ObjectHelper.ShallowCopy(x));
		AddRangeCopy(collection, items, times, (T x, int i) => copying(x));
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="times">项目序列添加次数</param>
	/// <param name="copying">项目复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void AddRangeCopy<T>(ICollection<T> collection, IEnumerable<T> items, int times, Func<T, int, T> copying)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		copying = ObjectHelper.IfNull(copying, (T x, int i) => ObjectHelper.ShallowCopy(x));
		while (times-- > 0)
		{
			int index = 0;
			foreach (T item in items)
			{
				collection.Add(copying(item, index++));
			}
		}
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="equaliter">集合元素相等比较器</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	public static bool AddUnique<T>(ICollection<T> collection, T item, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(collection, "collection");
		equaliter = ObjectHelper.IfNull(equaliter, EqualityComparer<T>.Default);
		if (collection.Contains(item, equaliter))
		{
			return false;
		}
		collection.Add(item);
		return true;
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="equalition">集合元素相等比较方法</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	public static bool AddUnique<T>(ICollection<T> collection, T item, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(collection, "collection");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		if (Contains(collection, item, equalition))
		{
			return false;
		}
		collection.Add(item);
		return true;
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="equaliter">集合元素比较器</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static bool AddUnique<T, V>(ICollection<T> collection, V item, Func<V, T> evaluation, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(evaluation, "evaluation");
		return AddUnique(collection, evaluation(item), equaliter);
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static bool AddUnique<T, V>(ICollection<T> collection, V item, Func<V, T> evaluation, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(evaluation, "evaluation");
		return AddUnique(collection, evaluation(item), equalition);
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目处理方法 <paramref name="evaluation" /> 为空；或者集合元素比较方法 <paramref name="equalition" /> 为空。</exception>
	public static bool AddUnique<T, V>(ICollection<T> collection, V item, Func<T, V, bool> equalition, Func<V, T> evaluation)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(equalition, "equalition");
		Guard.AssertNotNull(evaluation, "evaluation");
		if (ContainsValue(collection, item, equalition))
		{
			return false;
		}
		collection.Add(evaluation(item));
		return true;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目数组</param>
	/// <returns>返回成功添加的项目数量</returns>
	public static int AddRangeUnique<T>(ICollection<T> collection, params T[] items)
	{
		return AddRangeUnique(collection, (IEnumerable<T>)items, (IEqualityComparer<T>)null);
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="equaliter">集合论元素比较器</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	public static int AddRangeUnique<T>(ICollection<T> collection, IEnumerable<T> items, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		int count = 0;
		foreach (T item in items)
		{
			if (AddUnique(collection, item, equaliter))
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="equalition">集合论元素比较方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	public static int AddRangeUnique<T>(ICollection<T> collection, IEnumerable<T> items, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		int count = 0;
		foreach (T item in items)
		{
			if (AddUnique(collection, item, equalition))
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="equaliter">集合元素比较器</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(ICollection<T> collection, IEnumerable<V> items, Func<V, T> evaluation, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		return AddRangeUnique(collection, items, (V x, int i) => evaluation(x), equaliter);
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(ICollection<T> collection, IEnumerable<V> items, Func<V, T> evaluation, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		return AddRangeUnique(collection, items, (V x, int i) => evaluation(x), equalition);
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="equaliter">集合元素比较器</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(ICollection<T> collection, IEnumerable<V> items, Func<V, int, T> evaluation, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		int count = 0;
		if (ObjectHelper.IsNotNull(items))
		{
			int index = 0;
			foreach (V item in items)
			{
				if (AddUnique(collection, item, (V x) => evaluation(x, index++), equaliter))
				{
					count++;
				}
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(ICollection<T> collection, IEnumerable<V> items, Func<V, int, T> evaluation, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		int count = 0;
		if (ObjectHelper.IsNotNull(items))
		{
			int index = 0;
			foreach (V item in items)
			{
				if (AddUnique(collection, item, (V x) => evaluation(x, index++), equalition))
				{
					count++;
				}
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者集合元素比较方法 <paramref name="equalition" /> 为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(ICollection<T> collection, IEnumerable<V> items, Func<T, V, bool> equalition, Func<V, T> evaluation)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(equalition, "equalition");
		Guard.AssertNotNull(evaluation, "evaluation");
		return AddRangeUnique(collection, items, equalition, (V x, int i) => evaluation(x));
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者集合元素比较方法 <paramref name="equalition" /> 为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(ICollection<T> collection, IEnumerable<V> items, Func<T, V, bool> equalition, Func<V, int, T> evaluation)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(equalition, "equalition");
		Guard.AssertNotNull(evaluation, "evaluation");
		int count = 0;
		int index = 0;
		foreach (V item in items)
		{
			if (AddUnique(collection, item, equalition, (V x) => evaluation(x, index++)))
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 对当前序列执行累加器函数
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="aggregating">累加器方法，参数分别为当前累加值和当前元素，返回累加当前元素后的新累加值</param>
	/// <returns>累加的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者累加器方法 <paramref name="aggregating" /> 为空。</exception>
	public static T Aggregate<T>(IEnumerable<T> source, Func<T, T, T> aggregating)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(aggregating, "aggregating");
		return source.Aggregate(aggregating);
	}

	/// <summary>
	/// 对当前序列执行累加器函数
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>            
	/// <typeparam name="S">累加结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">累加器初始值</param>
	/// <param name="aggregating">累加器方法，参数分别为当前累加值和当前元素，返回累加当前元素后的新累加值</param>
	/// <returns>累加的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者累加器方法 <paramref name="aggregating" /> 为空。</exception>
	public static S Aggregate<T, S>(IEnumerable<T> source, S initValue, Func<S, T, S> aggregating)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(aggregating, "aggregating");
		return source.Aggregate(initValue, aggregating);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都满足条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool All(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (object o in source)
		{
			if (!predicate(o))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都满足条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool All(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (!predicate(o, index++))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都满足条件
	/// </summary>
	/// <typeparam name="T">当前序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool All<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (T o in source)
		{
			if (!predicate(o))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都满足条件
	/// </summary>
	/// <typeparam name="T">当前序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool All<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T o in source)
		{
			if (!predicate(o, index++))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都不满足条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都不满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AllNot(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (object o in source)
		{
			if (predicate(o))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都不满足条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都不满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AllNot(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (predicate(o, index++))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都不满足条件
	/// </summary>
	/// <typeparam name="T">当前序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都不满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AllNot<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (T o in source)
		{
			if (predicate(o))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都不满足条件
	/// </summary>
	/// <typeparam name="T">当前序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都不满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AllNot<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T o in source)
		{
			if (predicate(o, index++))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中是否包含元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>如果当前序列包含元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Any(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		IEnumerator enumerator = source.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				object o = enumerator.Current;
				return true;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素满足指定条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Any(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (object o in source)
		{
			if (predicate(o))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素满足指定条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Any(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (predicate(o, index++))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否包含任意一个元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>如果当前序列包含任意一个元素返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Any<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Any();
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素满足指定条件
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Any<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (T o in source)
		{
			if (predicate(o))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素满足指定条件
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Any<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T o in source)
		{
			if (predicate(o, index++))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素不满足指定条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素不满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AnyNot(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (object o in source)
		{
			if (!predicate(o))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素不满足指定条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素不满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AnyNot(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (!predicate(o, index++))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素不满足指定条件
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素不满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AnyNot<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (T o in source)
		{
			if (!predicate(o))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素不满足指定条件
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">待检测的当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素不满足指定条件则返回true，否则返回false</returns>
	public static bool AnyNot<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T o in source)
		{
			if (!predicate(o, index++))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="item">向序列尾部添加的元素</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Append(IEnumerable source, object item)
	{
		Guard.AssertNotNull(source, "source");
		foreach (object item2 in source)
		{
			yield return item2;
		}
		yield return item;
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列尾部添加的元素数组</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Append(IEnumerable source, params object[] items)
	{
		return Append(source, (IEnumerable)items);
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列尾部添加的元素序列</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Append(IEnumerable source, IEnumerable items)
	{
		Guard.AssertNotNull(source, "source");
		foreach (object item in source)
		{
			yield return item;
		}
		if (!ObjectHelper.IsNotNull(items))
		{
			yield break;
		}
		foreach (object item2 in items)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="item">向序列尾部添加的元素</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Append<T>(IEnumerable<T> source, T item)
	{
		Guard.AssertNotNull(source, "source");
		foreach (T item2 in source)
		{
			yield return item2;
		}
		yield return item;
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列尾部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Append<T>(IEnumerable<T> source, params T[] items)
	{
		return Append(source, (IEnumerable<T>)items);
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列尾部添加的元素序列</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Append<T>(IEnumerable<T> source, IEnumerable<T> items)
	{
		Guard.AssertNotNull(source, "source");
		foreach (T item in source)
		{
			yield return item;
		}
		if (!ObjectHelper.IsNotNull(items))
		{
			yield break;
		}
		foreach (T item2 in items)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 比较当前序列与指定序列是否相等，如果两个序列元素数量相同且每个序列元素都相等则为true
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>两个源序列的长度相等，且其相应元素相等，则为 true；否则为 false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreEqualTo(IEnumerable source, IEnumerable target, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return AreEqualTo(source.OfType<object>(), target.OfType<object>(), equalition);
	}

	/// <summary>
	/// 比较当前序列与指定序列是否相等，如果两个序列元素数量相同且每个序列元素都相等则为true
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>两个源序列的长度相等，且其相应元素相等，则为 true；否则为 false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreEqualTo<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		ICollection<T> s = source as ICollection<T>;
		ICollection<T> t = source as ICollection<T>;
		if (ObjectHelper.IsNotNull(s) && ObjectHelper.IsNotNull(t) && s.Count != t.Count)
		{
			return false;
		}
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (!equalition(es.Current, et.Current))
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return !fs && !ft;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 比较当前序列是否大于目标序列，当前序列的每个元素都大于目标序列相应的元素则返回true，或者当前序列元素个数大于目标序列的元素个数返回true。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都大于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreGreaterThan(IEnumerable source, IEnumerable target, Func<object, object, int> comparison = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return AreGreaterThan(source.OfType<object>(), target.OfType<object>(), comparison);
	}

	/// <summary>
	/// 比较当前序列是否大于目标序列，当前序列的每个元素都大于目标序列相应的元素则返回true，或者当前序列元素个数大于目标序列的元素个数返回true。
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都大于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreGreaterThan<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, int> comparison = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (comparison(es.Current, et.Current) <= 0)
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return fs;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 比较当前序列是否大于或者等于目标序列，当前序列的每个元素都大于或等于目标序列相应的元素则返回true，或者当前序列元素个数大于等于目标序列的元素个数返回true。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都大于或等于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreGreaterThanOrEqualTo(IEnumerable source, IEnumerable target, Func<object, object, int> comparison = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return AreGreaterThanOrEqualTo(source.OfType<object>(), target.OfType<object>(), comparison);
	}

	/// <summary>
	/// 比较当前序列是否大于或者等于目标序列，当前序列的每个元素都大于或等于目标序列相应的元素则返回true，或者当前序列元素个数大于等于目标序列的元素个数返回true。
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都大于或等于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreGreaterThanOrEqualTo<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, int> comparison = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (comparison(es.Current, et.Current) < 0)
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return (!fs && !ft) || fs;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 比较当前序列是否小于目标序列，当前序列的每个元素都小于目标序列相应的元素则返回true，或者当前序列元素个数小于目标序列的元素个数返回true。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都小于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreLessThan(IEnumerable source, IEnumerable target, Func<object, object, int> comparison = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return AreLessThan(source.OfType<object>(), target.OfType<object>(), comparison);
	}

	/// <summary>
	/// 比较当前序列是否小于目标序列，当前序列的每个元素都小于目标序列相应的元素则返回true，或者当前序列元素个数小于目标序列的元素个数返回true。
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都小于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreLessThan<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, int> comparison = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (comparison(es.Current, et.Current) >= 0)
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return ft;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 比较当前序列是否小于或者等于目标序列，当前序列的每个元素都小于或者等于目标序列相应的元素则返回true
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都小于或者等于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreLessThanOrEqualTo(IEnumerable source, IEnumerable target, Func<object, object, int> comparison = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return AreLessThanOrEqualTo(source.OfType<object>(), target.OfType<object>(), comparison);
	}

	/// <summary>
	/// 比较当前序列是否小于或者等于目标序列，当前序列的每个元素都小于或者等于目标序列相应的元素则返回true
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都小于或者等于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreLessThanOrEqualTo<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, int> comparison = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (comparison(es.Current, et.Current) > 0)
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return (!fs && !ft) || ft;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 将当前集合作为 <see cref="T:System.Collections.ICollection" /> 类型返回
	/// </summary>
	/// <param name="collection">当前集合</param>
	/// <returns><see cref="T:System.Collections.ICollection" /> 类型的集合</returns>
	public static ICollection AsCollection(ICollection collection)
	{
		return collection;
	}

	/// <summary>
	/// 将当前集合作为 <see cref="T:System.Collections.Generic.ICollection`1" /> 类型返回
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <returns><see cref="T:System.Collections.Generic.ICollection`1" /> 类型的集合</returns>
	public static ICollection<T> AsCollection<T>(ICollection<T> collection)
	{
		return collection;
	}

	/// <summary>
	/// 将任意实现了 <see cref="T:System.Collections.IEnumerable" /> 接口的集合，作为该接口返回。
	/// </summary>
	/// <param name="items">实现了 <see cref="T:System.Collections.IEnumerable" /> 接口的集合</param>
	/// <returns><see cref="T:System.Collections.IEnumerable" /> 接口类型的序列</returns>
	public static IEnumerable AsEnumerable(IEnumerable items)
	{
		return items;
	}

	/// <summary>
	/// 将任意实现了 <see cref="T:System.Collections.Generic.IEnumerable`1" /> 接口的集合，作为该接口返回。
	/// </summary>
	/// <param name="items">实现了 <see cref="T:System.Collections.Generic.IEnumerable`1" /> 接口的集合</param>
	/// <returns><see cref="T:System.Collections.Generic.IEnumerable`1" /> 接口类型的序列</returns>
	public static IEnumerable<T> AsEnumerable<T>(IEnumerable<T> items)
	{
		return items;
	}

	/// <summary>
	/// 将当前列表作为 <see cref="T:System.Collections.IList" /> 类型的集合返回
	/// </summary>
	/// <param name="list">输入列表</param>
	/// <returns><see cref="T:System.Collections.IList" /> 类型的列表</returns>
	public static IList AsList(IList list)
	{
		return list;
	}

	/// <summary>
	/// 将当前列表作为 <see cref="T:System.Collections.Generic.IList`1" /> 类型的集合返回
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <returns><see cref="T:System.Collections.Generic.IList`1" /> 类型的列表</returns>
	public static IList<T> AsList<T>(IList<T> list)
	{
		return list;
	}

	/// <summary>
	/// 在当前列表中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">当前元素的判断条件，继续左半部分判断返回小于0的值，继续右半部分的判断返回大于0的值</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素判断条件 <paramref name="predicate" /> 为空。</exception>
	public static int BinarySearch(IList list, Func<object, int> predicate)
	{
		Guard.AssertNotNull(list, "list");
		return BinarySearch(list, 0, list.Count, predicate);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int BinarySearch(IList list, object item, IComparer comparer)
	{
		Guard.AssertNotNull(list, "list");
		return BinarySearch(list, 0, list.Count, item, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int BinarySearch(IList list, object item, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(list, "list");
		return BinarySearch(list, 0, list.Count, item, ObjectHelper.IfNull(comparison, Comparer.Default.Compare));
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="predicate">当前元素的判断条件，继续左半部分判断返回小于0的值，继续右半部分的判断返回大于0的值</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素判断条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch(IList list, int start, int count, Func<object, int> predicate)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(start, 0, list.Count - 1, "start");
		Guard.AssertBetween(count, 0, list.Count - start, "count");
		Guard.AssertNotNull(predicate, "predicate");
		int i = start;
		int j = ((count > 0) ? (start + count - 1) : start);
		while (i <= j)
		{
			int median = start + count >> 1;
			int result = predicate(list[median]);
			if (result > 0)
			{
				i = median - 1;
				continue;
			}
			if (result < 0)
			{
				j = median - 1;
				continue;
			}
			return median;
		}
		return -1;
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch(IList list, int start, int count, object item, IComparer comparer)
	{
		return BinarySearch(list, start, count, item, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch(IList list, int start, int count, object item, Func<object, object, int> comparison)
	{
		comparison = ObjectHelper.IfNull(comparison, Comparer.Default.Compare);
		return BinarySearch(list, start, count, (object x) => comparison(item, x));
	}

	/// <summary>
	/// 在当前列表中使用二分法查找指定的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">当前元素的判断条件，继续左半部分判断返回小于0的值，继续右半部分的判断返回大于0的值</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素判断条件 <paramref name="predicate" /> 为空。</exception>
	public static int BinarySearch<T>(IList<T> list, Func<T, int> predicate)
	{
		Guard.AssertNotNull(list, "list");
		return BinarySearch(list, 0, list.Count, predicate);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int BinarySearch<T>(IList<T> list, T item, IComparer<T> comparer)
	{
		Guard.AssertNotNull(list, "list");
		return BinarySearch(list, 0, list.Count, item, ObjectHelper.IfNull(comparer, Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int BinarySearch<T>(IList<T> list, T item, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(list, "list");
		return BinarySearch(list, 0, list.Count, item, ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare));
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="predicate">当前元素的判断条件，继续左半部分判断返回小于0的值，继续右半部分的判断返回大于0的值</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素判断条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch<T>(IList<T> list, int start, int count, Func<T, int> predicate)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(start, 0, list.Count - 1, "start");
		Guard.AssertBetween(count, 0, list.Count - start, "count");
		Guard.AssertNotNull(predicate, "predicate");
		int i = start;
		int j = ((count > 0) ? (start + count - 1) : start);
		while (i <= j)
		{
			int median = start + count >> 1;
			int result = predicate(list[median]);
			if (result > 0)
			{
				i = median - 1;
				continue;
			}
			if (result < 0)
			{
				j = median - 1;
				continue;
			}
			return median;
		}
		return -1;
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch<T>(IList<T> list, int start, int count, T item, IComparer<T> comparer)
	{
		return BinarySearch(list, start, count, item, ObjectHelper.IfNull(comparer, Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch<T>(IList<T> list, int start, int count, T item, Func<T, T, int> comparison)
	{
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		return BinarySearch(list, start, count, (T x) => comparison(item, x));
	}

	/// <summary>
	/// 将当前序列的元素转换为指定的类型
	/// </summary>
	/// <typeparam name="R">当前序列转换的指定类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>转换的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<R> Cast<R>(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		foreach (object item in source)
		{
			yield return ConvertHelper.Cast<R>(item);
		}
	}

	/// <summary>
	/// 将当前非泛型序列转换为泛型序列
	/// </summary>
	/// <typeparam name="R">当前序列元素类型</typeparam>
	/// <param name="source">当前待转换的序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <returns>转换后的泛型序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="conversion" /> 为空。</exception>
	public static IEnumerable<R> Cast<R>(IEnumerable source, Func<object, R> conversion)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(conversion, "conversion");
		return source.OfType<object>().Select(conversion);
	}

	/// <summary>
	/// 将当前非泛型序列转换为泛型序列
	/// </summary>
	/// <typeparam name="R">当前序列元素类型</typeparam>
	/// <param name="source">当前待转换的序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <returns>转换后的泛型序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="conversion" /> 为空。</exception>
	public static IEnumerable<R> Cast<R>(IEnumerable source, Func<object, int, R> conversion)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(conversion, "conversion");
		return source.OfType<object>().Select(conversion);
	}

	/// <summary>
	/// 将当前序列的元素转换为指定的类型
	/// </summary>
	/// <typeparam name="T">当前序列类型</typeparam>
	/// <typeparam name="R">当前序列转换的指定类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>转换的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidCastException">当前序列元素无法转换为指定的类型</exception>
	public static IEnumerable<R> Cast<T, R>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		foreach (T item in source)
		{
			yield return ConvertHelper.Cast<R>(item);
		}
	}

	/// <summary>
	/// 将当前序列的元素类型转换为另一种类型
	/// </summary>
	/// <typeparam name="S">当前序列的元素类型</typeparam>
	/// <typeparam name="T">目标序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <returns>转换后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="conversion" /> 为空。</exception>
	public static IEnumerable<T> Cast<S, T>(IEnumerable<S> source, Func<S, T> conversion)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(conversion, "conversion");
		return source.Select(conversion);
	}

	/// <summary>
	/// 将当前序列的元素类型转换为另一种类型
	/// </summary>
	/// <typeparam name="S">当前序列的元素类型</typeparam>
	/// <typeparam name="T">目标序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <returns>转换后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="conversion" /> 为空。</exception>
	public static IEnumerable<T> Cast<S, T>(IEnumerable<S> source, Func<S, int, T> conversion)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(conversion, "conversion");
		return source.Select(conversion);
	}

	/// <summary>
	/// 连接当前序列和目标序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">待连接的目标序列</param>
	/// <returns>连接后的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable<T> Concat<T>(IEnumerable<T> source, IEnumerable<T> target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Concat(target);
	}

	/// <summary>
	/// 将当前序列与多个目标序列进行连接，返回连接后的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">连接的目标序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者连接的目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Concat<T>(IEnumerable<T> source, params IEnumerable<T>[] targets)
	{
		return Concat(source, (IEnumerable<IEnumerable<T>>)targets);
	}

	/// <summary>
	/// 将当前序列与多个目标序列进行连接，返回连接后的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">连接的目标序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者连接的目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Concat<T>(IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(targets, "targets");
		foreach (IEnumerable<T> target in targets)
		{
			if (ObjectHelper.IsNotNull(target))
			{
				source = source.Concat(target);
			}
		}
		return source;
	}

	/// <summary>
	/// 将当前序列与给定序列进行连接，返回连接后的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="list">待连接的子序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ConcatObject(IEnumerable source, IEnumerable list)
	{
		Guard.AssertNotNull(source, "source");
		foreach (object item in source)
		{
			yield return item;
		}
		if (!ObjectHelper.IsNotNull(list))
		{
			yield break;
		}
		foreach (object item2 in list)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 将当前序列与多个给定序列进行连接，返回连接后的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="lists">待连接的子序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ConcatObject(IEnumerable source, params IEnumerable[] lists)
	{
		return ConcatObject(source, (IEnumerable<IEnumerable>)lists);
	}

	/// <summary>
	/// 将当前序列与多个给定序列进行连接，返回连接后的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="lists">待连接的子序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ConcatObject(IEnumerable source, IEnumerable<IEnumerable> lists)
	{
		Guard.AssertNotNull(source, "source");
		foreach (object item in source)
		{
			yield return item;
		}
		if (!ObjectHelper.IsNotNull(lists))
		{
			yield break;
		}
		foreach (IEnumerable list in lists)
		{
			foreach (object item2 in list)
			{
				yield return item2;
			}
		}
	}

	/// <summary>
	/// 检测当前序列中是否包含指定的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="value">待检测的元素</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Contains(IEnumerable source, object value, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		return Contains(source.OfType<object>(), value, equalition);
	}

	/// <summary>
	/// 检测当前序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="value">待检测的元素</param>
	/// <returns>如果当前序列中包含指定的元素返回true， 否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Contains<T>(IEnumerable<T> source, T value)
	{
		Guard.AssertNotNull(source, "source");
		return source.Contains(value);
	}

	/// <summary>
	/// 检测当前序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="value">待检测的元素</param>
	/// <param name="equaliter">序列元素相等比较器</param>
	/// <returns>如果当前序列中包含指定的元素返回true， 否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Contains<T>(IEnumerable<T> source, T value, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		return source.Contains(value, equaliter);
	}

	/// <summary>
	/// 检测当前序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="value">待检测的元素</param>
	/// <param name="equalition">相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Contains<T>(IEnumerable<T> source, T value, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		return source.Any((T item) => equalition(item, value));
	}

	/// <summary>
	/// 检测当前的序列是否包含指定的全部元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素数组</param>
	/// <returns>如果当前序列中包含指定的全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAll(IEnumerable source, params object[] items)
	{
		return ContainsAll(source, items, null);
	}

	/// <summary>
	/// 检测当前的序列是否包含指定的全部元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAll(IEnumerable source, IEnumerable items, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		foreach (object item in items)
		{
			Func<object, bool> predicate = (object x) => equalition(x, item);
			if (!Any(source, predicate))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前的序列是否包含指定的全部元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素数组</param>
	/// <returns>如果当前序列中包含指定的全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAll<T>(IEnumerable<T> source, params T[] items)
	{
		return ContainsAll(source, items, null);
	}

	/// <summary>
	/// 检测当前的序列是否包含指定的全部元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAll<T>(IEnumerable<T> source, IEnumerable<T> items, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		foreach (T item in items)
		{
			Func<T, bool> predicate = (T x) => equalition(x, item);
			if (!source.Any(predicate))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前的序列中是否包含指定的任意一个元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素数组</param>
	/// <returns>如果当前序列中包含指定的元素中的任意一个返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAny(IEnumerable source, params object[] items)
	{
		return ContainsAny(source, items, null);
	}

	/// <summary>
	/// 检测当前的序列中是否包含指定的任意一个元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素中的任意一个返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAny(IEnumerable source, IEnumerable items, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		foreach (object item in items)
		{
			Func<object, bool> predicate = (object x) => equalition(x, item);
			if (Any(source, predicate))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前的序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素数组</param>
	/// <returns>如果当前序列中包含指定的元素中的任意一个返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAny<T>(IEnumerable<T> source, params T[] items)
	{
		return ContainsAny(source, items, null);
	}

	/// <summary>
	/// 检测当前的序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素中的任意一个返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAny<T>(IEnumerable<T> source, IEnumerable<T> items, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(items, "item");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		foreach (T item in items)
		{
			Func<T, bool> predicate = (T x) => equalition(x, item);
			if (source.Any(predicate))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 使用指定的比较方法检测当前序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">待比较的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="value">待比较的元素</param>
	/// <param name="equalition">相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素比较方法 <paramref name="equalition" /> 为空。</exception>
	public static bool ContainsValue<T, V>(IEnumerable<T> source, V value, Func<T, V, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(equalition, "equalition");
		return source.Any((T x) => equalition(x, value));
	}

	/// <summary>
	/// 检测当前的序列中是否包含所有指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">待比较的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="values">待比较的元素序列</param>
	/// <param name="equalition">相等比较方法</param>
	/// <returns>如果当前序列包含全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的元素序列 <paramref name="values" /> 为空；或者元素比较方法 <paramref name="equalition" /> 为空。</exception>
	public static bool ContainsAllValue<T, V>(IEnumerable<T> source, IEnumerable<V> values, Func<T, V, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(values, "values");
		Guard.AssertNotNull(equalition, "equalition");
		foreach (V value in values)
		{
			Func<T, bool> predicate = (T x) => equalition(x, value);
			if (!source.Any(predicate))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前的序列中是否包含所有指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">待比较的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="values">待比较的元素列表</param>
	/// <param name="equalition">相等比较方法</param>
	/// <returns>如果当前序列包含全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的元素序列 <paramref name="values" /> 为空；或者元素比较方法 <paramref name="equalition" /> 为空。</exception>
	public static bool ContainsAnyValue<T, V>(IEnumerable<T> source, IEnumerable<V> values, Func<T, V, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(values, "values");
		Guard.AssertNotNull(equalition, "equalition");
		foreach (V value in values)
		{
			Func<T, bool> predicate = (T x) => equalition(x, value);
			if (source.Any(predicate))
			{
				return true;
			}
		}
		return false;
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
	public static bool ContainsKey<K, V>(IDictionary<K, V> dictionary, K key, IEqualityComparer<K> equaliter)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		return Contains(dictionary.Keys, key, equaliter);
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
	public static bool ContainsKey<K, V>(IDictionary<K, V> dictionary, K key, Func<K, K, bool> equalition)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		return Contains(dictionary.Keys, key, equalition);
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
	public static bool ContainsValue<K, V>(IDictionary<K, V> dictionary, V value)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
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
	public static bool ContainsValue<K, V>(IDictionary<K, V> dictionary, V value, IEqualityComparer<V> equaliter)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
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
	public static bool ContainsValue<K, V>(IDictionary<K, V> dictionary, V value, Func<V, V, bool> equalition)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		return Contains(dictionary.Values, value, equalition);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	public static void CopyTo(IEnumerable source, object[] array, Func<object, object> copying = null)
	{
		CopyTo(source, array, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="start">目标数组开始复制的位置</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标数组起始复制位置 <paramref name="start" /> 小于0，或者大于目标数组的最大索引。</exception>
	public static void CopyTo(IEnumerable source, object[] array, int start, Func<object, object> copying = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "array start");
		copying = ObjectHelper.IfNull(copying, (object x) => x);
		foreach (object o in source)
		{
			if (start >= array.Length)
			{
				break;
			}
			array[start++] = copying(o);
		}
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	public static void CopyTo<V>(IEnumerable source, V[] array, Func<object, V> copying = null)
	{
		CopyTo(source, array, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="start">目标数组开始复制的位置</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标数组起始复制位置 <paramref name="start" /> 小于0，或者大于目标数组的最大索引。</exception>
	public static void CopyTo<V>(IEnumerable source, V[] array, int start, Func<object, V> copying = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "array start");
		copying = ObjectHelper.IfNull(copying, (object x) => (V)x);
		foreach (object o in source)
		{
			if (start >= array.Length)
			{
				break;
			}
			array[start++] = copying(o);
		}
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	public static void CopyTo<T>(IEnumerable<T> source, T[] array, Func<T, T> copying = null)
	{
		CollectionHelper.CopyTo<T>(source, array, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="start">目标数组开始复制的位置</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标数组起始复制位置 <paramref name="start" /> 小于0，或者大于目标数组的最大索引。</exception>
	public static void CopyTo<T>(IEnumerable<T> source, T[] array, int start, Func<T, T> copying = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "array start");
		copying = ObjectHelper.IfNull(copying, (T x) => x);
		foreach (T o in source)
		{
			if (start >= array.Length)
			{
				break;
			}
			array[start++] = copying(o);
		}
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	public static void CopyTo<T, V>(IEnumerable<T> source, V[] array, Func<T, V> copying = null)
	{
		CopyTo(source, array, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="start">目标数组开始复制的位置</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标数组起始复制位置 <paramref name="start" /> 小于0，或者大于目标数组的最大索引。</exception>
	public static void CopyTo<T, V>(IEnumerable<T> source, V[] array, int start, Func<T, V> copying = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "array start");
		copying = ObjectHelper.IfNull(copying, (T x) => ObjectHelper.As<V>(x));
		foreach (T o in source)
		{
			if (start >= array.Length)
			{
				break;
			}
			array[start++] = copying(o);
		}
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="list">目标列表</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标列表 <paramref name="list" /> 为空。</exception>
	public static void CopyTo<T>(IEnumerable<T> source, IList<T> list, Func<T, T> copying = null)
	{
		CollectionHelper.CopyTo<T>(source, list, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="list">目标列表</param>
	/// <param name="listStart">目标列表开始复制的位置</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标列表 <paramref name="list" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标列表起始复制位置 <paramref name="listStart" /> 小于0，或者大于目标列表的最大索引。</exception>
	public static void CopyTo<T>(IEnumerable<T> source, IList<T> list, int listStart, Func<T, T> copying = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(listStart, 0, list.Count - 1, "list start");
		copying = ObjectHelper.IfNull(copying, (T x) => x);
		foreach (T o in source)
		{
			if (listStart >= list.Count)
			{
				break;
			}
			list[listStart++] = copying(o);
		}
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="list">目标列表</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标列表 <paramref name="list" /> 为空。</exception>
	public static void CopyTo<T, V>(IEnumerable<T> source, IList<V> list, Func<T, V> copying = null)
	{
		CopyTo(source, list, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="list">目标列表</param>
	/// <param name="listStart">目标列表开始复制的位置</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标列表 <paramref name="list" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标列表起始复制位置 <paramref name="listStart" /> 小于0，或者大于目标列表的最大索引。</exception>
	public static void CopyTo<T, V>(IEnumerable<T> source, IList<V> list, int listStart, Func<T, V> copying = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(listStart, 0, list.Count - 1, "list start");
		copying = ObjectHelper.IfNull(copying, (T x) => ObjectHelper.As<V>(x));
		foreach (T o in source)
		{
			if (listStart >= list.Count)
			{
				break;
			}
			list[listStart++] = copying(o);
		}
	}

	/// <summary>
	/// 统计当前序列中元素的个数
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int Count<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Count();
	}

	/// <summary>
	/// 统计当前序列中满足给定条件的元素的个数
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中满足给定条件的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int Count<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Count(predicate);
	}

	/// <summary>
	/// 返回当前非泛型序列中元素的个数
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int Count<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		return source.OfType<T>().Count((T x) => predicate(x, index++));
	}

	/// <summary>
	/// 返回当前非泛型序列中元素的个数
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int CountObject(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		return source.OfType<object>().Count();
	}

	/// <summary>
	/// 返回当前非泛型序列中元素的个数
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int CountObject(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.OfType<object>().Count(predicate);
	}

	/// <summary>
	/// 返回当前非泛型序列中元素的个数
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int CountObject(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		return source.OfType<object>().Count((object x) => predicate(x, index++));
	}

	/// <summary>
	/// 使用序列元素默认的比较器返回当前序列中非重复的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列中非重复元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Distinct<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Distinct();
	}

	/// <summary>
	/// 使用的指定的元素比较器返回当前序列中非重复的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>当前序列中非重复元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Distinct<T>(IEnumerable<T> source, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		return source.Distinct(equaliter);
	}

	/// <summary>
	/// 返回当前序列中非重复的元素组成的序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>筛选后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Distinct<T>(IEnumerable<T> source, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		return source.Distinct(ConvertHelper.ToComparer(equalition));
	}

	/// <summary>
	/// 返回当前序列中非重复的元素组成的序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>筛选后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable DistinctObject(IEnumerable source, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		return source.OfType<object>().Distinct(ConvertHelper.ToComparer<object>(equalition));
	}

	/// <summary>
	/// 获取当前序列中指定位置的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="index">获取元素的位置索引</param>
	/// <returns>当前序列中指定位置的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的元素索引位置 <paramref name="index" /> 小于0或者大于序列最大的元素索引。</exception>
	public static T ElementAt<T>(IEnumerable<T> source, int index)
	{
		Guard.AssertNotNull(source, "source");
		return source.ElementAt(index);
	}

	/// <summary>
	/// 获取当前序列中指定位置的元素，如果指定的索引超出范围则返回当前序列元素的默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="index">指定的序列元素索引</param>
	/// <returns>当前序列中指定位置的元素，或者序列元素的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T ElementAtOrDefault<T>(IEnumerable<T> source, int index)
	{
		Guard.AssertNotNull(source, "source");
		return source.ElementAt(index);
	}

	/// <summary>
	/// 获取当前序列中指定位置的元素，如果指定位置的值不存在则返回指定的元素默认值  <paramref name="defaultValue" />。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="index">获取的元素索引</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列指定位置的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">获取的元素索引 <paramref name="index" /> 小于0。</exception>
	public static T ElementAtOrDefault<T>(IEnumerable<T> source, int index, T defaultValue)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(index, 0, "index");
		int current = 0;
		foreach (T item in source)
		{
			if (current++ == index)
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取具有指定类型元素的空序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <returns>具有指定类型元素的空序列。</returns>
	public static IEnumerable<T> Empty<T>()
	{
		return Enumerable.Empty<T>();
	}

	/// <summary>
	/// 对当前序列进行计算
	/// </summary>
	/// <typeparam name="T">计算结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">计算初始值</param>
	/// <param name="evaluation">计算方法</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	public static T Evaluate<T>(IEnumerable source, T initValue, Func<object, T, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		return Evaluate(source.OfType<T>(), initValue, evaluation);
	}

	/// <summary>
	/// 对当前序列进行计算
	/// </summary>
	/// <typeparam name="T">计算结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">计算初始值</param>
	/// <param name="evaluation">计算方法</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	public static T Evaluate<T>(IEnumerable source, T initValue, Func<object, int, T, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		return Evaluate(source.OfType<T>(), initValue, evaluation);
	}

	/// <summary>
	/// 对当前序列进行计算
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">计算结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">计算初始值</param>
	/// <param name="evaluation">计算方法</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	public static V Evaluate<T, V>(IEnumerable<T> source, V initValue, Func<object, V, V> evaluation)
	{
		return Evaluate(source, initValue, (T x, int i, V v) => evaluation(x, v));
	}

	/// <summary>
	/// 对当前序列进行计算
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">计算结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">计算初始值</param>
	/// <param name="evaluation">计算方法</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	public static V Evaluate<T, V>(IEnumerable<T> source, V initValue, Func<T, int, V, V> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		int index = 0;
		foreach (T o in source)
		{
			initValue = evaluation(o, index++, initValue);
		}
		return initValue;
	}

	/// <summary>
	/// 从当前序列中排除与给定值匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">排除的元素值数组</param>
	/// <returns>处理后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Except(IEnumerable source, params object[] items)
	{
		return Except(source, items, null);
	}

	/// <summary>
	/// 从当前序列中排除与给定值匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">排除的元素值序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>处理后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Except(IEnumerable source, IEnumerable items, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(items, "items");
		foreach (object o in source)
		{
			if (ObjectHelper.IsNull(items) || !Contains(items, o, equalition))
			{
				yield return o;
			}
		}
	}

	/// <summary>
	/// 从当前序列中排除与给定值匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">排除的元素值序列</param>
	/// <returns>处理后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的目标序列为空。</exception>
	public static IEnumerable<T> Except<T>(IEnumerable<T> source, params T[] items)
	{
		return Except(source, (IEnumerable<T>)items);
	}

	/// <summary>
	/// 使用默认的相等比较器比较生成当前序列和目标序列的差集
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <returns>当前序列和目标序列的差集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的目标序列为空。</exception>
	public static IEnumerable<T> Except<T>(IEnumerable<T> source, IEnumerable<T> target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Except(target);
	}

	/// <summary>
	/// 使用指定的相等比较器比较生成当前序列和目标序列的差集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="equaliter">指定的元素比较器</param>
	/// <returns>当前序列和目标序列的差集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的目标序列为空。</exception>
	public static IEnumerable<T> Except<T>(IEnumerable<T> source, IEnumerable<T> target, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Except(target, equaliter);
	}

	/// <summary>
	/// 从当前序列中排除与给定值匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">排除的元素值序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>处理后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Except<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Except(target, ConvertHelper.ToComparer(equalition));
	}

	/// <summary>
	/// 检测当前序列中是否存在满足检测条件的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果存在符合条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		return Exists(source.OfType<object>(), predicate);
	}

	/// <summary>
	/// 检测当前序列中是否存在满足检测条件的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果存在符合条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		return Exists(source.OfType<object>(), predicate);
	}

	/// <summary>
	/// 检测当前序列中是否存在满足检测条件的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果存在符合条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "preidcate");
		return source.Any((T item) => predicate(item));
	}

	/// <summary>
	/// 检测当前序列中是否存在满足检测条件的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待检测的序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果存在符合条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "preidcate");
		return Any(source, (T item, int i) => predicate(item, i));
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="value">列表填充的值</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Fill(IList list, object value)
	{
		Guard.AssertNotNull(list, "list");
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = value;
		}
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill(IList list, Func<object> evaluation)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(evaluation, "evaluation");
		Fill(list, (object x, int i) => evaluation());
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill(IList list, Func<int, object> evaluation)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(evaluation, "evaluation");
		Fill(list, (object x, int i) => evaluation(i));
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill(IList list, Func<object, int, object> evaluation)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(evaluation, "evaluation");
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = evaluation(list[i], i);
		}
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="value">列表填充的值</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Fill<T>(IList<T> list, T value)
	{
		Guard.AssertNotNull(list, "list");
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = value;
		}
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill<T>(IList<T> list, Func<T> evaluation)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(evaluation, "evaluation");
		Fill(list, (T x, int i) => evaluation());
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill<T>(IList<T> list, Func<int, T> evaluation)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(evaluation, "evaluation");
		Fill(list, (T x, int i) => evaluation(i));
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill<T>(IList<T> list, Func<T, int, T> evaluation)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(evaluation, "evaluation");
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = evaluation(list[i], i);
		}
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素，如果未找到匹配的元素则抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">未找到匹配的元素。</exception>
	public static object Find(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Find(source, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素，如果未找到匹配的元素则抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">如果无法找到匹配的元素，则返回该默认值</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object Find(IEnumerable source, Func<object, bool> predicate, object defaultValue)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Find(source, (object x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">未找到匹配的元素。</exception>
	public static object Find(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		throw new InvalidOperationException(Literals.MSG_ValueNotFound);
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">如果无法找到匹配的元素，则返回该默认值</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object Find(IEnumerable source, Func<object, int, bool> predicate, object defaultValue)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素，如果未找到匹配的元素则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">未找到匹配的元素。</exception>
	public static T Find<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Find(source, (T x, int i) => predicate(x));
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素，如果未找到匹配的元素则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">如果无法找到匹配的元素，则返回该默认值</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T Find<T>(IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Find(source, (T x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">未找到匹配的元素。</exception>
	public static T Find<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		throw new InvalidOperationException(Literals.MSG_ValueNotFound);
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">如果无法找到匹配的元素，则返回该默认值</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T Find<T>(IEnumerable<T> source, Func<T, int, bool> predicate, T defaultValue)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 在当前序列中查找满足指定条件的元素，并返回匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static object[] FindAll(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.OfType<object>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 在当前序列中查找满足指定条件的元素，并返回匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static object[] FindAll(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.OfType<object>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 在当前序列中查找满足指定条件的元素，并返回匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static T[] FindAll<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Where(predicate).ToArray();
	}

	/// <summary>
	/// 在当前序列中查找满足指定条件的元素，并返回匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static T[] FindAll<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取在当前序列中第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	public static int FindIndex(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(source, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static int FindIndex(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object item in source)
		{
			if (predicate(item, index))
			{
				return index;
			}
			index++;
		}
		return -1;
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	public static int FindIndex(IEnumerable source, int start, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(source, start, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	public static int FindIndex(IEnumerable source, int start, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (object o in SkipObject(source, start))
		{
			if (predicate(o, start))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int FindIndex(IEnumerable source, int start, int count, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(source, start, count, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int FindIndex(IEnumerable source, int start, int count, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(predicate, "predicate");
		int end = start + count;
		foreach (object o in SkipObject(source, start))
		{
			if (start >= end)
			{
				break;
			}
			if (predicate(o, start))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取在当前序列中第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	public static int FindIndex<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(source, (T x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static int FindIndex<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index))
			{
				return index;
			}
			index++;
		}
		return -1;
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	public static int FindIndex<T>(IEnumerable<T> source, int start, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(source, start, (T x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	public static int FindIndex<T>(IEnumerable<T> source, int start, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (T o in source.Skip(start))
		{
			if (predicate(o, start))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int FindIndex<T>(IEnumerable<T> source, int start, int count, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(source, start, count, (T x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int FindIndex<T>(IEnumerable<T> source, int start, int count, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(predicate, "predicate");
		int end = start + count;
		foreach (T o in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			if (predicate(o, start))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中的第一个元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static T First<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.First();
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何符合条件的元素。</exception>
	public static T First<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		return source.First(predicate);
	}

	/// <summary>
	/// 返回当前序列中第一个符合指定条件的元素，如果没有符合条件的元素，则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列没有符合条件的元素。</exception>
	public static T First<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceNotElementInPredicate);
	}

	/// <summary>
	/// 获取当前序列中从头部开始指定数量的元素，如果序列中存在的元素不足，则只返回序列中存在的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">子序列元素的数量</param>
	/// <returns>选取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> First<T>(IEnumerable<T> source, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return source.Take(count);
	}

	/// <summary>
	/// 获取当前序列中第一个元素，如果序列为空则抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static object FirstObject(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		IEnumerator enumerator = source.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果不存在则抛出异常。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列没有符合条件的元素。</exception>
	public static object FirstObject(IEnumerable source, Func<object, bool> predicate)
	{
		return FirstObject(source, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果不存在则抛出异常。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列没有符合条件的元素。</exception>
	public static object FirstObject(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (predicate(o, index++))
			{
				return o;
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceNotElementInPredicate);
	}

	/// <summary>
	/// 获取当前序列中从头部开始指定数量的元素，如果序列中存在的元素不足，则只返回序列中存在的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">子序列元素的数量</param>
	/// <returns>选取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable FirstObject(IEnumerable source, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return TakeObject(source, count);
	}

	/// <summary>
	/// 获取当前序列的第一个元素，如果当前序列不包含任何元素则返回当前序列元素的默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列的元素或者序列元素的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T FirstOrDefault<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.FirstOrDefault();
	}

	/// <summary>
	/// 获取当前序列的第一个元素，如果不存在则返回元素默认值  <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T FirstOrDefault<T>(IEnumerable<T> source, T defaultValue)
	{
		Guard.AssertNotNull(source, "source");
		using (IEnumerator<T> enumerator = source.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果没有符合条件的元素返回当前序列元素的默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T FirstOrDefault<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.FirstOrDefault(predicate);
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果不存在则返回元素默认值  <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T FirstOrDefault<T>(IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FirstOrDefault(source, (T x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果不存在则返回元素默认值  <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T FirstOrDefault<T>(IEnumerable<T> source, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中从开始指定数量元素的子序列，如果序列中的元素数量不足指定的数量，则使用序列元素默认值  <paramref name="defaultValue" /> 进行填充
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的序列元素数量</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的序列元素 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> FirstOrDefault<T>(IEnumerable<T> source, int count, T defaultValue = default(T))
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (T item in source)
		{
			if (index++ >= count)
			{
				yield break;
			}
			yield return item;
		}
		if (index < count)
		{
			while (index++ >= count)
			{
				yield return defaultValue;
			}
		}
	}

	/// <summary>
	/// 获取当前序列中第一个元素，如果序列为空则返回 <paramref name="defaultValue" /> 指定的默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static object FirstObjectOrDefault(IEnumerable source, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		IEnumerator enumerator = source.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果序列为空则返回 <paramref name="defaultValue" /> 指定的默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object FirstObjectOrDefault(IEnumerable source, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FirstObjectOrDefault(source, (object x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果序列为空则返回 <paramref name="defaultValue" /> 指定的默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object FirstObjectOrDefault(IEnumerable source, Func<object, int, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (predicate(o, index++))
			{
				return o;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中从开始指定数量元素的子序列，如果序列中的元素数量不足指定的数量，则使用序列元素默认值 <paramref name="defaultValue" /> 进行填充
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的序列元素数量</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的序列元素 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable FirstObjectOrDefault(IEnumerable source, int count, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (object item in source)
		{
			if (index++ >= count)
			{
				yield break;
			}
			yield return item;
		}
		if (index < count)
		{
			while (index++ >= count)
			{
				yield return defaultValue;
			}
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void For(IEnumerable source, Action<int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		int index = 0;
		foreach (object item in source)
		{
			action(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void For(IEnumerable source, Action<int> action, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (object item in source)
		{
			if (index >= count)
			{
				break;
			}
			action(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void For(IEnumerable source, int start, Action<int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(start, 0, "start");
		Guard.AssertNotNull(action, "action");
		foreach (object item in SkipObject(source, start))
		{
			action(start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void For(IEnumerable source, int start, int count, Action<int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		int end = start + count;
		foreach (object item in SkipObject(source, start))
		{
			if (start >= end)
			{
				break;
			}
			action(start++);
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void For<T>(IEnumerable<T> source, Action<int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		int index = 0;
		foreach (T item in source)
		{
			action(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void For<T>(IEnumerable<T> source, Action<int> action, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (T item in source)
		{
			if (index >= count)
			{
				break;
			}
			action(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void For<T>(IEnumerable<T> source, int start, Action<int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(start, 0, "start");
		Guard.AssertNotNull(action, "action");
		foreach (T item in source.Skip(start))
		{
			action(start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void For<T>(IEnumerable<T> source, int start, int count, Action<int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		int end = start + count;
		foreach (T item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			action(start++);
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前序列为空</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void ForEach(IEnumerable source, Action<object> action)
	{
		Guard.AssertNotNull(action, "action");
		ForEach(source, delegate(object x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach(IEnumerable source, Action<object> action, int count)
	{
		Guard.AssertNotNull(action, "action");
		ForEach(source, delegate(object x, int i)
		{
			action(x);
		}, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void ForEach(IEnumerable source, int start, Action<object> action)
	{
		Guard.AssertNotNull(action, "action");
		ForEach(source, start, delegate(object x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach(IEnumerable source, int start, int count, Action<object> action)
	{
		Guard.AssertNotNull(action, "action");
		ForEach(source, start, count, delegate(object x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void ForEach(IEnumerable source, Action<object, int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		int index = 0;
		foreach (object item in source)
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach(IEnumerable source, Action<object, int> action, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (object item in source)
		{
			if (index >= count)
			{
				break;
			}
			action(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void ForEach(IEnumerable source, int start, Action<object, int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(start, 0, "start");
		Guard.AssertNotNull(action, "action");
		foreach (object item in SkipObject(source, start))
		{
			action(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach(IEnumerable source, int start, int count, Action<object, int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		int end = start + count;
		foreach (object item in SkipObject(source, start))
		{
			if (start >= end)
			{
				break;
			}
			action(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列为空</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void ForEach<T>(IEnumerable<T> source, Action<T> action)
	{
		Guard.AssertNotNull(action, "action");
		ForEach(source, delegate(T x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach<T>(IEnumerable<T> source, Action<T> action, int count)
	{
		Guard.AssertNotNull(action, "action");
		ForEach(source, delegate(T x, int i)
		{
			action(x);
		}, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void ForEach<T>(IEnumerable<T> source, int start, Action<T> action)
	{
		Guard.AssertNotNull(action, "action");
		ForEach(source, start, delegate(T x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach<T>(IEnumerable<T> source, int start, int count, Action<T> action)
	{
		Guard.AssertNotNull(action, "action");
		ForEach(source, start, count, delegate(T x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void ForEach<T>(IEnumerable<T> source, Action<T, int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		int index = 0;
		foreach (T item in source)
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach<T>(IEnumerable<T> source, Action<T, int> action, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (T item in source)
		{
			if (index >= count)
			{
				break;
			}
			action(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void ForEach<T>(IEnumerable<T> source, int start, Action<T, int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(start, 0, "start");
		Guard.AssertNotNull(action, "action");
		foreach (T item in source.Skip(start))
		{
			action(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach<T>(IEnumerable<T> source, int start, int count, Action<T, int> action)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		int end = start + count;
		foreach (T item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			action(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素索引执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable ForEval(IEnumerable source, Func<int, object> evaluation)
	{
		return ForEval(source.OfType<object>(), evaluation);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEval(IEnumerable source, Func<int, object> evaluation, int count)
	{
		return ForEval(source.OfType<object>(), evaluation, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable ForEval(IEnumerable source, int start, Func<int, object> evaluation)
	{
		return ForEval(source.OfType<object>(), start, evaluation);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEval(IEnumerable source, int start, int count, Func<int, object> evaluation)
	{
		return ForEval(source.OfType<object>(), start, count, evaluation);
	}

	/// <summary>
	/// 对当前序列中的每个元素索引执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable<T> ForEval<S, T>(IEnumerable<S> source, Func<int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		int index = 0;
		foreach (S item in source)
		{
			_ = item;
			yield return evaluation(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEval<S, T>(IEnumerable<S> source, Func<int, T> evaluation, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (S item in source)
		{
			_ = item;
			if (index >= count)
			{
				break;
			}
			yield return evaluation(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable<T> ForEval<S, T>(IEnumerable<S> source, int start, Func<int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(start, 0, "start");
		Guard.AssertNotNull(evaluation, "evaluation");
		foreach (S item in source.Skip(start))
		{
			_ = item;
			yield return evaluation(start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEval<S, T>(IEnumerable<S> source, int start, int count, Func<int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(evaluation, "evaluation");
		int end = start + count;
		foreach (S item in source.Skip(start))
		{
			_ = item;
			if (start >= end)
			{
				break;
			}
			yield return evaluation(start++);
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable ForEachEval(IEnumerable source, Func<object, object> evaluation)
	{
		return ForEachEval(source.OfType<object>(), evaluation);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEachEval(IEnumerable source, Func<object, object> evaluation, int count)
	{
		return ForEachEval(source.OfType<object>(), evaluation, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static IEnumerable ForEachEval(IEnumerable source, int start, Func<object, object> evaluation)
	{
		return ForEachEval(source.OfType<object>(), start, evaluation);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEachEval(IEnumerable source, int start, int count, Func<object, object> evaluation)
	{
		return ForEachEval(source.OfType<object>(), start, count, evaluation);
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable ForEachEval(IEnumerable source, Func<object, int, object> evaluation)
	{
		return ForEachEval(source.OfType<object>(), evaluation);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEachEval(IEnumerable source, Func<object, int, object> evaluation, int count)
	{
		return ForEachEval(source.OfType<object>(), evaluation, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable ForEachEval(IEnumerable source, int start, Func<object, int, object> evaluation)
	{
		return ForEachEval(source.OfType<object>(), start, evaluation);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEachEval(IEnumerable source, int start, int count, Func<object, int, object> evaluation)
	{
		return ForEachEval(source.OfType<object>(), start, count, evaluation);
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(IEnumerable<S> source, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return ForEachEval(source, (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(IEnumerable<S> source, Func<S, T> evaluation, int count)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return ForEachEval(source, (S x, int i) => evaluation(x), count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(IEnumerable<S> source, int start, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return ForEachEval(source, start, (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(IEnumerable<S> source, int start, int count, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return ForEachEval(source, start, count, (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(IEnumerable<S> source, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		int index = 0;
		foreach (S value in source)
		{
			yield return evaluation(value, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluation">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(IEnumerable<S> source, Func<S, int, T> evaluation, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (S item in source)
		{
			if (index >= count)
			{
				break;
			}
			yield return evaluation(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(IEnumerable<S> source, int start, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(start, 0, "start");
		Guard.AssertNotNull(evaluation, "evaluation");
		foreach (S item in source.Skip(start))
		{
			yield return evaluation(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluation">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(IEnumerable<S> source, int start, int count, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(evaluation, "evaluation");
		int end = start + count;
		foreach (S item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			yield return evaluation(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, Action<int> action, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), action, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, Action<long> action, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, Action<int, ParallelLoopState> action, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, Action<long, ParallelLoopState> action, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, Func<int, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, Func<long, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, int start, int count, Action<int> action, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), start, count, action, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, long start, long count, Action<long> action, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, int start, int count, Action<int, ParallelLoopState> action, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, long start, long count, Action<long, ParallelLoopState> action, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, int start, int count, Func<int, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), start, count, func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(IEnumerable source, long start, long count, Func<long, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return ForParallel(source.OfType<object>(), start, count, func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(IEnumerable<T> source, Action<int> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		return ForParallel(source, 0, source.Count(), action, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(IEnumerable<T> source, Action<long> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		return ForParallel(source, 0L, source.LongCount(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(IEnumerable<T> source, Action<int, ParallelLoopState> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		return ForParallel(source, 0, source.Count(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(IEnumerable<T> source, Action<long, ParallelLoopState> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		return ForParallel(source, 0L, source.LongCount(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<S, T>(IEnumerable<S> source, Func<int, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		return ForParallel(source, 0, source.Count(), func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<S, T>(IEnumerable<S> source, Func<long, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		return ForParallel(source, 0L, source.LongCount(), func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(IEnumerable<T> source, int start, int count, Action<int> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(IEnumerable<T> source, long start, long count, Action<long> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0L, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(IEnumerable<T> source, int start, int count, Action<int, ParallelLoopState> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(IEnumerable<T> source, long start, long count, Action<long, ParallelLoopState> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0L, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<S, T>(IEnumerable<S> source, int start, int count, Func<int, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(func, "func");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		initializer = ObjectHelper.IfNull(initializer, () => default(T));
		finalizer = ObjectHelper.IfNull(finalizer, delegate
		{
		});
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, count, initializer, func, finalizer);
		}
		return Parallel.For(start, count, options, initializer, func, finalizer);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<S, T>(IEnumerable<S> source, long start, long count, Func<long, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(func, "func");
		Guard.AssertIndexLowBound(start, 0L, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		initializer = ObjectHelper.IfNull(initializer, () => default(T));
		finalizer = ObjectHelper.IfNull(finalizer, delegate
		{
		});
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, count, initializer, func, finalizer);
		}
		return Parallel.For(start, count, options, initializer, func, finalizer);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>循环结果信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, Action<object> action, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), action, options);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, Action<object, long> action, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), action, options);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, Action<object, ParallelLoopState> action, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), action, options);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, Action<object, long, ParallelLoopState> action, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), action, options);
	}

	/// <summary>
	///             对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, Func<object, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, Func<object, long, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, int start, int count, Action<object> action, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, int start, int count, Action<object, int> action, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), start, count, action, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, int start, int count, Action<object, ParallelLoopState> action, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, int start, int count, Action<object, int, ParallelLoopState> action, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, int start, int count, Func<object, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), start, count, func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(IEnumerable source, int start, int count, Func<object, int, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return ForEachParallel(source.OfType<object>(), start, count, func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>循环结果信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(IEnumerable<T> source, Action<T> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.ForEach(source, action);
		}
		return Parallel.ForEach(source, options, action);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(IEnumerable<T> source, Action<T, long> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.ForEach(source, delegate(T x, ParallelLoopState p, long i)
			{
				action(x, i);
			});
		}
		return Parallel.ForEach(source, options, delegate(T x, ParallelLoopState p, long i)
		{
			action(x, i);
		});
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(IEnumerable<T> source, Action<T, ParallelLoopState> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.ForEach(source, action);
		}
		return Parallel.ForEach(source, options, action);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(IEnumerable<T> source, Action<T, long, ParallelLoopState> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.ForEach(source, delegate(T x, ParallelLoopState p, long i)
			{
				action(x, i, p);
			});
		}
		return Parallel.ForEach(source, options, delegate(T x, ParallelLoopState p, long i)
		{
			action(x, i, p);
		});
	}

	/// <summary>
	///             对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<S, T>(IEnumerable<S> source, Func<S, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(func, "func");
		initializer = ObjectHelper.IfNull(initializer, () => default(T));
		finalizer = ObjectHelper.IfNull(finalizer, delegate
		{
		});
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.ForEach(source, initializer, func, finalizer);
		}
		return Parallel.ForEach(source, options, initializer, func, finalizer);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<S, T>(IEnumerable<S> source, Func<S, long, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(func, "func");
		initializer = ObjectHelper.IfNull(initializer, () => default(T));
		finalizer = ObjectHelper.IfNull(finalizer, delegate
		{
		});
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.ForEach(source, initializer, (S x, ParallelLoopState p, long i, T v) => func(x, i, p, v), finalizer);
		}
		return Parallel.ForEach(source, options, initializer, (S x, ParallelLoopState p, long i, T v) => func(x, i, p, v), finalizer);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(IEnumerable<T> source, int start, int count, Action<T> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, start + count, delegate(int i)
			{
				action(source.ElementAt(i));
			});
		}
		return Parallel.For(start, start + count, options, delegate(int i)
		{
			action(source.ElementAt(i));
		});
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(IEnumerable<T> source, int start, int count, Action<T, int> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, start + count, delegate(int i)
			{
				action(source.ElementAt(i), i);
			});
		}
		return Parallel.For(start, start + count, options, delegate(int i)
		{
			action(source.ElementAt(i), i);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(IEnumerable<T> source, int start, int count, Action<T, ParallelLoopState> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, start + count, delegate(int i, ParallelLoopState p)
			{
				action(source.ElementAt(i), p);
			});
		}
		return Parallel.For(start, start + count, options, delegate(int i, ParallelLoopState p)
		{
			action(source.ElementAt(i), p);
		});
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(IEnumerable<T> source, int start, int count, Action<T, int, ParallelLoopState> action, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(action, "action");
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, start + count, delegate(int i, ParallelLoopState p)
			{
				action(source.ElementAt(i), i, p);
			});
		}
		return Parallel.For(start, start + count, options, delegate(int i, ParallelLoopState p)
		{
			action(source.ElementAt(i), i, p);
		});
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<S, T>(IEnumerable<S> source, int start, int count, Func<S, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "start");
		Guard.AssertNotNull(func, "func");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		initializer = ObjectHelper.IfNull(initializer, () => default(T));
		finalizer = ObjectHelper.IfNull(finalizer, delegate
		{
		});
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, count, initializer, (int i, ParallelLoopState p, T v) => func(source.ElementAt(i), p, v), finalizer);
		}
		return Parallel.For(start, count, options, initializer, (int i, ParallelLoopState p, T v) => func(source.ElementAt(i), p, v), finalizer);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<S, T>(IEnumerable<S> source, int start, int count, Func<S, int, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(func, "func");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		initializer = ObjectHelper.IfNull(initializer, () => default(T));
		finalizer = ObjectHelper.IfNull(finalizer, delegate
		{
		});
		if (ObjectHelper.IsNull(options))
		{
			return Parallel.For(start, count, initializer, (int i, ParallelLoopState p, T v) => func(source.ElementAt(i), i, p, v), finalizer);
		}
		return Parallel.For(start, count, options, initializer, (int i, ParallelLoopState p, T v) => func(source.ElementAt(i), i, p, v), finalizer);
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
	public static V Get<K, V>(IDictionary<K, V> dictionary, K key)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		if (dictionary.ContainsKey(key))
		{
			return dictionary[key];
		}
		throw new KeyNotFoundException(string.Format(Literals.MSG_DictionaryKeyNotFound_1, key));
	}

	/// <summary>
	/// 获取当前字典的键和值的数组，键和值的数组中的元素按顺寻一一对应。
	/// </summary>
	/// <typeparam name="K">当前字典键类型</typeparam>
	/// <typeparam name="V">当前字典值类型</typeparam>
	/// <param name="dictionary">当前字典</param>
	/// <returns>当前字典的键和值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字典为空。</exception>
	public static Tuple<K[], V[]> GetKeyValues<K, V>(IDictionary<K, V> dictionary)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
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
	public static V GetOrAdd<K, V>(IDictionary<K, V> dictionary, K key, V value = default(V))
	{
		Guard.AssertNotNull(dictionary, "dictionary");
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
	public static V GetOrDefault<K, V>(IDictionary<K, V> dictionary, K key, V defaultValue = default(V))
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		return dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
	}

	/// <summary>
	/// 获取当前序列中每个元素的类型，如果元素为空，则对应的类型为空
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <returns>当前序列中各个元素的类型的数组；如果序列元素为空，则元素类型为空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<Type> GetTypes(IEnumerable items)
	{
		Guard.AssertNotNull(items, "items");
		foreach (object item in items)
		{
			yield return ObjectHelper.IsNull(item) ? null : item.GetType();
		}
	}

	/// <summary>
	/// 获取当前序列中每个元素的类型，如果元素为空，则对应的类型为空
	/// </summary>
	/// <typeparam name="T">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <returns>当前序列中各个元素的类型的数组；如果序列元素为空，则元素类型为空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<Type> GetTypes<T>(IEnumerable<T> items)
	{
		Guard.AssertNotNull(items, "items");
		foreach (T item2 in items)
		{
			object item = item2;
			yield return ObjectHelper.IsNull(item) ? null : item.GetType();
		}
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="obj">待查找的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int IndexOf(IEnumerable source, object obj)
	{
		return IndexOf(source, 0, obj);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int IndexOf(IEnumerable source, object obj, Func<object, object, bool> equalition)
	{
		return IndexOf(source, 0, obj, equalition);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOf(IEnumerable source, int start, object obj)
	{
		return IndexOf(source, start, obj, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOf(IEnumerable source, int start, object obj, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		foreach (object item in SkipObject(source, start))
		{
			if (equalition(item, obj))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOf(IEnumerable source, int start, int count, object obj)
	{
		return IndexOf(source, start, count, obj, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOf(IEnumerable source, int start, int count, object obj, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		int end = start + count;
		foreach (object item in SkipObject(source, start))
		{
			if (start >= end)
			{
				break;
			}
			if (equalition(item, obj))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="obj">待查找的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int IndexOf<T>(IEnumerable<T> source, T obj)
	{
		return IndexOf(source, 0, obj);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int IndexOf<T>(IEnumerable<T> source, T obj, Func<T, T, bool> equalition)
	{
		return IndexOf(source, 0, obj, equalition);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOf<T>(IEnumerable<T> source, int start, T obj)
	{
		return IndexOf(source, start, obj, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOf<T>(IEnumerable<T> source, int start, T obj, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		foreach (T item in source.Skip(start))
		{
			if (equalition(item, obj))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOf<T>(IEnumerable<T> source, int start, int count, T obj)
	{
		return IndexOf(source, start, count, obj, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOf<T>(IEnumerable<T> source, int start, int count, T obj, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		int end = start + count;
		foreach (T item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			if (equalition(item, obj))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	public static int IndexOfAny(IEnumerable source, params object[] values)
	{
		return IndexOfAny(source, 0, values);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	public static int IndexOfAny(IEnumerable source, IEnumerable values, Func<object, object, bool> equalition)
	{
		return IndexOfAny(source, 0, values, equalition);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOfAny(IEnumerable source, int start, params object[] values)
	{
		return IndexOfAny(source, start, values, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOfAny(IEnumerable source, int start, IEnumerable values, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertNotNull(values, "values");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		foreach (object item in SkipObject(source, start))
		{
			Func<object, bool> predicate = (object x) => equalition(x, item);
			if (Any(values, predicate))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOfAny(IEnumerable source, int start, int count, params object[] values)
	{
		return IndexOfAny(source, start, count, values, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOfAny(IEnumerable source, int start, int count, IEnumerable values, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(values, "values");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		int end = start + count;
		foreach (object item in SkipObject(source, start))
		{
			if (start >= end)
			{
				break;
			}
			if (Any(values, (object x) => equalition(x, item)))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	public static int IndexOfAny<T>(IEnumerable<T> source, params T[] values)
	{
		return IndexOfAny(source, 0, values);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	public static int IndexOfAny<T>(IEnumerable<T> source, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		return IndexOfAny(source, 0, values, equalition);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOfAny<T>(IEnumerable<T> source, int start, params T[] values)
	{
		return IndexOfAny(source, start, values, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOfAny<T>(IEnumerable<T> source, int start, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertNotNull(values, "values");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		foreach (T item in source.Skip(start))
		{
			Func<T, bool> predicate = (T x) => equalition(x, item);
			if (values.Any(predicate))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOfAny<T>(IEnumerable<T> source, int start, int count, params T[] values)
	{
		return IndexOfAny(source, start, count, values, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOfAny<T>(IEnumerable<T> source, int start, int count, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(start, 0, "start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertNotNull(values, "values");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		int end = start + count;
		foreach (T item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			if (values.Any((T x) => equalition(x, item)))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert(IList list, int index, object item, int times)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			list.Insert(index++, item);
		}
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">插入的元素</param>
	/// <param name="evaluation">元素值处理方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素值处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert(IList list, int index, object item, Func<object, object> evaluation, int times = 1)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(evaluation, "evaluation");
		Insert(list, index, evaluation(item), times);
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="evaluation">计算方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert(IList list, int index, Func<object> evaluation, int times = 1)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		Insert(list, index, (int i) => evaluation(), times);
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="evaluation">计算方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert(IList list, int index, Func<int, object> evaluation, int times = 1)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		for (int i = 0; i < times; i++)
		{
			list.Insert(index++, evaluation(i));
		}
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert<T>(IList<T> list, int index, T item, int times)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			list.Insert(index++, item);
		}
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <typeparam name="T">当前列表的元素类型</typeparam>
	/// <typeparam name="V">待插入的项目的类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">插入的元素</param>
	/// <param name="evaluation">元素值处理方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素值处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert<T, V>(IList<T> list, int index, V item, Func<V, T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(evaluation, "evaluation");
		Insert(list, index, evaluation(item), times);
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="evaluation">计算方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert<T>(IList<T> list, int index, Func<T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		Insert(list, index, (int i) => evaluation(), times);
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="evaluation">计算方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert<T>(IList<T> list, int index, Func<int, T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		for (int i = 0; i < times; i++)
		{
			list.Insert(index++, evaluation(i));
		}
	}

	/// <summary>
	/// 向当前列表中插入指定项目的副本，默认将插入指定项目的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的项目</param>
	/// <param name="copying">项目复制函数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	public static void InsertCopy(IList list, int index, object item, Func<object, object> copying = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		copying = ObjectHelper.IfNull(copying, (object x) => ObjectHelper.ShallowCopy(x));
		list.Insert(index, copying(item));
	}

	/// <summary>
	/// 向当前列表中插入指定项目的副本，默认将插入指定项目的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的项目</param>
	/// <param name="times">插入次数</param>
	/// <param name="copying">项目复制函数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void InsertCopy(IList list, int index, object item, int times, Func<object, object> copying = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		copying = ObjectHelper.IfNull(copying, (object x) => ObjectHelper.ShallowCopy(x));
		while (times-- > 0)
		{
			list.Insert(index++, copying(item));
		}
	}

	/// <summary>
	/// 向当前列表中插入指定项目的副本，默认将插入指定项目的浅表副本
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的项目</param>
	/// <param name="copying">项目复制函数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	public static void InsertCopy<T>(IList<T> list, int index, T item, Func<T, T> copying = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		copying = ObjectHelper.IfNull(copying, (T x) => ObjectHelper.ShallowCopy(x));
		list.Insert(index, copying(item));
	}

	/// <summary>
	/// 向当前列表中插入指定项目的副本，默认将插入指定项目的浅表副本
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的项目</param>
	/// <param name="times">插入次数</param>
	/// <param name="copying">项目复制函数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void InsertCopy<T>(IList<T> list, int index, T item, int times, Func<T, T> copying = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		copying = ObjectHelper.IfNull(copying, (T x) => ObjectHelper.ShallowCopy(x));
		while (times-- > 0)
		{
			list.Insert(index++, copying(item));
		}
	}

	/// <summary>
	/// 向当前列表中插入指定项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素数组 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	public static void InsertRange(IList list, int index, params object[] items)
	{
		InsertRange(list, index, items, 1);
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange(IList list, int index, IEnumerable items, int times = 1)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			foreach (object item in items)
			{
				list.Insert(index++, item);
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空：或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange(IList list, int index, IEnumerable items, Func<object, object> evaluation, int times = 1)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		InsertRange(list, index, items, (object x, int i) => evaluation(x), times);
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空：或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange(IList list, int index, IEnumerable items, Func<object, int, object> evaluation, int times = 1)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			int no = 0;
			foreach (object item in items)
			{
				list.Insert(index++, evaluation(item, no++));
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入指定项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	public static void InsertRange<T>(IList<T> list, int index, params T[] items)
	{
		InsertRange(list, index, items, 1);
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange<T>(IList<T> list, int index, IEnumerable<T> items, int times = 1)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			foreach (T item in items)
			{
				list.Insert(index++, item);
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <typeparam name="V">插入的元素的类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空：或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange<T, V>(IList<T> list, int index, IEnumerable<V> items, Func<V, T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		InsertRange(list, index, items, (V x, int i) => evaluation(x), times);
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <typeparam name="V">插入的元素的类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空：或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange<T, V>(IList<T> list, int index, IEnumerable<V> items, Func<V, int, T> evaluation, int times = 1)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		while (times-- > 0)
		{
			int no = 0;
			foreach (V item in items)
			{
				list.Insert(index++, evaluation(item, no++));
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空。</exception>
	public static void InsertRangeCopy(IList list, int index, IEnumerable items, Func<object, object> copying = null)
	{
		copying = ObjectHelper.IfNull(copying, (object x) => ObjectHelper.ShallowCopy(x));
		InsertRangeCopy(list, index, items, (object x, int i) => copying(x));
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static void InsertRangeCopy(IList list, int index, IEnumerable items, Func<object, int, object> copying)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		copying = ObjectHelper.IfNull(copying, (object x, int i) => ObjectHelper.ShallowCopy(x));
		int no = 0;
		foreach (object item in items)
		{
			list.Insert(index++, copying(item, no++));
		}
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="times">插入的次数</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRangeCopy(IList list, int index, IEnumerable items, int times, Func<object, object> copying = null)
	{
		copying = ObjectHelper.IfNull(copying, (object x) => ObjectHelper.ShallowCopy(x));
		InsertRangeCopy(list, index, items, times, (object x, int i) => copying(x));
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="times">插入的次数</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRangeCopy(IList list, int index, IEnumerable items, int times, Func<object, int, object> copying)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		copying = ObjectHelper.IfNull(copying, (object x, int i) => ObjectHelper.ShallowCopy(x));
		int no = 0;
		while (times-- > 0)
		{
			no = 0;
			foreach (object item in items)
			{
				list.Insert(index++, copying(item, no++));
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <typeparam name="T">当前列表中的元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空。</exception>
	public static void InsertRangeCopy<T>(IList<T> list, int index, IEnumerable<T> items, Func<T, T> copying = null)
	{
		copying = ObjectHelper.IfNull(copying, (T x) => ObjectHelper.ShallowCopy(x));
		InsertRangeCopy(list, index, items, (T x, int i) => copying(x));
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <typeparam name="T">当前列表中的元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static void InsertRangeCopy<T>(IList<T> list, int index, IEnumerable<T> items, Func<T, int, T> copying)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		copying = ObjectHelper.IfNull(copying, (T x, int i) => ObjectHelper.ShallowCopy(x));
		int no = 0;
		foreach (T item in items)
		{
			list.Insert(index++, copying(item, no++));
		}
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <typeparam name="T">当前列表中的元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="times">插入的次数</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRangeCopy<T>(IList<T> list, int index, IEnumerable<T> items, int times, Func<T, T> copying = null)
	{
		copying = ObjectHelper.IfNull(copying, (T x) => ObjectHelper.ShallowCopy(x));
		InsertRangeCopy(list, index, items, times, (T x, int i) => copying(x));
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <typeparam name="T">当前列表中的元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="times">插入的次数</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRangeCopy<T>(IList<T> list, int index, IEnumerable<T> items, int times, Func<T, int, T> copying)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		Guard.AssertGreaterThanOrEqualTo(times, 0, "times");
		copying = ObjectHelper.IfNull(copying, (T x, int i) => ObjectHelper.ShallowCopy(x));
		int no = 0;
		while (times-- > 0)
		{
			no = 0;
			foreach (T item in items)
			{
				list.Insert(index++, copying(item, no++));
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入唯一的元素
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="equalition">列表元素相等比较方法</param>
	/// <returns>如果插入成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static bool InsertUnique(IList list, int index, object item, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		if (!Contains(list, item, equalition))
		{
			list.Insert(index, item);
			return true;
		}
		return false;
	}

	/// <summary>
	/// 向当前序列中插入唯一的元素
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果插入成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static bool InsertUnique(IList list, int index, object item, Func<object, object> evaluation, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(evaluation, "evaluation");
		return InsertUnique(list, index, evaluation(item), equalition);
	}

	/// <summary>
	/// 向当前列表中插入唯一的元素
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="equalition">列表元素相等比较方法</param>
	/// <returns>如果插入成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static bool InsertUnique<T>(IList<T> list, int index, T item, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		if (!Contains(list, item, equalition))
		{
			list.Insert(index, item);
			return true;
		}
		return false;
	}

	/// <summary>
	/// 向当前序列中插入唯一的元素
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <typeparam name="V">插入的元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果插入成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static bool InsertUnique<T, V>(IList<T> list, int index, V item, Func<V, T> evaluation, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(evaluation, "evaluation");
		return InsertUnique(list, index, evaluation(item), equalition);
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素数组</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素数组 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique(IList list, int index, params object[] items)
	{
		return InsertRangeUnique(list, index, (IEnumerable)items, (Func<object, object, bool>)null);
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique(IList list, int index, IEnumerable items, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		int count = 0;
		foreach (object item in items)
		{
			if (InsertUnique(list, index, item, equalition))
			{
				index++;
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique(IList list, int index, IEnumerable items, Func<object, object> evaluation, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return InsertRangeUnique(list, index, items, (object x, int i) => evaluation(x), equalition);
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique(IList list, int index, IEnumerable items, Func<object, int, object> evaluation, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		int count = 0;
		int no = 0;
		foreach (object item in items)
		{
			if (InsertUnique(list, index, item, (object x) => evaluation(x, no++), equalition))
			{
				index++;
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素数组</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素数组 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique<T>(IList<T> list, int index, params T[] items)
	{
		return InsertRangeUnique(list, index, (IEnumerable<T>)items, (Func<T, T, bool>)null);
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique<T>(IList<T> list, int index, IEnumerable<T> items, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		int count = 0;
		foreach (T item in items)
		{
			if (InsertUnique(list, index, item, equalition))
			{
				index++;
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <typeparam name="V">插入的元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique<T, V>(IList<T> list, int index, IEnumerable<V> items, Func<V, T> evaluation, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return InsertRangeUnique(list, index, items, (V x, int i) => evaluation(x), equalition);
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <typeparam name="V">插入的元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique<T, V>(IList<T> list, int index, IEnumerable<V> items, Func<V, int, T> evaluation, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(index, 0, list.Count, "index");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(evaluation, "evaluation");
		int count = 0;
		int no = 0;
		foreach (V item in items)
		{
			if (InsertUnique(list, index, item, (V x) => evaluation(x, no++), equalition))
			{
				index++;
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 获取当前序列与目标序列的交集
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <param name="equalition">返回两个序列的交集</param>
	/// <returns>返回两个序列的交集。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable Intersect(IEnumerable source, IEnumerable target, Func<object, object, bool> equalition)
	{
		return Intersect(source.OfType<object>(), target.OfType<object>(), equalition);
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列数组 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable Intersect(IEnumerable source, params IEnumerable[] targets)
	{
		return Intersect(source.OfType<object>(), targets.Select((IEnumerable x) => x.OfType<object>()), ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable Intersect(IEnumerable source, IEnumerable<IEnumerable> targets, Func<object, object, bool> equalition)
	{
		return Intersect(source.OfType<object>(), targets.Select((IEnumerable x) => x.OfType<object>()), ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 使用默认的相等比较器获取当前序列与目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">获取交集的目标序列</param>
	/// <returns>当前序列与目标序列的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(IEnumerable<T> source, IEnumerable<T> target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Intersect(target);
	}

	/// <summary>
	/// 使用指定的相等比较器获取当前序列与目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">获取交集的目标序列</param>
	/// <param name="equaliter">指定的序列元素相等比较器</param>
	/// <returns>当前序列与目标序列的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(IEnumerable<T> source, IEnumerable<T> target, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Intersect(target, equaliter);
	}

	/// <summary>
	/// 获取当前序列与目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <param name="equalition">返回两个序列的交集</param>
	/// <returns>返回两个序列的交集。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Intersect(target, ConvertHelper.ToComparer(equalition));
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列数组 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(IEnumerable<T> source, params IEnumerable<T>[] targets)
	{
		return Intersect(source, targets, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(targets, "targets");
		foreach (IEnumerable<T> target in targets)
		{
			if (ObjectHelper.IsNotNull(target))
			{
				source = source.Intersect(target, equaliter);
			}
		}
		return source;
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets, Func<T, T, bool> equalition)
	{
		return Intersect(source, targets, ConvertHelper.ToComparer(equalition));
	}

	/// <summary>
	/// 检测当前序列是否为空或者不包含任何元素
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <returns>如果当前序列为空或者不包含任何元素返回true，否则返回false</returns>
	public static bool IsNullOrEmpty(IEnumerable items)
	{
		return ObjectHelper.IsNull(items) || !Any(items);
	}

	/// <summary>
	/// 检测当前序列是否为空或者不包含任何元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <returns>如果序列为空或者不包含任何元素返回true，否则返回false</returns>
	public static bool IsNullOrEmpty<T>(IEnumerable<T> items)
	{
		return ObjectHelper.IsNull(items) || !items.Any();
	}

	/// <summary>
	/// 检测当前集合是否为空或者不包含任何元素。
	/// </summary>
	/// <param name="collection">当前集合</param>
	/// <returns>如果当前集合为空或者不包含任何元素返回true，否则返回false。</returns>
	public static bool IsNullOrEmpty(ICollection collection)
	{
		return ObjectHelper.IsNull(collection) || collection.Count == 0;
	}

	/// <summary>
	/// 检测当前集合是否为空或者不包含任何元素。
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <returns>如果当前集合为空或者不包含任何元素返回true，否则返回false。</returns>
	public static bool IsNullOrEmpty<T>(ICollection<T> collection)
	{
		return ObjectHelper.IsNull(collection) || collection.Count == 0;
	}

	/// <summary>
	/// 检测当前序列是否不为空且包含序列元素
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <returns>如果当前序列不为空且包含序列元素返回true，否则返回false</returns>
	public static bool IsNotNullAndEmpty(IEnumerable items)
	{
		return !object.ReferenceEquals(items, null) && Any(items);
	}

	/// <summary>
	/// 检测当前序列是否不为空且包含序列元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <returns>如果当前序列序列不为空且包含元素返回true，否则返回false</returns>
	public static bool IsNotNullAndEmpty<T>(IEnumerable<T> items)
	{
		return !object.ReferenceEquals(items, null) && items.Any();
	}

	/// <summary>
	/// 检测当前集合是否不为空且包含元素
	/// </summary>
	/// <param name="collection">当前集合</param>
	/// <returns>如果当前集合不为空且包含元素返回true，否则返回false。</returns>
	public static bool IsNotNullAndEmpty(ICollection collection)
	{
		return !object.ReferenceEquals(collection, null) && collection.Count > 0;
	}

	/// <summary>
	/// 检测当前集合是否不为空且包含元素
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <returns>如果当前集合不为空且包含元素返回true，否则返回false。</returns>
	public static bool IsNotNullAndEmpty<T>(ICollection<T> collection)
	{
		return !object.ReferenceEquals(collection, null) && collection.Count > 0;
	}

	/// <summary>
	/// 将序列元素连接为字符串；序列中各个元素通过调用ToString方法获取其字符串表示
	/// </summary>
	/// <param name="source">源序列</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	public static string JoinObjectString(IEnumerable source, string separator = null)
	{
		Guard.AssertNotNull(source, "source");
		separator = ObjectHelper.IfNull(separator, string.Empty);
		return JoinObjectString(source, (object x) => x.ToString(), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="format">当前序列元素格式化符合字符串</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinObjectString(IEnumerable source, string format, string separator = null)
	{
		Guard.AssertNotNull(source, "source");
		format = ObjectHelper.IfNull(format, "{0}");
		separator = ObjectHelper.IfNull(separator, string.Empty);
		return JoinObjectString(source, (object x) => string.Format(format, x), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="formatting">当前序列元素格式化方法</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinObjectString(IEnumerable source, Func<object, string> formatting, string separator = null)
	{
		Guard.AssertNotNull(source, "source");
		formatting = ObjectHelper.IfNull(formatting, (object x) => x.ToString());
		return JoinObjectString(source, (object x, int i) => formatting(x), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="formatting">当前序列元素格式化方法</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinObjectString(IEnumerable source, Func<object, int, string> formatting, string separator = null)
	{
		Guard.AssertNotNull(source, "source");
		formatting = ObjectHelper.IfNull(formatting, (object x, int i) => x.ToString());
		separator = ObjectHelper.IfNull(separator, string.Empty);
		StringBuilder buff = new StringBuilder();
		int index = 0;
		foreach (object item in source)
		{
			buff.Append(ObjectHelper.IfNull(formatting(item, index++), string.Empty)).Append(separator);
		}
		return (buff.Length > 0) ? buff.ToString(0, buff.Length - separator.Length) : string.Empty;
	}

	/// <summary>
	/// 将序列元素连接为字符串；序列中各个元素通过调用ToString方法获取其字符串表示
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">源序列</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	public static string JoinString<T>(IEnumerable<T> source, string separator = null)
	{
		Guard.AssertNotNull(source, "source");
		separator = ObjectHelper.IfNull(separator, string.Empty);
		return JoinString(source, (T x) => x.ToString(), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="format">当前序列元素格式化符合字符串</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinString<T>(IEnumerable<T> source, string format, string separator = null)
	{
		Guard.AssertNotNull(source, "source");
		format = ObjectHelper.IfNull(format, "{0}");
		separator = ObjectHelper.IfNull(separator, string.Empty);
		return JoinString(source, (T x) => string.Format(format, x), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="formatting">当前序列元素格式化方法</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinString<T>(IEnumerable<T> source, Func<T, string> formatting, string separator = null)
	{
		Guard.AssertNotNull(source, "source");
		formatting = ObjectHelper.IfNull(formatting, (T x) => x.ToString());
		return JoinString(source, (T x, int i) => formatting(x), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="formatting">当前序列元素格式化方法</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinString<T>(IEnumerable<T> source, Func<T, int, string> formatting, string separator = null)
	{
		Guard.AssertNotNull(source, "source");
		formatting = ObjectHelper.IfNull(formatting, (T x, int i) => x.ToString());
		separator = ObjectHelper.IfNull(separator, string.Empty);
		StringBuilder buff = new StringBuilder();
		int index = 0;
		foreach (T item in source)
		{
			buff.Append(ObjectHelper.IfNull(formatting(item, index++), string.Empty)).Append(separator);
		}
		return (buff.Length > 0) ? buff.ToString(0, buff.Length - separator.Length) : string.Empty;
	}

	/// <summary>
	/// 获取当前序列的最后一个元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列的最后一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Last<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Last();
	}

	/// <summary>
	/// 获取当前序列的最后一个满足条件的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列最后一个满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前序列中没有满足指定条件的元素。</exception>
	public static T Last<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Last(predicate);
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>最后一个符合条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T Last<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = source.Count() - 1;
		foreach (T item in source.Reverse())
		{
			if (predicate(item, index--))
			{
				return item;
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceNotElementInPredicate);
	}

	/// <summary>
	/// 获取当前序列中最后指定数量的元素的子序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> Last<T>(IEnumerable<T> source, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int start = source.Count() - count;
		start = ((start >= 0) ? start : 0);
		return source.Skip(start).Take(count);
	}

	/// <summary>
	/// 获取当前序列中的最后一个元素，如果当前序列不包含任何元素则抛出异常。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>最后一个符合条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static object LastObject(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		IEnumerator enumerator = ReverseObject(source).GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>最后一个符合条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object LastObject(IEnumerable source, Func<object, bool> predicate)
	{
		return LastObject(source, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>最后一个符合条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object LastObject(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = CountObject(source) - 1;
		foreach (object item in ReverseObject(source))
		{
			if (predicate(item, index--))
			{
				return item;
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceNotElementInPredicate);
	}

	/// <summary>
	/// 获取当前序列中最后指定数量的元素的子序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable LastObject(IEnumerable source, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int start = CountObject(source) - count;
		start = ((start >= 0) ? start : 0);
		return TakeObject(SkipObject(source, start), count);
	}

	/// <summary>
	/// 获取当前序列最后一个元素，如果当前序列不包含任何元素则返回序列元素类型的默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列的最后一个元素或者序列元素类型的默认值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T LastOrDefault<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull("source");
		return source.LastOrDefault();
	}

	/// <summary>
	/// 获取当前序列最后一个元素，如果当前序列为空则返回元素默认值 <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列的最后一个元素或者元素默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T LastOrDefault<T>(IEnumerable<T> source, T defaultValue)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(source, "source");
		using (IEnumerator<T> enumerator = source.Reverse().GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列最后一个满足条件的元素，如果当前序列不包含任何满足条件元素则返回序列元素类型的默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列的最后一个元素或者序列元素类型的默认值</returns>
	public static T LastOrDefault<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.LastOrDefault(predicate);
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素返回元素默认值 <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个符合条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T LastOrDefault<T>(IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return LastOrDefault(source, (T x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素返回元素默认值 <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个符合条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T LastOrDefault<T>(IEnumerable<T> source, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = source.Count() - 1;
		foreach (T item in source.Reverse())
		{
			if (predicate(item, index--))
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中最后指定数量元素的子序列，如果序列中的元素数量不足指定的数量，则使用序列元素默认值 <paramref name="defaultValue" /> 进行填充
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的序列元素数量</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的序列元素 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> LastOrDefault<T>(IEnumerable<T> source, int count, T defaultValue = default(T))
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int total = source.Count();
		if (total >= count)
		{
			return source.Skip(total - count).Take(count);
		}
		return ArrayHelper.Fill(new T[count - total], defaultValue).Concat(source);
	}

	/// <summary>
	/// 获取当前序列中的最后一个元素，如果当前序列为空则返回元素默认值 <paramref name="defaultValue" />
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static object LastObjectOrDefault(IEnumerable source, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		IEnumerator enumerator = ReverseObject(source).GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素默认值 <paramref name="defaultValue" />
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个符合条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object LastObjectOrDefault(IEnumerable source, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return LastObjectOrDefault(source, (object x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素则返回元素默认值 <paramref name="defaultValue" />
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个符合条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object LastObjectOrDefault(IEnumerable source, Func<object, int, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = CountObject(source) - 1;
		foreach (object item in ReverseObject(source))
		{
			if (predicate(item, index--))
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中最后指定数量元素的子序列，如果序列中的元素数量不足指定的数量，则使用序列元素默认值 <paramref name="defaultValue" /> 进行填充
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的序列元素数量</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的序列元素 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable LastObjectOrDefault(IEnumerable source, int count, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int total = CountObject(source);
		if (total >= count)
		{
			return SkipObject(source, total - count);
		}
		return ConcatObject(ArrayHelper.Fill(new object[total - count], defaultValue), source);
	}

	/// <summary>
	/// 获取当前序列中元素的数量
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列中元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static long LongCount<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.LongCount();
	}

	/// <summary>
	/// 获取当前序列中满足条件的元素的数量
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中满足条件的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static long LongCount<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.LongCount(predicate);
	}

	/// <summary>
	/// 生成指定范围内的整数的序列
	/// </summary>
	/// <param name="start">序列中的第一个整数值</param>
	/// <param name="count">要生成顺序整数的数目</param>
	/// <returns>生成的整数的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">生成顺序整数的数目 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<long> LongRange(long start, long count)
	{
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		for (long i = 0L; i < count; i++)
		{
			yield return start + i;
		}
	}

	/// <summary>
	/// 生成包含一个重复值的序列
	/// </summary>
	/// <typeparam name="T">生成的序列的元素类型</typeparam>
	/// <param name="element">重复的序列元素</param>
	/// <param name="count">重复的元素数量</param>
	/// <returns>生成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">重复的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> LongRepeat<T>(T element, long count)
	{
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		while (count-- > 0)
		{
			yield return element;
		}
	}

	/// <summary>
	/// 跳过当前序列中指定数量的元素，返回剩余的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">跳过元素的数量</param>
	/// <returns>当前序列中剩余元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过元素的数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> LongSkip<T>(IEnumerable<T> source, long count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		long index = 0L;
		foreach (T item in source)
		{
			if (index++ >= count)
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 跳过当前序列中指定数量的元素，返回剩余的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">跳过元素的数量</param>
	/// <returns>当前序列中剩余元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过元素的数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable LongSkipObject(IEnumerable source, long count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		long index = 0L;
		foreach (object item in source)
		{
			if (index++ >= count)
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 从当前序列的开头返回指定数量的连续元素。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>当前序列中剩余元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> LongTake<T>(IEnumerable<T> source, long count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		long index = 0L;
		foreach (T item in source)
		{
			if (index++ < count)
			{
				yield return item;
				continue;
			}
			break;
		}
	}

	/// <summary>
	/// 从当前序列的开头返回指定数量的连续元素。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>当前序列中剩余元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable LongTakeObject(IEnumerable source, long count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0L, "count");
		long index = 0L;
		foreach (object item in source)
		{
			if (index++ < count)
			{
				yield return item;
				continue;
			}
			break;
		}
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Max(IEnumerable source)
	{
		return Max(source, Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Max(IEnumerable source, IComparer comparer)
	{
		return Max(source, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Max(IEnumerable source, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer.Default.Compare);
		if (!Any(source))
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		object max = FirstObject(source);
		foreach (object item in source)
		{
			if (comparison(item, max) > 0)
			{
				max = item;
			}
		}
		return max;
	}

	/// <summary>
	/// 根据默认序列元素比较器获取当前序列中的最大值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Max<T>(IEnumerable<T> source)
	{
		return Max(source, Comparer<T>.Default);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Max<T>(IEnumerable<T> source, IComparer<T> comparer)
	{
		return Max(source, ObjectHelper.IfNull(comparer, Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Max<T>(IEnumerable<T> source, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		T max = source.First();
		foreach (T item in source)
		{
			if (comparison(item, max) > 0)
			{
				max = item;
			}
		}
		return max;
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxObject(IEnumerable source)
	{
		return MaxObject(source, Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxObject(IEnumerable source, IComparer comparer)
	{
		return MaxObject(source, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxObject(IEnumerable source, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer.Default.Compare);
		if (!Any(source))
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		object max = FirstObject(source);
		foreach (object item in source)
		{
			if (comparison(item, max) > 0)
			{
				max = item;
			}
		}
		return max;
	}

	/// <summary>
	/// 根据默认序列元素比较器获取当前序列中的最大值，如果当前序列为空序列则返回默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T MaxOrDefault<T>(IEnumerable<T> source, T defaultValue = default(T))
	{
		return MaxOrDefault(source, Comparer<T>.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则返回默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T MaxOrDefault<T>(IEnumerable<T> source, IComparer<T> comparer, T defaultValue = default(T))
	{
		return MaxOrDefault(source, ObjectHelper.IfNull(comparer, Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则返回默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T MaxOrDefault<T>(IEnumerable<T> source, Func<T, T, int> comparison, T defaultValue = default(T))
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		if (!source.Any())
		{
			return defaultValue;
		}
		T max = source.First();
		foreach (T item in source)
		{
			if (comparison(item, max) > 0)
			{
				max = item;
			}
		}
		return max;
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxObjectOrDefault(IEnumerable source, object defaultValue = null)
	{
		return MaxObjectOrDefault(source, Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxObjectOrDefault(IEnumerable source, IComparer comparer, object defaultValue = null)
	{
		return MaxObjectOrDefault(source, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxObjectOrDefault(IEnumerable source, Func<object, object, int> comparison, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer.Default.Compare);
		if (!Any(source))
		{
			return defaultValue;
		}
		object max = FirstObject(source);
		foreach (object item in source)
		{
			if (comparison(item, max) > 0)
			{
				max = item;
			}
		}
		return max;
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static T Median<T>(IEnumerable<T> source)
	{
		return Median(source, Comparer<T>.Default);
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static T Median<T>(IEnumerable<T> source, IComparer<T> comparer)
	{
		Guard.AssertNotNull(source, "source");
		comparer = ObjectHelper.IfNull(comparer, Comparer<T>.Default);
		int count = source.Count();
		if (count == 0)
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		return OrderBy(source, comparer).ElementAt(count / 2);
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static T Median<T>(IEnumerable<T> source, Func<T, T, int> comparison)
	{
		return Median(source, ConvertHelper.ToComparer(comparison));
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static object MedianObject(IEnumerable source)
	{
		return MedianObject(source, Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static object MedianObject(IEnumerable source, IComparer comparer)
	{
		return MedianObject(source, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static object MedianObject(IEnumerable source, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer.Default.Compare);
		int count = CountObject(source);
		if (count == 0)
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		return OrderBy(source.OfType<object>(), ConvertHelper.ToComparer<object>(comparison)).ElementAt(count / 2);
	}

	/// <summary>
	/// 将当前列表指定的序列进行合并, 相同的序列元素由指定的合并方法进行处理
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">合并的序列</param>
	/// <param name="merging">合并相同元素的方法，接收列表中的元素和待合并的相同的元素</param>
	/// <param name="equalition">合并元素的比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者合并的序列 <paramref name="items" /> 为空；或者合并方法 <paramref name="merging" /> 为空。</exception>
	public static void Merge(IList list, IEnumerable items, Func<object, object, object> merging, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(merging, "merging");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		int index = 0;
		foreach (object item in items)
		{
			if ((index = IndexOf(list, item, equalition)) >= 0)
			{
				list[index] = merging(list[index], item);
			}
			else
			{
				list.Add(item);
			}
		}
	}

	/// <summary>
	/// 将当前列表指定的序列进行合并, 相同的序列元素由指定的合并方法进行处理
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">合并的序列</param>
	/// <param name="merging">合并中找到相同元素的合并方法，接收当前列表、当前列表中重复元素的索引以及待合并的元素</param>
	/// <param name="equalition">合并元素的比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者合并序列 <paramref name="items" /> 为空；或者合并方法 <paramref name="merging" /> 为空。</exception>
	public static void Merge(IList list, IEnumerable items, Action<IList, int, object> merging, Func<object, object, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(merging, "merging");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		int index = 0;
		foreach (object item in items)
		{
			if ((index = IndexOf(list, item, equalition)) >= 0)
			{
				merging(list, index, item);
			}
			else
			{
				list.Add(item);
			}
		}
	}

	/// <summary>
	/// 将当前列表指定的序列进行合并, 相同的序列元素由指定的合并方法进行处理
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">合并的序列</param>
	/// <param name="merging">合并相同元素的方法，接收列表中的元素和待合并的相同的元素</param>
	/// <param name="equalition">合并元素的比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者合并的序列 <paramref name="items" /> 为空；或者合并方法 <paramref name="merging" /> 为空。</exception>
	public static void Merge<T>(IList<T> list, IEnumerable<T> items, Func<T, T, T> merging, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(merging, "merging");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		int index = 0;
		foreach (T item in items)
		{
			if ((index = IndexOf(list, item, equalition)) >= 0)
			{
				list[index] = merging(list[index], item);
			}
			else
			{
				list.Add(item);
			}
		}
	}

	/// <summary>
	/// 将当前列表指定的序列进行合并, 相同的序列元素由指定的合并方法进行处理
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">合并的序列</param>
	/// <param name="merging">合并中找到相同元素的合并方法，接收当前列表、当前列表中重复元素的索引以及待合并的元素</param>
	/// <param name="equalition">合并元素的比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者合并序列 <paramref name="items" /> 为空；或者合并方法 <paramref name="merging" /> 为空。</exception>
	public static void Merge<T>(IList<T> list, IEnumerable<T> items, Action<IList<T>, int, T> merging, Func<T, T, bool> equalition = null)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		Guard.AssertNotNull(merging, "merging");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		int index = 0;
		foreach (T item in items)
		{
			if ((index = IndexOf(list, item, equalition)) >= 0)
			{
				merging(list, index, item);
			}
			else
			{
				list.Add(item);
			}
		}
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
	public static void Merge<K, V>(IDictionary<K, V> dictionary, IDictionary<K, V> merging, bool overwrite = false)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(merging, "target");
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
	/// 使用序列元素默认比较器获取当前序列中的最小值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列中元素的最小值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T Min<T>(IEnumerable<T> source)
	{
		return Min(source, Comparer<T>.Default);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Min<T>(IEnumerable<T> source, IComparer<T> comparer)
	{
		return Min(source, ObjectHelper.IfNull(comparer, Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Min<T>(IEnumerable<T> source, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		T min = source.First();
		foreach (T item in source)
		{
			if (comparison(item, min) < 0)
			{
				min = item;
			}
		}
		return min;
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinObject(IEnumerable source)
	{
		return MinObject(source, Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinObject(IEnumerable source, IComparer comparer)
	{
		return MinObject(source, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinObject(IEnumerable source, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer.Default.Compare);
		if (!Any(source))
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		object min = FirstObject(source);
		foreach (object item in source)
		{
			if (comparison(item, min) < 0)
			{
				min = item;
			}
		}
		return min;
	}

	/// <summary>
	/// 使用序列元素默认比较器获取当前序列中的最小值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>当前序列中元素的最小值，如果当前序列为空则返回默认值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T MinOrDefault<T>(IEnumerable<T> source, T defaultValue = default(T))
	{
		return MinOrDefault(source, Comparer<T>.Default, defaultValue);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T MinOrDefault<T>(IEnumerable<T> source, IComparer<T> comparer, T defaultValue = default(T))
	{
		return MinOrDefault(source, ObjectHelper.IfNull(comparer, Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T MinOrDefault<T>(IEnumerable<T> source, Func<T, T, int> comparison, T defaultValue = default(T))
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		if (!source.Any())
		{
			return defaultValue;
		}
		T min = source.First();
		foreach (T item in source)
		{
			if (comparison(item, min) < 0)
			{
				min = item;
			}
		}
		return min;
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinObjectOrDefault(IEnumerable source, object defaultValue = null)
	{
		return MinObjectOrDefault(source, Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinObjectOrDefault(IEnumerable source, IComparer comparer, object defaultValue = null)
	{
		return MinObjectOrDefault(source, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinObjectOrDefault(IEnumerable source, Func<object, object, int> comparison, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		comparison = ObjectHelper.IfNull(comparison, Comparer.Default.Compare);
		if (!Any(source))
		{
			return defaultValue;
		}
		object min = FirstObject(source);
		foreach (object item in source)
		{
			if (comparison(item, min) < 0)
			{
				min = item;
			}
		}
		return min;
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Most<T>(IEnumerable<T> source)
	{
		return Most(source, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Most<T>(IEnumerable<T> source, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		Dictionary<T, int> bag = new Dictionary<T, int>(equaliter);
		foreach (T item in source)
		{
			if (bag.ContainsKey(item))
			{
				bag[item]++;
			}
			else
			{
				bag.Add(item, 1);
			}
		}
		return Max(bag, (KeyValuePair<T, int> p1, KeyValuePair<T, int> p2) => p1.Value - p2.Value).Key;
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Most<T>(IEnumerable<T> source, Func<T, T, bool> equalition)
	{
		return Most(source, ConvertHelper.ToComparer(equalition));
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MostObject(IEnumerable source)
	{
		return MostObject(source, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MostObject(IEnumerable source, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		if (!Any(source))
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		Dictionary<object, int> bag = new Dictionary<object, int>(ConvertHelper.ToComparer<object>(equalition));
		foreach (object item in source)
		{
			if (bag.ContainsKey(item))
			{
				bag[item]++;
			}
			else
			{
				bag.Add(item, 1);
			}
		}
		return Max(bag, (KeyValuePair<object, int> p1, KeyValuePair<object, int> p2) => p1.Value - p2.Value).Key;
	}

	/// <summary>
	/// 获取当前序列中指定位置的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="index">获取的元素索引</param>
	/// <returns>当前序列指定位置的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">指定的元素索引 <paramref name="index" /> 小于0。</exception>
	public static object ObjectAt(IEnumerable source, int index)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(index, 0, "index");
		long current = 0L;
		foreach (object item in source)
		{
			if (current++ == index)
			{
				return item;
			}
		}
		throw new IndexOutOfRangeException(string.Format(Literals.MSG_IndexOutOfRange_1, index));
	}

	/// <summary>
	/// 获取当前序列中指定位置的元素，如果指定位置的值不存在则返回元素默认值 <paramref name="defaultValue" />
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="index">获取的元素索引</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列指定位置的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">指定的元素索引 <paramref name="index" /> 小于0。</exception>
	public static object ObjectAtOrDefault(IEnumerable source, int index, object defaultValue = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertIndexLowBound(index, 0, "index");
		long current = 0L;
		foreach (object item in source)
		{
			if (current++ == index)
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderBy<T>(IEnumerable<T> source)
	{
		return OrderBy(source, Comparer<T>.Default);
	}

	/// <summary>
	/// 将当前序列中的元素按键的升序进行排序，返回排序后的序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="K">当前序列元素键类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keySelection">序列元素键选择方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者键选择方法 <paramref name="keySelection" /> 为空。</exception>
	public static IOrderedEnumerable<T> OrderBy<T, K>(IEnumerable<T> source, Func<T, K> keySelection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		return source.OrderBy(keySelection);
	}

	/// <summary>
	/// 将当前序列中的元素按键的升序进行排序，返回排序后的序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="K">当前序列元素键类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keySelection">序列元素键选择方法</param>
	/// <param name="comparer">元素键比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者键选择方法 <paramref name="keySelection" /> 为空。</exception>
	public static IOrderedEnumerable<T> OrderBy<T, K>(IEnumerable<T> source, Func<T, K> keySelection, IComparer<K> comparer)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		return source.OrderBy(keySelection, comparer);
	}

	/// <summary>
	/// 将当前序列中的元素按键的升序进行排序，返回排序后的序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="K">当前序列元素键类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keySelection">序列元素键选择方法</param>
	/// <param name="comparison">元素键比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者键选择方法 <paramref name="keySelection" /> 为空。</exception>
	public static IOrderedEnumerable<T> OrderBy<T, K>(IEnumerable<T> source, Func<T, K> keySelection, Func<K, K, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		return source.OrderBy(keySelection, ObjectHelper.IsNull(comparison) ? null : ConvertHelper.ToComparer(comparison));
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">元素排序比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderBy<T>(IEnumerable<T> source, IComparer<T> comparer)
	{
		Guard.AssertNotNull(source, "source");
		return source.OrderBy((T x) => x, ObjectHelper.IfNull(comparer, Comparer<T>.Default));
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">元素排序比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderBy<T>(IEnumerable<T> source, Func<T, T, int> comparison)
	{
		return OrderBy(source, ObjectHelper.IsNull(comparison) ? null : ConvertHelper.ToComparer(comparison));
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空。</exception>
	public static IEnumerable<T> OrderBy<T>(IEnumerable<T> source, params Func<T, object>[] keys)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], Comparer<object>.Default) : source.OrderBy(keys[i], Comparer<object>.Default));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparers">排序键排序对象</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序对象为空。</exception>
	public static IEnumerable<T> OrderBy<T>(IEnumerable<T> source, Func<T, object>[] keys, IComparer<object>[] comparers)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		Guard.AssertNotNull(comparers, "key comparers");
		Guard.AssertArrayLength(comparers, keys.Length, "key comparers");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			Guard.AssertNotNull(comparers[i], "key comparer");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], comparers[i]) : source.OrderBy(keys[i], comparers[i]));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparisons">排序键排序方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序方法为空。</exception>
	public static IEnumerable<T> OrderBy<T>(IEnumerable<T> source, Func<T, object>[] keys, Func<object, object, int>[] comparisons)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		Guard.AssertNotNull(comparisons, "key comparisons");
		Guard.AssertArrayLength(comparisons, keys.Length, "key comparisons");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			Guard.AssertNotNull(comparisons[i], "key comparsion");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], ConvertHelper.ToComparer<object>(comparisons[i])) : source.OrderBy(keys[i], ConvertHelper.ToComparer<object>(comparisons[i])));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable OrderObjectBy(IEnumerable source)
	{
		return OrderObjectBy(source, Comparer.Default);
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">元素排序比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable OrderObjectBy(IEnumerable source, IComparer comparer)
	{
		Guard.AssertNotNull(source, "source");
		return source.OfType<object>().OrderBy((object x) => x, ConvertHelper.ToComparer(ObjectHelper.IfNull(comparer, Comparer.Default)));
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">元素排序比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable OrderObjectBy(IEnumerable source, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		return source.OfType<object>().OrderBy((object x) => x, ConvertHelper.ToComparer<object>(ObjectHelper.IfNull(comparison, Comparer.Default.Compare)));
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空。</exception>
	public static IEnumerable OrderObjectBy(IEnumerable source, params Func<object, object>[] keys)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], Comparer<object>.Default) : source.OfType<object>().OrderBy(keys[i], Comparer<object>.Default));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparers">排序键排序对象</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序对象为空。</exception>
	public static IEnumerable OrderObjectBy(IEnumerable source, Func<object, object>[] keys, IComparer[] comparers)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		Guard.AssertNotNull(comparers, "key comparers");
		Guard.AssertArrayLength(comparers, keys.Length, "key comparers");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			Guard.AssertNotNull(comparers[i], "key comparer");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], ConvertHelper.ToComparer(comparers[i])) : source.OfType<object>().OrderBy(keys[i], ConvertHelper.ToComparer(comparers[i])));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparisons">排序键排序方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序方法为空。</exception>
	public static IEnumerable OrderObjectBy(IEnumerable source, Func<object, object>[] keys, Func<object, object, int>[] comparisons)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		Guard.AssertNotNull(comparisons, "key comparisons");
		Guard.AssertArrayLength(comparisons, keys.Length, "key comparisons");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			Guard.AssertNotNull(comparisons[i], "key comparsion");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], ConvertHelper.ToComparer<object>(comparisons[i])) : source.OfType<object>().OrderBy(keys[i], ConvertHelper.ToComparer<object>(comparisons[i])));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(IEnumerable<T> source)
	{
		return OrderByDescending(source, Comparer<T>.Default);
	}

	/// <summary>
	/// 将当前序列中的元素按键的降序进行排序，返回排序后的序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="K">当前序列元素键类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keySelection">序列元素键选择方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者键选择方法 <paramref name="keySelection" /> 为空。</exception>
	public static IOrderedEnumerable<T> OrderByDescending<T, K>(IEnumerable<T> source, Func<T, K> keySelection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		return source.OrderByDescending(keySelection);
	}

	/// <summary>
	/// 将当前序列中的元素按键的降序进行排序，返回排序后的序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="K">当前序列元素键类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keySelection">序列元素键选择方法</param>
	/// <param name="comparer">元素键比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者键选择方法 <paramref name="keySelection" /> 为空。</exception>
	public static IOrderedEnumerable<T> OrderByDescending<T, K>(IEnumerable<T> source, Func<T, K> keySelection, IComparer<K> comparer)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		return source.OrderByDescending(keySelection, comparer);
	}

	/// <summary>
	/// 将当前序列中的元素按键的降序进行排序，返回排序后的序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="K">当前序列元素键类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keySelection">序列元素键选择方法</param>
	/// <param name="comparison">元素键比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者键选择方法 <paramref name="keySelection" /> 为空。</exception>
	public static IOrderedEnumerable<T> OrderByDescending<T, K>(IEnumerable<T> source, Func<T, K> keySelection, Func<K, K, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		return source.OrderByDescending(keySelection, ObjectHelper.IsNull(comparison) ? null : ConvertHelper.ToComparer(comparison));
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">元素排序比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(IEnumerable<T> source, IComparer<T> comparer)
	{
		Guard.AssertNotNull(source, "source");
		return source.OrderByDescending((T x) => x, ObjectHelper.IfNull(comparer, Comparer<T>.Default));
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">元素排序比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(IEnumerable<T> source, Func<T, T, int> comparison)
	{
		return OrderByDescending(source, ObjectHelper.IsNull(comparison) ? null : ConvertHelper.ToComparer(comparison));
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(IEnumerable<T> source, params Func<T, object>[] keys)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], Comparer<object>.Default) : source.OrderByDescending(keys[i], Comparer<object>.Default));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparers">排序键排序对象</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序对象为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(IEnumerable<T> source, Func<T, object>[] keys, IComparer<object>[] comparers)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		Guard.AssertNotNull(comparers, "key comparers");
		Guard.AssertArrayLength(comparers, keys.Length, "key comparers");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			Guard.AssertNotNull(comparers[i], "key comparer");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], comparers[i]) : source.OrderByDescending(keys[i], comparers[i]));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparisons">排序键排序方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序方法为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(IEnumerable<T> source, Func<T, object>[] keys, Func<object, object, int>[] comparisons)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		Guard.AssertNotNull(comparisons, "key comparisons");
		Guard.AssertArrayLength(comparisons, keys.Length, "key comparisons");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			Guard.AssertNotNull(comparisons[i], "key comparsion");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], ConvertHelper.ToComparer<object>(comparisons[i])) : source.OrderByDescending(keys[i], ConvertHelper.ToComparer<object>(comparisons[i])));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable OrderObjectByDescending(IEnumerable source)
	{
		return OrderObjectByDescending(source, Comparer.Default);
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">元素排序比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable OrderObjectByDescending(IEnumerable source, IComparer comparer)
	{
		Guard.AssertNotNull(source, "source");
		return source.OfType<object>().OrderByDescending((object x) => x, ConvertHelper.ToComparer(ObjectHelper.IfNull(comparer, Comparer.Default)));
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">元素排序比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable OrderObjectByDescending(IEnumerable source, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(source, "source");
		return source.OfType<object>().OrderByDescending((object x) => x, ConvertHelper.ToComparer<object>(ObjectHelper.IfNull(comparison, Comparer.Default.Compare)));
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空。</exception>
	public static IEnumerable OrderObjectByDescending(IEnumerable source, params Func<object, object>[] keys)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], Comparer<object>.Default) : source.OfType<object>().OrderByDescending(keys[i], Comparer<object>.Default));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparers">排序键排序对象</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序对象为空。</exception>
	public static IEnumerable OrderObjectByDescending(IEnumerable source, Func<object, object>[] keys, IComparer[] comparers)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		Guard.AssertNotNull(comparers, "key comparers");
		Guard.AssertArrayLength(comparers, keys.Length, "key comparers");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			Guard.AssertNotNull(comparers[i], "key comparer");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], ConvertHelper.ToComparer(comparers[i])) : source.OfType<object>().OrderByDescending(keys[i], ConvertHelper.ToComparer(comparers[i])));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparisons">排序键排序方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序方法为空。</exception>
	public static IEnumerable OrderObjectByDescending(IEnumerable source, Func<object, object>[] keys, Func<object, object, int>[] comparisons)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keys, "key selectors");
		Guard.AssertNotNull(comparisons, "key comparisons");
		Guard.AssertArrayLength(comparisons, keys.Length, "key comparisons");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			Guard.AssertNotNull(keys[i], "key selector");
			Guard.AssertNotNull(comparisons[i], "key comparsion");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], ConvertHelper.ToComparer<object>(comparisons[i])) : source.OfType<object>().OrderByDescending(keys[i], ConvertHelper.ToComparer<object>(comparisons[i])));
		}
		return ordered;
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="item">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Prepend(IEnumerable source, object item)
	{
		Guard.AssertNotNull(source, "source");
		yield return item;
		foreach (object item2 in source)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Prepend(IEnumerable source, params object[] items)
	{
		return Prepend(source, (IEnumerable)items);
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Prepend(IEnumerable source, IEnumerable items)
	{
		Guard.AssertNotNull(source, "source");
		if (ObjectHelper.IsNotNull(items))
		{
			foreach (object item in items)
			{
				yield return item;
			}
		}
		foreach (object item2 in source)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="item">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Prepend<T>(IEnumerable<T> source, T item)
	{
		Guard.AssertNotNull(source, "source");
		yield return item;
		foreach (T item2 in source)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Prepend<T>(IEnumerable<T> source, params T[] items)
	{
		return Prepend(source, (IEnumerable<T>)items);
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Prepend<T>(IEnumerable<T> source, IEnumerable<T> items)
	{
		Guard.AssertNotNull(source, "source");
		if (ObjectHelper.IsNotNull(items))
		{
			foreach (T item in items)
			{
				yield return item;
			}
		}
		foreach (T item2 in source)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 生成指定范围内的整数的序列
	/// </summary>
	/// <param name="start">序列中的第一个整数值</param>
	/// <param name="count">要生成顺序整数的数目</param>
	/// <returns>生成的整数的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">生成顺序整数的数目 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<int> Range(int start, int count)
	{
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return Enumerable.Range(start, count);
	}

	/// <summary>
	/// 从当前列表中移除满足条件的第一个匹配的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Remove(IList list, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Remove(list, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 从当前列表中移除满足条件的第一个匹配的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Remove(IList list, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(predicate, "predicate");
		for (int i = 0; i < list.Count; i++)
		{
			if (predicate(list[i], i))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前列表中移除第一个匹配的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static bool Remove(IList list, object item, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		for (int i = 0; i < list.Count; i++)
		{
			if (equalition(list[i], item))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int Remove(IList list, params object[] items)
	{
		return Remove(list, items, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove(IList list, IEnumerable items)
	{
		return Remove(list, items, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove(IList list, IEnumerable items, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			foreach (object item in items)
			{
				if (equalition(list[i], item))
				{
					list.RemoveAt(i--);
					count++;
					break;
				}
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前集合中移除序列中每个元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">移除的匹配元素数组</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove<T>(ICollection<T> collection, params T[] items)
	{
		return Remove(collection, (IEnumerable<T>)items);
	}

	/// <summary>
	/// 从当前集合中移除序列中每个元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">移除的匹配元素序列</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove<T>(ICollection<T> collection, IEnumerable<T> items)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		int count = 0;
		foreach (T item in items)
		{
			if (collection.Remove(item))
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中移除满足条件的第一个匹配的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Remove<T>(IList<T> list, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return Remove(list, (T x, int i) => predicate(x));
	}

	/// <summary>
	/// 从当前列表中移除满足条件的第一个匹配的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Remove<T>(IList<T> list, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(predicate, "predicate");
		for (int i = 0; i < list.Count; i++)
		{
			if (predicate(list[i], i))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前列表中移除第一个匹配的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <param name="equaliter">列表元素比较器</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static bool Remove<T>(IList<T> list, T item, IEqualityComparer<T> equaliter)
	{
		return Remove(list, item, ObjectHelper.IfNull(equaliter, EqualityComparer<T>.Default).Equals);
	}

	/// <summary>
	/// 从当前列表中移除第一个匹配的项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static bool Remove<T>(IList<T> list, T item, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		for (int i = 0; i < list.Count; i++)
		{
			if (equalition(list[i], item))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int Remove<T>(IList<T> list, params T[] items)
	{
		return Remove(list, items, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove<T>(IList<T> list, IEnumerable<T> items)
	{
		return Remove(list, items, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equaliter">列表元素比较器</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove<T>(IList<T> list, IEnumerable<T> items, IEqualityComparer<T> equaliter)
	{
		return Remove(list, items, ObjectHelper.IfNull(equaliter, EqualityComparer<T>.Default).Equals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove<T>(IList<T> list, IEnumerable<T> items, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			foreach (T item in items)
			{
				if (equalition(list[i], item))
				{
					list.RemoveAt(i--);
					count++;
					break;
				}
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前集合中移除数组中任意元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny(IList list, params object[] items)
	{
		return RemoveAny(list, items, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny(IList list, IEnumerable items)
	{
		return RemoveAny(list, items, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny(IList list, IEnumerable items, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		for (int i = 0; i < list.Count; i++)
		{
			if (Contains(items, list[i], equalition))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前集合中移除数组中任意元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">移除的匹配元素数组</param>
	/// <returns>如果成功移除元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny<T>(ICollection<T> collection, params T[] items)
	{
		return RemoveAny(collection, (IEnumerable<T>)items);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">移除的匹配元素序列</param>
	/// <returns>如果成功移除元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny<T>(ICollection<T> collection, IEnumerable<T> items)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		foreach (T item in items)
		{
			if (collection.Remove(item))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前集合中移除数组中任意元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny<T>(IList<T> list, params T[] items)
	{
		return RemoveAny(list, items, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny<T>(IList<T> list, IEnumerable<T> items)
	{
		return RemoveAny(list, items, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equaliter">列表元素比较器</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny<T>(IList<T> list, IEnumerable<T> items, IEqualityComparer<T> equaliter)
	{
		return RemoveAny(list, items, ObjectHelper.IfNull(equaliter, EqualityComparer<T>.Default).Equals);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny<T>(IList<T> list, IEnumerable<T> items, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		for (int i = 0; i < list.Count; i++)
		{
			if (Contains(items, list[i], equalition))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前列表中移除满足条件的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int RemoveAll(IList list, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return RemoveAll(list, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 从当前列表中移除满足条件的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int RemoveAll(IList list, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(predicate, "predicate");
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (predicate(list[i], i))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中移除与指定项目匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int RemoveAll(IList list, object item)
	{
		return RemoveAll(list, item, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除与指定项目匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int RemoveAll(IList list, object item, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (equalition(list[i], item))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll(IList list, params object[] items)
	{
		return RemoveAll(list, items, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll(IList list, IEnumerable items)
	{
		return RemoveAll(list, items, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll(IList list, IEnumerable items, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (Contains(items, list[i], equalition))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前集合中移除所有与指定元素匹配的元素
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">移除的元素</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	public static int RemoveAll<T>(ICollection<T> collection, T item)
	{
		Guard.AssertNotNull(collection, "collection");
		int count = 0;
		while (collection.Remove(item))
		{
			count++;
		}
		return count;
	}

	/// <summary>
	/// 从当前集合中移除所有与指定的序列中的任一元素匹配的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll<T>(ICollection<T> collection, params T[] items)
	{
		return RemoveAll(collection, (IEnumerable<T>)items);
	}

	/// <summary>
	/// 从当前集合中移除所有与指定的序列中的任一元素匹配的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll<T>(ICollection<T> collection, IEnumerable<T> items)
	{
		Guard.AssertNotNull(collection, "collection");
		Guard.AssertNotNull(items, "items");
		int count = 0;
		foreach (T item in items)
		{
			count += RemoveAll(collection, item);
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中移除满足条件的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int RemoveAll<T>(IList<T> list, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return RemoveAll(list, (T x, int i) => predicate(x));
	}

	/// <summary>
	/// 从当前列表中移除满足条件的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int RemoveAll<T>(IList<T> list, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(predicate, "predicate");
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (predicate(list[i], i))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中移除与指定项目匹配的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int RemoveAll<T>(IList<T> list, T item)
	{
		return RemoveAll(list, item, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 从当前列表中移除与指定项目匹配的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <param name="equaliter">列表元素比较器</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int RemoveAll<T>(IList<T> list, T item, IEqualityComparer<T> equaliter)
	{
		return RemoveAll(list, item, ObjectHelper.IfNull(equaliter, EqualityComparer<T>.Default).Equals);
	}

	/// <summary>
	/// 从当前列表中移除与指定项目匹配的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int RemoveAll<T>(IList<T> list, T item, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (equalition(list[i], item))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll<T>(IList<T> list, params T[] items)
	{
		return RemoveAll(list, items, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll<T>(IList<T> list, IEnumerable<T> items)
	{
		return RemoveAll(list, items, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equaliter">列表元素比较器</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll<T>(IList<T> list, IEnumerable<T> items, IEqualityComparer<T> equaliter)
	{
		return RemoveAll(list, items, ObjectHelper.IfNull(equaliter, EqualityComparer<T>.Default).Equals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <typeparam name="T">当前列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll<T>(IList<T> list, IEnumerable<T> items, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(items, "items");
		equalition = ObjectHelper.IfNull(equalition, EqualityComparer<T>.Default.Equals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (Contains(items, list[i], equalition))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中删除多个指定索引位置的元素
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="indices">删除的多个索引位置</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者删除的索引位置数组 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定删除的索引位置超出当前列表元素有效的索引范围。</exception>
	public static void RemoveAt(IList list, params int[] indices)
	{
		RemoveAt(list, (IEnumerable<int>)indices);
	}

	/// <summary>
	/// 从当前列表中删除多个指定索引位置的元素
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="indices">删除的多个索引序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者删除的索引位置序列 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定删除的索引位置超出当前列表元素有效的索引范围。</exception>
	public static void RemoveAt(IList list, IEnumerable<int> indices)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(indices, "indices");
		foreach (int index in Distinct(OrderByDescending(indices)))
		{
			Guard.AssertIndexRange(index, 0, list.Count - 1);
			list.RemoveAt(index);
		}
	}

	/// <summary>
	/// 从当前列表中删除多个指定索引位置的元素
	/// </summary>
	/// <typeparam name="T">当期列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="indices">删除的多个索引位置</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者删除的索引位置数组 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定删除的索引位置超出当前列表元素有效的索引范围。</exception>
	public static void RemoveAt<T>(IList<T> list, params int[] indices)
	{
		RemoveAt(list, (IEnumerable<int>)indices);
	}

	/// <summary>
	/// 从当前列表中删除多个指定索引位置的元素
	/// </summary>
	/// <typeparam name="T">当期列表元素类型</typeparam>
	/// <param name="list">当前列表</param>
	/// <param name="indices">删除的多个索引序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者删除的索引位置序列 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定删除的索引位置超出当前列表元素有效的索引范围。</exception>
	public static void RemoveAt<T>(IList<T> list, IEnumerable<int> indices)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertNotNull(indices, "indices");
		foreach (int index in OrderByDescending(indices).Distinct())
		{
			Guard.AssertIndexRange(index, 0, list.Count - 1);
			list.RemoveAt(index);
		}
	}

	/// <summary>
	/// 生成包含一个重复值的序列
	/// </summary>
	/// <typeparam name="T">生成的序列的元素类型</typeparam>
	/// <param name="element">重复的序列元素</param>
	/// <param name="count">重复的元素数量</param>
	/// <returns>生成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">重复的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> Repeat<T>(T element, int count)
	{
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return Enumerable.Repeat(element, count);
	}

	/// <summary>
	/// 反转当前序列中的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>反转后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Reverse<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Reverse();
	}

	/// <summary>
	/// 反转当前序列中元素的顺序
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>返回当前序列的相反顺序的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ReverseObject(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		return source.OfType<object>().Reverse();
	}

	/// <summary>
	/// 获取当前序列投影后的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="R">投影的序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="selection">序列投影方法</param>
	/// <returns>投影后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selection" /> 为空。</exception>
	public static IEnumerable<R> Select<T, R>(IEnumerable<T> source, Func<T, R> selection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selection, "selection");
		return source.Select(selection);
	}

	/// <summary>
	/// 获取当前序列投影后的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="R">投影序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="selection">序列投影方法</param>
	/// <returns>投影后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selection" /> 为空。</exception>
	public static IEnumerable<R> Select<T, R>(IEnumerable<T> source, Func<T, int, R> selection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selection, "selection");
		return source.Select(selection);
	}

	/// <summary>
	/// 获取当前序列投影后的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="R">投影序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="selection">序列投影方法</param>
	/// <returns>投影后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selection" /> 为空。</exception>
	public static IEnumerable<R> Select<T, R>(IEnumerable<T> source, Func<T, long, R> selection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selection, "selection");
		long index = 0L;
		foreach (T item in source)
		{
			yield return selection(item, index++);
		}
	}

	/// <summary>
	/// 将当前序列中的每个元素投影到新的序列中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selector">序列元素投影方法</param>
	/// <returns>投影生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable SelectObject(IEnumerable source, Func<object, object> selector)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selector, "selector");
		return source.OfType<object>().Select(selector);
	}

	/// <summary>
	/// 将当前序列中的每个元素投影到新的序列中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selector">序列元素投影方法</param>
	/// <returns>投影生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable SelectObject(IEnumerable source, Func<object, int, object> selector)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selector, "selector");
		return source.OfType<object>().Select(selector);
	}

	/// <summary>
	/// 通过合并元素的索引将当前序列的每个元素投影到新表中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selection">当前序列元素转换方法</param>
	/// <returns>映射后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素转换方法 <paramref name="selection" /> 为空。</exception>
	public static IEnumerable SelectObject(IEnumerable source, Func<object, long, object> selection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selection, "selection");
		long index = 0L;
		foreach (object item in source)
		{
			yield return selection(item, index++);
		}
	}

	/// <summary>
	/// 将当前序列中每个元素都投影为一个序列，再所有元素投影的序列合并为一个新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="R">投影序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="selection">序列元素投影方法</param>
	/// <returns>当前序列中各个元素的投影序列合并的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selection" /> 为空。</exception>
	public static IEnumerable<R> SelectMany<T, R>(IEnumerable<T> source, Func<T, IEnumerable<R>> selection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selection, "selection");
		return source.SelectMany(selection);
	}

	/// <summary>
	/// 将当前序列中每个元素都投影为一个序列，再所有元素投影的序列合并为一个新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="R">投影序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="selection">序列元素投影方法</param>
	/// <returns>当前序列中各个元素的投影序列合并的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selection" /> 为空。</exception>
	public static IEnumerable<R> SelectMany<T, R>(IEnumerable<T> source, Func<T, int, IEnumerable<R>> selection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selection, "selection");
		return source.SelectMany(selection);
	}

	/// <summary>
	/// 将当前序列中每个元素都投影为一个序列，再所有元素投影的序列合并为一个新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="C">中间序列元素类型</typeparam>
	/// <typeparam name="R">投影序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="collectionSelection">序列元素到中间序列的投影方法</param>
	/// <param name="resultSelection">中间序列元素到结果序列元素的投影方法</param>
	/// <returns>当前序列中各个元素的投影序列合并的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="collectionSelection" /> 为空；或者投影方法 <paramref name="resultSelection" /> 为空。</exception>
	public static IEnumerable<R> SelectMany<T, C, R>(IEnumerable<T> source, Func<T, IEnumerable<C>> collectionSelection, Func<T, C, R> resultSelection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(collectionSelection, "collection selection");
		Guard.AssertNotNull(resultSelection, "result selection");
		return source.SelectMany(collectionSelection, resultSelection);
	}

	/// <summary>
	/// 将当前序列中的每个元素投影到新的序列中，再将全部新序列合并为一个序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selector">序列元素投影方法</param>
	/// <returns>投影生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable SelectManyObject(IEnumerable source, Func<object, IEnumerable> selector)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selector, "selector");
		return source.OfType<object>().SelectMany((object x) => selector(x).OfType<object>());
	}

	/// <summary>
	/// 将当前序列中的每个元素投影到新的序列中，再将全部新序列合并为一个序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selector">序列元素投影方法</param>
	/// <returns>投影生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable SelectManyObject(IEnumerable source, Func<object, int, IEnumerable> selector)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selector, "selector");
		return source.OfType<object>().SelectMany((object x, int i) => selector(x, i).OfType<object>());
	}

	/// <summary>
	/// 递归获取当前序列中元素对象属性值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="selector">属性集合选择器</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>递归的元素序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性集合选择方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable<T> SelectRecursion<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> selector, Func<T, bool> predicate = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(selector, "selector");
		return source.SelectMany((T x) => ObjectHelper.Enumerate(x, selector, predicate));
	}

	/// <summary>
	/// 使用默认的元素比较器比较当前序列和目标序列是否相等
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <returns>如果两个序列长度相同且每个对应位置的元素相等返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的目标序列 <paramref name="target" /> 为空。</exception>
	public static bool SequenceEqual<T>(IEnumerable<T> source, IEnumerable<T> target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.SequenceEqual(target);
	}

	/// <summary>
	/// 使用指定的元素比较器比较当前序列和目标序列是否相等
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">待比较的目标序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>如果两个序列长度相同且每个对应位置的元素相等返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的目标序列 <paramref name="target" /> 为空。</exception>
	public static bool SequenceEqual<T>(IEnumerable<T> source, IEnumerable<T> target, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.SequenceEqual(target, equaliter);
	}

	/// <summary>
	/// 使用指定的元素比较方法比较当前序列和目标序列是否相等
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">待比较的目标序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>如果两个序列长度相同且每个对应位置的元素相等返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的目标序列 <paramref name="target" /> 为空。</exception>
	public static bool SequenceEqual<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.SequenceEqual(target, ConvertHelper.ToComparer(equalition));
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
	public static void Set<K, V>(IDictionary<K, V> dictionary, K key, V value)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		if (dictionary.ContainsKey(key))
		{
			dictionary[key] = value;
			return;
		}
		throw new KeyNotFoundException(string.Format(Literals.MSG_DictionaryKeyNotFound_1, key));
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
	public static V SetOrAdd<K, V>(IDictionary<K, V> dictionary, K key, V value)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
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
	public static void SetOrAdd<K, V>(IDictionary<K, V> dictionary, K key, V value, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		if (dictionary.ContainsKey(key))
		{
			dictionary[key] = (ObjectHelper.IsNull(valueUpdating) ? value : valueUpdating(key, dictionary[key]));
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
	public static V SetOrAdd<K, V>(IDictionary<K, V> dictionary, V value, Func<V, K> keySelection)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		return SetOrAdd(dictionary, keySelection(value), value);
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
	public static void SetOrAdd<K, V>(IDictionary<K, V> dictionary, V value, Func<V, K> keySelection, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		SetOrAdd(dictionary, keySelection(value), value, valueUpdating);
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
	public static V SetOrAdd<K, V, S>(IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		return SetOrAdd(dictionary, keySelection(item), valueSelection(item));
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
	public static void SetOrAdd<K, V, S>(IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		SetOrAdd(dictionary, keySelection(item), valueSelection(item), valueUpdating);
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
	public static V SetOrAdd<K, V>(IDictionary<K, V> dictionary, Tuple<K, V> pair)
	{
		Guard.AssertNotNull(pair, "pair");
		return SetOrAdd(dictionary, pair.Item1, pair.Item2);
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
	public static void SetOrAdd<K, V>(IDictionary<K, V> dictionary, Tuple<K, V> pair, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(pair, "pair");
		SetOrAdd(dictionary, pair.Item1, pair.Item2, valueUpdating);
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
	public static V SetOrAdd<K, V>(IDictionary<K, V> dictionary, KeyValuePair<K, V> pair)
	{
		Guard.AssertNotNull(pair, "pair");
		return SetOrAdd(dictionary, pair.Key, pair.Value);
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
	public static void SetOrAdd<K, V>(IDictionary<K, V> dictionary, KeyValuePair<K, V> pair, Func<K, V, V> valueUpdating)
	{
		Guard.AssertNotNull(pair, "pair");
		SetOrAdd(dictionary, pair.Key, pair.Value, valueUpdating);
	}

	/// <summary>
	/// 返回当前序列的唯一一个元素。如果当前序列不包含任何元素或者包含多于一个元素则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列包含的唯一一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素或者包含多于一个元素。</exception>
	public static T Single<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Single();
	}

	/// <summary>
	/// 返回当前序列中满足指定条件的唯一一个元素，如果当前序列中不包含满足条件的任何元素或者满足条件的元素多于一个则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中满足条件的唯一一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素或者满足指定条件的元素多于一个。</exception>
	public static T Single<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Single(predicate);
	}

	/// <summary>
	/// 返回当前序列的唯一一个元素。如果当前序列不包含任何元素则返回序列元素类型的默认值；如果包含多于一个元素则抛出异常。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列包含的唯一一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列包含多于一个元素。</exception>
	public static T SingleOrDefault<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.SingleOrDefault();
	}

	/// <summary>
	/// 返回当前序列中满足指定条件的唯一一个元素，如果当前序列中不包含满足条件的任何元素则返回序列元素类型的默认值；如果满足条件的元素多于一个则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中满足条件的唯一一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列中满足指定条件的元素多于一个。</exception>
	public static T SingleOrDefault<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		return source.SingleOrDefault(predicate);
	}

	/// <summary>
	/// 跳过当前序列中指定数量的元素，返回剩余元素的子序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">跳过的元素数量</param>
	/// <returns>当前序列中跳过指定数量元素后，剩余元素的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> Skip<T>(IEnumerable<T> source, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, "count");
		return source.Skip(count);
	}

	/// <summary>
	/// 跳过当前序列中指定数量的元素，然后返回剩余的元素。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">跳过的元素数量</param>
	/// <returns>当前序列跳过指定数量元素后剩余的元素序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable SkipObject(IEnumerable source, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int index = 0;
		foreach (object o in source)
		{
			if (index >= count)
			{
				yield return o;
			}
		}
	}

	/// <summary>
	/// 跳过当前序列中满足指定条件的连续的元素，返回剩余元素的子序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中跳过满足指定条件的连续的元素后，剩余元素的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<T> SkipWhile<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.SkipWhile(predicate);
	}

	/// <summary>
	/// 跳过当前序列中满足指定条件的连续的元素，返回剩余元素的子序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中跳过满足指定条件的连续的元素后，剩余元素的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<T> SkipWhile<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.SkipWhile(predicate);
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort(IList list)
	{
		Guard.AssertNotNull(list, "list");
		Sort(list, 0, list.Count, Comparer.Default);
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="comparer">序列元素的排序比较对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort(IList list, IComparer comparer)
	{
		Guard.AssertNotNull(list, "list");
		Sort(list, 0, list.Count, comparer);
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="comparison">序列元素的排序比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort(IList list, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(list, "list");
		Sort(list, 0, list.Count, comparison);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort(IList list, int start, int count)
	{
		Sort(list, start, count, Comparer.Default.Compare);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <param name="comparer">序列元素的排序比较对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort(IList list, int start, int count, IComparer comparer)
	{
		Sort(list, start, count, ObjectHelper.IfNull(comparer, Comparer.Default).Compare);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <param name="comparison">序列元素的排序比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort(IList list, int start, int count, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(start, 0, list.Count - 1, "start");
		Guard.AssertBetween(count, 0, list.Count - start, "count");
		comparison = ObjectHelper.IfNull(comparison, Comparer.Default.Compare);
		QuickSort(list, start, (count > 0) ? (start + count - 1) : start, comparison);
	}

	/// <summary>
	/// QuickSort排序算法
	/// </summary>
	/// <param name="elements">待排序列表</param>
	/// <param name="start">排序区域起始位置</param>
	/// <param name="end">排序区域结束位置</param>
	/// <param name="comparison">元素比较方法</param>
	private static void QuickSort(IList elements, int start, int end, Func<object, object, int> comparison)
	{
		int i = start;
		int j = end;
		object pivot = elements[i + j >> 1];
		while (i <= j)
		{
			for (; comparison(elements[i], pivot) < 0; i++)
			{
			}
			while (comparison(elements[j], pivot) > 0)
			{
				j--;
			}
			if (i <= j)
			{
				object temp = elements[i];
				elements[i] = elements[j];
				elements[j] = temp;
				i++;
				j--;
			}
		}
		if (start < j)
		{
			QuickSort(elements, start, j, comparison);
		}
		if (i < end)
		{
			QuickSort(elements, i, end, comparison);
		}
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="list">当前序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort<T>(IList<T> list)
	{
		Guard.AssertNotNull(list, "list");
		Sort(list, 0, list.Count, Comparer<T>.Default);
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="list">当前序列</param>
	/// <param name="comparer">序列元素的排序比较对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort<T>(IList<T> list, IComparer<T> comparer)
	{
		Guard.AssertNotNull(list, "list");
		Sort(list, 0, list.Count, comparer);
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="list">当前序列</param>
	/// <param name="comparison">序列元素的排序比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort<T>(IList<T> list, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(list, "list");
		Sort(list, 0, list.Count, comparison);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort<T>(IList<T> list, int start, int count)
	{
		Sort(list, start, count, Comparer<T>.Default.Compare);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <param name="comparer">序列元素的排序比较对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort<T>(IList<T> list, int start, int count, IComparer<T> comparer)
	{
		Sort(list, start, count, ObjectHelper.IfNull(comparer, Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <param name="comparison">序列元素的排序比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort<T>(IList<T> list, int start, int count, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(list, "list");
		Guard.AssertIndexRange(start, 0, list.Count - 1, "start");
		Guard.AssertBetween(count, 0, list.Count - start, "count");
		comparison = ObjectHelper.IfNull(comparison, Comparer<T>.Default.Compare);
		QuickSort(list, start, (count > 0) ? (start + count - 1) : start, comparison);
	}

	/// <summary>
	/// QuickSort排序算法
	/// </summary>
	/// <typeparam name="T">排序列表元素类型</typeparam>
	/// <param name="elements">待排序列表</param>
	/// <param name="start">排序区域起始位置</param>
	/// <param name="end">排序区域结束位置</param>
	/// <param name="comparison">元素比较方法</param>
	private static void QuickSort<T>(IList<T> elements, int start, int end, Func<T, T, int> comparison)
	{
		int i = start;
		int j = end;
		T pivot = elements[i + j >> 1];
		while (i <= j)
		{
			for (; comparison(elements[i], pivot) < 0; i++)
			{
			}
			while (comparison(elements[j], pivot) > 0)
			{
				j--;
			}
			if (i <= j)
			{
				T temp = elements[i];
				elements[i] = elements[j];
				elements[j] = temp;
				i++;
				j--;
			}
		}
		if (start < j)
		{
			QuickSort(elements, start, j, comparison);
		}
		if (i < end)
		{
			QuickSort(elements, i, end, comparison);
		}
	}

	/// <summary>
	/// 从当前序列开始处返回指定数量元素组成的子序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>获取的指定数量的元素的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> Take<T>(IEnumerable<T> source, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return source.Take(count);
	}

	/// <summary>
	/// 从当前序列的开头返回指定数量的连续元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">返回的元素数量</param>
	/// <returns>从当前序列开头返回的指定数量元素的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable TakeObject(IEnumerable source, int count)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		foreach (object o in source)
		{
			if (count-- > 0)
			{
				yield return o;
				continue;
			}
			break;
		}
	}

	/// <summary>
	/// 从当前序列起始位置返回满足指定条件的连续元素组成的子序列。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>获取的指定数量的元素的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<T> TakeWhile<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.TakeWhile(predicate);
	}

	/// <summary>
	/// 从当前序列起始位置返回满足指定条件的连续元素组成的子序列。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>获取的指定数量的元素的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<T> TakeWhile<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.TakeWhile(predicate);
	}

	/// <summary>
	/// 将当前序列转换为数组
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T[] ToArray<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.ToArray();
	}

	/// <summary>
	/// 将当前序列中满足指定条件的元素转换为数组
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件为空。</exception>
	public static T[] ToArray<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Where(predicate).ToArray();
	}

	/// <summary>
	/// 将当前序列中满足指定条件的元素转换为数组
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件为空。</exception>
	public static T[] ToArray<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Where(predicate).ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T[] ToArray<S, T>(IEnumerable<S> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Select((S x) => ObjectHelper.As<T>(x)).ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<S, T>(IEnumerable<S> source, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		return source.Select(evaluation).ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<S, T>(IEnumerable<S> source, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		return source.Select(evaluation).ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<S, T>(IEnumerable<S> source, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToArray(source, (S x, int i) => predicate(x), (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<S, T>(IEnumerable<S> source, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		List<T> list = new List<T>();
		int index = 0;
		foreach (S item in source)
		{
			if (predicate(item, index))
			{
				list.Add(evaluation(item, index));
			}
			index++;
		}
		return list.ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static ArrayList ToArrayList(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		ArrayList array = new ArrayList();
		foreach (object item in source)
		{
			array.Add(item);
		}
		return array;
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static ArrayList ToArrayList(IEnumerable source, Func<object, object> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToArrayList(source, (object x, int i) => true, (object x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static ArrayList ToArrayList(IEnumerable source, Func<object, int, object> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToArrayList(source, (object x, int i) => true, evaluation);
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static ArrayList ToArrayList(IEnumerable source, Func<object, bool> predicate, Func<object, object> evaluation)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToArrayList(source, (object x, int i) => predicate(x), (object x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前序列转换为指定类型的列表
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static ArrayList ToArrayList(IEnumerable source, Func<object, int, bool> predicate, Func<object, int, object> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		ArrayList list = new ArrayList();
		int index = 0;
		foreach (object item in source)
		{
			if (predicate(item, index))
			{
				list.Add(evaluation(item, index));
			}
			index++;
		}
		return list;
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static DataTable ToDataTable(IEnumerable source)
	{
		return ToDataTable(source);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static DataTable ToDataTable(IEnumerable source, BindingFlags flags)
	{
		return ToDataTable(source, flags);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable(IEnumerable source, params string[] propertyNames)
	{
		return ToDataTable(source, propertyNames);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable(IEnumerable source, string[] propertyNames, bool ignoreCase = false)
	{
		return ToDataTable(source, propertyNames, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable(IEnumerable source, string[] propertyNames, BindingFlags flags, bool ignoreCase = false)
	{
		return ToDataTable(source, propertyNames, flags, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="mappings">序列元素属性到数据列的映射，序列元素属性名称支持属性路径，未设置序列元素属性则忽略</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的序列元素属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable(IEnumerable source, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return ToDataTable(source, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="mappings">序列元素属性到数据列的映射，序列元素属性名称支持属性路径，未设置序列元素属性则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的序列元素属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable(IEnumerable source, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(mappings, "mappings");
		DataTable table = null;
		foreach (object item in source)
		{
			table = ObjectHelper.ToDataTable(item, mappings, flags, onlyMapping, ignoreCase, table);
		}
		return table;
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static DataTable ToDataTable<T>(IEnumerable<T> source)
	{
		return ToDataTable(source);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static DataTable ToDataTable<T>(IEnumerable<T> source, BindingFlags flags)
	{
		return ToDataTable(source, flags);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable<T>(IEnumerable<T> source, params string[] propertyNames)
	{
		return ToDataTable(source, propertyNames);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable<T>(IEnumerable<T> source, string[] propertyNames, bool ignoreCase = false)
	{
		return ToDataTable(source, propertyNames, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable<T>(IEnumerable<T> source, string[] propertyNames, BindingFlags flags, bool ignoreCase = false)
	{
		return ToDataTable(source, propertyNames, flags, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="mappings">序列元素属性到数据列的映射，序列元素属性名称支持属性路径，未设置序列元素属性则忽略</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的序列元素属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable<T>(IEnumerable<T> source, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return ToDataTable(source, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="mappings">序列元素属性到数据列的映射，序列元素属性名称支持属性路径，未设置序列元素属性则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的序列元素属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable<T>(IEnumerable<T> source, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(mappings, "mappings");
		DataTable table = null;
		foreach (T item in source)
		{
			table = ObjectHelper.ToDataTable(item, mappings, flags, onlyMapping, ignoreCase, table);
		}
		return table;
	}

	/// <summary>
	/// 使用指定的键选择方法，从当前序列创建字典
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="K">创建的字典的键</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keySelection">字典的键选择方法</param>
	/// <returns>从当前序列创建的字典</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者字典键选择方法 <paramref name="keySelection" /> 为空。</exception>
	public static Dictionary<K, T> ToDictionary<T, K>(IEnumerable<T> source, Func<T, K> keySelection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		return source.ToDictionary(keySelection);
	}

	/// <summary>
	/// 使用指定的键选择方法，从当前序列创建字典
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="K">创建的字典的键</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keySelection">字典的键选择方法</param>
	/// <param name="equaliter">创建字典时使用的键比较器</param>
	/// <returns>从当前序列创建的字典</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者字典键选择方法 <paramref name="keySelection" /> 为空。</exception>
	public static Dictionary<K, T> ToDictionary<T, K>(IEnumerable<T> source, Func<T, K> keySelection, IEqualityComparer<K> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		return source.ToDictionary(keySelection, equaliter);
	}

	/// <summary>
	/// 使用指定的键选择方法和值选择方法，从当前序列中创建字典
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="K">创建的字典键的类型</typeparam>
	/// <typeparam name="V">创建的字典值的类型</typeparam>
	/// <param name="source">当前序列元素</param>
	/// <param name="keySelection">创建字典键的选择方法</param>
	/// <param name="valueSelection">创建字典值的选择方法</param>
	/// <returns>从当前序列创建的字典</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者字典键选择方法 <paramref name="keySelection" />；或者字典值选择方法 <paramref name="valueSelection" />。</exception>
	public static Dictionary<K, V> ToDictionary<T, K, V>(IEnumerable<T> source, Func<T, K> keySelection, Func<T, V> valueSelection)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		return source.ToDictionary(keySelection, valueSelection);
	}

	/// <summary>
	/// 使用指定的键选择方法和值选择方法，从当前序列中创建字典
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="K">创建的字典键的类型</typeparam>
	/// <typeparam name="V">创建的字典值的类型</typeparam>
	/// <param name="source">当前序列元素</param>
	/// <param name="keySelection">创建字典键的选择方法</param>
	/// <param name="valueSelection">创建字典值的选择方法</param>
	/// <param name="equaliter">创建字典时使用的键比较器</param>
	/// <returns>从当前序列创建的字典</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者字典键选择方法 <paramref name="keySelection" />；或者字典值选择方法 <paramref name="equaliter" />。</exception>
	public static Dictionary<K, V> ToDictionary<T, K, V>(IEnumerable<T> source, Func<T, K> keySelection, Func<T, V> valueSelection, IEqualityComparer<K> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		return source.ToDictionary(keySelection, valueSelection, equaliter);
	}

	/// <summary>
	/// 将当前序列转换为列表
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static List<T> ToList<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.ToList();
	}

	/// <summary>
	/// 将当前序列中符合指定条件的元素转换为列表
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列符合指定条件的元素转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static List<T> ToList<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Where(predicate).ToList();
	}

	/// <summary>
	/// 将当前序列中符合指定条件的元素转换为列表
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列符合指定条件的元素转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static List<T> ToList<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Where(predicate).ToList();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static List<T> ToList<S, T>(IEnumerable<S> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Select((S x) => ObjectHelper.As<T>(x)).ToList();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<S, T>(IEnumerable<S> source, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		return source.Select(evaluation).ToList();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<S, T>(IEnumerable<S> source, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		return source.Select(evaluation).ToList();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<S, T>(IEnumerable<S> source, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(source, (S x, int i) => predicate(x), (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前序列转换为指定类型的列表
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<S, T>(IEnumerable<S> source, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		List<T> list = new List<T>();
		int index = 0;
		foreach (S item in source)
		{
			if (predicate(item, index))
			{
				list.Add(evaluation(item, index));
			}
			index++;
		}
		return list;
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static object[] ToObjectArray(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		return source.OfType<object>().ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素变换方法</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者变化方法 <paramref name="evaluation" /> 为空。</exception>
	public static object[] ToObjectArray(IEnumerable source, Func<object, object> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		return ToArray(source.OfType<object>(), evaluation);
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素变换方法</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者变化方法 <paramref name="evaluation" /> 为空。</exception>
	public static object[] ToObjectArray(IEnumerable source, Func<object, int, object> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		return ToArray(source.OfType<object>(), evaluation);
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">转换的当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluation">序列元素变换方法</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者变化方法 <paramref name="evaluation" /> 为空。</exception>
	public static object[] ToObjectArray(IEnumerable source, Func<object, bool> predicate, Func<object, object> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		return ToArray(source.OfType<object>(), predicate, evaluation);
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">转换的当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluation">序列元素变换方法</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者变化方法 <paramref name="evaluation" /> 为空。</exception>
	public static object[] ToObjectArray(IEnumerable source, Func<object, int, bool> predicate, Func<object, int, object> evaluation)
	{
		Guard.AssertNotNull(source, "source");
		return ToArray(source.OfType<object>(), predicate, evaluation);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	public static HashSet<T> ToSet<T>(IEnumerable<T> source, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(source);
		return new HashSet<T>(source, equaliter);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="filling">元素填充方法，当元素转换失败则调用该填充方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；集填充方法 <paramref name="filling" /> 为空。</exception>
	public static HashSet<T> ToSet<T>(IEnumerable<T> source, Action<T, ISet<T>> filling, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(filling, "filling");
		return ToSet(source, delegate(T x, int i, ISet<T> s)
		{
			filling(x, s);
		}, equaliter);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="filling">元素填充方法，当元素转换失败则调用该填充方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；集填充方法 <paramref name="filling" /> 为空。</exception>
	public static HashSet<T> ToSet<T>(IEnumerable<T> source, Action<T, int, ISet<T>> filling, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(filling, "filling");
		HashSet<T> set = new HashSet<T>(equaliter);
		int index = 0;
		foreach (T item in source)
		{
			if (!set.Add(item))
			{
				filling(item, index++, set);
			}
		}
		return set;
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标集的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static HashSet<T> ToSet<S, T>(IEnumerable<S> source, Func<S, T> evaluation, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		return new HashSet<T>(source.Select(evaluation), equaliter);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标集的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素转换方法 <paramref name="evaluation" /> 为空。</exception>
	public static HashSet<T> ToSet<S, T>(IEnumerable<S> source, Func<S, int, T> evaluation, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(evaluation, "evaluation");
		return new HashSet<T>(source.Select(evaluation), equaliter);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标集的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluation">序列元素转换方法</param>
	/// <param name="filling">元素填充方法，当元素转换失败则调用该填充方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素转换方法 <paramref name="evaluation" /> 为空；集填充方法 <paramref name="filling" /> 为空。</exception>
	public static HashSet<T> ToSet<S, T>(IEnumerable<S> source, Func<S, T> evaluation, Action<S, ISet<T>> filling, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertNotNull(filling, "filling");
		return ToSet(source, (S x, int i) => evaluation(x), delegate(S x, int i, ISet<T> s)
		{
			filling(x, s);
		}, equaliter);
	}

	/// <summary>
	/// 当当前序列转换为集
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标集的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <param name="filling">元素填充方法，当元素转换失败则调用该填充方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素转换方法 <paramref name="conversion" /> 为空；集填充方法 <paramref name="filling" /> 为空。</exception>
	public static HashSet<T> ToSet<S, T>(IEnumerable<S> source, Func<S, int, T> conversion, Action<S, int, ISet<T>> filling, IEqualityComparer<T> equaliter = null)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(conversion, "conversion");
		Guard.AssertNotNull(filling, "filling");
		HashSet<T> set = new HashSet<T>(equaliter);
		int index = 0;
		foreach (S item in source)
		{
			if (ObjectHelper.IsNull(ObjectHelper.Try(item, (S x) => conversion(x, index), out var value)))
			{
				if (!set.Add(value))
				{
					filling(item, index, set);
				}
			}
			else
			{
				filling(item, index, set);
			}
			index++;
		}
		return set;
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
	public static bool TryAdd<K, V>(IDictionary<K, V> dictionary, K key, V value)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
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
	public static bool TryAdd<K, V>(IDictionary<K, V> dictionary, V value, Func<V, K> keySelection)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		return TryAdd(dictionary, keySelection(value), value);
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
	public static bool TryAdd<K, V, S>(IDictionary<K, V> dictionary, S item, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		return TryAdd(dictionary, keySelection(item), valueSelection(item));
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
	public static bool TryAdd<K, V>(IDictionary<K, V> dictionary, Tuple<K, V> pair)
	{
		Guard.AssertNotNull(pair, "pair");
		return TryAdd(dictionary, pair.Item1, pair.Item2);
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
	public static bool TryAdd<K, V>(IDictionary<K, V> dictionary, KeyValuePair<K, V> pair)
	{
		Guard.AssertNotNull(pair, "pair");
		return TryAdd(dictionary, pair.Key, pair.Value);
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
	public static int TryAddRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<K> keys, IEnumerable<V> values)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(values, "values");
		IEnumerator<K> keyEnumer = null;
		IEnumerator<V> valueEnumer = null;
		int count = 0;
		try
		{
			keyEnumer = keys.GetEnumerator();
			valueEnumer = values.GetEnumerator();
			while (keyEnumer.MoveNext() && valueEnumer.MoveNext())
			{
				if (TryAdd(dictionary, keyEnumer.Current, valueEnumer.Current))
				{
					count++;
				}
			}
		}
		finally
		{
			if (ObjectHelper.IsNotNull(keyEnumer))
			{
				keyEnumer.Dispose();
			}
			if (ObjectHelper.IsNotNull(valueEnumer))
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
	public static int TryAddRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<V> values, Func<V, K> keySelection)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(values, "values");
		Guard.AssertNotNull(keySelection, "key selection");
		return TryAddRange(dictionary, values.Select((V v) => keySelection(v)), values);
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
	public static int TryAddRange<K, V, S>(IDictionary<K, V> dictionary, IEnumerable<S> items, Func<S, K> keySelection, Func<S, V> valueSelection)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(items, "values");
		Guard.AssertNotNull(keySelection, "key selection");
		Guard.AssertNotNull(valueSelection, "value selection");
		return TryAddRange(dictionary, items.Select((S x) => keySelection(x)), items.Select((S x) => valueSelection(x)));
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
	public static int TryAddRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<Tuple<K, V>> pairs)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pairs, "pairs");
		return TryAddRange(dictionary, pairs.Select((Tuple<K, V> p) => p.Item1), pairs.Select((Tuple<K, V> p) => p.Item2));
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
	public static int TryAddRange<K, V>(IDictionary<K, V> dictionary, IEnumerable<KeyValuePair<K, V>> pairs)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		Guard.AssertNotNull(pairs, "pairs");
		return TryAddRange(dictionary, pairs.Select((KeyValuePair<K, V> p) => p.Key), pairs.Select((KeyValuePair<K, V> p) => p.Value));
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
	public static bool TryGet<K, V>(IDictionary<K, V> dictionary, K key, out V value)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
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
	public static bool TrySet<K, V>(IDictionary<K, V> dictionary, K key, V value)
	{
		Guard.AssertNotNull(dictionary, "dictionary");
		if (dictionary.ContainsKey(key))
		{
			dictionary[key] = value;
			return true;
		}
		return false;
	}

	/// <summary>
	/// 使用默认的元素比较器返回当前序列与目标序列的并集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">目标序列</param>
	/// <returns>当前序列与目标序列的并集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static IEnumerable<T> Union<T>(IEnumerable<T> source, IEnumerable<T> target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Union(target);
	}

	/// <summary>
	/// 使用指定的元素比较器返回当前序列与目标序列的并集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">目标序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>当前序列与目标序列的并集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static IEnumerable<T> Union<T>(IEnumerable<T> source, IEnumerable<T> target, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Union(target, equaliter);
	}

	/// <summary>
	/// 合并当前序列和目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable<T> Union<T>(IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.Union(target, ConvertHelper.ToComparer(equalition));
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列数组</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列数组 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Union<T>(IEnumerable<T> source, params IEnumerable<T>[] targets)
	{
		return Union(source, targets, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列集合</param>
	/// <param name="equaliter">序列元素相等比较器</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列集合 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Union<T>(IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(targets, "targets");
		equaliter = ObjectHelper.IfNull(equaliter, EqualityComparer<T>.Default);
		foreach (IEnumerable<T> target in targets)
		{
			if (ObjectHelper.IsNotNull(target))
			{
				source = source.Union(target, equaliter);
			}
		}
		return source;
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列集合</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列集合 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Union<T>(IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets, Func<T, T, bool> equalition)
	{
		return Union(source, targets, ObjectHelper.IsNull(equalition) ? null : ConvertHelper.ToComparer(equalition));
	}

	/// <summary>
	/// 合并当前序列和目标序列，返回合并后的新序列；合并后的新序列中不包含重复的项目
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者合并的目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable UnionObject(IEnumerable source, IEnumerable target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return source.OfType<object>().Union(target.OfType<object>());
	}

	/// <summary>
	/// 合并当前序列和目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable UnionObject(IEnumerable source, IEnumerable target, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		return Union(source.OfType<object>(), target.OfType<object>(), ConvertHelper.ToComparer<object>(ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals)));
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列数组</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列数组 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable UnionObject(IEnumerable source, params IEnumerable[] targets)
	{
		return Union(source.OfType<object>(), (IEnumerable<IEnumerable>)targets, ObjectHelper.ObjectEquals);
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列集合</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列集合 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable UnionObject(IEnumerable source, IEnumerable<IEnumerable> targets, Func<object, object, bool> equalition)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(targets, "targets");
		IEqualityComparer<object> equaliter = ConvertHelper.ToComparer<object>(ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals));
		IEnumerable<object> result = source.OfType<object>();
		foreach (IEnumerable target in targets)
		{
			if (ObjectHelper.IsNotNull(target))
			{
				result = result.Union(target.OfType<object>(), equaliter);
			}
		}
		return source;
	}

	/// <summary>
	/// 返回当前序列中满足指定条件的元素的序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中满足指定条件的元素的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<T> Where<T>(IEnumerable<T> source, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Where(predicate);
	}

	/// <summary>
	/// 返回当前序列中满足指定条件的元素的序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列中满足指定条件的元素的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<T> Where<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		return source.Where(predicate);
	}

	/// <summary>
	/// 对当前序列进行筛选，返回满足条件的元素组成的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列满足条件组成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<T> Where<T>(IEnumerable<T> source, Func<T, long, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		long index = 0L;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 获取当前序列中所有不为空的元素组成的新序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> WhereNotNull<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Where((T x) => ObjectHelper.IsNotNull(x));
	}

	/// <summary>
	/// 获取当前序列中所有不为空且不为 <see cref="T:System.DBNull" /> 的元素组成的新序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> WhereNotNullAndDBNull<T>(IEnumerable<T> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Where((T x) => ObjectHelper.IsNotNullAndDBNull(x));
	}

	/// <summary>
	/// 获取当前序列中所有不为空且不为其类型默认值的元素组成的新序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="defaultType">期望的元素默认值类型</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> WhereNotNullAndDefault<T>(IEnumerable<T> source, Type defaultType = null)
	{
		Guard.AssertNotNull(source, "source");
		return source.Where((T x) => ObjectHelper.IsNotNullAndDefault(x, defaultType));
	}

	/// <summary>
	/// 从当前序列中筛选满足指定谓词条件的元素，返回这些元素组成的新元素。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选谓词</param>
	/// <returns>满足条件组成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选谓词条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable WhereObject(IEnumerable source, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		foreach (object item in source)
		{
			if (predicate(item))
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 从当前序列中筛选满足指定谓词条件的元素，返回这些元素组成的新元素。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选谓词</param>
	/// <returns>满足条件组成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选谓词条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable WhereObject(IEnumerable source, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		int index = 0;
		foreach (object item in source)
		{
			if (predicate(item, index++))
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 对当前序列进行筛选，返回满足条件的元素组成的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列满足条件组成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable WhereObject(IEnumerable source, Func<object, long, bool> predicate)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(predicate, "predicate");
		long index = 0L;
		foreach (object item in source)
		{
			if (predicate(item, index++))
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 获取当前序列中所有不为空的元素组成的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable WhereObjectNotNull(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		return WhereObject(source, (object x) => ObjectHelper.IsNotNull(x));
	}

	/// <summary>
	/// 获取当前序列中所有不为空且不为 <see cref="T:System.DBNull" /> 的元素组成的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable WhereObjectNotNullAndDBNull(IEnumerable source)
	{
		Guard.AssertNotNull(source, "source");
		return WhereObject(source, (object x) => ObjectHelper.IsNotNullAndDBNull(x));
	}

	/// <summary>
	/// 获取当前序列中所有不为空且不为其类型默认值的元素组成的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="defaultType">期望的元素默认值类型</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable WhereObjectNotNullOrDefault(IEnumerable source, Type defaultType = null)
	{
		Guard.AssertNotNull(source, "source");
		return WhereObject(source, (object x) => ObjectHelper.IsNotNullAndDefault(x, defaultType));
	}
}
