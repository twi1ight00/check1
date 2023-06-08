using System;
using Quartz.Util;

namespace Quartz.Impl.Matchers;

/// <summary>
/// An abstract base class for some types of matchers.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public abstract class StringMatcher<TKey> : IMatcher<TKey> where TKey : Key<TKey>
{
	private readonly string compareTo;

	private readonly StringOperator compareWith;

	public string CompareToValue => compareTo;

	public StringOperator CompareWithOperator => compareWith;

	protected StringMatcher(string compareTo, StringOperator compareWith)
	{
		if (compareTo == null)
		{
			throw new ArgumentNullException("compareTo", "CompareTo value cannot be null!");
		}
		this.compareTo = compareTo;
		this.compareWith = compareWith;
	}

	protected abstract string GetValue(TKey key);

	public bool IsMatch(TKey key)
	{
		return compareWith.Evaluate(GetValue(key), compareTo);
	}

	public override int GetHashCode()
	{
		int result = 1;
		result = 31 * result + ((compareTo != null) ? compareTo.GetHashCode() : 0);
		return 31 * result + compareWith.GetHashCode();
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
		StringMatcher<TKey> other = (StringMatcher<TKey>)obj;
		if (compareTo == null)
		{
			if (other.compareTo != null)
			{
				return false;
			}
		}
		else if (!compareTo.Equals(other.compareTo))
		{
			return false;
		}
		if (!compareWith.Equals(other.compareWith))
		{
			return false;
		}
		return true;
	}
}
