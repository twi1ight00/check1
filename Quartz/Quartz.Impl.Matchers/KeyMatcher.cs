using System;
using Quartz.Util;

namespace Quartz.Impl.Matchers;

/// <summary>
/// Matches on the complete key being equal (both name and group). 
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class KeyMatcher<TKey> : IMatcher<TKey> where TKey : Key<TKey>
{
	private readonly TKey compareTo;

	public TKey CompareToValue => compareTo;

	protected KeyMatcher(TKey compareTo)
	{
		this.compareTo = compareTo;
	}

	/// <summary>
	/// Create a KeyMatcher that matches Keys that equal the given key. 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="compareTo"></param>
	/// <returns></returns>
	public static KeyMatcher<T> KeyEquals<T>(T compareTo) where T : Key<T>
	{
		return new KeyMatcher<T>(compareTo);
	}

	public bool IsMatch(TKey key)
	{
		TKey val = compareTo;
		return val.Equals(key);
	}

	public override int GetHashCode()
	{
		int result = 1;
		int num = 31 * result;
		int num2;
		if (compareTo != null)
		{
			TKey val = compareTo;
			num2 = val.GetHashCode();
		}
		else
		{
			num2 = 0;
		}
		return num + num2;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (GetType() != obj.GetType())
		{
			return false;
		}
		KeyMatcher<TKey> other = (KeyMatcher<TKey>)obj;
		if (compareTo == null)
		{
			if (other.compareTo != null)
			{
				return false;
			}
		}
		else
		{
			TKey val = compareTo;
			if (!val.Equals(other.compareTo))
			{
				return false;
			}
		}
		return true;
	}
}
