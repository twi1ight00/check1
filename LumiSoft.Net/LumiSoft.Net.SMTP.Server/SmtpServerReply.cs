using System;

namespace LumiSoft.Net.SMTP.Server;

public class SmtpServerReply
{
	private bool m_ErrorReply = false;

	private int m_SmtpReplyCode = -1;

	private string m_ReplyText = "";

	public bool ErrorReply
	{
		get
		{
			return m_ErrorReply;
		}
		set
		{
			m_ErrorReply = value;
		}
	}

	public int SmtpReplyCode
	{
		get
		{
			return m_SmtpReplyCode;
		}
		set
		{
			m_SmtpReplyCode = value;
		}
	}

	public string ReplyText
	{
		get
		{
			return m_ReplyText;
		}
		set
		{
			if (!Core.IsAscii(value))
			{
				throw new Exception("Reply text can contian only ASCII chars !");
			}
			if (value.Length > 500)
			{
				value = value.Substring(0, 500);
			}
			value = value.Replace("\r", "").Replace("\n", "");
			m_ReplyText = value;
		}
	}

	internal string ToSmtpReply(string defaultSmtpRelyCode, string defaultReplyText)
	{
		string text = "";
		text = ((SmtpReplyCode != -1) ? (SmtpReplyCode + " ") : (defaultSmtpRelyCode + " "));
		if (ReplyText == "")
		{
			return text + defaultReplyText;
		}
		return text + ReplyText;
	}
}
