namespace LumiSoft.Net.IMAP.Server;

public enum IMAP_MessageItems_enum
{
	None = 0,
	Header = 2,
	Envelope = 4,
	BodyStructure = 8,
	Message = 0x10
}
