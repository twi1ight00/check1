using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json;

/// <summary>
///   Represents a reader that provides fast, non-cached, forward-only access to serialized JSON data.
/// </summary>
public abstract class JsonReader : IDisposable
{
	/// <summary>
	///   Specifies the state of the reader.
	/// </summary>
	protected internal enum State
	{
		/// <summary>
		///   The Read method has not been called.
		/// </summary>
		Start,
		/// <summary>
		///   The end of the file has been reached successfully.
		/// </summary>
		Complete,
		/// <summary>
		///   Reader is at a property.
		/// </summary>
		Property,
		/// <summary>
		///   Reader is at the start of an object.
		/// </summary>
		ObjectStart,
		/// <summary>
		///   Reader is in an object.
		/// </summary>
		Object,
		/// <summary>
		///   Reader is at the start of an array.
		/// </summary>
		ArrayStart,
		/// <summary>
		///   Reader is in an array.
		/// </summary>
		Array,
		/// <summary>
		///   The Close method has been called.
		/// </summary>
		Closed,
		/// <summary>
		///   Reader has just read a value.
		/// </summary>
		PostValue,
		/// <summary>
		///   Reader is at the start of a constructor.
		/// </summary>
		ConstructorStart,
		/// <summary>
		///   Reader in a constructor.
		/// </summary>
		Constructor,
		/// <summary>
		///   An error occurred that prevents the read operation from continuing.
		/// </summary>
		Error,
		/// <summary>
		///   The end of the file has been reached successfully.
		/// </summary>
		Finished
	}

	private JsonToken _tokenType;

	private object _value;

	internal char _quoteChar;

	internal State _currentState;

	private JsonPosition _currentPosition;

	private CultureInfo _culture;

	private DateTimeZoneHandling _dateTimeZoneHandling;

	private int? _maxDepth;

	private bool _hasExceededMaxDepth;

	internal DateParseHandling _dateParseHandling;

	internal FloatParseHandling _floatParseHandling;

	private string _dateFormatString;

	private List<JsonPosition> _stack;

	/// <summary>
	///   Gets the current reader state.
	/// </summary>
	/// <value>The current reader state.</value>
	protected State CurrentState => _currentState;

	/// <summary>
	///   Gets or sets a value indicating whether the underlying stream or
	///   <see cref="T:System.IO.TextReader" /> should be closed when the reader is closed.
	/// </summary>
	/// <value>
	///   true to close the underlying stream or <see cref="T:System.IO.TextReader" /> when
	///   the reader is closed; otherwise false. The default is true.
	/// </value>
	public bool CloseInput { get; set; }

	/// <summary>
	///   Gets or sets a value indicating whether multiple pieces of JSON content can
	///   be read from a continuous stream without erroring.
	/// </summary>
	/// <value>
	///   true to support reading multiple pieces of JSON content; otherwise false. The default is false.
	/// </value>
	public bool SupportMultipleContent { get; set; }

	/// <summary>
	///   Gets the quotation mark character used to enclose the value of a string.
	/// </summary>
	public virtual char QuoteChar
	{
		get
		{
			return _quoteChar;
		}
		protected internal set
		{
			_quoteChar = value;
		}
	}

	/// <summary>
	///   Get or set how <see cref="T:System.DateTime" /> time zones are handling when reading JSON.
	/// </summary>
	public DateTimeZoneHandling DateTimeZoneHandling
	{
		get
		{
			return _dateTimeZoneHandling;
		}
		set
		{
			if (value < DateTimeZoneHandling.Local || value > DateTimeZoneHandling.RoundtripKind)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			_dateTimeZoneHandling = value;
		}
	}

	/// <summary>
	///   Get or set how date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed when reading JSON.
	/// </summary>
	public DateParseHandling DateParseHandling
	{
		get
		{
			return _dateParseHandling;
		}
		set
		{
			if (value < DateParseHandling.None || value > DateParseHandling.DateTimeOffset)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			_dateParseHandling = value;
		}
	}

	/// <summary>
	///   Get or set how floating point numbers, e.g. 1.0 and 9.9, are parsed when reading JSON text.
	/// </summary>
	public FloatParseHandling FloatParseHandling
	{
		get
		{
			return _floatParseHandling;
		}
		set
		{
			if (value < FloatParseHandling.Double || value > FloatParseHandling.Decimal)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			_floatParseHandling = value;
		}
	}

	/// <summary>
	///   Get or set how custom date formatted strings are parsed when reading JSON.
	/// </summary>
	public string DateFormatString
	{
		get
		{
			return _dateFormatString;
		}
		set
		{
			_dateFormatString = value;
		}
	}

	/// <summary>
	///   Gets or sets the maximum depth allowed when reading JSON. Reading past this depth will throw a <see cref="T:Newtonsoft.Json.JsonReaderException" />.
	/// </summary>
	public int? MaxDepth
	{
		get
		{
			return _maxDepth;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentException("Value must be positive.", "value");
			}
			_maxDepth = value;
		}
	}

	/// <summary>
	///   Gets the type of the current JSON token.
	/// </summary>
	public virtual JsonToken TokenType => _tokenType;

	/// <summary>
	///   Gets the text value of the current JSON token.
	/// </summary>
	public virtual object Value => _value;

	/// <summary>
	///   Gets The Common Language Runtime (CLR) type for the current JSON token.
	/// </summary>
	public virtual Type ValueType
	{
		get
		{
			if (_value == null)
			{
				return null;
			}
			return _value.GetType();
		}
	}

	/// <summary>
	///   Gets the depth of the current token in the JSON document.
	/// </summary>
	/// <value>The depth of the current token in the JSON document.</value>
	public virtual int Depth
	{
		get
		{
			int num = ((_stack != null) ? _stack.Count : 0);
			if (JsonTokenUtils.IsStartToken(TokenType) || _currentPosition.Type == JsonContainerType.None)
			{
				return num;
			}
			return num + 1;
		}
	}

	/// <summary>
	///   Gets the path of the current JSON token.
	/// </summary>
	public virtual string Path
	{
		get
		{
			if (_currentPosition.Type == JsonContainerType.None)
			{
				return string.Empty;
			}
			JsonPosition? currentPosition = ((_currentState != State.ArrayStart && _currentState != State.ConstructorStart && _currentState != State.ObjectStart) ? new JsonPosition?(_currentPosition) : null);
			return JsonPosition.BuildPath(_stack, currentPosition);
		}
	}

	/// <summary>
	///   Gets or sets the culture used when reading JSON. Defaults to <see cref="P:System.Globalization.CultureInfo.InvariantCulture" />.
	/// </summary>
	public CultureInfo Culture
	{
		get
		{
			return _culture ?? CultureInfo.InvariantCulture;
		}
		set
		{
			_culture = value;
		}
	}

	internal JsonPosition GetPosition(int depth)
	{
		if (_stack != null && depth < _stack.Count)
		{
			return _stack[depth];
		}
		return _currentPosition;
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.JsonReader" /> class with the specified <see cref="T:System.IO.TextReader" />.
	/// </summary>
	protected JsonReader()
	{
		_currentState = State.Start;
		_dateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
		_dateParseHandling = DateParseHandling.DateTime;
		_floatParseHandling = FloatParseHandling.Double;
		CloseInput = true;
	}

	private void Push(JsonContainerType value)
	{
		UpdateScopeWithFinishedValue();
		if (_currentPosition.Type == JsonContainerType.None)
		{
			_currentPosition = new JsonPosition(value);
			return;
		}
		if (_stack == null)
		{
			_stack = new List<JsonPosition>();
		}
		_stack.Add(_currentPosition);
		_currentPosition = new JsonPosition(value);
		if (_maxDepth.HasValue)
		{
			int num = Depth + 1;
			int? maxDepth = _maxDepth;
			if (num > maxDepth.GetValueOrDefault() && maxDepth.HasValue && !_hasExceededMaxDepth)
			{
				_hasExceededMaxDepth = true;
				throw JsonReaderException.Create(this, "The reader's MaxDepth of {0} has been exceeded.".FormatWith(CultureInfo.InvariantCulture, _maxDepth));
			}
		}
	}

	private JsonContainerType Pop()
	{
		JsonPosition currentPosition;
		if (_stack != null && _stack.Count > 0)
		{
			currentPosition = _currentPosition;
			_currentPosition = _stack[_stack.Count - 1];
			_stack.RemoveAt(_stack.Count - 1);
		}
		else
		{
			currentPosition = _currentPosition;
			_currentPosition = default(JsonPosition);
		}
		if (_maxDepth.HasValue && Depth <= _maxDepth)
		{
			_hasExceededMaxDepth = false;
		}
		return currentPosition.Type;
	}

	private JsonContainerType Peek()
	{
		return _currentPosition.Type;
	}

	/// <summary>
	///   Reads the next JSON token from the stream.
	/// </summary>
	/// <returns>
	///   <c>true</c> if the next token was read successfully; <c>false</c> if there are no more tokens to read.
	/// </returns>
	public abstract bool Read();

	/// <summary>
	///   Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.
	/// </returns>
	public virtual int? ReadAsInt32()
	{
		JsonToken contentToken = GetContentToken();
		switch (contentToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Integer:
		case JsonToken.Float:
			if (!(Value is int))
			{
				SetToken(JsonToken.Integer, Convert.ToInt32(Value, CultureInfo.InvariantCulture), updateIndex: false);
			}
			return (int)Value;
		case JsonToken.String:
		{
			string s = (string)Value;
			return ReadInt32String(s);
		}
		default:
			throw JsonReaderException.Create(this, "Error reading integer. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, contentToken));
		}
	}

	internal int? ReadInt32String(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (int.TryParse(s, NumberStyles.Integer, Culture, out var result))
		{
			SetToken(JsonToken.Integer, result, updateIndex: false);
			return result;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw JsonReaderException.Create(this, "Could not convert string to integer: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	/// <summary>
	///   Reads the next JSON token from the stream as a <see cref="T:System.String" />.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.String" />. This method will return <c>null</c> at the end of an array.
	/// </returns>
	public virtual string ReadAsString()
	{
		JsonToken contentToken = GetContentToken();
		switch (contentToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.String:
			return (string)Value;
		default:
			if (JsonTokenUtils.IsPrimitiveToken(contentToken) && Value != null)
			{
				string text = ((Value is IFormattable) ? ((IFormattable)Value).ToString(null, Culture) : ((!(Value is Uri)) ? Value.ToString() : ((Uri)Value).OriginalString));
				SetToken(JsonToken.String, text, updateIndex: false);
				return text;
			}
			throw JsonReaderException.Create(this, "Error reading string. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, contentToken));
		}
	}

	/// <summary>
	///   Reads the next JSON token from the stream as a <see cref="T:System.Byte" />[].
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Byte" />[] or a null reference if the next JSON token is null. This method will return <c>null</c> at the end of an array.
	/// </returns>
	public virtual byte[] ReadAsBytes()
	{
		JsonToken contentToken = GetContentToken();
		if (contentToken == JsonToken.None)
		{
			return null;
		}
		if (TokenType == JsonToken.StartObject)
		{
			ReadIntoWrappedTypeObject();
			byte[] array = ReadAsBytes();
			ReaderReadAndAssert();
			if (TokenType != JsonToken.EndObject)
			{
				throw JsonReaderException.Create(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, TokenType));
			}
			SetToken(JsonToken.Bytes, array, updateIndex: false);
			return array;
		}
		switch (contentToken)
		{
		case JsonToken.String:
		{
			string text = (string)Value;
			Guid g;
			byte[] array3 = ((text.Length == 0) ? new byte[0] : ((!ConvertUtils.TryConvertGuid(text, out g)) ? Convert.FromBase64String(text) : g.ToByteArray()));
			SetToken(JsonToken.Bytes, array3, updateIndex: false);
			return array3;
		}
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Bytes:
			if (ValueType == typeof(Guid))
			{
				byte[] array2 = ((Guid)Value).ToByteArray();
				SetToken(JsonToken.Bytes, array2, updateIndex: false);
				return array2;
			}
			return (byte[])Value;
		case JsonToken.StartArray:
			return ReadArrayIntoByteArray();
		default:
			throw JsonReaderException.Create(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, contentToken));
		}
	}

	internal byte[] ReadArrayIntoByteArray()
	{
		List<byte> list = new List<byte>();
		while (true)
		{
			JsonToken contentToken = GetContentToken();
			switch (contentToken)
			{
			case JsonToken.None:
				throw JsonReaderException.Create(this, "Unexpected end when reading bytes.");
			case JsonToken.Integer:
				break;
			case JsonToken.EndArray:
			{
				byte[] array = list.ToArray();
				SetToken(JsonToken.Bytes, array, updateIndex: false);
				return array;
			}
			default:
				throw JsonReaderException.Create(this, "Unexpected token when reading bytes: {0}.".FormatWith(CultureInfo.InvariantCulture, contentToken));
			}
			list.Add(Convert.ToByte(Value, CultureInfo.InvariantCulture));
		}
	}

	/// <summary>
	///   Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.
	/// </returns>
	public virtual double? ReadAsDouble()
	{
		JsonToken contentToken = GetContentToken();
		switch (contentToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Integer:
		case JsonToken.Float:
			if (!(Value is double))
			{
				double num = ((!(Value is BigInteger)) ? Convert.ToDouble(Value, CultureInfo.InvariantCulture) : ((double)(BigInteger)Value));
				SetToken(JsonToken.Float, num, updateIndex: false);
			}
			return (double)Value;
		case JsonToken.String:
			return ReadDoubleString((string)Value);
		default:
			throw JsonReaderException.Create(this, "Error reading double. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, contentToken));
		}
	}

	internal double? ReadDoubleString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, Culture, out var result))
		{
			SetToken(JsonToken.Float, result, updateIndex: false);
			return result;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw JsonReaderException.Create(this, "Could not convert string to double: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	/// <summary>
	///   Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.
	/// </returns>
	public virtual bool? ReadAsBoolean()
	{
		JsonToken contentToken = GetContentToken();
		switch (contentToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Integer:
		case JsonToken.Float:
		{
			bool flag = ((!(Value is BigInteger)) ? Convert.ToBoolean(Value, CultureInfo.InvariantCulture) : ((BigInteger)Value != 0L));
			SetToken(JsonToken.Boolean, flag, updateIndex: false);
			return flag;
		}
		case JsonToken.String:
			return ReadBooleanString((string)Value);
		case JsonToken.Boolean:
			return (bool)Value;
		default:
			throw JsonReaderException.Create(this, "Error reading boolean. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, contentToken));
		}
	}

	internal bool? ReadBooleanString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (bool.TryParse(s, out var result))
		{
			SetToken(JsonToken.Boolean, result, updateIndex: false);
			return result;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw JsonReaderException.Create(this, "Could not convert string to boolean: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	/// <summary>
	///   Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.
	/// </returns>
	public virtual decimal? ReadAsDecimal()
	{
		JsonToken contentToken = GetContentToken();
		switch (contentToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Integer:
		case JsonToken.Float:
			if (!(Value is decimal))
			{
				SetToken(JsonToken.Float, Convert.ToDecimal(Value, CultureInfo.InvariantCulture), updateIndex: false);
			}
			return (decimal)Value;
		case JsonToken.String:
			return ReadDecimalString((string)Value);
		default:
			throw JsonReaderException.Create(this, "Error reading decimal. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, contentToken));
		}
	}

	internal decimal? ReadDecimalString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (decimal.TryParse(s, NumberStyles.Number, Culture, out var result))
		{
			SetToken(JsonToken.Float, result, updateIndex: false);
			return result;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw JsonReaderException.Create(this, "Could not convert string to decimal: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	/// <summary>
	///   Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.
	/// </returns>
	public virtual DateTime? ReadAsDateTime()
	{
		switch (GetContentToken())
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Date:
			if (Value is DateTimeOffset)
			{
				SetToken(JsonToken.Date, ((DateTimeOffset)Value).DateTime, updateIndex: false);
			}
			return (DateTime)Value;
		case JsonToken.String:
		{
			string s = (string)Value;
			return ReadDateTimeString(s);
		}
		default:
			throw JsonReaderException.Create(this, "Error reading date. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, TokenType));
		}
	}

	internal DateTime? ReadDateTimeString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (DateTimeUtils.TryParseDateTime(s, DateTimeZoneHandling, _dateFormatString, Culture, out var dt))
		{
			dt = DateTimeUtils.EnsureDateTime(dt, DateTimeZoneHandling);
			SetToken(JsonToken.Date, dt, updateIndex: false);
			return dt;
		}
		if (DateTime.TryParse(s, Culture, DateTimeStyles.RoundtripKind, out dt))
		{
			dt = DateTimeUtils.EnsureDateTime(dt, DateTimeZoneHandling);
			SetToken(JsonToken.Date, dt, updateIndex: false);
			return dt;
		}
		throw JsonReaderException.Create(this, "Could not convert string to DateTime: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	/// <summary>
	///   Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
	/// </summary>
	/// <returns>
	///   A <see cref="T:System.Nullable`1" />. This method will return <c>null</c> at the end of an array.
	/// </returns>
	public virtual DateTimeOffset? ReadAsDateTimeOffset()
	{
		JsonToken contentToken = GetContentToken();
		switch (contentToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Date:
			if (Value is DateTime)
			{
				SetToken(JsonToken.Date, new DateTimeOffset((DateTime)Value), updateIndex: false);
			}
			return (DateTimeOffset)Value;
		case JsonToken.String:
		{
			string s = (string)Value;
			return ReadDateTimeOffsetString(s);
		}
		default:
			throw JsonReaderException.Create(this, "Error reading date. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, contentToken));
		}
	}

	internal DateTimeOffset? ReadDateTimeOffsetString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (DateTimeUtils.TryParseDateTimeOffset(s, _dateFormatString, Culture, out var dt))
		{
			SetToken(JsonToken.Date, dt, updateIndex: false);
			return dt;
		}
		if (DateTimeOffset.TryParse(s, Culture, DateTimeStyles.RoundtripKind, out dt))
		{
			SetToken(JsonToken.Date, dt, updateIndex: false);
			return dt;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw JsonReaderException.Create(this, "Could not convert string to DateTimeOffset: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	internal void ReaderReadAndAssert()
	{
		if (!Read())
		{
			throw CreateUnexpectedEndException();
		}
	}

	internal JsonReaderException CreateUnexpectedEndException()
	{
		return JsonReaderException.Create(this, "Unexpected end when reading JSON.");
	}

	internal void ReadIntoWrappedTypeObject()
	{
		ReaderReadAndAssert();
		if (Value.ToString() == "$type")
		{
			ReaderReadAndAssert();
			if (Value != null && Value.ToString().StartsWith("System.Byte[]", StringComparison.Ordinal))
			{
				ReaderReadAndAssert();
				if (Value.ToString() == "$value")
				{
					return;
				}
			}
		}
		throw JsonReaderException.Create(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, JsonToken.StartObject));
	}

	/// <summary>
	///   Skips the children of the current token.
	/// </summary>
	public void Skip()
	{
		if (TokenType == JsonToken.PropertyName)
		{
			Read();
		}
		if (JsonTokenUtils.IsStartToken(TokenType))
		{
			int depth = Depth;
			while (Read() && depth < Depth)
			{
			}
		}
	}

	/// <summary>
	///   Sets the current token.
	/// </summary>
	/// <param name="newToken">The new token.</param>
	protected void SetToken(JsonToken newToken)
	{
		SetToken(newToken, null, updateIndex: true);
	}

	/// <summary>
	///   Sets the current token and value.
	/// </summary>
	/// <param name="newToken">The new token.</param>
	/// <param name="value">The value.</param>
	protected void SetToken(JsonToken newToken, object value)
	{
		SetToken(newToken, value, updateIndex: true);
	}

	internal void SetToken(JsonToken newToken, object value, bool updateIndex)
	{
		_tokenType = newToken;
		_value = value;
		switch (newToken)
		{
		case JsonToken.StartObject:
			_currentState = State.ObjectStart;
			Push(JsonContainerType.Object);
			break;
		case JsonToken.StartArray:
			_currentState = State.ArrayStart;
			Push(JsonContainerType.Array);
			break;
		case JsonToken.StartConstructor:
			_currentState = State.ConstructorStart;
			Push(JsonContainerType.Constructor);
			break;
		case JsonToken.EndObject:
			ValidateEnd(JsonToken.EndObject);
			break;
		case JsonToken.EndArray:
			ValidateEnd(JsonToken.EndArray);
			break;
		case JsonToken.EndConstructor:
			ValidateEnd(JsonToken.EndConstructor);
			break;
		case JsonToken.PropertyName:
			_currentState = State.Property;
			_currentPosition.PropertyName = (string)value;
			break;
		case JsonToken.Raw:
		case JsonToken.Integer:
		case JsonToken.Float:
		case JsonToken.String:
		case JsonToken.Boolean:
		case JsonToken.Null:
		case JsonToken.Undefined:
		case JsonToken.Date:
		case JsonToken.Bytes:
			SetPostValueState(updateIndex);
			break;
		case JsonToken.Comment:
			break;
		}
	}

	internal void SetPostValueState(bool updateIndex)
	{
		if (Peek() != 0)
		{
			_currentState = State.PostValue;
		}
		else
		{
			SetFinished();
		}
		if (updateIndex)
		{
			UpdateScopeWithFinishedValue();
		}
	}

	private void UpdateScopeWithFinishedValue()
	{
		if (_currentPosition.HasIndex)
		{
			_currentPosition.Position++;
		}
	}

	private void ValidateEnd(JsonToken endToken)
	{
		JsonContainerType jsonContainerType = Pop();
		if (GetTypeForCloseToken(endToken) != jsonContainerType)
		{
			throw JsonReaderException.Create(this, "JsonToken {0} is not valid for closing JsonType {1}.".FormatWith(CultureInfo.InvariantCulture, endToken, jsonContainerType));
		}
		if (Peek() != 0)
		{
			_currentState = State.PostValue;
		}
		else
		{
			SetFinished();
		}
	}

	/// <summary>
	///   Sets the state based on current token type.
	/// </summary>
	protected void SetStateBasedOnCurrent()
	{
		JsonContainerType jsonContainerType = Peek();
		switch (jsonContainerType)
		{
		case JsonContainerType.Object:
			_currentState = State.Object;
			break;
		case JsonContainerType.Array:
			_currentState = State.Array;
			break;
		case JsonContainerType.Constructor:
			_currentState = State.Constructor;
			break;
		case JsonContainerType.None:
			SetFinished();
			break;
		default:
			throw JsonReaderException.Create(this, "While setting the reader state back to current object an unexpected JsonType was encountered: {0}".FormatWith(CultureInfo.InvariantCulture, jsonContainerType));
		}
	}

	private void SetFinished()
	{
		if (SupportMultipleContent)
		{
			_currentState = State.Start;
		}
		else
		{
			_currentState = State.Finished;
		}
	}

	private JsonContainerType GetTypeForCloseToken(JsonToken token)
	{
		return token switch
		{
			JsonToken.EndObject => JsonContainerType.Object, 
			JsonToken.EndArray => JsonContainerType.Array, 
			JsonToken.EndConstructor => JsonContainerType.Constructor, 
			_ => throw JsonReaderException.Create(this, "Not a valid close JsonToken: {0}".FormatWith(CultureInfo.InvariantCulture, token)), 
		};
	}

	/// <summary>
	///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	/// </summary>
	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	///   Releases unmanaged and - optionally - managed resources
	/// </summary>
	/// <param name="disposing">
	///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (_currentState != State.Closed && disposing)
		{
			Close();
		}
	}

	/// <summary>
	///   Changes the <see cref="T:Newtonsoft.Json.JsonReader.State" /> to Closed.
	/// </summary>
	public virtual void Close()
	{
		_currentState = State.Closed;
		_tokenType = JsonToken.None;
		_value = null;
	}

	internal void ReadAndAssert()
	{
		if (!Read())
		{
			throw JsonSerializationException.Create(this, "Unexpected end when reading JSON.");
		}
	}

	internal bool ReadAndMoveToContent()
	{
		if (Read())
		{
			return MoveToContent();
		}
		return false;
	}

	internal bool MoveToContent()
	{
		JsonToken tokenType = TokenType;
		while (tokenType == JsonToken.None || tokenType == JsonToken.Comment)
		{
			if (!Read())
			{
				return false;
			}
			tokenType = TokenType;
		}
		return true;
	}

	private JsonToken GetContentToken()
	{
		JsonToken tokenType;
		do
		{
			if (!Read())
			{
				SetToken(JsonToken.None);
				return JsonToken.None;
			}
			tokenType = TokenType;
		}
		while (tokenType == JsonToken.Comment);
		return tokenType;
	}
}
