using System;
using System.Runtime.InteropServices;
using System.Text;

namespace C5;

[Serializable]
internal struct KeyValuePair<K, V> : IEquatable<KeyValuePair<K, V>>, IShowable, IFormattable
{
	[ComVisible(true)]
	public K Key;

	[ComVisible(true)]
	public V Value;

	[ComVisible(true)]
	public KeyValuePair(K key, V value)
	{
		Key = key;
		Value = value;
	}

	[ComVisible(true)]
	public KeyValuePair(K key)
	{
		Key = key;
		Value = default(V);
	}

	[Tested]
	[ComVisible(true)]
	public override string ToString()
	{
		return string.Concat("(", Key, ", ", Value, ")");
	}

	[Tested]
	[ComVisible(true)]
	public override bool Equals(object obj)
	{
		if (!(obj is KeyValuePair<K, V> other))
		{
			return false;
		}
		return Equals(other);
	}

	[Tested]
	[ComVisible(true)]
	public override int GetHashCode()
	{
		return EqualityComparer<K>.Default.GetHashCode(Key) + 13984681 * EqualityComparer<V>.Default.GetHashCode(Value);
	}

	[ComVisible(true)]
	public bool Equals(KeyValuePair<K, V> other)
	{
		if (EqualityComparer<K>.Default.Equals(Key, other.Key))
		{
			return EqualityComparer<V>.Default.Equals(Value, other.Value);
		}
		return false;
	}

	[ComVisible(true)]
	public static bool operator ==(KeyValuePair<K, V> pair1, KeyValuePair<K, V> pair2)
	{
		return pair1.Equals(pair2);
	}

	[ComVisible(true)]
	public static bool operator !=(KeyValuePair<K, V> pair1, KeyValuePair<K, V> pair2)
	{
		return !pair1.Equals(pair2);
	}

	[ComVisible(true)]
	public bool Show(StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
	{
		if (rest < 0)
		{
			return false;
		}
		if (!Showing.Show(Key, stringbuilder, ref rest, formatProvider))
		{
			return false;
		}
		stringbuilder.Append(" => ");
		rest -= 4;
		if (!Showing.Show(Value, stringbuilder, ref rest, formatProvider))
		{
			return false;
		}
		return rest >= 0;
	}

	[ComVisible(true)]
	public string ToString(string format, IFormatProvider formatProvider)
	{
		return Showing.ShowString(this, format, formatProvider);
	}
}
