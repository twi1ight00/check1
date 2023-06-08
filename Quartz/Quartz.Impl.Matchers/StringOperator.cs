using System;

namespace Quartz.Impl.Matchers;

/// <summary>
/// Operators available for comparing string values.
/// </summary>
[Serializable]
public abstract class StringOperator : IEquatable<StringOperator>
{
	[Serializable]
	private class EqualityOperator : StringOperator
	{
		public override bool Evaluate(string value, string compareTo)
		{
			return value.Equals(compareTo);
		}
	}

	[Serializable]
	private class StartsWithOperator : StringOperator
	{
		public override bool Evaluate(string value, string compareTo)
		{
			return value.StartsWith(compareTo);
		}
	}

	[Serializable]
	private class EndsWithOperator : StringOperator
	{
		public override bool Evaluate(string value, string compareTo)
		{
			return value.EndsWith(compareTo);
		}
	}

	[Serializable]
	private class ContainsOperator : StringOperator
	{
		public override bool Evaluate(string value, string compareTo)
		{
			return value.Contains(compareTo);
		}
	}

	public static readonly StringOperator Equality = new EqualityOperator();

	public static readonly StringOperator StartsWith = new StartsWithOperator();

	public static readonly StringOperator EndsWith = new EndsWithOperator();

	public static readonly StringOperator Contains = new ContainsOperator();

	public abstract bool Evaluate(string value, string compareTo);

	public override bool Equals(object obj)
	{
		return Equals(obj as StringOperator);
	}

	public bool Equals(StringOperator other)
	{
		if (other == null)
		{
			return false;
		}
		return GetType().Equals(other.GetType());
	}

	public override int GetHashCode()
	{
		return GetType().GetHashCode();
	}
}
