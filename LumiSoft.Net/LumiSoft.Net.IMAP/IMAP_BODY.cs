using System.Collections.Generic;
using System.IO;
using System.Text;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP;

public class IMAP_BODY
{
	private IMAP_BODY_Entity m_pMainEntity = null;

	public IMAP_BODY_Entity MainEntity => m_pMainEntity;

	public IMAP_BODY_Entity[] Entities
	{
		get
		{
			List<IMAP_BODY_Entity> list = new List<IMAP_BODY_Entity>();
			list.Add(m_pMainEntity);
			GetEntities(m_pMainEntity.ChildEntities, list);
			return list.ToArray();
		}
	}

	public IMAP_BODY_Entity[] Attachmnets
	{
		get
		{
			List<IMAP_BODY_Entity> list = new List<IMAP_BODY_Entity>();
			IMAP_BODY_Entity[] entities = Entities;
			IMAP_BODY_Entity[] array = entities;
			foreach (IMAP_BODY_Entity iMAP_BODY_Entity in array)
			{
				HeaderFieldParameter[] contentType_Paramters = iMAP_BODY_Entity.ContentType_Paramters;
				foreach (HeaderFieldParameter headerFieldParameter in contentType_Paramters)
				{
					if (headerFieldParameter.Name.ToLower() == "name")
					{
						list.Add(iMAP_BODY_Entity);
						break;
					}
				}
			}
			return list.ToArray();
		}
	}

	public static string ConstructBodyStructure(LumiSoft.Net.Mime.Mime mime, bool bodystructure)
	{
		if (bodystructure)
		{
			return "BODYSTRUCTURE " + ConstructParts(mime.MainEntity, bodystructure);
		}
		return "BODY " + ConstructParts(mime.MainEntity, bodystructure);
	}

	private static string ConstructParts(MimeEntity entity, bool bodystructure)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if ((entity.ContentType & MediaType_enum.Multipart) != 0)
		{
			stringBuilder.Append("(");
			foreach (MimeEntity childEntity in entity.ChildEntities)
			{
				stringBuilder.Append(ConstructParts(childEntity, bodystructure));
			}
			string text = entity.ContentTypeString.Split(';')[0];
			if (text.Split('/').Length == 2)
			{
				stringBuilder.Append(" \"" + text.Split('/')[1].Replace(";", "") + "\"");
			}
			else
			{
				stringBuilder.Append(" NIL");
			}
			stringBuilder.Append(")");
		}
		else
		{
			stringBuilder.Append("(");
			if (entity.ContentTypeString != null)
			{
				string text = entity.ContentTypeString.Split(';')[0];
				if (text.Split('/').Length == 2)
				{
					stringBuilder.Append("\"" + entity.ContentTypeString.Split('/')[0] + "\"");
				}
				else
				{
					stringBuilder.Append(" NIL");
				}
			}
			else
			{
				stringBuilder.Append(" NIL");
			}
			if (entity.ContentTypeString != null)
			{
				string text = entity.ContentTypeString.Split(';')[0];
				if (text.Split('/').Length == 2)
				{
					stringBuilder.Append(" \"" + text.Split('/')[1].Replace(";", "") + "\"");
				}
				else
				{
					stringBuilder.Append(" NIL");
				}
			}
			else
			{
				stringBuilder.Append(" NIL");
			}
			if (entity.ContentTypeString != null)
			{
				ParametizedHeaderField parametizedHeaderField = new ParametizedHeaderField(entity.Header.GetFirst("Content-Type:"));
				if (parametizedHeaderField.Parameters.Count > 0)
				{
					stringBuilder.Append(" (");
					bool flag = true;
					foreach (HeaderFieldParameter parameter in parametizedHeaderField.Parameters)
					{
						if (!flag)
						{
							stringBuilder.Append(" ");
						}
						else
						{
							flag = false;
						}
						stringBuilder.Append("\"" + parameter.Name + "\" \"" + MimeUtils.EncodeHeaderField(parameter.Value) + "\"");
					}
					stringBuilder.Append(")");
				}
				else
				{
					stringBuilder.Append(" NIL");
				}
			}
			else
			{
				stringBuilder.Append(" NIL");
			}
			string contentID = entity.ContentID;
			if (contentID != null)
			{
				stringBuilder.Append(" \"" + MimeUtils.EncodeHeaderField(contentID) + "\"");
			}
			else
			{
				stringBuilder.Append(" NIL");
			}
			string contentDescription = entity.ContentDescription;
			if (contentDescription != null)
			{
				stringBuilder.Append(" \"" + MimeUtils.EncodeHeaderField(contentDescription) + "\"");
			}
			else
			{
				stringBuilder.Append(" NIL");
			}
			HeaderField first = entity.Header.GetFirst("Content-Transfer-Encoding:");
			if (first != null)
			{
				stringBuilder.Append(" \"" + MimeUtils.EncodeHeaderField(first.Value) + "\"");
			}
			else
			{
				stringBuilder.Append(" \"7bit\"");
			}
			if (entity.DataEncoded != null)
			{
				stringBuilder.Append(" " + entity.DataEncoded.Length);
			}
			else
			{
				stringBuilder.Append(" 0");
			}
			if ((entity.ContentType & MediaType_enum.Message_rfc822) != 0)
			{
				stringBuilder.Append(" " + IMAP_Envelope.ConstructEnvelope(entity));
			}
			if ((entity.ContentType & MediaType_enum.Text) != 0)
			{
				if (entity.DataEncoded != null)
				{
					long num = 0L;
					StreamLineReader streamLineReader = new StreamLineReader(new MemoryStream(entity.DataEncoded));
					for (byte[] array = streamLineReader.ReadLine(); array != null; array = streamLineReader.ReadLine())
					{
						num++;
					}
					stringBuilder.Append(" " + num);
				}
				else
				{
					stringBuilder.Append(" 0");
				}
			}
			stringBuilder.Append(")");
		}
		return stringBuilder.ToString();
	}

	public void Parse(string bodyStructureString)
	{
		m_pMainEntity = new IMAP_BODY_Entity();
		m_pMainEntity.Parse(bodyStructureString);
	}

	private void GetEntities(IMAP_BODY_Entity[] entities, List<IMAP_BODY_Entity> allEntries)
	{
		if (entities == null)
		{
			return;
		}
		foreach (IMAP_BODY_Entity iMAP_BODY_Entity in entities)
		{
			allEntries.Add(iMAP_BODY_Entity);
			if (iMAP_BODY_Entity.ChildEntities.Length > 0)
			{
				GetEntities(iMAP_BODY_Entity.ChildEntities, allEntries);
			}
		}
	}
}
