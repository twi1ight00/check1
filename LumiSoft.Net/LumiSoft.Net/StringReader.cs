using System;
using System.Text;

namespace LumiSoft.Net;

public class StringReader
{
	private string m_OriginalString = "";

	private string m_SourceString = "";

	public long Available => m_SourceString.Length;

	public string OriginalString => m_OriginalString;

	public string SourceString => m_SourceString;

	public int Position => m_OriginalString.Length - m_SourceString.Length;

	public StringReader(string source)
	{
		m_OriginalString = source;
		m_SourceString = source;
	}

	public void AppenString(string str)
	{
		m_SourceString += str;
	}

	public void ReadToFirstChar()
	{
		m_SourceString = m_SourceString.TrimStart();
	}

	public string ReadSpecifiedLength(int length)
	{
		if (m_SourceString.Length >= length)
		{
			string result = m_SourceString.Substring(0, length);
			m_SourceString = m_SourceString.Substring(length);
			return result;
		}
		throw new Exception("Read length can't be bigger than source string !");
	}

	public string QuotedReadToDelimiter(char delimiter)
	{
		return QuotedReadToDelimiter(new char[1] { delimiter });
	}

	public string QuotedReadToDelimiter(char[] delimiters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		char c = '\0';
		for (int i = 0; i < m_SourceString.Length; i++)
		{
			char c2 = m_SourceString[i];
			if (c != '\\' && c2 == '"')
			{
				flag = !flag;
			}
			bool flag2 = false;
			foreach (char c3 in delimiters)
			{
				if (c2 == c3)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag && flag2)
			{
				string text = stringBuilder.ToString();
				m_SourceString = m_SourceString.Substring(text.Length + 1);
				return text;
			}
			stringBuilder.Append(c2);
			c = c2;
		}
		m_SourceString = "";
		return stringBuilder.ToString();
	}

	public string ReadWord()
	{
		return ReadWord(unQuote: true);
	}

	public string ReadWord(bool unQuote)
	{
		return ReadWord(unQuote, new char[11]
		{
			' ', '{', '}', '(', ')', '[', ']', '<', '>', '\r',
			'\n'
		}, removeWordTerminator: false);
	}

	public string ReadWord(bool unQuote, char[] wordTerminatorChars, bool removeWordTerminator)
	{
		ReadToFirstChar();
		if (Available == 0)
		{
			return null;
		}
		if (m_SourceString.StartsWith("\""))
		{
			if (unQuote)
			{
				return TextUtils.UnQuoteString(QuotedReadToDelimiter(wordTerminatorChars));
			}
			return QuotedReadToDelimiter(wordTerminatorChars);
		}
		int num = 0;
		for (int i = 0; i < m_SourceString.Length; i++)
		{
			char c = m_SourceString[i];
			bool flag = false;
			foreach (char c2 in wordTerminatorChars)
			{
				if (c == c2)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
			num++;
		}
		string result = m_SourceString.Substring(0, num);
		if (removeWordTerminator)
		{
			if (m_SourceString.Length >= num + 1)
			{
				m_SourceString = m_SourceString.Substring(num + 1);
			}
		}
		else
		{
			m_SourceString = m_SourceString.Substring(num);
		}
		return result;
	}

	public string ReadParenthesized()
	{
		char c = ' ';
		char c2 = ' ';
		if (m_SourceString.StartsWith("{"))
		{
			c = '{';
			c2 = '}';
		}
		else if (m_SourceString.StartsWith("("))
		{
			c = '(';
			c2 = ')';
		}
		else if (m_SourceString.StartsWith("["))
		{
			c = '[';
			c2 = ']';
		}
		else
		{
			if (!m_SourceString.StartsWith("<"))
			{
				throw new Exception("No parenthesized value '" + m_SourceString + "' !");
			}
			c = '<';
			c2 = '>';
		}
		bool flag = false;
		char c3 = '\0';
		int num = -1;
		int num2 = 0;
		for (int i = 1; i < m_SourceString.Length; i++)
		{
			if (c3 != '\\' && m_SourceString[i] == '"')
			{
				flag = !flag;
			}
			else if (!flag)
			{
				if (m_SourceString[i] == c)
				{
					num2++;
				}
				else if (m_SourceString[i] == c2)
				{
					if (num2 == 0)
					{
						num = i;
						break;
					}
					num2--;
				}
			}
			c3 = m_SourceString[i];
		}
		if (num == -1)
		{
			throw new Exception("There is no closing parenthesize for '" + m_SourceString + "' !");
		}
		string result = m_SourceString.Substring(1, num - 1);
		m_SourceString = m_SourceString.Substring(num + 1);
		return result;
	}

	public string ReadToEnd()
	{
		if (Available == 0)
		{
			return null;
		}
		string sourceString = m_SourceString;
		m_SourceString = "";
		return sourceString;
	}

	public bool StartsWith(string value)
	{
		return m_SourceString.StartsWith(value);
	}

	public bool StartsWith(string value, bool case_sensitive)
	{
		if (case_sensitive)
		{
			return m_SourceString.StartsWith(value);
		}
		return m_SourceString.ToLower().StartsWith(value.ToLower());
	}
}
