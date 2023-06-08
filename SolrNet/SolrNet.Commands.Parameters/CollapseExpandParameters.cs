using System;

namespace SolrNet.Commands.Parameters;

/// <summary>
/// Parameters for CollapsingQParserPlugin / ExpandComponent
/// </summary>
public class CollapseExpandParameters
{
	public abstract class MinOrMax
	{
		public class Min : MinOrMax
		{
			public Min(string field)
				: base(field)
			{
			}

			public override T Switch<T>(Func<Min, T> min, Func<Max, T> max)
			{
				return min(this);
			}
		}

		public class Max : MinOrMax
		{
			public Max(string field)
				: base(field)
			{
			}

			public override T Switch<T>(Func<Min, T> min, Func<Max, T> max)
			{
				return max(this);
			}
		}

		private readonly string field;

		public string Field => field;

		private MinOrMax(string field)
		{
			this.field = field;
		}

		public abstract T Switch<T>(Func<Min, T> min, Func<Max, T> max);
	}

	/// <summary>
	/// Determines how to treat nulls while collapsing
	/// </summary>
	public class NullPolicyType : IEquatable<NullPolicyType>
	{
		private readonly string policy;

		/// <summary>
		/// Removes documents with a null value in the collapse field. This is the default.
		/// </summary>
		public static readonly NullPolicyType Ignore = new NullPolicyType("ignore");

		/// <summary>
		/// Treats each document with a null value in the collapse field as a separate group.
		/// </summary>
		public static readonly NullPolicyType Expand = new NullPolicyType("expand");

		/// <summary>
		/// Collapses all documents with a null value into a single group using either highest score, or minimum/maximum.
		/// </summary>
		public static readonly NullPolicyType Collapse = new NullPolicyType("collapse");

		/// <summary>
		/// Determines how to treat nulls while collapsing
		/// </summary>
		public string Policy => policy;

		private NullPolicyType(string policy)
		{
			this.policy = policy;
		}

		public override string ToString()
		{
			return policy;
		}

		public bool Equals(NullPolicyType other)
		{
			if (object.ReferenceEquals(null, other))
			{
				return false;
			}
			if (object.ReferenceEquals(this, other))
			{
				return true;
			}
			return string.Equals(policy, other.policy);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((NullPolicyType)obj);
		}

		public override int GetHashCode()
		{
			return (policy != null) ? policy.GetHashCode() : 0;
		}

		public static bool operator ==(NullPolicyType left, NullPolicyType right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(NullPolicyType left, NullPolicyType right)
		{
			return !object.Equals(left, right);
		}
	}

	private readonly string field;

	private readonly ExpandParameters expand;

	private readonly MinOrMax minOrMaxField;

	private readonly NullPolicyType nullPolicy;

	/// <summary>
	/// Field to group results by
	/// </summary>
	public string Field => field;

	/// <summary>
	/// Used to expand the results.
	/// Null if expansion is not requested.
	/// </summary>
	public ExpandParameters Expand => expand;

	/// <summary>
	/// Field or function to use for min/max collapsing
	/// </summary>
	public MinOrMax MinOrMaxField => minOrMaxField;

	/// <summary>
	/// Determines how to treat nulls while collapsing
	/// </summary>
	public NullPolicyType NullPolicy => nullPolicy;

	/// <summary>
	/// Parameters for CollapsingQParserPlugin / ExpandComponent
	/// </summary>
	/// <param name="field">Field to collapse</param>
	/// <param name="expand"></param>
	/// <param name="minOrMaxField"></param>
	/// <param name="nullPolicy"></param>
	public CollapseExpandParameters(string field, ExpandParameters expand, MinOrMax minOrMaxField, NullPolicyType nullPolicy)
	{
		if (field == null)
		{
			throw new ArgumentNullException("field");
		}
		this.field = field;
		this.expand = expand;
		this.minOrMaxField = minOrMaxField;
		this.nullPolicy = nullPolicy;
	}
}
