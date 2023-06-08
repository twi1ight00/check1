using System;
using System.Globalization;
using LumiSoft.Net.Mime;

namespace LumiSoft.Net.IMAP.Server;

public class IMAP_Utils
{
	public static IMAP_MessageFlags ParseMessageFlags(string flagsString)
	{
		IMAP_MessageFlags iMAP_MessageFlags = (IMAP_MessageFlags)0;
		flagsString = flagsString.ToUpper();
		if (flagsString.IndexOf("ANSWERED") > -1)
		{
			iMAP_MessageFlags |= IMAP_MessageFlags.Answered;
		}
		if (flagsString.IndexOf("FLAGGED") > -1)
		{
			iMAP_MessageFlags |= IMAP_MessageFlags.Flagged;
		}
		if (flagsString.IndexOf("DELETED") > -1)
		{
			iMAP_MessageFlags |= IMAP_MessageFlags.Deleted;
		}
		if (flagsString.IndexOf("SEEN") > -1)
		{
			iMAP_MessageFlags |= IMAP_MessageFlags.Seen;
		}
		if (flagsString.IndexOf("DRAFT") > -1)
		{
			iMAP_MessageFlags |= IMAP_MessageFlags.Draft;
		}
		return iMAP_MessageFlags;
	}

	public static string MessageFlagsToString(IMAP_MessageFlags msgFlags)
	{
		string text = "";
		if ((IMAP_MessageFlags.Answered & msgFlags) != 0)
		{
			text += " \\ANSWERED";
		}
		if ((IMAP_MessageFlags.Flagged & msgFlags) != 0)
		{
			text += " \\FLAGGED";
		}
		if ((IMAP_MessageFlags.Deleted & msgFlags) != 0)
		{
			text += " \\DELETED";
		}
		if ((IMAP_MessageFlags.Seen & msgFlags) != 0)
		{
			text += " \\SEEN";
		}
		if ((IMAP_MessageFlags.Draft & msgFlags) != 0)
		{
			text += " \\DRAFT";
		}
		return text.Trim();
	}

	public static string ACL_to_String(IMAP_ACL_Flags flags)
	{
		string text = "";
		if ((flags & IMAP_ACL_Flags.l) != 0)
		{
			text += "l";
		}
		if ((flags & IMAP_ACL_Flags.r) != 0)
		{
			text += "r";
		}
		if ((flags & IMAP_ACL_Flags.s) != 0)
		{
			text += "s";
		}
		if ((flags & IMAP_ACL_Flags.w) != 0)
		{
			text += "w";
		}
		if ((flags & IMAP_ACL_Flags.i) != 0)
		{
			text += "i";
		}
		if ((flags & IMAP_ACL_Flags.p) != 0)
		{
			text += "p";
		}
		if ((flags & IMAP_ACL_Flags.c) != 0)
		{
			text += "c";
		}
		if ((flags & IMAP_ACL_Flags.d) != 0)
		{
			text += "d";
		}
		if ((flags & IMAP_ACL_Flags.a) != 0)
		{
			text += "a";
		}
		return text;
	}

	public static IMAP_ACL_Flags ACL_From_String(string aclString)
	{
		IMAP_ACL_Flags iMAP_ACL_Flags = IMAP_ACL_Flags.None;
		aclString = aclString.ToLower();
		if (aclString.IndexOf('l') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.l;
		}
		if (aclString.IndexOf('r') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.r;
		}
		if (aclString.IndexOf('s') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.s;
		}
		if (aclString.IndexOf('w') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.w;
		}
		if (aclString.IndexOf('i') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.i;
		}
		if (aclString.IndexOf('p') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.p;
		}
		if (aclString.IndexOf('c') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.c;
		}
		if (aclString.IndexOf('d') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.d;
		}
		if (aclString.IndexOf('a') > -1)
		{
			iMAP_ACL_Flags |= IMAP_ACL_Flags.a;
		}
		return iMAP_ACL_Flags;
	}

	public static DateTime ParseDate(string date)
	{
		return MimeUtils.ParseDate(date);
	}

	public static string DateTimeToString(DateTime date)
	{
		string text = "";
		text += date.ToString("dd-MMM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
		return text + " " + date.ToString("zzz", CultureInfo.InvariantCulture).Replace(":", "");
	}

	public static string NormalizeFolder(string folder)
	{
		folder = folder.Replace("\\", "/");
		if (folder.StartsWith("/"))
		{
			folder = folder.Substring(1);
		}
		if (folder.EndsWith("/"))
		{
			folder = folder.Substring(0, folder.Length - 1);
		}
		return folder;
	}

	public static string ParseQuotedParam(ref string argsText)
	{
		string text = "";
		if (argsText.StartsWith("\""))
		{
			char c = ' ';
			int num = -1;
			for (int i = 1; i < argsText.Length; i++)
			{
				if (argsText[i] == '"' && c != '\\')
				{
					num = i;
					break;
				}
				c = argsText[i];
			}
			if (num == -1)
			{
				throw new Exception("qouted-string doesn't have enclosing quote(\")");
			}
			text = argsText.Substring(1, num - 1).Replace("\\\"", "\"");
			argsText = argsText.Substring(num + 1).Trim();
		}
		else
		{
			text = argsText.Split(' ')[0];
			argsText = argsText.Substring(text.Length).Trim();
		}
		return text;
	}

	public static string ParseBracketParam(ref string argsText)
	{
		string text = "";
		if (argsText.StartsWith("("))
		{
			char c = ' ';
			int num = -1;
			int num2 = 0;
			for (int i = 1; i < argsText.Length; i++)
			{
				if (argsText[i] == '(')
				{
					num2++;
				}
				else if (argsText[i] == ')')
				{
					if (num2 == 0)
					{
						num = i;
						break;
					}
					num2--;
				}
				c = argsText[i];
			}
			if (num == -1)
			{
				throw new Exception("bracket doesn't have enclosing bracket ')'");
			}
			text = argsText.Substring(1, num - 1);
			argsText = argsText.Substring(num + 1).Trim();
		}
		else
		{
			text = argsText;
			argsText = "";
		}
		return text;
	}
}
