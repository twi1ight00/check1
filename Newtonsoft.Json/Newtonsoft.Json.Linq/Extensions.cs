using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq;

/// <summary>
///   Contains the LINQ to JSON extension methods.
/// </summary>
public static class Extensions
{
	/// <summary>
	///   Returns a collection of tokens that contains the ancestors of every token in the source collection.
	/// </summary>
	/// <typeparam name="T">
	///   The type of the objects in source, constrained to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </typeparam>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the ancestors of every token in the source collection.
	/// </returns>
	public static IJEnumerable<JToken> Ancestors<T>(this IEnumerable<T> source) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany((T j) => j.Ancestors()).AsJEnumerable();
	}

	/// <summary>
	///   Returns a collection of tokens that contains every token in the source collection, and the ancestors of every token in the source collection.
	/// </summary>
	/// <typeparam name="T">
	///   The type of the objects in source, constrained to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </typeparam>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains every token in the source collection, the ancestors of every token in the source collection.
	/// </returns>
	public static IJEnumerable<JToken> AncestorsAndSelf<T>(this IEnumerable<T> source) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany((T j) => j.AncestorsAndSelf()).AsJEnumerable();
	}

	/// <summary>
	///   Returns a collection of tokens that contains the descendants of every token in the source collection.
	/// </summary>
	/// <typeparam name="T">
	///   The type of the objects in source, constrained to <see cref="T:Newtonsoft.Json.Linq.JContainer" />.
	/// </typeparam>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the descendants of every token in the source collection.
	/// </returns>
	public static IJEnumerable<JToken> Descendants<T>(this IEnumerable<T> source) where T : JContainer
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany((T j) => j.Descendants()).AsJEnumerable();
	}

	/// <summary>
	///   Returns a collection of tokens that contains every token in the source collection, and the descendants of every token in the source collection.
	/// </summary>
	/// <typeparam name="T">
	///   The type of the objects in source, constrained to <see cref="T:Newtonsoft.Json.Linq.JContainer" />.
	/// </typeparam>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains every token in the source collection, and the descendants of every token in the source collection.
	/// </returns>
	public static IJEnumerable<JToken> DescendantsAndSelf<T>(this IEnumerable<T> source) where T : JContainer
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany((T j) => j.DescendantsAndSelf()).AsJEnumerable();
	}

	/// <summary>
	///   Returns a collection of child properties of every object in the source collection.
	/// </summary>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JObject" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JProperty" /> that contains the properties of every object in the source collection.
	/// </returns>
	public static IJEnumerable<JProperty> Properties(this IEnumerable<JObject> source)
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany((JObject d) => d.Properties()).AsJEnumerable();
	}

	/// <summary>
	///   Returns a collection of child values of every object in the source collection with the given key.
	/// </summary>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <param name="key">The token key.</param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the values of every token in the source collection with the given key.
	/// </returns>
	public static IJEnumerable<JToken> Values(this IEnumerable<JToken> source, object key)
	{
		return source.Values<JToken, JToken>(key).AsJEnumerable();
	}

	/// <summary>
	///   Returns a collection of child values of every object in the source collection.
	/// </summary>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the values of every token in the source collection.
	/// </returns>
	public static IJEnumerable<JToken> Values(this IEnumerable<JToken> source)
	{
		return source.Values(null);
	}

	/// <summary>
	///   Returns a collection of converted child values of every object in the source collection with the given key.
	/// </summary>
	/// <typeparam name="U">The type to convert the values to.</typeparam>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <param name="key">The token key.</param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the converted values of every token in the source collection with the given key.
	/// </returns>
	public static IEnumerable<U> Values<U>(this IEnumerable<JToken> source, object key)
	{
		return source.Values<JToken, U>(key);
	}

	/// <summary>
	///   Returns a collection of converted child values of every object in the source collection.
	/// </summary>
	/// <typeparam name="U">The type to convert the values to.</typeparam>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the converted values of every token in the source collection.
	/// </returns>
	public static IEnumerable<U> Values<U>(this IEnumerable<JToken> source)
	{
		return source.Values<JToken, U>(null);
	}

	/// <summary>
	///   Converts the value.
	/// </summary>
	/// <typeparam name="U">The type to convert the value to.</typeparam>
	/// <param name="value">
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" /> cast as a <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </param>
	/// <returns>A converted value.</returns>
	public static U Value<U>(this IEnumerable<JToken> value)
	{
		return value.Value<JToken, U>();
	}

	/// <summary>
	///   Converts the value.
	/// </summary>
	/// <typeparam name="T">The source collection type.</typeparam>
	/// <typeparam name="U">The type to convert the value to.</typeparam>
	/// <param name="value">
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" /> cast as a <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </param>
	/// <returns>A converted value.</returns>
	public static U Value<T, U>(this IEnumerable<T> value) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(value, "value");
		return ((value as JToken) ?? throw new ArgumentException("Source value must be a JToken.")).Convert<JToken, U>();
	}

	internal static IEnumerable<U> Values<T, U>(this IEnumerable<T> source, object key) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		foreach (T token in source)
		{
			if (key == null)
			{
				if (token is JValue)
				{
					yield return ((JValue)(object)token).Convert<JValue, U>();
					continue;
				}
				foreach (JToken item in token.Children())
				{
					yield return item.Convert<JToken, U>();
				}
			}
			else
			{
				JToken jToken = token[key];
				if (jToken != null)
				{
					yield return jToken.Convert<JToken, U>();
				}
			}
		}
	}

	/// <summary>
	///   Returns a collection of child tokens of every array in the source collection.
	/// </summary>
	/// <typeparam name="T">The source collection type.</typeparam>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the values of every token in the source collection.
	/// </returns>
	public static IJEnumerable<JToken> Children<T>(this IEnumerable<T> source) where T : JToken
	{
		return source.Children<T, JToken>().AsJEnumerable();
	}

	/// <summary>
	///   Returns a collection of converted child tokens of every array in the source collection.
	/// </summary>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <typeparam name="U">The type to convert the values to.</typeparam>
	/// <typeparam name="T">The source collection type.</typeparam>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the converted values of every token in the source collection.
	/// </returns>
	public static IEnumerable<U> Children<T, U>(this IEnumerable<T> source) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany((T c) => c.Children()).Convert<JToken, U>();
	}

	internal static IEnumerable<U> Convert<T, U>(this IEnumerable<T> source) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		foreach (T item in source)
		{
			yield return item.Convert<JToken, U>();
		}
	}

	internal static U Convert<T, U>(this T token) where T : JToken
	{
		if (token == null)
		{
			return default(U);
		}
		if (token is U && typeof(U) != typeof(IComparable) && typeof(U) != typeof(IFormattable))
		{
			return (U)(object)token;
		}
		if (!(token is JValue jValue))
		{
			throw new InvalidCastException("Cannot cast {0} to {1}.".FormatWith(CultureInfo.InvariantCulture, token.GetType(), typeof(T)));
		}
		if (jValue.Value is U)
		{
			return (U)jValue.Value;
		}
		Type type = typeof(U);
		if (ReflectionUtils.IsNullableType(type))
		{
			if (jValue.Value == null)
			{
				return default(U);
			}
			type = Nullable.GetUnderlyingType(type);
		}
		return (U)System.Convert.ChangeType(jValue.Value, type, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Returns the input typed as <see cref="T:Newtonsoft.Json.Linq.IJEnumerable`1" />.
	/// </summary>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   The input typed as <see cref="T:Newtonsoft.Json.Linq.IJEnumerable`1" />.
	/// </returns>
	public static IJEnumerable<JToken> AsJEnumerable(this IEnumerable<JToken> source)
	{
		return source.AsJEnumerable<JToken>();
	}

	/// <summary>
	///   Returns the input typed as <see cref="T:Newtonsoft.Json.Linq.IJEnumerable`1" />.
	/// </summary>
	/// <typeparam name="T">The source collection type.</typeparam>
	/// <param name="source">
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the source collection.
	/// </param>
	/// <returns>
	///   The input typed as <see cref="T:Newtonsoft.Json.Linq.IJEnumerable`1" />.
	/// </returns>
	public static IJEnumerable<T> AsJEnumerable<T>(this IEnumerable<T> source) where T : JToken
	{
		if (source == null)
		{
			return null;
		}
		if (source is IJEnumerable<T>)
		{
			return (IJEnumerable<T>)source;
		}
		return new JEnumerable<T>(source);
	}
}