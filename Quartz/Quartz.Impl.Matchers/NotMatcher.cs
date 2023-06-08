using System;
using Quartz.Util;

namespace Quartz.Impl.Matchers;

/// <summary>
/// Matches using an NOT operator on another Matcher. 
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class NotMatcher<TKey> : IMatcher<TKey> where TKey : Key<TKey>
{
	private readonly IMatcher<TKey> operand;

	public IMatcher<TKey> Operand => operand;

	protected NotMatcher(IMatcher<TKey> operand)
	{
		if (operand == null)
		{
			throw new ArgumentNullException("operand", "Non-null operand required!");
		}
		this.operand = operand;
	}

	/// <summary>
	/// Create a NotMatcher that reverses the result of the given matcher.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="operand"></param>
	/// <returns></returns>
	public static NotMatcher<T> Not<T>(IMatcher<T> operand) where T : Key<T>
	{
		return new NotMatcher<T>(operand);
	}

	public bool IsMatch(TKey key)
	{
		return !operand.IsMatch(key);
	}

	public override int GetHashCode()
	{
		int result = 1;
		return 31 * result + ((operand != null) ? operand.GetHashCode() : 0);
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
		NotMatcher<TKey> other = (NotMatcher<TKey>)obj;
		if (operand == null)
		{
			if (other.operand != null)
			{
				return false;
			}
		}
		else if (!operand.Equals(other.operand))
		{
			return false;
		}
		return true;
	}
}
