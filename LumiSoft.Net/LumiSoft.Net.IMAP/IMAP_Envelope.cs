using System;
using System.Collections;
using System.Text;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP;

public class IMAP_Envelope
{
	private DateTime m_Date = DateTime.MinValue;

	private string m_Subject = null;

	private MailboxAddress[] m_From = null;

	private MailboxAddress m_Sender = null;

	private MailboxAddress[] m_ReplyTo = null;

	private MailboxAddress[] m_To = null;

	private MailboxAddress[] m_Cc = null;

	private MailboxAddress[] m_Bcc = null;

	private string m_InReplyTo = null;

	private string m_MessageID = null;

	public DateTime Date => m_Date;

	public string Subject => m_Subject;

	public MailboxAddress[] From => m_From;

	public MailboxAddress Sender => m_Sender;

	public MailboxAddress[] ReplyTo => m_ReplyTo;

	public MailboxAddress[] To => m_To;

	public MailboxAddress[] Cc => m_Cc;

	public MailboxAddress[] Bcc => m_Bcc;

	public string InReplyTo => m_InReplyTo;

	public string MessageID => m_MessageID;

	public static string ConstructEnvelope(MimeEntity entity)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("(");
		if (entity.Header.Contains("Date:"))
		{
			stringBuilder.Append(TextUtils.QuoteString(MimeUtils.DateTimeToRfc2822(entity.Date)));
		}
		else
		{
			stringBuilder.Append("NIL");
		}
		if (entity.Subject != null)
		{
			stringBuilder.Append(" " + TextUtils.QuoteString(MimeUtils.EncodeHeaderField(entity.Subject)));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		if (entity.From != null && entity.From.Count > 0)
		{
			stringBuilder.Append(" " + ConstructAddresses(entity.From));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		if (entity.Sender != null)
		{
			stringBuilder.Append(" (");
			stringBuilder.Append(ConstructAddress(entity.Sender));
			stringBuilder.Append(")");
		}
		else if (entity.From != null)
		{
			stringBuilder.Append(" " + ConstructAddresses(entity.From));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		if (entity.ReplyTo != null)
		{
			stringBuilder.Append(" " + ConstructAddresses(entity.ReplyTo));
		}
		else if (entity.From != null)
		{
			stringBuilder.Append(" " + ConstructAddresses(entity.From));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		if (entity.To != null && entity.To.Count > 0)
		{
			stringBuilder.Append(" " + ConstructAddresses(entity.To));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		if (entity.Cc != null && entity.Cc.Count > 0)
		{
			stringBuilder.Append(" " + ConstructAddresses(entity.Cc));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		if (entity.Bcc != null && entity.Bcc.Count > 0)
		{
			stringBuilder.Append(" " + ConstructAddresses(entity.Bcc));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		if (entity.InReplyTo != null)
		{
			stringBuilder.Append(" " + TextUtils.QuoteString(MimeUtils.EncodeHeaderField(entity.InReplyTo)));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		if (entity.MessageID != null)
		{
			stringBuilder.Append(" " + TextUtils.QuoteString(MimeUtils.EncodeHeaderField(entity.MessageID)));
		}
		else
		{
			stringBuilder.Append(" NIL");
		}
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}

	public void Parse(string envelopeString)
	{
		if (envelopeString.StartsWith("("))
		{
			envelopeString = envelopeString.Substring(1);
		}
		if (envelopeString.EndsWith(")"))
		{
			envelopeString = envelopeString.Substring(0, envelopeString.Length - 1);
		}
		string text = "";
		StringReader stringReader = new StringReader(envelopeString);
		text = stringReader.ReadWord();
		if (text == null)
		{
			throw new Exception("Invalid IMAP ENVELOPE structure !");
		}
		if (text.ToUpper() == "NIL")
		{
			m_Date = DateTime.MinValue;
		}
		else
		{
			try
			{
				m_Date = MimeUtils.ParseDate(text);
			}
			catch
			{
				m_Date = DateTime.MinValue;
			}
		}
		text = stringReader.ReadWord();
		if (text == null)
		{
			throw new Exception("Invalid IMAP ENVELOPE structure !");
		}
		if (text.ToUpper() == "NIL")
		{
			m_Subject = null;
		}
		else
		{
			m_Subject = Core.CanonicalDecode(text);
		}
		m_From = ParseAddresses(stringReader);
		MailboxAddress[] array = ParseAddresses(stringReader);
		if (array != null && array.Length > 0)
		{
			m_Sender = array[0];
		}
		else
		{
			m_Sender = null;
		}
		m_ReplyTo = ParseAddresses(stringReader);
		m_To = ParseAddresses(stringReader);
		m_Cc = ParseAddresses(stringReader);
		m_Bcc = ParseAddresses(stringReader);
		stringReader.ReadToFirstChar();
		text = stringReader.ReadWord();
		if (text == null)
		{
			throw new Exception("Invalid IMAP ENVELOPE structure !");
		}
		if (text.ToUpper() == "NIL")
		{
			m_InReplyTo = null;
		}
		else
		{
			m_InReplyTo = text;
		}
		stringReader.ReadToFirstChar();
		text = stringReader.ReadWord();
		if (text == null)
		{
			throw new Exception("Invalid IMAP ENVELOPE structure !");
		}
		if (text.ToUpper() == "NIL")
		{
			m_MessageID = null;
		}
		else
		{
			m_MessageID = text;
		}
	}

	private MailboxAddress[] ParseAddresses(StringReader r)
	{
		r.ReadToFirstChar();
		if (r.StartsWith("NIL", case_sensitive: false))
		{
			r.ReadSpecifiedLength("NIL".Length);
			return null;
		}
		r.ReadToFirstChar();
		if (!r.StartsWith("("))
		{
			throw new Exception("Invalid IMAP ENVELOPE structure !");
		}
		string text = r.ReadParenthesized();
		ArrayList arrayList = new ArrayList();
		StringReader stringReader = new StringReader(text.Trim());
		while (stringReader.StartsWith("("))
		{
			arrayList.Add(ParseAddress(stringReader.ReadParenthesized()));
			stringReader.ReadToFirstChar();
		}
		MailboxAddress[] array = new MailboxAddress[arrayList.Count];
		arrayList.CopyTo(array);
		return array;
	}

	private MailboxAddress ParseAddress(string addressString)
	{
		StringReader stringReader = new StringReader(addressString.Trim());
		string displayName = "";
		string text = "";
		if (stringReader.StartsWith("NIL", case_sensitive: false))
		{
			stringReader.ReadSpecifiedLength("NIL".Length);
		}
		else
		{
			displayName = Core.CanonicalDecode(stringReader.ReadWord());
		}
		stringReader.ReadWord();
		if (stringReader.StartsWith("NIL", case_sensitive: false))
		{
			stringReader.ReadSpecifiedLength("NIL".Length);
		}
		else
		{
			text = stringReader.ReadWord() + "@";
		}
		if (stringReader.StartsWith("NIL", case_sensitive: false))
		{
			stringReader.ReadSpecifiedLength("NIL".Length);
		}
		else
		{
			text += stringReader.ReadWord();
		}
		return new MailboxAddress(displayName, text);
	}

	private static string ConstructAddresses(AddressList addressList)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("(");
		MailboxAddress[] mailboxes = addressList.Mailboxes;
		foreach (MailboxAddress address in mailboxes)
		{
			stringBuilder.Append(ConstructAddress(address));
		}
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}

	private static string ConstructAddress(MailboxAddress address)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("(");
		stringBuilder.Append(TextUtils.QuoteString(MimeUtils.EncodeHeaderField(address.DisplayName)));
		stringBuilder.Append(" NIL");
		stringBuilder.Append(" " + TextUtils.QuoteString(MimeUtils.EncodeHeaderField(address.LocalPart)));
		stringBuilder.Append(" " + TextUtils.QuoteString(MimeUtils.EncodeHeaderField(address.Domain)));
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}
}
