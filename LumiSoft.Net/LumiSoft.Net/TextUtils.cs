using System.Collections;
using System.Text;

namespace LumiSoft.Net;

public class TextUtils
{
	public static string QuoteString(string text)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in text)
		{
			switch (c)
			{
			case '\\':
				stringBuilder.Append("\\\\");
				break;
			case '"':
				stringBuilder.Append("\\\"");
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		return "\"" + stringBuilder.ToString() + "\"";
	}

	public static string UnQuoteString(string text)
	{
		StringBuilder stringBuilder = new StringBuilder();
		text = text.Trim();
		if (text.StartsWith("\""))
		{
			text = text.Substring(1);
		}
		if (text.EndsWith("\""))
		{
			text = text.Substring(0, text.Length - 1);
		}
		bool flag = false;
		foreach (char c in text)
		{
			if (!flag && c == '\\')
			{
				flag = true;
			}
			else if (flag)
			{
				stringBuilder.Append(c);
				flag = false;
			}
			else
			{
				stringBuilder.Append(c);
				flag = false;
			}
		}
		return stringBuilder.ToString();
	}

	public static string[] SplitQuotedString(string text, char splitChar)
	{
		ArrayList arrayList = new ArrayList();
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		foreach (char c in text)
		{
			if (c == '"')
			{
				flag = !flag;
			}
			if (!flag && c == splitChar)
			{
				arrayList.Add(stringBuilder.ToString());
				stringBuilder = new StringBuilder();
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		arrayList.Add(stringBuilder.ToString());
		string[] array = new string[arrayList.Count];
		for (int j = 0; j < arrayList.Count; j++)
		{
			array[j] = (string)arrayList[j];
		}
		return array;
	}

	public static int QuotedIndexOf(string text, char indexChar)
	{
		int result = -1;
		bool flag = false;
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			if (c == '"')
			{
				flag = !flag;
			}
			if (!flag && c == indexChar)
			{
				return i;
			}
		}
		return result;
	}

	public static string[] SplitString(string text, char splitChar)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int length = text.Length;
		for (int i = 0; i < length; i++)
		{
			if (text[i] == splitChar)
			{
				arrayList.Add(text.Substring(num, i - num));
				num = i + 1;
			}
		}
		if (num <= length)
		{
			arrayList.Add(text.Substring(num));
		}
		string[] array = new string[arrayList.Count];
		arrayList.CopyTo(array, 0);
		return array;
	}
}
