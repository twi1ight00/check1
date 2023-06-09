using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Security.Permissions;
using System.Text;
using System.Web;

namespace SolrNet.Utils;

[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
public sealed class HttpUtility
{
	private sealed class HttpQSCollection : NameValueCollection
	{
		public override string ToString()
		{
			int count = Count;
			if (count == 0)
			{
				return "";
			}
			StringBuilder sb = new StringBuilder();
			string[] keys = AllKeys;
			for (int i = 0; i < count; i++)
			{
				sb.AppendFormat("{0}={1}&", keys[i], base[keys[i]]);
			}
			if (sb.Length > 0)
			{
				sb.Length--;
			}
			return sb.ToString();
		}
	}

	public static void HtmlAttributeEncode(string s, TextWriter output)
	{
		if (output == null)
		{
			throw new NullReferenceException(".NET emulation");
		}
		output.Write(HttpEncoder.HtmlAttributeEncode(s));
	}

	public static string HtmlAttributeEncode(string s)
	{
		return HttpEncoder.HtmlAttributeEncode(s);
	}

	public static string UrlDecode(string str)
	{
		return UrlDecode(str, Encoding.UTF8);
	}

	private static char[] GetChars(MemoryStream b, Encoding e)
	{
		return e.GetChars(b.GetBuffer(), 0, (int)b.Length);
	}

	private static void WriteCharBytes(IList buf, char ch, Encoding e)
	{
		if (ch > 'ÿ')
		{
			byte[] bytes = e.GetBytes(new char[1] { ch });
			foreach (byte b in bytes)
			{
				buf.Add(b);
			}
		}
		else
		{
			buf.Add((byte)ch);
		}
	}

	public static string UrlDecode(string s, Encoding e)
	{
		if (null == s)
		{
			return null;
		}
		if (s.IndexOf('%') == -1 && s.IndexOf('+') == -1)
		{
			return s;
		}
		if (e == null)
		{
			e = Encoding.UTF8;
		}
		long len = s.Length;
		List<byte> bytes = new List<byte>();
		for (int i = 0; i < len; i++)
		{
			char ch = s[i];
			if (ch == '%' && i + 2 < len && s[i + 1] != '%')
			{
				int xchar;
				if (s[i + 1] == 'u' && i + 5 < len)
				{
					xchar = GetChar(s, i + 2, 4);
					if (xchar != -1)
					{
						WriteCharBytes(bytes, (char)xchar, e);
						i += 5;
					}
					else
					{
						WriteCharBytes(bytes, '%', e);
					}
				}
				else if ((xchar = GetChar(s, i + 1, 2)) != -1)
				{
					WriteCharBytes(bytes, (char)xchar, e);
					i += 2;
				}
				else
				{
					WriteCharBytes(bytes, '%', e);
				}
			}
			else if (ch == '+')
			{
				WriteCharBytes(bytes, ' ', e);
			}
			else
			{
				WriteCharBytes(bytes, ch, e);
			}
		}
		byte[] buf = bytes.ToArray();
		bytes = null;
		return e.GetString(buf);
	}

	public static string UrlDecode(byte[] bytes, Encoding e)
	{
		if (bytes == null)
		{
			return null;
		}
		return UrlDecode(bytes, 0, bytes.Length, e);
	}

	private static int GetInt(byte b)
	{
		char c = (char)b;
		if (c >= '0' && c <= '9')
		{
			return c - 48;
		}
		if (c >= 'a' && c <= 'f')
		{
			return c - 97 + 10;
		}
		if (c >= 'A' && c <= 'F')
		{
			return c - 65 + 10;
		}
		return -1;
	}

	private static int GetChar(byte[] bytes, int offset, int length)
	{
		int value = 0;
		int end = length + offset;
		for (int i = offset; i < end; i++)
		{
			int current = GetInt(bytes[i]);
			if (current == -1)
			{
				return -1;
			}
			value = (value << 4) + current;
		}
		return value;
	}

	private static int GetChar(string str, int offset, int length)
	{
		int val = 0;
		int end = length + offset;
		for (int i = offset; i < end; i++)
		{
			char c = str[i];
			if (c > '\u007f')
			{
				return -1;
			}
			int current = GetInt((byte)c);
			if (current == -1)
			{
				return -1;
			}
			val = (val << 4) + current;
		}
		return val;
	}

	public static string UrlDecode(byte[] bytes, int offset, int count, Encoding e)
	{
		if (bytes == null)
		{
			return null;
		}
		if (count == 0)
		{
			return string.Empty;
		}
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (offset < 0 || offset > bytes.Length)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count < 0 || offset + count > bytes.Length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		StringBuilder output = new StringBuilder();
		using (MemoryStream acc = new MemoryStream())
		{
			int end = count + offset;
			for (int i = offset; i < end; i++)
			{
				if (bytes[i] == 37 && i + 2 < count && bytes[i + 1] != 37)
				{
					int xchar;
					if (bytes[i + 1] == 117 && i + 5 < end)
					{
						if (acc.Length > 0)
						{
							output.Append(GetChars(acc, e));
							acc.SetLength(0L);
						}
						xchar = GetChar(bytes, i + 2, 4);
						if (xchar != -1)
						{
							output.Append((char)xchar);
							i += 5;
							continue;
						}
					}
					else if ((xchar = GetChar(bytes, i + 1, 2)) != -1)
					{
						acc.WriteByte((byte)xchar);
						i += 2;
						continue;
					}
				}
				if (acc.Length > 0)
				{
					output.Append(GetChars(acc, e));
					acc.SetLength(0L);
				}
				if (bytes[i] == 43)
				{
					output.Append(' ');
				}
				else
				{
					output.Append((char)bytes[i]);
				}
			}
			if (acc.Length > 0)
			{
				output.Append(GetChars(acc, e));
			}
		}
		return output.ToString();
	}

	public static byte[] UrlDecodeToBytes(byte[] bytes)
	{
		if (bytes == null)
		{
			return null;
		}
		return UrlDecodeToBytes(bytes, 0, bytes.Length);
	}

	public static byte[] UrlDecodeToBytes(string str)
	{
		return UrlDecodeToBytes(str, Encoding.UTF8);
	}

	public static byte[] UrlDecodeToBytes(string str, Encoding e)
	{
		if (str == null)
		{
			return null;
		}
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return UrlDecodeToBytes(e.GetBytes(str));
	}

	public static byte[] UrlDecodeToBytes(byte[] bytes, int offset, int count)
	{
		if (bytes == null)
		{
			return null;
		}
		if (count == 0)
		{
			return new byte[0];
		}
		int len = bytes.Length;
		if (offset < 0 || offset >= len)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count < 0 || offset > len - count)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		using MemoryStream result = new MemoryStream();
		int end = offset + count;
		for (int i = offset; i < end; i++)
		{
			char c = (char)bytes[i];
			switch (c)
			{
			case '+':
				c = ' ';
				break;
			case '%':
				if (i < end - 2)
				{
					int xchar = GetChar(bytes, i + 1, 2);
					if (xchar != -1)
					{
						c = (char)xchar;
						i += 2;
					}
				}
				break;
			}
			result.WriteByte((byte)c);
		}
		return result.ToArray();
	}

	public static string UrlEncode(string str)
	{
		return UrlEncode(str, Encoding.UTF8);
	}

	public static string UrlEncode(string s, Encoding Enc)
	{
		if (s == null)
		{
			return null;
		}
		if (s == string.Empty)
		{
			return string.Empty;
		}
		bool needEncode = false;
		int len = s.Length;
		for (int i = 0; i < len; i++)
		{
			char c = s[i];
			if ((c < '0' || (c < 'A' && c > '9') || (c > 'Z' && c < 'a') || c > 'z') && !HttpEncoder.NotEncoded(c))
			{
				needEncode = true;
				break;
			}
		}
		if (!needEncode)
		{
			return s;
		}
		byte[] bytes = new byte[Enc.GetMaxByteCount(s.Length)];
		int realLen = Enc.GetBytes(s, 0, s.Length, bytes, 0);
		return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes, 0, realLen));
	}

	public static string UrlEncode(byte[] bytes)
	{
		if (bytes == null)
		{
			return null;
		}
		if (bytes.Length == 0)
		{
			return string.Empty;
		}
		return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes, 0, bytes.Length));
	}

	public static string UrlEncode(byte[] bytes, int offset, int count)
	{
		if (bytes == null)
		{
			return null;
		}
		if (bytes.Length == 0)
		{
			return string.Empty;
		}
		return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes, offset, count));
	}

	public static byte[] UrlEncodeToBytes(string str)
	{
		return UrlEncodeToBytes(str, Encoding.UTF8);
	}

	public static byte[] UrlEncodeToBytes(string str, Encoding e)
	{
		if (str == null)
		{
			return null;
		}
		if (str.Length == 0)
		{
			return new byte[0];
		}
		byte[] bytes = e.GetBytes(str);
		return UrlEncodeToBytes(bytes, 0, bytes.Length);
	}

	public static byte[] UrlEncodeToBytes(byte[] bytes)
	{
		if (bytes == null)
		{
			return null;
		}
		if (bytes.Length == 0)
		{
			return new byte[0];
		}
		return UrlEncodeToBytes(bytes, 0, bytes.Length);
	}

	public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
	{
		if (bytes == null)
		{
			return null;
		}
		return HttpEncoder.UrlEncodeToBytes(bytes, offset, count);
	}

	public static string UrlEncodeUnicode(string str)
	{
		if (str == null)
		{
			return null;
		}
		return Encoding.ASCII.GetString(UrlEncodeUnicodeToBytes(str));
	}

	public static byte[] UrlEncodeUnicodeToBytes(string str)
	{
		if (str == null)
		{
			return null;
		}
		if (str.Length == 0)
		{
			return new byte[0];
		}
		using MemoryStream result = new MemoryStream(str.Length);
		foreach (char c in str)
		{
			HttpEncoder.UrlEncodeChar(c, result, isUnicode: true);
		}
		return result.ToArray();
	}

	/// <summary>
	/// Decodes an HTML-encoded string and returns the decoded string.
	/// </summary>
	/// <param name="s">The HTML string to decode. </param>
	/// <returns>The decoded text.</returns>
	public static string HtmlDecode(string s)
	{
		return HttpEncoder.HtmlDecode(s);
	}

	/// <summary>
	/// Decodes an HTML-encoded string and sends the resulting output to a TextWriter output stream.
	/// </summary>
	/// <param name="s">The HTML string to decode</param>
	/// <param name="output">The TextWriter output stream containing the decoded string. </param>
	public static void HtmlDecode(string s, TextWriter output)
	{
		if (output == null)
		{
			throw new NullReferenceException(".NET emulation");
		}
		if (!string.IsNullOrEmpty(s))
		{
			output.Write(HttpEncoder.HtmlDecode(s));
		}
	}

	public static string HtmlEncode(string s)
	{
		return HttpEncoder.HtmlEncode(s);
	}

	/// <summary>
	/// HTML-encodes a string and sends the resulting output to a TextWriter output stream.
	/// </summary>
	/// <param name="s">The string to encode. </param>
	/// <param name="output">The TextWriter output stream containing the encoded string. </param>
	public static void HtmlEncode(string s, TextWriter output)
	{
		if (output == null)
		{
			throw new NullReferenceException(".NET emulation");
		}
		if (!string.IsNullOrEmpty(s))
		{
			output.Write(HttpEncoder.HtmlEncode(s));
		}
	}

	public static string UrlPathEncode(string s)
	{
		return HttpEncoder.UrlPathEncode(s);
	}

	public static NameValueCollection ParseQueryString(string query)
	{
		return ParseQueryString(query, Encoding.UTF8);
	}

	public static NameValueCollection ParseQueryString(string query, Encoding encoding)
	{
		if (query == null)
		{
			throw new ArgumentNullException("query");
		}
		if (encoding == null)
		{
			throw new ArgumentNullException("encoding");
		}
		if (query.Length == 0 || (query.Length == 1 && query[0] == '?'))
		{
			return new NameValueCollection();
		}
		if (query[0] == '?')
		{
			query = query.Substring(1);
		}
		NameValueCollection result = new HttpQSCollection();
		ParseQueryString(query, encoding, result);
		return result;
	}

	internal static void ParseQueryString(string query, Encoding encoding, NameValueCollection result)
	{
		if (query.Length == 0)
		{
			return;
		}
		string decoded = HtmlDecode(query);
		int decodedLength = decoded.Length;
		int namePos = 0;
		bool first = true;
		while (namePos <= decodedLength)
		{
			int valuePos = -1;
			int valueEnd = -1;
			for (int q = namePos; q < decodedLength; q++)
			{
				if (valuePos == -1 && decoded[q] == '=')
				{
					valuePos = q + 1;
				}
				else if (decoded[q] == '&')
				{
					valueEnd = q;
					break;
				}
			}
			if (first)
			{
				first = false;
				if (decoded[namePos] == '?')
				{
					namePos++;
				}
			}
			string name;
			if (valuePos == -1)
			{
				name = null;
				valuePos = namePos;
			}
			else
			{
				name = UrlDecode(decoded.Substring(namePos, valuePos - namePos - 1), encoding);
			}
			if (valueEnd < 0)
			{
				namePos = -1;
				valueEnd = decoded.Length;
			}
			else
			{
				namePos = valueEnd + 1;
			}
			string value = UrlDecode(decoded.Substring(valuePos, valueEnd - valuePos), encoding);
			result.Add(name, value);
			if (namePos == -1)
			{
				break;
			}
		}
	}
}
