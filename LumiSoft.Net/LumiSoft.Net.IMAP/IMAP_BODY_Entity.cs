using System;
using System.Collections.Generic;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP;

public class IMAP_BODY_Entity
{
	private IMAP_BODY_Entity m_pParentEntity = null;

	private List<IMAP_BODY_Entity> m_pChildEntities = null;

	private MediaType_enum m_pContentType = MediaType_enum.Text_plain;

	private HeaderFieldParameter[] m_pContentTypeParams = null;

	private string m_ContentID = null;

	private string m_ContentDescription = null;

	private ContentTransferEncoding_enum m_ContentEncoding = ContentTransferEncoding_enum._7bit;

	private int m_ContentSize = 0;

	private IMAP_Envelope m_pEnvelope = null;

	private int m_ContentLines = 0;

	public IMAP_BODY_Entity ParentEntity => m_pParentEntity;

	public IMAP_BODY_Entity[] ChildEntities => m_pChildEntities.ToArray();

	public MediaType_enum ContentType => m_pContentType;

	public HeaderFieldParameter[] ContentType_Paramters => m_pContentTypeParams;

	public string ContentID => m_ContentID;

	public string ContentDescription => m_ContentDescription;

	public ContentTransferEncoding_enum ContentTransferEncoding => m_ContentEncoding;

	public int ContentSize
	{
		get
		{
			if ((ContentType & MediaType_enum.Multipart) != 0)
			{
				throw new Exception("NOTE: ContentSize property is available only for non-multipart contentype !");
			}
			return m_ContentSize;
		}
	}

	public IMAP_Envelope Envelope
	{
		get
		{
			if ((ContentType & MediaType_enum.Message) == 0)
			{
				throw new Exception("NOTE: Envelope property is available only for non-multipart contentype !");
			}
			return null;
		}
	}

	public int ContentLines
	{
		get
		{
			if ((ContentType & MediaType_enum.Text) == 0)
			{
				throw new Exception("NOTE: ContentLines property is available only for text/xxx content type !");
			}
			return m_ContentSize;
		}
	}

	internal IMAP_BODY_Entity()
	{
		m_pChildEntities = new List<IMAP_BODY_Entity>();
	}

	internal void Parse(string text)
	{
		StringReader stringReader = new StringReader(text);
		stringReader.ReadToFirstChar();
		string text2;
		if (stringReader.StartsWith("("))
		{
			while (stringReader.StartsWith("("))
			{
				IMAP_BODY_Entity iMAP_BODY_Entity = new IMAP_BODY_Entity();
				iMAP_BODY_Entity.Parse(stringReader.ReadParenthesized());
				iMAP_BODY_Entity.m_pParentEntity = this;
				m_pChildEntities.Add(iMAP_BODY_Entity);
				stringReader.ReadToFirstChar();
			}
			text2 = stringReader.ReadWord();
			m_pContentType = MimeUtils.ParseMediaType("multipart/" + text2);
			return;
		}
		string text3 = stringReader.ReadWord();
		text2 = stringReader.ReadWord();
		if (text3.ToUpper() != "NIL" && text2.ToUpper() != "NIL")
		{
			m_pContentType = MimeUtils.ParseMediaType(text3 + "/" + text2);
		}
		stringReader.ReadToFirstChar();
		string text4 = "NIL";
		if (stringReader.StartsWith("("))
		{
			text4 = stringReader.ReadParenthesized();
			StringReader stringReader2 = new StringReader(Core.CanonicalDecode(text4));
			List<HeaderFieldParameter> list = new List<HeaderFieldParameter>();
			while (stringReader2.Available > 0)
			{
				string parameterName = stringReader2.ReadWord();
				string parameterValue = stringReader2.ReadWord();
				list.Add(new HeaderFieldParameter(parameterName, parameterValue));
			}
			m_pContentTypeParams = list.ToArray();
		}
		else
		{
			stringReader.ReadWord();
		}
		string text5 = stringReader.ReadWord();
		if (text5.ToUpper() != "NIL")
		{
			m_ContentID = text5;
		}
		string text6 = stringReader.ReadWord();
		if (text6.ToUpper() != "NIL")
		{
			m_ContentDescription = text6;
		}
		string text7 = stringReader.ReadWord();
		if (text7.ToUpper() != "NIL")
		{
			m_ContentEncoding = MimeUtils.ParseContentTransferEncoding(text7);
		}
		string text8 = stringReader.ReadWord();
		if (text8.ToUpper() != "NIL")
		{
			m_ContentSize = Convert.ToInt32(text8);
		}
		if (ContentType == MediaType_enum.Message_rfc822)
		{
			stringReader.ReadToFirstChar();
			if (stringReader.StartsWith("("))
			{
				m_pEnvelope = new IMAP_Envelope();
				m_pEnvelope.Parse(stringReader.ReadParenthesized());
			}
			else
			{
				stringReader.ReadWord();
			}
		}
		if (text3.ToLower() == "text")
		{
			string text9 = stringReader.ReadWord();
			if (text9.ToUpper() != "NIL")
			{
				m_ContentLines = Convert.ToInt32(text9);
			}
		}
	}
}
