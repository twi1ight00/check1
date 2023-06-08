using System;

namespace SolrNet.Utils;

/// <summary>
/// Function helpers
/// </summary>
public static class F
{
	/// <summary>
	/// Does nothing
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="a"></param>
	public static void DoNothing<T>(T a)
	{
	}

	/// <summary>
	/// Converts an <see cref="T:System.Action" /> into a <see cref="!:Func&lt;T,Unit&gt;" />, which is generally more composable
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="action"></param>
	/// <returns></returns>
	public static Func<T, Unit> ToFunc<T>(this Action<T> action)
	{
		return delegate(T x)
		{
			action(x);
			return null;
		};
	}

	public static Func<A, B, Unit> ToFunc<A, B>(this Action<A, B> action)
	{
		return delegate(A a, B b)
		{
			action(a, b);
			return null;
		};
	}

	public static Action<A, B> ToAction<A, B>(this Func<A, B, Unit> f)
	{
		return delegate(A a, B b)
		{
			f(a, b);
		};
	}

	/// <summary>
	/// Helps C# with type inference
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="f"></param>
	/// <returns></returns>
	public static Func<T> Func<T>(Func<T> f)
	{
		return f;
	}
}
