namespace Oracle.DataAccess.Client;

public enum OracleNotificationInfo
{
	Insert = 1,
	Delete = 0x10,
	Update = 0x20,
	Startup = 0x40,
	Shutdown = 0x80,
	Shutdown_any = 0x100,
	Alter = 0x200,
	Drop = 0x400,
	End = 0x800,
	Error = 0x1000
}
