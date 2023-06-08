namespace LumiSoft.Net.SMTP.Client;

public enum SMTP_ErrorType
{
	ConnectionError = 1,
	InvalidEmailAddress = 2,
	NotSupported = 4,
	NotAuthenticated = 5,
	UnKnown = 256
}
