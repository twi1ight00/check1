using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LumiSoft.Net.Mime;

public class Mime
{
	private MimeEntity m_pMainEntity = null;

	public MimeEntity MainEntity => m_pMainEntity;

	public MimeEntity[] MimeEntities
	{
		get
		{
			List<MimeEntity> list = new List<MimeEntity>();
			list.Add(m_pMainEntity);
			GetEntities(m_pMainEntity.ChildEntities, list);
			return list.ToArray();
		}
	}

	public MimeEntity[] Attachments
	{
		get
		{
			List<MimeEntity> list = new List<MimeEntity>();
			MimeEntity[] mimeEntities = MimeEntities;
			MimeEntity[] array = mimeEntities;
			foreach (MimeEntity mimeEntity in array)
			{
				if (mimeEntity.ContentDisposition == ContentDisposition_enum.Attachment)
				{
					list.Add(mimeEntity);
				}
				else if (mimeEntity.ContentType_Name != null)
				{
					list.Add(mimeEntity);
				}
				else if (mimeEntity.ContentDisposition_FileName != null)
				{
					list.Add(mimeEntity);
				}
			}
			return list.ToArray();
		}
	}

	public string BodyText
	{
		get
		{
			if (MainEntity.ContentType == MediaType_enum.NotSpecified)
			{
				if (MainEntity.DataEncoded != null)
				{
					return Encoding.ASCII.GetString(MainEntity.Data);
				}
			}
			else
			{
				MimeEntity[] mimeEntities = MimeEntities;
				MimeEntity[] array = mimeEntities;
				foreach (MimeEntity mimeEntity in array)
				{
					if (mimeEntity.ContentType == MediaType_enum.Text_plain)
					{
						return mimeEntity.DataText;
					}
				}
			}
			return null;
		}
	}

	public string BodyHtml
	{
		get
		{
			MimeEntity[] mimeEntities = MimeEntities;
			MimeEntity[] array = mimeEntities;
			foreach (MimeEntity mimeEntity in array)
			{
				if (mimeEntity.ContentType == MediaType_enum.Text_html)
				{
					return mimeEntity.DataText;
				}
			}
			return null;
		}
	}

	public Mime()
	{
		m_pMainEntity = new MimeEntity();
		m_pMainEntity.MessageID = MimeUtils.CreateMessageID();
		m_pMainEntity.Date = DateTime.Now;
		m_pMainEntity.MimeVersion = "1.0";
	}

	public static Mime Parse(byte[] data)
	{
		using MemoryStream stream = new MemoryStream(data);
		return Parse(stream);
	}

	public static Mime Parse(string fileName)
	{
		using FileStream stream = File.OpenRead(fileName);
		return Parse(stream);
	}

	public static Mime Parse(Stream stream)
	{
		Mime mime = new Mime();
		mime.MainEntity.Parse(stream, null);
		return mime;
	}

	public static Mime CreateSimple(AddressList from, AddressList to, string subject, string bodyText, string bodyHtml)
	{
		return CreateSimple(from, to, subject, bodyText, bodyHtml, null);
	}

	public static Mime CreateSimple(AddressList from, AddressList to, string subject, string bodyText, string bodyHtml, string[] attachmentFileNames)
	{
		Mime mime = new Mime();
		MimeEntity mainEntity = mime.MainEntity;
		mainEntity.From = from;
		mainEntity.To = to;
		mainEntity.Subject = subject;
		if (attachmentFileNames == null || attachmentFileNames.Length == 0)
		{
			if (bodyText != null && bodyHtml != null)
			{
				mainEntity.ContentType = MediaType_enum.Multipart_alternative;
				MimeEntity mimeEntity = mainEntity.ChildEntities.Add();
				mimeEntity.ContentType = MediaType_enum.Text_plain;
				mimeEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
				mimeEntity.DataText = bodyText;
				MimeEntity mimeEntity2 = mainEntity.ChildEntities.Add();
				mimeEntity2.ContentType = MediaType_enum.Text_html;
				mimeEntity2.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
				mimeEntity2.DataText = bodyHtml;
			}
			else if (bodyText != null)
			{
				MimeEntity mimeEntity = mainEntity;
				mimeEntity.ContentType = MediaType_enum.Text_plain;
				mimeEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
				mimeEntity.DataText = bodyText;
			}
			else if (bodyHtml != null)
			{
				MimeEntity mimeEntity2 = mainEntity;
				mimeEntity2.ContentType = MediaType_enum.Text_html;
				mimeEntity2.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
				mimeEntity2.DataText = bodyHtml;
			}
		}
		else
		{
			mainEntity.ContentType = MediaType_enum.Multipart_mixed;
			if (bodyText != null && bodyHtml != null)
			{
				MimeEntity mimeEntity3 = mainEntity.ChildEntities.Add();
				mimeEntity3.ContentType = MediaType_enum.Multipart_alternative;
				MimeEntity mimeEntity = mimeEntity3.ChildEntities.Add();
				mimeEntity.ContentType = MediaType_enum.Text_plain;
				mimeEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
				mimeEntity.DataText = bodyText;
				MimeEntity mimeEntity2 = mimeEntity3.ChildEntities.Add();
				mimeEntity2.ContentType = MediaType_enum.Text_html;
				mimeEntity2.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
				mimeEntity2.DataText = bodyHtml;
			}
			else if (bodyText != null)
			{
				MimeEntity mimeEntity = mainEntity.ChildEntities.Add();
				mimeEntity.ContentType = MediaType_enum.Text_plain;
				mimeEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
				mimeEntity.DataText = bodyText;
			}
			else if (bodyHtml != null)
			{
				MimeEntity mimeEntity2 = mainEntity.ChildEntities.Add();
				mimeEntity2.ContentType = MediaType_enum.Text_html;
				mimeEntity2.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
				mimeEntity2.DataText = bodyHtml;
			}
			foreach (string text in attachmentFileNames)
			{
				MimeEntity mimeEntity4 = mainEntity.ChildEntities.Add();
				mimeEntity4.ContentType = MediaType_enum.Application_octet_stream;
				mimeEntity4.ContentDisposition = ContentDisposition_enum.Attachment;
				mimeEntity4.ContentTransferEncoding = ContentTransferEncoding_enum.Base64;
				mimeEntity4.ContentDisposition_FileName = Core.GetFileNameFromPath(text);
				mimeEntity4.DataFromFile(text);
			}
		}
		return mime;
	}

	public string ToStringData()
	{
		return Encoding.Default.GetString(ToByteData());
	}

	public byte[] ToByteData()
	{
		using MemoryStream memoryStream = new MemoryStream();
		ToStream(memoryStream);
		return memoryStream.ToArray();
	}

	public void ToFile(string fileName)
	{
		using FileStream storeStream = File.Create(fileName);
		ToStream(storeStream);
	}

	public void ToStream(Stream storeStream)
	{
		m_pMainEntity.ToStream(storeStream);
	}

	private void GetEntities(MimeEntityCollection entities, List<MimeEntity> allEntries)
	{
		if (entities == null)
		{
			return;
		}
		foreach (MimeEntity entity in entities)
		{
			allEntries.Add(entity);
			if (entity.ChildEntities.Count > 0)
			{
				GetEntities(entity.ChildEntities, allEntries);
			}
		}
	}
}
