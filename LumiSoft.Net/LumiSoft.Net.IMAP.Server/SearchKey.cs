using System;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP.Server;

internal class SearchKey
{
	private string m_SearchKeyName = "";

	private object m_SearchKeyValue = null;

	public SearchKey(string searchKeyName, object value)
	{
		m_SearchKeyName = searchKeyName;
		m_SearchKeyValue = value;
	}

	public static SearchKey Parse(StringReader reader)
	{
		string text = "";
		object value = null;
		reader.ReadToFirstChar();
		string text2 = reader.ReadWord();
		if (text2 == null)
		{
			return null;
		}
		text2 = text2.ToUpper().Trim();
		reader.ReadToFirstChar();
		switch (text2)
		{
		case "ALL":
			text = "ALL";
			break;
		case "ANSWERED":
			text = "KEYWORD";
			value = "ANSWERED";
			break;
		case "BCC":
		{
			text = "HEADER";
			string text3 = ReadString(reader);
			if (text3 != null)
			{
				value = new string[2]
				{
					"BCC:",
					TextUtils.UnQuoteString(text3)
				};
				break;
			}
			throw new Exception("BCC <string> value is missing !");
		}
		case "BEFORE":
		{
			text = "BEFORE";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				try
				{
					value = IMAP_Utils.ParseDate(TextUtils.UnQuoteString(text3));
				}
				catch
				{
					throw new Exception("Invalid BEFORE <date> value '" + text3 + "', valid date syntax: {dd-MMM-yyyy} !");
				}
				break;
			}
			throw new Exception("BEFORE <date> value is missing !");
		}
		case "BODY":
		{
			text = "BODY";
			string text3 = ReadString(reader);
			if (text3 != null)
			{
				value = text3;
				break;
			}
			throw new Exception("BODY <string> value is missing !");
		}
		case "CC":
		{
			text = "HEADER";
			string text3 = ReadString(reader);
			if (text3 != null)
			{
				value = new string[2]
				{
					"CC:",
					TextUtils.UnQuoteString(text3)
				};
				break;
			}
			throw new Exception("CC <string> value is missing !");
		}
		case "DELETED":
			text = "KEYWORD";
			value = "DELETED";
			break;
		case "DRAFT":
			text = "KEYWORD";
			value = "DRAFT";
			break;
		case "FLAGGED":
			text = "KEYWORD";
			value = "FLAGGED";
			break;
		case "FROM":
		{
			text = "HEADER";
			string text3 = ReadString(reader);
			if (text3 != null)
			{
				value = new string[2]
				{
					"FROM:",
					TextUtils.UnQuoteString(text3)
				};
				break;
			}
			throw new Exception("FROM <string> value is missing !");
		}
		case "HEADER":
		{
			text = "HEADER";
			string text4 = ReadString(reader);
			if (text4 != null)
			{
				text4 = TextUtils.UnQuoteString(text4);
				string text3 = ReadString(reader);
				if (text3 != null)
				{
					value = new string[2]
					{
						text4,
						TextUtils.UnQuoteString(text3)
					};
					break;
				}
				throw new Exception("(HEADER <field-name>) <string> value is missing !");
			}
			throw new Exception("HEADER <field-name> value is missing !");
		}
		case "KEYWORD":
		{
			text = "KEYWORD";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				value = TextUtils.UnQuoteString(text3);
				break;
			}
			throw new Exception("KEYWORD <flag> value is missing !");
		}
		case "LARGER":
		{
			text = "LARGER";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				try
				{
					value = Convert.ToInt64(TextUtils.UnQuoteString(text3));
				}
				catch
				{
					throw new Exception("Invalid LARGER <n> value '" + text3 + "', it must be numeric value !");
				}
				break;
			}
			throw new Exception("LARGER <n> value is missing !");
		}
		case "NEW":
			text = "KEYWORD";
			value = "RECENT";
			break;
		case "NOT":
		{
			text = "NOT";
			object obj8 = SearchGroup.ParseSearchKey(reader);
			if (obj8 != null)
			{
				value = obj8;
				break;
			}
			throw new Exception("Required NOT <search-key> isn't specified !");
		}
		case "OLD":
			text = "UNKEYWORD";
			value = "RECENT";
			break;
		case "ON":
		{
			text = "ON";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				try
				{
					value = IMAP_Utils.ParseDate(TextUtils.UnQuoteString(text3));
				}
				catch
				{
					throw new Exception("Invalid ON <date> value '" + text3 + "', valid date syntax: {dd-MMM-yyyy} !");
				}
				break;
			}
			throw new Exception("ON <date> value is missing !");
		}
		case "OR":
		{
			text = "OR";
			object obj3 = SearchGroup.ParseSearchKey(reader);
			if (obj3 == null)
			{
				throw new Exception("Required OR <search-key1> isn't specified !");
			}
			object obj4 = SearchGroup.ParseSearchKey(reader);
			if (obj4 == null)
			{
				throw new Exception("Required (OR <search-key1>) <search-key2> isn't specified !");
			}
			value = new object[2] { obj3, obj4 };
			break;
		}
		case "RECENT":
			text = "KEYWORD";
			value = "RECENT";
			break;
		case "SEEN":
			text = "KEYWORD";
			value = "SEEN";
			break;
		case "SENTBEFORE":
		{
			text = "SENTBEFORE";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				try
				{
					value = IMAP_Utils.ParseDate(TextUtils.UnQuoteString(text3));
				}
				catch
				{
					throw new Exception("Invalid SENTBEFORE <date> value '" + text3 + "', valid date syntax: {dd-MMM-yyyy} !");
				}
				break;
			}
			throw new Exception("SENTBEFORE <date> value is missing !");
		}
		case "SENTON":
		{
			text = "SENTON";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				try
				{
					value = IMAP_Utils.ParseDate(TextUtils.UnQuoteString(text3));
				}
				catch
				{
					throw new Exception("Invalid SENTON <date> value '" + text3 + "', valid date syntax: {dd-MMM-yyyy} !");
				}
				break;
			}
			throw new Exception("SENTON <date> value is missing !");
		}
		case "SENTSINCE":
		{
			text = "SENTSINCE";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				try
				{
					value = IMAP_Utils.ParseDate(TextUtils.UnQuoteString(text3));
				}
				catch
				{
					throw new Exception("Invalid SENTSINCE <date> value '" + text3 + "', valid date syntax: {dd-MMM-yyyy} !");
				}
				break;
			}
			throw new Exception("SENTSINCE <date> value is missing !");
		}
		case "SINCE":
		{
			text = "SINCE";
			string text3 = reader.ReadWord();
			if (text3 != null)
			{
				try
				{
					value = IMAP_Utils.ParseDate(TextUtils.UnQuoteString(text3));
				}
				catch
				{
					throw new Exception("Invalid SINCE <date> value '" + text3 + "', valid date syntax: {dd-MMM-yyyy} !");
				}
				break;
			}
			throw new Exception("SINCE <date> value is missing !");
		}
		case "SMALLER":
		{
			text = "SMALLER";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				text3 = TextUtils.UnQuoteString(text3);
				try
				{
					value = Convert.ToInt64(text3);
				}
				catch
				{
					throw new Exception("Invalid SMALLER <n> value '" + text3 + "', it must be numeric value !");
				}
				break;
			}
			throw new Exception("SMALLER <n> value is missing !");
		}
		case "SUBJECT":
		{
			text = "HEADER";
			string text3 = ReadString(reader);
			if (text3 != null)
			{
				value = new string[2]
				{
					"SUBJECT:",
					TextUtils.UnQuoteString(text3)
				};
				break;
			}
			throw new Exception("SUBJECT <string> value is missing !");
		}
		case "TEXT":
		{
			text = "TEXT";
			string text3 = ReadString(reader);
			if (text3 != null)
			{
				value = text3;
				break;
			}
			throw new Exception("TEXT <string> value is missing !");
		}
		case "TO":
		{
			text = "HEADER";
			string text3 = ReadString(reader);
			if (text3 != null)
			{
				value = new string[2]
				{
					"TO:",
					TextUtils.UnQuoteString(text3)
				};
				break;
			}
			throw new Exception("TO <string> value is missing !");
		}
		case "UID":
		{
			text = "UID";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				try
				{
					IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
					iMAP_SequenceSet.Parse(TextUtils.UnQuoteString(text3));
					value = iMAP_SequenceSet;
				}
				catch
				{
					throw new Exception("Invalid UID <sequence-set> value '" + text3 + "' !");
				}
				break;
			}
			throw new Exception("UID <sequence-set> value is missing !");
		}
		case "UNANSWERED":
			text = "UNKEYWORD";
			value = "ANSWERED";
			break;
		case "UNDELETED":
			text = "UNKEYWORD";
			value = "DELETED";
			break;
		case "UNDRAFT":
			text = "UNKEYWORD";
			value = "DRAFT";
			break;
		case "UNFLAGGED":
			text = "UNKEYWORD";
			value = "FLAGGED";
			break;
		case "UNKEYWORD":
		{
			text = "UNKEYWORD";
			string text3 = reader.QuotedReadToDelimiter(' ');
			if (text3 != null)
			{
				value = TextUtils.UnQuoteString(text3);
				break;
			}
			throw new Exception("UNKEYWORD <flag> value is missing !");
		}
		case "UNSEEN":
			text = "UNKEYWORD";
			value = "SEEN";
			break;
		default:
			try
			{
				IMAP_SequenceSet iMAP_SequenceSet = new IMAP_SequenceSet();
				iMAP_SequenceSet.Parse(text2);
				text = "SEQUENCESET";
				value = iMAP_SequenceSet;
			}
			catch
			{
				throw new Exception("Invalid search key or <sequnce-set> value '" + text2 + "' !");
			}
			break;
		}
		return new SearchKey(text, value);
	}

	public bool IsHeaderNeeded()
	{
		if (m_SearchKeyName == "HEADER")
		{
			return true;
		}
		if (m_SearchKeyName == "NOT")
		{
			return SearchGroup.IsHeaderNeededForKey(m_SearchKeyValue);
		}
		if (m_SearchKeyName == "OR")
		{
			object searchKey = ((object[])m_SearchKeyValue)[0];
			object searchKey2 = ((object[])m_SearchKeyValue)[1];
			if (SearchGroup.IsHeaderNeededForKey(searchKey) || SearchGroup.IsHeaderNeededForKey(searchKey2))
			{
				return true;
			}
		}
		else
		{
			if (m_SearchKeyName == "SENTBEFORE")
			{
				return true;
			}
			if (m_SearchKeyName == "SENTON")
			{
				return true;
			}
			if (m_SearchKeyName == "SENTSINCE")
			{
				return true;
			}
			if (m_SearchKeyName == "TEXT")
			{
				return true;
			}
		}
		return false;
	}

	public bool IsBodyTextNeeded()
	{
		if (m_SearchKeyName == "BODY")
		{
			return true;
		}
		if (m_SearchKeyName == "NOT")
		{
			return SearchGroup.IsBodyTextNeededForKey(m_SearchKeyValue);
		}
		if (m_SearchKeyName == "OR")
		{
			object searchKey = ((object[])m_SearchKeyValue)[0];
			object searchKey2 = ((object[])m_SearchKeyValue)[1];
			if (SearchGroup.IsBodyTextNeededForKey(searchKey) || SearchGroup.IsBodyTextNeededForKey(searchKey2))
			{
				return true;
			}
		}
		else if (m_SearchKeyName == "TEXT")
		{
			return true;
		}
		return false;
	}

	public bool Match(int no, int uid, int size, DateTime internalDate, IMAP_MessageFlags flags, LumiSoft.Net.Mime.Mime mime, string bodyText)
	{
		if (m_SearchKeyName == "ALL")
		{
			return true;
		}
		if (m_SearchKeyName == "BEFORE")
		{
			if (internalDate.Date < (DateTime)m_SearchKeyValue)
			{
				return true;
			}
		}
		else if (m_SearchKeyName == "BODY")
		{
			string text = bodyText;
			if (text != null && text.ToLower().IndexOf(((string)m_SearchKeyValue).ToLower()) > -1)
			{
				return true;
			}
		}
		else if (m_SearchKeyName == "HEADER")
		{
			string[] array = (string[])m_SearchKeyValue;
			if (mime.MainEntity.Header.Contains(array[0]))
			{
				if (array[1].Length == 0)
				{
					return true;
				}
				if (mime.MainEntity.Header.GetFirst(array[0]).Value.ToLower().IndexOf(array[1].ToLower()) > -1)
				{
					return true;
				}
			}
		}
		else if (m_SearchKeyName == "KEYWORD")
		{
			if ((flags & IMAP_Utils.ParseMessageFlags((string)m_SearchKeyValue)) != 0)
			{
				return true;
			}
		}
		else if (m_SearchKeyName == "LARGER")
		{
			if (size > (long)m_SearchKeyValue)
			{
				return true;
			}
		}
		else
		{
			if (m_SearchKeyName == "NOT")
			{
				return !SearchGroup.Match_Key_Value(m_SearchKeyValue, no, uid, size, internalDate, flags, mime, bodyText);
			}
			if (m_SearchKeyName == "ON")
			{
				if (internalDate.Date == (DateTime)m_SearchKeyValue)
				{
					return true;
				}
			}
			else if (m_SearchKeyName == "OR")
			{
				object searchKey = ((object[])m_SearchKeyValue)[0];
				object searchKey2 = ((object[])m_SearchKeyValue)[1];
				if (SearchGroup.Match_Key_Value(searchKey, no, uid, size, internalDate, flags, mime, bodyText) || SearchGroup.Match_Key_Value(searchKey2, no, uid, size, internalDate, flags, mime, bodyText))
				{
					return true;
				}
			}
			else if (m_SearchKeyName == "SENTBEFORE")
			{
				if (mime.MainEntity.Date.Date < (DateTime)m_SearchKeyValue)
				{
					return true;
				}
			}
			else if (m_SearchKeyName == "SENTON")
			{
				if (mime.MainEntity.Date.Date == (DateTime)m_SearchKeyValue)
				{
					return true;
				}
			}
			else if (m_SearchKeyName == "SENTSINCE")
			{
				if (mime.MainEntity.Date.Date >= (DateTime)m_SearchKeyValue)
				{
					return true;
				}
			}
			else if (m_SearchKeyName == "SINCE")
			{
				if (internalDate.Date >= (DateTime)m_SearchKeyValue)
				{
					return true;
				}
			}
			else if (m_SearchKeyName == "SMALLER")
			{
				if (size < (long)m_SearchKeyValue)
				{
					return true;
				}
			}
			else if (m_SearchKeyName == "TEXT")
			{
				string text = bodyText;
				if (text != null && text.ToLower().IndexOf(((string)m_SearchKeyValue).ToLower()) > -1)
				{
					return true;
				}
				foreach (HeaderField item in mime.MainEntity.Header)
				{
					if (item.Value.ToLower().IndexOf(((string)m_SearchKeyValue).ToLower()) > -1)
					{
						return true;
					}
				}
			}
			else
			{
				if (m_SearchKeyName == "UID")
				{
					return ((IMAP_SequenceSet)m_SearchKeyValue).Contains(uid, long.MaxValue);
				}
				if (m_SearchKeyName == "UNKEYWORD")
				{
					if ((flags & IMAP_Utils.ParseMessageFlags((string)m_SearchKeyValue)) == 0)
					{
						return true;
					}
				}
				else if (m_SearchKeyName == "SEQUENCESET")
				{
					return ((IMAP_SequenceSet)m_SearchKeyValue).Contains(no, long.MaxValue);
				}
			}
		}
		return false;
	}

	private static string ReadString(StringReader reader)
	{
		reader.ReadToFirstChar();
		if (reader.StartsWith("{"))
		{
			reader.ReadSpecifiedLength("{".Length);
			int length = Convert.ToInt32(reader.QuotedReadToDelimiter('}'));
			return reader.ReadSpecifiedLength(length);
		}
		return TextUtils.UnQuoteString(reader.QuotedReadToDelimiter(' '));
	}
}
