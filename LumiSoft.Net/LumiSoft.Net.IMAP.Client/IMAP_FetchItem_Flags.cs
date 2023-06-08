namespace LumiSoft.Net.IMAP.Client;

public enum IMAP_FetchItem_Flags
{
	UID = 1,
	Size = 2,
	InternalDate = 4,
	MessageFlags = 8,
	Header = 16,
	Message = 32,
	Envelope = 64,
	BodyStructure = 128,
	All = 65535
}
