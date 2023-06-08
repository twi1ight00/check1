using System;
using System.Collections.Generic;

namespace SolrNet.Utils;

/// <summary>
/// Function memoizer
/// From http://blogs.msdn.com/wesdyer/archive/2007/01/26/function-memoization.aspx
/// </summary>
public class Memoizer
{
	private struct Tuple2<A, B>
	{
		private readonly A first;

		private readonly B second;

		public Tuple2(A first, B second)
		{
			this.first = first;
			this.second = second;
		}

		public bool Equals(Tuple2<A, B> other)
		{
			return object.Equals(other.first, first) && object.Equals(other.second, second);
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (obj.GetType() != typeof(Tuple2<A, B>))
			{
				return false;
			}
			return Equals((Tuple2<A, B>)obj);
		}

		public override int GetHashCode()
		{
			A val = first;
			int num = val.GetHashCode() * 397;
			B val2 = second;
			return num ^ val2.GetHashCode();
		}
	}

	/// <summary>
	/// Function memoizer
	/// From http://blogs.msdn.com/wesdyer/archive/2007/01/26/function-memoization.aspx
	/// </summary>
	public static Converter<TArg, TResult> Memoize<TArg, TResult>(Converter<TArg, TResult> function)
	{
		Dictionary<TArg, TResult> results = new Dictionary<TArg, TResult>();
		return delegate(TArg key)
		{
			lock (results)
			{
				if (results.TryGetValue(key, out var value))
				{
					return value;
				}
				value = function(key);
				results.Add(key, value);
				return value;
			}
		};
	}

	/// <summary>
	/// Memoize a binary function
	/// </summary>
	/// <typeparam name="TArg1"></typeparam>
	/// <typeparam name="TArg2"></typeparam>
	/// <typeparam name="TResult"></typeparam>
	/// <param name="function"></param>
	/// <returns></returns>
	public static Func<TArg1, TArg2, TResult> Memoize2<TArg1, TArg2, TResult>(Func<TArg1, TArg2, TResult> function)
	{
		Dictionary<Tuple2<TArg1, TArg2>, TResult> results = new Dictionary<Tuple2<TArg1, TArg2>, TResult>();
		return delegate(TArg1 k1, TArg2 k2)
		{
			lock (results)
			{
				Tuple2<TArg1, TArg2> key = new Tuple2<TArg1, TArg2>(k1, k2);
				if (results.TryGetValue(key, out var value))
				{
					return value;
				}
				value = function(k1, k2);
				results.Add(key, value);
				return value;
			}
		};
	}
}
