using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using Newtonsoft.Json.Linq.JsonPath;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq;

/// <summary>
///   Represents an abstract JSON token.
/// </summary>
public abstract class JToken : IJEnumerable<JToken>, IEnumerable<JToken>, IEnumerable, IJsonLineInfo, ICloneable, IDynamicMetaObjectProvider
{
	private class LineInfoAnnotation
	{
		internal readonly int LineNumber;

		internal readonly int LinePosition;

		public LineInfoAnnotation(int lineNumber, int linePosition)
		{
			LineNumber = lineNumber;
			LinePosition = linePosition;
		}
	}

	private static JTokenEqualityComparer _equalityComparer;

	private JContainer _parent;

	private JToken _previous;

	private JToken _next;

	private object _annotations;

	private static readonly JTokenType[] BooleanTypes = new JTokenType[6]
	{
		JTokenType.Integer,
		JTokenType.Float,
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw,
		JTokenType.Boolean
	};

	private static readonly JTokenType[] NumberTypes = new JTokenType[6]
	{
		JTokenType.Integer,
		JTokenType.Float,
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw,
		JTokenType.Boolean
	};

	private static readonly JTokenType[] BigIntegerTypes = new JTokenType[7]
	{
		JTokenType.Integer,
		JTokenType.Float,
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw,
		JTokenType.Boolean,
		JTokenType.Bytes
	};

	private static readonly JTokenType[] StringTypes = new JTokenType[11]
	{
		JTokenType.Date,
		JTokenType.Integer,
		JTokenType.Float,
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw,
		JTokenType.Boolean,
		JTokenType.Bytes,
		JTokenType.Guid,
		JTokenType.TimeSpan,
		JTokenType.Uri
	};

	private static readonly JTokenType[] GuidTypes = new JTokenType[5]
	{
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw,
		JTokenType.Guid,
		JTokenType.Bytes
	};

	private static readonly JTokenType[] TimeSpanTypes = new JTokenType[4]
	{
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw,
		JTokenType.TimeSpan
	};

	private static readonly JTokenType[] UriTypes = new JTokenType[4]
	{
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw,
		JTokenType.Uri
	};

	private static readonly JTokenType[] CharTypes = new JTokenType[5]
	{
		JTokenType.Integer,
		JTokenType.Float,
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw
	};

	private static readonly JTokenType[] DateTimeTypes = new JTokenType[4]
	{
		JTokenType.Date,
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw
	};

	private static readonly JTokenType[] BytesTypes = new JTokenType[5]
	{
		JTokenType.Bytes,
		JTokenType.String,
		JTokenType.Comment,
		JTokenType.Raw,
		JTokenType.Integer
	};

	/// <summary>
	///   Gets a comparer that can compare two tokens for value equality.
	/// </summary>
	/// <value>
	///   A <see cref="T:Newtonsoft.Json.Linq.JTokenEqualityComparer" /> that can compare two nodes for value equality.
	/// </value>
	public static JTokenEqualityComparer EqualityComparer
	{
		get
		{
			if (_equalityComparer == null)
			{
				_equalityComparer = new JTokenEqualityComparer();
			}
			return _equalityComparer;
		}
	}

	/// <summary>
	///   Gets or sets the parent.
	/// </summary>
	/// <value>The parent.</value>
	public JContainer Parent
	{
		[DebuggerStepThrough]
		get
		{
			return _parent;
		}
		internal set
		{
			_parent = value;
		}
	}

	/// <summary>
	///   Gets the root <see cref="T:Newtonsoft.Json.Linq.JToken" /> of this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <value>
	///   The root <see cref="T:Newtonsoft.Json.Linq.JToken" /> of this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </value>
	public JToken Root
	{
		get
		{
			JContainer parent = Parent;
			if (parent == null)
			{
				return this;
			}
			while (parent.Parent != null)
			{
				parent = parent.Parent;
			}
			return parent;
		}
	}

	/// <summary>
	///   Gets the node type for this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <value>The type.</value>
	public abstract JTokenType Type { get; }

	/// <summary>
	///   Gets a value indicating whether this token has child tokens.
	/// </summary>
	/// <value>
	///   <c>true</c> if this token has child values; otherwise, <c>false</c>.
	/// </value>
	public abstract bool HasValues { get; }

	/// <summary>
	///   Gets the next sibling token of this node.
	/// </summary>
	/// <value>
	///   The <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the next sibling token.
	/// </value>
	public JToken Next
	{
		get
		{
			return _next;
		}
		internal set
		{
			_next = value;
		}
	}

	/// <summary>
	///   Gets the previous sibling token of this node.
	/// </summary>
	/// <value>
	///   The <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the previous sibling token.
	/// </value>
	public JToken Previous
	{
		get
		{
			return _previous;
		}
		internal set
		{
			_previous = value;
		}
	}

	/// <summary>
	///   Gets the path of the JSON token.
	/// </summary>
	public string Path
	{
		get
		{
			if (Parent == null)
			{
				return string.Empty;
			}
			List<JsonPosition> list = new List<JsonPosition>();
			JToken jToken = null;
			for (JToken jToken2 = this; jToken2 != null; jToken2 = jToken2.Parent)
			{
				switch (jToken2.Type)
				{
				case JTokenType.Property:
				{
					JProperty jProperty = (JProperty)jToken2;
					list.Add(new JsonPosition(JsonContainerType.Object)
					{
						PropertyName = jProperty.Name
					});
					break;
				}
				case JTokenType.Array:
				case JTokenType.Constructor:
					if (jToken != null)
					{
						int position = ((IList<JToken>)jToken2).IndexOf(jToken);
						list.Add(new JsonPosition(JsonContainerType.Array)
						{
							Position = position
						});
					}
					break;
				}
				jToken = jToken2;
			}
			list.Reverse();
			return JsonPosition.BuildPath(list, null);
		}
	}

	/// <summary>
	///   Gets the <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified key.
	/// </summary>
	/// <value>
	///   The <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified key.
	/// </value>
	public virtual JToken this[object key]
	{
		get
		{
			throw new InvalidOperationException("Cannot access child value on {0}.".FormatWith(CultureInfo.InvariantCulture, GetType()));
		}
		set
		{
			throw new InvalidOperationException("Cannot set child value on {0}.".FormatWith(CultureInfo.InvariantCulture, GetType()));
		}
	}

	/// <summary>
	///   Get the first child token of this token.
	/// </summary>
	/// <value>
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" /> containing the first child token of the <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </value>
	public virtual JToken First
	{
		get
		{
			throw new InvalidOperationException("Cannot access child value on {0}.".FormatWith(CultureInfo.InvariantCulture, GetType()));
		}
	}

	/// <summary>
	///   Get the last child token of this token.
	/// </summary>
	/// <value>
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" /> containing the last child token of the <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </value>
	public virtual JToken Last
	{
		get
		{
			throw new InvalidOperationException("Cannot access child value on {0}.".FormatWith(CultureInfo.InvariantCulture, GetType()));
		}
	}

	IJEnumerable<JToken> IJEnumerable<JToken>.this[object key] => this[key];

	int IJsonLineInfo.LineNumber => Annotation<LineInfoAnnotation>()?.LineNumber ?? 0;

	int IJsonLineInfo.LinePosition => Annotation<LineInfoAnnotation>()?.LinePosition ?? 0;

	internal abstract JToken CloneToken();

	internal abstract bool DeepEquals(JToken node);

	/// <summary>
	///   Compares the values of two tokens, including the values of all descendant tokens.
	/// </summary>
	/// <param name="t1">
	///   The first <see cref="T:Newtonsoft.Json.Linq.JToken" /> to compare.
	/// </param>
	/// <param name="t2">
	///   The second <see cref="T:Newtonsoft.Json.Linq.JToken" /> to compare.
	/// </param>
	/// <returns>
	///   <c>true</c> if the tokens are equal; otherwise <c>false</c>.
	/// </returns>
	public static bool DeepEquals(JToken t1, JToken t2)
	{
		if (t1 != t2)
		{
			if (t1 != null && t2 != null)
			{
				return t1.DeepEquals(t2);
			}
			return false;
		}
		return true;
	}

	internal JToken()
	{
	}

	/// <summary>
	///   Adds the specified content immediately after this token.
	/// </summary>
	/// <param name="content">A content object that contains simple content or a collection of content objects to be added after this token.</param>
	public void AddAfterSelf(object content)
	{
		if (_parent == null)
		{
			throw new InvalidOperationException("The parent is missing.");
		}
		int num = _parent.IndexOfItem(this);
		_parent.AddInternal(num + 1, content, skipParentCheck: false);
	}

	/// <summary>
	///   Adds the specified content immediately before this token.
	/// </summary>
	/// <param name="content">A content object that contains simple content or a collection of content objects to be added before this token.</param>
	public void AddBeforeSelf(object content)
	{
		if (_parent == null)
		{
			throw new InvalidOperationException("The parent is missing.");
		}
		int index = _parent.IndexOfItem(this);
		_parent.AddInternal(index, content, skipParentCheck: false);
	}

	/// <summary>
	///   Returns a collection of the ancestor tokens of this token.
	/// </summary>
	/// <returns>A collection of the ancestor tokens of this token.</returns>
	public IEnumerable<JToken> Ancestors()
	{
		return GetAncestors(self: false);
	}

	/// <summary>
	///   Returns a collection of tokens that contain this token, and the ancestors of this token.
	/// </summary>
	/// <returns>A collection of tokens that contain this token, and the ancestors of this token.</returns>
	public IEnumerable<JToken> AncestorsAndSelf()
	{
		return GetAncestors(self: true);
	}

	internal IEnumerable<JToken> GetAncestors(bool self)
	{
		for (JToken current = (self ? this : Parent); current != null; current = current.Parent)
		{
			yield return current;
		}
	}

	/// <summary>
	///   Returns a collection of the sibling tokens after this token, in document order.
	/// </summary>
	/// <returns>A collection of the sibling tokens after this tokens, in document order.</returns>
	public IEnumerable<JToken> AfterSelf()
	{
		if (Parent != null)
		{
			for (JToken o = Next; o != null; o = o.Next)
			{
				yield return o;
			}
		}
	}

	/// <summary>
	///   Returns a collection of the sibling tokens before this token, in document order.
	/// </summary>
	/// <returns>A collection of the sibling tokens before this token, in document order.</returns>
	public IEnumerable<JToken> BeforeSelf()
	{
		for (JToken o = Parent.First; o != this; o = o.Next)
		{
			yield return o;
		}
	}

	/// <summary>
	///   Gets the <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified key converted to the specified type.
	/// </summary>
	/// <typeparam name="T">The type to convert the token to.</typeparam>
	/// <param name="key">The token key.</param>
	/// <returns>The converted token value.</returns>
	public virtual T Value<T>(object key)
	{
		JToken jToken = this[key];
		if (jToken != null)
		{
			return jToken.Convert<JToken, T>();
		}
		return default(T);
	}

	/// <summary>
	///   Returns a collection of the child tokens of this token, in document order.
	/// </summary>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Newtonsoft.Json.Linq.JToken" /> containing the child tokens of this <see cref="T:Newtonsoft.Json.Linq.JToken" />, in document order.
	/// </returns>
	public virtual JEnumerable<JToken> Children()
	{
		return JEnumerable<JToken>.Empty;
	}

	/// <summary>
	///   Returns a collection of the child tokens of this token, in document order, filtered by the specified type.
	/// </summary>
	/// <typeparam name="T">The type to filter the child tokens on.</typeparam>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JEnumerable`1" /> containing the child tokens of this <see cref="T:Newtonsoft.Json.Linq.JToken" />, in document order.
	/// </returns>
	public JEnumerable<T> Children<T>() where T : JToken
	{
		return new JEnumerable<T>(Children().OfType<T>());
	}

	/// <summary>
	///   Returns a collection of the child values of this token, in document order.
	/// </summary>
	/// <typeparam name="T">The type to convert the values to.</typeparam>
	/// <returns>
	///   A <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing the child values of this <see cref="T:Newtonsoft.Json.Linq.JToken" />, in document order.
	/// </returns>
	public virtual IEnumerable<T> Values<T>()
	{
		throw new InvalidOperationException("Cannot access child value on {0}.".FormatWith(CultureInfo.InvariantCulture, GetType()));
	}

	/// <summary>
	///   Removes this token from its parent.
	/// </summary>
	public void Remove()
	{
		if (_parent == null)
		{
			throw new InvalidOperationException("The parent is missing.");
		}
		_parent.RemoveItem(this);
	}

	/// <summary>
	///   Replaces this token with the specified token.
	/// </summary>
	/// <param name="value">The value.</param>
	public void Replace(JToken value)
	{
		if (_parent == null)
		{
			throw new InvalidOperationException("The parent is missing.");
		}
		_parent.ReplaceItem(this, value);
	}

	/// <summary>
	///   Writes this token to a <see cref="T:Newtonsoft.Json.JsonWriter" />.
	/// </summary>
	/// <param name="writer">
	///   A <see cref="T:Newtonsoft.Json.JsonWriter" /> into which this method will write.
	/// </param>
	/// <param name="converters">
	///   A collection of <see cref="T:Newtonsoft.Json.JsonConverter" /> which will be used when writing the token.
	/// </param>
	public abstract void WriteTo(JsonWriter writer, params JsonConverter[] converters);

	/// <summary>
	///   Returns the indented JSON for this token.
	/// </summary>
	/// <returns>
	///   The indented JSON for this token.
	/// </returns>
	public override string ToString()
	{
		return ToString(Formatting.Indented);
	}

	/// <summary>
	///   Returns the JSON for this token using the given formatting and converters.
	/// </summary>
	/// <param name="formatting">Indicates how the output is formatted.</param>
	/// <param name="converters">
	///   A collection of <see cref="T:Newtonsoft.Json.JsonConverter" /> which will be used when writing the token.
	/// </param>
	/// <returns>The JSON for this token using the given formatting and converters.</returns>
	public string ToString(Formatting formatting, params JsonConverter[] converters)
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter);
		jsonTextWriter.Formatting = formatting;
		WriteTo(jsonTextWriter, converters);
		return stringWriter.ToString();
	}

	private static JValue EnsureValue(JToken value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (value is JProperty)
		{
			value = ((JProperty)value).Value;
		}
		return value as JValue;
	}

	private static string GetType(JToken token)
	{
		ValidationUtils.ArgumentNotNull(token, "token");
		if (token is JProperty)
		{
			token = ((JProperty)token).Value;
		}
		return token.Type.ToString();
	}

	private static bool ValidateToken(JToken o, JTokenType[] validTypes, bool nullable)
	{
		if (Array.IndexOf(validTypes, o.Type) == -1)
		{
			if (nullable)
			{
				if (o.Type != JTokenType.Null)
				{
					return o.Type == JTokenType.Undefined;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Boolean" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator bool(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, BooleanTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Boolean.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return Convert.ToBoolean((int)(BigInteger)jValue.Value);
		}
		return Convert.ToBoolean(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.DateTimeOffset" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator DateTimeOffset(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, DateTimeTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to DateTimeOffset.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is DateTimeOffset)
		{
			return (DateTimeOffset)jValue.Value;
		}
		if (jValue.Value is string)
		{
			return DateTimeOffset.Parse((string)jValue.Value, CultureInfo.InvariantCulture);
		}
		return new DateTimeOffset(Convert.ToDateTime(jValue.Value, CultureInfo.InvariantCulture));
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator bool?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, BooleanTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Boolean.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return Convert.ToBoolean((int)(BigInteger)jValue.Value);
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToBoolean(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Int64" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator long(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Int64.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (long)(BigInteger)jValue.Value;
		}
		return Convert.ToInt64(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator DateTime?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, DateTimeTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to DateTime.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is DateTimeOffset)
		{
			return ((DateTimeOffset)jValue.Value).DateTime;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToDateTime(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator DateTimeOffset?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, DateTimeTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to DateTimeOffset.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value == null)
		{
			return null;
		}
		if (jValue.Value is DateTimeOffset)
		{
			return (DateTimeOffset?)jValue.Value;
		}
		if (jValue.Value is string)
		{
			return DateTimeOffset.Parse((string)jValue.Value, CultureInfo.InvariantCulture);
		}
		return new DateTimeOffset(Convert.ToDateTime(jValue.Value, CultureInfo.InvariantCulture));
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator decimal?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Decimal.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (decimal)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToDecimal(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator double?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Double.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (double)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToDouble(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator char?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, CharTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Char.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (char)(ushort)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToChar(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Int32" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator int(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Int32.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (int)(BigInteger)jValue.Value;
		}
		return Convert.ToInt32(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Int16" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator short(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Int16.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (short)(BigInteger)jValue.Value;
		}
		return Convert.ToInt16(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.UInt16" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator ushort(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to UInt16.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (ushort)(BigInteger)jValue.Value;
		}
		return Convert.ToUInt16(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Char" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator char(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, CharTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Char.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (char)(ushort)(BigInteger)jValue.Value;
		}
		return Convert.ToChar(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Byte" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator byte(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Byte.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (byte)(BigInteger)jValue.Value;
		}
		return Convert.ToByte(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.SByte" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator sbyte(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to SByte.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (sbyte)(BigInteger)jValue.Value;
		}
		return Convert.ToSByte(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator int?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Int32.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (int)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToInt32(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator short?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Int16.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (short)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToInt16(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator ushort?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to UInt16.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (ushort)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToUInt16(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator byte?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Byte.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (byte)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToByte(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator sbyte?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to SByte.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (sbyte)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToSByte(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.DateTime" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator DateTime(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, DateTimeTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to DateTime.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is DateTimeOffset)
		{
			return ((DateTimeOffset)jValue.Value).DateTime;
		}
		return Convert.ToDateTime(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator long?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Int64.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (long)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToInt64(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator float?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Single.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (float)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToSingle(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Decimal" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator decimal(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Decimal.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (decimal)(BigInteger)jValue.Value;
		}
		return Convert.ToDecimal(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator uint?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to UInt32.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (uint)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToUInt32(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator ulong?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to UInt64.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (ulong)(BigInteger)jValue.Value;
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return Convert.ToUInt64(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Double" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator double(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Double.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (double)(BigInteger)jValue.Value;
		}
		return Convert.ToDouble(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Single" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator float(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Single.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (float)(BigInteger)jValue.Value;
		}
		return Convert.ToSingle(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.String" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator string(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, StringTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to String.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value == null)
		{
			return null;
		}
		if (jValue.Value is byte[])
		{
			return Convert.ToBase64String((byte[])jValue.Value);
		}
		if (jValue.Value is BigInteger)
		{
			return ((BigInteger)jValue.Value).ToString(CultureInfo.InvariantCulture);
		}
		return Convert.ToString(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.UInt32" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator uint(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to UInt32.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (uint)(BigInteger)jValue.Value;
		}
		return Convert.ToUInt32(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.UInt64" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	[CLSCompliant(false)]
	public static explicit operator ulong(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to UInt64.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is BigInteger)
		{
			return (ulong)(BigInteger)jValue.Value;
		}
		return Convert.ToUInt64(jValue.Value, CultureInfo.InvariantCulture);
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Byte" />[].
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator byte[](JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, BytesTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to byte array.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is string)
		{
			return Convert.FromBase64String(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}
		if (jValue.Value is BigInteger)
		{
			return ((BigInteger)jValue.Value).ToByteArray();
		}
		if (jValue.Value is byte[])
		{
			return (byte[])jValue.Value;
		}
		throw new ArgumentException("Can not convert {0} to byte array.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Guid" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator Guid(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, GuidTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to Guid.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value is byte[])
		{
			return new Guid((byte[])jValue.Value);
		}
		if (!(jValue.Value is Guid))
		{
			return new Guid(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}
		return (Guid)jValue.Value;
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Guid" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator Guid?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, GuidTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Guid.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value == null)
		{
			return null;
		}
		if (jValue.Value is byte[])
		{
			return new Guid((byte[])jValue.Value);
		}
		return (jValue.Value is Guid) ? ((Guid)jValue.Value) : new Guid(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.TimeSpan" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator TimeSpan(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, TimeSpanTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to TimeSpan.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (!(jValue.Value is TimeSpan))
		{
			return ConvertUtils.ParseTimeSpan(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}
		return (TimeSpan)jValue.Value;
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.TimeSpan" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator TimeSpan?(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, TimeSpanTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to TimeSpan.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return (jValue.Value is TimeSpan) ? ((TimeSpan)jValue.Value) : ConvertUtils.ParseTimeSpan(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
	}

	/// <summary>
	///   Performs an explicit conversion from <see cref="T:Newtonsoft.Json.Linq.JToken" /> to <see cref="T:System.Uri" />.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator Uri(JToken value)
	{
		if (value == null)
		{
			return null;
		}
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, UriTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to Uri.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value == null)
		{
			return null;
		}
		if (!(jValue.Value is Uri))
		{
			return new Uri(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}
		return (Uri)jValue.Value;
	}

	private static BigInteger ToBigInteger(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, BigIntegerTypes, nullable: false))
		{
			throw new ArgumentException("Can not convert {0} to BigInteger.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		return ConvertUtils.ToBigInteger(jValue.Value);
	}

	private static BigInteger? ToBigIntegerNullable(JToken value)
	{
		JValue jValue = EnsureValue(value);
		if (jValue == null || !ValidateToken(jValue, BigIntegerTypes, nullable: true))
		{
			throw new ArgumentException("Can not convert {0} to BigInteger.".FormatWith(CultureInfo.InvariantCulture, GetType(value)));
		}
		if (jValue.Value == null)
		{
			return null;
		}
		return ConvertUtils.ToBigInteger(jValue.Value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Boolean" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(bool value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.DateTimeOffset" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(DateTimeOffset value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Byte" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(byte value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(byte? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.SByte" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(sbyte value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(sbyte? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(bool? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(long value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(DateTime? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(DateTimeOffset? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(decimal? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(double? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Int16" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(short value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.UInt16" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(ushort value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Int32" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(int value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(int? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.DateTime" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(DateTime value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(long? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(float? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Decimal" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(decimal value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(short? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(ushort? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(uint? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(ulong? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Double" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(double value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Single" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(float value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(string value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.UInt32" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(uint value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.UInt64" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	[CLSCompliant(false)]
	public static implicit operator JToken(ulong value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Byte" />[] to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(byte[] value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Uri" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(Uri value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.TimeSpan" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(TimeSpan value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(TimeSpan? value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Guid" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(Guid value)
	{
		return new JValue(value);
	}

	/// <summary>
	///   Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="value">
	///   The value to create a <see cref="T:Newtonsoft.Json.Linq.JValue" /> from.
	/// </param>
	/// <returns>
	///   The <see cref="T:Newtonsoft.Json.Linq.JValue" /> initialized with the specified value.
	/// </returns>
	public static implicit operator JToken(Guid? value)
	{
		return new JValue(value);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<JToken>)this).GetEnumerator();
	}

	IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator()
	{
		return Children().GetEnumerator();
	}

	internal abstract int GetDeepHashCode();

	/// <summary>
	///   Creates an <see cref="T:Newtonsoft.Json.JsonReader" /> for this token.
	/// </summary>
	/// <returns>
	///   An <see cref="T:Newtonsoft.Json.JsonReader" /> that can be used to read this token and its descendants.
	/// </returns>
	public JsonReader CreateReader()
	{
		return new JTokenReader(this);
	}

	internal static JToken FromObjectInternal(object o, JsonSerializer jsonSerializer)
	{
		ValidationUtils.ArgumentNotNull(o, "o");
		ValidationUtils.ArgumentNotNull(jsonSerializer, "jsonSerializer");
		using JTokenWriter jTokenWriter = new JTokenWriter();
		jsonSerializer.Serialize(jTokenWriter, o);
		return jTokenWriter.Token;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JToken" /> from an object.
	/// </summary>
	/// <param name="o">
	///   The object that will be used to create <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the value of the specified object
	/// </returns>
	public static JToken FromObject(object o)
	{
		return FromObjectInternal(o, JsonSerializer.CreateDefault());
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JToken" /> from an object using the specified <see cref="T:Newtonsoft.Json.JsonSerializer" />.
	/// </summary>
	/// <param name="o">
	///   The object that will be used to create <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </param>
	/// <param name="jsonSerializer">
	///   The <see cref="T:Newtonsoft.Json.JsonSerializer" /> that will be used when reading the object.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the value of the specified object
	/// </returns>
	public static JToken FromObject(object o, JsonSerializer jsonSerializer)
	{
		return FromObjectInternal(o, jsonSerializer);
	}

	/// <summary>
	///   Creates the specified .NET type from the <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <typeparam name="T">The object type that the token will be deserialized to.</typeparam>
	/// <returns>The new object created from the JSON value.</returns>
	public T ToObject<T>()
	{
		return (T)ToObject(typeof(T));
	}

	/// <summary>
	///   Creates the specified .NET type from the <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="objectType">The object type that the token will be deserialized to.</param>
	/// <returns>The new object created from the JSON value.</returns>
	public object ToObject(Type objectType)
	{
		if (JsonConvert.DefaultSettings == null)
		{
			bool isEnum;
			PrimitiveTypeCode typeCode = ConvertUtils.GetTypeCode(objectType, out isEnum);
			if (isEnum)
			{
				if (Type == JTokenType.String)
				{
					try
					{
						return ToObject(objectType, JsonSerializer.CreateDefault());
					}
					catch (Exception innerException)
					{
						Type type = (objectType.IsEnum() ? objectType : Nullable.GetUnderlyingType(objectType));
						throw new ArgumentException("Could not convert '{0}' to {1}.".FormatWith(CultureInfo.InvariantCulture, (string)this, type.Name), innerException);
					}
				}
				if (Type == JTokenType.Integer)
				{
					return Enum.ToObject(objectType.IsEnum() ? objectType : Nullable.GetUnderlyingType(objectType), ((JValue)this).Value);
				}
			}
			switch (typeCode)
			{
			case PrimitiveTypeCode.BooleanNullable:
				return (bool?)this;
			case PrimitiveTypeCode.Boolean:
				return (bool)this;
			case PrimitiveTypeCode.CharNullable:
				return (char?)this;
			case PrimitiveTypeCode.Char:
				return (char)this;
			case PrimitiveTypeCode.SByte:
				return (sbyte?)this;
			case PrimitiveTypeCode.SByteNullable:
				return (sbyte)this;
			case PrimitiveTypeCode.ByteNullable:
				return (byte?)this;
			case PrimitiveTypeCode.Byte:
				return (byte)this;
			case PrimitiveTypeCode.Int16Nullable:
				return (short?)this;
			case PrimitiveTypeCode.Int16:
				return (short)this;
			case PrimitiveTypeCode.UInt16Nullable:
				return (ushort?)this;
			case PrimitiveTypeCode.UInt16:
				return (ushort)this;
			case PrimitiveTypeCode.Int32Nullable:
				return (int?)this;
			case PrimitiveTypeCode.Int32:
				return (int)this;
			case PrimitiveTypeCode.UInt32Nullable:
				return (uint?)this;
			case PrimitiveTypeCode.UInt32:
				return (uint)this;
			case PrimitiveTypeCode.Int64Nullable:
				return (long?)this;
			case PrimitiveTypeCode.Int64:
				return (long)this;
			case PrimitiveTypeCode.UInt64Nullable:
				return (ulong?)this;
			case PrimitiveTypeCode.UInt64:
				return (ulong)this;
			case PrimitiveTypeCode.SingleNullable:
				return (float?)this;
			case PrimitiveTypeCode.Single:
				return (float)this;
			case PrimitiveTypeCode.DoubleNullable:
				return (double?)this;
			case PrimitiveTypeCode.Double:
				return (double)this;
			case PrimitiveTypeCode.DecimalNullable:
				return (decimal?)this;
			case PrimitiveTypeCode.Decimal:
				return (decimal)this;
			case PrimitiveTypeCode.DateTimeNullable:
				return (DateTime?)this;
			case PrimitiveTypeCode.DateTime:
				return (DateTime)this;
			case PrimitiveTypeCode.DateTimeOffsetNullable:
				return (DateTimeOffset?)this;
			case PrimitiveTypeCode.DateTimeOffset:
				return (DateTimeOffset)this;
			case PrimitiveTypeCode.String:
				return (string)this;
			case PrimitiveTypeCode.GuidNullable:
				return (Guid?)this;
			case PrimitiveTypeCode.Guid:
				return (Guid)this;
			case PrimitiveTypeCode.Uri:
				return (Uri)this;
			case PrimitiveTypeCode.TimeSpanNullable:
				return (TimeSpan?)this;
			case PrimitiveTypeCode.TimeSpan:
				return (TimeSpan)this;
			case PrimitiveTypeCode.BigIntegerNullable:
				return ToBigIntegerNullable(this);
			case PrimitiveTypeCode.BigInteger:
				return ToBigInteger(this);
			}
		}
		return ToObject(objectType, JsonSerializer.CreateDefault());
	}

	/// <summary>
	///   Creates the specified .NET type from the <see cref="T:Newtonsoft.Json.Linq.JToken" /> using the specified <see cref="T:Newtonsoft.Json.JsonSerializer" />.
	/// </summary>
	/// <typeparam name="T">The object type that the token will be deserialized to.</typeparam>
	/// <param name="jsonSerializer">
	///   The <see cref="T:Newtonsoft.Json.JsonSerializer" /> that will be used when creating the object.
	/// </param>
	/// <returns>The new object created from the JSON value.</returns>
	public T ToObject<T>(JsonSerializer jsonSerializer)
	{
		return (T)ToObject(typeof(T), jsonSerializer);
	}

	/// <summary>
	///   Creates the specified .NET type from the <see cref="T:Newtonsoft.Json.Linq.JToken" /> using the specified <see cref="T:Newtonsoft.Json.JsonSerializer" />.
	/// </summary>
	/// <param name="objectType">The object type that the token will be deserialized to.</param>
	/// <param name="jsonSerializer">
	///   The <see cref="T:Newtonsoft.Json.JsonSerializer" /> that will be used when creating the object.
	/// </param>
	/// <returns>The new object created from the JSON value.</returns>
	public object ToObject(Type objectType, JsonSerializer jsonSerializer)
	{
		ValidationUtils.ArgumentNotNull(jsonSerializer, "jsonSerializer");
		using JTokenReader reader = new JTokenReader(this);
		return jsonSerializer.Deserialize(reader, objectType);
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JToken" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </summary>
	/// <param name="reader">
	///   An <see cref="T:Newtonsoft.Json.JsonReader" /> positioned at the token to read into this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </param>
	/// <returns>
	///   An <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the token and its descendant tokens
	///   that were read from the reader. The runtime type of the token is determined
	///   by the token type of the first token encountered in the reader.
	/// </returns>
	public static JToken ReadFrom(JsonReader reader)
	{
		return ReadFrom(reader, null);
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JToken" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </summary>
	/// <param name="reader">
	///   An <see cref="T:Newtonsoft.Json.JsonReader" /> positioned at the token to read into this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </param>
	/// <param name="settings">
	///   The <see cref="T:Newtonsoft.Json.Linq.JsonLoadSettings" /> used to load the JSON.
	///   If this is null, default load settings will be used.
	/// </param>
	/// <returns>
	///   An <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the token and its descendant tokens
	///   that were read from the reader. The runtime type of the token is determined
	///   by the token type of the first token encountered in the reader.
	/// </returns>
	public static JToken ReadFrom(JsonReader reader, JsonLoadSettings settings)
	{
		ValidationUtils.ArgumentNotNull(reader, "reader");
		if (reader.TokenType == JsonToken.None && !((settings != null && settings.CommentHandling == CommentHandling.Ignore) ? reader.ReadAndMoveToContent() : reader.Read()))
		{
			throw JsonReaderException.Create(reader, "Error reading JToken from JsonReader.");
		}
		IJsonLineInfo lineInfo = reader as IJsonLineInfo;
		switch (reader.TokenType)
		{
		case JsonToken.StartObject:
			return JObject.Load(reader, settings);
		case JsonToken.StartArray:
			return JArray.Load(reader, settings);
		case JsonToken.StartConstructor:
			return JConstructor.Load(reader, settings);
		case JsonToken.PropertyName:
			return JProperty.Load(reader, settings);
		case JsonToken.Integer:
		case JsonToken.Float:
		case JsonToken.String:
		case JsonToken.Boolean:
		case JsonToken.Date:
		case JsonToken.Bytes:
		{
			JValue jValue4 = new JValue(reader.Value);
			jValue4.SetLineInfo(lineInfo, settings);
			return jValue4;
		}
		case JsonToken.Comment:
		{
			JValue jValue3 = JValue.CreateComment(reader.Value.ToString());
			jValue3.SetLineInfo(lineInfo, settings);
			return jValue3;
		}
		case JsonToken.Null:
		{
			JValue jValue2 = JValue.CreateNull();
			jValue2.SetLineInfo(lineInfo, settings);
			return jValue2;
		}
		case JsonToken.Undefined:
		{
			JValue jValue = JValue.CreateUndefined();
			jValue.SetLineInfo(lineInfo, settings);
			return jValue;
		}
		default:
			throw JsonReaderException.Create(reader, "Error reading JToken from JsonReader. Unexpected token: {0}".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
		}
	}

	/// <summary>
	///   Load a <see cref="T:Newtonsoft.Json.Linq.JToken" /> from a string that contains JSON.
	/// </summary>
	/// <param name="json">
	///   A <see cref="T:System.String" /> that contains JSON.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" /> populated from the string that contains JSON.
	/// </returns>
	public static JToken Parse(string json)
	{
		return Parse(json, null);
	}

	/// <summary>
	///   Load a <see cref="T:Newtonsoft.Json.Linq.JToken" /> from a string that contains JSON.
	/// </summary>
	/// <param name="json">
	///   A <see cref="T:System.String" /> that contains JSON.
	/// </param>
	/// <param name="settings">
	///   The <see cref="T:Newtonsoft.Json.Linq.JsonLoadSettings" /> used to load the JSON.
	///   If this is null, default load settings will be used.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" /> populated from the string that contains JSON.
	/// </returns>
	public static JToken Parse(string json, JsonLoadSettings settings)
	{
		using JsonReader jsonReader = new JsonTextReader(new StringReader(json));
		JToken result = Load(jsonReader, settings);
		if (jsonReader.Read() && jsonReader.TokenType != JsonToken.Comment)
		{
			throw JsonReaderException.Create(jsonReader, "Additional text found in JSON string after parsing content.");
		}
		return result;
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JToken" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </summary>
	/// <param name="reader">
	///   An <see cref="T:Newtonsoft.Json.JsonReader" /> positioned at the token to read into this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </param>
	/// <param name="settings">
	///   The <see cref="T:Newtonsoft.Json.Linq.JsonLoadSettings" /> used to load the JSON.
	///   If this is null, default load settings will be used.
	/// </param>
	/// <returns>
	///   An <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the token and its descendant tokens
	///   that were read from the reader. The runtime type of the token is determined
	///   by the token type of the first token encountered in the reader.
	/// </returns>
	public static JToken Load(JsonReader reader, JsonLoadSettings settings)
	{
		return ReadFrom(reader, settings);
	}

	/// <summary>
	///   Creates a <see cref="T:Newtonsoft.Json.Linq.JToken" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
	/// </summary>
	/// <param name="reader">
	///   An <see cref="T:Newtonsoft.Json.JsonReader" /> positioned at the token to read into this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </param>
	/// <returns>
	///   An <see cref="T:Newtonsoft.Json.Linq.JToken" /> that contains the token and its descendant tokens
	///   that were read from the reader. The runtime type of the token is determined
	///   by the token type of the first token encountered in the reader.
	/// </returns>
	public static JToken Load(JsonReader reader)
	{
		return Load(reader, null);
	}

	internal void SetLineInfo(IJsonLineInfo lineInfo, JsonLoadSettings settings)
	{
		if ((settings == null || settings.LineInfoHandling != LineInfoHandling.Load) && lineInfo != null && lineInfo.HasLineInfo())
		{
			SetLineInfo(lineInfo.LineNumber, lineInfo.LinePosition);
		}
	}

	internal void SetLineInfo(int lineNumber, int linePosition)
	{
		AddAnnotation(new LineInfoAnnotation(lineNumber, linePosition));
	}

	bool IJsonLineInfo.HasLineInfo()
	{
		return Annotation<LineInfoAnnotation>() != null;
	}

	/// <summary>
	///   Selects a <see cref="T:Newtonsoft.Json.Linq.JToken" /> using a JPath expression. Selects the token that matches the object path.
	/// </summary>
	/// <param name="path">
	///   A <see cref="T:System.String" /> that contains a JPath expression.
	/// </param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" />, or null.
	/// </returns>
	public JToken SelectToken(string path)
	{
		return SelectToken(path, errorWhenNoMatch: false);
	}

	/// <summary>
	///   Selects a <see cref="T:Newtonsoft.Json.Linq.JToken" /> using a JPath expression. Selects the token that matches the object path.
	/// </summary>
	/// <param name="path">
	///   A <see cref="T:System.String" /> that contains a JPath expression.
	/// </param>
	/// <param name="errorWhenNoMatch">A flag to indicate whether an error should be thrown if no tokens are found when evaluating part of the expression.</param>
	/// <returns>
	///   A <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </returns>
	public JToken SelectToken(string path, bool errorWhenNoMatch)
	{
		JPath jPath = new JPath(path);
		JToken jToken = null;
		foreach (JToken item in jPath.Evaluate(this, errorWhenNoMatch))
		{
			if (jToken != null)
			{
				throw new JsonException("Path returned multiple tokens.");
			}
			jToken = item;
		}
		return jToken;
	}

	/// <summary>
	///   Selects a collection of elements using a JPath expression.
	/// </summary>
	/// <param name="path">
	///   A <see cref="T:System.String" /> that contains a JPath expression.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the selected elements.
	/// </returns>
	public IEnumerable<JToken> SelectTokens(string path)
	{
		return SelectTokens(path, errorWhenNoMatch: false);
	}

	/// <summary>
	///   Selects a collection of elements using a JPath expression.
	/// </summary>
	/// <param name="path">
	///   A <see cref="T:System.String" /> that contains a JPath expression.
	/// </param>
	/// <param name="errorWhenNoMatch">A flag to indicate whether an error should be thrown if no tokens are found when evaluating part of the expression.</param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the selected elements.
	/// </returns>
	public IEnumerable<JToken> SelectTokens(string path, bool errorWhenNoMatch)
	{
		return new JPath(path).Evaluate(this, errorWhenNoMatch);
	}

	/// <summary>
	///   Returns the <see cref="T:System.Dynamic.DynamicMetaObject" /> responsible for binding operations performed on this object.
	/// </summary>
	/// <param name="parameter">The expression tree representation of the runtime value.</param>
	/// <returns>
	///   The <see cref="T:System.Dynamic.DynamicMetaObject" /> to bind this object.
	/// </returns>
	protected virtual DynamicMetaObject GetMetaObject(Expression parameter)
	{
		return new DynamicProxyMetaObject<JToken>(parameter, this, new DynamicProxy<JToken>(), dontFallbackFirst: true);
	}

	/// <summary>
	///   Returns the <see cref="T:System.Dynamic.DynamicMetaObject" /> responsible for binding operations performed on this object.
	/// </summary>
	/// <param name="parameter">The expression tree representation of the runtime value.</param>
	/// <returns>
	///   The <see cref="T:System.Dynamic.DynamicMetaObject" /> to bind this object.
	/// </returns>
	DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
	{
		return GetMetaObject(parameter);
	}

	object ICloneable.Clone()
	{
		return DeepClone();
	}

	/// <summary>
	///   Creates a new instance of the <see cref="T:Newtonsoft.Json.Linq.JToken" />. All child tokens are recursively cloned.
	/// </summary>
	/// <returns>
	///   A new instance of the <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </returns>
	public JToken DeepClone()
	{
		return CloneToken();
	}

	/// <summary>
	///   Adds an object to the annotation list of this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="annotation">The annotation to add.</param>
	public void AddAnnotation(object annotation)
	{
		if (annotation == null)
		{
			throw new ArgumentNullException("annotation");
		}
		if (_annotations == null)
		{
			_annotations = ((!(annotation is object[])) ? annotation : new object[1] { annotation });
			return;
		}
		object[] array = _annotations as object[];
		if (array == null)
		{
			_annotations = new object[2] { _annotations, annotation };
			return;
		}
		int i;
		for (i = 0; i < array.Length && array[i] != null; i++)
		{
		}
		if (i == array.Length)
		{
			Array.Resize(ref array, i * 2);
			_annotations = array;
		}
		array[i] = annotation;
	}

	/// <summary>
	///   Get the first annotation object of the specified type from this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <typeparam name="T">The type of the annotation to retrieve.</typeparam>
	/// <returns>
	///   The first annotation object that matches the specified type, or <c>null</c> if no annotation is of the specified type.
	/// </returns>
	public T Annotation<T>() where T : class
	{
		if (_annotations != null)
		{
			if (!(_annotations is object[] array))
			{
				return _annotations as T;
			}
			foreach (object obj in array)
			{
				if (obj == null)
				{
					break;
				}
				if (obj is T result)
				{
					return result;
				}
			}
		}
		return null;
	}

	/// <summary>
	///   Gets the first annotation object of the specified type from this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="type">
	///   The <see cref="P:Newtonsoft.Json.Linq.JToken.Type" /> of the annotation to retrieve.
	/// </param>
	/// <returns>
	///   The first annotation object that matches the specified type, or <c>null</c> if no annotation is of the specified type.
	/// </returns>
	public object Annotation(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (_annotations != null)
		{
			if (!(_annotations is object[] array))
			{
				if (type.IsInstanceOfType(_annotations))
				{
					return _annotations;
				}
			}
			else
			{
				foreach (object obj in array)
				{
					if (obj == null)
					{
						break;
					}
					if (type.IsInstanceOfType(obj))
					{
						return obj;
					}
				}
			}
		}
		return null;
	}

	/// <summary>
	///   Gets a collection of annotations of the specified type for this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <typeparam name="T">The type of the annotations to retrieve.</typeparam>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" />  that contains the annotations for this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </returns>
	public IEnumerable<T> Annotations<T>() where T : class
	{
		if (_annotations == null)
		{
			yield break;
		}
		if (_annotations is object[] annotations)
		{
			foreach (object obj in annotations)
			{
				if (obj != null)
				{
					if (obj is T val)
					{
						yield return val;
					}
					continue;
				}
				break;
			}
		}
		else if (_annotations is T val2)
		{
			yield return val2;
		}
	}

	/// <summary>
	///   Gets a collection of annotations of the specified type for this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="type">
	///   The <see cref="P:Newtonsoft.Json.Linq.JToken.Type" /> of the annotations to retrieve.
	/// </param>
	/// <returns>
	///   An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:System.Object" /> that contains the annotations that match the specified type for this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </returns>
	public IEnumerable<object> Annotations(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (_annotations == null)
		{
			yield break;
		}
		if (_annotations is object[] annotations)
		{
			foreach (object obj in annotations)
			{
				if (obj != null)
				{
					if (type.IsInstanceOfType(obj))
					{
						yield return obj;
					}
					continue;
				}
				break;
			}
		}
		else if (type.IsInstanceOfType(_annotations))
		{
			yield return _annotations;
		}
	}

	/// <summary>
	///   Removes the annotations of the specified type from this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <typeparam name="T">The type of annotations to remove.</typeparam>
	public void RemoveAnnotations<T>() where T : class
	{
		if (_annotations == null)
		{
			return;
		}
		if (!(_annotations is object[] array))
		{
			if (_annotations is T)
			{
				_annotations = null;
			}
			return;
		}
		int i = 0;
		int num = 0;
		for (; i < array.Length; i++)
		{
			object obj = array[i];
			if (obj == null)
			{
				break;
			}
			if (!(obj is T))
			{
				array[num++] = obj;
			}
		}
		if (num != 0)
		{
			while (num < i)
			{
				array[num++] = null;
			}
		}
		else
		{
			_annotations = null;
		}
	}

	/// <summary>
	///   Removes the annotations of the specified type from this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
	/// </summary>
	/// <param name="type">
	///   The <see cref="P:Newtonsoft.Json.Linq.JToken.Type" /> of annotations to remove.
	/// </param>
	public void RemoveAnnotations(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (_annotations == null)
		{
			return;
		}
		if (!(_annotations is object[] array))
		{
			if (type.IsInstanceOfType(_annotations))
			{
				_annotations = null;
			}
			return;
		}
		int i = 0;
		int num = 0;
		for (; i < array.Length; i++)
		{
			object obj = array[i];
			if (obj == null)
			{
				break;
			}
			if (!type.IsInstanceOfType(obj))
			{
				array[num++] = obj;
			}
		}
		if (num != 0)
		{
			while (num < i)
			{
				array[num++] = null;
			}
		}
		else
		{
			_annotations = null;
		}
	}
}
