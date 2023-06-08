namespace Oracle.DataAccess.Client;

public enum FailoverEvent
{
	End = 1,
	Abort = 2,
	Reauth = 4,
	Begin = 8,
	Error = 0x10
}
