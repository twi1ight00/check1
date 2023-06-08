using System;
using Quartz.Util;

namespace Quartz.Impl.Matchers;

/// <summary>
/// Matches on group (ignores name) property of Keys.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class GroupMatcher<TKey> : StringMatcher<TKey> where TKey : Key<TKey>
{
	protected GroupMatcher(string compareTo, StringOperator compareWith)
		: base(compareTo, compareWith)
	{
	}

	/// <summary>
	/// Create a GroupMatcher that matches groups equaling the given string.
	/// </summary>
	/// <param name="compareTo"></param>
	/// <returns></returns>
	public static GroupMatcher<TKey> GroupEquals(string compareTo)
	{
		return new GroupMatcher<TKey>(compareTo, StringOperator.Equality);
	}

	/// <summary>
	/// Create a GroupMatcher that matches groups starting with the given string.
	/// </summary>
	/// <param name="compareTo"></param>
	/// <returns></returns>
	public static GroupMatcher<TKey> GroupStartsWith(string compareTo)
	{
		return new GroupMatcher<TKey>(compareTo, StringOperator.StartsWith);
	}

	/// <summary>
	/// Create a GroupMatcher that matches groups ending with the given string.
	/// </summary>
	/// <param name="compareTo"></param>
	/// <returns></returns>
	public static GroupMatcher<TKey> GroupEndsWith(string compareTo)
	{
		return new GroupMatcher<TKey>(compareTo, StringOperator.EndsWith);
	}

	/// <summary>
	/// Create a GroupMatcher that matches groups containing the given string.
	/// </summary>
	/// <param name="compareTo"></param>
	/// <returns></returns>
	public static GroupMatcher<TKey> GroupContains(string compareTo)
	{
		return new GroupMatcher<TKey>(compareTo, StringOperator.Contains);
	}

	protected override string GetValue(TKey key)
	{
		return key.Group;
	}
}
