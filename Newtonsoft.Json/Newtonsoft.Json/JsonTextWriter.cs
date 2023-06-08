using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json;

/// <summary>
///   Represents a writer that provides a fast, non-cached, forward-only way of generating JSON data.
/// </summary>
public class JsonTextWriter : JsonWriter
{
	private readonly TextWriter _writer;

	private Base64Encoder _base64Encoder;

	private char _indentChar;

	private int _indentation;

	private char _quoteChar;

	private bool _quoteName;

	private bool[] _charEscapeFlags;

	private char[] _writeBuffer;

	private IArrayPool<char> _arrayPool;

	private char[] _indentChars;

	private Base64Encoder Base64Encoder
	{
		get
		{
			if (_base64Encoder == null)
			{
				_base64Encoder = new Base64Encoder(_writer);
			}
			return _base64Encoder;
		}
	}

	/// <summary>
	///   Gets or sets the writer's character array pool.
	/// </summary>
	public IArrayPool<char> ArrayPool
	{
		get
		{
			return _arrayPool;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_arrayPool = value;
		}
	}

	/// <summary>
	///   Gets or sets how many IndentChars to write for each level in the hierarchy when <see cref="T:Newtonsoft.Json.Formatting" /> is set to <c>Formatting.Indented</c>.
	/// </summary>
	public int Indentation
	{
		get
		{
			return _indentation;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Indentation value must be greater than 0.");
			}
			_indentation = value;
		}
	}

	/// <summary>
	///   Gets or sets which character to use to quote attribute values.
	/// </summary>
	public char QuoteChar
	{
		get
		{
			return _quoteChar;
		}
		set
		{
			if (value != '"' && value != '\'')
			{
				throw new ArgumentException("Invalid JavaScript string quote character. Valid quote characters are ' and \".");
			}
			_quoteChar = value;
			UpdateCharEscapeFlags();
		}
	}

	/// <summary>
	///   Gets or sets which character to use for indenting when <see cref="T:Newtonsoft.Json.Formatting" /> is set to <c>Formatting.Indented</c>.
	/// </summary>
	public char IndentChar
	{
		get
		{
			return _indentChar;
		}
		set
		{
			if (value != _indentChar)
			{
				_indentChar = value;
				_indentChars = null;
			}
		}
	}

	/// <summary>
	///   Gets or sets a value indicating whether object names will be surrounded with quotes.
	/// </summary>
	public bool QuoteName
	{
		get
		{
			return _quoteName;
		}
		set
		{
			_quoteName = value;
		}
	}

	/// <summary>
	///   Creates an instance of the <c>JsonWriter</c> class using the specified <see cref="T:System.IO.TextWriter" />.
	/// </summary>
	/// <param name="textWriter">
	///   The <c>TextWriter</c> to write to.
	/// </param>
	public JsonTextWriter(TextWriter textWriter)
	{
		if (textWriter == null)
		{
			throw new ArgumentNullException("textWriter");
		}
		_writer = textWriter;
		_quoteChar = '"';
		_quoteName = true;
		_indentChar = ' ';
		_indentation = 2;
		UpdateCharEscapeFlags();
	}

	/// <summary>
	///   Flushes whatever is in the buffer to the underlying streams and also flushes the underlying stream.
	/// </summary>
	public override void Flush()
	{
		_writer.Flush();
	}

	/// <summary>
	///   Closes this stream and the underlying stream.
	/// </summary>
	public override void Close()
	{
		base.Close();
		if (_writeBuffer != null)
		{
			BufferUtils.ReturnBuffer(_arrayPool, _writeBuffer);
			_writeBuffer = null;
		}
		if (base.CloseOutput && _writer != null)
		{
			_writer.Close();
		}
	}

	/// <summary>
	///   Writes the beginning of a JSON object.
	/// </summary>
	public override void WriteStartObject()
	{
		InternalWriteStart(JsonToken.StartObject, JsonContainerType.Object);
		_writer.Write('{');
	}

	/// <summary>
	///   Writes the beginning of a JSON array.
	/// </summary>
	public override void WriteStartArray()
	{
		InternalWriteStart(JsonToken.StartArray, JsonContainerType.Array);
		_writer.Write('[');
	}

	/// <summary>
	///   Writes the start of a constructor with the given name.
	/// </summary>
	/// <param name="name">The name of the constructor.</param>
	public override void WriteStartConstructor(string name)
	{
		InternalWriteStart(JsonToken.StartConstructor, JsonContainerType.Constructor);
		_writer.Write("new ");
		_writer.Write(name);
		_writer.Write('(');
	}

	/// <summary>
	///   Writes the specified end token.
	/// </summary>
	/// <param name="token">The end token to write.</param>
	protected override void WriteEnd(JsonToken token)
	{
		switch (token)
		{
		case JsonToken.EndObject:
			_writer.Write('}');
			break;
		case JsonToken.EndArray:
			_writer.Write(']');
			break;
		case JsonToken.EndConstructor:
			_writer.Write(')');
			break;
		default:
			throw JsonWriterException.Create(this, "Invalid JsonToken: " + token, null);
		}
	}

	/// <summary>
	///   Writes the property name of a name/value pair on a JSON object.
	/// </summary>
	/// <param name="name">The name of the property.</param>
	public override void WritePropertyName(string name)
	{
		InternalWritePropertyName(name);
		WriteEscapedString(name, _quoteName);
		_writer.Write(':');
	}

	/// <summary>
	///   Writes the property name of a name/value pair on a JSON object.
	/// </summary>
	/// <param name="name">The name of the property.</param>
	/// <param name="escape">A flag to indicate whether the text should be escaped when it is written as a JSON property name.</param>
	public override void WritePropertyName(string name, bool escape)
	{
		InternalWritePropertyName(name);
		if (escape)
		{
			WriteEscapedString(name, _quoteName);
		}
		else
		{
			if (_quoteName)
			{
				_writer.Write(_quoteChar);
			}
			_writer.Write(name);
			if (_quoteName)
			{
				_writer.Write(_quoteChar);
			}
		}
		_writer.Write(':');
	}

	internal override void OnStringEscapeHandlingChanged()
	{
		UpdateCharEscapeFlags();
	}

	private void UpdateCharEscapeFlags()
	{
		_charEscapeFlags = JavaScriptUtils.GetCharEscapeFlags(base.StringEscapeHandling, _quoteChar);
	}

	/// <summary>
	///   Writes indent characters.
	/// </summary>
	protected override void WriteIndent()
	{
		_writer.WriteLine();
		int num = base.Top * _indentation;
		if (num > 0)
		{
			if (_indentChars == null)
			{
				_indentChars = new string(_indentChar, 10).ToCharArray();
			}
			while (num > 0)
			{
				int num2 = Math.Min(num, 10);
				_writer.Write(_indentChars, 0, num2);
				num -= num2;
			}
		}
	}

	/// <summary>
	///   Writes the JSON value delimiter.
	/// </summary>
	protected override void WriteValueDelimiter()
	{
		_writer.Write(',');
	}

	/// <summary>
	///   Writes an indent space.
	/// </summary>
	protected override void WriteIndentSpace()
	{
		_writer.Write(' ');
	}

	private void WriteValueInternal(string value, JsonToken token)
	{
		_writer.Write(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Object" /> value.
	///   An error will raised if the value cannot be written as a single JSON token.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Object" /> value to write.
	/// </param>
	public override void WriteValue(object value)
	{
		if (value is BigInteger)
		{
			InternalWriteValue(JsonToken.Integer);
			WriteValueInternal(((BigInteger)value).ToString(CultureInfo.InvariantCulture), JsonToken.String);
		}
		else
		{
			base.WriteValue(value);
		}
	}

	/// <summary>
	///   Writes a null value.
	/// </summary>
	public override void WriteNull()
	{
		InternalWriteValue(JsonToken.Null);
		WriteValueInternal(JsonConvert.Null, JsonToken.Null);
	}

	/// <summary>
	///   Writes an undefined value.
	/// </summary>
	public override void WriteUndefined()
	{
		InternalWriteValue(JsonToken.Undefined);
		WriteValueInternal(JsonConvert.Undefined, JsonToken.Undefined);
	}

	/// <summary>
	///   Writes raw JSON.
	/// </summary>
	/// <param name="json">The raw JSON to write.</param>
	public override void WriteRaw(string json)
	{
		InternalWriteRaw();
		_writer.Write(json);
	}

	/// <summary>
	///   Writes a <see cref="T:System.String" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.String" /> value to write.
	/// </param>
	public override void WriteValue(string value)
	{
		InternalWriteValue(JsonToken.String);
		if (value == null)
		{
			WriteValueInternal(JsonConvert.Null, JsonToken.Null);
		}
		else
		{
			WriteEscapedString(value, quote: true);
		}
	}

	private void WriteEscapedString(string value, bool quote)
	{
		EnsureWriteBuffer();
		JavaScriptUtils.WriteEscapedJavaScriptString(_writer, value, _quoteChar, quote, _charEscapeFlags, base.StringEscapeHandling, _arrayPool, ref _writeBuffer);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Int32" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Int32" /> value to write.
	/// </param>
	public override void WriteValue(int value)
	{
		InternalWriteValue(JsonToken.Integer);
		WriteIntegerValue(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.UInt32" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.UInt32" /> value to write.
	/// </param>
	[CLSCompliant(false)]
	public override void WriteValue(uint value)
	{
		InternalWriteValue(JsonToken.Integer);
		WriteIntegerValue(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Int64" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Int64" /> value to write.
	/// </param>
	public override void WriteValue(long value)
	{
		InternalWriteValue(JsonToken.Integer);
		WriteIntegerValue(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.UInt64" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.UInt64" /> value to write.
	/// </param>
	[CLSCompliant(false)]
	public override void WriteValue(ulong value)
	{
		InternalWriteValue(JsonToken.Integer);
		WriteIntegerValue(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Single" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Single" /> value to write.
	/// </param>
	public override void WriteValue(float value)
	{
		InternalWriteValue(JsonToken.Float);
		WriteValueInternal(JsonConvert.ToString(value, base.FloatFormatHandling, QuoteChar, nullable: false), JsonToken.Float);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Nullable`1" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Nullable`1" /> value to write.
	/// </param>
	public override void WriteValue(float? value)
	{
		if (!value.HasValue)
		{
			WriteNull();
			return;
		}
		InternalWriteValue(JsonToken.Float);
		WriteValueInternal(JsonConvert.ToString(value.GetValueOrDefault(), base.FloatFormatHandling, QuoteChar, nullable: true), JsonToken.Float);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Double" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Double" /> value to write.
	/// </param>
	public override void WriteValue(double value)
	{
		InternalWriteValue(JsonToken.Float);
		WriteValueInternal(JsonConvert.ToString(value, base.FloatFormatHandling, QuoteChar, nullable: false), JsonToken.Float);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Nullable`1" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Nullable`1" /> value to write.
	/// </param>
	public override void WriteValue(double? value)
	{
		if (!value.HasValue)
		{
			WriteNull();
			return;
		}
		InternalWriteValue(JsonToken.Float);
		WriteValueInternal(JsonConvert.ToString(value.GetValueOrDefault(), base.FloatFormatHandling, QuoteChar, nullable: true), JsonToken.Float);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Boolean" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Boolean" /> value to write.
	/// </param>
	public override void WriteValue(bool value)
	{
		InternalWriteValue(JsonToken.Boolean);
		WriteValueInternal(JsonConvert.ToString(value), JsonToken.Boolean);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Int16" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Int16" /> value to write.
	/// </param>
	public override void WriteValue(short value)
	{
		InternalWriteValue(JsonToken.Integer);
		WriteIntegerValue(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.UInt16" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.UInt16" /> value to write.
	/// </param>
	[CLSCompliant(false)]
	public override void WriteValue(ushort value)
	{
		InternalWriteValue(JsonToken.Integer);
		WriteIntegerValue(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Char" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Char" /> value to write.
	/// </param>
	public override void WriteValue(char value)
	{
		InternalWriteValue(JsonToken.String);
		WriteValueInternal(JsonConvert.ToString(value), JsonToken.String);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Byte" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Byte" /> value to write.
	/// </param>
	public override void WriteValue(byte value)
	{
		InternalWriteValue(JsonToken.Integer);
		WriteIntegerValue(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.SByte" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.SByte" /> value to write.
	/// </param>
	[CLSCompliant(false)]
	public override void WriteValue(sbyte value)
	{
		InternalWriteValue(JsonToken.Integer);
		WriteIntegerValue(value);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Decimal" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Decimal" /> value to write.
	/// </param>
	public override void WriteValue(decimal value)
	{
		InternalWriteValue(JsonToken.Float);
		WriteValueInternal(JsonConvert.ToString(value), JsonToken.Float);
	}

	/// <summary>
	///   Writes a <see cref="T:System.DateTime" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.DateTime" /> value to write.
	/// </param>
	public override void WriteValue(DateTime value)
	{
		InternalWriteValue(JsonToken.Date);
		value = DateTimeUtils.EnsureDateTime(value, base.DateTimeZoneHandling);
		if (string.IsNullOrEmpty(base.DateFormatString))
		{
			EnsureWriteBuffer();
			int start = 0;
			_writeBuffer[start++] = _quoteChar;
			start = DateTimeUtils.WriteDateTimeString(_writeBuffer, start, value, null, value.Kind, base.DateFormatHandling);
			_writeBuffer[start++] = _quoteChar;
			_writer.Write(_writeBuffer, 0, start);
		}
		else
		{
			_writer.Write(_quoteChar);
			_writer.Write(value.ToString(base.DateFormatString, base.Culture));
			_writer.Write(_quoteChar);
		}
	}

	/// <summary>
	///   Writes a <see cref="T:System.Byte" />[] value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Byte" />[] value to write.
	/// </param>
	public override void WriteValue(byte[] value)
	{
		if (value == null)
		{
			WriteNull();
			return;
		}
		InternalWriteValue(JsonToken.Bytes);
		_writer.Write(_quoteChar);
		Base64Encoder.Encode(value, 0, value.Length);
		Base64Encoder.Flush();
		_writer.Write(_quoteChar);
	}

	/// <summary>
	///   Writes a <see cref="T:System.DateTimeOffset" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.DateTimeOffset" /> value to write.
	/// </param>
	public override void WriteValue(DateTimeOffset value)
	{
		InternalWriteValue(JsonToken.Date);
		if (string.IsNullOrEmpty(base.DateFormatString))
		{
			EnsureWriteBuffer();
			int start = 0;
			_writeBuffer[start++] = _quoteChar;
			start = DateTimeUtils.WriteDateTimeString(_writeBuffer, start, (base.DateFormatHandling == DateFormatHandling.IsoDateFormat) ? value.DateTime : value.UtcDateTime, value.Offset, DateTimeKind.Local, base.DateFormatHandling);
			_writeBuffer[start++] = _quoteChar;
			_writer.Write(_writeBuffer, 0, start);
		}
		else
		{
			_writer.Write(_quoteChar);
			_writer.Write(value.ToString(base.DateFormatString, base.Culture));
			_writer.Write(_quoteChar);
		}
	}

	/// <summary>
	///   Writes a <see cref="T:System.Guid" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Guid" /> value to write.
	/// </param>
	public override void WriteValue(Guid value)
	{
		InternalWriteValue(JsonToken.String);
		string text = null;
		text = value.ToString("D", CultureInfo.InvariantCulture);
		_writer.Write(_quoteChar);
		_writer.Write(text);
		_writer.Write(_quoteChar);
	}

	/// <summary>
	///   Writes a <see cref="T:System.TimeSpan" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.TimeSpan" /> value to write.
	/// </param>
	public override void WriteValue(TimeSpan value)
	{
		InternalWriteValue(JsonToken.String);
		string value2 = value.ToString(null, CultureInfo.InvariantCulture);
		_writer.Write(_quoteChar);
		_writer.Write(value2);
		_writer.Write(_quoteChar);
	}

	/// <summary>
	///   Writes a <see cref="T:System.Uri" /> value.
	/// </summary>
	/// <param name="value">
	///   The <see cref="T:System.Uri" /> value to write.
	/// </param>
	public override void WriteValue(Uri value)
	{
		if (value == null)
		{
			WriteNull();
			return;
		}
		InternalWriteValue(JsonToken.String);
		WriteEscapedString(value.OriginalString, quote: true);
	}

	/// <summary>
	///   Writes out a comment <code>/*...*/</code> containing the specified text.
	/// </summary>
	/// <param name="text">Text to place inside the comment.</param>
	public override void WriteComment(string text)
	{
		InternalWriteComment();
		_writer.Write("/*");
		_writer.Write(text);
		_writer.Write("*/");
	}

	/// <summary>
	///   Writes out the given white space.
	/// </summary>
	/// <param name="ws">The string of white space characters.</param>
	public override void WriteWhitespace(string ws)
	{
		InternalWriteWhitespace(ws);
		_writer.Write(ws);
	}

	private void EnsureWriteBuffer()
	{
		if (_writeBuffer == null)
		{
			_writeBuffer = BufferUtils.RentBuffer(_arrayPool, 35);
		}
	}

	private void WriteIntegerValue(long value)
	{
		if (value >= 0 && value <= 9)
		{
			_writer.Write((char)(48 + value));
			return;
		}
		ulong uvalue = (ulong)((value < 0) ? (-value) : value);
		if (value < 0)
		{
			_writer.Write('-');
		}
		WriteIntegerValue(uvalue);
	}

	private void WriteIntegerValue(ulong uvalue)
	{
		if (uvalue <= 9)
		{
			_writer.Write((char)(48 + uvalue));
			return;
		}
		EnsureWriteBuffer();
		int num = MathUtils.IntLength(uvalue);
		int num2 = 0;
		do
		{
			_writeBuffer[num - ++num2] = (char)(48 + uvalue % 10uL);
			uvalue /= 10uL;
		}
		while (uvalue != 0L);
		_writer.Write(_writeBuffer, 0, num2);
	}
}
