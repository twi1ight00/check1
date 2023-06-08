using System;
using Quartz.Util;

namespace Quartz.Impl.Matchers;

/// <summary>
/// Matches using an OR operator on two Matcher operands. 
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class OrMatcher<TKey> : IMatcher<TKey> where TKey : Key<TKey>
{
	private readonly IMatcher<TKey> leftOperand;

	private readonly IMatcher<TKey> rightOperand;

	public IMatcher<TKey> LeftOperand => leftOperand;

	public IMatcher<TKey> RightOperand => rightOperand;

	protected OrMatcher(IMatcher<TKey> leftOperand, IMatcher<TKey> rightOperand)
	{
		if (leftOperand == null || rightOperand == null)
		{
			throw new ArgumentException("Two non-null operands required!");
		}
		this.leftOperand = leftOperand;
		this.rightOperand = rightOperand;
	}

	/// <summary>
	/// Create an OrMatcher that depends upon the result of at least one of the given matchers.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="leftOperand"></param>
	/// <param name="rightOperand"></param>
	/// <returns></returns>
	public static OrMatcher<T> Or<T>(IMatcher<T> leftOperand, IMatcher<T> rightOperand) where T : Key<T>
	{
		return new OrMatcher<T>(leftOperand, rightOperand);
	}

	public bool IsMatch(TKey key)
	{
		if (!leftOperand.IsMatch(key))
		{
			return rightOperand.IsMatch(key);
		}
		return true;
	}

	public override int GetHashCode()
	{
		int result = 1;
		result = 31 * result + ((leftOperand != null) ? leftOperand.GetHashCode() : 0);
		return 31 * result + ((rightOperand != null) ? rightOperand.GetHashCode() : 0);
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
		OrMatcher<TKey> other = (OrMatcher<TKey>)obj;
		if (leftOperand == null)
		{
			if (other.leftOperand != null)
			{
				return false;
			}
		}
		else if (!leftOperand.Equals(other.leftOperand))
		{
			return false;
		}
		if (rightOperand == null)
		{
			if (other.rightOperand != null)
			{
				return false;
			}
		}
		else if (!rightOperand.Equals(other.rightOperand))
		{
			return false;
		}
		return true;
	}
}
