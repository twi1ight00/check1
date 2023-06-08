using System;
using System.IO;
using System.Text;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP.Server;

internal class FetchHelper
{
	public static byte[] ParseHeaderFields(string fieldsStr, MimeEntity entity)
	{
		return ParseHeaderFields(fieldsStr, Encoding.Default.GetBytes(entity.HeaderString));
	}

	public static byte[] ParseHeaderFields(string fieldsStr, byte[] data)
	{
		fieldsStr = fieldsStr.Trim();
		if (fieldsStr.StartsWith("("))
		{
			fieldsStr = fieldsStr.Substring(1, fieldsStr.Length - 1);
		}
		if (fieldsStr.EndsWith(")"))
		{
			fieldsStr = fieldsStr.Substring(0, fieldsStr.Length - 1);
		}
		string text = "";
		string[] array = fieldsStr.Split(' ');
		using (MemoryStream stream = new MemoryStream(data))
		{
			TextReader textReader = new StreamReader(stream);
			string text2 = textReader.ReadLine();
			bool flag = false;
			while (text2 != null && text2.Length != 0)
			{
				if (flag && text2.StartsWith("\t"))
				{
					text = text + text2 + "\r\n";
				}
				else
				{
					flag = false;
					string[] array2 = array;
					foreach (string text3 in array2)
					{
						if (text2.Trim().ToLower().StartsWith(text3.Trim().ToLower()))
						{
							text = text + text2 + "\r\n";
							flag = true;
						}
					}
				}
				text2 = textReader.ReadLine();
			}
		}
		text += "\r\n";
		return Encoding.ASCII.GetBytes(text);
	}

	public static byte[] ParseHeaderFieldsNot(string fieldsStr, MimeEntity entity)
	{
		return ParseHeaderFieldsNot(fieldsStr, Encoding.Default.GetBytes(entity.HeaderString));
	}

	public static byte[] ParseHeaderFieldsNot(string fieldsStr, byte[] data)
	{
		fieldsStr = fieldsStr.Trim();
		if (fieldsStr.StartsWith("("))
		{
			fieldsStr = fieldsStr.Substring(1, fieldsStr.Length - 1);
		}
		if (fieldsStr.EndsWith(")"))
		{
			fieldsStr = fieldsStr.Substring(0, fieldsStr.Length - 1);
		}
		string text = "";
		string[] array = fieldsStr.Split(' ');
		using (MemoryStream stream = new MemoryStream(data))
		{
			TextReader textReader = new StreamReader(stream);
			string text2 = textReader.ReadLine();
			bool flag = false;
			while (text2 != null && text2.Length != 0)
			{
				if (flag && text2.StartsWith("\t"))
				{
					text = text + text2 + "\r\n";
				}
				else
				{
					flag = false;
					string[] array2 = array;
					foreach (string text3 in array2)
					{
						if (text2.Trim().ToLower().StartsWith(text3.Trim().ToLower()))
						{
							flag = true;
						}
					}
					if (!flag)
					{
						text = text + text2 + "\r\n";
					}
				}
				text2 = textReader.ReadLine();
			}
		}
		return Encoding.ASCII.GetBytes(text);
	}

	public static MimeEntity GetMimeEntity(LumiSoft.Net.Mime.Mime parser, string mimeEntitySpecifier)
	{
		if ((parser.MainEntity.ContentType & MediaType_enum.Multipart) == 0)
		{
			if (mimeEntitySpecifier.Length == 1 && Convert.ToInt32(mimeEntitySpecifier) == 1)
			{
				return parser.MainEntity;
			}
			return null;
		}
		MimeEntity mimeEntity = parser.MainEntity;
		string[] array = mimeEntitySpecifier.Split('.');
		string[] array2 = array;
		foreach (string value in array2)
		{
			int num = Convert.ToInt32(value) - 1;
			if (num > -1 && num < mimeEntity.ChildEntities.Count)
			{
				mimeEntity = mimeEntity.ChildEntities[num];
				continue;
			}
			return null;
		}
		return mimeEntity;
	}

	public static byte[] GetMimeEntityHeader(MimeEntity entity)
	{
		return Encoding.ASCII.GetBytes(entity.HeaderString + "\r\n");
	}

	public static byte[] GetMimeEntityHeader(LumiSoft.Net.Mime.Mime parser, string mimeEntitySpecifier)
	{
		MimeEntity mimeEntity = GetMimeEntity(parser, mimeEntitySpecifier);
		if (mimeEntity != null)
		{
			return GetMimeEntityHeader(mimeEntity);
		}
		return null;
	}

	public static byte[] GetMimeEntityData(LumiSoft.Net.Mime.Mime parser, string mimeEntitySpecifier)
	{
		return GetMimeEntity(parser, mimeEntitySpecifier)?.DataEncoded;
	}

	private static string Escape(string text)
	{
		text = text.Replace("\\", "\\\\");
		text = text.Replace("\"", "\\\"");
		return text;
	}
}
