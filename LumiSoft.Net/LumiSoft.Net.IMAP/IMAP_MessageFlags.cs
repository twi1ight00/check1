namespace LumiSoft.Net.IMAP;

public enum IMAP_MessageFlags
{
	Seen = 2,
	Answered = 4,
	Flagged = 8,
	Deleted = 0x10,
	Draft = 0x20,
	Recent = 0x40
}
